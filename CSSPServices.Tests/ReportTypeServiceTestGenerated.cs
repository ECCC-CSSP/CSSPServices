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
    public partial class ReportTypeServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ReportTypeService reportTypeService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeServiceTest() : base()
        {
            //reportTypeService = new ReportTypeService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ReportType_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ReportType reportType = GetFilledRandomReportType("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = reportTypeService.GetRead().Count();

                    Assert.AreEqual(reportTypeService.GetRead().Count(), reportTypeService.GetEdit().Count());

                    reportTypeService.Add(reportType);
                    if (reportType.HasErrors)
                    {
                        Assert.AreEqual("", reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportTypeService.GetRead().Where(c => c == reportType).Any());
                    reportTypeService.Update(reportType);
                    if (reportType.HasErrors)
                    {
                        Assert.AreEqual("", reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportTypeService.GetRead().Count());
                    reportTypeService.Delete(reportType);
                    if (reportType.HasErrors)
                    {
                        Assert.AreEqual("", reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportTypeService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // reportType.ReportTypeID   (Int32)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.ReportTypeID = 0;
                    reportTypeService.Update(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeReportTypeID"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.ReportTypeID = 10000000;
                    reportTypeService.Update(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeReportTypeID", reportType.ReportTypeID.ToString()), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportType.TVType   (TVTypeEnum)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.TVType = (TVTypeEnum)1000000;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeTVType"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportType.FileType   (FileTypeEnum)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.FileType = (FileTypeEnum)1000000;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeFileType"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // reportType.UniqueCode   (String)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("UniqueCode");
                    Assert.AreEqual(false, reportTypeService.Add(reportType));
                    Assert.AreEqual(1, reportType.ValidationResults.Count());
                    Assert.IsTrue(reportType.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ReportTypeUniqueCode")).Any());
                    Assert.AreEqual(null, reportType.UniqueCode);
                    Assert.AreEqual(count, reportTypeService.GetRead().Count());

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.UniqueCode = GetRandomString("", 101);
                    Assert.AreEqual(false, reportTypeService.Add(reportType));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportTypeUniqueCode", "100"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // reportType.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateDate_UTC = new DateTime();
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeLastUpdateDate_UTC"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ReportTypeLastUpdateDate_UTC", "1980"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // reportType.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateContactTVItemID = 0;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ReportTypeLastUpdateContactTVItemID", reportType.LastUpdateContactTVItemID.ToString()), reportType.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateContactTVItemID = 1;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ReportTypeLastUpdateContactTVItemID", "Contact"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportType.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportType.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetReportTypeWithReportTypeID(reportType.ReportTypeID)
        [TestMethod]
        public void GetReportTypeWithReportTypeID__reportType_ReportTypeID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportType reportType = (from c in reportTypeService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportType);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportTypeService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ReportType reportTypeRet = reportTypeService.GetReportTypeWithReportTypeID(reportType.ReportTypeID);
                            CheckReportTypeFields(new List<ReportType>() { reportTypeRet });
                            Assert.AreEqual(reportType.ReportTypeID, reportTypeRet.ReportTypeID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ReportTypeWeb reportTypeWebRet = reportTypeService.GetReportTypeWebWithReportTypeID(reportType.ReportTypeID);
                            CheckReportTypeWebFields(new List<ReportTypeWeb>() { reportTypeWebRet });
                            Assert.AreEqual(reportType.ReportTypeID, reportTypeWebRet.ReportTypeID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ReportTypeReport reportTypeReportRet = reportTypeService.GetReportTypeReportWithReportTypeID(reportType.ReportTypeID);
                            CheckReportTypeReportFields(new List<ReportTypeReport>() { reportTypeReportRet });
                            Assert.AreEqual(reportType.ReportTypeID, reportTypeReportRet.ReportTypeID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeWithReportTypeID(reportType.ReportTypeID)

        #region Tests Generated for GetReportTypeList()
        [TestMethod]
        public void GetReportTypeList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportType reportType = (from c in reportTypeService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportType);

                    List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                    reportTypeDirectQueryList = reportTypeService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportTypeService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeWeb> reportTypeWebList = new List<ReportTypeWeb>();
                            reportTypeWebList = reportTypeService.GetReportTypeWebList().ToList();
                            CheckReportTypeWebFields(reportTypeWebList);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeReport> reportTypeReportList = new List<ReportTypeReport>();
                            reportTypeReportList = reportTypeService.GetReportTypeReportList().ToList();
                            CheckReportTypeReportFields(reportTypeReportList);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList()

        #region Tests Generated for GetReportTypeList() Skip Take
        [TestMethod]
        public void GetReportTypeList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = reportTypeService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeWeb> reportTypeWebList = new List<ReportTypeWeb>();
                            reportTypeWebList = reportTypeService.GetReportTypeWebList().ToList();
                            CheckReportTypeWebFields(reportTypeWebList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeWebList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeReport> reportTypeReportList = new List<ReportTypeReport>();
                            reportTypeReportList = reportTypeService.GetReportTypeReportList().ToList();
                            CheckReportTypeReportFields(reportTypeReportList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeReportList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take

        #region Tests Generated for GetReportTypeList() Skip Take Order
        [TestMethod]
        public void GetReportTypeList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 1, 1,  "ReportTypeID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = reportTypeService.GetRead().Skip(1).Take(1).OrderBy(c => c.ReportTypeID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeWeb> reportTypeWebList = new List<ReportTypeWeb>();
                            reportTypeWebList = reportTypeService.GetReportTypeWebList().ToList();
                            CheckReportTypeWebFields(reportTypeWebList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeWebList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeReport> reportTypeReportList = new List<ReportTypeReport>();
                            reportTypeReportList = reportTypeService.GetReportTypeReportList().ToList();
                            CheckReportTypeReportFields(reportTypeReportList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeReportList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take Order

        #region Tests Generated for GetReportTypeList() Skip Take 2Order
        [TestMethod]
        public void GetReportTypeList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 1, 1, "ReportTypeID,TVType", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = reportTypeService.GetRead().Skip(1).Take(1).OrderBy(c => c.ReportTypeID).ThenBy(c => c.TVType).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeWeb> reportTypeWebList = new List<ReportTypeWeb>();
                            reportTypeWebList = reportTypeService.GetReportTypeWebList().ToList();
                            CheckReportTypeWebFields(reportTypeWebList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeWebList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeReport> reportTypeReportList = new List<ReportTypeReport>();
                            reportTypeReportList = reportTypeService.GetReportTypeReportList().ToList();
                            CheckReportTypeReportFields(reportTypeReportList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeReportList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take 2Order

        #region Tests Generated for GetReportTypeList() Skip Take Order Where
        [TestMethod]
        public void GetReportTypeList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 0, 1, "ReportTypeID", "ReportTypeID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = reportTypeService.GetRead().Where(c => c.ReportTypeID == 4).Skip(0).Take(1).OrderBy(c => c.ReportTypeID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeWeb> reportTypeWebList = new List<ReportTypeWeb>();
                            reportTypeWebList = reportTypeService.GetReportTypeWebList().ToList();
                            CheckReportTypeWebFields(reportTypeWebList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeWebList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeReport> reportTypeReportList = new List<ReportTypeReport>();
                            reportTypeReportList = reportTypeService.GetReportTypeReportList().ToList();
                            CheckReportTypeReportFields(reportTypeReportList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeReportList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take Order Where

        #region Tests Generated for GetReportTypeList() Skip Take Order 2Where
        [TestMethod]
        public void GetReportTypeList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 0, 1, "ReportTypeID", "ReportTypeID,GT,2|ReportTypeID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = reportTypeService.GetRead().Where(c => c.ReportTypeID > 2 && c.ReportTypeID < 5).Skip(0).Take(1).OrderBy(c => c.ReportTypeID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeWeb> reportTypeWebList = new List<ReportTypeWeb>();
                            reportTypeWebList = reportTypeService.GetReportTypeWebList().ToList();
                            CheckReportTypeWebFields(reportTypeWebList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeWebList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeReport> reportTypeReportList = new List<ReportTypeReport>();
                            reportTypeReportList = reportTypeService.GetReportTypeReportList().ToList();
                            CheckReportTypeReportFields(reportTypeReportList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeReportList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take Order 2Where

        #region Tests Generated for GetReportTypeList() 2Where
        [TestMethod]
        public void GetReportTypeList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 0, 10000, "", "ReportTypeID,GT,2|ReportTypeID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = reportTypeService.GetRead().Where(c => c.ReportTypeID > 2 && c.ReportTypeID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<ReportTypeWeb> reportTypeWebList = new List<ReportTypeWeb>();
                            reportTypeWebList = reportTypeService.GetReportTypeWebList().ToList();
                            CheckReportTypeWebFields(reportTypeWebList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeWebList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<ReportTypeReport> reportTypeReportList = new List<ReportTypeReport>();
                            reportTypeReportList = reportTypeService.GetReportTypeReportList().ToList();
                            CheckReportTypeReportFields(reportTypeReportList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeReportList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() 2Where

        #region Functions private
        private void CheckReportTypeFields(List<ReportType> reportTypeList)
        {
            Assert.IsNotNull(reportTypeList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeList[0].TVType);
            Assert.IsNotNull(reportTypeList[0].FileType);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeList[0].UniqueCode));
            Assert.IsNotNull(reportTypeList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeList[0].HasErrors);
        }
        private void CheckReportTypeWebFields(List<ReportTypeWeb> reportTypeWebList)
        {
            Assert.IsNotNull(reportTypeWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(reportTypeWebList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeWebList[0].TVType);
            Assert.IsNotNull(reportTypeWebList[0].FileType);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeWebList[0].UniqueCode));
            Assert.IsNotNull(reportTypeWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeWebList[0].HasErrors);
        }
        private void CheckReportTypeReportFields(List<ReportTypeReport> reportTypeReportList)
        {
            if (!string.IsNullOrWhiteSpace(reportTypeReportList[0].ReportTypeReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeReportList[0].ReportTypeReportTest));
            }
            Assert.IsNotNull(reportTypeReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(reportTypeReportList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeReportList[0].TVType);
            Assert.IsNotNull(reportTypeReportList[0].FileType);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeReportList[0].UniqueCode));
            Assert.IsNotNull(reportTypeReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeReportList[0].HasErrors);
        }
        private ReportType GetFilledRandomReportType(string OmitPropName)
        {
            ReportType reportType = new ReportType();

            if (OmitPropName != "TVType") reportType.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "FileType") reportType.FileType = (FileTypeEnum)GetRandomEnumType(typeof(FileTypeEnum));
            if (OmitPropName != "UniqueCode") reportType.UniqueCode = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") reportType.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportType.LastUpdateContactTVItemID = 2;

            return reportType;
        }
        #endregion Functions private
    }
}
