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
            SetupTestHelper(culture);
            AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            AppTaskLanguage appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

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

            //Error: Type not implemented [Language]

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("StatusText");
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(1, appTaskLanguage.ValidationResults.Count());
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageStatusText)).Any());
            Assert.AreEqual(null, appTaskLanguage.StatusText);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("ErrorText");
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(1, appTaskLanguage.ValidationResults.Count());
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageErrorText)).Any());
            Assert.AreEqual(null, appTaskLanguage.ErrorText);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            //Error: Type not implemented [TranslationStatus]

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(1, appTaskLanguage.ValidationResults.Count());
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(appTaskLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, appTaskLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [AppTask]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [AppTaskLanguageID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [AppTaskID] of type [Int32]
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
            // doing property [StatusText] of type [String]
            //-----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            //-----------------------------------
            // doing property [ErrorText] of type [String]
            //-----------------------------------

            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [AppTask] of type [AppTask]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
