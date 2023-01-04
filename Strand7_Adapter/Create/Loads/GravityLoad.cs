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
       
        private bool CreateObject(GravityLoad gravityLoad)
        {
            int err = 0;
            Loadcase loadcase = gravityLoad.Loadcase;
            int loadCaseId = GetAdapterId<int>(loadcase);
            err = St7.St7SetLoadCaseType(1, loadCaseId, St7.lcGravity);
            err = St7.St7EnableLSALoadCase(1, loadCaseId, 1);
            if (!St7ErrorCustom(err, "Couldn't set gravity for a loadcase " + loadCaseId)) return false;
            int gravityDir = 0;
            if (gravityLoad.GravityDirection.X != 0) gravityDir = 1;
            if (gravityLoad.GravityDirection.Y != 0) gravityDir = 2;
            if (gravityLoad.GravityDirection.Z != 0) gravityDir = 3;

            err = St7.St7SetLoadCaseGravityDir(1, loadCaseId, gravityDir);
            if (!St7ErrorCustom(err, "Couldn't set gravity direction for a loadcase " + loadCaseId)) return false;

            int[] units = new int[St7.kLastUnit];
            err = St7.St7GetUnits(1, units);
            if (!St7ErrorCustom(err, "Couldn't get default units for a loadcase " + loadCaseId)) return false;
            double temp = St7TempFromTUnints(units[St7.ipTEMPERU]);
            double accel = St7AccelerationFromLUnints(units[St7.ipLENGTHU]);

            // Load case defaults array
            double[] loadVals = new double[13];
            loadVals[St7.ipLoadCaseRefTemp] = temp;
            loadVals[St7.ipLoadCaseAccX] = gravityDir == 1 ? accel : 0;
            loadVals[St7.ipLoadCaseAccY] = gravityDir == 2 ? accel : 0;
            loadVals[St7.ipLoadCaseAccZ] = gravityDir == 3 ? accel : 0;
            err = St7.St7SetLoadCaseDefaults(1, loadCaseId, loadVals);
            if (!St7ErrorCustom(err, "Couldn't set gravity acceleration for a loadcase " + loadCaseId)) return false;
            return true;
        }
        /***************************************************/
        private bool CreateObject(St7LoadCaseInertia loadCaseInertia)
        {
            int err = 0;
            Loadcase loadcase = loadCaseInertia.Loadcase;
            int loadCaseId = GetAdapterId<int>(loadcase);
            err = St7.St7SetLoadCaseType(1, loadCaseId, St7.lcGravity);
            err = St7.St7EnableLSALoadCase(1, loadCaseId, 1);
            if (!St7ErrorCustom(err, "Couldn't set gravity for a loadcase " + loadCaseId)) return false;
            int gravityDir = 0;
            if (loadCaseInertia.GravityDirection.X != 0) gravityDir = 1;
            if (loadCaseInertia.GravityDirection.Y != 0) gravityDir = 2;
            if (loadCaseInertia.GravityDirection.Z != 0) gravityDir = 3;

            err = St7.St7SetLoadCaseGravityDir(1, loadCaseId, gravityDir);
            if (!St7ErrorCustom(err, "Couldn't set gravity direction for a loadcase " + loadCaseId)) return false;

            int[] units = new int[St7.kLastUnit];
            err = St7.St7GetUnits(1, units);
            if (!St7ErrorCustom(err, "Couldn't get default units for a loadcase " + loadCaseId)) return false;
            double temp = St7TempFromTUnints(units[St7.ipTEMPERU]);
            double accel = St7AccelerationFromLUnints(units[St7.ipLENGTHU]);

            // Load case defaults array
            double[] loadVals = new double[13];
            loadVals[St7.ipLoadCaseRefTemp] = temp;
            loadVals[St7.ipLoadCaseAccX] = gravityDir == 1 ? accel * loadCaseInertia.GravityDirection.X : 0;
            loadVals[St7.ipLoadCaseAccY] = gravityDir == 2 ? accel * loadCaseInertia.GravityDirection.Y : 0;
            loadVals[St7.ipLoadCaseAccZ] = gravityDir == 3 ? accel * loadCaseInertia.GravityDirection.Z : 0;
            err = St7.St7SetLoadCaseDefaults(1, loadCaseId, loadVals);
            if (!St7ErrorCustom(err, "Couldn't set gravity acceleration for a loadcase " + loadCaseId)) return false;

            //Structural and Non-structural Mass
            int structuralMass = loadCaseInertia.StructuralMass ? St7.btTrue : St7.btFalse;
            int nonStructuralMass = loadCaseInertia.NonStructuralMass ? St7.btTrue : St7.btFalse;
            err = St7.St7SetLoadCaseMassOption(1, loadCaseId, (byte)structuralMass, (byte)nonStructuralMass);
            if (!St7ErrorCustom(err, "Couldn't set structural Mass for a loadcase " + loadCaseId)) return false;
            return true;
        }
    }
}

