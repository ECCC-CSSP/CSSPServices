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
            if (OmitPropName != "LastUpdateDate_UTC") boxModelLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // boxModelLanguage.BoxModelLanguageID   (Int32)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.BoxModelLanguageID = 0;
            boxModelLanguageService.Update(boxModelLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageBoxModelLanguageID), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "BoxModel", Plurial = "s", FieldID = "BoxModelID", TVType = TVTypeEnum.Error)]
            // boxModelLanguage.BoxModelID   (Int32)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.BoxModelID = 0;
            boxModelLanguageService.Add(boxModelLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.BoxModel, ModelsRes.BoxModelLanguageBoxModelID, boxModelLanguage.BoxModelID.ToString()), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // boxModelLanguage.Language   (LanguageEnum)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.Language = (LanguageEnum)1000000;
            boxModelLanguageService.Add(boxModelLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageLanguage), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250))]
            // boxModelLanguage.ScenarioName   (String)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("ScenarioName");
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(1, boxModelLanguage.ValidationResults.Count());
            Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageScenarioName)).Any());
            Assert.AreEqual(null, boxModelLanguage.ScenarioName);
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.ScenarioName = GetRandomString("", 251);
            Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelLanguageScenarioName, "250"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // boxModelLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            boxModelLanguageService.Add(boxModelLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageTranslationStatus), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // boxModelLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // boxModelLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.LastUpdateContactTVItemID = 0;
            boxModelLanguageService.Add(boxModelLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelLanguageLastUpdateContactTVItemID, boxModelLanguage.LastUpdateContactTVItemID.ToString()), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.LastUpdateContactTVItemID = 1;
            boxModelLanguageService.Add(boxModelLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.BoxModelLanguageLastUpdateContactTVItemID, "Contact"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // boxModelLanguage.BoxModel   (BoxModel)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // boxModelLanguage.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
