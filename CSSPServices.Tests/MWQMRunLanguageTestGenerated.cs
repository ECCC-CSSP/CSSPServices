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
    public partial class MWQMRunLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMRunLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMRunLanguage GetFilledRandomMWQMRunLanguage(string OmitPropName)
        {
            MWQMRunLanguageID += 1;

            MWQMRunLanguage mwqmRunLanguage = new MWQMRunLanguage();

            if (OmitPropName != "MWQMRunLanguageID") mwqmRunLanguage.MWQMRunLanguageID = MWQMRunLanguageID;
            if (OmitPropName != "MWQMRunID") mwqmRunLanguage.MWQMRunID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") mwqmRunLanguage.Language = language;
            if (OmitPropName != "RunComment") mwqmRunLanguage.RunComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunComment") mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "RunWeatherComment") mwqmRunLanguage.RunWeatherComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunWeatherComment") mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRunLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRunLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mwqmRunLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMRunLanguage_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            MWQMRunLanguageService mwqmRunLanguageService = new MWQMRunLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MWQMRunLanguage mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            Assert.AreEqual(true, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(true, mwqmRunLanguageService.GetRead().Where(c => c == mwqmRunLanguage).Any());
            mwqmRunLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mwqmRunLanguageService.Update(mwqmRunLanguage));
            Assert.AreEqual(1, mwqmRunLanguageService.GetRead().Count());
            Assert.AreEqual(true, mwqmRunLanguageService.Delete(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MWQMRunID will automatically be initialized at 0 --> not null

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("Language");
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageLanguage)).Any());
            Assert.AreEqual(LanguageEnum.Error, mwqmRunLanguage.Language);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunComment");
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageRunComment)).Any());
            Assert.AreEqual(null, mwqmRunLanguage.RunComment);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("TranslationStatusRunComment");
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageTranslationStatusRunComment)).Any());
            Assert.AreEqual(TranslationStatusEnum.Error, mwqmRunLanguage.TranslationStatusRunComment);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunWeatherComment");
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageRunWeatherComment)).Any());
            Assert.AreEqual(null, mwqmRunLanguage.RunWeatherComment);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("TranslationStatusRunWeatherComment");
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageTranslationStatusRunWeatherComment)).Any());
            Assert.AreEqual(TranslationStatusEnum.Error, mwqmRunLanguage.TranslationStatusRunWeatherComment);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmRunLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMRunLanguageID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMRunID] of type [int]
            //-----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            // MWQMRunID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRunLanguage.MWQMRunID = 1;
            Assert.AreEqual(true, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguage.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRunLanguage.MWQMRunID);
            Assert.AreEqual(true, mwqmRunLanguageService.Delete(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());
            // MWQMRunID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRunLanguage.MWQMRunID = 2;
            Assert.AreEqual(true, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguage.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRunLanguage.MWQMRunID);
            Assert.AreEqual(true, mwqmRunLanguageService.Delete(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());
            // MWQMRunID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRunLanguage.MWQMRunID = 0;
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLanguageMWQMRunID, "1")).Any());
            Assert.AreEqual(0, mwqmRunLanguage.MWQMRunID);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [RunComment] of type [string]
            //-----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

            //-----------------------------------
            // doing property [TranslationStatusRunComment] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [RunWeatherComment] of type [string]
            //-----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

            //-----------------------------------
            // doing property [TranslationStatusRunWeatherComment] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRunLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguage.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRunLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmRunLanguageService.Delete(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRunLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguage.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRunLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmRunLanguageService.Delete(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRunLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRunLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
