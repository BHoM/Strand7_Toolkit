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
using BH.oM.Structure.Elements;
using St7API;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool CreateObject(Bar bar)
        {
            int err = 0;
            int uID = 1;
            int barId = GetAdapterId<int>(bar);
            int secPropId = GetAdapterId<int>(bar.SectionProperty);         
            int[] beamNodes = new int[St7.kMaxElementNode + 1];
            beamNodes[0] = 2;
            beamNodes[1] = GetAdapterId<int>(bar.StartNode);
            beamNodes[2] = GetAdapterId<int>(bar.EndNode);
     
            // geometry
            err = St7.St7SetElementConnection(uID, St7.tyBEAM, barId, secPropId, beamNodes);
            if (!St7ErrorCustom(err, "Could not create beam number " + barId)) return false;
            err = St7.St7SetBeamReferenceAngle1(uID, barId, new double[] { bar.OrientationAngle * 180 / System.Math.PI });
            if (!St7ErrorCustom(err, "Could not set orientation angle for a beam number " + barId)) return false;

            // type
            //if (bar.FEAType == BarFEAType.Cable)
            //{
            //    err = St7.St7SetBeamPropertyType(uID, secPropId, St7.btCable);
            //    if (!St7ErrorCustom(err, "Could not set cable type for a beam number " + barId)) return false;
            //}
            //else if (bar.FEAType == BarFEAType.CompressionCutoff)
            //{
            //    err = St7.St7SetBeamPropertyType(uID, secPropId, St7.btCutoff);
            //    if (!St7ErrorCustom(err, "Could not set cutoff type for a beam number " + barId)) return false;
            //    err = St7.St7SetCutoffBarData(uID, secPropId, new int[] { St7.cbDuctile, St7.btTrue }, new double[] { 0, 1e20 });
            //    if (!St7ErrorCustom(err, "Could not set cutoff type for a beam number " + barId)) return false;
            //}
            if (bar.FEAType == BarFEAType.CompressionOnly)
            {
                err = St7.St7SetBeamPropertyType(uID, secPropId, St7.btContact);
                if (!St7ErrorCustom(err, "Could not set contact type for a beam number " + barId)) return false;
                int[] settings = new int[7];
                settings[St7.ipContactType] = St7.ctNormal;
                settings[St7.ipContactSubType] = St7.tuCompression;
                settings[St7.ipDynamicStiffness] = St7.btTrue;
                settings[St7.ipUpdateDirection] = St7.btFalse;
                settings[St7.ipFrictionModel] = St7.cfPlastic;
                settings[St7.ipFrictionYieldType] = St7.cyElliptical;
                settings[St7.ipTensionLateralStiffness] = St7.btFalse;
                err = St7.St7SetPointContactData(uID, secPropId, settings, new double[] { 1e6, 0, 0, 0, 0 });
                if (!St7ErrorCustom(err, "Could not set compression contact properties for a beam number " + barId)) return false;
            }
            //else if (bar.FEAType == BarFEAType.TensionCutoff)
            //{
            //    err = St7.St7SetBeamPropertyType(uID, secPropId, St7.btCutoff);
            //    if (!St7ErrorCustom(err, "Could not set cutoff type for a beam number " + barId)) return false;
            //    err = St7.St7SetCutoffBarData(uID, secPropId, new int[] { St7.cbDuctile, St7.btTrue }, new double[] { 1e20, 0 });
            //    if (!St7ErrorCustom(err, "Could not set cutoff type for a beam number " + barId)) return false;
            //}
            else if (bar.FEAType == BarFEAType.TensionOnly)
            {
                err = St7.St7SetBeamPropertyType(uID, secPropId, St7.btContact);
                if (!St7ErrorCustom(err, "Could not set contact type for a beam number " + barId)) return false;
                int[] settings = new int[7];
                settings[St7.ipContactType] = St7.ctTension;
                settings[St7.ipContactSubType] = St7.tuTension;
                settings[St7.ipDynamicStiffness] = St7.btTrue;
                settings[St7.ipUpdateDirection] = St7.btFalse;
                settings[St7.ipFrictionModel] = St7.cfPlastic;
                settings[St7.ipFrictionYieldType] = St7.cyElliptical;
                settings[St7.ipTensionLateralStiffness] = St7.btFalse;
                err = St7.St7SetPointContactData(uID, secPropId, settings, new double[] { 1e6, 0, 0, 0, 0 });            
                if (!St7ErrorCustom(err, "Could not set tension contact properties for a beam number " + barId)) return false;
            }
            // releases

            int[] statusTranslStart = new int[3];
            statusTranslStart[0] = ConvertBHoMReleaseToStrand7(bar.Release.StartRelease.TranslationX, bar.Release.StartRelease.TranslationalStiffnessX);
            statusTranslStart[1] = ConvertBHoMReleaseToStrand7(bar.Release.StartRelease.TranslationY, bar.Release.StartRelease.TranslationalStiffnessY);
            statusTranslStart[2] = ConvertBHoMReleaseToStrand7(bar.Release.StartRelease.TranslationZ, bar.Release.StartRelease.TranslationalStiffnessZ);
            double[] stiffnessTranslStart = new double[3];
            stiffnessTranslStart[0] = bar.Release.StartRelease.TranslationalStiffnessX;
            stiffnessTranslStart[1] = bar.Release.StartRelease.TranslationalStiffnessY;
            stiffnessTranslStart[2] = bar.Release.StartRelease.TranslationalStiffnessZ;
            err = St7.St7SetBeamTRelease3(1, barId, 1, statusTranslStart, stiffnessTranslStart);
            if (!St7ErrorCustom(err, "Could not set translation releases for a beam number " + barId)) return false;

            int[] statusRotationalStart = new int[3];
            statusRotationalStart[0] = ConvertBHoMReleaseToStrand7(bar.Release.StartRelease.RotationX, bar.Release.StartRelease.RotationalStiffnessX);
            statusRotationalStart[1] = ConvertBHoMReleaseToStrand7(bar.Release.StartRelease.RotationY, bar.Release.StartRelease.RotationalStiffnessY);
            statusRotationalStart[2] = ConvertBHoMReleaseToStrand7(bar.Release.StartRelease.RotationZ, bar.Release.StartRelease.RotationalStiffnessZ);
            double[] stiffnessRotationalStart = new double[3];
            stiffnessRotationalStart[0] = bar.Release.StartRelease.RotationalStiffnessX;
            stiffnessRotationalStart[1] = bar.Release.StartRelease.RotationalStiffnessY;
            stiffnessRotationalStart[2] = bar.Release.StartRelease.RotationalStiffnessZ;
            err = St7.St7SetBeamRRelease3(1, barId, 1, statusRotationalStart, stiffnessRotationalStart);
            if (!St7ErrorCustom(err, "Could not set rotational releases for a beam number " + barId)) return false;

            int[] statusTranslEnd = new int[3];
            statusTranslEnd[0] = ConvertBHoMReleaseToStrand7(bar.Release.EndRelease.TranslationX, bar.Release.EndRelease.TranslationalStiffnessX);
            statusTranslEnd[1] = ConvertBHoMReleaseToStrand7(bar.Release.EndRelease.TranslationY, bar.Release.EndRelease.TranslationalStiffnessY);
            statusTranslEnd[2] = ConvertBHoMReleaseToStrand7(bar.Release.EndRelease.TranslationZ, bar.Release.EndRelease.TranslationalStiffnessZ);
            double[] stiffnessTranslEnd = new double[3];
            stiffnessTranslEnd[0] = bar.Release.EndRelease.TranslationalStiffnessX;
            stiffnessTranslEnd[1] = bar.Release.EndRelease.TranslationalStiffnessY;
            stiffnessTranslEnd[2] = bar.Release.EndRelease.TranslationalStiffnessZ;
            err = St7.St7SetBeamTRelease3(1, barId, 2, statusTranslEnd, stiffnessTranslEnd);
            if (!St7ErrorCustom(err, "Could not set translation releases for a beam number " + barId)) return false;

            int[] statusRotationalEnd = new int[3];
            statusRotationalEnd[0] = ConvertBHoMReleaseToStrand7(bar.Release.EndRelease.RotationX, bar.Release.EndRelease.RotationalStiffnessX);
            statusRotationalEnd[1] = ConvertBHoMReleaseToStrand7(bar.Release.EndRelease.RotationY, bar.Release.EndRelease.RotationalStiffnessY);
            statusRotationalEnd[2] = ConvertBHoMReleaseToStrand7(bar.Release.EndRelease.RotationZ, bar.Release.EndRelease.RotationalStiffnessZ);
            double[] stiffnessRotationalEnd = new double[3];
            stiffnessRotationalEnd[0] = bar.Release.EndRelease.RotationalStiffnessX;
            stiffnessRotationalEnd[1] = bar.Release.EndRelease.RotationalStiffnessY;
            stiffnessRotationalEnd[2] = bar.Release.EndRelease.RotationalStiffnessZ;
            err = St7.St7SetBeamRRelease3(1, barId, 2, statusRotationalEnd, stiffnessRotationalEnd);
            if (!St7ErrorCustom(err, "Could not set rotational releases for a beam number " + barId)) return false;
            return true;
        }

        private static int ConvertBHoMReleaseToStrand7(oM.Structure.Constraints.DOFType bhRestr, double bhStiff)
        {
            if (bhRestr == oM.Structure.Constraints.DOFType.Fixed) return St7.brFixed;
            if (bhRestr == oM.Structure.Constraints.DOFType.Free && bhStiff != 0) return St7.brPartial;
            else return St7.brReleased;
        }
        /***************************************************/

    }
}


