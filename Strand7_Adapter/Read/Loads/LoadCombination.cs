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

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        private List<LoadCombination> ReadLoadCombination(List<string> ids = null)
        {
            // Linear Load Combinations !! Only !!
            // only solver generated combinations
            List<LoadCombination> loadCombinations = new List<LoadCombination>();
            int err = 0;
            int uID = 1;
            int freedomCase = 1;
            int loadComboCount = 0;
            List<Loadcase> allLoadCases = ReadLoadcase();
            err = St7.St7GetNumLSACombinations(uID, ref loadComboCount);
            if (!St7ErrorCustom(err, "Could not get loadCombinations")) return loadCombinations;        
          
            for (int ldCombo = 1; ldCombo <= loadComboCount; ldCombo++)
            {
                StringBuilder loadComboName = new StringBuilder(St7.kMaxStrLen);
                err = St7.St7GetLSACombinationName(uID, ldCombo, loadComboName, St7.kMaxStrLen);
                if (!St7ErrorCustom(err, "Could not get a name of load combination " + ldCombo)) continue;
                List<double> loadCaseFactors = new List<double>();
                for (int j = 0; j < allLoadCases.Count; j++)
                {                 
                    int loadcaseNum = GetAdapterId<int>(allLoadCases[j]);
                    double factor = 0;
                    err = St7.St7GetLSACombinationFactor(uID, St7.ltLoadCase, ldCombo, loadcaseNum, freedomCase, ref factor);
                    if (!St7ErrorCustom(err, "Could not get a factor for a loadcase " + loadcaseNum + " load combo " + ldCombo)) return loadCombinations;
                    loadCaseFactors.Add(factor);
                }
                LoadCombination loadCombination = BH.Engine.Structure.Create.LoadCombination(loadComboName.ToString(), ldCombo, allLoadCases, loadCaseFactors);
                SetAdapterId(loadCombination, ldCombo);              
                loadCombinations.Add(loadCombination);
            }
            return loadCombinations;
        }
    }
}


