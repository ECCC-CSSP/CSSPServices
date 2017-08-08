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
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class AppTaskLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AppTaskLanguageService appTaskLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageServiceTest() : base()
        {
            //appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTaskLanguage GetFilledRandomAppTaskLanguage(string OmitPropName)
        {
            AppTaskLanguage appTaskLanguage = new AppTaskLanguage();

            if (OmitPropName != "AppTaskID") appTaskLanguage.AppTaskID = 1;
            if (OmitPropName != "Language") appTaskLanguage.Language = LanguageRequest;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") appTaskLanguage.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "LanguageText") appTaskLanguage.LanguageText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusText") appTaskLanguage.TranslationStatusText = GetRandomString("", 5);

            return appTaskLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AppTaskLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, dbTestDB, ContactID);

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


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // appTaskLanguage.AppTaskLanguageID   (Int32)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.AppTaskLanguageID = 0;
                appTaskLanguageService.Update(appTaskLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageAppTaskLanguageID), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID", AllowableTVtypeList = Error)]
                // appTaskLanguage.AppTaskID   (Int32)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.AppTaskID = 0;
                appTaskLanguageService.Add(appTaskLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.AppTask, ModelsRes.AppTaskLanguageAppTaskID, appTaskLanguage.AppTaskID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // appTaskLanguage.Language   (LanguageEnum)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.Language = (LanguageEnum)1000000;
                appTaskLanguageService.Add(appTaskLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLanguage), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [StringLength(250))]
                // appTaskLanguage.StatusText   (String)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.StatusText = GetRandomString("", 251);
                Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageStatusText, "250"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [StringLength(250))]
                // appTaskLanguage.ErrorText   (String)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.ErrorText = GetRandomString("", 251);
                Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageErrorText, "250"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // appTaskLanguage.TranslationStatus   (TranslationStatusEnum)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                appTaskLanguageService.Add(appTaskLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageTranslationStatus), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // appTaskLanguage.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // appTaskLanguage.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.LastUpdateContactTVItemID = 0;
                appTaskLanguageService.Add(appTaskLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskLanguageLastUpdateContactTVItemID, appTaskLanguage.LastUpdateContactTVItemID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.LastUpdateContactTVItemID = 1;
                appTaskLanguageService.Add(appTaskLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppTaskLanguageLastUpdateContactTVItemID, "Contact"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // appTaskLanguage.LastUpdateContactTVText   (String)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageLastUpdateContactTVText, "200"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // appTaskLanguage.LanguageText   (String)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.LanguageText = GetRandomString("", 101);
                Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageLanguageText, "100"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // appTaskLanguage.TranslationStatusText   (String)
                // -----------------------------------

                appTaskLanguage = null;
                appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                appTaskLanguage.TranslationStatusText = GetRandomString("", 101);
                Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageTranslationStatusText, "100"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // appTaskLanguage.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void AppTaskLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, dbTestDB, ContactID);
                AppTaskLanguage appTaskLanguage = (from c in appTaskLanguageService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(appTaskLanguage);

                AppTaskLanguage appTaskLanguageRet = appTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID);
                Assert.AreEqual(appTaskLanguage.AppTaskLanguageID, appTaskLanguageRet.AppTaskLanguageID);
                Assert.AreEqual(appTaskLanguage.AppTaskID, appTaskLanguageRet.AppTaskID);
                Assert.AreEqual(appTaskLanguage.Language, appTaskLanguageRet.Language);
                Assert.AreEqual(appTaskLanguage.StatusText, appTaskLanguageRet.StatusText);
                Assert.AreEqual(appTaskLanguage.ErrorText, appTaskLanguageRet.ErrorText);
                Assert.AreEqual(appTaskLanguage.TranslationStatus, appTaskLanguageRet.TranslationStatus);
                Assert.AreEqual(appTaskLanguage.LastUpdateDate_UTC, appTaskLanguageRet.LastUpdateDate_UTC);
                Assert.AreEqual(appTaskLanguage.LastUpdateContactTVItemID, appTaskLanguageRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(appTaskLanguageRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.LastUpdateContactTVText));
                Assert.IsNotNull(appTaskLanguageRet.LanguageText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.LanguageText));
                Assert.IsNotNull(appTaskLanguageRet.TranslationStatusText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.TranslationStatusText));
            }
        }
        #endregion Tests Get With Key

    }
}
