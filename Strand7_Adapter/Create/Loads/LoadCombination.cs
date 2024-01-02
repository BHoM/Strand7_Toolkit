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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Engine.Base.Objects;
using BH.oM.Geometry;
using BH.oM.Structure.Elements;
using BH.oM.Structure.Loads;
using St7API;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/
        private bool CreateObject(LoadCombination bhLoadCombo)
        {
            int err;
            int uID = 1;
            int loadCaseType = St7.ltLoadCase;
            int freedomCaseNum = 1;
            int loadComboId = GetAdapterId<int>(bhLoadCombo);

            List<Loadcase> allLoadCases = ReadLoadcase();
            var comparer = new BHoMObjectNameOrToStringComparer();
            err = St7.St7AddLSACombination(uID, bhLoadCombo.Name);
            if (err != St7.ERR7_NoError)
            {
                err = St7.St7SetLSACombinationName(uID, loadComboId, bhLoadCombo.Name);
                if (!St7ErrorCustom(err, "Could not create or update a load combination number " + loadComboId)) return false;
            }
            foreach (Tuple<double, ICase> tuple in bhLoadCombo.LoadCases)
            {
                Loadcase ldcas = allLoadCases.Where(x => x.Number == (tuple.Item2 as Loadcase).Number).FirstOrDefault();
                int lCaseNum =ldcas.Number;
               // int lCaseNum = GetAdapterId<int>(ldcas);              
                err = St7.St7SetLSACombinationFactor(uID, loadCaseType, loadComboId, lCaseNum, freedomCaseNum, tuple.Item1);
                if (!St7ErrorCustom(err, "Could not set load case " + lCaseNum + " factor for a load combo " + loadComboId)) return false;
            }
            return true;
        }

        /***************************************************/
    }
}


