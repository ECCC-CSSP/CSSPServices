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
            if (OmitPropName != "Depth_m") mwqmSample.Depth_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "FecCol_MPN_100ml") mwqmSample.FecCol_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Salinity_PPT") mwqmSample.Salinity_PPT = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "WaterTemp_C") mwqmSample.WaterTemp_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PH") mwqmSample.PH = GetRandomDouble(1.0D, 1000.0D);
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
            MWQMSampleService mwqmSampleService = new MWQMSampleService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            MWQMSample mwqmSample = GetFilledRandomMWQMSample("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

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

            //Error: Type not implemented [Depth_m]

            // FecCol_MPN_100ml will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Salinity_PPT]

            //Error: Type not implemented [WaterTemp_C]

            //Error: Type not implemented [PH]

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("SampleTypesText");
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(1, mwqmSample.ValidationResults.Count());
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleTypesText)).Any());
            Assert.AreEqual(null, mwqmSample.SampleTypesText);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //Error: Type not implemented [SampleType_old]

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(1, mwqmSample.ValidationResults.Count());
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmSample.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MWQMSampleLanguages]

            //Error: Type not implemented [MWQMRunTVItem]

            //Error: Type not implemented [MWQMSiteTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMSampleID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSiteTVItemID] of type [Int32]
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
            // doing property [MWQMRunTVItemID] of type [Int32]
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
            // doing property [Depth_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [FecCol_MPN_100ml] of type [Int32]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 0;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            mwqmSample.FecCol_MPN_100ml = -1;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 10000000;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(10000000, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 9999999;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(9999999, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            mwqmSample.FecCol_MPN_100ml = 10000001;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            // doing property [Salinity_PPT] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [WaterTemp_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [PH] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SampleTypesText] of type [String]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");

            //-----------------------------------
            // doing property [SampleType_old] of type [SampleTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Tube_10] of type [Int32]
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
            // doing property [Tube_1_0] of type [Int32]
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
            // doing property [Tube_0_1] of type [Int32]
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
            // doing property [ProcessedBy] of type [String]
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [MWQMSampleLanguages] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMRunTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSiteTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
