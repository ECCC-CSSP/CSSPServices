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
    public partial class VPResultTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private VPResultService vpResultService { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultTest() : base()
        {
            vpResultService = new VPResultService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPResult GetFilledRandomVPResult(string OmitPropName)
        {
            VPResult vpResult = new VPResult();

            if (OmitPropName != "VPScenarioID") vpResult.VPScenarioID = 1;
            if (OmitPropName != "Ordinal") vpResult.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "Concentration_MPN_100ml") vpResult.Concentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Dilution") vpResult.Dilution = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "FarFieldWidth_m") vpResult.FarFieldWidth_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "DispersionDistance_m") vpResult.DispersionDistance_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "TravelTime_hour") vpResult.TravelTime_hour = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") vpResult.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpResult.LastUpdateContactTVItemID = 2;

            return vpResult;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPResult_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            VPResult vpResult = GetFilledRandomVPResult("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = vpResultService.GetRead().Count();

            vpResultService.Add(vpResult);
            if (vpResult.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, vpResultService.GetRead().Where(c => c == vpResult).Any());
            vpResultService.Update(vpResult);
            if (vpResult.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, vpResultService.GetRead().Count());
            vpResultService.Delete(vpResult);
            if (vpResult.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, vpResultService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // vpResult.VPResultID   (Int32)
            //-----------------------------------
            vpResult = GetFilledRandomVPResult("");
            vpResult.VPResultID = 0;
            vpResultService.Update(vpResult);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.VPResultVPResultID), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "VPScenario", Plurial = "s", FieldID = "VPScenarioID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // vpResult.VPScenarioID   (Int32)
            //-----------------------------------
            // VPScenarioID will automatically be initialized at 0 --> not null


            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // VPScenarioID has Min [1] and Max [empty]. At Min should return true and no errors
            vpResult.VPScenarioID = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.VPScenarioID);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpResult.VPScenarioID = 2;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(2, vpResult.VPScenarioID);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpResult.VPScenarioID = 0;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPResultVPScenarioID, "1")).Any());
            Assert.AreEqual(0, vpResult.VPScenarioID);
            Assert.AreEqual(count, vpResultService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000)]
            // vpResult.Ordinal   (Int32)
            //-----------------------------------
            // Ordinal will automatically be initialized at 0 --> not null


            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            vpResult.Ordinal = 0;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            vpResult.Ordinal = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            vpResult.Ordinal = -1;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, vpResult.Ordinal);
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            vpResult.Ordinal = 1000;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1000, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            vpResult.Ordinal = 999;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(999, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            vpResult.Ordinal = 1001;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, vpResult.Ordinal);
            Assert.AreEqual(count, vpResultService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10000000)]
            // vpResult.Concentration_MPN_100ml   (Int32)
            //-----------------------------------
            // Concentration_MPN_100ml will automatically be initialized at 0 --> not null


            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            vpResult.Concentration_MPN_100ml = 0;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            vpResult.Concentration_MPN_100ml = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            vpResult.Concentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            vpResult.Concentration_MPN_100ml = 10000000;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(10000000, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            vpResult.Concentration_MPN_100ml = 9999999;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(9999999, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            vpResult.Concentration_MPN_100ml = 10000001;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(count, vpResultService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000000)]
            // vpResult.Dilution   (Double)
            //-----------------------------------
            //Error: Type not implemented [Dilution]


            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // Dilution has Min [0.0D] and Max [1000000.0D]. At Min should return true and no errors
            vpResult.Dilution = 0.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpResult.Dilution);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Dilution has Min [0.0D] and Max [1000000.0D]. At Min + 1 should return true and no errors
            vpResult.Dilution = 1.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpResult.Dilution);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Dilution has Min [0.0D] and Max [1000000.0D]. At Min - 1 should return false with one error
            vpResult.Dilution = -1.0D;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDilution, "0", "1000000")).Any());
            Assert.AreEqual(-1.0D, vpResult.Dilution);
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Dilution has Min [0.0D] and Max [1000000.0D]. At Max should return true and no errors
            vpResult.Dilution = 1000000.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1000000.0D, vpResult.Dilution);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Dilution has Min [0.0D] and Max [1000000.0D]. At Max - 1 should return true and no errors
            vpResult.Dilution = 999999.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(999999.0D, vpResult.Dilution);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // Dilution has Min [0.0D] and Max [1000000.0D]. At Max + 1 should return false with one error
            vpResult.Dilution = 1000001.0D;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDilution, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0D, vpResult.Dilution);
            Assert.AreEqual(count, vpResultService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10000)]
            // vpResult.FarFieldWidth_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [FarFieldWidth_m]


            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // FarFieldWidth_m has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            vpResult.FarFieldWidth_m = 0.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpResult.FarFieldWidth_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            vpResult.FarFieldWidth_m = 1.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpResult.FarFieldWidth_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            vpResult.FarFieldWidth_m = -1.0D;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultFarFieldWidth_m, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, vpResult.FarFieldWidth_m);
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            vpResult.FarFieldWidth_m = 10000.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(10000.0D, vpResult.FarFieldWidth_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            vpResult.FarFieldWidth_m = 9999.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(9999.0D, vpResult.FarFieldWidth_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            vpResult.FarFieldWidth_m = 10001.0D;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultFarFieldWidth_m, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, vpResult.FarFieldWidth_m);
            Assert.AreEqual(count, vpResultService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 100000)]
            // vpResult.DispersionDistance_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [DispersionDistance_m]


            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // DispersionDistance_m has Min [0.0D] and Max [100000.0D]. At Min should return true and no errors
            vpResult.DispersionDistance_m = 0.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpResult.DispersionDistance_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0.0D] and Max [100000.0D]. At Min + 1 should return true and no errors
            vpResult.DispersionDistance_m = 1.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpResult.DispersionDistance_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0.0D] and Max [100000.0D]. At Min - 1 should return false with one error
            vpResult.DispersionDistance_m = -1.0D;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDispersionDistance_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0D, vpResult.DispersionDistance_m);
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0.0D] and Max [100000.0D]. At Max should return true and no errors
            vpResult.DispersionDistance_m = 100000.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(100000.0D, vpResult.DispersionDistance_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0.0D] and Max [100000.0D]. At Max - 1 should return true and no errors
            vpResult.DispersionDistance_m = 99999.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(99999.0D, vpResult.DispersionDistance_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0.0D] and Max [100000.0D]. At Max + 1 should return false with one error
            vpResult.DispersionDistance_m = 100001.0D;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDispersionDistance_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0D, vpResult.DispersionDistance_m);
            Assert.AreEqual(count, vpResultService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 100)]
            // vpResult.TravelTime_hour   (Double)
            //-----------------------------------
            //Error: Type not implemented [TravelTime_hour]


            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // TravelTime_hour has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            vpResult.TravelTime_hour = 0.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpResult.TravelTime_hour);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            vpResult.TravelTime_hour = 1.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpResult.TravelTime_hour);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            vpResult.TravelTime_hour = -1.0D;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultTravelTime_hour, "0", "100")).Any());
            Assert.AreEqual(-1.0D, vpResult.TravelTime_hour);
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            vpResult.TravelTime_hour = 100.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(100.0D, vpResult.TravelTime_hour);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            vpResult.TravelTime_hour = 99.0D;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(99.0D, vpResult.TravelTime_hour);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            vpResult.TravelTime_hour = 101.0D;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultTravelTime_hour, "0", "100")).Any());
            Assert.AreEqual(101.0D, vpResult.TravelTime_hour);
            Assert.AreEqual(count, vpResultService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // vpResult.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // vpResult.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpResult.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpResult.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(2, vpResult.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(count, vpResultService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpResult.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPResultLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, vpResult.LastUpdateContactTVItemID);
            Assert.AreEqual(count, vpResultService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // vpResult.VPScenario   (VPScenario)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // vpResult.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
