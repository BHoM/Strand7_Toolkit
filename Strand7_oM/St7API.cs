using System;
using System.Runtime.InteropServices;
using System.Text;

namespace St7API
{
    public static class St7
    {

        public const int lmMessageBox = 0;
        public const int lmWaitRetry = 1;
        public const int lmAbort = 2;
        public const int kMaxStrLen = 255;

        // Array Limits
        public const int kMaxEntityTotals = 4;
        public const int kMaxElementNode = 20;
        public const int kMaxEntity = 10;
        public const int kMaxBeamResult = 4096;
        public const int kNumBeamSectionData = 20;
        public const int kNumMaterialData = 4;
        public const int kMaxAttributeDoubles = 12;
        public const int kMaxAttributeLogicals = 6;
        public const int kMaxAttributeLongint = 6;
        public const int kLastUnit = 6;
        public const int kMaxBGLDimensions = 16;

        // Selection States
        public const int ssSelected = 1;
        public const int ssUnselected = 2;

        // Unit Positions
        public const int ipLENGTHU = 0;
        public const int ipFORCEU = 1;
        public const int ipSTRESSU = 2;
        public const int ipMASSU = 3;
        public const int ipTEMPERU = 4;
        public const int ipENERGYU = 5;

        // Unit Types - LENGTH
        public const int luMETRE = 0;
        public const int luCENTIMETRE = 1;
        public const int luMILLIMETRE = 2;
        public const int luFOOT = 3;
        public const int luINCH = 4;

        // Unit Types - FORCE
        public const int fuNEWTON = 0;
        public const int fuKILONEWTON = 1;
        public const int fuMEGANEWTON = 2;
        public const int fuKILOFORCE = 3;
        public const int fuPOUNDFORCE = 4;
        public const int fuTONNEFORCE = 5;
        public const int fuKIPFORCE = 6;

        // Unit Types - STRESS
        public const int suPASCAL = 0;
        public const int suKILOPASCAL = 1;
        public const int suMEGAPASCAL = 2;
        public const int suKSCm = 3;
        public const int suPSI = 4;
        public const int suKSI = 5;
        public const int suPSF = 6;

        // Unit Types - MASS
        public const int muKILOGRAM = 0;
        public const int muTONNE = 1;
        public const int muGRAM = 2;
        public const int muPOUND = 3;
        public const int muSLUG = 4;

        // Unit Types - TEMPERATURE
        public const int tuCELSIUS = 0;
        public const int tuFAHRENHEIT = 1;
        public const int tuKELVIN = 2;
        public const int tuRANKINE = 3;

        // Unit Types - ENERGY
        public const int euJOULE = 0;
        public const int euBTU = 1;
        public const int euFTLBF = 2;
        public const int euCALORIE = 3;
        public const int euKILOJOULE = 4;

        // Unit Types - TIME
        public const int tuMilliSec = 0;
        public const int tuSec = 1;
        public const int tuMin = 2;
        public const int tuHour = 3;
        public const int tuDay = 4;

        // Entity Types
        public const int tyNODE = 0;
        public const int tyBEAM = 1;
        public const int tyPLATE = 2;
        public const int tyBRICK = 3;
        public const int tyLINK = 4;
        public const int tyVERTEX = 5;
        public const int tyGEOMETRYEDGE = 6;
        public const int tyGEOMETRYFACE = 7;
        public const int tyLOADPATH = 8;
        public const int tyGEOMETRYCOEDGE = 9;
        public const int tyGEOMETRYLOOP = 10;

        // Link Types
        public const int ltMasterSlaveLink = 1;
        public const int ltSectorSymmetryLink = 2;
        public const int ltCouplingLink = 3;
        public const int ltPinnedLink = 4;
        public const int ltRigidLink = 5;
        public const int ltShrinkLink = 6;
        public const int ltTwoPointLink = 7;
        public const int ltAttachmentLink = 8;
        public const int ltInterpolatedMultiPointLink = 9;
        public const int ltReactionMultiPointLink = 10;
        public const int ltRigidMultiPointLink = 11;
        public const int ltPinnedMultiPointLink = 12;
        public const int ltMasterSlaveMultiPointLink = 13;
        public const int ltUserDefinedMultiPointLink = 14;

        // Master-Slave Link
        public const int msFree = 0;
        public const int msFix = 1;
        public const int msFixNegate = -1;

        // Coupling, Attachment and Multi-Point Links
        public const int cpTranslational = 1;
        public const int cpRotational = 2;
        public const int cpBoth = 3;

        // Rigid Link
        public const int rlPlaneXYZ = 0;
        public const int rlPlaneXY = 1;
        public const int rlPlaneYZ = 2;
        public const int rlPlaneZX = 3;

        // 2-Point Link
        public const int ipTwoPointDOF1 = 0;
        public const int ipTwoPointDOF2 = 1;
        public const int ipTwoPointUCS1 = 2;
        public const int ipTwoPointUCS2 = 3;
        public const int ipTwoPointFC = 4;
        public const int ipTwoPointC1 = 0;
        public const int ipTwoPointC2 = 1;
        public const int ipTwoPointConst = 2;

        // Attachment Link
        public const int ipAttachmentElType = 0;
        public const int ipAttachmentElNum = 1;
        public const int ipAttachmentBrickFaceNum = 2;
        public const int ipAttachmentCouple = 3;

        // Node Temperature Types
        public const int ntReferenceTemperature = 0;
        public const int ntFixedTemperature = 1;
        public const int ntInitialTemperature = 2;
        public const int ntTableTemperature = 3;

        // Beam End Release Constants
        public const int brReleased = 0;
        public const int brFixed = 1;
        public const int brPartial = 2;

        // Plate Edge Release Constants
        public const int prReleased = 0;
        public const int prFixed = 1;

        // Property Types
        public const int ptBEAMPROP = 1;
        public const int ptPLATEPROP = 2;
        public const int ptBRICKPROP = 3;
        public const int ptPLYPROP = 4;

        // Property Totals
        public const int ipBeamPropTotal = 0;
        public const int ipPlatePropTotal = 1;
        public const int ipBrickPropTotal = 2;
        public const int ipPlyPropTotal = 3;

        // Alpha Temperature Types
        public const int atIntegrated = 0;
        public const int atInstantaneous = 1;

        // Sampling Positions
        public const int spCentroid = 0;
        public const int spGaussPoints = 1;
        public const int spNodesAverageNever = 2;
        public const int spNodesAverageAll = 3;
        public const int spNodesAverageSame = 4;

        // Limit Envelope Averaging
        public const int aoAverageThenEnvelope = 0;
        public const int aoEnvelopeThenAverage = 1;

        // Beam Types
        public const int btNull = 0;
        public const int btSpring = 1;
        public const int btCable = 2;
        public const int btTruss = 3;
        public const int btCutoff = 4;
        public const int btContact = 5;
        public const int btBeam = 6;
        public const int btUser = 7;
        public const int btPipe = 8;
        public const int btConnection = 9;

        // Contact Types
        public const int ctZeroGap = 0;
        public const int ctNormal = 1;
        public const int ctTension = 2;
        public const int ctTakeup = 3;

        // Takeup Contact Sub Types
        public const int tuTension = 0;
        public const int tuCompression = 1;

        // Cutoff Bar Types
        public const int cbBrittle = 0;
        public const int cbDuctile = 1;

        // Contact Parameters Positions - Integers
        public const int ipContactType = 0;
        public const int ipDynamicStiffness = 1;
        public const int ipUpdateDirection = 2;
        public const int ipContactSubType = 3;
        public const int ipFrictionYieldType = 4;
        public const int ipFrictionModel = 5;
        public const int ipTensionLateralStiffness = 6;

        // Contact Parameters Positions - Doubles
        public const int ipContactAxialStiffness = 0;
        public const int ipFrictionC1 = 1;
        public const int ipFrictionC2 = 2;
        public const int ipContactMaxTension = 3;
        public const int ipContactLateralStiffness = 4;
        public const int ipContactStrainTol = 5;

        // CutoffBar Parameter Positions
        public const int ipCutoffType = 0;
        public const int ipKeepMass = 1;

        // Library Types
        public const int lbMaterial = 0;
        public const int lbBeamSection = 1;
        public const int lbComposite = 2;
        public const int lbReinforcementLayout = 3;
        public const int lbCreepDefinition = 4;
        public const int lbLoadPathTemplate = 5;
        public const int lbSectionGeometry = 6;

        // Beam Section Types
        public const int bsNullSection = 0;
        public const int bsCircularSolid = 1;
        public const int bsCircularHollow = 2;
        public const int bsSquareSolid = 3;
        public const int bsSquareHollow = 4;
        public const int bsLipChannel = 5;
        public const int bsTopHatChannel = 6;
        public const int bsISection = 7;
        public const int bsTSection = 8;
        public const int bsLSection = 9;
        public const int bsZSection = 10;
        public const int bsUserSection = 11;
        public const int bsTrapezoidSolid = 12;
        public const int bsTrapezoidHollow = 13;
        public const int bsTriangleSolid = 14;
        public const int bsTriangleHollow = 15;
        public const int bsCruciform = 16;

        // Beam Geometry Section Types
        public const int bgNullSection = 0;
        public const int bgRectangularHollow = 1;
        public const int bgISection = 2;
        public const int bgChannel = 3;
        public const int bgTSection = 4;
        public const int bgAngle = 5;
        public const int bgBulbFlat = 6;

        // Beam Mirror Types
        public const int mtNone = 0;
        public const int mtTop = 1;
        public const int mtBot = 2;
        public const int mtLeft = 3;
        public const int mtRight = 4;
        public const int mtLeftAndTop = 5;
        public const int mtLeftAndBot = 6;
        public const int mtRightAndTop = 7;
        public const int mtRightAndBot = 8;
        public const int mtLeftTopOnly = 9;
        public const int mtLeftBotOnly = 10;
        public const int mtRightTopOnly = 11;
        public const int mtRightBotOnly = 12;

        // Beam Section Positions
        public const int ipAREA = 0;
        public const int ipI11 = 1;
        public const int ipI22 = 2;
        public const int ipJ = 3;
        public const int ipSL1 = 4;
        public const int ipSL2 = 5;
        public const int ipSA1 = 6;
        public const int ipSA2 = 7;
        public const int ipXBAR = 8;
        public const int ipYBAR = 9;
        public const int ipANGLE = 10;
        public const int ipD1 = 11;
        public const int ipD2 = 12;
        public const int ipD3 = 13;
        public const int ipT1 = 14;
        public const int ipT2 = 15;
        public const int ipT3 = 16;
        public const int ipGapA = 17;
        public const int ipGapB = 18;

        // Beam Load Types
        public const int dlConstant = 0;
        public const int dlLinear = 1;
        public const int dlTriangular = 2;
        public const int dlThreePoint0 = 3;
        public const int dlThreePoint1 = 4;
        public const int dlTrapezoidal = 5;

        // Plate Load Patch Types
        public const int ptAuto4 = 0;
        public const int ptAuto3 = 1;
        public const int ptAuto2 = 2;
        public const int ptAuto1 = 3;
        public const int ptAngleSplit = 4;
        public const int ptManual = 5;

        // Plate Types
        public const int ptNull = 0;
        public const int ptPlaneStress = 1;
        public const int ptPlaneStrain = 2;
        public const int ptAxisymmetric = 3;
        public const int ptPlateShell = 4;
        public const int ptShearPanel = 5;
        public const int ptMembrane = 6;
        public const int ptLoadPatch = 7;

        // Geometry Surface Types
        public const int suNull = -1;
        public const int suPlane = 0;
        public const int suSphere = 1;
        public const int suTorus = 2;
        public const int suCone = 3;
        public const int suBSpline = 4;
        public const int suRotSur = 5;
        public const int suPipeSur = 6;
        public const int suSumSur = 7;
        public const int suTabCyl = 8;
        public const int suRuleSur = 9;
        public const int suCubicSpline = 10;

        // Material Types
        public const int mtNull = 0;
        public const int mtIsotropic = 1;
        public const int mtOrthotropic = 2;
        public const int mtAnisotropic = 3;
        public const int mtRubber = 4;
        public const int mtSoil = 5;
        public const int mtLaminate = 6;
        public const int mtUserDefined = 7;
        public const int mtFluid = 10;

        // Soil Types
        public const int stDuncanChang = 0;
        public const int stModifiedCamClay = 1;
        public const int stMohrCoulomb = 2;
        public const int stDruckerPrager = 3;
        public const int stLinearElastic = 4;

        // Yield Criteria - beams
        public const int ycBeamFibre = 0;
        public const int ycBeamTresca = 1;
        public const int ycBeamVonMises = 2;

        // Yield Criteria - plates and bricks
        public const int ycTresca = 0;
        public const int ycVonMises = 1;
        public const int ycMaxStress = 2;
        public const int ycMohrCoulomb = 3;
        public const int ycDruckerPrager = 4;

        // Nonlinear Types
        public const int ntNonlinElastic = 0;
        public const int ntElastoPlastic = 1;

        // Rubber Types
        public const int rtNeoHookean = 1;
        public const int rtMooneyRivlin = 2;
        public const int rtGeneralisedMooneyRivlin = 3;
        public const int rtOgden = 4;

        // Material Positions
        public const int ipModulus = 0;
        public const int ipPoisson = 1;
        public const int ipDensity = 2;
        public const int ipShearModulus = 3;

        // Element Result State
        public const int ipResStateActive = 0;
        public const int ipResStateResults = 1;
        public const int ipResStateBirthStage = 2;

        // Node Result Types
        public const int rtNodeDisp = 1;
        public const int rtNodeVel = 2;
        public const int rtNodeAcc = 3;
        public const int rtNodePhase = 4;
        public const int rtNodeReact = 5;
        public const int rtNodeTemp = 6;
        public const int rtNodeFlux = 7;
        public const int rtNodeInertia = 8;
        public const int rtNodeInfluence = 1;

        // Beam Result Types
        public const int rtBeamForce = 1;
        public const int rtBeamAllStrain = 2;
        public const int rtBeamAllStress = 3;
        public const int rtBeamCableXYZ = 6;
        public const int rtBeamFlux = 8;
        public const int rtBeamGradient = 9;
        public const int rtBeamCreepStrain = 10;
        public const int rtBeamEnergy = 11;
        public const int rtBeamDisp = 12;
        public const int rtBeamNodeReact = 13;
        public const int rtBeamBirthDisp = 14;
        public const int rtBeamNodeFlux = 15;
        public const int rtBeamAxialStress = 16;
        public const int rtBeamBendingStress = 17;
        public const int rtBeamFibreStress = 18;
        public const int rtBeamAvShearStress = 19;
        public const int rtBeamShearStress = 20;
        public const int rtBeamCombinedStress = 21;
        public const int rtPipeHoopStress = 22;
        public const int rtBeamYieldAreaRatio = 23;
        public const int rtBeamUser = 24;
        public const int rtBeamAllTotalStrain = 25;
        public const int rtBeamExtraResults = 99;

        // Beam Result Quantities - BEAMFORCE - Principal
        public const int ipBeamSF1 = 0;
        public const int ipBeamBM1 = 1;
        public const int ipBeamSF2 = 2;
        public const int ipBeamBM2 = 3;

        // Beam Result Quantities - BEAMFORCE - Local
        public const int ipBeamSFx = 0;
        public const int ipBeamBMx = 1;
        public const int ipBeamSFy = 2;
        public const int ipBeamBMy = 3;

        // Beam Result Quantities - BEAMFORCE - Local and Principal
        public const int ipBeamAxialF = 4;
        public const int ipBeamTorque = 5;

        // Beam Result Quantities - BEAMFORCE - Global
        public const int ipBeamFX = 0;
        public const int ipBeamMX = 1;
        public const int ipBeamFY = 2;
        public const int ipBeamMY = 3;
        public const int ipBeamFZ = 4;
        public const int ipBeamMZ = 5;

        // Beam Result Quantities - BEAMSTRESS
        public const int ipMinFibreStress = 0;
        public const int ipMaxFibreStress = 1;
        public const int ipMaxShearStress1 = 2;
        public const int ipMaxShearStress2 = 3;
        public const int ipShearF1MeanShearStress = 4;
        public const int ipShearF2MeanShearStress = 5;
        public const int ipShearStressMag = 6;
        public const int ipMinPrincipalStress = 7;
        public const int ipMaxPrincipalStress = 8;
        public const int ipMinPipeHoopStress = 9;
        public const int ipMaxPipeHoopStress = 10;
        public const int ipMinAxialStress = 11;
        public const int ipMaxAxialStress = 12;
        public const int ipMinBendingStress1 = 13;
        public const int ipMaxBendingStress1 = 14;
        public const int ipMinBendingStress2 = 15;
        public const int ipMaxBendingStress2 = 16;
        public const int ipYieldAreaRatio = 17;
        public const int ipVonMisesStress = 18;
        public const int ipTrescaStress = 19;
        public const int ipTorqueShearStress = 20;
        public const int ipShearF1ShearStress = 21;
        public const int ipShearF2ShearStress = 22;

        // Beam Result Quantities - BEAMSTRAIN
        public const int ipAxialStrain = 0;
        public const int ipCurvature1 = 1;
        public const int ipCurvature2 = 2;
        public const int ipTwist = 3;
        public const int ipMinFibreStrain = 4;
        public const int ipMaxFibreStrain = 5;

        // Beam Result Quantities - BEAMCREEPSTRAIN
        public const int ipMinFibreCreepStrain = 0;
        public const int ipMaxFibreCreepStrain = 1;
        public const int ipMinFibreCreepStrainRate = 2;
        public const int ipMaxFibreCreepStrainRate = 3;
        public const int ipShrinkageStrain = 4;

        // Beam Result Quantities - BEAMRELEASE
        public const int ipRelEnd1Dir1 = 0;
        public const int ipRelEnd1Dir2 = 1;
        public const int ipRelEnd1Dir3 = 2;
        public const int ipRelEnd1Dir4 = 3;
        public const int ipRelEnd1Dir5 = 4;
        public const int ipRelEnd1Dir6 = 5;
        public const int ipRelEnd2Dir1 = 6;
        public const int ipRelEnd2Dir2 = 7;
        public const int ipRelEnd2Dir3 = 8;
        public const int ipRelEnd2Dir4 = 9;
        public const int ipRelEnd2Dir5 = 10;
        public const int ipRelEnd2Dir6 = 11;

        // Beam Result Quantities - BEAMENERGY
        public const int ipBeamEnergyStored = 0;
        public const int ipBeamEnergySpent = 1;

        // Beam Section Result Types
        public const int rtBeamSectionStress = 1;
        public const int rtBeamSectionStrain = 2;
        public const int rtBeamSectionCreepStrain = 3;
        public const int rtBeamSectionTotalStrain = 4;

        // Beam Section Result Quantities
        public const int ipFibreStressXY = 0;
        public const int ipShearStress1XY = 1;
        public const int ipShearStress2XY = 2;
        public const int ipMinPrincipalStressXY = 3;
        public const int ipMaxPrincipalStressXY = 4;
        public const int ipAxialStressXY = 5;
        public const int ipBendingStress1XY = 6;
        public const int ipBendingStress2XY = 7;
        public const int ipVonMisesStressXY = 8;
        public const int ipTrescaStressXY = 9;
        public const int ipTorqueStressXY = 10;
        public const int ipShearF1ShearStressXY = 11;
        public const int ipShearF2ShearStressXY = 12;

        // Plate Result Types
        public const int rtPlateStress = 1;
        public const int rtPlateStrain = 2;
        public const int rtPlateEnergyDensity = 3;
        public const int rtPlateForce = 4;
        public const int rtPlateMoment = 5;
        public const int rtPlateCurvature = 6;
        public const int rtPlatePlyStress = 7;
        public const int rtPlatePlyStrain = 8;
        public const int rtPlatePlyReserve = 9;
        public const int rtPlateFlux = 10;
        public const int rtPlateGradient = 11;
        public const int rtPlateRCDesign = 12;
        public const int rtPlateCreepStrain = 13;
        public const int rtPlateSoil = 14;
        public const int rtPlateUser = 15;
        public const int rtPlateNodeReact = 16;
        public const int rtPlateNodeDisp = 17;
        public const int rtPlateNodeBirthDisp = 18;
        public const int rtPlateEffectiveStress = 19;
        public const int rtPlateEffectiveForce = 20;
        public const int rtPlateNodeFlux = 21;
        public const int rtPlateTotalStrain = 22;
        public const int rtPlateTotalCurvature = 23;
        public const int rtPlateEnergyIntegral = 24;

        // Plate Surface Definition
        public const int psPlateMidPlane = 0;
        public const int psPlateZMinus = 1;
        public const int psPlateZPlus = 2;

        // Brick Result Types
        public const int rtBrickStress = 1;
        public const int rtBrickStrain = 2;
        public const int rtBrickEnergyDensity = 3;
        public const int rtBrickFlux = 4;
        public const int rtBrickGradient = 5;
        public const int rtBrickCreepStrain = 6;
        public const int rtBrickSoil = 7;
        public const int rtBrickUser = 8;
        public const int rtBrickNodeReact = 9;
        public const int rtBrickNodeDisp = 10;
        public const int rtBrickNodeBirthDisp = 11;
        public const int rtBrickEffectiveStress = 12;
        public const int rtBrickNodeFlux = 13;
        public const int rtBrickTotalStrain = 14;
        public const int rtBrickEnergyIntegral = 15;

        // Link Result Types
        public const int rtLinkNodeDisp = 0;
        public const int rtLinkNodeReact = 1;
        public const int rtLinkNodeFlux = 2;
        public const int rtLinkNodeBirthDisp = 3;

        // Beam Result Sub Types
        public const int stBeamLocal = 0;
        public const int stBeamPrincipal = -1;
        public const int stBeamGlobal = -2;

        // Plate Result Sub Types
        public const int stPlateLocal = 0;
        public const int stPlateGlobal = -1;
        public const int stPlateCombined = -2;
        public const int stPlateSupport = -3;
        public const int stPlateDevLocal = -4;
        public const int stPlateDevGlobal = -5;
        public const int stPlateDevCombined = -6;
        public const int stPlateCavity = -7;

        // Brick Result Sub Types
        public const int stBrickLocal = 0;
        public const int stBrickGlobal = -1;
        public const int stBrickCombined = -2;
        public const int stBrickSupport = -3;
        public const int stBrickDevLocal = -4;
        public const int stBrickDevGlobal = -5;
        public const int stBrickDevCombined = -6;
        public const int stBrickCavity = -7;

        // Link Result Sub Types
        public const int stLinkGlobal = 1;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN, PLATEMOMENT, PLATECURVATURE, PLATEFORCE results for STLOCAL
        public const int ipPlateLocalxx = 0;
        public const int ipPlateLocalyy = 1;
        public const int ipPlateLocalzz = 2;
        public const int ipPlateLocalxy = 3;
        public const int ipPlateLocalyz = 4;
        public const int ipPlateLocalzx = 5;
        public const int ipPlateLocalxz = 5;
        public const int ipPlateLocalMean = 0;
        public const int ipPlateLocalDevxx = 1;
        public const int ipPlateLocalDevyy = 2;
        public const int ipPlateEdgeSupport = 0;
        public const int ipPlateFaceSupport = 1;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN, PLATEMOMENT, PLATECURVATURE, PLATEFORCE results for STGLOBAL (NOT AXISYMMETRIC)
        public const int ipPlateGlobalXX = 0;
        public const int ipPlateGlobalYY = 1;
        public const int ipPlateGlobalZZ = 2;
        public const int ipPlateGlobalXY = 3;
        public const int ipPlateGlobalYZ = 4;
        public const int ipPlateGlobalZX = 5;
        public const int ipPlateGlobalMean = 0;
        public const int ipPlateGlobalDevXX = 1;
        public const int ipPlateGlobalDevYY = 2;
        public const int ipPlateGlobalDevZZ = 3;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN, PLATEMOMENT, PLATECURVATURE, PLATEFORCE results for STUCS
        public const int ipPlateUCSXX = 0;
        public const int ipPlateUCSYY = 1;
        public const int ipPlateUCSZZ = 2;
        public const int ipPlateUCSXY = 3;
        public const int ipPlateUCSYZ = 4;
        public const int ipPlateUCSZX = 5;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN, PLATEFORCE, PLATEMOMENT, PLATECURVATURE results for STCOMBINED (NOT AXISYMMETRIC)
        public const int ipPlateCombPrincipal11 = 0;
        public const int ipPlateCombPrincipal22 = 1;
        public const int ipPlateCombPrincipalAngle = 3;
        public const int ipPlateCombVonMises = 4;
        public const int ipPlateCombTresca = 5;
        public const int ipPlateCombMohrCoulomb = 6;
        public const int ipPlateCombDruckerPrager = 7;
        public const int ipPlateCombMagnitude = 9;
        public const int ipPlateCombPlasticStrain = 6;
        public const int ipPlateCombCreepEffRate = 6;
        public const int ipPlateCombCreepShrinkage = 7;
        public const int ipPlateCombYieldIndex = 8;
        public const int ipPlateCombMean = 0;
        public const int ipPlateCombDev11 = 1;
        public const int ipPlateCombDev22 = 2;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN results for STGLOBAL (AXISYMMETRIC)
        public const int ipPlateAxiGlobalRR = 0;
        public const int ipPlateAxiGlobalZZ = 1;
        public const int ipPlateAxiGlobalTT = 2;
        public const int ipPlateAxiGlobalRZ = 3;
        public const int ipPlateAxiGlobalMean = 0;
        public const int ipPlateAxiGlobalDevRR = 1;
        public const int ipPlateAxiGlobalDevZZ = 2;
        public const int ipPlateAxiGlobalDevTT = 3;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN results for STCOMBINED (AXISYMMETRIC)
        public const int ipPlateAxiCombPrincipal11 = 0;
        public const int ipPlateAxiCombPrincipal22 = 1;
        public const int ipPlateAxiCombPrincipal33 = 2;
        public const int ipPlateAxiCombVonMises = 4;
        public const int ipPlateAxiCombTresca = 5;
        public const int ipPlateAxiCombMohrCoulomb = 6;
        public const int ipPlateAxiCombDruckerPrager = 7;
        public const int ipPlateAxiCombMagnitude = 9;
        public const int ipPlateAxiCombPlasticStrain = 6;
        public const int ipPlateAxiCombCreepEffRate = 6;
        public const int ipPlateAxiCombCreepShrinkage = 7;
        public const int ipPlateAxiCombYieldIndex = 8;
        public const int ipPlateAxiCombMean = 0;
        public const int ipPlateAxiCombDev11 = 1;
        public const int ipPlateAxiCombDev22 = 2;
        public const int ipPlateAxiCombDev33 = 3;

        // PLATEPLYSTRESS
        public const int ipPlyStress11 = 0;
        public const int ipPlyStress22 = 1;
        public const int ipPlyStress12 = 3;
        public const int ipPlyILSx = 4;
        public const int ipPlyILSy = 5;

        // PLATEPLYSTRAIN
        public const int ipPlyStrain11 = 0;
        public const int ipPlyStrain22 = 1;
        public const int ipPlyStrain12 = 3;

        // PLATEPLYRESERVE
        public const int ipPlyMaxStress = 0;
        public const int ipPlyMaxStrain = 1;
        public const int ipPlyTsaiHill = 2;
        public const int ipPlyModTsaiWu = 3;
        public const int ipPlyHoffman = 4;
        public const int ipPlyInterlam = 5;

        // PLATESOIL
        public const int ipPlateSoilTotalPorePressure = 0;
        public const int ipPlateSoilExcessPorePressure = 1;
        public const int ipPlateSoilOCRIndex = 2;
        public const int ipPlateSoilStateIndex = 3;
        public const int ipPlateSoilVoidRatio = 4;

        // PLATEFLUX, PLATEGRADIENT results for STLOCAL
        public const int ipPlateFluxLocalx = 0;
        public const int ipPlateFluxLocaly = 1;
        public const int ipPlateFluxLocalMagxy = 2;

        // PLATEFLUX, PLATEGRADIENT results for STGLOBAL
        public const int ipPlateFluxGlobalX = 0;
        public const int ipPlateFluxGlobalY = 1;
        public const int ipPlateFluxGlobalZ = 2;
        public const int ipPlateFluxGlobalMagXY = 3;
        public const int ipPlateFluxGlobalMagYZ = 4;
        public const int ipPlateFluxGlobalMagZX = 5;
        public const int ipPlateFluxGlobalMagXYZ = 6;

        // PLATEFLUX, PLATEGRADIENT results for STUCS
        public const int ipPlateFluxUCSX = 0;
        public const int ipPlateFluxUCSY = 1;
        public const int ipPlateFluxUCSZ = 2;
        public const int ipPlateFluxUCSMagXY = 3;
        public const int ipPlateFluxUCSMagYZ = 4;
        public const int ipPlateFluxUCSMagZX = 5;
        public const int ipPlateFluxUCSMagXYZ = 6;

        // PLATERCDESIGN
        public const int ipPlateRCWoodArmerMoment = 0;
        public const int ipPlateRCWoodArmerForce = 1;
        public const int ipPlateRCSteelArea = 2;
        public const int ipPlateRCConcreteStrain = 3;
        public const int ipPlateRCSteelAreaLessBase = 4;
        public const int ipPlateRCUserSteelStress = 5;
        public const int ipPlateRCUserConcreteStrain = 6;
        public const int ipPlateRCBlockRatio = 7;

        // PLATEENERGY
        public const int ipPlateEnergyStored = 0;
        public const int ipPlateEnergySpent = 1;

        // BRICKSTRESS, BRICKSTRAIN, BRICKCREEPSTRAIN results for STLOCAL
        public const int ipBrickLocalxx = 0;
        public const int ipBrickLocalyy = 1;
        public const int ipBrickLocalzz = 2;
        public const int ipBrickLocalxy = 3;
        public const int ipBrickLocalyz = 4;
        public const int ipBrickLocalzx = 5;
        public const int ipBrickLocalMean = 0;
        public const int ipBrickLocalDevxx = 1;
        public const int ipBrickLocalDevyy = 2;
        public const int ipBrickLocalDevzz = 3;
        public const int ipBrickFaceSupport = 0;

        // BRICKSTRESS, BRICKSTRAIN, BRICKCREEPSTRAIN results for STGLOBAL
        public const int ipBrickGlobalXX = 0;
        public const int ipBrickGlobalYY = 1;
        public const int ipBrickGlobalZZ = 2;
        public const int ipBrickGlobalXY = 3;
        public const int ipBrickGlobalYZ = 4;
        public const int ipBrickGlobalZX = 5;
        public const int ipBrickGlobalMean = 0;
        public const int ipBrickGlobalDevXX = 1;
        public const int ipBrickGlobalDevYY = 2;
        public const int ipBrickGlobalDevZZ = 3;

        // BRICKSTRESS, BRICKSTRAIN, BRICKCREEPSTRAIN results for STUCS
        public const int ipBrickUCSXX = 0;
        public const int ipBrickUCSYY = 1;
        public const int ipBrickUCSZZ = 2;
        public const int ipBrickUCSXY = 3;
        public const int ipBrickUCSYZ = 4;
        public const int ipBrickUCSZX = 5;

        // BRICKSTRESS, BRICKSTRAIN, BRICKCREEPSTRAIN results for STCOMBINED
        public const int ipBrickCombPrincipal11 = 0;
        public const int ipBrickCombPrincipal22 = 1;
        public const int ipBrickCombPrincipal33 = 2;
        public const int ipBrickCombVonMises = 3;
        public const int ipBrickCombTresca = 4;
        public const int ipBrickCombMohrCoulomb = 5;
        public const int ipBrickCombDruckerPrager = 6;
        public const int ipBrickCombPlasticStrain = 6;
        public const int ipBrickCombCreepEffRate = 6;
        public const int ipBrickCombCreepShrinkage = 7;
        public const int ipBrickCombMean = 7;
        public const int ipBrickCombYieldIndex = 8;
        public const int ipBrickCombMagnitude = 9;
        public const int ipBrickCombDevMean = 0;
        public const int ipBrickCombDev11 = 1;
        public const int ipBrickCombDev22 = 2;
        public const int ipBrickCombDev33 = 3;

        // BRICKSOIL
        public const int ipBrickSoilTotalPorePressure = 0;
        public const int ipBrickSoilExcessPorePressure = 1;
        public const int ipBrickSoilOCRIndex = 2;
        public const int ipBrickSoilStateIndex = 3;
        public const int ipBrickSoilVoidRatio = 4;

        // BRICKFLUX, BRICKGRADIENT results for STLOCAL
        public const int ipBrickFluxLocalx = 0;
        public const int ipBrickFluxLocaly = 1;
        public const int ipBrickFluxLocalz = 2;
        public const int ipBrickFluxLocalMagxy = 3;
        public const int ipBrickFluxLocalMagyz = 4;
        public const int ipBrickFluxLocalMagzx = 5;
        public const int ipBrickFluxLocalMagxyz = 6;

        // BRICKFLUX, BRICKGRADIENT results for STGLOBAL
        public const int ipBrickFluxGlobalX = 0;
        public const int ipBrickFluxGlobalY = 1;
        public const int ipBrickFluxGlobalZ = 2;
        public const int ipBrickFluxGlobalMagXY = 3;
        public const int ipBrickFluxGlobalMagYZ = 4;
        public const int ipBrickFluxGlobalMagZX = 5;
        public const int ipBrickFluxGlobalMagXYZ = 6;

        // BRICKFLUX, BRICKGRADIENT results for STUCS
        public const int ipBrickFluxUCSX = 0;
        public const int ipBrickFluxUCSY = 1;
        public const int ipBrickFluxUCSZ = 2;
        public const int ipBrickFluxUCSMagXY = 3;
        public const int ipBrickFluxUCSMagYZ = 4;
        public const int ipBrickFluxUCSMagZX = 5;
        public const int ipBrickFluxUCSMagXYZ = 6;

        // BRICKENERGY
        public const int ipBrickEnergyStored = 0;
        public const int ipBrickEnergySpent = 1;

        // MODAL RESULTS NFA
        public const int ipFrequencyNFA = 0;
        public const int ipModalMassNFA = 1;
        public const int ipModalStiffNFA = 2;
        public const int ipModalDampNFA = 3;
        public const int ipModalTMassP1 = 4;
        public const int ipModalTMassP2 = 5;
        public const int ipModalTMassP3 = 6;
        public const int ipModalRMassP1 = 7;
        public const int ipModalRMassP2 = 8;
        public const int ipModalRMassP3 = 9;

        // MODAL RESULTS HRA
        public const int ipFrequencyHRA = 0;
        public const int ipDampRatioHRA = 1;
        public const int ipAmplitudeHRA = 2;
        public const int ipPhaseAngleHRA = 3;
        public const int ipMassPartHRA = 4;

        // MODAL RESULTS SRA
        public const int ipFrequencySRA = 0;
        public const int ipSpectralValueSRA = 1;
        public const int ipDampRatioSRA = 2;
        public const int ipAmplitudeSRA = 3;
        public const int ipExcitationSRA = 4;
        public const int ipMassPartSRA = 5;

        // INERTIA RELIEF RESULTS
        public const int ipMassXIRA = 0;
        public const int ipMassYIRA = 1;
        public const int ipMassZIRA = 2;
        public const int ipXcIRA = 3;
        public const int ipYcIRA = 4;
        public const int ipZcIRA = 5;
        public const int ipAccXIRA = 6;
        public const int ipAccYIRA = 7;
        public const int ipAccZIRA = 8;
        public const int ipAngAccXIRA = 9;
        public const int ipAngAccYIRA = 10;
        public const int ipAngAccZIRA = 11;

        // CONTOUR FILE EXTRAPOLATION
        public const int eoCentroid = 0;
        public const int eoNode = 1;
        public const int eoGaussPoint = 2;

        // CONTOUR FILE AVERAGING
        public const int aoAlways = 0;
        public const int aoNever = 1;
        public const int aoSameProp = 2;
        public const int aoJumps = 3;
        public const int aoJumpsN = 4;
        public const int aoRange = 5;
        public const int aoSamePropAndStage = 6;

        // CONTOUR FILE INDEXES
        public const int ipQuantityRF = 0;
        public const int ipSystemRF = 1;
        public const int ipComponentRF = 2;
        public const int ipLayerRF = 3;
        public const int ipExtrapolateRF = 4;
        public const int ipAverageRF = 5;
        public const int ipAbsoluteRF = 6;
        public const int ipSubtractSupportRF = 7;

        // Coordinate System Types
        public const int csCartesian = 0;
        public const int csCylindrical = 1;
        public const int csSpherical = 2;
        public const int csToroidal = 3;

        // Matrix Types
        public const int mtCompliance = 1;
        public const int mtStiffness = 2;

        // Vertex Types
        public const int vtFree = 1;
        public const int vtFixed = 2;

        // Beam Distributed Load Projection Options
        public const int bpNone = 0;
        public const int bpProjected = 1;

        // Edge Types
        public const int etInterpolated = 0;
        public const int etNonInterpolated = 1;

        // Edge Cluster Origin Types
        public const int coAutoClusterOrigin = 0;
        public const int coManualClusterOrigin = 1;

        // Plate/Face Global Pressure Projection Options
        public const int ppNone = 0;
        public const int ppProjResultant = 1;
        public const int ppProjComponents = 2;

        // Node/Vertex Attribute Types
        public const int aoRestraint = 1;
        public const int aoForce = 2;
        public const int aoMoment = 3;
        public const int aoTemperature = 4;
        public const int aoMTranslation = 5;
        public const int aoMRotation = 6;
        public const int aoKTranslation = 7;
        public const int aoKRotation = 8;
        public const int aoDamping = 9;
        public const int aoNSMass = 10;
        public const int aoNodeInfluence = 11;
        public const int aoNodeHeatSource = 12;
        public const int aoNodeVelocity = 13;
        public const int aoNodeAcceleration = 14;
        public const int aoVertexMeshSize = 20;

        // Beam Attribute Types
        public const int aoBeamAngle = 21;
        public const int aoBeamOffset = 22;
        public const int aoBeamTEndRelease = 23;
        public const int aoBeamREndRelease = 24;
        public const int aoBeamSupport = 25;
        public const int aoBeamPreTension = 26;
        public const int aoCableFreeLength = 27;
        public const int aoBeamDLL = 28;
        public const int aoBeamDLG = 29;
        public const int aoBeamCFL = 30;
        public const int aoBeamCFG = 31;
        public const int aoBeamCML = 32;
        public const int aoBeamCMG = 33;
        public const int aoBeamTempGradient = 34;
        public const int aoBeamConvection = 35;
        public const int aoBeamRadiation = 36;
        public const int aoBeamFlux = 37;
        public const int aoBeamHeatSource = 38;
        public const int aoBeamRadius = 39;
        public const int aoPipePressure = 40;
        public const int aoBeamNSMass = 41;
        public const int aoPipeTemperature = 42;
        public const int aoBeamDML = 44;
        public const int aoBeamStringGroup = 45;
        public const int aoBeamPreCurvature = 46;
        public const int aoBeamTaper = 92;
        public const int aoBeamInfluence = 93;
        public const int aoBeamSectionFactor = 94;
        public const int aoBeamCreepLoadingAge = 95;
        public const int aoBeamEndAttachment = 96;
        public const int aoBeamConnectionUCS = 97;
        public const int aoBeamStageProperty = 98;
        public const int aoBeamSideAttachment = 120;

