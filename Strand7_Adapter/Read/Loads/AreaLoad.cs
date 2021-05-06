/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2021, the respective contributors. All rights reserved.
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
using BH.Engine.Geometry;
using BH.Engine.Structure;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        private List<ILoad> ReadAreaLoad(List<Loadcase> loadcases)
        {
            int uID = 1;
            int err = 0;
            List<ILoad> bhLoads = new List<ILoad>();
            List<Panel> bhPanels = ReadPanel();
            Vector localPressure = new Vector();
            Vector globalPressure = new Vector();
            foreach (Loadcase ldcs in loadcases)
            {
                int ldcsId = GetAdapterId<int>(ldcs);
                foreach (Panel panel in bhPanels)
                {
                    BHoMGroup<IAreaElement> panelObjects = new BHoMGroup<IAreaElement>() { Elements = { panel } };
                    int panelId = GetAdapterId<int>(panel);

                    // local pressures
                    double[] normalPressures = new double[2];
                    err = St7.St7GetPlateNormalPressure2(uID, panelId, ldcsId, normalPressures);
                    double[] shearPressures = new double[2];
                    err = St7.St7GetPlateShear2(uID, panelId, ldcsId, shearPressures);
                    localPressure = Vector.ZAxis * (normalPressures[0] - normalPressures[1]) + Vector.XAxis * shearPressures[0] + Vector.YAxis * shearPressures[1];
                    if (localPressure.Length() > 0)
                        bhLoads.Add(new AreaUniformlyDistributedLoad() { Loadcase = ldcs, Pressure = localPressure, Objects = panelObjects, Axis = LoadAxis.Local, Projected = false });

                    // global pressures
                    double[] globalPressuresZplus = new double[3];
                    double[] globalPressuresZminus = new double[3];
                    int projectionFlag = 0;
                    err = St7.St7GetPlateGlobalPressure3S(uID, panelId, St7.psPlateZPlus, ldcsId, ref projectionFlag, globalPressuresZplus);
                    err = St7.St7GetPlateGlobalPressure3S(uID, panelId, St7.psPlateZMinus, ldcsId, ref projectionFlag, globalPressuresZminus);
                    globalPressure = BH.Engine.Geometry.Create.Vector(globalPressuresZplus[0] + globalPressuresZminus[0], globalPressuresZplus[1] + globalPressuresZminus[1], globalPressuresZplus[2] + globalPressuresZminus[2]);
                    bool projected = projectionFlag != St7.ppNone;
                    if (globalPressure.Length() > 0)
                        bhLoads.Add(new AreaUniformlyDistributedLoad() { Loadcase = ldcs, Pressure = globalPressure, Objects = panelObjects, Axis = LoadAxis.Global, Projected = projected });
                }
            }
            return bhLoads;
        }

    }
}
