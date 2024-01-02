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

using St7API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Adapter.Strand7;

namespace BH.Engine.Strand7
{
    public static partial class Compute
    {
        public static SolverResults St7RunSolver(string resultsFileName, string fileDir, St7SolverType solverType = St7SolverType.LinearStatic, St7SolverMode solverMode = St7SolverMode.BackgroundRun, int numCPU = 4, bool active = false)
        {
            if (!active) return new SolverResults(false, "");
            int err = St7.St7SetUseSolverDLL(St7.btTrue);
            if (!St7ErrorCustom(err, "Could not set use solver DLL")) return new SolverResults(false, "");
            err = St7.St7SetSolverNumCPU(numCPU);
            if (!St7ErrorCustom(err, "Could not set a number of CPU to use")) return new SolverResults(false, "");
            fileDir = fileDir.EndsWith(Path.DirectorySeparatorChar.ToString()) ? fileDir : fileDir + Path.DirectorySeparatorChar;
            string logFileName = resultsFileName.Remove(resultsFileName.Length - 1, 1) + "L";
            err = St7.St7SetResultLogFileName(1, fileDir + logFileName);
            if (!St7ErrorCustom(err, "Could not set results log name")) return new SolverResults(false, "");
            err = St7.St7SetResultFileName(1, fileDir + resultsFileName);
            if (!St7ErrorCustom(err, "Could not set results file path")) return new SolverResults(false, "");
            err = St7.St7RunSolver(1, (int)solverType, (int)solverMode, St7.btTrue);
            if (!St7ErrorCustom(err, "Could not runt the solver")) return new SolverResults(false, "");
            string[] log = File.ReadAllLines(fileDir + logFileName);
            int indexOfSummary = Array.FindIndex(log, x => x.StartsWith("*SUMMARY OF MESSAGES"));
            return new SolverResults(err == St7.ERR7_NoError, string.Join(Environment.NewLine, new string[] { log[indexOfSummary], log[indexOfSummary + 1], log[indexOfSummary + 2], log[indexOfSummary + 3] }));
        }        
    }
    public class SolverResults
    {
        public bool Success { get; set; }
        public string SolverLog { get; set; }
        public SolverResults(bool success, string solverLog)
        {
            Success = success;
            SolverLog = solverLog;
        }
    }
}


