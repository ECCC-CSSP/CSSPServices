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
    public partial class DocTemplateServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private DocTemplateService docTemplateService { get; set; }
        #endregion Properties

        #region Constructors
        public DocTemplateServiceTest() : base()
        {
            //docTemplateService = new DocTemplateService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private DocTemplate GetFilledRandomDocTemplate(string OmitPropName)
        {
            DocTemplate docTemplate = new DocTemplate();

            if (OmitPropName != "Language") docTemplate.Language = LanguageRequest;
            if (OmitPropName != "TVType") docTemplate.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVFileTVItemID") docTemplate.TVFileTVItemID = 17;
            if (OmitPropName != "FileName") docTemplate.FileName = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") docTemplate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") docTemplate.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") docTemplate.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "LanguageText") docTemplate.LanguageText = GetRandomString("", 5);
            if (OmitPropName != "TVTypeText") docTemplate.TVTypeText = GetRandomString("", 5);

            return docTemplate;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void DocTemplate_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                DocTemplateService docTemplateService = new DocTemplateService(LanguageRequest, dbTestDB, ContactID);

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

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.Language = (LanguageEnum)1000000;
                docTemplateService.Add(docTemplate);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateLanguage), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // docTemplate.TVType   (TVTypeEnum)
                // -----------------------------------

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.TVType = (TVTypeEnum)1000000;
                docTemplateService.Add(docTemplate);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateTVType), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = File)]
                // docTemplate.TVFileTVItemID   (Int32)
                // -----------------------------------

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.TVFileTVItemID = 0;
                docTemplateService.Add(docTemplate);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.DocTemplateTVFileTVItemID, docTemplate.TVFileTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.TVFileTVItemID = 1;
                docTemplateService.Add(docTemplate);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.DocTemplateTVFileTVItemID, "File"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


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
                Assert.AreEqual(count, docTemplateService.GetRead().Count());

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.FileName = GetRandomString("", 151);
                Assert.AreEqual(false, docTemplateService.Add(docTemplate));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateFileName, "150"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, docTemplateService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // docTemplate.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // docTemplate.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.LastUpdateContactTVItemID = 0;
                docTemplateService.Add(docTemplate);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.DocTemplateLastUpdateContactTVItemID, docTemplate.LastUpdateContactTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.LastUpdateContactTVItemID = 1;
                docTemplateService.Add(docTemplate);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.DocTemplateLastUpdateContactTVItemID, "Contact"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // docTemplate.LastUpdateContactTVText   (String)
                // -----------------------------------

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, docTemplateService.Add(docTemplate));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateLastUpdateContactTVText, "200"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, docTemplateService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // docTemplate.LanguageText   (String)
                // -----------------------------------

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.LanguageText = GetRandomString("", 101);
                Assert.AreEqual(false, docTemplateService.Add(docTemplate));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateLanguageText, "100"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, docTemplateService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // docTemplate.TVTypeText   (String)
                // -----------------------------------

                docTemplate = null;
                docTemplate = GetFilledRandomDocTemplate("");
                docTemplate.TVTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, docTemplateService.Add(docTemplate));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateTVTypeText, "100"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, docTemplateService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // docTemplate.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void DocTemplate_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                DocTemplateService docTemplateService = new DocTemplateService(LanguageRequest, dbTestDB, ContactID);

                DocTemplate docTemplate = (from c in docTemplateService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(docTemplate);

                DocTemplate docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID);
                Assert.AreEqual(docTemplate.DocTemplateID, docTemplateRet.DocTemplateID);
            }
        }
        #endregion Tests Get With Key

    }
}
