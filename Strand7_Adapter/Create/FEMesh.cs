/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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
using BH.oM.Geometry;
using BH.oM.Structure.Elements;
using St7API;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool CreateObject(FEMesh fEMesh)
        {
            int uID = 1;
            int err = 0;
            int meshId = GetAdapterId<int>(fEMesh);
            int platePropId = GetAdapterId<int>(fEMesh.Property);

            // geometry          
            List<int> nodesIds = fEMesh.Nodes.Select(nd => GetAdapterId<int>(nd)).ToList();
            bool refresh = true;
            foreach (FEMeshFace fEMeshFace in fEMesh.Faces)
            {
                int plateId = (int)NextFreeId(typeof(FEMeshFace), refresh);
                refresh = false;
                SetAdapterId(fEMeshFace, plateId);             
                int[] connectionNodes = new int[fEMeshFace.NodeListIndices.Count + 1];
                connectionNodes[0] = fEMeshFace.NodeListIndices.Count;                
                for (int i = 0; i < fEMeshFace.NodeListIndices.Count; i++)
                {
                    connectionNodes[i + 1] = nodesIds[fEMeshFace.NodeListIndices[i]];
                }
                err = St7.St7SetElementConnection(uID, St7.tyPLATE, plateId, platePropId, connectionNodes);
            }
            return true;
        }

     
        /***************************************************/

    }
}

