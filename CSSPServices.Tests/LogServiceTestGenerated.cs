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

        #region Functions public
        #endregion Functions public

        #region Functions private
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Log_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LogService logService = new LogService(new GetParam(), dbTestDB, ContactID);

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

                    count = logService.GetRead().Count();

                    Assert.AreEqual(logService.GetRead().Count(), logService.GetEdit().Count());

                    logService.Add(log);
                    if (log.HasErrors)
                    {
                        Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, logService.GetRead().Where(c => c == log).Any());
                    logService.Update(log);
                    if (log.HasErrors)
                    {
                        Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, logService.GetRead().Count());
                    logService.Delete(log);
                    if (log.HasErrors)
                    {
                        Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, logService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogLogID), log.ValidationResults.FirstOrDefault().ErrorMessage);

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogID = 10000000;
                    logService.Update(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Log, CSSPModelsRes.LogLogID, log.LogID.ToString()), log.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // log.TableName   (String)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("TableName");
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(1, log.ValidationResults.Count());
                    Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogTableName)).Any());
                    Assert.AreEqual(null, log.TableName);
                    Assert.AreEqual(count, logService.GetRead().Count());

                    log = null;
                    log = GetFilledRandomLog("");
                    log.TableName = GetRandomString("", 51);
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LogTableName, "50"), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, logService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, -1)]
                    // log.ID   (Int32)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.ID = 0;
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.LogID, "1"), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, logService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // log.LogCommand   (LogCommandEnum)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogCommand = (LogCommandEnum)1000000;
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogLogCommand), log.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // log.Information   (String)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("Information");
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(1, log.ValidationResults.Count());
                    Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogInformation)).Any());
                    Assert.AreEqual(null, log.Information);
                    Assert.AreEqual(count, logService.GetRead().Count());


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // log.LogWeb   (LogWeb)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogWeb = null;
                    Assert.IsNull(log.LogWeb);

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogWeb = new LogWeb();
                    Assert.IsNotNull(log.LogWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // log.LogReport   (LogReport)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogReport = null;
                    Assert.IsNull(log.LogReport);

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogReport = new LogReport();
                    Assert.IsNotNull(log.LogReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // log.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateDate_UTC = new DateTime();
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogLastUpdateDate_UTC), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LogLastUpdateDate_UTC, "1980"), log.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // log.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateContactTVItemID = 0;
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LogLastUpdateContactTVItemID, log.LastUpdateContactTVItemID.ToString()), log.ValidationResults.FirstOrDefault().ErrorMessage);

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateContactTVItemID = 1;
                    logService.Add(log);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LogLastUpdateContactTVItemID, "Contact"), log.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated Get With Key
        [TestMethod]
        public void Log_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    LogService logService = new LogService(new GetParam(), dbTestDB, ContactID);
                    Log log = (from c in logService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(log);

                    Log logRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            logRet = logService.GetLogWithLogID(log.LogID, getParam);
                            Assert.IsNull(logRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            logRet = logService.GetLogWithLogID(log.LogID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            logRet = logService.GetLogWithLogID(log.LogID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            logRet = logService.GetLogWithLogID(log.LogID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Log fields
                        Assert.IsNotNull(logRet.LogID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.TableName));
                        Assert.IsNotNull(logRet.ID);
                        Assert.IsNotNull(logRet.LogCommand);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.Information));
                        Assert.IsNotNull(logRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(logRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // LogWeb and LogReport fields should be null here
                            Assert.IsNull(logRet.LogWeb);
                            Assert.IsNull(logRet.LogReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // LogWeb fields should not be null and LogReport fields should be null here
                            if (logRet.LogWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.LogWeb.LastUpdateContactTVText));
                            }
                            if (logRet.LogWeb.LogCommandText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.LogWeb.LogCommandText));
                            }
                            Assert.IsNull(logRet.LogReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // LogWeb and LogReport fields should NOT be null here
                            if (logRet.LogWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.LogWeb.LastUpdateContactTVText));
                            }
                            if (logRet.LogWeb.LogCommandText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.LogWeb.LogCommandText));
                            }
                            if (logRet.LogReport.LogReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.LogReport.LogReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of Log
        #endregion Tests Get List of Log

    }
}
