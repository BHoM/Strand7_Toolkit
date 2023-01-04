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
using BH.oM.Structure.SectionProperties;
using St7API;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Spatial.ShapeProfiles;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool CreateObject(ISectionProperty sectionProperty)
        {
            int secPropId = GetAdapterId<int>(sectionProperty);         
            int err = 0;        

            // creating new beam property. Do not showing an error for update
            err = St7.St7NewBeamProperty(1, secPropId, St7.btBeam, sectionProperty.Name);
            if (err != St7.ERR7_NoError)
            {                
                err = St7.St7SetPropertyName(1, St7.ptBEAMPROP, secPropId, sectionProperty.Name);
                if (!St7ErrorCustom(err, "Could not create or update section property number " + secPropId)) return false;
            }        

            // check first that the material is isotropic              
            if (!(sectionProperty.Material is IIsotropic))
            {
                BHError("Material in section property number " + secPropId + " is not Isotropic.");
                return false;
            }

            // set material to section property
            IIsotropic isotropic = sectionProperty.Material as IIsotropic;
            double[] materialVals = new double[9];
            materialVals[St7.ipBeamModulus] = isotropic.YoungsModulus;
            materialVals[St7.ipBeamPoisson] = isotropic.PoissonsRatio;
            materialVals[St7.ipBeamDensity] = isotropic.Density;
            materialVals[St7.ipBeamAlpha] = isotropic.ThermalExpansionCoeff;
            err = St7.St7SetBeamMaterialData(1, secPropId, materialVals);
            if (!St7ErrorCustom(err, "Could not set material for a section property number " + secPropId)) return false;        
            err = St7.St7SetMaterialName(1, St7.ptBEAMPROP, secPropId, isotropic.Name);
            if (!St7ErrorCustom(err, "Could not set material name for a section property number " + secPropId)) return false;
            err = St7.St7SetBeamUsePoisson(1, secPropId);
            if (!St7ErrorCustom(err, "Could not set Poisson ratio usage for a section property number " + secPropId)) return false;
            // section property geometry set
            (double[], int, string) tuple = GetDimensionsFromSection(sectionProperty as dynamic);
            (double[] dimensions, int sectionType, string profileName) = tuple;
            err = St7.St7SetBeamSectionGeometry(1, secPropId, sectionType, dimensions);
            if (!St7ErrorCustom(err, "Could not set section geometry " + secPropId)) return false;
            err = St7.St7SetBeamSectionName(1, secPropId, profileName);

            // set section properties
            int[] intBeamSec = new int[] { 0 };
            double[] beamSecData = new double[11];
            beamSecData[St7.ipAREA] = sectionProperty.Area;
            beamSecData[St7.ipI11] = sectionProperty.Iy;
            beamSecData[St7.ipI22] = sectionProperty.Iz;
            beamSecData[St7.ipJ] = sectionProperty.J;
            beamSecData[St7.ipSL1] = 0; //shear centre offset
            beamSecData[St7.ipSL2] = 0; //shear centre offset
            beamSecData[St7.ipSA1] = 0; // sectionProperty.Asy;
            beamSecData[St7.ipSA2] = 0; // sectionProperty.Asz;
            beamSecData[St7.ipXBAR] = sectionProperty.Vpy; //centroid X
            beamSecData[St7.ipYBAR] = sectionProperty.Vpz; //centroid Y
            beamSecData[St7.ipANGLE] = 0; // principal axes rotation
            err = St7.St7SetBeamSectionPropertyData(1, secPropId, intBeamSec, beamSecData);
            if (!St7ErrorCustom(err, "Could not set section properties " + secPropId)) return false;

            return true;
        }
        private (double[], int, string) GetDimensionsFromSection(SteelSection section)
        {
            return GetProfileDimensions(section.SectionProfile as dynamic);
        }
        private (double[], int, string) GetDimensionsFromSection(ConcreteSection section)
        {
            return GetProfileDimensions(section.SectionProfile as dynamic);
        }
        private (double[], int, string) GetProfileDimensions(TubeProfile profile)
        {
            return (new double[] { profile.Diameter, 0, 0, profile.Thickness, 0, 0 }, St7.bsCircularHollow, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(AngleProfile profile)
        {
            return (new double[] { profile.Width, profile.Height, 0, profile.FlangeThickness, profile.WebThickness, 0 }, St7.bsLSection, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(BoxProfile profile)
        {
            return (new double[] { profile.Width, profile.Height, 0, profile.Thickness, profile.Thickness, 0 }, St7.bsSquareHollow, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(FabricatedBoxProfile profile)
        {
            return (new double[] { profile.Width, profile.Height, 0, profile.TopFlangeThickness, profile.WebThickness, 0 }, St7.bsSquareHollow, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(ISectionProfile profile)
        {
            return (new double[] { profile.Width, profile.Width, profile.Height, profile.FlangeThickness, profile.FlangeThickness, profile.WebThickness }, St7.bsISection, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(FabricatedISectionProfile profile)
        {
            return (new double[] { profile.TopFlangeWidth, profile.BotFlangeWidth, profile.Height, profile.TopFlangeThickness, profile.BotFlangeThickness, profile.WebThickness }, St7.bsISection, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(ChannelProfile profile)
        {
            return (new double[] { profile.FlangeWidth, profile.Height, 0, profile.FlangeThickness, profile.WebThickness, 0 }, St7.bsLipChannel, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(TSectionProfile profile)
        {
            return (new double[] { profile.Width, profile.Height, 0, profile.FlangeThickness, profile.WebThickness, 0 }, St7.bsTSection, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(RectangleProfile profile)
        {
            return (new double[] { profile.Width, profile.Height, 0, 0, 0, 0 }, St7.bsSquareSolid, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(CircleProfile profile)
        {
            return (new double[] { profile.Diameter, 0, 0, 0, 0, 0 }, St7.bsCircularSolid, profile.Name);
        }
        private (double[], int, string) GetProfileDimensions(ZSectionProfile profile)
        {
            return (new double[] { profile.FlangeWidth, profile.FlangeWidth, profile.Height, profile.FlangeThickness, profile.FlangeThickness, profile.WebThickness }, St7.bsZSection, profile.Name);
        }
    }
}

