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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Base;
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.MaterialFragments;
using BH.oM.Structure.Loads;
using BH.oM.Structure.Results;
using BH.oM.Geometry;
using BH.oM.Structure.SurfaceProperties;
using BH.oM.Adapter;
using BH.oM.Adapter.Strand7;
using BH.oM.Analytical.Results;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {
        /***************************************************/
        /**** Adapter overload method                   ****/
        /***************************************************/

        // This method gets called when appropriate by the Pull method contained in the base Adapter class.
        // It gets called once per each Type.
        protected override IEnumerable<IBHoMObject> IRead(Type type, IList ids, ActionConfig actionConfig = null)
        {
            //Main dispatcher method.
            //Choose what to pull out depending on the type.
            if (type == typeof(Node))
                return ReadNodes(ids as dynamic);
            else if (type == typeof(Bar))
                return ReadBars(ids as dynamic);
            else if (type == typeof(ISectionProperty) || type.GetInterfaces().Contains(typeof(ISectionProperty)))
                return ReadSectionProperties(ids as dynamic);
            else if (type == typeof(ISurfaceProperty))
                return ReadSurfaceProperty(ids as dynamic);
            else if (type == typeof(IMaterialFragment))
                return ReadMaterials(ids as dynamic);
            else if (type == typeof(Loadcase))
                return ReadLoadcase(ids as dynamic);
            else if (type == typeof(LoadCombination))
                return ReadLoadCombination(ids as dynamic);
            else if (type == typeof(ILoad) || type.GetInterfaces().Contains(typeof(ILoad)))
                return ReadLoad(type, ids as dynamic);
            else if (type == typeof(FEMesh))
                return ReadMesh(ids as dynamic);
            else if (type == typeof(Mesh))
                return ReadMesh(ids as dynamic);
            else if (type == typeof(Panel))
                return ReadPanel(ids as dynamic);
            else if (type == typeof(St7Group<BHoMObject>))
                return ReadGroups(ids as dynamic);
            else if (type == typeof(St7Stage))
                return new List<St7Stage>();
            else if (type == typeof(St7StagedAnalysisParams))
                return new List<St7StagedAnalysisParams>();

            return new List<IBHoMObject>();
        }       
        /***************************************************/

    }
}


