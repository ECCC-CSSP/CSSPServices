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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeScenario GetFilledRandomMikeScenario(string OmitPropName)
        {
            MikeScenario mikeScenario = new MikeScenario();

            if (OmitPropName != "MikeScenarioTVItemID") mikeScenario.MikeScenarioTVItemID = 25;
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
            if (OmitPropName != "NumberOfElements") mikeScenario.NumberOfElements = GetRandomInt(1, 10000);
            if (OmitPropName != "NumberOfTimeSteps") mikeScenario.NumberOfTimeSteps = GetRandomInt(1, 10000);
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MikeScenario_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MikeScenarioService mikeScenarioService = new MikeScenarioService(new GetParam(), dbTestDB, ContactID);

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

                    count = mikeScenarioService.GetRead().Count();

                    Assert.AreEqual(mikeScenarioService.GetRead().Count(), mikeScenarioService.GetEdit().Count());

                    mikeScenarioService.Add(mikeScenario);
                    if (mikeScenario.HasErrors)
                    {
                        Assert.AreEqual("", mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mikeScenarioService.GetRead().Where(c => c == mikeScenario).Any());
                    mikeScenarioService.Update(mikeScenario);
                    if (mikeScenario.HasErrors)
                    {
                        Assert.AreEqual("", mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mikeScenarioService.GetRead().Count());
                    mikeScenarioService.Delete(mikeScenario);
                    if (mikeScenario.HasErrors)
                    {
                        Assert.AreEqual("", mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeScenarioMikeScenarioID), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioID = 10000000;
                    mikeScenarioService.Update(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeScenario, CSSPModelsRes.MikeScenarioMikeScenarioID, mikeScenario.MikeScenarioID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeScenario)]
                    // mikeScenario.MikeScenarioTVItemID   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioTVItemID = 0;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeScenarioMikeScenarioTVItemID, mikeScenario.MikeScenarioTVItemID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioTVItemID = 1;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeScenarioMikeScenarioTVItemID, "MikeScenario"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeScenario)]
                    // mikeScenario.ParentMikeScenarioID   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ParentMikeScenarioID = 0;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeScenarioParentMikeScenarioID, mikeScenario.ParentMikeScenarioID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ParentMikeScenarioID = 1;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeScenarioParentMikeScenarioID, "MikeScenario"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mikeScenario.ScenarioStatus   (ScenarioStatusEnum)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ScenarioStatus = (ScenarioStatusEnum)1000000;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeScenarioScenarioStatus), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeScenarioMikeScenarioStartDateTime_Local), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioStartDateTime_Local = new DateTime(1979, 1, 1);
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeScenarioMikeScenarioStartDateTime_Local, "1980"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeScenario.MikeScenarioEndDateTime_Local   (DateTime)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioEndDateTime_Local = new DateTime();
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeScenarioMikeScenarioEndDateTime_Local), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioEndDateTime_Local = new DateTime(1979, 1, 1);
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeScenarioMikeScenarioEndDateTime_Local, "1980"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeScenario.MikeScenarioStartExecutionDateTime_Local   (DateTime)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioStartExecutionDateTime_Local = new DateTime(1979, 1, 1);
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeScenarioMikeScenarioStartExecutionDateTime_Local, "1980"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioExecutionTime_min = 100001.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioWindSpeed_km_h, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.WindSpeed_km_h = 101.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioWindSpeed_km_h, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioWindDirection_deg, "0", "360"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.WindDirection_deg = 361.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioWindDirection_deg, "0", "360"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioDecayFactor_per_day, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.DecayFactor_per_day = 101.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioDecayFactor_per_day, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.DecayFactorAmplitude = 101.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // mikeScenario.ResultFrequency_min   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ResultFrequency_min = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioResultFrequency_min, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ResultFrequency_min = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioResultFrequency_min, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.AmbientTemperature_C = 41.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.AmbientSalinity_PSU = 41.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioManningNumber, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.ManningNumber = 101.0D;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioManningNumber, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 10000)]
                    // mikeScenario.NumberOfElements   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfElements = 0;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfElements, "1", "10000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfElements = 10001;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfElements, "1", "10000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(1, 10000)]
                    // mikeScenario.NumberOfTimeSteps   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfTimeSteps = 0;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfTimeSteps = 10001;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mikeScenario.NumberOfSigmaLayers   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfSigmaLayers = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfSigmaLayers = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mikeScenario.NumberOfZLayers   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfZLayers = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfZLayers, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfZLayers = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfZLayers, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mikeScenario.NumberOfHydroOutputParameters   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfHydroOutputParameters = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfHydroOutputParameters = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100)]
                    // mikeScenario.NumberOfTransOutputParameters   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfTransOutputParameters = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.NumberOfTransOutputParameters = 101;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000000)]
                    // mikeScenario.EstimatedHydroFileSize   (Int64)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.EstimatedHydroFileSize = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.EstimatedHydroFileSize = 100000001;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000000)]
                    // mikeScenario.EstimatedTransFileSize   (Int64)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.EstimatedTransFileSize = -1;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.EstimatedTransFileSize = 100000001;
                    Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mikeScenario.MikeScenarioWeb   (MikeScenarioWeb)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioWeb = null;
                    Assert.IsNull(mikeScenario.MikeScenarioWeb);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioWeb = new MikeScenarioWeb();
                    Assert.IsNotNull(mikeScenario.MikeScenarioWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mikeScenario.MikeScenarioReport   (MikeScenarioReport)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioReport = null;
                    Assert.IsNull(mikeScenario.MikeScenarioReport);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.MikeScenarioReport = new MikeScenarioReport();
                    Assert.IsNotNull(mikeScenario.MikeScenarioReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mikeScenario.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.LastUpdateDate_UTC = new DateTime();
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeScenarioLastUpdateDate_UTC), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeScenarioLastUpdateDate_UTC, "1980"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mikeScenario.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.LastUpdateContactTVItemID = 0;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeScenarioLastUpdateContactTVItemID, mikeScenario.LastUpdateContactTVItemID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                    mikeScenario = null;
                    mikeScenario = GetFilledRandomMikeScenario("");
                    mikeScenario.LastUpdateContactTVItemID = 1;
                    mikeScenarioService.Add(mikeScenario);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeScenarioLastUpdateContactTVItemID, "Contact"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated Get With Key
        [TestMethod]
        public void MikeScenario_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    MikeScenarioService mikeScenarioService = new MikeScenarioService(new GetParam(), dbTestDB, ContactID);
                    MikeScenario mikeScenario = (from c in mikeScenarioService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mikeScenario);

                    MikeScenario mikeScenarioRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            mikeScenarioRet = mikeScenarioService.GetMikeScenarioWithMikeScenarioID(mikeScenario.MikeScenarioID, getParam);
                            Assert.IsNull(mikeScenarioRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mikeScenarioRet = mikeScenarioService.GetMikeScenarioWithMikeScenarioID(mikeScenario.MikeScenarioID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mikeScenarioRet = mikeScenarioService.GetMikeScenarioWithMikeScenarioID(mikeScenario.MikeScenarioID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mikeScenarioRet = mikeScenarioService.GetMikeScenarioWithMikeScenarioID(mikeScenario.MikeScenarioID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MikeScenario fields
                        Assert.IsNotNull(mikeScenarioRet.MikeScenarioID);
                        Assert.IsNotNull(mikeScenarioRet.MikeScenarioTVItemID);
                        if (mikeScenarioRet.ParentMikeScenarioID != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.ParentMikeScenarioID);
                        }
                        Assert.IsNotNull(mikeScenarioRet.ScenarioStatus);
                        if (mikeScenarioRet.ErrorInfo != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.ErrorInfo));
                        }
                        Assert.IsNotNull(mikeScenarioRet.MikeScenarioStartDateTime_Local);
                        Assert.IsNotNull(mikeScenarioRet.MikeScenarioEndDateTime_Local);
                        if (mikeScenarioRet.MikeScenarioStartExecutionDateTime_Local != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.MikeScenarioStartExecutionDateTime_Local);
                        }
                        if (mikeScenarioRet.MikeScenarioExecutionTime_min != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.MikeScenarioExecutionTime_min);
                        }
                        Assert.IsNotNull(mikeScenarioRet.WindSpeed_km_h);
                        Assert.IsNotNull(mikeScenarioRet.WindDirection_deg);
                        Assert.IsNotNull(mikeScenarioRet.DecayFactor_per_day);
                        Assert.IsNotNull(mikeScenarioRet.DecayIsConstant);
                        Assert.IsNotNull(mikeScenarioRet.DecayFactorAmplitude);
                        Assert.IsNotNull(mikeScenarioRet.ResultFrequency_min);
                        Assert.IsNotNull(mikeScenarioRet.AmbientTemperature_C);
                        Assert.IsNotNull(mikeScenarioRet.AmbientSalinity_PSU);
                        Assert.IsNotNull(mikeScenarioRet.ManningNumber);
                        if (mikeScenarioRet.NumberOfElements != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.NumberOfElements);
                        }
                        if (mikeScenarioRet.NumberOfTimeSteps != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.NumberOfTimeSteps);
                        }
                        if (mikeScenarioRet.NumberOfSigmaLayers != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.NumberOfSigmaLayers);
                        }
                        if (mikeScenarioRet.NumberOfZLayers != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.NumberOfZLayers);
                        }
                        if (mikeScenarioRet.NumberOfHydroOutputParameters != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.NumberOfHydroOutputParameters);
                        }
                        if (mikeScenarioRet.NumberOfTransOutputParameters != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.NumberOfTransOutputParameters);
                        }
                        if (mikeScenarioRet.EstimatedHydroFileSize != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.EstimatedHydroFileSize);
                        }
                        if (mikeScenarioRet.EstimatedTransFileSize != null)
                        {
                            Assert.IsNotNull(mikeScenarioRet.EstimatedTransFileSize);
                        }
                        Assert.IsNotNull(mikeScenarioRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mikeScenarioRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MikeScenarioWeb and MikeScenarioReport fields should be null here
                            Assert.IsNull(mikeScenarioRet.MikeScenarioWeb);
                            Assert.IsNull(mikeScenarioRet.MikeScenarioReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MikeScenarioWeb fields should not be null and MikeScenarioReport fields should be null here
                            if (mikeScenarioRet.MikeScenarioWeb.MikeScenarioTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.MikeScenarioWeb.MikeScenarioTVText));
                            }
                            if (mikeScenarioRet.MikeScenarioWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.MikeScenarioWeb.LastUpdateContactTVText));
                            }
                            if (mikeScenarioRet.MikeScenarioWeb.ScenarioStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.MikeScenarioWeb.ScenarioStatusText));
                            }
                            Assert.IsNull(mikeScenarioRet.MikeScenarioReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MikeScenarioWeb and MikeScenarioReport fields should NOT be null here
                            if (mikeScenarioRet.MikeScenarioWeb.MikeScenarioTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.MikeScenarioWeb.MikeScenarioTVText));
                            }
                            if (mikeScenarioRet.MikeScenarioWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.MikeScenarioWeb.LastUpdateContactTVText));
                            }
                            if (mikeScenarioRet.MikeScenarioWeb.ScenarioStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.MikeScenarioWeb.ScenarioStatusText));
                            }
                            if (mikeScenarioRet.MikeScenarioReport.MikeScenarioReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.MikeScenarioReport.MikeScenarioReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of MikeScenario
        #endregion Tests Get List of MikeScenario

    }
}
