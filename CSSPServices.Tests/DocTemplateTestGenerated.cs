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
        private DocTemplateService docTemplateService { get; set; }
        #endregion Properties

        #region Constructors
        public DocTemplateTest() : base()
        {
            docTemplateService = new DocTemplateService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private DocTemplate GetFilledRandomDocTemplate(string OmitPropName)
        {
            DocTemplate docTemplate = new DocTemplate();

            if (OmitPropName != "Language") docTemplate.Language = language;
            if (OmitPropName != "TVType") docTemplate.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVFileTVItemID") docTemplate.TVFileTVItemID = 17;
            if (OmitPropName != "FileName") docTemplate.FileName = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") docTemplate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") docTemplate.LastUpdateContactTVItemID = 2;

            return docTemplate;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void DocTemplate_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            DocTemplate docTemplate = GetFilledRandomDocTemplate("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = docTemplateService.GetRead().Count();

            docTemplateService.Add(docTemplate);
            if (docTemplate.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, docTemplateService.GetRead().Where(c => c == docTemplate).Any());
            docTemplateService.Update(docTemplate);
            if (docTemplate.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, docTemplateService.GetRead().Count());
            docTemplateService.Delete(docTemplate);
            if (docTemplate.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, docTemplateService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // docTemplate.DocTemplateID   (Int32)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.DocTemplateID = 0;
            docTemplateService.Update(docTemplate);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateDocTemplateID), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // docTemplate.Language   (LanguageEnum)
            // -----------------------------------

            // Language will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // docTemplate.TVType   (TVTypeEnum)
            // -----------------------------------

            // TVType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.File)]
            // docTemplate.TVFileTVItemID   (Int32)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.TVFileTVItemID = 0;
            docTemplateService.Add(docTemplate);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.DocTemplateTVFileTVItemID, docTemplate.TVFileTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

            // TVFileTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(150))]
            // docTemplate.FileName   (String)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("FileName");
            Assert.AreEqual(false, docTemplateService.Add(docTemplate));
            Assert.AreEqual(1, docTemplate.ValidationResults.Count());
            Assert.IsTrue(docTemplate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateFileName)).Any());
            Assert.AreEqual(null, docTemplate.FileName);
            Assert.AreEqual(0, docTemplateService.GetRead().Count());

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            // FileName has MinLength [empty] and MaxLength [150]. At Max should return true and no errors
            string docTemplateFileNameMin = GetRandomString("", 150);
            docTemplate.FileName = docTemplateFileNameMin;
            Assert.AreEqual(true, docTemplateService.Add(docTemplate));
            Assert.AreEqual(0, docTemplate.ValidationResults.Count());
            Assert.AreEqual(docTemplateFileNameMin, docTemplate.FileName);
            Assert.AreEqual(true, docTemplateService.Delete(docTemplate));
            Assert.AreEqual(count, docTemplateService.GetRead().Count());

            // FileName has MinLength [empty] and MaxLength [150]. At Max - 1 should return true and no errors
            docTemplateFileNameMin = GetRandomString("", 149);
            docTemplate.FileName = docTemplateFileNameMin;
            Assert.AreEqual(true, docTemplateService.Add(docTemplate));
            Assert.AreEqual(0, docTemplate.ValidationResults.Count());
            Assert.AreEqual(docTemplateFileNameMin, docTemplate.FileName);
            Assert.AreEqual(true, docTemplateService.Delete(docTemplate));
            Assert.AreEqual(count, docTemplateService.GetRead().Count());

            // FileName has MinLength [empty] and MaxLength [150]. At Max + 1 should return false with one error
            docTemplateFileNameMin = GetRandomString("", 151);
            docTemplate.FileName = docTemplateFileNameMin;
            Assert.AreEqual(false, docTemplateService.Add(docTemplate));
            Assert.IsTrue(docTemplate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateFileName, "150")).Any());
            Assert.AreEqual(docTemplateFileNameMin, docTemplate.FileName);
            Assert.AreEqual(count, docTemplateService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // docTemplate.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // docTemplate.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.LastUpdateContactTVItemID = 0;
            docTemplateService.Add(docTemplate);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.DocTemplateLastUpdateContactTVItemID, docTemplate.LastUpdateContactTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // docTemplate.TVFileTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // docTemplate.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
