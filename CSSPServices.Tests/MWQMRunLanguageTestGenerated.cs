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
            if (OmitPropName != "LastUpdateDate_UTC") mwqmRunLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.MWQMRunLanguageID = 0;
            mwqmRunLanguageService.Update(mwqmRunLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageMWQMRunLanguageID), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "MWQMRun", Plurial = "s", FieldID = "MWQMRunID", TVType = TVTypeEnum.Error)]
            // mwqmRunLanguage.MWQMRunID   (Int32)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.MWQMRunID = 0;
            mwqmRunLanguageService.Add(mwqmRunLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MWQMRun, ModelsRes.MWQMRunLanguageMWQMRunID, mwqmRunLanguage.MWQMRunID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.Language   (LanguageEnum)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.Language = (LanguageEnum)1000000;
            mwqmRunLanguageService.Add(mwqmRunLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageLanguage), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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
            Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.TranslationStatusRunComment   (TranslationStatusEnum)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.TranslationStatusRunComment = (TranslationStatusEnum)1000000;
            mwqmRunLanguageService.Add(mwqmRunLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageTranslationStatusRunComment), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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
            Assert.AreEqual(count, mwqmRunLanguageService.GetRead().Count());


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmRunLanguage.TranslationStatusRunWeatherComment   (TranslationStatusEnum)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.TranslationStatusRunWeatherComment = (TranslationStatusEnum)1000000;
            mwqmRunLanguageService.Add(mwqmRunLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageTranslationStatusRunWeatherComment), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmRunLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // mwqmRunLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateContactTVItemID = 0;
            mwqmRunLanguageService.Add(mwqmRunLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            mwqmRunLanguage = null;
            mwqmRunLanguage = GetFilledRandomMWQMRunLanguage("");
            mwqmRunLanguage.LastUpdateContactTVItemID = 1;
            mwqmRunLanguageService.Add(mwqmRunLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, "Contact"), mwqmRunLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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
