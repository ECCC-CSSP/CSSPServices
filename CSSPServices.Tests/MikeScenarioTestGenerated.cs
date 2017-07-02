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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class MikeScenarioTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MikeScenarioID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeScenario GetFilledRandomMikeScenario(string OmitPropName)
        {
            MikeScenarioID += 1;

            MikeScenario mikeScenario = new MikeScenario();

            if (OmitPropName != "MikeScenarioID") mikeScenario.MikeScenarioID = MikeScenarioID;
            if (OmitPropName != "MikeScenarioTVItemID") mikeScenario.MikeScenarioTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "ParentMikeScenarioID") mikeScenario.ParentMikeScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "ScenarioStatus") mikeScenario.ScenarioStatus = (ScenarioStatusEnum)GetRandomEnumType(typeof(ScenarioStatusEnum));
            if (OmitPropName != "ErrorInfo") mikeScenario.ErrorInfo = GetRandomString("", 20);
            if (OmitPropName != "MikeScenarioStartDateTime_Local") mikeScenario.MikeScenarioStartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "MikeScenarioEndDateTime_Local") mikeScenario.MikeScenarioEndDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "MikeScenarioStartExecutionDateTime_Local") mikeScenario.MikeScenarioStartExecutionDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "MikeScenarioExecutionTime_min") mikeScenario.MikeScenarioExecutionTime_min = GetRandomFloat(0, 10000);
            if (OmitPropName != "WindSpeed_km_h") mikeScenario.WindSpeed_km_h = GetRandomFloat(0, 200);
            if (OmitPropName != "WindDirection_deg") mikeScenario.WindDirection_deg = GetRandomFloat(0, 360);
            if (OmitPropName != "DecayFactor_per_day") mikeScenario.DecayFactor_per_day = GetRandomFloat(0, 1000);
            if (OmitPropName != "DecayIsConstant") mikeScenario.DecayIsConstant = true;
            if (OmitPropName != "DecayFactorAmplitude") mikeScenario.DecayFactorAmplitude = GetRandomFloat(0, 1000);
            if (OmitPropName != "ResultFrequency_min") mikeScenario.ResultFrequency_min = GetRandomInt(15, 60);
            if (OmitPropName != "AmbientTemperature_C") mikeScenario.AmbientTemperature_C = GetRandomFloat(0, 50);
            if (OmitPropName != "AmbientSalinity_PSU") mikeScenario.AmbientSalinity_PSU = GetRandomFloat(0, 40);
            if (OmitPropName != "ManningNumber") mikeScenario.ManningNumber = GetRandomFloat(0, 100);
            if (OmitPropName != "UseWebTide") mikeScenario.UseWebTide = true;
            if (OmitPropName != "NumberOfElements") mikeScenario.NumberOfElements = GetRandomInt(1, 1000000);
            if (OmitPropName != "NumberOfTimeSteps") mikeScenario.NumberOfTimeSteps = GetRandomInt(1, 1000000);
            if (OmitPropName != "NumberOfSigmaLayers") mikeScenario.NumberOfSigmaLayers = GetRandomInt(1, 1000000);
            if (OmitPropName != "NumberOfZlayers") mikeScenario.NumberOfZlayers = GetRandomInt(1, 1000000);
            if (OmitPropName != "NumberOfHydroOutputParameters") mikeScenario.NumberOfHydroOutputParameters = GetRandomInt(1, 1000000);
            if (OmitPropName != "NumberOfTransOutputParameters") mikeScenario.NumberOfTransOutputParameters = GetRandomInt(1, 1000000);
            //Error: Type not implemented [EstimatedHydroFileSize]
            //Error: Type not implemented [EstimatedTransFileSize]
            if (OmitPropName != "LastUpdateDate_UTC") mikeScenario.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mikeScenario.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mikeScenario;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MikeScenario_Testing()
        {
            SetupTestHelper(culture);
            MikeScenarioService mikeScenarioService = new MikeScenarioService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MikeScenario mikeScenario = GetFilledRandomMikeScenario("");
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(true, mikeScenarioService.GetRead().Where(c => c == mikeScenario).Any());
            mikeScenario.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mikeScenarioService.Update(mikeScenario));
            Assert.AreEqual(1, mikeScenarioService.GetRead().Count());
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MikeScenarioTVItemID will automatically be initialized at 0 --> not null

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("ScenarioStatus");
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(1, mikeScenario.ValidationResults.Count());
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioScenarioStatus)).Any());
            Assert.AreEqual(ScenarioStatusEnum.Error, mikeScenario.ScenarioStatus);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("MikeScenarioStartDateTime_Local");
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(1, mikeScenario.ValidationResults.Count());
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioStartDateTime_Local)).Any());
            Assert.IsTrue(mikeScenario.MikeScenarioStartDateTime_Local.Year < 1900);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("MikeScenarioEndDateTime_Local");
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(1, mikeScenario.ValidationResults.Count());
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioEndDateTime_Local)).Any());
            Assert.IsTrue(mikeScenario.MikeScenarioEndDateTime_Local.Year < 1900);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            // WindSpeed_km_h will automatically be initialized at 0.0f --> not null

            // WindDirection_deg will automatically be initialized at 0.0f --> not null

            // DecayFactor_per_day will automatically be initialized at 0.0f --> not null

            // DecayIsConstant will automatically be initialized at false --> not null

            // DecayFactorAmplitude will automatically be initialized at 0.0f --> not null

            // ResultFrequency_min will automatically be initialized at 0 --> not null

            // AmbientTemperature_C will automatically be initialized at 0.0f --> not null

            // AmbientSalinity_PSU will automatically be initialized at 0.0f --> not null

            // ManningNumber will automatically be initialized at 0.0f --> not null

            //Error: Type not implemented [EstimatedHydroFileSize]

            //Error: Type not implemented [EstimatedTransFileSize]

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("LastUpdateDate_UTC");
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(1, mikeScenario.ValidationResults.Count());
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mikeScenario.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MikeScenarioID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeScenarioTVItemID] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // MikeScenarioTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeScenario.MikeScenarioTVItemID = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.MikeScenarioTVItemID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeScenario.MikeScenarioTVItemID = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.MikeScenarioTVItemID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeScenario.MikeScenarioTVItemID = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioMikeScenarioTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeScenario.MikeScenarioTVItemID);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [ParentMikeScenarioID] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // ParentMikeScenarioID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeScenario.ParentMikeScenarioID = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.ParentMikeScenarioID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ParentMikeScenarioID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeScenario.ParentMikeScenarioID = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.ParentMikeScenarioID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ParentMikeScenarioID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeScenario.ParentMikeScenarioID = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioParentMikeScenarioID, "1")).Any());
            Assert.AreEqual(0, mikeScenario.ParentMikeScenarioID);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [ScenarioStatus] of type [ScenarioStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [ErrorInfo] of type [string]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");

            //-----------------------------------
            // doing property [MikeScenarioStartDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeScenarioEndDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeScenarioStartExecutionDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeScenarioExecutionTime_min] of type [float]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // MikeScenarioExecutionTime_min has Min [0] and Max [10000]. At Min should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [0] and Max [10000]. At Min - 1 should return false with one error
            mikeScenario.MikeScenarioExecutionTime_min = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [0] and Max [10000]. At Max should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 10000.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(10000.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 9999.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(9999.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [0] and Max [10000]. At Max + 1 should return false with one error
            mikeScenario.MikeScenarioExecutionTime_min = 10001.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [WindSpeed_km_h] of type [float]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // WindSpeed_km_h has Min [0] and Max [200]. At Min should return true and no errors
            mikeScenario.WindSpeed_km_h = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [200]. At Min + 1 should return true and no errors
            mikeScenario.WindSpeed_km_h = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [200]. At Min - 1 should return false with one error
            mikeScenario.WindSpeed_km_h = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "200")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [200]. At Max should return true and no errors
            mikeScenario.WindSpeed_km_h = 200.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(200.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [200]. At Max - 1 should return true and no errors
            mikeScenario.WindSpeed_km_h = 199.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(199.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [200]. At Max + 1 should return false with one error
            mikeScenario.WindSpeed_km_h = 201.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "200")).Any());
            Assert.AreEqual(201.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [WindDirection_deg] of type [float]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // WindDirection_deg has Min [0] and Max [360]. At Min should return true and no errors
            mikeScenario.WindDirection_deg = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.WindDirection_deg);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0] and Max [360]. At Min + 1 should return true and no errors
            mikeScenario.WindDirection_deg = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.WindDirection_deg);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0] and Max [360]. At Min - 1 should return false with one error
            mikeScenario.WindDirection_deg = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindDirection_deg, "0", "360")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.WindDirection_deg);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0] and Max [360]. At Max should return true and no errors
            mikeScenario.WindDirection_deg = 360.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(360.0f, mikeScenario.WindDirection_deg);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0] and Max [360]. At Max - 1 should return true and no errors
            mikeScenario.WindDirection_deg = 359.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(359.0f, mikeScenario.WindDirection_deg);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0] and Max [360]. At Max + 1 should return false with one error
            mikeScenario.WindDirection_deg = 361.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindDirection_deg, "0", "360")).Any());
            Assert.AreEqual(361.0f, mikeScenario.WindDirection_deg);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [DecayFactor_per_day] of type [float]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // DecayFactor_per_day has Min [0] and Max [1000]. At Min should return true and no errors
            mikeScenario.DecayFactor_per_day = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mikeScenario.DecayFactor_per_day = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mikeScenario.DecayFactor_per_day = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [1000]. At Max should return true and no errors
            mikeScenario.DecayFactor_per_day = 1000.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mikeScenario.DecayFactor_per_day = 999.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(999.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mikeScenario.DecayFactor_per_day = 1001.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [DecayIsConstant] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [DecayFactorAmplitude] of type [float]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // DecayFactorAmplitude has Min [0] and Max [1000]. At Min should return true and no errors
            mikeScenario.DecayFactorAmplitude = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mikeScenario.DecayFactorAmplitude = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mikeScenario.DecayFactorAmplitude = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [1000]. At Max should return true and no errors
            mikeScenario.DecayFactorAmplitude = 1000.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1000.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mikeScenario.DecayFactorAmplitude = 999.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(999.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mikeScenario.DecayFactorAmplitude = 1001.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [ResultFrequency_min] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // ResultFrequency_min has Min [15] and Max [60]. At Min should return true and no errors
            mikeScenario.ResultFrequency_min = 15;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(15, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [15] and Max [60]. At Min + 1 should return true and no errors
            mikeScenario.ResultFrequency_min = 16;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(16, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [15] and Max [60]. At Min - 1 should return false with one error
            mikeScenario.ResultFrequency_min = 14;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "15", "60")).Any());
            Assert.AreEqual(14, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [15] and Max [60]. At Max should return true and no errors
            mikeScenario.ResultFrequency_min = 60;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(60, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [15] and Max [60]. At Max - 1 should return true and no errors
            mikeScenario.ResultFrequency_min = 59;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(59, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [15] and Max [60]. At Max + 1 should return false with one error
            mikeScenario.ResultFrequency_min = 61;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "15", "60")).Any());
            Assert.AreEqual(61, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [AmbientTemperature_C] of type [float]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // AmbientTemperature_C has Min [0] and Max [50]. At Min should return true and no errors
            mikeScenario.AmbientTemperature_C = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Min + 1 should return true and no errors
            mikeScenario.AmbientTemperature_C = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Min - 1 should return false with one error
            mikeScenario.AmbientTemperature_C = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "0", "50")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Max should return true and no errors
            mikeScenario.AmbientTemperature_C = 50.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(50.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Max - 1 should return true and no errors
            mikeScenario.AmbientTemperature_C = 49.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(49.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [0] and Max [50]. At Max + 1 should return false with one error
            mikeScenario.AmbientTemperature_C = 51.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "0", "50")).Any());
            Assert.AreEqual(51.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [AmbientSalinity_PSU] of type [float]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Min should return true and no errors
            mikeScenario.AmbientSalinity_PSU = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Min + 1 should return true and no errors
            mikeScenario.AmbientSalinity_PSU = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Min - 1 should return false with one error
            mikeScenario.AmbientSalinity_PSU = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Max should return true and no errors
            mikeScenario.AmbientSalinity_PSU = 40.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(40.0f, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Max - 1 should return true and no errors
            mikeScenario.AmbientSalinity_PSU = 39.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(39.0f, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0] and Max [40]. At Max + 1 should return false with one error
            mikeScenario.AmbientSalinity_PSU = 41.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0f, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [ManningNumber] of type [float]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // ManningNumber has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.ManningNumber = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.ManningNumber);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.ManningNumber = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.ManningNumber);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.ManningNumber = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioManningNumber, "0", "100")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.ManningNumber);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.ManningNumber = 100.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100.0f, mikeScenario.ManningNumber);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.ManningNumber = 99.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99.0f, mikeScenario.ManningNumber);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.ManningNumber = 101.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioManningNumber, "0", "100")).Any());
            Assert.AreEqual(101.0f, mikeScenario.ManningNumber);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [UseWebTide] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [NumberOfElements] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfElements has Min [1] and Max [1000000]. At Min should return true and no errors
            mikeScenario.NumberOfElements = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [1000000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfElements = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [1000000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfElements = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "1000000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfElements);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [1000000]. At Max should return true and no errors
            mikeScenario.NumberOfElements = 1000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1000000, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [1000000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfElements = 999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(999999, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [1000000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfElements = 1000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "1000000")).Any());
            Assert.AreEqual(1000001, mikeScenario.NumberOfElements);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfTimeSteps] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfTimeSteps has Min [1] and Max [1000000]. At Min should return true and no errors
            mikeScenario.NumberOfTimeSteps = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [1000000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfTimeSteps = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [1000000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfTimeSteps = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "1000000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [1000000]. At Max should return true and no errors
            mikeScenario.NumberOfTimeSteps = 1000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1000000, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [1000000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfTimeSteps = 999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(999999, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [1000000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfTimeSteps = 1000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "1000000")).Any());
            Assert.AreEqual(1000001, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfSigmaLayers] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfSigmaLayers has Min [1] and Max [1000000]. At Min should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [1] and Max [1000000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [1] and Max [1000000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfSigmaLayers = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "1", "1000000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [1] and Max [1000000]. At Max should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 1000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1000000, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [1] and Max [1000000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(999999, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [1] and Max [1000000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfSigmaLayers = 1000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "1", "1000000")).Any());
            Assert.AreEqual(1000001, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfZlayers] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfZlayers has Min [1] and Max [1000000]. At Min should return true and no errors
            mikeScenario.NumberOfZlayers = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [1] and Max [1000000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfZlayers = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [1] and Max [1000000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfZlayers = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZlayers, "1", "1000000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [1] and Max [1000000]. At Max should return true and no errors
            mikeScenario.NumberOfZlayers = 1000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1000000, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [1] and Max [1000000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfZlayers = 999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(999999, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [1] and Max [1000000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfZlayers = 1000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZlayers, "1", "1000000")).Any());
            Assert.AreEqual(1000001, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfHydroOutputParameters] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfHydroOutputParameters has Min [1] and Max [1000000]. At Min should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [1] and Max [1000000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [1] and Max [1000000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfHydroOutputParameters = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "1", "1000000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [1] and Max [1000000]. At Max should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 1000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1000000, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [1] and Max [1000000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(999999, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [1] and Max [1000000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfHydroOutputParameters = 1000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "1", "1000000")).Any());
            Assert.AreEqual(1000001, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfTransOutputParameters] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfTransOutputParameters has Min [1] and Max [1000000]. At Min should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [1] and Max [1000000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [1] and Max [1000000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfTransOutputParameters = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "1", "1000000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [1] and Max [1000000]. At Max should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 1000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1000000, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [1] and Max [1000000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(999999, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [1] and Max [1000000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfTransOutputParameters = 1000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "1", "1000000")).Any());
            Assert.AreEqual(1000001, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [EstimatedHydroFileSize] of type [long]
            //-----------------------------------

            //-----------------------------------
            // doing property [EstimatedTransFileSize] of type [long]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeScenario.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeScenario.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeScenario.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