        // Plate/Edge/Face Attribute Types
        public const int aoPlateAngle = 51;
        public const int aoPlateOffset = 52;
        public const int aoPlatePreLoad = 53;
        public const int aoPlateFacePressure = 54;
        public const int aoPlateFaceShear = 55;
        public const int aoPlateEdgeNormalPressure = 56;
        public const int aoPlateEdgeShear = 57;
        public const int aoPlateEdgeTransverseShear = 58;
        public const int aoPlateTempGradient = 59;
        public const int aoPlateEdgeSupport = 60;
        public const int aoPlateFaceSupport = 61;
        public const int aoPlateEdgeConvection = 62;
        public const int aoPlateEdgeRadiation = 63;
        public const int aoPlateFlux = 64;
        public const int aoPlateHeatSource = 65;
        public const int aoPlateGlobalPressure = 66;
        public const int aoPlateEdgeRelease = 67;
        public const int aoPlateReinforcement = 68;
        public const int aoPlateThickness = 69;
        public const int aoPlateNSMass = 70;
        public const int aoLoadPatch = 71;
        public const int aoPlateEdgeGlobalPressure = 72;
        public const int aoPlatePreCurvature = 73;
        public const int aoPlatePointForce = 99;
        public const int aoPlatePointMoment = 100;
        public const int aoPlateFaceConvection = 101;
        public const int aoPlateFaceRadiation = 102;
        public const int aoPlateInfluence = 103;
        public const int aoPlateSoilStress = 104;
        public const int aoPlateSoilRatio = 105;
        public const int aoPlateCreepLoadingAge = 106;
        public const int aoPlateEdgeAttachment = 107;
        public const int aoPlateFaceAttachment = 108;
        public const int aoPlateStageProperty = 109;
        public const int aoPlateSectionFactor = 121;
        public const int aoPlateCavity = 122;

        // Brick Attribute Types
        public const int aoBrickPressure = 81;
        public const int aoBrickShear = 82;
        public const int aoBrickFaceFoundation = 83;
        public const int aoBrickConvection = 84;
        public const int aoBrickRadiation = 85;
        public const int aoBrickFlux = 86;
        public const int aoBrickHeatSource = 87;
        public const int aoBrickGlobalPressure = 88;
        public const int aoBrickNSMass = 89;
        public const int aoBrickLocalAxes = 90;
        public const int aoBrickPreLoad = 91;
        public const int aoBrickPointForce = 110;
        public const int aoBrickInfluence = 111;
        public const int aoBrickSoilStress = 112;
        public const int aoBrickSoilRatio = 113;
        public const int aoBrickCreepLoadingAge = 114;
        public const int aoBrickFaceAttachment = 115;
        public const int aoBrickStageProperty = 116;
        public const int aoBrickCavity = 123;

        // Path Attribute Types
        public const int aoPathPointForce = 117;
        public const int aoPathDistributedForce = 118;
        public const int aoPathHeatSource = 119;

        // Attribute Deletion and AttributeSequence Indexes
        public const int ipAttrLocal = 0;
        public const int ipAttrAxis = 1;
        public const int ipAttrCase = 2;
        public const int ipAttrID = 3;

        // Marker Types
        public const int mtCircleMarker = 0;
        public const int mtSquareMarker = 1;
        public const int mtTriangleMarker = 2;
        public const int mtRectangleMarker = 3;
        public const int mtEntityHighlight = 4;
        public const int mtBanner = 5;

        // Marker Styles
        public const int msFilled = 0;
        public const int msOutlined = 1;
        public const int msFilledOutlined = 2;

        // Marker Definition Integers Indexes
        public const int ipMarkerType = 0;
        public const int ipMarkerStyle = 1;
        public const int ipMarkerFillColour = 2;
        public const int ipMarkerLineColour = 3;
        public const int ipMarkerLineThickness = 4;
        public const int ipMarkerSize = 5;
        public const int ipMarkerHeight = 6;
        public const int ipMarkerAnchorX = 7;
        public const int ipMarkerAnchorY = 8;
        public const int ipMarkerVisible = 9;
        public const int ipMarkerNumber = 10;
        public const int ipMarkerLabelled = 11;

        // Title Block
        public const int tbTitle = 0;
        public const int tbProject = 1;
        public const int tbReference = 2;
        public const int tbAuthor = 3;
        public const int tbCreated = 4;
        public const int tbModified = 5;

        // Table Types
        public const int ttVsTime = 1;
        public const int ttVsTemperature = 2;
        public const int ttVsFrequency = 3;
        public const int ttStressStrain = 4;
        public const int ttForceDisplacement = 5;
        public const int ttMomentCurvature = 6;
        public const int ttMomentRotation = 8;
        public const int ttAccVsTime = 9;
        public const int ttForceVelocity = 10;
        public const int ttVsPosition = 11;
        public const int ttStrainTime = 12;
        public const int ttDispVsTime = 13;
        public const int ttVelVsTime = 14;
        public const int ttVsVelocity = 15;
        public const int ttTemperatureVsTime = 16;

        // Acceleration Time Table Types
        public const int atModelUnits = 0;
        public const int atGravityUnits = 1;

        // Frequency Table Types
        public const int ftPeriod = 0;
        public const int ftFrequency = 1;

        // Beam Prop Table Entries
        public const int ptBeamStiffModVsTemp = 1001;
        public const int ptBeamAlphaVsTemp = 1002;
        public const int ptBeamConductVsTemp = 1003;
        public const int ptBeamCpVsTemp = 1004;
        public const int ptBeamStiffModVsTime = 1005;
        public const int ptBeamConductVsTime = 1006;
        public const int ptSpringAxialVsDisp = 1007;
        public const int ptSpringTorqueVsTwist = 1008;
        public const int ptSpringAxialVsVelocity = 1009;
        public const int ptBeamStressVsStrain = 1011;
        public const int ptBeamMomentK1 = 1012;
        public const int ptBeamMomentK2 = 1013;
        public const int ptConnectionShear1 = 1014;
        public const int ptConnectionShear2 = 1015;
        public const int ptConnectionAxial = 1016;
        public const int ptConnectionBend1 = 1017;
        public const int ptConnectionBend2 = 1018;
        public const int ptConnectionTorque = 1019;
        public const int ptBeamYieldVsTemp = 1020;

        // Plate Prop Table Entries
        public const int ptPlateModVsTemp = 2001;
        public const int ptPlateAlphaVsTemp = 2002;
        public const int ptPlateConductVsTemp = 2003;
        public const int ptPlateCpVsTemp = 2004;
        public const int ptPlateModVsTime = 2005;
        public const int ptPlateConductVsTime = 2006;
        public const int ptPlateStressVsStrain = 2007;
        public const int ptPlateYieldVsTemp = 2008;

        // Brick Prop Table Entries
        public const int ptBrickModVsTemp = 3001;
        public const int ptBrickAlphaVsTemp = 3002;
        public const int ptBrickConductVsTemp = 3003;
        public const int ptBrickCpVsTemp = 3004;
        public const int ptBrickModVsTime = 3005;
        public const int ptBrickConductVsTime = 3006;
        public const int ptBrickStressVsStrain = 3007;
        public const int ptBrickYieldVsTemp = 3008;

        // Creep Laws
        public const int clConcreteHyperbolic = 0;
        public const int clConcreteViscoChain = 1;
        public const int clConcreteUserDefined = 2;
        public const int clPrimaryPower = 3;
        public const int clSecondaryPower = 4;
        public const int clPrimarySecondaryPower = 5;
        public const int clSecondaryHyperbolic = 6;
        public const int clSecondaryExponential = 7;
        public const int clThetaProjection = 8;
        public const int clGenGraham = 9;
        public const int clGenBlackburn = 10;
        public const int clUserDefined = 11;

        // Load Case Types
        public const int lcNoInertia = 0;
        public const int lcGravity = 1;
        public const int lcAccelerations = 2;
        public const int lcSeismic = 3;

        // Freedom Case Types
        public const int fcNormalFreedom = 0;
        public const int fcFreeBodyInertiaRelief = 1;
        public const int fcSingleSymmetryInertiaXY = 2;
        public const int fcSingleSymmetryInertiaYZ = 3;
        public const int fcSingleSymmetryInertiaZX = 4;
        public const int fcDoubleSymmetryInertiaX = 5;
        public const int fcDoubleSymmetryInertiaY = 6;
        public const int fcDoubleSymmetryInertiaZ = 7;

        // Linear Combination Options
        public const int kNoCombinations = 0;
        public const int kGenerateNewCombinations = 1;
        public const int kUseExistingCombinations = 2;

        // Influence Case Types
        public const int icInfluenceMin = 0;
        public const int icInfluenceMax = 1;

        // Influence Combination Options
        public const int ipInfCaseLabel = 0;
        public const int ipInfCaseVariable = 1;
        public const int ipInfCaseLoadCase = 2;
        public const int ipInfCaseFreedomCase = 3;
        public const int ipInfCaseResponseType = 4;

        // Influence Warning Codes
        public const int wcInfluenceNoWarning = 0;
        public const int wcInfluenceUserTerminated = 1;
        public const int wcInfluenceRanOutOfAttributeID = 2;

        // Harmonic Combination Warning Codes
        public const int wcHarmonicCombineNoWarning = 0;
        public const int wcHarmonicCombineInvalidLSA = 1;

        // Global Load Case
        public const int ipLoadCaseRefTemp = 0;
        public const int ipLoadCaseOrigX = 1;
        public const int ipLoadCaseOrigY = 2;
        public const int ipLoadCaseOrigZ = 3;
        public const int ipLoadCaseAccX = 4;
        public const int ipLoadCaseAccY = 5;
        public const int ipLoadCaseAccZ = 6;
        public const int ipLoadCaseAngVelX = 7;
        public const int ipLoadCaseAngVelY = 8;
        public const int ipLoadCaseAngVelZ = 9;
        public const int ipLoadCaseAngAccX = 10;
        public const int ipLoadCaseAngAccY = 11;
        public const int ipLoadCaseAngAccZ = 12;

        // Global Seismic Load Case
        public const int ipSeismicCaseAlpha = 0;
        public const int ipSeismicCasePhi = 1;
        public const int ipSeismicCaseBeta = 2;
        public const int ipSeismicCaseK = 3;
        public const int ipSeismicCaseh0 = 4;
        public const int ipSeismicCaseDir = 5;
        public const int ipSeismicCaseLinAcc = 6;
        public const int ipSeismicCaseV1 = 7;
        public const int ipSeismicCaseV2 = 8;

        // Damping Types
        public const int dtNoDamping = 0;
        public const int dtRayleighDamping = 1;
        public const int dtModalDamping = 2;
        public const int dtViscousDamping = 3;

        // Rayleigh Modes
        public const int rmSetFrequencies = 0;
        public const int rmSetAlphaBeta = 1;

        // Rayleigh Damping Factors
        public const int ipRayleighF1 = 0;
        public const int ipRayleighF2 = 1;
        public const int ipRayleighR1 = 2;
        public const int ipRayleighR2 = 3;
        public const int ipRayleighAlpha = 0;
        public const int ipRayleighBeta = 1;
        public const int ipRayleighDisplayF1 = 4;
        public const int ipRayleighDisplayF2 = 5;

        // Entity Solver Result Types - HEAT
        public const int hrNodeFlux = 1;
        public const int hrBeamFlux = 2;
        public const int hrPlateFlux = 3;
        public const int hrBrickFlux = 4;
        public const int hrLinkFlux = 22;

        // Entity Solver Result Types - FREQUENCY
        public const int frBeamForcePattern = 5;
        public const int frBeamStrainPattern = 6;
        public const int frPlateStressPattern = 7;
        public const int frPlateStrainPattern = 8;
        public const int frBrickStressPattern = 9;
        public const int frBrickStrainPattern = 10;

        // Entity Solver Result Types - STRUCTURAL
        public const int srNodeReaction = 11;
        public const int srNodeVelocity = 12;
        public const int srNodeAcceleration = 13;
        public const int srBeamForce = 14;
        public const int srBeamMNLStress = 15;
        public const int srBeamStrain = 16;
        public const int srPlateStress = 17;
        public const int srPlateStrain = 18;
        public const int srBrickStress = 19;
        public const int srBrickStrain = 20;
        public const int srElementNodeForce = 21;
        public const int srLinkForce = 23;
        public const int srNodeInertia = 24;

        // Solver Defaults - LOGICALS
        public const int spDoSturm = 1;
        public const int spNonlinearMaterial = 2;
        public const int spUnusedL3 = 3;
        public const int spNonlinearGeometry = 4;
        public const int spUnusedL5 = 5;
        public const int spAddKg = 6;
        public const int spUnusedL7 = 7;
        public const int spCalcDampingRatios = 8;
        public const int spIncludeLinkReactions = 9;
        public const int spFullSystemTransient = 10;
        public const int spNonlinearHeat = 11;
        public const int spLumpedLoadBeam = 12;
        public const int spLumpedLoadPlate = 13;
        public const int spUnusedL14 = 14;
        public const int spLumpedMassBeam = 15;
        public const int spLumpedMassPlate = 16;
        public const int spLumpedMassBrick = 17;
        public const int spForceSingularityCheck = 18;
        public const int spUnusedL19 = 19;
        public const int spSaveRestartFile = 20;
        public const int spSaveIntermediate = 21;
        public const int spExcludeMassX = 22;
        public const int spExcludeMassY = 23;
        public const int spExcludeMassZ = 24;
        public const int spSaveSRSSSpectral = 25;
        public const int spSaveCQCSpectral = 26;
        public const int spDoResidualsCheck = 27;
        public const int spSuppressAllSingularities = 28;
        public const int spUnusedL29 = 29;
        public const int spUnusedL30 = 30;
        public const int spReducedLogFile = 31;
        public const int spIncludeRotationalMass = 32;
        public const int spIgnoreCompressiveBeamKg = 33;
        public const int spAutoScaleKg = 34;
        public const int spUnusedL35 = 35;
        public const int spScaleSupports = 36;
        public const int spAutoShift = 37;
        public const int spSaveTableInsertedSteps = 38;
        public const int spSaveLastRestartStep = 39;
        public const int spUnusedL40 = 40;
        public const int spDoInstantNTA = 41;
        public const int spAllowExtraIterations = 42;
        public const int spPredictImpact = 43;
        public const int spAutoWorkingSet = 44;
        public const int spDampingForce = 45;
        public const int spLimitDisplacementNLA = 46;
        public const int spLimitRotationNLA = 47;
        public const int spSaveFinalSubStep = 48;
        public const int spCablesAsMultiCase = 49;
        public const int spShowMessages = 50;
        public const int spShowProgress = 51;
        public const int spShowConvergenceGraph = 52;
        public const int spUnusedL53 = 53;
        public const int spSpectralBaseExcitation = 54;
        public const int spSpectralLoadExcitation = 55;
        public const int spUnusedL56 = 56;
        public const int spCheckEigenvector = 57;
        public const int spAppendRemainingTime = 58;
        public const int spIncludeFollowerLoadKG = 59;
        public const int spInertiaForce = 60;
        public const int spSolverGeneratesCombinations = 61;
        public const int spAutoNewmarkAlpha = 62;

        // Solver Defaults - INTEGERS
        public const int spTreeStartNumber = 1;
        public const int spNumFrequency = 2;
        public const int spNumBucklingModes = 3;
        public const int spMaxIterationEig = 4;
        public const int spMaxIterationNonlin = 5;
        public const int spNumBeamSlicesModal = 6;
        public const int spMaxConjugateGradientIter = 7;
        public const int spMaxNumRepeatedMessages = 8;
        public const int spFiniteStrainDefinition = 9;
        public const int spBeamLength = 10;
        public const int spFormStiffMatrix = 11;
        public const int spMaxUpdateInterval = 12;
        public const int spFormNonlinHeatStiffMatrix = 13;
        public const int spExpandWorkingSet = 14;
        public const int spMinNumViscoUnits = 15;
        public const int spMaxNumViscoUnits = 16;
        public const int spCurveFitTimeUnit = 17;
        public const int spStaticAutoStepping = 18;
        public const int spBeamKgType = 19;
        public const int spDynamicAutoStepping = 20;
        public const int spMaxIterationHeat = 21;

        // Solver Defaults - DOUBLES
        public const int spEigenTolerance = 1;
        public const int spFrequencyShift = 2;
        public const int spBucklingShift = 3;
        public const int spNonlinDispTolerance = 4;
        public const int spNonlinResidualTolerance = 5;
        public const int spTransientReferenceTemperature = 6;
        public const int spRelaxationFactor = 7;
        public const int spNonlinHeatTolerance = 8;
        public const int spMinimumTimeStep = 9;
        public const int spWilsonTheta = 10;
        public const int spNewmarkBeta = 11;
        public const int spGlobalZeroDiagonal = 12;
        public const int spConjugateGradientTol = 13;
        public const int spMinimumDimension = 14;
        public const int spMinimumInternalAngle = 15;
        public const int spZeroForce = 16;
        public const int spZeroDiagonal = 17;
        public const int spZeroContactFactor = 18;
        public const int spUnusedD19 = 19;
        public const int spZeroTranslation = 20;
        public const int spZeroRotation = 21;
        public const int spDrillStiffFactorQ8 = 22;
        public const int spUnusedD23 = 23;
        public const int spMaxNormalsAngle = 24;
        public const int spUnusedD25 = 25;
        public const int spMaximumRotation = 26;
        public const int spZeroDisplacement = 27;
        public const int spMaximumDispRatio = 28;
        public const int spMinimumLoadReductionFactor = 29;
        public const int spMaxDispChange = 30;
        public const int spMaxResidualChange = 31;
        public const int spZeroFrequency = 32;
        public const int spZeroBucklingEigen = 33;
        public const int spCurveFitTime = 34;
        public const int spSpacingBias = 35;
        public const int spTimeStepParam = 36;
        public const int spUnusedD37 = 37;
        public const int spMNLTangentRatio = 38;
        public const int spUnusedD39 = 39;
        public const int spMinArcLengthFactor = 40;
        public const int spMaxFibreStrainInc = 41;
        public const int spMaxDisplacementNLA = 42;
        public const int spMaxRotationNLA = 43;
        public const int spClusterZeroDiagonal = 44;
        public const int spUpdateDirContactCheckPoint = 45;
        public const int spFrictionModulusRatio = 46;
        public const int spNewmarkAlpha = 47;
        public const int spDrillStiffFactorQ4 = 48;
        public const int spDrillStiffFactorT3 = 49;

        // Solver Parameters Constants - spBeamKgType
        public const int scSimplifiedBeamKg = 0;
        public const int scCompleteBeamKg = 1;

        // Solver Parameters Constants - spBeamLength
        public const int scInitialBeamLength = 0;
        public const int scUpdatedBeamLength = 1;

        // Solver Parameters Constants - spStaticAutoStepping
        public const int scStaticAutoStepNone = 0;
        public const int scStaticAutoStepLoad = 1;
        public const int scStaticAutoStepDispLoad = 2;
        public const int scStaticAutoStepDispDisp = 3;
        public const int scStaticAutoStepDispArc = 4;

        // Solver Parameters Constants - spDynamicAutoStepping
        public const int scDynamicAutoStepNone = 0;
        public const int scDynamicAutoStepTime = 1;
        public const int scDynamicAutoStepDispTime = 2;
        public const int scDynamicAutoStepDispDisp = 3;

        // Solver Parameters Constants - spFiniteStrainDefinition
        public const int scFiniteStrainNominal = 0;
        public const int scFiniteStrainEng = 1;
        public const int scFiniteStrainGreen = 2;

        // Solver Parameters Constants - spFormNonlinHeatStiffMatrix
        public const int scHeatMatrixEveryRow = 0;
        public const int scHeatMatrixSavedStep = 1;
        public const int scHeatMatrixEveryStep = 2;

        // Solver Parameters Constants - spFormStiffMatrix
        public const int scStiffnessMatrixEveryIteration = 0;
        public const int scStiffnessMatrixTwoIterations = 1;
        public const int scStiffnessMatrixOneIteration = 2;
        public const int scStiffnessMatrixAutomatic = 3;

        // Spectral Base Load Types
        public const int slBaseAcc = 0;
        public const int slBaseVel = 1;
        public const int slBaseDisp = 2;
        public const int slAppliedLoad = 3;

        // Harmonic Load Types
        public const int hlBaseAcc = 0;
        public const int hlBaseVel = 1;
        public const int hlBaseDisp = 2;
        public const int hlAppliedLoad = 3;

        // Transient Base Excitation Types
        public const int beNone = 0;
        public const int beAcceleration = 1;
        public const int beVelocity = 2;
        public const int beDisplacement = 3;

        // Harmonic Modes
        public const int hmVsFrequency = 0;
        public const int hmVsTime = 1;

        // Solver Matrix Schemes
        public const int stSkyline = 0;
        public const int stSparse = 1;
        public const int stIterativePCG = 3;

        // Solver Temperature Dependence Types
        public const int tdNone = 0;
        public const int tdCombined = 1;

        // Result File Open Indexes
        public const int ipHideUnconvergedLBA = 1;
        public const int ipHideNegativeLBA = 2;
        public const int ipHideUnconvergedNFA = 3;
        public const int ipHideZeroNFA = 4;
        public const int ipHideModalSRA = 5;
        public const int ipHideUnconvergedNLA = 6;
        public const int ipHideSubStepNLA = 7;
        public const int ipHideUnconvergedNTA = 8;
        public const int ipHideSubStepNTA = 9;
        public const int ipHideUnconvergedQSA = 10;
        public const int ipHideSubStepQSA = 11;

        // Sort Types
        public const int rnNone = 0;
        public const int rnTree = 1;
        public const int rnGeometry = 2;
        public const int rnAMD = 3;

        // Utility
        public const int ztAbsolute = 0;
        public const int ztRelative = 1;

        // Boolean Types
        public const int btFalse = 0;
        public const int btTrue = 1;

        // Error Codes
        public const int ERR7_APIAlreadyInitialised = -12;
        public const int ERR7_LoginExceeded = -11;
        public const int ERR7_CannotCommunicate = -10;
        public const int ERR7_CannotFindNetworkLock = -9;
        public const int ERR7_CannotFindStandaloneLock = -8;
        public const int ERR7_CannotInitialiseDirectX = -7;
        public const int ERR7_InvalidRegionalSettings = -6;
        public const int ERR7_InvalidDLLsPresent = -5;
        public const int ERR7_APINotInitialised = -4;
        public const int ERR7_InvalidErrorCode = -3;
        public const int ERR7_APIModuleNotLicensed = -2;
        public const int ERR7_UnknownError = -1;
        public const int ERR7_NoError = 0;
        public const int ERR7_FileAlreadyOpen = 1;
        public const int ERR7_FileNotFound = 2;
        public const int ERR7_FileNotSt7 = 3;
        public const int ERR7_InvalidFileName = 4;
        public const int ERR7_FileIsNewer = 5;
        public const int ERR7_CannotReadFile = 6;
        public const int ERR7_InvalidScratchPath = 7;
        public const int ERR7_FileNotOpen = 8;
        public const int ERR7_ExceededTotal = 9;
        public const int ERR7_DataNotFound = 10;
        public const int ERR7_InvalidResultFile = 11;
        public const int ERR7_ResultFileNotOpen = 12;
        public const int ERR7_ExceededResultCase = 13;
        public const int ERR7_UnknownResultType = 14;
        public const int ERR7_UnknownResultLocation = 15;
        public const int ERR7_UnknownSurfaceLocation = 16;
        public const int ERR7_UnknownProperty = 17;
        public const int ERR7_InvalidEntity = 18;
        public const int ERR7_InvalidBeamPosition = 19;
        public const int ERR7_InvalidLoadCase = 20;
        public const int ERR7_InvalidFreedomCase = 21;
        public const int ERR7_UnknownTitle = 22;
        public const int ERR7_InvalidResOptsNFADisp = 23;
        public const int ERR7_TooManyBeamStations = 24;
        public const int ERR7_UnknownSubType = 25;
        public const int ERR7_GroupIdDoesNotExist = 26;
        public const int ERR7_InvalidFileUnit = 27;
        public const int ERR7_CannotSaveFile = 28;
        public const int ERR7_ResultFileIsOpen = 29;
        public const int ERR7_InvalidUnits = 30;
        public const int ERR7_InvalidEntityNodes = 31;
        public const int ERR7_InvalidUCSType = 32;
        public const int ERR7_InvalidUCSID = 33;
        public const int ERR7_UCSIDAlreadyExists = 34;
        public const int ERR7_CaseNameAlreadyExists = 35;
        public const int ERR7_InvalidEntityNumber = 36;
        public const int ERR7_InvalidBeamEnd = 37;
        public const int ERR7_InvalidBeamDir = 38;
        public const int ERR7_InvalidPlateEdge = 39;
        public const int ERR7_InvalidBrickFace = 40;
        public const int ERR7_InvalidBeamType = 41;
        public const int ERR7_InvalidPlateType = 42;
        public const int ERR7_InvalidMaterialType = 43;
        public const int ERR7_PropertyAlreadyExists = 44;
        public const int ERR7_InvalidBeamSectionType = 45;
        public const int ERR7_PropertyNotSpring = 46;
        public const int ERR7_PropertyNotCable = 47;
        public const int ERR7_PropertyNotTruss = 48;
        public const int ERR7_PropertyNotCutOffBar = 49;
        public const int ERR7_PropertyNotPointContact = 50;
        public const int ERR7_PropertyNotBeam = 51;
        public const int ERR7_PropertyNotPipe = 52;
        public const int ERR7_PropertyNotConnectionBeam = 53;
        public const int ERR7_InvalidSectionParameters = 54;
        public const int ERR7_PropertyNotUserDefinedBeam = 55;
        public const int ERR7_MaterialIsUserDefined = 56;
        public const int ERR7_MaterialNotIsotropic = 57;
        public const int ERR7_MaterialNotOrthotropic = 58;
        public const int ERR7_InvalidRubberModel = 59;
        public const int ERR7_MaterialNotRubber = 60;
        public const int ERR7_InvalidSectionProperties = 61;
        public const int ERR7_PlateDoesNotHaveThickness = 62;
        public const int ERR7_IncompatibleMaterialCombination = 63;
        public const int ERR7_UnknownSolver = 64;
        public const int ERR7_InvalidSolverMode = 65;
        public const int ERR7_InvalidMirrorOption = 66;
        public const int ERR7_SectionCannotBeMirrored = 67;
        public const int ERR7_InvalidTableType = 68;
        public const int ERR7_InvalidTableName = 69;
        public const int ERR7_TableNameAlreadyExists = 70;
        public const int ERR7_InvalidNumberOfEntries = 71;
        public const int ERR7_InvalidToleranceType = 72;
        public const int ERR7_TableDoesNotExist = 73;
        public const int ERR7_NotFrequencyTable = 74;
        public const int ERR7_InvalidFrequencyType = 75;
        public const int ERR7_InvalidTableSetting = 76;
        public const int ERR7_IncompatibleTableType = 77;
        public const int ERR7_IncompatibleCriterionCombination = 78;
        public const int ERR7_InvalidModalFile = 79;
        public const int ERR7_InvalidCombinationCaseNumber = 80;
        public const int ERR7_InvalidInitialCaseNumber = 81;
        public const int ERR7_InvalidInitialFile = 82;
        public const int ERR7_InvalidModeNumber = 83;
        public const int ERR7_BeamIsNotBXS = 84;
        public const int ERR7_InvalidDampingType = 85;
        public const int ERR7_InvalidRayleighMode = 86;
        public const int ERR7_CannotReadBXS = 87;
        public const int ERR7_InvalidResultType = 88;
        public const int ERR7_InvalidSolverParameter = 89;
        public const int ERR7_InvalidModalLoadType = 90;
        public const int ERR7_InvalidTimeRow = 91;
        public const int ERR7_SparseSolverModuleNotLicensed = 92;
        public const int ERR7_InvalidSolverScheme = 93;
        public const int ERR7_InvalidSortOption = 94;
        public const int ERR7_IncompatibleResultFile = 95;
        public const int ERR7_InvalidLinkType = 96;
        public const int ERR7_InvalidLinkData = 97;
        public const int ERR7_OnlyOneLoadCase = 98;
        public const int ERR7_OnlyOneFreedomCase = 99;
        public const int ERR7_InvalidLoadID = 100;
        public const int ERR7_InvalidBeamLoadType = 101;
        public const int ERR7_InvalidStringID = 102;
        public const int ERR7_InvalidPatchType = 103;
        public const int ERR7_IncrementDoesNotExist = 104;
        public const int ERR7_InvalidLoadCaseType = 105;
        public const int ERR7_InvalidFreedomCaseType = 106;
        public const int ERR7_InvalidHarmonicLoadType = 107;
        public const int ERR7_InvalidTemperatureType = 108;
        public const int ERR7_InvalidPatchTypeForPlate = 109;
        public const int ERR7_InvalidAttributeType = 110;
        public const int ERR7_MaterialNotAnisotropic = 111;
        public const int ERR7_InvalidMatrixType = 112;
        public const int ERR7_MaterialNotUserDefined = 113;
        public const int ERR7_InvalidIndex = 114;
        public const int ERR7_InvalidContactType = 115;
        public const int ERR7_InvalidContactSubType = 116;
        public const int ERR7_InvalidCutoffType = 117;
        public const int ERR7_ResultQuantityNotAvailable = 118;
        public const int ERR7_YieldNotMCDP = 119;
        public const int ERR7_CombinationDoesNotExist = 120;
        public const int ERR7_InvalidSeismicCase = 121;
        public const int ERR7_InvalidImportExportMode = 122;
        public const int ERR7_CannotReadImportFile = 123;
        public const int ERR7_InvalidAnsysImportFormat = 124;
        public const int ERR7_InvalidAnsysArrayStatus = 125;
        public const int ERR7_CannotWriteExportFile = 126;
        public const int ERR7_InvalidAnsysExportFormat = 127;
        public const int ERR7_InvalidAnsysEndReleaseOption = 128;
        public const int ERR7_InvalidAnsysExportUnits = 129;
        public const int ERR7_InvalidSt7ExportFormat = 130;
        public const int ERR7_InvalidUVPos = 131;
        public const int ERR7_InvalidResponseType = 132;
        public const int ERR7_InvalidLayoutID = 133;
        public const int ERR7_InvalidPlateSurface = 134;
        public const int ERR7_MeshingErrors = 135;
        public const int ERR7_InvalidTolerance = 136;
        public const int ERR7_InvalidTaperAxis = 137;
        public const int ERR7_InvalidTaperType = 138;
        public const int ERR7_InvalidTaperRatio = 139;
        public const int ERR7_InvalidPositionType = 140;
        public const int ERR7_InvalidPreLoadType = 141;
        public const int ERR7_InvalidVertexType = 142;
        public const int ERR7_InvalidVertexMeshSize = 143;
        public const int ERR7_InvalidGeometryEdgeType = 144;
        public const int ERR7_InvalidPropertyNumber = 145;
        public const int ERR7_InvalidFaceSurface = 146;
        public const int ERR7_InvalidModType = 147;
        public const int ERR7_MaterialNotSoil = 148;
        public const int ERR7_MaterialNotFluid = 149;
        public const int ERR7_SoilTypeNotDC = 150;
        public const int ERR7_SoilTypeNotCC = 151;
        public const int ERR7_MaterialNotLaminate = 152;
        public const int ERR7_InvalidLaminateID = 153;
        public const int ERR7_LaminateNameAlreadyExists = 154;
        public const int ERR7_LaminateIDAlreadyExists = 155;
        public const int ERR7_PlyDoesNotExist = 156;
        public const int ERR7_ExceededMaxNumPlies = 157;
        public const int ERR7_LayoutIDAlreadyExists = 158;
        public const int ERR7_InvalidNumModes = 159;
        public const int ERR7_InvalidLTAMethod = 160;
        public const int ERR7_InvalidLTASolutionType = 161;
        public const int ERR7_ExceededMaxNumStages = 162;
        public const int ERR7_StageDoesNotExist = 163;
        public const int ERR7_ExceededMaxNumSpectralCases = 164;
        public const int ERR7_InvalidSpectralCase = 165;
        public const int ERR7_InvalidSpectrumType = 166;
        public const int ERR7_InvalidResultsSign = 167;
        public const int ERR7_InvalidPositionTableAxis = 168;
        public const int ERR7_InvalidInitialConditionsType = 169;
        public const int ERR7_ExceededMaxNumNodeHistory = 170;
        public const int ERR7_NodeHistoryDoesNotExist = 171;
        public const int ERR7_InvalidTransientTempType = 172;
        public const int ERR7_InvalidTimeUnit = 173;
        public const int ERR7_InvalidLoadPath = 174;
        public const int ERR7_InvalidTempDependenceType = 175;
        public const int ERR7_InvalidTrigType = 176;
        public const int ERR7_InvalidUserEquation = 177;
        public const int ERR7_InvalidCreepID = 178;
        public const int ERR7_CreepIDAlreadyExists = 179;
        public const int ERR7_InvalidCreepLaw = 180;
        public const int ERR7_InvalidCreepHardeningLaw = 181;
        public const int ERR7_InvalidCreepViscoChainRow = 182;
        public const int ERR7_InvalidCreepFunctionType = 183;
        public const int ERR7_InvalidCreepShrinkageType = 184;
        public const int ERR7_InvalidTableRow = 185;
        public const int ERR7_ExceededMaxNumRows = 186;
        public const int ERR7_InvalidLoadPathTemplateID = 187;
        public const int ERR7_LoadPathTemplateIDAlreadyExists = 188;
        public const int ERR7_InvalidLoadPathLane = 189;
        public const int ERR7_ExceededMaxNumLoadPathTemplates = 190;
        public const int ERR7_ExceededMaxNumLoadPathVehicles = 191;
        public const int ERR7_InvalidLoadPathVehicle = 192;
        public const int ERR7_InvalidMobilityType = 193;
        public const int ERR7_InvalidAxisSystem = 194;
        public const int ERR7_InvalidLoadPathID = 195;
        public const int ERR7_LoadPathIDAlreadyExists = 196;
        public const int ERR7_InvalidPathDefinition = 197;
        public const int ERR7_InvalidLoadPathShape = 198;
        public const int ERR7_InvalidLoadPathSurface = 199;
        public const int ERR7_InvalidNumPathDivs = 200;
        public const int ERR7_InvalidGeometryCavityLoop = 201;
        public const int ERR7_InvalidLimitEnvelope = 202;
        public const int ERR7_ExceededMaxNumLimitEnvelopes = 203;
        public const int ERR7_InvalidCombEnvelope = 204;
        public const int ERR7_ExceededMaxNumCombEnvelopes = 205;
        public const int ERR7_InvalidFactorsEnvelope = 206;
        public const int ERR7_ExceededMaxNumFactorsEnvelopes = 207;
        public const int ERR7_InvalidLimitEnvelopeType = 208;
        public const int ERR7_InvalidCombEnvelopeType = 209;
        public const int ERR7_InvalidFactorsEnvelopeType = 210;
        public const int ERR7_InvalidCombEnvelopeAccType = 211;
        public const int ERR7_InvalidEnvelopeSet = 212;
        public const int ERR7_ExceededMaxNumEnvelopeSets = 213;
        public const int ERR7_InvalidEnvelopeSetType = 214;
        public const int ERR7_InvalidCombResFile = 215;
        public const int ERR7_ExceededMaxNumCombResFiles = 216;
        public const int ERR7_CannotCombResFiles = 217;
        public const int ERR7_InvalidStartEndTimes = 218;
        public const int ERR7_InvalidNumSteps = 219;
        public const int ERR7_InvalidLibraryPath = 220;
        public const int ERR7_InvalidLibraryType = 221;
        public const int ERR7_InvalidLibraryID = 222;
        public const int ERR7_InvalidLibraryName = 223;
        public const int ERR7_InvalidLibraryItemID = 224;
        public const int ERR7_InvalidLibraryItemName = 225;
        public const int ERR7_InvalidDisplayOptionsPath = 226;
        public const int ERR7_InvalidSolverPath = 227;
        public const int ERR7_InvalidCementHardeningType = 228;
        public const int ERR7_NoPlateElements = 229;
        public const int ERR7_CannotMakeBXS = 230;
        public const int ERR7_CannotCalculateBXSData = 231;
        public const int ERR7_InvalidSurfaceMeshTargetType = 232;
        public const int ERR7_InvalidModalNodeReactType = 233;
        public const int ERR7_InvalidAxis = 234;
        public const int ERR7_InvalidBeamAxisType = 235;
        public const int ERR7_InvalidStaadCountryCodeOption = 236;
        public const int ERR7_InvalidGeometryFormatProtocol = 237;
        public const int ERR7_InvalidDXFBeamOption = 238;
        public const int ERR7_InvalidDXFPlateOption = 239;
        public const int ERR7_InvalidLoadPathLaneFactorType = 240;
        public const int ERR7_InvalidLoadPathVehicleInstance = 241;
        public const int ERR7_InvalidNumBeamStations = 242;
        public const int ERR7_ResFileUnsupportedType = 243;
        public const int ERR7_ResFileAlreadyOpen = 244;
        public const int ERR7_ResFileInvalidNumCases = 245;
        public const int ERR7_ResFileNotOpen = 246;
        public const int ERR7_ResFileInvalidCase = 247;
        public const int ERR7_ResFileDoesNotHaveEntity = 248;
        public const int ERR7_ResFileInvalidQuantity = 249;
        public const int ERR7_ResFileQuantityNotExist = 250;
        public const int ERR7_ResFileCantSave = 251;
        public const int ERR7_ResFileCantClearQuantity = 252;
        public const int ERR7_ResFileContainsNoElements = 253;
        public const int ERR7_ResFileContainsNoNodes = 254;
        public const int ERR7_InvalidName = 255;
        public const int ERR7_ResFileAssociationNotAllowed = 256;
        public const int ERR7_ResFileIncompatibleQuantity = 257;
        public const int ERR7_CannotEditSolverFiles = 258;
        public const int ERR7_CannotOpenResultFile = 259;
        public const int ERR7_CouldNotShowModelWindow = 260;
        public const int ERR7_ModelWindowWasNotShowing = 261;
        public const int ERR7_CantDoWithModalWindows = 262;
        public const int ERR7_InvalidSelectionEndEdgeFace = 263;
        public const int ERR7_CouldNotCreateModelWindow = 264;
        public const int ERR7_ModelWindowWasNotCreated = 265;
        public const int ERR7_InvalidImageType = 266;
        public const int ERR7_InvalidImageDimensions = 267;
        public const int ERR7_ErrorCreatingImage = 268;
        public const int ERR7_CannotSaveImageFile = 269;
        public const int ERR7_InvalidWindowDimensions = 270;
        public const int ERR7_InvalidResultQuantity = 271;
        public const int ERR7_InvalidResultSubQuantity = 272;
        public const int ERR7_InvalidComponent = 273;
        public const int ERR7_ResultIsNotAvailable = 274;
        public const int ERR7_InvalidUCSIndex = 275;
        public const int ERR7_InvalidDiagramAxis = 276;
        public const int ERR7_InvalidVectorComponents = 277;
        public const int ERR7_TableTypeIsNotTimeBased = 278;
        public const int ERR7_InvalidTableID = 279;
        public const int ERR7_LinkNotMasterSlave = 280;
        public const int ERR7_LinkNotSectorSymmetry = 281;
        public const int ERR7_LinkNotCoupling = 282;
        public const int ERR7_LinkNotPinned = 283;
        public const int ERR7_LinkNotRigid = 284;
        public const int ERR7_LinkNotShrink = 285;
        public const int ERR7_LinkNotTwoPoint = 286;
        public const int ERR7_LinkNotAttachment = 287;
        public const int ERR7_LinkNotMultiPoint = 288;
        public const int ERR7_InvalidCoupleType = 289;
        public const int ERR7_InvalidRigidPlane = 290;
        public const int ERR7_InvalidMultiPointType = 291;
        public const int ERR7_InvalidMultiPointLink = 292;
        public const int ERR7_InvalidAttachmentType = 293;
        public const int ERR7_ExceededMaxNumColumns = 294;
        public const int ERR7_CouldNotDestroyModelWindow = 295;
        public const int ERR7_CannotSetWindowParent = 296;
        public const int ERR7_InvalidLoadCaseFilePath = 297;
        public const int ERR7_InvalidStaadLengthUnit = 298;
        public const int ERR7_InvalidStaadForceUnit = 299;
        public const int ERR7_InvalidDuplicateFaceType = 300;
        public const int ERR7_InvalidNodeCoordinateKeepType = 301;
        public const int ERR7_CommentDoesNotExist = 302;
        public const int ERR7_InvalidFilePath = 303;
        public const int ERR7_InvalidContactYieldType = 304;
        public const int ERR7_InvalidNumMeshingLoops = 305;
        public const int ERR7_InvalidMeshPositionOnUCS = 306;
        public const int ERR7_InvalidK0Expression = 307;
        public const int ERR7_InvalidK1Expression = 308;
        public const int ERR7_InvalidNumCopies = 309;
        public const int ERR7_InvalidCurvedPipesAsOption = 310;
        public const int ERR7_InvalidResOptsRotationUnit = 311;
        public const int ERR7_RayleighNotApplicable = 312;
        public const int ERR7_InvalidAttributeSetting = 313;
        public const int ERR7_InvalidToolOptsZipOptions = 314;
        public const int ERR7_InvalidToolOptsSubdivideOptions = 315;
        public const int ERR7_InvalidToolOptsCopyOptions = 316;
        public const int ERR7_InvalidBackgroundMode = 317;
        public const int ERR7_InvalidAttachPartsParams = 318;
        public const int ERR7_InvalidDrawParameters = 319;
        public const int ERR7_FilesStillOpen = 320;
        public const int ERR7_SolverStillRunning = 321;
        public const int ERR7_InvalidFaceFromBeamPolygonParameters = 322;
        public const int ERR7_InvalidResOptsStrainUnit = 323;
        public const int ERR7_FunctionNotSupported = 324;
        public const int ERR7_SoilTypeNotMC = 325;
        public const int ERR7_SoilTypeNotDP = 326;
        public const int ERR7_TooManyAnimations = 327;
        public const int ERR7_InvalidAnimationFile = 328;
        public const int ERR7_InvalidAnimationMode = 329;
        public const int ERR7_InsufficientFrames = 330;
        public const int ERR7_AnimationDimensionsTooSmall = 331;
        public const int ERR7_AnimationDimensionsTooLarge = 332;
        public const int ERR7_ReducedAnimation = 333;
        public const int ERR7_InvalidAnimationType = 334;
        public const int ERR7_InvalidEntityID = 335;
        public const int ERR7_CouldNotSaveAnimationFile = 336;
        public const int ERR7_AnimationHandleOutOfRange = 337;
        public const int ERR7_AnimationNotRunning = 338;
        public const int ERR7_SoilTypeNotLS = 339;
        public const int ERR7_InvalidPlane = 340;
        public const int ERR7_InvalidAlphaTempType = 341;
        public const int ERR7_InvalidGravityDirection = 342;
        public const int ERR7_InvalidAttachmentDirection = 343;
        public const int ERR7_InvalidHardeningType = 344;
        public const int ERR7_ResultCaseNotInertiaRelief = 345;
        public const int ERR7_InvalidNumLayers = 346;
        public const int ERR7_PlateDoesNotHaveLayers = 347;
        public const int ERR7_OperationFailed = 348;
        public const int ERR7_InvalidEntityContourFileType = 349;
        public const int ERR7_InvalidBrickIntegrationPoints = 350;
        public const int ERR7_InvalidDirection = 351;
        public const int ERR7_InvalidAttachConnectionType = 352;
        public const int ERR7_CannotSaveIniFile = 353;
        public const int ERR7_InvalidDivisionParameters = 354;
        public const int ERR7_InvalidContourIndex = 355;
        public const int ERR7_InvalidProjectFlag = 356;
        public const int ERR7_InvalidSegmentsPerCircle = 357;
        public const int ERR7_InvalidArcLength = 358;
        public const int ERR7_InvalidDivisionTargets = 359;
        public const int ERR7_InvalidProcessingMode = 360;
        public const int ERR7_InvalidDigits = 361;
        public const int ERR7_InvalidNumericStyle = 362;
        public const int ERR7_InvalidExponentFormat = 363;
        public const int ERR7_InvalidExportParameters = 364;
        public const int ERR7_InsituCalculationFailed = 365;
        public const int ERR7_ModelMixesAxiNonAxi = 366;
        public const int ERR7_InvalidInsituRunMode = 367;
        public const int ERR7_InvalidGradeType = 368;
        public const int ERR7_InvalidGradeRatio = 369;
        public const int ERR7_InvalidSplitData = 370;
        public const int ERR7_CannotMorphEdges = 371;
        public const int ERR7_TJunctionsFound = 372;
        public const int ERR7_FreeEdgesFound = 373;
        public const int ERR7_InvalidSTLFileFormat = 374;
        public const int ERR7_InvalidSTLGroupingOption = 375;
        public const int ERR7_InvalidSTLBeamOption = 376;
        public const int ERR7_InvalidSTLPlateOption = 377;
        public const int ERR7_InvalidNodeExtrudeTarget = 378;
        public const int ERR7_InvalidBeamExtrudeTarget = 379;
        public const int ERR7_InvalidLinkTarget = 380;
        public const int ERR7_InvalidSourceAction = 381;
        public const int ERR7_InvalidLinePoints = 382;
        public const int ERR7_InvalidLineID = 383;
        public const int ERR7_InvalidPlanePoints = 384;
        public const int ERR7_InvalidPlaneID = 385;
        public const int ERR7_InvalidSortMethod = 386;
        public const int ERR7_InvalidDirectionVector = 387;
        public const int ERR7_InvalidRCLayers = 388;
        public const int ERR7_InvalidConnectionType = 389;
        public const int ERR7_InvalidQuadraticAsOption = 390;
        public const int ERR7_InvalidGeometryAsOption = 391;
        public const int ERR7_InvalidSplitRatio = 392;
        public const int ERR7_InvalidLength = 393;
        public const int ERR7_InvalidEdgeTolerance = 394;
        public const int ERR7_InvalidRadius = 395;
        public const int ERR7_IncompatibleSections = 396;
        public const int ERR7_UCSMustBeDifferent = 397;
        public const int ERR7_InvalidNumCutFaces = 398;
        public const int ERR7_InvalidNumRepeats = 399;
        public const int ERR7_InvalidP1P2 = 400;
        public const int ERR7_InvalidP1P2P3 = 401;
        public const int ERR7_InvalidP1P2P3P4 = 402;
        public const int ERR7_IntersectionNotFound = 403;
        public const int ERR7_CantGenerateFillet = 404;
        public const int ERR7_InvalidR1R2 = 405;
        public const int ERR7_InvalidR2 = 406;
        public const int ERR7_InvalidPLTarget = 407;
        public const int ERR7_InvalidScaleAbout = 408;
        public const int ERR7_InvalidProjectionDirection = 409;
        public const int ERR7_InvalidCollectionID = 410;
        public const int ERR7_InvalidDivisions = 411;
        public const int ERR7_InvalidLineDefinition = 412;
        public const int ERR7_InvalidOriginMethod = 413;
        public const int ERR7_InvalidInfluenceFile = 414;
        public const int ERR7_InvalidResponseVariable = 415;
        public const int ERR7_NoMultiVariableInfluenceCases = 416;
        public const int ERR7_InvalidMultiVariableCaseID = 417;
        public const int ERR7_InvalidMultiVariableType = 418;
        public const int ERR7_NoInfluenceCombinationsDefined = 419;
        public const int ERR7_NothingSelected = 420;
        public const int ERR7_InvalidPasteOption = 421;
        public const int ERR7_InvalidResultCase = 422;
        public const int ERR7_InvalidEntitySet = 423;
        public const int ERR7_InvalidResOptsReactionLinkGNL = 424;
        public const int ERR7_FileIsProtected = 425;
        public const int ERR7_InvalidHRAMode = 426;
        public const int ERR7_InvalidBGLData = 427;
        public const int ERR7_InvalidWindowMode = 428;
        public const int ERR7_UnexpectedSolverTermination = 429;
        public const int ERR7_InvalidReferenceNode = 430;
        public const int ERR7_InvalidDetachMode = 431;
        public const int ERR7_InvalidResOptsBaseMode = 432;
        public const int ERR7_InvalidMarkerType = 433;
        public const int ERR7_InvalidMarkerStyle = 434;
        public const int ERR7_InvalidMarkerLineThickness = 435;
        public const int ERR7_InvalidMarkerSize = 436;
        public const int ERR7_MarkerNotFound = 437;
        public const int ERR7_PseudoTimeNotDefined = 438;
        public const int ERR7_EquationDoesNotExist = 439;
        public const int ERR7_InvalidOption = 440;
        public const int ERR7_InvalidIterationNumber = 441;
        public const int ERR7_InvalidAveragingOption = 442;
        public const int ERR7_InvalidContourFileIndex = 443;
        public const int ERR7_ContourFileNotLoaded = 444;
        public const int ERR7_NoLoadPathsFound = 445;
        public const int ERR7_NoElementsOnLoadPaths = 446;
        public const int ERR7_NoResponsesFound = 447;
        public const int ERR7_NoActiveResponseVariables = 448;
        public const int ERR7_NoSoilElementsFound = 449;
        public const int ERR7_OperationUserTerminated = 450;
        public const int ERR7_InvalidDefaultsMode = 451;
        public const int ERR7_InvalidFontName = 452;
        public const int ERR7_InvalidBaseExcitationType = 453;
        public const int ERR7_SectionNotBGL = 454;
        public const int ERR7_CavityFluidNotIdealGas = 455;
        public const int ERR7_CavityFluidNotConstBulk = 456;
        public const int ERR7_UnknownFileType = 457;
        public const int ERR7_FunctionalityNotAvailable = 458;
        public const int ERR7_DynamicsSolverModuleNotLicensed = 459;
        public const int ERR7_NonlinearSolverModuleNotLicensed = 460;
        public const int ERR7_MovingLoadModuleNotLicensed = 461;
        public const int ERR7_AutoMesherModuleNotLicensed = 462;
        public const int ERR7_RCModuleNotLicensed = 463;
        public const int ERR7_CompositesModuleNotLicensed = 464;

