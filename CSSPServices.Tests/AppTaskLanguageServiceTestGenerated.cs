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
    public partial class AppTaskLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AppTaskLanguageService appTaskLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageServiceTest() : base()
        {
            //appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTaskLanguage GetFilledRandomAppTaskLanguage(string OmitPropName)
        {
            AppTaskLanguage appTaskLanguage = new AppTaskLanguage();

            if (OmitPropName != "AppTaskID") appTaskLanguage.AppTaskID = 1;
            if (OmitPropName != "Language") appTaskLanguage.Language = LanguageRequest;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = 2;

            return appTaskLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AppTaskLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    AppTaskLanguage appTaskLanguage = GetFilledRandomAppTaskLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = appTaskLanguageService.GetRead().Count();

                    Assert.AreEqual(appTaskLanguageService.GetRead().Count(), appTaskLanguageService.GetEdit().Count());

                    appTaskLanguageService.Add(appTaskLanguage);
                    if (appTaskLanguage.HasErrors)
                    {
                        Assert.AreEqual("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, appTaskLanguageService.GetRead().Where(c => c == appTaskLanguage).Any());
                    appTaskLanguageService.Update(appTaskLanguage);
                    if (appTaskLanguage.HasErrors)
                    {
                        Assert.AreEqual("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, appTaskLanguageService.GetRead().Count());
                    appTaskLanguageService.Delete(appTaskLanguage);
                    if (appTaskLanguage.HasErrors)
                    {
                        Assert.AreEqual("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // appTaskLanguage.AppTaskLanguageID   (Int32)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageID = 0;
                    appTaskLanguageService.Update(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguageAppTaskLanguageID), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageID = 10000000;
                    appTaskLanguageService.Update(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AppTaskLanguage, CSSPModelsRes.AppTaskLanguageAppTaskLanguageID, appTaskLanguage.AppTaskLanguageID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID", AllowableTVtypeList = Error)]
                    // appTaskLanguage.AppTaskID   (Int32)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskID = 0;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AppTask, CSSPModelsRes.AppTaskLanguageAppTaskID, appTaskLanguage.AppTaskID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTaskLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.Language = (LanguageEnum)1000000;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguageLanguage), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // appTaskLanguage.StatusText   (String)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.StatusText = GetRandomString("", 251);
                    Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskLanguageStatusText, "250"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // appTaskLanguage.ErrorText   (String)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.ErrorText = GetRandomString("", 251);
                    Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskLanguageErrorText, "250"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTaskLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguageTranslationStatus), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // appTaskLanguage.AppTaskLanguageWeb   (AppTaskLanguageWeb)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageWeb = null;
                    Assert.IsNull(appTaskLanguage.AppTaskLanguageWeb);

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageWeb = new AppTaskLanguageWeb();
                    Assert.IsNotNull(appTaskLanguage.AppTaskLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // appTaskLanguage.AppTaskLanguageReport   (AppTaskLanguageReport)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageReport = null;
                    Assert.IsNull(appTaskLanguage.AppTaskLanguageReport);

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageReport = new AppTaskLanguageReport();
                    Assert.IsNotNull(appTaskLanguage.AppTaskLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appTaskLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateDate_UTC = new DateTime();
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguageLastUpdateDate_UTC), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppTaskLanguageLastUpdateDate_UTC, "1980"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // appTaskLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateContactTVItemID = 0;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppTaskLanguageLastUpdateContactTVItemID, appTaskLanguage.LastUpdateContactTVItemID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateContactTVItemID = 1;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskLanguageLastUpdateContactTVItemID, "Contact"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTaskLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTaskLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID)
        [TestMethod]
        public void GetAppTaskLanguageWithAppTaskLanguageID__appTaskLanguage_AppTaskLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new GetParam(), dbTestDB, ContactID);
                    AppTaskLanguage appTaskLanguage = (from c in appTaskLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(appTaskLanguage);

                    AppTaskLanguage appTaskLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appTaskLanguageService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appTaskLanguageRet = appTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID);
                            Assert.IsNull(appTaskLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskLanguageRet = appTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskLanguageRet = appTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskLanguageRet = appTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // AppTaskLanguage fields
                        Assert.IsNotNull(appTaskLanguageRet.AppTaskLanguageID);
                        Assert.IsNotNull(appTaskLanguageRet.AppTaskID);
                        Assert.IsNotNull(appTaskLanguageRet.Language);
                        if (appTaskLanguageRet.StatusText != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.StatusText));
                        }
                        if (appTaskLanguageRet.ErrorText != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.ErrorText));
                        }
                        Assert.IsNotNull(appTaskLanguageRet.TranslationStatus);
                        Assert.IsNotNull(appTaskLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(appTaskLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // AppTaskLanguageWeb and AppTaskLanguageReport fields should be null here
                            Assert.IsNull(appTaskLanguageRet.AppTaskLanguageWeb);
                            Assert.IsNull(appTaskLanguageRet.AppTaskLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // AppTaskLanguageWeb fields should not be null and AppTaskLanguageReport fields should be null here
                            if (appTaskLanguageRet.AppTaskLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.AppTaskLanguageWeb.LastUpdateContactTVText));
                            }
                            if (appTaskLanguageRet.AppTaskLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.AppTaskLanguageWeb.LanguageText));
                            }
                            if (appTaskLanguageRet.AppTaskLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.AppTaskLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(appTaskLanguageRet.AppTaskLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // AppTaskLanguageWeb and AppTaskLanguageReport fields should NOT be null here
                            if (appTaskLanguageRet.AppTaskLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.AppTaskLanguageWeb.LastUpdateContactTVText));
                            }
                            if (appTaskLanguageRet.AppTaskLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.AppTaskLanguageWeb.LanguageText));
                            }
                            if (appTaskLanguageRet.AppTaskLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.AppTaskLanguageWeb.TranslationStatusText));
                            }
                            if (appTaskLanguageRet.AppTaskLanguageReport.AppTaskLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageRet.AppTaskLanguageReport.AppTaskLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID)

        #region Tests Generated for GetAppTaskLanguageList()
        [TestMethod]
        public void GetAppTaskLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new GetParam(), dbTestDB, ContactID);
                    AppTaskLanguage appTaskLanguage = (from c in appTaskLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(appTaskLanguage);

                    List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appTaskLanguageService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                            Assert.AreEqual(0, appTaskLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // AppTaskLanguage fields
                        Assert.IsNotNull(appTaskLanguageList[0].AppTaskLanguageID);
                        Assert.IsNotNull(appTaskLanguageList[0].AppTaskID);
                        Assert.IsNotNull(appTaskLanguageList[0].Language);
                        if (appTaskLanguageList[0].StatusText != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].StatusText));
                        }
                        if (appTaskLanguageList[0].ErrorText != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].ErrorText));
                        }
                        Assert.IsNotNull(appTaskLanguageList[0].TranslationStatus);
                        Assert.IsNotNull(appTaskLanguageList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(appTaskLanguageList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // AppTaskLanguageWeb and AppTaskLanguageReport fields should be null here
                            Assert.IsNull(appTaskLanguageList[0].AppTaskLanguageWeb);
                            Assert.IsNull(appTaskLanguageList[0].AppTaskLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // AppTaskLanguageWeb fields should not be null and AppTaskLanguageReport fields should be null here
                            if (appTaskLanguageList[0].AppTaskLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].AppTaskLanguageWeb.LastUpdateContactTVText));
                            }
                            if (appTaskLanguageList[0].AppTaskLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].AppTaskLanguageWeb.LanguageText));
                            }
                            if (appTaskLanguageList[0].AppTaskLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].AppTaskLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(appTaskLanguageList[0].AppTaskLanguageReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // AppTaskLanguageWeb and AppTaskLanguageReport fields should NOT be null here
                            if (appTaskLanguageList[0].AppTaskLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].AppTaskLanguageWeb.LastUpdateContactTVText));
                            }
                            if (appTaskLanguageList[0].AppTaskLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].AppTaskLanguageWeb.LanguageText));
                            }
                            if (appTaskLanguageList[0].AppTaskLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].AppTaskLanguageWeb.TranslationStatusText));
                            }
                            if (appTaskLanguageList[0].AppTaskLanguageReport.AppTaskLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].AppTaskLanguageReport.AppTaskLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList()

        #region Tests Generated for GetAppTaskLanguageList() Skip Take
        [TestMethod]
        public void GetAppTaskLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(AppTaskLanguage), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                            Assert.AreEqual(0, appTaskLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, appTaskLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take

    }
}
