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
    public partial class TVItemLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVItemLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemLanguage GetFilledRandomTVItemLanguage(string OmitPropName)
        {
            TVItemLanguageID += 1;

            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            if (OmitPropName != "TVItemLanguageID") tvItemLanguage.TVItemLanguageID = TVItemLanguageID;
            if (OmitPropName != "TVItemID") tvItemLanguage.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") tvItemLanguage.Language = language;
            if (OmitPropName != "TVText") tvItemLanguage.TVText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") tvItemLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tvItemLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemLanguage_Testing()
        {
            SetupTestHelper(culture);
            TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            TVItemLanguage tvItemLanguage = GetFilledRandomTVItemLanguage("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(true, tvItemLanguageService.GetRead().Where(c => c == tvItemLanguage).Any());
            tvItemLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tvItemLanguageService.Update(tvItemLanguage));
            Assert.AreEqual(1, tvItemLanguageService.GetRead().Count());
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Language]

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("TVText");
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(1, tvItemLanguage.ValidationResults.Count());
            Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVText)).Any());
            Assert.AreEqual(null, tvItemLanguage.TVText);
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());

            //Error: Type not implemented [TranslationStatus]

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(1, tvItemLanguage.ValidationResults.Count());
            Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvItemLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVItemLanguageID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemID] of type [Int32]
            //-----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            // TVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLanguage.TVItemID = 1;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLanguage.TVItemID);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLanguage.TVItemID = 2;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLanguage.TVItemID);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLanguage.TVItemID = 0;
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLanguageTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLanguage.TVItemID);
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVText] of type [String]
            //-----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [TVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
