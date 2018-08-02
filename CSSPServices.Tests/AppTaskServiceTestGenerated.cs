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

                    count = appTaskService.GetRead().Count();

                    Assert.AreEqual(appTaskService.GetRead().Count(), appTaskService.GetEdit().Count());

                    appTaskService.Add(appTask);
                    if (appTask.HasErrors)
                    {
                        Assert.AreEqual("", appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, appTaskService.GetRead().Where(c => c == appTask).Any());
                    appTaskService.Update(appTask);
                    if (appTask.HasErrors)
                    {
                        Assert.AreEqual("", appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, appTaskService.GetRead().Count());
                    appTaskService.Delete(appTask);
                    if (appTask.HasErrors)
                    {
                        Assert.AreEqual("", appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskAppTaskID), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskID = 10000000;
                    appTaskService.Update(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AppTask, CSSPModelsRes.AppTaskAppTaskID, appTask.AppTaskID.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow)]
                    // appTask.TVItemID   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItemID = 0;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppTaskTVItemID, appTask.TVItemID.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItemID = 2;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskTVItemID, "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow)]
                    // appTask.TVItemID2   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItemID2 = 0;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppTaskTVItemID2, appTask.TVItemID2.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItemID2 = 2;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskTVItemID2, "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTask.AppTaskCommand   (AppTaskCommandEnum)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskCommand = (AppTaskCommandEnum)1000000;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskAppTaskCommand), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTask.AppTaskStatus   (AppTaskStatusEnum)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskStatus = (AppTaskStatusEnum)1000000;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskAppTaskStatus), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // appTask.PercentCompleted   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.PercentCompleted = -1;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AppTaskPercentCompleted, "0", "100"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.PercentCompleted = 101;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AppTaskPercentCompleted, "0", "100"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // appTask.Parameters   (String)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("Parameters");
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(1, appTask.ValidationResults.Count());
                    Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskParameters)).Any());
                    Assert.AreEqual(null, appTask.Parameters);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTask.Language   (LanguageEnum)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.Language = (LanguageEnum)1000000;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguage), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appTask.StartDateTime_UTC   (DateTime)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.StartDateTime_UTC = new DateTime();
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskStartDateTime_UTC), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.StartDateTime_UTC = new DateTime(1979, 1, 1);
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppTaskStartDateTime_UTC, "1980"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppTaskEndDateTime_UTC, "1980"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000000)]
                    // appTask.EstimatedLength_second   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.EstimatedLength_second = -1;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AppTaskEstimatedLength_second, "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.EstimatedLength_second = 1000001;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AppTaskEstimatedLength_second, "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000000)]
                    // appTask.RemainingTime_second   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.RemainingTime_second = -1;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AppTaskRemainingTime_second, "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.RemainingTime_second = 1000001;
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AppTaskRemainingTime_second, "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // appTask.AppTaskWeb   (AppTaskWeb)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskWeb = null;
                    Assert.IsNull(appTask.AppTaskWeb);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskWeb = new AppTaskWeb();
                    Assert.IsNotNull(appTask.AppTaskWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // appTask.AppTaskReport   (AppTaskReport)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskReport = null;
                    Assert.IsNull(appTask.AppTaskReport);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskReport = new AppTaskReport();
                    Assert.IsNotNull(appTask.AppTaskReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appTask.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LastUpdateDate_UTC = new DateTime();
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLastUpdateDate_UTC), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppTaskLastUpdateDate_UTC, "1980"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // appTask.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LastUpdateContactTVItemID = 0;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppTaskLastUpdateContactTVItemID, appTask.LastUpdateContactTVItemID.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LastUpdateContactTVItemID = 1;
                    appTaskService.Add(appTask);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskLastUpdateContactTVItemID, "Contact"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    AppTask appTask = (from c in appTaskService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(appTask);

                    AppTask appTaskRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appTaskService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            appTaskRet = appTaskService.GetAppTaskWithAppTaskID(appTask.AppTaskID);
                            Assert.IsNull(appTaskRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskRet = appTaskService.GetAppTaskWithAppTaskID(appTask.AppTaskID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskRet = appTaskService.GetAppTaskWithAppTaskID(appTask.AppTaskID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskRet = appTaskService.GetAppTaskWithAppTaskID(appTask.AppTaskID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppTaskFields(new List<AppTask>() { appTaskRet }, entityQueryDetailType);
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
                    AppTask appTask = (from c in appTaskService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(appTask);

                    List<AppTask> appTaskList = new List<AppTask>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        appTaskService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            Assert.AreEqual(0, appTaskList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppTaskFields(appTaskList, entityQueryDetailType);
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
                    List<AppTask> appTaskList = new List<AppTask>();
                    List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appTaskDirectQueryList = appTaskService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            Assert.AreEqual(0, appTaskList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppTaskFields(appTaskList, entityQueryDetailType);
                        Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        Assert.AreEqual(1, appTaskList.Count);
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
                    List<AppTask> appTaskList = new List<AppTask>();
                    List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 1, 1,  "AppTaskID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appTaskDirectQueryList = appTaskService.GetRead().Skip(1).Take(1).OrderBy(c => c.AppTaskID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            Assert.AreEqual(0, appTaskList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppTaskFields(appTaskList, entityQueryDetailType);
                        Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        Assert.AreEqual(1, appTaskList.Count);
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
                    List<AppTask> appTaskList = new List<AppTask>();
                    List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 1, 1, "AppTaskID,TVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appTaskDirectQueryList = appTaskService.GetRead().Skip(1).Take(1).OrderBy(c => c.AppTaskID).ThenBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            Assert.AreEqual(0, appTaskList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppTaskFields(appTaskList, entityQueryDetailType);
                        Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        Assert.AreEqual(1, appTaskList.Count);
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
                    List<AppTask> appTaskList = new List<AppTask>();
                    List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskID", "AppTaskID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appTaskDirectQueryList = appTaskService.GetRead().Where(c => c.AppTaskID == 4).Skip(0).Take(1).OrderBy(c => c.AppTaskID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            Assert.AreEqual(0, appTaskList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppTaskFields(appTaskList, entityQueryDetailType);
                        Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        Assert.AreEqual(1, appTaskList.Count);
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
                    List<AppTask> appTaskList = new List<AppTask>();
                    List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskID", "AppTaskID,GT,2|AppTaskID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appTaskDirectQueryList = appTaskService.GetRead().Where(c => c.AppTaskID > 2 && c.AppTaskID < 5).Skip(0).Take(1).OrderBy(c => c.AppTaskID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            Assert.AreEqual(0, appTaskList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppTaskFields(appTaskList, entityQueryDetailType);
                        Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        Assert.AreEqual(1, appTaskList.Count);
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
                    List<AppTask> appTaskList = new List<AppTask>();
                    List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 0, 10000, "", "AppTaskID,GT,2|AppTaskID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        appTaskDirectQueryList = appTaskService.GetRead().Where(c => c.AppTaskID > 2 && c.AppTaskID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            Assert.AreEqual(0, appTaskList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckAppTaskFields(appTaskList, entityQueryDetailType);
                        Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        Assert.AreEqual(2, appTaskList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskList() 2Where

        #region Functions private
        private void CheckAppTaskFields(List<AppTask> appTaskList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // AppTask fields
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

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // AppTaskWeb and AppTaskReport fields should be null here
                Assert.IsNull(appTaskList[0].AppTaskWeb);
                Assert.IsNull(appTaskList[0].AppTaskReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // AppTaskWeb fields should not be null and AppTaskReport fields should be null here
                Assert.IsNotNull(appTaskList[0].AppTaskWeb.TVItemTVItemLanguage);
                Assert.IsNotNull(appTaskList[0].AppTaskWeb.TVItem2TVItemLanguage);
                Assert.IsNotNull(appTaskList[0].AppTaskWeb.LastUpdateContactTVItemLanguage);
                if (!string.IsNullOrWhiteSpace(appTaskList[0].AppTaskWeb.AppTaskCommandText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskList[0].AppTaskWeb.AppTaskCommandText));
                }
                if (!string.IsNullOrWhiteSpace(appTaskList[0].AppTaskWeb.AppTaskStatusText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskList[0].AppTaskWeb.AppTaskStatusText));
                }
                if (!string.IsNullOrWhiteSpace(appTaskList[0].AppTaskWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskList[0].AppTaskWeb.LanguageText));
                }
                Assert.IsNull(appTaskList[0].AppTaskReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // AppTaskWeb and AppTaskReport fields should NOT be null here
                Assert.IsNotNull(appTaskList[0].AppTaskWeb.TVItemTVItemLanguage);
                Assert.IsNotNull(appTaskList[0].AppTaskWeb.TVItem2TVItemLanguage);
                Assert.IsNotNull(appTaskList[0].AppTaskWeb.LastUpdateContactTVItemLanguage);
                if (appTaskList[0].AppTaskWeb.AppTaskCommandText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskList[0].AppTaskWeb.AppTaskCommandText));
                }
                if (appTaskList[0].AppTaskWeb.AppTaskStatusText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskList[0].AppTaskWeb.AppTaskStatusText));
                }
                if (appTaskList[0].AppTaskWeb.LanguageText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskList[0].AppTaskWeb.LanguageText));
                }
                if (appTaskList[0].AppTaskReport.AppTaskReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskList[0].AppTaskReport.AppTaskReportTest));
                }
            }
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
