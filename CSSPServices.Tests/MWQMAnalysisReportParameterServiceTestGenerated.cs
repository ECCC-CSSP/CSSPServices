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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMAnalysisReportParameter_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMAnalysisReportParameterSubsectorTVItemID, "Subsector"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    // Is Nullable
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

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.StartDate = new DateTime();
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMAnalysisReportParameterStartDate), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.StartDate = new DateTime(1979, 1, 1);
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMAnalysisReportParameterStartDate, "1980"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDate)]
                    // mwqmAnalysisReportParameter.EndDate   (DateTime)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.EndDate = new DateTime();
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMAnalysisReportParameterEndDate), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.EndDate = new DateTime(1979, 1, 1);
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMAnalysisReportParameterEndDate, "1980"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    // Is Nullable
                    // [StringLength(20))]
                    // mwqmAnalysisReportParameter.ShowDataTypes   (String)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.ShowDataTypes = GetRandomString("", 21);
                    Assert.AreEqual(false, mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMAnalysisReportParameterShowDataTypes, "20"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmAnalysisReportParameterService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
                    // mwqmAnalysisReportParameter.ExcelTVFileTVItemID   (Int32)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.ExcelTVFileTVItemID = 0;
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMAnalysisReportParameterExcelTVFileTVItemID, mwqmAnalysisReportParameter.ExcelTVFileTVItemID.ToString()), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.ExcelTVFileTVItemID = 1;
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMAnalysisReportParameterExcelTVFileTVItemID, "File"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmAnalysisReportParameter.Command   (AnalysisReportExportCommandEnum)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.Command = (AnalysisReportExportCommandEnum)1000000;
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMAnalysisReportParameterCommand), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmAnalysisReportParameter.MWQMAnalysisReportParameterWeb   (MWQMAnalysisReportParameterWeb)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.MWQMAnalysisReportParameterWeb = null;
                    Assert.IsNull(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterWeb);

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.MWQMAnalysisReportParameterWeb = new MWQMAnalysisReportParameterWeb();
                    Assert.IsNotNull(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmAnalysisReportParameter.MWQMAnalysisReportParameterReport   (MWQMAnalysisReportParameterReport)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.MWQMAnalysisReportParameterReport = null;
                    Assert.IsNull(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterReport);

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.MWQMAnalysisReportParameterReport = new MWQMAnalysisReportParameterReport();
                    Assert.IsNotNull(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmAnalysisReportParameter.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.LastUpdateDate_UTC = new DateTime();
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMAnalysisReportParameterLastUpdateDate_UTC), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmAnalysisReportParameter = null;
                    mwqmAnalysisReportParameter = GetFilledRandomMWQMAnalysisReportParameter("");
                    mwqmAnalysisReportParameter.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmAnalysisReportParameterService.Add(mwqmAnalysisReportParameter);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMAnalysisReportParameterLastUpdateDate_UTC, "1980"), mwqmAnalysisReportParameter.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmAnalysisReportParameter.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmAnalysisReportParameter.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID)
        [TestMethod]
        public void GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID__mwqmAnalysisReportParameter_MWQMAnalysisReportParameterID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in mwqmAnalysisReportParameterService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmAnalysisReportParameter);

                    MWQMAnalysisReportParameter mwqmAnalysisReportParameterRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmAnalysisReportParameterService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mwqmAnalysisReportParameterRet = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID);
                            Assert.IsNull(mwqmAnalysisReportParameterRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmAnalysisReportParameterRet = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmAnalysisReportParameterRet = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmAnalysisReportParameterRet = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMAnalysisReportParameterFields(new List<MWQMAnalysisReportParameter>() { mwqmAnalysisReportParameterRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID)

        #region Tests Generated for GetMWQMAnalysisReportParameterList()
        [TestMethod]
        public void GetMWQMAnalysisReportParameterList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in mwqmAnalysisReportParameterService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmAnalysisReportParameter);

                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmAnalysisReportParameterService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                            Assert.AreEqual(0, mwqmAnalysisReportParameterList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMAnalysisReportParameterFields(mwqmAnalysisReportParameterList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMAnalysisReportParameterList()

        #region Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take
        [TestMethod]
        public void GetMWQMAnalysisReportParameterList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterDirectQueryList = new List<MWQMAnalysisReportParameter>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmAnalysisReportParameterDirectQueryList = mwqmAnalysisReportParameterService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                            Assert.AreEqual(0, mwqmAnalysisReportParameterList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMAnalysisReportParameterFields(mwqmAnalysisReportParameterList, entityQueryDetailType);
                        Assert.AreEqual(mwqmAnalysisReportParameterDirectQueryList[0].MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID);
                        Assert.AreEqual(1, mwqmAnalysisReportParameterList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take

        #region Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take Order
        [TestMethod]
        public void GetMWQMAnalysisReportParameterList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterDirectQueryList = new List<MWQMAnalysisReportParameter>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMAnalysisReportParameterID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmAnalysisReportParameterDirectQueryList = mwqmAnalysisReportParameterService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMAnalysisReportParameterID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                            Assert.AreEqual(0, mwqmAnalysisReportParameterList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMAnalysisReportParameterFields(mwqmAnalysisReportParameterList, entityQueryDetailType);
                        Assert.AreEqual(mwqmAnalysisReportParameterDirectQueryList[0].MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID);
                        Assert.AreEqual(1, mwqmAnalysisReportParameterList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take Order

        #region Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMAnalysisReportParameterList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterDirectQueryList = new List<MWQMAnalysisReportParameter>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), culture.TwoLetterISOLanguageName, 1, 1, "MWQMAnalysisReportParameterID,SubsectorTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmAnalysisReportParameterDirectQueryList = mwqmAnalysisReportParameterService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMAnalysisReportParameterID).ThenBy(c => c.SubsectorTVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                            Assert.AreEqual(0, mwqmAnalysisReportParameterList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMAnalysisReportParameterFields(mwqmAnalysisReportParameterList, entityQueryDetailType);
                        Assert.AreEqual(mwqmAnalysisReportParameterDirectQueryList[0].MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID);
                        Assert.AreEqual(1, mwqmAnalysisReportParameterList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take 2Order

        #region Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMAnalysisReportParameterList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterDirectQueryList = new List<MWQMAnalysisReportParameter>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), culture.TwoLetterISOLanguageName, 0, 1, "MWQMAnalysisReportParameterID", "MWQMAnalysisReportParameterID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmAnalysisReportParameterDirectQueryList = mwqmAnalysisReportParameterService.GetRead().Where(c => c.MWQMAnalysisReportParameterID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMAnalysisReportParameterID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                            Assert.AreEqual(0, mwqmAnalysisReportParameterList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMAnalysisReportParameterFields(mwqmAnalysisReportParameterList, entityQueryDetailType);
                        Assert.AreEqual(mwqmAnalysisReportParameterDirectQueryList[0].MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID);
                        Assert.AreEqual(1, mwqmAnalysisReportParameterList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take Order Where

        #region Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMAnalysisReportParameterList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterDirectQueryList = new List<MWQMAnalysisReportParameter>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), culture.TwoLetterISOLanguageName, 0, 1, "MWQMAnalysisReportParameterID", "MWQMAnalysisReportParameterID,GT,2|MWQMAnalysisReportParameterID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmAnalysisReportParameterDirectQueryList = mwqmAnalysisReportParameterService.GetRead().Where(c => c.MWQMAnalysisReportParameterID > 2 && c.MWQMAnalysisReportParameterID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMAnalysisReportParameterID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                            Assert.AreEqual(0, mwqmAnalysisReportParameterList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMAnalysisReportParameterFields(mwqmAnalysisReportParameterList, entityQueryDetailType);
                        Assert.AreEqual(mwqmAnalysisReportParameterDirectQueryList[0].MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID);
                        Assert.AreEqual(1, mwqmAnalysisReportParameterList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMAnalysisReportParameterList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMAnalysisReportParameterList() 2Where
        [TestMethod]
        public void GetMWQMAnalysisReportParameterList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
                    List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterDirectQueryList = new List<MWQMAnalysisReportParameter>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMAnalysisReportParameterService mwqmAnalysisReportParameterService = new MWQMAnalysisReportParameterService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmAnalysisReportParameterService.Query = mwqmAnalysisReportParameterService.FillQuery(typeof(MWQMAnalysisReportParameter), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMAnalysisReportParameterID,GT,2|MWQMAnalysisReportParameterID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmAnalysisReportParameterDirectQueryList = mwqmAnalysisReportParameterService.GetRead().Where(c => c.MWQMAnalysisReportParameterID > 2 && c.MWQMAnalysisReportParameterID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                            Assert.AreEqual(0, mwqmAnalysisReportParameterList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmAnalysisReportParameterList = mwqmAnalysisReportParameterService.GetMWQMAnalysisReportParameterList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMAnalysisReportParameterFields(mwqmAnalysisReportParameterList, entityQueryDetailType);
                        Assert.AreEqual(mwqmAnalysisReportParameterDirectQueryList[0].MWQMAnalysisReportParameterID, mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID);
                        Assert.AreEqual(2, mwqmAnalysisReportParameterList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMAnalysisReportParameterList() 2Where

        #region Functions private
        private void CheckMWQMAnalysisReportParameterFields(List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // MWQMAnalysisReportParameter fields
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].SubsectorTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].AnalysisName));
            if (mwqmAnalysisReportParameterList[0].AnalysisReportYear != null)
            {
                Assert.IsNotNull(mwqmAnalysisReportParameterList[0].AnalysisReportYear);
            }
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].StartDate);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].EndDate);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].AnalysisCalculationType);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].NumberOfRuns);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].FullYear);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].SalinityHighlightDeviationFromAverage);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].ShortRangeNumberOfDays);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].MidRangeNumberOfDays);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].DryLimit24h);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].DryLimit48h);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].DryLimit72h);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].DryLimit96h);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].WetLimit24h);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].WetLimit48h);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].WetLimit72h);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].WetLimit96h);
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].RunsToOmit));
            if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].ShowDataTypes))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].ShowDataTypes));
            }
            if (mwqmAnalysisReportParameterList[0].ExcelTVFileTVItemID != null)
            {
                Assert.IsNotNull(mwqmAnalysisReportParameterList[0].ExcelTVFileTVItemID);
            }
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].Command);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmAnalysisReportParameterList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // MWQMAnalysisReportParameterWeb and MWQMAnalysisReportParameterReport fields should be null here
                Assert.IsNull(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb);
                Assert.IsNull(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // MWQMAnalysisReportParameterWeb fields should not be null and MWQMAnalysisReportParameterReport fields should be null here
                if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.ExcelTVFileTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.ExcelTVFileTVText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.CommandText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.CommandText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // MWQMAnalysisReportParameterWeb and MWQMAnalysisReportParameterReport fields should NOT be null here
                if (mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.ExcelTVFileTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.ExcelTVFileTVText));
                }
                if (mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.CommandText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.CommandText));
                }
                if (mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterWeb.LastUpdateContactTVText));
                }
                if (mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterReport.MWQMAnalysisReportParameterReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterReport.MWQMAnalysisReportParameterReportTest));
                }
            }
        }
        private MWQMAnalysisReportParameter GetFilledRandomMWQMAnalysisReportParameter(string OmitPropName)
        {
            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = new MWQMAnalysisReportParameter();

            if (OmitPropName != "SubsectorTVItemID") mwqmAnalysisReportParameter.SubsectorTVItemID = 11;
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
            if (OmitPropName != "ShowDataTypes") mwqmAnalysisReportParameter.ShowDataTypes = GetRandomString("", 5);
            if (OmitPropName != "ExcelTVFileTVItemID") mwqmAnalysisReportParameter.ExcelTVFileTVItemID = 38;
            if (OmitPropName != "Command") mwqmAnalysisReportParameter.Command = (AnalysisReportExportCommandEnum)GetRandomEnumType(typeof(AnalysisReportExportCommandEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmAnalysisReportParameter.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmAnalysisReportParameter.LastUpdateContactTVItemID = 2;

            return mwqmAnalysisReportParameter;
        }
        #endregion Functions private
    }
}
