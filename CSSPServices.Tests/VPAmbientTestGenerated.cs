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
    public partial class VPAmbientTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private VPAmbientService vpAmbientService { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientTest() : base()
        {
            vpAmbientService = new VPAmbientService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPAmbient GetFilledRandomVPAmbient(string OmitPropName)
        {
            VPAmbient vpAmbient = new VPAmbient();

            if (OmitPropName != "VPScenarioID") vpAmbient.VPScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "Row") vpAmbient.Row = GetRandomInt(0, 10);
            if (OmitPropName != "MeasurementDepth_m") vpAmbient.MeasurementDepth_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "CurrentSpeed_m_s") vpAmbient.CurrentSpeed_m_s = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "CurrentDirection_deg") vpAmbient.CurrentDirection_deg = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "AmbientSalinity_PSU") vpAmbient.AmbientSalinity_PSU = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "AmbientTemperature_C") vpAmbient.AmbientTemperature_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "BackgroundConcentration_MPN_100ml") vpAmbient.BackgroundConcentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "PollutantDecayRate_per_day") vpAmbient.PollutantDecayRate_per_day = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "FarFieldCurrentSpeed_m_s") vpAmbient.FarFieldCurrentSpeed_m_s = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "FarFieldCurrentDirection_deg") vpAmbient.FarFieldCurrentDirection_deg = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "FarFieldDiffusionCoefficient") vpAmbient.FarFieldDiffusionCoefficient = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") vpAmbient.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpAmbient.LastUpdateContactTVItemID = 2;

            return vpAmbient;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPAmbient_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            VPAmbient vpAmbient = GetFilledRandomVPAmbient("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = vpAmbientService.GetRead().Count();

            vpAmbientService.Add(vpAmbient);
            if (vpAmbient.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, vpAmbientService.GetRead().Where(c => c == vpAmbient).Any());
            vpAmbientService.Update(vpAmbient);
            if (vpAmbient.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, vpAmbientService.GetRead().Count());
            vpAmbientService.Delete(vpAmbient);
            if (vpAmbient.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // VPScenarioID will automatically be initialized at 0 --> not null

            // Row will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MeasurementDepth_m]

            //Error: Type not implemented [CurrentSpeed_m_s]

            //Error: Type not implemented [CurrentDirection_deg]

            //Error: Type not implemented [AmbientSalinity_PSU]

            //Error: Type not implemented [AmbientTemperature_C]

            // BackgroundConcentration_MPN_100ml will automatically be initialized at 0 --> not null

            //Error: Type not implemented [PollutantDecayRate_per_day]

            //Error: Type not implemented [FarFieldCurrentSpeed_m_s]

            //Error: Type not implemented [FarFieldCurrentDirection_deg]

            //Error: Type not implemented [FarFieldDiffusionCoefficient]

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("LastUpdateDate_UTC");
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(1, vpAmbient.ValidationResults.Count());
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPAmbientLastUpdateDate_UTC)).Any());
            Assert.IsTrue(vpAmbient.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [VPScenario]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [VPAmbientID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPScenarioID] of type [Int32]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // VPScenarioID has Min [1] and Max [empty]. At Min should return true and no errors
            vpAmbient.VPScenarioID = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.VPScenarioID);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpAmbient.VPScenarioID = 2;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(2, vpAmbient.VPScenarioID);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpAmbient.VPScenarioID = 0;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPAmbientVPScenarioID, "1")).Any());
            Assert.AreEqual(0, vpAmbient.VPScenarioID);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [Row] of type [Int32]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // Row has Min [0] and Max [10]. At Min should return true and no errors
            vpAmbient.Row = 0;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Min + 1 should return true and no errors
            vpAmbient.Row = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Min - 1 should return false with one error
            vpAmbient.Row = -1;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "0", "10")).Any());
            Assert.AreEqual(-1, vpAmbient.Row);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Max should return true and no errors
            vpAmbient.Row = 10;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(10, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Max - 1 should return true and no errors
            vpAmbient.Row = 9;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(9, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Max + 1 should return false with one error
            vpAmbient.Row = 11;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "0", "10")).Any());
            Assert.AreEqual(11, vpAmbient.Row);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [MeasurementDepth_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [CurrentSpeed_m_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [CurrentDirection_deg] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [AmbientSalinity_PSU] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [AmbientTemperature_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [BackgroundConcentration_MPN_100ml] of type [Int32]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 0;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            vpAmbient.BackgroundConcentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 10000000;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(10000000, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 9999999;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(9999999, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            vpAmbient.BackgroundConcentration_MPN_100ml = 10000001;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [PollutantDecayRate_per_day] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [FarFieldCurrentSpeed_m_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [FarFieldCurrentDirection_deg] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [FarFieldDiffusionCoefficient] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpAmbient.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpAmbient.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(2, vpAmbient.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpAmbient.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPAmbientLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, vpAmbient.LastUpdateContactTVItemID);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

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
