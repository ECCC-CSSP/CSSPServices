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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppTask appTask = (from c in dbTestDB.AppTasks select c).FirstOrDefault();
                    Assert.IsNotNull(appTask);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        appTaskService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            AppTask appTaskRet = appTaskService.GetAppTaskWithAppTaskID(appTask.AppTaskID);
                            CheckAppTaskFields(new List<AppTask>() { appTaskRet });
                            Assert.AreEqual(appTask.AppTaskID, appTaskRet.AppTaskID);
                        }
                        else if (detail == "ExtraA")
                        {
                            AppTaskExtraA appTaskExtraARet = appTaskService.GetAppTaskExtraAWithAppTaskID(appTask.AppTaskID);
                            CheckAppTaskExtraAFields(new List<AppTaskExtraA>() { appTaskExtraARet });
                            Assert.AreEqual(appTask.AppTaskID, appTaskExtraARet.AppTaskID);
                        }
                        else if (detail == "ExtraB")
                        {
                            AppTaskExtraB appTaskExtraBRet = appTaskService.GetAppTaskExtraBWithAppTaskID(appTask.AppTaskID);
                            CheckAppTaskExtraBFields(new List<AppTaskExtraB>() { appTaskExtraBRet });
                            Assert.AreEqual(appTask.AppTaskID, appTaskExtraBRet.AppTaskID);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppTask appTask = (from c in dbTestDB.AppTasks select c).FirstOrDefault();
                    Assert.IsNotNull(appTask);

                    List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                    appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        appTaskService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskExtraA> appTaskExtraAList = new List<AppTaskExtraA>();
                            appTaskExtraAList = appTaskService.GetAppTaskExtraAList().ToList();
                            CheckAppTaskExtraAFields(appTaskExtraAList);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskExtraB> appTaskExtraBList = new List<AppTaskExtraB>();
                            appTaskExtraBList = appTaskService.GetAppTaskExtraBList().ToList();
                            CheckAppTaskExtraBFields(appTaskExtraBList);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskExtraA> appTaskExtraAList = new List<AppTaskExtraA>();
                            appTaskExtraAList = appTaskService.GetAppTaskExtraAList().ToList();
                            CheckAppTaskExtraAFields(appTaskExtraAList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraAList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskExtraB> appTaskExtraBList = new List<AppTaskExtraB>();
                            appTaskExtraBList = appTaskService.GetAppTaskExtraBList().ToList();
                            CheckAppTaskExtraBFields(appTaskExtraBList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraBList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 1, 1,  "AppTaskID", "");

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Skip(1).Take(1).OrderBy(c => c.AppTaskID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskExtraA> appTaskExtraAList = new List<AppTaskExtraA>();
                            appTaskExtraAList = appTaskService.GetAppTaskExtraAList().ToList();
                            CheckAppTaskExtraAFields(appTaskExtraAList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraAList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskExtraB> appTaskExtraBList = new List<AppTaskExtraB>();
                            appTaskExtraBList = appTaskService.GetAppTaskExtraBList().ToList();
                            CheckAppTaskExtraBFields(appTaskExtraBList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraBList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 1, 1, "AppTaskID,TVItemID", "");

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Skip(1).Take(1).OrderBy(c => c.AppTaskID).ThenBy(c => c.TVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskExtraA> appTaskExtraAList = new List<AppTaskExtraA>();
                            appTaskExtraAList = appTaskService.GetAppTaskExtraAList().ToList();
                            CheckAppTaskExtraAFields(appTaskExtraAList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraAList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskExtraB> appTaskExtraBList = new List<AppTaskExtraB>();
                            appTaskExtraBList = appTaskService.GetAppTaskExtraBList().ToList();
                            CheckAppTaskExtraBFields(appTaskExtraBList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraBList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskID", "AppTaskID,EQ,4", "");

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Where(c => c.AppTaskID == 4).Skip(0).Take(1).OrderBy(c => c.AppTaskID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskExtraA> appTaskExtraAList = new List<AppTaskExtraA>();
                            appTaskExtraAList = appTaskService.GetAppTaskExtraAList().ToList();
                            CheckAppTaskExtraAFields(appTaskExtraAList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraAList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskExtraB> appTaskExtraBList = new List<AppTaskExtraB>();
                            appTaskExtraBList = appTaskService.GetAppTaskExtraBList().ToList();
                            CheckAppTaskExtraBFields(appTaskExtraBList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraBList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskID", "AppTaskID,GT,2|AppTaskID,LT,5", "");

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Where(c => c.AppTaskID > 2 && c.AppTaskID < 5).Skip(0).Take(1).OrderBy(c => c.AppTaskID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskExtraA> appTaskExtraAList = new List<AppTaskExtraA>();
                            appTaskExtraAList = appTaskService.GetAppTaskExtraAList().ToList();
                            CheckAppTaskExtraAFields(appTaskExtraAList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraAList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskExtraB> appTaskExtraBList = new List<AppTaskExtraB>();
                            appTaskExtraBList = appTaskService.GetAppTaskExtraBList().ToList();
                            CheckAppTaskExtraBFields(appTaskExtraBList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraBList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskService appTaskService = new AppTaskService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskService.Query = appTaskService.FillQuery(typeof(AppTask), culture.TwoLetterISOLanguageName, 0, 10000, "", "AppTaskID,GT,2|AppTaskID,LT,5", "");

                        List<AppTask> appTaskDirectQueryList = new List<AppTask>();
                        appTaskDirectQueryList = (from c in dbTestDB.AppTasks select c).Where(c => c.AppTaskID > 2 && c.AppTaskID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTask> appTaskList = new List<AppTask>();
                            appTaskList = appTaskService.GetAppTaskList().ToList();
                            CheckAppTaskFields(appTaskList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskList[0].AppTaskID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskExtraA> appTaskExtraAList = new List<AppTaskExtraA>();
                            appTaskExtraAList = appTaskService.GetAppTaskExtraAList().ToList();
                            CheckAppTaskExtraAFields(appTaskExtraAList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraAList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskExtraB> appTaskExtraBList = new List<AppTaskExtraB>();
                            appTaskExtraBList = appTaskService.GetAppTaskExtraBList().ToList();
                            CheckAppTaskExtraBFields(appTaskExtraBList);
                            Assert.AreEqual(appTaskDirectQueryList[0].AppTaskID, appTaskExtraBList[0].AppTaskID);
                            Assert.AreEqual(appTaskDirectQueryList.Count, appTaskExtraBList.Count);
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
        private void CheckAppTaskExtraAFields(List<AppTaskExtraA> appTaskExtraAList)
        {
            Assert.IsNotNull(appTaskExtraAList[0].TVItemTVItemLanguage);
            Assert.IsNotNull(appTaskExtraAList[0].TVItem2TVItemLanguage);
            Assert.IsNotNull(appTaskExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(appTaskExtraAList[0].AppTaskCommandText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskExtraAList[0].AppTaskCommandText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskExtraAList[0].AppTaskStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskExtraAList[0].AppTaskStatusText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskExtraAList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskExtraAList[0].LanguageText));
            }
            Assert.IsNotNull(appTaskExtraAList[0].AppTaskID);
            Assert.IsNotNull(appTaskExtraAList[0].TVItemID);
            Assert.IsNotNull(appTaskExtraAList[0].TVItemID2);
            Assert.IsNotNull(appTaskExtraAList[0].AppTaskCommand);
            Assert.IsNotNull(appTaskExtraAList[0].AppTaskStatus);
            Assert.IsNotNull(appTaskExtraAList[0].PercentCompleted);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskExtraAList[0].Parameters));
            Assert.IsNotNull(appTaskExtraAList[0].Language);
            Assert.IsNotNull(appTaskExtraAList[0].StartDateTime_UTC);
            if (appTaskExtraAList[0].EndDateTime_UTC != null)
            {
                Assert.IsNotNull(appTaskExtraAList[0].EndDateTime_UTC);
            }
            if (appTaskExtraAList[0].EstimatedLength_second != null)
            {
                Assert.IsNotNull(appTaskExtraAList[0].EstimatedLength_second);
            }
            if (appTaskExtraAList[0].RemainingTime_second != null)
            {
                Assert.IsNotNull(appTaskExtraAList[0].RemainingTime_second);
            }
            Assert.IsNotNull(appTaskExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appTaskExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appTaskExtraAList[0].HasErrors);
        }
        private void CheckAppTaskExtraBFields(List<AppTaskExtraB> appTaskExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(appTaskExtraBList[0].AppTaskReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskExtraBList[0].AppTaskReportTest));
            }
            Assert.IsNotNull(appTaskExtraBList[0].TVItemTVItemLanguage);
            Assert.IsNotNull(appTaskExtraBList[0].TVItem2TVItemLanguage);
            Assert.IsNotNull(appTaskExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(appTaskExtraBList[0].AppTaskCommandText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskExtraBList[0].AppTaskCommandText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskExtraBList[0].AppTaskStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskExtraBList[0].AppTaskStatusText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskExtraBList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskExtraBList[0].LanguageText));
            }
            Assert.IsNotNull(appTaskExtraBList[0].AppTaskID);
            Assert.IsNotNull(appTaskExtraBList[0].TVItemID);
            Assert.IsNotNull(appTaskExtraBList[0].TVItemID2);
            Assert.IsNotNull(appTaskExtraBList[0].AppTaskCommand);
            Assert.IsNotNull(appTaskExtraBList[0].AppTaskStatus);
            Assert.IsNotNull(appTaskExtraBList[0].PercentCompleted);
            Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskExtraBList[0].Parameters));
            Assert.IsNotNull(appTaskExtraBList[0].Language);
            Assert.IsNotNull(appTaskExtraBList[0].StartDateTime_UTC);
            if (appTaskExtraBList[0].EndDateTime_UTC != null)
            {
                Assert.IsNotNull(appTaskExtraBList[0].EndDateTime_UTC);
            }
            if (appTaskExtraBList[0].EstimatedLength_second != null)
            {
                Assert.IsNotNull(appTaskExtraBList[0].EstimatedLength_second);
            }
            if (appTaskExtraBList[0].RemainingTime_second != null)
            {
                Assert.IsNotNull(appTaskExtraBList[0].RemainingTime_second);
            }
            Assert.IsNotNull(appTaskExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appTaskExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appTaskExtraBList[0].HasErrors);
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
