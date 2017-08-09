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
            if (OmitPropName != "MikeScenarioTVText") mikeScenario.MikeScenarioTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") mikeScenario.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "ScenarioStatusText") mikeScenario.ScenarioStatusText = GetRandomString("", 5);

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

                MikeScenarioService mikeScenarioService = new MikeScenarioService(LanguageRequest, dbTestDB, ContactID);

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

                mikeScenarioService.Add(mikeScenario);
                if (mikeScenario.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, mikeScenarioService.GetRead().Where(c => c == mikeScenario).Any());
                mikeScenarioService.Update(mikeScenario);
                if (mikeScenario.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, mikeScenarioService.GetRead().Count());
                mikeScenarioService.Delete(mikeScenario);
                if (mikeScenario.ValidationResults.Count() > 0)
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioID), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeScenario)]
                // mikeScenario.MikeScenarioTVItemID   (Int32)
                // -----------------------------------

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.MikeScenarioTVItemID = 0;
                mikeScenarioService.Add(mikeScenario);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeScenarioMikeScenarioTVItemID, mikeScenario.MikeScenarioTVItemID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.MikeScenarioTVItemID = 1;
                mikeScenarioService.Add(mikeScenario);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeScenarioMikeScenarioTVItemID, "MikeScenario"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeScenario)]
                // mikeScenario.ParentMikeScenarioID   (Int32)
                // -----------------------------------

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.ParentMikeScenarioID = 0;
                mikeScenarioService.Add(mikeScenario);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeScenarioParentMikeScenarioID, mikeScenario.ParentMikeScenarioID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.ParentMikeScenarioID = 1;
                mikeScenarioService.Add(mikeScenario);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeScenarioParentMikeScenarioID, "MikeScenario"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // mikeScenario.ScenarioStatus   (ScenarioStatusEnum)
                // -----------------------------------

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.ScenarioStatus = (ScenarioStatusEnum)1000000;
                mikeScenarioService.Add(mikeScenario);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioScenarioStatus), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // mikeScenario.ErrorInfo   (String)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mikeScenario.MikeScenarioStartDateTime_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mikeScenario.MikeScenarioEndDateTime_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // mikeScenario.MikeScenarioStartExecutionDateTime_Local   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [Range(1, 100000)]
                // mikeScenario.MikeScenarioExecutionTime_min   (Double)
                // -----------------------------------

                //Error: Type not implemented [MikeScenarioExecutionTime_min]

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.MikeScenarioExecutionTime_min = 0.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.MikeScenarioExecutionTime_min = 100001.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100)]
                // mikeScenario.WindSpeed_km_h   (Double)
                // -----------------------------------

                //Error: Type not implemented [WindSpeed_km_h]

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.WindSpeed_km_h = -1.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.WindSpeed_km_h = 101.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 360)]
                // mikeScenario.WindDirection_deg   (Double)
                // -----------------------------------

                //Error: Type not implemented [WindDirection_deg]

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.WindDirection_deg = -1.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindDirection_deg, "0", "360"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.WindDirection_deg = 361.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindDirection_deg, "0", "360"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100)]
                // mikeScenario.DecayFactor_per_day   (Double)
                // -----------------------------------

                //Error: Type not implemented [DecayFactor_per_day]

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.DecayFactor_per_day = -1.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.DecayFactor_per_day = 101.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.DecayFactorAmplitude = -1.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.DecayFactorAmplitude = 101.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.ResultFrequency_min = 101;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-10, 40)]
                // mikeScenario.AmbientTemperature_C   (Double)
                // -----------------------------------

                //Error: Type not implemented [AmbientTemperature_C]

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.AmbientTemperature_C = -11.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.AmbientTemperature_C = 41.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 40)]
                // mikeScenario.AmbientSalinity_PSU   (Double)
                // -----------------------------------

                //Error: Type not implemented [AmbientSalinity_PSU]

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.AmbientSalinity_PSU = -1.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.AmbientSalinity_PSU = 41.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100)]
                // mikeScenario.ManningNumber   (Double)
                // -----------------------------------

                //Error: Type not implemented [ManningNumber]

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.ManningNumber = -1.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioManningNumber, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.ManningNumber = 101.0D;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioManningNumber, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "10000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.NumberOfElements = 10001;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "10000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.NumberOfTimeSteps = 10001;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.NumberOfSigmaLayers = 101;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZLayers, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.NumberOfZLayers = 101;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZLayers, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.NumberOfHydroOutputParameters = 101;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.NumberOfTransOutputParameters = 101;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.EstimatedHydroFileSize = 100000001;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.EstimatedTransFileSize = 100000001;
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mikeScenario.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // mikeScenario.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.LastUpdateContactTVItemID = 0;
                mikeScenarioService.Add(mikeScenario);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeScenarioLastUpdateContactTVItemID, mikeScenario.LastUpdateContactTVItemID.ToString()), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.LastUpdateContactTVItemID = 1;
                mikeScenarioService.Add(mikeScenario);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeScenarioLastUpdateContactTVItemID, "Contact"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "MikeScenarioTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // mikeScenario.MikeScenarioTVText   (String)
                // -----------------------------------

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.MikeScenarioTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeScenarioMikeScenarioTVText, "200"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // mikeScenario.LastUpdateContactTVText   (String)
                // -----------------------------------

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeScenarioLastUpdateContactTVText, "200"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mikeScenario.ScenarioStatusText   (String)
                // -----------------------------------

                mikeScenario = null;
                mikeScenario = GetFilledRandomMikeScenario("");
                mikeScenario.ScenarioStatusText = GetRandomString("", 101);
                Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeScenarioScenarioStatusText, "100"), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // mikeScenario.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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

                MikeScenarioService mikeScenarioService = new MikeScenarioService(LanguageRequest, dbTestDB, ContactID);
                MikeScenario mikeScenario = (from c in mikeScenarioService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(mikeScenario);

                MikeScenario mikeScenarioRet = mikeScenarioService.GetMikeScenarioWithMikeScenarioID(mikeScenario.MikeScenarioID);
                Assert.IsNotNull(mikeScenarioRet.MikeScenarioID);
                Assert.IsNotNull(mikeScenarioRet.MikeScenarioTVItemID);
                if (mikeScenarioRet.ParentMikeScenarioID != null)
                {
                   Assert.IsNotNull(mikeScenarioRet.ParentMikeScenarioID);
                }
                Assert.IsNotNull(mikeScenarioRet.ScenarioStatus);
                if (mikeScenarioRet.ErrorInfo != null)
                {
                   Assert.IsNotNull(mikeScenarioRet.ErrorInfo);
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

                Assert.IsNotNull(mikeScenarioRet.MikeScenarioTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.MikeScenarioTVText));
                Assert.IsNotNull(mikeScenarioRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.LastUpdateContactTVText));
                Assert.IsNotNull(mikeScenarioRet.ScenarioStatusText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mikeScenarioRet.ScenarioStatusText));
            }
        }
        #endregion Tests Get With Key

    }
}