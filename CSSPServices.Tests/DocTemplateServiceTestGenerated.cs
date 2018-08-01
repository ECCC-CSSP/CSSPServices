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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void DocTemplate_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.DocTemplateWeb = null;
                    Assert.IsNull(docTemplate.DocTemplateWeb);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.DocTemplateWeb = new DocTemplateWeb();
                    Assert.IsNotNull(docTemplate.DocTemplateWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // docTemplate.DocTemplateReport   (DocTemplateReport)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.DocTemplateReport = null;
                    Assert.IsNull(docTemplate.DocTemplateReport);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.DocTemplateReport = new DocTemplateReport();
                    Assert.IsNotNull(docTemplate.DocTemplateReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // docTemplate.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateDate_UTC = new DateTime();
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateLastUpdateDate_UTC), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.DocTemplateLastUpdateDate_UTC, "1980"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

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

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // docTemplate.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID)
        [TestMethod]
        public void GetDocTemplateWithDocTemplateID__docTemplate_DocTemplateID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    DocTemplate docTemplate = (from c in docTemplateService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(docTemplate);

                    DocTemplate docTemplateRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        docTemplateService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID);
                            Assert.IsNull(docTemplateRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckDocTemplateFields(new List<DocTemplate>() { docTemplateRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID)

        #region Tests Generated for GetDocTemplateList()
        [TestMethod]
        public void GetDocTemplateList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    DocTemplate docTemplate = (from c in docTemplateService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(docTemplate);

                    List<DocTemplate> docTemplateList = new List<DocTemplate>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        docTemplateService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            Assert.AreEqual(0, docTemplateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckDocTemplateFields(docTemplateList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList()

        #region Tests Generated for GetDocTemplateList() Skip Take
        [TestMethod]
        public void GetDocTemplateList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<DocTemplate> docTemplateList = new List<DocTemplate>();
                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        docTemplateDirectQueryList = docTemplateService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            Assert.AreEqual(0, docTemplateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckDocTemplateFields(docTemplateList, entityQueryDetailType);
                        Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        Assert.AreEqual(1, docTemplateList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take

        #region Tests Generated for GetDocTemplateList() Skip Take Order
        [TestMethod]
        public void GetDocTemplateList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<DocTemplate> docTemplateList = new List<DocTemplate>();
                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1,  "DocTemplateID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        docTemplateDirectQueryList = docTemplateService.GetRead().Skip(1).Take(1).OrderBy(c => c.DocTemplateID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            Assert.AreEqual(0, docTemplateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckDocTemplateFields(docTemplateList, entityQueryDetailType);
                        Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        Assert.AreEqual(1, docTemplateList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take Order

        #region Tests Generated for GetDocTemplateList() Skip Take 2Order
        [TestMethod]
        public void GetDocTemplateList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<DocTemplate> docTemplateList = new List<DocTemplate>();
                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1, "DocTemplateID,Language", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        docTemplateDirectQueryList = docTemplateService.GetRead().Skip(1).Take(1).OrderBy(c => c.DocTemplateID).ThenBy(c => c.Language).ToList();

                        if (entityQueryDetailType == null)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            Assert.AreEqual(0, docTemplateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckDocTemplateFields(docTemplateList, entityQueryDetailType);
                        Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        Assert.AreEqual(1, docTemplateList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take 2Order

        #region Tests Generated for GetDocTemplateList() Skip Take Order Where
        [TestMethod]
        public void GetDocTemplateList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<DocTemplate> docTemplateList = new List<DocTemplate>();
                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 1, "DocTemplateID", "DocTemplateID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        docTemplateDirectQueryList = docTemplateService.GetRead().Where(c => c.DocTemplateID == 4).Skip(0).Take(1).OrderBy(c => c.DocTemplateID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            Assert.AreEqual(0, docTemplateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckDocTemplateFields(docTemplateList, entityQueryDetailType);
                        Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        Assert.AreEqual(1, docTemplateList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take Order Where

        #region Tests Generated for GetDocTemplateList() Skip Take Order 2Where
        [TestMethod]
        public void GetDocTemplateList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<DocTemplate> docTemplateList = new List<DocTemplate>();
                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 1, "DocTemplateID", "DocTemplateID,GT,2|DocTemplateID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        docTemplateDirectQueryList = docTemplateService.GetRead().Where(c => c.DocTemplateID > 2 && c.DocTemplateID < 5).Skip(0).Take(1).OrderBy(c => c.DocTemplateID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            Assert.AreEqual(0, docTemplateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckDocTemplateFields(docTemplateList, entityQueryDetailType);
                        Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        Assert.AreEqual(1, docTemplateList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() Skip Take Order 2Where

        #region Tests Generated for GetDocTemplateList() 2Where
        [TestMethod]
        public void GetDocTemplateList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<DocTemplate> docTemplateList = new List<DocTemplate>();
                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 10000, "", "DocTemplateID,GT,2|DocTemplateID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        docTemplateDirectQueryList = docTemplateService.GetRead().Where(c => c.DocTemplateID > 2 && c.DocTemplateID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            Assert.AreEqual(0, docTemplateList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckDocTemplateFields(docTemplateList, entityQueryDetailType);
                        Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        Assert.AreEqual(2, docTemplateList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() 2Where

        #region Functions private
        private void CheckDocTemplateFields(List<DocTemplate> docTemplateList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // DocTemplate fields
            Assert.IsNotNull(docTemplateList[0].DocTemplateID);
            Assert.IsNotNull(docTemplateList[0].Language);
            Assert.IsNotNull(docTemplateList[0].TVType);
            Assert.IsNotNull(docTemplateList[0].TVFileTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateList[0].FileName));
            Assert.IsNotNull(docTemplateList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(docTemplateList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // DocTemplateWeb and DocTemplateReport fields should be null here
                Assert.IsNull(docTemplateList[0].DocTemplateWeb);
                Assert.IsNull(docTemplateList[0].DocTemplateReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // DocTemplateWeb fields should not be null and DocTemplateReport fields should be null here
                if (!string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateWeb.LanguageText));
                }
                if (!string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateWeb.TVTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateWeb.TVTypeText));
                }
                Assert.IsNull(docTemplateList[0].DocTemplateReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // DocTemplateWeb and DocTemplateReport fields should NOT be null here
                if (docTemplateList[0].DocTemplateWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateWeb.LastUpdateContactTVText));
                }
                if (docTemplateList[0].DocTemplateWeb.LanguageText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateWeb.LanguageText));
                }
                if (docTemplateList[0].DocTemplateWeb.TVTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateWeb.TVTypeText));
                }
                if (docTemplateList[0].DocTemplateReport.DocTemplateReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateList[0].DocTemplateReport.DocTemplateReportTest));
                }
            }
        }
        private DocTemplate GetFilledRandomDocTemplate(string OmitPropName)
        {
            DocTemplate docTemplate = new DocTemplate();

            if (OmitPropName != "Language") docTemplate.Language = LanguageRequest;
            if (OmitPropName != "TVType") docTemplate.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVFileTVItemID") docTemplate.TVFileTVItemID = 38;
            if (OmitPropName != "FileName") docTemplate.FileName = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") docTemplate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") docTemplate.LastUpdateContactTVItemID = 2;

            return docTemplate;
        }
        #endregion Functions private
    }
}
