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

                    count = reportSectionLanguageService.GetRead().Count();

                    Assert.AreEqual(reportSectionLanguageService.GetRead().Count(), reportSectionLanguageService.GetEdit().Count());

                    reportSectionLanguageService.Add(reportSectionLanguage);
                    if (reportSectionLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportSectionLanguageService.GetRead().Where(c => c == reportSectionLanguage).Any());
                    reportSectionLanguageService.Update(reportSectionLanguage);
                    if (reportSectionLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportSectionLanguageService.GetRead().Count());
                    reportSectionLanguageService.Delete(reportSectionLanguage);
                    if (reportSectionLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

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
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionName = GetRandomString("", 101);
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportSectionLanguageReportSectionName", "100"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

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
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionText = GetRandomString("", 10001);
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportSectionLanguageReportSectionText", "10000"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

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
                    ReportSectionLanguage reportSectionLanguage = (from c in reportSectionLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportSectionLanguage);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportSectionLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ReportSectionLanguage reportSectionLanguageRet = reportSectionLanguageService.GetReportSectionLanguageWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID);
                            CheckReportSectionLanguageFields(new List<ReportSectionLanguage>() { reportSectionLanguageRet });
                            Assert.AreEqual(reportSectionLanguage.ReportSectionLanguageID, reportSectionLanguageRet.ReportSectionLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ReportSectionLanguageWeb reportSectionLanguageWebRet = reportSectionLanguageService.GetReportSectionLanguageWebWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID);
                            CheckReportSectionLanguageWebFields(new List<ReportSectionLanguageWeb>() { reportSectionLanguageWebRet });
                            Assert.AreEqual(reportSectionLanguage.ReportSectionLanguageID, reportSectionLanguageWebRet.ReportSectionLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ReportSectionLanguageReport reportSectionLanguageReportRet = reportSectionLanguageService.GetReportSectionLanguageReportWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID);
                            CheckReportSectionLanguageReportFields(new List<ReportSectionLanguageReport>() { reportSectionLanguageReportRet });
                            Assert.AreEqual(reportSectionLanguage.ReportSectionLanguageID, reportSectionLanguageReportRet.ReportSectionLanguageID);
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
                    ReportSectionLanguage reportSectionLanguage = (from c in reportSectionLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportSectionLanguage);

                    List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                    reportSectionLanguageDirectQueryList = reportSectionLanguageService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportSectionLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionLanguageWeb> reportSectionLanguageWebList = new List<ReportSectionLanguageWeb>();
                            reportSectionLanguageWebList = reportSectionLanguageService.GetReportSectionLanguageWebList().ToList();
                            CheckReportSectionLanguageWebFields(reportSectionLanguageWebList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionLanguageReport> reportSectionLanguageReportList = new List<ReportSectionLanguageReport>();
                            reportSectionLanguageReportList = reportSectionLanguageService.GetReportSectionLanguageReportList().ToList();
                            CheckReportSectionLanguageReportFields(reportSectionLanguageReportList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageReportList.Count);
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = reportSectionLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionLanguageWeb> reportSectionLanguageWebList = new List<ReportSectionLanguageWeb>();
                            reportSectionLanguageWebList = reportSectionLanguageService.GetReportSectionLanguageWebList().ToList();
                            CheckReportSectionLanguageWebFields(reportSectionLanguageWebList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageWebList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionLanguageReport> reportSectionLanguageReportList = new List<ReportSectionLanguageReport>();
                            reportSectionLanguageReportList = reportSectionLanguageService.GetReportSectionLanguageReportList().ToList();
                            CheckReportSectionLanguageReportFields(reportSectionLanguageReportList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageReportList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageReportList.Count);
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "ReportSectionLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = reportSectionLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.ReportSectionLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionLanguageWeb> reportSectionLanguageWebList = new List<ReportSectionLanguageWeb>();
                            reportSectionLanguageWebList = reportSectionLanguageService.GetReportSectionLanguageWebList().ToList();
                            CheckReportSectionLanguageWebFields(reportSectionLanguageWebList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageWebList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionLanguageReport> reportSectionLanguageReportList = new List<ReportSectionLanguageReport>();
                            reportSectionLanguageReportList = reportSectionLanguageService.GetReportSectionLanguageReportList().ToList();
                            CheckReportSectionLanguageReportFields(reportSectionLanguageReportList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageReportList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageReportList.Count);
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 1, 1, "ReportSectionLanguageID,ReportSectionID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = reportSectionLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.ReportSectionLanguageID).ThenBy(c => c.ReportSectionID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionLanguageWeb> reportSectionLanguageWebList = new List<ReportSectionLanguageWeb>();
                            reportSectionLanguageWebList = reportSectionLanguageService.GetReportSectionLanguageWebList().ToList();
                            CheckReportSectionLanguageWebFields(reportSectionLanguageWebList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageWebList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionLanguageReport> reportSectionLanguageReportList = new List<ReportSectionLanguageReport>();
                            reportSectionLanguageReportList = reportSectionLanguageService.GetReportSectionLanguageReportList().ToList();
                            CheckReportSectionLanguageReportFields(reportSectionLanguageReportList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageReportList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageReportList.Count);
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 0, 1, "ReportSectionLanguageID", "ReportSectionLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = reportSectionLanguageService.GetRead().Where(c => c.ReportSectionLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.ReportSectionLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionLanguageWeb> reportSectionLanguageWebList = new List<ReportSectionLanguageWeb>();
                            reportSectionLanguageWebList = reportSectionLanguageService.GetReportSectionLanguageWebList().ToList();
                            CheckReportSectionLanguageWebFields(reportSectionLanguageWebList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageWebList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionLanguageReport> reportSectionLanguageReportList = new List<ReportSectionLanguageReport>();
                            reportSectionLanguageReportList = reportSectionLanguageService.GetReportSectionLanguageReportList().ToList();
                            CheckReportSectionLanguageReportFields(reportSectionLanguageReportList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageReportList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageReportList.Count);
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 0, 1, "ReportSectionLanguageID", "ReportSectionLanguageID,GT,2|ReportSectionLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = reportSectionLanguageService.GetRead().Where(c => c.ReportSectionLanguageID > 2 && c.ReportSectionLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.ReportSectionLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionLanguageWeb> reportSectionLanguageWebList = new List<ReportSectionLanguageWeb>();
                            reportSectionLanguageWebList = reportSectionLanguageService.GetReportSectionLanguageWebList().ToList();
                            CheckReportSectionLanguageWebFields(reportSectionLanguageWebList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageWebList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionLanguageReport> reportSectionLanguageReportList = new List<ReportSectionLanguageReport>();
                            reportSectionLanguageReportList = reportSectionLanguageService.GetReportSectionLanguageReportList().ToList();
                            CheckReportSectionLanguageReportFields(reportSectionLanguageReportList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageReportList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageReportList.Count);
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionLanguageService.Query = reportSectionLanguageService.FillQuery(typeof(ReportSectionLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "ReportSectionLanguageID,GT,2|ReportSectionLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSectionLanguage> reportSectionLanguageDirectQueryList = new List<ReportSectionLanguage>();
                        reportSectionLanguageDirectQueryList = reportSectionLanguageService.GetRead().Where(c => c.ReportSectionLanguageID > 2 && c.ReportSectionLanguageID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSectionLanguage> reportSectionLanguageList = new List<ReportSectionLanguage>();
                            reportSectionLanguageList = reportSectionLanguageService.GetReportSectionLanguageList().ToList();
                            CheckReportSectionLanguageFields(reportSectionLanguageList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionLanguageWeb> reportSectionLanguageWebList = new List<ReportSectionLanguageWeb>();
                            reportSectionLanguageWebList = reportSectionLanguageService.GetReportSectionLanguageWebList().ToList();
                            CheckReportSectionLanguageWebFields(reportSectionLanguageWebList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageWebList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionLanguageReport> reportSectionLanguageReportList = new List<ReportSectionLanguageReport>();
                            reportSectionLanguageReportList = reportSectionLanguageService.GetReportSectionLanguageReportList().ToList();
                            CheckReportSectionLanguageReportFields(reportSectionLanguageReportList);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList[0].ReportSectionLanguageID, reportSectionLanguageReportList[0].ReportSectionLanguageID);
                            Assert.AreEqual(reportSectionLanguageDirectQueryList.Count, reportSectionLanguageReportList.Count);
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
        private void CheckReportSectionLanguageWebFields(List<ReportSectionLanguageWeb> reportSectionLanguageWebList)
        {
            Assert.IsNotNull(reportSectionLanguageWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(reportSectionLanguageWebList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageWebList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(reportSectionLanguageWebList[0].TranslationStatusReportSectionNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageWebList[0].TranslationStatusReportSectionNameText));
            }
            if (!string.IsNullOrWhiteSpace(reportSectionLanguageWebList[0].TranslationStatusReportSectionNameTextText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageWebList[0].TranslationStatusReportSectionNameTextText));
            }
            Assert.IsNotNull(reportSectionLanguageWebList[0].ReportSectionLanguageID);
            Assert.IsNotNull(reportSectionLanguageWebList[0].ReportSectionID);
            Assert.IsNotNull(reportSectionLanguageWebList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageWebList[0].ReportSectionName));
            Assert.IsNotNull(reportSectionLanguageWebList[0].TranslationStatusReportSectionName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageWebList[0].ReportSectionText));
            Assert.IsNotNull(reportSectionLanguageWebList[0].TranslationStatusReportSectionText);
            Assert.IsNotNull(reportSectionLanguageWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportSectionLanguageWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportSectionLanguageWebList[0].HasErrors);
        }
        private void CheckReportSectionLanguageReportFields(List<ReportSectionLanguageReport> reportSectionLanguageReportList)
        {
            if (!string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].ReportSectionLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].ReportSectionLanguageReportTest));
            }
            Assert.IsNotNull(reportSectionLanguageReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].TranslationStatusReportSectionNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].TranslationStatusReportSectionNameText));
            }
            if (!string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].TranslationStatusReportSectionNameTextText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].TranslationStatusReportSectionNameTextText));
            }
            Assert.IsNotNull(reportSectionLanguageReportList[0].ReportSectionLanguageID);
            Assert.IsNotNull(reportSectionLanguageReportList[0].ReportSectionID);
            Assert.IsNotNull(reportSectionLanguageReportList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].ReportSectionName));
            Assert.IsNotNull(reportSectionLanguageReportList[0].TranslationStatusReportSectionName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageReportList[0].ReportSectionText));
            Assert.IsNotNull(reportSectionLanguageReportList[0].TranslationStatusReportSectionText);
            Assert.IsNotNull(reportSectionLanguageReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportSectionLanguageReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportSectionLanguageReportList[0].HasErrors);
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
