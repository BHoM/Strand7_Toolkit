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

using BH.Adapter;
using BH.oM.Adapter.Strand7;
using BH.oM.Structure.Elements;
using BH.oM.Structure.Results;
using St7API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.Strand7
{
    public static partial class Compute
    {
        public static List<List<double>> St7GetNodeResults(BHoMAdapter st7Adapter, List<int> caseIds, St7NodeResultsTypes resultType, St7NodeResultComponent component, List<Node> nodes, bool active = false)
        {
            List<List<double>> results = new List<List<double>>();

            if (!active) return results;
            int err;
            // checking node ids


            double[] nodeResArray = new double[6];
            foreach (Node node in nodes)
            {
                int UCSid = 1;
                int nodeId = st7Adapter.GetAdapterId<int>(node);     
                if (node.Support != null) UCSid = st7Adapter.GetAdapterId<int>(node.Support);
                var interResults = new List<double>();
                foreach (int loadcaseId in caseIds)
                {
                    err = St7.St7GetNodeResultUCS(1, (int)resultType, UCSid, nodeId, loadcaseId, nodeResArray);
                    if (component == St7NodeResultComponent.All) interResults.AddRange(nodeResArray);
                    else interResults.Add(nodeResArray[(int)component]);
                }
                results.Add(interResults);
            }
            return results;
        }
        public static List<List<double>> St7GetNodeResultsId(List<int> caseIds, St7NodeResultsTypes resultType, St7NodeResultComponent component, List<int> nodeIDs, List<int> nodeUCSs, bool active = false)
        {
            List<List<double>> results = new List<List<double>>();

            if (!active) return results;
            int err;

            double[] nodeResArray = new double[6];
            for (int i = 0; i < nodeIDs.Count; i++)
            {
                int UCSid = 1;
                int nodeId = nodeIDs[i];
                if (nodeUCSs.Any()) UCSid = nodeUCSs[i];
                var interResults = new List<double>();
                foreach (int loadcaseId in caseIds)
                {
                    err = St7.St7GetNodeResultUCS(1, (int)resultType, UCSid, nodeId, loadcaseId, nodeResArray);
                    if (component== St7NodeResultComponent.All) interResults.AddRange(nodeResArray);
                    else interResults.Add(nodeResArray[(int)component]);
                }
                results.Add(interResults);
            }
            return results;
        }
    }
}


