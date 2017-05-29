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
            if (OmitPropName != "Version") labSheetDetail.Version = GetRandomInt(1, 11);
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
            if (OmitPropName != "IncubationBath1TimeCalculated_minutes") labSheetDetail.IncubationBath1TimeCalculated_minutes = GetRandomInt(1, 1000);
            if (OmitPropName != "IncubationBath2TimeCalculated_minutes") labSheetDetail.IncubationBath2TimeCalculated_minutes = GetRandomInt(1, 1000);
            if (OmitPropName != "IncubationBath3TimeCalculated_minutes") labSheetDetail.IncubationBath3TimeCalculated_minutes = GetRandomInt(1, 1000);
            if (OmitPropName != "WaterBath1") labSheetDetail.WaterBath1 = GetRandomString("", 5);
            if (OmitPropName != "WaterBath2") labSheetDetail.WaterBath2 = GetRandomString("", 5);
            if (OmitPropName != "WaterBath3") labSheetDetail.WaterBath3 = GetRandomString("", 5);
            if (OmitPropName != "TCField1") labSheetDetail.TCField1 = GetRandomFloat(0, 40);
            if (OmitPropName != "TCLab1") labSheetDetail.TCLab1 = GetRandomFloat(0, 40);
            if (OmitPropName != "TCField2") labSheetDetail.TCField2 = GetRandomFloat(0, 40);
            if (OmitPropName != "TCLab2") labSheetDetail.TCLab2 = GetRandomFloat(0, 40);
            if (OmitPropName != "TCFirst") labSheetDetail.TCFirst = GetRandomFloat(0, 40);
            if (OmitPropName != "TCAverage") labSheetDetail.TCAverage = GetRandomFloat(0, 40);
            if (OmitPropName != "ControlLot") labSheetDetail.ControlLot = GetRandomString("", 5);
            if (OmitPropName != "Positive35") labSheetDetail.Positive35 = GetRandomString("", 20);
            if (OmitPropName != "NonTarget35") labSheetDetail.NonTarget35 = GetRandomString("", 20);
            if (OmitPropName != "Negative35") labSheetDetail.Negative35 = GetRandomString("", 20);
            if (OmitPropName != "Bath1Positive44_5") labSheetDetail.Bath1Positive44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath2Positive44_5") labSheetDetail.Bath2Positive44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath3Positive44_5") labSheetDetail.Bath3Positive44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath1NonTarget44_5") labSheetDetail.Bath1NonTarget44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath2NonTarget44_5") labSheetDetail.Bath2NonTarget44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath3NonTarget44_5") labSheetDetail.Bath3NonTarget44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath1Negative44_5") labSheetDetail.Bath1Negative44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath2Negative44_5") labSheetDetail.Bath2Negative44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath3Negative44_5") labSheetDetail.Bath3Negative44_5 = GetRandomString("", 6);
            if (OmitPropName != "Blank35") labSheetDetail.Blank35 = GetRandomString("", 6);
            if (OmitPropName != "Bath1Blank44_5") labSheetDetail.Bath1Blank44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath2Blank44_5") labSheetDetail.Bath2Blank44_5 = GetRandomString("", 6);
            if (OmitPropName != "Bath3Blank44_5") labSheetDetail.Bath3Blank44_5 = GetRandomString("", 6);
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
            if (OmitPropName != "DailyDuplicateRlog") labSheetDetail.DailyDuplicateRlog = GetRandomFloat(0, 1000);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") labSheetDetail.DailyDuplicatePrecisionCriteria = GetRandomFloat(0, 1000);
            if (OmitPropName != "DailyDuplicateAcceptable") labSheetDetail.DailyDuplicateAcceptable = true;
            if (OmitPropName != "IntertechDuplicateRlog") labSheetDetail.IntertechDuplicateRlog = GetRandomFloat(0, 1000);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") labSheetDetail.IntertechDuplicatePrecisionCriteria = GetRandomFloat(0, 1000);
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
            SetupTestHelper(LoginEmail, culture);
            LabSheetDetailService labSheetDetailService = new LabSheetDetailService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            LabSheetDetail labSheetDetail = GetFilledRandomLabSheetDetail("");
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

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("LastUpdateDate_UTC");
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(1, labSheetDetail.ValidationResults.Count());
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailLastUpdateDate_UTC)).Any());
            Assert.IsTrue(labSheetDetail.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [LabSheetDetailID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetID] of type [int]
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
            // doing property [SamplingPlanID] of type [int]
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
            // doing property [SubsectorTVItemID] of type [int]
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
            // doing property [Version] of type [int]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // Version has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetDetail.Version = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetDetail.Version = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetDetail.Version = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetDetailVersion, "1")).Any());
            Assert.AreEqual(0, labSheetDetail.Version);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [RunDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Tides] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Tides has MinLength [empty] and MaxLength [7]. At Max should return true and no errors
            string labSheetDetailTidesMin = GetRandomString("", 7);
            labSheetDetail.Tides = labSheetDetailTidesMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailTidesMin, labSheetDetail.Tides);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Tides has MinLength [empty] and MaxLength [7]. At Max - 1 should return true and no errors
            labSheetDetailTidesMin = GetRandomString("", 6);
            labSheetDetail.Tides = labSheetDetailTidesMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailTidesMin, labSheetDetail.Tides);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Tides has MinLength [empty] and MaxLength [7]. At Max + 1 should return false with one error
            labSheetDetailTidesMin = GetRandomString("", 8);
            labSheetDetail.Tides = labSheetDetailTidesMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailTides, "7")).Any());
            Assert.AreEqual(labSheetDetailTidesMin, labSheetDetail.Tides);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [SampleCrewInitials] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // SampleCrewInitials has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string labSheetDetailSampleCrewInitialsMin = GetRandomString("", 20);
            labSheetDetail.SampleCrewInitials = labSheetDetailSampleCrewInitialsMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailSampleCrewInitialsMin, labSheetDetail.SampleCrewInitials);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // SampleCrewInitials has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailSampleCrewInitialsMin = GetRandomString("", 19);
            labSheetDetail.SampleCrewInitials = labSheetDetailSampleCrewInitialsMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailSampleCrewInitialsMin, labSheetDetail.SampleCrewInitials);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // SampleCrewInitials has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailSampleCrewInitialsMin = GetRandomString("", 21);
            labSheetDetail.SampleCrewInitials = labSheetDetailSampleCrewInitialsMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSampleCrewInitials, "20")).Any());
            Assert.AreEqual(labSheetDetailSampleCrewInitialsMin, labSheetDetail.SampleCrewInitials);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [WaterBathCount] of type [int]
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
            // doing property [IncubationBath1TimeCalculated_minutes] of type [int]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IncubationBath1TimeCalculated_minutes has Min [1] and Max [1000]. At Min should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [1] and Max [1000]. At Min + 1 should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [1] and Max [1000]. At Min - 1 should return false with one error
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "1", "1000")).Any());
            Assert.AreEqual(0, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [1] and Max [1000]. At Max should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 1000;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1000, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [1] and Max [1000]. At Max - 1 should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 999;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(999, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [1] and Max [1000]. At Max + 1 should return false with one error
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 1001;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "1", "1000")).Any());
            Assert.AreEqual(1001, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [IncubationBath2TimeCalculated_minutes] of type [int]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IncubationBath2TimeCalculated_minutes has Min [1] and Max [1000]. At Min should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [1] and Max [1000]. At Min + 1 should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [1] and Max [1000]. At Min - 1 should return false with one error
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "1", "1000")).Any());
            Assert.AreEqual(0, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [1] and Max [1000]. At Max should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 1000;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1000, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [1] and Max [1000]. At Max - 1 should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 999;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(999, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [1] and Max [1000]. At Max + 1 should return false with one error
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 1001;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "1", "1000")).Any());
            Assert.AreEqual(1001, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [IncubationBath3TimeCalculated_minutes] of type [int]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IncubationBath3TimeCalculated_minutes has Min [1] and Max [1000]. At Min should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [1] and Max [1000]. At Min + 1 should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [1] and Max [1000]. At Min - 1 should return false with one error
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "1", "1000")).Any());
            Assert.AreEqual(0, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [1] and Max [1000]. At Max should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 1000;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1000, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [1] and Max [1000]. At Max - 1 should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 999;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(999, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [1] and Max [1000]. At Max + 1 should return false with one error
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 1001;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "1", "1000")).Any());
            Assert.AreEqual(1001, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [WaterBath1] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // WaterBath1 has MinLength [empty] and MaxLength [10]. At Max should return true and no errors
            string labSheetDetailWaterBath1Min = GetRandomString("", 10);
            labSheetDetail.WaterBath1 = labSheetDetailWaterBath1Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWaterBath1Min, labSheetDetail.WaterBath1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // WaterBath1 has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            labSheetDetailWaterBath1Min = GetRandomString("", 9);
            labSheetDetail.WaterBath1 = labSheetDetailWaterBath1Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWaterBath1Min, labSheetDetail.WaterBath1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // WaterBath1 has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            labSheetDetailWaterBath1Min = GetRandomString("", 11);
            labSheetDetail.WaterBath1 = labSheetDetailWaterBath1Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath1, "10")).Any());
            Assert.AreEqual(labSheetDetailWaterBath1Min, labSheetDetail.WaterBath1);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [WaterBath2] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // WaterBath2 has MinLength [empty] and MaxLength [10]. At Max should return true and no errors
            string labSheetDetailWaterBath2Min = GetRandomString("", 10);
            labSheetDetail.WaterBath2 = labSheetDetailWaterBath2Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWaterBath2Min, labSheetDetail.WaterBath2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // WaterBath2 has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            labSheetDetailWaterBath2Min = GetRandomString("", 9);
            labSheetDetail.WaterBath2 = labSheetDetailWaterBath2Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWaterBath2Min, labSheetDetail.WaterBath2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // WaterBath2 has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            labSheetDetailWaterBath2Min = GetRandomString("", 11);
            labSheetDetail.WaterBath2 = labSheetDetailWaterBath2Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath2, "10")).Any());
            Assert.AreEqual(labSheetDetailWaterBath2Min, labSheetDetail.WaterBath2);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [WaterBath3] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // WaterBath3 has MinLength [empty] and MaxLength [10]. At Max should return true and no errors
            string labSheetDetailWaterBath3Min = GetRandomString("", 10);
            labSheetDetail.WaterBath3 = labSheetDetailWaterBath3Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWaterBath3Min, labSheetDetail.WaterBath3);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // WaterBath3 has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            labSheetDetailWaterBath3Min = GetRandomString("", 9);
            labSheetDetail.WaterBath3 = labSheetDetailWaterBath3Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWaterBath3Min, labSheetDetail.WaterBath3);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // WaterBath3 has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            labSheetDetailWaterBath3Min = GetRandomString("", 11);
            labSheetDetail.WaterBath3 = labSheetDetailWaterBath3Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath3, "10")).Any());
            Assert.AreEqual(labSheetDetailWaterBath3Min, labSheetDetail.WaterBath3);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [TCField1] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCField1 has Min [0] and Max [40]. At Min should return true and no errors
            labSheetDetail.TCField1 = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.TCField1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [0] and Max [40]. At Min + 1 should return true and no errors
            labSheetDetail.TCField1 = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.TCField1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [0] and Max [40]. At Min - 1 should return false with one error
            labSheetDetail.TCField1 = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField1, "0", "40")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.TCField1);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [0] and Max [40]. At Max should return true and no errors
            labSheetDetail.TCField1 = 40.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0f, labSheetDetail.TCField1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [0] and Max [40]. At Max - 1 should return true and no errors
            labSheetDetail.TCField1 = 39.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0f, labSheetDetail.TCField1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [0] and Max [40]. At Max + 1 should return false with one error
            labSheetDetail.TCField1 = 41.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField1, "0", "40")).Any());
            Assert.AreEqual(41.0f, labSheetDetail.TCField1);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [TCLab1] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCLab1 has Min [0] and Max [40]. At Min should return true and no errors
            labSheetDetail.TCLab1 = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.TCLab1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [0] and Max [40]. At Min + 1 should return true and no errors
            labSheetDetail.TCLab1 = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.TCLab1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [0] and Max [40]. At Min - 1 should return false with one error
            labSheetDetail.TCLab1 = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab1, "0", "40")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.TCLab1);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [0] and Max [40]. At Max should return true and no errors
            labSheetDetail.TCLab1 = 40.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0f, labSheetDetail.TCLab1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [0] and Max [40]. At Max - 1 should return true and no errors
            labSheetDetail.TCLab1 = 39.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0f, labSheetDetail.TCLab1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [0] and Max [40]. At Max + 1 should return false with one error
            labSheetDetail.TCLab1 = 41.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab1, "0", "40")).Any());
            Assert.AreEqual(41.0f, labSheetDetail.TCLab1);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [TCField2] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCField2 has Min [0] and Max [40]. At Min should return true and no errors
            labSheetDetail.TCField2 = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.TCField2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [0] and Max [40]. At Min + 1 should return true and no errors
            labSheetDetail.TCField2 = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.TCField2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [0] and Max [40]. At Min - 1 should return false with one error
            labSheetDetail.TCField2 = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField2, "0", "40")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.TCField2);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [0] and Max [40]. At Max should return true and no errors
            labSheetDetail.TCField2 = 40.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0f, labSheetDetail.TCField2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [0] and Max [40]. At Max - 1 should return true and no errors
            labSheetDetail.TCField2 = 39.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0f, labSheetDetail.TCField2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [0] and Max [40]. At Max + 1 should return false with one error
            labSheetDetail.TCField2 = 41.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField2, "0", "40")).Any());
            Assert.AreEqual(41.0f, labSheetDetail.TCField2);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [TCLab2] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCLab2 has Min [0] and Max [40]. At Min should return true and no errors
            labSheetDetail.TCLab2 = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.TCLab2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [0] and Max [40]. At Min + 1 should return true and no errors
            labSheetDetail.TCLab2 = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.TCLab2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [0] and Max [40]. At Min - 1 should return false with one error
            labSheetDetail.TCLab2 = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab2, "0", "40")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.TCLab2);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [0] and Max [40]. At Max should return true and no errors
            labSheetDetail.TCLab2 = 40.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0f, labSheetDetail.TCLab2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [0] and Max [40]. At Max - 1 should return true and no errors
            labSheetDetail.TCLab2 = 39.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0f, labSheetDetail.TCLab2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [0] and Max [40]. At Max + 1 should return false with one error
            labSheetDetail.TCLab2 = 41.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab2, "0", "40")).Any());
            Assert.AreEqual(41.0f, labSheetDetail.TCLab2);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [TCFirst] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCFirst has Min [0] and Max [40]. At Min should return true and no errors
            labSheetDetail.TCFirst = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.TCFirst);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [0] and Max [40]. At Min + 1 should return true and no errors
            labSheetDetail.TCFirst = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.TCFirst);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [0] and Max [40]. At Min - 1 should return false with one error
            labSheetDetail.TCFirst = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCFirst, "0", "40")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.TCFirst);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [0] and Max [40]. At Max should return true and no errors
            labSheetDetail.TCFirst = 40.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0f, labSheetDetail.TCFirst);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [0] and Max [40]. At Max - 1 should return true and no errors
            labSheetDetail.TCFirst = 39.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0f, labSheetDetail.TCFirst);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [0] and Max [40]. At Max + 1 should return false with one error
            labSheetDetail.TCFirst = 41.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCFirst, "0", "40")).Any());
            Assert.AreEqual(41.0f, labSheetDetail.TCFirst);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [TCAverage] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCAverage has Min [0] and Max [40]. At Min should return true and no errors
            labSheetDetail.TCAverage = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.TCAverage);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [0] and Max [40]. At Min + 1 should return true and no errors
            labSheetDetail.TCAverage = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.TCAverage);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [0] and Max [40]. At Min - 1 should return false with one error
            labSheetDetail.TCAverage = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCAverage, "0", "40")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.TCAverage);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [0] and Max [40]. At Max should return true and no errors
            labSheetDetail.TCAverage = 40.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0f, labSheetDetail.TCAverage);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [0] and Max [40]. At Max - 1 should return true and no errors
            labSheetDetail.TCAverage = 39.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0f, labSheetDetail.TCAverage);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [0] and Max [40]. At Max + 1 should return false with one error
            labSheetDetail.TCAverage = 41.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCAverage, "0", "40")).Any());
            Assert.AreEqual(41.0f, labSheetDetail.TCAverage);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [ControlLot] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // ControlLot has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string labSheetDetailControlLotMin = GetRandomString("", 100);
            labSheetDetail.ControlLot = labSheetDetailControlLotMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailControlLotMin, labSheetDetail.ControlLot);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // ControlLot has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            labSheetDetailControlLotMin = GetRandomString("", 99);
            labSheetDetail.ControlLot = labSheetDetailControlLotMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailControlLotMin, labSheetDetail.ControlLot);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // ControlLot has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            labSheetDetailControlLotMin = GetRandomString("", 101);
            labSheetDetail.ControlLot = labSheetDetailControlLotMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailControlLot, "100")).Any());
            Assert.AreEqual(labSheetDetailControlLotMin, labSheetDetail.ControlLot);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Positive35] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [NonTarget35] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Negative35] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            //-----------------------------------
            // doing property [Bath1Positive44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath1Positive44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath1Positive44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1Positive44_5 = labSheetDetailBath1Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Positive44_5Min, labSheetDetail.Bath1Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath1Positive44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath1Positive44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath1Positive44_5 = labSheetDetailBath1Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Positive44_5Min, labSheetDetail.Bath1Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath2Positive44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath2Positive44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath2Positive44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2Positive44_5 = labSheetDetailBath2Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Positive44_5Min, labSheetDetail.Bath2Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath2Positive44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath2Positive44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath2Positive44_5 = labSheetDetailBath2Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Positive44_5Min, labSheetDetail.Bath2Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath3Positive44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath3Positive44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath3Positive44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3Positive44_5 = labSheetDetailBath3Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Positive44_5Min, labSheetDetail.Bath3Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath3Positive44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath3Positive44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath3Positive44_5 = labSheetDetailBath3Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Positive44_5Min, labSheetDetail.Bath3Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath1NonTarget44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath1NonTarget44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath1NonTarget44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1NonTarget44_5 = labSheetDetailBath1NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1NonTarget44_5Min, labSheetDetail.Bath1NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath1NonTarget44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath1NonTarget44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath1NonTarget44_5 = labSheetDetailBath1NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1NonTarget44_5Min, labSheetDetail.Bath1NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath2NonTarget44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath2NonTarget44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath2NonTarget44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2NonTarget44_5 = labSheetDetailBath2NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2NonTarget44_5Min, labSheetDetail.Bath2NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath2NonTarget44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath2NonTarget44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath2NonTarget44_5 = labSheetDetailBath2NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2NonTarget44_5Min, labSheetDetail.Bath2NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath3NonTarget44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath3NonTarget44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath3NonTarget44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3NonTarget44_5 = labSheetDetailBath3NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3NonTarget44_5Min, labSheetDetail.Bath3NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath3NonTarget44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath3NonTarget44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath3NonTarget44_5 = labSheetDetailBath3NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3NonTarget44_5Min, labSheetDetail.Bath3NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath1Negative44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath1Negative44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath1Negative44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1Negative44_5 = labSheetDetailBath1Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Negative44_5Min, labSheetDetail.Bath1Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath1Negative44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath1Negative44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath1Negative44_5 = labSheetDetailBath1Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Negative44_5Min, labSheetDetail.Bath1Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath2Negative44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath2Negative44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath2Negative44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2Negative44_5 = labSheetDetailBath2Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Negative44_5Min, labSheetDetail.Bath2Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath2Negative44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath2Negative44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath2Negative44_5 = labSheetDetailBath2Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Negative44_5Min, labSheetDetail.Bath2Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath3Negative44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath3Negative44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath3Negative44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3Negative44_5 = labSheetDetailBath3Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Negative44_5Min, labSheetDetail.Bath3Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath3Negative44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath3Negative44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath3Negative44_5 = labSheetDetailBath3Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Negative44_5Min, labSheetDetail.Bath3Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Blank35] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Blank35 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBlank35Min = GetRandomString("", 1);
            labSheetDetail.Blank35 = labSheetDetailBlank35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBlank35Min, labSheetDetail.Blank35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Blank35 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBlank35Min = GetRandomString("", 2);
            labSheetDetail.Blank35 = labSheetDetailBlank35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBlank35Min, labSheetDetail.Blank35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath1Blank44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath1Blank44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath1Blank44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1Blank44_5 = labSheetDetailBath1Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Blank44_5Min, labSheetDetail.Bath1Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath1Blank44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath1Blank44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath1Blank44_5 = labSheetDetailBath1Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Blank44_5Min, labSheetDetail.Bath1Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath2Blank44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath2Blank44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath2Blank44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2Blank44_5 = labSheetDetailBath2Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Blank44_5Min, labSheetDetail.Bath2Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath2Blank44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath2Blank44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath2Blank44_5 = labSheetDetailBath2Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Blank44_5Min, labSheetDetail.Bath2Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Bath3Blank44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath3Blank44_5 has MinLength [1] and MaxLength [empty]. At Min should return true and no errors
            string labSheetDetailBath3Blank44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3Blank44_5 = labSheetDetailBath3Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Blank44_5Min, labSheetDetail.Bath3Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Bath3Blank44_5 has MinLength [1] and MaxLength [empty]. At Min + 1 should return true and no errors
            labSheetDetailBath3Blank44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath3Blank44_5 = labSheetDetailBath3Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Blank44_5Min, labSheetDetail.Bath3Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Lot35] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Lot35 has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string labSheetDetailLot35Min = GetRandomString("", 20);
            labSheetDetail.Lot35 = labSheetDetailLot35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailLot35Min, labSheetDetail.Lot35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Lot35 has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailLot35Min = GetRandomString("", 19);
            labSheetDetail.Lot35 = labSheetDetailLot35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailLot35Min, labSheetDetail.Lot35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Lot35 has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailLot35Min = GetRandomString("", 21);
            labSheetDetail.Lot35 = labSheetDetailLot35Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailLot35, "20")).Any());
            Assert.AreEqual(labSheetDetailLot35Min, labSheetDetail.Lot35);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Lot44_5] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Lot44_5 has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string labSheetDetailLot44_5Min = GetRandomString("", 20);
            labSheetDetail.Lot44_5 = labSheetDetailLot44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailLot44_5Min, labSheetDetail.Lot44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Lot44_5 has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailLot44_5Min = GetRandomString("", 19);
            labSheetDetail.Lot44_5 = labSheetDetailLot44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailLot44_5Min, labSheetDetail.Lot44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Lot44_5 has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailLot44_5Min = GetRandomString("", 21);
            labSheetDetail.Lot44_5 = labSheetDetailLot44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailLot44_5, "20")).Any());
            Assert.AreEqual(labSheetDetailLot44_5Min, labSheetDetail.Lot44_5);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [Weather] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Weather has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string labSheetDetailWeatherMin = GetRandomString("", 250);
            labSheetDetail.Weather = labSheetDetailWeatherMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWeatherMin, labSheetDetail.Weather);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Weather has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetDetailWeatherMin = GetRandomString("", 249);
            labSheetDetail.Weather = labSheetDetailWeatherMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWeatherMin, labSheetDetail.Weather);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // Weather has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetDetailWeatherMin = GetRandomString("", 251);
            labSheetDetail.Weather = labSheetDetailWeatherMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWeather, "250")).Any());
            Assert.AreEqual(labSheetDetailWeatherMin, labSheetDetail.Weather);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [RunComment] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // RunComment has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string labSheetDetailRunCommentMin = GetRandomString("", 250);
            labSheetDetail.RunComment = labSheetDetailRunCommentMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailRunCommentMin, labSheetDetail.RunComment);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // RunComment has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetDetailRunCommentMin = GetRandomString("", 249);
            labSheetDetail.RunComment = labSheetDetailRunCommentMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailRunCommentMin, labSheetDetail.RunComment);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // RunComment has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetDetailRunCommentMin = GetRandomString("", 251);
            labSheetDetail.RunComment = labSheetDetailRunCommentMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailRunComment, "250")).Any());
            Assert.AreEqual(labSheetDetailRunCommentMin, labSheetDetail.RunComment);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [RunWeatherComment] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // RunWeatherComment has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string labSheetDetailRunWeatherCommentMin = GetRandomString("", 250);
            labSheetDetail.RunWeatherComment = labSheetDetailRunWeatherCommentMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailRunWeatherCommentMin, labSheetDetail.RunWeatherComment);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // RunWeatherComment has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetDetailRunWeatherCommentMin = GetRandomString("", 249);
            labSheetDetail.RunWeatherComment = labSheetDetailRunWeatherCommentMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailRunWeatherCommentMin, labSheetDetail.RunWeatherComment);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // RunWeatherComment has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetDetailRunWeatherCommentMin = GetRandomString("", 251);
            labSheetDetail.RunWeatherComment = labSheetDetailRunWeatherCommentMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailRunWeatherComment, "250")).Any());
            Assert.AreEqual(labSheetDetailRunWeatherCommentMin, labSheetDetail.RunWeatherComment);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [SampleBottleLotNumber] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // SampleBottleLotNumber has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string labSheetDetailSampleBottleLotNumberMin = GetRandomString("", 20);
            labSheetDetail.SampleBottleLotNumber = labSheetDetailSampleBottleLotNumberMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailSampleBottleLotNumberMin, labSheetDetail.SampleBottleLotNumber);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // SampleBottleLotNumber has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailSampleBottleLotNumberMin = GetRandomString("", 19);
            labSheetDetail.SampleBottleLotNumber = labSheetDetailSampleBottleLotNumberMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailSampleBottleLotNumberMin, labSheetDetail.SampleBottleLotNumber);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // SampleBottleLotNumber has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailSampleBottleLotNumberMin = GetRandomString("", 21);
            labSheetDetail.SampleBottleLotNumber = labSheetDetailSampleBottleLotNumberMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSampleBottleLotNumber, "20")).Any());
            Assert.AreEqual(labSheetDetailSampleBottleLotNumberMin, labSheetDetail.SampleBottleLotNumber);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [SalinitiesReadBy] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // SalinitiesReadBy has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string labSheetDetailSalinitiesReadByMin = GetRandomString("", 20);
            labSheetDetail.SalinitiesReadBy = labSheetDetailSalinitiesReadByMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailSalinitiesReadByMin, labSheetDetail.SalinitiesReadBy);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // SalinitiesReadBy has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailSalinitiesReadByMin = GetRandomString("", 19);
            labSheetDetail.SalinitiesReadBy = labSheetDetailSalinitiesReadByMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailSalinitiesReadByMin, labSheetDetail.SalinitiesReadBy);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // SalinitiesReadBy has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailSalinitiesReadByMin = GetRandomString("", 21);
            labSheetDetail.SalinitiesReadBy = labSheetDetailSalinitiesReadByMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSalinitiesReadBy, "20")).Any());
            Assert.AreEqual(labSheetDetailSalinitiesReadByMin, labSheetDetail.SalinitiesReadBy);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [SalinitiesReadDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [ResultsReadBy] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // ResultsReadBy has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string labSheetDetailResultsReadByMin = GetRandomString("", 20);
            labSheetDetail.ResultsReadBy = labSheetDetailResultsReadByMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailResultsReadByMin, labSheetDetail.ResultsReadBy);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // ResultsReadBy has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailResultsReadByMin = GetRandomString("", 19);
            labSheetDetail.ResultsReadBy = labSheetDetailResultsReadByMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailResultsReadByMin, labSheetDetail.ResultsReadBy);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // ResultsReadBy has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailResultsReadByMin = GetRandomString("", 21);
            labSheetDetail.ResultsReadBy = labSheetDetailResultsReadByMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailResultsReadBy, "20")).Any());
            Assert.AreEqual(labSheetDetailResultsReadByMin, labSheetDetail.ResultsReadBy);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [ResultsReadDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [ResultsRecordedBy] of type [string]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // ResultsRecordedBy has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string labSheetDetailResultsRecordedByMin = GetRandomString("", 20);
            labSheetDetail.ResultsRecordedBy = labSheetDetailResultsRecordedByMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailResultsRecordedByMin, labSheetDetail.ResultsRecordedBy);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // ResultsRecordedBy has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailResultsRecordedByMin = GetRandomString("", 19);
            labSheetDetail.ResultsRecordedBy = labSheetDetailResultsRecordedByMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailResultsRecordedByMin, labSheetDetail.ResultsRecordedBy);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            // ResultsRecordedBy has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailResultsRecordedByMin = GetRandomString("", 21);
            labSheetDetail.ResultsRecordedBy = labSheetDetailResultsRecordedByMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailResultsRecordedBy, "20")).Any());
            Assert.AreEqual(labSheetDetailResultsRecordedByMin, labSheetDetail.ResultsRecordedBy);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [ResultsRecordedDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyDuplicateRlog] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // DailyDuplicateRlog has Min [0] and Max [1000]. At Min should return true and no errors
            labSheetDetail.DailyDuplicateRlog = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.DailyDuplicateRlog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRlog has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            labSheetDetail.DailyDuplicateRlog = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.DailyDuplicateRlog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRlog has Min [0] and Max [1000]. At Min - 1 should return false with one error
            labSheetDetail.DailyDuplicateRlog = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicateRlog, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.DailyDuplicateRlog);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRlog has Min [0] and Max [1000]. At Max should return true and no errors
            labSheetDetail.DailyDuplicateRlog = 1000.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1000.0f, labSheetDetail.DailyDuplicateRlog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRlog has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            labSheetDetail.DailyDuplicateRlog = 999.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(999.0f, labSheetDetail.DailyDuplicateRlog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRlog has Min [0] and Max [1000]. At Max + 1 should return false with one error
            labSheetDetail.DailyDuplicateRlog = 1001.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicateRlog, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, labSheetDetail.DailyDuplicateRlog);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [DailyDuplicatePrecisionCriteria] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Min should return true and no errors
            labSheetDetail.DailyDuplicatePrecisionCriteria = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            labSheetDetail.DailyDuplicatePrecisionCriteria = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Min - 1 should return false with one error
            labSheetDetail.DailyDuplicatePrecisionCriteria = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Max should return true and no errors
            labSheetDetail.DailyDuplicatePrecisionCriteria = 1000.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1000.0f, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            labSheetDetail.DailyDuplicatePrecisionCriteria = 999.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(999.0f, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Max + 1 should return false with one error
            labSheetDetail.DailyDuplicatePrecisionCriteria = 1001.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [DailyDuplicateAcceptable] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [IntertechDuplicateRlog] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IntertechDuplicateRlog has Min [0] and Max [1000]. At Min should return true and no errors
            labSheetDetail.IntertechDuplicateRlog = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.IntertechDuplicateRlog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRlog has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            labSheetDetail.IntertechDuplicateRlog = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.IntertechDuplicateRlog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRlog has Min [0] and Max [1000]. At Min - 1 should return false with one error
            labSheetDetail.IntertechDuplicateRlog = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicateRlog, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.IntertechDuplicateRlog);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRlog has Min [0] and Max [1000]. At Max should return true and no errors
            labSheetDetail.IntertechDuplicateRlog = 1000.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1000.0f, labSheetDetail.IntertechDuplicateRlog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRlog has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            labSheetDetail.IntertechDuplicateRlog = 999.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(999.0f, labSheetDetail.IntertechDuplicateRlog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRlog has Min [0] and Max [1000]. At Max + 1 should return false with one error
            labSheetDetail.IntertechDuplicateRlog = 1001.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicateRlog, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, labSheetDetail.IntertechDuplicateRlog);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [IntertechDuplicatePrecisionCriteria] of type [float]
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Min should return true and no errors
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 0.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0f, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 1.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0f, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Min - 1 should return false with one error
            labSheetDetail.IntertechDuplicatePrecisionCriteria = -1.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Max should return true and no errors
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 1000.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1000.0f, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 999.0f;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(999.0f, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [1000]. At Max + 1 should return false with one error
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 1001.0f;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            // doing property [IntertechDuplicateAcceptable] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [IntertechReadAcceptable] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
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

        }
        #endregion Tests Generated
    }
}
