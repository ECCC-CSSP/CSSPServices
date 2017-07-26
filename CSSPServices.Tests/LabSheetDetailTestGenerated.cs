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
        private LabSheetDetailService labSheetDetailService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailTest() : base()
        {
            labSheetDetailService = new LabSheetDetailService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheetDetail GetFilledRandomLabSheetDetail(string OmitPropName)
        {
            LabSheetDetail labSheetDetail = new LabSheetDetail();

            if (OmitPropName != "LabSheetID") labSheetDetail.LabSheetID = 1;
            if (OmitPropName != "SamplingPlanID") labSheetDetail.SamplingPlanID = 1;
            if (OmitPropName != "SubsectorTVItemID") labSheetDetail.SubsectorTVItemID = 1;
            if (OmitPropName != "Version") labSheetDetail.Version = GetRandomInt(1, 5);
            if (OmitPropName != "RunDate") labSheetDetail.RunDate = GetRandomDateTime();
            if (OmitPropName != "Tides") labSheetDetail.Tides = GetRandomString("", 6);
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
            if (OmitPropName != "TCField1") labSheetDetail.TCField1 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCLab1") labSheetDetail.TCLab1 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCField2") labSheetDetail.TCField2 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCLab2") labSheetDetail.TCLab2 = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCFirst") labSheetDetail.TCFirst = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "TCAverage") labSheetDetail.TCAverage = GetRandomDouble(-10.0D, 40.0D);
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
            if (OmitPropName != "DailyDuplicateRLog") labSheetDetail.DailyDuplicateRLog = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") labSheetDetail.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "DailyDuplicateAcceptable") labSheetDetail.DailyDuplicateAcceptable = true;
            if (OmitPropName != "IntertechDuplicateRLog") labSheetDetail.IntertechDuplicateRLog = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") labSheetDetail.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicateAcceptable") labSheetDetail.IntertechDuplicateAcceptable = true;
            if (OmitPropName != "IntertechReadAcceptable") labSheetDetail.IntertechReadAcceptable = true;
            if (OmitPropName != "LastUpdateDate_UTC") labSheetDetail.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetDetail.LastUpdateContactTVItemID = 2;

            return labSheetDetail;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheetDetail_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            LabSheetDetail labSheetDetail = GetFilledRandomLabSheetDetail("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = labSheetDetailService.GetRead().Count();

            labSheetDetailService.Add(labSheetDetail);
            if (labSheetDetail.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, labSheetDetailService.GetRead().Where(c => c == labSheetDetail).Any());
            labSheetDetailService.Update(labSheetDetail);
            if (labSheetDetail.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, labSheetDetailService.GetRead().Count());
            labSheetDetailService.Delete(labSheetDetail);
            if (labSheetDetail.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // labSheetDetail.LabSheetDetailID   (Int32)
            //-----------------------------------
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            labSheetDetail.LabSheetDetailID = 0;
            labSheetDetailService.Update(labSheetDetail);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailLabSheetDetailID), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "LabSheet", Plurial = "s", FieldID = "LabSheetID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // labSheetDetail.LabSheetID   (Int32)
            //-----------------------------------
            // LabSheetID will automatically be initialized at 0 --> not null


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // LabSheetID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetDetail.LabSheetID = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.LabSheetID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // LabSheetID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetDetail.LabSheetID = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.LabSheetID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // LabSheetID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetDetail.LabSheetID = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetDetailLabSheetID, "1")).Any());
            Assert.AreEqual(0, labSheetDetail.LabSheetID);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "LabSheet", Plurial = "s", FieldID = "LabSheetID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // labSheetDetail.SamplingPlanID   (Int32)
            //-----------------------------------
            // SamplingPlanID will automatically be initialized at 0 --> not null


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // SamplingPlanID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetDetail.SamplingPlanID = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.SamplingPlanID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetDetail.SamplingPlanID = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.SamplingPlanID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetDetail.SamplingPlanID = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetDetailSamplingPlanID, "1")).Any());
            Assert.AreEqual(0, labSheetDetail.SamplingPlanID);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "LabSheet", Plurial = "s", FieldID = "LabSheetID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // labSheetDetail.SubsectorTVItemID   (Int32)
            //-----------------------------------
            // SubsectorTVItemID will automatically be initialized at 0 --> not null


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetDetail.SubsectorTVItemID = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.SubsectorTVItemID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetDetail.SubsectorTVItemID = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.SubsectorTVItemID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetDetail.SubsectorTVItemID = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetDetailSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheetDetail.SubsectorTVItemID);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(1, 5)]
            // labSheetDetail.Version   (Int32)
            //-----------------------------------
            // Version will automatically be initialized at 0 --> not null


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // Version has Min [1] and Max [5]. At Min should return true and no errors
            labSheetDetail.Version = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Min + 1 should return true and no errors
            labSheetDetail.Version = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Min - 1 should return false with one error
            labSheetDetail.Version = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailVersion, "1", "5")).Any());
            Assert.AreEqual(0, labSheetDetail.Version);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Max should return true and no errors
            labSheetDetail.Version = 5;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(5, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Max - 1 should return true and no errors
            labSheetDetail.Version = 4;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(4, labSheetDetail.Version);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // Version has Min [1] and Max [5]. At Max + 1 should return false with one error
            labSheetDetail.Version = 6;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailVersion, "1", "5")).Any());
            Assert.AreEqual(6, labSheetDetail.Version);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.RunDate   (DateTime)
            //-----------------------------------
            // RunDate will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(7, MinimumLength = 1)]
            // labSheetDetail.Tides   (String)
            //-----------------------------------
            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("Tides");
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(1, labSheetDetail.ValidationResults.Count());
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailTides)).Any());
            Assert.AreEqual(null, labSheetDetail.Tides);
            Assert.AreEqual(0, labSheetDetailService.GetRead().Count());


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Tides has MinLength [1] and MaxLength [7]. At Min should return true and no errors
            string labSheetDetailTidesMin = GetRandomString("", 1);
            labSheetDetail.Tides = labSheetDetailTidesMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailTidesMin, labSheetDetail.Tides);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Tides has MinLength [1] and MaxLength [7]. At Min + 1 should return true and no errors
            labSheetDetailTidesMin = GetRandomString("", 2);
            labSheetDetail.Tides = labSheetDetailTidesMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailTidesMin, labSheetDetail.Tides);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Tides has MinLength [1] and MaxLength [7]. At Max should return true and no errors
            labSheetDetailTidesMin = GetRandomString("", 7);
            labSheetDetail.Tides = labSheetDetailTidesMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailTidesMin, labSheetDetail.Tides);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Tides has MinLength [1] and MaxLength [7]. At Max - 1 should return true and no errors
            labSheetDetailTidesMin = GetRandomString("", 6);
            labSheetDetail.Tides = labSheetDetailTidesMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailTidesMin, labSheetDetail.Tides);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Tides has MinLength [1] and MaxLength [7]. At Max + 1 should return false with one error
            labSheetDetailTidesMin = GetRandomString("", 8);
            labSheetDetail.Tides = labSheetDetailTidesMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailTides, "1", "7")).Any());
            Assert.AreEqual(labSheetDetailTidesMin, labSheetDetail.Tides);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(20))]
            // labSheetDetail.SampleCrewInitials   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // SampleCrewInitials has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailSampleCrewInitialsMin = GetRandomString("", 19);
            labSheetDetail.SampleCrewInitials = labSheetDetailSampleCrewInitialsMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailSampleCrewInitialsMin, labSheetDetail.SampleCrewInitials);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // SampleCrewInitials has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailSampleCrewInitialsMin = GetRandomString("", 21);
            labSheetDetail.SampleCrewInitials = labSheetDetailSampleCrewInitialsMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSampleCrewInitials, "20")).Any());
            Assert.AreEqual(labSheetDetailSampleCrewInitialsMin, labSheetDetail.SampleCrewInitials);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(1, 3)]
            // labSheetDetail.WaterBathCount   (Int32)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // WaterBathCount has Min [1] and Max [3]. At Min should return true and no errors
            labSheetDetail.WaterBathCount = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.WaterBathCount);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Min + 1 should return true and no errors
            labSheetDetail.WaterBathCount = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.WaterBathCount);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Min - 1 should return false with one error
            labSheetDetail.WaterBathCount = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailWaterBathCount, "1", "3")).Any());
            Assert.AreEqual(0, labSheetDetail.WaterBathCount);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Max should return true and no errors
            labSheetDetail.WaterBathCount = 3;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(3, labSheetDetail.WaterBathCount);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Max - 1 should return true and no errors
            labSheetDetail.WaterBathCount = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.WaterBathCount);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // WaterBathCount has Min [1] and Max [3]. At Max + 1 should return false with one error
            labSheetDetail.WaterBathCount = 4;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailWaterBathCount, "1", "3")).Any());
            Assert.AreEqual(4, labSheetDetail.WaterBathCount);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.IncubationBath1StartTime   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.IncubationBath2StartTime   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.IncubationBath3StartTime   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.IncubationBath1EndTime   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.IncubationBath2EndTime   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.IncubationBath3EndTime   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[Range(0, 10000)]
            // labSheetDetail.IncubationBath1TimeCalculated_minutes   (Int32)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Min should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 0;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Min - 1 should return false with one error
            labSheetDetail.IncubationBath1TimeCalculated_minutes = -1;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(-1, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Max should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 10000;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(10000, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 9999;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(9999, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath1TimeCalculated_minutes has Min [0] and Max [10000]. At Max + 1 should return false with one error
            labSheetDetail.IncubationBath1TimeCalculated_minutes = 10001;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(10001, labSheetDetail.IncubationBath1TimeCalculated_minutes);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 10000)]
            // labSheetDetail.IncubationBath2TimeCalculated_minutes   (Int32)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Min should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 0;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Min - 1 should return false with one error
            labSheetDetail.IncubationBath2TimeCalculated_minutes = -1;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(-1, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Max should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 10000;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(10000, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 9999;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(9999, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath2TimeCalculated_minutes has Min [0] and Max [10000]. At Max + 1 should return false with one error
            labSheetDetail.IncubationBath2TimeCalculated_minutes = 10001;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(10001, labSheetDetail.IncubationBath2TimeCalculated_minutes);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 10000)]
            // labSheetDetail.IncubationBath3TimeCalculated_minutes   (Int32)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Min should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 0;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Min - 1 should return false with one error
            labSheetDetail.IncubationBath3TimeCalculated_minutes = -1;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(-1, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Max should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 10000;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(10000, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 9999;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(9999, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IncubationBath3TimeCalculated_minutes has Min [0] and Max [10000]. At Max + 1 should return false with one error
            labSheetDetail.IncubationBath3TimeCalculated_minutes = 10001;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000")).Any());
            Assert.AreEqual(10001, labSheetDetail.IncubationBath3TimeCalculated_minutes);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(10))]
            // labSheetDetail.WaterBath1   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // WaterBath1 has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            labSheetDetailWaterBath1Min = GetRandomString("", 9);
            labSheetDetail.WaterBath1 = labSheetDetailWaterBath1Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWaterBath1Min, labSheetDetail.WaterBath1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // WaterBath1 has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            labSheetDetailWaterBath1Min = GetRandomString("", 11);
            labSheetDetail.WaterBath1 = labSheetDetailWaterBath1Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath1, "10")).Any());
            Assert.AreEqual(labSheetDetailWaterBath1Min, labSheetDetail.WaterBath1);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(10))]
            // labSheetDetail.WaterBath2   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // WaterBath2 has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            labSheetDetailWaterBath2Min = GetRandomString("", 9);
            labSheetDetail.WaterBath2 = labSheetDetailWaterBath2Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWaterBath2Min, labSheetDetail.WaterBath2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // WaterBath2 has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            labSheetDetailWaterBath2Min = GetRandomString("", 11);
            labSheetDetail.WaterBath2 = labSheetDetailWaterBath2Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath2, "10")).Any());
            Assert.AreEqual(labSheetDetailWaterBath2Min, labSheetDetail.WaterBath2);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(10))]
            // labSheetDetail.WaterBath3   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // WaterBath3 has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            labSheetDetailWaterBath3Min = GetRandomString("", 9);
            labSheetDetail.WaterBath3 = labSheetDetailWaterBath3Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWaterBath3Min, labSheetDetail.WaterBath3);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // WaterBath3 has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            labSheetDetailWaterBath3Min = GetRandomString("", 11);
            labSheetDetail.WaterBath3 = labSheetDetailWaterBath3Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath3, "10")).Any());
            Assert.AreEqual(labSheetDetailWaterBath3Min, labSheetDetail.WaterBath3);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // labSheetDetail.TCField1   (Double)
            //-----------------------------------
            //Error: Type not implemented [TCField1]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCField1 has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            labSheetDetail.TCField1 = -10.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-10.0D, labSheetDetail.TCField1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            labSheetDetail.TCField1 = -9.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-9.0D, labSheetDetail.TCField1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            labSheetDetail.TCField1 = -11.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField1, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, labSheetDetail.TCField1);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            labSheetDetail.TCField1 = 40.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0D, labSheetDetail.TCField1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            labSheetDetail.TCField1 = 39.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0D, labSheetDetail.TCField1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField1 has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            labSheetDetail.TCField1 = 41.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField1, "-10", "40")).Any());
            Assert.AreEqual(41.0D, labSheetDetail.TCField1);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // labSheetDetail.TCLab1   (Double)
            //-----------------------------------
            //Error: Type not implemented [TCLab1]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCLab1 has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            labSheetDetail.TCLab1 = -10.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-10.0D, labSheetDetail.TCLab1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            labSheetDetail.TCLab1 = -9.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-9.0D, labSheetDetail.TCLab1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            labSheetDetail.TCLab1 = -11.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab1, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, labSheetDetail.TCLab1);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            labSheetDetail.TCLab1 = 40.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0D, labSheetDetail.TCLab1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            labSheetDetail.TCLab1 = 39.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0D, labSheetDetail.TCLab1);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab1 has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            labSheetDetail.TCLab1 = 41.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab1, "-10", "40")).Any());
            Assert.AreEqual(41.0D, labSheetDetail.TCLab1);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // labSheetDetail.TCField2   (Double)
            //-----------------------------------
            //Error: Type not implemented [TCField2]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCField2 has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            labSheetDetail.TCField2 = -10.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-10.0D, labSheetDetail.TCField2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            labSheetDetail.TCField2 = -9.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-9.0D, labSheetDetail.TCField2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            labSheetDetail.TCField2 = -11.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField2, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, labSheetDetail.TCField2);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            labSheetDetail.TCField2 = 40.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0D, labSheetDetail.TCField2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            labSheetDetail.TCField2 = 39.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0D, labSheetDetail.TCField2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCField2 has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            labSheetDetail.TCField2 = 41.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField2, "-10", "40")).Any());
            Assert.AreEqual(41.0D, labSheetDetail.TCField2);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // labSheetDetail.TCLab2   (Double)
            //-----------------------------------
            //Error: Type not implemented [TCLab2]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCLab2 has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            labSheetDetail.TCLab2 = -10.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-10.0D, labSheetDetail.TCLab2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            labSheetDetail.TCLab2 = -9.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-9.0D, labSheetDetail.TCLab2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            labSheetDetail.TCLab2 = -11.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab2, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, labSheetDetail.TCLab2);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            labSheetDetail.TCLab2 = 40.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0D, labSheetDetail.TCLab2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            labSheetDetail.TCLab2 = 39.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0D, labSheetDetail.TCLab2);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCLab2 has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            labSheetDetail.TCLab2 = 41.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab2, "-10", "40")).Any());
            Assert.AreEqual(41.0D, labSheetDetail.TCLab2);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // labSheetDetail.TCFirst   (Double)
            //-----------------------------------
            //Error: Type not implemented [TCFirst]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCFirst has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            labSheetDetail.TCFirst = -10.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-10.0D, labSheetDetail.TCFirst);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            labSheetDetail.TCFirst = -9.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-9.0D, labSheetDetail.TCFirst);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            labSheetDetail.TCFirst = -11.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCFirst, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, labSheetDetail.TCFirst);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            labSheetDetail.TCFirst = 40.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0D, labSheetDetail.TCFirst);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            labSheetDetail.TCFirst = 39.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0D, labSheetDetail.TCFirst);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCFirst has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            labSheetDetail.TCFirst = 41.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCFirst, "-10", "40")).Any());
            Assert.AreEqual(41.0D, labSheetDetail.TCFirst);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // labSheetDetail.TCAverage   (Double)
            //-----------------------------------
            //Error: Type not implemented [TCAverage]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // TCAverage has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            labSheetDetail.TCAverage = -10.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-10.0D, labSheetDetail.TCAverage);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            labSheetDetail.TCAverage = -9.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(-9.0D, labSheetDetail.TCAverage);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            labSheetDetail.TCAverage = -11.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCAverage, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, labSheetDetail.TCAverage);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            labSheetDetail.TCAverage = 40.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(40.0D, labSheetDetail.TCAverage);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            labSheetDetail.TCAverage = 39.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(39.0D, labSheetDetail.TCAverage);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // TCAverage has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            labSheetDetail.TCAverage = 41.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCAverage, "-10", "40")).Any());
            Assert.AreEqual(41.0D, labSheetDetail.TCAverage);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(100))]
            // labSheetDetail.ControlLot   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // ControlLot has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            labSheetDetailControlLotMin = GetRandomString("", 99);
            labSheetDetail.ControlLot = labSheetDetailControlLotMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailControlLotMin, labSheetDetail.ControlLot);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // ControlLot has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            labSheetDetailControlLotMin = GetRandomString("", 101);
            labSheetDetail.ControlLot = labSheetDetailControlLotMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailControlLot, "100")).Any());
            Assert.AreEqual(labSheetDetailControlLotMin, labSheetDetail.ControlLot);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Positive35   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Positive35 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailPositive35Min = GetRandomString("", 1);
            labSheetDetail.Positive35 = labSheetDetailPositive35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailPositive35Min, labSheetDetail.Positive35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Positive35 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailPositive35Min = GetRandomString("", 1);
            labSheetDetail.Positive35 = labSheetDetailPositive35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailPositive35Min, labSheetDetail.Positive35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Positive35 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailPositive35Min = GetRandomString("", 2);
            labSheetDetail.Positive35 = labSheetDetailPositive35Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailPositive35, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailPositive35Min, labSheetDetail.Positive35);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.NonTarget35   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // NonTarget35 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailNonTarget35Min = GetRandomString("", 1);
            labSheetDetail.NonTarget35 = labSheetDetailNonTarget35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailNonTarget35Min, labSheetDetail.NonTarget35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // NonTarget35 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailNonTarget35Min = GetRandomString("", 1);
            labSheetDetail.NonTarget35 = labSheetDetailNonTarget35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailNonTarget35Min, labSheetDetail.NonTarget35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // NonTarget35 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailNonTarget35Min = GetRandomString("", 2);
            labSheetDetail.NonTarget35 = labSheetDetailNonTarget35Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailNonTarget35, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailNonTarget35Min, labSheetDetail.NonTarget35);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Negative35   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Negative35 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailNegative35Min = GetRandomString("", 1);
            labSheetDetail.Negative35 = labSheetDetailNegative35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailNegative35Min, labSheetDetail.Negative35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Negative35 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailNegative35Min = GetRandomString("", 1);
            labSheetDetail.Negative35 = labSheetDetailNegative35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailNegative35Min, labSheetDetail.Negative35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Negative35 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailNegative35Min = GetRandomString("", 2);
            labSheetDetail.Negative35 = labSheetDetailNegative35Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailNegative35, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailNegative35Min, labSheetDetail.Negative35);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath1Positive44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath1Positive44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath1Positive44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1Positive44_5 = labSheetDetailBath1Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Positive44_5Min, labSheetDetail.Bath1Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath1Positive44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath1Positive44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1Positive44_5 = labSheetDetailBath1Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Positive44_5Min, labSheetDetail.Bath1Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath1Positive44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath1Positive44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath1Positive44_5 = labSheetDetailBath1Positive44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1Positive44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath1Positive44_5Min, labSheetDetail.Bath1Positive44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath2Positive44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath2Positive44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath2Positive44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2Positive44_5 = labSheetDetailBath2Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Positive44_5Min, labSheetDetail.Bath2Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath2Positive44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath2Positive44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2Positive44_5 = labSheetDetailBath2Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Positive44_5Min, labSheetDetail.Bath2Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath2Positive44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath2Positive44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath2Positive44_5 = labSheetDetailBath2Positive44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2Positive44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath2Positive44_5Min, labSheetDetail.Bath2Positive44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath3Positive44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath3Positive44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath3Positive44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3Positive44_5 = labSheetDetailBath3Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Positive44_5Min, labSheetDetail.Bath3Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath3Positive44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath3Positive44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3Positive44_5 = labSheetDetailBath3Positive44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Positive44_5Min, labSheetDetail.Bath3Positive44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath3Positive44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath3Positive44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath3Positive44_5 = labSheetDetailBath3Positive44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3Positive44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath3Positive44_5Min, labSheetDetail.Bath3Positive44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath1NonTarget44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath1NonTarget44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath1NonTarget44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1NonTarget44_5 = labSheetDetailBath1NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1NonTarget44_5Min, labSheetDetail.Bath1NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath1NonTarget44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath1NonTarget44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1NonTarget44_5 = labSheetDetailBath1NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1NonTarget44_5Min, labSheetDetail.Bath1NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath1NonTarget44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath1NonTarget44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath1NonTarget44_5 = labSheetDetailBath1NonTarget44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1NonTarget44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath1NonTarget44_5Min, labSheetDetail.Bath1NonTarget44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath2NonTarget44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath2NonTarget44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath2NonTarget44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2NonTarget44_5 = labSheetDetailBath2NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2NonTarget44_5Min, labSheetDetail.Bath2NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath2NonTarget44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath2NonTarget44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2NonTarget44_5 = labSheetDetailBath2NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2NonTarget44_5Min, labSheetDetail.Bath2NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath2NonTarget44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath2NonTarget44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath2NonTarget44_5 = labSheetDetailBath2NonTarget44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2NonTarget44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath2NonTarget44_5Min, labSheetDetail.Bath2NonTarget44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath3NonTarget44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath3NonTarget44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath3NonTarget44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3NonTarget44_5 = labSheetDetailBath3NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3NonTarget44_5Min, labSheetDetail.Bath3NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath3NonTarget44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath3NonTarget44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3NonTarget44_5 = labSheetDetailBath3NonTarget44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3NonTarget44_5Min, labSheetDetail.Bath3NonTarget44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath3NonTarget44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath3NonTarget44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath3NonTarget44_5 = labSheetDetailBath3NonTarget44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3NonTarget44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath3NonTarget44_5Min, labSheetDetail.Bath3NonTarget44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath1Negative44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath1Negative44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath1Negative44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1Negative44_5 = labSheetDetailBath1Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Negative44_5Min, labSheetDetail.Bath1Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath1Negative44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath1Negative44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1Negative44_5 = labSheetDetailBath1Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Negative44_5Min, labSheetDetail.Bath1Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath1Negative44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath1Negative44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath1Negative44_5 = labSheetDetailBath1Negative44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1Negative44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath1Negative44_5Min, labSheetDetail.Bath1Negative44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath2Negative44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath2Negative44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath2Negative44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2Negative44_5 = labSheetDetailBath2Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Negative44_5Min, labSheetDetail.Bath2Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath2Negative44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath2Negative44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2Negative44_5 = labSheetDetailBath2Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Negative44_5Min, labSheetDetail.Bath2Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath2Negative44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath2Negative44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath2Negative44_5 = labSheetDetailBath2Negative44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2Negative44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath2Negative44_5Min, labSheetDetail.Bath2Negative44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath3Negative44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath3Negative44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath3Negative44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3Negative44_5 = labSheetDetailBath3Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Negative44_5Min, labSheetDetail.Bath3Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath3Negative44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath3Negative44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3Negative44_5 = labSheetDetailBath3Negative44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Negative44_5Min, labSheetDetail.Bath3Negative44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath3Negative44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath3Negative44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath3Negative44_5 = labSheetDetailBath3Negative44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3Negative44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath3Negative44_5Min, labSheetDetail.Bath3Negative44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Blank35   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Blank35 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBlank35Min = GetRandomString("", 1);
            labSheetDetail.Blank35 = labSheetDetailBlank35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBlank35Min, labSheetDetail.Blank35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Blank35 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBlank35Min = GetRandomString("", 1);
            labSheetDetail.Blank35 = labSheetDetailBlank35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBlank35Min, labSheetDetail.Blank35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Blank35 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBlank35Min = GetRandomString("", 2);
            labSheetDetail.Blank35 = labSheetDetailBlank35Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBlank35, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBlank35Min, labSheetDetail.Blank35);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath1Blank44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath1Blank44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath1Blank44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1Blank44_5 = labSheetDetailBath1Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Blank44_5Min, labSheetDetail.Bath1Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath1Blank44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath1Blank44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath1Blank44_5 = labSheetDetailBath1Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath1Blank44_5Min, labSheetDetail.Bath1Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath1Blank44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath1Blank44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath1Blank44_5 = labSheetDetailBath1Blank44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1Blank44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath1Blank44_5Min, labSheetDetail.Bath1Blank44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath2Blank44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath2Blank44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath2Blank44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2Blank44_5 = labSheetDetailBath2Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Blank44_5Min, labSheetDetail.Bath2Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath2Blank44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath2Blank44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath2Blank44_5 = labSheetDetailBath2Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath2Blank44_5Min, labSheetDetail.Bath2Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath2Blank44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath2Blank44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath2Blank44_5 = labSheetDetailBath2Blank44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2Blank44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath2Blank44_5Min, labSheetDetail.Bath2Blank44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(1, MinimumLength = 1)]
            // labSheetDetail.Bath3Blank44_5   (String)
            //-----------------------------------

            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");

            // Bath3Blank44_5 has MinLength [1] and MaxLength [1]. At Min should return true and no errors
            string labSheetDetailBath3Blank44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3Blank44_5 = labSheetDetailBath3Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Blank44_5Min, labSheetDetail.Bath3Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath3Blank44_5 has MinLength [1] and MaxLength [1]. At Max should return true and no errors
            labSheetDetailBath3Blank44_5Min = GetRandomString("", 1);
            labSheetDetail.Bath3Blank44_5 = labSheetDetailBath3Blank44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailBath3Blank44_5Min, labSheetDetail.Bath3Blank44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Bath3Blank44_5 has MinLength [1] and MaxLength [1]. At Max + 1 should return false with one error
            labSheetDetailBath3Blank44_5Min = GetRandomString("", 2);
            labSheetDetail.Bath3Blank44_5 = labSheetDetailBath3Blank44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3Blank44_5, "1", "1")).Any());
            Assert.AreEqual(labSheetDetailBath3Blank44_5Min, labSheetDetail.Bath3Blank44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(20))]
            // labSheetDetail.Lot35   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Lot35 has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailLot35Min = GetRandomString("", 19);
            labSheetDetail.Lot35 = labSheetDetailLot35Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailLot35Min, labSheetDetail.Lot35);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Lot35 has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailLot35Min = GetRandomString("", 21);
            labSheetDetail.Lot35 = labSheetDetailLot35Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailLot35, "20")).Any());
            Assert.AreEqual(labSheetDetailLot35Min, labSheetDetail.Lot35);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(20))]
            // labSheetDetail.Lot44_5   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Lot44_5 has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailLot44_5Min = GetRandomString("", 19);
            labSheetDetail.Lot44_5 = labSheetDetailLot44_5Min;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailLot44_5Min, labSheetDetail.Lot44_5);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Lot44_5 has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailLot44_5Min = GetRandomString("", 21);
            labSheetDetail.Lot44_5 = labSheetDetailLot44_5Min;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailLot44_5, "20")).Any());
            Assert.AreEqual(labSheetDetailLot44_5Min, labSheetDetail.Lot44_5);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(250))]
            // labSheetDetail.Weather   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Weather has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetDetailWeatherMin = GetRandomString("", 249);
            labSheetDetail.Weather = labSheetDetailWeatherMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailWeatherMin, labSheetDetail.Weather);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // Weather has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetDetailWeatherMin = GetRandomString("", 251);
            labSheetDetail.Weather = labSheetDetailWeatherMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWeather, "250")).Any());
            Assert.AreEqual(labSheetDetailWeatherMin, labSheetDetail.Weather);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(250))]
            // labSheetDetail.RunComment   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // RunComment has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetDetailRunCommentMin = GetRandomString("", 249);
            labSheetDetail.RunComment = labSheetDetailRunCommentMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailRunCommentMin, labSheetDetail.RunComment);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // RunComment has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetDetailRunCommentMin = GetRandomString("", 251);
            labSheetDetail.RunComment = labSheetDetailRunCommentMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailRunComment, "250")).Any());
            Assert.AreEqual(labSheetDetailRunCommentMin, labSheetDetail.RunComment);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(250))]
            // labSheetDetail.RunWeatherComment   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // RunWeatherComment has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            labSheetDetailRunWeatherCommentMin = GetRandomString("", 249);
            labSheetDetail.RunWeatherComment = labSheetDetailRunWeatherCommentMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailRunWeatherCommentMin, labSheetDetail.RunWeatherComment);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // RunWeatherComment has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            labSheetDetailRunWeatherCommentMin = GetRandomString("", 251);
            labSheetDetail.RunWeatherComment = labSheetDetailRunWeatherCommentMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailRunWeatherComment, "250")).Any());
            Assert.AreEqual(labSheetDetailRunWeatherCommentMin, labSheetDetail.RunWeatherComment);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(20))]
            // labSheetDetail.SampleBottleLotNumber   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // SampleBottleLotNumber has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailSampleBottleLotNumberMin = GetRandomString("", 19);
            labSheetDetail.SampleBottleLotNumber = labSheetDetailSampleBottleLotNumberMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailSampleBottleLotNumberMin, labSheetDetail.SampleBottleLotNumber);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // SampleBottleLotNumber has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailSampleBottleLotNumberMin = GetRandomString("", 21);
            labSheetDetail.SampleBottleLotNumber = labSheetDetailSampleBottleLotNumberMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSampleBottleLotNumber, "20")).Any());
            Assert.AreEqual(labSheetDetailSampleBottleLotNumberMin, labSheetDetail.SampleBottleLotNumber);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(20))]
            // labSheetDetail.SalinitiesReadBy   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // SalinitiesReadBy has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailSalinitiesReadByMin = GetRandomString("", 19);
            labSheetDetail.SalinitiesReadBy = labSheetDetailSalinitiesReadByMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailSalinitiesReadByMin, labSheetDetail.SalinitiesReadBy);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // SalinitiesReadBy has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailSalinitiesReadByMin = GetRandomString("", 21);
            labSheetDetail.SalinitiesReadBy = labSheetDetailSalinitiesReadByMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSalinitiesReadBy, "20")).Any());
            Assert.AreEqual(labSheetDetailSalinitiesReadByMin, labSheetDetail.SalinitiesReadBy);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.SalinitiesReadDate   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[StringLength(20))]
            // labSheetDetail.ResultsReadBy   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // ResultsReadBy has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailResultsReadByMin = GetRandomString("", 19);
            labSheetDetail.ResultsReadBy = labSheetDetailResultsReadByMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailResultsReadByMin, labSheetDetail.ResultsReadBy);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // ResultsReadBy has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailResultsReadByMin = GetRandomString("", 21);
            labSheetDetail.ResultsReadBy = labSheetDetailResultsReadByMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailResultsReadBy, "20")).Any());
            Assert.AreEqual(labSheetDetailResultsReadByMin, labSheetDetail.ResultsReadBy);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.ResultsReadDate   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[StringLength(20))]
            // labSheetDetail.ResultsRecordedBy   (String)
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
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // ResultsRecordedBy has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            labSheetDetailResultsRecordedByMin = GetRandomString("", 19);
            labSheetDetail.ResultsRecordedBy = labSheetDetailResultsRecordedByMin;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(labSheetDetailResultsRecordedByMin, labSheetDetail.ResultsRecordedBy);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            // ResultsRecordedBy has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            labSheetDetailResultsRecordedByMin = GetRandomString("", 21);
            labSheetDetail.ResultsRecordedBy = labSheetDetailResultsRecordedByMin;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailResultsRecordedBy, "20")).Any());
            Assert.AreEqual(labSheetDetailResultsRecordedByMin, labSheetDetail.ResultsRecordedBy);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.ResultsRecordedDate   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[Range(0, 100)]
            // labSheetDetail.DailyDuplicateRLog   (Double)
            //-----------------------------------
            //Error: Type not implemented [DailyDuplicateRLog]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // DailyDuplicateRLog has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            labSheetDetail.DailyDuplicateRLog = 0.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0D, labSheetDetail.DailyDuplicateRLog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRLog has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            labSheetDetail.DailyDuplicateRLog = 1.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0D, labSheetDetail.DailyDuplicateRLog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRLog has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            labSheetDetail.DailyDuplicateRLog = -1.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicateRLog, "0", "100")).Any());
            Assert.AreEqual(-1.0D, labSheetDetail.DailyDuplicateRLog);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRLog has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            labSheetDetail.DailyDuplicateRLog = 100.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(100.0D, labSheetDetail.DailyDuplicateRLog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRLog has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            labSheetDetail.DailyDuplicateRLog = 99.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(99.0D, labSheetDetail.DailyDuplicateRLog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicateRLog has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            labSheetDetail.DailyDuplicateRLog = 101.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicateRLog, "0", "100")).Any());
            Assert.AreEqual(101.0D, labSheetDetail.DailyDuplicateRLog);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 100)]
            // labSheetDetail.DailyDuplicatePrecisionCriteria   (Double)
            //-----------------------------------
            //Error: Type not implemented [DailyDuplicatePrecisionCriteria]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            labSheetDetail.DailyDuplicatePrecisionCriteria = 0.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0D, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            labSheetDetail.DailyDuplicatePrecisionCriteria = 1.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0D, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            labSheetDetail.DailyDuplicatePrecisionCriteria = -1.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(-1.0D, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            labSheetDetail.DailyDuplicatePrecisionCriteria = 100.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(100.0D, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            labSheetDetail.DailyDuplicatePrecisionCriteria = 99.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(99.0D, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            labSheetDetail.DailyDuplicatePrecisionCriteria = 101.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(101.0D, labSheetDetail.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            // labSheetDetail.DailyDuplicateAcceptable   (Boolean)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[Range(0, 100)]
            // labSheetDetail.IntertechDuplicateRLog   (Double)
            //-----------------------------------
            //Error: Type not implemented [IntertechDuplicateRLog]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IntertechDuplicateRLog has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            labSheetDetail.IntertechDuplicateRLog = 0.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0D, labSheetDetail.IntertechDuplicateRLog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRLog has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            labSheetDetail.IntertechDuplicateRLog = 1.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0D, labSheetDetail.IntertechDuplicateRLog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRLog has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            labSheetDetail.IntertechDuplicateRLog = -1.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicateRLog, "0", "100")).Any());
            Assert.AreEqual(-1.0D, labSheetDetail.IntertechDuplicateRLog);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRLog has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            labSheetDetail.IntertechDuplicateRLog = 100.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(100.0D, labSheetDetail.IntertechDuplicateRLog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRLog has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            labSheetDetail.IntertechDuplicateRLog = 99.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(99.0D, labSheetDetail.IntertechDuplicateRLog);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicateRLog has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            labSheetDetail.IntertechDuplicateRLog = 101.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicateRLog, "0", "100")).Any());
            Assert.AreEqual(101.0D, labSheetDetail.IntertechDuplicateRLog);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 100)]
            // labSheetDetail.IntertechDuplicatePrecisionCriteria   (Double)
            //-----------------------------------
            //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 0.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(0.0D, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 1.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1.0D, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            labSheetDetail.IntertechDuplicatePrecisionCriteria = -1.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(-1.0D, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 100.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(100.0D, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 99.0D;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(99.0D, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            labSheetDetail.IntertechDuplicatePrecisionCriteria = 101.0D;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(101.0D, labSheetDetail.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            // labSheetDetail.IntertechDuplicateAcceptable   (Boolean)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            // labSheetDetail.IntertechReadAcceptable   (Boolean)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // labSheetDetail.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // labSheetDetail.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            labSheetDetail = null;
            labSheetDetail = GetFilledRandomLabSheetDetail("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            labSheetDetail.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(1, labSheetDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            labSheetDetail.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, labSheetDetailService.Add(labSheetDetail));
            Assert.AreEqual(0, labSheetDetail.ValidationResults.Count());
            Assert.AreEqual(2, labSheetDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(true, labSheetDetailService.Delete(labSheetDetail));
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            labSheetDetail.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
            Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetDetailLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, labSheetDetail.LastUpdateContactTVItemID);
            Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheetDetail.LabSheetTubeMPNDetails   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheetDetail.LabSheet   (LabSheet)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheetDetail.SamplingPlan   (SamplingPlan)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // labSheetDetail.SubsectorTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // labSheetDetail.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
