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
    public partial class MWQMSampleLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSampleLanguageService mwqmSampleLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageTest() : base()
        {
            mwqmSampleLanguageService = new MWQMSampleLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSampleLanguage GetFilledRandomMWQMSampleLanguage(string OmitPropName)
        {
            MWQMSampleLanguage mwqmSampleLanguage = new MWQMSampleLanguage();

            if (OmitPropName != "MWQMSampleID") mwqmSampleLanguage.MWQMSampleID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") mwqmSampleLanguage.Language = language;
            if (OmitPropName != "MWQMSampleNote") mwqmSampleLanguage.MWQMSampleNote = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") mwqmSampleLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSampleLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSampleLanguage.LastUpdateContactTVItemID = 2;

            return mwqmSampleLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSampleLanguage_Testing()
        {

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
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MWQMSampleID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Language]

            mwqmSampleLanguage = null;
            mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("MWQMSampleNote");
            Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
            Assert.AreEqual(1, mwqmSampleLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmSampleLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageMWQMSampleNote)).Any());
            Assert.AreEqual(null, mwqmSampleLanguage.MWQMSampleNote);
            Assert.AreEqual(0, mwqmSampleLanguageService.GetRead().Count());

            //Error: Type not implemented [TranslationStatus]

            mwqmSampleLanguage = null;
            mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
            Assert.AreEqual(1, mwqmSampleLanguage.ValidationResults.Count());
            Assert.IsTrue(mwqmSampleLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmSampleLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmSampleLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MWQMSample]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMSampleLanguageID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSampleID] of type [Int32]
            //-----------------------------------

            mwqmSampleLanguage = null;
            mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
            // MWQMSampleID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSampleLanguage.MWQMSampleID = 1;
            Assert.AreEqual(true, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
            Assert.AreEqual(0, mwqmSampleLanguage.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSampleLanguage.MWQMSampleID);
            Assert.AreEqual(true, mwqmSampleLanguageService.Delete(mwqmSampleLanguage));
            Assert.AreEqual(0, mwqmSampleLanguageService.GetRead().Count());
            // MWQMSampleID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSampleLanguage.MWQMSampleID = 2;
            Assert.AreEqual(true, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
            Assert.AreEqual(0, mwqmSampleLanguage.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSampleLanguage.MWQMSampleID);
            Assert.AreEqual(true, mwqmSampleLanguageService.Delete(mwqmSampleLanguage));
            Assert.AreEqual(0, mwqmSampleLanguageService.GetRead().Count());
            // MWQMSampleID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSampleLanguage.MWQMSampleID = 0;
            Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
            Assert.IsTrue(mwqmSampleLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleLanguageMWQMSampleID, "1")).Any());
            Assert.AreEqual(0, mwqmSampleLanguage.MWQMSampleID);
            Assert.AreEqual(0, mwqmSampleLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSampleNote] of type [String]
            //-----------------------------------

            mwqmSampleLanguage = null;
            mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            mwqmSampleLanguage = null;
            mwqmSampleLanguage = GetFilledRandomMWQMSampleLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSampleLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
            Assert.AreEqual(0, mwqmSampleLanguage.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSampleLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSampleLanguageService.Delete(mwqmSampleLanguage));
            Assert.AreEqual(0, mwqmSampleLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSampleLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
            Assert.AreEqual(0, mwqmSampleLanguage.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSampleLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSampleLanguageService.Delete(mwqmSampleLanguage));
            Assert.AreEqual(0, mwqmSampleLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSampleLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmSampleLanguageService.Add(mwqmSampleLanguage));
            Assert.IsTrue(mwqmSampleLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSampleLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mwqmSampleLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMSample] of type [MWQMSample]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
