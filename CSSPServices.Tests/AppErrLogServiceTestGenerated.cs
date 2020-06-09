 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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

        #region Tests Generated CRUD
        [TestMethod]
        public void AppErrLog_CRUD_Test()
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

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [TestMethod]
        public void AppErrLog_Properties_Test()
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

                    count = appErrLogService.GetAppErrLogList().Count();

                    AppErrLog appErrLog = GetFilledRandomAppErrLog("");

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppErrLogID"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.AppErrLogID = 10000000;
                    appErrLogService.Update(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogID", appErrLog.AppErrLogID.ToString()), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // appErrLog.Tag   (String)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("Tag");
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(1, appErrLog.ValidationResults.Count());
                    Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Tag")).Any());
                    Assert.AreEqual(null, appErrLog.Tag);
                    Assert.AreEqual(count, appErrLogService.GetAppErrLogList().Count());

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.Tag = GetRandomString("", 101);
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "Tag", "100"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "LineNumber", "1"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appErrLogService.GetAppErrLogList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // appErrLog.Source   (String)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("Source");
                    Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                    Assert.AreEqual(1, appErrLog.ValidationResults.Count());
                    Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Source")).Any());
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
                    Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Message")).Any());
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "DateTime_UTC"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.DateTime_UTC = new DateTime(1979, 1, 1);
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "DateTime_UTC", "1980"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appErrLog.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateDate_UTC = new DateTime();
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // appErrLog.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateContactTVItemID = 0;
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appErrLog.LastUpdateContactTVItemID.ToString()), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                    appErrLog = null;
                    appErrLog = GetFilledRandomAppErrLog("");
                    appErrLog.LastUpdateContactTVItemID = 1;
                    appErrLogService.Add(appErrLog);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);


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
        #endregion Tests Generated Properties

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

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        appErrLogService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            AppErrLog appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID);
                            CheckAppErrLogFields(new List<AppErrLog>() { appErrLogRet });
                            Assert.AreEqual(appErrLog.AppErrLogID, appErrLogRet.AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
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

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        appErrLogService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
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
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "", "", "", extra);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take

        #region Tests Generated for GetAppErrLogList() Skip Take Asc
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1,  "AppErrLogID", "", "", extra);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).OrderBy(c => c.AppErrLogID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take Asc

        #region Tests Generated for GetAppErrLogList() Skip Take 2 Asc
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "AppErrLogID,Tag", "", "", extra);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).OrderBy(c => c.AppErrLogID).ThenBy(c => c.Tag).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take 2 Asc

        #region Tests Generated for GetAppErrLogList() Skip Take Asc Where
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "", "AppErrLogID,EQ,4", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID == 4).OrderBy(c => c.AppErrLogID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take Asc Where

        #region Tests Generated for GetAppErrLogList() Skip Take Asc 2 Where
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "", "AppErrLogID,GT,2|AppErrLogID,LT,5", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).Skip(0).Take(1).OrderBy(c => c.AppErrLogID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take Asc 2 Where

        #region Tests Generated for GetAppErrLogList() Skip Take Desc
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "", "AppErrLogID", "", extra);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).OrderByDescending(c => c.AppErrLogID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take Desc

        #region Tests Generated for GetAppErrLogList() Skip Take 2 Desc
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 1, 1, "", "AppErrLogID,Tag", "", extra);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).OrderByDescending(c => c.AppErrLogID).ThenByDescending(c => c.Tag).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take 2 Desc

        #region Tests Generated for GetAppErrLogList() Skip Take Desc Where
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "AppErrLogID", "", "AppErrLogID,EQ,4", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID == 4).OrderByDescending(c => c.AppErrLogID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take Desc Where

        #region Tests Generated for GetAppErrLogList() Skip Take Desc 2 Where
        [TestMethod]
        public void GetAppErrLogList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 1, "", "AppErrLogID", "AppErrLogID,GT,2|AppErrLogID,LT,5", "");

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).OrderByDescending(c => c.AppErrLogID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() Skip Take Desc 2 Where

        #region Tests Generated for GetAppErrLogList() 2 Where
        [TestMethod]
        public void GetAppErrLogList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        AppErrLogService appErrLogService = new AppErrLogService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appErrLogService.Query = appErrLogService.FillQuery(typeof(AppErrLog), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "AppErrLogID,GT,2|AppErrLogID,LT,5", extra);

                        List<AppErrLog> appErrLogDirectQueryList = new List<AppErrLog>();
                        appErrLogDirectQueryList = (from c in dbTestDB.AppErrLogs select c).Where(c => c.AppErrLogID > 2 && c.AppErrLogID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<AppErrLog> appErrLogList = new List<AppErrLog>();
                            appErrLogList = appErrLogService.GetAppErrLogList().ToList();
                            CheckAppErrLogFields(appErrLogList);
                            Assert.AreEqual(appErrLogDirectQueryList[0].AppErrLogID, appErrLogList[0].AppErrLogID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppErrLogList() 2 Where

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
