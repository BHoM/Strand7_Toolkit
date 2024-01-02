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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Adapter;
using BH.Engine.Strand7;
using BH.oM.Base;
using St7API;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter : BHoMAdapter
    {
        public string AdapterIdName { get; set; }
        public double Tolerance { get; set; }
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        //Add any applicable constructors here, such as linking to a specific file or anything else as well as linking to that file through the (if existing) com link via the API
        public Strand7Adapter(bool initialise = false, double tolerance = 0.1)
        {
            if (initialise)
            {
                int err = St7.St7Init();
                if (St7Error(err))
                {
                    Tolerance = tolerance;
                    AdapterIdFragmentType = typeof(Strand7Id);
                    SetupDependencies();
                    SetupComparers();                
                    AdapterIdName = BH.Engine.Strand7.Convert.AdapterId;   //Sets` the "AdapterId" to "SoftwareName_id". Generally stored as a constant string in the convert class in the 
                }
            }
        }

        [Description("Fragment storing identifier information of the object in Strand7.")]
        public class Strand7Id : IAdapterId
        {
            [Description("The identifier of the object in Strand7. It will always be an integer.")]
            public object Id { get; set; }
        }


    }
}


