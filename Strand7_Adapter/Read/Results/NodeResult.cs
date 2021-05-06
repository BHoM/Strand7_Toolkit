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
        private IEnumerable<IResult> GetNodeResults(Type type, IList ids = null, IList cases = null)
        {
            List<NodeResult> results = new List<NodeResult>();
            int resultType = -1;
            if (type == typeof(NodeAcceleration))
                resultType = St7.rtNodeAcc;
            else if (type == typeof(NodeDisplacement))
                resultType = St7.rtNodeDisp;
            else if (type == typeof(NodeReaction))
                resultType = St7.rtNodeReact;
            else if (type == typeof(NodeVelocity))
                resultType = St7.rtNodeVel;

            List<int> loadcaseIds = new List<int>();
            List<int> nodeIds = new List<int>();        
            int err;

            // checking node ids
            if (ids == null || ids.Count == 0)
            {
                int nodeCount = 0;
                err = St7.St7GetTotal(1, St7.tyNODE, ref nodeCount);
                if (!St7Error(err)) return null;
                nodeIds = Enumerable.Range(1, nodeCount).ToList();
            }
            else
                nodeIds = ids.Cast<int>().ToList();

            // checking load ids
            if (cases == null) BHError("No load cases are provided");
            else
            {
                foreach (object one_case in cases)
                {
                    if (one_case is ICase) loadcaseIds.Add(GetAdapterId<int>(one_case as ICase));
                    else if (one_case is int) loadcaseIds.Add((int)one_case);
                }
            }
            double[] nodeResArray = new double[6];
            NodeResult nd;
            foreach (int loadcaseId in loadcaseIds)
            {
                double caseTime = 0;
                err = St7.St7GetResultCaseTime(1, loadcaseId, ref caseTime);
                foreach (int nodeId in nodeIds)
                {
                    err = St7.St7GetNodeResult(1, resultType, nodeId, loadcaseId, nodeResArray);                  
                    switch (resultType)
                    {
                        case St7.rtNodeAcc:
                            nd = new NodeAcceleration(nodeId, loadcaseId,1, caseTime, oM.Geometry.Basis.XY, nodeResArray[0], nodeResArray[1], nodeResArray[2], nodeResArray[3], nodeResArray[4], nodeResArray[5]);                          
                            break;
                        case St7.rtNodeDisp:
                            nd = new NodeDisplacement(nodeId, loadcaseId, 1, caseTime, oM.Geometry.Basis.XY, nodeResArray[0], nodeResArray[1], nodeResArray[2], nodeResArray[3], nodeResArray[4], nodeResArray[5]);                          
                            break;
                        case St7.rtNodeVel:
                            nd = new NodeVelocity(nodeId, loadcaseId, 1, caseTime, oM.Geometry.Basis.XY, nodeResArray[0], nodeResArray[1], nodeResArray[2], nodeResArray[3], nodeResArray[4], nodeResArray[5]);                        
                            break;
                        case St7.rtNodeReact:
                            nd = new NodeReaction(nodeId, loadcaseId, 1, caseTime, oM.Geometry.Basis.XY, nodeResArray[0], nodeResArray[1], nodeResArray[2], nodeResArray[3], nodeResArray[4], nodeResArray[5]);                         
                            break;
                        default:
                            nd = null;
                            BHError("Unknown Result type");
                            break;
                    }                           
                    results.Add(nd);
                }
            }            
            return results;
        }

     
    }
}
