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
            if (OmitPropName != "LastUpdateDate_UTC") vpAmbient.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpAmbient.LastUpdateContactTVItemID = 2;

            return vpAmbient;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPAmbient_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPAmbientService vpAmbientService = new VPAmbientService(new GetParam(), dbTestDB, ContactID);

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

                    Assert.AreEqual(vpAmbientService.GetRead().Count(), vpAmbientService.GetEdit().Count());

                    vpAmbientService.Add(vpAmbient);
                    if (vpAmbient.HasErrors)
                    {
                        Assert.AreEqual("", vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, vpAmbientService.GetRead().Where(c => c == vpAmbient).Any());
                    vpAmbientService.Update(vpAmbient);
                    if (vpAmbient.HasErrors)
                    {
                        Assert.AreEqual("", vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, vpAmbientService.GetRead().Count());
                    vpAmbientService.Delete(vpAmbient);
                    if (vpAmbient.HasErrors)
                    {
                        Assert.AreEqual("", vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPAmbientVPAmbientID), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.VPAmbientID = 10000000;
                    vpAmbientService.Update(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPAmbient, CSSPModelsRes.VPAmbientVPAmbientID, vpAmbient.VPAmbientID.ToString()), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = Error)]
                    // vpAmbient.VPScenarioID   (Int32)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.VPScenarioID = 0;
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenario, CSSPModelsRes.VPAmbientVPScenarioID, vpAmbient.VPScenarioID.ToString()), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10)]
                    // vpAmbient.Row   (Int32)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.Row = -1;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientRow, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.Row = 11;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientRow, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientMeasurementDepth_m, "0", "1000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.MeasurementDepth_m = 1001.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientMeasurementDepth_m, "0", "1000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.CurrentSpeed_m_s = 11.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientCurrentDirection_deg, "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.CurrentDirection_deg = 181.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientCurrentDirection_deg, "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.AmbientSalinity_PSU = 41.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientAmbientTemperature_C, "-10", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.AmbientTemperature_C = 41.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientAmbientTemperature_C, "-10", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000000)]
                    // vpAmbient.BackgroundConcentration_MPN_100ml   (Int32)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.BackgroundConcentration_MPN_100ml = -1;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "10000000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.BackgroundConcentration_MPN_100ml = 10000001;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "10000000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "100"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.PollutantDecayRate_per_day = 101.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "100"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.FarFieldCurrentSpeed_m_s = 11.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientFarFieldCurrentDirection_deg, "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.FarFieldCurrentDirection_deg = 181.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientFarFieldCurrentDirection_deg, "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "1"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.FarFieldDiffusionCoefficient = 2.0D;
                    Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "1"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // vpAmbient.VPAmbientWeb   (VPAmbientWeb)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.VPAmbientWeb = null;
                    Assert.IsNull(vpAmbient.VPAmbientWeb);

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.VPAmbientWeb = new VPAmbientWeb();
                    Assert.IsNotNull(vpAmbient.VPAmbientWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // vpAmbient.VPAmbientReport   (VPAmbientReport)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.VPAmbientReport = null;
                    Assert.IsNull(vpAmbient.VPAmbientReport);

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.VPAmbientReport = new VPAmbientReport();
                    Assert.IsNotNull(vpAmbient.VPAmbientReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpAmbient.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.LastUpdateDate_UTC = new DateTime();
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPAmbientLastUpdateDate_UTC), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.VPAmbientLastUpdateDate_UTC, "1980"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpAmbient.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.LastUpdateContactTVItemID = 0;
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPAmbientLastUpdateContactTVItemID, vpAmbient.LastUpdateContactTVItemID.ToString()), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpAmbient = null;
                    vpAmbient = GetFilledRandomVPAmbient("");
                    vpAmbient.LastUpdateContactTVItemID = 1;
                    vpAmbientService.Add(vpAmbient);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPAmbientLastUpdateContactTVItemID, "Contact"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    VPAmbientService vpAmbientService = new VPAmbientService(new GetParam(), dbTestDB, ContactID);
                    VPAmbient vpAmbient = (from c in vpAmbientService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpAmbient);

                    VPAmbient vpAmbientRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpAmbientService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpAmbientRet = vpAmbientService.GetVPAmbientWithVPAmbientID(vpAmbient.VPAmbientID);
                            Assert.IsNull(vpAmbientRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpAmbientRet = vpAmbientService.GetVPAmbientWithVPAmbientID(vpAmbient.VPAmbientID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpAmbientRet = vpAmbientService.GetVPAmbientWithVPAmbientID(vpAmbient.VPAmbientID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpAmbientRet = vpAmbientService.GetVPAmbientWithVPAmbientID(vpAmbient.VPAmbientID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // VPAmbient fields
                        Assert.IsNotNull(vpAmbientRet.VPAmbientID);
                        Assert.IsNotNull(vpAmbientRet.VPScenarioID);
                        Assert.IsNotNull(vpAmbientRet.Row);
                        if (vpAmbientRet.MeasurementDepth_m != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.MeasurementDepth_m);
                        }
                        if (vpAmbientRet.CurrentSpeed_m_s != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.CurrentSpeed_m_s);
                        }
                        if (vpAmbientRet.CurrentDirection_deg != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.CurrentDirection_deg);
                        }
                        if (vpAmbientRet.AmbientSalinity_PSU != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.AmbientSalinity_PSU);
                        }
                        if (vpAmbientRet.AmbientTemperature_C != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.AmbientTemperature_C);
                        }
                        if (vpAmbientRet.BackgroundConcentration_MPN_100ml != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.BackgroundConcentration_MPN_100ml);
                        }
                        if (vpAmbientRet.PollutantDecayRate_per_day != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.PollutantDecayRate_per_day);
                        }
                        if (vpAmbientRet.FarFieldCurrentSpeed_m_s != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.FarFieldCurrentSpeed_m_s);
                        }
                        if (vpAmbientRet.FarFieldCurrentDirection_deg != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.FarFieldCurrentDirection_deg);
                        }
                        if (vpAmbientRet.FarFieldDiffusionCoefficient != null)
                        {
                            Assert.IsNotNull(vpAmbientRet.FarFieldDiffusionCoefficient);
                        }
                        Assert.IsNotNull(vpAmbientRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(vpAmbientRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // VPAmbientWeb and VPAmbientReport fields should be null here
                            Assert.IsNull(vpAmbientRet.VPAmbientWeb);
                            Assert.IsNull(vpAmbientRet.VPAmbientReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // VPAmbientWeb fields should not be null and VPAmbientReport fields should be null here
                            if (vpAmbientRet.VPAmbientWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpAmbientRet.VPAmbientWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(vpAmbientRet.VPAmbientReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // VPAmbientWeb and VPAmbientReport fields should NOT be null here
                            if (vpAmbientRet.VPAmbientWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpAmbientRet.VPAmbientWeb.LastUpdateContactTVText));
                            }
                            if (vpAmbientRet.VPAmbientReport.VPAmbientReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpAmbientRet.VPAmbientReport.VPAmbientReportTest));
                            }
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
                    VPAmbientService vpAmbientService = new VPAmbientService(new GetParam(), dbTestDB, ContactID);
                    VPAmbient vpAmbient = (from c in vpAmbientService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpAmbient);

                    List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpAmbientService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                            Assert.AreEqual(0, vpAmbientList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // VPAmbient fields
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

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // VPAmbientWeb and VPAmbientReport fields should be null here
                            Assert.IsNull(vpAmbientList[0].VPAmbientWeb);
                            Assert.IsNull(vpAmbientList[0].VPAmbientReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // VPAmbientWeb fields should not be null and VPAmbientReport fields should be null here
                            if (vpAmbientList[0].VPAmbientWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpAmbientList[0].VPAmbientWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(vpAmbientList[0].VPAmbientReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // VPAmbientWeb and VPAmbientReport fields should NOT be null here
                            if (vpAmbientList[0].VPAmbientWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpAmbientList[0].VPAmbientWeb.LastUpdateContactTVText));
                            }
                            if (vpAmbientList[0].VPAmbientReport.VPAmbientReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpAmbientList[0].VPAmbientReport.VPAmbientReportTest));
                            }
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
                    List<VPAmbient> vpAmbientList = new List<VPAmbient>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(VPAmbient), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        VPAmbientService vpAmbientService = new VPAmbientService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                            Assert.AreEqual(0, vpAmbientList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpAmbientList = vpAmbientService.GetVPAmbientList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, vpAmbientList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPAmbientList() Skip Take

    }
}
