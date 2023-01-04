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
using St7API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.Strand7
{
    public static partial class Compute
    {
        public static bool St7ImportRhino(string fileName, string fileDir, St7UnitEnum st7UnitEnum, bool active = false)
        {
           
            if (!active) return false;
            int uID = 1;
            int err = 0;
            fileDir = fileDir.EndsWith(Path.DirectorySeparatorChar.ToString()) ? fileDir : fileDir + Path.DirectorySeparatorChar;
            string tempDir = string.Concat(fileDir, "tmp" + Path.DirectorySeparatorChar);
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);


            int[] Integers = new int[5];
            Integers[St7.ipGeomImportProperty] = 1;
            Integers[St7.ipGeomImportCurvesToBeams] = St7.btFalse;
            Integers[St7.ipGeomImportGroupsAs] = St7.ggLayers;
            Integers[St7.ipGeomImportColourAsProperty] = St7.btTrue;
            if (st7UnitEnum ==  St7UnitEnum.N_mm) Integers[St7.ipGeomImportLengthUnit] = St7.luGeomMillimetre;
            else if (st7UnitEnum == St7UnitEnum.kN_m) Integers[St7.ipGeomImportLengthUnit] = St7.luGeomMetre;

            double[] Doubles = new double[] { 0.001 };

            int Mode = St7.ieQuietRun;

            err = St7.St7ImportRhino(uID, string.Concat(fileDir, fileName), Integers, Doubles, Mode);
            int numFaces = 0;
            err = St7.St7GetTotal(uID, St7.tyGEOMETRYFACE, ref numFaces);
            foreach (int i in Enumerable.Range(1, numFaces + 1)) err = St7.St7SetEntitySelectState(uID, St7.tyGEOMETRYFACE, i, 0, St7.btTrue);          
            err = St7.St7SetKeepSelect(1, St7.btFalse);
            if (st7UnitEnum == St7UnitEnum.N_mm)  err = St7.St7GraftEdgesToFaces(1, St7.ztAbsolute, 0.01);
            else if (st7UnitEnum == St7UnitEnum.kN_m) err = St7.St7GraftEdgesToFaces(1, St7.ztAbsolute, 0.0001);

            return St7Error(err);
        }

    }
}

