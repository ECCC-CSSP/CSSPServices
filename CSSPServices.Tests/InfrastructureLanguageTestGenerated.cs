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
    public partial class InfrastructureLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int InfrastructureLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private InfrastructureLanguage GetFilledRandomInfrastructureLanguage(string OmitPropName)
        {
            InfrastructureLanguageID += 1;

            InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();

            if (OmitPropName != "InfrastructureLanguageID") infrastructureLanguage.InfrastructureLanguageID = InfrastructureLanguageID;
            if (OmitPropName != "InfrastructureID") infrastructureLanguage.InfrastructureID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") infrastructureLanguage.Language = language;
            if (OmitPropName != "Comment") infrastructureLanguage.Comment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") infrastructureLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructureLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return infrastructureLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void InfrastructureLanguage_Testing()
        {
            SetupTestHelper(culture);
            InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            InfrastructureLanguage infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            Assert.AreEqual(true, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(true, infrastructureLanguageService.GetRead().Where(c => c == infrastructureLanguage).Any());
            infrastructureLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, infrastructureLanguageService.Update(infrastructureLanguage));
            Assert.AreEqual(1, infrastructureLanguageService.GetRead().Count());
            Assert.AreEqual(true, infrastructureLanguageService.Delete(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // InfrastructureID will automatically be initialized at 0 --> not null

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("Language");
            Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(1, infrastructureLanguage.ValidationResults.Count());
            Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageLanguage)).Any());
            Assert.AreEqual(LanguageEnum.Error, infrastructureLanguage.Language);
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("Comment");
            Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(1, infrastructureLanguage.ValidationResults.Count());
            Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageComment)).Any());
            Assert.AreEqual(null, infrastructureLanguage.Comment);
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("TranslationStatus");
            Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(1, infrastructureLanguage.ValidationResults.Count());
            Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageTranslationStatus)).Any());
            Assert.AreEqual(TranslationStatusEnum.Error, infrastructureLanguage.TranslationStatus);
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(1, infrastructureLanguage.ValidationResults.Count());
            Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(infrastructureLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [InfrastructureLanguageID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureID] of type [int]
            //-----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            // InfrastructureID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructureLanguage.InfrastructureID = 1;
            Assert.AreEqual(true, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguage.ValidationResults.Count());
            Assert.AreEqual(1, infrastructureLanguage.InfrastructureID);
            Assert.AreEqual(true, infrastructureLanguageService.Delete(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());
            // InfrastructureID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructureLanguage.InfrastructureID = 2;
            Assert.AreEqual(true, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguage.ValidationResults.Count());
            Assert.AreEqual(2, infrastructureLanguage.InfrastructureID);
            Assert.AreEqual(true, infrastructureLanguageService.Delete(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());
            // InfrastructureID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructureLanguage.InfrastructureID = 0;
            Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLanguageInfrastructureID, "1")).Any());
            Assert.AreEqual(0, infrastructureLanguage.InfrastructureID);
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Comment] of type [string]
            //-----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructureLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguage.ValidationResults.Count());
            Assert.AreEqual(1, infrastructureLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, infrastructureLanguageService.Delete(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructureLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguage.ValidationResults.Count());
            Assert.AreEqual(2, infrastructureLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, infrastructureLanguageService.Delete(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructureLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructureLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
