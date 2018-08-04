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
    public partial class LogServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LogService logService { get; set; }
        #endregion Properties

        #region Constructors
        public LogServiceTest() : base()
        {
            //logService = new LogService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Log_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LogService logService = new LogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Log log = GetFilledRandomLog("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = logService.GetLogList().Count();

                    Assert.AreEqual(logService.GetLogList().Count(), (from c in dbTestDB.Logs select c).Take(200).Count());

                    logService.Add(log);
                    if (log.HasErrors)
                    {
                        Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, logService.GetLogList().Where(c => c == log).Any());
                    logService.Update(log);
                    if (log.HasErrors)
                    {
                        Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, logService.GetLogList().Count());
                    logService.Delete(log);
                    if (log.HasErrors)
                    {
                        Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, logService.GetLogList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // log.LogID   (Int32)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogID = 0;
                    logService.Update(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LogLogID"), log.ValidationResults.FirstOrDefault().ErrorMessage);

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogID = 10000000;
                    logService.Update(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Log", "LogLogID", log.LogID.ToString()), log.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // log.TableName   (String)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("TableName");
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(1, log.ValidationResults.Count());
                    Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "LogTableName")).Any());
                    Assert.AreEqual(null, log.TableName);
                    Assert.AreEqual(count, logService.GetLogList().Count());

                    log = null;
                    log = GetFilledRandomLog("");
                    log.TableName = GetRandomString("", 51);
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "LogTableName", "50"), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, logService.GetLogList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, -1)]
                    // log.ID   (Int32)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.ID = 0;
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "LogID", "1"), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, logService.GetLogList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // log.LogCommand   (LogCommandEnum)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogCommand = (LogCommandEnum)1000000;
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LogLogCommand"), log.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // log.Information   (String)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("Information");
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(1, log.ValidationResults.Count());
                    Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "LogInformation")).Any());
                    Assert.AreEqual(null, log.Information);
                    Assert.AreEqual(count, logService.GetLogList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // log.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateDate_UTC = new DateTime();
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LogLastUpdateDate_UTC"), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LogLastUpdateDate_UTC", "1980"), log.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // log.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateContactTVItemID = 0;
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LogLastUpdateContactTVItemID", log.LastUpdateContactTVItemID.ToString()), log.ValidationResults.FirstOrDefault().ErrorMessage);

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateContactTVItemID = 1;
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LogLastUpdateContactTVItemID", "Contact"), log.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // log.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // log.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetLogWithLogID(log.LogID)
        [TestMethod]
        public void GetLogWithLogID__log_LogID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LogService logService = new LogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Log log = (from c in dbTestDB.Logs select c).FirstOrDefault();
                    Assert.IsNotNull(log);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        logService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            Log logRet = logService.GetLogWithLogID(log.LogID);
                            CheckLogFields(new List<Log>() { logRet });
                            Assert.AreEqual(log.LogID, logRet.LogID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            LogWeb logWebRet = logService.GetLogWebWithLogID(log.LogID);
                            CheckLogWebFields(new List<LogWeb>() { logWebRet });
                            Assert.AreEqual(log.LogID, logWebRet.LogID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            LogReport logReportRet = logService.GetLogReportWithLogID(log.LogID);
                            CheckLogReportFields(new List<LogReport>() { logReportRet });
                            Assert.AreEqual(log.LogID, logReportRet.LogID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLogWithLogID(log.LogID)

        #region Tests Generated for GetLogList()
        [TestMethod]
        public void GetLogList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LogService logService = new LogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Log log = (from c in dbTestDB.Logs select c).FirstOrDefault();
                    Assert.IsNotNull(log);

                    List<Log> logDirectQueryList = new List<Log>();
                    logDirectQueryList = (from c in dbTestDB.Logs select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        logService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Log> logList = new List<Log>();
                            logList = logService.GetLogList().ToList();
                            CheckLogFields(logList);
                            Assert.AreEqual(logDirectQueryList.Count, logList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LogWeb> logWebList = new List<LogWeb>();
                            logWebList = logService.GetLogWebList().ToList();
                            CheckLogWebFields(logWebList);
                            Assert.AreEqual(logDirectQueryList.Count, logWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LogReport> logReportList = new List<LogReport>();
                            logReportList = logService.GetLogReportList().ToList();
                            CheckLogReportFields(logReportList);
                            Assert.AreEqual(logDirectQueryList.Count, logReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLogList()

        #region Tests Generated for GetLogList() Skip Take
        [TestMethod]
        public void GetLogList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LogService logService = new LogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        logService.Query = logService.FillQuery(typeof(Log), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Log> logDirectQueryList = new List<Log>();
                        logDirectQueryList = (from c in dbTestDB.Logs select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Log> logList = new List<Log>();
                            logList = logService.GetLogList().ToList();
                            CheckLogFields(logList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LogWeb> logWebList = new List<LogWeb>();
                            logWebList = logService.GetLogWebList().ToList();
                            CheckLogWebFields(logWebList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logWebList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LogReport> logReportList = new List<LogReport>();
                            logReportList = logService.GetLogReportList().ToList();
                            CheckLogReportFields(logReportList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logReportList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLogList() Skip Take

        #region Tests Generated for GetLogList() Skip Take Order
        [TestMethod]
        public void GetLogList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LogService logService = new LogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        logService.Query = logService.FillQuery(typeof(Log), culture.TwoLetterISOLanguageName, 1, 1,  "LogID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Log> logDirectQueryList = new List<Log>();
                        logDirectQueryList = (from c in dbTestDB.Logs select c).Skip(1).Take(1).OrderBy(c => c.LogID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Log> logList = new List<Log>();
                            logList = logService.GetLogList().ToList();
                            CheckLogFields(logList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LogWeb> logWebList = new List<LogWeb>();
                            logWebList = logService.GetLogWebList().ToList();
                            CheckLogWebFields(logWebList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logWebList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LogReport> logReportList = new List<LogReport>();
                            logReportList = logService.GetLogReportList().ToList();
                            CheckLogReportFields(logReportList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logReportList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLogList() Skip Take Order

        #region Tests Generated for GetLogList() Skip Take 2Order
        [TestMethod]
        public void GetLogList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LogService logService = new LogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        logService.Query = logService.FillQuery(typeof(Log), culture.TwoLetterISOLanguageName, 1, 1, "LogID,TableName", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Log> logDirectQueryList = new List<Log>();
                        logDirectQueryList = (from c in dbTestDB.Logs select c).Skip(1).Take(1).OrderBy(c => c.LogID).ThenBy(c => c.TableName).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Log> logList = new List<Log>();
                            logList = logService.GetLogList().ToList();
                            CheckLogFields(logList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LogWeb> logWebList = new List<LogWeb>();
                            logWebList = logService.GetLogWebList().ToList();
                            CheckLogWebFields(logWebList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logWebList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LogReport> logReportList = new List<LogReport>();
                            logReportList = logService.GetLogReportList().ToList();
                            CheckLogReportFields(logReportList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logReportList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLogList() Skip Take 2Order

        #region Tests Generated for GetLogList() Skip Take Order Where
        [TestMethod]
        public void GetLogList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LogService logService = new LogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        logService.Query = logService.FillQuery(typeof(Log), culture.TwoLetterISOLanguageName, 0, 1, "LogID", "LogID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Log> logDirectQueryList = new List<Log>();
                        logDirectQueryList = (from c in dbTestDB.Logs select c).Where(c => c.LogID == 4).Skip(0).Take(1).OrderBy(c => c.LogID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Log> logList = new List<Log>();
                            logList = logService.GetLogList().ToList();
                            CheckLogFields(logList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LogWeb> logWebList = new List<LogWeb>();
                            logWebList = logService.GetLogWebList().ToList();
                            CheckLogWebFields(logWebList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logWebList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LogReport> logReportList = new List<LogReport>();
                            logReportList = logService.GetLogReportList().ToList();
                            CheckLogReportFields(logReportList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logReportList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLogList() Skip Take Order Where

        #region Tests Generated for GetLogList() Skip Take Order 2Where
        [TestMethod]
        public void GetLogList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LogService logService = new LogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        logService.Query = logService.FillQuery(typeof(Log), culture.TwoLetterISOLanguageName, 0, 1, "LogID", "LogID,GT,2|LogID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Log> logDirectQueryList = new List<Log>();
                        logDirectQueryList = (from c in dbTestDB.Logs select c).Where(c => c.LogID > 2 && c.LogID < 5).Skip(0).Take(1).OrderBy(c => c.LogID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Log> logList = new List<Log>();
                            logList = logService.GetLogList().ToList();
                            CheckLogFields(logList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LogWeb> logWebList = new List<LogWeb>();
                            logWebList = logService.GetLogWebList().ToList();
                            CheckLogWebFields(logWebList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logWebList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LogReport> logReportList = new List<LogReport>();
                            logReportList = logService.GetLogReportList().ToList();
                            CheckLogReportFields(logReportList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logReportList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLogList() Skip Take Order 2Where

        #region Tests Generated for GetLogList() 2Where
        [TestMethod]
        public void GetLogList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LogService logService = new LogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        logService.Query = logService.FillQuery(typeof(Log), culture.TwoLetterISOLanguageName, 0, 10000, "", "LogID,GT,2|LogID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<Log> logDirectQueryList = new List<Log>();
                        logDirectQueryList = (from c in dbTestDB.Logs select c).Where(c => c.LogID > 2 && c.LogID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<Log> logList = new List<Log>();
                            logList = logService.GetLogList().ToList();
                            CheckLogFields(logList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LogWeb> logWebList = new List<LogWeb>();
                            logWebList = logService.GetLogWebList().ToList();
                            CheckLogWebFields(logWebList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logWebList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LogReport> logReportList = new List<LogReport>();
                            logReportList = logService.GetLogReportList().ToList();
                            CheckLogReportFields(logReportList);
                            Assert.AreEqual(logDirectQueryList[0].LogID, logReportList[0].LogID);
                            Assert.AreEqual(logDirectQueryList.Count, logReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLogList() 2Where

        #region Functions private
        private void CheckLogFields(List<Log> logList)
        {
            Assert.IsNotNull(logList[0].LogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(logList[0].TableName));
            Assert.IsNotNull(logList[0].ID);
            Assert.IsNotNull(logList[0].LogCommand);
            Assert.IsFalse(string.IsNullOrWhiteSpace(logList[0].Information));
            Assert.IsNotNull(logList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(logList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(logList[0].HasErrors);
        }
        private void CheckLogWebFields(List<LogWeb> logWebList)
        {
            Assert.IsNotNull(logWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(logWebList[0].LogCommandText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(logWebList[0].LogCommandText));
            }
            Assert.IsNotNull(logWebList[0].LogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(logWebList[0].TableName));
            Assert.IsNotNull(logWebList[0].ID);
            Assert.IsNotNull(logWebList[0].LogCommand);
            Assert.IsFalse(string.IsNullOrWhiteSpace(logWebList[0].Information));
            Assert.IsNotNull(logWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(logWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(logWebList[0].HasErrors);
        }
        private void CheckLogReportFields(List<LogReport> logReportList)
        {
            if (!string.IsNullOrWhiteSpace(logReportList[0].LogReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(logReportList[0].LogReportTest));
            }
            Assert.IsNotNull(logReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(logReportList[0].LogCommandText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(logReportList[0].LogCommandText));
            }
            Assert.IsNotNull(logReportList[0].LogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(logReportList[0].TableName));
            Assert.IsNotNull(logReportList[0].ID);
            Assert.IsNotNull(logReportList[0].LogCommand);
            Assert.IsFalse(string.IsNullOrWhiteSpace(logReportList[0].Information));
            Assert.IsNotNull(logReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(logReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(logReportList[0].HasErrors);
        }
        private Log GetFilledRandomLog(string OmitPropName)
        {
            Log log = new Log();

            if (OmitPropName != "TableName") log.TableName = GetRandomString("", 5);
            if (OmitPropName != "ID") log.ID = GetRandomInt(1, 11);
            if (OmitPropName != "LogCommand") log.LogCommand = (LogCommandEnum)GetRandomEnumType(typeof(LogCommandEnum));
            if (OmitPropName != "Information") log.Information = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") log.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") log.LastUpdateContactTVItemID = 2;

            return log;
        }
        #endregion Functions private
    }
}
