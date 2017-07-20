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
    public partial class DocTemplateTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int DocTemplateID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public DocTemplateTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private DocTemplate GetFilledRandomDocTemplate(string OmitPropName)
        {
            DocTemplateID += 1;

            DocTemplate docTemplate = new DocTemplate();

            if (OmitPropName != "DocTemplateID") docTemplate.DocTemplateID = DocTemplateID;
            if (OmitPropName != "Language") docTemplate.Language = language;
            if (OmitPropName != "TVType") docTemplate.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVFileTVItemID") docTemplate.TVFileTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "FileName") docTemplate.FileName = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") docTemplate.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") docTemplate.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return docTemplate;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void DocTemplate_Testing()
        {
            SetupTestHelper(culture);
            DocTemplateService docTemplateService = new DocTemplateService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            DocTemplate docTemplate = GetFilledRandomDocTemplate("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, docTemplateService.Add(docTemplate));
            Assert.AreEqual(true, docTemplateService.GetRead().Where(c => c == docTemplate).Any());
            docTemplate.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, docTemplateService.Update(docTemplate));
            Assert.AreEqual(1, docTemplateService.GetRead().Count());
            Assert.AreEqual(true, docTemplateService.Delete(docTemplate));
            Assert.AreEqual(0, docTemplateService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            //Error: Type not implemented [Language]

            //Error: Type not implemented [TVType]

            // TVFileTVItemID will automatically be initialized at 0 --> not null

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("FileName");
            Assert.AreEqual(false, docTemplateService.Add(docTemplate));
            Assert.AreEqual(1, docTemplate.ValidationResults.Count());
            Assert.IsTrue(docTemplate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateFileName)).Any());
            Assert.AreEqual(null, docTemplate.FileName);
            Assert.AreEqual(0, docTemplateService.GetRead().Count());

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("LastUpdateDate_UTC");
            Assert.AreEqual(false, docTemplateService.Add(docTemplate));
            Assert.AreEqual(1, docTemplate.ValidationResults.Count());
            Assert.IsTrue(docTemplate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateLastUpdateDate_UTC)).Any());
            Assert.IsTrue(docTemplate.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, docTemplateService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TVFileTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [DocTemplateID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVFileTVItemID] of type [Int32]
            //-----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            // TVFileTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            docTemplate.TVFileTVItemID = 1;
            Assert.AreEqual(true, docTemplateService.Add(docTemplate));
            Assert.AreEqual(0, docTemplate.ValidationResults.Count());
            Assert.AreEqual(1, docTemplate.TVFileTVItemID);
            Assert.AreEqual(true, docTemplateService.Delete(docTemplate));
            Assert.AreEqual(0, docTemplateService.GetRead().Count());
            // TVFileTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            docTemplate.TVFileTVItemID = 2;
            Assert.AreEqual(true, docTemplateService.Add(docTemplate));
            Assert.AreEqual(0, docTemplate.ValidationResults.Count());
            Assert.AreEqual(2, docTemplate.TVFileTVItemID);
            Assert.AreEqual(true, docTemplateService.Delete(docTemplate));
            Assert.AreEqual(0, docTemplateService.GetRead().Count());
            // TVFileTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            docTemplate.TVFileTVItemID = 0;
            Assert.AreEqual(false, docTemplateService.Add(docTemplate));
            Assert.IsTrue(docTemplate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.DocTemplateTVFileTVItemID, "1")).Any());
            Assert.AreEqual(0, docTemplate.TVFileTVItemID);
            Assert.AreEqual(0, docTemplateService.GetRead().Count());

            //-----------------------------------
            // doing property [FileName] of type [String]
            //-----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            docTemplate.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, docTemplateService.Add(docTemplate));
            Assert.AreEqual(0, docTemplate.ValidationResults.Count());
            Assert.AreEqual(1, docTemplate.LastUpdateContactTVItemID);
            Assert.AreEqual(true, docTemplateService.Delete(docTemplate));
            Assert.AreEqual(0, docTemplateService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            docTemplate.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, docTemplateService.Add(docTemplate));
            Assert.AreEqual(0, docTemplate.ValidationResults.Count());
            Assert.AreEqual(2, docTemplate.LastUpdateContactTVItemID);
            Assert.AreEqual(true, docTemplateService.Delete(docTemplate));
            Assert.AreEqual(0, docTemplateService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            docTemplate.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, docTemplateService.Add(docTemplate));
            Assert.IsTrue(docTemplate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.DocTemplateLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, docTemplate.LastUpdateContactTVItemID);
            Assert.AreEqual(0, docTemplateService.GetRead().Count());

            //-----------------------------------
            // doing property [TVFileTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
