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
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLanguage.LastUpdateDate_UTC = GetRandomDateTime();
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


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // tvItemLanguage.TVItemLanguageID   (Int32)
            //-----------------------------------
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            tvItemLanguage.TVItemLanguageID = 0;
            tvItemLanguageService.Update(tvItemLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVItemLanguageID), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // tvItemLanguage.TVItemID   (Int32)
            //-----------------------------------
            // TVItemID will automatically be initialized at 0 --> not null


            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            // TVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLanguage.TVItemID = 1;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLanguage.TVItemID);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLanguage.TVItemID = 2;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLanguage.TVItemID);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLanguage.TVItemID = 0;
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLanguageTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLanguage.TVItemID);
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // tvItemLanguage.Language   (LanguageEnum)
            //-----------------------------------
            // Language will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(200))]
            // tvItemLanguage.TVText   (String)
            //-----------------------------------
            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("TVText");
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(1, tvItemLanguage.ValidationResults.Count());
            Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVText)).Any());
            Assert.AreEqual(null, tvItemLanguage.TVText);
            Assert.AreEqual(0, tvItemLanguageService.GetRead().Count());


            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");

            // TVText has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string tvItemLanguageTVTextMin = GetRandomString("", 200);
            tvItemLanguage.TVText = tvItemLanguageTVTextMin;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(tvItemLanguageTVTextMin, tvItemLanguage.TVText);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

            // TVText has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            tvItemLanguageTVTextMin = GetRandomString("", 199);
            tvItemLanguage.TVText = tvItemLanguageTVTextMin;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(tvItemLanguageTVTextMin, tvItemLanguage.TVText);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

            // TVText has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            tvItemLanguageTVTextMin = GetRandomString("", 201);
            tvItemLanguage.TVText = tvItemLanguageTVTextMin;
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageTVText, "200")).Any());
            Assert.AreEqual(tvItemLanguageTVTextMin, tvItemLanguage.TVText);
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // tvItemLanguage.TranslationStatus   (TranslationStatusEnum)
            //-----------------------------------
            // TranslationStatus will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // tvItemLanguage.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // tvItemLanguage.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            tvItemLanguage = null;
            tvItemLanguage = GetFilledRandomTVItemLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemLanguageService.Add(tvItemLanguage));
            Assert.AreEqual(0, tvItemLanguage.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemLanguageService.Delete(tvItemLanguage));
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
            Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // tvItemLanguage.TVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // tvItemLanguage.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
