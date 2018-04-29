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
    public partial class MWQMSampleServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSampleService mwqmSampleService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleServiceTest() : base()
        {
            //mwqmSampleService = new MWQMSampleService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSample GetFilledRandomMWQMSample(string OmitPropName)
        {
            MWQMSample mwqmSample = new MWQMSample();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSample.MWQMSiteTVItemID = 19;
            if (OmitPropName != "MWQMRunTVItemID") mwqmSample.MWQMRunTVItemID = 25;
            if (OmitPropName != "SampleDateTime_Local") mwqmSample.SampleDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Depth_m") mwqmSample.Depth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "FecCol_MPN_100ml") mwqmSample.FecCol_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Salinity_PPT") mwqmSample.Salinity_PPT = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "WaterTemp_C") mwqmSample.WaterTemp_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "PH") mwqmSample.PH = GetRandomDouble(0.0D, 14.0D);
            if (OmitPropName != "SampleTypesText") mwqmSample.SampleTypesText = GetRandomString("", 5);
            if (OmitPropName != "SampleType_old") mwqmSample.SampleType_old = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "Tube_10") mwqmSample.Tube_10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_1_0") mwqmSample.Tube_1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_0_1") mwqmSample.Tube_0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "ProcessedBy") mwqmSample.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "UseForOpenData") mwqmSample.UseForOpenData = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSample.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSample.LastUpdateContactTVItemID = 2;

            return mwqmSample;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSample_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleService mwqmSampleService = new MWQMSampleService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMSample mwqmSample = GetFilledRandomMWQMSample("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmSampleService.GetRead().Count();

                    Assert.AreEqual(mwqmSampleService.GetRead().Count(), mwqmSampleService.GetEdit().Count());

                    mwqmSampleService.Add(mwqmSample);
                    if (mwqmSample.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSampleService.GetRead().Where(c => c == mwqmSample).Any());
                    mwqmSampleService.Update(mwqmSample);
                    if (mwqmSample.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSampleService.GetRead().Count());
                    mwqmSampleService.Delete(mwqmSample);
                    if (mwqmSample.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmSample.MWQMSampleID   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSampleID = 0;
                    mwqmSampleService.Update(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleMWQMSampleID), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSampleID = 10000000;
                    mwqmSampleService.Update(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSample, CSSPModelsRes.MWQMSampleMWQMSampleID, mwqmSample.MWQMSampleID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // mwqmSample.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSiteTVItemID = 0;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSampleMWQMSiteTVItemID, mwqmSample.MWQMSiteTVItemID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSiteTVItemID = 1;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSampleMWQMSiteTVItemID, "MWQMSite"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
                    // mwqmSample.MWQMRunTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMRunTVItemID = 0;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSampleMWQMRunTVItemID, mwqmSample.MWQMRunTVItemID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMRunTVItemID = 1;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSampleMWQMRunTVItemID, "MWQMRun"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSample.SampleDateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.SampleDateTime_Local = new DateTime();
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleSampleDateTime_Local), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.SampleDateTime_Local = new DateTime(1979, 1, 1);
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSampleSampleDateTime_Local, "1980"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // mwqmSample.Depth_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Depth_m]

                    //Error: Type not implemented [Depth_m]

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Depth_m = -1.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleDepth_m, "0", "1000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Depth_m = 1001.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleDepth_m, "0", "1000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // mwqmSample.FecCol_MPN_100ml   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.FecCol_MPN_100ml = -1;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.FecCol_MPN_100ml = 10000001;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 40)]
                    // mwqmSample.Salinity_PPT   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Salinity_PPT]

                    //Error: Type not implemented [Salinity_PPT]

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Salinity_PPT = -1.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleSalinity_PPT, "0", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Salinity_PPT = 41.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleSalinity_PPT, "0", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // mwqmSample.WaterTemp_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WaterTemp_C]

                    //Error: Type not implemented [WaterTemp_C]

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.WaterTemp_C = -11.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleWaterTemp_C, "-10", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.WaterTemp_C = 41.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleWaterTemp_C, "-10", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 14)]
                    // mwqmSample.PH   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PH]

                    //Error: Type not implemented [PH]

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.PH = -1.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSamplePH, "0", "14"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.PH = 15.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSamplePH, "0", "14"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // mwqmSample.SampleTypesText   (String)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("SampleTypesText");
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(1, mwqmSample.ValidationResults.Count());
                    Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleSampleTypesText)).Any());
                    Assert.AreEqual(null, mwqmSample.SampleTypesText);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.SampleTypesText = GetRandomString("", 51);
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSampleSampleTypesText, "50"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmSample.SampleType_old   (SampleTypeEnum)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.SampleType_old = (SampleTypeEnum)1000000;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleSampleType_old), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 5)]
                    // mwqmSample.Tube_10   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_10 = -1;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleTube_10, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_10 = 6;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleTube_10, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 5)]
                    // mwqmSample.Tube_1_0   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_1_0 = -1;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleTube_1_0, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_1_0 = 6;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleTube_1_0, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 5)]
                    // mwqmSample.Tube_0_1   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_0_1 = -1;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleTube_0_1, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_0_1 = 6;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleTube_0_1, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // mwqmSample.ProcessedBy   (String)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.ProcessedBy = GetRandomString("", 11);
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSampleProcessedBy, "10"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmSample.UseForOpenData   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSample.MWQMSampleWeb   (MWQMSampleWeb)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSampleWeb = null;
                    Assert.IsNull(mwqmSample.MWQMSampleWeb);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSampleWeb = new MWQMSampleWeb();
                    Assert.IsNotNull(mwqmSample.MWQMSampleWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSample.MWQMSampleReport   (MWQMSampleReport)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSampleReport = null;
                    Assert.IsNull(mwqmSample.MWQMSampleReport);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSampleReport = new MWQMSampleReport();
                    Assert.IsNotNull(mwqmSample.MWQMSampleReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSample.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.LastUpdateDate_UTC = new DateTime();
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLastUpdateDate_UTC), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSampleLastUpdateDate_UTC, "1980"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSample.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.LastUpdateContactTVItemID = 0;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSampleLastUpdateContactTVItemID, mwqmSample.LastUpdateContactTVItemID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.LastUpdateContactTVItemID = 1;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSampleLastUpdateContactTVItemID, "Contact"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSample.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSample.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MWQMSample_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    MWQMSampleService mwqmSampleService = new MWQMSampleService(new GetParam(), dbTestDB, ContactID);
                    MWQMSample mwqmSample = (from c in mwqmSampleService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSample);

                    MWQMSample mwqmSampleRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID, getParam);
                            Assert.IsNull(mwqmSampleRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MWQMSample fields
                        Assert.IsNotNull(mwqmSampleRet.MWQMSampleID);
                        Assert.IsNotNull(mwqmSampleRet.MWQMSiteTVItemID);
                        Assert.IsNotNull(mwqmSampleRet.MWQMRunTVItemID);
                        Assert.IsNotNull(mwqmSampleRet.SampleDateTime_Local);
                        if (mwqmSampleRet.Depth_m != null)
                        {
                            Assert.IsNotNull(mwqmSampleRet.Depth_m);
                        }
                        Assert.IsNotNull(mwqmSampleRet.FecCol_MPN_100ml);
                        if (mwqmSampleRet.Salinity_PPT != null)
                        {
                            Assert.IsNotNull(mwqmSampleRet.Salinity_PPT);
                        }
                        if (mwqmSampleRet.WaterTemp_C != null)
                        {
                            Assert.IsNotNull(mwqmSampleRet.WaterTemp_C);
                        }
                        if (mwqmSampleRet.PH != null)
                        {
                            Assert.IsNotNull(mwqmSampleRet.PH);
                        }
                        Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.SampleTypesText));
                        if (mwqmSampleRet.SampleType_old != null)
                        {
                            Assert.IsNotNull(mwqmSampleRet.SampleType_old);
                        }
                        if (mwqmSampleRet.Tube_10 != null)
                        {
                            Assert.IsNotNull(mwqmSampleRet.Tube_10);
                        }
                        if (mwqmSampleRet.Tube_1_0 != null)
                        {
                            Assert.IsNotNull(mwqmSampleRet.Tube_1_0);
                        }
                        if (mwqmSampleRet.Tube_0_1 != null)
                        {
                            Assert.IsNotNull(mwqmSampleRet.Tube_0_1);
                        }
                        if (mwqmSampleRet.ProcessedBy != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.ProcessedBy));
                        }
                        Assert.IsNotNull(mwqmSampleRet.UseForOpenData);
                        Assert.IsNotNull(mwqmSampleRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mwqmSampleRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MWQMSampleWeb and MWQMSampleReport fields should be null here
                            Assert.IsNull(mwqmSampleRet.MWQMSampleWeb);
                            Assert.IsNull(mwqmSampleRet.MWQMSampleReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MWQMSampleWeb fields should not be null and MWQMSampleReport fields should be null here
                            if (mwqmSampleRet.MWQMSampleWeb.MWQMSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSampleWeb.MWQMSiteTVText));
                            }
                            if (mwqmSampleRet.MWQMSampleWeb.MWQMRunTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSampleWeb.MWQMRunTVText));
                            }
                            if (mwqmSampleRet.MWQMSampleWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSampleWeb.LastUpdateContactTVText));
                            }
                            if (mwqmSampleRet.MWQMSampleWeb.SampleType_oldText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSampleWeb.SampleType_oldText));
                            }
                            Assert.IsNull(mwqmSampleRet.MWQMSampleReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MWQMSampleWeb and MWQMSampleReport fields should NOT be null here
                            if (mwqmSampleRet.MWQMSampleWeb.MWQMSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSampleWeb.MWQMSiteTVText));
                            }
                            if (mwqmSampleRet.MWQMSampleWeb.MWQMRunTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSampleWeb.MWQMRunTVText));
                            }
                            if (mwqmSampleRet.MWQMSampleWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSampleWeb.LastUpdateContactTVText));
                            }
                            if (mwqmSampleRet.MWQMSampleWeb.SampleType_oldText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSampleWeb.SampleType_oldText));
                            }
                            if (mwqmSampleRet.MWQMSampleReport.MWQMSampleReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSampleReport.MWQMSampleReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of MWQMSample
        #endregion Tests Get List of MWQMSample

    }
}
