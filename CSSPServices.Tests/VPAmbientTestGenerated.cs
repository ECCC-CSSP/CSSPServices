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
        private int VPAmbientID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPAmbient GetFilledRandomVPAmbient(string OmitPropName)
        {
            VPAmbientID += 1;

            VPAmbient vpAmbient = new VPAmbient();

            if (OmitPropName != "VPAmbientID") vpAmbient.VPAmbientID = VPAmbientID;
            if (OmitPropName != "VPScenarioID") vpAmbient.VPScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "Row") vpAmbient.Row = GetRandomInt(0, 10);
            if (OmitPropName != "MeasurementDepth_m") vpAmbient.MeasurementDepth_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "CurrentSpeed_m_s") vpAmbient.CurrentSpeed_m_s = GetRandomFloat(0, 10);
            if (OmitPropName != "CurrentDirection_deg") vpAmbient.CurrentDirection_deg = GetRandomFloat(-180, 180);
            if (OmitPropName != "AmbientSalinity_PSU") vpAmbient.AmbientSalinity_PSU = GetRandomFloat(0, 40);
            if (OmitPropName != "AmbientTemperature_C") vpAmbient.AmbientTemperature_C = GetRandomFloat(-10, 40);
            if (OmitPropName != "BackgroundConcentration_MPN_100ml") vpAmbient.BackgroundConcentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "PollutantDecayRate_per_day") vpAmbient.PollutantDecayRate_per_day = GetRandomFloat(0, 100);
            if (OmitPropName != "FarFieldCurrentSpeed_m_s") vpAmbient.FarFieldCurrentSpeed_m_s = GetRandomFloat(0, 10);
            if (OmitPropName != "FarFieldCurrentDirection_deg") vpAmbient.FarFieldCurrentDirection_deg = GetRandomFloat(-180, 180);
            if (OmitPropName != "FarFieldDiffusionCoefficient") vpAmbient.FarFieldDiffusionCoefficient = GetRandomFloat(0, 1);
            if (OmitPropName != "LastUpdateDate_UTC") vpAmbient.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpAmbient.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return vpAmbient;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPAmbient_Testing()
        {
            SetupTestHelper(culture);
            VPAmbientService vpAmbientService = new VPAmbientService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            VPAmbient vpAmbient = GetFilledRandomVPAmbient("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(true, vpAmbientService.GetRead().Where(c => c == vpAmbient).Any());
            vpAmbient.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, vpAmbientService.Update(vpAmbient));
            Assert.AreEqual(1, vpAmbientService.GetRead().Count());
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // VPScenarioID will automatically be initialized at 0 --> not null

            // Row will automatically be initialized at 0 --> not null

            // MeasurementDepth_m will automatically be initialized at 0 --> not null

            // CurrentSpeed_m_s will automatically be initialized at 0 --> not null

            // CurrentDirection_deg will automatically be initialized at 0 --> not null

            // AmbientSalinity_PSU will automatically be initialized at 0 --> not null

            // AmbientTemperature_C will automatically be initialized at 0 --> not null

            // BackgroundConcentration_MPN_100ml will automatically be initialized at 0 --> not null

            // PollutantDecayRate_per_day will automatically be initialized at 0 --> not null

            // FarFieldCurrentSpeed_m_s will automatically be initialized at 0 --> not null

            // FarFieldCurrentDirection_deg will automatically be initialized at 0 --> not null

            // FarFieldDiffusionCoefficient will automatically be initialized at 0 --> not null

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
            // doing property [MeasurementDepth_m] of type [Single]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // MeasurementDepth_m has Min [0] and Max [1000]. At Min should return true and no errors
            vpAmbient.MeasurementDepth_m = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            vpAmbient.MeasurementDepth_m = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            vpAmbient.MeasurementDepth_m = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientMeasurementDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0] and Max [1000]. At Max should return true and no errors
            vpAmbient.MeasurementDepth_m = 1000.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1000.0f, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            vpAmbient.MeasurementDepth_m = 999.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(999.0f, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            vpAmbient.MeasurementDepth_m = 1001.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientMeasurementDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [CurrentSpeed_m_s] of type [Single]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // CurrentSpeed_m_s has Min [0] and Max [10]. At Min should return true and no errors
            vpAmbient.CurrentSpeed_m_s = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0] and Max [10]. At Min + 1 should return true and no errors
            vpAmbient.CurrentSpeed_m_s = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0] and Max [10]. At Min - 1 should return false with one error
            vpAmbient.CurrentSpeed_m_s = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0] and Max [10]. At Max should return true and no errors
            vpAmbient.CurrentSpeed_m_s = 10.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(10.0f, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0] and Max [10]. At Max - 1 should return true and no errors
            vpAmbient.CurrentSpeed_m_s = 9.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(9.0f, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0] and Max [10]. At Max + 1 should return false with one error
            vpAmbient.CurrentSpeed_m_s = 11.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0f, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [CurrentDirection_deg] of type [Single]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // CurrentDirection_deg has Min [-180] and Max [180]. At Min should return true and no errors
            vpAmbient.CurrentDirection_deg = -180.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-180.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            vpAmbient.CurrentDirection_deg = -179.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-179.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180] and Max [180]. At Min - 1 should return false with one error
            vpAmbient.CurrentDirection_deg = -181.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180] and Max [180]. At Max should return true and no errors
            vpAmbient.CurrentDirection_deg = 180.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(180.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            vpAmbient.CurrentDirection_deg = 179.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(179.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180] and Max [180]. At Max + 1 should return false with one error
            vpAmbient.CurrentDirection_deg = 181.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "-180", "180")).Any());
            Assert.AreEqual(181.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [AmbientSalinity_PSU] of type [Single]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Min should return true and no errors
            vpAmbient.AmbientSalinity_PSU = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Min + 1 should return true and no errors
            vpAmbient.AmbientSalinity_PSU = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Min - 1 should return false with one error
            vpAmbient.AmbientSalinity_PSU = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Max should return true and no errors
            vpAmbient.AmbientSalinity_PSU = 40.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(40.0f, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Max - 1 should return true and no errors
            vpAmbient.AmbientSalinity_PSU = 39.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(39.0f, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Max + 1 should return false with one error
            vpAmbient.AmbientSalinity_PSU = 41.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0f, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [AmbientTemperature_C] of type [Single]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // AmbientTemperature_C has Min [-10] and Max [40]. At Min should return true and no errors
            vpAmbient.AmbientTemperature_C = -10.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-10.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Min + 1 should return true and no errors
            vpAmbient.AmbientTemperature_C = -9.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-9.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Min - 1 should return false with one error
            vpAmbient.AmbientTemperature_C = -11.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Max should return true and no errors
            vpAmbient.AmbientTemperature_C = 40.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(40.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Max - 1 should return true and no errors
            vpAmbient.AmbientTemperature_C = 39.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(39.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Max + 1 should return false with one error
            vpAmbient.AmbientTemperature_C = 41.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(41.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

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
            // doing property [PollutantDecayRate_per_day] of type [Single]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // PollutantDecayRate_per_day has Min [0] and Max [100]. At Min should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [100]. At Min + 1 should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [100]. At Min - 1 should return false with one error
            vpAmbient.PollutantDecayRate_per_day = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "100")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [100]. At Max should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 100.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(100.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [100]. At Max - 1 should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 99.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(99.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [100]. At Max + 1 should return false with one error
            vpAmbient.PollutantDecayRate_per_day = 101.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "100")).Any());
            Assert.AreEqual(101.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [FarFieldCurrentSpeed_m_s] of type [Single]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // FarFieldCurrentSpeed_m_s has Min [0] and Max [10]. At Min should return true and no errors
            vpAmbient.FarFieldCurrentSpeed_m_s = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0] and Max [10]. At Min + 1 should return true and no errors
            vpAmbient.FarFieldCurrentSpeed_m_s = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0] and Max [10]. At Min - 1 should return false with one error
            vpAmbient.FarFieldCurrentSpeed_m_s = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0] and Max [10]. At Max should return true and no errors
            vpAmbient.FarFieldCurrentSpeed_m_s = 10.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(10.0f, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0] and Max [10]. At Max - 1 should return true and no errors
            vpAmbient.FarFieldCurrentSpeed_m_s = 9.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(9.0f, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0] and Max [10]. At Max + 1 should return false with one error
            vpAmbient.FarFieldCurrentSpeed_m_s = 11.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0f, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [FarFieldCurrentDirection_deg] of type [Single]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // FarFieldCurrentDirection_deg has Min [-180] and Max [180]. At Min should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = -180.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-180.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = -179.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-179.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180] and Max [180]. At Min - 1 should return false with one error
            vpAmbient.FarFieldCurrentDirection_deg = -181.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180] and Max [180]. At Max should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = 180.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(180.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = 179.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(179.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180] and Max [180]. At Max + 1 should return false with one error
            vpAmbient.FarFieldCurrentDirection_deg = 181.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "-180", "180")).Any());
            Assert.AreEqual(181.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [FarFieldDiffusionCoefficient] of type [Single]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // FarFieldDiffusionCoefficient has Min [0] and Max [1]. At Min should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [1]. At Min + 1 should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [1]. At Min - 1 should return false with one error
            vpAmbient.FarFieldDiffusionCoefficient = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "1")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [1]. At Max should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [1]. At Max - 1 should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [1]. At Max + 1 should return false with one error
            vpAmbient.FarFieldDiffusionCoefficient = 2.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "1")).Any());
            Assert.AreEqual(2.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

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
