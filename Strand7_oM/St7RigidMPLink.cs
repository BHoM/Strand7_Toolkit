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
using BH.oM.Structure.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Adapter.Strand7
{
    [Description("A rigid link object defining rigid constraints between two or more nodes.")]
    public class St7RigidMPLink : BHoMObject
    {
        [Description("Master node to which slave nodes are constrained.")]
        public Node MasterNode { get; set; } = new Node();

        [Description("List of slave nodes which are constrained to the master node.")]
        public List<Node> SlaveNodes { get; set; } = new List<Node>();
        public int UCS { get; set; } = 1;

        public St7UCSPlane UCSPlane { get; set; } = St7UCSPlane.XYZ;
    }
}

