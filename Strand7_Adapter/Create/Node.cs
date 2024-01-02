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
using St7API;

namespace BH.Adapter.Strand7
{
    public partial class Strand7Adapter
    {

        /***************************************************/
        /**** Private methods                           ****/
        /***************************************************/

        private bool CreateObject(Node bhnode)
        {
            double[] XYZ = new double[3];

            // Geometry
            int uID = 1;
            int err = 0;
            int nodeId = GetAdapterId<int>(bhnode);
            XYZ[0] = bhnode.Position.X;
            XYZ[1] = bhnode.Position.Y;
            XYZ[2] = bhnode.Position.Z;
            err = St7.St7SetNodeXYZ(1, nodeId, XYZ);
            if (!St7Error(err)) return false;         

            oM.Geometry.Vector xVector = bhnode.Orientation.X;
            oM.Geometry.Vector yVector = bhnode.Orientation.Y;
            double[] UCSDoubles = new double[] { 0, 0, 0, xVector.X, xVector.Y, xVector.Z, yVector.X, yVector.Y, yVector.Z };
            int UCSType = St7.csCartesian;


            int num_UCS = 0;
            int UCSid = 0;
            err = St7.St7GetNumUCS(uID, ref num_UCS);
            if (!St7Error(err)) return false;

            bool ucsExists = false;
            for (int i = 1; i <= num_UCS; i++)
            {
                double[] UCSDoubles_current = new double[9];
                int current_id = 0;
                err = St7.St7GetUCSID(uID, i, ref current_id);
                err = St7.St7GetUCS(uID, current_id, ref UCSType, UCSDoubles_current);
            
                if (UCSDoubles_current.SequenceEqual(UCSDoubles))
                {
                    UCSid = i;
                    ucsExists = true;
                    break;
                }
            }
            if (!ucsExists)
            {
                UCSid = num_UCS + 1;
                err = St7.St7SetUCS(uID, UCSid, UCSType, UCSDoubles);
                err = St7.St7SetUCSName(uID, UCSid, bhnode.Name);
            }


            // Restraints
            if (bhnode.Support == null) return true;
            SetAdapterId(bhnode.Support,UCSid);
            int freedomCase = 1;
            object freedomCaseObj;
            if (bhnode.CustomData.TryGetValue("Freedom", out freedomCaseObj))
            {
                freedomCase = (int)freedomCaseObj;
                while (St7.St7SetFreedomCaseType(uID, freedomCase, St7.fcNormalFreedom) != St7.ERR7_NoError) // there is no such freedom case, creating new
                {
                    err = St7.St7NewFreedomCase(uID, "fc " + freedomCase.ToString());
                    if (!St7Error(err)) return false;
                }
            }
            int[] restraints = new int[6];
            restraints[0] = (bhnode.Support.TranslationX == oM.Structure.Constraints.DOFType.Fixed) ? St7.btTrue : St7.btFalse;
            restraints[1] = (bhnode.Support.TranslationY == oM.Structure.Constraints.DOFType.Fixed) ? St7.btTrue : St7.btFalse;
            restraints[2] = (bhnode.Support.TranslationZ == oM.Structure.Constraints.DOFType.Fixed) ? St7.btTrue : St7.btFalse;
            restraints[3] = (bhnode.Support.RotationX == oM.Structure.Constraints.DOFType.Fixed) ? St7.btTrue : St7.btFalse;
            restraints[4] = (bhnode.Support.RotationY == oM.Structure.Constraints.DOFType.Fixed) ? St7.btTrue : St7.btFalse;
            restraints[5] = (bhnode.Support.RotationZ == oM.Structure.Constraints.DOFType.Fixed) ? St7.btTrue : St7.btFalse;
            double[] enforcedDispls = Enumerable.Repeat(0.0, 6).ToArray();
            err = St7.St7SetNodeRestraint6(uID, nodeId, freedomCase, UCSid, restraints, enforcedDispls);
            if (!St7Error(err)) return false;

            // Stiffness Translational
            double[] translationalStiffness = new double[3];
            translationalStiffness[0] = bhnode.Support.TranslationalStiffnessX;
            translationalStiffness[1] = bhnode.Support.TranslationalStiffnessY;
            translationalStiffness[2] = bhnode.Support.TranslationalStiffnessZ;
            err = St7.St7SetNodeKTranslation3F(uID, nodeId, freedomCase, UCSid, translationalStiffness);
            if (!St7Error(err)) return false;

            // Stiffness Rotational
            double[] rotationalStiffness = new double[3];
            rotationalStiffness[0] = bhnode.Support.RotationalStiffnessX;
            rotationalStiffness[1] = bhnode.Support.RotationalStiffnessY;
            rotationalStiffness[2] = bhnode.Support.RotationalStiffnessZ;
            err = St7.St7SetNodeKRotation3F(uID, nodeId, freedomCase, UCSid, rotationalStiffness);
            if (!St7Error(err)) return false;
            return true;
        }

        /***************************************************/
    }
}


