﻿/*
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

using BH.oM.Adapter;
using BH.oM.Reflection;
using St7API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Adapter.Commands;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        public override Output<List<object>, bool> Execute(IExecuteCommand command, ActionConfig actionConfig = null)
        {
            var output = new Output<List<object>, bool>() { Item1 = null, Item2 = false };

            output.Item2 = RunCommand(command as dynamic);

            return output;
        }
         public bool RunCommand(NewModel command)
        {
            bool success = true;
          
            return success;
        }      

        public static bool St7Error(int code)
        {
            if (code == St7.ERR7_NoError) return true;
            StringBuilder errorSb = new StringBuilder(St7.kMaxStrLen);
            if (St7.ERR7_NoError == St7.St7GetAPIErrorString(code, errorSb, St7.kMaxStrLen)) BH.Engine.Reflection.Compute.RecordError(errorSb.ToString());              
            else if (St7.ERR7_NoError == St7.St7GetSolverErrorString(code, errorSb, St7.kMaxStrLen)) BH.Engine.Reflection.Compute.RecordError(errorSb.ToString());
            return false;
        }
        public static void BHError(string errorString)
        {
            BH.Engine.Reflection.Compute.RecordError(errorString);           
        }
        public static bool St7ErrorCustom(int code, string customString)
        {
            if (code == St7.ERR7_NoError) return true;
            StringBuilder errorSb = new StringBuilder(St7.kMaxStrLen);
            if (St7.ERR7_NoError == St7.St7GetAPIErrorString(code, errorSb, St7.kMaxStrLen)) BH.Engine.Reflection.Compute.RecordError(errorSb.ToString() + ". " + customString);
            else if (St7.ERR7_NoError == St7.St7GetSolverErrorString(code, errorSb, St7.kMaxStrLen)) BH.Engine.Reflection.Compute.RecordError(errorSb.ToString() + ". " + customString);
            return false;
        }

        public static bool St7NoteCustom(int code, string customString)
        {
            if (code == St7.ERR7_NoError) return true;
            StringBuilder errorSb = new StringBuilder(St7.kMaxStrLen);
            if (St7.ERR7_NoError == St7.St7GetAPIErrorString(code, errorSb, St7.kMaxStrLen)) BH.Engine.Reflection.Compute.RecordNote(errorSb.ToString() + ". " + customString);
            else if (St7.ERR7_NoError == St7.St7GetSolverErrorString(code, errorSb, St7.kMaxStrLen)) BH.Engine.Reflection.Compute.RecordNote(errorSb.ToString() + ". " + customString);
            return false;
        }
    }
}
