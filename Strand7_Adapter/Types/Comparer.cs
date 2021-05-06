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

using BH.Engine.Base.Objects;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Constraints;
using System;
using System.Collections.Generic;
using BH.oM.Structure.Loads;
using BH.oM.Structure.MaterialFragments;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        /***************************************************/
        /**** BHoM Adapter Interface                    ****/
        /***************************************************/

        protected void SetupComparers()
        {
            AdapterComparers = new Dictionary<Type, object>
            {
            {typeof(Node), new BH.Engine.Structure.NodeDistanceComparer(3) },   //The 3 in here sets how many decimal places to look at for node merging. 3 decimal places gives mm precision 
            {typeof(ISectionProperty), new BHoMObjectNameOrToStringComparer() },
            {typeof(ConcreteSection), new BHoMObjectNameOrToStringComparer() },
            {typeof(SteelSection), new BHoMObjectNameOrToStringComparer() },
            {typeof(Loadcase), new BHoMObjectNameComparer() },
            {typeof(LoadCombination), new BHoMObjectNameComparer() },
            {typeof(Bar), new BH.Engine.Structure.BarEndNodesDistanceComparer(3) },
            {typeof(IMaterialFragment), new BHoMObjectNameComparer() },
            {typeof(LinkConstraint), new BHoMObjectNameComparer() },
            {typeof(ISurfaceProperty), new BHoMObjectNameComparer() },
           };
        }


        /***************************************************/
    }
}