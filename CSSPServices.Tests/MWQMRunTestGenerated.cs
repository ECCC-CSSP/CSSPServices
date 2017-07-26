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
        private MWQMRunService mwqmRunService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunTest() : base()
        {
            mwqmRunService = new MWQMRunService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMRun GetFilledRandomMWQMRun(string OmitPropName)
        {
            MWQMRun mwqmRun = new MWQMRun();

            if (OmitPropName != "SubsectorTVItemID") mwqmRun.SubsectorTVItemID = 11;
            if (OmitPropName != "MWQMRunTVItemID") mwqmRun.MWQMRunTVItemID = 24;
            if (OmitPropName != "RunSampleType") mwqmRun.RunSampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "DateTime_Local") mwqmRun.DateTime_Local = GetRandomDateTime();
            if (OmitPropName != "RunNumber") mwqmRun.RunNumber = GetRandomInt(1, 1000);
            if (OmitPropName != "StartDateTime_Local") mwqmRun.StartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "EndDateTime_Local") mwqmRun.EndDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "LabReceivedDateTime_Local") mwqmRun.LabReceivedDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "TemperatureControl1_C") mwqmRun.TemperatureControl1_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TemperatureControl2_C") mwqmRun.TemperatureControl2_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SeaStateAtStart_BeaufortScale") mwqmRun.SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)GetRandomEnumType(typeof(BeaufortScaleEnum));
            if (OmitPropName != "SeaStateAtEnd_BeaufortScale") mwqmRun.SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)GetRandomEnumType(typeof(BeaufortScaleEnum));
            if (OmitPropName != "WaterLevelAtBrook_m") mwqmRun.WaterLevelAtBrook_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "WaveHightAtStart_m") mwqmRun.WaveHightAtStart_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "WaveHightAtEnd_m") mwqmRun.WaveHightAtEnd_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "SampleCrewInitials") mwqmRun.SampleCrewInitials = GetRandomString("", 5);
            if (OmitPropName != "AnalyzeMethod") mwqmRun.AnalyzeMethod = (AnalyzeMethodEnum)GetRandomEnumType(typeof(AnalyzeMethodEnum));
            if (OmitPropName != "SampleMatrix") mwqmRun.SampleMatrix = (SampleMatrixEnum)GetRandomEnumType(typeof(SampleMatrixEnum));
            if (OmitPropName != "Laboratory") mwqmRun.Laboratory = (LaboratoryEnum)GetRandomEnumType(typeof(LaboratoryEnum));
            if (OmitPropName != "SampleStatus") mwqmRun.SampleStatus = (SampleStatusEnum)GetRandomEnumType(typeof(SampleStatusEnum));
            if (OmitPropName != "LabSampleApprovalContactTVItemID") mwqmRun.LabSampleApprovalContactTVItemID = 2;
            if (OmitPropName != "LabAnalyzeBath1IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "LabAnalyzeBath2IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "LabAnalyzeBath3IncubationStartDateTime_Local") mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "LabRunSampleApprovalDateTime_Local") mwqmRun.LabRunSampleApprovalDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Tide_Start") mwqmRun.Tide_Start = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "Tide_End") mwqmRun.Tide_End = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "RainDay0_mm") mwqmRun.RainDay0_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay1_mm") mwqmRun.RainDay1_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay2_mm") mwqmRun.RainDay2_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay3_mm") mwqmRun.RainDay3_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay4_mm") mwqmRun.RainDay4_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay5_mm") mwqmRun.RainDay5_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay6_mm") mwqmRun.RainDay6_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay7_mm") mwqmRun.RainDay7_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay8_mm") mwqmRun.RainDay8_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay9_mm") mwqmRun.RainDay9_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay10_mm") mwqmRun.RainDay10_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RemoveFromStat") mwqmRun.RemoveFromStat = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRun.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRun.LastUpdateContactTVItemID = 2;

            return mwqmRun;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMRun_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MWQMRun mwqmRun = GetFilledRandomMWQMRun("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = mwqmRunService.GetRead().Count();

            mwqmRunService.Add(mwqmRun);
            if (mwqmRun.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mwqmRunService.GetRead().Where(c => c == mwqmRun).Any());
            mwqmRunService.Update(mwqmRun);
            if (mwqmRun.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mwqmRunService.GetRead().Count());
            mwqmRunService.Delete(mwqmRun);
            if (mwqmRun.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // mwqmRun.MWQMRunID   (Int32)
            //-----------------------------------
            mwqmRun = GetFilledRandomMWQMRun("");
            mwqmRun.MWQMRunID = 0;
            mwqmRunService.Update(mwqmRun);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunMWQMRunID), mwqmRun.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Subsector)]
            //[Range(1, -1)]
            // mwqmRun.SubsectorTVItemID   (Int32)
            //-----------------------------------
            // SubsectorTVItemID will automatically be initialized at 0 --> not null


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRun.SubsectorTVItemID = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.SubsectorTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRun.SubsectorTVItemID = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.SubsectorTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRun.SubsectorTVItemID = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRun.SubsectorTVItemID);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMRun)]
            //[Range(1, -1)]
            // mwqmRun.MWQMRunTVItemID   (Int32)
            //-----------------------------------
            // MWQMRunTVItemID will automatically be initialized at 0 --> not null


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRun.MWQMRunTVItemID = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.MWQMRunTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRun.MWQMRunTVItemID = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.MWQMRunTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRun.MWQMRunTVItemID = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunMWQMRunTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRun.MWQMRunTVItemID);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // mwqmRun.RunSampleType   (SampleTypeEnum)
            //-----------------------------------
            // RunSampleType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmRun.DateTime_Local   (DateTime)
            //-----------------------------------
            // DateTime_Local will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[Range(1, 1000)]
            // mwqmRun.RunNumber   (Int32)
            //-----------------------------------
            // RunNumber will automatically be initialized at 0 --> not null


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RunNumber has Min [1] and Max [1000]. At Min should return true and no errors
            mwqmRun.RunNumber = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.RunNumber);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Min + 1 should return true and no errors
            mwqmRun.RunNumber = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.RunNumber);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Min - 1 should return false with one error
            mwqmRun.RunNumber = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRunNumber, "1", "1000")).Any());
            Assert.AreEqual(0, mwqmRun.RunNumber);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Max should return true and no errors
            mwqmRun.RunNumber = 1000;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1000, mwqmRun.RunNumber);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Max - 1 should return true and no errors
            mwqmRun.RunNumber = 999;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(999, mwqmRun.RunNumber);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RunNumber has Min [1] and Max [1000]. At Max + 1 should return false with one error
            mwqmRun.RunNumber = 1001;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRunNumber, "1", "1000")).Any());
            Assert.AreEqual(1001, mwqmRun.RunNumber);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmRun.StartDateTime_Local   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            //[CSSPBigger(OtherField = StartDateTime_Local)]
            // mwqmRun.EndDateTime_Local   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmRun.LabReceivedDateTime_Local   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // mwqmRun.TemperatureControl1_C   (Double)
            //-----------------------------------
            //Error: Type not implemented [TemperatureControl1_C]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // TemperatureControl1_C has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            mwqmRun.TemperatureControl1_C = -10.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(-10.0D, mwqmRun.TemperatureControl1_C);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl1_C has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mwqmRun.TemperatureControl1_C = -9.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(-9.0D, mwqmRun.TemperatureControl1_C);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl1_C has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mwqmRun.TemperatureControl1_C = -11.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl1_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, mwqmRun.TemperatureControl1_C);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl1_C has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            mwqmRun.TemperatureControl1_C = 40.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(40.0D, mwqmRun.TemperatureControl1_C);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl1_C has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mwqmRun.TemperatureControl1_C = 39.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(39.0D, mwqmRun.TemperatureControl1_C);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl1_C has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mwqmRun.TemperatureControl1_C = 41.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl1_C, "-10", "40")).Any());
            Assert.AreEqual(41.0D, mwqmRun.TemperatureControl1_C);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // mwqmRun.TemperatureControl2_C   (Double)
            //-----------------------------------
            //Error: Type not implemented [TemperatureControl2_C]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // TemperatureControl2_C has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            mwqmRun.TemperatureControl2_C = -10.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(-10.0D, mwqmRun.TemperatureControl2_C);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl2_C has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mwqmRun.TemperatureControl2_C = -9.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(-9.0D, mwqmRun.TemperatureControl2_C);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl2_C has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mwqmRun.TemperatureControl2_C = -11.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl2_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, mwqmRun.TemperatureControl2_C);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl2_C has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            mwqmRun.TemperatureControl2_C = 40.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(40.0D, mwqmRun.TemperatureControl2_C);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl2_C has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mwqmRun.TemperatureControl2_C = 39.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(39.0D, mwqmRun.TemperatureControl2_C);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // TemperatureControl2_C has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mwqmRun.TemperatureControl2_C = 41.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl2_C, "-10", "40")).Any());
            Assert.AreEqual(41.0D, mwqmRun.TemperatureControl2_C);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPEnumType]
            // mwqmRun.SeaStateAtStart_BeaufortScale   (BeaufortScaleEnum)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPEnumType]
            // mwqmRun.SeaStateAtEnd_BeaufortScale   (BeaufortScaleEnum)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[Range(0, 100)]
            // mwqmRun.WaterLevelAtBrook_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [WaterLevelAtBrook_m]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // WaterLevelAtBrook_m has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            mwqmRun.WaterLevelAtBrook_m = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.WaterLevelAtBrook_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaterLevelAtBrook_m has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            mwqmRun.WaterLevelAtBrook_m = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.WaterLevelAtBrook_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaterLevelAtBrook_m has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            mwqmRun.WaterLevelAtBrook_m = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.WaterLevelAtBrook_m);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaterLevelAtBrook_m has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            mwqmRun.WaterLevelAtBrook_m = 100.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(100.0D, mwqmRun.WaterLevelAtBrook_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaterLevelAtBrook_m has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            mwqmRun.WaterLevelAtBrook_m = 99.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(99.0D, mwqmRun.WaterLevelAtBrook_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaterLevelAtBrook_m has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            mwqmRun.WaterLevelAtBrook_m = 101.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100")).Any());
            Assert.AreEqual(101.0D, mwqmRun.WaterLevelAtBrook_m);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 100)]
            // mwqmRun.WaveHightAtStart_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [WaveHightAtStart_m]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // WaveHightAtStart_m has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            mwqmRun.WaveHightAtStart_m = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.WaveHightAtStart_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtStart_m has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            mwqmRun.WaveHightAtStart_m = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.WaveHightAtStart_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtStart_m has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            mwqmRun.WaveHightAtStart_m = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtStart_m, "0", "100")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.WaveHightAtStart_m);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtStart_m has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            mwqmRun.WaveHightAtStart_m = 100.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(100.0D, mwqmRun.WaveHightAtStart_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtStart_m has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            mwqmRun.WaveHightAtStart_m = 99.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(99.0D, mwqmRun.WaveHightAtStart_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtStart_m has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            mwqmRun.WaveHightAtStart_m = 101.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtStart_m, "0", "100")).Any());
            Assert.AreEqual(101.0D, mwqmRun.WaveHightAtStart_m);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 100)]
            // mwqmRun.WaveHightAtEnd_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [WaveHightAtEnd_m]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // WaveHightAtEnd_m has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            mwqmRun.WaveHightAtEnd_m = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.WaveHightAtEnd_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtEnd_m has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            mwqmRun.WaveHightAtEnd_m = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.WaveHightAtEnd_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtEnd_m has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            mwqmRun.WaveHightAtEnd_m = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.WaveHightAtEnd_m);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtEnd_m has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            mwqmRun.WaveHightAtEnd_m = 100.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(100.0D, mwqmRun.WaveHightAtEnd_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtEnd_m has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            mwqmRun.WaveHightAtEnd_m = 99.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(99.0D, mwqmRun.WaveHightAtEnd_m);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // WaveHightAtEnd_m has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            mwqmRun.WaveHightAtEnd_m = 101.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100")).Any());
            Assert.AreEqual(101.0D, mwqmRun.WaveHightAtEnd_m);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(20))]
            // mwqmRun.SampleCrewInitials   (String)
            //-----------------------------------

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");

            // SampleCrewInitials has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string mwqmRunSampleCrewInitialsMin = GetRandomString("", 20);
            mwqmRun.SampleCrewInitials = mwqmRunSampleCrewInitialsMin;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(mwqmRunSampleCrewInitialsMin, mwqmRun.SampleCrewInitials);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            // SampleCrewInitials has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            mwqmRunSampleCrewInitialsMin = GetRandomString("", 19);
            mwqmRun.SampleCrewInitials = mwqmRunSampleCrewInitialsMin;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(mwqmRunSampleCrewInitialsMin, mwqmRun.SampleCrewInitials);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            // SampleCrewInitials has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            mwqmRunSampleCrewInitialsMin = GetRandomString("", 21);
            mwqmRun.SampleCrewInitials = mwqmRunSampleCrewInitialsMin;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunSampleCrewInitials, "20")).Any());
            Assert.AreEqual(mwqmRunSampleCrewInitialsMin, mwqmRun.SampleCrewInitials);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPEnumType]
            // mwqmRun.AnalyzeMethod   (AnalyzeMethodEnum)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPEnumType]
            // mwqmRun.SampleMatrix   (SampleMatrixEnum)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPEnumType]
            // mwqmRun.Laboratory   (LaboratoryEnum)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPEnumType]
            // mwqmRun.SampleStatus   (SampleStatusEnum)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // mwqmRun.LabSampleApprovalContactTVItemID   (Int32)
            //-----------------------------------

            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // LabSampleApprovalContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRun.LabSampleApprovalContactTVItemID = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.LabSampleApprovalContactTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // LabSampleApprovalContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRun.LabSampleApprovalContactTVItemID = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.LabSampleApprovalContactTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // LabSampleApprovalContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRun.LabSampleApprovalContactTVItemID = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLabSampleApprovalContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRun.LabSampleApprovalContactTVItemID);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmRun.LabRunSampleApprovalDateTime_Local   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPEnumType]
            // mwqmRun.Tide_Start   (TideTextEnum)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPEnumType]
            // mwqmRun.Tide_End   (TideTextEnum)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay0_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay0_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay0_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay0_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay0_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay0_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay0_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay0_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay0_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay0_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay0_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay0_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay0_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay0_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay0_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay0_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay0_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay0_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay0_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay0_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay0_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay0_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay1_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay1_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay1_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay1_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay1_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay1_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay1_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay1_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay1_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay1_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay1_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay1_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay1_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay1_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay1_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay1_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay1_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay1_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay1_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay1_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay1_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay1_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay2_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay2_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay2_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay2_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay2_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay2_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay2_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay2_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay2_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay2_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay2_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay2_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay2_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay2_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay2_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay2_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay2_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay2_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay2_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay2_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay2_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay2_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay3_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay3_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay3_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay3_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay3_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay3_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay3_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay3_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay3_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay3_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay3_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay3_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay3_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay3_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay3_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay3_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay3_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay3_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay3_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay3_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay3_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay3_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay4_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay4_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay4_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay4_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay4_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay4_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay4_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay4_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay4_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay4_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay4_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay4_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay4_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay4_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay4_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay4_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay4_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay4_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay4_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay4_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay4_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay4_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay5_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay5_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay5_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay5_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay5_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay5_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay5_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay5_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay5_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay5_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay5_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay5_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay5_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay5_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay5_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay5_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay5_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay5_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay5_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay5_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay5_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay5_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay6_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay6_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay6_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay6_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay6_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay6_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay6_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay6_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay6_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay6_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay6_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay6_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay6_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay6_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay6_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay6_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay6_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay6_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay6_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay6_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay6_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay6_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay7_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay7_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay7_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay7_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay7_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay7_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay7_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay7_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay7_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay7_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay7_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay7_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay7_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay7_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay7_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay7_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay7_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay7_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay7_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay7_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay7_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay7_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay8_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay8_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay8_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay8_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay8_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay8_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay8_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay8_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay8_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay8_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay8_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay8_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay8_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay8_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay8_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay8_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay8_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay8_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay8_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay8_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay8_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay8_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay9_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay9_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay9_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay9_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay9_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay9_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay9_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay9_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay9_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay9_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay9_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay9_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay9_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay9_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay9_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay9_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay9_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay9_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay9_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay9_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay9_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay9_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // mwqmRun.RainDay10_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainDay10_mm]


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // RainDay10_mm has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmRun.RainDay10_mm = 0.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmRun.RainDay10_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay10_mm has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmRun.RainDay10_mm = 1.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmRun.RainDay10_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay10_mm has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmRun.RainDay10_mm = -1.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay10_mm, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmRun.RainDay10_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay10_mm has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmRun.RainDay10_mm = 300.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmRun.RainDay10_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay10_mm has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmRun.RainDay10_mm = 299.0D;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmRun.RainDay10_mm);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // RainDay10_mm has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmRun.RainDay10_mm = 301.0D;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay10_mm, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmRun.RainDay10_mm);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            // mwqmRun.RemoveFromStat   (Boolean)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmRun.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // mwqmRun.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            mwqmRun = null;
            mwqmRun = GetFilledRandomMWQMRun("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRun.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRun.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRun.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmRunService.Add(mwqmRun));
            Assert.AreEqual(0, mwqmRun.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRun.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmRunService.Delete(mwqmRun));
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRun.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmRunService.Add(mwqmRun));
            Assert.IsTrue(mwqmRun.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRun.LastUpdateContactTVItemID);
            Assert.AreEqual(count, mwqmRunService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mwqmRun.MWQMRunLanguages   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mwqmRun.LabSampleApprovalContactTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mwqmRun.MWQMRunTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mwqmRun.SubsectorTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // mwqmRun.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
