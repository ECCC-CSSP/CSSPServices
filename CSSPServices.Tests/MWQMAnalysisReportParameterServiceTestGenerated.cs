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
    public partial class MWQMAnalysisReportParameterServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterServiceTest() : base()
        {
            //mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMAnalysisReportParameter GetFilledRandomMWQMAnalysisReportParameter(string OmitPropName)
        {
            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = new MWQMAnalysisReportParameter();

            // Need to implement (no items found, would need to add at least one in the TestDB) [MWQMAnalysisReportParameter SubsectorTVItemID TVItem TVItemID]
            if (OmitPropName != "AnalysisName") mwqmAnalysisReportParameter.AnalysisName = GetRandomString("", 10);
            if (OmitPropName != "AnalysisReportYear") mwqmAnalysisReportParameter.AnalysisReportYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "StartDate") mwqmAnalysisReportParameter.StartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate") mwqmAnalysisReportParameter.EndDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "AnalysisCalculationType") mwqmAnalysisReportParameter.AnalysisCalculationType = (AnalysisCalculationTypeEnum)GetRandomEnumType(typeof(AnalysisCalculationTypeEnum));
            if (OmitPropName != "NumberOfRuns") mwqmAnalysisReportParameter.NumberOfRuns = GetRandomInt(1, 1000);
            if (OmitPropName != "FullYear") mwqmAnalysisReportParameter.FullYear = true;
            if (OmitPropName != "SalinityHighlightDeviationFromAverage") mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage = GetRandomDouble(1.0D, 20.0D);
            if (OmitPropName != "ShortRangeNumberOfDays") mwqmAnalysisReportParameter.ShortRangeNumberOfDays = GetRandomInt(0, 5);
            if (OmitPropName != "MidRangeNumberOfDays") mwqmAnalysisReportParameter.MidRangeNumberOfDays = GetRandomInt(2, 7);
            if (OmitPropName != "DryLimit24h") mwqmAnalysisReportParameter.DryLimit24h = GetRandomInt(1, 100);
            if (OmitPropName != "DryLimit48h") mwqmAnalysisReportParameter.DryLimit48h = GetRandomInt(1, 100);
            if (OmitPropName != "DryLimit72h") mwqmAnalysisReportParameter.DryLimit72h = GetRandomInt(1, 100);
            if (OmitPropName != "DryLimit96h") mwqmAnalysisReportParameter.DryLimit96h = GetRandomInt(1, 100);
            if (OmitPropName != "WetLimit24h") mwqmAnalysisReportParameter.WetLimit24h = GetRandomInt(1, 100);
            if (OmitPropName != "WetLimit48h") mwqmAnalysisReportParameter.WetLimit48h = GetRandomInt(1, 100);
            if (OmitPropName != "WetLimit72h") mwqmAnalysisReportParameter.WetLimit72h = GetRandomInt(1, 100);
            if (OmitPropName != "WetLimit96h") mwqmAnalysisReportParameter.WetLimit96h = GetRandomInt(1, 100);
            if (OmitPropName != "RunsToOmit") mwqmAnalysisReportParameter.RunsToOmit = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmAnalysisReportParameter.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmAnalysisReportParameter.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") mwqmAnalysisReportParameter.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") mwqmAnalysisReportParameter.HasErrors = true;

            return mwqmAnalysisReportParameter;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMAnalysisReportParameter_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                count = mwqmAnalysisReportParameterService.GetRead().Count();

                Assert.AreEqual(mwqmAnalysisReportParameterService.GetRead().Count(), mwqmAnalysisReportParameterService.GetEdit().Count());

                mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                if (mwqmAnalysisReportParameter.HasErrors)
                {
                    Assert.AreEqual("", mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, mwqmAnalysisReportParameterService.GetRead().Where(c => c == mwqmAnalysisReportParameter).Any());
                mwqmAnalysisReportParameterService.Update(mwqmAnalysisReportParameter);
                if (mwqmAnalysisReportParameter.HasErrors)
                {
                    Assert.AreEqual("", mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, mwqmAnalysisReportParameterService.GetRead().Count());
                mwqmAnalysisReportParameterService.Delete(mwqmAnalysisReportParameter);
                if (mwqmAnalysisReportParameter.HasErrors)
                {
                    Assert.AreEqual("", mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID = 0;
                    mwqmAnalysisReportParameterService.Update(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMAnalysisReportParameterMWQMAnalysisReportParameterID), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID = 10000000;
                    mwqmAnalysisReportParameterService.Update(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMAnalysisReportParameter, CSSPModelsRes.MWQMAnalysisReportParameterMWQMAnalysisReportParameterID, mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID.ToString()), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Error)]
                    // mwqmAnalysisReportParameter.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.SubsectorTVItemID = 0;
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMAnalysisReportParameterSubsectorTVItemID, mwqmAnalysisReportParameter.SubsectorTVItemID.ToString()), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.SubsectorTVItemID = 1;
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMAnalysisReportParameterSubsectorTVItemID, "Error"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250, MinimumLength = 5)]
                    // mwqmAnalysisReportParameter.AnalysisName   (String)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("AnalysisName");
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(1, mwqmAnalysisReportParameter.ValidationResults.Count());
                    Assert.IsTrue(mwqmAnalysisReportParameter.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMAnalysisReportParameterAnalysisName)).Any());
                    Assert.AreEqual(null, mwqmAnalysisReportParameter.AnalysisName);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.AnalysisName = GetRandomString("", 4);
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterAnalysisName, "5", "250"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.AnalysisName = GetRandomString("", 251);
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterAnalysisName, "5", "250"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1980, 2050)]
                    // mwqmAnalysisReportParameter.AnalysisReportYear   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.AnalysisReportYear = 1979;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterAnalysisReportYear, "1980", "2050"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.AnalysisReportYear = 2051;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterAnalysisReportYear, "1980", "2050"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmAnalysisReportParameter.StartDate   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDate)]
                    // mwqmAnalysisReportParameter.EndDate   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmAnalysisReportParameter.AnalysisCalculationType   (AnalysisCalculationTypeEnum)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.AnalysisCalculationType = (AnalysisCalculationTypeEnum)1000000;
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMAnalysisReportParameterAnalysisCalculationType), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 1000)]
                    // mwqmAnalysisReportParameter.NumberOfRuns   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.NumberOfRuns = 0;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterNumberOfRuns, "1", "1000"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.NumberOfRuns = 1001;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterNumberOfRuns, "1", "1000"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmAnalysisReportParameter.FullYear   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 20)]
                    // mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SalinityHighlightDeviationFromAverage]

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage = 0.0D;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage, "1", "20"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage = 21.0D;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage, "1", "20"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 5)]
                    // mwqmAnalysisReportParameter.ShortRangeNumberOfDays   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.ShortRangeNumberOfDays = -1;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterShortRangeNumberOfDays, "0", "5"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.ShortRangeNumberOfDays = 6;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterShortRangeNumberOfDays, "0", "5"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(2, 7)]
                    // mwqmAnalysisReportParameter.MidRangeNumberOfDays   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.MidRangeNumberOfDays = 1;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterMidRangeNumberOfDays, "2", "7"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.MidRangeNumberOfDays = 8;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterMidRangeNumberOfDays, "2", "7"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // mwqmAnalysisReportParameter.DryLimit24h   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.DryLimit24h = 0;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterDryLimit24h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.DryLimit24h = 101;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterDryLimit24h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // mwqmAnalysisReportParameter.DryLimit48h   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.DryLimit48h = 0;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterDryLimit48h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.DryLimit48h = 101;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterDryLimit48h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // mwqmAnalysisReportParameter.DryLimit72h   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.DryLimit72h = 0;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterDryLimit72h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.DryLimit72h = 101;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterDryLimit72h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // mwqmAnalysisReportParameter.DryLimit96h   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.DryLimit96h = 0;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterDryLimit96h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.DryLimit96h = 101;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterDryLimit96h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // mwqmAnalysisReportParameter.WetLimit24h   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.WetLimit24h = 0;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterWetLimit24h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.WetLimit24h = 101;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterWetLimit24h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // mwqmAnalysisReportParameter.WetLimit48h   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.WetLimit48h = 0;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterWetLimit48h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.WetLimit48h = 101;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterWetLimit48h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // mwqmAnalysisReportParameter.WetLimit72h   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.WetLimit72h = 0;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterWetLimit72h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.WetLimit72h = 101;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterWetLimit72h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // mwqmAnalysisReportParameter.WetLimit96h   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.WetLimit96h = 0;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterWetLimit96h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.WetLimit96h = 101;
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMAnalysisReportParameterWetLimit96h, "1", "100"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // mwqmAnalysisReportParameter.RunsToOmit   (String)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("RunsToOmit");
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(1, mwqmAnalysisReportParameter.ValidationResults.Count());
                    Assert.IsTrue(mwqmAnalysisReportParameter.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMAnalysisReportParameterRunsToOmit)).Any());
                    Assert.AreEqual(null, mwqmAnalysisReportParameter.RunsToOmit);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.RunsToOmit = GetRandomString("", 251);
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMAnalysisReportParameterRunsToOmit, "250"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmAnalysisReportParameter.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmAnalysisReportParameter.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.LastUpdateContactTVItemID = 0;
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMAnalysisReportParameterLastUpdateContactTVItemID, mwqmAnalysisReportParameter.LastUpdateContactTVItemID.ToString()), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.LastUpdateContactTVItemID = 1;
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMAnalysisReportParameterLastUpdateContactTVItemID, "Contact"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // mwqmAnalysisReportParameter.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMAnalysisReportParameterLastUpdateContactTVText, "200"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmAnalysisReportParameter.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmAnalysisReportParameter.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MWQMAnalysisReportParameter_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(LanguageRequest, dbTestDB, ContactID);
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in mwqmAnalysisReportParameterService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmAnalysisReportParameter);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.MWQMAnalysisReportParameterID);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.SubsectorTVItemID);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.AnalysisName);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterRet.AnalysisName));
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.AnalysisReportYear);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.StartDate);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.EndDate);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.AnalysisCalculationType);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.NumberOfRuns);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.FullYear);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.SalinityHighlightDeviationFromAverage);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.ShortRangeNumberOfDays);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.MidRangeNumberOfDays);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.DryLimit24h);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.DryLimit48h);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.DryLimit72h);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.DryLimit96h);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.WetLimit24h);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.WetLimit48h);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.WetLimit72h);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.WetLimit96h);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.RunsToOmit);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterRet.RunsToOmit));
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterRet.LastUpdateContactTVText));
                    Assert.IsNotNull(mwqmAnalysisReportParameterRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
