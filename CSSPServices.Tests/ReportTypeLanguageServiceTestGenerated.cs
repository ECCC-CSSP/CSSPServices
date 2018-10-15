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
    public partial class ReportTypeLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ReportTypeLanguageService reportTypeLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeLanguageServiceTest() : base()
        {
            //reportTypeLanguageService = new ReportTypeLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ReportTypeLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ReportTypeLanguage reportTypeLanguage = GetFilledRandomReportTypeLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = reportTypeLanguageService.GetReportTypeLanguageList().Count();

                    Assert.AreEqual(reportTypeLanguageService.GetReportTypeLanguageList().Count(), (from c in dbTestDB.ReportTypeLanguages select c).Take(200).Count());

                    reportTypeLanguageService.Add(reportTypeLanguage);
                    if (reportTypeLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportTypeLanguageService.GetReportTypeLanguageList().Where(c => c == reportTypeLanguage).Any());
                    reportTypeLanguageService.Update(reportTypeLanguage);
                    if (reportTypeLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportTypeLanguageService.GetReportTypeLanguageList().Count());
                    reportTypeLanguageService.Delete(reportTypeLanguage);
                    if (reportTypeLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportTypeLanguageService.GetReportTypeLanguageList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // reportTypeLanguage.ReportTypeLanguageID   (Int32)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeLanguageID = 0;
                    reportTypeLanguageService.Update(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeLanguageReportTypeLanguageID"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeLanguageID = 10000000;
                    reportTypeLanguageService.Update(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportTypeLanguage", "ReportTypeLanguageReportTypeLanguageID", reportTypeLanguage.ReportTypeLanguageID.ToString()), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID", AllowableTVtypeList = )]
                    // reportTypeLanguage.ReportTypeID   (Int32)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeID = 0;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeLanguageReportTypeID", reportTypeLanguage.ReportTypeID.ToString()), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportTypeLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.Language = (LanguageEnum)1000000;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeLanguageLanguage"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // reportTypeLanguage.Name   (String)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("Name");
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(1, reportTypeLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportTypeLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ReportTypeLanguageName")).Any());
                    Assert.AreEqual(null, reportTypeLanguage.Name);
                    Assert.AreEqual(count, reportTypeLanguageService.GetReportTypeLanguageList().Count());

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.Name = GetRandomString("", 101);
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportTypeLanguageName", "100"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeLanguageService.GetReportTypeLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportTypeLanguage.TranslationStatusName   (TranslationStatusEnum)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.TranslationStatusName = (TranslationStatusEnum)1000000;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeLanguageTranslationStatusName"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(1000))]
                    // reportTypeLanguage.Description   (String)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("Description");
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(1, reportTypeLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportTypeLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ReportTypeLanguageDescription")).Any());
                    Assert.AreEqual(null, reportTypeLanguage.Description);
                    Assert.AreEqual(count, reportTypeLanguageService.GetReportTypeLanguageList().Count());

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.Description = GetRandomString("", 1001);
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportTypeLanguageDescription", "1000"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeLanguageService.GetReportTypeLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportTypeLanguage.TranslationStatusDescription   (TranslationStatusEnum)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.TranslationStatusDescription = (TranslationStatusEnum)1000000;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeLanguageTranslationStatusDescription"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // reportTypeLanguage.StartOfFileName   (String)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("StartOfFileName");
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(1, reportTypeLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportTypeLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ReportTypeLanguageStartOfFileName")).Any());
                    Assert.AreEqual(null, reportTypeLanguage.StartOfFileName);
                    Assert.AreEqual(count, reportTypeLanguageService.GetReportTypeLanguageList().Count());

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.StartOfFileName = GetRandomString("", 101);
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportTypeLanguageStartOfFileName", "100"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeLanguageService.GetReportTypeLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportTypeLanguage.TranslationStatusStartOfFileName   (TranslationStatusEnum)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.TranslationStatusStartOfFileName = (TranslationStatusEnum)1000000;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeLanguageTranslationStatusStartOfFileName"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // reportTypeLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.LastUpdateDate_UTC = new DateTime();
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeLanguageLastUpdateDate_UTC"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ReportTypeLanguageLastUpdateDate_UTC", "1980"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // reportTypeLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.LastUpdateContactTVItemID = 0;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ReportTypeLanguageLastUpdateContactTVItemID", reportTypeLanguage.LastUpdateContactTVItemID.ToString()), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.LastUpdateContactTVItemID = 1;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ReportTypeLanguageLastUpdateContactTVItemID", "Contact"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportTypeLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportTypeLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetReportTypeLanguageWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID)
        [TestMethod]
        public void GetReportTypeLanguageWithReportTypeLanguageID__reportTypeLanguage_ReportTypeLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportTypeLanguage reportTypeLanguage = (from c in dbTestDB.ReportTypeLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(reportTypeLanguage);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        reportTypeLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            ReportTypeLanguage reportTypeLanguageRet = reportTypeLanguageService.GetReportTypeLanguageWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID);
                            CheckReportTypeLanguageFields(new List<ReportTypeLanguage>() { reportTypeLanguageRet });
                            Assert.AreEqual(reportTypeLanguage.ReportTypeLanguageID, reportTypeLanguageRet.ReportTypeLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            ReportTypeLanguageExtraA reportTypeLanguageExtraARet = reportTypeLanguageService.GetReportTypeLanguageExtraAWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID);
                            CheckReportTypeLanguageExtraAFields(new List<ReportTypeLanguageExtraA>() { reportTypeLanguageExtraARet });
                            Assert.AreEqual(reportTypeLanguage.ReportTypeLanguageID, reportTypeLanguageExtraARet.ReportTypeLanguageID);
                        }
                        else if (detail == "ExtraB")
                        {
                            ReportTypeLanguageExtraB reportTypeLanguageExtraBRet = reportTypeLanguageService.GetReportTypeLanguageExtraBWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID);
                            CheckReportTypeLanguageExtraBFields(new List<ReportTypeLanguageExtraB>() { reportTypeLanguageExtraBRet });
                            Assert.AreEqual(reportTypeLanguage.ReportTypeLanguageID, reportTypeLanguageExtraBRet.ReportTypeLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeLanguageWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID)

        #region Tests Generated for GetReportTypeLanguageList()
        [TestMethod]
        public void GetReportTypeLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportTypeLanguage reportTypeLanguage = (from c in dbTestDB.ReportTypeLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(reportTypeLanguage);

                    List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                    reportTypeLanguageDirectQueryList = (from c in dbTestDB.ReportTypeLanguages select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        reportTypeLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ReportTypeLanguageExtraA> reportTypeLanguageExtraAList = new List<ReportTypeLanguageExtraA>();
                            reportTypeLanguageExtraAList = reportTypeLanguageService.GetReportTypeLanguageExtraAList().ToList();
                            CheckReportTypeLanguageExtraAFields(reportTypeLanguageExtraAList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ReportTypeLanguageExtraB> reportTypeLanguageExtraBList = new List<ReportTypeLanguageExtraB>();
                            reportTypeLanguageExtraBList = reportTypeLanguageService.GetReportTypeLanguageExtraBList().ToList();
                            CheckReportTypeLanguageExtraBFields(reportTypeLanguageExtraBList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeLanguageList()

        #region Tests Generated for GetReportTypeLanguageList() Skip Take
        [TestMethod]
        public void GetReportTypeLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = (from c in dbTestDB.ReportTypeLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ReportTypeLanguageExtraA> reportTypeLanguageExtraAList = new List<ReportTypeLanguageExtraA>();
                            reportTypeLanguageExtraAList = reportTypeLanguageService.GetReportTypeLanguageExtraAList().ToList();
                            CheckReportTypeLanguageExtraAFields(reportTypeLanguageExtraAList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraAList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ReportTypeLanguageExtraB> reportTypeLanguageExtraBList = new List<ReportTypeLanguageExtraB>();
                            reportTypeLanguageExtraBList = reportTypeLanguageService.GetReportTypeLanguageExtraBList().ToList();
                            CheckReportTypeLanguageExtraBFields(reportTypeLanguageExtraBList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraBList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeLanguageList() Skip Take

        #region Tests Generated for GetReportTypeLanguageList() Skip Take Order
        [TestMethod]
        public void GetReportTypeLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "ReportTypeLanguageID", "");

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = (from c in dbTestDB.ReportTypeLanguages select c).Skip(1).Take(1).OrderBy(c => c.ReportTypeLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ReportTypeLanguageExtraA> reportTypeLanguageExtraAList = new List<ReportTypeLanguageExtraA>();
                            reportTypeLanguageExtraAList = reportTypeLanguageService.GetReportTypeLanguageExtraAList().ToList();
                            CheckReportTypeLanguageExtraAFields(reportTypeLanguageExtraAList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraAList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ReportTypeLanguageExtraB> reportTypeLanguageExtraBList = new List<ReportTypeLanguageExtraB>();
                            reportTypeLanguageExtraBList = reportTypeLanguageService.GetReportTypeLanguageExtraBList().ToList();
                            CheckReportTypeLanguageExtraBFields(reportTypeLanguageExtraBList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraBList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeLanguageList() Skip Take Order

        #region Tests Generated for GetReportTypeLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetReportTypeLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 1, 1, "ReportTypeLanguageID,ReportTypeID", "");

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = (from c in dbTestDB.ReportTypeLanguages select c).Skip(1).Take(1).OrderBy(c => c.ReportTypeLanguageID).ThenBy(c => c.ReportTypeID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ReportTypeLanguageExtraA> reportTypeLanguageExtraAList = new List<ReportTypeLanguageExtraA>();
                            reportTypeLanguageExtraAList = reportTypeLanguageService.GetReportTypeLanguageExtraAList().ToList();
                            CheckReportTypeLanguageExtraAFields(reportTypeLanguageExtraAList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraAList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ReportTypeLanguageExtraB> reportTypeLanguageExtraBList = new List<ReportTypeLanguageExtraB>();
                            reportTypeLanguageExtraBList = reportTypeLanguageService.GetReportTypeLanguageExtraBList().ToList();
                            CheckReportTypeLanguageExtraBFields(reportTypeLanguageExtraBList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraBList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeLanguageList() Skip Take 2Order

        #region Tests Generated for GetReportTypeLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetReportTypeLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 0, 1, "ReportTypeLanguageID", "ReportTypeLanguageID,EQ,4", "");

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = (from c in dbTestDB.ReportTypeLanguages select c).Where(c => c.ReportTypeLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.ReportTypeLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ReportTypeLanguageExtraA> reportTypeLanguageExtraAList = new List<ReportTypeLanguageExtraA>();
                            reportTypeLanguageExtraAList = reportTypeLanguageService.GetReportTypeLanguageExtraAList().ToList();
                            CheckReportTypeLanguageExtraAFields(reportTypeLanguageExtraAList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraAList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ReportTypeLanguageExtraB> reportTypeLanguageExtraBList = new List<ReportTypeLanguageExtraB>();
                            reportTypeLanguageExtraBList = reportTypeLanguageService.GetReportTypeLanguageExtraBList().ToList();
                            CheckReportTypeLanguageExtraBFields(reportTypeLanguageExtraBList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraBList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeLanguageList() Skip Take Order Where

        #region Tests Generated for GetReportTypeLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetReportTypeLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 0, 1, "ReportTypeLanguageID", "ReportTypeLanguageID,GT,2|ReportTypeLanguageID,LT,5", "");

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = (from c in dbTestDB.ReportTypeLanguages select c).Where(c => c.ReportTypeLanguageID > 2 && c.ReportTypeLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.ReportTypeLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ReportTypeLanguageExtraA> reportTypeLanguageExtraAList = new List<ReportTypeLanguageExtraA>();
                            reportTypeLanguageExtraAList = reportTypeLanguageService.GetReportTypeLanguageExtraAList().ToList();
                            CheckReportTypeLanguageExtraAFields(reportTypeLanguageExtraAList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraAList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ReportTypeLanguageExtraB> reportTypeLanguageExtraBList = new List<ReportTypeLanguageExtraB>();
                            reportTypeLanguageExtraBList = reportTypeLanguageService.GetReportTypeLanguageExtraBList().ToList();
                            CheckReportTypeLanguageExtraBFields(reportTypeLanguageExtraBList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraBList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetReportTypeLanguageList() 2Where
        [TestMethod]
        public void GetReportTypeLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "ReportTypeLanguageID,GT,2|ReportTypeLanguageID,LT,5", "");

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = (from c in dbTestDB.ReportTypeLanguages select c).Where(c => c.ReportTypeLanguageID > 2 && c.ReportTypeLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ReportTypeLanguageExtraA> reportTypeLanguageExtraAList = new List<ReportTypeLanguageExtraA>();
                            reportTypeLanguageExtraAList = reportTypeLanguageService.GetReportTypeLanguageExtraAList().ToList();
                            CheckReportTypeLanguageExtraAFields(reportTypeLanguageExtraAList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraAList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ReportTypeLanguageExtraB> reportTypeLanguageExtraBList = new List<ReportTypeLanguageExtraB>();
                            reportTypeLanguageExtraBList = reportTypeLanguageService.GetReportTypeLanguageExtraBList().ToList();
                            CheckReportTypeLanguageExtraBFields(reportTypeLanguageExtraBList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageExtraBList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeLanguageList() 2Where

        #region Functions private
        private void CheckReportTypeLanguageFields(List<ReportTypeLanguage> reportTypeLanguageList)
        {
            Assert.IsNotNull(reportTypeLanguageList[0].ReportTypeLanguageID);
            Assert.IsNotNull(reportTypeLanguageList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageList[0].Name));
            Assert.IsNotNull(reportTypeLanguageList[0].TranslationStatusName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageList[0].Description));
            Assert.IsNotNull(reportTypeLanguageList[0].TranslationStatusDescription);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageList[0].StartOfFileName));
            Assert.IsNotNull(reportTypeLanguageList[0].TranslationStatusStartOfFileName);
            Assert.IsNotNull(reportTypeLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeLanguageList[0].HasErrors);
        }
        private void CheckReportTypeLanguageExtraAFields(List<ReportTypeLanguageExtraA> reportTypeLanguageExtraAList)
        {
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].TranslationStatusNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].TranslationStatusNameText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].TranslationStatusDescriptionText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].TranslationStatusDescriptionText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].TranslationStatusStartOfFileNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].TranslationStatusStartOfFileNameText));
            }
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].ReportTypeLanguageID);
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].Name));
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].TranslationStatusName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].Description));
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].TranslationStatusDescription);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraAList[0].StartOfFileName));
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].TranslationStatusStartOfFileName);
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeLanguageExtraAList[0].HasErrors);
        }
        private void CheckReportTypeLanguageExtraBFields(List<ReportTypeLanguageExtraB> reportTypeLanguageExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].ReportTypeLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].ReportTypeLanguageReportTest));
            }
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].TranslationStatusNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].TranslationStatusNameText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].TranslationStatusDescriptionText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].TranslationStatusDescriptionText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].TranslationStatusStartOfFileNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].TranslationStatusStartOfFileNameText));
            }
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].ReportTypeLanguageID);
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].Name));
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].TranslationStatusName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].Description));
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].TranslationStatusDescription);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageExtraBList[0].StartOfFileName));
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].TranslationStatusStartOfFileName);
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeLanguageExtraBList[0].HasErrors);
        }
        private ReportTypeLanguage GetFilledRandomReportTypeLanguage(string OmitPropName)
        {
            ReportTypeLanguage reportTypeLanguage = new ReportTypeLanguage();

            if (OmitPropName != "ReportTypeID") reportTypeLanguage.ReportTypeID = 1;
            if (OmitPropName != "Language") reportTypeLanguage.Language = LanguageRequest;
            if (OmitPropName != "Name") reportTypeLanguage.Name = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusName") reportTypeLanguage.TranslationStatusName = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Description") reportTypeLanguage.Description = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusDescription") reportTypeLanguage.TranslationStatusDescription = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "StartOfFileName") reportTypeLanguage.StartOfFileName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusStartOfFileName") reportTypeLanguage.TranslationStatusStartOfFileName = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") reportTypeLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportTypeLanguage.LastUpdateContactTVItemID = 2;

            return reportTypeLanguage;
        }
        #endregion Functions private
    }
}
