/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Structure.Elements;
using BH.oM.Structure.Constraints;
using St7API;
using BH.oM.Structure.Loads;
using BH.oM.Geometry;
using BH.oM.Geometry.CoordinateSystem;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {             
        private List<ILoad> ReadGravityLoad(List<Loadcase> loadcases)
        {
            int err = 0;
            List<ILoad> bhLoads = new List<ILoad>();
            foreach (Loadcase ldcs in loadcases)
            {
                if (ldcs.Nature == LoadNature.Dead)
                {
                    int dir = 0;
                    double x = 0, y = 0, z = 0;
                    err = St7.St7GetLoadCaseGravityDir(1, GetAdapterId<int>(ldcs), ref dir);
                    if (!St7ErrorCustom(err, "Could not get a direction for gravity lc #" + GetAdapterId<int>(ldcs))) return bhLoads;
                    if (dir == 1) x = -1;
                    if (dir == 2) y = -1;
                    if (dir == 3) z = -1;
                    Vector vector = BH.Engine.Geometry.Create.Vector(x, y, z);
                    bhLoads.Add(BH.Engine.Structure.Create.GravityLoad(ldcs, vector, new BHoMObject[] { }));
                }
            }
            return bhLoads;
        }         
    }
}


