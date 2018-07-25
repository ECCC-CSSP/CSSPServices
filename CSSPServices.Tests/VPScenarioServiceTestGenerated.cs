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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPScenario_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
                    // Is Nullable
                    // [Range(0, 1000)]
                    // vpScenario.EffluentFlow_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [EffluentFlow_m3_s]

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
                    // Is Nullable
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
                    // Is Nullable
                    // [Range(0, 10000)]
                    // vpScenario.FroudeNumber   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [FroudeNumber]

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
                    // Is Nullable
                    // [Range(0, 10)]
                    // vpScenario.PortDiameter_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PortDiameter_m]

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
                    // Is Nullable
                    // [Range(0, 1000)]
                    // vpScenario.PortDepth_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PortDepth_m]

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
                    // Is Nullable
                    // [Range(0, 1000)]
                    // vpScenario.PortElevation_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PortElevation_m]

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
                    // Is Nullable
                    // [Range(-90, 90)]
                    // vpScenario.VerticalAngle_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [VerticalAngle_deg]

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
                    // Is Nullable
                    // [Range(-180, 180)]
                    // vpScenario.HorizontalAngle_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [HorizontalAngle_deg]

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
                    // Is Nullable
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
                    // Is Nullable
                    // [Range(0, 1000)]
                    // vpScenario.PortSpacing_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PortSpacing_m]

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
                    // Is Nullable
                    // [Range(0, 100)]
                    // vpScenario.AcuteMixZone_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [AcuteMixZone_m]

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
                    // Is Nullable
                    // [Range(0, 40000)]
                    // vpScenario.ChronicMixZone_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [ChronicMixZone_m]

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
                    // Is Nullable
                    // [Range(0, 40)]
                    // vpScenario.EffluentSalinity_PSU   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [EffluentSalinity_PSU]

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
                    // Is Nullable
                    // [Range(-10, 40)]
                    // vpScenario.EffluentTemperature_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [EffluentTemperature_C]

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
                    // Is Nullable
                    // [Range(0, 100)]
                    // vpScenario.EffluentVelocity_m_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [EffluentVelocity_m_s]

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
                    // Is Nullable
                    // [NotMapped]
                    // vpScenario.VPScenarioWeb   (VPScenarioWeb)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VPScenarioWeb = null;
                    Assert.IsNull(vpScenario.VPScenarioWeb);

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VPScenarioWeb = new VPScenarioWeb();
                    Assert.IsNotNull(vpScenario.VPScenarioWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // vpScenario.VPScenarioReport   (VPScenarioReport)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VPScenarioReport = null;
                    Assert.IsNull(vpScenario.VPScenarioReport);

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VPScenarioReport = new VPScenarioReport();
                    Assert.IsNotNull(vpScenario.VPScenarioReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpScenario.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.LastUpdateDate_UTC = new DateTime();
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLastUpdateDate_UTC), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.VPScenarioLastUpdateDate_UTC, "1980"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenario.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenario.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetVPScenarioWithVPScenarioID(vpScenario.VPScenarioID)
        [TestMethod]
        public void GetVPScenarioWithVPScenarioID__vpScenario_VPScenarioID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPScenario vpScenario = (from c in vpScenarioService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenario);

                    VPScenario vpScenarioRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpScenarioService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpScenarioRet = vpScenarioService.GetVPScenarioWithVPScenarioID(vpScenario.VPScenarioID);
                            Assert.IsNull(vpScenarioRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioRet = vpScenarioService.GetVPScenarioWithVPScenarioID(vpScenario.VPScenarioID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioRet = vpScenarioService.GetVPScenarioWithVPScenarioID(vpScenario.VPScenarioID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioRet = vpScenarioService.GetVPScenarioWithVPScenarioID(vpScenario.VPScenarioID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioFields(new List<VPScenario>() { vpScenarioRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioWithVPScenarioID(vpScenario.VPScenarioID)

        #region Tests Generated for GetVPScenarioList()
        [TestMethod]
        public void GetVPScenarioList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPScenario vpScenario = (from c in vpScenarioService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenario);

                    List<VPScenario> vpScenarioList = new List<VPScenario>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpScenarioService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            Assert.AreEqual(0, vpScenarioList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioFields(vpScenarioList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioList()

        #region Tests Generated for GetVPScenarioList() Skip Take
        [TestMethod]
        public void GetVPScenarioList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<VPScenario> vpScenarioList = new List<VPScenario>();
                    List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioDirectQueryList = vpScenarioService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            Assert.AreEqual(0, vpScenarioList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioFields(vpScenarioList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        Assert.AreEqual(1, vpScenarioList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioList() Skip Take

        #region Tests Generated for GetVPScenarioList() Skip Take Order
        [TestMethod]
        public void GetVPScenarioList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<VPScenario> vpScenarioList = new List<VPScenario>();
                    List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 1, 1,  "VPScenarioID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioDirectQueryList = vpScenarioService.GetRead().Skip(1).Take(1).OrderBy(c => c.VPScenarioID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            Assert.AreEqual(0, vpScenarioList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioFields(vpScenarioList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        Assert.AreEqual(1, vpScenarioList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioList() Skip Take Order

        #region Tests Generated for GetVPScenarioList() Skip Take 2Order
        [TestMethod]
        public void GetVPScenarioList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<VPScenario> vpScenarioList = new List<VPScenario>();
                    List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 1, 1, "VPScenarioID,InfrastructureTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioDirectQueryList = vpScenarioService.GetRead().Skip(1).Take(1).OrderBy(c => c.VPScenarioID).ThenBy(c => c.InfrastructureTVItemID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            Assert.AreEqual(0, vpScenarioList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioFields(vpScenarioList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        Assert.AreEqual(1, vpScenarioList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioList() Skip Take 2Order

        #region Tests Generated for GetVPScenarioList() Skip Take Order Where
        [TestMethod]
        public void GetVPScenarioList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<VPScenario> vpScenarioList = new List<VPScenario>();
                    List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioID", "VPScenarioID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioDirectQueryList = vpScenarioService.GetRead().Where(c => c.VPScenarioID == 4).Skip(0).Take(1).OrderBy(c => c.VPScenarioID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            Assert.AreEqual(0, vpScenarioList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioFields(vpScenarioList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        Assert.AreEqual(1, vpScenarioList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioList() Skip Take Order Where

        #region Tests Generated for GetVPScenarioList() Skip Take Order 2Where
        [TestMethod]
        public void GetVPScenarioList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<VPScenario> vpScenarioList = new List<VPScenario>();
                    List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioID", "VPScenarioID,GT,2|VPScenarioID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioDirectQueryList = vpScenarioService.GetRead().Where(c => c.VPScenarioID > 2 && c.VPScenarioID < 5).Skip(0).Take(1).OrderBy(c => c.VPScenarioID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            Assert.AreEqual(0, vpScenarioList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioFields(vpScenarioList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        Assert.AreEqual(1, vpScenarioList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioList() Skip Take Order 2Where

        #region Tests Generated for GetVPScenarioList() 2Where
        [TestMethod]
        public void GetVPScenarioList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<VPScenario> vpScenarioList = new List<VPScenario>();
                    List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 0, 10000, "", "VPScenarioID,GT,2|VPScenarioID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioDirectQueryList = vpScenarioService.GetRead().Where(c => c.VPScenarioID > 2 && c.VPScenarioID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            Assert.AreEqual(0, vpScenarioList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioFields(vpScenarioList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        Assert.AreEqual(2, vpScenarioList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioList() 2Where

        #region Functions private
        private void CheckVPScenarioFields(List<VPScenario> vpScenarioList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // VPScenario fields
            Assert.IsNotNull(vpScenarioList[0].VPScenarioID);
            Assert.IsNotNull(vpScenarioList[0].InfrastructureTVItemID);
            Assert.IsNotNull(vpScenarioList[0].VPScenarioStatus);
            Assert.IsNotNull(vpScenarioList[0].UseAsBestEstimate);
            if (vpScenarioList[0].EffluentFlow_m3_s != null)
            {
                Assert.IsNotNull(vpScenarioList[0].EffluentFlow_m3_s);
            }
            if (vpScenarioList[0].EffluentConcentration_MPN_100ml != null)
            {
                Assert.IsNotNull(vpScenarioList[0].EffluentConcentration_MPN_100ml);
            }
            if (vpScenarioList[0].FroudeNumber != null)
            {
                Assert.IsNotNull(vpScenarioList[0].FroudeNumber);
            }
            if (vpScenarioList[0].PortDiameter_m != null)
            {
                Assert.IsNotNull(vpScenarioList[0].PortDiameter_m);
            }
            if (vpScenarioList[0].PortDepth_m != null)
            {
                Assert.IsNotNull(vpScenarioList[0].PortDepth_m);
            }
            if (vpScenarioList[0].PortElevation_m != null)
            {
                Assert.IsNotNull(vpScenarioList[0].PortElevation_m);
            }
            if (vpScenarioList[0].VerticalAngle_deg != null)
            {
                Assert.IsNotNull(vpScenarioList[0].VerticalAngle_deg);
            }
            if (vpScenarioList[0].HorizontalAngle_deg != null)
            {
                Assert.IsNotNull(vpScenarioList[0].HorizontalAngle_deg);
            }
            if (vpScenarioList[0].NumberOfPorts != null)
            {
                Assert.IsNotNull(vpScenarioList[0].NumberOfPorts);
            }
            if (vpScenarioList[0].PortSpacing_m != null)
            {
                Assert.IsNotNull(vpScenarioList[0].PortSpacing_m);
            }
            if (vpScenarioList[0].AcuteMixZone_m != null)
            {
                Assert.IsNotNull(vpScenarioList[0].AcuteMixZone_m);
            }
            if (vpScenarioList[0].ChronicMixZone_m != null)
            {
                Assert.IsNotNull(vpScenarioList[0].ChronicMixZone_m);
            }
            if (vpScenarioList[0].EffluentSalinity_PSU != null)
            {
                Assert.IsNotNull(vpScenarioList[0].EffluentSalinity_PSU);
            }
            if (vpScenarioList[0].EffluentTemperature_C != null)
            {
                Assert.IsNotNull(vpScenarioList[0].EffluentTemperature_C);
            }
            if (vpScenarioList[0].EffluentVelocity_m_s != null)
            {
                Assert.IsNotNull(vpScenarioList[0].EffluentVelocity_m_s);
            }
            if (!string.IsNullOrWhiteSpace(vpScenarioList[0].RawResults))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioList[0].RawResults));
            }
            Assert.IsNotNull(vpScenarioList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpScenarioList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // VPScenarioWeb and VPScenarioReport fields should be null here
                Assert.IsNull(vpScenarioList[0].VPScenarioWeb);
                Assert.IsNull(vpScenarioList[0].VPScenarioReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // VPScenarioWeb fields should not be null and VPScenarioReport fields should be null here
                if (!string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioWeb.SubsectorTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioWeb.SubsectorTVText));
                }
                if (!string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioWeb.VPScenarioStatusText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioWeb.VPScenarioStatusText));
                }
                Assert.IsNull(vpScenarioList[0].VPScenarioReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // VPScenarioWeb and VPScenarioReport fields should NOT be null here
                if (vpScenarioList[0].VPScenarioWeb.SubsectorTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioWeb.SubsectorTVText));
                }
                if (vpScenarioList[0].VPScenarioWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioWeb.LastUpdateContactTVText));
                }
                if (vpScenarioList[0].VPScenarioWeb.VPScenarioStatusText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioWeb.VPScenarioStatusText));
                }
                if (vpScenarioList[0].VPScenarioReport.VPScenarioReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioList[0].VPScenarioReport.VPScenarioReportTest));
                }
            }
        }
        private VPScenario GetFilledRandomVPScenario(string OmitPropName)
        {
            VPScenario vpScenario = new VPScenario();

            if (OmitPropName != "InfrastructureTVItemID") vpScenario.InfrastructureTVItemID = 37;
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
    }
}
