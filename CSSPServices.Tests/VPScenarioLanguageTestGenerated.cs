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
        private VPScenarioLanguageService vpScenarioLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageTest() : base()
        {
            vpScenarioLanguageService = new VPScenarioLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPScenarioLanguage GetFilledRandomVPScenarioLanguage(string OmitPropName)
        {
            VPScenarioLanguage vpScenarioLanguage = new VPScenarioLanguage();

            if (OmitPropName != "VPScenarioID") vpScenarioLanguage.VPScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "Language") vpScenarioLanguage.Language = language;
            if (OmitPropName != "VPScenarioName") vpScenarioLanguage.VPScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") vpScenarioLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") vpScenarioLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") vpScenarioLanguage.LastUpdateContactTVItemID = 2;

            return vpScenarioLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPScenarioLanguage_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            VPScenarioLanguage vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = vpScenarioLanguageService.GetRead().Count();

            vpScenarioLanguageService.Add(vpScenarioLanguage);
            if (vpScenarioLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, vpScenarioLanguageService.GetRead().Where(c => c == vpScenarioLanguage).Any());
            vpScenarioLanguageService.Update(vpScenarioLanguage);
            if (vpScenarioLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, vpScenarioLanguageService.GetRead().Count());
            vpScenarioLanguageService.Delete(vpScenarioLanguage);
            if (vpScenarioLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // VPScenarioID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Language]

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("VPScenarioName");
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageVPScenarioName)).Any());
            Assert.AreEqual(null, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            //Error: Type not implemented [TranslationStatus]

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("LastUpdateDate_UTC");
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageLastUpdateDate_UTC)).Any());
            Assert.IsTrue(vpScenarioLanguage.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [VPScenario]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [VPScenarioLanguageID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [VPScenarioID] of type [Int32]
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
            // doing property [VPScenarioName] of type [String]
            //-----------------------------------

            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");

            //-----------------------------------
            // doing property [TranslationStatus] of type [TranslationStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [VPScenario] of type [VPScenario]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
