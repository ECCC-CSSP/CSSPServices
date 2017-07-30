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
    public partial class AppTaskTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private AppTaskService appTaskService { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskTest() : base()
        {
            appTaskService = new AppTaskService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTask GetFilledRandomAppTask(string OmitPropName)
        {
            AppTask appTask = new AppTask();

            if (OmitPropName != "TVItemID") appTask.TVItemID = 2;
            if (OmitPropName != "TVItemID2") appTask.TVItemID2 = 2;
            if (OmitPropName != "AppTaskCommand") appTask.AppTaskCommand = (AppTaskCommandEnum)GetRandomEnumType(typeof(AppTaskCommandEnum));
            if (OmitPropName != "AppTaskStatus") appTask.AppTaskStatus = (AppTaskStatusEnum)GetRandomEnumType(typeof(AppTaskStatusEnum));
            if (OmitPropName != "PercentCompleted") appTask.PercentCompleted = GetRandomInt(0, 100);
            if (OmitPropName != "Parameters") appTask.Parameters = GetRandomString("", 20);
            if (OmitPropName != "Language") appTask.Language = language;
            if (OmitPropName != "StartDateTime_UTC") appTask.StartDateTime_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_UTC") appTask.EndDateTime_UTC = new DateTime(2005, 3, 7);
            if (OmitPropName != "EstimatedLength_second") appTask.EstimatedLength_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "RemainingTime_second") appTask.RemainingTime_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "LastUpdateDate_UTC") appTask.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTask.LastUpdateContactTVItemID = 2;

            return appTask;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AppTask_Testing()
        {

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

            appTaskService.Add(appTask);
            if (appTask.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", appTask.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, appTaskService.GetRead().Where(c => c == appTask).Any());
            appTaskService.Update(appTask);
            if (appTask.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", appTask.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, appTaskService.GetRead().Count());
            appTaskService.Delete(appTask);
            if (appTask.ValidationResults.Count() > 0)
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
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskAppTaskID), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // appTask.TVItemID   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID = 0;
            appTaskService.Add(appTask);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskTVItemID, appTask.TVItemID.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // appTask.TVItemID2   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.TVItemID2 = 0;
            appTaskService.Add(appTask);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskTVItemID2, appTask.TVItemID2.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTask.AppTaskCommand   (AppTaskCommandEnum)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskCommand = (AppTaskCommandEnum)1000000;
            appTaskService.Add(appTask);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskAppTaskCommand), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // appTask.AppTaskStatus   (AppTaskStatusEnum)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskStatus = (AppTaskStatusEnum)1000000;
            appTaskService.Add(appTask);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskAppTaskStatus), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // appTask.PercentCompleted   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.PercentCompleted = -1;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskPercentCompleted, "0", "100"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.PercentCompleted = 101;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskPercentCompleted, "0", "100"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, appTaskService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // appTask.Parameters   (String)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("Parameters");
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(1, appTask.ValidationResults.Count());
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskParameters)).Any());
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
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguage), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


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
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskEstimatedLength_second, "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.EstimatedLength_second = 1000001;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskEstimatedLength_second, "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskRemainingTime_second, "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.RemainingTime_second = 1000001;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskRemainingTime_second, "0", "1000000"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, appTaskService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appTask.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // appTask.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateContactTVItemID = 0;
            appTaskService.Add(appTask);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskLastUpdateContactTVItemID, appTask.LastUpdateContactTVItemID.ToString()), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            appTask.LastUpdateContactTVItemID = 1;
            appTaskService.Add(appTask);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppTaskLastUpdateContactTVItemID, "Contact"), appTask.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // appTask.AppTaskLanguages   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // appTask.TVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // appTask.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
