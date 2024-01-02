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

namespace BH.Engine.Strand7
{
    public static partial class Compute
    {
        public static bool St7OpenFile(string fileName, string fileDir, bool active = false)
        {
            if (!active) return false;
            int err = St7.St7CloseFile(1);          
            fileDir = fileDir.EndsWith(Path.DirectorySeparatorChar.ToString()) ? fileDir : fileDir + Path.DirectorySeparatorChar;         
            string tempDir = string.Concat(fileDir, "tmp" + Path.DirectorySeparatorChar);
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);
            err = St7.St7OpenFile(1, string.Concat(fileDir, fileName), tempDir);           
            return St7Error(err);
        }
        
    }
}


