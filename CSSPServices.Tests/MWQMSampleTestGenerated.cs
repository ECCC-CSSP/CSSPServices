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
        private MWQMSampleService mwqmSampleService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleTest() : base()
        {
            mwqmSampleService = new MWQMSampleService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "SampleDateTime_Local") mwqmSample.SampleDateTime_Local = GetRandomDateTime();
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
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSample.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSample.LastUpdateContactTVItemID = 2;

            return mwqmSample;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSample_Testing()
        {

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


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // mwqmSample.MWQMSampleID   (Int32)
            //-----------------------------------
            mwqmSample = GetFilledRandomMWQMSample("");
            mwqmSample.MWQMSampleID = 0;
            mwqmSampleService.Update(mwqmSample);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleMWQMSampleID), mwqmSample.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMSite)]
            //[Range(1, -1)]
            // mwqmSample.MWQMSiteTVItemID   (Int32)
            //-----------------------------------
            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null


            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSample.MWQMSiteTVItemID = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.MWQMSiteTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSample.MWQMSiteTVItemID = 2;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSample.MWQMSiteTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSample.MWQMSiteTVItemID = 0;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleMWQMSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSample.MWQMSiteTVItemID);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMRun)]
            //[Range(1, -1)]
            // mwqmSample.MWQMRunTVItemID   (Int32)
            //-----------------------------------
            // MWQMRunTVItemID will automatically be initialized at 0 --> not null


            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSample.MWQMRunTVItemID = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.MWQMRunTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSample.MWQMRunTVItemID = 2;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSample.MWQMRunTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // MWQMRunTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSample.MWQMRunTVItemID = 0;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleMWQMRunTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSample.MWQMRunTVItemID);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmSample.SampleDateTime_Local   (DateTime)
            //-----------------------------------
            // SampleDateTime_Local will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is Nullable
            //[Range(0, 1000)]
            // mwqmSample.Depth_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [Depth_m]


            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            mwqmSample.Depth_m = 0.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSample.Depth_m);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            mwqmSample.Depth_m = 1.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSample.Depth_m);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            mwqmSample.Depth_m = -1.0D;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, mwqmSample.Depth_m);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            mwqmSample.Depth_m = 1000.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1000.0D, mwqmSample.Depth_m);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            mwqmSample.Depth_m = 999.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(999.0D, mwqmSample.Depth_m);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            mwqmSample.Depth_m = 1001.0D;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, mwqmSample.Depth_m);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10000000)]
            // mwqmSample.FecCol_MPN_100ml   (Int32)
            //-----------------------------------
            // FecCol_MPN_100ml will automatically be initialized at 0 --> not null


            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 0;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            mwqmSample.FecCol_MPN_100ml = -1;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 10000000;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(10000000, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            mwqmSample.FecCol_MPN_100ml = 9999999;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(9999999, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // FecCol_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            mwqmSample.FecCol_MPN_100ml = 10000001;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, mwqmSample.FecCol_MPN_100ml);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 40)]
            // mwqmSample.Salinity_PPT   (Double)
            //-----------------------------------
            //Error: Type not implemented [Salinity_PPT]


            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Salinity_PPT has Min [0.0D] and Max [40.0D]. At Min should return true and no errors
            mwqmSample.Salinity_PPT = 0.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSample.Salinity_PPT);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mwqmSample.Salinity_PPT = 1.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSample.Salinity_PPT);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mwqmSample.Salinity_PPT = -1.0D;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleSalinity_PPT, "0", "40")).Any());
            Assert.AreEqual(-1.0D, mwqmSample.Salinity_PPT);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0.0D] and Max [40.0D]. At Max should return true and no errors
            mwqmSample.Salinity_PPT = 40.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(40.0D, mwqmSample.Salinity_PPT);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mwqmSample.Salinity_PPT = 39.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(39.0D, mwqmSample.Salinity_PPT);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Salinity_PPT has Min [0.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mwqmSample.Salinity_PPT = 41.0D;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleSalinity_PPT, "0", "40")).Any());
            Assert.AreEqual(41.0D, mwqmSample.Salinity_PPT);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-10, 40)]
            // mwqmSample.WaterTemp_C   (Double)
            //-----------------------------------
            //Error: Type not implemented [WaterTemp_C]


            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // WaterTemp_C has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            mwqmSample.WaterTemp_C = -10.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(-10.0D, mwqmSample.WaterTemp_C);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mwqmSample.WaterTemp_C = -9.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(-9.0D, mwqmSample.WaterTemp_C);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mwqmSample.WaterTemp_C = -11.0D;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleWaterTemp_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, mwqmSample.WaterTemp_C);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            mwqmSample.WaterTemp_C = 40.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(40.0D, mwqmSample.WaterTemp_C);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mwqmSample.WaterTemp_C = 39.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(39.0D, mwqmSample.WaterTemp_C);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // WaterTemp_C has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mwqmSample.WaterTemp_C = 41.0D;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleWaterTemp_C, "-10", "40")).Any());
            Assert.AreEqual(41.0D, mwqmSample.WaterTemp_C);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 14)]
            // mwqmSample.PH   (Double)
            //-----------------------------------
            //Error: Type not implemented [PH]


            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // PH has Min [0.0D] and Max [14.0D]. At Min should return true and no errors
            mwqmSample.PH = 0.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSample.PH);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // PH has Min [0.0D] and Max [14.0D]. At Min + 1 should return true and no errors
            mwqmSample.PH = 1.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSample.PH);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // PH has Min [0.0D] and Max [14.0D]. At Min - 1 should return false with one error
            mwqmSample.PH = -1.0D;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSamplePH, "0", "14")).Any());
            Assert.AreEqual(-1.0D, mwqmSample.PH);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // PH has Min [0.0D] and Max [14.0D]. At Max should return true and no errors
            mwqmSample.PH = 14.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(14.0D, mwqmSample.PH);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // PH has Min [0.0D] and Max [14.0D]. At Max - 1 should return true and no errors
            mwqmSample.PH = 13.0D;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(13.0D, mwqmSample.PH);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // PH has Min [0.0D] and Max [14.0D]. At Max + 1 should return false with one error
            mwqmSample.PH = 15.0D;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSamplePH, "0", "14")).Any());
            Assert.AreEqual(15.0D, mwqmSample.PH);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(50))]
            // mwqmSample.SampleTypesText   (String)
            //-----------------------------------
            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("SampleTypesText");
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(1, mwqmSample.ValidationResults.Count());
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleTypesText)).Any());
            Assert.AreEqual(null, mwqmSample.SampleTypesText);
            Assert.AreEqual(0, mwqmSampleService.GetRead().Count());


            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");

            // SampleTypesText has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string mwqmSampleSampleTypesTextMin = GetRandomString("", 50);
            mwqmSample.SampleTypesText = mwqmSampleSampleTypesTextMin;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(mwqmSampleSampleTypesTextMin, mwqmSample.SampleTypesText);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            // SampleTypesText has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            mwqmSampleSampleTypesTextMin = GetRandomString("", 49);
            mwqmSample.SampleTypesText = mwqmSampleSampleTypesTextMin;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(mwqmSampleSampleTypesTextMin, mwqmSample.SampleTypesText);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            // SampleTypesText has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            mwqmSampleSampleTypesTextMin = GetRandomString("", 51);
            mwqmSample.SampleTypesText = mwqmSampleSampleTypesTextMin;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleSampleTypesText, "50")).Any());
            Assert.AreEqual(mwqmSampleSampleTypesTextMin, mwqmSample.SampleTypesText);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // mwqmSample.SampleType_old   (SampleTypeEnum)
            //-----------------------------------
            // SampleType_old will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is Nullable
            //[Range(0, 5)]
            // mwqmSample.Tube_10   (Int32)
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Tube_10 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmSample.Tube_10 = 0;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSample.Tube_10);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmSample.Tube_10 = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.Tube_10);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmSample.Tube_10 = -1;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_10, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmSample.Tube_10);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmSample.Tube_10 = 5;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(5, mwqmSample.Tube_10);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmSample.Tube_10 = 4;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(4, mwqmSample.Tube_10);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_10 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmSample.Tube_10 = 6;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_10, "0", "5")).Any());
            Assert.AreEqual(6, mwqmSample.Tube_10);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 5)]
            // mwqmSample.Tube_1_0   (Int32)
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Tube_1_0 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmSample.Tube_1_0 = 0;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSample.Tube_1_0);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmSample.Tube_1_0 = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.Tube_1_0);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmSample.Tube_1_0 = -1;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_1_0, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmSample.Tube_1_0);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmSample.Tube_1_0 = 5;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(5, mwqmSample.Tube_1_0);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmSample.Tube_1_0 = 4;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(4, mwqmSample.Tube_1_0);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_1_0 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmSample.Tube_1_0 = 6;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_1_0, "0", "5")).Any());
            Assert.AreEqual(6, mwqmSample.Tube_1_0);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 5)]
            // mwqmSample.Tube_0_1   (Int32)
            //-----------------------------------

            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // Tube_0_1 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmSample.Tube_0_1 = 0;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSample.Tube_0_1);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmSample.Tube_0_1 = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.Tube_0_1);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmSample.Tube_0_1 = -1;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_0_1, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmSample.Tube_0_1);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmSample.Tube_0_1 = 5;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(5, mwqmSample.Tube_0_1);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmSample.Tube_0_1 = 4;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(4, mwqmSample.Tube_0_1);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // Tube_0_1 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmSample.Tube_0_1 = 6;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_0_1, "0", "5")).Any());
            Assert.AreEqual(6, mwqmSample.Tube_0_1);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(10))]
            // mwqmSample.ProcessedBy   (String)
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
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            mwqmSampleProcessedByMin = GetRandomString("", 9);
            mwqmSample.ProcessedBy = mwqmSampleProcessedByMin;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(mwqmSampleProcessedByMin, mwqmSample.ProcessedBy);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            // ProcessedBy has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            mwqmSampleProcessedByMin = GetRandomString("", 11);
            mwqmSample.ProcessedBy = mwqmSampleProcessedByMin;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleProcessedBy, "10")).Any());
            Assert.AreEqual(mwqmSampleProcessedByMin, mwqmSample.ProcessedBy);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // mwqmSample.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // mwqmSample.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            mwqmSample = null;
            mwqmSample = GetFilledRandomMWQMSample("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSample.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSample.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSample.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmSampleService.Add(mwqmSample));
            Assert.AreEqual(0, mwqmSample.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSample.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSampleService.Delete(mwqmSample));
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSample.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmSampleService.Add(mwqmSample));
            Assert.IsTrue(mwqmSample.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSample.LastUpdateContactTVItemID);
            Assert.AreEqual(count, mwqmSampleService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mwqmSample.MWQMSampleLanguages   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mwqmSample.MWQMRunTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mwqmSample.MWQMSiteTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // mwqmSample.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