        // Solver Error Codes
        public const int SE_NoLoadCaseSelected = 1001;
        public const int SE_IncompatibleRestartFile = 1002;
        public const int SE_ElementUsesInvalidProperty = 1003;
        public const int SE_InvalidElement = 1004;
        public const int SE_NeedNonlinearHeatSolver = 1005;
        public const int SE_TableNotFound = 1006;
        public const int SE_InvalidRestartFile = 1007;
        public const int SE_InvalidInitialFile = 1008;
        public const int SE_InvalidSolverResultFile = 1009;
        public const int SE_InvalidLink = 1010;
        public const int SE_InvalidPlateCohesionValue = 1011;
        public const int SE_InvalidBrickCohesionValue = 1012;
        public const int SE_NonlinearSolverRequired = 1013;
        public const int SE_NoLoadTablesDefined = 1014;
        public const int SE_NoVelocityDataInInitialFile = 1015;
        public const int SE_NoModesIncluded = 1016;
        public const int SE_InvalidTimeStep = 1017;
        public const int SE_LoadIncrementsNotDefined = 1018;
        public const int SE_NoFreedomCaseInIncrements = 1019;
        public const int SE_InvalidInitialTemperatureFile = 1020;
        public const int SE_InvalidFrequencyRange = 1021;
        public const int SE_ModelMixesAxiNonAxi = 1022;
        public const int SE_CompositesModuleNotLicensed = 1023;
        public const int SE_CannotFindSolver = 1024;
        public const int SE_UnknownException = 1025;
        public const int SE_DuplicateLinks = 1026;
        public const int SE_CannotAppendToFile = 1027;
        public const int SE_CannotOverwriteFile = 1028;
        public const int SE_CannotWriteToResultFile = 1029;
        public const int SE_CannotWriteToLogFile = 1030;
        public const int SE_CannotReadRestartFile = 1031;
        public const int SE_InitialConditionsNotValid = 1032;
        public const int SE_InvalidRayleighFactors = 1033;
        public const int SE_SpectralExcitationsAllZero = 1034;
        public const int SE_ShearPanelMustBeQuad4 = 1035;
        public const int SE_SingularPlateMatrix = 1036;
        public const int SE_SingularBrickMatrix = 1037;
        public const int SE_NoBeamProperties = 1038;
        public const int SE_NoPlateProperties = 1039;
        public const int SE_NoBrickProperties = 1040;
        public const int SE_MoreLoadIncrementsNeeded = 1041;
        public const int SE_RubberRequiresGNL = 1042;
        public const int SE_NoFreedomCaseSelected = 1043;
        public const int SE_SpectralCasesNotDefined = 1044;
        public const int SE_NoSpectralResultsSelected = 1045;
        public const int SE_SpectralLoadExcitationsAllZero = 1046;
        public const int SE_SpectralBaseExcitationsAllZero = 1047;
        public const int SE_NoTimeStepsSaved = 1048;
        public const int SE_InvalidDirectionVector = 1049;
        public const int SE_HarmonicFactorsAllZero = 1050;
        public const int SE_TemperatureDependenceCaseNotSet = 1051;
        public const int SE_ZeroLengthRigidLinkGenerated = 1052;
        public const int SE_InvalidStringGroupDefinition = 1053;
        public const int SE_InvalidPreTensionOnString = 1054;
        public const int SE_StringOrderHasChanged = 1055;
        public const int SE_BadTaperData = 1056;
        public const int SE_TaperedPlasticBeams = 1057;
        public const int SE_NoMovingLoadPathsInCases = 1058;
        public const int SE_NoResponseVariablesDefined = 1059;
        public const int SE_InvalidPlateVariableRequested = 1060;
        public const int SE_InvalidGravityCase = 1061;
        public const int SE_InvalidUserPlateCreepDefinition = 1062;
        public const int SE_InvalidUserBrickCreepDefinition = 1063;
        public const int SE_InvalidPlateShrinkageDefinition = 1064;
        public const int SE_InvalidBrickShrinkageDefinition = 1065;
        public const int SE_InvalidLaminateID = 1066;
        public const int SE_CannotReadWriteScratchPath = 1067;
        public const int SE_CannotConvertAttachmentLink = 1068;
        public const int SE_SoilRequiresMNL = 1069;
        public const int SE_ActiveStageHasNoIncrements = 1070;
        public const int SE_ConcreteCreepMNL = 1071;
        public const int SE_CannotConvertInterpMultiPoint = 1072;
        public const int SE_MissingInsituStress = 1073;
        public const int SE_InvalidMaterialNonlinearString = 1074;
        public const int SE_TensileInsituPlateStress = 1075;
        public const int SE_TensileInsituBrickStress = 1076;
        public const int SE_IncompatibleRestartUnits = 1077;
        public const int SE_CreepTimeTooShort = 1078;
        public const int SE_InvalidElements = 1079;
        public const int SE_InsufficientRestartFileSteps = 1080;
        public const int SE_NeedNodeTempNTASolver = 1081;
        public const int SE_SingleShotRestartFile = 1082;
        public const int SE_SkylineUsesBadSort = 1083;
        public const int SE_StagedSolutionFileNotFound = 1084;
        public const int SE_NeedTemperatureTables = 1085;
        public const int SE_AttachmentsInWrongGroup = 1086;
        public const int SE_StagingHasChanged = 1087;
        public const int SE_NoNodes = 1088;
        public const int SE_CQCRequiresDamping = 1089;
        public const int SE_HaveLinearCables = 1090;
        public const int SE_CableRequiresGNL = 1091;
        public const int SE_BeamRequiresPoisson = 1092;
        public const int SE_BeamPoissonOutOfRange = 1093;
        public const int SE_CableRequiresNonlinearSolver = 1094;
        public const int SE_InitialSolutionFileIsBad = 1095;
        public const int SE_BeamPropertiesMayHaveChanged = 1096;
        public const int SE_NeedElementNodeForce = 1097;
        public const int SE_LinksHaveNoFreedomCase = 1098;
        public const int SE_InvalidCavityFluidDefinition = 1099;
        public const int SE_InactiveCavityControlCase = 1100;
        public const int SE_MovingLoadModuleNotLicensed = 1101;

        // Solver Termination Error Codes
        public const int ST_NoError = 0;
        public const int ST_Abnormal = -1;
        public const int ST_UserStop = -2;
        public const int ST_Internal = -3;
        public const int ST_NoDisk = -4;
        public const int ST_NoRam = -5;
        public const int ST_OpenLog = -6;
        public const int ST_CreateLog = -7;
        public const int ST_WriteLog = -8;
        public const int ST_MemError = -9;
        public const int ST_Scratch = -10;
        public const int ST_NoLicence = -11;

        // Other Constants
        public const int kMaxPlateResult = 1024;
        public const int kMaxBrickResult = 1024;
        public const int kMaxBeamRelease = 12;
        public const int kMaxDisp = 6;

        // UCS
        public const int kMaxUCSDoubles = 10;

        // Solvers
        public const int stLinearStatic = 1;
        public const int stLinearBuckling = 2;
        public const int stNonlinearStatic = 3;
        public const int stNaturalFrequency = 4;
        public const int stHarmonicResponse = 5;
        public const int stSpectralResponse = 6;
        public const int stLinearTransientDynamic = 7;
        public const int stNonlinearTransientDynamic = 8;
        public const int stSteadyHeat = 9;
        public const int stTransientHeat = 10;
        public const int stLoadInfluence = 11;
        public const int stQuasiStatic = 12;

        // Solver Modes
        public const int smNone = 0;
        public const int smFreqSolution = 1;
        public const int smTimeSolution = 2;
        public const int smTimeMode = 3;

        // Solver Run Modes
        public const int smNormalRun = 1;
        public const int smProgressRun = 2;
        public const int smBackgroundRun = 3;
        public const int smNormalCloseRun = 4;

        // Result File Validation Bits
        public const int ibResFileNotFound = 1;
        public const int ibResFileCannotOpen = 2;
        public const int ibResFileNotResultFile = 3;
        public const int ibResFileOldVersion = 4;
        public const int ibResFileFutureVersion = 5;
        public const int ibResFileWrongNumNodes = 6;
        public const int ibResFileWrongNumBeams = 7;
        public const int ibResFileWrongNumPlates = 8;
        public const int ibResFileWrongNumBricks = 9;
        public const int ibResFileWrongModelID = 10;
        public const int ibResFileUnknownError = 11;
        public const int ibResFileIsCombination = 12;
        public const int ibResFileIsMultiFile = 13;
        public const int ibResFileTruncated = 14;

        // Import/Export Modes
        public const int ieQuietRun = 0;
        public const int ieProgressRun = 1;

        // NASTRAN
        public const int ipNASTRANImportUnits = 0;
        public const int ipNASTRANFreedomCase = 0;
        public const int ipNASTRANLoadCaseNSMass = 1;
        public const int ipNASTRANSolver = 2;
        public const int ipNASTRANExportUnits = 3;
        public const int ipNASTRANBeamStressSections = 4;
        public const int ipNASTRANBeamSectionGeometry = 5;
        public const int ipNASTRANExportHeatTransfer = 6;
        public const int ipNASTRANExportNSMass = 7;
        public const int ipNASTRANExportUnusedProps = 8;
        public const int ipNASTRANTemperatureCase = 9;
        public const int ipNASTRANPreLoadCase = 10;
        public const int ipNASTRANNInc = 11;
        public const int ipNASTRANMaxIter = 12;
        public const int ipNASTRANDoEPSU = 13;
        public const int ipNASTRANDoEPSP = 14;
        public const int ipNASTRANDoEPSW = 15;
        public const int ipNASTRANExportPyramid = 16;
        public const int ipNASTRANExportQuad4 = 17;
        public const int ipNASTRANExportZeroFields = 0;
        public const int ipNASTRANEPSU = 1;
        public const int ipNASTRANEPSP = 2;
        public const int ipNASTRANEPSW = 3;
        public const int ieNASTRANSolverLSA = 0;
        public const int ieNASTRANSolverNFA = 1;
        public const int ieNASTRANSolverLBA = 2;
        public const int ieNASTRANSolverNLA = 3;
        public const int ieNASTRANExportGeometryProps = 0;
        public const int ieNASTRANExportPropsOnly = 1;
        public const int ieNASTRANExportPyramidAsHexa = 0;
        public const int ieNASTRANExportPyramidAsPyram = 1;
        public const int ieNASTRANExportCQUAD4 = 0;
        public const int ieNASTRANExportCQUADR = 1;
        public const int usNASTRAN_kg_N_m = 0;
        public const int usNASTRAN_T_N_mm = 1;
        public const int usNASTRAN_sl_lbf_ft = 2;
        public const int usNASTRAN_lbm_lbf_in = 3;
        public const int usNASTRAN_sl_lbf_in = 4;
        public const int usNASTRAN_None = 5;

        // ANSYS
        public const int ipANSYSImportFormat = 0;
        public const int ipANSYSArrayParameters = 1;
        public const int ipANSYSImportLoadCaseFiles = 2;
        public const int ipANSYSImportIGESEntities = 3;
        public const int ipANSYSFixElementConnectivity = 4;
        public const int ipANSYSRemoveDuplicateProps = 5;
        public const int ipANSYSExportFormat = 0;
        public const int ipANSYSFreedomCase = 1;
        public const int ipANSYSLoadCase = 2;
        public const int ipANSYSUnits = 3;
        public const int ipANSYSEndRelease = 4;
        public const int ipANSYSExportNonlinearMat = 5;
        public const int ipANSYSExportHeatTransfer = 6;
        public const int ipANSYSExportPreLoadNSMass = 7;
        public const int ipANSYSExportTetraOption = 8;
        public const int ipANSYSExportQuad8Option = 9;
        public const int ieANSYSBatchImport = 0;
        public const int ieANSYSCDBImport = 1;
        public const int ieANSYSBatchCDBImport = 2;
        public const int ieANSYSBatch1Export = 0;
        public const int ieANSYSBatch3Export = 1;
        public const int ieANSYSBlockedCDBExport = 2;
        public const int ieANSYSUnblockedCDBExport = 3;
        public const int ieANSYSArrayOverwrite = 0;
        public const int ieANSYSArrayIgnore = 1;
        public const int ieANSYSArrayPrompt = 2;
        public const int ieANSYSEndReleaseFixed = 0;
        public const int ieANSYSEndReleaseFull = 1;
        public const int usANSYS_None = 0;
        public const int usANSYS_kg_m_C = 1;
        public const int usANSYS_g_cm_C = 2;
        public const int usANSYS_T_mm_C = 3;
        public const int usANSYS_sl_ft_F = 4;
        public const int usANSYS_lbm_in_F = 5;

        // STAAD
        public const int ipSTAADCountryType = 0;
        public const int ipSTAADIncludeSectionLibrary = 1;
        public const int ipSTAADStripUnderscore = 2;
        public const int ipSTAADStripSectionSpaces = 3;
        public const int ipSTAADStripCaseQualifiers = 4;
        public const int ipSTAADLengthUnit = 5;
        public const int ipSTAADForceUnit = 6;
        public const int ieSTAADAmericanCode = 0;
        public const int ieSTAADAustralianCode = 1;
        public const int ieSTAADBritishCode = 2;
        public const int luSTAADInch = 0;
        public const int luSTAADFoot = 1;
        public const int luSTAADCentimetre = 2;
        public const int luSTAADMetre = 3;
        public const int luSTAADMillimetre = 4;
        public const int luSTAADDecimetre = 5;
        public const int luSTAADKilometre = 6;
        public const int fuSTAADKip = 0;
        public const int fuSTAADPoundForce = 1;
        public const int fuSTAADKilogramForce = 2;
        public const int fuSTAADMegatonneForce = 3;
        public const int fuSTAADNewton = 4;
        public const int fuSTAADKilonewton = 5;
        public const int fuSTAADMeganewton = 6;
        public const int fuSTAADDecanewton = 7;

        // SAP2000
        public const int ipSAP2000DecimalSeparator = 0;
        public const int ipSAP2000ThousandSeparator = 1;
        public const int ipSAP2000MergeDuplicateFreedomSets = 2;
        public const int ieSAP2000Period = 0;
        public const int ieSAP2000Comma = 1;
        public const int ieSAP2000Space = 2;
        public const int ieSAP2000None = 3;

        // ST7
        public const int ipSt7ImportRemoveCases = 0;
        public const int ipSt7ImportMatchUCSNames = 1;
        public const int ieSt7ExportCurrent = 0;
        public const int ieSt7Export106 = 1;
        public const int ieSt7Export21x = 2;
        public const int ieSt7Export22x = 3;
        public const int ieSt7Export23x = 4;
        public const int ieSt7Export24x = 5;

        // STL
        public const int ipSTLImportProperty = 0;
        public const int ipSTLImportLengthUnit = 1;
        public const int ipSTLExportFormat = 0;
        public const int ipSTLExportGrouping = 1;
        public const int ipSTLExportBeams = 2;
        public const int ipSTLExportPlates = 3;
        public const int ipSTLExportBricks = 4;
        public const int ipSTLExportGeometryFaces = 5;
        public const int ipSTLExportBeamsAs = 6;
        public const int ipSTLExportPlatesAs = 7;
        public const int ipSTLExportBeamOffsets = 8;
        public const int ipSTLExportPlateOffsets = 9;
        public const int ipSTLExportInternalBrickFaces = 10;
        public const int luSTLNone = 0;
        public const int luSTLMillimetre = 1;
        public const int luSTLCentimetre = 2;
        public const int luSTLMetre = 3;
        public const int luSTLInch = 4;
        public const int luSTLFoot = 5;
        public const int ieSTLText = 0;
        public const int ieSTLBinary = 1;
        public const int ieSTLGroupByNone = 0;
        public const int ieSTLGroupByEntityType = 1;
        public const int ieSTLGroupByGroups = 2;

        // GEOMETRY
        public const int ipGeomImportProperty = 0;
        public const int ipGeomImportCurvesToBeams = 1;
        public const int ipGeomImportGroupsAs = 2;
        public const int ipGeomImportColourAsProperty = 3;
        public const int ipGeomImportLengthUnit = 4;
        public const int ipGeomExportColour = 0;
        public const int ipGeomExportGroupsAsLevels = 1;
        public const int ipGeomExportFullGroupPath = 2;
        public const int ipGeomExportFormatProtocol = 3;
        public const int ipGeomExportCurve = 4;
        public const int ipGeomExportPeriodicFace = 5;
        public const int ipGeomExportKeepAnalytic = 6;
        public const int ipGeomImportTol = 0;
        public const int luGeomNone = -1;
        public const int luGeomInch = 0;
        public const int luGeomMillimetre = 1;
        public const int luGeomFoot = 2;
        public const int luGeomMile = 3;
        public const int luGeomMetre = 4;
        public const int luGeomKilometre = 5;
        public const int luGeomMil = 6;
        public const int luGeomMicron = 7;
        public const int luGeomCentimetre = 8;
        public const int luGeomMicroinch = 9;
        public const int luGeomUnspecified = 10;

        // IGES Formats
        public const int ieIGESBoundedSurface = 0;
        public const int ieIGESTrimmedParametricSurface = 1;
        public const int ieIGESOpenShell = 2;
        public const int ieIGESManifoldSolidBRep = 3;

        // STEP Protocols
        public const int ieSTEPConfigControlDesign = 0;
        public const int ieSTEPAutomotiveDesign = 1;

        // Geometry Export Format Options
        public const int ieGeomModelOnly = 0;
        public const int ieGeomParameterOnly = 1;
        public const int ieGeomModelPreferred = 2;
        public const int ieGeomParameterPreferred = 3;
        public const int ieGeomSeamOnlyAsRequired = 0;
        public const int ieGeomSplitOnFaceBoundary = 1;
        public const int ieGeomSplitIntoHalves = 2;
        public const int ieGeomColourNone = 0;
        public const int ieGeomFaceColour = 1;
        public const int ieGeomGroupColour = 2;
        public const int ieGeomPropertyColour = 3;

        // DXF Options
        public const int ipDXFImportFrozenLayers = 0;
        public const int ipDXFImportLayersAsGroups = 1;
        public const int ipDXFImportColoursAsProps = 2;
        public const int ipDXFImportPolylineAsPlates = 3;
        public const int ipDXFImportPolygonAsBricks = 4;
        public const int ipDXFImportSegmentsPerCircle = 5;
        public const int ipDXFImportUseSegmentsPerCircle = 6;
        public const int ipDXFImportLengthUnit = 7;
        public const int ipDXFImportProperty = 8;
        public const int ipDXFExportPlatesBricks3DFaces = 0;
        public const int ipDXFExportGroupsAsLayers = 1;
        public const int ipDXFExportPropColoursAsEntityColours = 2;
        public const int ipDXFExportBeamsAs = 3;
        public const int ipDXFExportPlatesAs = 4;
        public const int ipDXFExportBeamOffsets = 5;
        public const int ipDXFExportPlateOffsets = 6;
        public const int ipDXFExportInternalBrickFaces = 7;
        public const int ipDXFImportArcLength = 0;

        // DXF and STL
        public const int ieBeamAsLine = 0;
        public const int ieBeamAsSection = 1;
        public const int ieBeamAsSolid = 2;
        public const int iePlateAsSurface = 0;
        public const int iePlateAsSolid = 1;

        // Geometry Groups
        public const int ggNone = 0;
        public const int ggAuto = 1;
        public const int ggSubfigures = 2;
        public const int ggLevels = 3;
        public const int ggAssemblies = 1;
        public const int ggBlocks = 2;
        public const int ggLayers = 3;
        public const int ggBodies = 1;

        // BXS
        public const int ipBXSXBar = 0;
        public const int ipBXSYBar = 1;
        public const int ipBXSArea = 2;
        public const int ipBXSI11 = 3;
        public const int ipBXSI22 = 4;
        public const int ipBXSAngle = 5;
        public const int ipBXSZ11Plus = 6;
        public const int ipBXSZ11Minus = 7;
        public const int ipBXSZ22Plus = 8;
        public const int ipBXSZ22Minus = 9;
        public const int ipBXSS11 = 10;
        public const int ipBXSS22 = 11;
        public const int ipBXSr1 = 12;
        public const int ipBXSr2 = 13;
        public const int ipBXSSA1 = 14;
        public const int ipBXSSA2 = 15;
        public const int ipBXSSL1 = 16;
        public const int ipBXSSL2 = 17;
        public const int ipBXSIXX = 18;
        public const int ipBXSIYY = 19;
        public const int ipBXSIXY = 20;
        public const int ipBXSIxxL = 21;
        public const int ipBXSIyyL = 22;
        public const int ipBXSIxyL = 23;
        public const int ipBXSZxxPlus = 24;
        public const int ipBXSZxxMinus = 25;
        public const int ipBXSZyyPlus = 26;
        public const int ipBXSZyyMinus = 27;
        public const int ipBXSSxx = 28;
        public const int ipBXSSyy = 29;
        public const int ipBXSrx = 30;
        public const int ipBXSry = 31;
        public const int ipBXSJ = 32;
        public const int ipBXSIw = 33;
        public const int ipBXSrdA = 34;
        public const int ipBXSPC1 = 35;
        public const int ipBXSPC2 = 36;
        public const int ipBXSPCx = 37;
        public const int ipBXSPCy = 38;

        // BXS Loop Types
        public const int ltUnknown = 0;
        public const int ltOuter = 1;
        public const int ltInner = 2;

        // Geometry Clean - Doubles
        public const int ipGeometryFeatureLength = 0;
        public const int ipGeometryEdgeMergeAngle = 1;

        // Geometry Clean - Integers
        public const int ipGeometryFeatureType = 0;
        public const int ipGeometryActOnWholeModel = 1;
        public const int ipGeometryFreeEdgesOnly = 2;
        public const int ipGeometryDuplicateFaces = 3;
        public const int ipGeometryWithinGroups = 4;
        public const int dfLeaveAll = 0;
        public const int dfLeaveOne = 1;
        public const int dfLeaveNone = 2;

        // Mesh Clean - Doubles
        public const int ipMeshTolerance = 0;

        // Mesh Clean - Integers
        public const int ipMeshToleranceType = 0;
        public const int ipZipNodes = 1;
        public const int ipRemoveDuplicateElements = 2;
        public const int ipFixElementConnectivity = 3;
        public const int ipDeleteFreeNodes = 4;
        public const int ipDoBeams = 5;
        public const int ipDoPlates = 6;
        public const int ipDoBricks = 7;
        public const int ipDoLinks = 8;
        public const int ipZeroLengthLinks = 9;
        public const int ipZeroLengthBeams = 10;
        public const int ipNodeAttributeKeep = 11;
        public const int ipNodeCoordinates = 12;
        public const int ipAllowDifferentProps = 13;
        public const int ipActOnWholeModel = 14;
        public const int ipAllowDifferentGroups = 15;
        public const int ipPackStringGroupIDs = 16;
        public const int ipAllowDifferentBeamOffset = 17;
        public const int ipAllowDifferentPlateOffset = 18;

        // Attribute keep
        public const int naLower = 0;
        public const int naHigher = 1;
        public const int naAccumulate = 2;

        // Node coordinates
        public const int ncAverage = 0;
        public const int ncLowerNode = 1;
        public const int ncHigherNode = 2;
        public const int ncSelectedNode = 3;

        // Surface Meshing - Integers
        public const int ipSurfaceMeshMode = 0;
        public const int ipSurfaceMeshSizeMode = 1;
        public const int ipSurfaceMeshTargetNodes = 2;
        public const int ipSurfaceMeshTargetPropertyID = 3;
        public const int ipSurfaceMeshAutoCreateProperties = 4;
        public const int ipSurfaceMeshMinEdgesPerCircle = 5;
        public const int ipSurfaceMeshApplyTransitioning = 6;
        public const int ipSurfaceMeshAllowUserStop = 7;
        public const int ipSurfaceMeshConsiderNearVertex = 8;
        public const int ipSurfaceMeshSelectedFaces = 9;
        public const int ipSurfaceMeshApplySurfaceCurvature = 10;
        public const int mmAuto = 0;
        public const int mmCustom = 1;
        public const int smPercentage = 0;
        public const int smAbsolute = 1;

        // Surface Meshing - Doubles
        public const int ipSurfaceMeshSize = 0;
        public const int ipSurfaceMeshLengthRatio = 1;
        public const int ipSurfaceMeshMaximumIncrease = 2;
        public const int ipSurfaceMeshOnEdgesLongerThan = 3;

        // Tetra Meshing
        public const int ipTetraMeshSize = 0;
        public const int ipTetraMeshProperty = 1;
        public const int ipTetraMeshInc = 2;
        public const int ipTetraMesh10 = 3;
        public const int ipTetraMeshGroupsAsSolids = 4;
        public const int ipTetraMeshSmooth = 5;
        public const int ipTetraMeshAutoCreateProperties = 7;
        public const int ipTetraMeshDeletePlates = 8;
        public const int ipTetraMeshMultiBodyOption = 9;
        public const int ipTetraMeshAllowUserStop = 10;
        public const int ipTetraMeshCheckSelfIntersect = 11;

        // Direct Tetra Meshing
        public const int ipDirectTetraMeshMode = 0;
        public const int ipDirectTetraMeshSizeMode = 1;
        public const int ipDirectTetraMinEdgesPerCircle = 2;
        public const int ipDirectTetraApplyTransitioning = 3;
        public const int ipDirectTetraApplySurfaceCurvature = 4;
        public const int ipDirectTetraAllowUserStop = 5;
        public const int ipDirectTetraConsiderNearVertex = 6;
        public const int ipDirectTetraMeshSelectedGroups = 7;
        public const int ipDirectTetraMeshSize = 8;
        public const int ipDirectTetraMesh10 = 9;
        public const int ipDirectTetraMeshSmooth = 10;
        public const int ipDirectTetraAutoCreateProperties = 11;
        public const int msFine = 1;
        public const int msMedium = 2;
        public const int msCoarse = 3;
        public const int mbCancelMeshing = 0;
        public const int mbCavity = 1;
        public const int mbSeparateSolids = 2;

        // Polygon Meshing
        public const int ipMeshTargetNodes = 0;
        public const int ipMeshTargetPropertyID = 1;
        public const int ipMeshUCSID = 2;
        public const int ipMeshGroupID = 3;
        public const int ipMeshPositionUCS = 0;

        // Image Types
        public const int itBitmap8Bit = 1;
        public const int itBitmap16Bit = 2;
        public const int itBitmap24Bit = 3;
        public const int itJPEG = 4;
        public const int itPNG = 5;

        // Window State
        public const int wsModelWindowNotCreated = 0;
        public const int wsModelWindowVisible = 1;
        public const int wsModelWindowMaximised = 2;
        public const int wsModelWindowMinimised = 3;
        public const int wsModelWindowHidden = 4;

        // DISPLAY SETTINGS DEFAULTS

        // Defaults Mode
        public const int mdFactoryDefaults = 0;
        public const int mdUserDefaults = 1;

        // Model Defaults
        public const int mdViewOptions = 0;
        public const int mdEntityOptions = 1;
        public const int mdBeamPreContourOptions = 2;
        public const int mdPlatePreContourOptions = 3;
        public const int mdBrickPreContourOptions = 4;
        public const int mdAttributeOptions = 5;
        public const int mdResultOptions = 6;
        public const int mdBeamResultContourOptions = 7;
        public const int mdPlateResultContourOptions = 8;
        public const int mdBrickResultContourOptions = 9;
        public const int mdLinkResultContourOptions = 10;
        public const int mdPrintOptions = 11;

        // mdViewOptions
        public const int ipDefBackgroundTab = 0;
        public const int ipDefAxisTab = 1;
        public const int ipDefRotationTab = 2;
        public const int ipDefDrawingTab = 3;
        public const int ipDefPreNumbersTab = 4;
        public const int ipDefFreeEdgeTab = 5;
        public const int ipDefSelectionTab = 6;

        // mdEntityOptions
        public const int ipDefNodeTab = 0;
        public const int ipDefBeamTab = 1;
        public const int ipDefPlateTab = 2;
        public const int ipDefBrickTab = 3;
        public const int ipDefLinkTab = 4;
        public const int ipDefPathTab = 5;
        public const int ipDefVertexTab = 6;
        public const int ipDefFaceTab = 7;

        // mdPreContourOptions, mdResultContourOptions
        public const int ipDefContourStyleTab = 0;
        public const int ipDefContourLimitsTab = 1;
        public const int ipDefContourLegendTab = 2;
        public const int ipDefContourDiagramTab = 3;

        // mdAttributeOptions
        public const int ipDefNodeAttribTab = 0;
        public const int ipDefBeamAttribTab = 1;
        public const int ipDefPlateAttribTab = 2;
        public const int ipDefBrickAttribTab = 3;
        public const int ipDefPathAttribTab = 4;

