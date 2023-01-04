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

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {   
        private List<ILoad> ReadBarPointLoad(List<Loadcase> loadcases)
        {
            int err = 0;
            Dictionary<int, Loadcase> lcDict = loadcases.ToDictionary(x => GetAdapterId<int>(x));
            List<ILoad> bhLoads = new List<ILoad>();
            List<Bar> allBars = ReadBars();

            foreach (Bar bar in allBars)
            {
                double length = BH.Engine.Geometry.Query.Length(BH.Engine.Structure.Query.Centreline(bar));
                int barId = GetAdapterId<int>(bar);

                // ***************** try to get point forces first ************************
                // ****************************** global **********************************
                int globalPointForceCount = 0;
                err = St7.St7GetEntityAttributeSequenceCount(1, St7.tyBEAM, barId, St7.aoBeamCFG, ref globalPointForceCount);
                if (globalPointForceCount > 0)
                {
                    // getting load IDs
                    int[] sequenceNumbers = new int[globalPointForceCount * 4];
                    err = St7.St7GetEntityAttributeSequence(1, St7.tyBEAM, barId, St7.aoBeamCFG, globalPointForceCount, sequenceNumbers);
                    for (int i = 0; i < globalPointForceCount; i++)
                    {
                        int loadCaseNum = sequenceNumbers[4 * i + St7.ipAttrCase];
                        int loadID = sequenceNumbers[4 * i + St7.ipAttrID];
                        double[] forcesG = new double[4];
                        err = St7.St7GetBeamPointForceGlobal4ID(1, barId, loadCaseNum, loadID, forcesG);
                        if (!IsZeroSqLength(forcesG))
                        {
                            BarPointLoad bhLoad = new BarPointLoad()
                            {
                                DistanceFromA = length * forcesG[3],
                                Force = new Vector() { X = forcesG[0], Y = forcesG[1], Z = forcesG[2] },
                                Loadcase = lcDict[loadCaseNum],
                                Projected = false,
                                Axis = LoadAxis.Global,
                                Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                            };
                            bhLoads.Add(bhLoad);
                        }
                    }
                }
                int globalPointMomentCount = 0;
                err = St7.St7GetEntityAttributeSequenceCount(1, St7.tyBEAM, barId, St7.aoBeamCMG, ref globalPointMomentCount);
                if (globalPointMomentCount > 0)
                {
                    // getting load IDs
                    int[] sequenceNumbers = new int[globalPointMomentCount * 4];
                    err = St7.St7GetEntityAttributeSequence(1, St7.tyBEAM, barId, St7.aoBeamCMG, globalPointMomentCount, sequenceNumbers);
                    for (int i = 0; i < globalPointMomentCount; i++)
                    {
                        int loadCaseNum = sequenceNumbers[4 * i + St7.ipAttrCase];
                        int loadID = sequenceNumbers[4 * i + St7.ipAttrID];
                        double[] momentsG = new double[4];
                        err = St7.St7GetBeamPointMomentGlobal4ID(1, barId, loadCaseNum, loadID, momentsG);
                        if (!IsZeroSqLength(momentsG))
                        {
                            BarPointLoad bhLoad = new BarPointLoad()
                            {
                                DistanceFromA = length * momentsG[3],
                                Moment = new Vector() { X = momentsG[0], Y = momentsG[1], Z = momentsG[2] },
                                Loadcase = lcDict[loadCaseNum],
                                Projected = false,
                                Axis = LoadAxis.Global,
                                Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                            };
                            bhLoads.Add(bhLoad);
                        }
                    }
                }
                // ****************************** principal **********************************              
                int principalPointForceCount = 0;
                err = St7.St7GetEntityAttributeSequenceCount(1, St7.tyBEAM, barId, St7.aoBeamCFL, ref principalPointForceCount);
                if (principalPointForceCount > 0)
                {
                    // getting load IDs
                    int[] sequenceNumbers = new int[principalPointForceCount * 4];
                    err = St7.St7GetEntityAttributeSequence(1, St7.tyBEAM, barId, St7.aoBeamCFL, principalPointForceCount, sequenceNumbers);
                    for (int i = 0; i < principalPointForceCount; i++)
                    {
                        int loadCaseNum = sequenceNumbers[4 * i + St7.ipAttrCase];
                        int loadID = sequenceNumbers[4 * i + St7.ipAttrID];
                        double[] forcesP = new double[4];
                        err = St7.St7GetBeamPointForcePrincipal4ID(1, barId, loadCaseNum, loadID, forcesP);
                        if (!IsZeroSqLength(forcesP))
                        {
                            BarPointLoad bhLoad = new BarPointLoad()
                            {
                                DistanceFromA = length * forcesP[3],
                                //Force = BH.Engine.Geometry.Modify.Transform(new Vector() { X = forcesP[0], Y = forcesP[1], Z = forcesP[2] }, transformMatrix),
                                Force = new Vector() { X = forcesP[0], Y = forcesP[1], Z = forcesP[2] },
                                Loadcase = lcDict[loadCaseNum],
                                Projected = false,
                                Axis = LoadAxis.Local,                          
                                Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                            };
                            bhLoads.Add(bhLoad);
                        }
                    }
                }
                int principalPointMomentCount = 0;
                err = St7.St7GetEntityAttributeSequenceCount(1, St7.tyBEAM, barId, St7.aoBeamCML, ref principalPointMomentCount);
                if (principalPointMomentCount > 0)
                {
                    // getting load IDs
                    int[] sequenceNumbers = new int[principalPointMomentCount * 4];
                    err = St7.St7GetEntityAttributeSequence(1, St7.tyBEAM, barId, St7.aoBeamCML, principalPointMomentCount, sequenceNumbers);
                    for (int i = 0; i < principalPointMomentCount; i++)
                    {
                        int loadCaseNum = sequenceNumbers[4 * i + St7.ipAttrCase];
                        int loadID = sequenceNumbers[4 * i + St7.ipAttrID];
                        double[] momentsP = new double[4];
                        err = St7.St7GetBeamPointMomentPrincipal4ID(1, barId, loadCaseNum, loadID, momentsP);
                        if (!IsZeroSqLength(momentsP))
                        {
                            BarPointLoad bhLoad = new BarPointLoad()
                            {
                                DistanceFromA = length * momentsP[3],
                                //Moment = BH.Engine.Geometry.Modify.Transform(new Vector() { X = momentsP[0], Y = momentsP[1], Z = momentsP[2] }, transformMatrix),
                                Moment = new Vector() { X = momentsP[0], Y = momentsP[1], Z = momentsP[2] },
                                Projected = false,
                                Axis = LoadAxis.Local,
                                Loadcase = lcDict[loadCaseNum],
                                Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                            };
                            bhLoads.Add(bhLoad);
                        }
                    }
                }
            }
            return bhLoads;
        }       
    }
}

