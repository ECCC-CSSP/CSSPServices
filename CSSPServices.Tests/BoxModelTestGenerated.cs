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
    public partial class BoxModelTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int BoxModelID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModel GetFilledRandomBoxModel(string OmitPropName)
        {
            BoxModelID += 1;

            BoxModel boxModel = new BoxModel();

            if (OmitPropName != "BoxModelID") boxModel.BoxModelID = BoxModelID;
            if (OmitPropName != "InfrastructureTVItemID") boxModel.InfrastructureTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Flow_m3_day") boxModel.Flow_m3_day = GetRandomFloat(0, 1000000);
            if (OmitPropName != "Depth_m") boxModel.Depth_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "Temperature_C") boxModel.Temperature_C = GetRandomFloat(0, 50);
            if (OmitPropName != "Dilution") boxModel.Dilution = GetRandomFloat(0, 1000000);
            if (OmitPropName != "DecayRate_per_day") boxModel.DecayRate_per_day = GetRandomFloat(0, 1000);
            if (OmitPropName != "FCUntreated_MPN_100ml") boxModel.FCUntreated_MPN_100ml = GetRandomInt(0, 20000000);
            if (OmitPropName != "FCPreDisinfection_MPN_100ml") boxModel.FCPreDisinfection_MPN_100ml = GetRandomInt(0, 20000000);
            if (OmitPropName != "Concentration_MPN_100ml") boxModel.Concentration_MPN_100ml = GetRandomInt(0, 20000000);
            if (OmitPropName != "T90_hour") boxModel.T90_hour = GetRandomFloat(0, 10000);
            if (OmitPropName != "FlowDuration_hour") boxModel.FlowDuration_hour = GetRandomFloat(0, 10000);
            if (OmitPropName != "LastUpdateDate_UTC") boxModel.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") boxModel.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return boxModel;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void BoxModel_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            BoxModelService boxModelService = new BoxModelService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            BoxModel boxModel = GetFilledRandomBoxModel("");
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(true, boxModelService.GetRead().Where(c => c == boxModel).Any());
            boxModel.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, boxModelService.Update(boxModel));
            Assert.AreEqual(1, boxModelService.GetRead().Count());
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // InfrastructureTVItemID will automatically be initialized at 0 --> not null

            // Flow_m3_day will automatically be initialized at 0.0f --> not null

            // Depth_m will automatically be initialized at 0.0f --> not null

            // Temperature_C will automatically be initialized at 0.0f --> not null

            // Dilution will automatically be initialized at 0.0f --> not null

            // DecayRate_per_day will automatically be initialized at 0.0f --> not null

            // FCUntreated_MPN_100ml will automatically be initialized at 0 --> not null

            // FCPreDisinfection_MPN_100ml will automatically be initialized at 0 --> not null

            // Concentration_MPN_100ml will automatically be initialized at 0 --> not null

            // T90_hour will automatically be initialized at 0.0f --> not null

            // FlowDuration_hour will automatically be initialized at 0.0f --> not null

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("LastUpdateDate_UTC");
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.AreEqual(1, boxModel.ValidationResults.Count());
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLastUpdateDate_UTC)).Any());
            Assert.IsTrue(boxModel.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [BoxModelID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItemID] of type [int]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModel.InfrastructureTVItemID = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.InfrastructureTVItemID);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModel.InfrastructureTVItemID = 2;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(2, boxModel.InfrastructureTVItemID);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModel.InfrastructureTVItemID = 0;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelInfrastructureTVItemID, "1")).Any());
            Assert.AreEqual(0, boxModel.InfrastructureTVItemID);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [Flow_m3_day] of type [float]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Flow_m3_day has Min [0] and Max [1000000]. At Min should return true and no errors
            boxModel.Flow_m3_day = 0.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModel.Flow_m3_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            boxModel.Flow_m3_day = 1.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModel.Flow_m3_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            boxModel.Flow_m3_day = -1.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, boxModel.Flow_m3_day);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0] and Max [1000000]. At Max should return true and no errors
            boxModel.Flow_m3_day = 1000000.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, boxModel.Flow_m3_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            boxModel.Flow_m3_day = 999999.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(999999.0f, boxModel.Flow_m3_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            boxModel.Flow_m3_day = 1000001.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, boxModel.Flow_m3_day);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [Depth_m] of type [float]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Depth_m has Min [0] and Max [1000]. At Min should return true and no errors
            boxModel.Depth_m = 0.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModel.Depth_m);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            boxModel.Depth_m = 1.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModel.Depth_m);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            boxModel.Depth_m = -1.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, boxModel.Depth_m);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Max should return true and no errors
            boxModel.Depth_m = 1000.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1000.0f, boxModel.Depth_m);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            boxModel.Depth_m = 999.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(999.0f, boxModel.Depth_m);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Depth_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            boxModel.Depth_m = 1001.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, boxModel.Depth_m);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [Temperature_C] of type [float]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Temperature_C has Min [0] and Max [50]. At Min should return true and no errors
            boxModel.Temperature_C = 0.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModel.Temperature_C);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Temperature_C has Min [0] and Max [50]. At Min + 1 should return true and no errors
            boxModel.Temperature_C = 1.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModel.Temperature_C);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Temperature_C has Min [0] and Max [50]. At Min - 1 should return false with one error
            boxModel.Temperature_C = -1.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelTemperature_C, "0", "50")).Any());
            Assert.AreEqual(-1.0f, boxModel.Temperature_C);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Temperature_C has Min [0] and Max [50]. At Max should return true and no errors
            boxModel.Temperature_C = 50.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(50.0f, boxModel.Temperature_C);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Temperature_C has Min [0] and Max [50]. At Max - 1 should return true and no errors
            boxModel.Temperature_C = 49.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(49.0f, boxModel.Temperature_C);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Temperature_C has Min [0] and Max [50]. At Max + 1 should return false with one error
            boxModel.Temperature_C = 51.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelTemperature_C, "0", "50")).Any());
            Assert.AreEqual(51.0f, boxModel.Temperature_C);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [Dilution] of type [float]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Dilution has Min [0] and Max [1000000]. At Min should return true and no errors
            boxModel.Dilution = 0.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            boxModel.Dilution = 1.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            boxModel.Dilution = -1.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDilution, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, boxModel.Dilution);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Max should return true and no errors
            boxModel.Dilution = 1000000.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            boxModel.Dilution = 999999.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(999999.0f, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            boxModel.Dilution = 1000001.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDilution, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, boxModel.Dilution);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [DecayRate_per_day] of type [float]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // DecayRate_per_day has Min [0] and Max [1000]. At Min should return true and no errors
            boxModel.DecayRate_per_day = 0.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModel.DecayRate_per_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            boxModel.DecayRate_per_day = 1.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModel.DecayRate_per_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Min - 1 should return false with one error
            boxModel.DecayRate_per_day = -1.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDecayRate_per_day, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, boxModel.DecayRate_per_day);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Max should return true and no errors
            boxModel.DecayRate_per_day = 1000.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1000.0f, boxModel.DecayRate_per_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            boxModel.DecayRate_per_day = 999.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(999.0f, boxModel.DecayRate_per_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0] and Max [1000]. At Max + 1 should return false with one error
            boxModel.DecayRate_per_day = 1001.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDecayRate_per_day, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, boxModel.DecayRate_per_day);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [FCUntreated_MPN_100ml] of type [int]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // FCUntreated_MPN_100ml has Min [0] and Max [20000000]. At Min should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [20000000]. At Min + 1 should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [20000000]. At Min - 1 should return false with one error
            boxModel.FCUntreated_MPN_100ml = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(-1, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [20000000]. At Max should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 20000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(20000000, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [20000000]. At Max - 1 should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 19999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(19999999, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [20000000]. At Max + 1 should return false with one error
            boxModel.FCUntreated_MPN_100ml = 20000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(20000001, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [FCPreDisinfection_MPN_100ml] of type [int]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [20000000]. At Min should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [20000000]. At Min + 1 should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [20000000]. At Min - 1 should return false with one error
            boxModel.FCPreDisinfection_MPN_100ml = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(-1, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [20000000]. At Max should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 20000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(20000000, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [20000000]. At Max - 1 should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 19999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(19999999, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [20000000]. At Max + 1 should return false with one error
            boxModel.FCPreDisinfection_MPN_100ml = 20000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(20000001, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [Concentration_MPN_100ml] of type [int]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Min should return true and no errors
            boxModel.Concentration_MPN_100ml = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Min + 1 should return true and no errors
            boxModel.Concentration_MPN_100ml = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Min - 1 should return false with one error
            boxModel.Concentration_MPN_100ml = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelConcentration_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(-1, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Max should return true and no errors
            boxModel.Concentration_MPN_100ml = 20000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(20000000, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Max - 1 should return true and no errors
            boxModel.Concentration_MPN_100ml = 19999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(19999999, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [20000000]. At Max + 1 should return false with one error
            boxModel.Concentration_MPN_100ml = 20000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelConcentration_MPN_100ml, "0", "20000000")).Any());
            Assert.AreEqual(20000001, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [T90_hour] of type [float]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // T90_hour has Min [0] and Max [10000]. At Min should return true and no errors
            boxModel.T90_hour = 0.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModel.T90_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // T90_hour has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            boxModel.T90_hour = 1.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModel.T90_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // T90_hour has Min [0] and Max [10000]. At Min - 1 should return false with one error
            boxModel.T90_hour = -1.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelT90_hour, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, boxModel.T90_hour);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // T90_hour has Min [0] and Max [10000]. At Max should return true and no errors
            boxModel.T90_hour = 10000.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000.0f, boxModel.T90_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // T90_hour has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            boxModel.T90_hour = 9999.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999.0f, boxModel.T90_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // T90_hour has Min [0] and Max [10000]. At Max + 1 should return false with one error
            boxModel.T90_hour = 10001.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelT90_hour, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, boxModel.T90_hour);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [FlowDuration_hour] of type [float]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // FlowDuration_hour has Min [0] and Max [10000]. At Min should return true and no errors
            boxModel.FlowDuration_hour = 0.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModel.FlowDuration_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            boxModel.FlowDuration_hour = 1.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModel.FlowDuration_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0] and Max [10000]. At Min - 1 should return false with one error
            boxModel.FlowDuration_hour = -1.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlowDuration_hour, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, boxModel.FlowDuration_hour);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0] and Max [10000]. At Max should return true and no errors
            boxModel.FlowDuration_hour = 10000.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000.0f, boxModel.FlowDuration_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            boxModel.FlowDuration_hour = 9999.0f;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999.0f, boxModel.FlowDuration_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0] and Max [10000]. At Max + 1 should return false with one error
            boxModel.FlowDuration_hour = 10001.0f;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlowDuration_hour, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, boxModel.FlowDuration_hour);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModel.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModel.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(2, boxModel.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModel.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, boxModel.LastUpdateContactTVItemID);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
