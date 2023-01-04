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

using BH.Engine.Base.Objects;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Structure.Constraints;
using System;
using System.Collections.Generic;
using BH.oM.Structure.Loads;
using BH.oM.Base;
using BH.oM.Adapter.Strand7;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        /***************************************************/
        /**** BHoM Adapter Interface                    ****/
        /***************************************************/
                       
        protected void SetupDependencies()
        {
            DependencyTypes = new Dictionary<Type, List<Type>>
            {
            {typeof(Bar), new List<Type> { typeof(ISectionProperty), typeof(Node) } },
            //
            //{typeof(St7RigidMPLink), new List<Type> {typeof(Node) } },
            //{typeof(PointLoad), new List<Type> { typeof(BHoMGroup<Node>), typeof(Loadcase) }  },
            //   {typeof(PointLoad), new List<Type> { typeof(Loadcase) }  },
            //{typeof(BarUniformlyDistributedLoad), new List<Type> { typeof(BHoMGroup<Bar>), typeof(Loadcase) } },
            //{typeof(BarDistributedMass), new List<Type> { typeof(BHoMGroup<Bar>), typeof(Loadcase) } },
            //{typeof(BarVaryingDistributedLoad), new List<Type> { typeof(BHoMGroup<Bar>), typeof(Loadcase) } },
            //{typeof(BarPointLoad), new List<Type> { typeof(BHoMGroup<Bar>), typeof(Loadcase) } },
            //{typeof(BarPreLoad), new List<Type> { typeof(BHoMGroup<Bar>), typeof(Loadcase) } },
            //{typeof(AreaUniformlyDistributedLoad), new List<Type> { typeof(Loadcase) } },
            //{typeof(RigidLink), new List<Type> { typeof(LinkConstraint), typeof(Node) } },
            //
            {typeof(FEMesh), new List<Type> { typeof(ISurfaceProperty), typeof(Node) } },  
            {typeof(Panel), new List<Type> { typeof(ISurfaceProperty) } }
           };
        }
        /***************************************************/
    }
}

