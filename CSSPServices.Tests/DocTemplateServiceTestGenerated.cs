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

                    count = docTemplateService.GetDocTemplateList().Count();

                    Assert.AreEqual(docTemplateService.GetDocTemplateList().Count(), (from c in dbTestDB.DocTemplates select c).Take(200).Count());

                    docTemplateService.Add(docTemplate);
                    if (docTemplate.HasErrors)
                    {
                        Assert.AreEqual("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, docTemplateService.GetDocTemplateList().Where(c => c == docTemplate).Any());
                    docTemplateService.Update(docTemplate);
                    if (docTemplate.HasErrors)
                    {
                        Assert.AreEqual("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, docTemplateService.GetDocTemplateList().Count());
                    docTemplateService.Delete(docTemplate);
                    if (docTemplate.HasErrors)
                    {
                        Assert.AreEqual("", docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, docTemplateService.GetDocTemplateList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "DocTemplateDocTemplateID"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.DocTemplateID = 10000000;
                    docTemplateService.Update(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateDocTemplateID", docTemplate.DocTemplateID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // docTemplate.Language   (LanguageEnum)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.Language = (LanguageEnum)1000000;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "DocTemplateLanguage"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // docTemplate.TVType   (TVTypeEnum)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.TVType = (TVTypeEnum)1000000;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "DocTemplateTVType"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
                    // docTemplate.TVFileTVItemID   (Int32)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.TVFileTVItemID = 0;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "DocTemplateTVFileTVItemID", docTemplate.TVFileTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.TVFileTVItemID = 1;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "DocTemplateTVFileTVItemID", "File"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(150))]
                    // docTemplate.FileName   (String)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("FileName");
                    Assert.AreEqual(false, docTemplateService.Add(docTemplate));
                    Assert.AreEqual(1, docTemplate.ValidationResults.Count());
                    Assert.IsTrue(docTemplate.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "DocTemplateFileName")).Any());
                    Assert.AreEqual(null, docTemplate.FileName);
                    Assert.AreEqual(count, docTemplateService.GetDocTemplateList().Count());

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.FileName = GetRandomString("", 151);
                    Assert.AreEqual(false, docTemplateService.Add(docTemplate));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "DocTemplateFileName", "150"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, docTemplateService.GetDocTemplateList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // docTemplate.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateDate_UTC = new DateTime();
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "DocTemplateLastUpdateDate_UTC"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);
                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "DocTemplateLastUpdateDate_UTC", "1980"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // docTemplate.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateContactTVItemID = 0;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "DocTemplateLastUpdateContactTVItemID", docTemplate.LastUpdateContactTVItemID.ToString()), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);

                    docTemplate = null;
                    docTemplate = GetFilledRandomDocTemplate("");
                    docTemplate.LastUpdateContactTVItemID = 1;
                    docTemplateService.Add(docTemplate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "DocTemplateLastUpdateContactTVItemID", "Contact"), docTemplate.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    DocTemplate docTemplate = (from c in dbTestDB.DocTemplates select c).FirstOrDefault();
                    Assert.IsNotNull(docTemplate);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        docTemplateService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            DocTemplate docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateID(docTemplate.DocTemplateID);
                            CheckDocTemplateFields(new List<DocTemplate>() { docTemplateRet });
                            Assert.AreEqual(docTemplate.DocTemplateID, docTemplateRet.DocTemplateID);
                        }
                        else if (detail == "A")
                        {
                            DocTemplate_A docTemplate_ARet = docTemplateService.GetDocTemplate_AWithDocTemplateID(docTemplate.DocTemplateID);
                            CheckDocTemplate_AFields(new List<DocTemplate_A>() { docTemplate_ARet });
                            Assert.AreEqual(docTemplate.DocTemplateID, docTemplate_ARet.DocTemplateID);
                        }
                        else if (detail == "B")
                        {
                            DocTemplate_B docTemplate_BRet = docTemplateService.GetDocTemplate_BWithDocTemplateID(docTemplate.DocTemplateID);
                            CheckDocTemplate_BFields(new List<DocTemplate_B>() { docTemplate_BRet });
                            Assert.AreEqual(docTemplate.DocTemplateID, docTemplate_BRet.DocTemplateID);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    DocTemplate docTemplate = (from c in dbTestDB.DocTemplates select c).FirstOrDefault();
                    Assert.IsNotNull(docTemplate);

                    List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                    docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        docTemplateService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<DocTemplate> docTemplateList = new List<DocTemplate>();
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            CheckDocTemplateFields(docTemplateList);
                        }
                        else if (detail == "A")
                        {
                            List<DocTemplate_A> docTemplate_AList = new List<DocTemplate_A>();
                            docTemplate_AList = docTemplateService.GetDocTemplate_AList().ToList();
                            CheckDocTemplate_AFields(docTemplate_AList);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<DocTemplate_B> docTemplate_BList = new List<DocTemplate_B>();
                            docTemplate_BList = docTemplateService.GetDocTemplate_BList().ToList();
                            CheckDocTemplate_BFields(docTemplate_BList);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                        docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<DocTemplate> docTemplateList = new List<DocTemplate>();
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            CheckDocTemplateFields(docTemplateList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        }
                        else if (detail == "A")
                        {
                            List<DocTemplate_A> docTemplate_AList = new List<DocTemplate_A>();
                            docTemplate_AList = docTemplateService.GetDocTemplate_AList().ToList();
                            CheckDocTemplate_AFields(docTemplate_AList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_AList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<DocTemplate_B> docTemplate_BList = new List<DocTemplate_B>();
                            docTemplate_BList = docTemplateService.GetDocTemplate_BList().ToList();
                            CheckDocTemplate_BFields(docTemplate_BList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_BList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1,  "DocTemplateID", "");

                        List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                        docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Skip(1).Take(1).OrderBy(c => c.DocTemplateID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<DocTemplate> docTemplateList = new List<DocTemplate>();
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            CheckDocTemplateFields(docTemplateList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        }
                        else if (detail == "A")
                        {
                            List<DocTemplate_A> docTemplate_AList = new List<DocTemplate_A>();
                            docTemplate_AList = docTemplateService.GetDocTemplate_AList().ToList();
                            CheckDocTemplate_AFields(docTemplate_AList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_AList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<DocTemplate_B> docTemplate_BList = new List<DocTemplate_B>();
                            docTemplate_BList = docTemplateService.GetDocTemplate_BList().ToList();
                            CheckDocTemplate_BFields(docTemplate_BList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_BList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 1, 1, "DocTemplateID,Language", "");

                        List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                        docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Skip(1).Take(1).OrderBy(c => c.DocTemplateID).ThenBy(c => c.Language).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<DocTemplate> docTemplateList = new List<DocTemplate>();
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            CheckDocTemplateFields(docTemplateList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        }
                        else if (detail == "A")
                        {
                            List<DocTemplate_A> docTemplate_AList = new List<DocTemplate_A>();
                            docTemplate_AList = docTemplateService.GetDocTemplate_AList().ToList();
                            CheckDocTemplate_AFields(docTemplate_AList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_AList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<DocTemplate_B> docTemplate_BList = new List<DocTemplate_B>();
                            docTemplate_BList = docTemplateService.GetDocTemplate_BList().ToList();
                            CheckDocTemplate_BFields(docTemplate_BList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_BList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 1, "DocTemplateID", "DocTemplateID,EQ,4", "");

                        List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                        docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Where(c => c.DocTemplateID == 4).Skip(0).Take(1).OrderBy(c => c.DocTemplateID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<DocTemplate> docTemplateList = new List<DocTemplate>();
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            CheckDocTemplateFields(docTemplateList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        }
                        else if (detail == "A")
                        {
                            List<DocTemplate_A> docTemplate_AList = new List<DocTemplate_A>();
                            docTemplate_AList = docTemplateService.GetDocTemplate_AList().ToList();
                            CheckDocTemplate_AFields(docTemplate_AList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_AList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<DocTemplate_B> docTemplate_BList = new List<DocTemplate_B>();
                            docTemplate_BList = docTemplateService.GetDocTemplate_BList().ToList();
                            CheckDocTemplate_BFields(docTemplate_BList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_BList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 1, "DocTemplateID", "DocTemplateID,GT,2|DocTemplateID,LT,5", "");

                        List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                        docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Where(c => c.DocTemplateID > 2 && c.DocTemplateID < 5).Skip(0).Take(1).OrderBy(c => c.DocTemplateID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<DocTemplate> docTemplateList = new List<DocTemplate>();
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            CheckDocTemplateFields(docTemplateList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        }
                        else if (detail == "A")
                        {
                            List<DocTemplate_A> docTemplate_AList = new List<DocTemplate_A>();
                            docTemplate_AList = docTemplateService.GetDocTemplate_AList().ToList();
                            CheckDocTemplate_AFields(docTemplate_AList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_AList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<DocTemplate_B> docTemplate_BList = new List<DocTemplate_B>();
                            docTemplate_BList = docTemplateService.GetDocTemplate_BList().ToList();
                            CheckDocTemplate_BFields(docTemplate_BList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_BList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        DocTemplateService docTemplateService = new DocTemplateService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        docTemplateService.Query = docTemplateService.FillQuery(typeof(DocTemplate), culture.TwoLetterISOLanguageName, 0, 10000, "", "DocTemplateID,GT,2|DocTemplateID,LT,5", "");

                        List<DocTemplate> docTemplateDirectQueryList = new List<DocTemplate>();
                        docTemplateDirectQueryList = (from c in dbTestDB.DocTemplates select c).Where(c => c.DocTemplateID > 2 && c.DocTemplateID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<DocTemplate> docTemplateList = new List<DocTemplate>();
                            docTemplateList = docTemplateService.GetDocTemplateList().ToList();
                            CheckDocTemplateFields(docTemplateList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplateList[0].DocTemplateID);
                        }
                        else if (detail == "A")
                        {
                            List<DocTemplate_A> docTemplate_AList = new List<DocTemplate_A>();
                            docTemplate_AList = docTemplateService.GetDocTemplate_AList().ToList();
                            CheckDocTemplate_AFields(docTemplate_AList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_AList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<DocTemplate_B> docTemplate_BList = new List<DocTemplate_B>();
                            docTemplate_BList = docTemplateService.GetDocTemplate_BList().ToList();
                            CheckDocTemplate_BFields(docTemplate_BList);
                            Assert.AreEqual(docTemplateDirectQueryList[0].DocTemplateID, docTemplate_BList[0].DocTemplateID);
                            Assert.AreEqual(docTemplateDirectQueryList.Count, docTemplate_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetDocTemplateList() 2Where

        #region Functions private
        private void CheckDocTemplateFields(List<DocTemplate> docTemplateList)
        {
            Assert.IsNotNull(docTemplateList[0].DocTemplateID);
            Assert.IsNotNull(docTemplateList[0].Language);
            Assert.IsNotNull(docTemplateList[0].TVType);
            Assert.IsNotNull(docTemplateList[0].TVFileTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplateList[0].FileName));
            Assert.IsNotNull(docTemplateList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(docTemplateList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(docTemplateList[0].HasErrors);
        }
        private void CheckDocTemplate_AFields(List<DocTemplate_A> docTemplate_AList)
        {
            Assert.IsNotNull(docTemplate_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(docTemplate_AList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplate_AList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(docTemplate_AList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplate_AList[0].TVTypeText));
            }
            Assert.IsNotNull(docTemplate_AList[0].DocTemplateID);
            Assert.IsNotNull(docTemplate_AList[0].Language);
            Assert.IsNotNull(docTemplate_AList[0].TVType);
            Assert.IsNotNull(docTemplate_AList[0].TVFileTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplate_AList[0].FileName));
            Assert.IsNotNull(docTemplate_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(docTemplate_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(docTemplate_AList[0].HasErrors);
        }
        private void CheckDocTemplate_BFields(List<DocTemplate_B> docTemplate_BList)
        {
            if (!string.IsNullOrWhiteSpace(docTemplate_BList[0].DocTemplateReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplate_BList[0].DocTemplateReportTest));
            }
            Assert.IsNotNull(docTemplate_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(docTemplate_BList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplate_BList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(docTemplate_BList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplate_BList[0].TVTypeText));
            }
            Assert.IsNotNull(docTemplate_BList[0].DocTemplateID);
            Assert.IsNotNull(docTemplate_BList[0].Language);
            Assert.IsNotNull(docTemplate_BList[0].TVType);
            Assert.IsNotNull(docTemplate_BList[0].TVFileTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(docTemplate_BList[0].FileName));
            Assert.IsNotNull(docTemplate_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(docTemplate_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(docTemplate_BList[0].HasErrors);
        }
        private DocTemplate GetFilledRandomDocTemplate(string OmitPropName)
        {
            DocTemplate docTemplate = new DocTemplate();

            if (OmitPropName != "Language") docTemplate.Language = LanguageRequest;
            if (OmitPropName != "TVType") docTemplate.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVFileTVItemID") docTemplate.TVFileTVItemID = 41;
            if (OmitPropName != "FileName") docTemplate.FileName = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") docTemplate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") docTemplate.LastUpdateContactTVItemID = 2;

            return docTemplate;
        }
        #endregion Functions private
    }
}
