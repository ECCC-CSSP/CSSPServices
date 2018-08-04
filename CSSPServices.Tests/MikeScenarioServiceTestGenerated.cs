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
    public partial class MikeScenarioServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MikeScenarioService mikeScenarioService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioServiceTest() : base()
        {
            //mikeScenarioService = new MikeScenarioService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MikeScenario_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MikeScenario mikeScenario = GetFilledRandomMikeScenario("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mikeScenarioService.GetMikeScenarioList().Count();

                    Assert.AreEqual(mikeScenarioService.GetMikeScenarioList().Count(), (from c in dbTestDB.MikeScenarios select c).Take(200).Count());

                    mikeScenarioService.Add(mikeScenario);
                    if (mikeScenario.HasErrors)
                    {
                        Assert.AreEqual("", mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mikeScenarioService.GetMikeScenarioList().Where(c => c == mikeScenario).Any());
                    mikeScenarioService.Update(mikeScenario);
                    if (mikeScenario.HasErrors)
                    {
                        Assert.AreEqual("", mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenarioService.Delete(mikeScenario);
                    if (mikeScenario.HasErrors)
                    {
                        Assert.AreEqual("", mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mikeScenario.MikeScenarioID   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioID = 0;
                    mikeScenarioService.Update(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioMikeScenarioID"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioID = 10000000;
                    mikeScenarioService.Update(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioMikeScenarioID", mikeScenario.MikeScenarioID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeScenario)]
                    // mikeScenario.MikeScenarioTVItemID   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioTVItemID = 0;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioMikeScenarioTVItemID", mikeScenario.MikeScenarioTVItemID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioTVItemID = 1;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MikeScenarioMikeScenarioTVItemID", "MikeScenario"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeScenario)]
                    // mikeScenario.ParentMikeScenarioID   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ParentMikeScenarioID = 0;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioParentMikeScenarioID", mikeScenario.ParentMikeScenarioID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ParentMikeScenarioID = 1;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MikeScenarioParentMikeScenarioID", "MikeScenario"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mikeScenario.ScenarioStatus   (ScenarioStatusEnum)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ScenarioStatus = (ScenarioStatusEnum)1000000;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioScenarioStatus"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // mikeScenario.ErrorInfo   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeScenario.MikeScenarioStartDateTime_Local   (DateTime)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioStartDateTime_Local = new DateTime();
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioMikeScenarioStartDateTime_Local"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioStartDateTime_Local = new DateTime(1979, 1, 1);
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioMikeScenarioStartDateTime_Local", "1980"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeScenario.MikeScenarioEndDateTime_Local   (DateTime)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioEndDateTime_Local = new DateTime();
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioMikeScenarioEndDateTime_Local"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioEndDateTime_Local = new DateTime(1979, 1, 1);
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioMikeScenarioEndDateTime_Local", "1980"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeScenario.MikeScenarioStartExecutionDateTime_Local   (DateTime)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioStartExecutionDateTime_Local = new DateTime(1979, 1, 1);
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioMikeScenarioStartExecutionDateTime_Local", "1980"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 100000)]
                    // mikeScenario.MikeScenarioExecutionTime_min   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [MikeScenarioExecutionTime_min]

                    //Error: Type not implemented [MikeScenarioExecutionTime_min]

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioExecutionTime_min = 0.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioMikeScenarioExecutionTime_min", "1", "100000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioExecutionTime_min = 100001.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioMikeScenarioExecutionTime_min", "1", "100000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // mikeScenario.WindSpeed_km_h   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WindSpeed_km_h]

                    //Error: Type not implemented [WindSpeed_km_h]

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.WindSpeed_km_h = -1.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioWindSpeed_km_h", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.WindSpeed_km_h = 101.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioWindSpeed_km_h", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 360)]
                    // mikeScenario.WindDirection_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WindDirection_deg]

                    //Error: Type not implemented [WindDirection_deg]

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.WindDirection_deg = -1.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioWindDirection_deg", "0", "360"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.WindDirection_deg = 361.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioWindDirection_deg", "0", "360"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // mikeScenario.DecayFactor_per_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DecayFactor_per_day]

                    //Error: Type not implemented [DecayFactor_per_day]

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.DecayFactor_per_day = -1.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioDecayFactor_per_day", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.DecayFactor_per_day = 101.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioDecayFactor_per_day", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // mikeScenario.DecayIsConstant   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // mikeScenario.DecayFactorAmplitude   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DecayFactorAmplitude]

                    //Error: Type not implemented [DecayFactorAmplitude]

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.DecayFactorAmplitude = -1.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioDecayFactorAmplitude", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.DecayFactorAmplitude = 101.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioDecayFactorAmplitude", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // mikeScenario.ResultFrequency_min   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ResultFrequency_min = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioResultFrequency_min", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ResultFrequency_min = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioResultFrequency_min", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-10, 40)]
                    // mikeScenario.AmbientTemperature_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [AmbientTemperature_C]

                    //Error: Type not implemented [AmbientTemperature_C]

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.AmbientTemperature_C = -11.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioAmbientTemperature_C", "-10", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.AmbientTemperature_C = 41.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioAmbientTemperature_C", "-10", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 40)]
                    // mikeScenario.AmbientSalinity_PSU   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [AmbientSalinity_PSU]

                    //Error: Type not implemented [AmbientSalinity_PSU]

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.AmbientSalinity_PSU = -1.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioAmbientSalinity_PSU", "0", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.AmbientSalinity_PSU = 41.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioAmbientSalinity_PSU", "0", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // mikeScenario.ManningNumber   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [ManningNumber]

                    //Error: Type not implemented [ManningNumber]

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ManningNumber = -1.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioManningNumber", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ManningNumber = 101.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioManningNumber", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 1000000)]
                    // mikeScenario.NumberOfElements   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfElements = 0;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfElements", "1", "1000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfElements = 1000001;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfElements", "1", "1000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 1000000)]
                    // mikeScenario.NumberOfTimeSteps   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfTimeSteps = 0;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfTimeSteps", "1", "1000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfTimeSteps = 1000001;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfTimeSteps", "1", "1000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mikeScenario.NumberOfSigmaLayers   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfSigmaLayers = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfSigmaLayers", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfSigmaLayers = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfSigmaLayers", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mikeScenario.NumberOfZLayers   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfZLayers = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfZLayers", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfZLayers = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfZLayers", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mikeScenario.NumberOfHydroOutputParameters   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfHydroOutputParameters = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfHydroOutputParameters", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfHydroOutputParameters = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfHydroOutputParameters", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mikeScenario.NumberOfTransOutputParameters   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfTransOutputParameters = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfTransOutputParameters", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfTransOutputParameters = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfTransOutputParameters", "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000000)]
                    // mikeScenario.EstimatedHydroFileSize   (Int64)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.EstimatedHydroFileSize = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioEstimatedHydroFileSize", "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.EstimatedHydroFileSize = 100000001;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioEstimatedHydroFileSize", "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000000)]
                    // mikeScenario.EstimatedTransFileSize   (Int64)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.EstimatedTransFileSize = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioEstimatedTransFileSize", "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.EstimatedTransFileSize = 100000001;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioEstimatedTransFileSize", "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetMikeScenarioList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeScenario.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.LastUpdateDate_UTC = new DateTime();
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioLastUpdateDate_UTC"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioLastUpdateDate_UTC", "1980"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mikeScenario.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.LastUpdateContactTVItemID = 0;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioLastUpdateContactTVItemID", mikeScenario.LastUpdateContactTVItemID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.LastUpdateContactTVItemID = 1;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MikeScenarioLastUpdateContactTVItemID", "Contact"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeScenario.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mikeScenario.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMikeScenarioWithMikeScenarioID(mikeScenario.MikeScenarioID)
        [TestMethod]
        public void GetMikeScenarioWithMikeScenarioID__mikeScenario_MikeScenarioID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeScenario mikeScenario = (from c in dbTestDB.MikeScenarios select c).FirstOrDefault();
                    Assert.IsNotNull(mikeScenario);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mikeScenarioService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            MikeScenario mikeScenarioRet = mikeScenarioService.GetMikeScenarioWithMikeScenarioID(mikeScenario.MikeScenarioID);
                            CheckMikeScenarioFields(new List<MikeScenario>() { mikeScenarioRet });
                            Assert.AreEqual(mikeScenario.MikeScenarioID, mikeScenarioRet.MikeScenarioID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            MikeScenarioWeb mikeScenarioWebRet = mikeScenarioService.GetMikeScenarioWebWithMikeScenarioID(mikeScenario.MikeScenarioID);
                            CheckMikeScenarioWebFields(new List<MikeScenarioWeb>() { mikeScenarioWebRet });
                            Assert.AreEqual(mikeScenario.MikeScenarioID, mikeScenarioWebRet.MikeScenarioID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            MikeScenarioReport mikeScenarioReportRet = mikeScenarioService.GetMikeScenarioReportWithMikeScenarioID(mikeScenario.MikeScenarioID);
                            CheckMikeScenarioReportFields(new List<MikeScenarioReport>() { mikeScenarioReportRet });
                            Assert.AreEqual(mikeScenario.MikeScenarioID, mikeScenarioReportRet.MikeScenarioID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioWithMikeScenarioID(mikeScenario.MikeScenarioID)

        #region Tests Generated for GetMikeScenarioList()
        [TestMethod]
        public void GetMikeScenarioList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MikeScenario mikeScenario = (from c in dbTestDB.MikeScenarios select c).FirstOrDefault();
                    Assert.IsNotNull(mikeScenario);

                    List<MikeScenario> mikeScenarioDirectQueryList = new List<MikeScenario>();
                    mikeScenarioDirectQueryList = (from c in dbTestDB.MikeScenarios select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mikeScenarioService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MikeScenario> mikeScenarioList = new List<MikeScenario>();
                            mikeScenarioList = mikeScenarioService.GetMikeScenarioList().ToList();
                            CheckMikeScenarioFields(mikeScenarioList);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MikeScenarioWeb> mikeScenarioWebList = new List<MikeScenarioWeb>();
                            mikeScenarioWebList = mikeScenarioService.GetMikeScenarioWebList().ToList();
                            CheckMikeScenarioWebFields(mikeScenarioWebList);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MikeScenarioReport> mikeScenarioReportList = new List<MikeScenarioReport>();
                            mikeScenarioReportList = mikeScenarioService.GetMikeScenarioReportList().ToList();
                            CheckMikeScenarioReportFields(mikeScenarioReportList);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioList()

        #region Tests Generated for GetMikeScenarioList() Skip Take
        [TestMethod]
        public void GetMikeScenarioList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MikeScenario> mikeScenarioDirectQueryList = new List<MikeScenario>();
                        mikeScenarioDirectQueryList = (from c in dbTestDB.MikeScenarios select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MikeScenario> mikeScenarioList = new List<MikeScenario>();
                            mikeScenarioList = mikeScenarioService.GetMikeScenarioList().ToList();
                            CheckMikeScenarioFields(mikeScenarioList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MikeScenarioWeb> mikeScenarioWebList = new List<MikeScenarioWeb>();
                            mikeScenarioWebList = mikeScenarioService.GetMikeScenarioWebList().ToList();
                            CheckMikeScenarioWebFields(mikeScenarioWebList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioWebList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MikeScenarioReport> mikeScenarioReportList = new List<MikeScenarioReport>();
                            mikeScenarioReportList = mikeScenarioService.GetMikeScenarioReportList().ToList();
                            CheckMikeScenarioReportFields(mikeScenarioReportList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioReportList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioList() Skip Take

        #region Tests Generated for GetMikeScenarioList() Skip Take Order
        [TestMethod]
        public void GetMikeScenarioList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), culture.TwoLetterISOLanguageName, 1, 1,  "MikeScenarioID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MikeScenario> mikeScenarioDirectQueryList = new List<MikeScenario>();
                        mikeScenarioDirectQueryList = (from c in dbTestDB.MikeScenarios select c).Skip(1).Take(1).OrderBy(c => c.MikeScenarioID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MikeScenario> mikeScenarioList = new List<MikeScenario>();
                            mikeScenarioList = mikeScenarioService.GetMikeScenarioList().ToList();
                            CheckMikeScenarioFields(mikeScenarioList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MikeScenarioWeb> mikeScenarioWebList = new List<MikeScenarioWeb>();
                            mikeScenarioWebList = mikeScenarioService.GetMikeScenarioWebList().ToList();
                            CheckMikeScenarioWebFields(mikeScenarioWebList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioWebList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MikeScenarioReport> mikeScenarioReportList = new List<MikeScenarioReport>();
                            mikeScenarioReportList = mikeScenarioService.GetMikeScenarioReportList().ToList();
                            CheckMikeScenarioReportFields(mikeScenarioReportList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioReportList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioList() Skip Take Order

        #region Tests Generated for GetMikeScenarioList() Skip Take 2Order
        [TestMethod]
        public void GetMikeScenarioList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), culture.TwoLetterISOLanguageName, 1, 1, "MikeScenarioID,MikeScenarioTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MikeScenario> mikeScenarioDirectQueryList = new List<MikeScenario>();
                        mikeScenarioDirectQueryList = (from c in dbTestDB.MikeScenarios select c).Skip(1).Take(1).OrderBy(c => c.MikeScenarioID).ThenBy(c => c.MikeScenarioTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MikeScenario> mikeScenarioList = new List<MikeScenario>();
                            mikeScenarioList = mikeScenarioService.GetMikeScenarioList().ToList();
                            CheckMikeScenarioFields(mikeScenarioList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MikeScenarioWeb> mikeScenarioWebList = new List<MikeScenarioWeb>();
                            mikeScenarioWebList = mikeScenarioService.GetMikeScenarioWebList().ToList();
                            CheckMikeScenarioWebFields(mikeScenarioWebList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioWebList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MikeScenarioReport> mikeScenarioReportList = new List<MikeScenarioReport>();
                            mikeScenarioReportList = mikeScenarioService.GetMikeScenarioReportList().ToList();
                            CheckMikeScenarioReportFields(mikeScenarioReportList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioReportList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioList() Skip Take 2Order

        #region Tests Generated for GetMikeScenarioList() Skip Take Order Where
        [TestMethod]
        public void GetMikeScenarioList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), culture.TwoLetterISOLanguageName, 0, 1, "MikeScenarioID", "MikeScenarioID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MikeScenario> mikeScenarioDirectQueryList = new List<MikeScenario>();
                        mikeScenarioDirectQueryList = (from c in dbTestDB.MikeScenarios select c).Where(c => c.MikeScenarioID == 4).Skip(0).Take(1).OrderBy(c => c.MikeScenarioID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MikeScenario> mikeScenarioList = new List<MikeScenario>();
                            mikeScenarioList = mikeScenarioService.GetMikeScenarioList().ToList();
                            CheckMikeScenarioFields(mikeScenarioList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MikeScenarioWeb> mikeScenarioWebList = new List<MikeScenarioWeb>();
                            mikeScenarioWebList = mikeScenarioService.GetMikeScenarioWebList().ToList();
                            CheckMikeScenarioWebFields(mikeScenarioWebList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioWebList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MikeScenarioReport> mikeScenarioReportList = new List<MikeScenarioReport>();
                            mikeScenarioReportList = mikeScenarioService.GetMikeScenarioReportList().ToList();
                            CheckMikeScenarioReportFields(mikeScenarioReportList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioReportList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioList() Skip Take Order Where

        #region Tests Generated for GetMikeScenarioList() Skip Take Order 2Where
        [TestMethod]
        public void GetMikeScenarioList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), culture.TwoLetterISOLanguageName, 0, 1, "MikeScenarioID", "MikeScenarioID,GT,2|MikeScenarioID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MikeScenario> mikeScenarioDirectQueryList = new List<MikeScenario>();
                        mikeScenarioDirectQueryList = (from c in dbTestDB.MikeScenarios select c).Where(c => c.MikeScenarioID > 2 && c.MikeScenarioID < 5).Skip(0).Take(1).OrderBy(c => c.MikeScenarioID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MikeScenario> mikeScenarioList = new List<MikeScenario>();
                            mikeScenarioList = mikeScenarioService.GetMikeScenarioList().ToList();
                            CheckMikeScenarioFields(mikeScenarioList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MikeScenarioWeb> mikeScenarioWebList = new List<MikeScenarioWeb>();
                            mikeScenarioWebList = mikeScenarioService.GetMikeScenarioWebList().ToList();
                            CheckMikeScenarioWebFields(mikeScenarioWebList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioWebList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MikeScenarioReport> mikeScenarioReportList = new List<MikeScenarioReport>();
                            mikeScenarioReportList = mikeScenarioService.GetMikeScenarioReportList().ToList();
                            CheckMikeScenarioReportFields(mikeScenarioReportList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioReportList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioList() Skip Take Order 2Where

        #region Tests Generated for GetMikeScenarioList() 2Where
        [TestMethod]
        public void GetMikeScenarioList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MikeScenarioService mikeScenarioService = new MikeScenarioService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mikeScenarioService.Query = mikeScenarioService.FillQuery(typeof(MikeScenario), culture.TwoLetterISOLanguageName, 0, 10000, "", "MikeScenarioID,GT,2|MikeScenarioID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MikeScenario> mikeScenarioDirectQueryList = new List<MikeScenario>();
                        mikeScenarioDirectQueryList = (from c in dbTestDB.MikeScenarios select c).Where(c => c.MikeScenarioID > 2 && c.MikeScenarioID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MikeScenario> mikeScenarioList = new List<MikeScenario>();
                            mikeScenarioList = mikeScenarioService.GetMikeScenarioList().ToList();
                            CheckMikeScenarioFields(mikeScenarioList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MikeScenarioWeb> mikeScenarioWebList = new List<MikeScenarioWeb>();
                            mikeScenarioWebList = mikeScenarioService.GetMikeScenarioWebList().ToList();
                            CheckMikeScenarioWebFields(mikeScenarioWebList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioWebList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MikeScenarioReport> mikeScenarioReportList = new List<MikeScenarioReport>();
                            mikeScenarioReportList = mikeScenarioService.GetMikeScenarioReportList().ToList();
                            CheckMikeScenarioReportFields(mikeScenarioReportList);
                            Assert.AreEqual(mikeScenarioDirectQueryList[0].MikeScenarioID, mikeScenarioReportList[0].MikeScenarioID);
                            Assert.AreEqual(mikeScenarioDirectQueryList.Count, mikeScenarioReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMikeScenarioList() 2Where

        #region Functions private
        private void CheckMikeScenarioFields(List<MikeScenario> mikeScenarioList)
        {
            Assert.IsNotNull(mikeScenarioList[0].MikeScenarioID);
            Assert.IsNotNull(mikeScenarioList[0].MikeScenarioTVItemID);
            if (mikeScenarioList[0].ParentMikeScenarioID != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].ParentMikeScenarioID);
            }
            Assert.IsNotNull(mikeScenarioList[0].ScenarioStatus);
            if (!string.IsNullOrWhiteSpace(mikeScenarioList[0].ErrorInfo))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioList[0].ErrorInfo));
            }
            Assert.IsNotNull(mikeScenarioList[0].MikeScenarioStartDateTime_Local);
            Assert.IsNotNull(mikeScenarioList[0].MikeScenarioEndDateTime_Local);
            if (mikeScenarioList[0].MikeScenarioStartExecutionDateTime_Local != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].MikeScenarioStartExecutionDateTime_Local);
            }
            if (mikeScenarioList[0].MikeScenarioExecutionTime_min != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].MikeScenarioExecutionTime_min);
            }
            Assert.IsNotNull(mikeScenarioList[0].WindSpeed_km_h);
            Assert.IsNotNull(mikeScenarioList[0].WindDirection_deg);
            Assert.IsNotNull(mikeScenarioList[0].DecayFactor_per_day);
            Assert.IsNotNull(mikeScenarioList[0].DecayIsConstant);
            Assert.IsNotNull(mikeScenarioList[0].DecayFactorAmplitude);
            Assert.IsNotNull(mikeScenarioList[0].ResultFrequency_min);
            Assert.IsNotNull(mikeScenarioList[0].AmbientTemperature_C);
            Assert.IsNotNull(mikeScenarioList[0].AmbientSalinity_PSU);
            Assert.IsNotNull(mikeScenarioList[0].ManningNumber);
            if (mikeScenarioList[0].NumberOfElements != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].NumberOfElements);
            }
            if (mikeScenarioList[0].NumberOfTimeSteps != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].NumberOfTimeSteps);
            }
            if (mikeScenarioList[0].NumberOfSigmaLayers != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].NumberOfSigmaLayers);
            }
            if (mikeScenarioList[0].NumberOfZLayers != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].NumberOfZLayers);
            }
            if (mikeScenarioList[0].NumberOfHydroOutputParameters != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].NumberOfHydroOutputParameters);
            }
            if (mikeScenarioList[0].NumberOfTransOutputParameters != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].NumberOfTransOutputParameters);
            }
            if (mikeScenarioList[0].EstimatedHydroFileSize != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].EstimatedHydroFileSize);
            }
            if (mikeScenarioList[0].EstimatedTransFileSize != null)
            {
                Assert.IsNotNull(mikeScenarioList[0].EstimatedTransFileSize);
            }
            Assert.IsNotNull(mikeScenarioList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeScenarioList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mikeScenarioList[0].HasErrors);
        }
        private void CheckMikeScenarioWebFields(List<MikeScenarioWeb> mikeScenarioWebList)
        {
            Assert.IsNotNull(mikeScenarioWebList[0].MikeScenarioTVItemLanguage);
            Assert.IsNotNull(mikeScenarioWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mikeScenarioWebList[0].ScenarioStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioWebList[0].ScenarioStatusText));
            }
            Assert.IsNotNull(mikeScenarioWebList[0].MikeScenarioID);
            Assert.IsNotNull(mikeScenarioWebList[0].MikeScenarioTVItemID);
            if (mikeScenarioWebList[0].ParentMikeScenarioID != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].ParentMikeScenarioID);
            }
            Assert.IsNotNull(mikeScenarioWebList[0].ScenarioStatus);
            if (!string.IsNullOrWhiteSpace(mikeScenarioWebList[0].ErrorInfo))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioWebList[0].ErrorInfo));
            }
            Assert.IsNotNull(mikeScenarioWebList[0].MikeScenarioStartDateTime_Local);
            Assert.IsNotNull(mikeScenarioWebList[0].MikeScenarioEndDateTime_Local);
            if (mikeScenarioWebList[0].MikeScenarioStartExecutionDateTime_Local != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].MikeScenarioStartExecutionDateTime_Local);
            }
            if (mikeScenarioWebList[0].MikeScenarioExecutionTime_min != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].MikeScenarioExecutionTime_min);
            }
            Assert.IsNotNull(mikeScenarioWebList[0].WindSpeed_km_h);
            Assert.IsNotNull(mikeScenarioWebList[0].WindDirection_deg);
            Assert.IsNotNull(mikeScenarioWebList[0].DecayFactor_per_day);
            Assert.IsNotNull(mikeScenarioWebList[0].DecayIsConstant);
            Assert.IsNotNull(mikeScenarioWebList[0].DecayFactorAmplitude);
            Assert.IsNotNull(mikeScenarioWebList[0].ResultFrequency_min);
            Assert.IsNotNull(mikeScenarioWebList[0].AmbientTemperature_C);
            Assert.IsNotNull(mikeScenarioWebList[0].AmbientSalinity_PSU);
            Assert.IsNotNull(mikeScenarioWebList[0].ManningNumber);
            if (mikeScenarioWebList[0].NumberOfElements != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].NumberOfElements);
            }
            if (mikeScenarioWebList[0].NumberOfTimeSteps != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].NumberOfTimeSteps);
            }
            if (mikeScenarioWebList[0].NumberOfSigmaLayers != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].NumberOfSigmaLayers);
            }
            if (mikeScenarioWebList[0].NumberOfZLayers != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].NumberOfZLayers);
            }
            if (mikeScenarioWebList[0].NumberOfHydroOutputParameters != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].NumberOfHydroOutputParameters);
            }
            if (mikeScenarioWebList[0].NumberOfTransOutputParameters != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].NumberOfTransOutputParameters);
            }
            if (mikeScenarioWebList[0].EstimatedHydroFileSize != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].EstimatedHydroFileSize);
            }
            if (mikeScenarioWebList[0].EstimatedTransFileSize != null)
            {
                Assert.IsNotNull(mikeScenarioWebList[0].EstimatedTransFileSize);
            }
            Assert.IsNotNull(mikeScenarioWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeScenarioWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mikeScenarioWebList[0].HasErrors);
        }
        private void CheckMikeScenarioReportFields(List<MikeScenarioReport> mikeScenarioReportList)
        {
            if (!string.IsNullOrWhiteSpace(mikeScenarioReportList[0].MikeScenarioReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioReportList[0].MikeScenarioReportTest));
            }
            Assert.IsNotNull(mikeScenarioReportList[0].MikeScenarioTVItemLanguage);
            Assert.IsNotNull(mikeScenarioReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mikeScenarioReportList[0].ScenarioStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioReportList[0].ScenarioStatusText));
            }
            Assert.IsNotNull(mikeScenarioReportList[0].MikeScenarioID);
            Assert.IsNotNull(mikeScenarioReportList[0].MikeScenarioTVItemID);
            if (mikeScenarioReportList[0].ParentMikeScenarioID != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].ParentMikeScenarioID);
            }
            Assert.IsNotNull(mikeScenarioReportList[0].ScenarioStatus);
            if (!string.IsNullOrWhiteSpace(mikeScenarioReportList[0].ErrorInfo))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioReportList[0].ErrorInfo));
            }
            Assert.IsNotNull(mikeScenarioReportList[0].MikeScenarioStartDateTime_Local);
            Assert.IsNotNull(mikeScenarioReportList[0].MikeScenarioEndDateTime_Local);
            if (mikeScenarioReportList[0].MikeScenarioStartExecutionDateTime_Local != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].MikeScenarioStartExecutionDateTime_Local);
            }
            if (mikeScenarioReportList[0].MikeScenarioExecutionTime_min != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].MikeScenarioExecutionTime_min);
            }
            Assert.IsNotNull(mikeScenarioReportList[0].WindSpeed_km_h);
            Assert.IsNotNull(mikeScenarioReportList[0].WindDirection_deg);
            Assert.IsNotNull(mikeScenarioReportList[0].DecayFactor_per_day);
            Assert.IsNotNull(mikeScenarioReportList[0].DecayIsConstant);
            Assert.IsNotNull(mikeScenarioReportList[0].DecayFactorAmplitude);
            Assert.IsNotNull(mikeScenarioReportList[0].ResultFrequency_min);
            Assert.IsNotNull(mikeScenarioReportList[0].AmbientTemperature_C);
            Assert.IsNotNull(mikeScenarioReportList[0].AmbientSalinity_PSU);
            Assert.IsNotNull(mikeScenarioReportList[0].ManningNumber);
            if (mikeScenarioReportList[0].NumberOfElements != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].NumberOfElements);
            }
            if (mikeScenarioReportList[0].NumberOfTimeSteps != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].NumberOfTimeSteps);
            }
            if (mikeScenarioReportList[0].NumberOfSigmaLayers != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].NumberOfSigmaLayers);
            }
            if (mikeScenarioReportList[0].NumberOfZLayers != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].NumberOfZLayers);
            }
            if (mikeScenarioReportList[0].NumberOfHydroOutputParameters != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].NumberOfHydroOutputParameters);
            }
            if (mikeScenarioReportList[0].NumberOfTransOutputParameters != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].NumberOfTransOutputParameters);
            }
            if (mikeScenarioReportList[0].EstimatedHydroFileSize != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].EstimatedHydroFileSize);
            }
            if (mikeScenarioReportList[0].EstimatedTransFileSize != null)
            {
                Assert.IsNotNull(mikeScenarioReportList[0].EstimatedTransFileSize);
            }
            Assert.IsNotNull(mikeScenarioReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mikeScenarioReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mikeScenarioReportList[0].HasErrors);
        }
        private MikeScenario GetFilledRandomMikeScenario(string OmitPropName)
        {
            MikeScenario mikeScenario = new MikeScenario();

            if (OmitPropName != "MikeScenarioTVItemID") mikeScenario.MikeScenarioTVItemID = 47;
            if (OmitPropName != "ParentMikeScenarioID") mikeScenario.ParentMikeScenarioID = null;
            if (OmitPropName != "ScenarioStatus") mikeScenario.ScenarioStatus = (ScenarioStatusEnum)GetRandomEnumType(typeof(ScenarioStatusEnum));
            if (OmitPropName != "ErrorInfo") mikeScenario.ErrorInfo = GetRandomString("", 20);
            if (OmitPropName != "MikeScenarioStartDateTime_Local") mikeScenario.MikeScenarioStartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "MikeScenarioEndDateTime_Local") mikeScenario.MikeScenarioEndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "MikeScenarioStartExecutionDateTime_Local") mikeScenario.MikeScenarioStartExecutionDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "MikeScenarioExecutionTime_min") mikeScenario.MikeScenarioExecutionTime_min = GetRandomDouble(1.0D, 100000.0D);
            if (OmitPropName != "WindSpeed_km_h") mikeScenario.WindSpeed_km_h = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "WindDirection_deg") mikeScenario.WindDirection_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "DecayFactor_per_day") mikeScenario.DecayFactor_per_day = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "DecayIsConstant") mikeScenario.DecayIsConstant = true;
            if (OmitPropName != "DecayFactorAmplitude") mikeScenario.DecayFactorAmplitude = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "ResultFrequency_min") mikeScenario.ResultFrequency_min = GetRandomInt(0, 100);
            if (OmitPropName != "AmbientTemperature_C") mikeScenario.AmbientTemperature_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "AmbientSalinity_PSU") mikeScenario.AmbientSalinity_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "ManningNumber") mikeScenario.ManningNumber = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "NumberOfElements") mikeScenario.NumberOfElements = GetRandomInt(1, 1000000);
            if (OmitPropName != "NumberOfTimeSteps") mikeScenario.NumberOfTimeSteps = GetRandomInt(1, 1000000);
            if (OmitPropName != "NumberOfSigmaLayers") mikeScenario.NumberOfSigmaLayers = GetRandomInt(0, 100);
            if (OmitPropName != "NumberOfZLayers") mikeScenario.NumberOfZLayers = GetRandomInt(0, 100);
            if (OmitPropName != "NumberOfHydroOutputParameters") mikeScenario.NumberOfHydroOutputParameters = GetRandomInt(0, 100);
            if (OmitPropName != "NumberOfTransOutputParameters") mikeScenario.NumberOfTransOutputParameters = GetRandomInt(0, 100);
            if (OmitPropName != "EstimatedHydroFileSize") mikeScenario.EstimatedHydroFileSize = GetRandomInt(0, 100000000);
            if (OmitPropName != "EstimatedTransFileSize") mikeScenario.EstimatedTransFileSize = GetRandomInt(0, 100000000);
            if (OmitPropName != "LastUpdateDate_UTC") mikeScenario.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeScenario.LastUpdateContactTVItemID = 2;

            return mikeScenario;
        }
        #endregion Functions private
    }
}
