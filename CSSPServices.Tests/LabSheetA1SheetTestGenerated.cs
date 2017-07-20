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
    public partial class LabSheetA1SheetTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int LabSheetA1SheetID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetA1SheetTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheetA1Sheet GetFilledRandomLabSheetA1Sheet(string OmitPropName)
        {
            LabSheetA1SheetID += 1;

            LabSheetA1Sheet labSheetA1Sheet = new LabSheetA1Sheet();

            if (OmitPropName != "Error") labSheetA1Sheet.Error = GetRandomString("", 20);
            if (OmitPropName != "Version") labSheetA1Sheet.Version = GetRandomInt(1, 100);
            if (OmitPropName != "SamplingPlanType") labSheetA1Sheet.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "SampleType") labSheetA1Sheet.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "LabSheetType") labSheetA1Sheet.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "SubsectorName") labSheetA1Sheet.SubsectorName = GetRandomString("", 20);
            if (OmitPropName != "SubsectorLocation") labSheetA1Sheet.SubsectorLocation = GetRandomString("", 20);
            if (OmitPropName != "SubsectorTVItemID") labSheetA1Sheet.SubsectorTVItemID = GetRandomInt(1, 1000);
            if (OmitPropName != "RunYear") labSheetA1Sheet.RunYear = GetRandomString("", 20);
            if (OmitPropName != "RunMonth") labSheetA1Sheet.RunMonth = GetRandomString("", 20);
            if (OmitPropName != "RunDay") labSheetA1Sheet.RunDay = GetRandomString("", 20);
            if (OmitPropName != "RunNumber") labSheetA1Sheet.RunNumber = GetRandomInt(1, 1000);
            if (OmitPropName != "Tides") labSheetA1Sheet.Tides = GetRandomString("", 20);
            if (OmitPropName != "SampleCrewInitials") labSheetA1Sheet.SampleCrewInitials = GetRandomString("", 20);
            if (OmitPropName != "IncubationStartSameDay") labSheetA1Sheet.IncubationStartSameDay = GetRandomString("", 20);
            if (OmitPropName != "WaterBathCount") labSheetA1Sheet.WaterBathCount = GetRandomInt(1, 1000);
            if (OmitPropName != "IncubationBath1StartTime") labSheetA1Sheet.IncubationBath1StartTime = GetRandomString("", 20);
            if (OmitPropName != "IncubationBath2StartTime") labSheetA1Sheet.IncubationBath2StartTime = GetRandomString("", 20);
            if (OmitPropName != "IncubationBath3StartTime") labSheetA1Sheet.IncubationBath3StartTime = GetRandomString("", 20);
            if (OmitPropName != "IncubationBath1EndTime") labSheetA1Sheet.IncubationBath1EndTime = GetRandomString("", 20);
            if (OmitPropName != "IncubationBath2EndTime") labSheetA1Sheet.IncubationBath2EndTime = GetRandomString("", 20);
            if (OmitPropName != "IncubationBath3EndTime") labSheetA1Sheet.IncubationBath3EndTime = GetRandomString("", 20);
            if (OmitPropName != "IncubationBath1TimeCalculated") labSheetA1Sheet.IncubationBath1TimeCalculated = GetRandomString("", 20);
            if (OmitPropName != "IncubationBath2TimeCalculated") labSheetA1Sheet.IncubationBath2TimeCalculated = GetRandomString("", 20);
            if (OmitPropName != "IncubationBath3TimeCalculated") labSheetA1Sheet.IncubationBath3TimeCalculated = GetRandomString("", 20);
            if (OmitPropName != "WaterBath1") labSheetA1Sheet.WaterBath1 = GetRandomString("", 20);
            if (OmitPropName != "WaterBath2") labSheetA1Sheet.WaterBath2 = GetRandomString("", 20);
            if (OmitPropName != "WaterBath3") labSheetA1Sheet.WaterBath3 = GetRandomString("", 20);
            if (OmitPropName != "TCField1") labSheetA1Sheet.TCField1 = GetRandomString("", 20);
            if (OmitPropName != "TCLab1") labSheetA1Sheet.TCLab1 = GetRandomString("", 20);
            if (OmitPropName != "TCHas2Coolers") labSheetA1Sheet.TCHas2Coolers = GetRandomString("", 20);
            if (OmitPropName != "TCField2") labSheetA1Sheet.TCField2 = GetRandomString("", 20);
            if (OmitPropName != "TCLab2") labSheetA1Sheet.TCLab2 = GetRandomString("", 20);
            if (OmitPropName != "TCFirst") labSheetA1Sheet.TCFirst = GetRandomString("", 20);
            if (OmitPropName != "TCAverage") labSheetA1Sheet.TCAverage = GetRandomString("", 20);
            if (OmitPropName != "ControlLot") labSheetA1Sheet.ControlLot = GetRandomString("", 20);
            if (OmitPropName != "Positive35") labSheetA1Sheet.Positive35 = GetRandomString("", 20);
            if (OmitPropName != "NonTarget35") labSheetA1Sheet.NonTarget35 = GetRandomString("", 20);
            if (OmitPropName != "Negative35") labSheetA1Sheet.Negative35 = GetRandomString("", 20);
            if (OmitPropName != "Bath1Positive44_5") labSheetA1Sheet.Bath1Positive44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath2Positive44_5") labSheetA1Sheet.Bath2Positive44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath3Positive44_5") labSheetA1Sheet.Bath3Positive44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath1NonTarget44_5") labSheetA1Sheet.Bath1NonTarget44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath2NonTarget44_5") labSheetA1Sheet.Bath2NonTarget44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath3NonTarget44_5") labSheetA1Sheet.Bath3NonTarget44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath1Negative44_5") labSheetA1Sheet.Bath1Negative44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath2Negative44_5") labSheetA1Sheet.Bath2Negative44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath3Negative44_5") labSheetA1Sheet.Bath3Negative44_5 = GetRandomString("", 20);
            if (OmitPropName != "Blank35") labSheetA1Sheet.Blank35 = GetRandomString("", 20);
            if (OmitPropName != "Bath1Blank44_5") labSheetA1Sheet.Bath1Blank44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath2Blank44_5") labSheetA1Sheet.Bath2Blank44_5 = GetRandomString("", 20);
            if (OmitPropName != "Bath3Blank44_5") labSheetA1Sheet.Bath3Blank44_5 = GetRandomString("", 20);
            if (OmitPropName != "Lot35") labSheetA1Sheet.Lot35 = GetRandomString("", 20);
            if (OmitPropName != "Lot44_5") labSheetA1Sheet.Lot44_5 = GetRandomString("", 20);
            if (OmitPropName != "RunComment") labSheetA1Sheet.RunComment = GetRandomString("", 20);
            if (OmitPropName != "RunWeatherComment") labSheetA1Sheet.RunWeatherComment = GetRandomString("", 20);
            if (OmitPropName != "SampleBottleLotNumber") labSheetA1Sheet.SampleBottleLotNumber = GetRandomString("", 20);
            if (OmitPropName != "SalinitiesReadBy") labSheetA1Sheet.SalinitiesReadBy = GetRandomString("", 20);
            if (OmitPropName != "SalinitiesReadYear") labSheetA1Sheet.SalinitiesReadYear = GetRandomString("", 20);
            if (OmitPropName != "SalinitiesReadMonth") labSheetA1Sheet.SalinitiesReadMonth = GetRandomString("", 20);
            if (OmitPropName != "SalinitiesReadDay") labSheetA1Sheet.SalinitiesReadDay = GetRandomString("", 20);
            if (OmitPropName != "ResultsReadBy") labSheetA1Sheet.ResultsReadBy = GetRandomString("", 20);
            if (OmitPropName != "ResultsReadYear") labSheetA1Sheet.ResultsReadYear = GetRandomString("", 20);
            if (OmitPropName != "ResultsReadMonth") labSheetA1Sheet.ResultsReadMonth = GetRandomString("", 20);
            if (OmitPropName != "ResultsReadDay") labSheetA1Sheet.ResultsReadDay = GetRandomString("", 20);
            if (OmitPropName != "ResultsRecordedBy") labSheetA1Sheet.ResultsRecordedBy = GetRandomString("", 20);
            if (OmitPropName != "ResultsRecordedYear") labSheetA1Sheet.ResultsRecordedYear = GetRandomString("", 20);
            if (OmitPropName != "ResultsRecordedMonth") labSheetA1Sheet.ResultsRecordedMonth = GetRandomString("", 20);
            if (OmitPropName != "ResultsRecordedDay") labSheetA1Sheet.ResultsRecordedDay = GetRandomString("", 20);
            if (OmitPropName != "DailyDuplicateRLog") labSheetA1Sheet.DailyDuplicateRLog = GetRandomString("", 20);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") labSheetA1Sheet.DailyDuplicatePrecisionCriteria = GetRandomString("", 20);
            if (OmitPropName != "DailyDuplicateAcceptableOrUnacceptable") labSheetA1Sheet.DailyDuplicateAcceptableOrUnacceptable = GetRandomString("", 20);
            if (OmitPropName != "IntertechDuplicateRLog") labSheetA1Sheet.IntertechDuplicateRLog = GetRandomString("", 20);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") labSheetA1Sheet.IntertechDuplicatePrecisionCriteria = GetRandomString("", 20);
            if (OmitPropName != "IntertechDuplicateAcceptableOrUnacceptable") labSheetA1Sheet.IntertechDuplicateAcceptableOrUnacceptable = GetRandomString("", 20);
            if (OmitPropName != "IntertechReadAcceptableOrUnacceptable") labSheetA1Sheet.IntertechReadAcceptableOrUnacceptable = GetRandomString("", 20);
            if (OmitPropName != "ApprovalYear") labSheetA1Sheet.ApprovalYear = GetRandomString("", 20);
            if (OmitPropName != "ApprovalMonth") labSheetA1Sheet.ApprovalMonth = GetRandomString("", 20);
            if (OmitPropName != "ApprovalDay") labSheetA1Sheet.ApprovalDay = GetRandomString("", 20);
            if (OmitPropName != "ApprovedBySupervisorInitials") labSheetA1Sheet.ApprovedBySupervisorInitials = GetRandomString("", 20);
            if (OmitPropName != "IncludeLaboratoryQAQC") labSheetA1Sheet.IncludeLaboratoryQAQC = true;
            if (OmitPropName != "Log") labSheetA1Sheet.Log = GetRandomString("", 20);

            return labSheetA1Sheet;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheetA1Sheet_Testing()
        {
            SetupTestHelper(culture);
            LabSheetA1SheetService labSheetA1SheetService = new LabSheetA1SheetService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            LabSheetA1Sheet labSheetA1Sheet = GetFilledRandomLabSheetA1Sheet("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


        }
        #endregion Tests Generated
    }
}
