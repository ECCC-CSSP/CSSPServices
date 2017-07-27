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
    public partial class MWQMRunLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMRunLanguageService mwqmRunLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageTest() : base()
        {
            mwqmRunLanguageService = new MWQMRunLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMRunLanguage GetFilledRandomMWQMRunLanguage(string OmitPropName)
        {
            MWQMRunLanguage mwqmRunLanguage = new MWQMRunLanguage();

            if (OmitPropName != "MWQMRunID") mwqmRunLanguage.MWQMRunID = 1;
            if (OmitPropName != "Language") mwqmRunLanguage.Language = language;
            if (OmitPropName != "RunComment") mwqmRunLanguage.RunComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunComment") mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "RunWeatherComment") mwqmRunLanguage.RunWeatherComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusRunWeatherComment") mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRunLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmRunLanguage.LastUpdateContactTVItemID = 2;

            return mwqmRunLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMRunLanguage_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MWQMRunLanguage mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = mwqmRunLanguageService.GetRead().Count();

            mwqmRunLanguageService.Add(mwqmRunLanguage);
            if (mwqmRunLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mwqmRunLanguageService.GetRead().Where(c => c == mwqmRunLanguage).Any());
            mwqmRunLanguageService.Update(mwqmRunLanguage);
            if (mwqmRunLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mwqmRunLanguageService.GetRead().Count());
            mwqmRunLanguageService.Delete(mwqmRunLanguage);
            if (mwqmRunLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmRunLanguage.MWQMRunLanguageID   (Int32)
            // -----------------------------------

            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.MWQMRunLanguageID = 0;
            mwqmRunLanguageService.Update(mwqmRunLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageMWQMRunLanguageID), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "MWQMRun", Plurial = "s", FieldID = "MWQMRunID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // mwqmRunLanguage.MWQMRunID   (Int32)
            // -----------------------------------

            // MWQMRunID will automatically be initialized at 0 --> not null


            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            // MWQMRunID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRunLanguage.MWQMRunID = 1;
            Assert.AreEqual(true, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguage.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRunLanguage.MWQMRunID);
            Assert.AreEqual(true, mwqmRunLanguageService.Delete(mwqmRunLanguage));
            Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());
            // MWQMRunID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRunLanguage.MWQMRunID = 2;
            Assert.AreEqual(true, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguage.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRunLanguage.MWQMRunID);
            Assert.AreEqual(true, mwqmRunLanguageService.Delete(mwqmRunLanguage));
            Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());
            // MWQMRunID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRunLanguage.MWQMRunID = 0;
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLanguageMWQMRunID, "1")).Any());
            Assert.AreEqual(0, mwqmRunLanguage.MWQMRunID);
            Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.Language   (LanguageEnum)
            // -----------------------------------

            // Language will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // mwqmRunLanguage.RunComment   (String)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunComment");
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageRunComment)).Any());
            Assert.AreEqual(null, mwqmRunLanguage.RunComment);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());


            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.TranslationStatusRunComment   (TranslationStatusEnum)
            // -----------------------------------

            // TranslationStatusRunComment will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // mwqmRunLanguage.RunWeatherComment   (String)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("RunWeatherComment");
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(1, mwqmRunLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageRunWeatherComment)).Any());
            Assert.AreEqual(null, mwqmRunLanguage.RunWeatherComment);
            Assert.AreEqual(0, mwqmRunLanguageService.GetRead().Count());


            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.TranslationStatusRunWeatherComment   (TranslationStatusEnum)
            // -----------------------------------

            // TranslationStatusRunWeatherComment will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmRunLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // mwqmRunLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmRunLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguage.ValidationResults.Count());
            Assert.AreEqual(1, mwqmRunLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmRunLanguageService.Delete(mwqmRunLanguage));
            Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmRunLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.AreEqual(0, mwqmRunLanguage.ValidationResults.Count());
            Assert.AreEqual(2, mwqmRunLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmRunLanguageService.Delete(mwqmRunLanguage));
            Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmRunLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmRunLanguageService.Add(mwqmRunLanguage));
            Assert.IsTrue(mwqmRunLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmRunLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mwqmRunLanguage.MWQMRun   (MWQMRun)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mwqmRunLanguage.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
