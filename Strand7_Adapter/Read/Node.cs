/*
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        //The List<string> in the methods below can be changed to a list of any type of identification more suitable for the toolkit
        //If no ids are provided, the convention is to return all elements of the type

        private List<Node> ReadNodes(List<string> ids = null)
        {

            int err = 0;
            int nodeCount = 0;
            List<Node> nodes = new List<Node>();
            double[] XYZ = new double[3];

            err = St7.St7GetTotal(1, St7.tyNODE, ref nodeCount);
            if (!St7Error(err)) return nodes;
            for (int nn = 0; nn < nodeCount; nn++)
            {
                int nodeId = nn + 1;
                // getting node coordinates
                err = St7.St7GetNodeXYZ(1, nodeId, XYZ);
                if (!St7ErrorCustom(err, "Could not get a position of node: " + nodeId.ToString())) continue;
                // getting node restraints
                // !!! LOCAL RESTRAINTS ARE NOT IMPLEMENTED !!!! read UCS and write it to Orientation property in Node
                int ucsId = 1;
                int[] restraints = new int[6];
                double[] enforcedDispls = new double[6];
                List<bool> bhFixed = new List<bool>();
                err = St7.St7GetNodeRestraint6(1, nodeId, 1, ref ucsId, restraints, enforcedDispls);                    
                bhFixed = restraints.Select(rst => rst == St7.btTrue).ToList();
                double[] translationStiff = new double[3];
                err = St7.St7GetNodeKTranslation3F(1, nodeId, 1, ref ucsId, translationStiff);               
                double[] rotationStiff = new double[3];
                err = St7.St7GetNodeKRotation3F(1, nodeId, 1, ref ucsId, rotationStiff);             
                List<double> stiffnessVals = new List<double>();
                stiffnessVals.AddRange(translationStiff);
                stiffnessVals.AddRange(rotationStiff);
                Constraint6DOF bhRestraint = BH.Engine.Structure.Create.Constraint6DOF("", bhFixed, stiffnessVals);
                Node bhNode = BH.Engine.Structure.Create.Node(BH.Engine.Geometry.Create.Point(XYZ[0], XYZ[1], XYZ[2]),"", bhRestraint);
                SetAdapterId(bhNode, nodeId);             
                nodes.Add(bhNode);
            }
            return nodes;
        }

        /***************************************************/

    }
}


