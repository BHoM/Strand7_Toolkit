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
using BH.oM.Structure.Elements;
using BH.oM.Structure.SectionProperties;
using BH.oM.Structure.Constraints;
using St7API;
using BH.oM.Geometry;
using BH.Engine.Geometry;
using static System.Math;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/
        private List<Bar> ReadBars(List<string> ids = null)
        {
            int err = 0;
            List<Bar> beams = new List<Bar>();
            Dictionary<int, ISectionProperty> allBeamProperties = ReadSectionProperties().ToDictionary(x => GetAdapterId<int>(x));
            Dictionary<int, Node> allNodes = ReadNodes().ToDictionary(x => GetAdapterId<int>(x));
            int beamCount = 0;
            err = St7.St7GetTotal(1, St7.tyBEAM, ref beamCount);
            if (!St7ErrorCustom(err, "Could not get total number of beams.")) return beams;
            for (int bm = 0; bm < beamCount; bm++)
            {
                // Getting nodes for a beam
                int beamId = bm + 1;
                int[] bmNodes = new int[St7.kMaxElementNode + 1];
                err = St7.St7GetElementConnection(1, St7.tyBEAM, beamId, bmNodes);
                if (!St7ErrorCustom(err, "Could not get nodes for a beam " + beamId.ToString())) continue;                       
                if (bmNodes[0] != 2)    // checking number of nodes bmNodes[0]   
                {
                    BH.Engine.Base.Compute.RecordError("Number of nodes doesn't equal 2 for beam N: " + beamId.ToString());
                    return beams;
                }
                Node nd1 = allNodes[bmNodes[1]];
                Node nd2 = allNodes[bmNodes[2]];

                // getting a property for a beam
                int beamPropNum = 0;
                err = St7.St7GetElementProperty(1, St7.ptBEAMPROP, beamId, ref beamPropNum);
                if (!St7ErrorCustom(err, "Could not get property for a beam " + beamId.ToString())) continue;
                ISectionProperty prop = allBeamProperties.ContainsKey(beamPropNum)? allBeamProperties[beamPropNum] : null;
                //// getting an orientation vector
                //double[] beamAxes = new double[9];
                //err = St7.St7GetBeamAxisSystem(1, beamId, St7.btTrue, beamAxes);
                //if (!St7ErrorCustom(err, "Could not get local axes for a beam " + beamId.ToString())) continue;
                //Vector i2 = BH.Engine.Geometry.Create.Vector(beamAxes[3], beamAxes[4], beamAxes[5]); // normal vector
                //Vector i3 = BH.Engine.Geometry.Create.Vector(beamAxes[6], beamAxes[7], beamAxes[8]); // vector along the beam
                //Vector reference = Vector.ZAxis;
                //if (Abs(1 - Query.DotProduct(i3, Vector.ZAxis)) < 0.001) reference = i3.CrossProduct(Vector.YAxis); // if beam is vertical use X or -X axis as reference
                //double orientationAngle = reference.Angle(i2, new Plane { Normal = i3 });
                double[] orientationAngle = new double[1];
                err = St7.St7GetBeamReferenceAngle1(1, beamId, orientationAngle);
                int[] restrTranslationStart = new int[3];
                int[] restrTranslationEnd = new int[3];
                int[] restrRotationStart = new int[3];
                int[] restrRotationEnd = new int[3];
                double[] stiffTranslationStart = new double[3];
                double[] stiffTranslationEnd = new double[3];
                double[] stiffRotationStart = new double[3];
                double[] stiffRotationEnd = new double[3];
                // getting beam releases
                err = St7.St7GetBeamTRelease3(1, beamId, 1, restrTranslationStart, stiffTranslationStart);
                if (err != St7.ERR7_NoError) restrTranslationStart = new int[] { 1, 1, 1 }; // fixed if not set               
                err = St7.St7GetBeamRRelease3(1, beamId, 1, restrRotationStart, stiffRotationStart);
                if (err != St7.ERR7_NoError) restrRotationStart = new int[] { 1, 1, 1 }; // fixed if not set             
                List<bool> beamStartRestraint = restrTranslationStart.Concat(restrRotationStart).Select(rst => rst == St7.brFixed).ToList();
                List<double> stiffnessValsStart = stiffTranslationStart.Concat(stiffRotationStart).ToList();
                err = St7.St7GetBeamTRelease3(1, beamId, 2, restrTranslationEnd, stiffTranslationEnd);
                if (err != St7.ERR7_NoError) restrTranslationEnd = new int[] { 1, 1, 1 }; // fixed if not set     
                err = St7.St7GetBeamRRelease3(1, beamId, 2, restrRotationEnd, stiffRotationEnd);
                if (err != St7.ERR7_NoError) restrRotationEnd = new int[] { 1, 1, 1 }; // fixed if not set                    
                List<bool> beamEndRestraint = restrTranslationEnd.Concat(restrRotationEnd).Select(rst => rst == St7.brFixed).ToList();
                List<double> stiffnessValsEnd = stiffTranslationEnd.Concat(stiffRotationEnd).ToList();
                Constraint6DOF startRelease = BH.Engine.Structure.Create.Constraint6DOF("", beamStartRestraint, stiffnessValsStart);
                Constraint6DOF endRelease = BH.Engine.Structure.Create.Constraint6DOF("", beamEndRestraint, stiffnessValsEnd);
                BarRelease barRelease = BH.Engine.Structure.Create.BarRelease(startRelease, endRelease);
                Bar bar = BH.Engine.Structure.Create.Bar(nd1, nd2, prop, orientationAngle[0] * System.Math.PI / 180, barRelease);
                SetAdapterId(bar, beamId);
                beams.Add(bar);
            }

            return beams;
        }

        /***************************************************/

    }
}

