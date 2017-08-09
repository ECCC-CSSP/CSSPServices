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
    public partial class TVFileLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVFileLanguageService tvFileLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageServiceTest() : base()
        {
            //tvFileLanguageService = new TVFileLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVFileLanguage GetFilledRandomTVFileLanguage(string OmitPropName)
        {
            TVFileLanguage tvFileLanguage = new TVFileLanguage();

            if (OmitPropName != "TVFileID") tvFileLanguage.TVFileID = 1;
            if (OmitPropName != "Language") tvFileLanguage.Language = LanguageRequest;
            if (OmitPropName != "FileDescription") tvFileLanguage.FileDescription = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") tvFileLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvFileLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvFileLanguage.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") tvFileLanguage.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "LanguageText") tvFileLanguage.LanguageText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusText") tvFileLanguage.TranslationStatusText = GetRandomString("", 5);

            return tvFileLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVFileLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                TVFileLanguage tvFileLanguage = GetFilledRandomTVFileLanguage("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = tvFileLanguageService.GetRead().Count();

                tvFileLanguageService.Add(tvFileLanguage);
                if (tvFileLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, tvFileLanguageService.GetRead().Where(c => c == tvFileLanguage).Any());
                tvFileLanguageService.Update(tvFileLanguage);
                if (tvFileLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, tvFileLanguageService.GetRead().Count());
                tvFileLanguageService.Delete(tvFileLanguage);
                if (tvFileLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, tvFileLanguageService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // tvFileLanguage.TVFileLanguageID   (Int32)
                // -----------------------------------

                tvFileLanguage = null;
                tvFileLanguage = GetFilledRandomTVFileLanguage("");
                tvFileLanguage.TVFileLanguageID = 0;
                tvFileLanguageService.Update(tvFileLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageTVFileLanguageID), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVFile", ExistPlurial = "s", ExistFieldID = "TVFileID", AllowableTVtypeList = Error)]
                // tvFileLanguage.TVFileID   (Int32)
                // -----------------------------------

                tvFileLanguage = null;
                tvFileLanguage = GetFilledRandomTVFileLanguage("");
                tvFileLanguage.TVFileID = 0;
                tvFileLanguageService.Add(tvFileLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVFile, ModelsRes.TVFileLanguageTVFileID, tvFileLanguage.TVFileID.ToString()), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // tvFileLanguage.Language   (LanguageEnum)
                // -----------------------------------

                tvFileLanguage = null;
                tvFileLanguage = GetFilledRandomTVFileLanguage("");
                tvFileLanguage.Language = (LanguageEnum)1000000;
                tvFileLanguageService.Add(tvFileLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageLanguage), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // tvFileLanguage.FileDescription   (String)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // tvFileLanguage.TranslationStatus   (TranslationStatusEnum)
                // -----------------------------------

                tvFileLanguage = null;
                tvFileLanguage = GetFilledRandomTVFileLanguage("");
                tvFileLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                tvFileLanguageService.Add(tvFileLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageTranslationStatus), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // tvFileLanguage.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // tvFileLanguage.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                tvFileLanguage = null;
                tvFileLanguage = GetFilledRandomTVFileLanguage("");
                tvFileLanguage.LastUpdateContactTVItemID = 0;
                tvFileLanguageService.Add(tvFileLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVFileLanguageLastUpdateContactTVItemID, tvFileLanguage.LastUpdateContactTVItemID.ToString()), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                tvFileLanguage = null;
                tvFileLanguage = GetFilledRandomTVFileLanguage("");
                tvFileLanguage.LastUpdateContactTVItemID = 1;
                tvFileLanguageService.Add(tvFileLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVFileLanguageLastUpdateContactTVItemID, "Contact"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvFileLanguage.LastUpdateContactTVText   (String)
                // -----------------------------------

                tvFileLanguage = null;
                tvFileLanguage = GetFilledRandomTVFileLanguage("");
                tvFileLanguage.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvFileLanguageService.Add(tvFileLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileLanguageLastUpdateContactTVText, "200"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvFileLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // tvFileLanguage.LanguageText   (String)
                // -----------------------------------

                tvFileLanguage = null;
                tvFileLanguage = GetFilledRandomTVFileLanguage("");
                tvFileLanguage.LanguageText = GetRandomString("", 101);
                Assert.AreEqual(false, tvFileLanguageService.Add(tvFileLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileLanguageLanguageText, "100"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvFileLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // tvFileLanguage.TranslationStatusText   (String)
                // -----------------------------------

                tvFileLanguage = null;
                tvFileLanguage = GetFilledRandomTVFileLanguage("");
                tvFileLanguage.TranslationStatusText = GetRandomString("", 101);
                Assert.AreEqual(false, tvFileLanguageService.Add(tvFileLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileLanguageTranslationStatusText, "100"), tvFileLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvFileLanguageService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // tvFileLanguage.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TVFileLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVFileLanguageService tvFileLanguageService = new TVFileLanguageService(LanguageRequest, dbTestDB, ContactID);
                TVFileLanguage tvFileLanguage = (from c in tvFileLanguageService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(tvFileLanguage);

                TVFileLanguage tvFileLanguageRet = tvFileLanguageService.GetTVFileLanguageWithTVFileLanguageID(tvFileLanguage.TVFileLanguageID);
                Assert.IsNotNull(tvFileLanguageRet.TVFileLanguageID);
                Assert.IsNotNull(tvFileLanguageRet.TVFileID);
                Assert.IsNotNull(tvFileLanguageRet.Language);
                if (tvFileLanguageRet.FileDescription != null)
                {
                   Assert.IsNotNull(tvFileLanguageRet.FileDescription);
                   Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.FileDescription));
                }
                Assert.IsNotNull(tvFileLanguageRet.TranslationStatus);
                Assert.IsNotNull(tvFileLanguageRet.LastUpdateDate_UTC);
                Assert.IsNotNull(tvFileLanguageRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(tvFileLanguageRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.LastUpdateContactTVText));
                Assert.IsNotNull(tvFileLanguageRet.LanguageText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.LanguageText));
                Assert.IsNotNull(tvFileLanguageRet.TranslationStatusText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileLanguageRet.TranslationStatusText));
            }
        }
        #endregion Tests Get With Key

    }
}