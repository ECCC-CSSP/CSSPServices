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
        private int VPResultID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPResult GetFilledRandomVPResult(string OmitPropName)
        {
            VPResultID += 1;

            VPResult vpResult = new VPResult();

            if (OmitPropName != "VPResultID") vpResult.VPResultID = VPResultID;
            if (OmitPropName != "VPScenarioID") vpResult.VPScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "Ordinal") vpResult.Ordinal = GetRandomInt(0, 100);
            if (OmitPropName != "Concentration_MPN_100ml") vpResult.Concentration_MPN_100ml = GetRandomInt(0, 20000000);
            if (OmitPropName != "Dilution") vpResult.Dilution = GetRandomFloat(0, 1000000);
            if (OmitPropName != "FarFieldWidth_m") vpResult.FarFieldWidth_m = GetRandomFloat(0, 100000);
            if (OmitPropName != "DispersionDistance_m") vpResult.DispersionDistance_m = GetRandomFloat(0, 100000);
            if (OmitPropName != "TravelTime_hour") vpResult.TravelTime_hour = GetRandomFloat(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") vpResult.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpResult.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return vpResult;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPResult_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            VPResultService vpResultService = new VPResultService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            VPResult vpResult = GetFilledRandomVPResult("");
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(true, vpResultService.GetRead().Where(c => c == vpResult).Any());
            vpResult.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, vpResultService.Update(vpResult));
            Assert.AreEqual(1, vpResultService.GetRead().Count());
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // VPScenarioID will automatically be initialized at 0 --> not null

            // Ordinal will automatically be initialized at 0 --> not null

            // Concentration_MPN_100ml will automatically be initialized at 0 --> not null

            // Dilution will automatically be initialized at 0.0f --> not null

            // FarFieldWidth_m will automatically be initialized at 0.0f --> not null

            // DispersionDistance_m will automatically be initialized at 0.0f --> not null

            // TravelTime_hour will automatically be initialized at 0.0f --> not null

            vpResult = null;
            vpResult = GetFilledRandomVPResult("LastUpdateDate_UTC");
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.AreEqual(1, vpResult.ValidationResults.Count());
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPResultLastUpdateDate_UTC)).Any());
            Assert.IsTrue(vpResult.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [VPResultID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPScenarioID] of type [int]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // VPScenarioID has Min [1] and Max [empty]. At Min should return true and no errors
            vpResult.VPScenarioID = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.VPScenarioID);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpResult.VPScenarioID = 2;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(2, vpResult.VPScenarioID);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpResult.VPScenarioID = 0;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPResultVPScenarioID, "1")).Any());
            Assert.AreEqual(0, vpResult.VPScenarioID);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            //-----------------------------------
            // doing property [Ordinal] of type [int]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // Ordinal has Min [0] and Max [100]. At Min should return true and no errors
            vpResult.Ordinal = 0;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Min + 1 should return true and no errors
            vpResult.Ordinal = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Min - 1 should return false with one error
            vpResult.Ordinal = -1;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultOrdinal, "0", "100")).Any());
            Assert.AreEqual(-1, vpResult.Ordinal);
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Max should return true and no errors
            vpResult.Ordinal = 100;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(100, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Max - 1 should return true and no errors
            vpResult.Ordinal = 99;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(99, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Max + 1 should return false with one error
            vpResult.Ordinal = 101;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultOrdinal, "0", "100")).Any());
            Assert.AreEqual(101, vpResult.Ordinal);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            //-----------------------------------
            // doing property [Concentration_MPN_100ml] of type [int]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Min should return true and no errors
            vpResult.Concentration_MPN_100ml = 0;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Min + 1 should return true and no errors
            vpResult.Concentration_MPN_100ml = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Min - 1 should return false with one error
            vpResult.Concentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultConcentration_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(-1, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Max should return true and no errors
            vpResult.Concentration_MPN_100ml = 20000000;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(20000000, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Max - 1 should return true and no errors
            vpResult.Concentration_MPN_100ml = 19999999;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(19999999, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Max + 1 should return false with one error
            vpResult.Concentration_MPN_100ml = 20000001;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultConcentration_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(20000001, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            //-----------------------------------
            // doing property [Dilution] of type [float]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // Dilution has Min [0] and Max [1000000]. At Min should return true and no errors
            vpResult.Dilution = 0.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpResult.Dilution);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            vpResult.Dilution = 1.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpResult.Dilution);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            vpResult.Dilution = -1.0f;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDilution, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, vpResult.Dilution);
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Max should return true and no errors
            vpResult.Dilution = 1000000.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, vpResult.Dilution);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            vpResult.Dilution = 999999.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(999999.0f, vpResult.Dilution);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            vpResult.Dilution = 1000001.0f;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDilution, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, vpResult.Dilution);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            //-----------------------------------
            // doing property [FarFieldWidth_m] of type [float]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // FarFieldWidth_m has Min [0] and Max [100000]. At Min should return true and no errors
            vpResult.FarFieldWidth_m = 0.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpResult.FarFieldWidth_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            vpResult.FarFieldWidth_m = 1.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpResult.FarFieldWidth_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0] and Max [100000]. At Min - 1 should return false with one error
            vpResult.FarFieldWidth_m = -1.0f;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultFarFieldWidth_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0f, vpResult.FarFieldWidth_m);
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0] and Max [100000]. At Max should return true and no errors
            vpResult.FarFieldWidth_m = 100000.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(100000.0f, vpResult.FarFieldWidth_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            vpResult.FarFieldWidth_m = 99999.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(99999.0f, vpResult.FarFieldWidth_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // FarFieldWidth_m has Min [0] and Max [100000]. At Max + 1 should return false with one error
            vpResult.FarFieldWidth_m = 100001.0f;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultFarFieldWidth_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0f, vpResult.FarFieldWidth_m);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            //-----------------------------------
            // doing property [DispersionDistance_m] of type [float]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // DispersionDistance_m has Min [0] and Max [100000]. At Min should return true and no errors
            vpResult.DispersionDistance_m = 0.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpResult.DispersionDistance_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            vpResult.DispersionDistance_m = 1.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpResult.DispersionDistance_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0] and Max [100000]. At Min - 1 should return false with one error
            vpResult.DispersionDistance_m = -1.0f;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDispersionDistance_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0f, vpResult.DispersionDistance_m);
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0] and Max [100000]. At Max should return true and no errors
            vpResult.DispersionDistance_m = 100000.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(100000.0f, vpResult.DispersionDistance_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            vpResult.DispersionDistance_m = 99999.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(99999.0f, vpResult.DispersionDistance_m);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // DispersionDistance_m has Min [0] and Max [100000]. At Max + 1 should return false with one error
            vpResult.DispersionDistance_m = 100001.0f;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultDispersionDistance_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0f, vpResult.DispersionDistance_m);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            //-----------------------------------
            // doing property [TravelTime_hour] of type [float]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // TravelTime_hour has Min [0] and Max [1000]. At Min should return true and no errors
            vpResult.TravelTime_hour = 0.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpResult.TravelTime_hour);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            vpResult.TravelTime_hour = 1.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpResult.TravelTime_hour);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0] and Max [1000]. At Min - 1 should return false with one error
            vpResult.TravelTime_hour = -1.0f;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultTravelTime_hour, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, vpResult.TravelTime_hour);
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0] and Max [1000]. At Max should return true and no errors
            vpResult.TravelTime_hour = 1000.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1000.0f, vpResult.TravelTime_hour);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            vpResult.TravelTime_hour = 999.0f;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(999.0f, vpResult.TravelTime_hour);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // TravelTime_hour has Min [0] and Max [1000]. At Max + 1 should return false with one error
            vpResult.TravelTime_hour = 1001.0f;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultTravelTime_hour, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, vpResult.TravelTime_hour);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpResult.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpResult.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(2, vpResult.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpResult.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPResultLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, vpResult.LastUpdateContactTVItemID);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
