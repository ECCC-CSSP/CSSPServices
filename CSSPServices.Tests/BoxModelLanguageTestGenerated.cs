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
    public partial class BoxModelLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int BoxModelLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModelLanguage GetFilledRandomBoxModelLanguage(string OmitPropName)
        {
            BoxModelLanguageID += 1;

            BoxModelLanguage boxModelLanguage = new BoxModelLanguage();

            if (OmitPropName != "BoxModelLanguageID") boxModelLanguage.BoxModelLanguageID = BoxModelLanguageID;
            if (OmitPropName != "BoxModelID") boxModelLanguage.BoxModelID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") boxModelLanguage.Language = language;
            if (OmitPropName != "ScenarioName") boxModelLanguage.ScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") boxModelLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") boxModelLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return boxModelLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void BoxModelLanguage_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            BoxModelLanguage boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(true, boxModelLanguageService.GetRead().Where(c => c == boxModelLanguage).Any());
            boxModelLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, boxModelLanguageService.Update(boxModelLanguage));
            Assert.AreEqual(1, boxModelLanguageService.GetRead().Count());
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // BoxModelID will automatically be initialized at 0 --> not null

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("Language");
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(1, boxModelLanguage.ValidationResults.Count());
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageLanguage)).Any());
            Assert.AreEqual(LanguageEnum.Error, boxModelLanguage.Language);
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("ScenarioName");
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(1, boxModelLanguage.ValidationResults.Count());
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageScenarioName)).Any());
            Assert.AreEqual(null, boxModelLanguage.ScenarioName);
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("TranslationStatus");
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(1, boxModelLanguage.ValidationResults.Count());
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageTranslationStatus)).Any());
            Assert.AreEqual(TranslationStatusEnum.Error, boxModelLanguage.TranslationStatus);
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(1, boxModelLanguage.ValidationResults.Count());
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(boxModelLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [BoxModelLanguageID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [BoxModelID] of type [int]
            //-----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            // BoxModelID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModelLanguage.BoxModelID = 1;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(1, boxModelLanguage.BoxModelID);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());
            // BoxModelID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModelLanguage.BoxModelID = 2;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(2, boxModelLanguage.BoxModelID);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());
            // BoxModelID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModelLanguage.BoxModelID = 0;
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelLanguageBoxModelID, "1")).Any());
            Assert.AreEqual(0, boxModelLanguage.BoxModelID);
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [ScenarioName] of type [string]
            //-----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");

            // ScenarioName has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string boxModelLanguageScenarioNameMin = GetRandomString("", 250);
            boxModelLanguage.ScenarioName = boxModelLanguageScenarioNameMin;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(boxModelLanguageScenarioNameMin, boxModelLanguage.ScenarioName);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

            // ScenarioName has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            boxModelLanguageScenarioNameMin = GetRandomString("", 249);
            boxModelLanguage.ScenarioName = boxModelLanguageScenarioNameMin;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(boxModelLanguageScenarioNameMin, boxModelLanguage.ScenarioName);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

            // ScenarioName has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            boxModelLanguageScenarioNameMin = GetRandomString("", 251);
            boxModelLanguage.ScenarioName = boxModelLanguageScenarioNameMin;
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelLanguageScenarioName, "250")).Any());
            Assert.AreEqual(boxModelLanguageScenarioNameMin, boxModelLanguage.ScenarioName);
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModelLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(1, boxModelLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModelLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(2, boxModelLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModelLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, boxModelLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
