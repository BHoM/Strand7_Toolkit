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
using BH.oM.Geometry;
using BH.oM.Structure.Loads;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Adapter.Strand7
{
    [Description("Gravity options for loadcases to apply inertia, specify direction, include structural and non-structural masses.")]
    public class St7LoadCaseInertia : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        [Description("The Loadcase in which the load is applied.")]
        public Loadcase Loadcase { get; set; }
        [Description("The magnitude and direction of gravity. This will be scaled by the gravity constant g in the analysis, which means a load representing gravity should be a Vector with 1 as its Z-component.")]
        public Vector GravityDirection { get; set; } = new Vector { X = 0, Y = 0, Z = 1 };
        [Description("Apply inertia to Structural mass?")]
        public bool StructuralMass { get; set; }
        [Description("Apply inertia to Non-Structural mass?")]
        public bool NonStructuralMass { get; set; }


        /***************************************************/
    }
}

