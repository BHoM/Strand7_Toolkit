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
       
        private bool CreateObject(BarVaryingDistributedLoad distributedLoad)
        {
            int err = 0;
            int uID = 1;
            double tol = 0.001;
            int loadCaseId = GetAdapterId<int>(distributedLoad.Loadcase);
           
            // *************************** GLOBAL DISTRIBUTED ***************************
            if (distributedLoad.Axis == LoadAxis.Global)
            {
                foreach (Bar bar in distributedLoad.Objects.Elements)
                {
                    double length = BH.Engine.Geometry.Query.Length(BH.Engine.Structure.Query.Centreline(bar));
                    int barId = GetAdapterId<int>(bar);                   
                    if (BH.Engine.Geometry.Query.SquareLength(distributedLoad.ForceAtStart) > 0 || BH.Engine.Geometry.Query.SquareLength(distributedLoad.ForceAtEnd) > 0)
                    {
                        int dlType = St7.dlLinear;
                        int projected = distributedLoad.Projected ? St7.bpProjected : St7.bpNone;

                        // setting different directions                     
                        if (Math.Abs(distributedLoad.ForceAtStart.X) > tol || Math.Abs(distributedLoad.ForceAtEnd.X) > tol)
                        {
                            int beamDir = 1;   
                            double[] values = new double[6];
                            values[0] = distributedLoad.ForceAtStart.X;
                            values[1] = distributedLoad.ForceAtEnd.X;
                            values[4] = distributedLoad.StartPosition / length;
                            values[5] = distributedLoad.EndPosition / length;
                            int globalDistForceCount = 0;
                            err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamDLG, ref globalDistForceCount);
                            if (!St7ErrorCustom(err, "Couldn't get a number of global distributed beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                            err = St7.St7SetBeamDistributedForceGlobal6ID(uID, barId, beamDir, projected, loadCaseId, dlType, globalDistForceCount + 1, values);
                            if (!St7ErrorCustom(err, "Couldn't set a distributed beam load for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        }         
                        if (Math.Abs(distributedLoad.ForceAtStart.Y) > tol || Math.Abs(distributedLoad.ForceAtEnd.Y) > tol)
                        {
                            int beamDir = 2;
                            double[] values = new double[6];
                            values[0] = distributedLoad.ForceAtStart.Y;
                            values[1] = distributedLoad.ForceAtEnd.Y;
                            values[4] = distributedLoad.StartPosition / length;
                            values[5] = distributedLoad.EndPosition / length;
                            int globalDistForceCount = 0;
                            err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamDLG, ref globalDistForceCount);
                            if (!St7ErrorCustom(err, "Couldn't get a number of global distributed beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                            err = St7.St7SetBeamDistributedForceGlobal6ID(uID, barId, beamDir, projected, loadCaseId, dlType, globalDistForceCount + 1, values);
                            if (!St7ErrorCustom(err, "Couldn't set a distributed beam load for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        }                       
                        if (Math.Abs(distributedLoad.ForceAtStart.Z) > tol || Math.Abs(distributedLoad.ForceAtEnd.Z) > tol)
                        {
                            int beamDir = 3;
                            double[] values = new double[6];
                            values[0] = distributedLoad.ForceAtStart.Z;
                            values[1] = distributedLoad.ForceAtEnd.Z;
                            values[4] = distributedLoad.StartPosition / length;
                            values[5] = distributedLoad.EndPosition / length;
                            int globalDistForceCount = 0;
                            err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamDLG, ref globalDistForceCount);
                            if (!St7ErrorCustom(err, "Couldn't get a number of global distributed beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                            err = St7.St7SetBeamDistributedForceGlobal6ID(uID, barId, beamDir, projected, loadCaseId, dlType, globalDistForceCount + 1, values);
                            if (!St7ErrorCustom(err, "Couldn't set a distributed beam load for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        }
                    }                  
                }
            }
            // *************************** PRINCIPAL DISTRIBUTED ***************************
            if (distributedLoad.Axis == LoadAxis.Local)
            {
                foreach (Bar bar in distributedLoad.Objects.Elements)
                {
                    // get a principal coordinate system first
                    int barId = GetAdapterId<int>(bar);
                    double length = BH.Engine.Geometry.Query.Length(BH.Engine.Structure.Query.Centreline(bar));
                    // ******************************* FORCES  **********************************
                    if (BH.Engine.Geometry.Query.SquareLength(distributedLoad.ForceAtStart) > 0 || BH.Engine.Geometry.Query.SquareLength(distributedLoad.ForceAtEnd) > 0)
                    {
                        int dlType = St7.dlLinear; 
                        // setting different directions          
                        if (Math.Abs(distributedLoad.ForceAtStart.X) > tol || Math.Abs(distributedLoad.ForceAtEnd.X) > tol)
                        {
                            int beamDir = 1;
                            double[] values = new double[6];
                            values[0] = distributedLoad.ForceAtStart.X;
                            values[1] = distributedLoad.ForceAtEnd.X;
                            values[4] = distributedLoad.StartPosition / length;
                            values[5] = distributedLoad.EndPosition / length;
                            int localDistForceCount = 0;
                            err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamDLL, ref localDistForceCount);
                            if (!St7ErrorCustom(err, "Couldn't get a number of principal distributed beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                            err = St7.St7SetBeamDistributedForcePrincipal6ID(uID, barId, beamDir, loadCaseId, dlType, localDistForceCount + 1, values);
                            if (!St7ErrorCustom(err, "Couldn't set a distributed beam load for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        }             
                        if (Math.Abs(distributedLoad.ForceAtStart.Y) > tol || Math.Abs(distributedLoad.ForceAtEnd.Y) > tol)
                        {
                            int beamDir = 2;
                            double[] values = new double[6];
                            values[0] = distributedLoad.ForceAtStart.Y;
                            values[1] = distributedLoad.ForceAtEnd.Y;
                            values[4] = distributedLoad.StartPosition / length;
                            values[5] = distributedLoad.EndPosition / length;
                            int localDistForceCount = 0;
                            err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamDLL, ref localDistForceCount);
                            if (!St7ErrorCustom(err, "Couldn't get a number of principal distributed beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                            err = St7.St7SetBeamDistributedForcePrincipal6ID(uID, barId, beamDir, loadCaseId, dlType, localDistForceCount + 1, values);
                            if (!St7ErrorCustom(err, "Couldn't set a distributed beam load for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        }
                        if (Math.Abs(distributedLoad.ForceAtStart.Z) > tol || Math.Abs(distributedLoad.ForceAtEnd.Z) > tol)
                        {
                            int beamDir = 3;
                            double[] values = new double[6];
                            values[0] = distributedLoad.ForceAtStart.Z;
                            values[1] = distributedLoad.ForceAtEnd.Z;
                            values[4] = distributedLoad.StartPosition / length;
                            values[5] = distributedLoad.EndPosition / length;
                            int localDistForceCount = 0;
                            err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamDLL, ref localDistForceCount);
                            if (!St7ErrorCustom(err, "Couldn't get a number of principal distributed beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                            err = St7.St7SetBeamDistributedForcePrincipal6ID(uID, barId, beamDir, loadCaseId, dlType, localDistForceCount + 1, values);
                            if (!St7ErrorCustom(err, "Couldn't set a distributed beam load for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        }
                    }
                    // ******************************* MOMENTS  **********************************
                    if (BH.Engine.Geometry.Query.SquareLength(distributedLoad.MomentAtStart) > 0 || BH.Engine.Geometry.Query.SquareLength(distributedLoad.MomentAtEnd) > 0)
                    {
                        int dlType = St7.dlLinear;
                        // setting different directions                     
                        if (Math.Abs(distributedLoad.MomentAtStart.X) > tol || Math.Abs(distributedLoad.MomentAtEnd.X) > tol)
                        {
                            int beamDir = 1;
                            double[] values = new double[6];
                            values[0] = distributedLoad.MomentAtStart.X;
                            values[1] = distributedLoad.MomentAtEnd.X;
                            values[4] = distributedLoad.StartPosition / length;
                            values[5] = distributedLoad.EndPosition / length;
                            int localDistMomentCount = 0;
                            err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamDML, ref localDistMomentCount);
                            if (!St7ErrorCustom(err, "Couldn't get a number of principal distributed beam moments for a loadcase " + loadCaseId + " beam " + barId)) return false;
                            err = St7.St7SetBeamDistributedMomentPrincipal6ID(uID, barId, beamDir, loadCaseId, dlType, localDistMomentCount + 1, values);
                            if (!St7ErrorCustom(err, "Couldn't set a distributed beam moments for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        }                       
                        if (Math.Abs(distributedLoad.MomentAtStart.Y) > tol || Math.Abs(distributedLoad.MomentAtEnd.Y) > tol)
                        {
                            int beamDir = 2;
                            double[] values = new double[6];
                            values[0] = distributedLoad.MomentAtStart.Y;
                            values[1] = distributedLoad.MomentAtEnd.Y;
                            values[4] = distributedLoad.StartPosition / length;
                            values[5] = distributedLoad.EndPosition / length;
                            int localDistMomentCount = 0;
                            err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamDML, ref localDistMomentCount);
                            if (!St7ErrorCustom(err, "Couldn't get a number of principal distributed beam loads for a loadcase " + loadCaseId + " beam " + barId)) return false;
                            err = St7.St7SetBeamDistributedMomentPrincipal6ID(uID, barId, beamDir, loadCaseId, dlType, localDistMomentCount + 1, values);
                            if (!St7ErrorCustom(err, "Couldn't set a distributed beam moments for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        }                      
                        if (Math.Abs(distributedLoad.MomentAtStart.Z) > tol || Math.Abs(distributedLoad.MomentAtEnd.Z) > tol)
                        {
                            int beamDir = 3;
                            double[] values = new double[6];
                            values[0] = distributedLoad.MomentAtStart.Z;
                            values[1] = distributedLoad.MomentAtEnd.Z;
                            values[4] = distributedLoad.StartPosition / length;
                            values[5] = distributedLoad.EndPosition / length;
                            int localDistMomentCount = 0;
                            err = St7.St7GetEntityAttributeSequenceCount(uID, St7.tyBEAM, barId, St7.aoBeamDML, ref localDistMomentCount);
                            if (!St7ErrorCustom(err, "Couldn't get a number of principal distributed beam moments for a loadcase " + loadCaseId + " beam " + barId)) return false;
                            err = St7.St7SetBeamDistributedMomentPrincipal6ID(uID, barId, beamDir, loadCaseId, dlType, localDistMomentCount + 1, values);
                            if (!St7ErrorCustom(err, "Couldn't set a distributed beam moments for a loadcase " + loadCaseId + " beam " + barId)) return false;
                        }
                    }
                }
            }

            return true;
        }
        private bool CreateObject(BarUniformlyDistributedLoad uniDistributedLoad)
        {
            BarVaryingDistributedLoad vardistributedLoad = new BarVaryingDistributedLoad()
            {
                StartPosition = 0,
                EndPosition = 0,
                MomentAtStart = uniDistributedLoad.Moment,
                MomentAtEnd = uniDistributedLoad.Moment,
                ForceAtStart = uniDistributedLoad.Force,
                ForceAtEnd = uniDistributedLoad.Force,
                Loadcase = uniDistributedLoad.Loadcase,
                Projected = uniDistributedLoad.Projected,
                Axis = uniDistributedLoad.Axis,
                Objects = uniDistributedLoad.Objects
            };
            return CreateObject(vardistributedLoad);
        }       
        /***************************************************/
    }
}


