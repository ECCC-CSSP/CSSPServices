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
    public partial class TVFileLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVFileLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVFileLanguage GetFilledRandomTVFileLanguage(string OmitPropName)
        {
            TVFileLanguageID += 1;

            TVFileLanguage tvFileLanguage = new TVFileLanguage();

            if (OmitPropName != "TVFileLanguageID") tvFileLanguage.TVFileLanguageID = TVFileLanguageID;
            if (OmitPropName != "TVFileID") tvFileLanguage.TVFileID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") tvFileLanguage.Language = language;
            if (OmitPropName != "FileDescription") tvFileLanguage.FileDescription = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") tvFileLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvFileLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvFileLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tvFileLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVFileLanguage_Testing()
        {
            SetupTestHelper(culture);
            TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            TVFileLanguage tvFileLanguage = GetFilledRandomTVFileLanguage("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, tvFileLanguageService.Add(tvFileLanguage));
            Assert.AreEqual(true, tvFileLanguageService.GetRead().Where(c => c == tvFileLanguage).Any());
            tvFileLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tvFileLanguageService.Update(tvFileLanguage));
            Assert.AreEqual(1, tvFileLanguageService.GetRead().Count());
            Assert.AreEqual(true, tvFileLanguageService.Delete(tvFileLanguage));
            Assert.AreEqual(0, tvFileLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVFileID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Language]

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("FileDescription");
            Assert.AreEqual(false, tvFileLanguageService.Add(tvFileLanguage));
            Assert.AreEqual(1, tvFileLanguage.ValidationResults.Count());
            Assert.IsTrue(tvFileLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageFileDescription)).Any());
            Assert.AreEqual(null, tvFileLanguage.FileDescription);
            Assert.AreEqual(0, tvFileLanguageService.GetRead().Count());

            //Error: Type not implemented [TranslationStatus]

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvFileLanguageService.Add(tvFileLanguage));
            Assert.AreEqual(1, tvFileLanguage.ValidationResults.Count());
            Assert.IsTrue(tvFileLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvFileLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvFileLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TVFile]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVFileLanguageID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVFileID] of type [Int32]
            //-----------------------------------

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            // TVFileID has Min [1] and Max [empty]. At Min should return true and no errors
            tvFileLanguage.TVFileID = 1;
            Assert.AreEqual(true, tvFileLanguageService.Add(tvFileLanguage));
            Assert.AreEqual(0, tvFileLanguage.ValidationResults.Count());
            Assert.AreEqual(1, tvFileLanguage.TVFileID);
            Assert.AreEqual(true, tvFileLanguageService.Delete(tvFileLanguage));
            Assert.AreEqual(0, tvFileLanguageService.GetRead().Count());
            // TVFileID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvFileLanguage.TVFileID = 2;
            Assert.AreEqual(true, tvFileLanguageService.Add(tvFileLanguage));
            Assert.AreEqual(0, tvFileLanguage.ValidationResults.Count());
            Assert.AreEqual(2, tvFileLanguage.TVFileID);
            Assert.AreEqual(true, tvFileLanguageService.Delete(tvFileLanguage));
            Assert.AreEqual(0, tvFileLanguageService.GetRead().Count());
            // TVFileID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvFileLanguage.TVFileID = 0;
            Assert.AreEqual(false, tvFileLanguageService.Add(tvFileLanguage));
            Assert.IsTrue(tvFileLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileLanguageTVFileID, "1")).Any());
            Assert.AreEqual(0, tvFileLanguage.TVFileID);
            Assert.AreEqual(0, tvFileLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [FileDescription] of type [String]
            //-----------------------------------

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            tvFileLanguage = null;
            tvFileLanguage = GetFilledRandomTVFileLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvFileLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvFileLanguageService.Add(tvFileLanguage));
            Assert.AreEqual(0, tvFileLanguage.ValidationResults.Count());
            Assert.AreEqual(1, tvFileLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvFileLanguageService.Delete(tvFileLanguage));
            Assert.AreEqual(0, tvFileLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvFileLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvFileLanguageService.Add(tvFileLanguage));
            Assert.AreEqual(0, tvFileLanguage.ValidationResults.Count());
            Assert.AreEqual(2, tvFileLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvFileLanguageService.Delete(tvFileLanguage));
            Assert.AreEqual(0, tvFileLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvFileLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvFileLanguageService.Add(tvFileLanguage));
            Assert.IsTrue(tvFileLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvFileLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tvFileLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [TVFile] of type [TVFile]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
