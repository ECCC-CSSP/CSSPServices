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
            if (OmitPropName != "LastUpdateContactTVText") vpAmbient.LastUpdateContactTVText = GetRandomString("", 5);

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

                VPAmbientService vpAmbientService = new VPAmbientService(LanguageRequest, dbTestDB, ContactID);

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


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // vpAmbient.VPAmbientID   (Int32)
                // -----------------------------------

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.VPAmbientID = 0;
                vpAmbientService.Update(vpAmbient);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.VPAmbientVPAmbientID), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = Error)]
                // vpAmbient.VPScenarioID   (Int32)
                // -----------------------------------

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.VPScenarioID = 0;
                vpAmbientService.Add(vpAmbient);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.VPScenario, ModelsRes.VPAmbientVPScenarioID, vpAmbient.VPScenarioID.ToString()), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 10)]
                // vpAmbient.Row   (Int32)
                // -----------------------------------

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.Row = -1;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.Row = 11;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 1000)]
                // vpAmbient.MeasurementDepth_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [MeasurementDepth_m]

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.MeasurementDepth_m = -1.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientMeasurementDepth_m, "0", "1000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.MeasurementDepth_m = 1001.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientMeasurementDepth_m, "0", "1000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 10)]
                // vpAmbient.CurrentSpeed_m_s   (Double)
                // -----------------------------------

                //Error: Type not implemented [CurrentSpeed_m_s]

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.CurrentSpeed_m_s = -1.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.CurrentSpeed_m_s = 11.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-180, 180)]
                // vpAmbient.CurrentDirection_deg   (Double)
                // -----------------------------------

                //Error: Type not implemented [CurrentDirection_deg]

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.CurrentDirection_deg = -181.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.CurrentDirection_deg = 181.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 40)]
                // vpAmbient.AmbientSalinity_PSU   (Double)
                // -----------------------------------

                //Error: Type not implemented [AmbientSalinity_PSU]

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.AmbientSalinity_PSU = -1.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.AmbientSalinity_PSU = 41.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-10, 40)]
                // vpAmbient.AmbientTemperature_C   (Double)
                // -----------------------------------

                //Error: Type not implemented [AmbientTemperature_C]

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.AmbientTemperature_C = -11.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "-10", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.AmbientTemperature_C = 41.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "-10", "40"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 10000000)]
                // vpAmbient.BackgroundConcentration_MPN_100ml   (Int32)
                // -----------------------------------

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.BackgroundConcentration_MPN_100ml = -1;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "10000000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.BackgroundConcentration_MPN_100ml = 10000001;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "10000000"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100)]
                // vpAmbient.PollutantDecayRate_per_day   (Double)
                // -----------------------------------

                //Error: Type not implemented [PollutantDecayRate_per_day]

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.PollutantDecayRate_per_day = -1.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "100"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.PollutantDecayRate_per_day = 101.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "100"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 10)]
                // vpAmbient.FarFieldCurrentSpeed_m_s   (Double)
                // -----------------------------------

                //Error: Type not implemented [FarFieldCurrentSpeed_m_s]

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.FarFieldCurrentSpeed_m_s = -1.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.FarFieldCurrentSpeed_m_s = 11.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-180, 180)]
                // vpAmbient.FarFieldCurrentDirection_deg   (Double)
                // -----------------------------------

                //Error: Type not implemented [FarFieldCurrentDirection_deg]

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.FarFieldCurrentDirection_deg = -181.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.FarFieldCurrentDirection_deg = 181.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "-180", "180"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 1)]
                // vpAmbient.FarFieldDiffusionCoefficient   (Double)
                // -----------------------------------

                //Error: Type not implemented [FarFieldDiffusionCoefficient]

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.FarFieldDiffusionCoefficient = -1.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "1"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());
                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.FarFieldDiffusionCoefficient = 2.0D;
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "1"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // vpAmbient.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // vpAmbient.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.LastUpdateContactTVItemID = 0;
                vpAmbientService.Add(vpAmbient);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPAmbientLastUpdateContactTVItemID, vpAmbient.LastUpdateContactTVItemID.ToString()), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.LastUpdateContactTVItemID = 1;
                vpAmbientService.Add(vpAmbient);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.VPAmbientLastUpdateContactTVItemID, "Contact"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // vpAmbient.LastUpdateContactTVText   (String)
                // -----------------------------------

                vpAmbient = null;
                vpAmbient = GetFilledRandomVPAmbient("");
                vpAmbient.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, vpAmbientService.Add(vpAmbient));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.VPAmbientLastUpdateContactTVText, "200"), vpAmbient.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, vpAmbientService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // vpAmbient.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void VPAmbient_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                VPAmbientService vpAmbientService = new VPAmbientService(LanguageRequest, dbTestDB, ContactID);
                VPAmbient vpAmbient = (from c in vpAmbientService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(vpAmbient);

                VPAmbient vpAmbientRet = vpAmbientService.GetVPAmbientWithVPAmbientID(vpAmbient.VPAmbientID);
                Assert.IsNotNull(vpAmbientRet.VPAmbientID);
                Assert.IsNotNull(vpAmbientRet.VPScenarioID);
                Assert.IsNotNull(vpAmbientRet.Row);
                Assert.IsNotNull(vpAmbientRet.MeasurementDepth_m);
                Assert.IsNotNull(vpAmbientRet.CurrentSpeed_m_s);
                Assert.IsNotNull(vpAmbientRet.CurrentDirection_deg);
                Assert.IsNotNull(vpAmbientRet.AmbientSalinity_PSU);
                Assert.IsNotNull(vpAmbientRet.AmbientTemperature_C);
                Assert.IsNotNull(vpAmbientRet.BackgroundConcentration_MPN_100ml);
                Assert.IsNotNull(vpAmbientRet.PollutantDecayRate_per_day);
                Assert.IsNotNull(vpAmbientRet.FarFieldCurrentSpeed_m_s);
                Assert.IsNotNull(vpAmbientRet.FarFieldCurrentDirection_deg);
                Assert.IsNotNull(vpAmbientRet.FarFieldDiffusionCoefficient);
                Assert.IsNotNull(vpAmbientRet.LastUpdateDate_UTC);
                Assert.IsNotNull(vpAmbientRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(vpAmbientRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpAmbientRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}