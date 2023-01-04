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

using BH.oM.Base;
using BH.oM.Structure.Loads;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Adapter.Strand7
{
    [Description("Nonlinear load case class to set up combination of factored Loadcases with increments.")]
    public class St7NLLoadCAse : BHoMObject, ICase
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("The factored Loadcases that make up the nonlinear load case. Stored as a collection of Tuple<double,ICase> where the double is the factor the case should be scaled by in this nonlinear load case.")]
        public List<Tuple<double, ICase>> LoadCases { get; set; } = new List<Tuple<double, ICase>>();

        [Description("Unique numeric identifier of the LoadCombination.")]
        public int Number { get; set; } = 0;
        //public int Increments { get; set; } = 1;

        /***************************************************/
    }
}

