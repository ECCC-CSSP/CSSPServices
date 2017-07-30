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
    public partial class MWQMSubsectorLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSubsectorLanguageService mwqmSubsectorLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageTest() : base()
        {
            mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSubsectorLanguage GetFilledRandomMWQMSubsectorLanguage(string OmitPropName)
        {
            MWQMSubsectorLanguage mwqmSubsectorLanguage = new MWQMSubsectorLanguage();

            if (OmitPropName != "MWQMSubsectorID") mwqmSubsectorLanguage.MWQMSubsectorID = 1;
            if (OmitPropName != "Language") mwqmSubsectorLanguage.Language = language;
            if (OmitPropName != "SubsectorDesc") mwqmSubsectorLanguage.SubsectorDesc = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") mwqmSubsectorLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsectorLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsectorLanguage.LastUpdateContactTVItemID = 2;

            return mwqmSubsectorLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSubsectorLanguage_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MWQMSubsectorLanguage mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = mwqmSubsectorLanguageService.GetRead().Count();

            mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
            if (mwqmSubsectorLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mwqmSubsectorLanguageService.GetRead().Where(c => c == mwqmSubsectorLanguage).Any());
            mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage);
            if (mwqmSubsectorLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mwqmSubsectorLanguageService.GetRead().Count());
            mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage);
            if (mwqmSubsectorLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mwqmSubsectorLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmSubsectorLanguage.MWQMSubsectorLanguageID   (Int32)
            // -----------------------------------

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            mwqmSubsectorLanguage.MWQMSubsectorLanguageID = 0;
            mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageMWQMSubsectorLanguageID), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "MWQMSubsector", Plurial = "s", FieldID = "MWQMSubsectorID", TVType = TVTypeEnum.Error)]
            // mwqmSubsectorLanguage.MWQMSubsectorID   (Int32)
            // -----------------------------------

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            mwqmSubsectorLanguage.MWQMSubsectorID = 0;
            mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MWQMSubsector, ModelsRes.MWQMSubsectorLanguageMWQMSubsectorID, mwqmSubsectorLanguage.MWQMSubsectorID.ToString()), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmSubsectorLanguage.Language   (LanguageEnum)
            // -----------------------------------

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            mwqmSubsectorLanguage.Language = (LanguageEnum)1000000;
            mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageLanguage), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250))]
            // mwqmSubsectorLanguage.SubsectorDesc   (String)
            // -----------------------------------

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("SubsectorDesc");
            Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(1, mwqmSubsectorLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsectorLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageSubsectorDesc)).Any());
            Assert.AreEqual(null, mwqmSubsectorLanguage.SubsectorDesc);
            Assert.AreEqual(count, mwqmSubsectorLanguageService.GetRead().Count());

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            mwqmSubsectorLanguage.SubsectorDesc = GetRandomString("", 251);
            Assert.AreEqual(false, mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorLanguageSubsectorDesc, "250"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mwqmSubsectorLanguageService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmSubsectorLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            mwqmSubsectorLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageTranslationStatus), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsectorLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // mwqmSubsectorLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            mwqmSubsectorLanguage.LastUpdateContactTVItemID = 0;
            mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, mwqmSubsectorLanguage.LastUpdateContactTVItemID.ToString()), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            mwqmSubsectorLanguage = null;
            mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage("");
            mwqmSubsectorLanguage.LastUpdateContactTVItemID = 1;
            mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, "Contact"), mwqmSubsectorLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mwqmSubsectorLanguage.MWQMSubsector   (MWQMSubsector)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mwqmSubsectorLanguage.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
