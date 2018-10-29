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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = vpScenarioService.GetVPScenarioList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.VPScenarios select c).Count());

                    vpScenarioService.Add(vpScenario);
                    if (vpScenario.HasErrors)
                    {
                        Assert.AreEqual("", vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, vpScenarioService.GetVPScenarioList().Where(c => c == vpScenario).Any());
                    vpScenarioService.Update(vpScenario);
                    if (vpScenario.HasErrors)
                    {
                        Assert.AreEqual("", vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, vpScenarioService.GetVPScenarioList().Count());
                    vpScenarioService.Delete(vpScenario);
                    if (vpScenario.HasErrors)
                    {
                        Assert.AreEqual("", vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPScenarioVPScenarioID"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VPScenarioID = 10000000;
                    vpScenarioService.Update(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioVPScenarioID", vpScenario.VPScenarioID.ToString()), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                    // vpScenario.InfrastructureTVItemID   (Int32)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.InfrastructureTVItemID = 0;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "VPScenarioInfrastructureTVItemID", vpScenario.InfrastructureTVItemID.ToString()), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.InfrastructureTVItemID = 1;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "VPScenarioInfrastructureTVItemID", "Infrastructure"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // vpScenario.VPScenarioStatus   (ScenarioStatusEnum)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VPScenarioStatus = (ScenarioStatusEnum)1000000;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPScenarioVPScenarioStatus"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // vpScenario.UseAsBestEstimate   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // vpScenario.EffluentFlow_m3_s   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [EffluentFlow_m3_s]

                    //CSSPError: Type not implemented [EffluentFlow_m3_s]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentFlow_m3_s = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentFlow_m3_s", "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentFlow_m3_s = 1001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentFlow_m3_s", "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000000)]
                    // vpScenario.EffluentConcentration_MPN_100ml   (Int32)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentConcentration_MPN_100ml = -1;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentConcentration_MPN_100ml", "0", "10000000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentConcentration_MPN_100ml = 10000001;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentConcentration_MPN_100ml", "0", "10000000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // vpScenario.FroudeNumber   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [FroudeNumber]

                    //CSSPError: Type not implemented [FroudeNumber]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.FroudeNumber = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioFroudeNumber", "0", "10000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.FroudeNumber = 10001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioFroudeNumber", "0", "10000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10)]
                    // vpScenario.PortDiameter_m   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [PortDiameter_m]

                    //CSSPError: Type not implemented [PortDiameter_m]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortDiameter_m = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortDiameter_m", "0", "10"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortDiameter_m = 11.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortDiameter_m", "0", "10"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // vpScenario.PortDepth_m   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [PortDepth_m]

                    //CSSPError: Type not implemented [PortDepth_m]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortDepth_m = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortDepth_m", "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortDepth_m = 1001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortDepth_m", "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // vpScenario.PortElevation_m   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [PortElevation_m]

                    //CSSPError: Type not implemented [PortElevation_m]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortElevation_m = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortElevation_m", "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortElevation_m = 1001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortElevation_m", "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-90, 90)]
                    // vpScenario.VerticalAngle_deg   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [VerticalAngle_deg]

                    //CSSPError: Type not implemented [VerticalAngle_deg]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VerticalAngle_deg = -91.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioVerticalAngle_deg", "-90", "90"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.VerticalAngle_deg = 91.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioVerticalAngle_deg", "-90", "90"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-180, 180)]
                    // vpScenario.HorizontalAngle_deg   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [HorizontalAngle_deg]

                    //CSSPError: Type not implemented [HorizontalAngle_deg]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.HorizontalAngle_deg = -181.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioHorizontalAngle_deg", "-180", "180"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.HorizontalAngle_deg = 181.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioHorizontalAngle_deg", "-180", "180"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 100)]
                    // vpScenario.NumberOfPorts   (Int32)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.NumberOfPorts = 0;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioNumberOfPorts", "1", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.NumberOfPorts = 101;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioNumberOfPorts", "1", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // vpScenario.PortSpacing_m   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [PortSpacing_m]

                    //CSSPError: Type not implemented [PortSpacing_m]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortSpacing_m = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortSpacing_m", "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.PortSpacing_m = 1001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortSpacing_m", "0", "1000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // vpScenario.AcuteMixZone_m   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [AcuteMixZone_m]

                    //CSSPError: Type not implemented [AcuteMixZone_m]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.AcuteMixZone_m = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioAcuteMixZone_m", "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.AcuteMixZone_m = 101.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioAcuteMixZone_m", "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 40000)]
                    // vpScenario.ChronicMixZone_m   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [ChronicMixZone_m]

                    //CSSPError: Type not implemented [ChronicMixZone_m]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.ChronicMixZone_m = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioChronicMixZone_m", "0", "40000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.ChronicMixZone_m = 40001.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioChronicMixZone_m", "0", "40000"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 40)]
                    // vpScenario.EffluentSalinity_PSU   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [EffluentSalinity_PSU]

                    //CSSPError: Type not implemented [EffluentSalinity_PSU]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentSalinity_PSU = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentSalinity_PSU", "0", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentSalinity_PSU = 41.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentSalinity_PSU", "0", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // vpScenario.EffluentTemperature_C   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [EffluentTemperature_C]

                    //CSSPError: Type not implemented [EffluentTemperature_C]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentTemperature_C = -11.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentTemperature_C", "-10", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentTemperature_C = 41.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentTemperature_C", "-10", "40"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // vpScenario.EffluentVelocity_m_s   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [EffluentVelocity_m_s]

                    //CSSPError: Type not implemented [EffluentVelocity_m_s]

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentVelocity_m_s = -1.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentVelocity_m_s", "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.EffluentVelocity_m_s = 101.0D;
                    Assert.AreEqual(false, vpScenarioService.Add(vpScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentVelocity_m_s", "0", "100"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioService.GetVPScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // vpScenario.RawResults   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpScenario.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.LastUpdateDate_UTC = new DateTime();
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLastUpdateDate_UTC"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "VPScenarioLastUpdateDate_UTC", "1980"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpScenario.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.LastUpdateContactTVItemID = 0;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "VPScenarioLastUpdateContactTVItemID", vpScenario.LastUpdateContactTVItemID.ToString()), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenario = null;
                    vpScenario = GetFilledRandomVPScenario("");
                    vpScenario.LastUpdateContactTVItemID = 1;
                    vpScenarioService.Add(vpScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "VPScenarioLastUpdateContactTVItemID", "Contact"), vpScenario.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPScenario vpScenario = (from c in dbTestDB.VPScenarios select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenario);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        vpScenarioService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            VPScenario vpScenarioRet = vpScenarioService.GetVPScenarioWithVPScenarioID(vpScenario.VPScenarioID);
                            CheckVPScenarioFields(new List<VPScenario>() { vpScenarioRet });
                            Assert.AreEqual(vpScenario.VPScenarioID, vpScenarioRet.VPScenarioID);
                        }
                        else if (extra == "ExtraA")
                        {
                            VPScenarioExtraA vpScenarioExtraARet = vpScenarioService.GetVPScenarioExtraAWithVPScenarioID(vpScenario.VPScenarioID);
                            CheckVPScenarioExtraAFields(new List<VPScenarioExtraA>() { vpScenarioExtraARet });
                            Assert.AreEqual(vpScenario.VPScenarioID, vpScenarioExtraARet.VPScenarioID);
                        }
                        else if (extra == "ExtraB")
                        {
                            VPScenarioExtraB vpScenarioExtraBRet = vpScenarioService.GetVPScenarioExtraBWithVPScenarioID(vpScenario.VPScenarioID);
                            CheckVPScenarioExtraBFields(new List<VPScenarioExtraB>() { vpScenarioExtraBRet });
                            Assert.AreEqual(vpScenario.VPScenarioID, vpScenarioExtraBRet.VPScenarioID);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPScenario vpScenario = (from c in dbTestDB.VPScenarios select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenario);

                    List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                    vpScenarioDirectQueryList = (from c in dbTestDB.VPScenarios select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        vpScenarioService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<VPScenario> vpScenarioList = new List<VPScenario>();
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            CheckVPScenarioFields(vpScenarioList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<VPScenarioExtraA> vpScenarioExtraAList = new List<VPScenarioExtraA>();
                            vpScenarioExtraAList = vpScenarioService.GetVPScenarioExtraAList().ToList();
                            CheckVPScenarioExtraAFields(vpScenarioExtraAList);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<VPScenarioExtraB> vpScenarioExtraBList = new List<VPScenarioExtraB>();
                            vpScenarioExtraBList = vpScenarioService.GetVPScenarioExtraBList().ToList();
                            CheckVPScenarioExtraBFields(vpScenarioExtraBList);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                        vpScenarioDirectQueryList = (from c in dbTestDB.VPScenarios select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<VPScenario> vpScenarioList = new List<VPScenario>();
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            CheckVPScenarioFields(vpScenarioList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<VPScenarioExtraA> vpScenarioExtraAList = new List<VPScenarioExtraA>();
                            vpScenarioExtraAList = vpScenarioService.GetVPScenarioExtraAList().ToList();
                            CheckVPScenarioExtraAFields(vpScenarioExtraAList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraAList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<VPScenarioExtraB> vpScenarioExtraBList = new List<VPScenarioExtraB>();
                            vpScenarioExtraBList = vpScenarioService.GetVPScenarioExtraBList().ToList();
                            CheckVPScenarioExtraBFields(vpScenarioExtraBList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraBList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 1, 1,  "VPScenarioID", "");

                        List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                        vpScenarioDirectQueryList = (from c in dbTestDB.VPScenarios select c).Skip(1).Take(1).OrderBy(c => c.VPScenarioID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<VPScenario> vpScenarioList = new List<VPScenario>();
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            CheckVPScenarioFields(vpScenarioList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<VPScenarioExtraA> vpScenarioExtraAList = new List<VPScenarioExtraA>();
                            vpScenarioExtraAList = vpScenarioService.GetVPScenarioExtraAList().ToList();
                            CheckVPScenarioExtraAFields(vpScenarioExtraAList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraAList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<VPScenarioExtraB> vpScenarioExtraBList = new List<VPScenarioExtraB>();
                            vpScenarioExtraBList = vpScenarioService.GetVPScenarioExtraBList().ToList();
                            CheckVPScenarioExtraBFields(vpScenarioExtraBList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraBList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 1, 1, "VPScenarioID,InfrastructureTVItemID", "");

                        List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                        vpScenarioDirectQueryList = (from c in dbTestDB.VPScenarios select c).Skip(1).Take(1).OrderBy(c => c.VPScenarioID).ThenBy(c => c.InfrastructureTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<VPScenario> vpScenarioList = new List<VPScenario>();
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            CheckVPScenarioFields(vpScenarioList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<VPScenarioExtraA> vpScenarioExtraAList = new List<VPScenarioExtraA>();
                            vpScenarioExtraAList = vpScenarioService.GetVPScenarioExtraAList().ToList();
                            CheckVPScenarioExtraAFields(vpScenarioExtraAList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraAList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<VPScenarioExtraB> vpScenarioExtraBList = new List<VPScenarioExtraB>();
                            vpScenarioExtraBList = vpScenarioService.GetVPScenarioExtraBList().ToList();
                            CheckVPScenarioExtraBFields(vpScenarioExtraBList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraBList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioID", "VPScenarioID,EQ,4", "");

                        List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                        vpScenarioDirectQueryList = (from c in dbTestDB.VPScenarios select c).Where(c => c.VPScenarioID == 4).Skip(0).Take(1).OrderBy(c => c.VPScenarioID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<VPScenario> vpScenarioList = new List<VPScenario>();
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            CheckVPScenarioFields(vpScenarioList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<VPScenarioExtraA> vpScenarioExtraAList = new List<VPScenarioExtraA>();
                            vpScenarioExtraAList = vpScenarioService.GetVPScenarioExtraAList().ToList();
                            CheckVPScenarioExtraAFields(vpScenarioExtraAList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraAList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<VPScenarioExtraB> vpScenarioExtraBList = new List<VPScenarioExtraB>();
                            vpScenarioExtraBList = vpScenarioService.GetVPScenarioExtraBList().ToList();
                            CheckVPScenarioExtraBFields(vpScenarioExtraBList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraBList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioID", "VPScenarioID,GT,2|VPScenarioID,LT,5", "");

                        List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                        vpScenarioDirectQueryList = (from c in dbTestDB.VPScenarios select c).Where(c => c.VPScenarioID > 2 && c.VPScenarioID < 5).Skip(0).Take(1).OrderBy(c => c.VPScenarioID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<VPScenario> vpScenarioList = new List<VPScenario>();
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            CheckVPScenarioFields(vpScenarioList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<VPScenarioExtraA> vpScenarioExtraAList = new List<VPScenarioExtraA>();
                            vpScenarioExtraAList = vpScenarioService.GetVPScenarioExtraAList().ToList();
                            CheckVPScenarioExtraAFields(vpScenarioExtraAList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraAList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<VPScenarioExtraB> vpScenarioExtraBList = new List<VPScenarioExtraB>();
                            vpScenarioExtraBList = vpScenarioService.GetVPScenarioExtraBList().ToList();
                            CheckVPScenarioExtraBFields(vpScenarioExtraBList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraBList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        VPScenarioService vpScenarioService = new VPScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioService.Query = vpScenarioService.FillQuery(typeof(VPScenario), culture.TwoLetterISOLanguageName, 0, 10000, "", "VPScenarioID,GT,2|VPScenarioID,LT,5", "");

                        List<VPScenario> vpScenarioDirectQueryList = new List<VPScenario>();
                        vpScenarioDirectQueryList = (from c in dbTestDB.VPScenarios select c).Where(c => c.VPScenarioID > 2 && c.VPScenarioID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<VPScenario> vpScenarioList = new List<VPScenario>();
                            vpScenarioList = vpScenarioService.GetVPScenarioList().ToList();
                            CheckVPScenarioFields(vpScenarioList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioList[0].VPScenarioID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<VPScenarioExtraA> vpScenarioExtraAList = new List<VPScenarioExtraA>();
                            vpScenarioExtraAList = vpScenarioService.GetVPScenarioExtraAList().ToList();
                            CheckVPScenarioExtraAFields(vpScenarioExtraAList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraAList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<VPScenarioExtraB> vpScenarioExtraBList = new List<VPScenarioExtraB>();
                            vpScenarioExtraBList = vpScenarioService.GetVPScenarioExtraBList().ToList();
                            CheckVPScenarioExtraBFields(vpScenarioExtraBList);
                            Assert.AreEqual(vpScenarioDirectQueryList[0].VPScenarioID, vpScenarioExtraBList[0].VPScenarioID);
                            Assert.AreEqual(vpScenarioDirectQueryList.Count, vpScenarioExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioList() 2Where

        #region Functions private
        private void CheckVPScenarioFields(List<VPScenario> vpScenarioList)
        {
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
            Assert.IsNotNull(vpScenarioList[0].HasErrors);
        }
        private void CheckVPScenarioExtraAFields(List<VPScenarioExtraA> vpScenarioExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioExtraAList[0].SubsectorText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioExtraAList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(vpScenarioExtraAList[0].VPScenarioStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioExtraAList[0].VPScenarioStatusText));
            }
            Assert.IsNotNull(vpScenarioExtraAList[0].VPScenarioID);
            Assert.IsNotNull(vpScenarioExtraAList[0].InfrastructureTVItemID);
            Assert.IsNotNull(vpScenarioExtraAList[0].VPScenarioStatus);
            Assert.IsNotNull(vpScenarioExtraAList[0].UseAsBestEstimate);
            if (vpScenarioExtraAList[0].EffluentFlow_m3_s != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].EffluentFlow_m3_s);
            }
            if (vpScenarioExtraAList[0].EffluentConcentration_MPN_100ml != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].EffluentConcentration_MPN_100ml);
            }
            if (vpScenarioExtraAList[0].FroudeNumber != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].FroudeNumber);
            }
            if (vpScenarioExtraAList[0].PortDiameter_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].PortDiameter_m);
            }
            if (vpScenarioExtraAList[0].PortDepth_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].PortDepth_m);
            }
            if (vpScenarioExtraAList[0].PortElevation_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].PortElevation_m);
            }
            if (vpScenarioExtraAList[0].VerticalAngle_deg != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].VerticalAngle_deg);
            }
            if (vpScenarioExtraAList[0].HorizontalAngle_deg != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].HorizontalAngle_deg);
            }
            if (vpScenarioExtraAList[0].NumberOfPorts != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].NumberOfPorts);
            }
            if (vpScenarioExtraAList[0].PortSpacing_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].PortSpacing_m);
            }
            if (vpScenarioExtraAList[0].AcuteMixZone_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].AcuteMixZone_m);
            }
            if (vpScenarioExtraAList[0].ChronicMixZone_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].ChronicMixZone_m);
            }
            if (vpScenarioExtraAList[0].EffluentSalinity_PSU != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].EffluentSalinity_PSU);
            }
            if (vpScenarioExtraAList[0].EffluentTemperature_C != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].EffluentTemperature_C);
            }
            if (vpScenarioExtraAList[0].EffluentVelocity_m_s != null)
            {
                Assert.IsNotNull(vpScenarioExtraAList[0].EffluentVelocity_m_s);
            }
            if (!string.IsNullOrWhiteSpace(vpScenarioExtraAList[0].RawResults))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioExtraAList[0].RawResults));
            }
            Assert.IsNotNull(vpScenarioExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpScenarioExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpScenarioExtraAList[0].HasErrors);
        }
        private void CheckVPScenarioExtraBFields(List<VPScenarioExtraB> vpScenarioExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(vpScenarioExtraBList[0].VPScenarioReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioExtraBList[0].VPScenarioReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioExtraBList[0].SubsectorText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioExtraBList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(vpScenarioExtraBList[0].VPScenarioStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioExtraBList[0].VPScenarioStatusText));
            }
            Assert.IsNotNull(vpScenarioExtraBList[0].VPScenarioID);
            Assert.IsNotNull(vpScenarioExtraBList[0].InfrastructureTVItemID);
            Assert.IsNotNull(vpScenarioExtraBList[0].VPScenarioStatus);
            Assert.IsNotNull(vpScenarioExtraBList[0].UseAsBestEstimate);
            if (vpScenarioExtraBList[0].EffluentFlow_m3_s != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].EffluentFlow_m3_s);
            }
            if (vpScenarioExtraBList[0].EffluentConcentration_MPN_100ml != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].EffluentConcentration_MPN_100ml);
            }
            if (vpScenarioExtraBList[0].FroudeNumber != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].FroudeNumber);
            }
            if (vpScenarioExtraBList[0].PortDiameter_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].PortDiameter_m);
            }
            if (vpScenarioExtraBList[0].PortDepth_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].PortDepth_m);
            }
            if (vpScenarioExtraBList[0].PortElevation_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].PortElevation_m);
            }
            if (vpScenarioExtraBList[0].VerticalAngle_deg != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].VerticalAngle_deg);
            }
            if (vpScenarioExtraBList[0].HorizontalAngle_deg != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].HorizontalAngle_deg);
            }
            if (vpScenarioExtraBList[0].NumberOfPorts != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].NumberOfPorts);
            }
            if (vpScenarioExtraBList[0].PortSpacing_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].PortSpacing_m);
            }
            if (vpScenarioExtraBList[0].AcuteMixZone_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].AcuteMixZone_m);
            }
            if (vpScenarioExtraBList[0].ChronicMixZone_m != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].ChronicMixZone_m);
            }
            if (vpScenarioExtraBList[0].EffluentSalinity_PSU != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].EffluentSalinity_PSU);
            }
            if (vpScenarioExtraBList[0].EffluentTemperature_C != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].EffluentTemperature_C);
            }
            if (vpScenarioExtraBList[0].EffluentVelocity_m_s != null)
            {
                Assert.IsNotNull(vpScenarioExtraBList[0].EffluentVelocity_m_s);
            }
            if (!string.IsNullOrWhiteSpace(vpScenarioExtraBList[0].RawResults))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioExtraBList[0].RawResults));
            }
            Assert.IsNotNull(vpScenarioExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpScenarioExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpScenarioExtraBList[0].HasErrors);
        }
        private VPScenario GetFilledRandomVPScenario(string OmitPropName)
        {
            VPScenario vpScenario = new VPScenario();

            if (OmitPropName != "InfrastructureTVItemID") vpScenario.InfrastructureTVItemID = 40;
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
