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

using BH.oM.Adapter.Strand7;
using BH.oM.Geometry;
using BH.oM.Base;
using BH.oM.Dimensional;
using BH.oM.Structure.Elements;
using BH.oM.Structure.Loads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry.CoordinateSystem;
using BH.oM.Structure.Constraints;
using System.ComponentModel;
using BH.oM.Base.Attributes;

namespace BH.Engine.Strand7.Create
{
    public static partial class Create
    {

        [Description("Created a Node from a Cartesian coordinate system. The position of the Node will be the Orgin, and the Orientation of the node will match the axes of the Coordinate system.")]
        [Input("coordinates", "The Cartesian coordinate system to control the position and orientation of the Node.")]
        [Input("name", "The name of the created Node.")]
        [InputFromProperty("support")]
        [Output("node", "The created structural Node.")]
        public static Node Node(Cartesian coordinates, int freedomeCase, string name = "", Constraint6DOF support = null)
        {
            Node nd = new Node();
            nd.Position = coordinates.Origin;
            nd.Orientation = (Basis)coordinates;
            nd.Name = name;
            nd.CustomData["Freedom"] = freedomeCase;
            nd.Support = support;
            return nd;
        }
    }
}

