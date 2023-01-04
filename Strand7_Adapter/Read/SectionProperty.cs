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

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private List<ISectionProperty> ReadSectionProperties(List<int> ids = null)
        {
            int err = 0;
            List<ISectionProperty> beamSections = new List<ISectionProperty>();
            int[] propCount = new int[St7.kMaxEntityTotals - 1];
            int[] propLastNumbers = new int[St7.kMaxEntityTotals - 1];
            err = St7.St7GetTotalProperties(1, propCount, propLastNumbers);
            if (!St7Error(err)) return beamSections;
            int numberOfBeamProps = propCount[St7.ipBeamPropTotal];
            for (int pp = 0; pp < numberOfBeamProps; pp++)
            {
                int propNumber = 0;
                err = St7.St7GetPropertyNumByIndex(1, St7.ptBEAMPROP, pp + 1, ref propNumber);
                if (!St7Error(err)) return beamSections;
                int sectionTypeVar = 0;
                double[] dimArray = new double[6];
                StringBuilder propertyName = new StringBuilder(St7.kMaxStrLen);
                err = St7.St7GetBeamSectionGeometry(1, propNumber, ref sectionTypeVar, dimArray);
                if (!St7Error(err)) return beamSections;
                err = St7.St7GetPropertyName(1, St7.ptBEAMPROP, propNumber, propertyName, St7.kMaxStrLen);
                if (!St7Error(err)) return beamSections;
                IMaterialFragment material = GetBeamPropertyMaterial(propNumber);              
                IProfile sectionProfile;
                switch (sectionTypeVar)
                {
                    case St7.bsNullSection:
                        sectionProfile = null;
                        break;
                    case St7.bsCircularSolid:
                        sectionProfile = Engine.Spatial.Create.CircleProfile(dimArray[0]);
                        break;
                    case St7.bsCircularHollow:
                        sectionProfile = BH.Engine.Spatial.Create.TubeProfile(dimArray[0], dimArray[3]);
                        break;
                    case St7.bsSquareSolid:
                        sectionProfile = BH.Engine.Spatial.Create.RectangleProfile(dimArray[1], dimArray[0],  0);
                        break;
                    case St7.bsSquareHollow:
                        sectionProfile = BH.Engine.Spatial.Create.FabricatedBoxProfile(dimArray[1], dimArray[0], dimArray[4], dimArray[3], dimArray[3], 0);                    
                        break;
                    case St7.bsTSection:
                        sectionProfile = BH.Engine.Spatial.Create.TSectionProfile(dimArray[1], dimArray[0], dimArray[4], dimArray[3], 0, 0);
                        break;
                    case St7.bsLipChannel:
                        sectionProfile = BH.Engine.Spatial.Create.ChannelProfile(dimArray[1], dimArray[0], dimArray[4], dimArray[3], 0, 0);
                        break;
                    case St7.bsTopHatChannel:
                        sectionProfile = null;
                        break;
                    case St7.bsISection:
                        sectionProfile = BH.Engine.Spatial.Create.FabricatedISectionProfile(dimArray[2], dimArray[0], dimArray[1], dimArray[5], dimArray[3], dimArray[4], 0);
                        break;                      
                    case St7.bsLSection:
                        sectionProfile = BH.Engine.Spatial.Create.AngleProfile(dimArray[1], dimArray[0], dimArray[4], dimArray[3], 0, 0);
                        break;
                    case St7.bsZSection:
                        sectionProfile = BH.Engine.Spatial.Create.ZSectionProfile(dimArray[2], dimArray[0], dimArray[5], dimArray[3], 0, 0);
                        break;
                    case St7.bsUserSection:
                        sectionProfile = null;
                        break;
                    case St7.bsTrapezoidSolid:
                        sectionProfile = null;
                        break;
                    case St7.bsTrapezoidHollow:
                        sectionProfile = null;
                        break;
                    case St7.bsTriangleSolid:
                        sectionProfile = null;
                        break;
                    case St7.bsTriangleHollow:
                        sectionProfile = null;
                        break;
                    case St7.bsCruciform:
                        sectionProfile = null;
                        break;
                    default:
                        sectionProfile = null;
                        break;
                }
                ISectionProperty sectionProperty = null;
                if (material is null || sectionProfile is null) continue;          
                if (material is Concrete) sectionProperty = BH.Engine.Structure.Create.ConcreteSectionFromProfile(sectionProfile, (Concrete)material, propertyName.ToString());
                else sectionProperty = BH.Engine.Structure.Create.SteelSectionFromProfile(sectionProfile, (Steel)material, propertyName.ToString());
                SetAdapterId(sectionProperty, propNumber);             
                beamSections.Add(sectionProperty);
            }
            return beamSections;
        }
    }
}

