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

using BH.Engine.Geometry;
using BH.oM.Adapter.Strand7;
using BH.oM.Geometry.CoordinateSystem;
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
        public static CoordSystems St7GetUCSs(bool active = false)
        {        
            if (!active) return new CoordSystems(false, new List<Cartesian>());
            int err;
            int uID = 1;
            int num_UCS = 0;
            err = St7.St7GetNumUCS(uID, ref num_UCS);
            if (!St7Error(err)) return new CoordSystems(false, new List<Cartesian>());
            int UCSType = St7.csCartesian;
            List<Cartesian> UCSs = new List<Cartesian>();
            for (int i = 1; i <= num_UCS; i++)
            {
                double[] UCSDoubles_current = new double[9];
                int current_id = 0;
                err = St7.St7GetUCSID(uID, i, ref current_id);
                err = St7.St7GetUCS(uID, current_id, ref UCSType, UCSDoubles_current);
                oM.Geometry.Point origin = Geometry.Create.Point(UCSDoubles_current[0], UCSDoubles_current[1], UCSDoubles_current[2]);
                oM.Geometry.Vector x = Geometry.Create.Point(UCSDoubles_current[3], UCSDoubles_current[4], UCSDoubles_current[5]) - origin;
                oM.Geometry.Vector y = Geometry.Create.Point(UCSDoubles_current[6], UCSDoubles_current[7], UCSDoubles_current[8]) - origin;
                Cartesian cs = Geometry.Create.CartesianCoordinateSystem(origin, x, y);
                UCSs.Add(cs);
                if (!St7Error(err)) return new CoordSystems(false, new List<Cartesian>());
            }
            return new CoordSystems(true, UCSs);
        }
        public class CoordSystems
        {
            public bool Success { get; set; }           
            public List<Cartesian> UCSs { get; set; }
            public CoordSystems(bool success, List<Cartesian> ucss)
            {
                Success = success;
                UCSs = ucss;
            }
        }
    }
}
