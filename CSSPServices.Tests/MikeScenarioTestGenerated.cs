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
        private MikeScenarioService mikeScenarioService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioTest() : base()
        {
            mikeScenarioService = new MikeScenarioService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeScenario GetFilledRandomMikeScenario(string OmitPropName)
        {
            MikeScenario mikeScenario = new MikeScenario();

            if (OmitPropName != "MikeScenarioTVItemID") mikeScenario.MikeScenarioTVItemID = 25;
            if (OmitPropName != "ParentMikeScenarioID") mikeScenario.ParentMikeScenarioID = 25;
            if (OmitPropName != "ScenarioStatus") mikeScenario.ScenarioStatus = (ScenarioStatusEnum)GetRandomEnumType(typeof(ScenarioStatusEnum));
            if (OmitPropName != "ErrorInfo") mikeScenario.ErrorInfo = GetRandomString("", 20);
            if (OmitPropName != "MikeScenarioStartDateTime_Local") mikeScenario.MikeScenarioStartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "MikeScenarioEndDateTime_Local") mikeScenario.MikeScenarioEndDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "MikeScenarioStartExecutionDateTime_Local") mikeScenario.MikeScenarioStartExecutionDateTime_Local = GetRandomDateTime();
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
            if (OmitPropName != "LastUpdateDate_UTC") mikeScenario.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mikeScenario.LastUpdateContactTVItemID = 2;

            return mikeScenario;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MikeScenario_Testing()
        {

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

            mikeScenario = GetFilledRandomMikeScenario("");
            mikeScenario.MikeScenarioID = 0;
            mikeScenarioService.Update(mikeScenario);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioID), mikeScenario.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MikeScenario)]
            // [Range(1, -1)]
            // mikeScenario.MikeScenarioTVItemID   (Int32)
            // -----------------------------------

            // MikeScenarioTVItemID will automatically be initialized at 0 --> not null


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // MikeScenarioTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeScenario.MikeScenarioTVItemID = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.MikeScenarioTVItemID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // MikeScenarioTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeScenario.MikeScenarioTVItemID = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.MikeScenarioTVItemID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // MikeScenarioTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeScenario.MikeScenarioTVItemID = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioMikeScenarioTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeScenario.MikeScenarioTVItemID);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MikeScenario)]
            // [Range(1, -1)]
            // mikeScenario.ParentMikeScenarioID   (Int32)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // ParentMikeScenarioID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeScenario.ParentMikeScenarioID = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.ParentMikeScenarioID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ParentMikeScenarioID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeScenario.ParentMikeScenarioID = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.ParentMikeScenarioID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ParentMikeScenarioID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeScenario.ParentMikeScenarioID = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioParentMikeScenarioID, "1")).Any());
            Assert.AreEqual(0, mikeScenario.ParentMikeScenarioID);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mikeScenario.ScenarioStatus   (ScenarioStatusEnum)
            // -----------------------------------

            // ScenarioStatus will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is Nullable
            // mikeScenario.ErrorInfo   (String)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeScenario.MikeScenarioStartDateTime_Local   (DateTime)
            // -----------------------------------

            // MikeScenarioStartDateTime_Local will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeScenario.MikeScenarioEndDateTime_Local   (DateTime)
            // -----------------------------------

            // MikeScenarioEndDateTime_Local will automatically be initialized at 0 --> not null


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
            // MikeScenarioExecutionTime_min has Min [1.0D] and Max [100000.0D]. At Min should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 1.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1.0D] and Max [100000.0D]. At Min + 1 should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 2.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2.0D, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1.0D] and Max [100000.0D]. At Min - 1 should return false with one error
            mikeScenario.MikeScenarioExecutionTime_min = 0.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000")).Any());
            Assert.AreEqual(0.0D, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1.0D] and Max [100000.0D]. At Max should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 100000.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100000.0D, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1.0D] and Max [100000.0D]. At Max - 1 should return true and no errors
            mikeScenario.MikeScenarioExecutionTime_min = 99999.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99999.0D, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // MikeScenarioExecutionTime_min has Min [1.0D] and Max [100000.0D]. At Max + 1 should return false with one error
            mikeScenario.MikeScenarioExecutionTime_min = 100001.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000")).Any());
            Assert.AreEqual(100001.0D, mikeScenario.MikeScenarioExecutionTime_min);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // mikeScenario.WindSpeed_km_h   (Double)
            // -----------------------------------

            //Error: Type not implemented [WindSpeed_km_h]


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // WindSpeed_km_h has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            mikeScenario.WindSpeed_km_h = 0.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            mikeScenario.WindSpeed_km_h = 1.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            mikeScenario.WindSpeed_km_h = -1.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "100")).Any());
            Assert.AreEqual(-1.0D, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            mikeScenario.WindSpeed_km_h = 100.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100.0D, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            mikeScenario.WindSpeed_km_h = 99.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99.0D, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindSpeed_km_h has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            mikeScenario.WindSpeed_km_h = 101.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "100")).Any());
            Assert.AreEqual(101.0D, mikeScenario.WindSpeed_km_h);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 360)]
            // mikeScenario.WindDirection_deg   (Double)
            // -----------------------------------

            //Error: Type not implemented [WindDirection_deg]


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // WindDirection_deg has Min [0.0D] and Max [360.0D]. At Min should return true and no errors
            mikeScenario.WindDirection_deg = 0.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeScenario.WindDirection_deg);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0.0D] and Max [360.0D]. At Min + 1 should return true and no errors
            mikeScenario.WindDirection_deg = 1.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeScenario.WindDirection_deg);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0.0D] and Max [360.0D]. At Min - 1 should return false with one error
            mikeScenario.WindDirection_deg = -1.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindDirection_deg, "0", "360")).Any());
            Assert.AreEqual(-1.0D, mikeScenario.WindDirection_deg);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0.0D] and Max [360.0D]. At Max should return true and no errors
            mikeScenario.WindDirection_deg = 360.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(360.0D, mikeScenario.WindDirection_deg);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0.0D] and Max [360.0D]. At Max - 1 should return true and no errors
            mikeScenario.WindDirection_deg = 359.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(359.0D, mikeScenario.WindDirection_deg);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // WindDirection_deg has Min [0.0D] and Max [360.0D]. At Max + 1 should return false with one error
            mikeScenario.WindDirection_deg = 361.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindDirection_deg, "0", "360")).Any());
            Assert.AreEqual(361.0D, mikeScenario.WindDirection_deg);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // mikeScenario.DecayFactor_per_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [DecayFactor_per_day]


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // DecayFactor_per_day has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            mikeScenario.DecayFactor_per_day = 0.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            mikeScenario.DecayFactor_per_day = 1.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            mikeScenario.DecayFactor_per_day = -1.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "100")).Any());
            Assert.AreEqual(-1.0D, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            mikeScenario.DecayFactor_per_day = 100.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100.0D, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            mikeScenario.DecayFactor_per_day = 99.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99.0D, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactor_per_day has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            mikeScenario.DecayFactor_per_day = 101.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "100")).Any());
            Assert.AreEqual(101.0D, mikeScenario.DecayFactor_per_day);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // mikeScenario.DecayIsConstant   (Boolean)
            // -----------------------------------

            // DecayIsConstant will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // mikeScenario.DecayFactorAmplitude   (Double)
            // -----------------------------------

            //Error: Type not implemented [DecayFactorAmplitude]


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // DecayFactorAmplitude has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            mikeScenario.DecayFactorAmplitude = 0.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            mikeScenario.DecayFactorAmplitude = 1.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            mikeScenario.DecayFactorAmplitude = -1.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100")).Any());
            Assert.AreEqual(-1.0D, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            mikeScenario.DecayFactorAmplitude = 100.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100.0D, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            mikeScenario.DecayFactorAmplitude = 99.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99.0D, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // DecayFactorAmplitude has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            mikeScenario.DecayFactorAmplitude = 101.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100")).Any());
            Assert.AreEqual(101.0D, mikeScenario.DecayFactorAmplitude);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // mikeScenario.ResultFrequency_min   (Int32)
            // -----------------------------------

            // ResultFrequency_min will automatically be initialized at 0 --> not null


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // ResultFrequency_min has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.ResultFrequency_min = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.ResultFrequency_min = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.ResultFrequency_min = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.ResultFrequency_min = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.ResultFrequency_min = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ResultFrequency_min has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.ResultFrequency_min = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.ResultFrequency_min);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-10, 40)]
            // mikeScenario.AmbientTemperature_C   (Double)
            // -----------------------------------

            //Error: Type not implemented [AmbientTemperature_C]


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Min should return true and no errors
            mikeScenario.AmbientTemperature_C = -10.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(-10.0D, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mikeScenario.AmbientTemperature_C = -9.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(-9.0D, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mikeScenario.AmbientTemperature_C = -11.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(-11.0D, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Max should return true and no errors
            mikeScenario.AmbientTemperature_C = 40.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(40.0D, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mikeScenario.AmbientTemperature_C = 39.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(39.0D, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientTemperature_C has Min [-10.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mikeScenario.AmbientTemperature_C = 41.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40")).Any());
            Assert.AreEqual(41.0D, mikeScenario.AmbientTemperature_C);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 40)]
            // mikeScenario.AmbientSalinity_PSU   (Double)
            // -----------------------------------

            //Error: Type not implemented [AmbientSalinity_PSU]


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min should return true and no errors
            mikeScenario.AmbientSalinity_PSU = 0.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            mikeScenario.AmbientSalinity_PSU = 1.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Min - 1 should return false with one error
            mikeScenario.AmbientSalinity_PSU = -1.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(-1.0D, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max should return true and no errors
            mikeScenario.AmbientSalinity_PSU = 40.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(40.0D, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            mikeScenario.AmbientSalinity_PSU = 39.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(39.0D, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // AmbientSalinity_PSU has Min [0.0D] and Max [40.0D]. At Max + 1 should return false with one error
            mikeScenario.AmbientSalinity_PSU = 41.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40")).Any());
            Assert.AreEqual(41.0D, mikeScenario.AmbientSalinity_PSU);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // mikeScenario.ManningNumber   (Double)
            // -----------------------------------

            //Error: Type not implemented [ManningNumber]


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // ManningNumber has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            mikeScenario.ManningNumber = 0.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0.0D, mikeScenario.ManningNumber);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            mikeScenario.ManningNumber = 1.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1.0D, mikeScenario.ManningNumber);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            mikeScenario.ManningNumber = -1.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioManningNumber, "0", "100")).Any());
            Assert.AreEqual(-1.0D, mikeScenario.ManningNumber);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            mikeScenario.ManningNumber = 100.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100.0D, mikeScenario.ManningNumber);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            mikeScenario.ManningNumber = 99.0D;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99.0D, mikeScenario.ManningNumber);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // ManningNumber has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            mikeScenario.ManningNumber = 101.0D;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioManningNumber, "0", "100")).Any());
            Assert.AreEqual(101.0D, mikeScenario.ManningNumber);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(1, 10000)]
            // mikeScenario.NumberOfElements   (Int32)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfElements has Min [1] and Max [10000]. At Min should return true and no errors
            mikeScenario.NumberOfElements = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfElements = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfElements = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "10000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfElements);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Max should return true and no errors
            mikeScenario.NumberOfElements = 10000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(10000, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfElements = 9999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(9999, mikeScenario.NumberOfElements);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfElements has Min [1] and Max [10000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfElements = 10001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "10000")).Any());
            Assert.AreEqual(10001, mikeScenario.NumberOfElements);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(1, 10000)]
            // mikeScenario.NumberOfTimeSteps   (Int32)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Min should return true and no errors
            mikeScenario.NumberOfTimeSteps = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfTimeSteps = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Min - 1 should return false with one error
            mikeScenario.NumberOfTimeSteps = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000")).Any());
            Assert.AreEqual(0, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Max should return true and no errors
            mikeScenario.NumberOfTimeSteps = 10000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(10000, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfTimeSteps = 9999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(9999, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTimeSteps has Min [1] and Max [10000]. At Max + 1 should return false with one error
            mikeScenario.NumberOfTimeSteps = 10001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000")).Any());
            Assert.AreEqual(10001, mikeScenario.NumberOfTimeSteps);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // mikeScenario.NumberOfSigmaLayers   (Int32)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.NumberOfSigmaLayers = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfSigmaLayers = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfSigmaLayers has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.NumberOfSigmaLayers = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.NumberOfSigmaLayers);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // mikeScenario.NumberOfZLayers   (Int32)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfZLayers has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.NumberOfZLayers = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.NumberOfZLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfZLayers has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfZLayers = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfZLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfZLayers has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.NumberOfZLayers = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZLayers, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.NumberOfZLayers);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfZLayers has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.NumberOfZLayers = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.NumberOfZLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfZLayers has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfZLayers = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.NumberOfZLayers);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfZLayers has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.NumberOfZLayers = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZLayers, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.NumberOfZLayers);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // mikeScenario.NumberOfHydroOutputParameters   (Int32)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.NumberOfHydroOutputParameters = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfHydroOutputParameters = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfHydroOutputParameters has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.NumberOfHydroOutputParameters = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.NumberOfHydroOutputParameters);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // mikeScenario.NumberOfTransOutputParameters   (Int32)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Min should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Min + 1 should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Min - 1 should return false with one error
            mikeScenario.NumberOfTransOutputParameters = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100")).Any());
            Assert.AreEqual(-1, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Max should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 100;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Max - 1 should return true and no errors
            mikeScenario.NumberOfTransOutputParameters = 99;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // NumberOfTransOutputParameters has Min [0] and Max [100]. At Max + 1 should return false with one error
            mikeScenario.NumberOfTransOutputParameters = 101;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100")).Any());
            Assert.AreEqual(101, mikeScenario.NumberOfTransOutputParameters);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100000000)]
            // mikeScenario.EstimatedHydroFileSize   (Int64)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Min should return true and no errors
            mikeScenario.EstimatedHydroFileSize = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Min + 1 should return true and no errors
            mikeScenario.EstimatedHydroFileSize = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Min - 1 should return false with one error
            mikeScenario.EstimatedHydroFileSize = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000")).Any());
            Assert.AreEqual(-1, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Max should return true and no errors
            mikeScenario.EstimatedHydroFileSize = 100000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100000000, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Max - 1 should return true and no errors
            mikeScenario.EstimatedHydroFileSize = 99999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99999999, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedHydroFileSize has Min [0] and Max [100000000]. At Max + 1 should return false with one error
            mikeScenario.EstimatedHydroFileSize = 100000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000")).Any());
            Assert.AreEqual(100000001, mikeScenario.EstimatedHydroFileSize);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100000000)]
            // mikeScenario.EstimatedTransFileSize   (Int64)
            // -----------------------------------


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Min should return true and no errors
            mikeScenario.EstimatedTransFileSize = 0;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(0, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Min + 1 should return true and no errors
            mikeScenario.EstimatedTransFileSize = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Min - 1 should return false with one error
            mikeScenario.EstimatedTransFileSize = -1;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000")).Any());
            Assert.AreEqual(-1, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Max should return true and no errors
            mikeScenario.EstimatedTransFileSize = 100000000;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(100000000, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Max - 1 should return true and no errors
            mikeScenario.EstimatedTransFileSize = 99999999;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(99999999, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // EstimatedTransFileSize has Min [0] and Max [100000000]. At Max + 1 should return false with one error
            mikeScenario.EstimatedTransFileSize = 100000001;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000")).Any());
            Assert.AreEqual(100000001, mikeScenario.EstimatedTransFileSize);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeScenario.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // mikeScenario.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            mikeScenario = null;
            mikeScenario = GetFilledRandomMikeScenario("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeScenario.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(1, mikeScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeScenario.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mikeScenarioService.Add(mikeScenario));
            Assert.AreEqual(0, mikeScenario.ValidationResults.Count());
            Assert.AreEqual(2, mikeScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeScenarioService.Delete(mikeScenario));
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeScenario.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mikeScenarioService.Add(mikeScenario));
            Assert.IsTrue(mikeScenario.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeScenario.LastUpdateContactTVItemID);
            Assert.AreEqual(count, mikeScenarioService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mikeScenario.MikeScenarioTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mikeScenario.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