        // mdResultOptions
        public const int ipDefResShowHideTab = 0;
        public const int ipDefResPostNumbersTab = 1;
        public const int ipDefResCombinationsTab = 2;
        public const int ipDefResEnvelopesTab = 3;
        public const int ipDefResOtherTab = 4;

        // mdPrintOptions
        public const int ipHeaderFooterTab = 0;
        public const int ipPageSetupTab = 1;
        public const int ipFontsTab = 2;

        // ENTITY DISPLAY SETTINGS

        // Label Style
        public const int lsNone = 0;
        public const int lsEntityNumber = 1;
        public const int lsIDNumber = 2;
        public const int lsPropertyNumber = 3;
        public const int lsPropertyName = 4;
        public const int lsPropertyType = 5;
        public const int lsLinkType = 3;
        public const int lsLaneNumber = 2;

        // Line Thickness Limits
        public const int kMinThickness = 1;
        public const int kMaxThickness = 5;

        // Element Outline Style
        public const int omEdge = 0;
        public const int omPropertyBoundary = 1;
        public const int omGroupBoundary = 2;
        public const int omFacetAngle = 3;
        public const int omFacetProperty = 4;
        public const int omFacetGroup = 5;

        // Shrink Limits
        public const int kMinShrink = 0;
        public const int kMaxShrink = 95;

        // Point Styles
        public const int psCircle = 0;
        public const int psSquare = 1;

        // Point Size Limits
        public const int kMinPointSize = 0;
        public const int kMaxPointSize = 5;

        // NODE ENTITY DISPLAY

        // Node Show
        public const int nsFreeNodeAll = 0;
        public const int nsFreeNodeNone = 1;
        public const int nsFreeNodeGroup = 2;

        // Node Colour Indexes
        public const int clNodeUnselected = 0;
        public const int clNodeSelected = 1;

        // BEAM ENTITY DISPLAY

        // Beam Display Style
        public const int bsLine = 0;
        public const int bsSection = 1;
        public const int bsSolid = 2;
        public const int bsSlice = 3;

        // Beam Fill Colour Type
        public const int bfNone = 0;
        public const int bfProperty = 1;
        public const int bfGroup = 2;
        public const int bfColour = 3;
        public const int bfOrientation = 4;
        public const int bfContour = 5;

        // Beam Outline Colour Type
        public const int blNone = 0;
        public const int blProperty = 1;
        public const int blGroup = 2;
        public const int blColour = 3;
        public const int blOrientation = 4;
        public const int blContour = 5;

        // Beam Colour Indexes
        public const int ipBeamFillColour = 0;
        public const int ipBeamLineColour = 1;
        public const int ipBeamOrientation1Colour = 2;
        public const int ipBeamOrientation2Colour = 3;
        public const int ipBeamNRefColour = 4;

        // Beam Spring Coil Limits
        public const int kMinSpringCoils = 5;
        public const int kMaxSpringCoils = 30;
        public const int kMinSpringAspect = 5;
        public const int kMaxSpringAspect = 50;

        // Beam Round Facets Limits
        public const int kMinFacets = 8;
        public const int kMaxFacets = 32;
        public const int kMinSlices = 4;
        public const int kMaxSlices = 20;

        // PLATE ENTITY DISPLAY

        // Plate Display Style
        public const int psSurface = 0;
        public const int psSolid = 1;

        // Plate Fill Colour Type
        public const int pfNone = 0;
        public const int pfProperty = 1;
        public const int pfGroup = 2;
        public const int pfColour = 3;
        public const int pfOrientation = 4;
        public const int pfContour = 5;

        // Plate Outline Colour Type
        public const int plNone = 0;
        public const int plProperty = 1;
        public const int plGroup = 2;
        public const int plColour = 3;

        // Plate Colour Indexes
        public const int ipPlateFillColour = 0;
        public const int ipPlateLineColour = 1;
        public const int ipPlateOrientation1Colour = 2;
        public const int ipPlateOrientation2Colour = 3;
        public const int ipPlateOrientation3Colour = 4;
        public const int ipPlateOffsetColour = 5;

        // BRICK ENTITY DISPLAY

        // Brick Fill Colour Type
        public const int kfNone = 0;
        public const int kfProperty = 1;
        public const int kfGroup = 2;
        public const int kfColour = 3;
        public const int kfContour = 4;

        // Brick Outline Colour Type
        public const int klNone = 0;
        public const int klProperty = 1;
        public const int klGroup = 2;
        public const int klColour = 3;

        // Brick Colour Indexes
        public const int ipBrickFillColour = 0;
        public const int ipBrickLineColour = 1;

        // LINK ENTITY DISPLAY

        // Link Outline Colour Type
        public const int llType = 0;
        public const int llGroup = 1;
        public const int llGlobal = 2;

        // Link Colour Indexes
        public const int ipLinkColour = 0;
        public const int ipMasterSlaveColour = 1;
        public const int ipSectorSymmetryColour = 2;
        public const int ipCouplingColour = 3;
        public const int ipPinnedColour = 4;
        public const int ipRigidColour = 5;
        public const int ipShrinkColour = 6;
        public const int ipTwoPointColour = 7;
        public const int ipAttachmentColour = 8;
        public const int ipInterpolatedMPLColour = 9;
        public const int ipMasterSlaveMPLColour = 10;
        public const int ipPinnedMPLColour = 11;
        public const int ipRigidMPLColour = 12;
        public const int ipUserMPLColour = 13;
        public const int ipReactionMPLColour = 14;

        // VERTEX ENTITY DISPLAY

        // Vertex Show
        public const int vsFreeVertexAll = 0;
        public const int vsFreeVertexNone = 1;
        public const int vsFreeVertexGroup = 2;

        // Vertex Colours Indexes
        public const int ipVertexFreeColour = 0;
        public const int ipVertexFixedColour = 1;
        public const int ipVertexSelectedColour = 2;

        // FACE ENTITY DISPLAY

        // Face Fill Style
        public const int fdNone = 0;
        public const int fdWireframe = 1;
        public const int fdSolid = 2;

        // Face Fill Colour Type
        public const int ffProperty = 0;
        public const int ffGroup = 1;
        public const int ffFaceNumber = 2;
        public const int ffColour = 3;
        public const int ffOrientation = 4;
        public const int ffFaceID = 5;

        // Face Line Colour Type
        public const int flNone = 0;
        public const int flProperty = 1;
        public const int flGroup = 2;
        public const int flFaceNumber = 3;
        public const int flColour = 4;
        public const int flFaceID = 5;

        // Face Colour Indexes
        public const int ipFaceFillColour = 0;
        public const int ipFaceLineColour = 1;
        public const int ipFaceOrientation1Colour = 2;
        public const int ipFaceOrientation2Colour = 3;
        public const int ipFaceNIEdgesColour = 4;
        public const int ipFaceCPuColour = 5;
        public const int ipFaceCPvColour = 6;
        public const int ipFaceNormalsColour = 7;

        // PATH ENTITY DISPLAY

        // Path Fill Colour Type
        public const int tfNone = 0;
        public const int tfTemplate = 1;
        public const int tfGroup = 2;
        public const int tfPathNumber = 3;
        public const int tfColour = 4;
        public const int tfOrientation = 5;

        // Path Outline Colour Type
        public const int tlNone = 0;
        public const int tlTemplate = 1;
        public const int tlGroup = 2;
        public const int tlPathNumber = 3;
        public const int tlColour = 4;

        // Path Colour Indexes
        public const int ipPathFillColour = 0;
        public const int ipPathLineColour = 1;
        public const int ipPathOrientation1Colour = 2;
        public const int ipPathOrientation2Colour = 3;

        // ATTRIBUTE DISPLAY
        public const int ipAttribDisplayShow = 0;
        public const int ipAttribDisplayLabel = 1;
        public const int ipAttribDisplayResultant = 2;
        public const int ipAttribDisplayAnchorTail = 3;
        public const int ipAttribDisplayScaled = 4;
        public const int ipAttribDisplaySize = 5;
        public const int ipAttribDisplayThickness = 6;
        public const int ipAttribDisplayCol1 = 7;
        public const int ipAttribDisplayCol2 = 8;
        public const int ipAttribDisplayCol3 = 9;

        // Window Background Modes
        public const int bgSolid = 0;
        public const int bgImage = 1;
        public const int bgGradient = 2;
        public const int bgImageGradient = 3;

        // Window Image Locations
        public const int ilCentre = 0;
        public const int ilTile = 1;
        public const int ilStretch = 2;
        public const int ilTopLeft = 3;
        public const int ilTopRight = 4;
        public const int ilBottomLeft = 5;
        public const int ilBottomRight = 6;

        // Window Display Modes
        public const int wmPreProcessing = 0;
        public const int wmPostProcessing = 1;

        // Numeric Modes
        public const int nmPreProcessing = 0;
        public const int nmPostProcessing = 1;

        // Numeric Styles
        public const int nsFixed = 0;
        public const int nsEngineering = 1;
        public const int nsScientific = 2;
        public const int nsAuto = 3;

        // Exponent formats
        public const int efLowered = 0;
        public const int efRaised = 1;

        // Entity Display Settings - Beam Contour Types
        public const int ctBeamNone = 0;
        public const int ctBeamLength = 1;
        public const int ctBeamAxis1 = 2;
        public const int ctBeamAxis2 = 3;
        public const int ctBeamAxis3 = 4;
        public const int ctBeamEA = 5;
        public const int ctBeamEI11 = 6;
        public const int ctBeamEI22 = 7;
        public const int ctBeamGJ = 8;
        public const int ctBeamEAFactor = 9;
        public const int ctBeamEI11Factor = 10;
        public const int ctBeamEI22Factor = 11;
        public const int ctBeamGJFactor = 12;
        public const int ctBeamOffset1 = 13;
        public const int ctBeamOffset2 = 14;
        public const int ctBeamStiffnessFactor1 = 15;
        public const int ctBeamStiffnessFactor2 = 16;
        public const int ctBeamStiffnessFactor3 = 17;
        public const int ctBeamStiffnessFactor4 = 18;
        public const int ctBeamStiffnessFactor5 = 19;
        public const int ctBeamStiffnessFactor6 = 20;
        public const int ctBeamMassFactor = 21;
        public const int ctBeamSupportM1 = 22;
        public const int ctBeamSupportP1 = 23;
        public const int ctBeamSupportM2 = 24;
        public const int ctBeamSupportP2 = 25;
        public const int ctBeamSupportGapM1 = 26;
        public const int ctBeamSupportGapP1 = 27;
        public const int ctBeamSupportGapM2 = 28;
        public const int ctBeamSupportGapP2 = 29;
        public const int ctBeamTemperature = 30;
        public const int ctBeamTempGradient1 = 31;
        public const int ctBeamTempGradient2 = 32;
        public const int ctBeamPreTension = 33;
        public const int ctBeamPreStrain = 34;
        public const int ctBeamPreCurvature1 = 35;
        public const int ctBeamPreCurvature2 = 36;
        public const int ctBeamPipePressureIn = 37;
        public const int ctBeamPipePressureOut = 38;
        public const int ctBeamPipeTempIn = 39;
        public const int ctBeamPipeTempOut = 40;
        public const int ctBeamConvectionCoeff = 41;
        public const int ctBeamConvectionAmbient = 42;
        public const int ctBeamRadiationCoeff = 43;
        public const int ctBeamRadiationAmbient = 44;
        public const int ctBeamHeatFlux = 45;
        public const int ctBeamHeatSource = 46;
        public const int ctBeamAgeAtFirstLoading = 47;

        // Entity Display Settings - Plate Contour Types
        public const int ctPlateNone = 0;
        public const int ctPlateAspectRatioMin = 1;
        public const int ctPlateAspectRatioMax = 2;
        public const int ctPlateWarping = 3;
        public const int ctPlateInternalAngle = 4;
        public const int ctPlateInternalAngleRatio = 5;
        public const int ctPlateArea = 6;
        public const int ctPlateAxis1 = 7;
        public const int ctPlateAxis2 = 8;
        public const int ctPlateAxis3 = 9;
        public const int ctPlateDiscreteThicknessM = 10;
        public const int ctPlateContinuousThicknessM = 11;
        public const int ctPlateDiscreteThicknessB = 12;
        public const int ctPlateContinuousThicknessB = 13;
        public const int ctPlateOffset = 14;
        public const int ctPlateStiffnessFactor1 = 15;
        public const int ctPlateStiffnessFactor2 = 16;
        public const int ctPlateStiffnessFactor3 = 17;
        public const int ctPlateStiffnessFactor4 = 18;
        public const int ctPlateStiffnessFactor5 = 19;
        public const int ctPlateStiffnessFactor6 = 20;
        public const int ctPlateStiffnessFactor7 = 21;
        public const int ctPlateStiffnessFactor8 = 22;
        public const int ctPlateStiffnessFactor9 = 23;
        public const int ctPlateMassFactor = 24;
        public const int ctPlateEdgeNormalSupport = 25;
        public const int ctPlateEdgeLateralSupport = 26;
        public const int ctPlateEdgeSupportGap = 27;
        public const int ctPlateFaceNormalSupportMZ = 28;
        public const int ctPlateFaceNormalSupportPZ = 29;
        public const int ctPlateFaceLateralSupportMZ = 30;
        public const int ctPlateFaceLateralSupportPZ = 31;
        public const int ctPlateFaceSupportGapMZ = 32;
        public const int ctPlateFaceSupportGapPZ = 33;
        public const int ctPlateTemperature = 34;
        public const int ctPlateTempGradient = 35;
        public const int ctPlatePreStressX = 36;
        public const int ctPlatePreStressY = 37;
        public const int ctPlatePreStressZ = 38;
        public const int ctPlatePreStressMagnitude = 39;
        public const int ctPlatePreStrainX = 40;
        public const int ctPlatePreStrainY = 41;
        public const int ctPlatePreStrainZ = 42;
        public const int ctPlatePreStrainMagnitude = 43;
        public const int ctPlatePreCurvatureX = 44;
        public const int ctPlatePreCurvatureY = 45;
        public const int ctPlatePreCurvatureMagnitude = 46;
        public const int ctPlateEdgeNormalPressure = 47;
        public const int ctPlateEdgeShear = 48;
        public const int ctPlateEdgeTransverseShear = 49;
        public const int ctPlateEdgeGlobalPressure = 50;
        public const int ctPlateEdgeGlobalPressureX = 51;
        public const int ctPlateEdgeGlobalPressureY = 52;
        public const int ctPlateEdgeGlobalPressureZ = 53;
        public const int ctPlatePressureNormalMZ = 54;
        public const int ctPlatePressureNormalPZ = 55;
        public const int ctPlatePressureGlobalMZ = 56;
        public const int ctPlatePressureGlobalXMZ = 57;
        public const int ctPlatePressureGlobalYMZ = 58;
        public const int ctPlatePressureGlobalZMZ = 59;
        public const int ctPlatePressureGlobalPZ = 60;
        public const int ctPlatePressureGlobalXPZ = 61;
        public const int ctPlatePressureGlobalYPZ = 62;
        public const int ctPlatePressureGlobalZPZ = 63;
        public const int ctPlateFaceShearX = 64;
        public const int ctPlateFaceShearY = 65;
        public const int ctPlateFaceShearMagnitude = 66;
        public const int ctPlateNSMass = 67;
        public const int ctPlateDynamicFactor = 68;
        public const int ctPlateConvectionCoeff = 69;
        public const int ctPlateConvectionAmbient = 70;
        public const int ctPlateRadiationCoeff = 71;
        public const int ctPlateRadiationAmbient = 72;
        public const int ctPlateHeatFlux = 73;
        public const int ctPlateConvectionCoeffZPlus = 74;
        public const int ctPlateConvectionCoeffZMinus = 75;
        public const int ctPlateConvectionAmbientZPlus = 76;
        public const int ctPlateConvectionAmbientZMinus = 77;
        public const int ctPlateRadiationCoeffZPlus = 78;
        public const int ctPlateRadiationCoeffZMinus = 79;
        public const int ctPlateRadiationAmbientZPlus = 80;
        public const int ctPlateRadiationAmbientZMinus = 81;
        public const int ctPlateHeatSource = 82;
        public const int ctPlateSoilStressSV = 83;
        public const int ctPlateSoilStressK0 = 84;
        public const int ctPlateSoilStressSH = 85;
        public const int ctPlateSoilRatioOCR = 86;
        public const int ctPlateSoilRatioE0 = 87;
        public const int ctPlateSoilFluidLevel = 88;
        public const int ctPlateAgeAtFirstLoading = 89;

        // Entity Display Settings - Brick Contour Types
        public const int ctBrickNone = 0;
        public const int ctBrickAspectRatioMin = 1;
        public const int ctBrickAspectRatioMax = 2;
        public const int ctBrickDeterminant = 3;
        public const int ctBrickInternalAngle = 4;
        public const int ctBrickMixedProduct = 5;
        public const int ctBrickDihedral = 6;
        public const int ctBrickVolume = 7;
        public const int ctBrickAxis1 = 8;
        public const int ctBrickAxis2 = 9;
        public const int ctBrickAxis3 = 10;
        public const int ctBrickNormalSupport = 11;
        public const int ctBrickLateralSupport = 12;
        public const int ctBrickSupportGap = 13;
        public const int ctBrickTemperature = 14;
        public const int ctBrickPreStressX = 15;
        public const int ctBrickPreStressY = 16;
        public const int ctBrickPreStressZ = 17;
        public const int ctBrickPreStressMagnitude = 18;
        public const int ctBrickPreStrainX = 19;
        public const int ctBrickPreStrainY = 20;
        public const int ctBrickPreStrainZ = 21;
        public const int ctBrickPreStrainMagnitude = 22;
        public const int ctBrickNormalPressure = 23;
        public const int ctBrickGlobalPressure = 24;
        public const int ctBrickGlobalPressureX = 25;
        public const int ctBrickGlobalPressureY = 26;
        public const int ctBrickGlobalPressureZ = 27;
        public const int ctBrickShearX = 28;
        public const int ctBrickShearY = 29;
        public const int ctBrickShearMagnitude = 30;
        public const int ctBrickNSMass = 31;
        public const int ctBrickDynamicFactor = 32;
        public const int ctBrickConvectionCoeff = 33;
        public const int ctBrickConvectionAmbient = 34;
        public const int ctBrickRadiationCoeff = 35;
        public const int ctBrickRadiationAmbient = 36;
        public const int ctBrickHeatFlux = 37;
        public const int ctBrickHeatSource = 38;
        public const int ctBrickSoilStressSV = 39;
        public const int ctBrickSoilStressK0 = 40;
        public const int ctBrickSoilStressSH = 41;
        public const int ctBrickSoilRatioOCR = 42;
        public const int ctBrickSoilRatioE0 = 43;
        public const int ctBrickSoilFluidLevel = 44;
        public const int ctBrickAgeAtFirstLoading = 45;

        // Beam/Plate/Brick/Link Result Display Type - INDEXED BY ipResultType
        public const int rtAsNone = 0;
        public const int rtAsContour = 1;
        public const int rtAsDiagram = 2;
        public const int rtAsVector = 3;

        // Node Output Display Quantity - Indexed by ipResultQuantity
        public const int rqDispC = 101;
        public const int rqInfluenceC = 101;
        public const int rqVelC = 102;
        public const int rqAccC = 103;
        public const int rqPhaseC = 104;
        public const int rqReactC = 105;
        public const int rqTempC = 106;
        public const int rqNodeForceC = 107;
        public const int rqNodeFluxC = 108;
        public const int rqNodeInertiaC = 109;

        // Beam Output Display Quantity - Indexed by ipResultQuantity
        public const int rqBeamForceC = 201;
        public const int rqBeamStrainC = 202;
        public const int rqBeamStressC = 203;
        public const int rqBeamCreepStrainC = 204;
        public const int rqBeamEnergyC = 205;
        public const int rqBeamFluxC = 206;
        public const int rqBeamTGradC = 207;
        public const int rqBeamTotalStrainC = 208;
        public const int rqBeamUserC = 299;

        // Plate Output Display Quantity - Indexed by ipResultQuantity
        public const int rqPlateForceC = 301;
        public const int rqPlateMomentC = 302;
        public const int rqPlateStressC = 303;
        public const int rqPlateStrainC = 304;
        public const int rqPlateCurvatureC = 305;
        public const int rqPlateCreepStrainC = 306;
        public const int rqPlateEnergyC = 307;
        public const int rqPlateFluxC = 308;
        public const int rqPlateTGradC = 309;
        public const int rqPlateRCDesignC = 310;
        public const int rqPlatePlyStressC = 311;
        public const int rqPlatePlyStrainC = 312;
        public const int rqPlatePlyReserveC = 313;
        public const int rqPlateSoilC = 314;
        public const int rqPlateTotalStrainC = 315;
        public const int rqPlateTotalCurvatureC = 316;
        public const int rqPlateUserC = 399;

        // Brick Output Display Quantity - Indexed by ipResultQuantity
        public const int rqBrickStressC = 401;
        public const int rqBrickStrainC = 402;
        public const int rqBrickCreepStrainC = 403;
        public const int rqBrickEnergyC = 404;
        public const int rqBrickFluxC = 405;
        public const int rqBrickTGradC = 406;
        public const int rqBrickSoilC = 407;
        public const int rqBrickTotalStrainC = 408;
        public const int rqBrickUserC = 499;

        // Link Output Display Quantity - Indexed by ipResultQuantity
        public const int rqLinkForceC = 501;
        public const int rqLinkFluxC = 502;
        public const int rqLinkMPLReactionC = 503;

        // Plate RC Output Display Sub-quantity - Indexed by ipResultComponent
        public const int rcWoodArmerMoment = 0;
        public const int rcWoodArmerForce = 1;
        public const int rcSteelRequirementMin = 2;
        public const int rcConcreteStrain = 3;
        public const int rcSteelRequirementLessBase = 4;
        public const int rcUserSteelStress = 5;
        public const int rcUserConcreteStrain = 6;
        public const int rcBlockRatio = 7;

        // Plate RC Area Output Display Sub-quantity - Indexed by ipResultSystem
        public const int rsAreaPerLength = 0;
        public const int rsBarSpacing = 1;
        public const int rsBarDiameter = 2;
        public const int rsAreaPerAreaSlab = 3;
        public const int rsAreaPerAreaBase = 4;

        // Plate Composite Output Display Sub-quantity - Indexed by ipResultSystem
        public const int rsPlyMinValue = -1;
        public const int rsPlyMaxValue = -2;
        public const int rsPlyMaxMag = -3;
        public const int rsPlyMinValueActivePlies = -4;
        public const int rsPlyMaxValueActivePlies = -5;
        public const int rsPlyMaxMagActivePlies = -6;

        // Vector Styles - Indexed by ipVectorStyle
        public const int vtVectorTranslationMag = 1;
        public const int vtVectorRotationMag = 2;
        public const int vtVectorTranslationComponents = 3;
        public const int vtVectorRotationComponents = 4;

        // Result Display Indexes
        public const int ipResultType = 0;
        public const int ipResultQuantity = 1;
        public const int ipResultSystem = 2;
        public const int ipResultComponent = 3;
        public const int ipResultSurface = 4;
        public const int ipVectorStyle = 5;
        public const int ipReferenceNode = 6;
        public const int ipAbsoluteValue = 7;
        public const int ipDiagram1 = 7;
        public const int ipDiagram2 = 8;
        public const int ipDiagram3 = 9;
        public const int ipDiagram4 = 10;
        public const int ipDiagram5 = 11;
        public const int ipDiagram6 = 12;
        public const int ipVector1 = 7;
        public const int ipVector2 = 8;
        public const int ipVector3 = 9;
        public const int ipVector4 = 10;
        public const int ipVector5 = 11;
        public const int ipVector6 = 12;

        // Contour Settings - Style Constants
        public const int csRainbow = 0;
        public const int csRainbowEnds = 1;
        public const int csMono = 2;
        public const int csLines = 3;
        public const int csBands = 4;
        public const int vaTail = 0;
        public const int vaHead = 1;

        // Contour Settings - Style Indexes
        public const int ipContourStyle = 0;
        public const int ipReverse = 1;
        public const int ipSeparator = 2;
        public const int ipBand1Colour = 3;
        public const int ipBand2Colour = 4;
        public const int ipSeparatorColour = 5;
        public const int ipLineBackColour = 6;
        public const int ipMonoColour = 7;
        public const int ipMinColour = 8;
        public const int ipMaxColour = 9;
        public const int ipLimitMin = 10;
        public const int ipLimitMax = 11;
        public const int ipVectorThickness = 12;
        public const int ipVectorLength = 13;
        public const int ipVectorAnchor = 14;

        // Contour Settings - Limits Constants
        public const int clDefault = 0;
        public const int clUserRange = 1;
        public const int clRounded = 2;
        public const int clUserSpecified = 3;
        public const int cmContinuous = 0;
        public const int cmDiscrete = 1;

        // Contour Settings - Limits Indexes
        public const int ipContourLimit = 0;
        public const int ipContourMode = 1;
        public const int ipNumContours = 2;
        public const int ipSetMinLimit = 3;
        public const int ipSetMaxLimit = 4;
        public const int ipMinLimit = 0;
        public const int ipMaxLimit = 1;

        // Contour Settings - Legend Constants
        public const int lpNone = 0;
        public const int lpTopLeft = 1;
        public const int lpTopRight = 2;
        public const int lpBottomLeft = 3;
        public const int lpBottomRight = 4;
        public const int lpFloating = 5;

        // Contour Settings - Legend Indexes
        public const int ipLegendPosition = 0;
        public const int ipOpaqueLegend = 1;
        public const int ipShowMinMax = 2;
        public const int ipHistogram = 3;
        public const int ipLegendWidth = 4;
        public const int ipLegendHeight = 5;

        // Contour Settings - Diagram Constants
        public const int dsSingleLine = 0;
        public const int dsHatched = 1;

        // Contour Settings - Diagram Indexes
        public const int ipDiagramStyle = 0;
        public const int ipDiagramAxialDir = 1;
        public const int ipDiagramTorqueDir = 2;
        public const int ipDiagramRelativeLength = 3;
        public const int ipDiagramThickness = 4;

        // Font Settings
        public const int ipFontSize = 0;
        public const int ipFontColour = 1;
        public const int ipFontStyleBold = 2;
        public const int ipFontStyleItalic = 3;
        public const int ipFontStyleUnderline = 4;

        // Displacement Scales
        public const int dsPercent = 0;
        public const int dsAbsolute = 1;

        // Reference Displacement Modes
        public const int rdNone = 0;
        public const int rdPreviousCase = -1;

        // User Contour File Types
        public const int ucNode = 0;
        public const int ucElement = 1;

        // Utility
        public const int auRadian = 0;
        public const int auDegree = 1;

        // Transient Base Modes
        public const int bmRelative = 0;
        public const int bmTotal = 1;

        // Beam Position Modes
        public const int bpLength = 0;
        public const int bpParam = 1;

        // Result Options
        public const int ipResOptsRotationUnit = 0;
        public const int ipResOptsStrainUnit = 1;
        public const int ipResOptsAddGNLDisp = 2;
        public const int ipResOptsOffsetDisp = 3;
        public const int ipResOptsNFADisp = 4;
        public const int ipResOptsReactionLinkGNL = 5;
        public const int ipResOptsBaseDisp = 6;
        public const int ipResOptsBaseVel = 7;
        public const int ipResOptsBaseAcc = 8;

        // Result Options - Strain Units
        public const int suUnit = 0;
        public const int suPercent = 1;
        public const int suMicro = 2;

        // Result Options - NFA Displacement Modes
        public const int dmUnitModalMass = 0;
        public const int dmEngModalMass = 1;

        // Tool Options - Doubles
        public const int ipToolOptsElementTol = 0;
        public const int ipToolOptsGeometryAccuracy = 1;
        public const int ipToolOptsGeometryFeatureLength = 2;

        // Tool Options - Integers
        public const int ipToolOptsElementTolType = 0;
        public const int ipToolOptsGeometryAccuracyType = 1;
        public const int ipToolOptsGeometryFeatureType = 2;
        public const int ipToolOptsZipMesh = 3;
        public const int ipToolOptsNodeCoordinate = 4;
        public const int ipToolOptsNodeAttributeKeep = 5;
        public const int ipToolOptsAllowZeroLengthLinks = 6;
        public const int ipToolOptsAllowZeroLengthBeams = 7;
        public const int ipToolOptsSubdivideBeams = 10;
        public const int ipToolOptsInterpSideAttachments = 11;
        public const int ipToolOptsCompatibleTriangle = 12;
        public const int ipToolOptsAdjustMidsideNodes = 13;
        public const int ipToolOptsEvaluateFormulas = 14;
        public const int ipToolOptsPlateAxisAlign = 15;
        public const int ipToolOptsWedgeSubdivision = 16;
        public const int ipToolOptsCopyMode = 17;
        public const int ipToolOptsAutoCreateProperties = 18;
        public const int ipToolOptsInsertMPLNodes = 19;
        public const int ipToolOptsConsiderDroopedCables = 20;
        public const int ipToolOptsConsiderBeam3 = 21;

        // Tool Options - Copy Flags
        public const int ipCopyNodeVertexAttributes = 0;
        public const int ipCopyElementFaceAttributes = 1;
        public const int ipIncrementStringID = 2;
        public const int ipCreateNewGroup = 3;
        public const int ipIncrementClusterID = 4;

        // Tool Options - Extrude Flags
        public const int ipExtrudePlateEdgeAttributes = 0;

        // Tool Options - Extrude Targets
        public const int ipExtrudeNodeTarget = 0;
        public const int ipExtrudeNodeTargetOption = 1;
        public const int ipExtrudeNodeTargetUCS = 2;
        public const int ipExtrudeBeamTarget = 3;
        public const int ipExtrudeShrinkFreedomCase = 4;

        // Tool Options - Mesh Zipping
        public const int zmAsNeeded = 0;
        public const int zmOnSave = 1;
        public const int zmOnRequest = 2;

        // Tool Options - Copy Mode
        public const int cmRoot = 0;
        public const int cmSibling = 1;

        // Tool Options - Axis Alignment
        public const int paCentroid = 0;
        public const int paCurvilinear = 1;

        // Tool Options - Wedge Subdivision
        public const int wsUseAB = 0;
        public const int wsUseAC = 1;

        // Tool Options - Source Action
        public const int saLeave = 0;
        public const int saDelete = 1;
        public const int saCopy = 2;
        public const int saMove = 3;

        // Tool Options - Extrude Target - Node
        public const int etBeam2 = 0;
        public const int etBeam3 = 1;
        public const int etMasterSlaveLink = 2;
        public const int etPinnedLink = 3;
        public const int etRigidLink = 4;
        public const int etShrinkLink = 5;

        // Tool Options - Scale by UCS - Scale About
        public const int saMiddle = 0;
        public const int saOrigin = 1;
        public const int saPoint = 2;

        // Tool Options - Extrude Target - Beam
        public const int etPlateQuad4 = 0;
        public const int etPlateQuad8 = 1;
        public const int etPlateQuad9 = 2;

        // Tool Options - Detach Elements - Connection Type
        public const int ctNone = 0;
        public const int ctMasterSlaveLink = 1;
        public const int ctBeam2 = 2;

        // Tool Options - Points and Lines - Target
        public const int plNode = 0;
        public const int plBeam2 = 1;
        public const int plBeam3 = 2;

        // Tool Options - Subdivide Target - Plate
        public const int stPlateTri3 = 0;
        public const int stPlateTri6 = 1;
        public const int stPlateQuad4 = 2;
        public const int stPlateQuad8 = 3;
        public const int stPlateQuad9 = 4;
        public const int stPlateSource = 5;
        public const int stPlateTri = 6;
        public const int stPlateQuad = 7;

        // Tool Options - Subdivide Target - Brick
        public const int stBrickTetra4 = 0;
        public const int stBrickTetra10 = 1;
        public const int stBrickWedge6 = 2;
        public const int stBrickWedge15 = 3;
        public const int stBrickHexa8 = 4;
        public const int stBrickHexa16 = 5;
        public const int stBrickHexa20 = 6;
        public const int stBrickSource = 7;
        public const int stBrickTetra = 8;
        public const int stBrickWedge = 9;
        public const int stBrickHexa = 10;

        // Tool Options - Grade Type
        public const int gt1x2Grade = 0;
        public const int gt1x2TriGrade = 1;
        public const int gt1x3Grade = 2;
        public const int gt2x3Grade = 3;
        public const int gt2x3TriGrade = 4;
        public const int gtQuarterQuadGrade = 5;
        public const int gtQuarterCircleCut = 6;
        public const int gtQuarterAnnulusCut = 7;
        public const int gtFullQuarterCircleCut = 8;
        public const int gtTriGrade2 = 9;
        public const int gtTriGrade1 = 10;
        public const int gtTriGrade3 = 11;
        public const int gt2x4Grade = 12;
        public const int gtBrickCornerGrade = 13;
        public const int gtQuadTriGrade1 = 14;
        public const int gtTriGrade5 = 15;
        public const int gtQuadCutOut = 16;
        public const int gtTriGrade4 = 17;
        public const int gtFullQuarterCircleGrade = 18;
        public const int gtQuadGradeTri = 19;

        // Tool Options - Beams on Edges
        public const int eeSplit = 0;
        public const int eeIgnoreMid = 1;
        public const int eeBeam3 = 2;
        public const int geBeam2 = 0;
        public const int geBeam3 = 1;

        // Tool Options - Create Entity UCS
        public const int puCylindrical = 0;
        public const int puCartesian = 1;

        // Tool Options - Create Entity UCS
        public const int buPrincipal = 0;
        public const int buLocal = 1;

        // Tool Options - Create Entity UCS
        public const int ulAtMin = 0;
        public const int ulAtMax = 1;
        public const int ulAtMean = 2;

        // Tools Options - Align Beam Offsets - Sections
        public const int ipCircularSection = 0;
        public const int ipSquareSection = 1;
        public const int ipCSection = 2;
        public const int ipISection = 3;
        public const int ipTSection = 4;
        public const int ipLSection = 5;
        public const int ipZSection = 6;
        public const int ipBXSSection = 7;
        public const int ipTrapezoidalSection = 8;
        public const int ipTriangularSection = 9;
        public const int ipCruciformSection = 10;
        public const int ipUndefinedSection = 11;

        // Tools Options - Align Beam Offsets - Section Offsets
        public const int soNoChange = 0;
        public const int soTopLeft = 1;
        public const int soTopMid = 2;
        public const int soTopRight = 3;
        public const int soMidLeft = 4;
        public const int soGeometricCenter = 5;
        public const int soMidRight = 6;
        public const int soBottomLeft = 7;
        public const int soBottomMid = 8;
        public const int soBottomRight = 9;
        public const int soCentroid = 10;
        public const int soShearCenter = 11;

        // Tools Options - Merge Line of Beams
        public const int mbStatic = 0;
        public const int mbDynamic = 1;

        // Tool Options - Reinforcement Alignment
        public const int raLayer13 = 1;
        public const int raLayer24 = 2;

        // Tool Options - Extrude by Line Direction
        public const int ldAuto = 0;
        public const int ldReversed = 1;

        // Tool Options - Create Beams on Element Edges
        public const int beBasedOnModel = 0;
        public const int beBasedOnSelected = 1;

        // Tool Options - ReactionMPL at specified origin
        public const int ocUseOrigin = -1;
        public const int ocUseNodeAverage = 0;

        // Tool Options - Detach modes
        public const int dmDetachIndividual = 0;
        public const int dmDetachAsCluster = 1;
        public const int dmDetachGroups = 2;

        // Copy-Paste - Constants
        public const int poCasesInOrder = 0;
        public const int poCasesMatchNames = 1;
        public const int poPropertiesUsePropertyID = 0;
        public const int poPropertiesMatchExisting = 1;
        public const int poPropertiesCreateNew = 2;
        public const int poLoadPathUseTemplateID = 0;
        public const int poLoadPathCreateNew = 1;

        // Copy-Paste - Indexes
        public const int ipPasteCases = 0;
        public const int ipPasteProperties = 1;
        public const int ipPasteLoadPaths = 2;
        public const int ipPasteAttributes = 3;
        public const int ipPasteGroups = 4;
        public const int ipPasteGlobals = 5;
        public const int ipPasteTables = 6;

        // Insitu Parameters
        public const int ipInsituGravityCase = 0;
        public const int ipInsituFreedomCase = 1;
        public const int ipInsituStageIndex = 2;
        public const int ipInsituUseExisting = 3;
        public const int ipInsituReplaceK0 = 4;
        public const int ipInsituMaxIterations = 5;
        public const int ipInsituAllowIterations = 6;
        public const int ipInsituDefaultFluidLevel = 0;
        public const int ipInsituDefaultFluidDensity = 1;

        // Insitu Warning Codes
        public const int wcInsituNoWarning = 0;
        public const int wcInsituUnconverged = 1;
        public const int wcInsituTensileStress = 2;

        // LSA Combinations Warning Codes
        public const int wcLSACombineNoWarning = 0;
        public const int wcLSACombineInvalidSRA = 1;

        // Axis Definitions
        public const int axLocalX = 1;
        public const int axLocalY = 2;
        public const int axPrincipal1 = 1;
        public const int axPrincipal2 = 2;
        public const int axBeamPrincipal = 0;
        public const int axBeamLocal = 1;

        // Beam Taper
        public const int btSymm = 0;
        public const int btTop = 1;
        public const int btBottom = 2;

        // Pre-load
        public const int plBeamPreTension = 0;
        public const int plBeamPreStrain = 1;
        public const int plPlatePreStress = 0;
        public const int plPlatePreStrain = 1;
        public const int plBrickPreStress = 0;
        public const int plBrickPreStrain = 1;
        public const int plCavityPreStress = 0;
        public const int plCavityPreStrain = 1;

        // Attachment Attribute
        public const int alRigid = 0;
        public const int alFlexible = 1;
        public const int alDirect = 2;
        public const int alMoment = 0;
        public const int alPinned = 1;

        // LTA Methods
        public const int ltWilson = 0;
        public const int ltNewmark = 1;

        // Spectral
        public const int stResponse = 0;
        public const int stPSD = 1;

        // Spectral Results Sign
        public const int rsAuto = 0;
        public const int rsAbsolute = 1;

        // LTA
        public const int stFullSystem = 0;
        public const int stSuperposition = 1;

        // Create Attachments - Brick Target
        public const int ktFreeFaces = 0;
        public const int ktAllFaces = 1;
        public const int ktInsideBricks = 2;

        // Transient Initial Conditions
        public const int icNone = 0;
        public const int icAppliedVectors = 1;
        public const int icNodalVelocity = 2;
        public const int icFromFile = 3;

        // Transient and QuasiStatic Temperature
        public const int ttNodalTemp = 0;
        public const int ttFromFile = 1;

        // Envelopes
        public const int etLimitEnvelopeAbs = 0;
        public const int etLimitEnvelopeMin = 1;
        public const int etLimitEnvelopeMax = 2;
        public const int etLimitEnvelopeMag = 3;
        public const int etCombEnvelopeMin = 0;
        public const int etCombEnvelopeMax = 1;
        public const int etFactEnvelopeMin = 0;
        public const int etFactEnvelopeMax = 1;
        public const int esCombEnvelopeOn = 0;
        public const int esCombEnvelopeOff = 1;
        public const int esCombEnvelopeCheck = 2;
        public const int stExclusiveOR = 0;
        public const int stExclusiveAND = 1;

