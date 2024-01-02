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

using BH.oM.Geometry;
using BH.oM.Structure.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Engine.Strand7.Query
{

    public static partial class Query
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static Mesh MeshFromFEMesh(this FEMesh feMesh, bool clean)
        {           
            Dictionary<int, int> indicesUsed = new Dictionary<int, int>();
            Mesh mesh = new Mesh();

            int fcA = 0;
            int fcB = 0;
            int fcC = 0;
            int fcD = 0;
            foreach (var feFace in feMesh.Faces)
            {
                Face face = new Face();
                if (feFace.NodeListIndices.Count == 3) // Plate elements Tri3 and Tri6. Firt index is a number of vertices      
                {
                    fcA = feFace.NodeListIndices[0];
                    fcB = feFace.NodeListIndices[1];
                    fcC = feFace.NodeListIndices[2];
                    face.A = clean ? AddItemToListAndReturnIndex(indicesUsed, fcA) : fcA;
                    face.B = clean ? AddItemToListAndReturnIndex(indicesUsed, fcB) : fcB;
                    face.C = clean ? AddItemToListAndReturnIndex(indicesUsed, fcC) : fcC;
                }
                else // All quad elements
                {
                    fcA = feFace.NodeListIndices[0];
                    fcB = feFace.NodeListIndices[1];
                    fcC = feFace.NodeListIndices[2];
                    fcD = feFace.NodeListIndices[3];
                    face.A = clean ? AddItemToListAndReturnIndex(indicesUsed, fcA) : fcA;
                    face.B = clean ? AddItemToListAndReturnIndex(indicesUsed, fcB) : fcB;
                    face.C = clean ? AddItemToListAndReturnIndex(indicesUsed, fcC) : fcC;
                    face.D = clean ? AddItemToListAndReturnIndex(indicesUsed, fcD) : fcD;
                }
                mesh.Faces.Add(face);
            }
            // creating a list of used Vertices
            if (clean) mesh.Vertices = indicesUsed.Select(x => feMesh.Nodes[x.Key].Position).ToList();
            else mesh.Vertices = feMesh.Nodes.Select(nd => nd.Position).ToList();
            return mesh;
        }
        public static int AddItemToListAndReturnIndex(Dictionary<int, int> oldIds, int vertexId)
        {
            // !!!! mutating the passed collection !!!!
            if (oldIds.TryGetValue(vertexId, out int index)) return index;
            int count = oldIds.Count;
            oldIds.Add(vertexId, count);
            return count;
        }
        /***************************************************/
    }
}


