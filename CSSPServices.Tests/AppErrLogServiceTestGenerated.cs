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
    public partial class AppErrLogServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AppErrLogService appErrLogService { get; set; }
        #endregion Properties

        #region Constructors
        public AppErrLogServiceTest() : base()
        {
            //appErrLogService = new AppErrLogService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "DateTime_UTC") appErrLog.DateTime_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateDate_UTC") appErrLog.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appErrLog.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") appErrLog.LastUpdateContactTVText = GetRandomString("", 5);

            return appErrLog;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AppErrLog_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                AppErrLogService appErrLogService = new AppErrLogService(LanguageRequest, dbTestDB, ContactID);

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

                appErrLog = null;
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
                Assert.AreEqual(count, appErrLogService.GetRead().Count());

                appErrLog = null;
                appErrLog = GetFilledRandomAppErrLog("");
                appErrLog.Tag = GetRandomString("", 101);
                Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppErrLogTag, "100"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, appErrLogService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(1, -1)]
                // appErrLog.LineNumber   (Int32)
                // -----------------------------------

                appErrLog = null;
                appErrLog = GetFilledRandomAppErrLog("");
                appErrLog.LineNumber = 0;
                Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                Assert.AreEqual(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppErrLogLineNumber, "1"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, appErrLogService.GetRead().Count());


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
                Assert.AreEqual(count, appErrLogService.GetRead().Count());


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // appErrLog.DateTime_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // appErrLog.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // appErrLog.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                appErrLog = null;
                appErrLog = GetFilledRandomAppErrLog("");
                appErrLog.LastUpdateContactTVItemID = 0;
                appErrLogService.Add(appErrLog);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppErrLogLastUpdateContactTVItemID, appErrLog.LastUpdateContactTVItemID.ToString()), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);

                appErrLog = null;
                appErrLog = GetFilledRandomAppErrLog("");
                appErrLog.LastUpdateContactTVItemID = 1;
                appErrLogService.Add(appErrLog);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppErrLogLastUpdateContactTVItemID, "Contact"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // appErrLog.LastUpdateContactTVText   (String)
                // -----------------------------------

                appErrLog = null;
                appErrLog = GetFilledRandomAppErrLog("");
                appErrLog.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, appErrLogService.Add(appErrLog));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppErrLogLastUpdateContactTVText, "200"), appErrLog.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, appErrLogService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // appErrLog.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void AppErrLog_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                AppErrLogService appErrLogService = new AppErrLogService(LanguageRequest, dbTestDB, ContactID);
                AppErrLog appErrLog = (from c in appErrLogService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(appErrLog);

                AppErrLog appErrLogRet = appErrLogService.GetAppErrLogWithAppErrLogID(appErrLog.AppErrLogID);
                Assert.IsNotNull(appErrLogRet.AppErrLogID);
                Assert.IsNotNull(appErrLogRet.Tag);
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.Tag));
                Assert.IsNotNull(appErrLogRet.LineNumber);
                Assert.IsNotNull(appErrLogRet.Source);
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.Source));
                Assert.IsNotNull(appErrLogRet.Message);
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.Message));
                Assert.IsNotNull(appErrLogRet.DateTime_UTC);
                Assert.IsNotNull(appErrLogRet.LastUpdateDate_UTC);
                Assert.IsNotNull(appErrLogRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(appErrLogRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(appErrLogRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}