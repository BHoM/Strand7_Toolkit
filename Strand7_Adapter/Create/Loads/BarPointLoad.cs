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
       
        private bool CreateObject(BarPointLoad barPointLoad)
        {
            int err = 0;
            int uID = 1;
            int loadCaseId = GetAdapterId<int>(barPointLoad.Loadcase);

            // *************************** GLOBAL ***************************
            if (barPointLoad.Axis == LoadAxis.Global)
            {
                foreach (Bar bar in barPointLoad.Objects.Elements)
                {
                    double length = BH.Engine.Geometry.Query.Length(BH.Engine.Structure.Query.Centreline(bar));
                    int barId = GetAdapterId<int>(bar);
                    // creating global Point Forces
                    if (BH.Engine.Geometry.Query.Length(barPointLoad.Force) > 0)
                    {
                        // get number of global point forces at the beam
                        int globalPointForceCount = 0;
                        err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamCFG, ref globalPointForceCount);
                        if (!St7ErrorCustom(err, "Couldn't get a number of global point beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        double[] forces = new double[4];
                        forces[0] = barPointLoad.Force.X;
                        forces[1] = barPointLoad.Force.Y;
                        forces[2] = barPointLoad.Force.Z;
                        forces[3] = barPointLoad.DistanceFromA / length;
                        err = St7.St7SetBeamPointForceGlobal4ID(uID, barId, loadCaseId, globalPointForceCount + 1, forces);
                        if (!St7ErrorCustom(err, "Couldn't set global point beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                    }
                    // creating global Point Moments
                    if (BH.Engine.Geometry.Query.Length(barPointLoad.Moment) > 0)
                    {
                        // get number of global point moments at the beam
                        int globalPointMomentCount = 0;
                        err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamCMG, ref globalPointMomentCount);
                        if (!St7ErrorCustom(err, "Couldn't get a number of global point beam moments for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        double[] moments = new double[4];
                        moments[0] = barPointLoad.Moment.X;
                        moments[1] = barPointLoad.Moment.Y;
                        moments[2] = barPointLoad.Moment.Z;
                        moments[3] = barPointLoad.DistanceFromA / length;
                        err = St7.St7SetBeamPointMomentGlobal4ID(uID, barId, loadCaseId, globalPointMomentCount + 1, moments);
                        if (!St7ErrorCustom(err, "Couldn't set global point beam moments for a loadcase " + loadCaseId + " beam " + barId)) return false;
                    }
                }
            }
            // *************************** LOCAL ****************************
            if (barPointLoad.Axis == LoadAxis.Local)
            {
                foreach (Bar bar in barPointLoad.Objects.Elements)
                {
                    double length = BH.Engine.Geometry.Query.Length(BH.Engine.Structure.Query.Centreline(bar));
                    int barId = GetAdapterId<int>(bar);

                    if (BH.Engine.Geometry.Query.Length(barPointLoad.Force) > 0)
                    {
                        // get number of local point forces at the beam
                        int localPointForceCount = 0;
                        err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamCFL, ref localPointForceCount);
                        if (!St7ErrorCustom(err, "Couldn't get a number of local point beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        double[] forces = new double[4];
                        forces[0] = barPointLoad.Force.X;
                        forces[1] = barPointLoad.Force.Y;
                        forces[2] = barPointLoad.Force.Z;
                        forces[3] = barPointLoad.DistanceFromA / length;
                        err = St7.St7SetBeamPointForcePrincipal4ID(uID, barId, loadCaseId, localPointForceCount + 1, forces);
                        if (!St7ErrorCustom(err, "Couldn't set local point beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                    }
                    // creating global Point Moments
                    if (BH.Engine.Geometry.Query.Length(barPointLoad.Moment) > 0)
                    {
                        // get number of local point moments at the beam
                        int localPointMomentCount = 0;
                        err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamCML, ref localPointMomentCount);
                        if (!St7ErrorCustom(err, "Couldn't get a number of local point beam moments for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        double[] moments = new double[4];
                        moments[0] = barPointLoad.Moment.X;
                        moments[1] = barPointLoad.Moment.Y;
                        moments[2] = barPointLoad.Moment.Z;
                        moments[3] = barPointLoad.DistanceFromA / length;
                        err = St7.St7SetBeamPointMomentPrincipal4ID(uID, barId, loadCaseId, localPointMomentCount + 1, moments);
                        if (!St7ErrorCustom(err, "Couldn't set local point beam moments for a loadcase " + loadCaseId + " beam " + barId)) return false;
                    }
                }
            }
            return true;
        }
       
        /***************************************************/
    }
}


