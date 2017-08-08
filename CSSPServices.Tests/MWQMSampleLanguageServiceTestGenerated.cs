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
    public partial class MWQMSampleLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSampleLanguageService mwqmSampleLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageServiceTest() : base()
        {
            //mwqmSampleLanguageService = new MWQMSampleLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSampleLanguage GetFilledRandomMWQMSampleLanguage(string OmitPropName)
        {
            MWQMSampleLanguage mwqmSampleLanguage = new MWQMSampleLanguage();

            if (OmitPropName != "MWQMSampleID") mwqmSampleLanguage.MWQMSampleID = 1;
            if (OmitPropName != "Language") mwqmSampleLanguage.Language = LanguageRequest;
            if (OmitPropName != "MWQMSampleNote") mwqmSampleLanguage.MWQMSampleNote = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") mwqmSampleLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSampleLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSampleLanguage.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") mwqmSampleLanguage.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "LanguageText") mwqmSampleLanguage.LanguageText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusText") mwqmSampleLanguage.TranslationStatusText = GetRandomString("", 5);

            return mwqmSampleLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSampleLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                MWQMSampleLanguage mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = mwqmSampleLanguageService.GetRead().Count();

                mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                if (mwqmSampleLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, mwqmSampleLanguageService.GetRead().Where(c => c == mwqmSampleLanguage).Any());
                mwqmSampleLanguageService.Update(mwqmSampleLanguage);
                if (mwqmSampleLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, mwqmSampleLanguageService.GetRead().Count());
                mwqmSampleLanguageService.Delete(mwqmSampleLanguage);
                if (mwqmSampleLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, mwqmSampleLanguageService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // mwqmSampleLanguage.MWQMSampleLanguageID   (Int32)
                // -----------------------------------

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                mwqmSampleLanguage.MWQMSampleLanguageID = 0;
                mwqmSampleLanguageService.Update(mwqmSampleLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageMWQMSampleLanguageID), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "MWQMSample", Plurial = "s", FieldID = "MWQMSampleID", AllowableTVtypeList = Error)]
                // mwqmSampleLanguage.MWQMSampleID   (Int32)
                // -----------------------------------

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                mwqmSampleLanguage.MWQMSampleID = 0;
                mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MWQMSample, ModelsRes.MWQMSampleLanguageMWQMSampleID, mwqmSampleLanguage.MWQMSampleID.ToString()), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // mwqmSampleLanguage.Language   (LanguageEnum)
                // -----------------------------------

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                mwqmSampleLanguage.Language = (LanguageEnum)1000000;
                mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageLanguage), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // mwqmSampleLanguage.MWQMSampleNote   (String)
                // -----------------------------------

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("MWQMSampleNote");
                Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
                Assert.AreEqual(1, mwqmSampleLanguage.ValidationResults.Count());
                Assert.IsTrue(mwqmSampleLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageMWQMSampleNote)).Any());
                Assert.AreEqual(null, mwqmSampleLanguage.MWQMSampleNote);
                Assert.AreEqual(count, mwqmSampleLanguageService.GetRead().Count());


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // mwqmSampleLanguage.TranslationStatus   (TranslationStatusEnum)
                // -----------------------------------

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                mwqmSampleLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageTranslationStatus), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSampleLanguage.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // mwqmSampleLanguage.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                mwqmSampleLanguage.LastUpdateContactTVItemID = 0;
                mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID, mwqmSampleLanguage.LastUpdateContactTVItemID.ToString()), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                mwqmSampleLanguage.LastUpdateContactTVItemID = 1;
                mwqmSampleLanguageService.Add(mwqmSampleLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID, "Contact"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // mwqmSampleLanguage.LastUpdateContactTVText   (String)
                // -----------------------------------

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                mwqmSampleLanguage.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleLanguageLastUpdateContactTVText, "200"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmSampleLanguage.LanguageText   (String)
                // -----------------------------------

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                mwqmSampleLanguage.LanguageText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleLanguageLanguageText, "100"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // mwqmSampleLanguage.TranslationStatusText   (String)
                // -----------------------------------

                mwqmSampleLanguage = null;
                mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
                mwqmSampleLanguage.TranslationStatusText = GetRandomString("", 101);
                Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleLanguageTranslationStatusText, "100"), mwqmSampleLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSampleLanguageService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // mwqmSampleLanguage.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MWQMSampleLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                MWQMSampleLanguageService mwqmSampleLanguageService = new MWQMSampleLanguageService(LanguageRequest, dbTestDB, ContactID);

                MWQMSampleLanguage mwqmSampleLanguage = (from c in mwqmSampleLanguageService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(mwqmSampleLanguage);

                MWQMSampleLanguage mwqmSampleLanguageRet = mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleLanguageID(mwqmSampleLanguage.MWQMSampleLanguageID);
                Assert.AreEqual(mwqmSampleLanguage.MWQMSampleLanguageID, mwqmSampleLanguageRet.MWQMSampleLanguageID);
            }
        }
        #endregion Tests Get With Key

    }
}
