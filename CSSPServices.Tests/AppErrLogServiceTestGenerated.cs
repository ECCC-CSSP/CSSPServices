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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    Assert.AreEqual(count, (from c in dbTestDB.AppErrLogs select c).Count());

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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppErrLog appErrLog = (from c in dbTestDB.AppErrLogs select c).FirstOrDefault();
                    Assert.IsNotNull(appErrLog);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        appErrLogService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            AppErrLog appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogFields(new List<AppErrLog>() { appErrLogRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogRet.AppErrLogID);
                        }
                        else if (extra == "ExtraA")
                        {
                            AppErrLogExtraA appErrLogExtraARet = appErrLogService.GetAppErrLogExtraAWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogExtraAFields(new List<AppErrLogExtraA>() { appErrLogExtraARet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogExtraARet.AppErrLogID);
                        }
                        else if (extra == "ExtraB")
                        {
                            AppErrLogExtraB appErrLogExtraBRet = appErrLogService.GetAppErrLogExtraBWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogExtraBFields(new List<AppErrLogExtraB>() { appErrLogExtraBRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogExtraBRet.AppErrLogID);
                        }
                        else if (extra == "ExtraC")
                        {
                            AppErrLogExtraC appErrLogExtraCRet = appErrLogService.GetAppErrLogExtraCWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogExtraCFields(new List<AppErrLogExtraC>() { appErrLogExtraCRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogExtraCRet.AppErrLogID);
                        }
                        else if (extra == "ExtraD")
                        {
                            AppErrLogExtraD appErrLogExtraDRet = appErrLogService.GetAppErrLogExtraDWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogExtraDFields(new List<AppErrLogExtraD>() { appErrLogExtraDRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogExtraDRet.AppErrLogID);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppErrLog appErrLog = (from c in dbTestDB.AppErrLogs select c).FirstOrDefault();
                    Assert.IsNotNull(appErrLog);

                    List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                    appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        appErrLogService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<AppErrLogExtraA> appErrLogExtraAList = new List<AppErrLogExtraA>();
                            appErrLogExtraAList = appErrLogService.GetAppErrLogExtraAList().ToList();
                            CheckAppErrLogExtraAFields(appErrLogExtraAList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<AppErrLogExtraB> appErrLogExtraBList = new List<AppErrLogExtraB>();
                            appErrLogExtraBList = appErrLogService.GetAppErrLogExtraBList().ToList();
                            CheckAppErrLogExtraBFields(appErrLogExtraBList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraBList.Count);
                        }
                        else if (extra == "ExtraC")
                        {
                            List<AppErrLogExtraC> appErrLogExtraCList = new List<AppErrLogExtraC>();
                            appErrLogExtraCList = appErrLogService.GetAppErrLogExtraCList().ToList();
                            CheckAppErrLogExtraCFields(appErrLogExtraCList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraCList.Count);
                        }
                        else if (extra == "ExtraD")
                        {
                            List<AppErrLogExtraD> appErrLogExtraDList = new List<AppErrLogExtraD>();
                            appErrLogExtraDList = appErrLogService.GetAppErrLogExtraDList().ToList();
                            CheckAppErrLogExtraDFields(appErrLogExtraDList);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraDList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<AppErrLogExtraA> appErrLogExtraAList = new List<AppErrLogExtraA>();
                            appErrLogExtraAList = appErrLogService.GetAppErrLogExtraAList().ToList();
                            CheckAppErrLogExtraAFields(appErrLogExtraAList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraAList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<AppErrLogExtraB> appErrLogExtraBList = new List<AppErrLogExtraB>();
                            appErrLogExtraBList = appErrLogService.GetAppErrLogExtraBList().ToList();
                            CheckAppErrLogExtraBFields(appErrLogExtraBList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraBList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraBList.Count);
                        }
                        else if (extra == "ExtraC")
                        {
                            List<AppErrLogExtraC> appErrLogExtraCList = new List<AppErrLogExtraC>();
                            appErrLogExtraCList = appErrLogService.GetAppErrLogExtraCList().ToList();
                            CheckAppErrLogExtraCFields(appErrLogExtraCList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraCList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraCList.Count);
                        }
                        else if (extra == "ExtraD")
                        {
                            List<AppErrLogExtraD> appErrLogExtraDList = new List<AppErrLogExtraD>();
                            appErrLogExtraDList = appErrLogService.GetAppErrLogExtraDList().ToList();
                            CheckAppErrLogExtraDFields(appErrLogExtraDList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraDList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraDList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1,  "AppErrLogID", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Skip(1).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<AppErrLogExtraA> appErrLogExtraAList = new List<AppErrLogExtraA>();
                            appErrLogExtraAList = appErrLogService.GetAppErrLogExtraAList().ToList();
                            CheckAppErrLogExtraAFields(appErrLogExtraAList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraAList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<AppErrLogExtraB> appErrLogExtraBList = new List<AppErrLogExtraB>();
                            appErrLogExtraBList = appErrLogService.GetAppErrLogExtraBList().ToList();
                            CheckAppErrLogExtraBFields(appErrLogExtraBList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraBList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraBList.Count);
                        }
                        else if (extra == "ExtraC")
                        {
                            List<AppErrLogExtraC> appErrLogExtraCList = new List<AppErrLogExtraC>();
                            appErrLogExtraCList = appErrLogService.GetAppErrLogExtraCList().ToList();
                            CheckAppErrLogExtraCFields(appErrLogExtraCList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraCList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraCList.Count);
                        }
                        else if (extra == "ExtraD")
                        {
                            List<AppErrLogExtraD> appErrLogExtraDList = new List<AppErrLogExtraD>();
                            appErrLogExtraDList = appErrLogService.GetAppErrLogExtraDList().ToList();
                            CheckAppErrLogExtraDFields(appErrLogExtraDList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraDList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraDList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "AppErrLogID,Tag", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Skip(1).Take(1).OrderBy(c => c.AppErrLogID).ThenBy(c => c.Tag).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<AppErrLogExtraA> appErrLogExtraAList = new List<AppErrLogExtraA>();
                            appErrLogExtraAList = appErrLogService.GetAppErrLogExtraAList().ToList();
                            CheckAppErrLogExtraAFields(appErrLogExtraAList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraAList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<AppErrLogExtraB> appErrLogExtraBList = new List<AppErrLogExtraB>();
                            appErrLogExtraBList = appErrLogService.GetAppErrLogExtraBList().ToList();
                            CheckAppErrLogExtraBFields(appErrLogExtraBList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraBList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraBList.Count);
                        }
                        else if (extra == "ExtraC")
                        {
                            List<AppErrLogExtraC> appErrLogExtraCList = new List<AppErrLogExtraC>();
                            appErrLogExtraCList = appErrLogService.GetAppErrLogExtraCList().ToList();
                            CheckAppErrLogExtraCFields(appErrLogExtraCList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraCList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraCList.Count);
                        }
                        else if (extra == "ExtraD")
                        {
                            List<AppErrLogExtraD> appErrLogExtraDList = new List<AppErrLogExtraD>();
                            appErrLogExtraDList = appErrLogService.GetAppErrLogExtraDList().ToList();
                            CheckAppErrLogExtraDFields(appErrLogExtraDList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraDList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraDList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "AppErrLogID,EQ,4", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID == 4).Skip(0).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<AppErrLogExtraA> appErrLogExtraAList = new List<AppErrLogExtraA>();
                            appErrLogExtraAList = appErrLogService.GetAppErrLogExtraAList().ToList();
                            CheckAppErrLogExtraAFields(appErrLogExtraAList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraAList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<AppErrLogExtraB> appErrLogExtraBList = new List<AppErrLogExtraB>();
                            appErrLogExtraBList = appErrLogService.GetAppErrLogExtraBList().ToList();
                            CheckAppErrLogExtraBFields(appErrLogExtraBList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraBList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraBList.Count);
                        }
                        else if (extra == "ExtraC")
                        {
                            List<AppErrLogExtraC> appErrLogExtraCList = new List<AppErrLogExtraC>();
                            appErrLogExtraCList = appErrLogService.GetAppErrLogExtraCList().ToList();
                            CheckAppErrLogExtraCFields(appErrLogExtraCList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraCList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraCList.Count);
                        }
                        else if (extra == "ExtraD")
                        {
                            List<AppErrLogExtraD> appErrLogExtraDList = new List<AppErrLogExtraD>();
                            appErrLogExtraDList = appErrLogService.GetAppErrLogExtraDList().ToList();
                            CheckAppErrLogExtraDFields(appErrLogExtraDList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraDList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraDList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "AppErrLogID,GT,2|AppErrLogID,LT,5", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).Skip(0).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<AppErrLogExtraA> appErrLogExtraAList = new List<AppErrLogExtraA>();
                            appErrLogExtraAList = appErrLogService.GetAppErrLogExtraAList().ToList();
                            CheckAppErrLogExtraAFields(appErrLogExtraAList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraAList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<AppErrLogExtraB> appErrLogExtraBList = new List<AppErrLogExtraB>();
                            appErrLogExtraBList = appErrLogService.GetAppErrLogExtraBList().ToList();
                            CheckAppErrLogExtraBFields(appErrLogExtraBList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraBList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraBList.Count);
                        }
                        else if (extra == "ExtraC")
                        {
                            List<AppErrLogExtraC> appErrLogExtraCList = new List<AppErrLogExtraC>();
                            appErrLogExtraCList = appErrLogService.GetAppErrLogExtraCList().ToList();
                            CheckAppErrLogExtraCFields(appErrLogExtraCList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraCList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraCList.Count);
                        }
                        else if (extra == "ExtraD")
                        {
                            List<AppErrLogExtraD> appErrLogExtraDList = new List<AppErrLogExtraD>();
                            appErrLogExtraDList = appErrLogService.GetAppErrLogExtraDList().ToList();
                            CheckAppErrLogExtraDFields(appErrLogExtraDList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraDList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraDList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 10000, "", "AppErrLogID,GT,2|AppErrLogID,LT,5", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<AppErrLogExtraA> appErrLogExtraAList = new List<AppErrLogExtraA>();
                            appErrLogExtraAList = appErrLogService.GetAppErrLogExtraAList().ToList();
                            CheckAppErrLogExtraAFields(appErrLogExtraAList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraAList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<AppErrLogExtraB> appErrLogExtraBList = new List<AppErrLogExtraB>();
                            appErrLogExtraBList = appErrLogService.GetAppErrLogExtraBList().ToList();
                            CheckAppErrLogExtraBFields(appErrLogExtraBList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraBList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraBList.Count);
                        }
                        else if (extra == "ExtraC")
                        {
                            List<AppErrLogExtraC> appErrLogExtraCList = new List<AppErrLogExtraC>();
                            appErrLogExtraCList = appErrLogService.GetAppErrLogExtraCList().ToList();
                            CheckAppErrLogExtraCFields(appErrLogExtraCList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraCList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraCList.Count);
                        }
                        else if (extra == "ExtraD")
                        {
                            List<AppErrLogExtraD> appErrLogExtraDList = new List<AppErrLogExtraD>();
                            appErrLogExtraDList = appErrLogService.GetAppErrLogExtraDList().ToList();
                            CheckAppErrLogExtraDFields(appErrLogExtraDList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogExtraDList[0].AppErrLogID);
                            Assert.AreEqual(appErrLogDirectQueryList.Count, appErrLogExtraDList.Count);
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
        private void CheckAppErrLogExtraAFields(List<AppErrLogExtraA> appErrLogExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraAList[0].LastUpdateContactText));
            Assert.IsNotNull(appErrLogExtraAList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraAList[0].Tag));
            Assert.IsNotNull(appErrLogExtraAList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraAList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraAList[0].Message));
            Assert.IsNotNull(appErrLogExtraAList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLogExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLogExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLogExtraAList[0].HasErrors);
        }
        private void CheckAppErrLogExtraBFields(List<AppErrLogExtraB> appErrLogExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(appErrLogExtraBList[0].AppErrLogReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraBList[0].AppErrLogReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraBList[0].LastUpdateContactText));
            Assert.IsNotNull(appErrLogExtraBList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraBList[0].Tag));
            Assert.IsNotNull(appErrLogExtraBList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraBList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraBList[0].Message));
            Assert.IsNotNull(appErrLogExtraBList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLogExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLogExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLogExtraBList[0].HasErrors);
        }
        private void CheckAppErrLogExtraCFields(List<AppErrLogExtraC> appErrLogExtraCList)
        {
            if (!string.IsNullOrWhiteSpace(appErrLogExtraCList[0].AppErrLogReportTest2))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraCList[0].AppErrLogReportTest2));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraCList[0].AppErrLogReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraCList[0].AppErrLogReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraCList[0].LastUpdateContactText));
            Assert.IsNotNull(appErrLogExtraCList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraCList[0].Tag));
            Assert.IsNotNull(appErrLogExtraCList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraCList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraCList[0].Message));
            Assert.IsNotNull(appErrLogExtraCList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLogExtraCList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLogExtraCList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLogExtraCList[0].HasErrors);
        }
        private void CheckAppErrLogExtraDFields(List<AppErrLogExtraD> appErrLogExtraDList)
        {
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2K))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2K));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2H))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2H));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2D))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2D));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2G))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2G));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2S))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2S));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2L))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2L));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2C))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2C));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2B))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2B));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2A))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2A));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest2));
            }
            if (!string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].AppErrLogReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].LastUpdateContactText));
            Assert.IsNotNull(appErrLogExtraDList[0].AppErrLogID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].Tag));
            Assert.IsNotNull(appErrLogExtraDList[0].LineNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].Source));
            Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogExtraDList[0].Message));
            Assert.IsNotNull(appErrLogExtraDList[0].DateTime_UTC);
            Assert.IsNotNull(appErrLogExtraDList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appErrLogExtraDList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appErrLogExtraDList[0].HasErrors);
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
