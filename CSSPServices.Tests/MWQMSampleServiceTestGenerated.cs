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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSample_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

        #region Tests Generated for GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID)
        [TestMethod]
        public void GetMWQMSampleWithMWQMSampleID__mwqmSample_MWQMSampleID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSample mwqmSample = (from c in mwqmSampleService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSample);

                    MWQMSample mwqmSampleRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSampleService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID);
                            Assert.IsNull(mwqmSampleRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSampleFields(new List<MWQMSample>() { mwqmSampleRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID)

        #region Tests Generated for GetMWQMSampleList()
        [TestMethod]
        public void GetMWQMSampleList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSample mwqmSample = (from c in mwqmSampleService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSample);

                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmSampleService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            Assert.AreEqual(0, mwqmSampleList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSampleFields(mwqmSampleList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleList()

        #region Tests Generated for GetMWQMSampleList() Skip Take
        [TestMethod]
        public void GetMWQMSampleList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleDirectQueryList = mwqmSampleService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            Assert.AreEqual(0, mwqmSampleList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSampleFields(mwqmSampleList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        Assert.AreEqual(1, mwqmSampleList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleList() Skip Take

        #region Tests Generated for GetMWQMSampleList() Skip Take Order
        [TestMethod]
        public void GetMWQMSampleList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSampleID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleDirectQueryList = mwqmSampleService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSampleID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            Assert.AreEqual(0, mwqmSampleList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSampleFields(mwqmSampleList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        Assert.AreEqual(1, mwqmSampleList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleList() Skip Take Order

        #region Tests Generated for GetMWQMSampleList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMSampleList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSampleID,MWQMSiteTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleDirectQueryList = mwqmSampleService.GetRead().Skip(1).Take(1).OrderBy(c => c.MWQMSampleID).ThenBy(c => c.MWQMSiteTVItemID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            Assert.AreEqual(0, mwqmSampleList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSampleFields(mwqmSampleList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        Assert.AreEqual(1, mwqmSampleList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleList() Skip Take 2Order

        #region Tests Generated for GetMWQMSampleList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMSampleList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSampleID", "MWQMSampleID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleDirectQueryList = mwqmSampleService.GetRead().Where(c => c.MWQMSampleID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSampleID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            Assert.AreEqual(0, mwqmSampleList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSampleFields(mwqmSampleList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        Assert.AreEqual(1, mwqmSampleList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleList() Skip Take Order Where

        #region Tests Generated for GetMWQMSampleList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMSampleList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSampleID", "MWQMSampleID,GT,2|MWQMSampleID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleDirectQueryList = mwqmSampleService.GetRead().Where(c => c.MWQMSampleID > 2 && c.MWQMSampleID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSampleID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            Assert.AreEqual(0, mwqmSampleList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSampleFields(mwqmSampleList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        Assert.AreEqual(1, mwqmSampleList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMSampleList() 2Where
        [TestMethod]
        public void GetMWQMSampleList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSampleID,GT,2|MWQMSampleID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        mwqmSampleDirectQueryList = mwqmSampleService.GetRead().Where(c => c.MWQMSampleID > 2 && c.MWQMSampleID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            Assert.AreEqual(0, mwqmSampleList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckMWQMSampleFields(mwqmSampleList, entityQueryDetailType);
                        Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        Assert.AreEqual(2, mwqmSampleList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleList() 2Where

        #region Functions private
        private void CheckMWQMSampleFields(List<MWQMSample> mwqmSampleList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // MWQMSample fields
            Assert.IsNotNull(mwqmSampleList[0].MWQMSampleID);
            Assert.IsNotNull(mwqmSampleList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSampleList[0].MWQMRunTVItemID);
            Assert.IsNotNull(mwqmSampleList[0].SampleDateTime_Local);
            if (mwqmSampleList[0].Depth_m != null)
            {
                Assert.IsNotNull(mwqmSampleList[0].Depth_m);
            }
            Assert.IsNotNull(mwqmSampleList[0].FecCol_MPN_100ml);
            if (mwqmSampleList[0].Salinity_PPT != null)
            {
                Assert.IsNotNull(mwqmSampleList[0].Salinity_PPT);
            }
            if (mwqmSampleList[0].WaterTemp_C != null)
            {
                Assert.IsNotNull(mwqmSampleList[0].WaterTemp_C);
            }
            if (mwqmSampleList[0].PH != null)
            {
                Assert.IsNotNull(mwqmSampleList[0].PH);
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].SampleTypesText));
            if (mwqmSampleList[0].SampleType_old != null)
            {
                Assert.IsNotNull(mwqmSampleList[0].SampleType_old);
            }
            if (mwqmSampleList[0].Tube_10 != null)
            {
                Assert.IsNotNull(mwqmSampleList[0].Tube_10);
            }
            if (mwqmSampleList[0].Tube_1_0 != null)
            {
                Assert.IsNotNull(mwqmSampleList[0].Tube_1_0);
            }
            if (mwqmSampleList[0].Tube_0_1 != null)
            {
                Assert.IsNotNull(mwqmSampleList[0].Tube_0_1);
            }
            if (!string.IsNullOrWhiteSpace(mwqmSampleList[0].ProcessedBy))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].ProcessedBy));
            }
            Assert.IsNotNull(mwqmSampleList[0].UseForOpenData);
            Assert.IsNotNull(mwqmSampleList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSampleList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // MWQMSampleWeb and MWQMSampleReport fields should be null here
                Assert.IsNull(mwqmSampleList[0].MWQMSampleWeb);
                Assert.IsNull(mwqmSampleList[0].MWQMSampleReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // MWQMSampleWeb fields should not be null and MWQMSampleReport fields should be null here
                if (!string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.MWQMSiteTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.MWQMSiteTVText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.MWQMRunTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.MWQMRunTVText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.SampleType_oldText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.SampleType_oldText));
                }
                Assert.IsNull(mwqmSampleList[0].MWQMSampleReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // MWQMSampleWeb and MWQMSampleReport fields should NOT be null here
                if (mwqmSampleList[0].MWQMSampleWeb.MWQMSiteTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.MWQMSiteTVText));
                }
                if (mwqmSampleList[0].MWQMSampleWeb.MWQMRunTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.MWQMRunTVText));
                }
                if (mwqmSampleList[0].MWQMSampleWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.LastUpdateContactTVText));
                }
                if (mwqmSampleList[0].MWQMSampleWeb.SampleType_oldText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleWeb.SampleType_oldText));
                }
                if (mwqmSampleList[0].MWQMSampleReport.MWQMSampleReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleList[0].MWQMSampleReport.MWQMSampleReportTest));
                }
            }
        }
        private MWQMSample GetFilledRandomMWQMSample(string OmitPropName)
        {
            MWQMSample mwqmSample = new MWQMSample();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSample.MWQMSiteTVItemID = 40;
            if (OmitPropName != "MWQMRunTVItemID") mwqmSample.MWQMRunTVItemID = 46;
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
    }
}
