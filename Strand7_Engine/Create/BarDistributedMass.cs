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

using BH.oM.Adapter.Strand7;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Structure.Elements;
using BH.oM.Structure.Loads;
using BH.oM.Base.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.Strand7.Create
{
    public static partial class Create
    {
        public static BarDistributedMass BarDistributedMass(Loadcase loadcase, BHoMGroup<Bar> group, double distFromA = 0, double massA = 0, double distFromB = 0, double massB = 0, string name = "")
        {
            if (massA == 0 && massB == 0)
                throw new ArgumentException("Bar distributed mass requires either the mass at A or/and B to be defined");

            return new BarDistributedMass
            {
                Loadcase = loadcase,
                Objects = group,
                DistanceFromA = distFromA,
                DistanceFromB = distFromB,
                MassA = massA,
                MassB = massB,
                Name = name
            };
        }
        /***************************************************/
        public static BarDistributedMass BarDistributedMass(Loadcase loadcase, IEnumerable<Bar> objects, double distFromA = 0, double massA = 0, double distFromB = 0, double massB = 0, string name = "")
        {
            return BarDistributedMass(loadcase, new BHoMGroup<Bar>() { Elements = objects.ToList() }, distFromA, massA, distFromB, massB, name);
        }
     
    }
}


