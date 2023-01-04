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
using BH.oM.Geometry;
using BH.oM.Structure.SurfaceProperties;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        //The List<string> in the methods below can be changed to a list of any type of identification more suitable for the toolkit
        //If no ids are provided, the convention is to return all elements of the type

        private List<Panel> ReadPanel(List<int> ids = null)
        {
            // Just reading mesh without properties. Use all nodes.
            int uID = 1;        
            int err = 0;
            int numberPlateElements = 0;
            err = St7.St7GetTotal(uID, St7.tyPLATE, ref numberPlateElements);
            if (!St7ErrorCustom(err, "Could not get total number of plate elements.")) return null;
            List<Node> nodes = ReadNodes();
            List<ISurfaceProperty> plateProps = ReadSurfaceProperty();
            if (ids == null || ids.Count == 0) ids = Enumerable.Range(1, numberPlateElements).ToList();
            List<Panel> panels = new List<Panel>();
            Dictionary<int, int> platePropsNumbers = new Dictionary<int, int>();
            for (int i = 0; i < plateProps.Count; i++)
            {
                platePropsNumbers.Add(GetAdapterId<int>(plateProps[i]), i);         
            }  
            foreach (int id in ids)
            {
                int platePropNum = 0;
                err = St7.St7GetElementProperty(uID, St7.ptPLATEPROP, id, ref platePropNum);
                int propIndex = platePropsNumbers[platePropNum];
                Panel panel = new Panel();
                SetAdapterId(panel, id);               
                panel.Property = plateProps[propIndex];
                //panel.Name = plateProps[propIndex].Name;
                int[] plateConnection = new int[St7.kMaxElementNode + 1];
                err = St7.St7GetElementConnection(uID, St7.tyPLATE, id, plateConnection);
                if (!St7ErrorCustom(err, "Could not get plate nodes.")) return null;
                if (plateConnection[0] == 3 || plateConnection[0] == 6) // Plate elements Tri3 and Tri6. Firt index is a number of vertices      
                {
                    Point pt1 = nodes[plateConnection[1] - 1].Position;
                    Point pt2 = nodes[plateConnection[2] - 1].Position;
                    Point pt3 = nodes[plateConnection[3] - 1].Position;
                    Line ln1 = BH.Engine.Geometry.Create.Line(pt1, pt2);
                    Line ln2 = BH.Engine.Geometry.Create.Line(pt2, pt3);
                    Line ln3 = BH.Engine.Geometry.Create.Line(pt3, pt1);
                    Edge edg1 = BH.Engine.Structure.Create.Edge(ln1, null, "");
                    Edge edg2 = BH.Engine.Structure.Create.Edge(ln2, null, "");
                    Edge edg3 = BH.Engine.Structure.Create.Edge(ln3, null, "");
                    SetAdapterId(edg1, plateConnection[1] - 1);
                    SetAdapterId(edg2, plateConnection[2] - 1);
                    SetAdapterId(edg3, plateConnection[3] - 1);        
                    panel.ExternalEdges.Add(edg1);
                    panel.ExternalEdges.Add(edg2);
                    panel.ExternalEdges.Add(edg3);                   
                }
                else // All quad elements
                {
                    Point pt1 = nodes[plateConnection[1] - 1].Position;
                    Point pt2 = nodes[plateConnection[2] - 1].Position;
                    Point pt3 = nodes[plateConnection[3] - 1].Position;
                    Point pt4 = nodes[plateConnection[4] - 1].Position;
                    Line ln1 = BH.Engine.Geometry.Create.Line(pt1, pt2);
                    Line ln2 = BH.Engine.Geometry.Create.Line(pt2, pt3);
                    Line ln3 = BH.Engine.Geometry.Create.Line(pt3, pt4);
                    Line ln4 = BH.Engine.Geometry.Create.Line(pt4, pt1);
                    Edge edg1 = BH.Engine.Structure.Create.Edge(ln1, null, "");
                    Edge edg2 = BH.Engine.Structure.Create.Edge(ln2, null, "");
                    Edge edg3 = BH.Engine.Structure.Create.Edge(ln3, null, "");
                    Edge edg4 = BH.Engine.Structure.Create.Edge(ln4, null, "");
                    SetAdapterId(edg1, plateConnection[1] - 1);
                    SetAdapterId(edg2, plateConnection[2] - 1);
                    SetAdapterId(edg3, plateConnection[3] - 1);
                    SetAdapterId(edg4, plateConnection[4] - 1);                  
                    panel.ExternalEdges.Add(edg1);
                    panel.ExternalEdges.Add(edg2);
                    panel.ExternalEdges.Add(edg3);
                    panel.ExternalEdges.Add(edg4);
                }
                panels.Add(panel);
            }         
            return panels;
        }
    /***************************************************/

}
}

