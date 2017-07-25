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
    public partial class AppErrLogTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private AppErrLogService appErrLogService { get; set; }
        #endregion Properties

        #region Constructors
        public AppErrLogTest() : base()
        {
            appErrLogService = new AppErrLogService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "DateTime_UTC") appErrLog.DateTime_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateDate_UTC") appErrLog.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") appErrLog.LastUpdateContactTVItemID = 2;

            return appErrLog;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AppErrLog_Testing()
        {

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

            appErrLogService.Add(appErrLog);
            if (appErrLog.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, appErrLogService.GetRead().Where(c => c == appErrLog).Any());
            appErrLogService.Update(appErrLog);
            if (appErrLog.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, appErrLogService.GetRead().Count());
            appErrLogService.Delete(appErrLog);
            if (appErrLog.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, appErrLogService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("Tag");
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.AreEqual(1, appErrLog.ValidationResults.Count());
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogTag)).Any());
            Assert.AreEqual(null, appErrLog.Tag);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());

            // LineNumber will automatically be initialized at 0 --> not null

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("Source");
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.AreEqual(1, appErrLog.ValidationResults.Count());
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogSource)).Any());
            Assert.AreEqual(null, appErrLog.Source);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("Message");
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.AreEqual(1, appErrLog.ValidationResults.Count());
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogMessage)).Any());
            Assert.AreEqual(null, appErrLog.Message);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("DateTime_UTC");
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.AreEqual(1, appErrLog.ValidationResults.Count());
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogDateTime_UTC)).Any());
            Assert.IsTrue(appErrLog.DateTime_UTC.Year < 1900);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("LastUpdateDate_UTC");
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.AreEqual(1, appErrLog.ValidationResults.Count());
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogLastUpdateDate_UTC)).Any());
            Assert.IsTrue(appErrLog.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [AppErrLogID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [Tag] of type [String]
            //-----------------------------------

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");

            //-----------------------------------
            // doing property [LineNumber] of type [Int32]
            //-----------------------------------

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");
            // LineNumber has Min [1] and Max [empty]. At Min should return true and no errors
            appErrLog.LineNumber = 1;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(1, appErrLog.LineNumber);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(0, appErrLogService.GetRead().Count());
            // LineNumber has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appErrLog.LineNumber = 2;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(2, appErrLog.LineNumber);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(0, appErrLogService.GetRead().Count());
            // LineNumber has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appErrLog.LineNumber = 0;
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppErrLogLineNumber, "1")).Any());
            Assert.AreEqual(0, appErrLog.LineNumber);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());

            //-----------------------------------
            // doing property [Source] of type [String]
            //-----------------------------------

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");

            //-----------------------------------
            // doing property [Message] of type [String]
            //-----------------------------------

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");

            //-----------------------------------
            // doing property [DateTime_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            appErrLog.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(1, appErrLog.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(0, appErrLogService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appErrLog.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(2, appErrLog.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(0, appErrLogService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appErrLog.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppErrLogLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, appErrLog.LastUpdateContactTVItemID);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
