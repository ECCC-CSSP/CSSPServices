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
        private int AppTaskID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTask GetFilledRandomAppTask(string OmitPropName)
        {
            AppTaskID += 1;

            AppTask appTask = new AppTask();

            if (OmitPropName != "AppTaskID") appTask.AppTaskID = AppTaskID;
            if (OmitPropName != "TVItemID") appTask.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TVItemID2") appTask.TVItemID2 = GetRandomInt(1, 11);
            if (OmitPropName != "Command") appTask.Command = (AppTaskCommandEnum)GetRandomEnumType(typeof(AppTaskCommandEnum));
            if (OmitPropName != "Status") appTask.Status = (AppTaskStatusEnum)GetRandomEnumType(typeof(AppTaskStatusEnum));
            if (OmitPropName != "PercentCompleted") appTask.PercentCompleted = GetRandomInt(0, 100);
            if (OmitPropName != "Parameters") appTask.Parameters = GetRandomString("", 20);
            if (OmitPropName != "Language") appTask.Language = language;
            if (OmitPropName != "StartDateTime_UTC") appTask.StartDateTime_UTC = GetRandomDateTime();
            if (OmitPropName != "EndDateTime_UTC") appTask.EndDateTime_UTC = GetRandomDateTime();
            if (OmitPropName != "EstimatedLength_second") appTask.EstimatedLength_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "RemainingTime_second") appTask.RemainingTime_second = GetRandomInt(0, 1000000);
            if (OmitPropName != "LastUpdateDate_UTC") appTask.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") appTask.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return appTask;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AppTask_Testing()
        {
            SetupTestHelper(culture);
            AppTaskService appTaskService = new AppTaskService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            AppTask appTask = GetFilledRandomAppTask("");
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(true, appTaskService.GetRead().Where(c => c == appTask).Any());
            appTask.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, appTaskService.Update(appTask));
            Assert.AreEqual(1, appTaskService.GetRead().Count());
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVItemID will automatically be initialized at 0 --> not null

            // TVItemID2 will automatically be initialized at 0 --> not null

            appTask = null;
            appTask = GetFilledRandomAppTask("Command");
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(1, appTask.ValidationResults.Count());
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskCommand)).Any());
            Assert.AreEqual(AppTaskCommandEnum.Error, appTask.Command);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            appTask = null;
            appTask = GetFilledRandomAppTask("Status");
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(1, appTask.ValidationResults.Count());
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskStatus)).Any());
            Assert.AreEqual(AppTaskStatusEnum.Error, appTask.Status);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            // PercentCompleted will automatically be initialized at 0 --> not null

            appTask = null;
            appTask = GetFilledRandomAppTask("Parameters");
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(1, appTask.ValidationResults.Count());
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskParameters)).Any());
            Assert.AreEqual(null, appTask.Parameters);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            appTask = null;
            appTask = GetFilledRandomAppTask("Language");
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(1, appTask.ValidationResults.Count());
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguage)).Any());
            Assert.AreEqual(LanguageEnum.Error, appTask.Language);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            appTask = null;
            appTask = GetFilledRandomAppTask("StartDateTime_UTC");
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(1, appTask.ValidationResults.Count());
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskStartDateTime_UTC)).Any());
            Assert.IsTrue(appTask.StartDateTime_UTC.Year < 1900);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            appTask = null;
            appTask = GetFilledRandomAppTask("LastUpdateDate_UTC");
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.AreEqual(1, appTask.ValidationResults.Count());
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLastUpdateDate_UTC)).Any());
            Assert.IsTrue(appTask.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [AppTaskID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemID] of type [int]
            //-----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // TVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            appTask.TVItemID = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.TVItemID);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTask.TVItemID = 2;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(2, appTask.TVItemID);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTask.TVItemID = 0;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskTVItemID, "1")).Any());
            Assert.AreEqual(0, appTask.TVItemID);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            //-----------------------------------
            // doing property [TVItemID2] of type [int]
            //-----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // TVItemID2 has Min [1] and Max [empty]. At Min should return true and no errors
            appTask.TVItemID2 = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.TVItemID2);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // TVItemID2 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTask.TVItemID2 = 2;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(2, appTask.TVItemID2);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // TVItemID2 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTask.TVItemID2 = 0;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskTVItemID2, "1")).Any());
            Assert.AreEqual(0, appTask.TVItemID2);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            //-----------------------------------
            // doing property [Command] of type [AppTaskCommandEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Status] of type [AppTaskStatusEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [PercentCompleted] of type [int]
            //-----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // PercentCompleted has Min [0] and Max [100]. At Min should return true and no errors
            appTask.PercentCompleted = 0;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(0, appTask.PercentCompleted);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Min + 1 should return true and no errors
            appTask.PercentCompleted = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.PercentCompleted);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Min - 1 should return false with one error
            appTask.PercentCompleted = -1;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskPercentCompleted, "0", "100")).Any());
            Assert.AreEqual(-1, appTask.PercentCompleted);
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Max should return true and no errors
            appTask.PercentCompleted = 100;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(100, appTask.PercentCompleted);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Max - 1 should return true and no errors
            appTask.PercentCompleted = 99;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(99, appTask.PercentCompleted);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // PercentCompleted has Min [0] and Max [100]. At Max + 1 should return false with one error
            appTask.PercentCompleted = 101;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskPercentCompleted, "0", "100")).Any());
            Assert.AreEqual(101, appTask.PercentCompleted);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            //-----------------------------------
            // doing property [Parameters] of type [string]
            //-----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [StartDateTime_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EndDateTime_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EstimatedLength_second] of type [int]
            //-----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // EstimatedLength_second has Min [0] and Max [1000000]. At Min should return true and no errors
            appTask.EstimatedLength_second = 0;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(0, appTask.EstimatedLength_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            appTask.EstimatedLength_second = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.EstimatedLength_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            appTask.EstimatedLength_second = -1;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskEstimatedLength_second, "0", "1000000")).Any());
            Assert.AreEqual(-1, appTask.EstimatedLength_second);
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Max should return true and no errors
            appTask.EstimatedLength_second = 1000000;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1000000, appTask.EstimatedLength_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            appTask.EstimatedLength_second = 999999;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(999999, appTask.EstimatedLength_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // EstimatedLength_second has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            appTask.EstimatedLength_second = 1000001;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskEstimatedLength_second, "0", "1000000")).Any());
            Assert.AreEqual(1000001, appTask.EstimatedLength_second);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            //-----------------------------------
            // doing property [RemainingTime_second] of type [int]
            //-----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // RemainingTime_second has Min [0] and Max [1000000]. At Min should return true and no errors
            appTask.RemainingTime_second = 0;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(0, appTask.RemainingTime_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            appTask.RemainingTime_second = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.RemainingTime_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            appTask.RemainingTime_second = -1;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskRemainingTime_second, "0", "1000000")).Any());
            Assert.AreEqual(-1, appTask.RemainingTime_second);
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Max should return true and no errors
            appTask.RemainingTime_second = 1000000;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1000000, appTask.RemainingTime_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            appTask.RemainingTime_second = 999999;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(999999, appTask.RemainingTime_second);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // RemainingTime_second has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            appTask.RemainingTime_second = 1000001;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskRemainingTime_second, "0", "1000000")).Any());
            Assert.AreEqual(1000001, appTask.RemainingTime_second);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            appTask = null;
            appTask = GetFilledRandomAppTask("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            appTask.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(1, appTask.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appTask.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, appTaskService.Add(appTask));
            Assert.AreEqual(0, appTask.ValidationResults.Count());
            Assert.AreEqual(2, appTask.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appTaskService.Delete(appTask));
            Assert.AreEqual(0, appTaskService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appTask.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, appTaskService.Add(appTask));
            Assert.IsTrue(appTask.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, appTask.LastUpdateContactTVItemID);
            Assert.AreEqual(0, appTaskService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
