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
    public partial class VPAmbientServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPAmbientService vpAmbientService { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientServiceTest() : base()
        {
            //vpAmbientService = new VPAmbientService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPAmbient_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = vpAmbientService.GetVPAmbientList().Count();

                    Assert.AreEqual(vpAmbientService.GetVPAmbientList().Count(), (from c in dbTestDB.VPAmbients select c).Take(200).Count());

                    vpAmbientService.Add(vpAmbient);
                    if (vpAmbient.HasErrors)
                    {
                        Assert.AreEqual("", vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, vpAmbientService.GetVPAmbientList().Where(c => c == vpAmbient).Any());
                    vpAmbientService.Update(vpAmbient);
                    if (vpAmbient.HasErrors)
                    {
                        Assert.AreEqual("", vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbientService.Delete(vpAmbient);
                    if (vpAmbient.HasErrors)
                    {
                        Assert.AreEqual("", vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // vpAmbient.VPAmbientID   (Int32)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.VPAmbientID = 0;
                    vpAmbientService.Update(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPAmbientVPAmbientID"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.VPAmbientID = 10000000;
                    vpAmbientService.Update(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientVPAmbientID", vpAmbient.VPAmbientID.ToString()), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
                    // vpAmbient.VPScenarioID   (Int32)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.VPScenarioID = 0;
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPAmbientVPScenarioID", vpAmbient.VPScenarioID.ToString()), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10)]
                    // vpAmbient.Row   (Int32)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.Row = -1;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientRow", "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.Row = 11;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientRow", "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // vpAmbient.MeasurementDepth_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [MeasurementDepth_m]

                    //Error: Type not implemented [MeasurementDepth_m]

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.MeasurementDepth_m = -1.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientMeasurementDepth_m", "0", "1000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.MeasurementDepth_m = 1001.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientMeasurementDepth_m", "0", "1000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10)]
                    // vpAmbient.CurrentSpeed_m_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [CurrentSpeed_m_s]

                    //Error: Type not implemented [CurrentSpeed_m_s]

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.CurrentSpeed_m_s = -1.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientCurrentSpeed_m_s", "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.CurrentSpeed_m_s = 11.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientCurrentSpeed_m_s", "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-180, 180)]
                    // vpAmbient.CurrentDirection_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [CurrentDirection_deg]

                    //Error: Type not implemented [CurrentDirection_deg]

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.CurrentDirection_deg = -181.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientCurrentDirection_deg", "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.CurrentDirection_deg = 181.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientCurrentDirection_deg", "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 40)]
                    // vpAmbient.AmbientSalinity_PSU   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [AmbientSalinity_PSU]

                    //Error: Type not implemented [AmbientSalinity_PSU]

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.AmbientSalinity_PSU = -1.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientAmbientSalinity_PSU", "0", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.AmbientSalinity_PSU = 41.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientAmbientSalinity_PSU", "0", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-10, 40)]
                    // vpAmbient.AmbientTemperature_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [AmbientTemperature_C]

                    //Error: Type not implemented [AmbientTemperature_C]

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.AmbientTemperature_C = -11.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientAmbientTemperature_C", "-10", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.AmbientTemperature_C = 41.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientAmbientTemperature_C", "-10", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000000)]
                    // vpAmbient.BackgroundConcentration_MPN_100ml   (Int32)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.BackgroundConcentration_MPN_100ml = -1;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientBackgroundConcentration_MPN_100ml", "0", "10000000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.BackgroundConcentration_MPN_100ml = 10000001;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientBackgroundConcentration_MPN_100ml", "0", "10000000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // vpAmbient.PollutantDecayRate_per_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [PollutantDecayRate_per_day]

                    //Error: Type not implemented [PollutantDecayRate_per_day]

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.PollutantDecayRate_per_day = -1.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientPollutantDecayRate_per_day", "0", "100"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.PollutantDecayRate_per_day = 101.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientPollutantDecayRate_per_day", "0", "100"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10)]
                    // vpAmbient.FarFieldCurrentSpeed_m_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [FarFieldCurrentSpeed_m_s]

                    //Error: Type not implemented [FarFieldCurrentSpeed_m_s]

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.FarFieldCurrentSpeed_m_s = -1.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientFarFieldCurrentSpeed_m_s", "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.FarFieldCurrentSpeed_m_s = 11.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientFarFieldCurrentSpeed_m_s", "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-180, 180)]
                    // vpAmbient.FarFieldCurrentDirection_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [FarFieldCurrentDirection_deg]

                    //Error: Type not implemented [FarFieldCurrentDirection_deg]

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.FarFieldCurrentDirection_deg = -181.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientFarFieldCurrentDirection_deg", "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.FarFieldCurrentDirection_deg = 181.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientFarFieldCurrentDirection_deg", "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1)]
                    // vpAmbient.FarFieldDiffusionCoefficient   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [FarFieldDiffusionCoefficient]

                    //Error: Type not implemented [FarFieldDiffusionCoefficient]

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.FarFieldDiffusionCoefficient = -1.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientFarFieldDiffusionCoefficient", "0", "1"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.FarFieldDiffusionCoefficient = 2.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientFarFieldDiffusionCoefficient", "0", "1"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetVPAmbientList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpAmbient.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.LastUpdateDate_UTC = new DateTime();
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPAmbientLastUpdateDate_UTC"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "VPAmbientLastUpdateDate_UTC", "1980"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpAmbient.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.LastUpdateContactTVItemID = 0;
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "VPAmbientLastUpdateContactTVItemID", vpAmbient.LastUpdateContactTVItemID.ToString()), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.LastUpdateContactTVItemID = 1;
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "VPAmbientLastUpdateContactTVItemID", "Contact"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpAmbient.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpAmbient.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetVPAmbientWithVPAmbientID(vpAmbient.VPAmbientID)
        [TestMethod]
        public void GetVPAmbientWithVPAmbientID__vpAmbient_VPAmbientID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPAmbient vpAmbient = (from c in dbTestDB.VPAmbients select c).FirstOrDefault();
                    Assert.IsNotNull(vpAmbient);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        vpAmbientService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            VPAmbient vpAmbientRet = vpAmbientService.GetVPAmbientWithVPAmbientID(vpAmbient.VPAmbientID);
                            CheckVPAmbientFields(new List<VPAmbient>() { vpAmbientRet });
                            Assert.AreEqual(vpAmbient.VPAmbientID, vpAmbientRet.VPAmbientID);
                        }
                        else if (detail == "A")
                        {
                            VPAmbient_A vpAmbient_ARet = vpAmbientService.GetVPAmbient_AWithVPAmbientID(vpAmbient.VPAmbientID);
                            CheckVPAmbient_AFields(new List<VPAmbient_A>() { vpAmbient_ARet });
                            Assert.AreEqual(vpAmbient.VPAmbientID, vpAmbient_ARet.VPAmbientID);
                        }
                        else if (detail == "B")
                        {
                            VPAmbient_B vpAmbient_BRet = vpAmbientService.GetVPAmbient_BWithVPAmbientID(vpAmbient.VPAmbientID);
                            CheckVPAmbient_BFields(new List<VPAmbient_B>() { vpAmbient_BRet });
                            Assert.AreEqual(vpAmbient.VPAmbientID, vpAmbient_BRet.VPAmbientID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPAmbientWithVPAmbientID(vpAmbient.VPAmbientID)

        #region Tests Generated for GetVPAmbientList()
        [TestMethod]
        public void GetVPAmbientList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPAmbient vpAmbient = (from c in dbTestDB.VPAmbients select c).FirstOrDefault();
                    Assert.IsNotNull(vpAmbient);

                    List<VPAmbient> vpAmbientDirectQueryList = new List<VPAmbient>();
                    vpAmbientDirectQueryList = (from c in dbTestDB.VPAmbients select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        vpAmbientService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                            CheckVPAmbientFields(vpAmbientList);
                        }
                        else if (detail == "A")
                        {
                            List<VPAmbient_A> vpAmbient_AList = new List<VPAmbient_A>();
                            vpAmbient_AList = vpAmbientService.GetVPAmbient_AList().ToList();
                            CheckVPAmbient_AFields(vpAmbient_AList);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPAmbient_B> vpAmbient_BList = new List<VPAmbient_B>();
                            vpAmbient_BList = vpAmbientService.GetVPAmbient_BList().ToList();
                            CheckVPAmbient_BFields(vpAmbient_BList);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPAmbientList()

        #region Tests Generated for GetVPAmbientList() Skip Take
        [TestMethod]
        public void GetVPAmbientList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<VPAmbient> vpAmbientDirectQueryList = new List<VPAmbient>();
                        vpAmbientDirectQueryList = (from c in dbTestDB.VPAmbients select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                            CheckVPAmbientFields(vpAmbientList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbientList[0].VPAmbientID);
                        }
                        else if (detail == "A")
                        {
                            List<VPAmbient_A> vpAmbient_AList = new List<VPAmbient_A>();
                            vpAmbient_AList = vpAmbientService.GetVPAmbient_AList().ToList();
                            CheckVPAmbient_AFields(vpAmbient_AList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_AList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPAmbient_B> vpAmbient_BList = new List<VPAmbient_B>();
                            vpAmbient_BList = vpAmbientService.GetVPAmbient_BList().ToList();
                            CheckVPAmbient_BFields(vpAmbient_BList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_BList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPAmbientList() Skip Take

        #region Tests Generated for GetVPAmbientList() Skip Take Order
        [TestMethod]
        public void GetVPAmbientList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), culture.TwoLetterISOLanguageName, 1, 1,  "VPAmbientID", "");

                        List<VPAmbient> vpAmbientDirectQueryList = new List<VPAmbient>();
                        vpAmbientDirectQueryList = (from c in dbTestDB.VPAmbients select c).Skip(1).Take(1).OrderBy(c => c.VPAmbientID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                            CheckVPAmbientFields(vpAmbientList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbientList[0].VPAmbientID);
                        }
                        else if (detail == "A")
                        {
                            List<VPAmbient_A> vpAmbient_AList = new List<VPAmbient_A>();
                            vpAmbient_AList = vpAmbientService.GetVPAmbient_AList().ToList();
                            CheckVPAmbient_AFields(vpAmbient_AList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_AList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPAmbient_B> vpAmbient_BList = new List<VPAmbient_B>();
                            vpAmbient_BList = vpAmbientService.GetVPAmbient_BList().ToList();
                            CheckVPAmbient_BFields(vpAmbient_BList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_BList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPAmbientList() Skip Take Order

        #region Tests Generated for GetVPAmbientList() Skip Take 2Order
        [TestMethod]
        public void GetVPAmbientList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), culture.TwoLetterISOLanguageName, 1, 1, "VPAmbientID,VPScenarioID", "");

                        List<VPAmbient> vpAmbientDirectQueryList = new List<VPAmbient>();
                        vpAmbientDirectQueryList = (from c in dbTestDB.VPAmbients select c).Skip(1).Take(1).OrderBy(c => c.VPAmbientID).ThenBy(c => c.VPScenarioID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                            CheckVPAmbientFields(vpAmbientList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbientList[0].VPAmbientID);
                        }
                        else if (detail == "A")
                        {
                            List<VPAmbient_A> vpAmbient_AList = new List<VPAmbient_A>();
                            vpAmbient_AList = vpAmbientService.GetVPAmbient_AList().ToList();
                            CheckVPAmbient_AFields(vpAmbient_AList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_AList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPAmbient_B> vpAmbient_BList = new List<VPAmbient_B>();
                            vpAmbient_BList = vpAmbientService.GetVPAmbient_BList().ToList();
                            CheckVPAmbient_BFields(vpAmbient_BList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_BList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPAmbientList() Skip Take 2Order

        #region Tests Generated for GetVPAmbientList() Skip Take Order Where
        [TestMethod]
        public void GetVPAmbientList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), culture.TwoLetterISOLanguageName, 0, 1, "VPAmbientID", "VPAmbientID,EQ,4", "");

                        List<VPAmbient> vpAmbientDirectQueryList = new List<VPAmbient>();
                        vpAmbientDirectQueryList = (from c in dbTestDB.VPAmbients select c).Where(c => c.VPAmbientID == 4).Skip(0).Take(1).OrderBy(c => c.VPAmbientID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                            CheckVPAmbientFields(vpAmbientList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbientList[0].VPAmbientID);
                        }
                        else if (detail == "A")
                        {
                            List<VPAmbient_A> vpAmbient_AList = new List<VPAmbient_A>();
                            vpAmbient_AList = vpAmbientService.GetVPAmbient_AList().ToList();
                            CheckVPAmbient_AFields(vpAmbient_AList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_AList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPAmbient_B> vpAmbient_BList = new List<VPAmbient_B>();
                            vpAmbient_BList = vpAmbientService.GetVPAmbient_BList().ToList();
                            CheckVPAmbient_BFields(vpAmbient_BList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_BList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPAmbientList() Skip Take Order Where

        #region Tests Generated for GetVPAmbientList() Skip Take Order 2Where
        [TestMethod]
        public void GetVPAmbientList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), culture.TwoLetterISOLanguageName, 0, 1, "VPAmbientID", "VPAmbientID,GT,2|VPAmbientID,LT,5", "");

                        List<VPAmbient> vpAmbientDirectQueryList = new List<VPAmbient>();
                        vpAmbientDirectQueryList = (from c in dbTestDB.VPAmbients select c).Where(c => c.VPAmbientID > 2 && c.VPAmbientID < 5).Skip(0).Take(1).OrderBy(c => c.VPAmbientID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                            CheckVPAmbientFields(vpAmbientList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbientList[0].VPAmbientID);
                        }
                        else if (detail == "A")
                        {
                            List<VPAmbient_A> vpAmbient_AList = new List<VPAmbient_A>();
                            vpAmbient_AList = vpAmbientService.GetVPAmbient_AList().ToList();
                            CheckVPAmbient_AFields(vpAmbient_AList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_AList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPAmbient_B> vpAmbient_BList = new List<VPAmbient_B>();
                            vpAmbient_BList = vpAmbientService.GetVPAmbient_BList().ToList();
                            CheckVPAmbient_BFields(vpAmbient_BList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_BList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPAmbientList() Skip Take Order 2Where

        #region Tests Generated for GetVPAmbientList() 2Where
        [TestMethod]
        public void GetVPAmbientList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPAmbientService vpAmbientService = new VPAmbientService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpAmbientService.Query = vpAmbientService.FillQuery(typeof(VPAmbient), culture.TwoLetterISOLanguageName, 0, 10000, "", "VPAmbientID,GT,2|VPAmbientID,LT,5", "");

                        List<VPAmbient> vpAmbientDirectQueryList = new List<VPAmbient>();
                        vpAmbientDirectQueryList = (from c in dbTestDB.VPAmbients select c).Where(c => c.VPAmbientID > 2 && c.VPAmbientID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                            CheckVPAmbientFields(vpAmbientList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbientList[0].VPAmbientID);
                        }
                        else if (detail == "A")
                        {
                            List<VPAmbient_A> vpAmbient_AList = new List<VPAmbient_A>();
                            vpAmbient_AList = vpAmbientService.GetVPAmbient_AList().ToList();
                            CheckVPAmbient_AFields(vpAmbient_AList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_AList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPAmbient_B> vpAmbient_BList = new List<VPAmbient_B>();
                            vpAmbient_BList = vpAmbientService.GetVPAmbient_BList().ToList();
                            CheckVPAmbient_BFields(vpAmbient_BList);
                            Assert.AreEqual(vpAmbientDirectQueryList[0].VPAmbientID, vpAmbient_BList[0].VPAmbientID);
                            Assert.AreEqual(vpAmbientDirectQueryList.Count, vpAmbient_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPAmbientList() 2Where

        #region Functions private
        private void CheckVPAmbientFields(List<VPAmbient> vpAmbientList)
        {
            Assert.IsNotNull(vpAmbientList[0].VPAmbientID);
            Assert.IsNotNull(vpAmbientList[0].VPScenarioID);
            Assert.IsNotNull(vpAmbientList[0].Row);
            if (vpAmbientList[0].MeasurementDepth_m != null)
            {
                Assert.IsNotNull(vpAmbientList[0].MeasurementDepth_m);
            }
            if (vpAmbientList[0].CurrentSpeed_m_s != null)
            {
                Assert.IsNotNull(vpAmbientList[0].CurrentSpeed_m_s);
            }
            if (vpAmbientList[0].CurrentDirection_deg != null)
            {
                Assert.IsNotNull(vpAmbientList[0].CurrentDirection_deg);
            }
            if (vpAmbientList[0].AmbientSalinity_PSU != null)
            {
                Assert.IsNotNull(vpAmbientList[0].AmbientSalinity_PSU);
            }
            if (vpAmbientList[0].AmbientTemperature_C != null)
            {
                Assert.IsNotNull(vpAmbientList[0].AmbientTemperature_C);
            }
            if (vpAmbientList[0].BackgroundConcentration_MPN_100ml != null)
            {
                Assert.IsNotNull(vpAmbientList[0].BackgroundConcentration_MPN_100ml);
            }
            if (vpAmbientList[0].PollutantDecayRate_per_day != null)
            {
                Assert.IsNotNull(vpAmbientList[0].PollutantDecayRate_per_day);
            }
            if (vpAmbientList[0].FarFieldCurrentSpeed_m_s != null)
            {
                Assert.IsNotNull(vpAmbientList[0].FarFieldCurrentSpeed_m_s);
            }
            if (vpAmbientList[0].FarFieldCurrentDirection_deg != null)
            {
                Assert.IsNotNull(vpAmbientList[0].FarFieldCurrentDirection_deg);
            }
            if (vpAmbientList[0].FarFieldDiffusionCoefficient != null)
            {
                Assert.IsNotNull(vpAmbientList[0].FarFieldDiffusionCoefficient);
            }
            Assert.IsNotNull(vpAmbientList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpAmbientList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpAmbientList[0].HasErrors);
        }
        private void CheckVPAmbient_AFields(List<VPAmbient_A> vpAmbient_AList)
        {
            Assert.IsNotNull(vpAmbient_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(vpAmbient_AList[0].VPAmbientID);
            Assert.IsNotNull(vpAmbient_AList[0].VPScenarioID);
            Assert.IsNotNull(vpAmbient_AList[0].Row);
            if (vpAmbient_AList[0].MeasurementDepth_m != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].MeasurementDepth_m);
            }
            if (vpAmbient_AList[0].CurrentSpeed_m_s != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].CurrentSpeed_m_s);
            }
            if (vpAmbient_AList[0].CurrentDirection_deg != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].CurrentDirection_deg);
            }
            if (vpAmbient_AList[0].AmbientSalinity_PSU != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].AmbientSalinity_PSU);
            }
            if (vpAmbient_AList[0].AmbientTemperature_C != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].AmbientTemperature_C);
            }
            if (vpAmbient_AList[0].BackgroundConcentration_MPN_100ml != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].BackgroundConcentration_MPN_100ml);
            }
            if (vpAmbient_AList[0].PollutantDecayRate_per_day != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].PollutantDecayRate_per_day);
            }
            if (vpAmbient_AList[0].FarFieldCurrentSpeed_m_s != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].FarFieldCurrentSpeed_m_s);
            }
            if (vpAmbient_AList[0].FarFieldCurrentDirection_deg != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].FarFieldCurrentDirection_deg);
            }
            if (vpAmbient_AList[0].FarFieldDiffusionCoefficient != null)
            {
                Assert.IsNotNull(vpAmbient_AList[0].FarFieldDiffusionCoefficient);
            }
            Assert.IsNotNull(vpAmbient_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpAmbient_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpAmbient_AList[0].HasErrors);
        }
        private void CheckVPAmbient_BFields(List<VPAmbient_B> vpAmbient_BList)
        {
            if (!string.IsNullOrWhiteSpace(vpAmbient_BList[0].VPAmbientReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpAmbient_BList[0].VPAmbientReportTest));
            }
            Assert.IsNotNull(vpAmbient_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(vpAmbient_BList[0].VPAmbientID);
            Assert.IsNotNull(vpAmbient_BList[0].VPScenarioID);
            Assert.IsNotNull(vpAmbient_BList[0].Row);
            if (vpAmbient_BList[0].MeasurementDepth_m != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].MeasurementDepth_m);
            }
            if (vpAmbient_BList[0].CurrentSpeed_m_s != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].CurrentSpeed_m_s);
            }
            if (vpAmbient_BList[0].CurrentDirection_deg != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].CurrentDirection_deg);
            }
            if (vpAmbient_BList[0].AmbientSalinity_PSU != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].AmbientSalinity_PSU);
            }
            if (vpAmbient_BList[0].AmbientTemperature_C != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].AmbientTemperature_C);
            }
            if (vpAmbient_BList[0].BackgroundConcentration_MPN_100ml != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].BackgroundConcentration_MPN_100ml);
            }
            if (vpAmbient_BList[0].PollutantDecayRate_per_day != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].PollutantDecayRate_per_day);
            }
            if (vpAmbient_BList[0].FarFieldCurrentSpeed_m_s != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].FarFieldCurrentSpeed_m_s);
            }
            if (vpAmbient_BList[0].FarFieldCurrentDirection_deg != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].FarFieldCurrentDirection_deg);
            }
            if (vpAmbient_BList[0].FarFieldDiffusionCoefficient != null)
            {
                Assert.IsNotNull(vpAmbient_BList[0].FarFieldDiffusionCoefficient);
            }
            Assert.IsNotNull(vpAmbient_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpAmbient_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpAmbient_BList[0].HasErrors);
        }
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
            if (OmitPropName != "LastUpdateDate_UTC") vpAmbient.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpAmbient.LastUpdateContactTVItemID = 2;

            return vpAmbient;
        }
        #endregion Functions private
    }
}
