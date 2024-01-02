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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Engine.Geometry;
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

        private bool CreateObject(AreaUniformlyDistributedLoad areaUDL)
        {
            int uID = 1;
            int err = 0;

            int loadCaseId = GetAdapterId<int>(areaUDL.Loadcase);
            double[] pressures = new double[3];
            pressures[0] = areaUDL.Pressure.X;
            pressures[1] = areaUDL.Pressure.Y;
            pressures[2] = areaUDL.Pressure.Z;
            double[] normalPressures = new double[2];
            normalPressures[0] = areaUDL.Pressure.Z; // -z surface of the plate.
            double[] shearPressures = new double[2];
            shearPressures[0] = areaUDL.Pressure.X;
            shearPressures[1] = areaUDL.Pressure.Y;
            int project = areaUDL.Projected ? St7.ppProjResultant : St7.ppNone;

            if (areaUDL.Axis == LoadAxis.Local)
            {
                foreach (IAreaElement areaElement in areaUDL.Objects.Elements)
                {
                    if (areaElement is Panel)
                    {
                        int elementId = GetAdapterId<int>(areaElement);
                        if (areaUDL.Pressure.Z != 0)
                        {
                            err = St7.St7SetPlateNormalPressure2(uID, elementId, loadCaseId, normalPressures);
                            if (!St7ErrorCustom(err, "Couldn't set normal pressure for a loadcase " + loadCaseId + " plate " + elementId)) return false;
                        }
                        if (areaUDL.Pressure.X != 0 || areaUDL.Pressure.Y != 0)
                        {
                            err = St7.St7SetPlateShear2(uID, elementId, loadCaseId, shearPressures);
                            if (!St7ErrorCustom(err, "Couldn't set shear pressure for a loadcase " + loadCaseId + " plate " + elementId)) return false;
                        }
                    }
                    else if (areaElement is FEMesh)
                    {
                        foreach (FEMeshFace feFace in (areaElement as FEMesh).Faces)
                        {
                            int elementId = GetAdapterId<int>(feFace);
                            if (areaUDL.Pressure.Z != 0)
                            {
                                err = St7.St7SetPlateNormalPressure2(uID, elementId, loadCaseId, normalPressures);
                                if (!St7ErrorCustom(err, "Couldn't set normal pressure for a loadcase " + loadCaseId + " plate " + elementId)) return false;
                            }
                            if (areaUDL.Pressure.X != 0 || areaUDL.Pressure.Y != 0)
                            {
                                err = St7.St7SetPlateShear2(uID, elementId, loadCaseId, shearPressures);
                                if (!St7ErrorCustom(err, "Couldn't set shear pressure for a loadcase " + loadCaseId + " plate " + elementId)) return false;
                            }
                        }
                    }
                }
            }
            if (areaUDL.Axis == LoadAxis.Global && areaUDL.Pressure.Length() > 0)
            {
                foreach (IAreaElement areaElement in areaUDL.Objects.Elements)
                {
                    if (areaElement is Panel)
                    {
                        int elementId = GetAdapterId<int>(areaElement);
                        err = St7.St7SetPlateGlobalPressure3S(uID, elementId, St7.psPlateZPlus, project, loadCaseId, pressures);
                        if (!St7ErrorCustom(err, "Couldn't set global pressure for a loadcase " + loadCaseId + " plate " + elementId)) return false;
                    }
                    else if (areaElement is FEMesh)
                    {
                        foreach (FEMeshFace feFace in (areaElement as FEMesh).Faces)
                        {
                            int elementId = GetAdapterId<int>(feFace);
                            err = St7.St7SetPlateGlobalPressure3S(uID, elementId, St7.psPlateZPlus, project, loadCaseId, pressures);
                            if (!St7ErrorCustom(err, "Couldn't set global pressure for a loadcase " + loadCaseId + " plate " + elementId)) return false;
                        }
                    }
                }
            }
            return true;
        }
        /***************************************************/
    }
}


