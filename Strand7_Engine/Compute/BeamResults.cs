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
using BH.Adapter;

namespace BH.Engine.Strand7
{
    public static partial class Compute
    {
        public static BeamResults St7GetBeamResults(BHoMAdapter st7Adapter, List<int> caseIds, St7ResultForceComponent component, St7BeamResultsTypes resultType = St7BeamResultsTypes.BeamForce, St7BeamResultAxis resultAxis = St7BeamResultAxis.Principal, int minStations = 1, List<Bar> beams = null, bool active = false)
        {

            if (!active) return null;
            int err;
            int uID = 1;
            List<int> beamIds = new List<int>();
            // checking node ids
            if (beams == null || beams.Count == 0)
            {
                int beamCount = 0;
                err = St7.St7GetTotal(1, St7.tyBEAM, ref beamCount);
                if (!St7Error(err)) return null;
                beamIds = Enumerable.Range(1, beamCount).ToList();
            }
            else
            {            
                beamIds = beams.Select(bar => st7Adapter.GetAdapterId<int>(bar)).ToList();               
            }
            List<List<double>> positionResults = new List<List<double>>();
            List<List<double>> valuesResults = new List<List<double>>();
            List<List<int>> numberStations = new List<List<int>>();
            List<List<int>> resultsPerStation = new List<List<int>>();
            // output from strand 7
            double[] beamPos = new double[St7.kMaxBeamResult];
            double[] beamResult = new double[St7.kMaxBeamResult];
            int numStations = 0;
            int numColumns = 0;

            foreach (int beamId in beamIds)
            {
                List<double> interPosResults = new List<double>();
                List<double> interValues = new List<double>();
                List<int> interStations = new List<int>();
                List<int> interResPerStation = new List<int>();
                foreach (int loadcaseId in caseIds)
                {
                    err = St7.St7GetBeamResultArray(uID, (int)resultType, (int)resultAxis, beamId, minStations, loadcaseId, ref numStations, ref numColumns, beamPos, beamResult);
                    interPosResults.AddRange(beamPos.Take(numStations));
                    interStations.Add(numStations);
                    if (component == St7ResultForceComponent.All) interResPerStation.Add(numColumns);
                    else interResPerStation.Add(1);
                    if (component == St7ResultForceComponent.All)
                        interValues.AddRange(beamResult.Take(numStations * numColumns));
                    else
                        for (int i = 0; i < numStations; i++)
                            interValues.Add(beamResult[(int)component + i * numColumns]);
                }
                numberStations.Add(interStations);
                positionResults.Add(interPosResults);
                valuesResults.Add(interValues);
                resultsPerStation.Add(interResPerStation);
            }
            return new BeamResults(true, positionResults, valuesResults, numberStations, resultsPerStation);
        }


        public static BeamResults St7GetBeamResultsAtT(BHoMAdapter st7Adapter, List<int> caseIds, List<Bar> beams, List<double> t_params, St7ResultForceComponent component, St7BeamResultsTypes resultType = St7BeamResultsTypes.BeamForce, St7BeamResultAxis resultAxis = St7BeamResultAxis.Principal, bool active = false)
        {

            if (!active) return null;
            int err;
            int uID = 1;
            err = St7.St7SetBeamResultPosMode(uID, St7.bpParam);
            List<List<double>> valuesResults = new List<List<double>>();
            List<List<int>> resultsPerStation = new List<List<int>>();
            // output from strand 7

            double[] beamResult = new double[St7.kMaxBeamResult];
            int numStations = 1;
            int numColumns = 0;
        
            for (int i = 0; i < beams.Count; i++)
            {
                Bar beam = beams[i];
                double[] beamPos;
                if (i > t_params.Count - 1)
                {
                    beamPos = new double[] { t_params[t_params.Count-1] };
                }
                else beamPos = new double[] { t_params[i] };
                int beamId = st7Adapter.GetAdapterId<int>(beam);             

                List<double> interValues = new List<double>();
                List<int> interResPerStation = new List<int>();
                foreach (int loadcaseId in caseIds)
                {
                    err = St7.St7GetBeamResultArrayPos(uID, (int)resultType, (int)resultAxis, beamId, loadcaseId, numStations, beamPos, ref numColumns, beamResult);
                    if (component == St7ResultForceComponent.All) interResPerStation.Add(numColumns);
                    else interResPerStation.Add(1);
                    if (component == St7ResultForceComponent.All)
                        interValues.AddRange(beamResult.Take(numStations * numColumns));
                    else
                        for (int j = 0; j < numStations; j++)
                            interValues.Add(beamResult[(int)component + j * numColumns]);
                }
                valuesResults.Add(interValues);
                resultsPerStation.Add(interResPerStation);
            }
            return new BeamResults(true, new List<List<double>>(), valuesResults, new List<List<int>>(), resultsPerStation);
        }

        public static BeamResults St7GetBeamResultsEnds(List<int> caseIds, List<int> beamIDs, List<int> beamEnd, St7ResultForceComponent component, St7BeamResultsTypes resultType = St7BeamResultsTypes.BeamForce, St7BeamResultAxis resultAxis = St7BeamResultAxis.Principal, bool active = false)
        {

            if (!active) return null;
            int err;
            int uID = 1;


            List<List<double>> valuesResults = new List<List<double>>();
            List<List<int>> resultsPerStation = new List<List<int>>();
            // output from strand 7

            double[] beamResult = new double[St7.kMaxBeamResult];
            int numColumns = 0;

            for (int i = 0; i < beamIDs.Count; i++)
            {           
                int beamId = beamIDs[i];
                List<double> interValues = new List<double>();
                List<int> interResPerStation = new List<int>();
                foreach (int loadcaseId in caseIds)
                {
                    err = St7.St7GetBeamResultEndPos(uID, (int)resultType, (int)resultAxis, beamId, loadcaseId, ref numColumns, beamResult);
                    if (component == St7ResultForceComponent.All) interResPerStation.Add(numColumns);
                    else interResPerStation.Add(1);
                    if (beamEnd[i] == 1)
                        interValues.AddRange(beamResult.Take(numColumns));
                    else
                        interValues.AddRange(beamResult.Skip(numColumns).Take(numColumns));

                }
                valuesResults.Add(interValues);
                resultsPerStation.Add(interResPerStation);
            }
            return new BeamResults(true, new List<List<double>>(), valuesResults, new List<List<int>>(), resultsPerStation);
        }

        public class BeamResults
        {
            public bool Success { get; set; }
            public List<List<int>> ResultsPerStation { get; set; }
            public List<List<int>> NumberStations { get; set; }
            public List<List<double>> PositionResults { get; set; }
            public List<List<double>> ValuesResults { get; set; }

            public BeamResults(bool success, List<List<double>> positionResults, List<List<double>> valuesResults, List<List<int>> numberStations, List<List<int>> resultsPerStation)
            {
                Success = success;
                PositionResults = positionResults;
                ValuesResults = valuesResults;
                ResultsPerStation = resultsPerStation;
                NumberStations = numberStations;
            }
        }
    }
}

