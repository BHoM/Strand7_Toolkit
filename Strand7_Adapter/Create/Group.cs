/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Adapter.Strand7;
using BH.oM.Base;
using BH.oM.Structure.Elements;
using St7API;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool CreateObject(St7Group<IBHoMObject> groupToStrand)
        {
            // reading groups is not implemented
            int err = 0;
            int groupID = 0;
            int uID = 1;          
            int parentGroup = 1;

            err = St7.St7NewChildGroup(uID, parentGroup, groupToStrand.Name, ref groupID);
            if (!St7Error(err)) return false;
            SetAdapterId(groupToStrand, groupID);           
            foreach (IBHoMObject bhObject in groupToStrand.Elements)
            {
                err =  addElementToGroup(uID, groupID, bhObject as dynamic);
                if (!St7Error(err)) return false;
            }
            return true;
        }
        private int addElementToGroup(int uID, int groupID, Bar bar)
        {
            return St7.St7SetEntityGroup(uID, St7.tyBEAM, GetAdapterId<int>(bar), groupID);
        }
        private int addElementToGroup(int uID, int groupID, St7RigidMPLink link)
        {
            return St7.St7SetEntityGroup(uID, St7.tyLINK, GetAdapterId<int>(link), groupID);
        }
        private int addElementToGroup(int uID, int groupID, FEMesh feMesh)
        {
            int err = 0;
            foreach (FEMeshFace fEMeshFace in feMesh.Faces)
            {
                int plateId = GetAdapterId<int>(fEMeshFace);
                err = St7.St7SetEntityGroup(uID, St7.tyPLATE, plateId, groupID);
                if (!St7Error(err)) return err;
            }              
            return 0;
        }
        /***************************************************/
    }
}
