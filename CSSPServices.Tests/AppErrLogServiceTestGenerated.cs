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

        #region Functions public
        #endregion Functions public

        #region Functions private
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AppErrLog_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppErrLogService appErrLogService = new AppErrLogService(new GetParam(), dbTestDB, ContactID);

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

        #region Tests Generated Get With Key
        [TestMethod]
        public void AppErrLog_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    AppErrLogService appErrLogService = new AppErrLogService(new GetParam(), dbTestDB, ContactID);
                    AppErrLog appErrLog = (from c in appErrLogService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(appErrLog);

                    AppErrLog appErrLogRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID, getParam);
                            Assert.IsNull(appErrLogRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // AppErrLog fields
                        Assert.IsNotNull(appErrLogRet.AppErrLogID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.Tag));
                        Assert.IsNotNull(appErrLogRet.LineNumber);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.Source));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.Message));
                        Assert.IsNotNull(appErrLogRet.DateTime_UTC);
                        Assert.IsNotNull(appErrLogRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(appErrLogRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // AppErrLogWeb and AppErrLogReport fields should be null here
                            Assert.IsNull(appErrLogRet.AppErrLogWeb);
                            Assert.IsNull(appErrLogRet.AppErrLogReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // AppErrLogWeb fields should not be null and AppErrLogReport fields should be null here
                            if (appErrLogRet.AppErrLogWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.AppErrLogWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(appErrLogRet.AppErrLogReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // AppErrLogWeb and AppErrLogReport fields should NOT be null here
                            if (appErrLogRet.AppErrLogWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.AppErrLogWeb.LastUpdateContactTVText));
                            }
                            if (appErrLogRet.AppErrLogReport.AppErrLogTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.AppErrLogReport.AppErrLogTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of AppErrLog
        #endregion Tests Get List of AppErrLog

    }
}
