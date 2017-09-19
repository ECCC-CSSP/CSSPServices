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

        #region Functions public
        #endregion Functions public

        #region Functions private
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
            if (OmitPropName != "TVItemTVText") appTask.TVItemTVText = GetRandomString("", 5);
            if (OmitPropName != "TVItem2TVText") appTask.TVItem2TVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") appTask.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "AppTaskCommandText") appTask.AppTaskCommandText = GetRandomString("", 5);
            if (OmitPropName != "AppTaskStatusText") appTask.AppTaskStatusText = GetRandomString("", 5);
            if (OmitPropName != "LanguageText") appTask.LanguageText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") appTask.HasErrors = true;

            return appTask;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AppTask_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskService appTaskService = new AppTaskService(LanguageRequest, dbTestDB, ContactID);

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
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite,VisualPlumesScenario)]
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite,VisualPlumesScenario"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite,VisualPlumesScenario)]
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskTVItemID2, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite,VisualPlumesScenario"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


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


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateTime_UTC)]
                    // appTask.EndDateTime_UTC   (DateTime)
                    // -----------------------------------


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
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appTask.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


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
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // appTask.TVItemTVText   (String)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItemTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskTVItemTVText, "200"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TVItemID2", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // appTask.TVItem2TVText   (String)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.TVItem2TVText = GetRandomString("", 201);
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskTVItem2TVText, "200"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // appTask.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskLastUpdateContactTVText, "200"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // appTask.AppTaskCommandText   (String)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskCommandText = GetRandomString("", 101);
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskAppTaskCommandText, "100"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // appTask.AppTaskStatusText   (String)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.AppTaskStatusText = GetRandomString("", 101);
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskAppTaskStatusText, "100"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // appTask.LanguageText   (String)
                    // -----------------------------------

                    appTask = null;
                    appTask = GetFilledRandomAppTask("");
                    appTask.LanguageText = GetRandomString("", 101);
                    Assert.AreEqual(false, appTaskService.Add(appTask));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskLanguageText, "100"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTask.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTask.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void AppTask_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskService appTaskService = new AppTaskService(LanguageRequest, dbTestDB, ContactID);
                    AppTask appTask = (from c in appTaskService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(appTask);

                    AppTask appTaskRet = appTaskService.GetAppTaskWithAppTaskID(appTask.AppTaskID);
                    Assert.IsNotNull(appTaskRet.AppTaskID);
                    Assert.IsNotNull(appTaskRet.TVItemID);
                    Assert.IsNotNull(appTaskRet.TVItemID2);
                    Assert.IsNotNull(appTaskRet.AppTaskCommand);
                    Assert.IsNotNull(appTaskRet.AppTaskStatus);
                    Assert.IsNotNull(appTaskRet.PercentCompleted);
                    Assert.IsNotNull(appTaskRet.Parameters);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskRet.Parameters));
                    Assert.IsNotNull(appTaskRet.Language);
                    Assert.IsNotNull(appTaskRet.StartDateTime_UTC);
                    if (appTaskRet.EndDateTime_UTC != null)
                    {
                       Assert.IsNotNull(appTaskRet.EndDateTime_UTC);
                    }
                    if (appTaskRet.EstimatedLength_second != null)
                    {
                       Assert.IsNotNull(appTaskRet.EstimatedLength_second);
                    }
                    if (appTaskRet.RemainingTime_second != null)
                    {
                       Assert.IsNotNull(appTaskRet.RemainingTime_second);
                    }
                    Assert.IsNotNull(appTaskRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(appTaskRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(appTaskRet.TVItemTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskRet.TVItemTVText));
                    Assert.IsNotNull(appTaskRet.TVItem2TVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskRet.TVItem2TVText));
                    Assert.IsNotNull(appTaskRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskRet.LastUpdateContactTVText));
                    Assert.IsNotNull(appTaskRet.AppTaskCommandText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskRet.AppTaskCommandText));
                    Assert.IsNotNull(appTaskRet.AppTaskStatusText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskRet.AppTaskStatusText));
                    Assert.IsNotNull(appTaskRet.LanguageText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskRet.LanguageText));
                    Assert.IsNotNull(appTaskRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
