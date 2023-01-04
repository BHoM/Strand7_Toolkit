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

        private bool CreateObject(BarDistributedMass distributedMass)
        {
            int err = 0;
            int uID = 1;
            double tol = 0.001;
            int loadCaseId = GetAdapterId<int>(distributedMass.Loadcase);

            foreach (Bar bar in distributedMass.Objects.Elements)
            {
                double length = BH.Engine.Geometry.Query.Length(BH.Engine.Structure.Query.Centreline(bar));
                int barId = GetAdapterId<int>(bar);
                if (distributedMass.MassA > 0 || distributedMass.MassB > 0)
                {
                    int dlType = St7.dlLinear;

                    double[] values = new double[10];
                    values[0] = distributedMass.MassA;
                    values[1] = distributedMass.MassB;
                    values[4] = distributedMass.DistanceFromA / length;
                    values[5] = distributedMass.DistanceFromB / length;
                    values[6] = distributedMass.DynamicFactor;
                    values[7] = distributedMass.Offset.X;
                    values[8] = distributedMass.Offset.Y;
                    values[9] = distributedMass.Offset.Z;
                    int globalDistMassCount = 0;
                    err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamNSMass, ref globalDistMassCount);
                    if (!St7ErrorCustom(err, "Couldn't get a number of global distributed beam masses for a loadcase " + loadCaseId + " beam " + barId)) return false;
                    err = St7.St7SetBeamNSMass10ID(uID, barId, loadCaseId, dlType, globalDistMassCount + 1, values);
                    if (!St7ErrorCustom(err, "Couldn't set a distributed beam load for a loadcase " + loadCaseId + " beam " + barId)) return false;
                }
            }
            return true;
        }      
    }
}

