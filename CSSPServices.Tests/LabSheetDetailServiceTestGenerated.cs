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
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class LabSheetDetailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LabSheetDetailService labSheetDetailService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailServiceTest() : base()
        {
            //labSheetDetailService = new LabSheetDetailService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "SubsectorTVItemID") labSheetDetail.SubsectorTVItemID = 11;
            if (OmitPropName != "Version") labSheetDetail.Version = GetRandomInt(1, 5);
            if (OmitPropName != "RunDate") labSheetDetail.RunDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "Tides") labSheetDetail.Tides = GetRandomString("", 6);
            if (OmitPropName != "SampleCrewInitials") labSheetDetail.SampleCrewInitials = GetRandomString("", 5);
            if (OmitPropName != "WaterBathCount") labSheetDetail.WaterBathCount = GetRandomInt(1, 3);
            if (OmitPropName != "IncubationBath1StartTime") labSheetDetail.IncubationBath1StartTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath2StartTime") labSheetDetail.IncubationBath2StartTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath3StartTime") labSheetDetail.IncubationBath3StartTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath1EndTime") labSheetDetail.IncubationBath1EndTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath2EndTime") labSheetDetail.IncubationBath2EndTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncubationBath3EndTime") labSheetDetail.IncubationBath3EndTime = new DateTime(2005, 3, 6);
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
            if (OmitPropName != "SalinitiesReadDate") labSheetDetail.SalinitiesReadDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "ResultsReadBy") labSheetDetail.ResultsReadBy = GetRandomString("", 5);
            if (OmitPropName != "ResultsReadDate") labSheetDetail.ResultsReadDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "ResultsRecordedBy") labSheetDetail.ResultsRecordedBy = GetRandomString("", 5);
            if (OmitPropName != "ResultsRecordedDate") labSheetDetail.ResultsRecordedDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "DailyDuplicateRLog") labSheetDetail.DailyDuplicateRLog = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") labSheetDetail.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "DailyDuplicateAcceptable") labSheetDetail.DailyDuplicateAcceptable = true;
            if (OmitPropName != "IntertechDuplicateRLog") labSheetDetail.IntertechDuplicateRLog = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") labSheetDetail.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicateAcceptable") labSheetDetail.IntertechDuplicateAcceptable = true;
            if (OmitPropName != "IntertechReadAcceptable") labSheetDetail.IntertechReadAcceptable = true;
            if (OmitPropName != "LastUpdateDate_UTC") labSheetDetail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheetDetail.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "SubsectorTVText") labSheetDetail.SubsectorTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") labSheetDetail.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") labSheetDetail.HasErrors = true;

            return labSheetDetail;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LabSheetDetail_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetDetailService labSheetDetailService = new LabSheetDetailService(LanguageRequest, dbTestDB, ContactID);

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

                Assert.AreEqual(labSheetDetailService.GetRead().Count(), labSheetDetailService.GetEdit().Count());

                labSheetDetailService.Add(labSheetDetail);
                if (labSheetDetail.HasErrors)
                {
                    Assert.AreEqual("", labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, labSheetDetailService.GetRead().Where(c => c == labSheetDetail).Any());
                labSheetDetailService.Update(labSheetDetail);
                if (labSheetDetail.HasErrors)
                {
                    Assert.AreEqual("", labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, labSheetDetailService.GetRead().Count());
                labSheetDetailService.Delete(labSheetDetail);
                if (labSheetDetail.HasErrors)
                {
                    Assert.AreEqual("", labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // labSheetDetail.LabSheetDetailID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetDetailID = 0;
                    labSheetDetailService.Update(labSheetDetail);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailLabSheetDetailID), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetDetailID = 10000000;
                    labSheetDetailService.Update(labSheetDetail);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.LabSheetDetail, ModelsRes.LabSheetDetailLabSheetDetailID, labSheetDetail.LabSheetDetailID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "LabSheet", ExistPlurial = "s", ExistFieldID = "LabSheetID", AllowableTVtypeList = Error)]
                    // labSheetDetail.LabSheetID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LabSheetID = 0;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.LabSheet, ModelsRes.LabSheetDetailLabSheetID, labSheetDetail.LabSheetID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = Error)]
                    // labSheetDetail.SamplingPlanID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SamplingPlanID = 0;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlan, ModelsRes.LabSheetDetailSamplingPlanID, labSheetDetail.SamplingPlanID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // labSheetDetail.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SubsectorTVItemID = 0;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetDetailSubsectorTVItemID, labSheetDetail.SubsectorTVItemID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SubsectorTVItemID = 1;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetDetailSubsectorTVItemID, "Subsector"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 5)]
                    // labSheetDetail.Version   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Version = 0;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailVersion, "1", "5"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Version = 6;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailVersion, "1", "5"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.RunDate   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(7, MinimumLength = 1)]
                    // labSheetDetail.Tides   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("Tides");
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(1, labSheetDetail.ValidationResults.Count());
                    Assert.IsTrue(labSheetDetail.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailTides)).Any());
                    Assert.AreEqual(null, labSheetDetail.Tides);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Tides = GetRandomString("", 8);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailTides, "1", "7"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.SampleCrewInitials   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SampleCrewInitials = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSampleCrewInitials, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 3)]
                    // labSheetDetail.WaterBathCount   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBathCount = 0;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailWaterBathCount, "1", "3"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBathCount = 4;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailWaterBathCount, "1", "3"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath1StartTime   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath2StartTime   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath3StartTime   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath1EndTime   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath2EndTime   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.IncubationBath3EndTime   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // labSheetDetail.IncubationBath1TimeCalculated_minutes   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath1TimeCalculated_minutes = -1;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath1TimeCalculated_minutes = 10001;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // labSheetDetail.IncubationBath2TimeCalculated_minutes   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath2TimeCalculated_minutes = -1;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath2TimeCalculated_minutes = 10001;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // labSheetDetail.IncubationBath3TimeCalculated_minutes   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath3TimeCalculated_minutes = -1;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IncubationBath3TimeCalculated_minutes = 10001;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // labSheetDetail.WaterBath1   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBath1 = GetRandomString("", 11);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath1, "10"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // labSheetDetail.WaterBath2   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBath2 = GetRandomString("", 11);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath2, "10"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // labSheetDetail.WaterBath3   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.WaterBath3 = GetRandomString("", 11);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath3, "10"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCField1   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCField1]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCField1 = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField1, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCField1 = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField1, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCLab1   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCLab1]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCLab1 = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab1, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCLab1 = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab1, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCField2   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCField2]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCField2 = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField2, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCField2 = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField2, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCLab2   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCLab2]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCLab2 = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab2, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCLab2 = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab2, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCFirst   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCFirst]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCFirst = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCFirst, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCFirst = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCFirst, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // labSheetDetail.TCAverage   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TCAverage]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCAverage = -11.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCAverage, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.TCAverage = 41.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCAverage, "-10", "40"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(100))]
                    // labSheetDetail.ControlLot   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.ControlLot = GetRandomString("", 101);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailControlLot, "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Positive35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Positive35 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailPositive35, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.NonTarget35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.NonTarget35 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailNonTarget35, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Negative35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Negative35 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailNegative35, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath1Positive44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath1Positive44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1Positive44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath2Positive44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath2Positive44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2Positive44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath3Positive44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath3Positive44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3Positive44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath1NonTarget44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath1NonTarget44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1NonTarget44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath2NonTarget44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath2NonTarget44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2NonTarget44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath3NonTarget44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath3NonTarget44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3NonTarget44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath1Negative44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath1Negative44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1Negative44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath2Negative44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath2Negative44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2Negative44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath3Negative44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath3Negative44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3Negative44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Blank35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Blank35 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBlank35, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath1Blank44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath1Blank44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1Blank44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath2Blank44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath2Blank44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2Blank44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(1, MinimumLength = 1)]
                    // labSheetDetail.Bath3Blank44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Bath3Blank44_5 = GetRandomString("", 2);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3Blank44_5, "1", "1"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.Lot35   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Lot35 = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailLot35, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.Lot44_5   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Lot44_5 = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailLot44_5, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheetDetail.Weather   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.Weather = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWeather, "250"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheetDetail.RunComment   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.RunComment = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailRunComment, "250"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheetDetail.RunWeatherComment   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.RunWeatherComment = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailRunWeatherComment, "250"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.SampleBottleLotNumber   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SampleBottleLotNumber = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSampleBottleLotNumber, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.SalinitiesReadBy   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SalinitiesReadBy = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSalinitiesReadBy, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.SalinitiesReadDate   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.ResultsReadBy   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.ResultsReadBy = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailResultsReadBy, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.ResultsReadDate   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(20))]
                    // labSheetDetail.ResultsRecordedBy   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.ResultsRecordedBy = GetRandomString("", 21);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailResultsRecordedBy, "20"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.ResultsRecordedDate   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // labSheetDetail.DailyDuplicateRLog   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DailyDuplicateRLog]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.DailyDuplicateRLog = -1.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicateRLog, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.DailyDuplicateRLog = 101.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicateRLog, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // labSheetDetail.DailyDuplicatePrecisionCriteria   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DailyDuplicatePrecisionCriteria]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.DailyDuplicatePrecisionCriteria = -1.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.DailyDuplicatePrecisionCriteria = 101.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // labSheetDetail.DailyDuplicateAcceptable   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // labSheetDetail.IntertechDuplicateRLog   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [IntertechDuplicateRLog]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IntertechDuplicateRLog = -1.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicateRLog, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IntertechDuplicateRLog = 101.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicateRLog, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // labSheetDetail.IntertechDuplicatePrecisionCriteria   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IntertechDuplicatePrecisionCriteria = -1.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());
                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.IntertechDuplicatePrecisionCriteria = 101.0D;
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "100"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // labSheetDetail.IntertechDuplicateAcceptable   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // labSheetDetail.IntertechReadAcceptable   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheetDetail.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // labSheetDetail.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LastUpdateContactTVItemID = 0;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetDetailLastUpdateContactTVItemID, labSheetDetail.LastUpdateContactTVItemID.ToString()), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LastUpdateContactTVItemID = 1;
                    labSheetDetailService.Add(labSheetDetail);
                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetDetailLastUpdateContactTVItemID, "Contact"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "SubsectorTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // labSheetDetail.SubsectorTVText   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.SubsectorTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSubsectorTVText, "200"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // labSheetDetail.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    labSheetDetail = null;
                    labSheetDetail = GetFilledRandomLabSheetDetail("");
                    labSheetDetail.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, labSheetDetailService.Add(labSheetDetail));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailLastUpdateContactTVText, "200"), labSheetDetail.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetDetailService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheetDetail.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheetDetail.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void LabSheetDetail_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetDetailService labSheetDetailService = new LabSheetDetailService(LanguageRequest, dbTestDB, ContactID);
                    LabSheetDetail labSheetDetail = (from c in labSheetDetailService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(labSheetDetail);

                    LabSheetDetail labSheetDetailRet = labSheetDetailService.GetLabSheetDetailWithLabSheetDetailID(labSheetDetail.LabSheetDetailID);
                    Assert.IsNotNull(labSheetDetailRet.LabSheetDetailID);
                    Assert.IsNotNull(labSheetDetailRet.LabSheetID);
                    Assert.IsNotNull(labSheetDetailRet.SamplingPlanID);
                    Assert.IsNotNull(labSheetDetailRet.SubsectorTVItemID);
                    Assert.IsNotNull(labSheetDetailRet.Version);
                    Assert.IsNotNull(labSheetDetailRet.RunDate);
                    Assert.IsNotNull(labSheetDetailRet.Tides);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Tides));
                    if (labSheetDetailRet.SampleCrewInitials != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.SampleCrewInitials);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.SampleCrewInitials));
                    }
                    if (labSheetDetailRet.WaterBathCount != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.WaterBathCount);
                    }
                    if (labSheetDetailRet.IncubationBath1StartTime != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IncubationBath1StartTime);
                    }
                    if (labSheetDetailRet.IncubationBath2StartTime != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IncubationBath2StartTime);
                    }
                    if (labSheetDetailRet.IncubationBath3StartTime != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IncubationBath3StartTime);
                    }
                    if (labSheetDetailRet.IncubationBath1EndTime != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IncubationBath1EndTime);
                    }
                    if (labSheetDetailRet.IncubationBath2EndTime != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IncubationBath2EndTime);
                    }
                    if (labSheetDetailRet.IncubationBath3EndTime != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IncubationBath3EndTime);
                    }
                    if (labSheetDetailRet.IncubationBath1TimeCalculated_minutes != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IncubationBath1TimeCalculated_minutes);
                    }
                    if (labSheetDetailRet.IncubationBath2TimeCalculated_minutes != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IncubationBath2TimeCalculated_minutes);
                    }
                    if (labSheetDetailRet.IncubationBath3TimeCalculated_minutes != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IncubationBath3TimeCalculated_minutes);
                    }
                    if (labSheetDetailRet.WaterBath1 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.WaterBath1);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.WaterBath1));
                    }
                    if (labSheetDetailRet.WaterBath2 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.WaterBath2);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.WaterBath2));
                    }
                    if (labSheetDetailRet.WaterBath3 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.WaterBath3);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.WaterBath3));
                    }
                    if (labSheetDetailRet.TCField1 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.TCField1);
                    }
                    if (labSheetDetailRet.TCLab1 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.TCLab1);
                    }
                    if (labSheetDetailRet.TCField2 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.TCField2);
                    }
                    if (labSheetDetailRet.TCLab2 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.TCLab2);
                    }
                    if (labSheetDetailRet.TCFirst != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.TCFirst);
                    }
                    if (labSheetDetailRet.TCAverage != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.TCAverage);
                    }
                    if (labSheetDetailRet.ControlLot != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.ControlLot);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.ControlLot));
                    }
                    if (labSheetDetailRet.Positive35 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Positive35);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Positive35));
                    }
                    if (labSheetDetailRet.NonTarget35 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.NonTarget35);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.NonTarget35));
                    }
                    if (labSheetDetailRet.Negative35 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Negative35);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Negative35));
                    }
                    if (labSheetDetailRet.Bath1Positive44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath1Positive44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath1Positive44_5));
                    }
                    if (labSheetDetailRet.Bath2Positive44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath2Positive44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath2Positive44_5));
                    }
                    if (labSheetDetailRet.Bath3Positive44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath3Positive44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath3Positive44_5));
                    }
                    if (labSheetDetailRet.Bath1NonTarget44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath1NonTarget44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath1NonTarget44_5));
                    }
                    if (labSheetDetailRet.Bath2NonTarget44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath2NonTarget44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath2NonTarget44_5));
                    }
                    if (labSheetDetailRet.Bath3NonTarget44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath3NonTarget44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath3NonTarget44_5));
                    }
                    if (labSheetDetailRet.Bath1Negative44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath1Negative44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath1Negative44_5));
                    }
                    if (labSheetDetailRet.Bath2Negative44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath2Negative44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath2Negative44_5));
                    }
                    if (labSheetDetailRet.Bath3Negative44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath3Negative44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath3Negative44_5));
                    }
                    if (labSheetDetailRet.Blank35 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Blank35);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Blank35));
                    }
                    if (labSheetDetailRet.Bath1Blank44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath1Blank44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath1Blank44_5));
                    }
                    if (labSheetDetailRet.Bath2Blank44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath2Blank44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath2Blank44_5));
                    }
                    if (labSheetDetailRet.Bath3Blank44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Bath3Blank44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Bath3Blank44_5));
                    }
                    if (labSheetDetailRet.Lot35 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Lot35);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Lot35));
                    }
                    if (labSheetDetailRet.Lot44_5 != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Lot44_5);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Lot44_5));
                    }
                    if (labSheetDetailRet.Weather != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.Weather);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.Weather));
                    }
                    if (labSheetDetailRet.RunComment != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.RunComment);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.RunComment));
                    }
                    if (labSheetDetailRet.RunWeatherComment != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.RunWeatherComment);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.RunWeatherComment));
                    }
                    if (labSheetDetailRet.SampleBottleLotNumber != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.SampleBottleLotNumber);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.SampleBottleLotNumber));
                    }
                    if (labSheetDetailRet.SalinitiesReadBy != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.SalinitiesReadBy);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.SalinitiesReadBy));
                    }
                    if (labSheetDetailRet.SalinitiesReadDate != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.SalinitiesReadDate);
                    }
                    if (labSheetDetailRet.ResultsReadBy != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.ResultsReadBy);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.ResultsReadBy));
                    }
                    if (labSheetDetailRet.ResultsReadDate != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.ResultsReadDate);
                    }
                    if (labSheetDetailRet.ResultsRecordedBy != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.ResultsRecordedBy);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.ResultsRecordedBy));
                    }
                    if (labSheetDetailRet.ResultsRecordedDate != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.ResultsRecordedDate);
                    }
                    if (labSheetDetailRet.DailyDuplicateRLog != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.DailyDuplicateRLog);
                    }
                    if (labSheetDetailRet.DailyDuplicatePrecisionCriteria != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.DailyDuplicatePrecisionCriteria);
                    }
                    if (labSheetDetailRet.DailyDuplicateAcceptable != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.DailyDuplicateAcceptable);
                    }
                    if (labSheetDetailRet.IntertechDuplicateRLog != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IntertechDuplicateRLog);
                    }
                    if (labSheetDetailRet.IntertechDuplicatePrecisionCriteria != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IntertechDuplicatePrecisionCriteria);
                    }
                    if (labSheetDetailRet.IntertechDuplicateAcceptable != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IntertechDuplicateAcceptable);
                    }
                    if (labSheetDetailRet.IntertechReadAcceptable != null)
                    {
                       Assert.IsNotNull(labSheetDetailRet.IntertechReadAcceptable);
                    }
                    Assert.IsNotNull(labSheetDetailRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(labSheetDetailRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(labSheetDetailRet.SubsectorTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.SubsectorTVText));
                    Assert.IsNotNull(labSheetDetailRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetDetailRet.LastUpdateContactTVText));
                    Assert.IsNotNull(labSheetDetailRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
