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

                    count = appErrLogService.GetAppErrLogList().Count();

                    Assert.AreEqual(appErrLogService.GetAppErrLogList().Count(), (from c in dbTestDB.AppErrLogs select c).Take(200).Count());

                    appErrLogService.Add(appErrLog);
                    if (appErrLog.HasErrors)
                    {
                        Assert.AreEqual("", appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, appErrLogService.GetAppErrLogList().Where(c => c == appErrLog).Any());
                    appErrLogService.Update(appErrLog);
                    if (appErrLog.HasErrors)
                    {
                        Assert.AreEqual("", appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, appErrLogService.GetAppErrLogList().Count());
                    appErrLogService.Delete(appErrLog);
                    if (appErrLog.HasErrors)
                    {
                        Assert.AreEqual("", appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, appErrLogService.GetAppErrLogList().Count());

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
                    Assert.AreEqual(count, appErrLogService.GetAppErrLogList().Count());

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.Tag = GetRandomString("", 101);
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "AppErrLogTag", "100"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appErrLogService.GetAppErrLogList().Count());

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
                    Assert.AreEqual(count, appErrLogService.GetAppErrLogList().Count());

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
                    Assert.AreEqual(count, appErrLogService.GetAppErrLogList().Count());


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
                    Assert.AreEqual(count, appErrLogService.GetAppErrLogList().Count());


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
                    AppErrLog appErrLog = (from c in dbTestDB.AppErrLogs select c).FirstOrDefault();
                    Assert.IsNotNull(appErrLog);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        appErrLogService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            AppErrLog appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogFields(new List<AppErrLog>() { appErrLogRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogRet.AppErrLogID);
                        }
                        else if (detail == "A")
                        {
                            AppErrLog_A appErrLog_ARet = appErrLogService.GetAppErrLog_AWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLog_AFields(new List<AppErrLog_A>() { appErrLog_ARet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLog_ARet.AppErrLogID);
                        }
                        else if (detail == "B")
                        {
                            AppErrLog_B appErrLog_BRet = appErrLogService.GetAppErrLog_BWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLog_BFields(new List<AppErrLog_B>() { appErrLog_BRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLog_BRet.AppErrLogID);
                        }
                        else if (detail == "C")
                        {
                            AppErrLog_C appErrLog_CRet = appErrLogService.GetAppErrLog_CWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLog_CFields(new List<AppErrLog_C>() { appErrLog_CRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLog_CRet.AppErrLogID);
                        }
                        else if (detail == "D")
                        {
                            AppErrLog_D appErrLog_DRet = appErrLogService.GetAppErrLog_DWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLog_DFields(new List<AppErrLog_D>() { appErrLog_DRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLog_DRet.AppErrLogID);
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
                    AppErrLog appErrLog = (from c in dbTestDB.AppErrLogs select c).FirstOrDefault();
                    Assert.IsNotNull(appErrLog);

                    List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                    appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        appErrLogService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                        }
                        else if (detail == "A")
                        {
                            List<AppErrLog_A> appErrLog_AList = new List<AppErrLog_A>();
                            appErrLog_AList = appErrLogService.GetAppErrLog_AList().ToList();
                            CheckAppErrLog_AFields(appErrLog_AList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<AppErrLog_B> appErrLog_BList = new List<AppErrLog_B>();
                            appErrLog_BList = appErrLogService.GetAppErrLog_BList().ToList();
                            CheckAppErrLog_BFields(appErrLog_BList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_BList.Count);
                        }
                        else if (detail == "C")
                        {
                            List<AppErrLog_C> appErrLog_CList = new List<AppErrLog_C>();
                            appErrLog_CList = appErrLogService.GetAppErrLog_CList().ToList();
                            CheckAppErrLog_CFields(appErrLog_CList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_CList.Count);
                        }
                        else if (detail == "D")
                        {
                            List<AppErrLog_D> appErrLog_DList = new List<AppErrLog_D>();
                            appErrLog_DList = appErrLogService.GetAppErrLog_DList().ToList();
                            CheckAppErrLog_DFields(appErrLog_DList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_DList.Count);
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (detail == "A")
                        {
                            List<AppErrLog_A> appErrLog_AList = new List<AppErrLog_A>();
                            appErrLog_AList = appErrLogService.GetAppErrLog_AList().ToList();
                            CheckAppErrLog_AFields(appErrLog_AList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_AList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<AppErrLog_B> appErrLog_BList = new List<AppErrLog_B>();
                            appErrLog_BList = appErrLogService.GetAppErrLog_BList().ToList();
                            CheckAppErrLog_BFields(appErrLog_BList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_BList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_BList.Count);
                        }
                        else if (detail == "C")
                        {
                            List<AppErrLog_C> appErrLog_CList = new List<AppErrLog_C>();
                            appErrLog_CList = appErrLogService.GetAppErrLog_CList().ToList();
                            CheckAppErrLog_CFields(appErrLog_CList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_CList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_CList.Count);
                        }
                        else if (detail == "D")
                        {
                            List<AppErrLog_D> appErrLog_DList = new List<AppErrLog_D>();
                            appErrLog_DList = appErrLogService.GetAppErrLog_DList().ToList();
                            CheckAppErrLog_DFields(appErrLog_DList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_DList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_DList.Count);
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1,  "AppErrLogID", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Skip(1).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (detail == "A")
                        {
                            List<AppErrLog_A> appErrLog_AList = new List<AppErrLog_A>();
                            appErrLog_AList = appErrLogService.GetAppErrLog_AList().ToList();
                            CheckAppErrLog_AFields(appErrLog_AList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_AList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<AppErrLog_B> appErrLog_BList = new List<AppErrLog_B>();
                            appErrLog_BList = appErrLogService.GetAppErrLog_BList().ToList();
                            CheckAppErrLog_BFields(appErrLog_BList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_BList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_BList.Count);
                        }
                        else if (detail == "C")
                        {
                            List<AppErrLog_C> appErrLog_CList = new List<AppErrLog_C>();
                            appErrLog_CList = appErrLogService.GetAppErrLog_CList().ToList();
                            CheckAppErrLog_CFields(appErrLog_CList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_CList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_CList.Count);
                        }
                        else if (detail == "D")
                        {
                            List<AppErrLog_D> appErrLog_DList = new List<AppErrLog_D>();
                            appErrLog_DList = appErrLogService.GetAppErrLog_DList().ToList();
                            CheckAppErrLog_DFields(appErrLog_DList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_DList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_DList.Count);
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "AppErrLogID,Tag", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Skip(1).Take(1).OrderBy(c => c.AppErrLogID).ThenBy(c => c.Tag).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (detail == "A")
                        {
                            List<AppErrLog_A> appErrLog_AList = new List<AppErrLog_A>();
                            appErrLog_AList = appErrLogService.GetAppErrLog_AList().ToList();
                            CheckAppErrLog_AFields(appErrLog_AList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_AList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<AppErrLog_B> appErrLog_BList = new List<AppErrLog_B>();
                            appErrLog_BList = appErrLogService.GetAppErrLog_BList().ToList();
                            CheckAppErrLog_BFields(appErrLog_BList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_BList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_BList.Count);
                        }
                        else if (detail == "C")
                        {
                            List<AppErrLog_C> appErrLog_CList = new List<AppErrLog_C>();
                            appErrLog_CList = appErrLogService.GetAppErrLog_CList().ToList();
                            CheckAppErrLog_CFields(appErrLog_CList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_CList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_CList.Count);
                        }
                        else if (detail == "D")
                        {
                            List<AppErrLog_D> appErrLog_DList = new List<AppErrLog_D>();
                            appErrLog_DList = appErrLogService.GetAppErrLog_DList().ToList();
                            CheckAppErrLog_DFields(appErrLog_DList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_DList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_DList.Count);
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "AppErrLogID,EQ,4", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID == 4).Skip(0).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (detail == "A")
                        {
                            List<AppErrLog_A> appErrLog_AList = new List<AppErrLog_A>();
                            appErrLog_AList = appErrLogService.GetAppErrLog_AList().ToList();
                            CheckAppErrLog_AFields(appErrLog_AList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_AList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<AppErrLog_B> appErrLog_BList = new List<AppErrLog_B>();
                            appErrLog_BList = appErrLogService.GetAppErrLog_BList().ToList();
                            CheckAppErrLog_BFields(appErrLog_BList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_BList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_BList.Count);
                        }
                        else if (detail == "C")
                        {
                            List<AppErrLog_C> appErrLog_CList = new List<AppErrLog_C>();
                            appErrLog_CList = appErrLogService.GetAppErrLog_CList().ToList();
                            CheckAppErrLog_CFields(appErrLog_CList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_CList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_CList.Count);
                        }
                        else if (detail == "D")
                        {
                            List<AppErrLog_D> appErrLog_DList = new List<AppErrLog_D>();
                            appErrLog_DList = appErrLogService.GetAppErrLog_DList().ToList();
                            CheckAppErrLog_DFields(appErrLog_DList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_DList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_DList.Count);
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "AppErrLogID,GT,2|AppErrLogID,LT,5", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).Skip(0).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (detail == "A")
                        {
                            List<AppErrLog_A> appErrLog_AList = new List<AppErrLog_A>();
                            appErrLog_AList = appErrLogService.GetAppErrLog_AList().ToList();
                            CheckAppErrLog_AFields(appErrLog_AList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_AList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<AppErrLog_B> appErrLog_BList = new List<AppErrLog_B>();
                            appErrLog_BList = appErrLogService.GetAppErrLog_BList().ToList();
                            CheckAppErrLog_BFields(appErrLog_BList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_BList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_BList.Count);
                        }
                        else if (detail == "C")
                        {
                            List<AppErrLog_C> appErrLog_CList = new List<AppErrLog_C>();
                            appErrLog_CList = appErrLogService.GetAppErrLog_CList().ToList();
                            CheckAppErrLog_CFields(appErrLog_CList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_CList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_CList.Count);
                        }
                        else if (detail == "D")
                        {
                            List<AppErrLog_D> appErrLog_DList = new List<AppErrLog_D>();
                            appErrLog_DList = appErrLogService.GetAppErrLog_DList().ToList();
                            CheckAppErrLog_DFields(appErrLog_DList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_DList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_DList.Count);
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 10000, "", "AppErrLogID,GT,2|AppErrLogID,LT,5", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (detail == "A")
                        {
                            List<AppErrLog_A> appErrLog_AList = new List<AppErrLog_A>();
                            appErrLog_AList = appErrLogService.GetAppErrLog_AList().ToList();
                            CheckAppErrLog_AFields(appErrLog_AList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_AList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<AppErrLog_B> appErrLog_BList = new List<AppErrLog_B>();
                            appErrLog_BList = appErrLogService.GetAppErrLog_BList().ToList();
                            CheckAppErrLog_BFields(appErrLog_BList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_BList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_BList.Count);
                        }
                        else if (detail == "C")
                        {
                            List<AppErrLog_C> appErrLog_CList = new List<AppErrLog_C>();
                            appErrLog_CList = appErrLogService.GetAppErrLog_CList().ToList();
                            CheckAppErrLog_CFields(appErrLog_CList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_CList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_CList.Count);
                        }
                        else if (detail == "D")
                        {
                            List<AppErrLog_D> appErrLog_DList = new List<AppErrLog_D>();
                            appErrLog_DList = appErrLogService.GetAppErrLog_DList().ToList();
                            CheckAppErrLog_DFields(appErrLog_DList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLog_DList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLog_DList.Count);
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
        private void CheckAppErrLog_AFields(List<AppErrLog_A> appErrLog_AList)
        {
            Assert.IsNotNull(appErrLog_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(appErrLog_AList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_AList[0].Tag));
            Assert.IsNotNull(appErrLog_AList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_AList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_AList[0].Message));
            Assert.IsNotNull(appErrLog_AList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLog_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLog_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLog_AList[0].HasErrors);
        }
        private void CheckAppErrLog_BFields(List<AppErrLog_B> appErrLog_BList)
        {
            if (!string.IsNullOrWhiteSpace(appErrLog_BList[0].AppErrLogReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_BList[0].AppErrLogReportTest));
            }
            Assert.IsNotNull(appErrLog_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(appErrLog_BList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_BList[0].Tag));
            Assert.IsNotNull(appErrLog_BList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_BList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_BList[0].Message));
            Assert.IsNotNull(appErrLog_BList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLog_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLog_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLog_BList[0].HasErrors);
        }
        private void CheckAppErrLog_CFields(List<AppErrLog_C> appErrLog_CList)
        {
            if (!string.IsNullOrWhiteSpace(appErrLog_CList[0].AppErrLogReportTest2))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_CList[0].AppErrLogReportTest2));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_CList[0].AppErrLogReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_CList[0].AppErrLogReportTest));
            }
            Assert.IsNotNull(appErrLog_CList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(appErrLog_CList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_CList[0].Tag));
            Assert.IsNotNull(appErrLog_CList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_CList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_CList[0].Message));
            Assert.IsNotNull(appErrLog_CList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLog_CList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLog_CList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLog_CList[0].HasErrors);
        }
        private void CheckAppErrLog_DFields(List<AppErrLog_D> appErrLog_DList)
        {
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2K))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2K));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2H))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2H));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2D))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2D));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2G))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2G));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2S))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2S));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2L))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2L));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2C))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2C));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2B))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2B));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2A))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2A));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest2));
            }
            if (!string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].AppErrLogReportTest));
            }
            Assert.IsNotNull(appErrLog_DList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(appErrLog_DList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].Tag));
            Assert.IsNotNull(appErrLog_DList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLog_DList[0].Message));
            Assert.IsNotNull(appErrLog_DList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLog_DList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLog_DList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLog_DList[0].HasErrors);
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
