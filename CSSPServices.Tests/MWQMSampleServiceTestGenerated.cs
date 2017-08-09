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
            if (OmitPropName != "MWQMRunTVItemID") mwqmSample.MWQMRunTVItemID = 24;
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
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSample.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSample.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "MWQMSiteTVText") mwqmSample.MWQMSiteTVText = GetRandomString("", 5);
            if (OmitPropName != "MWQMRunTVText") mwqmSample.MWQMRunTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") mwqmSample.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "SampleType_oldText") mwqmSample.SampleType_oldText = GetRandomString("", 5);

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

                MWQMSampleService mwqmSampleService = new MWQMSampleService(LanguageRequest, dbTestDB, ContactID);

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

                mwqmSampleService.Add(mwqmSample);
                if (mwqmSample.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, mwqmSampleService.GetRead().Where(c => c == mwqmSample).Any());
                mwqmSampleService.Update(mwqmSample);
                if (mwqmSample.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, mwqmSampleService.GetRead().Count());
                mwqmSampleService.Delete(mwqmSample);
                if (mwqmSample.ValidationResults.Count() > 0)
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleMWQMSampleID), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                // mwqmSample.MWQMSiteTVItemID   (Int32)
                // -----------------------------------

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.MWQMSiteTVItemID = 0;
                mwqmSampleService.Add(mwqmSample);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSampleMWQMSiteTVItemID, mwqmSample.MWQMSiteTVItemID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.MWQMSiteTVItemID = 1;
                mwqmSampleService.Add(mwqmSample);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSampleMWQMSiteTVItemID, "MWQMSite"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
                // mwqmSample.MWQMRunTVItemID   (Int32)
                // -----------------------------------

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.MWQMRunTVItemID = 0;
                mwqmSampleService.Add(mwqmSample);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSampleMWQMRunTVItemID, mwqmSample.MWQMRunTVItemID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.MWQMRunTVItemID = 1;
                mwqmSampleService.Add(mwqmSample);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSampleMWQMRunTVItemID, "MWQMRun"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSample.SampleDateTime_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [Range(0, 1000)]
                // mwqmSample.Depth_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [Depth_m]

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.Depth_m = -1.0D;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleDepth_m, "0", "1000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.Depth_m = 1001.0D;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleDepth_m, "0", "1000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.FecCol_MPN_100ml = 10000001;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 40)]
                // mwqmSample.Salinity_PPT   (Double)
                // -----------------------------------

                //Error: Type not implemented [Salinity_PPT]

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.Salinity_PPT = -1.0D;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleSalinity_PPT, "0", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.Salinity_PPT = 41.0D;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleSalinity_PPT, "0", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(-10, 40)]
                // mwqmSample.WaterTemp_C   (Double)
                // -----------------------------------

                //Error: Type not implemented [WaterTemp_C]

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.WaterTemp_C = -11.0D;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleWaterTemp_C, "-10", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.WaterTemp_C = 41.0D;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleWaterTemp_C, "-10", "40"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 14)]
                // mwqmSample.PH   (Double)
                // -----------------------------------

                //Error: Type not implemented [PH]

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.PH = -1.0D;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSamplePH, "0", "14"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.PH = 15.0D;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSamplePH, "0", "14"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleTypesText)).Any());
                Assert.AreEqual(null, mwqmSample.SampleTypesText);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.SampleTypesText = GetRandomString("", 51);
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleSampleTypesText, "50"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // mwqmSample.SampleType_old   (SampleTypeEnum)
                // -----------------------------------

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.SampleType_old = (SampleTypeEnum)1000000;
                mwqmSampleService.Add(mwqmSample);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleType_old), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [Range(0, 5)]
                // mwqmSample.Tube_10   (Int32)
                // -----------------------------------

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.Tube_10 = -1;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_10, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.Tube_10 = 6;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_10, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_1_0, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.Tube_1_0 = 6;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_1_0, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_0_1, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.Tube_0_1 = 6;
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_0_1, "0", "5"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleProcessedBy, "10"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSample.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // mwqmSample.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.LastUpdateContactTVItemID = 0;
                mwqmSampleService.Add(mwqmSample);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSampleLastUpdateContactTVItemID, mwqmSample.LastUpdateContactTVItemID.ToString()), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.LastUpdateContactTVItemID = 1;
                mwqmSampleService.Add(mwqmSample);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSampleLastUpdateContactTVItemID, "Contact"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "MWQMSiteTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // mwqmSample.MWQMSiteTVText   (String)
                // -----------------------------------

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.MWQMSiteTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleMWQMSiteTVText, "200"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "MWQMRunTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // mwqmSample.MWQMRunTVText   (String)
                // -----------------------------------

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.MWQMRunTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleMWQMRunTVText, "200"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // mwqmSample.LastUpdateContactTVText   (String)
                // -----------------------------------

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleLastUpdateContactTVText, "200"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmSample.SampleType_oldText   (String)
                // -----------------------------------

                mwqmSample = null;
                mwqmSample = GetFilledRandomMWQMSample("");
                mwqmSample.SampleType_oldText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleSampleType_oldText, "100"), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // mwqmSample.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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

                MWQMSampleService mwqmSampleService = new MWQMSampleService(LanguageRequest, dbTestDB, ContactID);
                MWQMSample mwqmSample = (from c in mwqmSampleService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(mwqmSample);

                MWQMSample mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleID(mwqmSample.MWQMSampleID);
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
                Assert.IsNotNull(mwqmSampleRet.SampleTypesText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.SampleTypesText));
                Assert.IsNotNull(mwqmSampleRet.SampleType_old);
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
                   Assert.IsNotNull(mwqmSampleRet.ProcessedBy);
                   Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.ProcessedBy));
                }
                Assert.IsNotNull(mwqmSampleRet.LastUpdateDate_UTC);
                Assert.IsNotNull(mwqmSampleRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(mwqmSampleRet.MWQMSiteTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMSiteTVText));
                Assert.IsNotNull(mwqmSampleRet.MWQMRunTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.MWQMRunTVText));
                Assert.IsNotNull(mwqmSampleRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.LastUpdateContactTVText));
                Assert.IsNotNull(mwqmSampleRet.SampleType_oldText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSampleRet.SampleType_oldText));
            }
        }
        #endregion Tests Get With Key

    }
}
