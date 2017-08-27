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
    public partial class LogServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LogService logService { get; set; }
        #endregion Properties

        #region Constructors
        public LogServiceTest() : base()
        {
            //logService = new LogService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Log GetFilledRandomLog(string OmitPropName)
        {
            Log log = new Log();

            if (OmitPropName != "TableName") log.TableName = GetRandomString("", 5);
            if (OmitPropName != "ID") log.ID = GetRandomInt(1, 11);
            if (OmitPropName != "LogCommand") log.LogCommand = (LogCommandEnum)GetRandomEnumType(typeof(LogCommandEnum));
            if (OmitPropName != "Information") log.Information = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") log.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") log.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") log.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "LogCommandText") log.LogCommandText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") log.HasErrors = true;

            return log;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Log_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LogService logService = new LogService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Log log = GetFilledRandomLog("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                count = logService.GetRead().Count();

                Assert.AreEqual(logService.GetRead().Count(), logService.GetEdit().Count());

                logService.Add(log);
                if (log.HasErrors)
                {
                    Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, logService.GetRead().Where(c => c == log).Any());
                logService.Update(log);
                if (log.HasErrors)
                {
                    Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, logService.GetRead().Count());
                logService.Delete(log);
                if (log.HasErrors)
                {
                    Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, logService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // log.LogID   (Int32)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogID = 0;
                    logService.Update(log);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LogLogID), log.ValidationResults.FirstOrDefault().ErrorMessage);

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogID = 10000000;
                    logService.Update(log);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Log, ModelsRes.LogLogID, log.LogID.ToString()), log.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // log.TableName   (String)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("TableName");
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(1, log.ValidationResults.Count());
                    Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LogTableName)).Any());
                    Assert.AreEqual(null, log.TableName);
                    Assert.AreEqual(count, logService.GetRead().Count());

                    log = null;
                    log = GetFilledRandomLog("");
                    log.TableName = GetRandomString("", 51);
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LogTableName, "50"), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, logService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, -1)]
                    // log.ID   (Int32)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.ID = 0;
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(string.Format(ServicesRes._MinValueIs_, ModelsRes.LogID, "1"), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, logService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // log.LogCommand   (LogCommandEnum)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogCommand = (LogCommandEnum)1000000;
                    logService.Add(log);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LogLogCommand), log.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // log.Information   (String)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("Information");
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(1, log.ValidationResults.Count());
                    Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LogInformation)).Any());
                    Assert.AreEqual(null, log.Information);
                    Assert.AreEqual(count, logService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // log.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // log.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateContactTVItemID = 0;
                    logService.Add(log);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LogLastUpdateContactTVItemID, log.LastUpdateContactTVItemID.ToString()), log.ValidationResults.FirstOrDefault().ErrorMessage);

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateContactTVItemID = 1;
                    logService.Add(log);
                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LogLastUpdateContactTVItemID, "Contact"), log.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // log.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LogLastUpdateContactTVText, "200"), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, logService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // log.LogCommandText   (String)
                    // -----------------------------------

                    log = null;
                    log = GetFilledRandomLog("");
                    log.LogCommandText = GetRandomString("", 101);
                    Assert.AreEqual(false, logService.Add(log));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LogLogCommandText, "100"), log.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, logService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // log.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // log.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void Log_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LogService logService = new LogService(LanguageRequest, dbTestDB, ContactID);
                    Log log = (from c in logService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(log);

                    Log logRet = logService.GetLogWithLogID(log.LogID);
                    Assert.IsNotNull(logRet.LogID);
                    Assert.IsNotNull(logRet.TableName);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.TableName));
                    Assert.IsNotNull(logRet.ID);
                    Assert.IsNotNull(logRet.LogCommand);
                    Assert.IsNotNull(logRet.Information);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.Information));
                    Assert.IsNotNull(logRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(logRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(logRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.LastUpdateContactTVText));
                    Assert.IsNotNull(logRet.LogCommandText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(logRet.LogCommandText));
                    Assert.IsNotNull(logRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
