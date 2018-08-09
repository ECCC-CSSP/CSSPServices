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
    public partial class ReportSectionLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ReportSectionLanguageService reportSectionLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportSectionLanguageServiceTest() : base()
        {
            //reportSectionLanguageService = new ReportSectionLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ReportSectionLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ReportSectionLanguage reportSectionLanguage = GetFilledRandomReportSectionLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = reportSectionLanguageService.GetReportSectionLanguageList().Count();

                    Assert.AreEqual(reportSectionLanguageService.GetReportSectionLanguageList().Count(), (from c in dbTestDB.ReportSectionLanguages select c).Take(200).Count());

                    reportSectionLanguageService.Add(reportSectionLanguage);
                    if (reportSectionLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportSectionLanguageService.GetReportSectionLanguageList().Where(c => c == reportSectionLanguage).Any());
                    reportSectionLanguageService.Update(reportSectionLanguage);
                    if (reportSectionLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportSectionLanguageService.GetReportSectionLanguageList().Count());
                    reportSectionLanguageService.Delete(reportSectionLanguage);
                    if (reportSectionLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportSectionLanguageService.GetReportSectionLanguageList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // reportSectionLanguage.ReportSectionLanguageID   (Int32)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionLanguageID = 0;
                    reportSectionLanguageService.Update(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportSectionLanguageReportSectionLanguageID"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionLanguageID = 10000000;
                    reportSectionLanguageService.Update(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportSectionLanguage", "ReportSectionLanguageReportSectionLanguageID", reportSectionLanguage.ReportSectionLanguageID.ToString()), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID", AllowableTVtypeList = )]
                    // reportSectionLanguage.ReportSectionID   (Int32)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionID = 0;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportSection", "ReportSectionLanguageReportSectionID", reportSectionLanguage.ReportSectionID.ToString()), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportSectionLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.Language = (LanguageEnum)1000000;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportSectionLanguageLanguage"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // reportSectionLanguage.ReportSectionName   (String)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("ReportSectionName");
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(1, reportSectionLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportSectionLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ReportSectionLanguageReportSectionName")).Any());
                    Assert.AreEqual(null, reportSectionLanguage.ReportSectionName);
                    Assert.AreEqual(count, reportSectionLanguageService.GetReportSectionLanguageList().Count());

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionName = GetRandomString("", 101);
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportSectionLanguageReportSectionName", "100"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionLanguageService.GetReportSectionLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportSectionLanguage.TranslationStatusReportSectionName   (TranslationStatusEnum)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.TranslationStatusReportSectionName = (TranslationStatusEnum)1000000;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportSectionLanguageTranslationStatusReportSectionName"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(10000))]
                    // reportSectionLanguage.ReportSectionText   (String)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("ReportSectionText");
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(1, reportSectionLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportSectionLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ReportSectionLanguageReportSectionText")).Any());
                    Assert.AreEqual(null, reportSectionLanguage.ReportSectionText);
                    Assert.AreEqual(count, reportSectionLanguageService.GetReportSectionLanguageList().Count());

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionText = GetRandomString("", 10001);
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportSectionLanguageReportSectionText", "10000"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionLanguageService.GetReportSectionLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportSectionLanguage.TranslationStatusReportSectionText   (TranslationStatusEnum)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.TranslationStatusReportSectionText = (TranslationStatusEnum)1000000;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportSectionLanguageTranslationStatusReportSectionText"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // reportSectionLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.LastUpdateDate_UTC = new DateTime();
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportSectionLanguageLastUpdateDate_UTC"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ReportSectionLanguageLastUpdateDate_UTC", "1980"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // reportSectionLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.LastUpdateContactTVItemID = 0;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ReportSectionLanguageLastUpdateContactTVItemID", reportSectionLanguage.LastUpdateContactTVItemID.ToString()), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.LastUpdateContactTVItemID = 1;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ReportSectionLanguageLastUpdateContactTVItemID", "Contact"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportSectionLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportSectionLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetReportSectionLanguageWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID)
        [TestMethod]
        public void GetReportSectionLanguageWithReportSectionLanguageID__reportSectionLanguage_ReportSectionLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportSectionLanguage reportSectionLanguage = (from c in dbTestDB.ReportSectionLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(reportSectionLanguage);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        reportSectionLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            ReportSectionLanguage reportSectionLanguageRet = reportSectionLanguageService.GetReportSectionLanguageWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID);
                            CheckReportSectionLanguageFields(new List<ReportSectionLanguage>() { reportSectionLanguageRet });
                            Assert.AreEqual(reportSectionLanguage.ReportSectionLanguageID, reportSectionLanguageRet.ReportSectionLanguageID);
                        }
                        else if (detail == "A")
                        {
                            ReportSectionLanguage_A reportSectionLanguage_ARet = reportSectionLanguageService.GetReportSectionLanguage_AWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID);
                            CheckReportSectionLanguage_AFields(new List<ReportSectionLanguage_A>() { reportSectionLanguage_ARet });
                            Assert.AreEqual(reportSectionLanguage.ReportSectionLanguageID, reportSectionLanguage_ARet.ReportSectionLanguageID);
                        }
                        else if (detail == "B")
                        {
                            ReportSectionLanguage_B reportSectionLanguage_BRet = reportSectionLanguageService.GetReportSectionLanguage_BWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID);
                            CheckReportSectionLanguage_BFields(new List<ReportSectionLanguage_B>() { reportSectionLanguage_BRet });
                            Assert.AreEqual(reportSectionLanguage.ReportSectionLanguageID, reportSectionLanguage_BRet.ReportSectionLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionLanguageWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID)

        #region Tests Generated for GetReportSectionLanguageList()
        [TestMethod]
        public void GetReportSectionLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportSectionLanguage reportSectionLanguage = (from c in dbTestDB.ReportSectionLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(reportSectionLanguage);

                    List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                    reportSectionLanguageDirectQueryList = (from c in dbTestDB.ReportSectionLanguages select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        reportSectionLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                        }
                        else if (detail == "A")
                        {
                            List<ReportSectionLanguage_A> reportSectionLanguage_AList = new List<ReportSectionLanguage_A>();
                            reportSectionLanguage_AList = reportSectionLanguageService.GetReportSectionLanguage_AList().ToList();
                            CheckReportSectionLanguage_AFields(reportSectionLanguage_AList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ReportSectionLanguage_B> reportSectionLanguage_BList = new List<ReportSectionLanguage_B>();
                            reportSectionLanguage_BList = reportSectionLanguageService.GetReportSectionLanguage_BList().ToList();
                            CheckReportSectionLanguage_BFields(reportSectionLanguage_BList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionLanguageList()

        #region Tests Generated for GetReportSectionLanguageList() Skip Take
        [TestMethod]
        public void GetReportSectionLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = (from c in dbTestDB.ReportSectionLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<ReportSectionLanguage_A> reportSectionLanguage_AList = new List<ReportSectionLanguage_A>();
                            reportSectionLanguage_AList = reportSectionLanguageService.GetReportSectionLanguage_AList().ToList();
                            CheckReportSectionLanguage_AFields(reportSectionLanguage_AList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_AList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ReportSectionLanguage_B> reportSectionLanguage_BList = new List<ReportSectionLanguage_B>();
                            reportSectionLanguage_BList = reportSectionLanguageService.GetReportSectionLanguage_BList().ToList();
                            CheckReportSectionLanguage_BFields(reportSectionLanguage_BList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_BList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionLanguageList() Skip Take

        #region Tests Generated for GetReportSectionLanguageList() Skip Take Order
        [TestMethod]
        public void GetReportSectionLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "ReportSectionLanguageID", "");

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = (from c in dbTestDB.ReportSectionLanguages select c).Skip(1).Take(1).OrderBy(c => c.ReportSectionLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<ReportSectionLanguage_A> reportSectionLanguage_AList = new List<ReportSectionLanguage_A>();
                            reportSectionLanguage_AList = reportSectionLanguageService.GetReportSectionLanguage_AList().ToList();
                            CheckReportSectionLanguage_AFields(reportSectionLanguage_AList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_AList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ReportSectionLanguage_B> reportSectionLanguage_BList = new List<ReportSectionLanguage_B>();
                            reportSectionLanguage_BList = reportSectionLanguageService.GetReportSectionLanguage_BList().ToList();
                            CheckReportSectionLanguage_BFields(reportSectionLanguage_BList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_BList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionLanguageList() Skip Take Order

        #region Tests Generated for GetReportSectionLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetReportSectionLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 1, 1, "ReportSectionLanguageID,ReportSectionID", "");

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = (from c in dbTestDB.ReportSectionLanguages select c).Skip(1).Take(1).OrderBy(c => c.ReportSectionLanguageID).ThenBy(c => c.ReportSectionID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<ReportSectionLanguage_A> reportSectionLanguage_AList = new List<ReportSectionLanguage_A>();
                            reportSectionLanguage_AList = reportSectionLanguageService.GetReportSectionLanguage_AList().ToList();
                            CheckReportSectionLanguage_AFields(reportSectionLanguage_AList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_AList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ReportSectionLanguage_B> reportSectionLanguage_BList = new List<ReportSectionLanguage_B>();
                            reportSectionLanguage_BList = reportSectionLanguageService.GetReportSectionLanguage_BList().ToList();
                            CheckReportSectionLanguage_BFields(reportSectionLanguage_BList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_BList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionLanguageList() Skip Take 2Order

        #region Tests Generated for GetReportSectionLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetReportSectionLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 0, 1, "ReportSectionLanguageID", "ReportSectionLanguageID,EQ,4", "");

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = (from c in dbTestDB.ReportSectionLanguages select c).Where(c => c.ReportSectionLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.ReportSectionLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<ReportSectionLanguage_A> reportSectionLanguage_AList = new List<ReportSectionLanguage_A>();
                            reportSectionLanguage_AList = reportSectionLanguageService.GetReportSectionLanguage_AList().ToList();
                            CheckReportSectionLanguage_AFields(reportSectionLanguage_AList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_AList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ReportSectionLanguage_B> reportSectionLanguage_BList = new List<ReportSectionLanguage_B>();
                            reportSectionLanguage_BList = reportSectionLanguageService.GetReportSectionLanguage_BList().ToList();
                            CheckReportSectionLanguage_BFields(reportSectionLanguage_BList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_BList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionLanguageList() Skip Take Order Where

        #region Tests Generated for GetReportSectionLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetReportSectionLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 0, 1, "ReportSectionLanguageID", "ReportSectionLanguageID,GT,2|ReportSectionLanguageID,LT,5", "");

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = (from c in dbTestDB.ReportSectionLanguages select c).Where(c => c.ReportSectionLanguageID > 2 && c.ReportSectionLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.ReportSectionLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<ReportSectionLanguage_A> reportSectionLanguage_AList = new List<ReportSectionLanguage_A>();
                            reportSectionLanguage_AList = reportSectionLanguageService.GetReportSectionLanguage_AList().ToList();
                            CheckReportSectionLanguage_AFields(reportSectionLanguage_AList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_AList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ReportSectionLanguage_B> reportSectionLanguage_BList = new List<ReportSectionLanguage_B>();
                            reportSectionLanguage_BList = reportSectionLanguageService.GetReportSectionLanguage_BList().ToList();
                            CheckReportSectionLanguage_BFields(reportSectionLanguage_BList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_BList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetReportSectionLanguageList() 2Where
        [TestMethod]
        public void GetReportSectionLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "ReportSectionLanguageID,GT,2|ReportSectionLanguageID,LT,5", "");

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = (from c in dbTestDB.ReportSectionLanguages select c).Where(c => c.ReportSectionLanguageID > 2 && c.ReportSectionLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                        }
                        else if (detail == "A")
                        {
                            List<ReportSectionLanguage_A> reportSectionLanguage_AList = new List<ReportSectionLanguage_A>();
                            reportSectionLanguage_AList = reportSectionLanguageService.GetReportSectionLanguage_AList().ToList();
                            CheckReportSectionLanguage_AFields(reportSectionLanguage_AList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_AList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ReportSectionLanguage_B> reportSectionLanguage_BList = new List<ReportSectionLanguage_B>();
                            reportSectionLanguage_BList = reportSectionLanguageService.GetReportSectionLanguage_BList().ToList();
                            CheckReportSectionLanguage_BFields(reportSectionLanguage_BList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguage_BList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguage_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionLanguageList() 2Where

        #region Functions private
        private void CheckReportSectionLanguageFields(List<ReportSectionLanguage> reportSectionLanguageList)
        {
            Assert.IsNotNull(reportSectionLanguageList[0].ReportSectionLanguageID);
            Assert.IsNotNull(reportSectionLanguageList[0].ReportSectionID);
            Assert.IsNotNull(reportSectionLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageList[0].ReportSectionName));
            Assert.IsNotNull(reportSectionLanguageList[0].TranslationStatusReportSectionName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageList[0].ReportSectionText));
            Assert.IsNotNull(reportSectionLanguageList[0].TranslationStatusReportSectionText);
            Assert.IsNotNull(reportSectionLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportSectionLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportSectionLanguageList[0].HasErrors);
        }
        private void CheckReportSectionLanguage_AFields(List<ReportSectionLanguage_A> reportSectionLanguage_AList)
        {
            Assert.IsNotNull(reportSectionLanguage_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(reportSectionLanguage_AList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_AList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(reportSectionLanguage_AList[0].TranslationStatusReportSectionNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_AList[0].TranslationStatusReportSectionNameText));
            }
            if (!string.IsNullOrWhiteSpace(reportSectionLanguage_AList[0].TranslationStatusReportSectionNameTextText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_AList[0].TranslationStatusReportSectionNameTextText));
            }
            Assert.IsNotNull(reportSectionLanguage_AList[0].ReportSectionLanguageID);
            Assert.IsNotNull(reportSectionLanguage_AList[0].ReportSectionID);
            Assert.IsNotNull(reportSectionLanguage_AList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_AList[0].ReportSectionName));
            Assert.IsNotNull(reportSectionLanguage_AList[0].TranslationStatusReportSectionName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_AList[0].ReportSectionText));
            Assert.IsNotNull(reportSectionLanguage_AList[0].TranslationStatusReportSectionText);
            Assert.IsNotNull(reportSectionLanguage_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportSectionLanguage_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportSectionLanguage_AList[0].HasErrors);
        }
        private void CheckReportSectionLanguage_BFields(List<ReportSectionLanguage_B> reportSectionLanguage_BList)
        {
            if (!string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].ReportSectionLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].ReportSectionLanguageReportTest));
            }
            Assert.IsNotNull(reportSectionLanguage_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].TranslationStatusReportSectionNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].TranslationStatusReportSectionNameText));
            }
            if (!string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].TranslationStatusReportSectionNameTextText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].TranslationStatusReportSectionNameTextText));
            }
            Assert.IsNotNull(reportSectionLanguage_BList[0].ReportSectionLanguageID);
            Assert.IsNotNull(reportSectionLanguage_BList[0].ReportSectionID);
            Assert.IsNotNull(reportSectionLanguage_BList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].ReportSectionName));
            Assert.IsNotNull(reportSectionLanguage_BList[0].TranslationStatusReportSectionName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguage_BList[0].ReportSectionText));
            Assert.IsNotNull(reportSectionLanguage_BList[0].TranslationStatusReportSectionText);
            Assert.IsNotNull(reportSectionLanguage_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportSectionLanguage_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportSectionLanguage_BList[0].HasErrors);
        }
        private ReportSectionLanguage GetFilledRandomReportSectionLanguage(string OmitPropName)
        {
            ReportSectionLanguage reportSectionLanguage = new ReportSectionLanguage();

            if (OmitPropName != "ReportSectionID") reportSectionLanguage.ReportSectionID = 1;
            if (OmitPropName != "Language") reportSectionLanguage.Language = LanguageRequest;
            if (OmitPropName != "ReportSectionName") reportSectionLanguage.ReportSectionName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusReportSectionName") reportSectionLanguage.TranslationStatusReportSectionName = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "ReportSectionText") reportSectionLanguage.ReportSectionText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusReportSectionText") reportSectionLanguage.TranslationStatusReportSectionText = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") reportSectionLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportSectionLanguage.LastUpdateContactTVItemID = 2;

            return reportSectionLanguage;
        }
        #endregion Functions private
    }
}
