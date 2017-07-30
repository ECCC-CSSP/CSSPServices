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
    public partial class TVFileLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVFileLanguageService tvFileLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageTest() : base()
        {
            tvFileLanguageService = new TVFileLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVFileLanguage GetFilledRandomTVFileLanguage(string OmitPropName)
        {
            TVFileLanguage tvFileLanguage = new TVFileLanguage();

            if (OmitPropName != "TVFileID") tvFileLanguage.TVFileID = 1;
            if (OmitPropName != "Language") tvFileLanguage.Language = language;
            if (OmitPropName != "FileDescription") tvFileLanguage.FileDescription = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") tvFileLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvFileLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvFileLanguage.LastUpdateContactTVItemID = 2;

            return tvFileLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVFileLanguage_Testing()
        {

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
            // [CSSPExist(TypeName = "TVFile", Plurial = "s", FieldID = "TVFileID", TVType = TVTypeEnum.Error)]
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
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
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
            // Is NOT Nullable
            // [IsVirtual]
            // tvFileLanguage.TVFile   (TVFile)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tvFileLanguage.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
