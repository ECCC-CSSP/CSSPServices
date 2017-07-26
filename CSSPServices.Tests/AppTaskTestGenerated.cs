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
            if (OmitPropName != "StartDateTime_UTC") appTask.StartDateTime_UTC = GetRandomDateTime();
            if (OmitPropName != "EndDateTime_UTC") appTask.EndDateTime_UTC = GetRandomDateTime();
            if (OmitPropName != "EstimatedLength_second") appTask.EstimatedLength_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "RemainingTime_second") appTask.RemainingTime_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "LastUpdateDate_UTC") appTask.LastUpdateDate_UTC = GetRandomDateTime();
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


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // appTask.AppTaskID   (Int32)
            //-----------------------------------
            appTask = GetFilledRandomAppTask("");
            appTask.AppTaskID = 0;
            appTaskService.Update(appTask);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskAppTaskID), appTask.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // appTask.TVItemID   (Int32)
            //-----------------------------------
            // TVItemID will automatically be initialized at 0 --> not null


            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // TVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            appTask.TVItemID = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.TVItemID);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTask.TVItemID = 2;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(2, appTask.TVItemID);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTask.TVItemID = 0;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskTVItemID, "1")).Any());
            Assert.AreEqual(0, appTask.TVItemID);
            Assert.AreEqual(count, appTaskService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // appTask.TVItemID2   (Int32)
            //-----------------------------------
            // TVItemID2 will automatically be initialized at 0 --> not null


            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // TVItemID2 has Min [1] and Max [empty]. At Min should return true and no errors
            appTask.TVItemID2 = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.TVItemID2);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // TVItemID2 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTask.TVItemID2 = 2;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(2, appTask.TVItemID2);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // TVItemID2 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTask.TVItemID2 = 0;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskTVItemID2, "1")).Any());
            Assert.AreEqual(0, appTask.TVItemID2);
            Assert.AreEqual(count, appTaskService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // appTask.AppTaskCommand   (AppTaskCommandEnum)
            //-----------------------------------
            // AppTaskCommand will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // appTask.AppTaskStatus   (AppTaskStatusEnum)
            //-----------------------------------
            // AppTaskStatus will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 100)]
            // appTask.PercentCompleted   (Int32)
            //-----------------------------------
            // PercentCompleted will automatically be initialized at 0 --> not null


            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // PercentCompleted has Min [0] and Max [100]. At Min should return true and no errors
            appTask.PercentCompleted = 0;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(0, appTask.PercentCompleted);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Min + 1 should return true and no errors
            appTask.PercentCompleted = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.PercentCompleted);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Min - 1 should return false with one error
            appTask.PercentCompleted = -1;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskPercentCompleted, "0", "100")).Any());
            Assert.AreEqual(-1, appTask.PercentCompleted);
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Max should return true and no errors
            appTask.PercentCompleted = 100;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(100, appTask.PercentCompleted);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Max - 1 should return true and no errors
            appTask.PercentCompleted = 99;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(99, appTask.PercentCompleted);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Max + 1 should return false with one error
            appTask.PercentCompleted = 101;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskPercentCompleted, "0", "100")).Any());
            Assert.AreEqual(101, appTask.PercentCompleted);
            Assert.AreEqual(count, appTaskService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            // appTask.Parameters   (String)
            //-----------------------------------
            appTask = null;
            appTask = GetFilledRandomAppTask("Parameters");
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(1, appTask.ValidationResults.Count());
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskParameters)).Any());
            Assert.AreEqual(null, appTask.Parameters);
            Assert.AreEqual(0, appTaskService.GetRead().Count());


            appTask = null;
            appTask = GetFilledRandomAppTask("");

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // appTask.Language   (LanguageEnum)
            //-----------------------------------
            // Language will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // appTask.StartDateTime_UTC   (DateTime)
            //-----------------------------------
            // StartDateTime_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            //[CSSPBigger(OtherField = StartDateTime_UTC)]
            // appTask.EndDateTime_UTC   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[Range(0, 1000000)]
            // appTask.EstimatedLength_second   (Int32)
            //-----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // EstimatedLength_second has Min [0] and Max [1000000]. At Min should return true and no errors
            appTask.EstimatedLength_second = 0;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(0, appTask.EstimatedLength_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            appTask.EstimatedLength_second = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.EstimatedLength_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            appTask.EstimatedLength_second = -1;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskEstimatedLength_second, "0", "1000000")).Any());
            Assert.AreEqual(-1, appTask.EstimatedLength_second);
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Max should return true and no errors
            appTask.EstimatedLength_second = 1000000;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1000000, appTask.EstimatedLength_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            appTask.EstimatedLength_second = 999999;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(999999, appTask.EstimatedLength_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            appTask.EstimatedLength_second = 1000001;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskEstimatedLength_second, "0", "1000000")).Any());
            Assert.AreEqual(1000001, appTask.EstimatedLength_second);
            Assert.AreEqual(count, appTaskService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 1000000)]
            // appTask.RemainingTime_second   (Int32)
            //-----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // RemainingTime_second has Min [0] and Max [1000000]. At Min should return true and no errors
            appTask.RemainingTime_second = 0;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(0, appTask.RemainingTime_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            appTask.RemainingTime_second = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.RemainingTime_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            appTask.RemainingTime_second = -1;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskRemainingTime_second, "0", "1000000")).Any());
            Assert.AreEqual(-1, appTask.RemainingTime_second);
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Max should return true and no errors
            appTask.RemainingTime_second = 1000000;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1000000, appTask.RemainingTime_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            appTask.RemainingTime_second = 999999;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(999999, appTask.RemainingTime_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            appTask.RemainingTime_second = 1000001;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskRemainingTime_second, "0", "1000000")).Any());
            Assert.AreEqual(1000001, appTask.RemainingTime_second);
            Assert.AreEqual(count, appTaskService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // appTask.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // appTask.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            appTask.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTask.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(2, appTask.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(count, appTaskService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTask.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, appTask.LastUpdateContactTVItemID);
            Assert.AreEqual(count, appTaskService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // appTask.AppTaskLanguages   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // appTask.TVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // appTask.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
