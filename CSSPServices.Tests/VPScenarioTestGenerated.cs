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
            if (OmitPropName != "EffluentFlow_m3_s") vpScenario.EffluentFlow_m3_s = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "EffluentConcentration_MPN_100ml") vpScenario.EffluentConcentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "FroudeNumber") vpScenario.FroudeNumber = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PortDiameter_m") vpScenario.PortDiameter_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PortDepth_m") vpScenario.PortDepth_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PortElevation_m") vpScenario.PortElevation_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "VerticalAngle_deg") vpScenario.VerticalAngle_deg = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "HorizontalAngle_deg") vpScenario.HorizontalAngle_deg = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "NumberOfPorts") vpScenario.NumberOfPorts = GetRandomInt(1, 100);
            if (OmitPropName != "PortSpacing_m") vpScenario.PortSpacing_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "AcuteMixZone_m") vpScenario.AcuteMixZone_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "ChronicMixZone_m") vpScenario.ChronicMixZone_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "EffluentSalinity_PSU") vpScenario.EffluentSalinity_PSU = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "EffluentTemperature_C") vpScenario.EffluentTemperature_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "EffluentVelocity_m_s") vpScenario.EffluentVelocity_m_s = GetRandomDouble(1.0D, 1000.0D);
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
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // InfrastructureTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [VPScenarioStatus]

            // UseAsBestEstimate will automatically be initialized at 0 --> not null

            //Error: Type not implemented [EffluentFlow_m3_s]

            // EffluentConcentration_MPN_100ml will automatically be initialized at 0 --> not null

            //Error: Type not implemented [FroudeNumber]

            //Error: Type not implemented [PortDiameter_m]

            //Error: Type not implemented [PortDepth_m]

            //Error: Type not implemented [PortElevation_m]

            //Error: Type not implemented [VerticalAngle_deg]

            //Error: Type not implemented [HorizontalAngle_deg]

            // NumberOfPorts will automatically be initialized at 0 --> not null

            //Error: Type not implemented [PortSpacing_m]

            //Error: Type not implemented [AcuteMixZone_m]

            //Error: Type not implemented [ChronicMixZone_m]

            //Error: Type not implemented [EffluentSalinity_PSU]

            //Error: Type not implemented [EffluentTemperature_C]

            //Error: Type not implemented [EffluentVelocity_m_s]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("RawResults");
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(1, vpScenario.ValidationResults.Count());
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioRawResults)).Any());
            Assert.AreEqual(null, vpScenario.RawResults);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("LastUpdateDate_UTC");
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(1, vpScenario.ValidationResults.Count());
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLastUpdateDate_UTC)).Any());
            Assert.IsTrue(vpScenario.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [VPAmbients]

            //Error: Type not implemented [VPResults]

            //Error: Type not implemented [VPScenarioLanguages]

            //Error: Type not implemented [InfrastructureTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [VPScenarioID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItemID] of type [Int32]
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
            // doing property [UseAsBestEstimate] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [EffluentFlow_m3_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [EffluentConcentration_MPN_100ml] of type [Int32]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 0;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(0, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 1;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(1, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            vpScenario.EffluentConcentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 10000000;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(10000000, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            vpScenario.EffluentConcentration_MPN_100ml = 9999999;
            Assert.AreEqual(true, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(0, vpScenario.ValidationResults.Count());
            Assert.AreEqual(9999999, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(true, vpScenarioService.Delete(vpScenario));
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());
            // EffluentConcentration_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            vpScenario.EffluentConcentration_MPN_100ml = 10000001;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.IsTrue(vpScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, vpScenario.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(0, vpScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [FroudeNumber] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [PortDiameter_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [PortDepth_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [PortElevation_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [VerticalAngle_deg] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [HorizontalAngle_deg] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [NumberOfPorts] of type [Int32]
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
            // doing property [PortSpacing_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [AcuteMixZone_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [ChronicMixZone_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [EffluentSalinity_PSU] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [EffluentTemperature_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [EffluentVelocity_m_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RawResults] of type [String]
            //-----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [VPAmbients] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPResults] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPScenarioLanguages] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
