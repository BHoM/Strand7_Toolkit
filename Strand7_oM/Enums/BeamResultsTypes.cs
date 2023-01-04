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
using St7API;

namespace BH.oM.Adapter.Strand7
{
    public enum St7BeamResultsTypes
    {
        BeamForce = St7.rtBeamForce,
        BeamAllStrain = St7.rtBeamAllStrain,
        AllStress = St7.rtBeamAllStress,
        AxialStress = St7.rtBeamAxialStress,
        BendingStress = St7.rtBeamBendingStress,
        FibreStress = St7.rtBeamFibreStress,
        AvShearStress = St7.rtBeamAvShearStress,
        ShearStress = St7.rtBeamShearStress,
        CombinedStress = St7.rtBeamCombinedStress,
        HoopStress = St7.rtPipeHoopStress,
        YieldAreaRatio = St7.rtBeamYieldAreaRatio,
        CableXYZ = St7.rtBeamCableXYZ,
        BeamFlux = St7.rtBeamFlux,
        NodeFlux = St7.rtBeamNodeFlux,
        Gradient = St7.rtBeamGradient,
        CreepStrain = St7.rtBeamCreepStrain,
        Energy = St7.rtBeamEnergy,
        NodeReaction = St7.rtBeamNodeReact,
        Displacement = St7.rtBeamDisp,
        BirthDisp = St7.rtBeamBirthDisp,
        BeamUser = St7.rtBeamUser
    }
}

