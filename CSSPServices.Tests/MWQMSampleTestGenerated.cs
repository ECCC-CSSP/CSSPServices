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
    public partial class MWQMSampleTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMSampleID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSample GetFilledRandomMWQMSample(string OmitPropName)
        {
            MWQMSampleID += 1;

            MWQMSample mwqmSample = new MWQMSample();

            if (OmitPropName != "MWQMSampleID") mwqmSample.MWQMSampleID = MWQMSampleID;
            if (OmitPropName != "MWQMSiteTVItemID") mwqmSample.MWQMSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "MWQMRunTVItemID") mwqmSample.MWQMRunTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "SampleDateTime_Local") mwqmSample.SampleDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Depth_m") mwqmSample.Depth_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "FecCol_MPN_100ml") mwqmSample.FecCol_MPN_100ml = GetRandomInt(0, 20000000);
            if (OmitPropName != "Salinity_PPT") mwqmSample.Salinity_PPT = GetRandomFloat(0, 40);
            if (OmitPropName != "WaterTemp_C") mwqmSample.WaterTemp_C = GetRandomFloat(0, 40);
            if (OmitPropName != "PH") mwqmSample.PH = GetRandomFloat(0, 14);
            if (OmitPropName != "SampleTypesText") mwqmSample.SampleTypesText = GetRandomString("", 5);
            if (OmitPropName != "SampleType_old") mwqmSample.SampleType_old = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "Tube_10") mwqmSample.Tube_10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_1_0") mwqmSample.Tube_1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_0_1") mwqmSample.Tube_0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "ProcessedBy") mwqmSample.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSample.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSample.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mwqmSample;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSample_Testing()
        {
            SetupTestHelper(culture);
            MWQMSampleService mwqmSampleService = new MWQMSampleService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MWQMSample mwqmSample = GetFilledRandomMWQMSample("");
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(true, mwqmSampleService.GetRead().Where(c => c == mwqmSample).Any());
            mwqmSample.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mwqmSampleService.Update(mwqmSample));
            Assert.AreEqual(1, mwqmSampleService.GetRead().Count());
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null

            // MWQMRunTVItemID will automatically be initialized at 0 --> not null

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("SampleDateTime_Local");
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(1, mwqmSample.ValidationResults.Count());
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleDateTime_Local)).Any());
            Assert.IsTrue(mwqmSample.SampleDateTime_Local.Year < 1900);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            // FecCol_MPN_100ml will automatically be initialized at 0 --> not null

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("SampleTypesText");
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(1, mwqmSample.ValidationResults.Count());
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleTypesText)).Any());
            Assert.AreEqual(null, mwqmSample.SampleTypesText);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("SampleType_old");
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(1, mwqmSample.ValidationResults.Count());
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleType_old)).Any());
            Assert.AreEqual(SampleTypeEnum.Error, mwqmSample.SampleType_old);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(1, mwqmSample.ValidationResults.Count());
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmSample.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMSampleID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSiteTVItemID] of type [int]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSample.MWQMSiteTVItemID = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.MWQMSiteTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSample.MWQMSiteTVItemID = 2;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSample.MWQMSiteTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSample.MWQMSiteTVItemID = 0;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleMWQMSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSample.MWQMSiteTVItemID);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMRunTVItemID] of type [int]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSample.MWQMRunTVItemID = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.MWQMRunTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSample.MWQMRunTVItemID = 2;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSample.MWQMRunTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSample.MWQMRunTVItemID = 0;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleMWQMRunTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSample.MWQMRunTVItemID);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [SampleDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Depth_m] of type [float]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Depth_m has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSample.Depth_m = 0.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSample.Depth_m);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSample.Depth_m = 1.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSample.Depth_m);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSample.Depth_m = -1.0f;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mwqmSample.Depth_m);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSample.Depth_m = 1000.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mwqmSample.Depth_m);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSample.Depth_m = 999.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(999.0f, mwqmSample.Depth_m);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSample.Depth_m = 1001.0f;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mwqmSample.Depth_m);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [FecCol_MPN_100ml] of type [int]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // FecCol_MPN_100ml has Min [0] and Max [20000000]. At Min should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 0;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [20000000]. At Min + 1 should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [20000000]. At Min - 1 should return false with one error
            mwqmSample.FecCol_MPN_100ml = -1;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(-1, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [20000000]. At Max should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 20000000;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(20000000, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [20000000]. At Max - 1 should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 19999999;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(19999999, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [20000000]. At Max + 1 should return false with one error
            mwqmSample.FecCol_MPN_100ml = 20000001;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(20000001, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [Salinity_PPT] of type [float]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Salinity_PPT has Min [0] and Max [40]. At Min should return true and no errors
            mwqmSample.Salinity_PPT = 0.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSample.Salinity_PPT);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0] and Max [40]. At Min + 1 should return true and no errors
            mwqmSample.Salinity_PPT = 1.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSample.Salinity_PPT);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0] and Max [40]. At Min - 1 should return false with one error
            mwqmSample.Salinity_PPT = -1.0f;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleSalinity_PPT, "0", "40")).Any());
            Assert.AreEqual(-1.0f, mwqmSample.Salinity_PPT);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0] and Max [40]. At Max should return true and no errors
            mwqmSample.Salinity_PPT = 40.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(40.0f, mwqmSample.Salinity_PPT);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0] and Max [40]. At Max - 1 should return true and no errors
            mwqmSample.Salinity_PPT = 39.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(39.0f, mwqmSample.Salinity_PPT);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0] and Max [40]. At Max + 1 should return false with one error
            mwqmSample.Salinity_PPT = 41.0f;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleSalinity_PPT, "0", "40")).Any());
            Assert.AreEqual(41.0f, mwqmSample.Salinity_PPT);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [WaterTemp_C] of type [float]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // WaterTemp_C has Min [0] and Max [40]. At Min should return true and no errors
            mwqmSample.WaterTemp_C = 0.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSample.WaterTemp_C);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [0] and Max [40]. At Min + 1 should return true and no errors
            mwqmSample.WaterTemp_C = 1.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSample.WaterTemp_C);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [0] and Max [40]. At Min - 1 should return false with one error
            mwqmSample.WaterTemp_C = -1.0f;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleWaterTemp_C, "0", "40")).Any());
            Assert.AreEqual(-1.0f, mwqmSample.WaterTemp_C);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [0] and Max [40]. At Max should return true and no errors
            mwqmSample.WaterTemp_C = 40.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(40.0f, mwqmSample.WaterTemp_C);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [0] and Max [40]. At Max - 1 should return true and no errors
            mwqmSample.WaterTemp_C = 39.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(39.0f, mwqmSample.WaterTemp_C);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [0] and Max [40]. At Max + 1 should return false with one error
            mwqmSample.WaterTemp_C = 41.0f;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleWaterTemp_C, "0", "40")).Any());
            Assert.AreEqual(41.0f, mwqmSample.WaterTemp_C);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [PH] of type [float]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // PH has Min [0] and Max [14]. At Min should return true and no errors
            mwqmSample.PH = 0.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0.0f, mwqmSample.PH);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // PH has Min [0] and Max [14]. At Min + 1 should return true and no errors
            mwqmSample.PH = 1.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1.0f, mwqmSample.PH);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // PH has Min [0] and Max [14]. At Min - 1 should return false with one error
            mwqmSample.PH = -1.0f;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSamplePH, "0", "14")).Any());
            Assert.AreEqual(-1.0f, mwqmSample.PH);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // PH has Min [0] and Max [14]. At Max should return true and no errors
            mwqmSample.PH = 14.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(14.0f, mwqmSample.PH);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // PH has Min [0] and Max [14]. At Max - 1 should return true and no errors
            mwqmSample.PH = 13.0f;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(13.0f, mwqmSample.PH);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // PH has Min [0] and Max [14]. At Max + 1 should return false with one error
            mwqmSample.PH = 15.0f;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSamplePH, "0", "14")).Any());
            Assert.AreEqual(15.0f, mwqmSample.PH);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [SampleTypesText] of type [string]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");

            // SampleTypesText has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string mwqmSampleSampleTypesTextMin = GetRandomString("", 50);
            mwqmSample.SampleTypesText = mwqmSampleSampleTypesTextMin;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(mwqmSampleSampleTypesTextMin, mwqmSample.SampleTypesText);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            // SampleTypesText has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            mwqmSampleSampleTypesTextMin = GetRandomString("", 49);
            mwqmSample.SampleTypesText = mwqmSampleSampleTypesTextMin;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(mwqmSampleSampleTypesTextMin, mwqmSample.SampleTypesText);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            // SampleTypesText has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            mwqmSampleSampleTypesTextMin = GetRandomString("", 51);
            mwqmSample.SampleTypesText = mwqmSampleSampleTypesTextMin;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleSampleTypesText, "50")).Any());
            Assert.AreEqual(mwqmSampleSampleTypesTextMin, mwqmSample.SampleTypesText);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [SampleType_old] of type [SampleTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Tube_10] of type [int]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Tube_10 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmSample.Tube_10 = 0;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSample.Tube_10);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmSample.Tube_10 = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.Tube_10);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmSample.Tube_10 = -1;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_10, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmSample.Tube_10);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmSample.Tube_10 = 5;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(5, mwqmSample.Tube_10);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmSample.Tube_10 = 4;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(4, mwqmSample.Tube_10);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmSample.Tube_10 = 6;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_10, "0", "5")).Any());
            Assert.AreEqual(6, mwqmSample.Tube_10);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [Tube_1_0] of type [int]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Tube_1_0 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmSample.Tube_1_0 = 0;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSample.Tube_1_0);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmSample.Tube_1_0 = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.Tube_1_0);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmSample.Tube_1_0 = -1;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_1_0, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmSample.Tube_1_0);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmSample.Tube_1_0 = 5;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(5, mwqmSample.Tube_1_0);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmSample.Tube_1_0 = 4;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(4, mwqmSample.Tube_1_0);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmSample.Tube_1_0 = 6;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_1_0, "0", "5")).Any());
            Assert.AreEqual(6, mwqmSample.Tube_1_0);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [Tube_0_1] of type [int]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Tube_0_1 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmSample.Tube_0_1 = 0;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSample.Tube_0_1);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmSample.Tube_0_1 = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.Tube_0_1);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmSample.Tube_0_1 = -1;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_0_1, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmSample.Tube_0_1);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmSample.Tube_0_1 = 5;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(5, mwqmSample.Tube_0_1);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmSample.Tube_0_1 = 4;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(4, mwqmSample.Tube_0_1);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmSample.Tube_0_1 = 6;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_0_1, "0", "5")).Any());
            Assert.AreEqual(6, mwqmSample.Tube_0_1);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [ProcessedBy] of type [string]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max should return true and no errors
            string mwqmSampleProcessedByMin = GetRandomString("", 10);
            mwqmSample.ProcessedBy = mwqmSampleProcessedByMin;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(mwqmSampleProcessedByMin, mwqmSample.ProcessedBy);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            mwqmSampleProcessedByMin = GetRandomString("", 9);
            mwqmSample.ProcessedBy = mwqmSampleProcessedByMin;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(mwqmSampleProcessedByMin, mwqmSample.ProcessedBy);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            mwqmSampleProcessedByMin = GetRandomString("", 11);
            mwqmSample.ProcessedBy = mwqmSampleProcessedByMin;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleProcessedBy, "10")).Any());
            Assert.AreEqual(mwqmSampleProcessedByMin, mwqmSample.ProcessedBy);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSample.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSample.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSample.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSample.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSample.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
