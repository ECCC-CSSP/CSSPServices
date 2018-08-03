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
    public partial class AppErrLogServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AppErrLogService appErrLogService { get; set; }
        #endregion Properties

        #region Constructors
        public AppErrLogServiceTest() : base()
        {
            //appErrLogService = new AppErrLogService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AppErrLog_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    AppErrLog appErrLog = GetFilledRandomAppErrLog("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = appErrLogService.GetRead().Count();

                    Assert.AreEqual(appErrLogService.GetRead().Count(), appErrLogService.GetEdit().Count());

                    appErrLogService.Add(appErrLog);
                    if (appErrLog.HasErrors)
                    {
                        Assert.AreEqual("", appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, appErrLogService.GetRead().Where(c => c == appErrLog).Any());
                    appErrLogService.Update(appErrLog);
                    if (appErrLog.HasErrors)
                    {
                        Assert.AreEqual("", appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, appErrLogService.GetRead().Count());
                    appErrLogService.Delete(appErrLog);
                    if (appErrLog.HasErrors)
                    {
                        Assert.AreEqual("", appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, appErrLogService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // appErrLog.AppErrLogID   (Int32)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.AppErrLogID = 0;
                    appErrLogService.Update(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppErrLogAppErrLogID"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.AppErrLogID = 10000000;
                    appErrLogService.Update(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogAppErrLogID", appErrLog.AppErrLogID.ToString()), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // appErrLog.Tag   (String)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("Tag");
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(1, appErrLog.ValidationResults.Count());
                    Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "AppErrLogTag")).Any());
                    Assert.AreEqual(null, appErrLog.Tag);
                    Assert.AreEqual(count, appErrLogService.GetRead().Count());

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.Tag = GetRandomString("", 101);
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "AppErrLogTag", "100"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appErrLogService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, -1)]
                    // appErrLog.LineNumber   (Int32)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LineNumber = 0;
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "AppErrLogLineNumber", "1"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appErrLogService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // appErrLog.Source   (String)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("Source");
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(1, appErrLog.ValidationResults.Count());
                    Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "AppErrLogSource")).Any());
                    Assert.AreEqual(null, appErrLog.Source);
                    Assert.AreEqual(count, appErrLogService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // appErrLog.Message   (String)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("Message");
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(1, appErrLog.ValidationResults.Count());
                    Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "AppErrLogMessage")).Any());
                    Assert.AreEqual(null, appErrLog.Message);
                    Assert.AreEqual(count, appErrLogService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appErrLog.DateTime_UTC   (DateTime)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.DateTime_UTC = new DateTime();
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppErrLogDateTime_UTC"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.DateTime_UTC = new DateTime(1979, 1, 1);
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppErrLogDateTime_UTC", "1980"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appErrLog.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateDate_UTC = new DateTime();
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppErrLogLastUpdateDate_UTC"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppErrLogLastUpdateDate_UTC", "1980"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // appErrLog.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateContactTVItemID = 0;
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppErrLogLastUpdateContactTVItemID", appErrLog.LastUpdateContactTVItemID.ToString()), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateContactTVItemID = 1;
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AppErrLogLastUpdateContactTVItemID", "Contact"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appErrLog.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appErrLog.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID)
        [TestMethod]
        public void GetAppErrLogWithAppErrLogID__appErrLog_AppErrLogID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppErrLog appErrLog = (from c in appErrLogService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(appErrLog);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appErrLogService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            AppErrLog appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogFields(new List<AppErrLog>() { appErrLogRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogRet.AppErrLogID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            AppErrLogWeb appErrLogWebRet = appErrLogService.GetAppErrLogWebWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogWebFields(new List<AppErrLogWeb>() { appErrLogWebRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogWebRet.AppErrLogID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            AppErrLogReport appErrLogReportRet = appErrLogService.GetAppErrLogReportWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogReportFields(new List<AppErrLogReport>() { appErrLogReportRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogReportRet.AppErrLogID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID)

        #region Tests Generated for GetAppErrLogList()
        [TestMethod]
        public void GetAppErrLogList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppErrLog appErrLog = (from c in appErrLogService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(appErrLog);

                    List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                    appErrLogDirectQueryList = appErrLogService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appErrLogService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppErrLogWeb> appErrLogWebList = new List<AppErrLogWeb>();
                            appErrLogWebList = appErrLogService.GetAppErrLogWebList().ToList();
                            CheckAppErrLogWebFields(appErrLogWebList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppErrLogReport> appErrLogReportList = new List<AppErrLogReport>();
                            appErrLogReportList = appErrLogService.GetAppErrLogReportList().ToList();
                            CheckAppErrLogReportFields(appErrLogReportList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList()

        #region Tests Generated for GetAppErrLogList() Skip Take
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = appErrLogService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppErrLogWeb> appErrLogWebList = new List<AppErrLogWeb>();
                            appErrLogWebList = appErrLogService.GetAppErrLogWebList().ToList();
                            CheckAppErrLogWebFields(appErrLogWebList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogWebList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppErrLogReport> appErrLogReportList = new List<AppErrLogReport>();
                            appErrLogReportList = appErrLogService.GetAppErrLogReportList().ToList();
                            CheckAppErrLogReportFields(appErrLogReportList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogReportList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take

        #region Tests Generated for GetAppErrLogList() Skip Take Order
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1,  "AppErrLogID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = appErrLogService.GetRead().Skip(1).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppErrLogWeb> appErrLogWebList = new List<AppErrLogWeb>();
                            appErrLogWebList = appErrLogService.GetAppErrLogWebList().ToList();
                            CheckAppErrLogWebFields(appErrLogWebList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogWebList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppErrLogReport> appErrLogReportList = new List<AppErrLogReport>();
                            appErrLogReportList = appErrLogService.GetAppErrLogReportList().ToList();
                            CheckAppErrLogReportFields(appErrLogReportList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogReportList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take Order

        #region Tests Generated for GetAppErrLogList() Skip Take 2Order
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "AppErrLogID,Tag", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = appErrLogService.GetRead().Skip(1).Take(1).OrderBy(c => c.AppErrLogID).ThenBy(c => c.Tag).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppErrLogWeb> appErrLogWebList = new List<AppErrLogWeb>();
                            appErrLogWebList = appErrLogService.GetAppErrLogWebList().ToList();
                            CheckAppErrLogWebFields(appErrLogWebList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogWebList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppErrLogReport> appErrLogReportList = new List<AppErrLogReport>();
                            appErrLogReportList = appErrLogService.GetAppErrLogReportList().ToList();
                            CheckAppErrLogReportFields(appErrLogReportList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogReportList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take 2Order

        #region Tests Generated for GetAppErrLogList() Skip Take Order Where
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "AppErrLogID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = appErrLogService.GetRead().Where(c => c.AppErrLogID == 4).Skip(0).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppErrLogWeb> appErrLogWebList = new List<AppErrLogWeb>();
                            appErrLogWebList = appErrLogService.GetAppErrLogWebList().ToList();
                            CheckAppErrLogWebFields(appErrLogWebList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogWebList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppErrLogReport> appErrLogReportList = new List<AppErrLogReport>();
                            appErrLogReportList = appErrLogService.GetAppErrLogReportList().ToList();
                            CheckAppErrLogReportFields(appErrLogReportList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogReportList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take Order Where

        #region Tests Generated for GetAppErrLogList() Skip Take Order 2Where
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "AppErrLogID,GT,2|AppErrLogID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = appErrLogService.GetRead().Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).Skip(0).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppErrLogWeb> appErrLogWebList = new List<AppErrLogWeb>();
                            appErrLogWebList = appErrLogService.GetAppErrLogWebList().ToList();
                            CheckAppErrLogWebFields(appErrLogWebList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogWebList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppErrLogReport> appErrLogReportList = new List<AppErrLogReport>();
                            appErrLogReportList = appErrLogService.GetAppErrLogReportList().ToList();
                            CheckAppErrLogReportFields(appErrLogReportList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogReportList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take Order 2Where

        #region Tests Generated for GetAppErrLogList() 2Where
        [TestMethod]
        public void GetAppErrLogList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 10000, "", "AppErrLogID,GT,2|AppErrLogID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = appErrLogService.GetRead().Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppErrLogWeb> appErrLogWebList = new List<AppErrLogWeb>();
                            appErrLogWebList = appErrLogService.GetAppErrLogWebList().ToList();
                            CheckAppErrLogWebFields(appErrLogWebList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogWebList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppErrLogReport> appErrLogReportList = new List<AppErrLogReport>();
                            appErrLogReportList = appErrLogService.GetAppErrLogReportList().ToList();
                            CheckAppErrLogReportFields(appErrLogReportList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogReportList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() 2Where

        #region Functions private
        private void CheckAppErrLogFields(List<AppErrLog> appErrLogList)
        {
            Assert.IsNotNull(appErrLogList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogList[0].Tag));
            Assert.IsNotNull(appErrLogList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogList[0].Message));
            Assert.IsNotNull(appErrLogList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLogList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLogList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLogList[0].HasErrors);
        }
        private void CheckAppErrLogWebFields(List<AppErrLogWeb> appErrLogWebList)
        {
            Assert.IsNotNull(appErrLogWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(appErrLogWebList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogWebList[0].Tag));
            Assert.IsNotNull(appErrLogWebList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogWebList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogWebList[0].Message));
            Assert.IsNotNull(appErrLogWebList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLogWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLogWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLogWebList[0].HasErrors);
        }
        private void CheckAppErrLogReportFields(List<AppErrLogReport> appErrLogReportList)
        {
            if (!string.IsNullOrWhiteSpace(appErrLogReportList[0].AppErrLogReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogReportList[0].AppErrLogReportTest));
            }
            Assert.IsNotNull(appErrLogReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(appErrLogReportList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogReportList[0].Tag));
            Assert.IsNotNull(appErrLogReportList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogReportList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogReportList[0].Message));
            Assert.IsNotNull(appErrLogReportList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLogReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLogReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLogReportList[0].HasErrors);
        }
        private AppErrLog GetFilledRandomAppErrLog(string OmitPropName)
        {
            AppErrLog appErrLog = new AppErrLog();

            if (OmitPropName != "Tag") appErrLog.Tag = GetRandomString("", 5);
            if (OmitPropName != "LineNumber") appErrLog.LineNumber = GetRandomInt(1, 11);
            if (OmitPropName != "Source") appErrLog.Source = GetRandomString("", 20);
            if (OmitPropName != "Message") appErrLog.Message = GetRandomString("", 20);
            if (OmitPropName != "DateTime_UTC") appErrLog.DateTime_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateDate_UTC") appErrLog.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appErrLog.LastUpdateContactTVItemID = 2;

            return appErrLog;
        }
        #endregion Functions private
    }
}
