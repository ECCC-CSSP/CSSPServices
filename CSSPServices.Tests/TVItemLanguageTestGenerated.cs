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
    public partial class TVItemLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemLanguageService tvItemLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageTest() : base()
        {
            tvItemLanguageService = new TVItemLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemLanguage GetFilledRandomTVItemLanguage(string OmitPropName)
        {
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            if (OmitPropName != "TVItemID") tvItemLanguage.TVItemID = 2;
            if (OmitPropName != "Language") tvItemLanguage.Language = language;
            if (OmitPropName != "TVText") tvItemLanguage.TVText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") tvItemLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLanguage.LastUpdateContactTVItemID = 2;

            return tvItemLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemLanguage_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVItemLanguage tvItemLanguage = GetFilledRandomTVItemLanguage("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tvItemLanguageService.GetRead().Count();

            tvItemLanguageService.Add(tvItemLanguage);
            if (tvItemLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tvItemLanguageService.GetRead().Where(c => c == tvItemLanguage).Any());
            tvItemLanguageService.Update(tvItemLanguage);
            if (tvItemLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tvItemLanguageService.GetRead().Count());
            tvItemLanguageService.Delete(tvItemLanguage);
            if (tvItemLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvItemLanguage.TVItemLanguageID   (Int32)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TVItemLanguageID = 0;
            tvItemLanguageService.Update(tvItemLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVItemLanguageID), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // tvItemLanguage.TVItemID   (Int32)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TVItemID = 0;
            tvItemLanguageService.Add(tvItemLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLanguageTVItemID, tvItemLanguage.TVItemID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemLanguage.Language   (LanguageEnum)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.Language = (LanguageEnum)1000000;
            tvItemLanguageService.Add(tvItemLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageLanguage), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(200))]
            // tvItemLanguage.TVText   (String)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("TVText");
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(1, tvItemLanguage.ValidationResults.Count());
            Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVText)).Any());
            Assert.AreEqual(null, tvItemLanguage.TVText);
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TVText = GetRandomString("", 201);
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageTVText, "200"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            tvItemLanguageService.Add(tvItemLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTranslationStatus), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tvItemLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.LastUpdateContactTVItemID = 0;
            tvItemLanguageService.Add(tvItemLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, tvItemLanguage.LastUpdateContactTVItemID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.LastUpdateContactTVItemID = 1;
            tvItemLanguageService.Add(tvItemLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, "Contact"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItemLanguage.TVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tvItemLanguage.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
