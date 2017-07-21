using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class MWQMRunTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMRunID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMRun GetFilledRandomMWQMRun(string OmitPropName)
        {
            MWQMRunID += 1;

            MWQMRun mwqmRun = new MWQMRun();

            if (OmitPropName != "MWQMRunID") mwqmRun.MWQMRunID = MWQMRunID;
            if (OmitPropName != "SubsectorTVItemID") mwqmRun.SubsectorTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "MWQMRunTVItemID") mwqmRun.MWQMRunTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "RunSampleType") mwqmRun.RunSampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "DateTime_Local") mwqmRun.DateTime_Local = GetRandomDateTime();
            if (OmitPropName != "RunNumber") mwqmRun.RunNumber = GetRandomInt(1, 1000);
            if (OmitPropName != "StartDateTime_Local") mwqmRun.StartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "EndDateTime_Local") mwqmRun.EndDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "LabReceivedDateTime_Local") mwqmRun.LabReceivedDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "TemperatureControl1_C") mwqmRun.TemperatureControl1_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TemperatureControl2_C") mwqmRun.TemperatureControl2_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SeaStateAtStart_BeaufortScale") mwqmRun.SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)GetRandomEnumType(typeof(BeaufortScaleEnum));
            if (OmitPropName != "SeaStateAtEnd_BeaufortScale") mwqmRun.SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)GetRandomEnumType(typeof(BeaufortScaleEnum));
            if (OmitPropName != "WaterLevelAtBrook_m") mwqmRun.WaterLevelAtBrook_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "WaveHightAtStart_m") mwqmRun.WaveHightAtStart_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "WaveHightAtEnd_m") mwqmRun.WaveHightAtEnd_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SampleCrewInitials") mwqmRun.SampleCrewInitials = GetRandomString("", 5);
            if (OmitPropName != "AnalyzeMethod") mwqmRun.AnalyzeMethod = (AnalyzeMethodEnum)GetRandomEnumType(typeof(AnalyzeMethodEnum));
            if (OmitPropName != "SampleMatrix") mwqmRun.SampleMatrix = (SampleMatrixEnum)GetRandomEnumType(typeof(SampleMatrixEnum));
            if (OmitPropName != "Laboratory") mwqmRun.Laboratory = (LaboratoryEnum)GetRandomEnumType(typeof(LaboratoryEnum));
            if (OmitPropName != "SampleStatus") mwqmRun.SampleStatus = (SampleStatusEnum)GetRandomEnumType(typeof(SampleStatusEnum));
            if (OmitPropName != "LabSampleApprovalContactTVItemID") mwqmRun.LabSampleApprovalContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "LabAnalyzeBath1IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "LabAnalyzeBath2IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "LabAnalyzeBath3IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "LabRunSampleApprovalDateTime_Local") mwqmRun.LabRunSampleApprovalDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Tide_Start") mwqmRun.Tide_Start = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "Tide_End") mwqmRun.Tide_End = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "RainDay0_mm") mwqmRun.RainDay0_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay1_mm") mwqmRun.RainDay1_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay2_mm") mwqmRun.RainDay2_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay3_mm") mwqmRun.RainDay3_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay4_mm") mwqmRun.RainDay4_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay5_mm") mwqmRun.RainDay5_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay6_mm") mwqmRun.RainDay6_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay7_mm") mwqmRun.RainDay7_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay8_mm") mwqmRun.RainDay8_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay9_mm") mwqmRun.RainDay9_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainDay10_mm") mwqmRun.RainDay10_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RemoveFromStat") mwqmRun.RemoveFromStat = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRun.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRun.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mwqmRun;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMRun_Testing()
        {
            SetupTestHelper(culture);
            MWQMRunService mwqmRunService = new MWQMRunService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            MWQMRun mwqmRun = GetFilledRandomMWQMRun("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(true, mwqmRunService.GetRead().Where(c => c == mwqmRun).Any());
            mwqmRun.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mwqmRunService.Update(mwqmRun));
            Assert.AreEqual(1, mwqmRunService.GetRead().Count());
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // SubsectorTVItemID will automatically be initialized at 0 --> not null

            // MWQMRunTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [RunSampleType]

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("DateTime_Local");
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(1, mwqmRun.ValidationResults.Count());
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunDateTime_Local)).Any());
            Assert.IsTrue(mwqmRun.DateTime_Local.Year < 1900);
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());

            // RunNumber will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TemperatureControl1_C]

            //Error: Type not implemented [TemperatureControl2_C]

            //Error: Type not implemented [SeaStateAtStart_BeaufortScale]

            //Error: Type not implemented [SeaStateAtEnd_BeaufortScale]

            //Error: Type not implemented [WaterLevelAtBrook_m]

            //Error: Type not implemented [WaveHightAtStart_m]

            //Error: Type not implemented [WaveHightAtEnd_m]

            //Error: Type not implemented [AnalyzeMethod]

            //Error: Type not implemented [SampleMatrix]

            //Error: Type not implemented [Laboratory]

            //Error: Type not implemented [SampleStatus]

            //Error: Type not implemented [Tide_Start]

            //Error: Type not implemented [Tide_End]

            //Error: Type not implemented [RainDay0_mm]

            //Error: Type not implemented [RainDay1_mm]

            //Error: Type not implemented [RainDay2_mm]

            //Error: Type not implemented [RainDay3_mm]

            //Error: Type not implemented [RainDay4_mm]

            //Error: Type not implemented [RainDay5_mm]

            //Error: Type not implemented [RainDay6_mm]

            //Error: Type not implemented [RainDay7_mm]

            //Error: Type not implemented [RainDay8_mm]

            //Error: Type not implemented [RainDay9_mm]

            //Error: Type not implemented [RainDay10_mm]

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(1, mwqmRun.ValidationResults.Count());
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmRun.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MWQMRunLanguages]

            //Error: Type not implemented [LabSampleApprovalContactTVItem]

            //Error: Type not implemented [MWQMRunTVItem]

            //Error: Type not implemented [SubsectorTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMRunID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [SubsectorTVItemID] of type [Int32]
            //-----------------------------------

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRun.SubsectorTVItemID = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.SubsectorTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRun.SubsectorTVItemID = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.SubsectorTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRun.SubsectorTVItemID = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRun.SubsectorTVItemID);
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMRunTVItemID] of type [Int32]
            //-----------------------------------

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRun.MWQMRunTVItemID = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.MWQMRunTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRun.MWQMRunTVItemID = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.MWQMRunTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRun.MWQMRunTVItemID = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunMWQMRunTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRun.MWQMRunTVItemID);
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());

            //-----------------------------------
            // doing property [RunSampleType] of type [SampleTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [DateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [RunNumber] of type [Int32]
            //-----------------------------------

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RunNumber has Min [1] and Max [1000]. At Min should return true and no errors
            mwqmRun.RunNumber = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.RunNumber);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Min + 1 should return true and no errors
            mwqmRun.RunNumber = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.RunNumber);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Min - 1 should return false with one error
            mwqmRun.RunNumber = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRunNumber, "1", "1000")).Any());
            Assert.AreEqual(0, mwqmRun.RunNumber);
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Max should return true and no errors
            mwqmRun.RunNumber = 1000;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1000, mwqmRun.RunNumber);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Max - 1 should return true and no errors
            mwqmRun.RunNumber = 999;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(999, mwqmRun.RunNumber);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Max + 1 should return false with one error
            mwqmRun.RunNumber = 1001;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRunNumber, "1", "1000")).Any());
            Assert.AreEqual(1001, mwqmRun.RunNumber);
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());

            //-----------------------------------
            // doing property [StartDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EndDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabReceivedDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [TemperatureControl1_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TemperatureControl2_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SeaStateAtStart_BeaufortScale] of type [BeaufortScaleEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [SeaStateAtEnd_BeaufortScale] of type [BeaufortScaleEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [WaterLevelAtBrook_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [WaveHightAtStart_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [WaveHightAtEnd_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SampleCrewInitials] of type [String]
            //-----------------------------------

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");

            //-----------------------------------
            // doing property [AnalyzeMethod] of type [AnalyzeMethodEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [SampleMatrix] of type [SampleMatrixEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Laboratory] of type [LaboratoryEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [SampleStatus] of type [SampleStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSampleApprovalContactTVItemID] of type [Int32]
            //-----------------------------------

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // LabSampleApprovalContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRun.LabSampleApprovalContactTVItemID = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.LabSampleApprovalContactTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // LabSampleApprovalContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRun.LabSampleApprovalContactTVItemID = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.LabSampleApprovalContactTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // LabSampleApprovalContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRun.LabSampleApprovalContactTVItemID = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLabSampleApprovalContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRun.LabSampleApprovalContactTVItemID);
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());

            //-----------------------------------
            // doing property [LabAnalyzeBath1IncubationStartDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabAnalyzeBath2IncubationStartDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabAnalyzeBath3IncubationStartDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabRunSampleApprovalDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Tide_Start] of type [TideTextEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Tide_End] of type [TideTextEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay0_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay1_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay2_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay3_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay4_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay5_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay6_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay7_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay8_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay9_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainDay10_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RemoveFromStat] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRun.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRun.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRun.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRun.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mwqmRunService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMRunLanguages] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSampleApprovalContactTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMRunTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [SubsectorTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
