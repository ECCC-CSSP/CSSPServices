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
            if (OmitPropName != "MikeScenarioExecutionTime_min") mikeScenario.MikeScenarioExecutionTime_min = GetRandomFloat(1, 100000);
            if (OmitPropName != "WindSpeed_km_h") mikeScenario.WindSpeed_km_h = GetRandomFloat(0, 100);
            if (OmitPropName != "WindDirection_deg") mikeScenario.WindDirection_deg = GetRandomFloat(0, 360);
            if (OmitPropName != "DecayFactor_per_day") mikeScenario.DecayFactor_per_day = GetRandomFloat(0, 100);
            if (OmitPropName != "DecayIsConstant") mikeScenario.DecayIsConstant = true;
            if (OmitPropName != "DecayFactorAmplitude") mikeScenario.DecayFactorAmplitude = GetRandomFloat(0, 100);
            if (OmitPropName != "ResultFrequency_min") mikeScenario.ResultFrequency_min = GetRandomInt(0, 100);
            if (OmitPropName != "AmbientTemperature_C") mikeScenario.AmbientTemperature_C = GetRandomFloat(-10, 40);
            if (OmitPropName != "AmbientSalinity_PSU") mikeScenario.AmbientSalinity_PSU = GetRandomFloat(0, 40);
            if (OmitPropName != "ManningNumber") mikeScenario.ManningNumber = GetRandomFloat(0, 100);
            if (OmitPropName != "UseWebTide") mikeScenario.UseWebTide = true;
            if (OmitPropName != "NumberOfElements") mikeScenario.NumberOfElements = GetRandomInt(1, 10000);
            if (OmitPropName != "NumberOfTimeSteps") mikeScenario.NumberOfTimeSteps = GetRandomInt(1, 10000);
            if (OmitPropName != "NumberOfSigmaLayers") mikeScenario.NumberOfSigmaLayers = GetRandomInt(0, 100);
            if (OmitPropName != "NumberOfZlayers") mikeScenario.NumberOfZlayers = GetRandomInt(0, 100);
            if (OmitPropName != "NumberOfHydroOutputParameters") mikeScenario.NumberOfHydroOutputParameters = GetRandomInt(0, 100);
            if (OmitPropName != "NumberOfTransOutputParameters") mikeScenario.NumberOfTransOutputParameters = GetRandomInt(0, 100);
            if (OmitPropName != "EstimatedHydroFileSize") mikeScenario.EstimatedHydroFileSize = GetRandomInt(0, 100000000);
            if (OmitPropName != "EstimatedTransFileSize") mikeScenario.EstimatedTransFileSize = GetRandomInt(0, 100000000);
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
            MikeScenario mikeScenario = GetFilledRandomMikeScenario("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

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

            //Error: Type not implemented [ScenarioStatus]

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("ErrorInfo");
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(1, mikeScenario.ValidationResults.Count());
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioErrorInfo)).Any());
            Assert.AreEqual(null, mikeScenario.ErrorInfo);
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

            // WindSpeed_km_h will automatically be initialized at 0 --> not null

            // WindDirection_deg will automatically be initialized at 0 --> not null

            // DecayFactor_per_day will automatically be initialized at 0 --> not null

            // DecayIsConstant will automatically be initialized at 0 --> not null

            // DecayFactorAmplitude will automatically be initialized at 0 --> not null

            // ResultFrequency_min will automatically be initialized at 0 --> not null

            // AmbientTemperature_C will automatically be initialized at 0 --> not null

            // AmbientSalinity_PSU will automatically be initialized at 0 --> not null

            // ManningNumber will automatically be initialized at 0 --> not null

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("LastUpdateDate_UTC");
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(1, mikeScenario.ValidationResults.Count());
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mikeScenario.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MikeScenarioTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MikeScenarioID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeScenarioTVItemID] of type [Int32]
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
            // doing property [ParentMikeScenarioID] of type [Int32]
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
            // doing property [ErrorInfo] of type [String]
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
            // doing property [MikeScenarioExecutionTime_min] of type [Single]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // MikeScenarioExecutionTime_min has Min [1] and Max [100000]. At Min should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1] and Max [100000]. At Min + 1 should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 2.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1] and Max [100000]. At Min - 1 should return false with one error
            mikeScenario.MikeScenarioExecutionTime_min = 0.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000")).Any());
            Assert.AreEqual(0.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1] and Max [100000]. At Max should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 100000.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100000.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1] and Max [100000]. At Max - 1 should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 99999.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99999.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1] and Max [100000]. At Max + 1 should return false with one error
            mikeScenario.MikeScenarioExecutionTime_min = 100001.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000")).Any());
            Assert.AreEqual(100001.0f, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [WindSpeed_km_h] of type [Single]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // WindSpeed_km_h has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.WindSpeed_km_h = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.WindSpeed_km_h = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.WindSpeed_km_h = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "100")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.WindSpeed_km_h = 100.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.WindSpeed_km_h = 99.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.WindSpeed_km_h = 101.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "100")).Any());
            Assert.AreEqual(101.0f, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [WindDirection_deg] of type [Single]
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
            // doing property [DecayFactor_per_day] of type [Single]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // DecayFactor_per_day has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.DecayFactor_per_day = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.DecayFactor_per_day = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.DecayFactor_per_day = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "100")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.DecayFactor_per_day = 100.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.DecayFactor_per_day = 99.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.DecayFactor_per_day = 101.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "100")).Any());
            Assert.AreEqual(101.0f, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [DecayIsConstant] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [DecayFactorAmplitude] of type [Single]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // DecayFactorAmplitude has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.DecayFactorAmplitude = 0.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.DecayFactorAmplitude = 1.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.DecayFactorAmplitude = -1.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100")).Any());
            Assert.AreEqual(-1.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.DecayFactorAmplitude = 100.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.DecayFactorAmplitude = 99.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.DecayFactorAmplitude = 101.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100")).Any());
            Assert.AreEqual(101.0f, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [ResultFrequency_min] of type [Int32]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // ResultFrequency_min has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.ResultFrequency_min = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.ResultFrequency_min = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.ResultFrequency_min = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.ResultFrequency_min = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.ResultFrequency_min = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.ResultFrequency_min = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [AmbientTemperature_C] of type [Single]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // AmbientTemperature_C has Min [-10] and Max [40]. At Min should return true and no errors
            mikeScenario.AmbientTemperature_C = -10.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(-10.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Min + 1 should return true and no errors
            mikeScenario.AmbientTemperature_C = -9.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(-9.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Min - 1 should return false with one error
            mikeScenario.AmbientTemperature_C = -11.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Max should return true and no errors
            mikeScenario.AmbientTemperature_C = 40.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(40.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Max - 1 should return true and no errors
            mikeScenario.AmbientTemperature_C = 39.0f;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(39.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10] and Max [40]. At Max + 1 should return false with one error
            mikeScenario.AmbientTemperature_C = 41.0f;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(41.0f, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [AmbientSalinity_PSU] of type [Single]
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
            // doing property [ManningNumber] of type [Single]
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
            // doing property [UseWebTide] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [NumberOfElements] of type [Int32]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfElements has Min [1] and Max [10000]. At Min should return true and no errors
            mikeScenario.NumberOfElements = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfElements = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfElements = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "10000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfElements);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Max should return true and no errors
            mikeScenario.NumberOfElements = 10000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(10000, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfElements = 9999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(9999, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfElements = 10001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "10000")).Any());
            Assert.AreEqual(10001, mikeScenario.NumberOfElements);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfTimeSteps] of type [Int32]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Min should return true and no errors
            mikeScenario.NumberOfTimeSteps = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfTimeSteps = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfTimeSteps = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Max should return true and no errors
            mikeScenario.NumberOfTimeSteps = 10000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(10000, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfTimeSteps = 9999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(9999, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfTimeSteps = 10001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000")).Any());
            Assert.AreEqual(10001, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfSigmaLayers] of type [Int32]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.NumberOfSigmaLayers = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.NumberOfSigmaLayers = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfZlayers] of type [Int32]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfZlayers has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.NumberOfZlayers = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfZlayers = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.NumberOfZlayers = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZlayers, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.NumberOfZlayers = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfZlayers = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfZlayers has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.NumberOfZlayers = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZlayers, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.NumberOfZlayers);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfHydroOutputParameters] of type [Int32]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.NumberOfHydroOutputParameters = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.NumberOfHydroOutputParameters = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [NumberOfTransOutputParameters] of type [Int32]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.NumberOfTransOutputParameters = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.NumberOfTransOutputParameters = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [EstimatedHydroFileSize] of type [Int64]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Min should return true and no errors
            mikeScenario.EstimatedHydroFileSize = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Min + 1 should return true and no errors
            mikeScenario.EstimatedHydroFileSize = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Min - 1 should return false with one error
            mikeScenario.EstimatedHydroFileSize = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000")).Any());
            Assert.AreEqual(-1, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Max should return true and no errors
            mikeScenario.EstimatedHydroFileSize = 100000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100000000, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Max - 1 should return true and no errors
            mikeScenario.EstimatedHydroFileSize = 99999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99999999, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Max + 1 should return false with one error
            mikeScenario.EstimatedHydroFileSize = 100000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000")).Any());
            Assert.AreEqual(100000001, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [EstimatedTransFileSize] of type [Int64]
            //-----------------------------------

            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Min should return true and no errors
            mikeScenario.EstimatedTransFileSize = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Min + 1 should return true and no errors
            mikeScenario.EstimatedTransFileSize = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Min - 1 should return false with one error
            mikeScenario.EstimatedTransFileSize = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000")).Any());
            Assert.AreEqual(-1, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Max should return true and no errors
            mikeScenario.EstimatedTransFileSize = 100000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100000000, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Max - 1 should return true and no errors
            mikeScenario.EstimatedTransFileSize = 99999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99999999, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Max + 1 should return false with one error
            mikeScenario.EstimatedTransFileSize = 100000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000")).Any());
            Assert.AreEqual(100000001, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(0, mikeScenarioService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [MikeScenarioTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
