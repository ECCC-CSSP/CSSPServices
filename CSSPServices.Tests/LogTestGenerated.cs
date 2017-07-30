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
    public partial class LogTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LogService logService { get; set; }
        #endregion Properties

        #region Constructors
        public LogTest() : base()
        {
            logService = new LogService(LanguageRequest, dbTestDB, ContactID);
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

            return log;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Log_Testing()
        {

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

            logService.Add(log);
            if (log.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, logService.GetRead().Where(c => c == log).Any());
            logService.Update(log);
            if (log.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", log.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, logService.GetRead().Count());
            logService.Delete(log);
            if (log.ValidationResults.Count() > 0)
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
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
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
            // Is NOT Nullable
            // [NotMapped]
            // log.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
