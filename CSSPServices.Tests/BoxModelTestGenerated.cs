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
            if (OmitPropName != "Flow_m3_day") boxModel.Flow_m3_day = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Depth_m") boxModel.Depth_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Temperature_C") boxModel.Temperature_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Dilution") boxModel.Dilution = GetRandomInt(0, 10000000);
            if (OmitPropName != "DecayRate_per_day") boxModel.DecayRate_per_day = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "FCUntreated_MPN_100ml") boxModel.FCUntreated_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "FCPreDisinfection_MPN_100ml") boxModel.FCPreDisinfection_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Concentration_MPN_100ml") boxModel.Concentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "T90_hour") boxModel.T90_hour = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "FlowDuration_hour") boxModel.FlowDuration_hour = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") boxModel.LastUpdateDate_UTC = GetRandomDateTime();
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
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // InfrastructureTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Flow_m3_day]

            //Error: Type not implemented [Depth_m]

            //Error: Type not implemented [Temperature_C]

            // Dilution will automatically be initialized at 0 --> not null

            //Error: Type not implemented [DecayRate_per_day]

            // FCUntreated_MPN_100ml will automatically be initialized at 0 --> not null

            // FCPreDisinfection_MPN_100ml will automatically be initialized at 0 --> not null

            // Concentration_MPN_100ml will automatically be initialized at 0 --> not null

            //Error: Type not implemented [T90_hour]

            //Error: Type not implemented [FlowDuration_hour]

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("LastUpdateDate_UTC");
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.AreEqual(1, boxModel.ValidationResults.Count());
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLastUpdateDate_UTC)).Any());
            Assert.IsTrue(boxModel.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [BoxModelLanguages]

            //Error: Type not implemented [BoxModelResults]

            //Error: Type not implemented [InfrastructureTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [BoxModelID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItemID] of type [Int32]
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
            // doing property [Flow_m3_day] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Depth_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Temperature_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Dilution] of type [Int32]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Dilution has Min [0] and Max [10000000]. At Min should return true and no errors
            boxModel.Dilution = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            boxModel.Dilution = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            boxModel.Dilution = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDilution, "0", "10000000")).Any());
            Assert.AreEqual(-1, boxModel.Dilution);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Max should return true and no errors
            boxModel.Dilution = 10000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000000, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            boxModel.Dilution = 9999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999999, boxModel.Dilution);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Dilution has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            boxModel.Dilution = 10000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelDilution, "0", "10000000")).Any());
            Assert.AreEqual(10000001, boxModel.Dilution);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [DecayRate_per_day] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [FCUntreated_MPN_100ml] of type [Int32]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            boxModel.FCUntreated_MPN_100ml = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 10000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000000, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            boxModel.FCUntreated_MPN_100ml = 9999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999999, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCUntreated_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            boxModel.FCUntreated_MPN_100ml = 10000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCUntreated_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, boxModel.FCUntreated_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [FCPreDisinfection_MPN_100ml] of type [Int32]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            boxModel.FCPreDisinfection_MPN_100ml = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 10000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000000, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            boxModel.FCPreDisinfection_MPN_100ml = 9999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999999, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // FCPreDisinfection_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            boxModel.FCPreDisinfection_MPN_100ml = 10000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelFCPreDisinfection_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, boxModel.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [Concentration_MPN_100ml] of type [Int32]
            //-----------------------------------

            boxModel = null;
            boxModel = GetFilledRandomBoxModel("");
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min should return true and no errors
            boxModel.Concentration_MPN_100ml = 0;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(0, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            boxModel.Concentration_MPN_100ml = 1;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(1, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            boxModel.Concentration_MPN_100ml = -1;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(-1, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max should return true and no errors
            boxModel.Concentration_MPN_100ml = 10000000;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(10000000, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            boxModel.Concentration_MPN_100ml = 9999999;
            Assert.AreEqual(true, boxModelService.Add(boxModel));
            Assert.AreEqual(0, boxModel.ValidationResults.Count());
            Assert.AreEqual(9999999, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(true, boxModelService.Delete(boxModel));
            Assert.AreEqual(0, boxModelService.GetRead().Count());
            // Concentration_MPN_100ml has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            boxModel.Concentration_MPN_100ml = 10000001;
            Assert.AreEqual(false, boxModelService.Add(boxModel));
            Assert.IsTrue(boxModel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelConcentration_MPN_100ml, "0", "10000000")).Any());
            Assert.AreEqual(10000001, boxModel.Concentration_MPN_100ml);
            Assert.AreEqual(0, boxModelService.GetRead().Count());

            //-----------------------------------
            // doing property [T90_hour] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [FlowDuration_hour] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [BoxModelLanguages] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [BoxModelResults] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
