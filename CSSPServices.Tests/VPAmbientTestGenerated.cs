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

            if (OmitPropName != "VPScenarioID") vpAmbient.VPScenarioID = 1;
            if (OmitPropName != "Row") vpAmbient.Row = GetRandomInt(0, 10);
            if (OmitPropName != "MeasurementDepth_m") vpAmbient.MeasurementDepth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "CurrentSpeed_m_s") vpAmbient.CurrentSpeed_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CurrentDirection_deg") vpAmbient.CurrentDirection_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "AmbientSalinity_PSU") vpAmbient.AmbientSalinity_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "AmbientTemperature_C") vpAmbient.AmbientTemperature_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "BackgroundConcentration_MPN_100ml") vpAmbient.BackgroundConcentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "PollutantDecayRate_per_day") vpAmbient.PollutantDecayRate_per_day = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "FarFieldCurrentSpeed_m_s") vpAmbient.FarFieldCurrentSpeed_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "FarFieldCurrentDirection_deg") vpAmbient.FarFieldCurrentDirection_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "FarFieldDiffusionCoefficient") vpAmbient.FarFieldDiffusionCoefficient = GetRandomDouble(0.0D, 1.0D);
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
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // vpAmbient.VPAmbientID   (Int32)
            //-----------------------------------
            vpAmbient = GetFilledRandomVPAmbient("");
            vpAmbient.VPAmbientID = 0;
            vpAmbientService.Update(vpAmbient);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.VPAmbientVPAmbientID), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "VPScenario", Plurial = "s", FieldID = "VPScenarioID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // vpAmbient.VPScenarioID   (Int32)
            //-----------------------------------
            // VPScenarioID will automatically be initialized at 0 --> not null


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // VPScenarioID has Min [1] and Max [empty]. At Min should return true and no errors
            vpAmbient.VPScenarioID = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.VPScenarioID);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpAmbient.VPScenarioID = 2;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(2, vpAmbient.VPScenarioID);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpAmbient.VPScenarioID = 0;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPAmbientVPScenarioID, "1")).Any());
            Assert.AreEqual(0, vpAmbient.VPScenarioID);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10)]
            // vpAmbient.Row   (Int32)
            //-----------------------------------
            // Row will automatically be initialized at 0 --> not null


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // Row has Min [0] and Max [10]. At Min should return true and no errors
            vpAmbient.Row = 0;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Min + 1 should return true and no errors
            vpAmbient.Row = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Min - 1 should return false with one error
            vpAmbient.Row = -1;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "0", "10")).Any());
            Assert.AreEqual(-1, vpAmbient.Row);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Max should return true and no errors
            vpAmbient.Row = 10;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(10, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Max - 1 should return true and no errors
            vpAmbient.Row = 9;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(9, vpAmbient.Row);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // Row has Min [0] and Max [10]. At Max + 1 should return false with one error
            vpAmbient.Row = 11;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "0", "10")).Any());
            Assert.AreEqual(11, vpAmbient.Row);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000)]
            // vpAmbient.MeasurementDepth_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [MeasurementDepth_m]


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // MeasurementDepth_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            vpAmbient.MeasurementDepth_m = 0.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            vpAmbient.MeasurementDepth_m = 1.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            vpAmbient.MeasurementDepth_m = -1.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientMeasurementDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            vpAmbient.MeasurementDepth_m = 1000.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1000.0D, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            vpAmbient.MeasurementDepth_m = 999.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(999.0D, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // MeasurementDepth_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            vpAmbient.MeasurementDepth_m = 1001.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientMeasurementDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, vpAmbient.MeasurementDepth_m);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10)]
            // vpAmbient.CurrentSpeed_m_s   (Double)
            //-----------------------------------
            //Error: Type not implemented [CurrentSpeed_m_s]


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // CurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Min should return true and no errors
            vpAmbient.CurrentSpeed_m_s = 0.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Min + 1 should return true and no errors
            vpAmbient.CurrentSpeed_m_s = 1.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Min - 1 should return false with one error
            vpAmbient.CurrentSpeed_m_s = -1.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0D, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Max should return true and no errors
            vpAmbient.CurrentSpeed_m_s = 10.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(10.0D, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Max - 1 should return true and no errors
            vpAmbient.CurrentSpeed_m_s = 9.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(9.0D, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Max + 1 should return false with one error
            vpAmbient.CurrentSpeed_m_s = 11.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0D, vpAmbient.CurrentSpeed_m_s);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-180, 180)]
            // vpAmbient.CurrentDirection_deg   (Double)
            //-----------------------------------
            //Error: Type not implemented [CurrentDirection_deg]


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // CurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            vpAmbient.CurrentDirection_deg = -180.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-180.0D, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            vpAmbient.CurrentDirection_deg = -179.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-179.0D, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            vpAmbient.CurrentDirection_deg = -181.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            vpAmbient.CurrentDirection_deg = 180.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(180.0D, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            vpAmbient.CurrentDirection_deg = 179.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(179.0D, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // CurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            vpAmbient.CurrentDirection_deg = 181.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "-180", "180")).Any());
            Assert.AreEqual(181.0D, vpAmbient.CurrentDirection_deg);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 40)]
            // vpAmbient.AmbientSalinity_PSU   (Double)
            //-----------------------------------
            //Error: Type not implemented [AmbientSalinity_PSU]


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min should return true and no errors
            vpAmbient.AmbientSalinity_PSU = 0.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            vpAmbient.AmbientSalinity_PSU = 1.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min - 1 should return false with one error
            vpAmbient.AmbientSalinity_PSU = -1.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0D, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max should return true and no errors
            vpAmbient.AmbientSalinity_PSU = 40.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(40.0D, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            vpAmbient.AmbientSalinity_PSU = 39.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(39.0D, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max + 1 should return false with one error
            vpAmbient.AmbientSalinity_PSU = 41.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0D, vpAmbient.AmbientSalinity_PSU);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-10, 40)]
            // vpAmbient.AmbientTemperature_C   (Double)
            //-----------------------------------
            //Error: Type not implemented [AmbientTemperature_C]


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            vpAmbient.AmbientTemperature_C = -10.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-10.0D, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            vpAmbient.AmbientTemperature_C = -9.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-9.0D, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            vpAmbient.AmbientTemperature_C = -11.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            vpAmbient.AmbientTemperature_C = 40.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(40.0D, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            vpAmbient.AmbientTemperature_C = 39.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(39.0D, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            vpAmbient.AmbientTemperature_C = 41.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(41.0D, vpAmbient.AmbientTemperature_C);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10000000)]
            // vpAmbient.BackgroundConcentration_MPN_100ml   (Int32)
            //-----------------------------------
            // BackgroundConcentration_MPN_100ml will automatically be initialized at 0 --> not null


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 0;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            vpAmbient.BackgroundConcentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 10000000;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(10000000, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            vpAmbient.BackgroundConcentration_MPN_100ml = 9999999;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(9999999, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // BackgroundConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            vpAmbient.BackgroundConcentration_MPN_100ml = 10000001;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, vpAmbient.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 100)]
            // vpAmbient.PollutantDecayRate_per_day   (Double)
            //-----------------------------------
            //Error: Type not implemented [PollutantDecayRate_per_day]


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // PollutantDecayRate_per_day has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 0.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 1.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            vpAmbient.PollutantDecayRate_per_day = -1.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "100")).Any());
            Assert.AreEqual(-1.0D, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 100.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(100.0D, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            vpAmbient.PollutantDecayRate_per_day = 99.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(99.0D, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // PollutantDecayRate_per_day has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            vpAmbient.PollutantDecayRate_per_day = 101.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "100")).Any());
            Assert.AreEqual(101.0D, vpAmbient.PollutantDecayRate_per_day);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10)]
            // vpAmbient.FarFieldCurrentSpeed_m_s   (Double)
            //-----------------------------------
            //Error: Type not implemented [FarFieldCurrentSpeed_m_s]


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // FarFieldCurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Min should return true and no errors
            vpAmbient.FarFieldCurrentSpeed_m_s = 0.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Min + 1 should return true and no errors
            vpAmbient.FarFieldCurrentSpeed_m_s = 1.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Min - 1 should return false with one error
            vpAmbient.FarFieldCurrentSpeed_m_s = -1.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0D, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Max should return true and no errors
            vpAmbient.FarFieldCurrentSpeed_m_s = 10.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(10.0D, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Max - 1 should return true and no errors
            vpAmbient.FarFieldCurrentSpeed_m_s = 9.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(9.0D, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentSpeed_m_s has Min [0.0D] and Max [10.0D]. At Max + 1 should return false with one error
            vpAmbient.FarFieldCurrentSpeed_m_s = 11.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0D, vpAmbient.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-180, 180)]
            // vpAmbient.FarFieldCurrentDirection_deg   (Double)
            //-----------------------------------
            //Error: Type not implemented [FarFieldCurrentDirection_deg]


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // FarFieldCurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = -180.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-180.0D, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = -179.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(-179.0D, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            vpAmbient.FarFieldCurrentDirection_deg = -181.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = 180.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(180.0D, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            vpAmbient.FarFieldCurrentDirection_deg = 179.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(179.0D, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldCurrentDirection_deg has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            vpAmbient.FarFieldCurrentDirection_deg = 181.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "-180", "180")).Any());
            Assert.AreEqual(181.0D, vpAmbient.FarFieldCurrentDirection_deg);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1)]
            // vpAmbient.FarFieldDiffusionCoefficient   (Double)
            //-----------------------------------
            //Error: Type not implemented [FarFieldDiffusionCoefficient]


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // FarFieldDiffusionCoefficient has Min [0.0D] and Max [1.0D]. At Min should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 0.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0.0D] and Max [1.0D]. At Min + 1 should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 1.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0.0D] and Max [1.0D]. At Min - 1 should return false with one error
            vpAmbient.FarFieldDiffusionCoefficient = -1.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "1")).Any());
            Assert.AreEqual(-1.0D, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0.0D] and Max [1.0D]. At Max should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 1.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0.0D] and Max [1.0D]. At Max - 1 should return true and no errors
            vpAmbient.FarFieldDiffusionCoefficient = 0.0D;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // FarFieldDiffusionCoefficient has Min [0.0D] and Max [1.0D]. At Max + 1 should return false with one error
            vpAmbient.FarFieldDiffusionCoefficient = 2.0D;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "1")).Any());
            Assert.AreEqual(2.0D, vpAmbient.FarFieldDiffusionCoefficient);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // vpAmbient.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // vpAmbient.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            vpAmbient = null;
            vpAmbient = GetFilledRandomVPAmbient("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpAmbient.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(1, vpAmbient.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpAmbient.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, vpAmbientService.Add(vpAmbient));
            Assert.AreEqual(0, vpAmbient.ValidationResults.Count());
            Assert.AreEqual(2, vpAmbient.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpAmbientService.Delete(vpAmbient));
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpAmbient.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
            Assert.IsTrue(vpAmbient.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPAmbientLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, vpAmbient.LastUpdateContactTVItemID);
            Assert.AreEqual(count, vpAmbientService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // vpAmbient.VPScenario   (VPScenario)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // vpAmbient.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
