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
    public partial class AppTaskLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int AppTaskLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTaskLanguage GetFilledRandomAppTaskLanguage(string OmitPropName)
        {
            AppTaskLanguageID += 1;

            AppTaskLanguage appTaskLanguage = new AppTaskLanguage();

            if (OmitPropName != "AppTaskLanguageID") appTaskLanguage.AppTaskLanguageID = AppTaskLanguageID;
            if (OmitPropName != "AppTaskID") appTaskLanguage.AppTaskID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") appTaskLanguage.Language = language;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return appTaskLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AppTaskLanguage_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            AppTaskLanguage appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(true, appTaskLanguageService.GetRead().Where(c => c == appTaskLanguage).Any());
            appTaskLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, appTaskLanguageService.Update(appTaskLanguage));
            Assert.AreEqual(1, appTaskLanguageService.GetRead().Count());
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // AppTaskID will automatically be initialized at 0 --> not null

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("Language");
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(1, appTaskLanguage.ValidationResults.Count());
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLanguage)).Any());
            Assert.AreEqual(LanguageEnum.Error, appTaskLanguage.Language);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("TranslationStatus");
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(1, appTaskLanguage.ValidationResults.Count());
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageTranslationStatus)).Any());
            Assert.AreEqual(TranslationStatusEnum.Error, appTaskLanguage.TranslationStatus);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(1, appTaskLanguage.ValidationResults.Count());
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(appTaskLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [AppTaskLanguageID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [AppTaskID] of type [int]
            //-----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            // AppTaskID has Min [1] and Max [empty]. At Min should return true and no errors
            appTaskLanguage.AppTaskID = 1;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(1, appTaskLanguage.AppTaskID);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());
            // AppTaskID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTaskLanguage.AppTaskID = 2;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(2, appTaskLanguage.AppTaskID);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());
            // AppTaskID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTaskLanguage.AppTaskID = 0;
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLanguageAppTaskID, "1")).Any());
            Assert.AreEqual(0, appTaskLanguage.AppTaskID);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [StatusText] of type [string]
            //-----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            // StatusText has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string appTaskLanguageStatusTextMin = GetRandomString("", 250);
            appTaskLanguage.StatusText = appTaskLanguageStatusTextMin;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(appTaskLanguageStatusTextMin, appTaskLanguage.StatusText);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            // StatusText has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            appTaskLanguageStatusTextMin = GetRandomString("", 249);
            appTaskLanguage.StatusText = appTaskLanguageStatusTextMin;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(appTaskLanguageStatusTextMin, appTaskLanguage.StatusText);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            // StatusText has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            appTaskLanguageStatusTextMin = GetRandomString("", 251);
            appTaskLanguage.StatusText = appTaskLanguageStatusTextMin;
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageStatusText, "250")).Any());
            Assert.AreEqual(appTaskLanguageStatusTextMin, appTaskLanguage.StatusText);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [ErrorText] of type [string]
            //-----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            // ErrorText has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string appTaskLanguageErrorTextMin = GetRandomString("", 250);
            appTaskLanguage.ErrorText = appTaskLanguageErrorTextMin;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(appTaskLanguageErrorTextMin, appTaskLanguage.ErrorText);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            // ErrorText has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            appTaskLanguageErrorTextMin = GetRandomString("", 249);
            appTaskLanguage.ErrorText = appTaskLanguageErrorTextMin;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(appTaskLanguageErrorTextMin, appTaskLanguage.ErrorText);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            // ErrorText has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            appTaskLanguageErrorTextMin = GetRandomString("", 251);
            appTaskLanguage.ErrorText = appTaskLanguageErrorTextMin;
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageErrorText, "250")).Any());
            Assert.AreEqual(appTaskLanguageErrorTextMin, appTaskLanguage.ErrorText);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            appTaskLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(1, appTaskLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTaskLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(2, appTaskLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTaskLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, appTaskLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
