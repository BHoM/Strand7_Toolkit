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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Adapter.Strand7;
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

        private bool CreateObject(BarPreLoad barPointLoad)
        {
            int err = 0;
            int uID = 1;
            int loadCaseId = GetAdapterId<int>(barPointLoad.Loadcase);

            // *************************** GLOBAL ***************************

            foreach (Bar bar in barPointLoad.Objects.Elements)
            {
                int barId = GetAdapterId<int>(bar);

                err = St7.St7SetBeamPreLoad1(uID, barId, loadCaseId, (int)barPointLoad.PreloadType, new double[] { barPointLoad.Prestress });
                if (!St7ErrorCustom(err, "Couldn't set global beam preload for a loadcase " + loadCaseId + " beam " + barId)) return false;
            }

            return true;
        }

        /***************************************************/
    }
}
