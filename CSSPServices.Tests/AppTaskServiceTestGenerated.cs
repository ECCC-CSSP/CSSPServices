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
    public partial class AppTaskServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AppTaskService appTaskService { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskServiceTest() : base()
        {
            //appTaskService = new AppTaskService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AppTask_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    AppTask appTask = GetFilledRandomAppTask("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = appTaskService.GetAppTaskList().Count();

                    Assert.AreEqual(appTaskService.GetAppTaskList().Count(), (from c in dbTestDB.AppTasks select c).Take(200).Count());

                    appTaskService.Add(appTask);
                    if (appTask.HasErrors)
                    {
                        Assert.AreEqual("", appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, appTaskService.GetAppTaskList().Where(c => c == appTask).Any());
                    appTaskService.Update(appTask);
                    if (appTask.HasErrors)
                    {
                        Assert.AreEqual("", appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, appTaskService.GetAppTaskList().Count());
                    appTaskService.Delete(appTask);
                    if (appTask.HasErrors)
                    {
                        Assert.AreEqual("", appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // appTask.AppTaskID   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskID = 0;
                    appTaskService.Update(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskAppTaskID"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskID = 10000000;
                    appTaskService.Update(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskAppTaskID", appTask.AppTaskID.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow)]
                    // appTask.TVItemID   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItemID = 0;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppTaskTVItemID", appTask.TVItemID.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItemID = 2;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AppTaskTVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow)]
                    // appTask.TVItemID2   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItemID2 = 0;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppTaskTVItemID2", appTask.TVItemID2.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItemID2 = 2;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AppTaskTVItemID2", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTask.AppTaskCommand   (AppTaskCommandEnum)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskCommand = (AppTaskCommandEnum)1000000;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskAppTaskCommand"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTask.AppTaskStatus   (AppTaskStatusEnum)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskStatus = (AppTaskStatusEnum)1000000;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskAppTaskStatus"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // appTask.PercentCompleted   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.PercentCompleted = -1;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AppTaskPercentCompleted", "0", "100"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.PercentCompleted = 101;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AppTaskPercentCompleted", "0", "100"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // appTask.Parameters   (String)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("Parameters");
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(1, appTask.ValidationResults.Count());
                    Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "AppTaskParameters")).Any());
                    Assert.AreEqual(null, appTask.Parameters);
                    Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTask.Language   (LanguageEnum)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.Language = (LanguageEnum)1000000;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguage"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appTask.StartDateTime_UTC   (DateTime)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.StartDateTime_UTC = new DateTime();
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskStartDateTime_UTC"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.StartDateTime_UTC = new DateTime(1979, 1, 1);
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppTaskStartDateTime_UTC", "1980"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateTime_UTC)]
                    // appTask.EndDateTime_UTC   (DateTime)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.EndDateTime_UTC = new DateTime(1979, 1, 1);
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppTaskEndDateTime_UTC", "1980"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000000)]
                    // appTask.EstimatedLength_second   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.EstimatedLength_second = -1;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AppTaskEstimatedLength_second", "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.EstimatedLength_second = 1000001;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AppTaskEstimatedLength_second", "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000000)]
                    // appTask.RemainingTime_second   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.RemainingTime_second = -1;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AppTaskRemainingTime_second", "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.RemainingTime_second = 1000001;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AppTaskRemainingTime_second", "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetAppTaskList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appTask.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LastUpdateDate_UTC = new DateTime();
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskLastUpdateDate_UTC"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppTaskLastUpdateDate_UTC", "1980"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // appTask.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LastUpdateContactTVItemID = 0;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppTaskLastUpdateContactTVItemID", appTask.LastUpdateContactTVItemID.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LastUpdateContactTVItemID = 1;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AppTaskLastUpdateContactTVItemID", "Contact"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTask.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTask.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetAppTaskWithAppTaskID(appTask.AppTaskID)
        [TestMethod]
        public void GetAppTaskWithAppTaskID__appTask_AppTaskID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppTask appTask = (from c in dbTestDB.AppTasks select c).FirstOrDefault();
                    Assert.IsNotNull(appTask);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appTaskService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            AppTask appTaskRet = appTaskService.GetAppTaskWithAppTaskID(appTask.AppTaskID);
                            CheckAppTaskFields(new List<AppTask>() { appTaskRet });
                            Assert.AreEqual(appTask.AppTaskID, appTaskRet.AppTaskID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            AppTaskWeb appTaskWebRet = appTaskService.GetAppTaskWebWithAppTaskID(appTask.AppTaskID);
                            CheckAppTaskWebFields(new List<AppTaskWeb>() { appTaskWebRet });
                            Assert.AreEqual(appTask.AppTaskID, appTaskWebRet.AppTaskID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            AppTaskReport appTaskReportRet = appTaskService.GetAppTaskReportWithAppTaskID(appTask.AppTaskID);
                            CheckAppTaskReportFields(new List<AppTaskReport>() { appTaskReportRet });
                            Assert.AreEqual(appTask.AppTaskID, appTaskReportRet.AppTaskID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskWithAppTaskID(appTask.AppTaskID)

        #region Tests Generated for GetAppTaskList()
        [TestMethod]
        public void GetAppTaskList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppTask appTask = (from c in dbTestDB.AppTasks select c).FirstOrDefault();
                    Assert.IsNotNull(appTask);

                    List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                    appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appTaskService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppTaskWeb> appTaskWebList = new List<AppTaskWeb>();
                            appTaskWebList = appTaskService.GetAppTaskWebList().ToList();
                            CheckAppTaskWebFields(appTaskWebList);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppTaskReport> appTaskReportList = new List<AppTaskReport>();
                            appTaskReportList = appTaskService.GetAppTaskReportList().ToList();
                            CheckAppTaskReportFields(appTaskReportList);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskList()

        #region Tests Generated for GetAppTaskList() Skip Take
        [TestMethod]
        public void GetAppTaskList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppTaskWeb> appTaskWebList = new List<AppTaskWeb>();
                            appTaskWebList = appTaskService.GetAppTaskWebList().ToList();
                            CheckAppTaskWebFields(appTaskWebList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskWebList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppTaskReport> appTaskReportList = new List<AppTaskReport>();
                            appTaskReportList = appTaskService.GetAppTaskReportList().ToList();
                            CheckAppTaskReportFields(appTaskReportList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskReportList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskList() Skip Take

        #region Tests Generated for GetAppTaskList() Skip Take Order
        [TestMethod]
        public void GetAppTaskList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 1, 1,  "AppTaskID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Skip(1).Take(1).OrderBy(c => c.AppTaskID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppTaskWeb> appTaskWebList = new List<AppTaskWeb>();
                            appTaskWebList = appTaskService.GetAppTaskWebList().ToList();
                            CheckAppTaskWebFields(appTaskWebList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskWebList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppTaskReport> appTaskReportList = new List<AppTaskReport>();
                            appTaskReportList = appTaskService.GetAppTaskReportList().ToList();
                            CheckAppTaskReportFields(appTaskReportList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskReportList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskList() Skip Take Order

        #region Tests Generated for GetAppTaskList() Skip Take 2Order
        [TestMethod]
        public void GetAppTaskList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 1, 1, "AppTaskID,TVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Skip(1).Take(1).OrderBy(c => c.AppTaskID).ThenBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppTaskWeb> appTaskWebList = new List<AppTaskWeb>();
                            appTaskWebList = appTaskService.GetAppTaskWebList().ToList();
                            CheckAppTaskWebFields(appTaskWebList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskWebList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppTaskReport> appTaskReportList = new List<AppTaskReport>();
                            appTaskReportList = appTaskService.GetAppTaskReportList().ToList();
                            CheckAppTaskReportFields(appTaskReportList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskReportList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskList() Skip Take 2Order

        #region Tests Generated for GetAppTaskList() Skip Take Order Where
        [TestMethod]
        public void GetAppTaskList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskID", "AppTaskID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Where(c => c.AppTaskID == 4).Skip(0).Take(1).OrderBy(c => c.AppTaskID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppTaskWeb> appTaskWebList = new List<AppTaskWeb>();
                            appTaskWebList = appTaskService.GetAppTaskWebList().ToList();
                            CheckAppTaskWebFields(appTaskWebList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskWebList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppTaskReport> appTaskReportList = new List<AppTaskReport>();
                            appTaskReportList = appTaskService.GetAppTaskReportList().ToList();
                            CheckAppTaskReportFields(appTaskReportList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskReportList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskList() Skip Take Order Where

        #region Tests Generated for GetAppTaskList() Skip Take Order 2Where
        [TestMethod]
        public void GetAppTaskList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskID", "AppTaskID,GT,2|AppTaskID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Where(c => c.AppTaskID > 2 && c.AppTaskID < 5).Skip(0).Take(1).OrderBy(c => c.AppTaskID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppTaskWeb> appTaskWebList = new List<AppTaskWeb>();
                            appTaskWebList = appTaskService.GetAppTaskWebList().ToList();
                            CheckAppTaskWebFields(appTaskWebList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskWebList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppTaskReport> appTaskReportList = new List<AppTaskReport>();
                            appTaskReportList = appTaskService.GetAppTaskReportList().ToList();
                            CheckAppTaskReportFields(appTaskReportList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskReportList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskList() Skip Take Order 2Where

        #region Tests Generated for GetAppTaskList() 2Where
        [TestMethod]
        public void GetAppTaskList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 0, 10000, "", "AppTaskID,GT,2|AppTaskID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Where(c => c.AppTaskID > 2 && c.AppTaskID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<AppTaskWeb> appTaskWebList = new List<AppTaskWeb>();
                            appTaskWebList = appTaskService.GetAppTaskWebList().ToList();
                            CheckAppTaskWebFields(appTaskWebList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskWebList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<AppTaskReport> appTaskReportList = new List<AppTaskReport>();
                            appTaskReportList = appTaskService.GetAppTaskReportList().ToList();
                            CheckAppTaskReportFields(appTaskReportList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskReportList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskList() 2Where

        #region Functions private
        private void CheckAppTaskFields(List<AppTask> appTaskList)
        {
            Assert.IsNotNull(appTaskList[0].AppTaskID);
            Assert.IsNotNull(appTaskList[0].TVItemID);
            Assert.IsNotNull(appTaskList[0].TVItemID2);
            Assert.IsNotNull(appTaskList[0].AppTaskCommand);
            Assert.IsNotNull(appTaskList[0].AppTaskStatus);
            Assert.IsNotNull(appTaskList[0].PercentCompleted);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskList[0].Parameters));
            Assert.IsNotNull(appTaskList[0].Language);
            Assert.IsNotNull(appTaskList[0].StartDateTime_UTC);
            if (appTaskList[0].EndDateTime_UTC != null)
            {
                Assert.IsNotNull(appTaskList[0].EndDateTime_UTC);
            }
            if (appTaskList[0].EstimatedLength_second != null)
            {
                Assert.IsNotNull(appTaskList[0].EstimatedLength_second);
            }
            if (appTaskList[0].RemainingTime_second != null)
            {
                Assert.IsNotNull(appTaskList[0].RemainingTime_second);
            }
            Assert.IsNotNull(appTaskList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appTaskList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appTaskList[0].HasErrors);
        }
        private void CheckAppTaskWebFields(List<AppTaskWeb> appTaskWebList)
        {
            Assert.IsNotNull(appTaskWebList[0].TVItemTVItemLanguage);
            Assert.IsNotNull(appTaskWebList[0].TVItem2TVItemLanguage);
            Assert.IsNotNull(appTaskWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(appTaskWebList[0].AppTaskCommandText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskWebList[0].AppTaskCommandText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskWebList[0].AppTaskStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskWebList[0].AppTaskStatusText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskWebList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskWebList[0].LanguageText));
            }
            Assert.IsNotNull(appTaskWebList[0].AppTaskID);
            Assert.IsNotNull(appTaskWebList[0].TVItemID);
            Assert.IsNotNull(appTaskWebList[0].TVItemID2);
            Assert.IsNotNull(appTaskWebList[0].AppTaskCommand);
            Assert.IsNotNull(appTaskWebList[0].AppTaskStatus);
            Assert.IsNotNull(appTaskWebList[0].PercentCompleted);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskWebList[0].Parameters));
            Assert.IsNotNull(appTaskWebList[0].Language);
            Assert.IsNotNull(appTaskWebList[0].StartDateTime_UTC);
            if (appTaskWebList[0].EndDateTime_UTC != null)
            {
                Assert.IsNotNull(appTaskWebList[0].EndDateTime_UTC);
            }
            if (appTaskWebList[0].EstimatedLength_second != null)
            {
                Assert.IsNotNull(appTaskWebList[0].EstimatedLength_second);
            }
            if (appTaskWebList[0].RemainingTime_second != null)
            {
                Assert.IsNotNull(appTaskWebList[0].RemainingTime_second);
            }
            Assert.IsNotNull(appTaskWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appTaskWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appTaskWebList[0].HasErrors);
        }
        private void CheckAppTaskReportFields(List<AppTaskReport> appTaskReportList)
        {
            if (!string.IsNullOrWhiteSpace(appTaskReportList[0].AppTaskReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskReportList[0].AppTaskReportTest));
            }
            Assert.IsNotNull(appTaskReportList[0].TVItemTVItemLanguage);
            Assert.IsNotNull(appTaskReportList[0].TVItem2TVItemLanguage);
            Assert.IsNotNull(appTaskReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(appTaskReportList[0].AppTaskCommandText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskReportList[0].AppTaskCommandText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskReportList[0].AppTaskStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskReportList[0].AppTaskStatusText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskReportList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskReportList[0].LanguageText));
            }
            Assert.IsNotNull(appTaskReportList[0].AppTaskID);
            Assert.IsNotNull(appTaskReportList[0].TVItemID);
            Assert.IsNotNull(appTaskReportList[0].TVItemID2);
            Assert.IsNotNull(appTaskReportList[0].AppTaskCommand);
            Assert.IsNotNull(appTaskReportList[0].AppTaskStatus);
            Assert.IsNotNull(appTaskReportList[0].PercentCompleted);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskReportList[0].Parameters));
            Assert.IsNotNull(appTaskReportList[0].Language);
            Assert.IsNotNull(appTaskReportList[0].StartDateTime_UTC);
            if (appTaskReportList[0].EndDateTime_UTC != null)
            {
                Assert.IsNotNull(appTaskReportList[0].EndDateTime_UTC);
            }
            if (appTaskReportList[0].EstimatedLength_second != null)
            {
                Assert.IsNotNull(appTaskReportList[0].EstimatedLength_second);
            }
            if (appTaskReportList[0].RemainingTime_second != null)
            {
                Assert.IsNotNull(appTaskReportList[0].RemainingTime_second);
            }
            Assert.IsNotNull(appTaskReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appTaskReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appTaskReportList[0].HasErrors);
        }
        private AppTask GetFilledRandomAppTask(string OmitPropName)
        {
            AppTask appTask = new AppTask();

            if (OmitPropName != "TVItemID") appTask.TVItemID = 1;
            if (OmitPropName != "TVItemID2") appTask.TVItemID2 = 1;
            if (OmitPropName != "AppTaskCommand") appTask.AppTaskCommand = (AppTaskCommandEnum)GetRandomEnumType(typeof(AppTaskCommandEnum));
            if (OmitPropName != "AppTaskStatus") appTask.AppTaskStatus = (AppTaskStatusEnum)GetRandomEnumType(typeof(AppTaskStatusEnum));
            if (OmitPropName != "PercentCompleted") appTask.PercentCompleted = GetRandomInt(0, 100);
            if (OmitPropName != "Parameters") appTask.Parameters = GetRandomString("", 20);
            if (OmitPropName != "Language") appTask.Language = LanguageRequest;
            if (OmitPropName != "StartDateTime_UTC") appTask.StartDateTime_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_UTC") appTask.EndDateTime_UTC = new DateTime(2005, 3, 7);
            if (OmitPropName != "EstimatedLength_second") appTask.EstimatedLength_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "RemainingTime_second") appTask.RemainingTime_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "LastUpdateDate_UTC") appTask.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTask.LastUpdateContactTVItemID = 2;

            return appTask;
        }
        #endregion Functions private
    }
}
