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
            // Need to implement (no items found, would need to add at least one in the TestDB) [DocTemplate TVFileTVItemID TVItem TVItemID]
            if (OmitPropName != "FileName") docTemplate.FileName = GetRandomString("", 5);
            //Error: property [DocTemplateWeb] and type [DocTemplate] is  not implemented
            //Error: property [DocTemplateReport] and type [DocTemplate] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") docTemplate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") docTemplate.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") docTemplate.HasErrors = true;

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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
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

                    Assert.AreEqual(docTemplateService.GetRead().Count(), docTemplateService.GetEdit().Count());

                    docTemplateService.Add(docTemplate);
                    if (docTemplate.HasErrors)
                    {
                        Assert.AreEqual("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, docTemplateService.GetRead().Where(c => c == docTemplate).Any());
                    docTemplateService.Update(docTemplate);
                    if (docTemplate.HasErrors)
                    {
                        Assert.AreEqual("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, docTemplateService.GetRead().Count());
                    docTemplateService.Delete(docTemplate);
                    if (docTemplate.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateDocTemplateID), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.DocTemplateID = 10000000;
                    docTemplateService.Update(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.DocTemplate, CSSPModelsRes.DocTemplateDocTemplateID, docTemplate.DocTemplateID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // docTemplate.Language   (LanguageEnum)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.Language = (LanguageEnum)1000000;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateLanguage), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // docTemplate.TVType   (TVTypeEnum)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.TVType = (TVTypeEnum)1000000;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateTVType), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
                    // docTemplate.TVFileTVItemID   (Int32)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.TVFileTVItemID = 0;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.DocTemplateTVFileTVItemID, docTemplate.TVFileTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.TVFileTVItemID = 1;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.DocTemplateTVFileTVItemID, "File"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(150))]
                    // docTemplate.FileName   (String)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("FileName");
                    Assert.AreEqual(false, docTemplateService.Add(docTemplate));
                    Assert.AreEqual(1, docTemplate.ValidationResults.Count());
                    Assert.IsTrue(docTemplate.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateFileName)).Any());
                    Assert.AreEqual(null, docTemplate.FileName);
                    Assert.AreEqual(count, docTemplateService.GetRead().Count());

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.FileName = GetRandomString("", 151);
                    Assert.AreEqual(false, docTemplateService.Add(docTemplate));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.DocTemplateFileName, "150"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, docTemplateService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // docTemplate.DocTemplateWeb   (DocTemplateWeb)
                    // -----------------------------------

                    //Error: Type not implemented [DocTemplateWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // docTemplate.DocTemplateReport   (DocTemplateReport)
                    // -----------------------------------

                    //Error: Type not implemented [DocTemplateReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // docTemplate.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // docTemplate.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateContactTVItemID = 0;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.DocTemplateLastUpdateContactTVItemID, docTemplate.LastUpdateContactTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateContactTVItemID = 1;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.DocTemplateLastUpdateContactTVItemID, "Contact"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // docTemplate.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // docTemplate.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(LanguageRequest, dbTestDB, ContactID);
                    DocTemplate docTemplate = (from c in docTemplateService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(docTemplate);

                    DocTemplate docTemplateRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(docTemplateRet.DocTemplateID);
                        Assert.IsNotNull(docTemplateRet.Language);
                        Assert.IsNotNull(docTemplateRet.TVType);
                        Assert.IsNotNull(docTemplateRet.TVFileTVItemID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateRet.FileName));
                        Assert.IsNotNull(docTemplateRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(docTemplateRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (docTemplateRet.DocTemplateWeb != null)
                            {
                                Assert.IsNull(docTemplateRet.DocTemplateWeb);
                            }
                            if (docTemplateRet.DocTemplateReport != null)
                            {
                                Assert.IsNull(docTemplateRet.DocTemplateReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (docTemplateRet.DocTemplateWeb != null)
                            {
                                Assert.IsNotNull(docTemplateRet.DocTemplateWeb);
                            }
                            if (docTemplateRet.DocTemplateReport != null)
                            {
                                Assert.IsNotNull(docTemplateRet.DocTemplateReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of DocTemplate
        #endregion Tests Get List of DocTemplate

    }
}
