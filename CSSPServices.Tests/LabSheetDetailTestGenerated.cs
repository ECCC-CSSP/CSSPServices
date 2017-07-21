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
    public partial class LabSheetDetailTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int LabSheetDetailID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheetDetail GetFilledRandomLabSheetDetail(string OmitPropName)
        {
            LabSheetDetailID += 1;

            LabSheetDetail labSheetDetail = new LabSheetDetail();

            if (OmitPropName != "LabSheetDetailID") labSheetDetail.LabSheetDetailID = LabSheetDetailID;
            if (OmitPropName != "LabSheetID") labSheetDetail.LabSheetID = GetRandomInt(1, 11);
            if (OmitPropName != "SamplingPlanID") labSheetDetail.SamplingPlanID = GetRandomInt(1, 11);
            if (OmitPropName != "SubsectorTVItemID") labSheetDetail.SubsectorTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Version") labSheetDetail.Version = GetRandomInt(1, 5);
            if (OmitPropName != "RunDate") labSheetDetail.RunDate = GetRandomDateTime();
            if (OmitPropName != "Tides") labSheetDetail.Tides = GetRandomString("", 5);
            if (OmitPropName != "SampleCrewInitials") labSheetDetail.SampleCrewInitials = GetRandomString("", 5);
            if (OmitPropName != "WaterBathCount") labSheetDetail.WaterBathCount = GetRandomInt(1, 3);
            if (OmitPropName != "IncubationBath1StartTime") labSheetDetail.IncubationBath1StartTime = GetRandomDateTime();
            if (OmitPropName != "IncubationBath2StartTime") labSheetDetail.IncubationBath2StartTime = GetRandomDateTime();
            if (OmitPropName != "IncubationBath3StartTime") labSheetDetail.IncubationBath3StartTime = GetRandomDateTime();
            if (OmitPropName != "IncubationBath1EndTime") labSheetDetail.IncubationBath1EndTime = GetRandomDateTime();
            if (OmitPropName != "IncubationBath2EndTime") labSheetDetail.IncubationBath2EndTime = GetRandomDateTime();
            if (OmitPropName != "IncubationBath3EndTime") labSheetDetail.IncubationBath3EndTime = GetRandomDateTime();
            if (OmitPropName != "IncubationBath1TimeCalculated_minutes") labSheetDetail.IncubationBath1TimeCalculated_minutes = GetRandomInt(0, 10000);
            if (OmitPropName != "IncubationBath2TimeCalculated_minutes") labSheetDetail.IncubationBath2TimeCalculated_minutes = GetRandomInt(0, 10000);
            if (OmitPropName != "IncubationBath3TimeCalculated_minutes") labSheetDetail.IncubationBath3TimeCalculated_minutes = GetRandomInt(0, 10000);
            if (OmitPropName != "WaterBath1") labSheetDetail.WaterBath1 = GetRandomString("", 5);
            if (OmitPropName != "WaterBath2") labSheetDetail.WaterBath2 = GetRandomString("", 5);
            if (OmitPropName != "WaterBath3") labSheetDetail.WaterBath3 = GetRandomString("", 5);
            if (OmitPropName != "TCField1") labSheetDetail.TCField1 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TCLab1") labSheetDetail.TCLab1 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TCField2") labSheetDetail.TCField2 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TCLab2") labSheetDetail.TCLab2 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TCFirst") labSheetDetail.TCFirst = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TCAverage") labSheetDetail.TCAverage = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "ControlLot") labSheetDetail.ControlLot = GetRandomString("", 5);
            if (OmitPropName != "Positive35") labSheetDetail.Positive35 = GetRandomString("", 1);
            if (OmitPropName != "NonTarget35") labSheetDetail.NonTarget35 = GetRandomString("", 1);
            if (OmitPropName != "Negative35") labSheetDetail.Negative35 = GetRandomString("", 1);
            if (OmitPropName != "Bath1Positive44_5") labSheetDetail.Bath1Positive44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2Positive44_5") labSheetDetail.Bath2Positive44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3Positive44_5") labSheetDetail.Bath3Positive44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath1NonTarget44_5") labSheetDetail.Bath1NonTarget44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2NonTarget44_5") labSheetDetail.Bath2NonTarget44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3NonTarget44_5") labSheetDetail.Bath3NonTarget44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath1Negative44_5") labSheetDetail.Bath1Negative44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2Negative44_5") labSheetDetail.Bath2Negative44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3Negative44_5") labSheetDetail.Bath3Negative44_5 = GetRandomString("", 1);
            if (OmitPropName != "Blank35") labSheetDetail.Blank35 = GetRandomString("", 1);
            if (OmitPropName != "Bath1Blank44_5") labSheetDetail.Bath1Blank44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath2Blank44_5") labSheetDetail.Bath2Blank44_5 = GetRandomString("", 1);
            if (OmitPropName != "Bath3Blank44_5") labSheetDetail.Bath3Blank44_5 = GetRandomString("", 1);
            if (OmitPropName != "Lot35") labSheetDetail.Lot35 = GetRandomString("", 5);
            if (OmitPropName != "Lot44_5") labSheetDetail.Lot44_5 = GetRandomString("", 5);
            if (OmitPropName != "Weather") labSheetDetail.Weather = GetRandomString("", 5);
            if (OmitPropName != "RunComment") labSheetDetail.RunComment = GetRandomString("", 5);
            if (OmitPropName != "RunWeatherComment") labSheetDetail.RunWeatherComment = GetRandomString("", 5);
            if (OmitPropName != "SampleBottleLotNumber") labSheetDetail.SampleBottleLotNumber = GetRandomString("", 5);
            if (OmitPropName != "SalinitiesReadBy") labSheetDetail.SalinitiesReadBy = GetRandomString("", 5);
            if (OmitPropName != "SalinitiesReadDate") labSheetDetail.SalinitiesReadDate = GetRandomDateTime();
            if (OmitPropName != "ResultsReadBy") labSheetDetail.ResultsReadBy = GetRandomString("", 5);
            if (OmitPropName != "ResultsReadDate") labSheetDetail.ResultsReadDate = GetRandomDateTime();
            if (OmitPropName != "ResultsRecordedBy") labSheetDetail.ResultsRecordedBy = GetRandomString("", 5);
            if (OmitPropName != "ResultsRecordedDate") labSheetDetail.ResultsRecordedDate = GetRandomDateTime();
            if (OmitPropName != "DailyDuplicateRLog") labSheetDetail.DailyDuplicateRLog = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") labSheetDetail.DailyDuplicatePrecisionCriteria = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "DailyDuplicateAcceptable") labSheetDetail.DailyDuplicateAcceptable = true;
            if (OmitPropName != "IntertechDuplicateRLog") labSheetDetail.IntertechDuplicateRLog = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") labSheetDetail.IntertechDuplicatePrecisionCriteria = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "IntertechDuplicateAcceptable") labSheetDetail.IntertechDuplicateAcceptable = true;
            if (OmitPropName != "IntertechReadAcceptable") labSheetDetail.IntertechReadAcceptable = true;
            if (OmitPropName != "LastUpdateDate_UTC") labSheetDetail.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetDetail.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return labSheetDetail;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheetDetail_Testing()
        {
            SetupTestHelper(culture);
            LabSheetDetailService labSheetDetailService = new LabSheetDetailService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            LabSheetDetail labSheetDetail = GetFilledRandomLabSheetDetail("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(true, labSheetDetailService.GetRead().Where(c => c == labSheetDetail).Any());
            labSheetDetail.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, labSheetDetailService.Update(labSheetDetail));
            Assert.AreEqual(1, labSheetDetailService.GetRead().Count());
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // LabSheetID will automatically be initialized at 0 --> not null

            // SamplingPlanID will automatically be initialized at 0 --> not null

            // SubsectorTVItemID will automatically be initialized at 0 --> not null

            // Version will automatically be initialized at 0 --> not null

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("RunDate");
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(1, labSheetDetail.ValidationResults.Count());
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailRunDate)).Any());
            Assert.IsTrue(labSheetDetail.RunDate.Year < 1900);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("Tides");
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(1, labSheetDetail.ValidationResults.Count());
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailTides)).Any());
            Assert.AreEqual(null, labSheetDetail.Tides);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //Error: Type not implemented [TCField1]

            //Error: Type not implemented [TCLab1]

            //Error: Type not implemented [TCField2]

            //Error: Type not implemented [TCLab2]

            //Error: Type not implemented [TCFirst]

            //Error: Type not implemented [TCAverage]

            //Error: Type not implemented [DailyDuplicateRLog]

            //Error: Type not implemented [DailyDuplicatePrecisionCriteria]

            //Error: Type not implemented [IntertechDuplicateRLog]

            //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("LastUpdateDate_UTC");
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(1, labSheetDetail.ValidationResults.Count());
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailLastUpdateDate_UTC)).Any());
            Assert.IsTrue(labSheetDetail.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [LabSheetTubeMPNDetails]

            //Error: Type not implemented [LabSheet]

            //Error: Type not implemented [SamplingPlan]

            //Error: Type not implemented [SubsectorTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [LabSheetDetailID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetID] of type [Int32]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // LabSheetID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetDetail.LabSheetID = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.LabSheetID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // LabSheetID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetDetail.LabSheetID = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.LabSheetID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // LabSheetID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetDetail.LabSheetID = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetDetailLabSheetID, "1")).Any());
            Assert.AreEqual(0, labSheetDetail.LabSheetID);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [SamplingPlanID] of type [Int32]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // SamplingPlanID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetDetail.SamplingPlanID = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.SamplingPlanID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetDetail.SamplingPlanID = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.SamplingPlanID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetDetail.SamplingPlanID = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetDetailSamplingPlanID, "1")).Any());
            Assert.AreEqual(0, labSheetDetail.SamplingPlanID);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [SubsectorTVItemID] of type [Int32]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetDetail.SubsectorTVItemID = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.SubsectorTVItemID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetDetail.SubsectorTVItemID = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.SubsectorTVItemID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetDetail.SubsectorTVItemID = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetDetailSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheetDetail.SubsectorTVItemID);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Version] of type [Int32]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // Version has Min [1] and Max [5]. At Min should return true and no errors
            labSheetDetail.Version = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Min + 1 should return true and no errors
            labSheetDetail.Version = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Min - 1 should return false with one error
            labSheetDetail.Version = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailVersion, "1", "5")).Any());
            Assert.AreEqual(0, labSheetDetail.Version);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Max should return true and no errors
            labSheetDetail.Version = 5;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(5, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Max - 1 should return true and no errors
            labSheetDetail.Version = 4;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(4, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Max + 1 should return false with one error
            labSheetDetail.Version = 6;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailVersion, "1", "5")).Any());
            Assert.AreEqual(6, labSheetDetail.Version);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [RunDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Tides] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [SampleCrewInitials] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [WaterBathCount] of type [Int32]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // WaterBathCount has Min [1] and Max [3]. At Min should return true and no errors
            labSheetDetail.WaterBathCount = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.WaterBathCount);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Min + 1 should return true and no errors
            labSheetDetail.WaterBathCount = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.WaterBathCount);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Min - 1 should return false with one error
            labSheetDetail.WaterBathCount = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailWaterBathCount, "1", "3")).Any());
            Assert.AreEqual(0, labSheetDetail.WaterBathCount);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Max should return true and no errors
            labSheetDetail.WaterBathCount = 3;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(3, labSheetDetail.WaterBathCount);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Max - 1 should return true and no errors
            labSheetDetail.WaterBathCount = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.WaterBathCount);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Max + 1 should return false with one error
            labSheetDetail.WaterBathCount = 4;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailWaterBathCount, "1", "3")).Any());
            Assert.AreEqual(4, labSheetDetail.WaterBathCount);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [IncubationBath1StartTime] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncubationBath2StartTime] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncubationBath3StartTime] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncubationBath1EndTime] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncubationBath2EndTime] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncubationBath3EndTime] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncubationBath1TimeCalculated_minutes] of type [Int32]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Min should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 0;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Min - 1 should return false with one error
            labSheetDetail.IncubationBath1TimeCalculated_minutes = -1;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(-1, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Max should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 10000;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(10000, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 9999;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(9999, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Max + 1 should return false with one error
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 10001;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(10001, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [IncubationBath2TimeCalculated_minutes] of type [Int32]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Min should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 0;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Min - 1 should return false with one error
            labSheetDetail.IncubationBath2TimeCalculated_minutes = -1;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(-1, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Max should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 10000;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(10000, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 9999;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(9999, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Max + 1 should return false with one error
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 10001;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(10001, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [IncubationBath3TimeCalculated_minutes] of type [Int32]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Min should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 0;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Min - 1 should return false with one error
            labSheetDetail.IncubationBath3TimeCalculated_minutes = -1;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(-1, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Max should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 10000;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(10000, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 9999;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(9999, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Max + 1 should return false with one error
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 10001;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(10001, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [WaterBath1] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [WaterBath2] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [WaterBath3] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [TCField1] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TCLab1] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TCField2] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TCLab2] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TCFirst] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TCAverage] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [ControlLot] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Positive35] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [NonTarget35] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Negative35] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath1Positive44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath2Positive44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath3Positive44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath1NonTarget44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath2NonTarget44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath3NonTarget44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath1Negative44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath2Negative44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath3Negative44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Blank35] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath1Blank44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath2Blank44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath3Blank44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Lot35] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Lot44_5] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Weather] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [RunComment] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [RunWeatherComment] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [SampleBottleLotNumber] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [SalinitiesReadBy] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [SalinitiesReadDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [ResultsReadBy] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [ResultsReadDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [ResultsRecordedBy] of type [String]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [ResultsRecordedDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyDuplicateRLog] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyDuplicatePrecisionCriteria] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyDuplicateAcceptable] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [IntertechDuplicateRLog] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [IntertechDuplicatePrecisionCriteria] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [IntertechDuplicateAcceptable] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [IntertechReadAcceptable] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetDetail.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetDetail.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetDetail.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetDetailLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheetDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [LabSheetTubeMPNDetails] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheet] of type [LabSheet]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlan] of type [SamplingPlan]
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
