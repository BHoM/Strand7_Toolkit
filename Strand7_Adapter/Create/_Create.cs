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
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Loads;
using BH.oM.Adapter;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        // This method gets called when appropriate by the methods contained in the base Adapter class (Push, Update).
        // It gets called once per each Type <T>.
        protected override bool ICreate<T>(IEnumerable<T> objects, ActionConfig actionConfig = null)
        {
            bool success = true;

            if (typeof(BH.oM.Base.IBHoMObject).IsAssignableFrom(typeof(T)))
            {
                success = CreateCollection(objects);
            }
            else
            {
                success = false;
            }
            return success;

        }
        private bool CreateCollection<T>(IEnumerable<T> objects) where T : BH.oM.Base.IObject
        {
            bool success = true;         
            if (typeof(T) == typeof(BH.oM.Base.BHoMGroup<Node>))
            {
                foreach (T obj in objects)
                {
                    List<Node> nodes = (obj as BH.oM.Base.BHoMGroup<Node>).Elements;
                    this.FullCRUD(nodes, PushType.FullPush);
                }
            }
            else if (typeof(T) == typeof(BH.oM.Base.BHoMGroup<Bar>))
            {
                foreach (T obj in objects)
                {
                    List<Bar> bars = (obj as BH.oM.Base.BHoMGroup<Bar>).Elements;
                    this.FullCRUD(bars, PushType.FullPush);
                }
            }
            else if (typeof(T) == typeof(List<Tuple<double, ICase>>))
            {
                foreach (T obj in objects)
                {
                    List<Loadcase> loadcases = (obj as List<Tuple<double, ICase>>).Select(x => x.Item2).Cast<Loadcase>().ToList();
                    this.FullCRUD(loadcases, PushType.FullPush);
                }
            }      
            else
            {
                foreach (T obj in objects)
                {
                    success &= CreateObject(obj as dynamic);
                }
            }

            return success;
        }

        /***************************************************/
    }
}


