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
    public partial class VPScenarioLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int VPScenarioLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPScenarioLanguage GetFilledRandomVPScenarioLanguage(string OmitPropName)
        {
            VPScenarioLanguageID += 1;

            VPScenarioLanguage vpScenarioLanguage = new VPScenarioLanguage();

            if (OmitPropName != "VPScenarioLanguageID") vpScenarioLanguage.VPScenarioLanguageID = VPScenarioLanguageID;
            if (OmitPropName != "VPScenarioID") vpScenarioLanguage.VPScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") vpScenarioLanguage.Language = language;
            if (OmitPropName != "VPScenarioName") vpScenarioLanguage.VPScenarioName = GetRandomString("", 6);
            if (OmitPropName != "TranslationStatus") vpScenarioLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") vpScenarioLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpScenarioLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return vpScenarioLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPScenarioLanguage_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            VPScenarioLanguage vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(true, vpScenarioLanguageService.GetRead().Where(c => c == vpScenarioLanguage).Any());
            vpScenarioLanguage.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, vpScenarioLanguageService.Update(vpScenarioLanguage));
            Assert.AreEqual(1, vpScenarioLanguageService.GetRead().Count());
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // VPScenarioID will automatically be initialized at 0 --> not null

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("Language");
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageLanguage)).Any());
            Assert.AreEqual(LanguageEnum.Error, vpScenarioLanguage.Language);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("VPScenarioName");
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageVPScenarioName)).Any());
            Assert.AreEqual(null, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("TranslationStatus");
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageTranslationStatus)).Any());
            Assert.AreEqual(TranslationStatusEnum.Error, vpScenarioLanguage.TranslationStatus);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(vpScenarioLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [VPScenarioLanguageID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPScenarioID] of type [int]
            //-----------------------------------

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
            // VPScenarioID has Min [1] and Max [empty]. At Min should return true and no errors
            vpScenarioLanguage.VPScenarioID = 1;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(1, vpScenarioLanguage.VPScenarioID);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpScenarioLanguage.VPScenarioID = 2;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(2, vpScenarioLanguage.VPScenarioID);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpScenarioLanguage.VPScenarioID = 0;
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioLanguageVPScenarioID, "1")).Any());
            Assert.AreEqual(0, vpScenarioLanguage.VPScenarioID);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPScenarioName] of type [string]
            //-----------------------------------

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");

            // VPScenarioName has MinLength [1] and MaxLength [100]. At Min should return true and no errors
            string vpScenarioLanguageVPScenarioNameMin = GetRandomString("", 1);
            vpScenarioLanguage.VPScenarioName = vpScenarioLanguageVPScenarioNameMin;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(vpScenarioLanguageVPScenarioNameMin, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            // VPScenarioName has MinLength [1] and MaxLength [100]. At Min + 1 should return true and no errors
            vpScenarioLanguageVPScenarioNameMin = GetRandomString("", 2);
            vpScenarioLanguage.VPScenarioName = vpScenarioLanguageVPScenarioNameMin;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(vpScenarioLanguageVPScenarioNameMin, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            // VPScenarioName has MinLength [1] and MaxLength [100]. At Max should return true and no errors
            vpScenarioLanguageVPScenarioNameMin = GetRandomString("", 100);
            vpScenarioLanguage.VPScenarioName = vpScenarioLanguageVPScenarioNameMin;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(vpScenarioLanguageVPScenarioNameMin, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            // VPScenarioName has MinLength [1] and MaxLength [100]. At Max - 1 should return true and no errors
            vpScenarioLanguageVPScenarioNameMin = GetRandomString("", 99);
            vpScenarioLanguage.VPScenarioName = vpScenarioLanguageVPScenarioNameMin;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(vpScenarioLanguageVPScenarioNameMin, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            // VPScenarioName has MinLength [1] and MaxLength [100]. At Max + 1 should return false with one error
            vpScenarioLanguageVPScenarioNameMin = GetRandomString("", 101);
            vpScenarioLanguage.VPScenarioName = vpScenarioLanguageVPScenarioNameMin;
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.VPScenarioLanguageVPScenarioName, "1", "100")).Any());
            Assert.AreEqual(vpScenarioLanguageVPScenarioNameMin, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpScenarioLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(1, vpScenarioLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpScenarioLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(2, vpScenarioLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpScenarioLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, vpScenarioLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
