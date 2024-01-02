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

using BH.oM.Base;
using BH.oM.Structure.Elements;
using BH.oM.Structure.Loads;
using BH.oM.Dimensional;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Geometry;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Adapter.Strand7
{
    [Description("Varying distributed mass for bar elements. Can be used to apply non-structural mass per unit length.")]
    public class BarDistributedMass : BHoMObject, IElementLoad<Bar>
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
      
        [Description("Distance along the bar between the start node and the start of the loaded region.")]
        public double DistanceFromA { get; set; } = 0;

       
        [Description("Magnitude of the mass at the start of the loaded region.")]
        public double MassA { get; set; } = 0;

      
        [Description("Distance along the bar between the end node and the end of the loaded region.")]
        public double DistanceFromB { get; set; } = 0;

      
        [Description("Magnitude of the mass at the end of the loaded region.")]
        public double MassB { get; set; } = 0;

      
        [Description("Offset of the distrubuted mass.")]
        public Vector Offset { get; set; } = new Vector();

        [Description("Dynamic Factor in Strand7.")]
        public double DynamicFactor { get; set; } = 1.0;

        [Description("The Loadcase in which the load is applied.")]
        public virtual Loadcase Loadcase { get; set; }

        [Description("The group of Bars that the load should be applied to. For most analysis packages the objects added here need to be pulled from the analysis package before being assigned to the load.")]
        public virtual BHoMGroup<Bar> Objects { get; set; } = new BHoMGroup<Bar>();

        [Description("Defines whether the load is applied in local or global coordinates.")]
        public virtual LoadAxis Axis { get; set; } = LoadAxis.Global;

        [Description("If true the load is projected to the element. This means that the load will be reduced when its direction is at an angle to the element.")]
        public virtual bool Projected { get; set; } = false;
        /***************************************************/
    }
}


