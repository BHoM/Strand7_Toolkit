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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Structure.SectionProperties;
using St7API;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Spatial.ShapeProfiles;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Adapter.Strand7;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private List<ISurfaceProperty> ReadSurfaceProperty(List<int> ids = null)
        {
            int uID = 1;
            int err = 0;
            List<ISurfaceProperty> propertyList = new List<ISurfaceProperty>();
       
            int[] propCount = new int[St7.kMaxEntityTotals - 1];
            int[] propLastNumbers = new int[St7.kMaxEntityTotals - 1];
            err = St7.St7GetTotalProperties(uID, propCount, propLastNumbers);
            if (!St7Error(err)) return propertyList;
            int numberOfPlateProps = propCount[St7.ipPlatePropTotal];
            for (int pp = 0; pp < numberOfPlateProps; pp++)
            {
                int propNumber = 0;
                err = St7.St7GetPropertyNumByIndex(uID, St7.ptPLATEPROP, pp + 1, ref propNumber);
                if (!St7Error(err)) return propertyList;
                int plateType = 0;
                int materialType = 0;
                err = St7.St7GetPlatePropertyType(uID, propNumber, ref plateType, ref materialType);
                if (!St7Error(err)) return propertyList;
                StringBuilder propertyName = new StringBuilder(St7.kMaxStrLen);           
                err = St7.St7GetPropertyName(uID, St7.ptPLATEPROP, propNumber, propertyName, St7.kMaxStrLen);
                if (!St7Error(err)) return propertyList;             
                IMaterialFragment material = GetPlateIsotropicMaterial(propNumber);
                if ((St7PlateType)plateType == St7PlateType.LoadPatch)
                {
                    LoadingPanelProperty loadingPanelProperty = new LoadingPanelProperty();
                    loadingPanelProperty.Name = propertyName.ToString();
                    SetAdapterId(loadingPanelProperty, propNumber);                 
                    loadingPanelProperty.CustomData["ShellType"] = (St7PlateType)plateType;
                    propertyList.Add(loadingPanelProperty);
                }
                else
                {
                    double[] plateThickness = new double[2];
                    err = St7.St7GetPlateThickness(uID, propNumber, plateThickness);
                    if (!St7Error(err)) return propertyList;
                    ConstantThickness panelConstant = new ConstantThickness();
                    panelConstant.Name = propertyName.ToString();
                    SetAdapterId(panelConstant, propNumber);    
                    panelConstant.Material = material;
                    panelConstant.Thickness = plateThickness[1]; // here is bending thickness
                    panelConstant.PanelType = PanelType.Undefined;
                    panelConstant.CustomData["ShellType"] = (St7PlateType)plateType;
                    propertyList.Add(panelConstant);
                }             
            }
            return propertyList;
        }
        private IMaterialFragment GetPlateIsotropicMaterial(int platePropNumber)
        {
            int uID = 1;
            int err = 0;
            IMaterialFragment material = null;
            double[] materialArray = new double[8];
            StringBuilder materialName = new StringBuilder(St7.kMaxStrLen);
            err = St7.St7GetPlateIsotropicMaterial(uID, platePropNumber, materialArray);
            if (!St7Error(err)) return material;
            err = St7.St7GetMaterialName(uID, St7.ptPLATEPROP, platePropNumber, materialName, St7.kMaxStrLen);
            if (!St7Error(err)) return material;
            // !!!! Materials are set based on Poisson Ratio !!!!
            if (materialArray[St7.ipPlateIsoPoisson] <= 0.2)
                material = BH.Engine.Structure.Create.Concrete(materialName.ToString(), materialArray[St7.ipPlateIsoModulus], materialArray[St7.ipPlateIsoPoisson], materialArray[St7.ipPlateIsoAlpha], materialArray[St7.ipPlateIsoDensity], materialArray[St7.ipPlateIsoDampingRatio]);
            else material = BH.Engine.Structure.Create.Steel(materialName.ToString(), materialArray[St7.ipPlateIsoModulus], materialArray[St7.ipPlateIsoPoisson], materialArray[St7.ipPlateIsoAlpha], materialArray[St7.ipPlateIsoDensity], materialArray[St7.ipPlateIsoDampingRatio]);
            return material;
        }
      
    }
}

