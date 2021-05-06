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

using BH.oM.Geometry;
using BH.oM.Structure.Elements;
using St7API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.Strand7
{
    public static partial class Compute
    {
        public static GetMeshOut St7ReadMesh(bool clean = true, bool active = false)
        {
            if (!active) return null;
            int err = 0;
            // Just reading mesh without properties
            List<Point> points = new List<Point>();
            int pointCount = 0;
            double[] XYZ = new double[3];
            err = St7.St7GetTotal(1, St7.tyNODE, ref pointCount);
            if (!St7Error(err)) return null;
            for (int nn = 0; nn < pointCount; nn++)
            {
                int nodeId = nn + 1;               
                err = St7.St7GetNodeXYZ(1, nodeId, XYZ);
                points.Add(Geometry.Create.Point(XYZ[0], XYZ[1], XYZ[2]));
            }
            Dictionary<int, int> indicesUsed = new Dictionary<int, int>();      
            int numberPlateElements = 0;
            err = St7.St7GetTotal(1, St7.tyPLATE, ref numberPlateElements);
            if (!St7ErrorCustom(err, "Could not get total number of plate elements.")) return null;
            List<int> ids = new List<int>();
            if (ids == null || ids.Count == 0) ids = Enumerable.Range(1, numberPlateElements).ToList();
            Mesh mesh = new Mesh();

            int fcA = 0;
            int fcB = 0;
            int fcC = 0;
            int fcD = 0;
            foreach (int id in ids)
            {
                Face face = new Face();
                int[] plateConnection = new int[St7.kMaxElementNode + 1];
                err = St7.St7GetElementConnection(1, St7.tyPLATE, id, plateConnection);
                if (plateConnection[0] == 3 || plateConnection[0] == 6) // Plate elements Tri3 and Tri6. Firt index is a number of vertices      
                {
                    fcA = plateConnection[1] - 1;
                    fcB = plateConnection[2] - 1;
                    fcC = plateConnection[3] - 1;
                    face.A = clean ? AddItemToListAndReturnIndex(indicesUsed, fcA) : fcA;
                    face.B = clean ? AddItemToListAndReturnIndex(indicesUsed, fcB) : fcB;
                    face.C = clean ? AddItemToListAndReturnIndex(indicesUsed, fcC) : fcC;
                }
                else // All quad elements
                {
                    fcA = plateConnection[1] - 1;
                    fcB = plateConnection[2] - 1;
                    fcC = plateConnection[3] - 1;
                    fcD = plateConnection[4] - 1;
                    face.A = clean ? AddItemToListAndReturnIndex(indicesUsed, fcA) : fcA;
                    face.B = clean ? AddItemToListAndReturnIndex(indicesUsed, fcB) : fcB;
                    face.C = clean ? AddItemToListAndReturnIndex(indicesUsed, fcC) : fcC;
                    face.D = clean ? AddItemToListAndReturnIndex(indicesUsed, fcD) : fcD;
                }
                mesh.Faces.Add(face);
            }
            // creating a list of used Vertices
            if (clean)
            {
                mesh.Vertices = indicesUsed.Select(x => points[x.Key]).ToList();
                return new GetMeshOut(true, mesh, indicesUsed.Select(x => x.Key).ToList());
            }
            mesh.Vertices = points;
            return new GetMeshOut(true, mesh, Enumerable.Range(0, pointCount).ToList());
        }

        private static int AddItemToListAndReturnIndex(Dictionary<int, int> oldIds, int vertexId)
        {
            // !!!! mutating the passed collection !!!!
            if (oldIds.TryGetValue(vertexId, out int index)) return index;
            int count = oldIds.Count;
            oldIds.Add(vertexId, count);
            return count;
        }

        public class GetMeshOut
        {
            public bool Success { get; set; }
            public Mesh Mesh { get; set; }
            public List<int> NodeIdsUsed { get; set; }
            public GetMeshOut(bool success, Mesh mesh, List<int> nodeIdsUsed)
            {
                Success = success;
                Mesh = mesh;
                NodeIdsUsed = nodeIdsUsed;
            }
        }
    }
}
