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
    public partial class SpillLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int SpillLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SpillLanguage GetFilledRandomSpillLanguage(string OmitPropName)
        {
            SpillLanguageID += 1;

            SpillLanguage spillLanguage = new SpillLanguage();

            if (OmitPropName != "SpillLanguageID") spillLanguage.SpillLanguageID = SpillLanguageID;
            if (OmitPropName != "SpillID") spillLanguage.SpillID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") spillLanguage.Language = language;
            if (OmitPropName != "SpillComment") spillLanguage.SpillComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") spillLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") spillLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") spillLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return spillLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SpillLanguage_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            SpillLanguageService spillLanguageService = new SpillLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            SpillLanguage spillLanguage = GetFilledRandomSpillLanguage("");
            Assert.AreEqual(true, spillLanguageService.Add(spillLanguage));
            Assert.AreEqual(true, spillLanguageService.GetRead().Where(c => c == spillLanguage).Any());
            spillLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, spillLanguageService.Update(spillLanguage));
            Assert.AreEqual(1, spillLanguageService.GetRead().Count());
            Assert.AreEqual(true, spillLanguageService.Delete(spillLanguage));
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // SpillID will automatically be initialized at 0 --> not null

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("Language");
            Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
            Assert.AreEqual(1, spillLanguage.ValidationResults.Count());
            Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageLanguage)).Any());
            Assert.AreEqual(LanguageEnum.Error, spillLanguage.Language);
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("SpillComment");
            Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
            Assert.AreEqual(1, spillLanguage.ValidationResults.Count());
            Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageSpillComment)).Any());
            Assert.AreEqual(null, spillLanguage.SpillComment);
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("TranslationStatus");
            Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
            Assert.AreEqual(1, spillLanguage.ValidationResults.Count());
            Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageTranslationStatus)).Any());
            Assert.AreEqual(TranslationStatusEnum.Error, spillLanguage.TranslationStatus);
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
            Assert.AreEqual(1, spillLanguage.ValidationResults.Count());
            Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(spillLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [SpillLanguageID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [SpillID] of type [int]
            //-----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            // SpillID has Min [1] and Max [empty]. At Min should return true and no errors
            spillLanguage.SpillID = 1;
            Assert.AreEqual(true, spillLanguageService.Add(spillLanguage));
            Assert.AreEqual(0, spillLanguage.ValidationResults.Count());
            Assert.AreEqual(1, spillLanguage.SpillID);
            Assert.AreEqual(true, spillLanguageService.Delete(spillLanguage));
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());
            // SpillID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            spillLanguage.SpillID = 2;
            Assert.AreEqual(true, spillLanguageService.Add(spillLanguage));
            Assert.AreEqual(0, spillLanguage.ValidationResults.Count());
            Assert.AreEqual(2, spillLanguage.SpillID);
            Assert.AreEqual(true, spillLanguageService.Delete(spillLanguage));
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());
            // SpillID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            spillLanguage.SpillID = 0;
            Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
            Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillLanguageSpillID, "1")).Any());
            Assert.AreEqual(0, spillLanguage.SpillID);
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [SpillComment] of type [string]
            //-----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            spillLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, spillLanguageService.Add(spillLanguage));
            Assert.AreEqual(0, spillLanguage.ValidationResults.Count());
            Assert.AreEqual(1, spillLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, spillLanguageService.Delete(spillLanguage));
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            spillLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, spillLanguageService.Add(spillLanguage));
            Assert.AreEqual(0, spillLanguage.ValidationResults.Count());
            Assert.AreEqual(2, spillLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, spillLanguageService.Delete(spillLanguage));
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            spillLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
            Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, spillLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
