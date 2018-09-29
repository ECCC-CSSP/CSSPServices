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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = mwqmSampleService.GetMWQMSampleList().Count();

                    Assert.AreEqual(mwqmSampleService.GetMWQMSampleList().Count(), (from c in dbTestDB.MWQMSamples select c).Take(200).Count());

                    mwqmSampleService.Add(mwqmSample);
                    if (mwqmSample.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSampleService.GetMWQMSampleList().Where(c => c == mwqmSample).Any());
                    mwqmSampleService.Update(mwqmSample);
                    if (mwqmSample.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSampleService.GetMWQMSampleList().Count());
                    mwqmSampleService.Delete(mwqmSample);
                    if (mwqmSample.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleMWQMSampleID"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSampleID = 10000000;
                    mwqmSampleService.Update(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleMWQMSampleID", mwqmSample.MWQMSampleID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // mwqmSample.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSiteTVItemID = 0;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSampleMWQMSiteTVItemID", mwqmSample.MWQMSiteTVItemID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMSiteTVItemID = 1;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSampleMWQMSiteTVItemID", "MWQMSite"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
                    // mwqmSample.MWQMRunTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMRunTVItemID = 0;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSampleMWQMRunTVItemID", mwqmSample.MWQMRunTVItemID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.MWQMRunTVItemID = 1;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSampleMWQMRunTVItemID", "MWQMRun"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSample.SampleDateTime_Local   (DateTime)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.SampleDateTime_Local = new DateTime();
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleSampleDateTime_Local"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.SampleDateTime_Local = new DateTime(1979, 1, 1);
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSampleSampleDateTime_Local", "1980"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleDepth_m", "0", "1000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Depth_m = 1001.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleDepth_m", "0", "1000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // mwqmSample.FecCol_MPN_100ml   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.FecCol_MPN_100ml = -1;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleFecCol_MPN_100ml", "0", "10000000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.FecCol_MPN_100ml = 10000001;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleFecCol_MPN_100ml", "0", "10000000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleSalinity_PPT", "0", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Salinity_PPT = 41.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleSalinity_PPT", "0", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleWaterTemp_C", "-10", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.WaterTemp_C = 41.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleWaterTemp_C", "-10", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSamplePH", "0", "14"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.PH = 15.0D;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSamplePH", "0", "14"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // mwqmSample.SampleTypesText   (String)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("SampleTypesText");
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(1, mwqmSample.ValidationResults.Count());
                    Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "MWQMSampleSampleTypesText")).Any());
                    Assert.AreEqual(null, mwqmSample.SampleTypesText);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.SampleTypesText = GetRandomString("", 51);
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSampleSampleTypesText", "50"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // mwqmSample.SampleType_old   (SampleTypeEnum)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.SampleType_old = (SampleTypeEnum)1000000;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleSampleType_old"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 5)]
                    // mwqmSample.Tube_10   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_10 = -1;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleTube_10", "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_10 = 6;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleTube_10", "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 5)]
                    // mwqmSample.Tube_1_0   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_1_0 = -1;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleTube_1_0", "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_1_0 = 6;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleTube_1_0", "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 5)]
                    // mwqmSample.Tube_0_1   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_0_1 = -1;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleTube_0_1", "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.Tube_0_1 = 6;
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSampleTube_0_1", "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(10))]
                    // mwqmSample.ProcessedBy   (String)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.ProcessedBy = GetRandomString("", 11);
                    Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSampleProcessedBy", "10"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSampleService.GetMWQMSampleList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // mwqmSample.UseForOpenData   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSample.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.LastUpdateDate_UTC = new DateTime();
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLastUpdateDate_UTC"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSampleLastUpdateDate_UTC", "1980"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSample.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.LastUpdateContactTVItemID = 0;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSampleLastUpdateContactTVItemID", mwqmSample.LastUpdateContactTVItemID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSample = null;
                    mwqmSample = GetFilledRandomMWQMSample("");
                    mwqmSample.LastUpdateContactTVItemID = 1;
                    mwqmSampleService.Add(mwqmSample);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSampleLastUpdateContactTVItemID", "Contact"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSample mwqmSample = (from c in dbTestDB.MWQMSamples select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSample);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        mwqmSampleService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            MWQMSample mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID);
                            CheckMWQMSampleFields(new List<MWQMSample>() { mwqmSampleRet });
                            Assert.AreEqual(mwqmSample.MWQMSampleID, mwqmSampleRet.MWQMSampleID);
                        }
                        else if (detail == "A")
                        {
                            MWQMSample_A mwqmSample_ARet = mwqmSampleService.GetMWQMSample_AWithMWQMSampleID(mwqmSample.MWQMSampleID);
                            CheckMWQMSample_AFields(new List<MWQMSample_A>() { mwqmSample_ARet });
                            Assert.AreEqual(mwqmSample.MWQMSampleID, mwqmSample_ARet.MWQMSampleID);
                        }
                        else if (detail == "B")
                        {
                            MWQMSample_B mwqmSample_BRet = mwqmSampleService.GetMWQMSample_BWithMWQMSampleID(mwqmSample.MWQMSampleID);
                            CheckMWQMSample_BFields(new List<MWQMSample_B>() { mwqmSample_BRet });
                            Assert.AreEqual(mwqmSample.MWQMSampleID, mwqmSample_BRet.MWQMSampleID);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMSample mwqmSample = (from c in dbTestDB.MWQMSamples select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSample);

                    List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                    mwqmSampleDirectQueryList = (from c in dbTestDB.MWQMSamples select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        mwqmSampleService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            CheckMWQMSampleFields(mwqmSampleList);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSample_A> mwqmSample_AList = new List<MWQMSample_A>();
                            mwqmSample_AList = mwqmSampleService.GetMWQMSample_AList().ToList();
                            CheckMWQMSample_AFields(mwqmSample_AList);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSample_B> mwqmSample_BList = new List<MWQMSample_B>();
                            mwqmSample_BList = mwqmSampleService.GetMWQMSample_BList().ToList();
                            CheckMWQMSample_BFields(mwqmSample_BList);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                        mwqmSampleDirectQueryList = (from c in dbTestDB.MWQMSamples select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            CheckMWQMSampleFields(mwqmSampleList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSample_A> mwqmSample_AList = new List<MWQMSample_A>();
                            mwqmSample_AList = mwqmSampleService.GetMWQMSample_AList().ToList();
                            CheckMWQMSample_AFields(mwqmSample_AList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_AList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSample_B> mwqmSample_BList = new List<MWQMSample_B>();
                            mwqmSample_BList = mwqmSampleService.GetMWQMSample_BList().ToList();
                            CheckMWQMSample_BFields(mwqmSample_BList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_BList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMSampleID", "");

                        List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                        mwqmSampleDirectQueryList = (from c in dbTestDB.MWQMSamples select c).Skip(1).Take(1).OrderBy(c => c.MWQMSampleID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            CheckMWQMSampleFields(mwqmSampleList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSample_A> mwqmSample_AList = new List<MWQMSample_A>();
                            mwqmSample_AList = mwqmSampleService.GetMWQMSample_AList().ToList();
                            CheckMWQMSample_AFields(mwqmSample_AList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_AList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSample_B> mwqmSample_BList = new List<MWQMSample_B>();
                            mwqmSample_BList = mwqmSampleService.GetMWQMSample_BList().ToList();
                            CheckMWQMSample_BFields(mwqmSample_BList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_BList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 1, 1, "MWQMSampleID,MWQMSiteTVItemID", "");

                        List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                        mwqmSampleDirectQueryList = (from c in dbTestDB.MWQMSamples select c).Skip(1).Take(1).OrderBy(c => c.MWQMSampleID).ThenBy(c => c.MWQMSiteTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            CheckMWQMSampleFields(mwqmSampleList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSample_A> mwqmSample_AList = new List<MWQMSample_A>();
                            mwqmSample_AList = mwqmSampleService.GetMWQMSample_AList().ToList();
                            CheckMWQMSample_AFields(mwqmSample_AList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_AList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSample_B> mwqmSample_BList = new List<MWQMSample_B>();
                            mwqmSample_BList = mwqmSampleService.GetMWQMSample_BList().ToList();
                            CheckMWQMSample_BFields(mwqmSample_BList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_BList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSampleID", "MWQMSampleID,EQ,4", "");

                        List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                        mwqmSampleDirectQueryList = (from c in dbTestDB.MWQMSamples select c).Where(c => c.MWQMSampleID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMSampleID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            CheckMWQMSampleFields(mwqmSampleList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSample_A> mwqmSample_AList = new List<MWQMSample_A>();
                            mwqmSample_AList = mwqmSampleService.GetMWQMSample_AList().ToList();
                            CheckMWQMSample_AFields(mwqmSample_AList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_AList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSample_B> mwqmSample_BList = new List<MWQMSample_B>();
                            mwqmSample_BList = mwqmSampleService.GetMWQMSample_BList().ToList();
                            CheckMWQMSample_BFields(mwqmSample_BList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_BList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 0, 1, "MWQMSampleID", "MWQMSampleID,GT,2|MWQMSampleID,LT,5", "");

                        List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                        mwqmSampleDirectQueryList = (from c in dbTestDB.MWQMSamples select c).Where(c => c.MWQMSampleID > 2 && c.MWQMSampleID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMSampleID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            CheckMWQMSampleFields(mwqmSampleList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSample_A> mwqmSample_AList = new List<MWQMSample_A>();
                            mwqmSample_AList = mwqmSampleService.GetMWQMSample_AList().ToList();
                            CheckMWQMSample_AFields(mwqmSample_AList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_AList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSample_B> mwqmSample_BList = new List<MWQMSample_B>();
                            mwqmSample_BList = mwqmSampleService.GetMWQMSample_BList().ToList();
                            CheckMWQMSample_BFields(mwqmSample_BList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_BList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        MWQMSampleService mwqmSampleService = new MWQMSampleService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmSampleService.Query = mwqmSampleService.FillQuery(typeof(MWQMSample), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMSampleID,GT,2|MWQMSampleID,LT,5", "");

                        List<MWQMSample> mwqmSampleDirectQueryList = new List<MWQMSample>();
                        mwqmSampleDirectQueryList = (from c in dbTestDB.MWQMSamples select c).Where(c => c.MWQMSampleID > 2 && c.MWQMSampleID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                            mwqmSampleList = mwqmSampleService.GetMWQMSampleList().ToList();
                            CheckMWQMSampleFields(mwqmSampleList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSampleList[0].MWQMSampleID);
                        }
                        else if (detail == "A")
                        {
                            List<MWQMSample_A> mwqmSample_AList = new List<MWQMSample_A>();
                            mwqmSample_AList = mwqmSampleService.GetMWQMSample_AList().ToList();
                            CheckMWQMSample_AFields(mwqmSample_AList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_AList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<MWQMSample_B> mwqmSample_BList = new List<MWQMSample_B>();
                            mwqmSample_BList = mwqmSampleService.GetMWQMSample_BList().ToList();
                            CheckMWQMSample_BFields(mwqmSample_BList);
                            Assert.AreEqual(mwqmSampleDirectQueryList[0].MWQMSampleID, mwqmSample_BList[0].MWQMSampleID);
                            Assert.AreEqual(mwqmSampleDirectQueryList.Count, mwqmSample_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMSampleList() 2Where

        #region Functions private
        private void CheckMWQMSampleFields(List<MWQMSample> mwqmSampleList)
        {
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
            Assert.IsNotNull(mwqmSampleList[0].HasErrors);
        }
        private void CheckMWQMSample_AFields(List<MWQMSample_A> mwqmSample_AList)
        {
            Assert.IsNotNull(mwqmSample_AList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(mwqmSample_AList[0].MWQMRunTVItemLanguage);
            Assert.IsNotNull(mwqmSample_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmSample_AList[0].SampleType_oldText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSample_AList[0].SampleType_oldText));
            }
            Assert.IsNotNull(mwqmSample_AList[0].MWQMSampleID);
            Assert.IsNotNull(mwqmSample_AList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSample_AList[0].MWQMRunTVItemID);
            Assert.IsNotNull(mwqmSample_AList[0].SampleDateTime_Local);
            if (mwqmSample_AList[0].Depth_m != null)
            {
                Assert.IsNotNull(mwqmSample_AList[0].Depth_m);
            }
            Assert.IsNotNull(mwqmSample_AList[0].FecCol_MPN_100ml);
            if (mwqmSample_AList[0].Salinity_PPT != null)
            {
                Assert.IsNotNull(mwqmSample_AList[0].Salinity_PPT);
            }
            if (mwqmSample_AList[0].WaterTemp_C != null)
            {
                Assert.IsNotNull(mwqmSample_AList[0].WaterTemp_C);
            }
            if (mwqmSample_AList[0].PH != null)
            {
                Assert.IsNotNull(mwqmSample_AList[0].PH);
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSample_AList[0].SampleTypesText));
            if (mwqmSample_AList[0].SampleType_old != null)
            {
                Assert.IsNotNull(mwqmSample_AList[0].SampleType_old);
            }
            if (mwqmSample_AList[0].Tube_10 != null)
            {
                Assert.IsNotNull(mwqmSample_AList[0].Tube_10);
            }
            if (mwqmSample_AList[0].Tube_1_0 != null)
            {
                Assert.IsNotNull(mwqmSample_AList[0].Tube_1_0);
            }
            if (mwqmSample_AList[0].Tube_0_1 != null)
            {
                Assert.IsNotNull(mwqmSample_AList[0].Tube_0_1);
            }
            if (!string.IsNullOrWhiteSpace(mwqmSample_AList[0].ProcessedBy))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSample_AList[0].ProcessedBy));
            }
            Assert.IsNotNull(mwqmSample_AList[0].UseForOpenData);
            Assert.IsNotNull(mwqmSample_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSample_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSample_AList[0].HasErrors);
        }
        private void CheckMWQMSample_BFields(List<MWQMSample_B> mwqmSample_BList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmSample_BList[0].MWQMSampleReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSample_BList[0].MWQMSampleReportTest));
            }
            Assert.IsNotNull(mwqmSample_BList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(mwqmSample_BList[0].MWQMRunTVItemLanguage);
            Assert.IsNotNull(mwqmSample_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mwqmSample_BList[0].SampleType_oldText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSample_BList[0].SampleType_oldText));
            }
            Assert.IsNotNull(mwqmSample_BList[0].MWQMSampleID);
            Assert.IsNotNull(mwqmSample_BList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(mwqmSample_BList[0].MWQMRunTVItemID);
            Assert.IsNotNull(mwqmSample_BList[0].SampleDateTime_Local);
            if (mwqmSample_BList[0].Depth_m != null)
            {
                Assert.IsNotNull(mwqmSample_BList[0].Depth_m);
            }
            Assert.IsNotNull(mwqmSample_BList[0].FecCol_MPN_100ml);
            if (mwqmSample_BList[0].Salinity_PPT != null)
            {
                Assert.IsNotNull(mwqmSample_BList[0].Salinity_PPT);
            }
            if (mwqmSample_BList[0].WaterTemp_C != null)
            {
                Assert.IsNotNull(mwqmSample_BList[0].WaterTemp_C);
            }
            if (mwqmSample_BList[0].PH != null)
            {
                Assert.IsNotNull(mwqmSample_BList[0].PH);
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSample_BList[0].SampleTypesText));
            if (mwqmSample_BList[0].SampleType_old != null)
            {
                Assert.IsNotNull(mwqmSample_BList[0].SampleType_old);
            }
            if (mwqmSample_BList[0].Tube_10 != null)
            {
                Assert.IsNotNull(mwqmSample_BList[0].Tube_10);
            }
            if (mwqmSample_BList[0].Tube_1_0 != null)
            {
                Assert.IsNotNull(mwqmSample_BList[0].Tube_1_0);
            }
            if (mwqmSample_BList[0].Tube_0_1 != null)
            {
                Assert.IsNotNull(mwqmSample_BList[0].Tube_0_1);
            }
            if (!string.IsNullOrWhiteSpace(mwqmSample_BList[0].ProcessedBy))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSample_BList[0].ProcessedBy));
            }
            Assert.IsNotNull(mwqmSample_BList[0].UseForOpenData);
            Assert.IsNotNull(mwqmSample_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmSample_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmSample_BList[0].HasErrors);
        }
        private MWQMSample GetFilledRandomMWQMSample(string OmitPropName)
        {
            MWQMSample mwqmSample = new MWQMSample();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSample.MWQMSiteTVItemID = 43;
            if (OmitPropName != "MWQMRunTVItemID") mwqmSample.MWQMRunTVItemID = 49;
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
