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
    public partial class ReportSectionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ReportSectionService reportSectionService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportSectionServiceTest() : base()
        {
            //reportSectionService = new ReportSectionService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ReportSection_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ReportSection reportSection = GetFilledRandomReportSection("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = reportSectionService.GetRead().Count();

                    Assert.AreEqual(reportSectionService.GetRead().Count(), reportSectionService.GetEdit().Count());

                    reportSectionService.Add(reportSection);
                    if (reportSection.HasErrors)
                    {
                        Assert.AreEqual("", reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportSectionService.GetRead().Where(c => c == reportSection).Any());
                    reportSectionService.Update(reportSection);
                    if (reportSection.HasErrors)
                    {
                        Assert.AreEqual("", reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportSectionService.GetRead().Count());
                    reportSectionService.Delete(reportSection);
                    if (reportSection.HasErrors)
                    {
                        Assert.AreEqual("", reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // reportSection.ReportSectionID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportSectionID = 0;
                    reportSectionService.Update(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportSectionReportSectionID"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportSectionID = 10000000;
                    reportSectionService.Update(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportSection", "ReportSectionReportSectionID", reportSection.ReportSectionID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID", AllowableTVtypeList = )]
                    // reportSection.ReportTypeID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportTypeID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportSectionReportTypeID", reportSection.ReportTypeID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = )]
                    // reportSection.TVItemID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.TVItemID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ReportSectionTVItemID", reportSection.TVItemID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.TVItemID = 1;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ReportSectionTVItemID", ""), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // reportSection.Ordinal   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.Ordinal = -1;
                    Assert.AreEqual(false, reportSectionService.Add(reportSection));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ReportSectionOrdinal", "0", "1000"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());
                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.Ordinal = 1001;
                    Assert.AreEqual(false, reportSectionService.Add(reportSection));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ReportSectionOrdinal", "0", "1000"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // reportSection.IsStatic   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID", AllowableTVtypeList = )]
                    // reportSection.ParentReportSectionID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ParentReportSectionID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportSection", "ReportSectionParentReportSectionID", reportSection.ParentReportSectionID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(1979, 2050)]
                    // reportSection.Year   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.Year = 1978;
                    Assert.AreEqual(false, reportSectionService.Add(reportSection));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ReportSectionYear", "1979", "2050"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());
                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.Year = 2051;
                    Assert.AreEqual(false, reportSectionService.Add(reportSection));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ReportSectionYear", "1979", "2050"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // reportSection.Locked   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID", AllowableTVtypeList = )]
                    // reportSection.TemplateReportSectionID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.TemplateReportSectionID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportSection", "ReportSectionTemplateReportSectionID", reportSection.TemplateReportSectionID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // reportSection.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.LastUpdateDate_UTC = new DateTime();
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportSectionLastUpdateDate_UTC"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ReportSectionLastUpdateDate_UTC", "1980"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // reportSection.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.LastUpdateContactTVItemID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ReportSectionLastUpdateContactTVItemID", reportSection.LastUpdateContactTVItemID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.LastUpdateContactTVItemID = 1;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ReportSectionLastUpdateContactTVItemID", "Contact"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportSection.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportSection.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetReportSectionWithReportSectionID(reportSection.ReportSectionID)
        [TestMethod]
        public void GetReportSectionWithReportSectionID__reportSection_ReportSectionID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportSection reportSection = (from c in reportSectionService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportSection);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportSectionService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ReportSection reportSectionRet = reportSectionService.GetReportSectionWithReportSectionID(reportSection.ReportSectionID);
                            CheckReportSectionFields(new List<ReportSection>() { reportSectionRet });
                            Assert.AreEqual(reportSection.ReportSectionID, reportSectionRet.ReportSectionID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ReportSectionWeb reportSectionWebRet = reportSectionService.GetReportSectionWebWithReportSectionID(reportSection.ReportSectionID);
                            CheckReportSectionWebFields(new List<ReportSectionWeb>() { reportSectionWebRet });
                            Assert.AreEqual(reportSection.ReportSectionID, reportSectionWebRet.ReportSectionID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ReportSectionReport reportSectionReportRet = reportSectionService.GetReportSectionReportWithReportSectionID(reportSection.ReportSectionID);
                            CheckReportSectionReportFields(new List<ReportSectionReport>() { reportSectionReportRet });
                            Assert.AreEqual(reportSection.ReportSectionID, reportSectionReportRet.ReportSectionID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionWithReportSectionID(reportSection.ReportSectionID)

        #region Tests Generated for GetReportSectionList()
        [TestMethod]
        public void GetReportSectionList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportSection reportSection = (from c in reportSectionService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportSection);

                    List<ReportSection> reportSectionDirectQueryList = new List<ReportSection>();
                    reportSectionDirectQueryList = reportSectionService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportSectionService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSection> reportSectionList = new List<ReportSection>();
                            reportSectionList = reportSectionService.GetReportSectionList().ToList();
                            CheckReportSectionFields(reportSectionList);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionWeb> reportSectionWebList = new List<ReportSectionWeb>();
                            reportSectionWebList = reportSectionService.GetReportSectionWebList().ToList();
                            CheckReportSectionWebFields(reportSectionWebList);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionReport> reportSectionReportList = new List<ReportSectionReport>();
                            reportSectionReportList = reportSectionService.GetReportSectionReportList().ToList();
                            CheckReportSectionReportFields(reportSectionReportList);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionList()

        #region Tests Generated for GetReportSectionList() Skip Take
        [TestMethod]
        public void GetReportSectionList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSection> reportSectionDirectQueryList = new List<ReportSection>();
                        reportSectionDirectQueryList = reportSectionService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSection> reportSectionList = new List<ReportSection>();
                            reportSectionList = reportSectionService.GetReportSectionList().ToList();
                            CheckReportSectionFields(reportSectionList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionWeb> reportSectionWebList = new List<ReportSectionWeb>();
                            reportSectionWebList = reportSectionService.GetReportSectionWebList().ToList();
                            CheckReportSectionWebFields(reportSectionWebList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionWebList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionReport> reportSectionReportList = new List<ReportSectionReport>();
                            reportSectionReportList = reportSectionService.GetReportSectionReportList().ToList();
                            CheckReportSectionReportFields(reportSectionReportList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionReportList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionList() Skip Take

        #region Tests Generated for GetReportSectionList() Skip Take Order
        [TestMethod]
        public void GetReportSectionList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), culture.TwoLetterISOLanguageName, 1, 1,  "ReportSectionID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSection> reportSectionDirectQueryList = new List<ReportSection>();
                        reportSectionDirectQueryList = reportSectionService.GetRead().Skip(1).Take(1).OrderBy(c => c.ReportSectionID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSection> reportSectionList = new List<ReportSection>();
                            reportSectionList = reportSectionService.GetReportSectionList().ToList();
                            CheckReportSectionFields(reportSectionList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionWeb> reportSectionWebList = new List<ReportSectionWeb>();
                            reportSectionWebList = reportSectionService.GetReportSectionWebList().ToList();
                            CheckReportSectionWebFields(reportSectionWebList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionWebList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionReport> reportSectionReportList = new List<ReportSectionReport>();
                            reportSectionReportList = reportSectionService.GetReportSectionReportList().ToList();
                            CheckReportSectionReportFields(reportSectionReportList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionReportList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionList() Skip Take Order

        #region Tests Generated for GetReportSectionList() Skip Take 2Order
        [TestMethod]
        public void GetReportSectionList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), culture.TwoLetterISOLanguageName, 1, 1, "ReportSectionID,ReportTypeID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSection> reportSectionDirectQueryList = new List<ReportSection>();
                        reportSectionDirectQueryList = reportSectionService.GetRead().Skip(1).Take(1).OrderBy(c => c.ReportSectionID).ThenBy(c => c.ReportTypeID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSection> reportSectionList = new List<ReportSection>();
                            reportSectionList = reportSectionService.GetReportSectionList().ToList();
                            CheckReportSectionFields(reportSectionList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionWeb> reportSectionWebList = new List<ReportSectionWeb>();
                            reportSectionWebList = reportSectionService.GetReportSectionWebList().ToList();
                            CheckReportSectionWebFields(reportSectionWebList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionWebList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionReport> reportSectionReportList = new List<ReportSectionReport>();
                            reportSectionReportList = reportSectionService.GetReportSectionReportList().ToList();
                            CheckReportSectionReportFields(reportSectionReportList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionReportList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionList() Skip Take 2Order

        #region Tests Generated for GetReportSectionList() Skip Take Order Where
        [TestMethod]
        public void GetReportSectionList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), culture.TwoLetterISOLanguageName, 0, 1, "ReportSectionID", "ReportSectionID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSection> reportSectionDirectQueryList = new List<ReportSection>();
                        reportSectionDirectQueryList = reportSectionService.GetRead().Where(c => c.ReportSectionID == 4).Skip(0).Take(1).OrderBy(c => c.ReportSectionID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSection> reportSectionList = new List<ReportSection>();
                            reportSectionList = reportSectionService.GetReportSectionList().ToList();
                            CheckReportSectionFields(reportSectionList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionWeb> reportSectionWebList = new List<ReportSectionWeb>();
                            reportSectionWebList = reportSectionService.GetReportSectionWebList().ToList();
                            CheckReportSectionWebFields(reportSectionWebList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionWebList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionReport> reportSectionReportList = new List<ReportSectionReport>();
                            reportSectionReportList = reportSectionService.GetReportSectionReportList().ToList();
                            CheckReportSectionReportFields(reportSectionReportList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionReportList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionList() Skip Take Order Where

        #region Tests Generated for GetReportSectionList() Skip Take Order 2Where
        [TestMethod]
        public void GetReportSectionList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), culture.TwoLetterISOLanguageName, 0, 1, "ReportSectionID", "ReportSectionID,GT,2|ReportSectionID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSection> reportSectionDirectQueryList = new List<ReportSection>();
                        reportSectionDirectQueryList = reportSectionService.GetRead().Where(c => c.ReportSectionID > 2 && c.ReportSectionID < 5).Skip(0).Take(1).OrderBy(c => c.ReportSectionID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSection> reportSectionList = new List<ReportSection>();
                            reportSectionList = reportSectionService.GetReportSectionList().ToList();
                            CheckReportSectionFields(reportSectionList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionWeb> reportSectionWebList = new List<ReportSectionWeb>();
                            reportSectionWebList = reportSectionService.GetReportSectionWebList().ToList();
                            CheckReportSectionWebFields(reportSectionWebList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionWebList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionReport> reportSectionReportList = new List<ReportSectionReport>();
                            reportSectionReportList = reportSectionService.GetReportSectionReportList().ToList();
                            CheckReportSectionReportFields(reportSectionReportList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionReportList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionList() Skip Take Order 2Where

        #region Tests Generated for GetReportSectionList() 2Where
        [TestMethod]
        public void GetReportSectionList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportSectionService reportSectionService = new ReportSectionService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportSectionService.Query = reportSectionService.FillQuery(typeof(ReportSection), culture.TwoLetterISOLanguageName, 0, 10000, "", "ReportSectionID,GT,2|ReportSectionID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportSection> reportSectionDirectQueryList = new List<ReportSection>();
                        reportSectionDirectQueryList = reportSectionService.GetRead().Where(c => c.ReportSectionID > 2 && c.ReportSectionID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportSection> reportSectionList = new List<ReportSection>();
                            reportSectionList = reportSectionService.GetReportSectionList().ToList();
                            CheckReportSectionFields(reportSectionList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportSectionWeb> reportSectionWebList = new List<ReportSectionWeb>();
                            reportSectionWebList = reportSectionService.GetReportSectionWebList().ToList();
                            CheckReportSectionWebFields(reportSectionWebList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionWebList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportSectionReport> reportSectionReportList = new List<ReportSectionReport>();
                            reportSectionReportList = reportSectionService.GetReportSectionReportList().ToList();
                            CheckReportSectionReportFields(reportSectionReportList);
                            Assert.AreEqual(reportSectionDirectQueryList[0].ReportSectionID, reportSectionReportList[0].ReportSectionID);
                            Assert.AreEqual(reportSectionDirectQueryList.Count, reportSectionReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportSectionList() 2Where

        #region Functions private
        private void CheckReportSectionFields(List<ReportSection> reportSectionList)
        {
            Assert.IsNotNull(reportSectionList[0].ReportSectionID);
            Assert.IsNotNull(reportSectionList[0].ReportTypeID);
            if (reportSectionList[0].TVItemID != null)
            {
                Assert.IsNotNull(reportSectionList[0].TVItemID);
            }
            Assert.IsNotNull(reportSectionList[0].Ordinal);
            Assert.IsNotNull(reportSectionList[0].IsStatic);
            if (reportSectionList[0].ParentReportSectionID != null)
            {
                Assert.IsNotNull(reportSectionList[0].ParentReportSectionID);
            }
            if (reportSectionList[0].Year != null)
            {
                Assert.IsNotNull(reportSectionList[0].Year);
            }
            Assert.IsNotNull(reportSectionList[0].Locked);
            if (reportSectionList[0].TemplateReportSectionID != null)
            {
                Assert.IsNotNull(reportSectionList[0].TemplateReportSectionID);
            }
            Assert.IsNotNull(reportSectionList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportSectionList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportSectionList[0].HasErrors);
        }
        private void CheckReportSectionWebFields(List<ReportSectionWeb> reportSectionWebList)
        {
            Assert.IsNotNull(reportSectionWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(reportSectionWebList[0].ReportSectionName);
            Assert.IsNotNull(reportSectionWebList[0].ReportSectionText);
            Assert.IsNotNull(reportSectionWebList[0].ReportSectionID);
            Assert.IsNotNull(reportSectionWebList[0].ReportTypeID);
            if (reportSectionWebList[0].TVItemID != null)
            {
                Assert.IsNotNull(reportSectionWebList[0].TVItemID);
            }
            Assert.IsNotNull(reportSectionWebList[0].Ordinal);
            Assert.IsNotNull(reportSectionWebList[0].IsStatic);
            if (reportSectionWebList[0].ParentReportSectionID != null)
            {
                Assert.IsNotNull(reportSectionWebList[0].ParentReportSectionID);
            }
            if (reportSectionWebList[0].Year != null)
            {
                Assert.IsNotNull(reportSectionWebList[0].Year);
            }
            Assert.IsNotNull(reportSectionWebList[0].Locked);
            if (reportSectionWebList[0].TemplateReportSectionID != null)
            {
                Assert.IsNotNull(reportSectionWebList[0].TemplateReportSectionID);
            }
            Assert.IsNotNull(reportSectionWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportSectionWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportSectionWebList[0].HasErrors);
        }
        private void CheckReportSectionReportFields(List<ReportSectionReport> reportSectionReportList)
        {
            if (!string.IsNullOrWhiteSpace(reportSectionReportList[0].ReportSectionReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionReportList[0].ReportSectionReportTest));
            }
            Assert.IsNotNull(reportSectionReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(reportSectionReportList[0].ReportSectionName);
            Assert.IsNotNull(reportSectionReportList[0].ReportSectionText);
            Assert.IsNotNull(reportSectionReportList[0].ReportSectionID);
            Assert.IsNotNull(reportSectionReportList[0].ReportTypeID);
            if (reportSectionReportList[0].TVItemID != null)
            {
                Assert.IsNotNull(reportSectionReportList[0].TVItemID);
            }
            Assert.IsNotNull(reportSectionReportList[0].Ordinal);
            Assert.IsNotNull(reportSectionReportList[0].IsStatic);
            if (reportSectionReportList[0].ParentReportSectionID != null)
            {
                Assert.IsNotNull(reportSectionReportList[0].ParentReportSectionID);
            }
            if (reportSectionReportList[0].Year != null)
            {
                Assert.IsNotNull(reportSectionReportList[0].Year);
            }
            Assert.IsNotNull(reportSectionReportList[0].Locked);
            if (reportSectionReportList[0].TemplateReportSectionID != null)
            {
                Assert.IsNotNull(reportSectionReportList[0].TemplateReportSectionID);
            }
            Assert.IsNotNull(reportSectionReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportSectionReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportSectionReportList[0].HasErrors);
        }
        private ReportSection GetFilledRandomReportSection(string OmitPropName)
        {
            ReportSection reportSection = new ReportSection();

            if (OmitPropName != "ReportTypeID") reportSection.ReportTypeID = 1;
            // Need to implement (no items found, would need to add at least one in the TestDB) [ReportSection TVItemID TVItem TVItemID]
            if (OmitPropName != "Ordinal") reportSection.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "IsStatic") reportSection.IsStatic = true;
            if (OmitPropName != "ParentReportSectionID") reportSection.ParentReportSectionID = 1;
            if (OmitPropName != "Year") reportSection.Year = GetRandomInt(1979, 2050);
            if (OmitPropName != "Locked") reportSection.Locked = true;
            if (OmitPropName != "TemplateReportSectionID") reportSection.TemplateReportSectionID = 1;
            if (OmitPropName != "LastUpdateDate_UTC") reportSection.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportSection.LastUpdateContactTVItemID = 2;

            return reportSection;
        }
        #endregion Functions private
    }
}
