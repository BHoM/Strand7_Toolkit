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
using BH.oM.Structure.Results;
using BH.oM.Analytical.Results;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        private IEnumerable<IResult> GetGlobalResults(Type type, IList cases)
        {           
            //if (typeof(ModalDynamics).IsAssignableFrom(type))
            //    return GetFrequencies(cases);

            return new List<IResult>();

        }
        private IEnumerable<IResult> GetObjectResults(Type type, IList ids = null, IList cases = null, int divisions = 5)
        {
            IEnumerable<IResult> results = new List<IResult>();

            if (typeof(NodeResult).IsAssignableFrom(type))
                results = GetNodeResults(type, ids, cases);
            //else if (typeof(BarResult).IsAssignableFrom(type))
            //    results = GetBarResults(type, ids, cases, divisions);
            //else if (typeof(MeshElementResult).IsAssignableFrom(type))
            //    results = GetMeshResults(type, ids, cases, divisions);
            //else
            //    return new List<IResult>();

            return results;
        }

    }
}
