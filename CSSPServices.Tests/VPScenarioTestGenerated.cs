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
        private VPScenarioService vpScenarioService { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioTest() : base()
        {
            vpScenarioService = new VPScenarioService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPScenario GetFilledRandomVPScenario(string OmitPropName)
        {
            VPScenario vpScenario = new VPScenario();

            if (OmitPropName != "InfrastructureTVItemID") vpScenario.InfrastructureTVItemID = 16;
            if (OmitPropName != "VPScenarioStatus") vpScenario.VPScenarioStatus = (ScenarioStatusEnum)GetRandomEnumType(typeof(ScenarioStatusEnum));
            if (OmitPropName != "UseAsBestEstimate") vpScenario.UseAsBestEstimate = true;
            if (OmitPropName != "EffluentFlow_m3_s") vpScenario.EffluentFlow_m3_s = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "EffluentConcentration_MPN_100ml") vpScenario.EffluentConcentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "FroudeNumber") vpScenario.FroudeNumber = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "PortDiameter_m") vpScenario.PortDiameter_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "PortDepth_m") vpScenario.PortDepth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "PortElevation_m") vpScenario.PortElevation_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "VerticalAngle_deg") vpScenario.VerticalAngle_deg = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "HorizontalAngle_deg") vpScenario.HorizontalAngle_deg = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "NumberOfPorts") vpScenario.NumberOfPorts = GetRandomInt(1, 100);
            if (OmitPropName != "PortSpacing_m") vpScenario.PortSpacing_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "AcuteMixZone_m") vpScenario.AcuteMixZone_m = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "ChronicMixZone_m") vpScenario.ChronicMixZone_m = GetRandomDouble(0.0D, 40000.0D);
            if (OmitPropName != "EffluentSalinity_PSU") vpScenario.EffluentSalinity_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "EffluentTemperature_C") vpScenario.EffluentTemperature_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "EffluentVelocity_m_s") vpScenario.EffluentVelocity_m_s = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "RawResults") vpScenario.RawResults = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") vpScenario.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpScenario.LastUpdateContactTVItemID = 2;

            return vpScenario;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPScenario_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            VPScenario vpScenario = GetFilledRandomVPScenario("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = vpScenarioService.GetRead().Count();

            vpScenarioService.Add(vpScenario);
            if (vpScenario.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, vpScenarioService.GetRead().Where(c => c == vpScenario).Any());
            vpScenarioService.Update(vpScenario);
            if (vpScenario.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, vpScenarioService.GetRead().Count());
            vpScenarioService.Delete(vpScenario);
            if (vpScenario.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // vpScenario.VPScenarioID   (Int32)
            //-----------------------------------
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VPScenarioID = 0;
            vpScenarioService.Update(vpScenario);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioVPScenarioID), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Infrastructure)]
            //[Range(1, -1)]
            // vpScenario.InfrastructureTVItemID   (Int32)
            //-----------------------------------
            // InfrastructureTVItemID will automatically be initialized at 0 --> not null


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpScenario.InfrastructureTVItemID = 1;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1, vpScenario.InfrastructureTVItemID);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpScenario.InfrastructureTVItemID = 2;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(2, vpScenario.InfrastructureTVItemID);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpScenario.InfrastructureTVItemID = 0;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioInfrastructureTVItemID, "1")).Any());
            Assert.AreEqual(0, vpScenario.InfrastructureTVItemID);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // vpScenario.VPScenarioStatus   (ScenarioStatusEnum)
            //-----------------------------------
            // VPScenarioStatus will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            // vpScenario.UseAsBestEstimate   (Boolean)
            //-----------------------------------
            // UseAsBestEstimate will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000)]
            // vpScenario.EffluentFlow_m3_s   (Double)
            //-----------------------------------
            //Error: Type not implemented [EffluentFlow_m3_s]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentFlow_m3_s has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            vpScenario.EffluentFlow_m3_s = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            vpScenario.EffluentFlow_m3_s = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            vpScenario.EffluentFlow_m3_s = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentFlow_m3_s, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            vpScenario.EffluentFlow_m3_s = 1000.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1000.0D, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            vpScenario.EffluentFlow_m3_s = 999.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(999.0D, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentFlow_m3_s has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            vpScenario.EffluentFlow_m3_s = 1001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentFlow_m3_s, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, vpScenario.EffluentFlow_m3_s);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10000000)]
            // vpScenario.EffluentConcentration_MPN_100ml   (Int32)
            //-----------------------------------
            // EffluentConcentration_MPN_100ml will automatically be initialized at 0 --> not null


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 0;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 1;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            vpScenario.EffluentConcentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 10000000;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(10000000, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 9999999;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(9999999, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            vpScenario.EffluentConcentration_MPN_100ml = 10000001;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10000)]
            // vpScenario.FroudeNumber   (Double)
            //-----------------------------------
            //Error: Type not implemented [FroudeNumber]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // FroudeNumber has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            vpScenario.FroudeNumber = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.FroudeNumber);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            vpScenario.FroudeNumber = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.FroudeNumber);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            vpScenario.FroudeNumber = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioFroudeNumber, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, vpScenario.FroudeNumber);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            vpScenario.FroudeNumber = 10000.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(10000.0D, vpScenario.FroudeNumber);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            vpScenario.FroudeNumber = 9999.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(9999.0D, vpScenario.FroudeNumber);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // FroudeNumber has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            vpScenario.FroudeNumber = 10001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioFroudeNumber, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, vpScenario.FroudeNumber);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 10)]
            // vpScenario.PortDiameter_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [PortDiameter_m]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Min should return true and no errors
            vpScenario.PortDiameter_m = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.PortDiameter_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Min + 1 should return true and no errors
            vpScenario.PortDiameter_m = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.PortDiameter_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Min - 1 should return false with one error
            vpScenario.PortDiameter_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDiameter_m, "0", "10")).Any());
            Assert.AreEqual(-1.0D, vpScenario.PortDiameter_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Max should return true and no errors
            vpScenario.PortDiameter_m = 10.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(10.0D, vpScenario.PortDiameter_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Max - 1 should return true and no errors
            vpScenario.PortDiameter_m = 9.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(9.0D, vpScenario.PortDiameter_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDiameter_m has Min [0.0D] and Max [10.0D]. At Max + 1 should return false with one error
            vpScenario.PortDiameter_m = 11.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDiameter_m, "0", "10")).Any());
            Assert.AreEqual(11.0D, vpScenario.PortDiameter_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000)]
            // vpScenario.PortDepth_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [PortDepth_m]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // PortDepth_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            vpScenario.PortDepth_m = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.PortDepth_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            vpScenario.PortDepth_m = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.PortDepth_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            vpScenario.PortDepth_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, vpScenario.PortDepth_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            vpScenario.PortDepth_m = 1000.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1000.0D, vpScenario.PortDepth_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            vpScenario.PortDepth_m = 999.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(999.0D, vpScenario.PortDepth_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortDepth_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            vpScenario.PortDepth_m = 1001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, vpScenario.PortDepth_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000)]
            // vpScenario.PortElevation_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [PortElevation_m]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            vpScenario.PortElevation_m = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.PortElevation_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            vpScenario.PortElevation_m = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.PortElevation_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            vpScenario.PortElevation_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortElevation_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, vpScenario.PortElevation_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            vpScenario.PortElevation_m = 1000.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1000.0D, vpScenario.PortElevation_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            vpScenario.PortElevation_m = 999.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(999.0D, vpScenario.PortElevation_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortElevation_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            vpScenario.PortElevation_m = 1001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortElevation_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, vpScenario.PortElevation_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-90, 90)]
            // vpScenario.VerticalAngle_deg   (Double)
            //-----------------------------------
            //Error: Type not implemented [VerticalAngle_deg]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Min should return true and no errors
            vpScenario.VerticalAngle_deg = -90.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-90.0D, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Min + 1 should return true and no errors
            vpScenario.VerticalAngle_deg = -89.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-89.0D, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Min - 1 should return false with one error
            vpScenario.VerticalAngle_deg = -91.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioVerticalAngle_deg, "-90", "90")).Any());
            Assert.AreEqual(-91.0D, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Max should return true and no errors
            vpScenario.VerticalAngle_deg = 90.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(90.0D, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Max - 1 should return true and no errors
            vpScenario.VerticalAngle_deg = 89.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(89.0D, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // VerticalAngle_deg has Min [-90.0D] and Max [90.0D]. At Max + 1 should return false with one error
            vpScenario.VerticalAngle_deg = 91.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioVerticalAngle_deg, "-90", "90")).Any());
            Assert.AreEqual(91.0D, vpScenario.VerticalAngle_deg);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-180, 180)]
            // vpScenario.HorizontalAngle_deg   (Double)
            //-----------------------------------
            //Error: Type not implemented [HorizontalAngle_deg]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            vpScenario.HorizontalAngle_deg = -180.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-180.0D, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            vpScenario.HorizontalAngle_deg = -179.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-179.0D, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            vpScenario.HorizontalAngle_deg = -181.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            vpScenario.HorizontalAngle_deg = 180.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(180.0D, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            vpScenario.HorizontalAngle_deg = 179.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(179.0D, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // HorizontalAngle_deg has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            vpScenario.HorizontalAngle_deg = 181.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180")).Any());
            Assert.AreEqual(181.0D, vpScenario.HorizontalAngle_deg);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(1, 100)]
            // vpScenario.NumberOfPorts   (Int32)
            //-----------------------------------
            // NumberOfPorts will automatically be initialized at 0 --> not null


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // NumberOfPorts has Min [1] and Max [100]. At Min should return true and no errors
            vpScenario.NumberOfPorts = 1;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1, vpScenario.NumberOfPorts);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Min + 1 should return true and no errors
            vpScenario.NumberOfPorts = 2;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(2, vpScenario.NumberOfPorts);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Min - 1 should return false with one error
            vpScenario.NumberOfPorts = 0;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioNumberOfPorts, "1", "100")).Any());
            Assert.AreEqual(0, vpScenario.NumberOfPorts);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Max should return true and no errors
            vpScenario.NumberOfPorts = 100;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(100, vpScenario.NumberOfPorts);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Max - 1 should return true and no errors
            vpScenario.NumberOfPorts = 99;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(99, vpScenario.NumberOfPorts);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // NumberOfPorts has Min [1] and Max [100]. At Max + 1 should return false with one error
            vpScenario.NumberOfPorts = 101;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioNumberOfPorts, "1", "100")).Any());
            Assert.AreEqual(101, vpScenario.NumberOfPorts);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000)]
            // vpScenario.PortSpacing_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [PortSpacing_m]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // PortSpacing_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            vpScenario.PortSpacing_m = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.PortSpacing_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            vpScenario.PortSpacing_m = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.PortSpacing_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            vpScenario.PortSpacing_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortSpacing_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, vpScenario.PortSpacing_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            vpScenario.PortSpacing_m = 1000.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1000.0D, vpScenario.PortSpacing_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            vpScenario.PortSpacing_m = 999.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(999.0D, vpScenario.PortSpacing_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // PortSpacing_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            vpScenario.PortSpacing_m = 1001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortSpacing_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, vpScenario.PortSpacing_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 100)]
            // vpScenario.AcuteMixZone_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [AcuteMixZone_m]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // AcuteMixZone_m has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            vpScenario.AcuteMixZone_m = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            vpScenario.AcuteMixZone_m = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            vpScenario.AcuteMixZone_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioAcuteMixZone_m, "0", "100")).Any());
            Assert.AreEqual(-1.0D, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            vpScenario.AcuteMixZone_m = 100.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(100.0D, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            vpScenario.AcuteMixZone_m = 99.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(99.0D, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // AcuteMixZone_m has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            vpScenario.AcuteMixZone_m = 101.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioAcuteMixZone_m, "0", "100")).Any());
            Assert.AreEqual(101.0D, vpScenario.AcuteMixZone_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 40000)]
            // vpScenario.ChronicMixZone_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [ChronicMixZone_m]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // ChronicMixZone_m has Min [0.0D] and Max [40000.0D]. At Min should return true and no errors
            vpScenario.ChronicMixZone_m = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0.0D] and Max [40000.0D]. At Min + 1 should return true and no errors
            vpScenario.ChronicMixZone_m = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0.0D] and Max [40000.0D]. At Min - 1 should return false with one error
            vpScenario.ChronicMixZone_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioChronicMixZone_m, "0", "40000")).Any());
            Assert.AreEqual(-1.0D, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0.0D] and Max [40000.0D]. At Max should return true and no errors
            vpScenario.ChronicMixZone_m = 40000.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(40000.0D, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0.0D] and Max [40000.0D]. At Max - 1 should return true and no errors
            vpScenario.ChronicMixZone_m = 39999.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(39999.0D, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // ChronicMixZone_m has Min [0.0D] and Max [40000.0D]. At Max + 1 should return false with one error
            vpScenario.ChronicMixZone_m = 40001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioChronicMixZone_m, "0", "40000")).Any());
            Assert.AreEqual(40001.0D, vpScenario.ChronicMixZone_m);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 40)]
            // vpScenario.EffluentSalinity_PSU   (Double)
            //-----------------------------------
            //Error: Type not implemented [EffluentSalinity_PSU]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min should return true and no errors
            vpScenario.EffluentSalinity_PSU = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            vpScenario.EffluentSalinity_PSU = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min - 1 should return false with one error
            vpScenario.EffluentSalinity_PSU = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0D, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max should return true and no errors
            vpScenario.EffluentSalinity_PSU = 40.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(40.0D, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            vpScenario.EffluentSalinity_PSU = 39.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(39.0D, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max + 1 should return false with one error
            vpScenario.EffluentSalinity_PSU = 41.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0D, vpScenario.EffluentSalinity_PSU);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-10, 40)]
            // vpScenario.EffluentTemperature_C   (Double)
            //-----------------------------------
            //Error: Type not implemented [EffluentTemperature_C]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentTemperature_C has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            vpScenario.EffluentTemperature_C = -10.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-10.0D, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            vpScenario.EffluentTemperature_C = -9.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(-9.0D, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            vpScenario.EffluentTemperature_C = -11.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            vpScenario.EffluentTemperature_C = 40.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(40.0D, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            vpScenario.EffluentTemperature_C = 39.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(39.0D, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentTemperature_C has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            vpScenario.EffluentTemperature_C = 41.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(41.0D, vpScenario.EffluentTemperature_C);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 100)]
            // vpScenario.EffluentVelocity_m_s   (Double)
            //-----------------------------------
            //Error: Type not implemented [EffluentVelocity_m_s]


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentVelocity_m_s has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            vpScenario.EffluentVelocity_m_s = 0.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            vpScenario.EffluentVelocity_m_s = 1.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            vpScenario.EffluentVelocity_m_s = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentVelocity_m_s, "0", "100")).Any());
            Assert.AreEqual(-1.0D, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            vpScenario.EffluentVelocity_m_s = 100.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(100.0D, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            vpScenario.EffluentVelocity_m_s = 99.0D;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(99.0D, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // EffluentVelocity_m_s has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            vpScenario.EffluentVelocity_m_s = 101.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentVelocity_m_s, "0", "100")).Any());
            Assert.AreEqual(101.0D, vpScenario.EffluentVelocity_m_s);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            // vpScenario.RawResults   (String)
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // vpScenario.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // vpScenario.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpScenario.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1, vpScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpScenario.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(2, vpScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpScenario.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, vpScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // vpScenario.VPAmbients   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // vpScenario.VPResults   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // vpScenario.VPScenarioLanguages   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // vpScenario.InfrastructureTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // vpScenario.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
