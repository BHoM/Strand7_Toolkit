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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private bool CreateObject(Loadcase bhLoadCase)
        {
            int err;        
            int loadCaseId = bhLoadCase.Number;
            int loadCaseCount = 0;
            int uID = 1;
            err = St7.St7GetNumLoadCase(uID, ref loadCaseCount);

            if (loadCaseCount < loadCaseId)
            {
                err = St7.St7NewLoadCase(uID, bhLoadCase.Name);
                if (!St7ErrorCustom(err, "Could not create a load case number " + loadCaseId)) return false;
            }
            else // updating
            {
                StringBuilder currentLoadCaseName = new StringBuilder(St7.kMaxStrLen);
                err = St7.St7GetLoadCaseName(uID, loadCaseId, currentLoadCaseName, St7.kMaxStrLen);
                if (!String.Equals(currentLoadCaseName.ToString(), bhLoadCase.Name, StringComparison.OrdinalIgnoreCase))
                {
                    err = St7.St7SetLoadCaseName(uID, loadCaseId, bhLoadCase.Name);
                    if (!St7ErrorCustom(err, "Could not update a load case number " + loadCaseId)) return false;
                }
            }
            err = St7.St7SetLoadCaseType(uID, loadCaseId, St7LoadCaseTypeFromNature(bhLoadCase.Nature));
            err = St7.St7EnableLSALoadCase(uID, loadCaseId, 1);
            return true;
        }

        private static int St7LoadCaseTypeFromNature(LoadNature loadNature)
        {
            switch (loadNature)
            {
                case LoadNature.Seismic:
                    return St7.lcSeismic;
                case LoadNature.Notional:
                    return St7.lcAccelerations;
                default:
                    return St7.lcNoInertia;
            }
        }
        private static double St7AccelerationFromLUnints(int units)
        {
            switch (units)
            {
                case St7.luMETRE:
                    return -9.80665;
                case St7.luMILLIMETRE:
                    return -9806.65;
                case St7.luCENTIMETRE:
                    return -980.665;
                case St7.luINCH:
                    return -3786.24;
                case St7.luFOOT:
                    return -315.52;
                default:
                    BHError("Wrong length units when setting a gravity load");
                    return 0;
            }
        }
        private static double St7TempFromTUnints(int units)
        {
            switch (units)
            {
                case St7.tuCELSIUS:
                    return 25;
                case St7.tuFAHRENHEIT:
                    return 77;
                case St7.tuKELVIN:
                    return 298.15;
                default:
                    BHError("Wrong temperature units when setting a gravity load");
                    return 0;
            }
        }
        /***************************************************/
    }
}

