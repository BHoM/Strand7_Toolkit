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
        public static bool St7Automesh(bool active, double meshSize, int corners)
        {
            if (!active) return false;
            int uID = 1;
            int err = 0;
            int[] Integers = new int[11];
            Integers[St7.ipSurfaceMeshMode] = St7.mmAuto;
            Integers[St7.ipSurfaceMeshSizeMode] = St7.smAbsolute;
            Integers[St7.ipSurfaceMeshTargetNodes] = corners;
            Integers[St7.ipSurfaceMeshTargetPropertyID] = -1;
            Integers[St7.ipSurfaceMeshAutoCreateProperties] = St7.btFalse;
            Integers[St7.ipSurfaceMeshMinEdgesPerCircle] = 12;
            Integers[St7.ipSurfaceMeshApplyTransitioning] = St7.btTrue;
            Integers[St7.ipSurfaceMeshApplySurfaceCurvature] = St7.btFalse;
            Integers[St7.ipSurfaceMeshAllowUserStop] = St7.btTrue;
            Integers[St7.ipSurfaceMeshConsiderNearVertex] = St7.btFalse;
            Integers[St7.ipSurfaceMeshSelectedFaces] = St7.btFalse;

            double[] Doubles = new double[4];
            Doubles[St7.ipSurfaceMeshSize] = meshSize;
            Doubles[St7.ipSurfaceMeshLengthRatio] = 0.1;
            Doubles[St7.ipSurfaceMeshMaximumIncrease] = 0.3;
            Doubles[St7.ipSurfaceMeshOnEdgesLongerThan] = 0;
            // err = St7.St7SetEntitySelectState(1, St7.tyGEOMETRYFACE, 1, 0, St7.btTrue);
            //err = St7.St7SetKeepSelect(1, St7.btFalse);

            err = St7.St7SurfaceMesh(uID, Integers, Doubles, St7.ieProgressRun);

            return St7Error(err);
        }

    }
}