        // Frequency Table Units
        public const int fuNone = 0;
        public const int fuDispResponse = 1;
        public const int fuVelResponse = 2;
        public const int fuAccelResponse = 3;
        public const int fuDispPSD = 4;
        public const int fuVelPSD = 5;
        public const int fuAccelPSD = 6;
        public const int fuAccelResponseG = 7;
        public const int fuAccelPSDG = 8;

        // Temp/Time Types
        public const int mtElastic = 0;
        public const int mtPlastic = 1;

        // Material Hardening Types
        public const int htIsotropic = 0;
        public const int htKinematic = 1;
        public const int htTakeda = 2;

        // Spring-damper
        public const int ipSpringAxialStiff = 0;
        public const int ipSpringLateralStiff = 1;
        public const int ipSpringTorsionStiff = 2;
        public const int ipSpringAxialDamp = 3;
        public const int ipSpringLateralDamp = 4;
        public const int ipSpringTorsionDamp = 5;
        public const int ipSpringMass = 6;

        // Truss
        public const int ipTrussIncludeTorsion = 0;

        // Cable - Integers
        public const int ipCablePreStrainScalesMass = 0;

        // Cable - Doubles
        public const int ipCableDiameter = 0;

        // Cutoff Bar
        public const int ipCutoffTension = 0;
        public const int ipCutoffCompression = 1;

        // Contact
        public const int cfElastic = 0;
        public const int cfPlastic = 1;
        public const int cyRectangular = 0;
        public const int cyElliptical = 1;

        // Thermal data
        public const int ipThermalArea = 0;
        public const int ipThermalMass = 1;

        // Ply Material - Integers
        public const int ipPlyWeaveType = 0;
        public const int wtPlyUniDirectional = 0;
        public const int wtPlyBiDirectional = 1;
        public const int wtPlyTriDirectional = 2;
        public const int wtPlyQuasiIsotropic = 3;

        // Ply Material - Doubles
        public const int ipPlyModulus1 = 0;
        public const int ipPlyModulus2 = 1;
        public const int ipPlyPoisson = 2;
        public const int ipPlyShear12 = 3;
        public const int ipPlyShear13 = 4;
        public const int ipPlyShear23 = 5;
        public const int ipPlyAlpha1 = 6;
        public const int ipPlyAlpha2 = 7;
        public const int ipPlyDensity = 8;
        public const int ipPlyThickness = 9;
        public const int ipPlyS1Tension = 10;
        public const int ipPlyS2Tension = 11;
        public const int ipPlyS1Compression = 12;
        public const int ipPlyS2Compression = 13;
        public const int ipPlySShear = 14;
        public const int ipPlyE1Tension = 15;
        public const int ipPlyE2Tension = 16;
        public const int ipPlyE1Compression = 17;
        public const int ipPlyE2Compression = 18;
        public const int ipPlyEShear = 19;
        public const int ipPlyInterLaminaShear = 20;

        // Laminate Material
        public const int ipLaminateViscosity = 0;
        public const int ipLaminateDampingRatio = 1;
        public const int ipLaminateConductivity1 = 2;
        public const int ipLaminateConductivity2 = 3;
        public const int ipLaminateSpecificHeat = 4;
        public const int ipLaminateDensity = 5;
        public const int ipLaminateAlphax = 6;
        public const int ipLaminateAlphay = 7;
        public const int ipLaminateAlphaxy = 8;
        public const int ipLaminateBetax = 9;
        public const int ipLaminateBetay = 10;
        public const int ipLaminateBetaxy = 11;
        public const int ipLaminateModulusx = 12;
        public const int ipLaminateModulusy = 13;
        public const int ipLaminateShearxy = 14;
        public const int ipLaminatePoissonxy = 15;
        public const int ipLaminatePoissonyx = 16;
        public const int ipLaminateThickness = 17;

        // Laminate Plies
        public const int ipLaminatePlyAngle = 0;
        public const int ipLaminatePlyThickness = 1;

        // Laminate Matrices
        public const int ipLaminateIgnoreCoupling = 0;
        public const int ipLaminateAutoTransverseShear = 1;

        // Concrete Reinforcement Layouts - Integers
        public const int ipRCLayoutType = 0;
        public const int ipRCColour13 = 1;
        public const int ipRCColour24 = 2;
        public const int ipRCCalcMethod = 3;
        public const int ipRCConsiderMembrane = 4;
        public const int ipRCAllowCompressionReo = 5;
        public const int ipRCCode = 6;
        public const int ipRCLimitConcreteStrain = 7;
        public const int crEC2 = 0;
        public const int crAS3600 = 1;
        public const int crACI318 = 2;
        public const int crRCSymmetric = 0;
        public const int crRCAntiSymmetric = 1;
        public const int crRCSimplified = 0;
        public const int crRCElastoPlasticIter = 1;

        // Concrete Reinforcement Layouts - Doubles
        public const int ipRCDiam1 = 0;
        public const int ipRCDiam2 = 1;
        public const int ipRCDiam3 = 2;
        public const int ipRCDiam4 = 3;
        public const int ipRCCover1 = 4;
        public const int ipRCCover2 = 5;
        public const int ipRCSpacing1 = 6;
        public const int ipRCSpacing2 = 7;
        public const int ipRCSpacing3 = 8;
        public const int ipRCSpacing4 = 9;
        public const int ipRCConcreteModulus = 10;
        public const int ipRCConcreteStrain = 11;
        public const int ipRCConcreteStress = 12;
        public const int ipRCConcreteAlpha = 13;
        public const int ipRCConcreteGamma = 14;
        public const int ipRCSteelModulus = 15;
        public const int ipRCSteelStress = 16;
        public const int ipRCSteelGamma = 17;
        public const int ipRCSteelMinArea = 18;
        public const int ipRCReduction = 19;
        public const int ipRCConcreteEta = 20;

        // Cavity Fluid Layout Types
        public const int ftIdealGas = 0;
        public const int ftConstantBulkModulus = 1;

        // Cavity Fluid Layouts - Integers
        public const int ipCFColour = 0;
        public const int ipCFConsiderTemperature = 1;
        public const int ipCFPressureControlCase = 2;

        // Cavity Fluid Layouts - Ideal Gas Doubles
        public const int ipCFInitialPressure = 0;
        public const int ipCFInitialTemperature = 1;

        // Cavity Fluid Layouts - Constant Bulk Modulus Doubles
        public const int ipCFBulkModulus = 0;
        public const int ipCFAlpha = 1;

        // Creep Hardening
        public const int ipCreepHardeningType = 0;
        public const int ipCreepHardeningCyclic = 1;
        public const int crHardeningTime = 0;
        public const int crHardeningStrain = 1;

        // Hyperbolic Creep - Doubles
        public const int ipCreepHyberbolicAlpha = 0;
        public const int ipCreepHyperbolicBeta = 1;
        public const int ipCreepHyperbolicDelta = 2;
        public const int ipCreepHyperbolicPhi = 3;

        // Hyperbolic Creep - Integers
        public const int ipCreepHyperbolicTimeTable = 0;
        public const int ipCreepHyperbolicConstModulus = 1;

        // Visco-elastic Creep - Integers
        public const int ipCreepViscoTimeTable = 0;
        public const int ipCreepViscoTempTable = 1;

        // Visco-elastic Creep - Doubles
        public const int ipCreepViscoDamper = 0;
        public const int ipCreepViscoStiffness = 1;

        // Creep Concrete Functions
        public const int crCreepFunction = 0;
        public const int crRelaxationFunction = 1;

        // Creep Shrinkage
        public const int crCreepShrinkageTable = 0;
        public const int crCreepShrinkageFormula = 1;
        public const int ipCreepShrinkageAlpha = 0;
        public const int ipCreepShrinkageBeta = 1;
        public const int ipCreepShrinkageDelta = 2;
        public const int ipCreepShrinkageStrain = 3;

        // Creep Temperature - Integers
        public const int ipIncludeCreepTemperature = 0;
        public const int ipIncludeRateTemperature = 1;
        public const int ipIncludeShrinkageTemperature = 2;

        // Creep Temperature - Doubles
        public const int ipCreepCAAge = 0;
        public const int ipCreepTRefAge = 1;
        public const int ipCreepCCCreep = 2;
        public const int ipCreepTRefCreep = 3;
        public const int ipCreepCAShrink = 4;
        public const int ipCreepTRefShrink = 5;

        // Cement Curing - Integers
        public const int ipCreepIncludeCuring = 0;
        public const int ipCreepCuringTimeTable = 1;
        public const int ipCreepCuringType = 2;
        public const int crCementCuringRapid = 0;
        public const int crCementCuringNormal = 1;
        public const int crCementCuringSlow = 2;

        // Cement Curing - Doubles
        public const int ipCreepCuringCT = 0;
        public const int ipCreepCuringTRef = 1;
        public const int ipCreepCuringT0 = 2;

        // Stage Data
        public const int ipStageMorph = 0;
        public const int ipStageMoveFixedNodes = 1;
        public const int ipStageRotateClusters = 2;
        public const int ipStageSetFluidLevel = 3;
        public const int ipStageReset = 4;

        // Node Response Variables
        public const int rvNodeDisplacement = 0;
        public const int rvNodeReaction = 1;

        // Beam Response Variables
        public const int ipBeamResponseSF1 = 0;
        public const int ipBeamResponseSF2 = 1;
        public const int ipBeamResponseAxial = 2;
        public const int ipBeamResponseBM1 = 3;
        public const int ipBeamResponseBM2 = 4;
        public const int ipBeamResponseTorque = 5;

        // Plate Response Variables
        public const int rvPlateForce = 0;
        public const int rvPlateMoment = 1;

        // Pipe Properties
        public const int ipPipeFlexibility = 0;
        public const int ipPipeFluidDensity = 1;
        public const int ipPipeOuterDiameter = 2;
        public const int ipPipeThickness = 3;

        // Connection Properties
        public const int ipConnectionShear1 = 0;
        public const int ipConnectionShear2 = 1;
        public const int ipConnectionAxial = 2;
        public const int ipConnectionBend1 = 3;
        public const int ipConnectionBend2 = 4;
        public const int ipConnectionTorque = 5;

        // Beam Materials
        public const int ipBeamModulus = 0;
        public const int ipBeamShear = 1;
        public const int ipBeamPoisson = 2;
        public const int ipBeamDensity = 3;
        public const int ipBeamAlpha = 4;
        public const int ipBeamViscosity = 5;
        public const int ipBeamDampingRatio = 6;
        public const int ipBeamConductivity = 7;
        public const int ipBeamSpecificHeat = 8;

        // Plate Isotropic Materials
        public const int ipPlateIsoModulus = 0;
        public const int ipPlateIsoPoisson = 1;
        public const int ipPlateIsoDensity = 2;
        public const int ipPlateIsoAlpha = 3;
        public const int ipPlateIsoViscosity = 4;
        public const int ipPlateIsoDampingRatio = 5;
        public const int ipPlateIsoConductivity = 6;
        public const int ipPlateIsoSpecificHeat = 7;

        // Brick Isotropic Materials
        public const int ipBrickIsoModulus = 0;
        public const int ipBrickIsoPoisson = 1;
        public const int ipBrickIsoDensity = 2;
        public const int ipBrickIsoAlpha = 3;
        public const int ipBrickIsoViscosity = 4;
        public const int ipBrickIsoDampingRatio = 5;
        public const int ipBrickIsoConductivity = 6;
        public const int ipBrickIsoSpecificHeat = 7;

        // Plate Orthotropic Materials
        public const int ipPlateOrthoModulus1 = 0;
        public const int ipPlateOrthoModulus2 = 1;
        public const int ipPlateOrthoModulus3 = 2;
        public const int ipPlateOrthoShear12 = 3;
        public const int ipPlateOrthoShear23 = 4;
        public const int ipPlateOrthoShear31 = 5;
        public const int ipPlateOrthoPoisson12 = 6;
        public const int ipPlateOrthoPoisson23 = 7;
        public const int ipPlateOrthoPoisson31 = 8;
        public const int ipPlateOrthoDensity = 9;
        public const int ipPlateOrthoAlpha1 = 10;
        public const int ipPlateOrthoAlpha2 = 11;
        public const int ipPlateOrthoAlpha3 = 12;
        public const int ipPlateOrthoViscosity = 13;
        public const int ipPlateOrthoDampingRatio = 14;
        public const int ipPlateOrthoConductivity1 = 15;
        public const int ipPlateOrthoConductivity2 = 16;
        public const int ipPlateOrthoSpecificHeat = 17;

        // Brick Orthotropic Materials
        public const int ipBrickOrthoModulus1 = 0;
        public const int ipBrickOrthoModulus2 = 1;
        public const int ipBrickOrthoModulus3 = 2;
        public const int ipBrickOrthoShear12 = 3;
        public const int ipBrickOrthoShear23 = 4;
        public const int ipBrickOrthoShear31 = 5;
        public const int ipBrickOrthoPoisson12 = 6;
        public const int ipBrickOrthoPoisson23 = 7;
        public const int ipBrickOrthoPoisson31 = 8;
        public const int ipBrickOrthoDensity = 9;
        public const int ipBrickOrthoAlpha1 = 10;
        public const int ipBrickOrthoAlpha2 = 11;
        public const int ipBrickOrthoAlpha3 = 12;
        public const int ipBrickOrthoViscosity = 13;
        public const int ipBrickOrthoDampingRatio = 14;
        public const int ipBrickOrthoConductivity1 = 15;
        public const int ipBrickOrthoConductivity2 = 16;
        public const int ipBrickOrthoConductivity3 = 17;
        public const int ipBrickOrthoSpecificHeat = 18;

        // Plate Anisotropic Materials

        // 0..9 ansi matrix
        public const int ipPlateAnisoTransShear1 = 10;
        public const int ipPlateAnisoTransShear2 = 11;
        public const int ipPlateAnisoTransShear3 = 12;
        public const int ipPlateAnisoDensity = 13;
        public const int ipPlateAnisoAlpha1 = 14;
        public const int ipPlateAnisoAlpha2 = 15;
        public const int ipPlateAnisoAlpha3 = 16;
        public const int ipPlateAnisoAlpha12 = 17;
        public const int ipPlateAnisoViscosity = 18;
        public const int ipPlateAnisoDampingRatio = 19;
        public const int ipPlateAnisoConductivity1 = 20;
        public const int ipPlateAnisoConductivity2 = 21;
        public const int ipPlateAnisoSpecificHeat = 22;

        // Plate User Defined Materials

        // 0..20 user matrix
        public const int ipPlateUserTransShearxz = 21;
        public const int ipPlateUserTransShearyz = 22;
        public const int ipPlateUserTransShearcz = 23;
        public const int ipPlateUserDensity = 24;
        public const int ipPlateUserAlphax = 25;
        public const int ipPlateUserAlphay = 26;
        public const int ipPlateUserAlphaxy = 27;
        public const int ipPlateUserBetax = 28;
        public const int ipPlateUserBetay = 29;
        public const int ipPlateUserBetaxy = 30;
        public const int ipPlateUserViscosity = 31;
        public const int ipPlateUserDampingRatio = 32;
        public const int ipPlateUserConductivity1 = 33;
        public const int ipPlateUserConductivity2 = 34;
        public const int ipPlateUserSpecificHeat = 35;

        // Brick Anisotropic Materials

        // 0..20 user matrix
        public const int ipBrickAnisoDensity = 21;
        public const int ipBrickAnisoAlpha1 = 22;
        public const int ipBrickAnisoAlpha2 = 23;
        public const int ipBrickAnisoAlpha3 = 24;
        public const int ipBrickAnisoAlpha12 = 25;
        public const int ipBrickAnisoAlpha23 = 26;
        public const int ipBrickAnisoAlpha31 = 27;
        public const int ipBrickAnisoViscosity = 28;
        public const int ipBrickAnisoDampingRatio = 29;
        public const int ipBrickAnisoConductivity1 = 30;
        public const int ipBrickAnisoConductivity2 = 31;
        public const int ipBrickAnisoConductivity3 = 32;
        public const int ipBrickAnisoSpecificHeat = 33;

        // Duncan-Chang Soil Materials - Integers
        public const int ipSoilDCUsePoisson = 0;
        public const int ipSoilDCSetLevel = 1;
        public const int ipSoilDCDrainedState = 2;

        // Duncan-Chang Soil Materials - Doubles
        public const int ipSoilDCModulusK = 0;
        public const int ipSoilDCModulusKUR = 1;
        public const int ipSoilDCModulusN = 2;
        public const int ipSoilDCPoisson = 3;
        public const int ipSoilDCBulkK = 4;
        public const int ipSoilDCBulkM = 5;
        public const int ipSoilDCFrictionAngle = 6;
        public const int ipSoilDCDeltaAngle = 7;
        public const int ipSoilDCCohesion = 8;
        public const int ipSoilDCFailureRatio = 9;
        public const int ipSoilDCFailureMod = 10;
        public const int ipSoilDCReferenceP = 11;
        public const int ipSoilDCDensity = 12;
        public const int ipSoilDCHorizontalRatio = 13;
        public const int ipSoilDCER = 14;
        public const int ipSoilDCConductivity = 15;
        public const int ipSoilDCSpecificHeat = 16;
        public const int ipSoilDCFluidLevel = 17;
        public const int ipSoilDCViscosity = 18;
        public const int ipSoilDCDampingRatio = 19;

        // Cam-Clay Soil Materials - Integers
        public const int ipSoilCCUsePoisson = 0;
        public const int ipSoilCCDrainedState = 1;
        public const int ipSoilCCUseOCR = 2;
        public const int ipSoilCCSetLevel = 3;

        // Cam-Clay Soil Materials - Doubles
        public const int ipSoilCCCriticalStateLine = 0;
        public const int ipSoilCCConsolidationLine = 1;
        public const int ipSoilCCSwellingLine = 2;
        public const int ipSoilCCDensity = 3;
        public const int ipSoilCCPoisson = 4;
        public const int ipSoilCCModulusG = 5;
        public const int ipSoilCCModulusB = 6;
        public const int ipSoilCCHorizontalRatio = 7;
        public const int ipSoilCCER = 8;
        public const int ipSoilCCPR = 9;
        public const int ipSoilCCPC0 = 10;
        public const int ipSoilCCOCR = 11;
        public const int ipSoilCCConductivity = 12;
        public const int ipSoilCCSpecificHeat = 13;
        public const int ipSoilCCFluidLevel = 14;
        public const int ipSoilCCViscosity = 15;
        public const int ipSoilCCDampingRatio = 16;

        // Mohr-Coulomb Soil Materials - Integers
        public const int ipSoilMCSetLevel = 0;
        public const int ipSoilMCDrainedState = 1;

        // Mohr-Coulomb Soil Materials - Doubles
        public const int ipSoilMCModulus = 0;
        public const int ipSoilMCPoisson = 1;
        public const int ipSoilMCDensity = 2;
        public const int ipSoilMCHorizontalRatio = 3;
        public const int ipSoilMCER = 4;
        public const int ipSoilMCConductivity = 5;
        public const int ipSoilMCSpecificHeat = 6;
        public const int ipSoilMCFluidLevel = 7;
        public const int ipSoilMCViscosity = 8;
        public const int ipSoilMCDampingRatio = 9;
        public const int ipSoilMCCohesion = 10;
        public const int ipSoilMCFrictionAngle = 11;

        // Drucker-Prager Soil Materials - Integers
        public const int ipSoilDPSetLevel = 0;
        public const int ipSoilDPDrainedState = 1;

        // Drucker-Prager Soil Materials - Doubles
        public const int ipSoilDPModulus = 0;
        public const int ipSoilDPPoisson = 1;
        public const int ipSoilDPDensity = 2;
        public const int ipSoilDPHorizontalRatio = 3;
        public const int ipSoilDPER = 4;
        public const int ipSoilDPConductivity = 5;
        public const int ipSoilDPSpecificHeat = 6;
        public const int ipSoilDPFluidLevel = 7;
        public const int ipSoilDPViscosity = 8;
        public const int ipSoilDPDampingRatio = 9;
        public const int ipSoilDPCohesion = 10;
        public const int ipSoilDPFrictionAngle = 11;

        // Linear Elastic Soil Materials - Integers
        public const int ipSoilLSSetLevel = 0;
        public const int ipSoilLSDrainedState = 1;

        // Linear Elastic Soil Materials - Doubles
        public const int ipSoilLSModulus = 0;
        public const int ipSoilLSPoisson = 1;
        public const int ipSoilLSDensity = 2;
        public const int ipSoilLSHorizontalRatio = 3;
        public const int ipSoilLSER = 4;
        public const int ipSoilLSConductivity = 5;
        public const int ipSoilLSSpecificHeat = 6;
        public const int ipSoilLSFluidLevel = 7;
        public const int ipSoilLSViscosity = 8;
        public const int ipSoilLSDampingRatio = 9;

        // Fluid Materials
        public const int ipFluidModulus = 0;
        public const int ipFluidPenaltyParam = 1;
        public const int ipFluidDensity = 2;
        public const int ipFluidAlpha = 3;
        public const int ipFluidViscosity = 4;
        public const int ipFluidDampingRatio = 5;
        public const int ipFluidConductivity = 6;
        public const int ipFluidSpecificHeat = 7;

        // Mohr-Coulomb, Drucker-Prager
        public const int ipFrictionAngle = 0;
        public const int ipCohesion = 1;

        // Rubber Materials
        public const int ipRubberBulk = 0;
        public const int ipRubberDensity = 1;
        public const int ipRubberAlpha = 2;
        public const int ipRubberViscosity = 3;
        public const int ipRubberDampingRatio = 4;
        public const int ipRubberConductivity = 5;
        public const int ipRubberSpecificHeat = 6;
        public const int ipRubberConstC1 = 7;

        // Load Case Types
        public const int ltLoadCase = 0;
        public const int ltSpectralCase = 2;

        // Beam Property
        public const int ipBeamPropBeamType = 0;
        public const int ipBeamPropUsePoisson = 1;
        public const int ipBeamPropSectionType = 2;
        public const int ipBeamPropMirrorType = 3;
        public const int ipBeamPropCompatibleTwist = 4;

        // Element Axis Types
        public const int axUCS = 0;
        public const int axLocal = 1;

        // Load Path Template - Integers
        public const int ipLPTColour = 0;
        public const int ipLPTNumLanes = 1;
        public const int ipLPTMultiLaneType = 2;
        public const int ipLPTTransitionLoad = 3;
        public const int lpAllSameFactors = 0;
        public const int lpAllDifferentFactors = 1;

        // Load Path Template - Doubles
        public const int ipLPTTolerance = 0;
        public const int ipLPTMinLaneWidth = 1;

        // Load Path Template Vehicle - Integers
        public const int ipLPTVehicleInstance = 0;
        public const int ipLPTVehicleDirection = 1;
        public const int lpVehicleSingleLane = 0;
        public const int lpVehicleDoubleLane = 1;
        public const int lpVehicleForward = 0;
        public const int lpVehicleBackward = 1;

        // Load Path Template Vehicle - Doubles
        public const int ipLPTVehicleVelocity = 0;
        public const int ipLPTVehicleStartTime = 1;

        // Load Path Template Forces - Integers
        public const int ipLPTMobility = 0;
        public const int ipLPTAxisSystem = 1;
        public const int ipLPTAdjacency = 2;
        public const int ipLPTCentrifugal = 3;
        public const int lpPointForceMobilityGrouped = 0;
        public const int lpPointForceMobilityFloating = 1;
        public const int lpDistrForceMobilityGrouped = 0;
        public const int lpDistrForceMobilityLeading = 1;
        public const int lpDistrForceMobilityTrailing = 2;
        public const int lpDistrForceMobilityFullLength = 3;
        public const int lpDistrForceMobilityFloating = 4;
        public const int lpAxisLocal = 0;
        public const int lpAxisGlobal = 1;

        // Load Path Templates - Integers
        public const int ipLPTLimitK1 = 0;
        public const int ipLPTLengthUnit = 1;
        public const int ipLPTForceUnit = 2;

        // Load Path Templates - Doubles
        public const int ipLPTMinK1 = 0;
        public const int ipLPTMaxK1 = 1;

        // Combined Result Files
        public const int rfCombFactors = 0;
        public const int rfCombSRSS = 1;

        // Load Path
        public const int ipLoadPathCase = 0;
        public const int ipLoadPathTemplate = 1;
        public const int ipLoadPathShape = 2;
        public const int ipLoadPathSurface = 3;
        public const int ipLoadPathTarget = 4;
        public const int ipLoadPathDivisions = 5;
        public const int ipLoadPathSet = 6;
        public const int lpShapeStraight = 0;
        public const int lpShapeCurved = 1;
        public const int lpShapeQuadratic = 2;
        public const int lpSurfaceFlat = 0;
        public const int lpSurfaceCurved = 1;
        public const int lpAnyEntity = 0;
        public const int lpEntitySet = 1;
        public const int lpBeamElement = 2;
        public const int lpPlateElement = 3;
        public const int lpBrickElement = 4;

        // Animation
        public const int ipAniCase = 0;
        public const int ipNumFrames = 1;
        public const int ipAniWidth = 2;
        public const int ipAniHeight = 3;
        public const int ipAniType = 4;
        public const int afAniSAF = 0;
        public const int afAniEXE = 1;
        public const int afAniAVI = 2;

        // Custom Result Files - NODEDISP, NODEREACT
        public const int ipNodeResFileDX = 0;
        public const int ipNodeResFileDY = 1;
        public const int ipNodeResFileDZ = 2;
        public const int ipNodeResFileRX = 3;
        public const int ipNodeResFileRY = 4;
        public const int ipNodeResFileRZ = 5;

        // Custom Result Files - NODETEMP, NODEFLUX
        public const int ipNodeResTemp = 0;

        // Custom Result Files - BEAMFORCE
        public const int ipBeamResFileSF1 = 0;
        public const int ipBeamResFileSF2 = 1;
        public const int ipBeamResFileAxial = 2;
        public const int ipBeamResFileBM1 = 3;
        public const int ipBeamResFileBM2 = 4;
        public const int ipBeamResFileTorque = 5;
        public const int kBeamResFileForceSize = 6;

        // Custom Result Files - BEAMSTRAIN
        public const int ipBeamResFileAxialStrain = 2;
        public const int ipBeamResFileCurvature1 = 3;
        public const int ipBeamResFileCurvature2 = 4;
        public const int ipBeamResFileTwist = 5;
        public const int kBeamResFileStrainSize = 6;

        // Custom Result Files - BEAMNODEREACT
        public const int ipBeamResFileFX = 0;
        public const int ipBeamResFileFY = 1;
        public const int ipBeamResFileFZ = 2;
        public const int ipBeamResFileMX = 3;
        public const int ipBeamResFileMY = 4;
        public const int ipBeamResFileMZ = 5;
        public const int kBeamResFileReactSize = 6;

        // Custom Result Files - BEAMFLUX
        public const int ipBeamResFileF = 0;
        public const int ipBeamResFileG = 1;
        public const int kBeamResFileFluxSize = 2;

        // Custom Result Files - PLATESTRESS for PlateShell - Local system
        public const int ipPlateShellResFileNxx = 0;
        public const int ipPlateShellResFileNyy = 1;
        public const int ipPlateShellResFileNxy = 2;
        public const int ipPlateShellResFileMxx = 3;
        public const int ipPlateShellResFileMyy = 4;
        public const int ipPlateShellResFileMxy = 5;
        public const int ipPlateShellResFileQxz = 6;
        public const int ipPlateShellResFileQyz = 7;
        public const int ipPlateShellResFileZMinusSxx = 8;
        public const int ipPlateShellResFileZMinusSyy = 9;
        public const int ipPlateShellResFileZMinusSxy = 10;
        public const int ipPlateShellResFileMidPlaneSxx = 11;
        public const int ipPlateShellResFileMidPlaneSyy = 12;
        public const int ipPlateShellResFileMidPlaneSxy = 13;
        public const int ipPlateShellResFileZPlusSxx = 14;
        public const int ipPlateShellResFileZPlusSyy = 15;
        public const int ipPlateShellResFileZPlusSxy = 16;
        public const int kPlateShellResFileStressSize = 17;

        // Custom Result Files - PLATESTRAIN for PlateShell - Local system
        public const int ipPlateShellResFileExx = 0;
        public const int ipPlateShellResFileEyy = 1;
        public const int ipPlateShellResFileExy = 2;
        public const int ipPlateShellResFileEzz = 3;
        public const int ipPlateShellResFileKxx = 4;
        public const int ipPlateShellResFileKyy = 5;
        public const int ipPlateShellResFileKxy = 6;
        public const int ipPlateShellResFileTxz = 7;
        public const int ipPlateShellResFileTyz = 8;
        public const int ipPlateShellResFileStoredE = 9;
        public const int ipPlateShellResFileSpentE = 10;
        public const int kPlateShellResFileStrainSize = 11;

        // Custom Result Files - PLATESTRESS for 3D Membrane - Local system
        public const int ipPlateMembraneResFileSXX = 0;
        public const int ipPlateMembraneResFileSYY = 1;
        public const int ipPlateMembraneResFileSXY = 2;
        public const int kPlateMembraneResFileStressSize = 3;

        // Custom Result Files - PLATESTRAIN for 3D Membrane - Local system
        public const int ipPlateMembraneResFileExx = 0;
        public const int ipPlateMembraneResFileEyy = 1;
        public const int ipPlateMembraneResFileExy = 2;
        public const int ipPlateMembraneResFileEzz = 3;
        public const int ipPlateMembraneResFileStoredE = 4;
        public const int ipPlateMembraneResFileSpentE = 5;
        public const int kPlateMembraneResFileStrainSize = 6;

        // Custom Result Files - PLATESTRESS for 2D Plates - Global system
        public const int ipPlate2DResFileSXX = 0;
        public const int ipPlate2DResFileSYY = 1;
        public const int ipPlate2DResFileSXY = 2;
        public const int ipPlate2DResFileSZZ = 3;
        public const int kPlate2DResFileStressSize = 4;

        // Custom Result Files - PLATESTRAIN for 2D Plates - Global system
        public const int ipPlate2DResFileEXX = 0;
        public const int ipPlate2DResFileEYY = 1;
        public const int ipPlate2DResFileEXY = 2;
        public const int ipPlate2DResFileEZZ = 3;
        public const int ipPlate2DResFileStoredE = 4;
        public const int ipPlate2DResFileSpentE = 5;
        public const int kPlate2DResFileStrainSize = 6;

        // Custom Result Files - PLATESTRESS for Axi Plates - Axisymmetric system
        public const int ipPlateAxiResFileSRR = 0;
        public const int ipPlateAxiResFileSZZ = 1;
        public const int ipPlateAxiResFileSTT = 2;
        public const int ipPlateAxiResFileSRT = 3;
        public const int kPlateAxiResFileStressSize = 4;

        // Custom Result Files - PLATESTRAIN for Axi Plates - Axisymmetric system
        public const int ipPlateAxiResFileERR = 0;
        public const int ipPlateAxiResFileEZZ = 1;
        public const int ipPlateAxiResFileETT = 2;
        public const int ipPlateAxiResFileERT = 3;
        public const int ipPlateAxiResFileStoredE = 4;
        public const int ipPlateAxiResFileSpentE = 5;
        public const int kPlateAxiResFileStrainSize = 6;

        // Custom Result Files - PLATESTRESS for Shear Panel - Local system
        public const int ipPlateShearPanelResFileNxy = 0;
        public const int kPlateShearPanelResFileStressSize = 1;

        // Custom Result Files - PLATESTRAIN for Shear Panel - Local system
        public const int ipPlateShearPanelResFileExy = 0;
        public const int ipPlateShearPanelResFileStoredE = 1;
        public const int ipPlateShearPanelResFileSpentE = 2;
        public const int kPlateShearPanelResFileStrainSize = 3;

        // Custom Result Files - PLATENODEREACT
        public const int ipPlateResFileFX = 0;
        public const int ipPlateResFileFY = 1;
        public const int ipPlateResFileFZ = 2;
        public const int ipPlateResFileMX = 3;
        public const int ipPlateResFileMY = 4;
        public const int ipPlateResFileMZ = 5;
        public const int kPlateResFileReactSize = 6;

        // Custom Result Files - PLATEFLUX
        public const int ipPlateResFileFxx = 0;
        public const int ipPlateResFileFyy = 1;
        public const int ipPlateResFileGxx = 2;
        public const int ipPlateResFileGyy = 3;
        public const int kPlateResFileFluxSize = 4;

        // Custom Result Files - BRICKSTRESS
        public const int ipBrickResFileSXX = 0;
        public const int ipBrickResFileSYY = 1;
        public const int ipBrickResFileSZZ = 2;
        public const int ipBrickResFileSXY = 3;
        public const int ipBrickResFileSYZ = 4;
        public const int ipBrickResFileSZX = 5;
        public const int kBrickResFileStressSize = 6;

        // Custom Result Files - BRICKSTRAIN
        public const int ipBrickResFileExx = 0;
        public const int ipBrickResFileEyy = 1;
        public const int ipBrickResFileEzz = 2;
        public const int ipBrickResFileExy = 3;
        public const int ipBrickResFileEyz = 4;
        public const int ipBrickResFileEzx = 5;
        public const int ipBrickResFileStoredE = 6;
        public const int ipBrickResFileSpentE = 7;
        public const int kBrickResFileStrainSize = 8;

        // Custom Result Files - BRICKNODEREACT
        public const int ipBrickResFileFX = 0;
        public const int ipBrickResFileFY = 1;
        public const int ipBrickResFileFZ = 2;
        public const int kBrickResFileReactSize = 3;

        // Custom Result Files - BRICKFLUX
        public const int ipBrickResFileFXX = 0;
        public const int ipBrickResFileFYY = 1;
        public const int ipBrickResFileFZZ = 2;
        public const int ipBrickResFileGXX = 3;
        public const int ipBrickResFileGYY = 4;
        public const int ipBrickResFileGZZ = 5;
        public const int kBrickResFileFluxSize = 6;

        // Plate Edge Attachment Direction
        public const int adPlanar = 0;
        public const int adMinusZ = 1;
        public const int adPlusZ = 2;

        // Beam Side Direction
        public const int adMinus1 = 0;
        public const int adPlus1 = 1;
        public const int adMinus2 = 2;
        public const int adPlus2 = 3;

        // GLOBAL INTEGERS
        public const int ivTessellationsFailed = 1;
        public const int ivSeamsAdded = 2;
        public const int ivIntersectionsFound = 3;
        public const int ivPlateEdgesAssigned = 4;
        public const int ivPlateEdgesNotFullyAssigned = 5;
        public const int ivAttachmentsCreated = 6;
        public const int ivAttachmentsFailed = 7;
        public const int ivNodesCreated = 8;
        public const int ivNodesDeleted = 9;
        public const int ivNodesMoved = 10;
        public const int ivBeamsChanged = 11;
        public const int ivBeamsCollapsed = 12;
        public const int ivBeamsCreated = 13;
        public const int ivBeamsDeleted = 14;
        public const int ivBeamsFailed = 15;
        public const int ivBeamsMoved = 16;
        public const int ivBeamsSplit = 17;
        public const int ivBeamsSubdivided = 18;
        public const int ivPlatesChanged = 19;
        public const int ivPlatesCollapsed = 20;
        public const int ivPlatesCreated = 21;
        public const int ivPlatesDeleted = 22;
        public const int ivPlatesFailed = 23;
        public const int ivPlatesGraded = 24;
        public const int ivPlatesMoved = 25;
        public const int ivPlatesSplit = 26;
        public const int ivPlatesSubdivided = 27;
        public const int ivBricksChanged = 28;
        public const int ivBricksCollapsed = 29;
        public const int ivBricksCreated = 30;
        public const int ivBricksDeleted = 31;
        public const int ivBricksFailed = 32;
        public const int ivBricksGraded = 33;
        public const int ivBricksMoved = 34;
        public const int ivBricksSplit = 35;
        public const int ivBricksSubdivided = 36;
        public const int ivLinksChanged = 37;
        public const int ivLinksCollapsed = 38;
        public const int ivLinksCreated = 39;
        public const int ivLinksDeleted = 40;
        public const int ivLinksMoved = 41;
        public const int ivLoadPathsChanged = 42;
        public const int ivLoadPathsCreated = 43;
        public const int ivLoadPathsMoved = 44;
        public const int ivFacesChanged = 45;
        public const int ivFacesCreated = 46;
        public const int ivFacesDeleted = 47;
        public const int ivFacesFailed = 48;
        public const int ivFacesMoved = 49;
        public const int ivEdgesMorphed = 50;
        public const int ivEdgesSubdivided = 51;
        public const int ivLoopsDeleted = 52;
        public const int ivAttributesApplied = 53;
        public const int ivUCSCreated = 54;
        public const int ivPatchPlatesCreated = 55;
        public const int ivLoadCasesCreated = 56;
        public const int ivFilletsCreated = 57;
        public const int ivFilletsFailed = 58;
        public const int ivLoftSeriesFound = 59;
        public const int ivDuplicateBeamsDeleted = 60;
        public const int ivDuplicatePlatesDeleted = 61;
        public const int ivDuplicateBricksDeleted = 62;
        public const int ivDuplicateLinksDeleted = 63;
        public const int ivStringGroupsPacked = 64;
        public const int ivClipboardNodes = 65;
        public const int ivClipboardBeams = 66;
        public const int ivClipboardPlates = 67;
        public const int ivClipboardBricks = 68;
        public const int ivClipboardLinks = 69;
        public const int ivClipboardLoadPaths = 70;
        public const int ivClipboardFaces = 71;
        public const int ivClipboardVertices = 72;
        public const int ivFacesMeshed = 73;
        public const int ivFacesPartiallyMeshed = 74;
        public const int ivFacesNotMeshed = 75;
        public const int ivSolverTerminationCode = 76;
        public const int ivSolidsMeshed = 77;
        public const int ivSolidsPartiallyMeshed = 78;
        public const int ivSolidsNotMeshed = 79;

        // GLOBAL LOGICALS
        public const int lvFormulaParseError = 1;

        // GLOBAL STRINGS
        public const int svInfluenceCombinationLog = 1;

        // SAVING VIEW-ONLY FILE
        public const int ipVoShowCoordinates = 0;
        public const int ipVoShowTEXT = 1;
        public const int ipVoShowCASES = 2;
        public const int ipVoAllowSave = 3;
        public const int ipVoShowTables = 4;
        public const int ipVoShowPlies = 5;
        public const int ipVoShowLaminates = 6;
        public const int ipVoShowPlateRC = 7;
        public const int ipVoShowCreep = 8;
        public const int ipVoShowPaths = 9;
        public const int ipVoShowCavities = 10;
        public const int ipVoShowProperties = 11;
        public const int ipVoShowLISTINGS = 12;
        public const int ipVoShowAttribSummary = 13;
        public const int ipVoShowPropSummary = 14;
        public const int ipVoShowModelSummary = 15;

