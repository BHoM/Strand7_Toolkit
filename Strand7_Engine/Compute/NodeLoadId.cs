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

using BH.oM.Adapter.Strand7;
using BH.oM.Structure.Results;
using St7API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.Strand7
{
    public static partial class Compute
    {
        public static bool St7SetNodeLoad_Id(int loadCase, int nodeId, oM.Geometry.Vector force, oM.Geometry.Vector moment, bool active = false)
        {
            if (!active) return false;
            int err;
            int uID = 1;

            double[] forces = new double[3];
            double[] moments = new double[3];
            forces[0] = force.X;
            forces[1] = force.Y;
            forces[2] = force.Z;
            moments[0] = moment.X;
            moments[1] = moment.Y;
            moments[2] = moment.Z;
            err = St7.St7SetNodeForce3(uID, nodeId, loadCase, forces);
            if (!St7ErrorCustom(err, "Couldn't set point load for a loadcase " + loadCase + " node " + nodeId)) return false;
            err = St7.St7SetNodeMoment3(uID, nodeId, loadCase, moments);
            if (!St7ErrorCustom(err, "Couldn't set point load for a loadcase " + loadCase + " node " + nodeId)) return false;
            return true;
        }
    }
}

