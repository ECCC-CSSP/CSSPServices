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
        private BoxModelService boxModelService { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelTest() : base()
        {
            boxModelService = new BoxModelService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModel GetFilledRandomBoxModel(string OmitPropName)
        {
            BoxModel boxModel = new BoxModel();

            if (OmitPropName != "InfrastructureTVItemID") boxModel.InfrastructureTVItemID = 16;
            if (OmitPropName != "Flow_m3_day") boxModel.Flow_m3_day = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "Depth_m") boxModel.Depth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "Temperature_C") boxModel.Temperature_C = GetRandomDouble(-15.0D, 40.0D);
            if (OmitPropName != "Dilution") boxModel.Dilution = GetRandomInt(0, 10000000);
            if (OmitPropName != "DecayRate_per_day") boxModel.DecayRate_per_day = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "FCUntreated_MPN_100ml") boxModel.FCUntreated_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "FCPreDisinfection_MPN_100ml") boxModel.FCPreDisinfection_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Concentration_MPN_100ml") boxModel.Concentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "T90_hour") boxModel.T90_hour = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "FlowDuration_hour") boxModel.FlowDuration_hour = GetRandomDouble(0.0D, 24.0D);
            if (OmitPropName != "LastUpdateDate_UTC") boxModel.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModel.LastUpdateContactTVItemID = 2;

            return boxModel;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void BoxModel_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            BoxModel boxModel = GetFilledRandomBoxModel("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = boxModelService.GetRead().Count();

            boxModelService.Add(boxModel);
            if (boxModel.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, boxModelService.GetRead().Where(c => c == boxModel).Any());
            boxModelService.Update(boxModel);
            if (boxModel.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, boxModelService.GetRead().Count());
            boxModelService.Delete(boxModel);
            if (boxModel.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", boxModel.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // boxModel.BoxModelID   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.BoxModelID = 0;
            boxModelService.Update(boxModel);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelBoxModelID), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Infrastructure)]
            // boxModel.InfrastructureTVItemID   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.InfrastructureTVItemID = 0;
            boxModelService.Add(boxModel);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelInfrastructureTVItemID, boxModel.InfrastructureTVItemID.ToString()), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

            // InfrastructureTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000)]
            // boxModel.Flow_m3_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [Flow_m3_day]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Flow_m3_day has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            boxModel.Flow_m3_day = 0.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModel.Flow_m3_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            boxModel.Flow_m3_day = 1.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModel.Flow_m3_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            boxModel.Flow_m3_day = -1.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlow_m3_day, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, boxModel.Flow_m3_day);
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            boxModel.Flow_m3_day = 10000.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000.0D, boxModel.Flow_m3_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            boxModel.Flow_m3_day = 9999.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999.0D, boxModel.Flow_m3_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Flow_m3_day has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            boxModel.Flow_m3_day = 10001.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlow_m3_day, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, boxModel.Flow_m3_day);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // boxModel.Depth_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [Depth_m]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            boxModel.Depth_m = 0.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModel.Depth_m);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            boxModel.Depth_m = 1.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModel.Depth_m);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            boxModel.Depth_m = -1.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDepth_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, boxModel.Depth_m);
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            boxModel.Depth_m = 1000.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1000.0D, boxModel.Depth_m);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            boxModel.Depth_m = 999.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(999.0D, boxModel.Depth_m);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            boxModel.Depth_m = 1001.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDepth_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, boxModel.Depth_m);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-15, 40)]
            // boxModel.Temperature_C   (Double)
            // -----------------------------------

            //Error: Type not implemented [Temperature_C]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Temperature_C has Min [-15.0D] and Max [40.0D]. At Min should return true and no errors
            boxModel.Temperature_C = -15.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(-15.0D, boxModel.Temperature_C);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Temperature_C has Min [-15.0D] and Max [40.0D]. At Min + 1 should return true and no errors
            boxModel.Temperature_C = -14.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(-14.0D, boxModel.Temperature_C);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Temperature_C has Min [-15.0D] and Max [40.0D]. At Min - 1 should return false with one error
            boxModel.Temperature_C = -16.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelTemperature_C, "-15", "40")).Any());
            Assert.AreEqual(-16.0D, boxModel.Temperature_C);
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Temperature_C has Min [-15.0D] and Max [40.0D]. At Max should return true and no errors
            boxModel.Temperature_C = 40.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(40.0D, boxModel.Temperature_C);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Temperature_C has Min [-15.0D] and Max [40.0D]. At Max - 1 should return true and no errors
            boxModel.Temperature_C = 39.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(39.0D, boxModel.Temperature_C);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Temperature_C has Min [-15.0D] and Max [40.0D]. At Max + 1 should return false with one error
            boxModel.Temperature_C = 41.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelTemperature_C, "-15", "40")).Any());
            Assert.AreEqual(41.0D, boxModel.Temperature_C);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000000)]
            // boxModel.Dilution   (Int32)
            // -----------------------------------

            // Dilution will automatically be initialized at 0 --> not null

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Dilution has Min [0] and Max [10000000]. At Min should return true and no errors
            boxModel.Dilution = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            boxModel.Dilution = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            boxModel.Dilution = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDilution, "0", "10000000")).Any());
            Assert.AreEqual(-1, boxModel.Dilution);
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Max should return true and no errors
            boxModel.Dilution = 10000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000000, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            boxModel.Dilution = 9999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999999, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            boxModel.Dilution = 10000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDilution, "0", "10000000")).Any());
            Assert.AreEqual(10000001, boxModel.Dilution);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // boxModel.DecayRate_per_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [DecayRate_per_day]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            boxModel.DecayRate_per_day = 0.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModel.DecayRate_per_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            boxModel.DecayRate_per_day = 1.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModel.DecayRate_per_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            boxModel.DecayRate_per_day = -1.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDecayRate_per_day, "0", "100")).Any());
            Assert.AreEqual(-1.0D, boxModel.DecayRate_per_day);
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            boxModel.DecayRate_per_day = 100.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(100.0D, boxModel.DecayRate_per_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            boxModel.DecayRate_per_day = 99.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(99.0D, boxModel.DecayRate_per_day);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // DecayRate_per_day has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            boxModel.DecayRate_per_day = 101.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDecayRate_per_day, "0", "100")).Any());
            Assert.AreEqual(101.0D, boxModel.DecayRate_per_day);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000000)]
            // boxModel.FCUntreated_MPN_100ml   (Int32)
            // -----------------------------------

            // FCUntreated_MPN_100ml will automatically be initialized at 0 --> not null

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            boxModel.FCUntreated_MPN_100ml = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 10000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000000, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 9999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999999, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            boxModel.FCUntreated_MPN_100ml = 10000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000000)]
            // boxModel.FCPreDisinfection_MPN_100ml   (Int32)
            // -----------------------------------

            // FCPreDisinfection_MPN_100ml will automatically be initialized at 0 --> not null

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            boxModel.FCPreDisinfection_MPN_100ml = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 10000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000000, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 9999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999999, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            boxModel.FCPreDisinfection_MPN_100ml = 10000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000000)]
            // boxModel.Concentration_MPN_100ml   (Int32)
            // -----------------------------------

            // Concentration_MPN_100ml will automatically be initialized at 0 --> not null

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            boxModel.Concentration_MPN_100ml = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            boxModel.Concentration_MPN_100ml = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            boxModel.Concentration_MPN_100ml = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            boxModel.Concentration_MPN_100ml = 10000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000000, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            boxModel.Concentration_MPN_100ml = 9999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999999, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            boxModel.Concentration_MPN_100ml = 10000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, -1)]
            // boxModel.T90_hour   (Double)
            // -----------------------------------

            //Error: Type not implemented [T90_hour]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // T90_hour has Min [0.0D] and Max [empty]. At Min should return true and no errors
            boxModel.T90_hour = 0.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModel.T90_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // T90_hour has Min [0.0D] and Max [empty]. At Min + 1 should return true and no errors
            boxModel.T90_hour = 1.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModel.T90_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // T90_hour has Min [0.0D] and Max [empty]. At Min - 1 should return false with one error
            boxModel.T90_hour = -1.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelT90_hour, "0")).Any());
            Assert.AreEqual(-1.0D, boxModel.T90_hour);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 24)]
            // boxModel.FlowDuration_hour   (Double)
            // -----------------------------------

            //Error: Type not implemented [FlowDuration_hour]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // FlowDuration_hour has Min [0.0D] and Max [24.0D]. At Min should return true and no errors
            boxModel.FlowDuration_hour = 0.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModel.FlowDuration_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0.0D] and Max [24.0D]. At Min + 1 should return true and no errors
            boxModel.FlowDuration_hour = 1.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModel.FlowDuration_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0.0D] and Max [24.0D]. At Min - 1 should return false with one error
            boxModel.FlowDuration_hour = -1.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlowDuration_hour, "0", "24")).Any());
            Assert.AreEqual(-1.0D, boxModel.FlowDuration_hour);
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0.0D] and Max [24.0D]. At Max should return true and no errors
            boxModel.FlowDuration_hour = 24.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(24.0D, boxModel.FlowDuration_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0.0D] and Max [24.0D]. At Max - 1 should return true and no errors
            boxModel.FlowDuration_hour = 23.0D;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(23.0D, boxModel.FlowDuration_hour);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(count, boxModelService.GetRead().Count());
            // FlowDuration_hour has Min [0.0D] and Max [24.0D]. At Max + 1 should return false with one error
            boxModel.FlowDuration_hour = 25.0D;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFlowDuration_hour, "0", "24")).Any());
            Assert.AreEqual(25.0D, boxModel.FlowDuration_hour);
            Assert.AreEqual(count, boxModelService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // boxModel.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // boxModel.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            boxModel.LastUpdateContactTVItemID = 0;
            boxModelService.Add(boxModel);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelLastUpdateContactTVItemID, boxModel.LastUpdateContactTVItemID.ToString()), boxModel.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // boxModel.BoxModelLanguages   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // boxModel.BoxModelResults   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // boxModel.InfrastructureTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // boxModel.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
