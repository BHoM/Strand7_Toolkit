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
using BH.oM.Adapter.Strand7;
using BH.oM.Base;
using BH.oM.Structure.Elements;
using St7API;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool CreateObject(St7Stage stage)
        {
            // reading groups is not implemented
            int uID = 1;
            int err = 0;
            int[] parameters = new int[4];
            parameters[0] = stage.Morphing ? St7.btTrue : St7.btFalse;
            parameters[1] = stage.MoveFixedNodes ? St7.btTrue : St7.btFalse;
            parameters[2] = stage.RotateClusters ? St7.btTrue : St7.btFalse;
            parameters[3] = St7.btFalse;
            err = St7.St7AddStage(uID, stage.Name, parameters);
            int stageId = 0;
            int numGroups = 0;
            err = St7.St7GetNumStages(uID, ref stageId);
            if (!St7Error(err)) return false;
            SetAdapterId(stage, stageId);
         
            err = St7.St7GetNumGroups(uID, ref numGroups);
            if (!St7Error(err)) return false;
            // disabling all groups first
            foreach (int groupIdtoDisable in Enumerable.Range(1, numGroups))
            {
                err = St7.St7DisableStageGroup(uID, stageId, groupIdtoDisable);
                if (!St7Error(err)) return false;
            }
            foreach (St7Group<IBHoMObject> group in stage.GroupsToEnable)
            {

                int groupIdtoEnable = GetAdapterId<int>(group);
                err = St7.St7EnableStageGroup(uID, stageId, groupIdtoEnable);
                if (!St7Error(err)) return false;
            }

            // nonlinear analysis
            err = St7.St7SetNLAStagedAnalysis(uID, St7.btTrue);
            if (!St7Error(err)) return false;



            IEnumerable<int> increments = Enumerable.Range(1, stage.Increments);

            err = St7.St7EnableNLAStage(uID, stageId);
            if (!St7Error(err)) return false;

            // adding increments
            foreach (int inc in increments)
            {
                err = St7.St7AddNLAIncrement(uID, stageId, inc.ToString() + " out of " + stage.Increments.ToString());
                if (!St7Error(err)) return false;
            }

            // Enabling Freedom case
            err = St7.St7EnableNLAFreedomCase(uID, stageId, stage.FreedomCaseToEnable);
            if (!St7Error(err)) return false;
            foreach (int inc in increments)
            {
                err = St7.St7SetNLAFreedomIncrementFactor(uID, stageId, inc, stage.FreedomCaseToEnable, 1.0);
                if (!St7Error(err)) return false;
            }
            // Factoring and enabling load cases
            foreach (var loadCase in stage.loadCombination.LoadCases)
            {
                int caseNum = GetAdapterId<int>(loadCase.Item2);

                if (loadCase.Item1 == 0) // disable load case
                {
                    err = St7.St7DisableNLALoadCase(uID, stageId, caseNum);
                    if (!St7Error(err)) return false;
                }
                else
                {
                    err = St7.St7EnableNLALoadCase(uID, stageId, caseNum);
                    if (!St7Error(err)) return false;
                }
                foreach (int inc in increments)
                {
                    double factor = inc * loadCase.Item1 / (double)stage.Increments;
                    err = St7.St7SetNLALoadIncrementFactor(uID, stageId, inc, caseNum, factor);
                    if (!St7Error(err)) return false;
                }
            }

            return true;
        }

        /***************************************************/
    }
}