        [DllImport("St7API.dll")]
        public static extern int St7SetLicenceOptions(int Mode, int MaxRetry, int RetryPause);
        [DllImport("St7API.dll")]
        public static extern int St7GetLicenceOptions(ref int Mode, ref int MaxRetry, ref int RetryPause);
        [DllImport("St7API.dll")]
        public static extern int St7Init();
        [DllImport("St7API.dll")]
        public static extern int St7Release();
        [DllImport("St7API.dll")]
        public static extern int St7Version(ref int Major, ref int Minor, ref int Point);
        [DllImport("St7API.dll")]
        public static extern int St7BuildString(StringBuilder BuildString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetListSeparatorCode(ref int Code);
        [DllImport("St7API.dll")]
        public static extern int St7GetDecimalSeparatorCode(ref int Code);
        [DllImport("St7API.dll")]
        public static extern int St7SetIconSize(int IconSize);
        [DllImport("St7API.dll")]
        public static extern int St7GetIconSize(ref int IconSize);
        [DllImport("St7API.dll")]
        public static extern int St7FileVersion(string FileName, ref int Major, ref int Minor, ref int Point);
        [DllImport("St7API.dll")]
        public static extern int St7OpenFile(int uID, string FileName, string ScratchPath);
        [DllImport("St7API.dll")]
        public static extern int St7OpenFileReadOnly(int uID, string FileName, string ScratchPath);
        [DllImport("St7API.dll")]
        public static extern int St7CloseFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7NewFile(int uID, string FileName, string ScratchPath);
        [DllImport("St7API.dll")]
        public static extern int St7SaveFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SaveFileCopy(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7SaveViewOnlyCopy(int uID, string FileName, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SaveDeformedCopy(int uID, string FileName, int ResultCase, double DispScale, int ScaleType);
        [DllImport("St7API.dll")]
        public static extern int St7SaveSubModel(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7ValidateResultFile(int uID, string FileName, ref int ValidationCode, ref int Solver);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileOpenFlag(int uID, int Index, byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFileOpenFlag(int uID, int Index, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFAFileOpenMinMass(int uID, double Mass);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFAFileOpenMinMass(int uID, ref double Mass);
        [DllImport("St7API.dll")]
        public static extern int St7OpenResultFile(int uID, string FileName, string SpectralName, int CombinationCode, ref int NumPrimary, ref int NumSecondary);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateLSACombinations(int uID, ref int NumSecondary, ref int WarningCode);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateEnvelopes(int uID, ref int NumLimitEnvelopes, ref int NumCombinationEnvelopes, ref int NumFactorsEnvelopes);
        [DllImport("St7API.dll")]
        public static extern int St7CloseResultFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetDisplayOptionsPath(string ConfigPath);
        [DllImport("St7API.dll")]
        public static extern int St7GetDisplayOptionsPath(StringBuilder ConfigPath, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLibraryPath(string LibraryPath);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryPath(StringBuilder LibraryPath, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetAPIPath(StringBuilder St7Path, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetLastError();
        [DllImport("St7API.dll")]
        public static extern int St7GetAPIErrorString(int iErr, StringBuilder ErrorString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverErrorString(int iErr, StringBuilder ErrorString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7TransformToUCS(int uID, int UCSId, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7TransformToXYZ(int uID, int UCSId, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7VectorTransformToUCS(int uID, int UCSId, double[] Position, double[] VXYZ);
        [DllImport("St7API.dll")]
        public static extern int St7VectorTransformToXYZ(int uID, int UCSId, double[] Position, double[] VXYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateUV(int uID, int PlateNum, double[] XYZ, double[] UV);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickUVW(int uID, int BrickNum, double[] XYZ, double[] UVW);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumElementResultGaussPoints(int uID, int Entity, int NumNodes, ref int NumGauss);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertElementResultNodeToGaussPoint(int uID, int Entity, int NumNodes, int NumColumns, double[] NodeDoubles, ref int NumGauss, double[] GaussDoubles);
        [DllImport("St7API.dll")]
        public static extern int St7PlateHullVolume(int uID, int ResultCase, ref double Volume);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntitySelectState(int uID, int Entity, int EntityNum, int EndEdgeFace, byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntitySelectState(int uID, int Entity, int EntityNum, int EndEdgeFace, ref byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntitySelectCount(int uID, int Entity, ref int NumSelected);
        [DllImport("St7API.dll")]
        public static extern int St7SetAllEntitySelectState(int uID, int Entity, byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntitySelectStateByProperty(int uID, int Entity, int PropertyNum, byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntitySelectStateByGroup(int uID, int Entity, int GroupID, byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntitySelectStateByEntitySet(int uID, int Entity, int SetNum, byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSelectState(int uID, int EntityNum, int FaceNum, int EdgeNum, byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSelectState(int uID, int EntityNum, int FaceNum, int EdgeNum, ref byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7SetModelWindowRefreshMode(int uID, byte AutoRefresh);
        [DllImport("St7API.dll")]
        public static extern int St7CreateModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DestroyModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetModelWindowState(int uID, ref int State);
        [DllImport("St7API.dll")]
        public static extern int St7GetModelWindowHandle(int uID, ref IntPtr Handle);
        [DllImport("St7API.dll")]
        public static extern int St7SetModelWindowParent(int uID, IntPtr Handle);
        [DllImport("St7API.dll")]
        public static extern int St7GetModelWindowParent(int uID, ref IntPtr Handle);
        [DllImport("St7API.dll")]
        public static extern int St7ShowModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowCombos(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowCombos(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowEntityPanel(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowEntityPanel(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowStatusBar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowStatusBar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableWindowStatusBar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableWindowStatusBar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowStatusBarRefreshMode(int uID, byte AutoRefresh);
        [DllImport("St7API.dll")]
        public static extern int St7RefreshWindowStatusBar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableWindowEntityInspector(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableWindowEntityInspector(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowSelectionToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowSelectionToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowCaption(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowCaption(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowViewToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowViewToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowResultsToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowResultsToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowShowHideToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowShowHideToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableWindowResize(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableWindowResize(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableWindowViewChanges(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableWindowViewChanges(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ClearModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7RedrawModel(int uID, byte Rescale);
        [DllImport("St7API.dll")]
        public static extern int St7RotateModel(int uID, double RX, double RY, double RZ);
        [DllImport("St7API.dll")]
        public static extern int St7ShowEntity(int uID, int Entity);
        [DllImport("St7API.dll")]
        public static extern int St7HideEntity(int uID, int Entity);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityVisibility(int uID, int Entity, ref byte Visible);
        [DllImport("St7API.dll")]
        public static extern int St7ShowPointAttributes(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HidePointAttributes(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetPointAttributesVisibility(int uID, ref byte Visible);
        [DllImport("St7API.dll")]
        public static extern int St7ShowEntityAttributes(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideEntityAttributes(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityAttributesVisibility(int uID, ref byte Visible);
        [DllImport("St7API.dll")]
        public static extern int St7PositionModelWindow(int uID, int Left, int Top, int Width, int Height);
        [DllImport("St7API.dll")]
        public static extern int St7GetModelWindowPosition(int uID, ref int Left, ref int Top, ref int Width, ref int Height);
        [DllImport("St7API.dll")]
        public static extern int St7GetDrawAreaSize(int uID, ref int Width, ref int Height);
        [DllImport("St7API.dll")]
        public static extern int St7GetDrawAreaPosition(int uID, ref int Left, ref int Top, ref int Width, ref int Height);
        [DllImport("St7API.dll")]
        public static extern int St7ShowProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7HideProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyVisibility(int uID, int Entity, int PropNum, ref byte Visible);
        [DllImport("St7API.dll")]
        public static extern int St7ShowGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7HideGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupVisibility(int uID, int GroupID, ref byte Visible);
        [DllImport("St7API.dll")]
        public static extern int St7SetAllEntitiesOn(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityNumVisibility(int uID, int Entity, int EntityNum, ref byte Visible);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowResultCase(int uID, int ResultCase);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowUCSCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamResultDisplay(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateResultDisplay(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickResultDisplay(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinkResultDisplay(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultSettingsStyle(int uID, int Solver, int Entity, int Quantity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultSettingsStyle(int uID, int Solver, int Entity, int Quantity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultSettingsLimits(int uID, int Solver, int Entity, int Quantity, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultSettingsLimits(int uID, int Solver, int Entity, int Quantity, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultSettingsLimitsString(int uID, int Solver, int Entity, int Quantity, string LimitsString);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultSettingsLimitsString(int uID, int Solver, int Entity, int Quantity, StringBuilder LimitsString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultSettingsLegend(int uID, int Solver, int Entity, int Quantity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultSettingsLegend(int uID, int Solver, int Entity, int Quantity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultSettingsLegendFont(int uID, int Solver, int Entity, int Quantity, string FontName, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultSettingsLegendFont(int uID, int Solver, int Entity, int Quantity, StringBuilder FontName, int MaxStringLen, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultSettingsDiagram(int uID, int Solver, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultSettingsDiagram(int uID, int Solver, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultSettingsDiagramColours(int uID, int Solver, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultSettingsDiagramColours(int uID, int Solver, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowColours(int uID, int WindowMode, int SolidColour, int GradientColour);
        [DllImport("St7API.dll")]
        public static extern int St7GetWindowColours(int uID, int WindowMode, ref int SolidColour, ref int GradientColour);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowBackgroundMode(int uID, int WindowMode, int BackgroundMode);
        [DllImport("St7API.dll")]
        public static extern int St7GetWindowBackgroundMode(int uID, int WindowMode, ref int BackgroundMode);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowImageLocation(int uID, int ImageLocation);
        [DllImport("St7API.dll")]
        public static extern int St7GetWindowImageLocation(int uID, ref int ImageLocation);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowImageSize(int uID, int ImageSize);
        [DllImport("St7API.dll")]
        public static extern int St7GetWindowImageSize(int uID, ref int ImageSize);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowImageFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetWindowImageFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNumericOptions(int uID, int Mode, int Style, int Digits, int Exponent, double Zero);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumericOptions(int uID, int Mode, ref int Style, ref int Digits, ref int Exponent, ref double Zero);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeStyle(int uID, int Style);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeShowHideSelected(int uID, byte UseSettings);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeSize(int uID, int Size);
        [DllImport("St7API.dll")]
        public static extern int St7SetFreeNodes(int uID, int Style);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeLabelStyle(int uID, int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeStyle(int uID, ref int Style);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeShowHideSelected(int uID, ref byte UseSettings);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeSize(int uID, ref int Size);
        [DllImport("St7API.dll")]
        public static extern int St7GetFreeNodes(int uID, ref int Style);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeLabelStyle(int uID, ref int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamStyle(int uID, int Style);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCableAsLine(int uID, byte AsLine);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamFill(int uID, int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamOutline(int uID, int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamLineThickness(int uID, int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamLabelStyle(int uID, int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamLighting(int uID, byte FillLighting, byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamNRef(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamOffsetNodes(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamMoveToOffset(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDrawAxes(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSpringCoils(int uID, int Coils);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSpringAspect(int uID, int Aspect);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamRoundFacets(int uID, int Facets);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSlices(int uID, int Slices);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamShrink(int uID, int Shrink);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamStyle(int uID, ref int Style);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamCableAsLine(int uID, ref byte AsLine);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamFill(int uID, ref int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamOutline(int uID, ref int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamLineThickness(int uID, ref int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamLabelStyle(int uID, ref int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamLighting(int uID, ref byte FillLighting, ref byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamNRef(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamOffsetNodes(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamMoveToOffset(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamDrawAxes(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSpringCoils(int uID, ref int Coils);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSpringAspect(int uID, ref int Aspect);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamRoundFacets(int uID, ref int Facets);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSlices(int uID, ref int Slices);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamShrink(int uID, ref int Shrink);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateStyle(int uID, int Style);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFill(int uID, int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateOutline(int uID, int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateLineThickness(int uID, int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateLabelStyle(int uID, int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateLighting(int uID, byte FillLighting, byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateOffsetNodes(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateMoveToOffset(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateDrawAxes(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateShrink(int uID, int Shrink);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceNodes(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateAxisLayer(int uID, int Layer);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateOutlineMode(int uID, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateAverageNormals(int uID, byte AverageNormals);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateAverageNormalsAngle(int uID, int Angle);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateStyle(int uID, ref int Style);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFill(int uID, ref int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateOutline(int uID, ref int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateLineThickness(int uID, ref int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateLabelStyle(int uID, ref int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateLighting(int uID, ref byte FillLighting, ref byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateOffsetNodes(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateMoveToOffset(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateDrawAxes(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateShrink(int uID, ref int Shrink);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceNodes(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateAxisLayer(int uID, ref int Layer);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateOutlineMode(int uID, ref int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateAverageNormals(int uID, ref byte AverageNormals);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateAverageNormalsAngle(int uID, ref int Angle);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickFill(int uID, int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickOutline(int uID, int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickLineThickness(int uID, int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickLabelStyle(int uID, int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickLighting(int uID, byte FillLighting, byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickDrawAxes(int uID, byte Show1, byte Show2, byte Show3);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickShrink(int uID, int Shrink);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickOutlineMode(int uID, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickWireframeAll(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFill(int uID, ref int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickOutline(int uID, ref int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickLineThickness(int uID, ref int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickLabelStyle(int uID, ref int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickLighting(int uID, ref byte FillLighting, ref byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickDrawAxes(int uID, ref byte Show1, ref byte Show2, ref byte Show3);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickShrink(int uID, ref int Shrink);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickOutlineMode(int uID, ref int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickWireframeAll(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinkOutline(int uID, int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinkLineThickness(int uID, int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinkLabelStyle(int uID, int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinkColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinkDashes(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkOutline(int uID, ref int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkLineThickness(int uID, ref int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkLabelStyle(int uID, ref int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkDashes(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexStyle(int uID, int Style);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexShowHideSelected(int uID, byte UseSettings);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexSize(int uID, int Size);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexLabelStyle(int uID, int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetFreeVertices(int uID, int Style);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexStyle(int uID, ref int Style);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexShowHideSelected(int uID, ref byte UseSettings);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexSize(int uID, ref int Size);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexLabelStyle(int uID, ref int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetFreeVertices(int uID, ref int Style);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceFillStyle(int uID, int Style);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceFill(int uID, int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceOutline(int uID, int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceLabelStyle(int uID, int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceLighting(int uID, byte FillLighting, byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceLineThickness(int uID, int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceWireThickness(int uID, int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceWireDensity(int uID, int Density);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceNormalsSize(int uID, int Size);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceNIEdges(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceControlPoints(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetFaceNormals(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceFillStyle(int uID, ref int Style);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceFill(int uID, ref int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceOutline(int uID, ref int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceLabelStyle(int uID, ref int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceLighting(int uID, ref byte FillLighting, ref byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceLineThickness(int uID, ref int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceWireThickness(int uID, ref int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceWireDensity(int uID, ref int Density);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceNormalsSize(int uID, ref int Size);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceNIEdges(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceControlPoints(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetFaceNormals(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetPathFill(int uID, int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7SetPathOutline(int uID, int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7SetPathLabelStyle(int uID, int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7SetPathColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetPathLighting(int uID, byte FillLighting, byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7SetPathLineThickness(int uID, int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7SetPathDivisions(int uID, byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7GetPathFill(int uID, ref int Fill);
        [DllImport("St7API.dll")]
        public static extern int St7GetPathOutline(int uID, ref int Outline);
        [DllImport("St7API.dll")]
        public static extern int St7GetPathLabelStyle(int uID, ref int LabelStyle);
        [DllImport("St7API.dll")]
        public static extern int St7GetPathColours(int uID, int[] Colours, int NumCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetPathLighting(int uID, ref byte FillLighting, ref byte LineLighting);
        [DllImport("St7API.dll")]
        public static extern int St7GetPathLineThickness(int uID, ref int Thickness);
        [DllImport("St7API.dll")]
        public static extern int St7GetPathDivisions(int uID, ref byte Show);
        [DllImport("St7API.dll")]
        public static extern int St7SetAttributeDisplay(int uID, int AttributeOrd, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetAttributeDisplay(int uID, int AttributeOrd, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityFont(int uID, int Entity, string FontName, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityFont(int uID, int Entity, StringBuilder FontName, int MaxStringLen, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityContourFile(int uID, int Entity, int FileType, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityContourFile(int uID, int Entity, ref int FileType, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityContourIndex(int uID, int Entity, int Index);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityContourIndex(int uID, int Entity, ref int Index);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityContourSettingsStyle(int uID, int Entity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityContourSettingsStyle(int uID, int Entity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityContourSettingsLimits(int uID, int Entity, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityContourSettingsLimits(int uID, int Entity, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityContourSettingsLimitsString(int uID, int Entity, string LimitsString);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityContourSettingsLimitsString(int uID, int Entity, StringBuilder LimitsString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityContourSettingsLegend(int uID, int Entity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityContourSettingsLegend(int uID, int Entity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityContourSettingsLegendFont(int uID, int Entity, string FontName, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityContourSettingsLegendFont(int uID, int Entity, StringBuilder FontName, int MaxStringLen, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetModelDefaults(int uID, int Options, int Mode, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetDisplacementScale(int uID, double DispScale, int ScaleType);
        [DllImport("St7API.dll")]
        public static extern int St7GetDisplacementScale(int uID, ref double DispScale, ref int ScaleType);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteAllGraphs(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ImportST7(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportIGES(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportACIS(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportSTEP(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportRhino(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportDXF(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportSTL(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportNASTRAN(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportANSYS(int uID, string FileName, string LoadCaseFilePath, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportSTAAD(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportSAP2000(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportImage(int uID, string FileName, int ImageType, int Width, int Height);
        [DllImport("St7API.dll")]
        public static extern int St7ExportImageToClipboard(int uID, int Width, int Height);
        [DllImport("St7API.dll")]
        public static extern int St7ExportST7(int uID, string FileName, int Mode, int ExportFormat);
        [DllImport("St7API.dll")]
        public static extern int St7ExportIGES(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportSTEP(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportDXF(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportSTL(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportNASTRAN(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportANSYS(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7PlayAnimationFile(string FileName, ref int aHandle);
        [DllImport("St7API.dll")]
        public static extern int St7CreateAnimation(int uID, int[] Integers, ref int aHandle);
        [DllImport("St7API.dll")]
        public static extern int St7CreateAnimationEmbedded(int uID, IntPtr pHandle, int[] Integers, ref int aHandle);
        [DllImport("St7API.dll")]
        public static extern int St7CreateAnimationFile(int uID, int[] Integers, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7CloseAnimation(int aHandle);
        [DllImport("St7API.dll")]
        public static extern int St7SetAnimationCase(int uID, int CaseNum, byte Active);
        [DllImport("St7API.dll")]
        public static extern int St7GetAnimationCase(int uID, int CaseNum, ref byte Active);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotal(int uID, int Entity, ref int Total);
        [DllImport("St7API.dll")]
        public static extern int St7SetCableDroopDirection(int uID, int Direction);
        [DllImport("St7API.dll")]
        public static extern int St7GetCableDroopDirection(int uID, ref int Direction);
        [DllImport("St7API.dll")]
        public static extern int St7SetTitle(int uID, int TitleType, string TitleString);
        [DllImport("St7API.dll")]
        public static extern int St7GetTitle(int uID, int TitleType, StringBuilder TitleString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7AddComment(int uID, string CommentString);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumComments(int uID, ref int NumComments);
        [DllImport("St7API.dll")]
        public static extern int St7SetComment(int uID, int Comment, string CommentString);
        [DllImport("St7API.dll")]
        public static extern int St7GetComment(int uID, int Comment, StringBuilder CommentString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteComment(int uID, int Comment);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateNumPlies(int uID, int PlateNum, ref int NumPlies);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamAxisSystemInitial(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamAxisSystemBirth(int uID, int BeamNum, int ResultCase, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamAxisSystemGNL(int uID, int BeamNum, int ResultCase, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateAxisSystemInitial(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateAxisSystemBirth(int uID, int PlateNum, int ResultCase, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateAxisSystemGNL(int uID, int PlateNum, int ResultCase, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFaceAxisSystemInitial(int uID, int BrickNum, int FaceNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFaceAxisSystemBirth(int uID, int BrickNum, int FaceNum, int ResultCase, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFaceAxisSystemGNL(int uID, int BrickNum, int FaceNum, int ResultCase, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumBXSLoopsAndPlates(int uID, int PropNum, ref int NumLoops, ref int NumPlates);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumBXSLoopPoints(int uID, int PropNum, int LoopNum, ref int NumPoints);
        [DllImport("St7API.dll")]
        public static extern int St7GetBXSLoop(int uID, int PropNum, int LoopNum, int MaxPoints, ref int NumPoints, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBXSLoopType(int uID, int PropNum, int LoopNum, ref int LoopType);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateBXS(int uID, string BXSName, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7NewLoadCase(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7NewFreedomCase(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadCase(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumFreedomCase(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetFreedomCaseName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetFreedomCaseName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseDefaults(int uID, int CaseNum, double[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseDefaults(int uID, int CaseNum, double[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7SetFreedomCaseDefaults(int uID, int CaseNum, int[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7GetFreedomCaseDefaults(int uID, int CaseNum, int[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseType(int uID, int CaseNum, int CaseType);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseType(int uID, int CaseNum, ref int CaseType);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseGravityDir(int uID, int CaseNum, int GravDir);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseGravityDir(int uID, int CaseNum, ref int GravDir);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseGravity(int uID, int CaseNum, double Gravity);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseGravity(int uID, int CaseNum, ref double Gravity);
        [DllImport("St7API.dll")]
        public static extern int St7SetSeismicCaseNSMassOption(int uID, int CaseNum, byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetSeismicCaseNSMassOption(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetFreedomCaseType(int uID, int CaseNum, int CaseType);
        [DllImport("St7API.dll")]
        public static extern int St7GetFreedomCaseType(int uID, int CaseNum, ref int CaseType);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseMassOption(int uID, int CaseNum, byte SMass, byte NSMass);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseMassOption(int uID, int CaseNum, ref byte SMass, ref byte NSMass);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumSeismicCase(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetSeismicCaseDefaults(int uID, int CaseNum, double[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7GetSeismicCaseDefaults(int uID, int CaseNum, double[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7SetUCS(int uID, int UCSId, int UCSType, double[] UCSDoubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetUCS(int uID, int UCSId, ref int UCSType, double[] UCSDoubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteUCS(int uID, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7SetUCSName(int uID, int UCSId, string UCSName);
        [DllImport("St7API.dll")]
        public static extern int St7GetUCSName(int uID, int UCSId, StringBuilder UCSName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetUCSID(int uID, int Index, ref int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumUCS(int uID, ref int NumUCS);
        [DllImport("St7API.dll")]
        public static extern int St7SetGroupIDName(int uID, int ID, string GName);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupIDName(int uID, int ID, StringBuilder GName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGroups(int uID, ref int NumGroups);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupByIndex(int uID, int Index, StringBuilder GName, int MaxStringLen, ref int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7NewChildGroup(int uID, int ParentID, string GName, ref int ChildID);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupParent(int uID, int GroupID, ref int ParentID);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupChild(int uID, int GroupID, ref int ChildID);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupSibling(int uID, int GroupID, ref int SiblingID);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7SetGroupColour(int uID, int GroupID, int GroupCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupColour(int uID, int GroupID, ref int GroupCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetDefaultGroupID(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetDefaultGroupID(int uID, ref int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7AddStage(int uID, string StageName, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7InsertStage(int uID, int Stage, string StageName, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteStage(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumStages(int uID, ref int NumStages);
        [DllImport("St7API.dll")]
        public static extern int St7SetStageName(int uID, int Stage, string StageName);
        [DllImport("St7API.dll")]
        public static extern int St7GetStageName(int uID, int Stage, StringBuilder StageName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetStageData(int uID, int Stage, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetStageData(int uID, int Stage, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetStageFluidLevel(int uID, int Stage, double Level);
        [DllImport("St7API.dll")]
        public static extern int St7GetStageFluidLevel(int uID, int Stage, ref double Level);
        [DllImport("St7API.dll")]
        public static extern int St7EnableStageGroup(int uID, int Stage, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableStageGroup(int uID, int Stage, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetStageGroupState(int uID, int Stage, int GroupID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7NewEntitySet(int uID, string SetName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteEntitySet(int uID, int SetNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntitySetName(int uID, int SetNum, string SetName);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntitySetName(int uID, int SetNum, StringBuilder SetName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntitySetEntityState(int uID, int Entity, int EntityNum, int SetNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7ShowEntitySet(int uID, int SetNum);
        [DllImport("St7API.dll")]
        public static extern int St7HideEntitySet(int uID, int SetNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntitySetVisibility(int uID, int SetNum, ref byte Visible);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumEntitySets(int uID, ref int NumSets);
        [DllImport("St7API.dll")]
        public static extern int St7AddSelectedToEntitySet(int uID, int Entity, int SetNum);
        [DllImport("St7API.dll")]
        public static extern int St7RemoveSelectedFromEntitySet(int uID, int Entity, int SetNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetUnits(int uID, int[] Units);
        [DllImport("St7API.dll")]
        public static extern int St7GetUnits(int uID, int[] Units);
        [DllImport("St7API.dll")]
        public static extern int St7SetRCUnits(int uID, int AreaUnit, int LengthUnit);
        [DllImport("St7API.dll")]
        public static extern int St7GetRCUnits(int uID, ref int AreaUnit, ref int LengthUnit);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertUnits(int uID, int[] Units);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeXYZ(int uID, int NodeNum, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeXYZ(int uID, int NodeNum, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeUCS(int uID, int NodeNum, int UCSId, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeUCS(int uID, int NodeNum, int UCSId, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7SetElementConnection(int uID, int Entity, int EntityNum, int PropNum, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementConnection(int uID, int Entity, int EntityNum, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementData(int uID, int Entity, int EntityNum, int ResultCase, ref double EltData);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementDataGNL(int uID, int Entity, int EntityNum, int ResultCase, ref double EltData);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementDataDeformed(int uID, int Entity, int EntityNum, int ResultCase, double DispScale, ref double EltData);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementCentroid(int uID, int Entity, int EntityNum, int FaceEdgeNum, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementCentroidAtBirth(int uID, int Entity, int EntityNum, int FaceEdgeNum, int ResultCase, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementCoordinatesAtBirth(int uID, int Entity, int EntityNum, int ResultCase, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7SetMasterSlaveLink(int uID, int LinkNum, int UCSId, int[] Connection, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetMasterSlaveLink(int uID, int LinkNum, ref int UCSId, int[] Connection, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetSectorSymmetryLink(int uID, int LinkNum, int Axis, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetSectorSymmetryLink(int uID, int LinkNum, ref int Axis, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetCouplingLink(int uID, int LinkNum, int Couple, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetCouplingLink(int uID, int LinkNum, ref int Couple, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetPinnedLink(int uID, int LinkNum, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetPinnedLink(int uID, int LinkNum, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetRigidLink(int uID, int LinkNum, int UCSId, int Plane, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetRigidLink(int uID, int LinkNum, ref int UCSId, ref int Plane, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetShrinkLink(int uID, int LinkNum, int[] Connection, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetShrinkLink(int uID, int LinkNum, int[] Connection, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetTwoPointLink(int uID, int LinkNum, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTwoPointLink(int uID, int LinkNum, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetAttachmentLink(int uID, int LinkNum, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetAttachmentLink(int uID, int LinkNum, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetInterpolatedMultiPointLink(int uID, int LinkNum, int NumNodes, int Couple, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetInterpolatedMultiPointLink(int uID, int LinkNum, int MaxNodes, ref int NumNodes, ref int Couple, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetMasterSlaveMultiPointLink(int uID, int LinkNum, int NumNodes, int UCSId, int DoFBits, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetMasterSlaveMultiPointLink(int uID, int LinkNum, int MaxNodes, ref int NumNodes, ref int UCSId, ref int DoFBits, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetPinnedMultiPointLink(int uID, int LinkNum, int NumNodes, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetPinnedMultiPointLink(int uID, int LinkNum, int MaxNodes, ref int NumNodes, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetRigidMultiPointLink(int uID, int LinkNum, int NumNodes, int UCSId, int Axis, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetRigidMultiPointLink(int uID, int LinkNum, int MaxNodes, ref int NumNodes, ref int UCSId, ref int Axis, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetUserDefinedMultiPointLink(int uID, int LinkNum, int NumNodes, int CaseNum, double CFactor, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetUserDefinedMultiPointLink(int uID, int LinkNum, int MaxNodes, ref int NumNodes, ref int CaseNum, ref double CFactor, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetReactionMultiPointLink(int uID, int LinkNum, int NumNodes, int SetNum, int[] Connection, double[] Origin);
        [DllImport("St7API.dll")]
        public static extern int St7GetReactionMultiPointLink(int uID, int LinkNum, int MaxNodes, ref int NumNodes, ref int SetNum, int[] Connection, double[] Origin);
        [DllImport("St7API.dll")]
        public static extern int St7SetReactionMultiPointLinkAttributes(int uID, int LinkNum, int SetNum, double[] Origin);
        [DllImport("St7API.dll")]
        public static extern int St7GetReactionMultiPointLinkAttributes(int uID, int LinkNum, ref int SetNum, double[] Origin);
        [DllImport("St7API.dll")]
        public static extern int St7SetInterpolatedMultiPointLinkAttributes(int uID, int LinkNum, int Couple);
        [DllImport("St7API.dll")]
        public static extern int St7GetInterpolatedMultiPointLinkAttributes(int uID, int LinkNum, ref int Couple);
        [DllImport("St7API.dll")]
        public static extern int St7SetMasterSlaveMultiPointLinkAttributes(int uID, int LinkNum, int UCSId, int DoFBits);
        [DllImport("St7API.dll")]
        public static extern int St7GetMasterSlaveMultiPointLinkAttributes(int uID, int LinkNum, ref int UCSId, ref int DoFBits);
        [DllImport("St7API.dll")]
        public static extern int St7SetRigidMultiPointLinkAttributes(int uID, int LinkNum, int UCSId, int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7GetRigidMultiPointLinkAttributes(int uID, int LinkNum, ref int UCSId, ref int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumMultiPointLinkNodes(int uID, int LinkNum, ref int NumNodes);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkType(int uID, int LinkNum, ref int LinkType);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexXYZ(int uID, int VertexNum, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceOuterLoops(int uID, int FaceNum, int[] OuterLoops);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGeometryFaceCavityLoops(int uID, int FaceNum, ref int NumCavityLoops);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceCavityLoops(int uID, int FaceNum, int MaxCavityLoops, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGeometryFaceEdges(int uID, int FaceNum, ref int NumEdges);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceEdges(int uID, int FaceNum, int MaxEdges, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGeometryLoopEdges(int uID, int LoopNum, ref int NumEdges);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryLoopEdges(int uID, int LoopNum, int MaxEdges, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeLength(int uID, int EdgeNum, ref double EdgeLength);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGeometryFaceCoedges(int uID, int FaceNum, ref int NumCoedges);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceCoedges(int uID, int FaceNum, int MaxCoedges, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGeometryLoopCoedges(int uID, int LoopNum, ref int NumCoedges);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryLoopCoedges(int uID, int LoopNum, int MaxCoedges, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeEdge(int uID, int CoedgeNum, ref int EdgeNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGeometryFaceVertices(int uID, int FaceNum, ref int NumVertices);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceVertices(int uID, int FaceNum, int MaxVertices, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeVertices(int uID, int EdgeNum, int[] EdgeVertices);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceSurface(int uID, int FaceNum, ref int SurfaceNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometrySurfaceType(int uID, int SurfaceNum, ref int SurfaceType);
        [DllImport("St7API.dll")]
        public static extern int St7InvalidateGeometryFace(int uID, int FaceNum);
        [DllImport("St7API.dll")]
        public static extern int St7InvalidateGeometryFaceCavityLoopID(int uID, int FaceNum, int LoopNum);
        [DllImport("St7API.dll")]
        public static extern int St7InvalidateGeometryFaceCavityLoopIndex(int uID, int FaceNum, int LoopIndex);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteInvalidGeometry(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetCleanGeometryOptions(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCleanGeometryOptions(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7CleanGeometry(int uID, ref int ChangesMade, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometrySize(int uID, ref double Size);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPath(int uID, int LoadPathID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPath(int uID, int LoadPathID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPath(int uID, int LoadPathID);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeID(int uID, int NodeNum, int NodeID);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeRestraint6(int uID, int NodeNum, int CaseNum, int UCSId, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeForce3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeMoment3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeTemperature1(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeTemperatureType1(int uID, int NodeNum, int CaseNum, int TType);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeTemperatureTable(int uID, int NodeNum, int CaseNum, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeKTranslation3F(int uID, int NodeNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeKRotation3F(int uID, int NodeNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeTMass1(int uID, int NodeNum, double Mass);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeTMass3(int uID, int NodeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeRMass3(int uID, int NodeNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeNSMass5ID(int uID, int NodeNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeKDamping3F(int uID, int NodeNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeHeatSource1(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeHeatSourceTables(int uID, int NodeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeInitialVelocity3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeAcceleration3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeResponse(int uID, int NodeNum, int CaseNum, int ResponseType, int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeID(int uID, int NodeNum, ref int NodeID);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeRestraint6(int uID, int NodeNum, int CaseNum, ref int UCSId, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeForce3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeMoment3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeTemperature1(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeTemperatureType1(int uID, int NodeNum, int CaseNum, ref int TType);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeTemperatureTable(int uID, int NodeNum, int CaseNum, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeKTranslation3F(int uID, int NodeNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeKRotation3F(int uID, int NodeNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeTMass3(int uID, int NodeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeRMass3(int uID, int NodeNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeNSMass5ID(int uID, int NodeNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeKDamping3F(int uID, int NodeNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeHeatSource1(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeHeatSourceTables(int uID, int NodeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeInitialVelocity3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeAcceleration3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeResponse(int uID, int NodeNum, int CaseNum, int ResponseType, ref int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamID(int uID, int BeamNum, int BeamID);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamReferenceAngle1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamConnectionUCS(int uID, int BeamNum, int BeamEnd, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamTaper2(int uID, int BeamNum, int TaperAxis, int TaperType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamOffset2(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSupport2(int uID, int BeamNum, int Direction, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionFactor7(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamTRelease3(int uID, int BeamNum, int BeamEnd, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamRRelease3(int uID, int BeamNum, int BeamEnd, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCableFreeLength1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamRadius1(int uID, int BeamNum, int BeamDir, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPipePressure2AF(int uID, int BeamNum, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPipeTemperature2OT(int uID, int BeamNum, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamStringGroup1(int uID, int BeamNum, int StringID);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPreLoad1(int uID, int BeamNum, int CaseNum, int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamTempGradient2(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPreCurvature2(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPointForcePrincipal4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPointForceGlobal4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPointMomentPrincipal4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPointMomentGlobal4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDistributedForcePrincipal6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int DLType, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDistributedForceGlobal6ID(int uID, int BeamNum, int BeamDir, int ProjectFlag, int CaseNum, int DLType, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDistributedMomentPrincipal6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int DLType, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamNSMass10ID(int uID, int BeamNum, int CaseNum, int DLType, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamConvection2(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamConvectionTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamRadiation2(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamRadiationTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamFlux1(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamFluxTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamHeatSource1(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamHeatSourceTables(int uID, int BeamNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamResponse(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCreepLoadingAge1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamEndAttachment1(int uID, int BeamNum, int BeamEnd, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSideAttachment1(int uID, int BeamNum, int BeamEnd, int Direction, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamID(int uID, int BeamNum, ref int BeamID);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamReferenceAngle1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamConnectionUCS(int uID, int BeamNum, int BeamEnd, ref int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamTaper2(int uID, int BeamNum, int TaperAxis, ref int TaperType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamOffset2(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSupport2(int uID, int BeamNum, int Direction, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionFactor7(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamTRelease3(int uID, int BeamNum, int BeamEnd, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamRRelease3(int uID, int BeamNum, int BeamEnd, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamCableFreeLength1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamRadius1(int uID, int BeamNum, ref int BeamDir, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPipePressure2AF(int uID, int BeamNum, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPipeTemperature2OT(int uID, int BeamNum, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamStringGroup1(int uID, int BeamNum, ref int StringID);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPreLoad1(int uID, int BeamNum, int CaseNum, ref int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamTempGradient2(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPreCurvature2(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPointForcePrincipal4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPointForceGlobal4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPointMomentPrincipal4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPointMomentGlobal4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamDistributedForcePrincipal6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int ID, ref int DLType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamDistributedForceGlobal6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int ID, ref int ProjectFlag, ref int DLType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamDistributedMomentPrincipal6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int ID, ref int DLType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamNSMass10ID(int uID, int BeamNum, int CaseNum, int ID, ref int DLType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamConvection2(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamConvectionTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamRadiation2(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamRadiationTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamFlux1(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamFluxTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamHeatSource1(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamHeatSourceTables(int uID, int BeamNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResponse(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamCreepLoadingAge1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamEndAttachment1(int uID, int BeamNum, int BeamEnd, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSideAttachment1(int uID, int BeamNum, int BeamEnd, int Direction, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateID(int uID, int PlateNum, int PlateID);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateXAngle1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateThickness2(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateOffset1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeSupport4(int uID, int PlateNum, int EdgeNum, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceSupport4(int uID, int PlateNum, int Surface, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeRelease1(int uID, int PlateNum, int EdgeNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePreLoad3(int uID, int PlateNum, int CaseNum, int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePreCurvature2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateTempGradient1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePointForce6(int uID, int PlateNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePointMoment6(int uID, int PlateNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgePressure1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgePressure3(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeShear1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeTransverseShear1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateNormalPressure2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateGlobalPressure3S(int uID, int PlateNum, int Surface, int ProjectFlag, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateShear2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateNSMass5ID(int uID, int PlateNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeConvection2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeConvectionTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeRadiation2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeRadiationTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFlux1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFluxTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceConvection2(int uID, int PlateNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceConvectionTables(int uID, int PlateNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceRadiation2(int uID, int PlateNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceRadiationTables(int uID, int PlateNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateHeatSource1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateHeatSourceTables(int uID, int PlateNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilStress2(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilRatio2(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateResponse(int uID, int PlateNum, int CaseNum, int ResponseType, int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateLoadPatch4(int uID, int PlateNum, int PatchType, int EdgeBits, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateReinforcement2(int uID, int PlateNum, int LayoutID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateCreepLoadingAge1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeAttachment1(int uID, int PlateNum, int EdgeNum, int Direction, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceAttachment1(int uID, int PlateNum, int Surface, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSectionFactor10(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateCavityFluid(int uID, int PlateNum, int Surface, int CavityID);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateID(int uID, int PlateNum, ref int PlateID);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateXAngle1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateThickness2(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateOffset1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeSupport4(int uID, int PlateNum, int EdgeNum, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceSupport4(int uID, int PlateNum, int Surface, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeRelease1(int uID, int PlateNum, int EdgeNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePreLoad3(int uID, int PlateNum, int CaseNum, ref int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePreCurvature2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateTempGradient1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePointForce6(int uID, int PlateNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePointMoment6(int uID, int PlateNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgePressure1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgePressure3(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeShear1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeTransverseShear1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateNormalPressure2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateGlobalPressure3S(int uID, int PlateNum, int Surface, int CaseNum, ref int ProjectFlag, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateShear2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateNSMass5ID(int uID, int PlateNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeConvection2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeConvectionTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeRadiation2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeRadiationTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFlux1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFluxTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceConvection2(int uID, int PlateNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceConvectionTables(int uID, int PlateNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceRadiation2(int uID, int PlateNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceRadiationTables(int uID, int PlateNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateHeatSource1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateHeatSourceTables(int uID, int PlateNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilStress2(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilRatio2(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResponse(int uID, int PlateNum, int CaseNum, int ResponseType, ref int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateLoadPatch4(int uID, int PlateNum, ref int PatchType, ref int EdgeBits, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateReinforcement2(int uID, int PlateNum, ref int LayoutID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateCreepLoadingAge1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeAttachment1(int uID, int PlateNum, int EdgeNum, int Direction, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceAttachment1(int uID, int PlateNum, int Surface, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSectionFactor10(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateCavityFluid(int uID, int PlateNum, int Surface, ref int CavityID);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickID(int uID, int BrickNum, int BrickID);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickLocalAxes1(int uID, int BrickNum, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSupport4(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickPreLoad3(int uID, int BrickNum, int CaseNum, int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickPointForce6(int uID, int BrickNum, int FaceNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickNormalPressure1(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickGlobalPressure3(int uID, int BrickNum, int FaceNum, int ProjectFlag, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickShear2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickNSMass5ID(int uID, int BrickNum, int FaceNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickConvection2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickConvectionTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickRadiation2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickRadiationTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickFlux1(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickFluxTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickHeatSource1(int uID, int BrickNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickHeatSourceTables(int uID, int BrickNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilStress2(int uID, int BrickNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilRatio2(int uID, int BrickNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickResponse(int uID, int BrickNum, int CaseNum, int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickCreepLoadingAge1(int uID, int BrickNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickFaceAttachment1(int uID, int BrickNum, int FaceNum, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickCavityFluid(int uID, int BrickNum, int FaceNum, int CavityID);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickID(int uID, int BrickNum, ref int BrickID);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickLocalAxes1(int uID, int BrickNum, ref int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSupport4(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickPreLoad3(int uID, int BrickNum, int CaseNum, ref int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickPointForce6(int uID, int BrickNum, int FaceNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickNormalPressure1(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickGlobalPressure3(int uID, int BrickNum, int FaceNum, int CaseNum, ref int ProjectFlag, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickShear2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickNSMass5ID(int uID, int BrickNum, int FaceNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickConvection2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickConvectionTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickRadiation2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickRadiationTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFlux1(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFluxTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickHeatSource1(int uID, int BrickNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickHeatSourceTables(int uID, int BrickNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilStress2(int uID, int BrickNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilRatio2(int uID, int BrickNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickResponse(int uID, int BrickNum, int CaseNum, ref int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickCreepLoadingAge1(int uID, int BrickNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFaceAttachment1(int uID, int BrickNum, int FaceNum, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickCavityFluid(int uID, int BrickNum, int FaceNum, ref int CavityID);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinkID(int uID, int LinkNum, int LinkID);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkID(int uID, int LinkNum, ref int LinkID);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexType(int uID, int VertexNum, int VertexType);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexID(int uID, int VertexNum, int VertexID);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexMeshSize1(int uID, int VertexNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexRestraint6(int uID, int VertexNum, int CaseNum, int UCSId, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexForce3(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexMoment3(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexTemperature1(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexTemperatureType1(int uID, int VertexNum, int CaseNum, int TType);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexTemperatureTable(int uID, int VertexNum, int CaseNum, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexKTranslation3F(int uID, int VertexNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexKRotation3F(int uID, int VertexNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexTMass1(int uID, int VertexNum, double Mass);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexTMass3(int uID, int VertexNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexRMass3(int uID, int VertexNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexNSMass5ID(int uID, int VertexNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexKDamping3F(int uID, int VertexNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexHeatSource1(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexHeatSourceTables(int uID, int VertexNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexType(int uID, int VertexNum, ref int VertexType);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexID(int uID, int VertexNum, ref int VertexID);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexMeshSize1(int uID, int VertexNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexRestraint6(int uID, int VertexNum, int CaseNum, ref int UCSId, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexForce3(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexMoment3(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexTemperature1(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexTemperatureType1(int uID, int VertexNum, int CaseNum, ref int TType);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexTemperatureTable(int uID, int VertexNum, int CaseNum, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexKTranslation3F(int uID, int VertexNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexKRotation3F(int uID, int VertexNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexTMass3(int uID, int VertexNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexRMass3(int uID, int VertexNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexNSMass5ID(int uID, int VertexNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexKDamping3F(int uID, int VertexNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexHeatSource1(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexHeatSourceTables(int uID, int VertexNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeType(int uID, int EdgeNum, int EdgeType);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeMinDivisions(int uID, int EdgeNum, int Divisions);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeBeamProperty(int uID, int EdgeNum, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeCluster(int uID, int EdgeNum, int ClusterID, int Entity, int EntityType, int OriginCode, double[] Origin);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeType(int uID, int EdgeNum, ref int EdgeType);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeMinDivisions(int uID, int EdgeNum, ref int Divisions);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeBeamProperty(int uID, int EdgeNum, ref int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeCluster(int uID, int EdgeNum, ref int ClusterID, ref int Entity, ref int EntityType, ref int OriginCode, double[] Origin);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeRelease1(int uID, int CoedgeNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeSupport4(int uID, int CoedgeNum, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgePressure1(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgePressure3(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeShear1(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeTransverseShear1(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeConvection2(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeConvectionTables(int uID, int CoedgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeRadiation2(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeRadiationTables(int uID, int CoedgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeFlux1(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeFluxTables(int uID, int CoedgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryCoedgeAttachment1(int uID, int CoedgeNum, int Direction, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeRelease1(int uID, int CoedgeNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeSupport4(int uID, int CoedgeNum, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgePressure1(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgePressure3(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeShear1(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeTransverseShear1(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeConvection2(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeConvectionTables(int uID, int CoedgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeRadiation2(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeRadiationTables(int uID, int CoedgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeFlux1(int uID, int CoedgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeFluxTables(int uID, int CoedgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryCoedgeAttachment1(int uID, int CoedgeNum, int Direction, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceProperty(int uID, int FaceNum, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceID(int uID, int FaceNum, int FaceID);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceThickness2(int uID, int FaceNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceOffset1(int uID, int FaceNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceSupport4(int uID, int FaceNum, int Surface, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceTempGradient1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceNormalPressure2(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceGlobalPressure3S(int uID, int FaceNum, int Surface, int ProjectFlag, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceNSMass5ID(int uID, int FaceNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceConvection2(int uID, int FaceNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceConvectionTables(int uID, int FaceNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceRadiation2(int uID, int FaceNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceRadiationTables(int uID, int FaceNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceHeatSource1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceHeatSourceTables(int uID, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceAttachment1(int uID, int FaceNum, int Surface, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceProperty(int uID, int FaceNum, ref int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceID(int uID, int FaceNum, ref int FaceID);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceThickness2(int uID, int FaceNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceOffset1(int uID, int FaceNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceSupport4(int uID, int FaceNum, int Surface, int CaseNum, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceTempGradient1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceNormalPressure2(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceGlobalPressure3S(int uID, int FaceNum, int Surface, int CaseNum, ref int ProjectFlag, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceNSMass5ID(int uID, int FaceNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceConvection2(int uID, int FaceNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceConvectionTables(int uID, int FaceNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceRadiation2(int uID, int FaceNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceRadiationTables(int uID, int FaceNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceHeatSource1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceHeatSourceTables(int uID, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceAttachment1(int uID, int FaceNum, int Surface, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetElementProperty(int uID, int Entity, int EntityNum, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementProperty(int uID, int Entity, int EntityNum, ref int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementPropertySequence(int uID, int Entity, int EntityNum, int MaxProps, int[] Props);
        [DllImport("St7API.dll")]
        public static extern int St7SetElementPropertySwitch(int uID, int Entity, int EntityNum, int PropID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteAttribute(int uID, int Entity, int EntityNum, int AttributeOrd, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityGroup(int uID, int Entity, int EntityNum, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityGroup(int uID, int Entity, int EntityNum, ref int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityAttributeSequenceCount(int uID, int Entity, int EntityNum, int AttributeOrd, ref int NumSets);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityAttributeSequence(int uID, int Entity, int EntityNum, int AttributeOrd, int MaxSets, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetMarker(int uID, int Entity, int EntityNum, int FaceNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetMarker(int uID, int Entity, int EntityNum, int FaceNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteMarker(int uID, int Entity, int EntityNum, int FaceNum);
        [DllImport("St7API.dll")]
        public static extern int St7ShowMarker(int uID, int Entity, int EntityNum, int FaceNum);
        [DllImport("St7API.dll")]
        public static extern int St7HideMarker(int uID, int Entity, int EntityNum, int FaceNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalProperties(int uID, int[] NumProperties, int[] LastProperty);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyNumByIndex(int uID, int Entity, int PropIndex, ref int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyName(int uID, int Entity, int PropNum, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyName(int uID, int Entity, int PropNum, StringBuilder PropName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyColour(int uID, int Entity, int PropNum, int PropCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyColour(int uID, int Entity, int PropNum, ref int PropCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyTable(int uID, int PropTableType, int PropNum, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyTable(int uID, int PropTableType, int PropNum, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyCreepID(int uID, int Entity, int PropNum, int CreepID);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyCreepID(int uID, int Entity, int PropNum, ref int CreepID);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyRayleighFactors(int uID, int Entity, int PropNum, int RayleighMode, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyRayleighFactors(int uID, int Entity, int PropNum, ref int RayleighMode, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetMaterialName(int uID, int Entity, int PropNum, string MaterialName);
        [DllImport("St7API.dll")]
        public static extern int St7GetMaterialName(int uID, int Entity, int PropNum, StringBuilder MaterialName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetTimeDependentModType(int uID, int Entity, int PropNum, int ModType);
        [DllImport("St7API.dll")]
        public static extern int St7GetTimeDependentModType(int uID, int Entity, int PropNum, ref int ModType);
        [DllImport("St7API.dll")]
        public static extern int St7SetHardeningType(int uID, int Entity, int PropNum, int HardType);
        [DllImport("St7API.dll")]
        public static extern int St7GetHardeningType(int uID, int Entity, int PropNum, ref int HardType);
        [DllImport("St7API.dll")]
        public static extern int St7SetAlphaTempType(int uID, int Entity, int PropNum, int AlphaTempType);
        [DllImport("St7API.dll")]
        public static extern int St7GetAlphaTempType(int uID, int Entity, int PropNum, ref int AlphaTempType);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteUnusedProperties(int uID, int Entity, ref int NumDeleted);
        [DllImport("St7API.dll")]
        public static extern int St7UpdateElementPropertyData(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7NewBeamProperty(int uID, int PropNum, int BeamType, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionName(int uID, int PropNum, string SectionName);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionName(int uID, int PropNum, StringBuilder SectionName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPropertyType(int uID, int PropNum, int BeamType);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPropertyType(int uID, int PropNum, ref int BeamType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamMirrorOption(int uID, int PropNum, int MirrorType, int CompatibleTwist, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamMirrorOption(int uID, int PropNum, ref int MirrorType, ref int CompatibleTwist, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamNonlinearType(int uID, int PropNum, int NonlinType, int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamNonlinearType(int uID, int PropNum, ref int NonlinType, ref int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionPropertyData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionPropertyData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionGeometry(int uID, int PropNum, int SectionType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionGeometry(int uID, int PropNum, ref int SectionType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionGeometryBGL(int uID, int PropNum, ref int Shape, double[] Dimensions);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionNominalDiscretisation(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionNominalDiscretisation(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionCircularDiscretisation(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionCircularDiscretisation(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPropertyData(int uID, int PropNum, int[] Integers, double[] SectionData, double[] MaterialData);
        [DllImport("St7API.dll")]
        public static extern int St7CalculateBeamSectionProperties(int uID, int PropNum, byte DoShear);
        [DllImport("St7API.dll")]
        public static extern int St7AssignBXS(int uID, int PropNum, string BXSName);
        [DllImport("St7API.dll")]
        public static extern int St7SaveBeamSectionMesh(int uID, int PropNum, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7SetSpringDamperData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetSpringDamperData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTrussData(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetTrussData(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetCableData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCableData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCutoffBarData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCutoffBarData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPointContactData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPointContactData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPipeData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPipeData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetConnectionData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetConnectionData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetUserBeamData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetUserBeamData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7CheckBeamSectionQuality(int uID, int PropNum, ref double Shear1, ref double Shear2, ref double Torque);
        [DllImport("St7API.dll")]
        public static extern int St7SetSpringDamperThermalData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetSpringDamperThermalData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPointContactThermalData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPointContactThermalData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetUserBeamThermalData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetUserBeamThermalData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetConnectionThermalData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetConnectionThermalData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamMaterialData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamMaterialData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamUsePoisson(int uID, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamUseShearMod(int uID, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamUseMomCurv(int uID, int PropNum, byte UseMomCurv);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamUseMomCurv(int uID, int PropNum, ref byte UseMomCurv);
        [DllImport("St7API.dll")]
        public static extern int St7NewPlateProperty(int uID, int PropNum, int PlateType, int MaterialType, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePropertyType(int uID, int PropNum, int PlateType, int MaterialType);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePropertyType(int uID, int PropNum, ref int PlateType, ref int MaterialType);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateNonlinearType(int uID, int PropNum, int NonlinType, int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateNonlinearType(int uID, int PropNum, ref int NonlinType, ref int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateThickness(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateThickness(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateLayers(int uID, int PropNum, int NumLayers);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateLayers(int uID, int PropNum, ref int NumLayers);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePatchTol(int uID, int PropNum, double PatchTol);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePatchTol(int uID, int PropNum, ref double PatchTol);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateIsotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateIsotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateOrthotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateOrthotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateRubberMaterial(int uID, int PropNum, int RubberType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateRubberMaterial(int uID, int PropNum, ref int RubberType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateAnisotropicMaterial(int uID, int PropNum, int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateAnisotropicMaterial(int uID, int PropNum, ref int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateLaminateMaterial(int uID, int PropNum, int LamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateLaminateMaterial(int uID, int PropNum, ref int LamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateUserDefinedMaterial(int uID, int PropNum, int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateUserDefinedMaterial(int uID, int PropNum, ref int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilType(int uID, int PropNum, ref int SoilType);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateMCDPMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateMCDPMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilDCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilDCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilCCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilCCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilMCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilMCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilDPMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilDPMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilLSMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilLSMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFluidMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFluidMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateUseReducedInt(int uID, int PropNum, byte UseReducedInt);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateUseReducedInt(int uID, int PropNum, ref byte UseReducedInt);
        [DllImport("St7API.dll")]
        public static extern int St7NewBrickProperty(int uID, int PropNum, int MaterialType, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickPropertyType(int uID, int PropNum, int MaterialType);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickPropertyType(int uID, int PropNum, ref int MaterialType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickNonlinearType(int uID, int PropNum, int NonlinType, int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickNonlinearType(int uID, int PropNum, ref int NonlinType, ref int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickIsotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickIsotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickOrthotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickOrthotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickAnisotropicMaterial(int uID, int PropNum, int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickAnisotropicMaterial(int uID, int PropNum, ref int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickRubberMaterial(int uID, int PropNum, int RubberType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickRubberMaterial(int uID, int PropNum, ref int RubberType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilType(int uID, int PropNum, ref int SoilType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickMCDPMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickMCDPMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilDCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilDCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilCCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilCCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilMCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilMCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilDPMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilDPMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilLSMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilLSMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickFluidMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFluidMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickAddBubbleFunction(int uID, int PropNum, byte AddBubbleFunction);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickAddBubbleFunction(int uID, int PropNum, ref byte AddBubbleFunction);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickIntegrationPoints(int uID, int PropNum, int Xi, int Eta, int Zeta);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickIntegrationPoints(int uID, int PropNum, ref int Xi, ref int Eta, ref int Zeta);
        [DllImport("St7API.dll")]
        public static extern int St7NewPlyProperty(int uID, int PropNum, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlyMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlyMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalLaminateStacks(int uID, ref int NumStacks, ref int LastStack);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminateStackNumByIndex(int uID, int Index, ref int LaminateNum);
        [DllImport("St7API.dll")]
        public static extern int St7NewLaminate(int uID, int LamNum, string LamName);
        [DllImport("St7API.dll")]
        public static extern int St7SetLaminateName(int uID, int LamNum, string LamName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminateName(int uID, int LamNum, StringBuilder LamName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminateNumPlies(int uID, int LamNum, ref int NumPlies);
        [DllImport("St7API.dll")]
        public static extern int St7SetLaminatePly(int uID, int LamNum, int Pos, int PlyPropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminatePly(int uID, int LamNum, int Pos, ref int PlyPropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7AddLaminatePly(int uID, int LamNum, int PlyPropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLaminatePly(int uID, int LamNum, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLaminatePly(int uID, int LamNum, int Pos, int PlyPropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLaminateMatrices(int uID, int LamNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminateMatrices(int uID, int LamNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLaminate(int uID, int LamNum);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteUnusedLaminates(int uID, ref int NumDeleted);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalReinforcementLayouts(int uID, ref int NumLayouts, ref int LastLayout);
        [DllImport("St7API.dll")]
        public static extern int St7GetReinforcementLayoutNumByIndex(int uID, int Index, ref int LayoutNum);
        [DllImport("St7API.dll")]
        public static extern int St7NewReinforcementLayout(int uID, int LayoutID, string LayoutName);
        [DllImport("St7API.dll")]
        public static extern int St7SetReinforcementName(int uID, int LayoutID, string LayoutName);
        [DllImport("St7API.dll")]
        public static extern int St7GetReinforcementName(int uID, int LayoutID, StringBuilder LayoutName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetReinforcementData(int uID, int LayoutID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetReinforcementData(int uID, int LayoutID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteReinforcementLayout(int uID, int LayoutID);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalCreepDefinitions(int uID, ref int NumSets, ref int LastSet);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepDefinitionNumByIndex(int uID, int Index, ref int CreepNum);
        [DllImport("St7API.dll")]
        public static extern int St7NewCreepDefinition(int uID, int CreepID, string CreepDefinitionName);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepDefinitionName(int uID, int CreepID, string CreepDefinitionName);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepDefinitionName(int uID, int CreepID, StringBuilder CreepDefinitionName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepLaw(int uID, int CreepID, int CreepLaw);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepLaw(int uID, int CreepID, ref int CreepLaw);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepBasicData(int uID, int CreepID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepBasicData(int uID, int CreepID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7EnableCreepUserTable(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableCreepUserTable(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepUserTableState(int uID, int CreepID, int TableID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepUserTableData(int uID, int CreepID, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepUserTableData(int uID, int CreepID, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepHardeningType(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepHardeningType(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepTimeUnit(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepTimeUnit(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepTemperatureInclude(int uID, int CreepID, byte Include);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepTemperatureInclude(int uID, int CreepID, ref byte Include);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteHyperbolicData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteHyperbolicData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteViscoChainData(int uID, int CreepID, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteViscoChainData(int uID, int CreepID, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7EnableCreepConcreteUserTable(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableCreepConcreteUserTable(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteUserTableState(int uID, int CreepID, int TableID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteUserTableData(int uID, int CreepID, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteUserTableData(int uID, int CreepID, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteFunctionType(int uID, int CreepID, int FunctionType);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteFunctionType(int uID, int CreepID, ref int FunctionType);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteLoadingAge(int uID, int CreepID, double LoadingAge);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteLoadingAge(int uID, int CreepID, ref double LoadingAge);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteLoadingTimeUnit(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteLoadingTimeUnit(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteShrinkageType(int uID, int CreepID, int ShrinkageType);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteShrinkageType(int uID, int CreepID, ref int ShrinkageType);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteShrinkageFormulaData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteShrinkageFormulaData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteShrinkageTableData(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteShrinkageTableData(int uID, int CreepID, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteTemperatureData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteTemperatureData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteCementCuringData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteCementCuringData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteCreepDefinition(int uID, int CreepID);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalLoadPathTemplates(int uID, ref int NumTemplates, ref int LastTemplate);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateNumByIndex(int uID, int Index, ref int PathNum);
        [DllImport("St7API.dll")]
        public static extern int St7NewLoadPathTemplate(int uID, int LoadPathTemplateID, string LoadPathTemplateName);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateName(int uID, int LoadPathTemplateID, string LoadPathTemplateName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateName(int uID, int LoadPathTemplateID, StringBuilder LoadPathTemplateName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateParameters(int uID, int LoadPathTemplateID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateParameters(int uID, int LoadPathTemplateID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateLaneFactor(int uID, int LoadPathTemplateID, int Lane, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateLaneFactor(int uID, int LoadPathTemplateID, int Lane, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7AddLoadPathTemplateVehicle(int uID, int LoadPathTemplateID);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateVehicleName(int uID, int LoadPathTemplateID, int Vehicle, string LoadPathTemplateVehicleName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateVehicleName(int uID, int LoadPathTemplateID, int Vehicle, StringBuilder LoadPathTemplateVehicleName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLoadPathTemplateVehicle(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7CloneLoadPathTemplateVehicle(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplateVehicle(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadPathTemplateVehicles(int uID, int LoadPathTemplateID, ref int NumVehicles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateVehicleData(int uID, int LoadPathTemplateID, int Vehicle, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateVehicleData(int uID, int LoadPathTemplateID, int Vehicle, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLoadPathTemplateVehicleLane(int uID, int LoadPathTemplateID, int Vehicle, int Lane);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLoadPathTemplateVehicleLane(int uID, int LoadPathTemplateID, int Vehicle, int Lane);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateVehicleLaneState(int uID, int LoadPathTemplateID, int Vehicle, int Lane, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7AddLoadPathTemplatePointForce(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLoadPathTemplatePointForce(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplatePointForce(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadPathTemplatePointForces(int uID, int LoadPathTemplateID, int Vehicle, ref int NumPointForces);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplatePointForceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplatePointForceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7AddLoadPathTemplateDistributedForce(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLoadPathTemplateDistributedForce(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplateDistributedForce(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadPathTemplateDistributedForces(int uID, int LoadPathTemplateID, int Vehicle, ref int NumDistributedForces);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateDistributedForceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateDistributedForceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7AddLoadPathTemplateHeatSource(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLoadPathTemplateHeatSource(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplateHeatSource(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadPathTemplateHeatSources(int uID, int LoadPathTemplateID, int Vehicle, ref int NumHeatSources);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateHeatSourceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateHeatSourceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateVehicleSet(int uID, int LoadPathTemplateID, int Vehicle, string LoadPathTemplateVehicleSet);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateVehicleSet(int uID, int LoadPathTemplateID, int Vehicle, StringBuilder LoadPathTemplateVehicleSet, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplate(int uID, int LoadPathTemplateID);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateCentrifugalData(int uID, int LoadPathTemplateID, string K0, string K1, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateCentrifugalData(int uID, int LoadPathTemplateID, StringBuilder K0, StringBuilder K1, int MaxStringLen, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalCavityFluidLayouts(int uID, ref int NumLayouts, ref int LastLayout);
        [DllImport("St7API.dll")]
        public static extern int St7GetCavityFluidLayoutNumByIndex(int uID, int Index, ref int LayoutNum);
        [DllImport("St7API.dll")]
        public static extern int St7NewCavityFluidLayout(int uID, int LayoutID, string LayoutName);
        [DllImport("St7API.dll")]
        public static extern int St7SetCavityFluidName(int uID, int LayoutID, string LayoutName);
        [DllImport("St7API.dll")]
        public static extern int St7GetCavityFluidName(int uID, int LayoutID, StringBuilder LayoutName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetCavityFluidType(int uID, int LayoutID, ref int FluidType);
        [DllImport("St7API.dll")]
        public static extern int St7SetCavityFluidIdealGas(int uID, int LayoutID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCavityFluidIdealGas(int uID, int LayoutID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCavityFluidConstBulk(int uID, int LayoutID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCavityFluidConstBulk(int uID, int LayoutID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCavityFluidPreLoad(int uID, int LayoutID, int CaseNum, int PreType, double Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetCavityFluidPreLoad(int uID, int LayoutID, int CaseNum, ref int PreType, ref double Value);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteCavityFluidLayout(int uID, int LayoutID);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLibraries(int LibraryType, ref int NumLibraries);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryName(int LibraryType, int LibraryID, StringBuilder LibraryName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryID(int LibraryType, string LibraryName, ref int LibraryID);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLibraryItems(int LibraryType, int LibraryID, ref int NumItems);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryItemName(int LibraryType, int LibraryID, int ItemID, StringBuilder ItemName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryItemID(int LibraryType, int LibraryID, string ItemName, ref int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryBeamSectionPropertyDataBSL(int LibraryID, int ItemID, int LengthUnit, StringBuilder ItemName, int MaxStringLen, ref int ItemShape, double[] SectionData);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryBeamSectionPropertyDataBGL(int LibraryID, int ItemID, int LengthUnit, StringBuilder ItemName, int MaxStringLen, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryBeamSectionGeometryBGL(int LibraryID, int ItemID, int LengthUnit, StringBuilder ItemName, int MaxStringLen, ref int ItemShape, double[] ItemDimensions);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryMaterial(int uID, int Entity, int PropNum, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryComposite(int uID, int PropNum, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryBeamSection(int uID, int PropNum, int LibraryID, int ItemID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryBeamSectionBGL(int uID, int PropNum, int LibraryID, int ItemID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryCreepDefinition(int uID, int CreepID, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryLoadPathTemplate(int uID, int LoadPathTemplateID, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryReinforcementLayout(int uID, int LayoutID, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7NewTableType(int uID, int TableType, int TableID, int NumEntries, string TableName, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteTableType(int uID, int TableType, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableTypeName(int uID, int TableType, int TableID, StringBuilder TableName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableID(int uID, string TableName, int TableType, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumTableTypeRows(int uID, int TableType, int TableID, ref int NumRows);
        [DllImport("St7API.dll")]
        public static extern int St7SetTableTypeData(int uID, int TableType, int TableID, int NumEntries, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableTypeData(int uID, int TableType, int TableID, int MaxRows, ref int NumRows, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetFrequencyTable(int uID, int TableID, int FreqType);
        [DllImport("St7API.dll")]
        public static extern int St7GetFrequencyTable(int uID, int TableID, ref int FreqType);
        [DllImport("St7API.dll")]
        public static extern int St7SetTimeTableUnits(int uID, int TableType, int TableID, int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7GetTimeTableUnits(int uID, int TableType, int TableID, ref int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertTimeTableUnits(int uID, int TableType, int TableID, int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7SetFrequencyPeriodTableUnits(int uID, int TableID, int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7GetFrequencyPeriodTableUnits(int uID, int TableID, ref int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7SetAccVsTimeTableUnits(int uID, int TableID, int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7GetAccVsTimeTableUnits(int uID, int TableID, ref int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumTables(int uID, int TableType, ref int NumTables, ref int MaxTableNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableInfoByIndex(int uID, int TableType, int Index, ref int TableID, StringBuilder TableName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLSALoadCase(int uID, int LoadCaseNum, int FreedomCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLSALoadCase(int uID, int LoadCaseNum, int FreedomCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSALoadCaseState(int uID, int LoadCaseNum, int FreedomCaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLSAInitialPCGFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLSAInitialPCGFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSAInitialPCGFileState(int uID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSAInitialPCGFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSAInitialPCGFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLBAInitial(int uID, string FileName, int VariableCaseNum, int FixedCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLBAInitial(int uID, StringBuilder FileName, ref int VariableCaseNum, ref int FixedCaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLBANumModes(int uID, int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7GetLBANumModes(int uID, ref int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7SetLBAShift(int uID, double Shift);
        [DllImport("St7API.dll")]
        public static extern int St7GetLBAShift(int uID, ref double Shift);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLIALoadCase(int uID, int LoadCaseNum, int FreedomCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLIALoadCase(int uID, int LoadCaseNum, int FreedomCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLIALoadCaseState(int uID, int LoadCaseNum, int FreedomCaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLAStagedAnalysis(int uID, byte StagedAnalysis);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAStagedAnalysis(int uID, ref byte StagedAnalysis);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNLAStage(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNLAStage(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAStageState(int uID, int Stage, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7AddNLAIncrement(int uID, int Stage, string IncName);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAIncrementName(int uID, int Stage, int Increment, StringBuilder IncName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7InsertNLAIncrement(int uID, int Stage, int Increment, string IncName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteNLAIncrement(int uID, int Stage, int Increment);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumNLAIncrements(int uID, int Stage, ref int NumIncrements);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLALoadIncrementFactor(int uID, int Stage, int Increment, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLALoadIncrementFactor(int uID, int Stage, int Increment, int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLAFreedomIncrementFactor(int uID, int Stage, int Increment, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAFreedomIncrementFactor(int uID, int Stage, int Increment, int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNLALoadCase(int uID, int Stage, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNLALoadCase(int uID, int Stage, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNLAFreedomCase(int uID, int Stage, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNLAFreedomCase(int uID, int Stage, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLALoadCaseState(int uID, int Stage, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAFreedomCaseState(int uID, int Stage, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLAInitial(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAInitial(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLAPseudoTime(int uID, int Stage, int Increment, double Time);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAPseudoTime(int uID, int Stage, int Increment, ref double Time);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNLAPseudoTime(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNLAPseudoTime(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAPseudoTimeState(int uID, int Stage, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLAResetAtIncrement(int uID, int Increment, byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAResetAtIncrement(int uID, int Increment, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetQSAInitial(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetQSAInitial(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFAInitial(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFAInitial(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFANumModes(int uID, int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFANumModes(int uID, ref int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFAShift(int uID, double Shift);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFAShift(int uID, ref double Shift);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFAModeParticipationCalculate(int uID, byte Calculate);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFAModeParticipationCalculate(int uID, ref byte Calculate);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFAModeParticipationVectors(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFAModeParticipationVectors(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRARange(int uID, int NumSteps, double F1, double F2, byte AutoInsert);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRARange(int uID, ref int NumSteps, ref double F1, ref double F2, ref byte AutoInsert);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRABaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRABaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRALoadCase(int uID, int CaseNum, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRALoadCase(int uID, int CaseNum, ref int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRALoadType(int uID, int LType);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRALoadType(int uID, ref int LType);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRAMode(int uID, int MType);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRAMode(int uID, ref int MType);
        [DllImport("St7API.dll")]
        public static extern int St7AddSRALoadCase(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertSRALoadCase(int uID, int SRACase, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteSRALoadCase(int uID, int SRACase);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumSRALoadCases(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRALoadCaseTable(int uID, int SRACase, int CaseNum, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRALoadCaseTable(int uID, int SRACase, int CaseNum, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7AddSRADirectionVector(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertSRADirectionVector(int uID, int SRACase, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteSRADirectionVector(int uID, int SRACase);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumSRADirectionVectors(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRADirectionVectorTable(int uID, int SRACase, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRADirectionVectorTable(int uID, int SRACase, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRADirectionVectorType(int uID, int SRACase, int VectType);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRADirectionVectorType(int uID, int SRACase, ref int VectType);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRADirectionVectorFactors(int uID, int SRACase, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRADirectionVectorFactors(int uID, int SRACase, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAResultModal(int uID, byte Modal);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRAResultModal(int uID, ref byte Modal);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAResultSRSS(int uID, byte SRSS);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRAResultSRSS(int uID, ref byte SRSS);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAResultCQC(int uID, byte CQC);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRAResultCQC(int uID, ref byte CQC);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAType(int uID, int SpectrumType);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRAType(int uID, ref int SpectrumType);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAResultsSign(int uID, int ResultsSign);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRAResultsSign(int uID, ref int ResultsSign);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRABaseExcitation(int uID, byte Base);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRABaseExcitation(int uID, ref byte Base);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRALoadExcitation(int uID, byte Load);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRALoadExcitation(int uID, ref byte Load);
        [DllImport("St7API.dll")]
        public static extern int St7EnableSRACase(int uID, int SRACase);
        [DllImport("St7API.dll")]
        public static extern int St7DisableSRACase(int uID, int SRACase);
        [DllImport("St7API.dll")]
        public static extern int St7EnableSRADirectionVector(int uID, int SRACase);
        [DllImport("St7API.dll")]
        public static extern int St7DisableSRADirectionVector(int uID, int SRACase);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRACaseStatus(int uID, int SRACase, ref byte Enabled);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRADirectionVectorStatus(int uID, int SRACase, ref byte Enabled);
        [DllImport("St7API.dll")]
        public static extern int St7SetLTAInitial(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLTAInitial(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLTAMethod(int uID, int Method);
        [DllImport("St7API.dll")]
        public static extern int St7GetLTAMethod(int uID, ref int Method);
        [DllImport("St7API.dll")]
        public static extern int St7SetLTASolutionType(int uID, int SolutionType);
        [DllImport("St7API.dll")]
        public static extern int St7GetLTASolutionType(int uID, ref int SolutionType);
        [DllImport("St7API.dll")]
        public static extern int St7SetNTAInitial(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNTAInitial(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7EnableHeatLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableHeatLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetHeatLoadCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetTHAInitial(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTHAInitial(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetTHATemperatureLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTHATemperatureLoadCase(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetTHAInitialAttributeOverride(int uID, byte Active);
        [DllImport("St7API.dll")]
        public static extern int St7GetTHAInitialAttributeOverride(int uID, ref byte Active);
        [DllImport("St7API.dll")]
        public static extern int St7SetModalSuperpositionFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetModalSuperpositionFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumModesInModalFile(int uID, ref int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumModesInNFAFile(int uID, string FileName, ref int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7EnableMode(int uID, int ModeNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableMode(int uID, int ModeNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetModeDampingRatio(int uID, int ModeNum, double Ratio);
        [DllImport("St7API.dll")]
        public static extern int St7GetModeDampingRatio(int uID, int ModeNum, ref double Ratio);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientInitialConditionsType(int uID, int InitialType);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientInitialConditionsType(int uID, ref int InitialType);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientInitialConditionsVectors(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientInitialConditionsVectors(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientInitialConditionsNodalVelocity(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientInitialConditionsNodalVelocity(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseExcitation(int uID, int BaseType);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseExcitation(int uID, ref int BaseType);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseAcceleration(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseAcceleration(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseVelocity(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseVelocity(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseDisplacement(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseDisplacement(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseTables(int uID, int BaseType, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseTables(int uID, int BaseType, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7AddTransientNodeHistoryCase(int uID, int NodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7InsertTransientNodeHistoryCase(int uID, int NodeNum, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteTransientNodeHistoryCase(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumTransientNodeHistoryCases(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientNodeHistoryCaseData(int uID, int Pos, byte[] Logicals);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientNodeHistoryCaseData(int uID, int Pos, byte[] Logicals);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientTemperatureInputType(int uID, int InputType);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientHeatFile(int uID, string FileName, double RefTemp);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientHeatFile(int uID, StringBuilder FileName, int MaxStringLen, ref double RefTemp);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientLoadPositionTable(int uID, int CaseNum, int TableNum, int UCSId, int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientLoadPositionTable(int uID, int CaseNum, ref int TableNum, ref int UCSId, ref int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientFreedomPositionTable(int uID, int CaseNum, int TableNum, int UCSId, int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientFreedomPositionTable(int uID, int CaseNum, ref int TableNum, ref int UCSId, ref int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7GetInitialTemperatureInTHAFile(int uID, string FileName, ref double InitialTemp);
        [DllImport("St7API.dll")]
        public static extern int St7EnableTransientLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableTransientLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7EnableTransientFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableTransientFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientLoadCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientFreedomCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientLoadTimeTable(int uID, int CaseNum, int TableNum, byte AddTimeSteps);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientLoadTimeTable(int uID, int CaseNum, ref int TableNum, ref byte AddTimeSteps);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientFreedomTimeTable(int uID, int CaseNum, int TableNum, byte AddTimeSteps);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientFreedomTimeTable(int uID, int CaseNum, ref int TableNum, ref byte AddTimeSteps);
        [DllImport("St7API.dll")]
        public static extern int St7SetNumTimeStepRows(int uID, int NumRows);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumTimeStepRows(int uID, ref int NumRows);
        [DllImport("St7API.dll")]
        public static extern int St7SetTimeStepData(int uID, int Row, int NumSteps, int SaveEvery, double TimeStep);
        [DllImport("St7API.dll")]
        public static extern int St7GetTimeStepData(int uID, int Row, ref int NumSteps, ref int SaveEvery, ref double TimeStep);
        [DllImport("St7API.dll")]
        public static extern int St7SetTimeStepUnit(int uID, int TimeUnit);
        [DllImport("St7API.dll")]
        public static extern int St7GetTimeStepUnit(int uID, ref int TimeUnit);
        [DllImport("St7API.dll")]
        public static extern int St7EnableMovingLoad(int uID, int LoadPathID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableMovingLoad(int uID, int LoadPathID);
        [DllImport("St7API.dll")]
        public static extern int St7GetMovingLoadState(int uID, int LoadPathID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetMovingLoadTimeTable(int uID, int LoadPathID, int TimeTableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetMovingLoadTimeTable(int uID, int LoadPathID, ref int TimeTableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetMovingLoadAutoDivisions(int uID, int LoadPathID, byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetMovingLoadAutoDivisions(int uID, int LoadPathID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverHeatNonlinear(int uID, byte Nonlinear);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverFontName(string FontName);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverFontName(StringBuilder FontName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverNumCPU(int NumCPU);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverNumCPU(ref int NumCPU);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverScheme(int uID, int Scheme);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverScheme(int uID, ref int Scheme);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverSort(int uID, int Sort);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverSort(int uID, ref int Sort);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverTreeStartNumber(int uID, int Start);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverTreeStartNumber(int uID, ref int Start);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverActiveStage(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverActiveStage(int uID, ref int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverTemperatureDependence(int uID, int TempType);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverTemperatureDependence(int uID, ref int TempType);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverLoadCaseTemperatureDependence(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverLoadCaseTemperatureDependence(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverLoadCaseCableInertia(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverLoadCaseCableInertia(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverLoadCaseCablePreLoad(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverLoadCaseCablePreLoad(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverFreedomCase(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetDampingType(int uID, int DampType);
        [DllImport("St7API.dll")]
        public static extern int St7GetDampingType(int uID, ref int DampType);
        [DllImport("St7API.dll")]
        public static extern int St7SetRayleighFactors(int uID, int RayleighMode, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetRayleighFactors(int uID, ref int RayleighMode, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetSoilFluidOptions(int uID, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetSoilFluidOptions(int uID, ref int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetSoilAutoDrained(int uID, byte Active);
        [DllImport("St7API.dll")]
        public static extern int St7GetSoilAutoDrained(int uID, ref byte Active);
        [DllImport("St7API.dll")]
        public static extern int St7SetSturmCheck(int uID, byte DoSturm);
        [DllImport("St7API.dll")]
        public static extern int St7GetSturmCheck(int uID, ref byte DoSturm);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverNonlinearGeometry(int uID, byte NonlinearGeometry);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverNonlinearGeometry(int uID, ref byte NonlinearGeometry);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverNonlinearMaterial(int uID, byte NonlinearMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverNonlinearMaterial(int uID, ref byte NonlinearMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverCreep(int uID, byte Creep);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverCreep(int uID, ref byte Creep);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverIncludeKG(int uID, byte IncludeKG);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverIncludeKG(int uID, ref byte IncludeKG);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverStressStiffening(int uID, byte AddStressStiffening);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverStressStiffening(int uID, ref byte AddStressStiffening);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityResult(int uID, int Result, int State);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityResult(int uID, int Result, ref int State);
        [DllImport("St7API.dll")]
        public static extern int St7EnableResultGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableResultGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultGroupState(int uID, int GroupID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7EnableResultProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableResultProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultPropertyState(int uID, int Entity, int PropNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultLogFileName(int uID, string LogName);
        [DllImport("St7API.dll")]
        public static extern int St7SetStaticRestartFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetStaticRestartFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetDynamicRestartFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetDynamicRestartFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetQuasiStaticRestartFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetQuasiStaticRestartFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeHistoryFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeHistoryFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7EnableSaveRestart(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableSaveRestart(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableSaveLastRestartStep(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableSaveLastRestartStep(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetAppendSRA(int uID, byte Append);
        [DllImport("St7API.dll")]
        public static extern int St7GetAppendSRA(int uID, ref byte Append);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNSMassCaseInMassMatrix(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNSMassCaseInMassMatrix(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNSMassCaseInMassMatrixState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverDefaultsLogical(int uID, int Parameter, byte Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverDefaultsLogical(int uID, int Parameter, ref byte Value);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverDefaultsInteger(int uID, int Parameter, int Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverDefaultsInteger(int uID, int Parameter, ref int Value);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverDefaultsDouble(int uID, int Parameter, double Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverDefaultsDouble(int uID, int Parameter, ref double Value);
        [DllImport("St7API.dll")]
        public static extern int St7SetUseSolverDLL(byte UseDLL);
        [DllImport("St7API.dll")]
        public static extern int St7GetUseSolverDLL(ref byte UseDLL);
        [DllImport("St7API.dll")]
        public static extern int St7CheckSolverRunning(int ProcessID, ref byte IsRunning);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverWindowPos(int L, int T, int W, int H);
        [DllImport("St7API.dll")]
        public static extern int St7ClearSolverWindowPos();
        [DllImport("St7API.dll")]
        public static extern int St7RunSolver(int uID, int Solver, int Mode, int Wait);
        [DllImport("St7API.dll")]
        public static extern int St7RunSolverProcess(int uID, int Solver, int Mode, int Wait, ref int ProcessID);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultOptions(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultOptions(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetEnvelopeAveragingOrder(int uID, int Order);
        [DllImport("St7API.dll")]
        public static extern int St7GetEnvelopeAveragingOrder(int uID, ref int Order);
        [DllImport("St7API.dll")]
        public static extern int St7SetEnvelopeAdditionalBeamSlices(int uID, byte Additional);
        [DllImport("St7API.dll")]
        public static extern int St7GetEnvelopeAdditionalBeamSlices(int uID, ref byte Additional);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamResultPosMode(int uID, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultPosMode(int uID, ref int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7EnableModelStrainUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableModelStrainUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableModelRotationUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableModelRotationUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableModelRCUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableModelRCUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFreedomCaseName(int uID, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseStage(int uID, int CaseNum, ref int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseConvergence(int uID, int CaseNum, ref byte Converged);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseReset(int uID, int CaseNum, ref byte Reset);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseTime(int uID, int CaseNum, ref double Time);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseFactor(int uID, int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseKineticEnergy(int uID, int CaseNum, ref double Energy);
        [DllImport("St7API.dll")]
        public static extern int St7GetFrequency(int uID, int Mode, ref double Freq);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumModes(int uID, ref int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumSRACases(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7GetModalResultsNFA(int uID, int Mode, double[] ModalResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetExcitationTypeSRA(int uID, int CaseNum, ref int ExcitationType);
        [DllImport("St7API.dll")]
        public static extern int St7GetModalResultsSRA(int uID, int CaseNum, int Mode, double[] ModalResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetModalResultsHRA(int uID, int CaseNum, int Mode, double[] ModalResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetInertiaReliefResults(int uID, int CaseNum, double[] InertiaResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetBucklingFactor(int uID, int Mode, ref double Fact);
        [DllImport("St7API.dll")]
        public static extern int St7GetInitialTemperatureTHA(int uID, ref double InitialTemp);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementResultStatus(int uID, int Entity, int EntityNum, int ResultCase, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeResult(int uID, int ResultType, int NodeNum, int ResultCase, double[] NodeResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeResultUCS(int uID, int ResultType, int UCSId, int NodeNum, int ResultCase, double[] NodeResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultArray(int uID, int ResultType, int ResultSubType, int BeamNum, int MinStations, int ResultCase, ref int NumStations, ref int NumColumns, double[] BeamPos, double[] BeamResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultArrayPos(int uID, int ResultType, int ResultSubType, int BeamNum, int ResultCase, int NumStations, double[] BeamPos, ref int NumColumns, double[] BeamResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultEndPos(int uID, int ResultType, int ResultSubType, int BeamNum, int ResultCase, ref int NumColumns, double[] BeamResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultSinglePos(int uID, int ResultType, int ResultSubType, int BeamNum, int ResultCase, double BeamPos, ref int NumColumns, double[] BeamResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionResult(int uID, int ResultType, int BeamNum, int ResultCase, double BeamPos, double x, double y, double[] BeamResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamReleaseResult(int uID, int BeamNum, int ResultCase, byte[] BeamReleased, double[] ReleaseValue);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResultArray(int uID, int ResultType, int ResultSubType, int PlateNum, int ResultCase, int SampleLocation, int Surface, int Layer, ref int NumPoints, ref int NumColumns, double[] PlateResult);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateResultMaxJunctionAngle(int uID, double MaxJunctionAngle);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResultMaxJunctionAngle(int uID, ref double MaxJunctionAngle);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResultGaussPoints(int uID, int PlateNum, int ResultCase, ref int NumGauss, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickResultArray(int uID, int ResultType, int ResultSubType, int BrickNum, int ResultCase, int SampleLocation, ref int NumPoints, ref int NumColumns, double[] BrickResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkResultArray(int uID, int ResultType, int UCSId, int LinkNum, int ResultCase, ref int NumPoints, ref int NumColumns, double[] LinkResult, int ArrayDim);
        [DllImport("St7API.dll")]
        public static extern int St7GetMultiPointLinkReactionSum(int uID, int LinkNum, int UCSId, int ResultCase, double[] Reaction);
        [DllImport("St7API.dll")]
        public static extern int St7GetMultiPointLinkFluxSum(int uID, int LinkNum, int ResultCase, ref double Flux);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickResultGaussPoints(int uID, int BrickNum, int ResultCase, ref int NumGauss, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetReferenceDisplacement(int uID, int RefCase, byte ApplyToDisplay);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeReactionSum(int uID, int UCSId, int ResultCase, double[] Origin, int NodeState, double[] ReactionSum);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementNodeForceSum(int uID, int UCSId, int ResultCase, double[] Origin, int[] EntityState, double[] ReactionSum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeFluxSum(int uID, int ResultCase, int NodeState, ref double FluxSum);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementNodeFluxSum(int uID, int ResultCase, int[] EntityState, ref double FluxSum);
        [DllImport("St7API.dll")]
        public static extern int St7EnablePlyPropertyResults(int uID, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisablePlyPropertyResults(int uID, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlyPropertyResultsState(int uID, int PropNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultUserEquation(int uID, int Entity, string Equation, int TrigType);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultUserEquation(int uID, int Entity, StringBuilder Equation, int MaxStringLen, ref int TrigType);
        [DllImport("St7API.dll")]
        public static extern int St7StoreResultUserEquation(int uID, int Entity, string Name, string Equation, int TrigType);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteStoredResultUserEquation(int uID, int Entity, int Number);
        [DllImport("St7API.dll")]
        public static extern int St7ReplaceStoredResultUserEquation(int uID, int Entity, int Number, string Name, string Equation, int TrigType);
        [DllImport("St7API.dll")]
        public static extern int St7RetrieveStoredResultUserEquation(int uID, int Entity, int Number, StringBuilder Name, StringBuilder Equation, int MaxStringLen, ref int TrigType);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumStoredResultUserEquations(int uID, int Entity, ref int NumEquations);
        [DllImport("St7API.dll")]
        public static extern int St7SetStoredResultUserEquation(int uID, int Entity, int Number);
        [DllImport("St7API.dll")]
        public static extern int St7GeneratePlateContourFile(int uID, int ResultCase, int[] Integers, ref int FileIndex);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateBrickContourFile(int uID, int ResultCase, int[] Integers, ref int FileIndex);
        [DllImport("St7API.dll")]
        public static extern int St7LoadPlateContourFile(int uID, int FileIndex);
        [DllImport("St7API.dll")]
        public static extern int St7LoadBrickContourFile(int uID, int FileIndex);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateContourFileResult(int uID, int PlateNum, double[] PlateResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickContourFileResult(int uID, int BrickNum, double[] BrickResult);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLSACombinations(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSACombinationName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSACombinationName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSACombinationSRAName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSACombinationSRAName(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7AddLSACombination(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLSACombination(int uID, int Pos, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLSACombination(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSACombinationFactor(int uID, int LType, int Pos, int LoadCaseNum, int FreedomCaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSACombinationFactor(int uID, int LType, int Pos, int LoadCaseNum, int FreedomCaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSACombinationState(int uID, int CaseNum, byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSACombinationState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumCombinedLSACombinations(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetCombinedLSACombinationName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetCombinedLSACombinationName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetCombinedLSACombinationState(int uID, int CaseNum, byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetCombinedLSACombinationState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7AddCombinedLSACombination(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertCombinedLSACombination(int uID, int Pos, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteCombinedLSACombination(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7SetCombinedLSACombinationFactor(int uID, int Pos, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetCombinedLSACombinationFactor(int uID, int Pos, int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRABaseCombinationFactor(int uID, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRABaseCombinationFactor(int uID, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRACaseCombinationFactor(int uID, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRACaseCombinationFactor(int uID, int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRACombinationFactorLSA(int uID, int LoadCaseNum, int FreedomCaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRACombinationFactorLSA(int uID, int LoadCaseNum, int FreedomCaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRACombinationLSAName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRACombinationLSAName(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetInfluenceFileName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluenceFileName(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumInfluenceVariables(int uID, ref int NumVariables);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumInfluenceMultiVariableCases(int uID, ref int NumMultiVariableCases);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluenceVariableData(int uID, int VariableID, ref int Entity, ref int EntityNum, ref int ResponseType, ref int DoF, ref int UCSId, ref int LoadCaseNum, ref int FreedomCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetInfluenceMinVariableState(int uID, int MinVariableID, byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluenceMinVariableState(int uID, int MinVariableID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetInfluenceMaxVariableState(int uID, int MaxVariableID, byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluenceMaxVariableState(int uID, int MaxVariableID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetInfluenceMultiVariableState(int uID, int MultiVariableID, int MultiVariableCaseID, byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluenceMultiVariableState(int uID, int MultiVariableID, int MultiVariableCaseID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetInfluenceMultiVariableType(int uID, int MultiVariableCaseID, int MultiVariableType);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluenceMultiVariableType(int uID, int MultiVariableCaseID, ref int MultiVariableType);
        [DllImport("St7API.dll")]
        public static extern int St7AddInfluenceMultiVariableCase(int uID, int MultiVariableType, string MultiVariableName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteInfluenceMultiVariableCase(int uID, int MultiVariableCaseID);
        [DllImport("St7API.dll")]
        public static extern int St7SetInfluenceMultiVariableName(int uID, int MultiVariableCaseID, string MultiVariableName);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluenceMultiVariableName(int uID, int MultiVariableCaseID, StringBuilder MultiVariableName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetInfluenceGroupStatus(int uID, int GroupID, byte Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluenceGroupStatus(int uID, int GroupID, ref byte Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetInfluencePropertyStatus(int uID, int Entity, int PropNum, byte Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluencePropertyStatus(int uID, int Entity, int PropNum, ref byte Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetInfluenceCombinationOptions(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetInfluenceCombinationOptions(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateInfluenceCases(int uID, byte RemoveExisting, byte AllowStop, byte WriteLog, int Mode, ref int NumCasesDeleted, ref int NumCasesGenerated, ref int WarningCode);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumEnvelopes(int uID, ref int NumLimitEnvelopes, ref int NumCombinationEnvelopes, ref int NumFactorsEnvelopes);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumEnvelopesSolver(int uID, int Solver, int SolverMode, ref int NumLimitEnvelopes, ref int NumCombinationEnvelopes, ref int NumFactorsEnvelopes);
        [DllImport("St7API.dll")]
        public static extern int St7AddLimitEnvelope(int uID, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLimitEnvelope(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLimitEnvelope(int uID, int Envelope);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLimitEnvelopeCase(int uID, int Envelope, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLimitEnvelopeCase(int uID, int Envelope, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLimitEnvelopeCaseState(int uID, int Envelope, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetLimitEnvelopeData(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLimitEnvelopeData(int uID, int Envelope, ref int EnvType, StringBuilder EnvName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7AddCombinationEnvelope(int uID, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertCombinationEnvelope(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteCombinationEnvelope(int uID, int Envelope);
        [DllImport("St7API.dll")]
        public static extern int St7SetCombinationEnvelopeCase(int uID, int Envelope, int CaseNum, int State);
        [DllImport("St7API.dll")]
        public static extern int St7GetCombinationEnvelopeCase(int uID, int Envelope, int CaseNum, ref int State);
        [DllImport("St7API.dll")]
        public static extern int St7SetCombinationEnvelopeData(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7GetCombinationEnvelopeData(int uID, int Envelope, ref int EnvType, StringBuilder EnvName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7AddFactorsEnvelope(int uID, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertFactorsEnvelope(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteFactorsEnvelope(int uID, int Envelope);
        [DllImport("St7API.dll")]
        public static extern int St7SetFactorsEnvelopeData(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7GetFactorsEnvelopeData(int uID, int Envelope, ref int EnvType, StringBuilder EnvName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7AddFactorsEnvelopeCase(int uID, int Envelope);
        [DllImport("St7API.dll")]
        public static extern int St7InsertFactorsEnvelopeCase(int uID, int Envelope, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteFactorsEnvelopeCase(int uID, int Envelope, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7SetFactorsEnvelopeCaseData(int uID, int Envelope, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetFactorsEnvelopeCaseData(int uID, int Envelope, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7AddFactorsEnvelopeSet(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7InsertFactorsEnvelopeSet(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteFactorsEnvelopeSet(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumFactorsEnvelopeSets(int uID, ref int NumSets);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumFactorsEnvelopeCases(int uID, int Envelope, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetFactorsEnvelopeSetData(int uID, int Pos, int SetType, string SetName, string SetGroup);
        [DllImport("St7API.dll")]
        public static extern int St7GetFactorsEnvelopeSetData(int uID, int Pos, ref int SetType, StringBuilder SetName, StringBuilder SetGroup, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileCombTargetFileName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFileCombTargetFileName(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7AddResultFileCombFileName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteResultFileCombFileName(int uID, int FileNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileCombFileName(int uID, int FileNum, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFileCombFileName(int uID, int FileNum, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7AddResultFileCombCase(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteResultFileCombCase(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileCombCaseData(int uID, int FileNum, int Pos, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFileCombCaseData(int uID, int FileNum, int Pos, ref int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileCombCaseName(int uID, int Pos, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFileCombCaseName(int uID, int Pos, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateResultFileComb(int uID, int Method);
        [DllImport("St7API.dll")]
        public static extern int St7RetrieveResultFileComb(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateHRATimeHistory(int uID, double StartTime, double EndTime, int NumSteps, ref int WarningCode);
        [DllImport("St7API.dll")]
        public static extern int St7ClearHRATimeHistory(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7NewResFile(int uID, string FileName, int ResultType);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileUnits(int uID, int[] Units);
        [DllImport("St7API.dll")]
        public static extern int St7OpenResFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7CloseResFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileDescription(int uID, string Name);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileDescription(int uID, StringBuilder Name, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileNumCases(int uID, int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileCaseName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7AssociateResFileCase(int uID, int CaseNum, int LoadCase, int FreedomCase);
        [DllImport("St7API.dll")]
        public static extern int St7AssociateResFileStage(int uID, int CaseNum, int StageNum);
        [DllImport("St7API.dll")]
        public static extern int St7AssociateResFileNSMassCase(int uID, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileSRACases(int uID, int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileMode(int uID, int CaseNum, double Mode);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileMode(int uID, int CaseNum, ref double Mode);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileTime(int uID, int CaseNum, double Time);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileTime(int uID, int CaseNum, ref double Time);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileTimeUnit(int uID, int TimeUnit);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileTimeUnit(int uID, ref int TimeUnit);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileQuantity(int uID, int CaseNum, int Entity, int Quantity);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileFreedomCase(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7ClearResFileQuantity(int uID, int CaseNum, int Entity, int Quantity);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileQuantity(int uID, int CaseNum, int Entity, int Quantity, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileNodeResult(int uID, int CaseNum, int NodeNum, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileNodeResult(int uID, int CaseNum, int NodeNum, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileBeamResult(int uID, int CaseNum, int BeamNum, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileBeamResult(int uID, int CaseNum, int BeamNum, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileBeamReleaseResult(int uID, int CaseNum, int BeamNum, byte[] BeamReleased, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileBeamReleaseResult(int uID, int CaseNum, int BeamNum, byte[] BeamReleased, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileBeamStations(int uID, int CaseNum, int Stations);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileBeamStations(int uID, int CaseNum, ref int Stations);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFilePlateResult(int uID, int CaseNum, int PlateNum, int Quantity, byte NonlinearMaterial, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFilePlateResult(int uID, int CaseNum, int PlateNum, int Quantity, ref byte NonlinearMaterial, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFilePlatePressureResult(int uID, int CaseNum, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFilePlatePressureResult(int uID, int CaseNum, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileBrickResult(int uID, int CaseNum, int BrickNum, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileBrickResult(int uID, int CaseNum, int BrickNum, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetToolOptions(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetToolOptions(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCleanMeshOptions(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCleanMeshOptions(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7CleanMesh(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SurfaceMesh(int uID, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7SolidTetMesh(int uID, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7DirectSolidTetMesh(int uID, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7MeshFromLoops(int uID, int[] Integers, double[] Doubles, int[] Loops, double[] Points, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteUnusedNodes(int uID, ref int NumDeleted);
        [DllImport("St7API.dll")]
        public static extern int St7InvalidateElement(int uID, int Entity, int EntityNum);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteInvalidElements(int uID, int Entity, ref int NumDeleted);
        [DllImport("St7API.dll")]
        public static extern int St7SetPasteOptions(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7CopyToSt7Clipboard(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7CutToSt7Clipboard(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7PasteFromSt7ClipboardByIncrements(int uID, double[] Rotation, double[] Translation, double Scaling);
        [DllImport("St7API.dll")]
        public static extern int St7PasteFromSt7ClipboardByAnchors(int uID, int[] SourceAnchorType, int[] SourceAnchorID, int[] TargetAnchorType, int[] TargetAnchorID, double[] Rotation, double[] Translation, double Scaling);
        [DllImport("St7API.dll")]
        public static extern int St7SetProjectDirectionAsSource(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetProjectDirectionAsTarget(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetProjectDirectionAsConical(int uID, double[] Apex);
        [DllImport("St7API.dll")]
        public static extern int St7SetProjectDirectionAsParallel(int uID, double[] P1, double[] P2);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyIncrement(int uID, int PropInc);
        [DllImport("St7API.dll")]
        public static extern int St7SetKeepSelect(int uID, byte KeepSelect);
        [DllImport("St7API.dll")]
        public static extern int St7SetCopyFlags(int uID, int[] Flags);
        [DllImport("St7API.dll")]
        public static extern int St7SetExtrudeFlags(int uID, int[] Flags);
        [DllImport("St7API.dll")]
        public static extern int St7SetExtrudeTargets(int uID, int[] Targets);
        [DllImport("St7API.dll")]
        public static extern int St7SetSourceAction(int uID, int SourceAction);
        [DllImport("St7API.dll")]
        public static extern int St7SetPLTarget(int uID, int Target, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7DefineLineN2(int uID, int NodeNum1, int NodeNum2, ref int LineID);
        [DllImport("St7API.dll")]
        public static extern int St7DefineLineV2(int uID, int VertexNum1, int VertexNum2, ref int LineID);
        [DllImport("St7API.dll")]
        public static extern int St7DefineLineNV(int uID, int NodeNum, int VertexNum, byte Reversed, ref int LineID);
        [DllImport("St7API.dll")]
        public static extern int St7DefineLineP2(int uID, double[] P1, double[] P2, ref int LineID);
        [DllImport("St7API.dll")]
        public static extern int St7DefinePlaneGlobalN(int uID, int NodeNum, int Plane, ref int PlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7DefinePlaneGlobalV(int uID, int VertexNum, int Plane, ref int PlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7DefinePlaneP3(int uID, double[] P1, double[] P2, double[] P3, ref int PlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7DefinePlaneUCS(int uID, int UCSId, int UCSPlane, ref int PlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7DefineEntityCollection(int uID, ref int CollectionID);
        [DllImport("St7API.dll")]
        public static extern int St7CopyByIncrement(int uID, double[] DXYZ, int UCSId, int NumCopies);
        [DllImport("St7API.dll")]
        public static extern int St7CopyByRotation(int uID, int UCSId, int Axis, double Angle, double[] Origin, int NumCopies);
        [DllImport("St7API.dll")]
        public static extern int St7CopyByProjectionToLine(int uID, int LineID, byte EquiSpace);
        [DllImport("St7API.dll")]
        public static extern int St7CopyByProjectionToPlane(int uID, int PlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7CopyByProjectionToUCS(int uID, int UCSId, int UCSPlane, double Ordinate);
        [DllImport("St7API.dll")]
        public static extern int St7CopyByProjectionToEntityFace(int uID, int CollectionID);
        [DllImport("St7API.dll")]
        public static extern int St7CopyByThickness(int uID, double Thickness, int BeamDir, int PlateSurface, int FaceSurface, byte UsePlateThickness, byte UseFaceThickness);
        [DllImport("St7API.dll")]
        public static extern int St7CopyByMirror(int uID, int PlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7CopyToAbsolute(int uID, double Value, int UCSId, int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7MoveByIncrement(int uID, double[] DXYZ, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7MoveByRotation(int uID, int UCSId, int Axis, double Angle, double[] Origin);
        [DllImport("St7API.dll")]
        public static extern int St7MoveByProjectionToLine(int uID, int LineID, byte EquiSpace);
        [DllImport("St7API.dll")]
        public static extern int St7MoveByProjectionToPlane(int uID, int PlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7MoveByProjectionToUCS(int uID, int UCSId, int UCSPlane, double Ordinate);
        [DllImport("St7API.dll")]
        public static extern int St7MoveByProjectionToEntityFace(int uID, int CollectionID);
        [DllImport("St7API.dll")]
        public static extern int St7MoveByThickness(int uID, double Thickness, int BeamDir, int PlateSurface, int FaceSurface, byte UsePlateThickness, byte UseFaceThickness);
        [DllImport("St7API.dll")]
        public static extern int St7MoveByMirror(int uID, int PlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7MoveBySkew(int uID, double[] Origin, double[] Skew, int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7MoveToAbsolute(int uID, double Value, int UCSId, int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7MoveToUCSIntersection(int uID, int UCSId1, int UCSId2, double Ordinate1, double Ordinate2);
        [DllImport("St7API.dll")]
        public static extern int St7MoveToOriginByPoint(int uID, int UCSId, double[] Point);
        [DllImport("St7API.dll")]
        public static extern int St7MoveToOriginMinXYZ(int uID, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7MoveToPlane(int uID, int SourcePlaneID, int TargetPlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByIncrement(int uID, double[] DXYZ, int UCSId, int NumCopies);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByRotation(int uID, int UCSId, int Axis, double Angle, double[] Origin, int NumCopies);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByProjectionToPoint(int uID, double[] Point);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByProjectionToAveragePoint(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByProjectionToLine(int uID, int LineID, byte EquiSpace);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByProjectionToPlane(int uID, int PlaneID);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByProjectionToUCS(int uID, int UCSId, int UCSPlane, double Ordinate);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByProjectionToEntityFace(int uID, int CollectionID);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByThickness(int uID, double Thickness, int BeamDir, int PlateSurface, byte UsePlateThickness, byte SourceMidPlane);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeByLine(int uID, int CollectionID, int Divisions, int Direction, double RotationAngle, double RadialScale);
        [DllImport("St7API.dll")]
        public static extern int St7ExtrudeToAbsolute(int uID, double Value, int UCSId, int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7ScaleByCartesianUCS(int uID, int UCSId, int ScaleAbout, double[] Factors, double[] Point);
        [DllImport("St7API.dll")]
        public static extern int St7ScaleByCylindricalUCS(int uID, int UCSId, int ScaleAbout, double[] Factors, double[] Point, double AngularCentre);
        [DllImport("St7API.dll")]
        public static extern int St7ScaleBySphericalUCS(int uID, int UCSId, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7ScaleByToroidalUCS(int uID, int UCSId, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7ScaleByTaper(int uID, int UCSId, int LineID, int Axis, double Scale1, double Scale2);
        [DllImport("St7API.dll")]
        public static extern int St7GraftEdgesToFaces(int uID, int DistanceType, double Distance);
        [DllImport("St7API.dll")]
        public static extern int St7IntersectEdges(int uID, int DistanceType, double Distance, byte SplitFaces);
        [DllImport("St7API.dll")]
        public static extern int St7MorphEdges(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SplitFaceByVertices(int uID, int NumVertexSets, int[] VertexSetData);
        [DllImport("St7API.dll")]
        public static extern int St7SplitFaceByPlane(int uID, int PlaneID, int NumCutFaces, int NumRepeats, double Increment);
        [DllImport("St7API.dll")]
        public static extern int St7FaceFromPlate(int uID, byte NodeAttribToVertices, byte PlateAttribToFaces, byte CircularFaceEdges);
        [DllImport("St7API.dll")]
        public static extern int St7FaceFromBeamPolygon(int uID, int FaceNum, int PropNum, double EdgeTol, byte BeamPropAsLoop, byte BeamGroupAsLoop);
        [DllImport("St7API.dll")]
        public static extern int St7FaceFromCavity(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7RebuildFaces(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7RebuildFacesUV(int uID, int DegreeU, int DegreeV, int ControlPointsU, int ControlPointsV);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertToNURBS(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7MidPlaneThinSolids(int uID, double NormalsTol);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteCavityLoops(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DetachFaces(int uID, int DetachMode);
        [DllImport("St7API.dll")]
        public static extern int St7InsertVerticesOnEdge(int uID, int EdgeID, int NumVertex, int VertexType, double[] Positions);
        [DllImport("St7API.dll")]
        public static extern int St7SubdivideEdges(int uID, int Divisions, int VertexType);
        [DllImport("St7API.dll")]
        public static extern int St7Subdivide(int uID, int DivsA, int DivsB, int DivsC, int PlateTarget, int BrickTarget);
        [DllImport("St7API.dll")]
        public static extern int St7Grade(int uID, int GradeType, double GradeRatio);
        [DllImport("St7API.dll")]
        public static extern int St7CutElementsByLine(int uID, int LineID, int EdgeTol, int BeamPropNum, int PlatePropNum);
        [DllImport("St7API.dll")]
        public static extern int St7CutElementsByPlane(int uID, int PlaneID, int EdgeTol, int BeamPropNum, int PlatePropNum);
        [DllImport("St7API.dll")]
        public static extern int St7CutElementsByUCS(int uID, int UCSId, int EdgeTol, int BeamPropNum, int PlatePropNum, double Radius);
        [DllImport("St7API.dll")]
        public static extern int St7SplitBeams(int uID, double SplitRatio, int SplitType);
        [DllImport("St7API.dll")]
        public static extern int St7SubdivideBeams(int uID, double Length);
        [DllImport("St7API.dll")]
        public static extern int St7InterpolateBeamSections(int uID, int PropNum1, int PropNum2, int Divisions);
        [DllImport("St7API.dll")]
        public static extern int St7IntersectBeamsAndLinks(int uID, double MaxGap, double MinAngle, byte SplitBeams, byte SplitLinks, byte ConsiderEdgeMidsideNode);
        [DllImport("St7API.dll")]
        public static extern int St7LoftBeams(int uID, int CrossBeamPropNum, int PlatePropNum, int NumSteps, int NumSubSteps, byte MakeCrossBeams, byte MakePlates);
        [DllImport("St7API.dll")]
        public static extern int St7SliceOnPlane(int uID, int PlaneID, int PropNum, int NumRepeats, double Increment, byte DoBeams, byte DoPlates);
        [DllImport("St7API.dll")]
        public static extern int St7FilletPlates(int uID, double Radius, byte StitchPlates);
        [DllImport("St7API.dll")]
        public static extern int St7MidPlanePlateProjection(int uID, int PlateNum);
        [DllImport("St7API.dll")]
        public static extern int St7RepairTri3Mesh(int uID, double MaxAngle);
        [DllImport("St7API.dll")]
        public static extern int St7DetachElements(int uID, int ConnectionType, int UCSId, int DoFBits, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7PLLine2(int uID, double[] P1, double[] P2, int NumSteps);
        [DllImport("St7API.dll")]
        public static extern int St7PLParabola3(int uID, double[] P1, double[] P2, double[] P3, int NumSteps);
        [DllImport("St7API.dll")]
        public static extern int St7PLNormal3(int uID, double[] P1, double[] P2, double[] P3);
        [DllImport("St7API.dll")]
        public static extern int St7PLNormal3R(int uID, double[] P1, double[] P2, double[] P3, double Radius, int NumSteps);
        [DllImport("St7API.dll")]
        public static extern int St7PLExtend2R(int uID, double[] P1, double[] P2, double Radius, int NumSteps);
        [DllImport("St7API.dll")]
        public static extern int St7PLAverage2(int uID, double[] P1, double[] P2, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7PLFillet3R(int uID, double[] P1, double[] P2, double[] P3, double Radius, int NumSteps);
        [DllImport("St7API.dll")]
        public static extern int St7PLFillet4R(int uID, double[] P1, double[] P2, double[] P3, double[] P4, double Radius, int NumSteps);
        [DllImport("St7API.dll")]
        public static extern int St7PLCircleO3(int uID, double[] P1, double[] P2, double[] P3, int NumSteps, byte FullCircle);
        [DllImport("St7API.dll")]
        public static extern int St7PLEllipseO3(int uID, double[] P1, double[] P2, double[] P3, int NumSteps, byte FullCircle);
        [DllImport("St7API.dll")]
        public static extern int St7PLCurve3(int uID, double[] P1, double[] P2, double[] P3, int NumSteps);
        [DllImport("St7API.dll")]
        public static extern int St7PLCircleC3(int uID, double[] P1, double[] P2, double[] P3, int NumSteps, byte FullCircle);
        [DllImport("St7API.dll")]
        public static extern int St7PLCirclesTangent3R(int uID, double[] P1, double[] P2, double[] P3, double R1, double R2);
        [DllImport("St7API.dll")]
        public static extern int St7PLIntersect4(int uID, double[] P1, double[] P2, double[] P3, double[] P4);
        [DllImport("St7API.dll")]
        public static extern int St7PLCircleTangent3R(int uID, double[] P1, double[] P2, double[] P3, double Radius);
        [DllImport("St7API.dll")]
        public static extern int St7PLCircleCentre3(int uID, double[] P1, double[] P2, double[] P3);
        [DllImport("St7API.dll")]
        public static extern int St7PLCirclesIntersect3R(int uID, double[] P1, double[] P2, double[] P3, double R1, double R2);
        [DllImport("St7API.dll")]
        public static extern int St7PLCircleLineInnerFillet3R(int uID, double[] P1, double[] P2, double[] P3, double R1, double R2, int NumSteps, byte FullCircle);
        [DllImport("St7API.dll")]
        public static extern int St7PLCircleLineOuterFillet3R(int uID, double[] P1, double[] P2, double[] P3, double R1, double R2, int NumSteps, byte FullCircle);
        [DllImport("St7API.dll")]
        public static extern int St7PLCircleLineIntersect3(int uID, double[] P1, double[] P2, double[] P3, double Radius);
        [DllImport("St7API.dll")]
        public static extern int St7PLCirclesFillet3R(int uID, double[] P1, double[] P2, double[] P3, double R1, double R2, double R3, int NumSteps, byte FullCircle);
        [DllImport("St7API.dll")]
        public static extern int St7CreateRigidLinkCluster(int uID, int UCSId, int Axis, int NodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7CreatePinnedLinkCluster(int uID, int NodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7CreateMasterSlaveLinkCluster(int uID, int UCSId, int DoFBits, int NodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7CreateSectorSymmetryLinkCluster(int uID, int Axis, double Plane1, double Plane2, double RadialTol, double AngularTol);
        [DllImport("St7API.dll")]
        public static extern int St7CreateInterpolatedMultiPointLink(int uID, int Couple, int NodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7CreateRigidMultiPointLink(int uID, int UCSId, int Axis, int NodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7CreatePinnedMultiPointLink(int uID, int NodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7CreateMasterSlaveMultiPointLink(int uID, int UCSId, int DoFBits, int NodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7CreateReactionMultiPointLink(int uID, int SetNum, int OriginCode, double[] Origin);
        [DllImport("St7API.dll")]
        public static extern int St7CreateLinksFromMultiPointLink(int uID, byte DeleteMPL);
        [DllImport("St7API.dll")]
        public static extern int St7CreateBeamsOnElementEdges(int uID, int PropNum, int QuadraticAs, int BasedOn, double FacetAngle, byte FreeEdges, byte TJunctions, byte PropBoundary, byte GroupBoundary, byte InternalBricks);
        [DllImport("St7API.dll")]
        public static extern int St7CreateBeamsOnGeometryEdges(int uID, int PropNum, int GeometryAs);
        [DllImport("St7API.dll")]
        public static extern int St7CreatePlatesOnBricks(int uID, byte FreeFacesOnly);
        [DllImport("St7API.dll")]
        public static extern int St7CreateEntityUCS(int uID, int CurvedPipeAxis, int BeamAxis, int OriginLocation, byte OriginNode);
        [DllImport("St7API.dll")]
        public static extern int St7CreateLoadPatches(int uID, double PlaneTol, byte TriangularLoad);
        [DllImport("St7API.dll")]
        public static extern int St7CreateAttachments(int uID, int BrickTarget, double AngleDelta, byte DeleteExisting);
        [DllImport("St7API.dll")]
        public static extern int St7CreateCartesianSymmetryRestraints(int uID, int FreedomCase);
        [DllImport("St7API.dll")]
        public static extern int St7CreateCylindricalSymmetryRestraints(int uID, int Axis, int FreedomCase, double Theta1, double Theta2, double AngularTol);
        [DllImport("St7API.dll")]
        public static extern int St7MergeElementPairs(int uID, byte Quadratic);
        [DllImport("St7API.dll")]
        public static extern int St7MergeLineOfBeams(int uID, double AngleTol, int AngleMode);
        [DllImport("St7API.dll")]
        public static extern int St7MergeTriToQuad(int uID, double MinInternalAngle, double MaxInternalAngle, double MaxNormalAngle);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertBeamsToLinks(int uID, int LinkType, int LinkOption, int CaseID);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertLinksToBeams(int uID, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertBeamOffsetsToRigidLinks(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertPatchLoads(int uID, int CaseNum, byte Overwrite);
        [DllImport("St7API.dll")]
        public static extern int St7CheckPatchLoads(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertLoadPathsToLoadCases(int uID, byte PointForces, byte DistributedForces, byte HeatSources);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertBeamPolygonsToPlates(int uID, double MinInternalAngle, double MaxInternalAngle, double MaxNormalAngle, byte CreateQuad4);
        [DllImport("St7API.dll")]
        public static extern int St7AdjustMidsideNodes(int uID, byte MakeStraight);
        [DllImport("St7API.dll")]
        public static extern int St7SmoothPlates(int uID, int UCSId, byte SmoothBoundary);
        [DllImport("St7API.dll")]
        public static extern int St7ReorderNodesTree(int uID, int StartNodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7ReorderNodesGeometry(int uID, double[] DXYZ);
        [DllImport("St7API.dll")]
        public static extern int St7ReorderNodesAMD(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7CorrectAttachmentLinkGroups(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7TrimMultiPointLinks(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7BeamOffsetsByCrossSection(int uID, int[] Offsets);
        [DllImport("St7API.dll")]
        public static extern int St7AlignBeamAxesToUCS(int uID, int BeamAxis, int BeamAxisType, int UCSAxis, int UCSId, double AngleTol, byte KeepEndAttributeLocation);
        [DllImport("St7API.dll")]
        public static extern int St7AlignBeamAxesToFramework(int uID, int BeamAxis, int BeamAxisType, byte PositiveDir);
        [DllImport("St7API.dll")]
        public static extern int St7AlignBeamAxesToPlate(int uID, int BeamAxis, int BeamAxisType, byte PositiveDir);
        [DllImport("St7API.dll")]
        public static extern int St7AlignBeamAxisToVector(int uID, int BeamAxis, int BeamAxisType, double AngleTol, double[] Vector);
        [DllImport("St7API.dll")]
        public static extern int St7RemoveBeamReferenceNode(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7PlateOffsetByThickness(int uID, int Surface);
        [DllImport("St7API.dll")]
        public static extern int St7AlignPlateAxesToUCS(int uID, int PlateAxis, int UCSAxis, int UCSId, double AngleTol);
        [DllImport("St7API.dll")]
        public static extern int St7AlignPlateNormalByConnection(int uID, int PlateNum);
        [DllImport("St7API.dll")]
        public static extern int St7AlignPlateRCDirectionsToUCS(int uID, int RCLayers, int UCSAxis, int UCSId, double AngleTol);
        [DllImport("St7API.dll")]
        public static extern int St7AlignFaceNormalByConnection(int uID, int FaceNum);
        [DllImport("St7API.dll")]
        public static extern int St7AlignBeam3AxisByConnection(int uID, byte KeepEndAttributeLocation);
        [DllImport("St7API.dll")]
        public static extern int St7AlignPlateAxesByConnection(int uID, int PlateNum, double MaxShearAngle);
        [DllImport("St7API.dll")]
        public static extern int St7RotatePlateConnections(int uID, byte Clockwise);
        [DllImport("St7API.dll")]
        public static extern int St7FlipEntity(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7InvertPathNormal(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetInsituStressOptions(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7InsituStress(int uID, int Mode, int Wait, int[] Integers, double[] Doubles, ref int ProcessID, ref int WarningCode);
        [DllImport("St7API.dll")]
        public static extern int St7GetGlobalIntegerValue(int Index, ref int Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetGlobalLogicalValue(int Index, ref byte Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetGlobalStringValue(int Index, StringBuilder Value, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7ClearGlobalIntegerValues();
        [DllImport("St7API.dll")]
        public static extern int St7ClearGlobalLogicalValues();
        [DllImport("St7API.dll")]
        public static extern int St7ClearGlobalStringValues();
        [DllImport("St7API.dll")]
        public static extern int St7RGBToColour(double Red, double Green, double Blue, ref int Colour);
        [DllImport("St7API.dll")]
        public static extern int St7ColourToRGB(int Colour, ref double Red, ref double Green, ref double Blue);
    }
}
