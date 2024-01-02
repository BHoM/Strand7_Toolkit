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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Structure.MaterialFragments;
using St7API;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        //Materials are read from element properties. STRAND7 does not separate materials to concrete, steel, timber etc. Separation is done based on Poisson Ratio
        private List<IMaterialFragment> ReadMaterials(List<string> ids = null)
        {
            int err = 0;
            List<IMaterialFragment> materials = new List<IMaterialFragment>();           
            int[] propCount = new int[St7.kMaxEntityTotals - 1];
            int[] propLastNumbers = new int[St7.kMaxEntityTotals - 1];
            err = St7.St7GetTotalProperties(1, propCount, propLastNumbers);
            if (!St7Error(err)) return materials;

            // getting beam materials
            for (int propIndx = 0; propIndx < propCount[St7.ipBeamPropTotal]; propIndx++)
            {
                int propNumber = 0;
                err = St7.St7GetPropertyNumByIndex(1, St7.ptBEAMPROP, propIndx + 1, ref propNumber);
                if (!St7Error(err)) return materials;
                IMaterialFragment material = GetBeamPropertyMaterial(propNumber);
                if (material != null) materials.Add(material);
            }

            // getting plate materials
            for (int propIndx = 0; propIndx < propCount[St7.ipPlatePropTotal]; propIndx++)
            {
                int propNumber = 0;
                err = St7.St7GetPropertyNumByIndex(1, St7.ptPLATEPROP, propIndx + 1, ref propNumber);
                if (!St7Error(err)) return materials;
                IMaterialFragment material = GetPlatePropertyMaterial(propNumber);
                if (material != null) materials.Add(material);
            }

            // getting brick materials
            for (int propIndx = 0; propIndx < propCount[St7.ipBrickPropTotal]; propIndx++)
            {
                int propNumber = 0;
                err = St7.St7GetPropertyNumByIndex(1, St7.ptBRICKPROP, propIndx + 1, ref propNumber);
                if (!St7Error(err)) return materials;
                IMaterialFragment material = GetBrickPropertyMaterial(propNumber);
                if (material != null) materials.Add(material);
            }         
            return materials;
        }

        private IMaterialFragment GetBeamPropertyMaterial(int beamProp)
        {
            int err = 0;
            IMaterialFragment material = null;
            double[] materialArray = new double[9];
            StringBuilder materialName = new StringBuilder(St7.kMaxStrLen);
            err = St7.St7GetBeamMaterialData(1, beamProp, materialArray);
            if (!St7Error(err)) return material;
             err = St7.St7GetMaterialName(1, St7.ptBEAMPROP, beamProp, materialName, St7.kMaxStrLen);
            if (!St7Error(err)) return material;
            // !!!! Materials are set based on Poisson Ratio !!!!
            if (materialArray[St7.ipBeamPoisson] <= 0.2)
                material = BH.Engine.Structure.Create.Concrete(materialName.ToString(), materialArray[St7.ipBeamModulus], materialArray[St7.ipBeamPoisson], materialArray[St7.ipBeamAlpha], materialArray[St7.ipBeamDensity]);
            else material = BH.Engine.Structure.Create.Steel(materialName.ToString(), materialArray[St7.ipBeamModulus], materialArray[St7.ipBeamPoisson], materialArray[St7.ipBeamAlpha], materialArray[St7.ipBeamDensity]);         
            return material;
        }
        /***************************************************/
        private IMaterialFragment GetPlatePropertyMaterial(int plateProp)
        {
            int err = 0;
            IMaterialFragment material = null;
            double[] materialArray = new double[8];
            int materialType = 0;
            int plateType = 0;
            StringBuilder materialName = new StringBuilder(St7.kMaxStrLen);
            err = St7.St7GetPlatePropertyType(1, plateProp, ref plateType, ref materialType);
            if (materialType != St7.mtIsotropic) return material;   // !!! ISOTROPIC ONLY !!!  
            err = St7.St7GetPlateIsotropicMaterial(1, plateProp, materialArray);
            if (!St7Error(err)) return material;
            err = St7.St7GetMaterialName(1, St7.ptPLATEPROP, plateProp, materialName, St7.kMaxStrLen);
            if (!St7Error(err)) return material;
            // !!!! Materials are set based on Poisson Ratio !!!!           
            if (materialArray[St7.ipBeamPoisson] <= 0.2)
                material = BH.Engine.Structure.Create.Concrete(materialName.ToString(), materialArray[St7.ipPlateIsoModulus], materialArray[St7.ipPlateIsoPoisson], materialArray[St7.ipPlateIsoAlpha], materialArray[St7.ipPlateIsoDensity]);
            else material = BH.Engine.Structure.Create.Steel(materialName.ToString(), materialArray[St7.ipPlateIsoModulus], materialArray[St7.ipPlateIsoPoisson], materialArray[St7.ipPlateIsoAlpha], materialArray[St7.ipPlateIsoDensity]);          
            return material;
        }

        private IMaterialFragment GetBrickPropertyMaterial(int brickProp)
        {
            int err = 0;
            IMaterialFragment material = null;
            double[] materialArray = new double[8];
            int materialType = 0;
            StringBuilder materialName = new StringBuilder(St7.kMaxStrLen);
            err = St7.St7GetBrickPropertyType(1, brickProp, ref materialType);
            if (materialType != St7.mtIsotropic) return material;   // !!! ISOTROPIC ONLY !!!  
            err = St7.St7GetBrickIsotropicMaterial(1, brickProp, materialArray);
            if (!St7Error(err)) return material;
            err = St7.St7GetMaterialName(1, St7.ptBRICKPROP, brickProp, materialName, St7.kMaxStrLen);          
            // !!!! Materials are set based on Poisson Ratio !!!!
            if (materialArray[St7.ipBeamPoisson] <= 0.2)
                material = BH.Engine.Structure.Create.Concrete(materialName.ToString(), materialArray[St7.ipBrickIsoModulus], materialArray[St7.ipBrickIsoPoisson], materialArray[St7.ipBrickIsoAlpha], materialArray[St7.ipBrickIsoDensity]);
            else material = BH.Engine.Structure.Create.Steel(materialName.ToString(), materialArray[St7.ipBrickIsoModulus], materialArray[St7.ipBrickIsoPoisson], materialArray[St7.ipBrickIsoAlpha], materialArray[St7.ipBrickIsoDensity]);        
            return material;
        }
    }
}


