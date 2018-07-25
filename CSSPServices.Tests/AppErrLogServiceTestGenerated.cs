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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogAppErrLogID), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.AppErrLogID = 10000000;
                    appErrLogService.Update(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AppErrLog, CSSPModelsRes.AppErrLogAppErrLogID, appErrLog.AppErrLogID.ToString()), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // appErrLog.Tag   (String)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("Tag");
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(1, appErrLog.ValidationResults.Count());
                    Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogTag)).Any());
                    Assert.AreEqual(null, appErrLog.Tag);
                    Assert.AreEqual(count, appErrLogService.GetRead().Count());

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.Tag = GetRandomString("", 101);
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppErrLogTag, "100"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.AppErrLogLineNumber, "1"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appErrLogService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // appErrLog.Source   (String)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("Source");
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(1, appErrLog.ValidationResults.Count());
                    Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogSource)).Any());
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
                    Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogMessage)).Any());
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogDateTime_UTC), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.DateTime_UTC = new DateTime(1979, 1, 1);
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppErrLogDateTime_UTC, "1980"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // appErrLog.AppErrLogWeb   (AppErrLogWeb)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.AppErrLogWeb = null;
                    Assert.IsNull(appErrLog.AppErrLogWeb);

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.AppErrLogWeb = new AppErrLogWeb();
                    Assert.IsNotNull(appErrLog.AppErrLogWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // appErrLog.AppErrLogReport   (AppErrLogReport)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.AppErrLogReport = null;
                    Assert.IsNull(appErrLog.AppErrLogReport);

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.AppErrLogReport = new AppErrLogReport();
                    Assert.IsNotNull(appErrLog.AppErrLogReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appErrLog.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateDate_UTC = new DateTime();
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogLastUpdateDate_UTC), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppErrLogLastUpdateDate_UTC, "1980"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // appErrLog.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateContactTVItemID = 0;
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppErrLogLastUpdateContactTVItemID, appErrLog.LastUpdateContactTVItemID.ToString()), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateContactTVItemID = 1;
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppErrLogLastUpdateContactTVItemID, "Contact"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);


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

                    AppErrLog appErrLogRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appErrLogService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID);
                            Assert.IsNull(appErrLogRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppErrLogFields(new List<AppErrLog>() { appErrLogRet }, entityQueryDetailType);
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

                    List<AppErrLog> appErrLogList = new List<AppErrLog>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appErrLogService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            Assert.AreEqual(0, appErrLogList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppErrLogFields(appErrLogList, entityQueryDetailType);
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
                    List<AppErrLog> appErrLogList = new List<AppErrLog>();
                    List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appErrLogDirectQueryList = appErrLogService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            Assert.AreEqual(0, appErrLogList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppErrLogFields(appErrLogList, entityQueryDetailType);
                        Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        Assert.AreEqual(1, appErrLogList.Count);
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
                    List<AppErrLog> appErrLogList = new List<AppErrLog>();
                    List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1,  "AppErrLogID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appErrLogDirectQueryList = appErrLogService.GetRead().Skip(1).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            Assert.AreEqual(0, appErrLogList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppErrLogFields(appErrLogList, entityQueryDetailType);
                        Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        Assert.AreEqual(1, appErrLogList.Count);
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
                    List<AppErrLog> appErrLogList = new List<AppErrLog>();
                    List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "AppErrLogID,Tag", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appErrLogDirectQueryList = appErrLogService.GetRead().Skip(1).Take(1).OrderBy(c => c.AppErrLogID).ThenBy(c => c.Tag).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            Assert.AreEqual(0, appErrLogList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppErrLogFields(appErrLogList, entityQueryDetailType);
                        Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        Assert.AreEqual(1, appErrLogList.Count);
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
                    List<AppErrLog> appErrLogList = new List<AppErrLog>();
                    List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "AppErrLogID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appErrLogDirectQueryList = appErrLogService.GetRead().Where(c => c.AppErrLogID == 4).Skip(0).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            Assert.AreEqual(0, appErrLogList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppErrLogFields(appErrLogList, entityQueryDetailType);
                        Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        Assert.AreEqual(1, appErrLogList.Count);
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
                    List<AppErrLog> appErrLogList = new List<AppErrLog>();
                    List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "AppErrLogID,GT,2|AppErrLogID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appErrLogDirectQueryList = appErrLogService.GetRead().Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).Skip(0).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            Assert.AreEqual(0, appErrLogList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppErrLogFields(appErrLogList, entityQueryDetailType);
                        Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        Assert.AreEqual(1, appErrLogList.Count);
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
                    List<AppErrLog> appErrLogList = new List<AppErrLog>();
                    List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 10000, "", "AppErrLogID,GT,2|AppErrLogID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appErrLogDirectQueryList = appErrLogService.GetRead().Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            Assert.AreEqual(0, appErrLogList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppErrLogFields(appErrLogList, entityQueryDetailType);
                        Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        Assert.AreEqual(2, appErrLogList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() 2Where

        #region Functions private
        private void CheckAppErrLogFields(List<AppErrLog> appErrLogList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // AppErrLog fields
            Assert.IsNotNull(appErrLogList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogList[0].Tag));
            Assert.IsNotNull(appErrLogList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogList[0].Message));
            Assert.IsNotNull(appErrLogList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLogList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLogList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // AppErrLogWeb and AppErrLogReport fields should be null here
                Assert.IsNull(appErrLogList[0].AppErrLogWeb);
                Assert.IsNull(appErrLogList[0].AppErrLogReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // AppErrLogWeb fields should not be null and AppErrLogReport fields should be null here
                if (!string.IsNullOrWhiteSpace(appErrLogList[0].AppErrLogWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogList[0].AppErrLogWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(appErrLogList[0].AppErrLogReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // AppErrLogWeb and AppErrLogReport fields should NOT be null here
                if (appErrLogList[0].AppErrLogWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogList[0].AppErrLogWeb.LastUpdateContactTVText));
                }
                if (appErrLogList[0].AppErrLogReport.AppErrLogTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogList[0].AppErrLogReport.AppErrLogTest));
                }
            }
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
