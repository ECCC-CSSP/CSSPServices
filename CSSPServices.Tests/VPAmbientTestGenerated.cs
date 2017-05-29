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
            if (OmitPropName != "Row") vpAmbient.Row = GetRandomInt(1, 8);
            if (OmitPropName != "MeasurementDepth_m") vpAmbient.MeasurementDepth_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "CurrentSpeed_m_s") vpAmbient.CurrentSpeed_m_s = GetRandomFloat(0, 10);
            if (OmitPropName != "CurrentDirection_deg") vpAmbient.CurrentDirection_deg = GetRandomFloat(0, 360);
            if (OmitPropName != "AmbientSalinity_PSU") vpAmbient.AmbientSalinity_PSU = GetRandomFloat(0, 40);
            if (OmitPropName != "AmbientTemperature_C") vpAmbient.AmbientTemperature_C = GetRandomFloat(0, 50);
            if (OmitPropName != "BackgroundConcentration_MPN_100ml") vpAmbient.BackgroundConcentration_MPN_100ml = GetRandomInt(0, 100000000);
            if (OmitPropName != "PollutantDecayRate_per_day") vpAmbient.PollutantDecayRate_per_day = GetRandomFloat(0, 1000);
            if (OmitPropName != "FarFieldCurrentSpeed_m_s") vpAmbient.FarFieldCurrentSpeed_m_s = GetRandomFloat(0, 10);
            if (OmitPropName != "FarFieldCurrentDirection_deg") vpAmbient.FarFieldCurrentDirection_deg = GetRandomFloat(0, 360);
            if (OmitPropName != "FarFieldDiffusionCoefficient") vpAmbient.FarFieldDiffusionCoefficient = GetRandomFloat(0, 10);
            if (OmitPropName != "LastUpdateDate_UTC") vpAmbient.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpAmbient.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return vpAmbient;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPAmbient_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            VPAmbientService vpAmbientService = new VPAmbientService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            VPAmbient vpAmbient = GetFilledRandomVPAmbient("");
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

            // MeasurementDepth_m will automatically be initialized at 0.0f --> not null

            // CurrentSpeed_m_s will automatically be initialized at 0.0f --> not null

            // CurrentDirection_deg will automatically be initialized at 0.0f --> not null

            // AmbientSalinity_PSU will automatically be initialized at 0.0f --> not null

            // AmbientTemperature_C will automatically be initialized at 0.0f --> not null

            // BackgroundConcentration_MPN_100ml will automatically be initialized at 0 --> not null

            // PollutantDecayRate_per_day will automatically be initialized at 0.0f --> not null

            // FarFieldCurrentSpeed_m_s will automatically be initialized at 0.0f --> not null

            // FarFieldCurrentDirection_deg will automatically be initialized at 0.0f --> not null

            // FarFieldDiffusionCoefficient will automatically be initialized at 0.0f --> not null

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("LastUpdateDate_UTC");
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(1, vpAmbient.ValidationResults.Count());
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPAmbientLastUpdateDate_UTC)).Any());
            Assert.IsTrue(vpAmbient.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [VPAmbientID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPScenarioID] of type [int]
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
            // doing property [Row] of type [int]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // Row has Min [1] and Max [8]. At Min should return true and no errors
            vpAmbient.Row = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [1] and Max [8]. At Min + 1 should return true and no errors
            vpAmbient.Row = 2;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(2, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [1] and Max [8]. At Min - 1 should return false with one error
            vpAmbient.Row = 0;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "1", "8")).Any());
            Assert.AreEqual(0, vpAmbient.Row);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [1] and Max [8]. At Max should return true and no errors
            vpAmbient.Row = 8;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(8, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [1] and Max [8]. At Max - 1 should return true and no errors
            vpAmbient.Row = 7;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(7, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // Row has Min [1] and Max [8]. At Max + 1 should return false with one error
            vpAmbient.Row = 9;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "1", "8")).Any());
            Assert.AreEqual(9, vpAmbient.Row);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [MeasurementDepth_m] of type [float]
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
            // doing property [CurrentSpeed_m_s] of type [float]
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
            // doing property [CurrentDirection_deg] of type [float]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // CurrentDirection_deg has Min [0] and Max [360]. At Min should return true and no errors
            vpAmbient.CurrentDirection_deg = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [0] and Max [360]. At Min + 1 should return true and no errors
            vpAmbient.CurrentDirection_deg = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [0] and Max [360]. At Min - 1 should return false with one error
            vpAmbient.CurrentDirection_deg = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "0", "360")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [0] and Max [360]. At Max should return true and no errors
            vpAmbient.CurrentDirection_deg = 360.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(360.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [0] and Max [360]. At Max - 1 should return true and no errors
            vpAmbient.CurrentDirection_deg = 359.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(359.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [0] and Max [360]. At Max + 1 should return false with one error
            vpAmbient.CurrentDirection_deg = 361.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "0", "360")).Any());
            Assert.AreEqual(361.0f, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [AmbientSalinity_PSU] of type [float]
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
            // doing property [AmbientTemperature_C] of type [float]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // AmbientTemperature_C has Min [0] and Max [50]. At Min should return true and no errors
            vpAmbient.AmbientTemperature_C = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Min + 1 should return true and no errors
            vpAmbient.AmbientTemperature_C = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Min - 1 should return false with one error
            vpAmbient.AmbientTemperature_C = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "0", "50")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Max should return true and no errors
            vpAmbient.AmbientTemperature_C = 50.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(50.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Max - 1 should return true and no errors
            vpAmbient.AmbientTemperature_C = 49.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(49.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Max + 1 should return false with one error
            vpAmbient.AmbientTemperature_C = 51.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "0", "50")).Any());
            Assert.AreEqual(51.0f, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [BackgroundConcentration_MPN_100ml] of type [int]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [100000000]. At Min should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 0;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [100000000]. At Min + 1 should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [100000000]. At Min - 1 should return false with one error
            vpAmbient.BackgroundConcentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "100000000")).Any());
            Assert.AreEqual(-1, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [100000000]. At Max should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 100000000;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(100000000, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [100000000]. At Max - 1 should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 99999999;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(99999999, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [100000000]. At Max + 1 should return false with one error
            vpAmbient.BackgroundConcentration_MPN_100ml = 100000001;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "100000000")).Any());
            Assert.AreEqual(100000001, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [PollutantDecayRate_per_day] of type [float]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // PollutantDecayRate_per_day has Min [0] and Max [1000]. At Min should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [1000]. At Min - 1 should return false with one error
            vpAmbient.PollutantDecayRate_per_day = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [1000]. At Max should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 1000.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1000.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 999.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(999.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0] and Max [1000]. At Max + 1 should return false with one error
            vpAmbient.PollutantDecayRate_per_day = 1001.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [FarFieldCurrentSpeed_m_s] of type [float]
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
            // doing property [FarFieldCurrentDirection_deg] of type [float]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // FarFieldCurrentDirection_deg has Min [0] and Max [360]. At Min should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [0] and Max [360]. At Min + 1 should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [0] and Max [360]. At Min - 1 should return false with one error
            vpAmbient.FarFieldCurrentDirection_deg = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "0", "360")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [0] and Max [360]. At Max should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = 360.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(360.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [0] and Max [360]. At Max - 1 should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = 359.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(359.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [0] and Max [360]. At Max + 1 should return false with one error
            vpAmbient.FarFieldCurrentDirection_deg = 361.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "0", "360")).Any());
            Assert.AreEqual(361.0f, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [FarFieldDiffusionCoefficient] of type [float]
            //-----------------------------------

            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // FarFieldDiffusionCoefficient has Min [0] and Max [10]. At Min should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 0.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [10]. At Min + 1 should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 1.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [10]. At Min - 1 should return false with one error
            vpAmbient.FarFieldDiffusionCoefficient = -1.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "10")).Any());
            Assert.AreEqual(-1.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [10]. At Max should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 10.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(10.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [10]. At Max - 1 should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 9.0f;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(9.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0] and Max [10]. At Max + 1 should return false with one error
            vpAmbient.FarFieldDiffusionCoefficient = 11.0f;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "10")).Any());
            Assert.AreEqual(11.0f, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(0, vpAmbientService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
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

        }
        #endregion Tests Generated
    }
}
