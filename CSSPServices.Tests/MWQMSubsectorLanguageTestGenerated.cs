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
    public partial class MWQMSubsectorLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMSubsectorLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSubsectorLanguage GetFilledRandomMWQMSubsectorLanguage(string OmitPropName)
        {
            MWQMSubsectorLanguageID += 1;

            MWQMSubsectorLanguage mwqmSubsectorLanguage = new MWQMSubsectorLanguage();

            if (OmitPropName != "MWQMSubsectorLanguageID") mwqmSubsectorLanguage.MWQMSubsectorLanguageID = MWQMSubsectorLanguageID;
            if (OmitPropName != "MWQMSubsectorID") mwqmSubsectorLanguage.MWQMSubsectorID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") mwqmSubsectorLanguage.Language = language;
            if (OmitPropName != "SubsectorDesc") mwqmSubsectorLanguage.SubsectorDesc = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") mwqmSubsectorLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsectorLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsectorLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mwqmSubsectorLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSubsectorLanguage_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            MWQMSubsectorLanguageService mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MWQMSubsectorLanguage mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(true, mwqmSubsectorLanguageService.GetRead().Where(c => c == mwqmSubsectorLanguage).Any());
            mwqmSubsectorLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage));
            Assert.AreEqual(1, mwqmSubsectorLanguageService.GetRead().Count());
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MWQMSubsectorID will automatically be initialized at 0 --> not null

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("Language");
            Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(1, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageLanguage)).Any());
            Assert.AreEqual(LanguageEnum.Error, mwqmSubsectorLanguage.Language);
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("SubsectorDesc");
            Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(1, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageSubsectorDesc)).Any());
            Assert.AreEqual(null, mwqmSubsectorLanguage.SubsectorDesc);
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("TranslationStatus");
            Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(1, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageTranslationStatus)).Any());
            Assert.AreEqual(TranslationStatusEnum.Error, mwqmSubsectorLanguage.TranslationStatus);
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(1, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmSubsectorLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMSubsectorLanguageID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSubsectorID] of type [int]
            //-----------------------------------

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            // MWQMSubsectorID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSubsectorLanguage.MWQMSubsectorID = 1;
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsectorLanguage.MWQMSubsectorID);
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());
            // MWQMSubsectorID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSubsectorLanguage.MWQMSubsectorID = 2;
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSubsectorLanguage.MWQMSubsectorID);
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());
            // MWQMSubsectorID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSubsectorLanguage.MWQMSubsectorID = 0;
            Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorLanguageMWQMSubsectorID, "1")).Any());
            Assert.AreEqual(0, mwqmSubsectorLanguage.MWQMSubsectorID);
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [SubsectorDesc] of type [string]
            //-----------------------------------

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");

            // SubsectorDesc has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string mwqmSubsectorLanguageSubsectorDescMin = GetRandomString("", 250);
            mwqmSubsectorLanguage.SubsectorDesc = mwqmSubsectorLanguageSubsectorDescMin;
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorLanguageSubsectorDescMin, mwqmSubsectorLanguage.SubsectorDesc);
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

            // SubsectorDesc has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            mwqmSubsectorLanguageSubsectorDescMin = GetRandomString("", 249);
            mwqmSubsectorLanguage.SubsectorDesc = mwqmSubsectorLanguageSubsectorDescMin;
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorLanguageSubsectorDescMin, mwqmSubsectorLanguage.SubsectorDesc);
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

            // SubsectorDesc has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            mwqmSubsectorLanguageSubsectorDescMin = GetRandomString("", 251);
            mwqmSubsectorLanguage.SubsectorDesc = mwqmSubsectorLanguageSubsectorDescMin;
            Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorLanguageSubsectorDesc, "250")).Any());
            Assert.AreEqual(mwqmSubsectorLanguageSubsectorDescMin, mwqmSubsectorLanguage.SubsectorDesc);
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSubsectorLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsectorLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSubsectorLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSubsectorLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage));
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSubsectorLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSubsectorLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mwqmSubsectorLanguageService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
