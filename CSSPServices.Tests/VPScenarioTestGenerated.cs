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
    public partial class VPScenarioTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int VPScenarioID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPScenario GetFilledRandomVPScenario(string OmitPropName)
        {
            VPScenarioID += 1;

            VPScenario vpScenario = new VPScenario();

            if (OmitPropName != "VPScenarioID") vpScenario.VPScenarioID = VPScenarioID;
            if (OmitPropName != "InfrastructureTVItemID") vpScenario.InfrastructureTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "VPScenarioStatus") vpScenario.VPScenarioStatus = (ScenarioStatusEnum)GetRandomEnumType(typeof(ScenarioStatusEnum));
            if (OmitPropName != "UseAsBestEstimate") vpScenario.UseAsBestEstimate = true;
            if (OmitPropName != "EffluentFlow_m3_s") vpScenario.EffluentFlow_m3_s = GetRandomFloat(0, 100000);
            if (OmitPropName != "EffluentConcentration_MPN_100ml") vpScenario.EffluentConcentration_MPN_100ml = GetRandomInt(0, 100000000);
            if (OmitPropName != "FroudeNumber") vpScenario.FroudeNumber = GetRandomFloat(0, 1000000);
            if (OmitPropName != "PortDiameter_m") vpScenario.PortDiameter_m = GetRandomFloat(0, 100);
            if (OmitPropName != "PortDepth_m") vpScenario.PortDepth_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "PortElevation_m") vpScenario.PortElevation_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "VerticalAngle_deg") vpScenario.VerticalAngle_deg = GetRandomFloat(0, 180);
            if (OmitPropName != "HorizontalAngle_deg") vpScenario.HorizontalAngle_deg = GetRandomFloat(-180, 180);
            if (OmitPropName != "NumberOfPorts") vpScenario.NumberOfPorts = GetRandomInt(1, 100);
            if (OmitPropName != "PortSpacing_m") vpScenario.PortSpacing_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "AcuteMixZone_m") vpScenario.AcuteMixZone_m = GetRandomFloat(0, 100000);
            if (OmitPropName != "ChronicMixZone_m") vpScenario.ChronicMixZone_m = GetRandomFloat(0, 100000);
            if (OmitPropName != "EffluentSalinity_PSU") vpScenario.EffluentSalinity_PSU = GetRandomFloat(0, 40);
            if (OmitPropName != "EffluentTemperature_C") vpScenario.EffluentTemperature_C = GetRandomFloat(-10, 40);
            if (OmitPropName != "EffluentVelocity_m_s") vpScenario.EffluentVelocity_m_s = GetRandomFloat(0, 10);
            if (OmitPropName != "RawResults") vpScenario.RawResults = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") vpScenario.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpScenario.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return vpScenario;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPScenario_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            VPScenarioService vpScenarioService = new VPScenarioService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            VPScenario vpScenario = GetFilledRandomVPScenario("");
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(true, vpScenarioService.GetRead().Where(c => c == vpScenario).Any());
            vpScenario.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, vpScenarioService.Update(vpScenario));
            Assert.AreEqual(1, vpScenarioService.GetRead().Count());
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // InfrastructureTVItemID will automatically be initialized at 0 --> not null

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("VPScenarioStatus");
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(1, vpScenario.ValidationResults.Count());
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioVPScenarioStatus)).Any());
            Assert.AreEqual(ScenarioStatusEnum.Error, vpScenario.VPScenarioStatus);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            // UseAsBestEstimate will automatically be initialized at false --> not null

            // EffluentFlow_m3_s will automatically be initialized at 0.0f --> not null

            // EffluentConcentration_MPN_100ml will automatically be initialized at 0 --> not null

            // FroudeNumber will automatically be initialized at 0.0f --> not null

            // PortDiameter_m will automatically be initialized at 0.0f --> not null

            // PortDepth_m will automatically be initialized at 0.0f --> not null

            // PortElevation_m will automatically be initialized at 0.0f --> not null

            // VerticalAngle_deg will automatically be initialized at 0.0f --> not null

            // HorizontalAngle_deg will automatically be initialized at 0.0f --> not null

            // NumberOfPorts will automatically be initialized at 0 --> not null

            // PortSpacing_m will automatically be initialized at 0.0f --> not null

            // AcuteMixZone_m will automatically be initialized at 0.0f --> not null

            // ChronicMixZone_m will automatically be initialized at 0.0f --> not null

            // EffluentSalinity_PSU will automatically be initialized at 0.0f --> not null

            // EffluentTemperature_C will automatically be initialized at 0.0f --> not null

            // EffluentVelocity_m_s will automatically be initialized at 0.0f --> not null

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("LastUpdateDate_UTC");
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(1, vpScenario.ValidationResults.Count());
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLastUpdateDate_UTC)).Any());
            Assert.IsTrue(vpScenario.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [VPScenarioID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItemID] of type [int]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpScenario.InfrastructureTVItemID = 1;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1, vpScenario.InfrastructureTVItemID);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpScenario.InfrastructureTVItemID = 2;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(2, vpScenario.InfrastructureTVItemID);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpScenario.InfrastructureTVItemID = 0;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioInfrastructureTVItemID, "1")).Any());
            Assert.AreEqual(0, vpScenario.InfrastructureTVItemID);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [VPScenarioStatus] of type [ScenarioStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [UseAsBestEstimate] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [EffluentFlow_m3_s] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentFlow_m3_s has Min [0] and Max [100000]. At Min should return true and no errors
            vpScenario.EffluentFlow_m3_s = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            vpScenario.EffluentFlow_m3_s = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0] and Max [100000]. At Min - 1 should return false with one error
            vpScenario.EffluentFlow_m3_s = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentFlow_m3_s, "0", "100000")).Any());
            Assert.AreEqual(-1.0f, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0] and Max [100000]. At Max should return true and no errors
            vpScenario.EffluentFlow_m3_s = 100000.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(100000.0f, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            vpScenario.EffluentFlow_m3_s = 99999.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(99999.0f, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0] and Max [100000]. At Max + 1 should return false with one error
            vpScenario.EffluentFlow_m3_s = 100001.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentFlow_m3_s, "0", "100000")).Any());
            Assert.AreEqual(100001.0f, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [EffluentConcentration_MPN_100ml] of type [int]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentConcentration_MPN_100ml has Min [0] and Max [100000000]. At Min should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 0;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [100000000]. At Min + 1 should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 1;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [100000000]. At Min - 1 should return false with one error
            vpScenario.EffluentConcentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "100000000")).Any());
            Assert.AreEqual(-1, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [100000000]. At Max should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 100000000;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(100000000, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [100000000]. At Max - 1 should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 99999999;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(99999999, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [100000000]. At Max + 1 should return false with one error
            vpScenario.EffluentConcentration_MPN_100ml = 100000001;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "100000000")).Any());
            Assert.AreEqual(100000001, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [FroudeNumber] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // FroudeNumber has Min [0] and Max [1000000]. At Min should return true and no errors
            vpScenario.FroudeNumber = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.FroudeNumber);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            vpScenario.FroudeNumber = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.FroudeNumber);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            vpScenario.FroudeNumber = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioFroudeNumber, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, vpScenario.FroudeNumber);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0] and Max [1000000]. At Max should return true and no errors
            vpScenario.FroudeNumber = 1000000.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, vpScenario.FroudeNumber);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            vpScenario.FroudeNumber = 999999.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(999999.0f, vpScenario.FroudeNumber);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            vpScenario.FroudeNumber = 1000001.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioFroudeNumber, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, vpScenario.FroudeNumber);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [PortDiameter_m] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // PortDiameter_m has Min [0] and Max [100]. At Min should return true and no errors
            vpScenario.PortDiameter_m = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.PortDiameter_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Min + 1 should return true and no errors
            vpScenario.PortDiameter_m = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.PortDiameter_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Min - 1 should return false with one error
            vpScenario.PortDiameter_m = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDiameter_m, "0", "100")).Any());
            Assert.AreEqual(-1.0f, vpScenario.PortDiameter_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Max should return true and no errors
            vpScenario.PortDiameter_m = 100.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(100.0f, vpScenario.PortDiameter_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Max - 1 should return true and no errors
            vpScenario.PortDiameter_m = 99.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(99.0f, vpScenario.PortDiameter_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0] and Max [100]. At Max + 1 should return false with one error
            vpScenario.PortDiameter_m = 101.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDiameter_m, "0", "100")).Any());
            Assert.AreEqual(101.0f, vpScenario.PortDiameter_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [PortDepth_m] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // PortDepth_m has Min [0] and Max [1000]. At Min should return true and no errors
            vpScenario.PortDepth_m = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.PortDepth_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            vpScenario.PortDepth_m = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.PortDepth_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            vpScenario.PortDepth_m = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, vpScenario.PortDepth_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0] and Max [1000]. At Max should return true and no errors
            vpScenario.PortDepth_m = 1000.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1000.0f, vpScenario.PortDepth_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            vpScenario.PortDepth_m = 999.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(999.0f, vpScenario.PortDepth_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            vpScenario.PortDepth_m = 1001.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, vpScenario.PortDepth_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [PortElevation_m] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // PortElevation_m has Min [0] and Max [1000]. At Min should return true and no errors
            vpScenario.PortElevation_m = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.PortElevation_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            vpScenario.PortElevation_m = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.PortElevation_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            vpScenario.PortElevation_m = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortElevation_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, vpScenario.PortElevation_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Max should return true and no errors
            vpScenario.PortElevation_m = 1000.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1000.0f, vpScenario.PortElevation_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            vpScenario.PortElevation_m = 999.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(999.0f, vpScenario.PortElevation_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            vpScenario.PortElevation_m = 1001.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortElevation_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, vpScenario.PortElevation_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [VerticalAngle_deg] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // VerticalAngle_deg has Min [0] and Max [180]. At Min should return true and no errors
            vpScenario.VerticalAngle_deg = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [0] and Max [180]. At Min + 1 should return true and no errors
            vpScenario.VerticalAngle_deg = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [0] and Max [180]. At Min - 1 should return false with one error
            vpScenario.VerticalAngle_deg = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioVerticalAngle_deg, "0", "180")).Any());
            Assert.AreEqual(-1.0f, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [0] and Max [180]. At Max should return true and no errors
            vpScenario.VerticalAngle_deg = 180.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(180.0f, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [0] and Max [180]. At Max - 1 should return true and no errors
            vpScenario.VerticalAngle_deg = 179.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(179.0f, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [0] and Max [180]. At Max + 1 should return false with one error
            vpScenario.VerticalAngle_deg = 181.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioVerticalAngle_deg, "0", "180")).Any());
            Assert.AreEqual(181.0f, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [HorizontalAngle_deg] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Min should return true and no errors
            vpScenario.HorizontalAngle_deg = -180.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-180.0f, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            vpScenario.HorizontalAngle_deg = -179.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-179.0f, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Min - 1 should return false with one error
            vpScenario.HorizontalAngle_deg = -181.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Max should return true and no errors
            vpScenario.HorizontalAngle_deg = 180.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(180.0f, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            vpScenario.HorizontalAngle_deg = 179.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(179.0f, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180] and Max [180]. At Max + 1 should return false with one error
            vpScenario.HorizontalAngle_deg = 181.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180")).Any());
            Assert.AreEqual(181.0f, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfPorts] of type [int]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // NumberOfPorts has Min [1] and Max [100]. At Min should return true and no errors
            vpScenario.NumberOfPorts = 1;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1, vpScenario.NumberOfPorts);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Min + 1 should return true and no errors
            vpScenario.NumberOfPorts = 2;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(2, vpScenario.NumberOfPorts);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Min - 1 should return false with one error
            vpScenario.NumberOfPorts = 0;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioNumberOfPorts, "1", "100")).Any());
            Assert.AreEqual(0, vpScenario.NumberOfPorts);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Max should return true and no errors
            vpScenario.NumberOfPorts = 100;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(100, vpScenario.NumberOfPorts);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Max - 1 should return true and no errors
            vpScenario.NumberOfPorts = 99;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(99, vpScenario.NumberOfPorts);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Max + 1 should return false with one error
            vpScenario.NumberOfPorts = 101;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioNumberOfPorts, "1", "100")).Any());
            Assert.AreEqual(101, vpScenario.NumberOfPorts);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [PortSpacing_m] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // PortSpacing_m has Min [0] and Max [1000]. At Min should return true and no errors
            vpScenario.PortSpacing_m = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.PortSpacing_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            vpScenario.PortSpacing_m = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.PortSpacing_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            vpScenario.PortSpacing_m = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortSpacing_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, vpScenario.PortSpacing_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Max should return true and no errors
            vpScenario.PortSpacing_m = 1000.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1000.0f, vpScenario.PortSpacing_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            vpScenario.PortSpacing_m = 999.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(999.0f, vpScenario.PortSpacing_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            vpScenario.PortSpacing_m = 1001.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortSpacing_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, vpScenario.PortSpacing_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [AcuteMixZone_m] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // AcuteMixZone_m has Min [0] and Max [100000]. At Min should return true and no errors
            vpScenario.AcuteMixZone_m = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            vpScenario.AcuteMixZone_m = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0] and Max [100000]. At Min - 1 should return false with one error
            vpScenario.AcuteMixZone_m = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioAcuteMixZone_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0f, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0] and Max [100000]. At Max should return true and no errors
            vpScenario.AcuteMixZone_m = 100000.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(100000.0f, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            vpScenario.AcuteMixZone_m = 99999.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(99999.0f, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0] and Max [100000]. At Max + 1 should return false with one error
            vpScenario.AcuteMixZone_m = 100001.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioAcuteMixZone_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0f, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [ChronicMixZone_m] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // ChronicMixZone_m has Min [0] and Max [100000]. At Min should return true and no errors
            vpScenario.ChronicMixZone_m = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            vpScenario.ChronicMixZone_m = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0] and Max [100000]. At Min - 1 should return false with one error
            vpScenario.ChronicMixZone_m = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioChronicMixZone_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0f, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0] and Max [100000]. At Max should return true and no errors
            vpScenario.ChronicMixZone_m = 100000.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(100000.0f, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            vpScenario.ChronicMixZone_m = 99999.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(99999.0f, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0] and Max [100000]. At Max + 1 should return false with one error
            vpScenario.ChronicMixZone_m = 100001.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioChronicMixZone_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0f, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [EffluentSalinity_PSU] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentSalinity_PSU has Min [0] and Max [40]. At Min should return true and no errors
            vpScenario.EffluentSalinity_PSU = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0] and Max [40]. At Min + 1 should return true and no errors
            vpScenario.EffluentSalinity_PSU = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0] and Max [40]. At Min - 1 should return false with one error
            vpScenario.EffluentSalinity_PSU = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0f, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0] and Max [40]. At Max should return true and no errors
            vpScenario.EffluentSalinity_PSU = 40.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(40.0f, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0] and Max [40]. At Max - 1 should return true and no errors
            vpScenario.EffluentSalinity_PSU = 39.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(39.0f, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0] and Max [40]. At Max + 1 should return false with one error
            vpScenario.EffluentSalinity_PSU = 41.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0f, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [EffluentTemperature_C] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentTemperature_C has Min [-10] and Max [40]. At Min should return true and no errors
            vpScenario.EffluentTemperature_C = -10.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-10.0f, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10] and Max [40]. At Min + 1 should return true and no errors
            vpScenario.EffluentTemperature_C = -9.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-9.0f, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10] and Max [40]. At Min - 1 should return false with one error
            vpScenario.EffluentTemperature_C = -11.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0f, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10] and Max [40]. At Max should return true and no errors
            vpScenario.EffluentTemperature_C = 40.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(40.0f, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10] and Max [40]. At Max - 1 should return true and no errors
            vpScenario.EffluentTemperature_C = 39.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(39.0f, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10] and Max [40]. At Max + 1 should return false with one error
            vpScenario.EffluentTemperature_C = 41.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(41.0f, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [EffluentVelocity_m_s] of type [float]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentVelocity_m_s has Min [0] and Max [10]. At Min should return true and no errors
            vpScenario.EffluentVelocity_m_s = 0.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0] and Max [10]. At Min + 1 should return true and no errors
            vpScenario.EffluentVelocity_m_s = 1.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0] and Max [10]. At Min - 1 should return false with one error
            vpScenario.EffluentVelocity_m_s = -1.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0f, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0] and Max [10]. At Max should return true and no errors
            vpScenario.EffluentVelocity_m_s = 10.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(10.0f, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0] and Max [10]. At Max - 1 should return true and no errors
            vpScenario.EffluentVelocity_m_s = 9.0f;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(9.0f, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0] and Max [10]. At Max + 1 should return false with one error
            vpScenario.EffluentVelocity_m_s = 11.0f;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0f, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [RawResults] of type [string]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpScenario.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1, vpScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpScenario.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(2, vpScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpScenario.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, vpScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
