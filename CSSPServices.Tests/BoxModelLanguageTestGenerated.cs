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
    public partial class BoxModelLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private BoxModelLanguageService boxModelLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageTest() : base()
        {
            boxModelLanguageService = new BoxModelLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModelLanguage GetFilledRandomBoxModelLanguage(string OmitPropName)
        {
            BoxModelLanguage boxModelLanguage = new BoxModelLanguage();

            if (OmitPropName != "BoxModelID") boxModelLanguage.BoxModelID = 1;
            if (OmitPropName != "Language") boxModelLanguage.Language = language;
            if (OmitPropName != "ScenarioName") boxModelLanguage.ScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") boxModelLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") boxModelLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelLanguage.LastUpdateContactTVItemID = 2;

            return boxModelLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void BoxModelLanguage_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            BoxModelLanguage boxModelLanguage = GetFilledRandomBoxModelLanguage("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = boxModelLanguageService.GetRead().Count();

            boxModelLanguageService.Add(boxModelLanguage);
            if (boxModelLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, boxModelLanguageService.GetRead().Where(c => c == boxModelLanguage).Any());
            boxModelLanguageService.Update(boxModelLanguage);
            if (boxModelLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, boxModelLanguageService.GetRead().Count());
            boxModelLanguageService.Delete(boxModelLanguage);
            if (boxModelLanguage.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // boxModelLanguage.BoxModelLanguageID   (Int32)
            //-----------------------------------
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.BoxModelLanguageID = 0;
            boxModelLanguageService.Update(boxModelLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageBoxModelLanguageID), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "BoxModel", Plurial = "s", FieldID = "BoxModelID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // boxModelLanguage.BoxModelID   (Int32)
            //-----------------------------------
            // BoxModelID will automatically be initialized at 0 --> not null


            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            // BoxModelID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModelLanguage.BoxModelID = 1;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(1, boxModelLanguage.BoxModelID);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());
            // BoxModelID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModelLanguage.BoxModelID = 2;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(2, boxModelLanguage.BoxModelID);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());
            // BoxModelID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModelLanguage.BoxModelID = 0;
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelLanguageBoxModelID, "1")).Any());
            Assert.AreEqual(0, boxModelLanguage.BoxModelID);
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // boxModelLanguage.Language   (LanguageEnum)
            //-----------------------------------
            // Language will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(250))]
            // boxModelLanguage.ScenarioName   (String)
            //-----------------------------------
            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("ScenarioName");
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(1, boxModelLanguage.ValidationResults.Count());
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageScenarioName)).Any());
            Assert.AreEqual(null, boxModelLanguage.ScenarioName);
            Assert.AreEqual(0, boxModelLanguageService.GetRead().Count());


            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");

            // ScenarioName has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string boxModelLanguageScenarioNameMin = GetRandomString("", 250);
            boxModelLanguage.ScenarioName = boxModelLanguageScenarioNameMin;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(boxModelLanguageScenarioNameMin, boxModelLanguage.ScenarioName);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

            // ScenarioName has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            boxModelLanguageScenarioNameMin = GetRandomString("", 249);
            boxModelLanguage.ScenarioName = boxModelLanguageScenarioNameMin;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(boxModelLanguageScenarioNameMin, boxModelLanguage.ScenarioName);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

            // ScenarioName has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            boxModelLanguageScenarioNameMin = GetRandomString("", 251);
            boxModelLanguage.ScenarioName = boxModelLanguageScenarioNameMin;
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelLanguageScenarioName, "250")).Any());
            Assert.AreEqual(boxModelLanguageScenarioNameMin, boxModelLanguage.ScenarioName);
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // boxModelLanguage.TranslationStatus   (TranslationStatusEnum)
            //-----------------------------------
            // TranslationStatus will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // boxModelLanguage.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // boxModelLanguage.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModelLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(1, boxModelLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModelLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(0, boxModelLanguage.ValidationResults.Count());
            Assert.AreEqual(2, boxModelLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelLanguageService.Delete(boxModelLanguage));
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModelLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, boxModelLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // boxModelLanguage.BoxModel   (BoxModel)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // boxModelLanguage.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
