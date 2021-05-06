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

using BH.oM.Adapter.Strand7;
using BH.oM.Analytical.Elements;
using BH.oM.Structure.Elements;
using BH.oM.Structure.Loads;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.SurfaceProperties;
using St7API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        // Method that returns the next free index for a specific object type as 'object'. 
        // 'object' is required as ID is software specific (could be int, string, Guid or anything else).
        // NextId is called in the base Adapter Push method, just before the call to Create();
        // it follows that at the point of index assignment, the objects have not yet been created in the target software. 
        // This is to ensure that the object exported in the software will have the the ID that we decided here.
        protected override object NextFreeId(Type objectType, bool refresh = false)
        {
            //Change from object to what the specific software is using
            int index = 1;
            int uID = 1;
            
            if (!refresh && m_indexDict.TryGetValue(objectType, out index))
            {
                index++;
            }
            else if (objectType == typeof(Loadcase))
            {
                int err = 0;
                int loadCaseCount = 0;
                err = St7.St7GetNumLoadCase(uID, ref loadCaseCount);
                // check if it is default loadcase and override it
                if (loadCaseCount == 1)
                {
                    StringBuilder loadCaseName = new StringBuilder(St7.kMaxStrLen);
                    err = St7.St7GetLoadCaseName(1, 1, loadCaseName, St7.kMaxStrLen);
                    if (loadCaseName.ToString() == "Load Case 1") loadCaseCount = 0;
                }
                if (St7Error(err)) index = loadCaseCount + 1;              
            }
            else if (objectType == typeof(Node))
            {
                int err = 0;
                int nodeCount = 0;
                err = St7.St7GetTotal(uID, St7.tyNODE, ref nodeCount);
                if (St7Error(err)) index = nodeCount + 1;
            }
            else if (objectType == typeof(St7RigidMPLink))
            {
                int err = 0;
                int linkCount = 0;
                err = St7.St7GetTotal(uID, St7.tyLINK, ref linkCount);
                if (St7Error(err)) index = linkCount + 1;
            }
            else if (objectType == typeof(LoadCombination))
            {
                int err = 0;              
                int loadComboCount = 0;             
                err = St7.St7GetNumLSACombinations(uID, ref loadComboCount);            
                if (St7Error(err)) index = loadComboCount + 1;
            }
            else if (objectType == typeof(Bar))
            {
                int err = 0;
                int beamCount = 0;
                err = St7.St7GetTotal(uID, St7.tyBEAM, ref beamCount);
                if (St7Error(err)) index = beamCount + 1;
            }
            else if (typeof(IAreaElement).IsAssignableFrom(objectType))
            {
                int err = 0;
                int plateCount = 0;
                err = St7.St7GetTotal(uID, St7.tyPLATE, ref plateCount);
                if (St7Error(err)) index = plateCount + 1;
            }
            else if (typeof(IFace).IsAssignableFrom(objectType))
            {
                int err = 0;
                int plateCount = 0;
                err = St7.St7GetTotal(uID, St7.tyPLATE, ref plateCount);
                if (St7Error(err)) index = plateCount + 1;
            }
            else if (typeof(ISectionProperty).IsAssignableFrom(objectType))
            {
                int err = 0;
                int[] propCount = new int[St7.kMaxEntityTotals - 1];
                int[] propLastNumbers = new int[St7.kMaxEntityTotals - 1];
                err = St7.St7GetTotalProperties(uID, propCount, propLastNumbers);
                if (St7Error(err)) index = propLastNumbers[St7.ipBeamPropTotal] + 1;
            }
            else if (typeof(ISurfaceProperty).IsAssignableFrom(objectType))
            {
                int err = 0;
                int[] propCount = new int[St7.kMaxEntityTotals - 1];
                int[] propLastNumbers = new int[St7.kMaxEntityTotals - 1];
                err = St7.St7GetTotalProperties(uID, propCount, propLastNumbers);
                if (St7Error(err)) index = propLastNumbers[St7.ipPlatePropTotal] + 1;
            }

            m_indexDict[objectType] = index;
            return index;
        }

        /***************************************************/
        /**** Private Fields                            ****/
        /***************************************************/

        // Change from object to the index type used by the specific software
        private Dictionary<Type, int> m_indexDict = new Dictionary<Type, int>();


        /***************************************************/
    }
}
