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
using BH.oM.Structure.Elements;
using BH.oM.Structure.Constraints;
using St7API;
using BH.oM.Structure.Loads;
using BH.oM.Geometry;
using BH.oM.Geometry.CoordinateSystem;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {       
        private List<ILoad> ReadBarDistributedLoad(List<Loadcase> loadcases)
        {
            int err = 0;
            Dictionary<int, Loadcase> lcDict = loadcases.ToDictionary(x => GetAdapterId<int>(x));
            List<ILoad> bhLoads = new List<ILoad>();
            List<Bar> allBars = ReadBars();

            foreach (Bar bar in allBars)
            {
                double length = BH.Engine.Geometry.Query.Length(BH.Engine.Structure.Query.Centreline(bar));
                int barId = GetAdapterId<int>(bar);

                // global Distributed Forces
                int globalDistForceCount = 0;
                err = St7.St7GetEntityAttributeSequenceCount(1, St7.tyBEAM, barId, St7.aoBeamDLG, ref globalDistForceCount);
                if (globalDistForceCount > 0)
                {
                    // getting load IDs and direction
                    int[] sequenceNumbers = new int[globalDistForceCount * 4];
                    err = St7.St7GetEntityAttributeSequence(1, St7.tyBEAM, barId, St7.aoBeamDLG, globalDistForceCount, sequenceNumbers);
                    for (int i = 0; i < globalDistForceCount; i++)
                    {
                        int loadCaseNum = sequenceNumbers[4 * i + St7.ipAttrCase];
                        int loadDir = sequenceNumbers[4 * i + St7.ipAttrAxis];
                        int loadID = sequenceNumbers[4 * i + St7.ipAttrID];
                        double loadX = loadDir == 1 ? 1 : 0;
                        double loadY = loadDir == 2 ? 1 : 0;
                        double loadZ = loadDir == 3 ? 1 : 0;
                        int projected = 0;
                        int distributionType = 0;
                        double[] forcesG = new double[6];
                        err = St7.St7GetBeamDistributedForceGlobal6ID(1, barId, loadDir, loadCaseNum, loadID, ref projected, ref distributionType, forcesG);  
                        // adding load case, object information to loads
                        bhLoads.AddRange(DistributedBarLoadsFromSt7(loadX, loadY, loadZ, distributionType, length, forcesG, new double[6], lcDict[loadCaseNum], bar, projected == St7.bpProjected, LoadAxis.Global)); 
                    }
                }
                // principal Distributed Forces
                int principalDistForceCount = 0;
                err = St7.St7GetEntityAttributeSequenceCount(1, St7.tyBEAM, barId, St7.aoBeamDLL, ref principalDistForceCount);
                if (principalDistForceCount > 0)
                {
                    // getting load IDs and direction
                    int[] sequenceNumbers = new int[principalDistForceCount * 4];
                    err = St7.St7GetEntityAttributeSequence(1, St7.tyBEAM, barId, St7.aoBeamDLL, principalDistForceCount, sequenceNumbers);
                    for (int i = 0; i < principalDistForceCount; i++)
                    {
                        int loadCaseNum = sequenceNumbers[4 * i + St7.ipAttrCase];
                        int loadDir = sequenceNumbers[4 * i + St7.ipAttrAxis];
                        int loadID = sequenceNumbers[4 * i + St7.ipAttrID];
                        double loadX = loadDir == 1 ? 1 : 0;
                        double loadY = loadDir == 2 ? 1 : 0;
                        double loadZ = loadDir == 3 ? 1 : 0;
                        int distributionType = 0;
                        double[] forcesP = new double[6];
                        err = St7.St7GetBeamDistributedForcePrincipal6ID(1, barId, loadDir, loadCaseNum, loadID, ref distributionType, forcesP);
                        bhLoads.AddRange(DistributedBarLoadsFromSt7(loadX, loadY, loadZ, distributionType, length, forcesP, new double[6], lcDict[loadCaseNum], bar, false, LoadAxis.Local));
                    }
                }
                // principal Distributed Moments
                int principalDistMomentCount = 0;
                err = St7.St7GetEntityAttributeSequenceCount(1, St7.tyBEAM, barId, St7.aoBeamDML, ref principalDistMomentCount);
                if (principalDistMomentCount > 0)
                {
                    // getting load IDs and direction
                    int[] sequenceNumbers = new int[principalDistMomentCount * 4];
                    err = St7.St7GetEntityAttributeSequence(1, St7.tyBEAM, barId, St7.aoBeamDML, principalDistMomentCount, sequenceNumbers);
                    for (int i = 0; i < principalDistMomentCount; i++)
                    {
                        int loadCaseNum = sequenceNumbers[4 * i + St7.ipAttrCase];
                        int loadDir = sequenceNumbers[4 * i + St7.ipAttrAxis];
                        int loadID = sequenceNumbers[4 * i + St7.ipAttrID];
                        double loadX = loadDir == 1 ? 1 : 0;
                        double loadY = loadDir == 2 ? 1 : 0;
                        double loadZ = loadDir == 3 ? 1 : 0;
                        int distributionType = 0;
                        double[] momentsP = new double[6];
                        err = St7.St7GetBeamDistributedMomentPrincipal6ID(1, barId, loadDir, loadCaseNum, loadID, ref distributionType, momentsP);
                        bhLoads.AddRange(DistributedBarLoadsFromSt7(loadX, loadY, loadZ, distributionType, length, new double[6], momentsP, lcDict[loadCaseNum], bar, false, LoadAxis.Local));
                    }
                }
            }
            return bhLoads;
        }
              
        private static List<ILoad> DistributedBarLoadsFromSt7(double loadX, double loadY, double loadZ, int distributionType, double barLength, double[] forces, double[] moments, Loadcase ldcase, Bar bar, bool projected, LoadAxis loadAxis)
        {
            List<ILoad> bhLoads = new List<ILoad>();
            double a;
            double b;
            if (IsZeroSqLength(forces))
            {
                a = moments[4];
                b = moments[5];
            }
            else
            {
                a = forces[4];
                b = forces[5];
            }
            ILoad bhLoad;
            ILoad bhLoad2;
            ILoad bhLoad3;
            switch (distributionType)
            {
                case St7.dlConstant:
                    bhLoad = new BarUniformlyDistributedLoad()
                    {                     
                        Moment = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],                     
                        Force = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],                       
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad);
                    break;
                case St7.dlLinear:
                    if (moments[0] == moments[1] && forces[0] == forces[1] && a == 0 && b == 0)
                    {
                        bhLoad = new BarUniformlyDistributedLoad()
                        {
                            Moment = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],
                            Force = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],
                            Loadcase = ldcase,
                            Projected = projected,
                            Axis = loadAxis,
                            Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                        };
                    }
                    else
                    {
                        bhLoad = new BarVaryingDistributedLoad()
                        {
                            StartPosition = barLength * a,
                            EndPosition = barLength * b,
                            MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],
                            MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[1],
                            ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],
                            ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[1],
                            Loadcase = ldcase,
                            Projected = projected,
                            Axis = loadAxis,
                            Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                        };
                    }
                    bhLoads.Add(bhLoad);
                    break;
                case St7.dlTriangular:
                    bhLoad = new BarVaryingDistributedLoad()
                    {
                        StartPosition = 0,
                        EndPosition = barLength * (1 - a),
                        MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[2],
                        MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],
                        ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[2],
                        ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad);
                    bhLoad2 = new BarVaryingDistributedLoad()
                    {
                        StartPosition = barLength * a,
                        EndPosition = 0,
                        MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],
                        MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[3],
                        ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],
                        ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[3],
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad2);
                    break;
                case St7.dlThreePoint0:
                    bhLoad = new BarVaryingDistributedLoad()
                    {
                        StartPosition = 0,
                        EndPosition = barLength * (1 - a),
                        MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[2],
                        MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],
                        ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[2],
                        ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad);
                    bhLoad2 = new BarVaryingDistributedLoad()
                    {
                        StartPosition = barLength * a,
                        EndPosition = barLength * b,
                        MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],
                        MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[1],
                        ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],
                        ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[1],
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad2);
                    break;
                case St7.dlThreePoint1:
                    bhLoad = new BarVaryingDistributedLoad()
                    {
                        StartPosition = barLength * a,
                        EndPosition = barLength * b,
                        MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],
                        MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[1],
                        ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],
                        ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[1],
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad);
                    bhLoad2 = new BarVaryingDistributedLoad()
                    {
                        StartPosition = barLength * (1 - b),
                        EndPosition = 0,
                        MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[1],
                        MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[3],
                        ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[1],
                        ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[3],
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad2);
                    break;
                case St7.dlTrapezoidal:
                    bhLoad = new BarVaryingDistributedLoad()
                    {
                        StartPosition = 0,
                        EndPosition = barLength * (1 - a),
                        MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[2],
                        MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],
                        ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[2],
                        ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad);
                    bhLoad2 = new BarVaryingDistributedLoad()
                    {
                        StartPosition = barLength * a,
                        EndPosition = barLength * b,
                        MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[0],
                        MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[1],
                        ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[0],
                        ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[1],
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad2);
                    bhLoad3 = new BarVaryingDistributedLoad()
                    {
                        StartPosition = barLength * (1 - b),
                        EndPosition = 0,
                        MomentAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[1],
                        MomentAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * moments[3],
                        ForceAtStart = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[1],
                        ForceAtEnd = BH.Engine.Geometry.Create.Vector(loadX, loadY, loadZ) * forces[3],
                        Loadcase = ldcase,
                        Projected = projected,
                        Axis = loadAxis,
                        Objects = new BHoMGroup<Bar>() { Elements = { bar } }
                    };
                    bhLoads.Add(bhLoad3);
                    break;
            }
            return bhLoads;
        }
    }
}

