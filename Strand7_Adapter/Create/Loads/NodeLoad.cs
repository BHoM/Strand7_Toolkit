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
using BH.oM.Structure.Loads;
using St7API;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/
      
        private bool CreateObject(PointLoad pointLoad)
        {
            int err = 0;
            int loadCaseId = GetAdapterId<int>(pointLoad);        
            double[] forces = new double[3];
            double[] moments = new double[3];
            forces[0] = pointLoad.Force.X;
            forces[1] = pointLoad.Force.Y;
            forces[2] = pointLoad.Force.Z;
            moments[0] = pointLoad.Moment.X;
            moments[1] = pointLoad.Moment.Y;
            moments[2] = pointLoad.Moment.Z;
            foreach (Node node in pointLoad.Objects.Elements)
            {
                int nodeId = GetAdapterId<int>(node);               
                err = St7.St7SetNodeForce3(1, nodeId, loadCaseId, forces);
                if (!St7ErrorCustom(err, "Couldn't set point load for a loadcase " + loadCaseId + " node " + nodeId)) return false;
                err = St7.St7SetNodeMoment3(1, nodeId, loadCaseId, moments);
                if (!St7ErrorCustom(err, "Couldn't set point load for a loadcase " + loadCaseId + " node " + nodeId)) return false;
            }

            return true;
        }     
        /***************************************************/
    }
}

