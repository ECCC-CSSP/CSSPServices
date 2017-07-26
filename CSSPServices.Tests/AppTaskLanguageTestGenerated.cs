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
        private AppTaskLanguageService appTaskLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageTest() : base()
        {
            appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTaskLanguage GetFilledRandomAppTaskLanguage(string OmitPropName)
        {
            AppTaskLanguage appTaskLanguage = new AppTaskLanguage();

            if (OmitPropName != "AppTaskID") appTaskLanguage.AppTaskID = 0;
            if (OmitPropName != "Language") appTaskLanguage.Language = language;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = 2;

            return appTaskLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AppTaskLanguage_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            AppTaskLanguage appTaskLanguage = GetFilledRandomAppTaskLanguage("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = appTaskLanguageService.GetRead().Count();

            appTaskLanguageService.Add(appTaskLanguage);
            if (appTaskLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, appTaskLanguageService.GetRead().Where(c => c == appTaskLanguage).Any());
            appTaskLanguageService.Update(appTaskLanguage);
            if (appTaskLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, appTaskLanguageService.GetRead().Count());
            appTaskLanguageService.Delete(appTaskLanguage);
            if (appTaskLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // appTaskLanguage.AppTaskLanguageID   (Int32)
            //-----------------------------------
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            appTaskLanguage.AppTaskLanguageID = 0;
            appTaskLanguageService.Update(appTaskLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageAppTaskLanguageID), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "AppTask", Plurial = "s", FieldID = "AppTaskID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // appTaskLanguage.AppTaskID   (Int32)
            //-----------------------------------
            // AppTaskID will automatically be initialized at 0 --> not null


            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            // AppTaskID has Min [1] and Max [empty]. At Min should return true and no errors
            appTaskLanguage.AppTaskID = 1;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(1, appTaskLanguage.AppTaskID);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());
            // AppTaskID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTaskLanguage.AppTaskID = 2;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(2, appTaskLanguage.AppTaskID);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());
            // AppTaskID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTaskLanguage.AppTaskID = 0;
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLanguageAppTaskID, "1")).Any());
            Assert.AreEqual(0, appTaskLanguage.AppTaskID);
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // appTaskLanguage.Language   (LanguageEnum)
            //-----------------------------------
            // Language will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is Nullable
            //[StringLength(250))]
            // appTaskLanguage.StatusText   (String)
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
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

            // StatusText has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            appTaskLanguageStatusTextMin = GetRandomString("", 249);
            appTaskLanguage.StatusText = appTaskLanguageStatusTextMin;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(appTaskLanguageStatusTextMin, appTaskLanguage.StatusText);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

            // StatusText has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            appTaskLanguageStatusTextMin = GetRandomString("", 251);
            appTaskLanguage.StatusText = appTaskLanguageStatusTextMin;
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageStatusText, "250")).Any());
            Assert.AreEqual(appTaskLanguageStatusTextMin, appTaskLanguage.StatusText);
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[StringLength(250))]
            // appTaskLanguage.ErrorText   (String)
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
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

            // ErrorText has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            appTaskLanguageErrorTextMin = GetRandomString("", 249);
            appTaskLanguage.ErrorText = appTaskLanguageErrorTextMin;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(appTaskLanguageErrorTextMin, appTaskLanguage.ErrorText);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

            // ErrorText has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            appTaskLanguageErrorTextMin = GetRandomString("", 251);
            appTaskLanguage.ErrorText = appTaskLanguageErrorTextMin;
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageErrorText, "250")).Any());
            Assert.AreEqual(appTaskLanguageErrorTextMin, appTaskLanguage.ErrorText);
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // appTaskLanguage.TranslationStatus   (TranslationStatusEnum)
            //-----------------------------------
            // TranslationStatus will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // appTaskLanguage.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // appTaskLanguage.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            appTaskLanguage = null;
            appTaskLanguage = GetFilledRandomAppTaskLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            appTaskLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(1, appTaskLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTaskLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, appTaskLanguageService.Add(appTaskLanguage));
            Assert.AreEqual(0, appTaskLanguage.ValidationResults.Count());
            Assert.AreEqual(2, appTaskLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appTaskLanguageService.Delete(appTaskLanguage));
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTaskLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
            Assert.IsTrue(appTaskLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, appTaskLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // appTaskLanguage.AppTask   (AppTask)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // appTaskLanguage.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
