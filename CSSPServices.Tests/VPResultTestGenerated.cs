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

            if (OmitPropName != "VPScenarioID") vpResult.VPScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "Ordinal") vpResult.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "Concentration_MPN_100ml") vpResult.Concentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Dilution") vpResult.Dilution = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "FarFieldWidth_m") vpResult.FarFieldWidth_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "DispersionDistance_m") vpResult.DispersionDistance_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TravelTime_hour") vpResult.TravelTime_hour = GetRandomDouble(1.0D, 1000.0D);
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
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // VPScenarioID will automatically be initialized at 0 --> not null

            // Ordinal will automatically be initialized at 0 --> not null

            // Concentration_MPN_100ml will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Dilution]

            //Error: Type not implemented [FarFieldWidth_m]

            //Error: Type not implemented [DispersionDistance_m]

            //Error: Type not implemented [TravelTime_hour]

            vpResult = null;
            vpResult = GetFilledRandomVPResult("LastUpdateDate_UTC");
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.AreEqual(1, vpResult.ValidationResults.Count());
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPResultLastUpdateDate_UTC)).Any());
            Assert.IsTrue(vpResult.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [VPScenario]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [VPResultID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPScenarioID] of type [Int32]
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
            // doing property [Ordinal] of type [Int32]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            vpResult.Ordinal = 0;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            vpResult.Ordinal = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            vpResult.Ordinal = -1;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, vpResult.Ordinal);
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            vpResult.Ordinal = 1000;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1000, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            vpResult.Ordinal = 999;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(999, vpResult.Ordinal);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            vpResult.Ordinal = 1001;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, vpResult.Ordinal);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            //-----------------------------------
            // doing property [Concentration_MPN_100ml] of type [Int32]
            //-----------------------------------

            vpResult = null;
            vpResult = GetFilledRandomVPResult("");
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            vpResult.Concentration_MPN_100ml = 0;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(0, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            vpResult.Concentration_MPN_100ml = 1;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(1, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            vpResult.Concentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            vpResult.Concentration_MPN_100ml = 10000000;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(10000000, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            vpResult.Concentration_MPN_100ml = 9999999;
            Assert.AreEqual(true, vpResultService.Add(vpResult));
            Assert.AreEqual(0, vpResult.ValidationResults.Count());
            Assert.AreEqual(9999999, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(true, vpResultService.Delete(vpResult));
            Assert.AreEqual(0, vpResultService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            vpResult.Concentration_MPN_100ml = 10000001;
            Assert.AreEqual(false, vpResultService.Add(vpResult));
            Assert.IsTrue(vpResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPResultConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, vpResult.Concentration_MPN_100ml);
            Assert.AreEqual(0, vpResultService.GetRead().Count());

            //-----------------------------------
            // doing property [Dilution] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [FarFieldWidth_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [DispersionDistance_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TravelTime_hour] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [VPScenario] of type [VPScenario]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
