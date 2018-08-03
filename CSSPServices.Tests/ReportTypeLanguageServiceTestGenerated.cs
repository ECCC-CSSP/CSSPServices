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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = reportTypeLanguageService.GetRead().Count();

                    Assert.AreEqual(reportTypeLanguageService.GetRead().Count(), reportTypeLanguageService.GetEdit().Count());

                    reportTypeLanguageService.Add(reportTypeLanguage);
                    if (reportTypeLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportTypeLanguageService.GetRead().Where(c => c == reportTypeLanguage).Any());
                    reportTypeLanguageService.Update(reportTypeLanguage);
                    if (reportTypeLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportTypeLanguageService.GetRead().Count());
                    reportTypeLanguageService.Delete(reportTypeLanguage);
                    if (reportTypeLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

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
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.Name = GetRandomString("", 101);
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportTypeLanguageName", "100"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

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
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.Description = GetRandomString("", 1001);
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportTypeLanguageDescription", "1000"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

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
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.StartOfFileName = GetRandomString("", 101);
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportTypeLanguageStartOfFileName", "100"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportTypeLanguage reportTypeLanguage = (from c in reportTypeLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportTypeLanguage);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportTypeLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ReportTypeLanguage reportTypeLanguageRet = reportTypeLanguageService.GetReportTypeLanguageWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID);
                            CheckReportTypeLanguageFields(new List<ReportTypeLanguage>() { reportTypeLanguageRet });
                            Assert.AreEqual(reportTypeLanguage.ReportTypeLanguageID, reportTypeLanguageRet.ReportTypeLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ReportTypeLanguageWeb reportTypeLanguageWebRet = reportTypeLanguageService.GetReportTypeLanguageWebWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID);
                            CheckReportTypeLanguageWebFields(new List<ReportTypeLanguageWeb>() { reportTypeLanguageWebRet });
                            Assert.AreEqual(reportTypeLanguage.ReportTypeLanguageID, reportTypeLanguageWebRet.ReportTypeLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ReportTypeLanguageReport reportTypeLanguageReportRet = reportTypeLanguageService.GetReportTypeLanguageReportWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID);
                            CheckReportTypeLanguageReportFields(new List<ReportTypeLanguageReport>() { reportTypeLanguageReportRet });
                            Assert.AreEqual(reportTypeLanguage.ReportTypeLanguageID, reportTypeLanguageReportRet.ReportTypeLanguageID);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportTypeLanguage reportTypeLanguage = (from c in reportTypeLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportTypeLanguage);

                    List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                    reportTypeLanguageDirectQueryList = reportTypeLanguageService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportTypeLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeLanguageWeb> reportTypeLanguageWebList = new List<ReportTypeLanguageWeb>();
                            reportTypeLanguageWebList = reportTypeLanguageService.GetReportTypeLanguageWebList().ToList();
                            CheckReportTypeLanguageWebFields(reportTypeLanguageWebList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeLanguageReport> reportTypeLanguageReportList = new List<ReportTypeLanguageReport>();
                            reportTypeLanguageReportList = reportTypeLanguageService.GetReportTypeLanguageReportList().ToList();
                            CheckReportTypeLanguageReportFields(reportTypeLanguageReportList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = reportTypeLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeLanguageWeb> reportTypeLanguageWebList = new List<ReportTypeLanguageWeb>();
                            reportTypeLanguageWebList = reportTypeLanguageService.GetReportTypeLanguageWebList().ToList();
                            CheckReportTypeLanguageWebFields(reportTypeLanguageWebList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageWebList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeLanguageReport> reportTypeLanguageReportList = new List<ReportTypeLanguageReport>();
                            reportTypeLanguageReportList = reportTypeLanguageService.GetReportTypeLanguageReportList().ToList();
                            CheckReportTypeLanguageReportFields(reportTypeLanguageReportList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageReportList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "ReportTypeLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = reportTypeLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.ReportTypeLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeLanguageWeb> reportTypeLanguageWebList = new List<ReportTypeLanguageWeb>();
                            reportTypeLanguageWebList = reportTypeLanguageService.GetReportTypeLanguageWebList().ToList();
                            CheckReportTypeLanguageWebFields(reportTypeLanguageWebList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageWebList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeLanguageReport> reportTypeLanguageReportList = new List<ReportTypeLanguageReport>();
                            reportTypeLanguageReportList = reportTypeLanguageService.GetReportTypeLanguageReportList().ToList();
                            CheckReportTypeLanguageReportFields(reportTypeLanguageReportList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageReportList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 1, 1, "ReportTypeLanguageID,ReportTypeID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = reportTypeLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.ReportTypeLanguageID).ThenBy(c => c.ReportTypeID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeLanguageWeb> reportTypeLanguageWebList = new List<ReportTypeLanguageWeb>();
                            reportTypeLanguageWebList = reportTypeLanguageService.GetReportTypeLanguageWebList().ToList();
                            CheckReportTypeLanguageWebFields(reportTypeLanguageWebList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageWebList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeLanguageReport> reportTypeLanguageReportList = new List<ReportTypeLanguageReport>();
                            reportTypeLanguageReportList = reportTypeLanguageService.GetReportTypeLanguageReportList().ToList();
                            CheckReportTypeLanguageReportFields(reportTypeLanguageReportList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageReportList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 0, 1, "ReportTypeLanguageID", "ReportTypeLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = reportTypeLanguageService.GetRead().Where(c => c.ReportTypeLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.ReportTypeLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeLanguageWeb> reportTypeLanguageWebList = new List<ReportTypeLanguageWeb>();
                            reportTypeLanguageWebList = reportTypeLanguageService.GetReportTypeLanguageWebList().ToList();
                            CheckReportTypeLanguageWebFields(reportTypeLanguageWebList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageWebList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeLanguageReport> reportTypeLanguageReportList = new List<ReportTypeLanguageReport>();
                            reportTypeLanguageReportList = reportTypeLanguageService.GetReportTypeLanguageReportList().ToList();
                            CheckReportTypeLanguageReportFields(reportTypeLanguageReportList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageReportList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 0, 1, "ReportTypeLanguageID", "ReportTypeLanguageID,GT,2|ReportTypeLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = reportTypeLanguageService.GetRead().Where(c => c.ReportTypeLanguageID > 2 && c.ReportTypeLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.ReportTypeLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeLanguageWeb> reportTypeLanguageWebList = new List<ReportTypeLanguageWeb>();
                            reportTypeLanguageWebList = reportTypeLanguageService.GetReportTypeLanguageWebList().ToList();
                            CheckReportTypeLanguageWebFields(reportTypeLanguageWebList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageWebList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeLanguageReport> reportTypeLanguageReportList = new List<ReportTypeLanguageReport>();
                            reportTypeLanguageReportList = reportTypeLanguageService.GetReportTypeLanguageReportList().ToList();
                            CheckReportTypeLanguageReportFields(reportTypeLanguageReportList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageReportList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeLanguageService.Query = reportTypeLanguageService.FillQuery(typeof(ReportTypeLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "ReportTypeLanguageID,GT,2|ReportTypeLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportTypeLanguage> reportTypeLanguageDirectQueryList = new List<ReportTypeLanguage>();
                        reportTypeLanguageDirectQueryList = reportTypeLanguageService.GetRead().Where(c => c.ReportTypeLanguageID > 2 && c.ReportTypeLanguageID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportTypeLanguage> reportTypeLanguageList = new List<ReportTypeLanguage>();
                            reportTypeLanguageList = reportTypeLanguageService.GetReportTypeLanguageList().ToList();
                            CheckReportTypeLanguageFields(reportTypeLanguageList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeLanguageWeb> reportTypeLanguageWebList = new List<ReportTypeLanguageWeb>();
                            reportTypeLanguageWebList = reportTypeLanguageService.GetReportTypeLanguageWebList().ToList();
                            CheckReportTypeLanguageWebFields(reportTypeLanguageWebList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageWebList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeLanguageReport> reportTypeLanguageReportList = new List<ReportTypeLanguageReport>();
                            reportTypeLanguageReportList = reportTypeLanguageService.GetReportTypeLanguageReportList().ToList();
                            CheckReportTypeLanguageReportFields(reportTypeLanguageReportList);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList[0].ReportTypeLanguageID, reportTypeLanguageReportList[0].ReportTypeLanguageID);
                            Assert.AreEqual(reportTypeLanguageDirectQueryList.Count, reportTypeLanguageReportList.Count);
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
        private void CheckReportTypeLanguageWebFields(List<ReportTypeLanguageWeb> reportTypeLanguageWebList)
        {
            Assert.IsNotNull(reportTypeLanguageWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].TranslationStatusNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].TranslationStatusNameText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].TranslationStatusDescriptionText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].TranslationStatusDescriptionText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].TranslationStatusStartOfFileNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].TranslationStatusStartOfFileNameText));
            }
            Assert.IsNotNull(reportTypeLanguageWebList[0].ReportTypeLanguageID);
            Assert.IsNotNull(reportTypeLanguageWebList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeLanguageWebList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].Name));
            Assert.IsNotNull(reportTypeLanguageWebList[0].TranslationStatusName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].Description));
            Assert.IsNotNull(reportTypeLanguageWebList[0].TranslationStatusDescription);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageWebList[0].StartOfFileName));
            Assert.IsNotNull(reportTypeLanguageWebList[0].TranslationStatusStartOfFileName);
            Assert.IsNotNull(reportTypeLanguageWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeLanguageWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeLanguageWebList[0].HasErrors);
        }
        private void CheckReportTypeLanguageReportFields(List<ReportTypeLanguageReport> reportTypeLanguageReportList)
        {
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].ReportTypeLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].ReportTypeLanguageReportTest));
            }
            Assert.IsNotNull(reportTypeLanguageReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].TranslationStatusNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].TranslationStatusNameText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].TranslationStatusDescriptionText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].TranslationStatusDescriptionText));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].TranslationStatusStartOfFileNameText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].TranslationStatusStartOfFileNameText));
            }
            Assert.IsNotNull(reportTypeLanguageReportList[0].ReportTypeLanguageID);
            Assert.IsNotNull(reportTypeLanguageReportList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeLanguageReportList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].Name));
            Assert.IsNotNull(reportTypeLanguageReportList[0].TranslationStatusName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].Description));
            Assert.IsNotNull(reportTypeLanguageReportList[0].TranslationStatusDescription);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageReportList[0].StartOfFileName));
            Assert.IsNotNull(reportTypeLanguageReportList[0].TranslationStatusStartOfFileName);
            Assert.IsNotNull(reportTypeLanguageReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeLanguageReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeLanguageReportList[0].HasErrors);
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
