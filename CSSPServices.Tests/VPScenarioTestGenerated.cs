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
using CSSPEnums.Resources;

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
            if (OmitPropName != "LastUpdateDate_UTC") vpScenario.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // vpScenario.VPScenarioID   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VPScenarioID = 0;
            vpScenarioService.Update(vpScenario);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioVPScenarioID), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Infrastructure)]
            // vpScenario.InfrastructureTVItemID   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.InfrastructureTVItemID = 0;
            vpScenarioService.Add(vpScenario);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPScenarioInfrastructureTVItemID, vpScenario.InfrastructureTVItemID.ToString()), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.InfrastructureTVItemID = 1;
            vpScenarioService.Add(vpScenario);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.VPScenarioInfrastructureTVItemID, "Infrastructure"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // vpScenario.VPScenarioStatus   (ScenarioStatusEnum)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VPScenarioStatus = (ScenarioStatusEnum)1000000;
            vpScenarioService.Add(vpScenario);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioVPScenarioStatus), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // vpScenario.UseAsBestEstimate   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // vpScenario.EffluentFlow_m3_s   (Double)
            // -----------------------------------

            //Error: Type not implemented [EffluentFlow_m3_s]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentFlow_m3_s = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentFlow_m3_s, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentFlow_m3_s = 1001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentFlow_m3_s, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000000)]
            // vpScenario.EffluentConcentration_MPN_100ml   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentConcentration_MPN_100ml = -1;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentConcentration_MPN_100ml = 10000001;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000)]
            // vpScenario.FroudeNumber   (Double)
            // -----------------------------------

            //Error: Type not implemented [FroudeNumber]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.FroudeNumber = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioFroudeNumber, "0", "10000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.FroudeNumber = 10001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioFroudeNumber, "0", "10000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10)]
            // vpScenario.PortDiameter_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [PortDiameter_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortDiameter_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDiameter_m, "0", "10"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortDiameter_m = 11.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDiameter_m, "0", "10"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // vpScenario.PortDepth_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [PortDepth_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortDepth_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDepth_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortDepth_m = 1001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortDepth_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // vpScenario.PortElevation_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [PortElevation_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortElevation_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortElevation_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortElevation_m = 1001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortElevation_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-90, 90)]
            // vpScenario.VerticalAngle_deg   (Double)
            // -----------------------------------

            //Error: Type not implemented [VerticalAngle_deg]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VerticalAngle_deg = -91.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioVerticalAngle_deg, "-90", "90"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.VerticalAngle_deg = 91.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioVerticalAngle_deg, "-90", "90"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-180, 180)]
            // vpScenario.HorizontalAngle_deg   (Double)
            // -----------------------------------

            //Error: Type not implemented [HorizontalAngle_deg]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.HorizontalAngle_deg = -181.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.HorizontalAngle_deg = 181.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(1, 100)]
            // vpScenario.NumberOfPorts   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.NumberOfPorts = 0;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioNumberOfPorts, "1", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.NumberOfPorts = 101;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioNumberOfPorts, "1", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // vpScenario.PortSpacing_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [PortSpacing_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortSpacing_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortSpacing_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.PortSpacing_m = 1001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioPortSpacing_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // vpScenario.AcuteMixZone_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [AcuteMixZone_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.AcuteMixZone_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioAcuteMixZone_m, "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.AcuteMixZone_m = 101.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioAcuteMixZone_m, "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 40000)]
            // vpScenario.ChronicMixZone_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [ChronicMixZone_m]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.ChronicMixZone_m = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioChronicMixZone_m, "0", "40000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.ChronicMixZone_m = 40001.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioChronicMixZone_m, "0", "40000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 40)]
            // vpScenario.EffluentSalinity_PSU   (Double)
            // -----------------------------------

            //Error: Type not implemented [EffluentSalinity_PSU]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentSalinity_PSU = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentSalinity_PSU = 41.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-10, 40)]
            // vpScenario.EffluentTemperature_C   (Double)
            // -----------------------------------

            //Error: Type not implemented [EffluentTemperature_C]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentTemperature_C = -11.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentTemperature_C, "-10", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentTemperature_C = 41.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentTemperature_C, "-10", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // vpScenario.EffluentVelocity_m_s   (Double)
            // -----------------------------------

            //Error: Type not implemented [EffluentVelocity_m_s]

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentVelocity_m_s = -1.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentVelocity_m_s, "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());
            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.EffluentVelocity_m_s = 101.0D;
            Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPScenarioEffluentVelocity_m_s, "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, vpScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // vpScenario.RawResults   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // vpScenario.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // vpScenario.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.LastUpdateContactTVItemID = 0;
            vpScenarioService.Add(vpScenario);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPScenarioLastUpdateContactTVItemID, vpScenario.LastUpdateContactTVItemID.ToString()), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

            vpScenario = null;
            vpScenario = GetFilledRandomVPScenario("");
            vpScenario.LastUpdateContactTVItemID = 1;
            vpScenarioService.Add(vpScenario);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.VPScenarioLastUpdateContactTVItemID, "Contact"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // vpScenario.VPAmbients   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // vpScenario.VPResults   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // vpScenario.VPScenarioLanguages   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // vpScenario.InfrastructureTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // vpScenario.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
