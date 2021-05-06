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

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {             
        private List<ILoad> ReadPointLoad(List<Loadcase> loadcases)
        {
            int err = 0;
            List<ILoad> bhLoads = new List<ILoad>();
            List<Node> allNodes = ReadNodes();
            foreach (Loadcase ldcs in loadcases)
            {
                foreach (Node node in allNodes)
                {
                    int nodeId = GetAdapterId<int>(node);
                    double[] forces = new double[3];
                    err = St7.St7GetNodeForce3(1, nodeId, GetAdapterId<int>(ldcs), forces);
                    double[] moments = new double[3];
                    err = St7.St7GetNodeMoment3(1, nodeId, GetAdapterId<int>(ldcs), moments);
                    if (!IsZeroSqLength(forces) || !IsZeroSqLength(moments))
                    {
                        PointLoad bhLoad = new PointLoad()
                        {
                            Force = new Vector() { X = forces[0], Y = forces[1], Z = forces[2] },
                            Moment = new Vector() { X = moments[0], Y = moments[1], Z = moments[2] },
                            Loadcase = ldcs,
                            Objects = new BHoMGroup<Node>() { Elements = { node } }
                        };
                        bhLoads.Add(bhLoad);
                    }
                }
            }
            return bhLoads;
        }      
      
    }
}
