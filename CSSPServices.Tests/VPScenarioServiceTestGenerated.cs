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
    public partial class VPScenarioServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPScenarioService vpScenarioService { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioServiceTest() : base()
        {
            //vpScenarioService = new VPScenarioService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "SubsectorTVText") vpScenario.SubsectorTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") vpScenario.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "VPScenarioStatusText") vpScenario.VPScenarioStatusText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") vpScenario.HasErrors = true;

            return vpScenario;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPScenario_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioService vpScenarioService = new VPScenarioService(LanguageRequest, dbTestDB, ContactID);

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

                Assert.AreEqual(vpScenarioService.GetRead().Count(), vpScenarioService.GetEdit().Count());

                vpScenarioService.Add(vpScenario);
                if (vpScenario.HasErrors)
                {
                    Assert.AreEqual("", vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, vpScenarioService.GetRead().Where(c => c == vpScenario).Any());
                vpScenarioService.Update(vpScenario);
                if (vpScenario.HasErrors)
                {
                    Assert.AreEqual("", vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, vpScenarioService.GetRead().Count());
                vpScenarioService.Delete(vpScenario);
                if (vpScenario.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioVPScenarioID), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VPScenarioID = 10000000;
                    vpScenarioService.Update(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenario, CSSPModelsRes.VPScenarioVPScenarioID, vpScenario.VPScenarioID.ToString()), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                    // vpScenario.InfrastructureTVItemID   (Int32)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.InfrastructureTVItemID = 0;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPScenarioInfrastructureTVItemID, vpScenario.InfrastructureTVItemID.ToString()), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.InfrastructureTVItemID = 1;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPScenarioInfrastructureTVItemID, "Infrastructure"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // vpScenario.VPScenarioStatus   (ScenarioStatusEnum)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VPScenarioStatus = (ScenarioStatusEnum)1000000;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioVPScenarioStatus), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentFlow_m3_s, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentFlow_m3_s = 1001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentFlow_m3_s, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentConcentration_MPN_100ml = 10000001;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioFroudeNumber, "0", "10000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.FroudeNumber = 10001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioFroudeNumber, "0", "10000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortDiameter_m, "0", "10"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortDiameter_m = 11.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortDiameter_m, "0", "10"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortDepth_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortDepth_m = 1001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortDepth_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortElevation_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortElevation_m = 1001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortElevation_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioVerticalAngle_deg, "-90", "90"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VerticalAngle_deg = 91.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioVerticalAngle_deg, "-90", "90"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.HorizontalAngle_deg = 181.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioNumberOfPorts, "1", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.NumberOfPorts = 101;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioNumberOfPorts, "1", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortSpacing_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortSpacing_m = 1001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortSpacing_m, "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioAcuteMixZone_m, "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.AcuteMixZone_m = 101.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioAcuteMixZone_m, "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioChronicMixZone_m, "0", "40000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.ChronicMixZone_m = 40001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioChronicMixZone_m, "0", "40000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentSalinity_PSU = 41.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentTemperature_C, "-10", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentTemperature_C = 41.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentTemperature_C, "-10", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentVelocity_m_s, "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentVelocity_m_s = 101.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentVelocity_m_s, "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpScenario.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.LastUpdateContactTVItemID = 0;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPScenarioLastUpdateContactTVItemID, vpScenario.LastUpdateContactTVItemID.ToString()), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.LastUpdateContactTVItemID = 1;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPScenarioLastUpdateContactTVItemID, "Contact"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "InfrastructureTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // vpScenario.SubsectorTVText   (String)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.SubsectorTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.VPScenarioSubsectorTVText, "200"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // vpScenario.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.VPScenarioLastUpdateContactTVText, "200"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // vpScenario.VPScenarioStatusText   (String)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VPScenarioStatusText = GetRandomString("", 101);
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.VPScenarioVPScenarioStatusText, "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenario.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenario.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void VPScenario_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioService vpScenarioService = new VPScenarioService(LanguageRequest, dbTestDB, ContactID);
                    VPScenario vpScenario = (from c in vpScenarioService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenario);

                    VPScenario vpScenarioRet = vpScenarioService.GetVPScenarioWithVPScenarioID(vpScenario.VPScenarioID);
                    Assert.IsNotNull(vpScenarioRet.VPScenarioID);
                    Assert.IsNotNull(vpScenarioRet.InfrastructureTVItemID);
                    Assert.IsNotNull(vpScenarioRet.VPScenarioStatus);
                    Assert.IsNotNull(vpScenarioRet.UseAsBestEstimate);
                    Assert.IsNotNull(vpScenarioRet.EffluentFlow_m3_s);
                    Assert.IsNotNull(vpScenarioRet.EffluentConcentration_MPN_100ml);
                    Assert.IsNotNull(vpScenarioRet.FroudeNumber);
                    Assert.IsNotNull(vpScenarioRet.PortDiameter_m);
                    Assert.IsNotNull(vpScenarioRet.PortDepth_m);
                    Assert.IsNotNull(vpScenarioRet.PortElevation_m);
                    Assert.IsNotNull(vpScenarioRet.VerticalAngle_deg);
                    Assert.IsNotNull(vpScenarioRet.HorizontalAngle_deg);
                    Assert.IsNotNull(vpScenarioRet.NumberOfPorts);
                    Assert.IsNotNull(vpScenarioRet.PortSpacing_m);
                    Assert.IsNotNull(vpScenarioRet.AcuteMixZone_m);
                    Assert.IsNotNull(vpScenarioRet.ChronicMixZone_m);
                    Assert.IsNotNull(vpScenarioRet.EffluentSalinity_PSU);
                    Assert.IsNotNull(vpScenarioRet.EffluentTemperature_C);
                    Assert.IsNotNull(vpScenarioRet.EffluentVelocity_m_s);
                    if (vpScenarioRet.RawResults != null)
                    {
                       Assert.IsNotNull(vpScenarioRet.RawResults);
                       Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioRet.RawResults));
                    }
                    Assert.IsNotNull(vpScenarioRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(vpScenarioRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(vpScenarioRet.SubsectorTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioRet.SubsectorTVText));
                    Assert.IsNotNull(vpScenarioRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioRet.LastUpdateContactTVText));
                    Assert.IsNotNull(vpScenarioRet.VPScenarioStatusText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioRet.VPScenarioStatusText));
                    Assert.IsNotNull(vpScenarioRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
