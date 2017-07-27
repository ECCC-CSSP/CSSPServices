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
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // appErrLog.AppErrLogID   (Int32)
            // -----------------------------------

            appErrLog = GetFilledRandomAppErrLog("");
            appErrLog.AppErrLogID = 0;
            appErrLogService.Update(appErrLog);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogAppErrLogID), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // appErrLog.Tag   (String)
            // -----------------------------------

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("Tag");
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.AreEqual(1, appErrLog.ValidationResults.Count());
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogTag)).Any());
            Assert.AreEqual(null, appErrLog.Tag);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());


            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");

            // Tag has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string appErrLogTagMin = GetRandomString("", 100);
            appErrLog.Tag = appErrLogTagMin;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(appErrLogTagMin, appErrLog.Tag);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(count, appErrLogService.GetRead().Count());

            // Tag has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            appErrLogTagMin = GetRandomString("", 99);
            appErrLog.Tag = appErrLogTagMin;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(appErrLogTagMin, appErrLog.Tag);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(count, appErrLogService.GetRead().Count());

            // Tag has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            appErrLogTagMin = GetRandomString("", 101);
            appErrLog.Tag = appErrLogTagMin;
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppErrLogTag, "100")).Any());
            Assert.AreEqual(appErrLogTagMin, appErrLog.Tag);
            Assert.AreEqual(count, appErrLogService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(1, -1)]
            // appErrLog.LineNumber   (Int32)
            // -----------------------------------

            // LineNumber will automatically be initialized at 0 --> not null


            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");
            // LineNumber has Min [1] and Max [empty]. At Min should return true and no errors
            appErrLog.LineNumber = 1;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(1, appErrLog.LineNumber);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(count, appErrLogService.GetRead().Count());
            // LineNumber has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appErrLog.LineNumber = 2;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(2, appErrLog.LineNumber);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(count, appErrLogService.GetRead().Count());
            // LineNumber has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appErrLog.LineNumber = 0;
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppErrLogLineNumber, "1")).Any());
            Assert.AreEqual(0, appErrLog.LineNumber);
            Assert.AreEqual(count, appErrLogService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // appErrLog.Source   (String)
            // -----------------------------------

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("Source");
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.AreEqual(1, appErrLog.ValidationResults.Count());
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogSource)).Any());
            Assert.AreEqual(null, appErrLog.Source);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());


            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");

            // -----------------------------------
            // Is NOT Nullable
            // appErrLog.Message   (String)
            // -----------------------------------

            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("Message");
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.AreEqual(1, appErrLog.ValidationResults.Count());
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogMessage)).Any());
            Assert.AreEqual(null, appErrLog.Message);
            Assert.AreEqual(0, appErrLogService.GetRead().Count());


            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appErrLog.DateTime_UTC   (DateTime)
            // -----------------------------------

            // DateTime_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // appErrLog.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // appErrLog.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            appErrLog = null;
            appErrLog = GetFilledRandomAppErrLog("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            appErrLog.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(1, appErrLog.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(count, appErrLogService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            appErrLog.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, appErrLogService.Add(appErrLog));
            Assert.AreEqual(0, appErrLog.ValidationResults.Count());
            Assert.AreEqual(2, appErrLog.LastUpdateContactTVItemID);
            Assert.AreEqual(true, appErrLogService.Delete(appErrLog));
            Assert.AreEqual(count, appErrLogService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            appErrLog.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, appErrLogService.Add(appErrLog));
            Assert.IsTrue(appErrLog.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AppErrLogLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, appErrLog.LastUpdateContactTVItemID);
            Assert.AreEqual(count, appErrLogService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // appErrLog.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
