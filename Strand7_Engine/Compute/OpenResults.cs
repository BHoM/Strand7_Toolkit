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
        public static OpenResultsOut St7OpenResults(string fileName, string fileDir, bool getCaseNames = true, bool generateCombinations = false, bool generateEnvelopes = false, bool active = false)
        {
            if (!active) return new OpenResultsOut(false, null, null);
            List<string> caseNames = new List<string>();
            List<int> caseIds = new List<int>();
            int err = St7.St7CloseResultFile(1);
            int primaryCases = 0;
            int secondaryCases = 0;
            int warningCode = 0;
            string spectralFileName = string.Empty;
            int combinations = generateCombinations ? St7.kGenerateNewCombinations : St7.kNoCombinations;
            fileDir = fileDir.EndsWith(Path.DirectorySeparatorChar.ToString()) ? fileDir : fileDir + Path.DirectorySeparatorChar;
            err = St7.St7OpenResultFile(1, string.Concat(fileDir, fileName), spectralFileName, combinations, ref primaryCases, ref secondaryCases);
            if (!St7ErrorCustom(err, "Could not open results file")) return new OpenResultsOut(false, null, null);
            if (generateCombinations) err = St7.St7GenerateLSACombinations(1, ref secondaryCases, ref warningCode);
            if (!St7ErrorCustom(err, "Could not generate combinations")) return new OpenResultsOut(false, null, null);
            int numLimitEnvelopes = 0;
            int numCombEnvelopes = 0;
            int numFactorEnvelopes = 0;
            if (generateEnvelopes) err = St7.St7GenerateEnvelopes(1, ref numLimitEnvelopes, ref numCombEnvelopes, ref numFactorEnvelopes);
            if (!St7ErrorCustom(err, "Could not generate combinations")) return new OpenResultsOut(false, null, null);
            if (getCaseNames)
            {
                for (int i = 1; i <= primaryCases + secondaryCases + numLimitEnvelopes + numCombEnvelopes + numFactorEnvelopes; i++)
                {
                    StringBuilder caseName = new StringBuilder(St7.kMaxStrLen);
                    err = St7.St7GetResultCaseName(1, i, caseName, St7.kMaxStrLen);
                    caseNames.Add(caseName.ToString());
                    caseIds.Add(i);
                }
            }
            return new OpenResultsOut(St7Error(err), caseNames, caseIds);
        }
     

        public class OpenResultsOut
        {
            public bool Success { get; set; }
            public List<string> CaseNames { get; set; }
            public List<int> CaseIds { get; set; }
            public OpenResultsOut(bool success, List<string> caseNames, List<int> caseIds)
            {
                Success = success;
                CaseNames = caseNames;
                CaseIds = caseIds;
            }
        }
    }
}
