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

            if (OmitPropName != "VPScenarioID") vpScenarioLanguage.VPScenarioID = 1;
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
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // vpScenarioLanguage.VPScenarioLanguageID   (Int32)
            //-----------------------------------
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
            vpScenarioLanguage.VPScenarioLanguageID = 0;
            vpScenarioLanguageService.Update(vpScenarioLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageVPScenarioLanguageID), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "VPScenario", Plurial = "s", FieldID = "VPScenarioID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // vpScenarioLanguage.VPScenarioID   (Int32)
            //-----------------------------------
            // VPScenarioID will automatically be initialized at 0 --> not null


            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
            // VPScenarioID has Min [1] and Max [empty]. At Min should return true and no errors
            vpScenarioLanguage.VPScenarioID = 1;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(1, vpScenarioLanguage.VPScenarioID);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpScenarioLanguage.VPScenarioID = 2;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(2, vpScenarioLanguage.VPScenarioID);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());
            // VPScenarioID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpScenarioLanguage.VPScenarioID = 0;
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioLanguageVPScenarioID, "1")).Any());
            Assert.AreEqual(0, vpScenarioLanguage.VPScenarioID);
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // vpScenarioLanguage.Language   (LanguageEnum)
            //-----------------------------------
            // Language will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(100))]
            // vpScenarioLanguage.VPScenarioName   (String)
            //-----------------------------------
            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("VPScenarioName");
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageVPScenarioName)).Any());
            Assert.AreEqual(null, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(0, vpScenarioLanguageService.GetRead().Count());


            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");

            // VPScenarioName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string vpScenarioLanguageVPScenarioNameMin = GetRandomString("", 100);
            vpScenarioLanguage.VPScenarioName = vpScenarioLanguageVPScenarioNameMin;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(vpScenarioLanguageVPScenarioNameMin, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

            // VPScenarioName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            vpScenarioLanguageVPScenarioNameMin = GetRandomString("", 99);
            vpScenarioLanguage.VPScenarioName = vpScenarioLanguageVPScenarioNameMin;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(vpScenarioLanguageVPScenarioNameMin, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

            // VPScenarioName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            vpScenarioLanguageVPScenarioNameMin = GetRandomString("", 101);
            vpScenarioLanguage.VPScenarioName = vpScenarioLanguageVPScenarioNameMin;
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.VPScenarioLanguageVPScenarioName, "100")).Any());
            Assert.AreEqual(vpScenarioLanguageVPScenarioNameMin, vpScenarioLanguage.VPScenarioName);
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // vpScenarioLanguage.TranslationStatus   (TranslationStatusEnum)
            //-----------------------------------
            // TranslationStatus will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // vpScenarioLanguage.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // vpScenarioLanguage.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            vpScenarioLanguage = null;
            vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            vpScenarioLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(1, vpScenarioLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            vpScenarioLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.AreEqual(0, vpScenarioLanguage.ValidationResults.Count());
            Assert.AreEqual(2, vpScenarioLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, vpScenarioLanguageService.Delete(vpScenarioLanguage));
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            vpScenarioLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
            Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, vpScenarioLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // vpScenarioLanguage.VPScenario   (VPScenario)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // vpScenarioLanguage.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
