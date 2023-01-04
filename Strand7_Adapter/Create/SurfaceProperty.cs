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
using BH.oM.Structure.SurfaceProperties;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool CreateObject(ISurfaceProperty surfaceProperty)
        {
            int uID = 1;
            int platePropId = GetAdapterId<int>(surfaceProperty);           
            int err = 0;
            if (surfaceProperty is ConstantThickness == false)
            {
                BHError("Only constant thickness plate properties are allowed in Strand7");
                return false;
            }
            // check first that the material is isotropic              
            if (surfaceProperty.Material is IIsotropic == false)
            {
                BHError("Material in surface property number " + platePropId + " is not Isotropic.");
                return false;
            }         

            // creating new plate property. Do not showing an error for update
            err = St7.St7NewPlateProperty(uID, platePropId, St7.ptPlateShell, St7.mtIsotropic, surfaceProperty.Name);
            if (err != St7.ERR7_NoError)
            {                
                err = St7.St7SetPropertyName(uID, St7.ptPLATEPROP, platePropId, surfaceProperty.Name);
                if (!St7ErrorCustom(err, "Could not create or update surface property number " + platePropId)) return false;
            }        
                      
            // set material to section property
            IIsotropic isotropic = surfaceProperty.Material as IIsotropic;
            double[] materialVals = new double[8];
            materialVals[St7.ipPlateIsoModulus] = isotropic.YoungsModulus;
            materialVals[St7.ipPlateIsoPoisson] = isotropic.PoissonsRatio;
            materialVals[St7.ipPlateIsoDensity] = isotropic.Density;
            materialVals[St7.ipPlateIsoAlpha] = isotropic.ThermalExpansionCoeff;
            materialVals[St7.ipPlateIsoDampingRatio] = isotropic.DampingRatio;
            err = St7.St7SetPlateIsotropicMaterial(uID, platePropId, materialVals);
            if (!St7ErrorCustom(err, "Could not set material for a plate property number " + platePropId)) return false; 
            err = St7.St7SetMaterialName(1, St7.ptPLATEPROP, platePropId, isotropic.Name);
            if (!St7ErrorCustom(err, "Could not set material name for a plate property number " + platePropId)) return false;

            // set plate thickness
            double thickness = (surfaceProperty as ConstantThickness).Thickness;
            double[] plateThickness = new double[] { thickness, thickness };
            err = St7.St7SetPlateThickness(uID, platePropId, plateThickness);         
            if (!St7ErrorCustom(err, "Could not set plate thickness " + platePropId)) return false;

            return true;
        }       
    }
}

