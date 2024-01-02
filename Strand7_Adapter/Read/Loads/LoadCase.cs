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
using BH.oM.Adapter.Strand7;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        private List<Loadcase> ReadLoadcase(List<string> ids = null)
        {
            List<Loadcase> loadCases = new List<Loadcase>();
            int err = 0;
            int loadCaseCount = 0;
            err = St7.St7GetNumLoadCase(1, ref loadCaseCount);
            if (!St7ErrorCustom(err, "Could not get loadcases")) return loadCases;
            for (int ldCs = 1; ldCs <= loadCaseCount; ldCs++)
            {
                StringBuilder loadCaseName = new StringBuilder(St7.kMaxStrLen);
                err = St7.St7GetLoadCaseName(1, ldCs, loadCaseName, St7.kMaxStrLen);
                if (!St7ErrorCustom(err, "Could not get a name of loadcase " + ldCs)) continue;
                int caseType = 0;
                err = St7.St7GetLoadCaseType(1, ldCs, ref caseType);
                if (!St7ErrorCustom(err, "Could not get a type of loadcase " + ldCs)) continue;
                Loadcase ldcase = null;
                if (caseType == St7.lcNoInertia) ldcase = BH.Engine.Structure.Create.Loadcase(loadCaseName.ToString(), ldCs);
                else if (caseType == St7.lcAccelerations) ldcase = BH.Engine.Structure.Create.Loadcase(loadCaseName.ToString(), ldCs, LoadNature.Notional);
                else if (caseType == St7.lcSeismic) ldcase = BH.Engine.Structure.Create.Loadcase(loadCaseName.ToString(), ldCs, LoadNature.Seismic);
                else if (caseType == St7.lcGravity) ldcase = BH.Engine.Structure.Create.Loadcase(loadCaseName.ToString(), ldCs, LoadNature.Dead);               
                else BHError("Load Type is not supported");   
                if (!(ldcase is null))
                {
                    SetAdapterId(ldcase, ldCs);
                    ldcase.Number = ldCs;
                    loadCases.Add(ldcase);
                }
            }
            return loadCases;
        }
        private List<ILoad> ReadLoad(Type type, List<string> ids = null)
        {
            List<ILoad> loadList = new List<ILoad>();
            List<Loadcase> loadcaseList = ReadLoadcase();

            if (type == typeof(PointLoad))
                return ReadPointLoad(loadcaseList);
            if (type == typeof(BarPreLoad))
                return new List<ILoad>(); // not implemented
            if (type == typeof(GravityLoad))
                return ReadGravityLoad(loadcaseList);
            else if (type == typeof(BarVaryingDistributedLoad))
                return ReadBarDistributedLoad(loadcaseList);
            else if (type == typeof(BarDistributedMass))
                return ReadBarDistributedMass(loadcaseList);
            else if (type == typeof(BarUniformlyDistributedLoad))
                return ReadBarDistributedLoad(loadcaseList);
            else if (type == typeof(BarPointLoad))
                return ReadBarPointLoad(loadcaseList);
            else if (type == typeof(AreaUniformlyDistributedLoad))
                return ReadAreaLoad(loadcaseList);
            else
            {
                List<ILoad> loads = new List<ILoad>();
                loads.AddRange(ReadPointLoad(loadcaseList));
                loads.AddRange(ReadBarPointLoad(loadcaseList));
                loads.AddRange(ReadBarDistributedLoad(loadcaseList));
                loads.AddRange(ReadAreaLoad(loadcaseList));
                loads.AddRange(ReadGravityLoad(loadcaseList));
                return loads;
            }
        }
        public static bool IsZeroSqLength(double[] arrayToCheck)
        {
            return arrayToCheck.Select(x => x * x).Sum() == 0;
        }     
    }
}


