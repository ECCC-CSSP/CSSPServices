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
            if (OmitPropName != "LastUpdateDate_UTC") log.LastUpdateDate_UTC = GetRandomDateTime();
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
            // Required properties testing
            // -------------------------------
            // -------------------------------

            log = null;
            log = GetFilledRandomLog("TableName");
            Assert.AreEqual(false, logService.Add(log));
            Assert.AreEqual(1, log.ValidationResults.Count());
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LogTableName)).Any());
            Assert.AreEqual(null, log.TableName);
            Assert.AreEqual(0, logService.GetRead().Count());

            // ID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [LogCommand]

            log = null;
            log = GetFilledRandomLog("Information");
            Assert.AreEqual(false, logService.Add(log));
            Assert.AreEqual(1, log.ValidationResults.Count());
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LogInformation)).Any());
            Assert.AreEqual(null, log.Information);
            Assert.AreEqual(0, logService.GetRead().Count());

            log = null;
            log = GetFilledRandomLog("LastUpdateDate_UTC");
            Assert.AreEqual(false, logService.Add(log));
            Assert.AreEqual(1, log.ValidationResults.Count());
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LogLastUpdateDate_UTC)).Any());
            Assert.IsTrue(log.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, logService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [LogID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [TableName] of type [String]
            //-----------------------------------

            log = null;
            log = GetFilledRandomLog("");

            //-----------------------------------
            // doing property [ID] of type [Int32]
            //-----------------------------------

            log = null;
            log = GetFilledRandomLog("");
            // ID has Min [1] and Max [empty]. At Min should return true and no errors
            log.ID = 1;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(1, log.ID);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(0, logService.GetRead().Count());
            // ID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            log.ID = 2;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(2, log.ID);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(0, logService.GetRead().Count());
            // ID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            log.ID = 0;
            Assert.AreEqual(false, logService.Add(log));
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LogID, "1")).Any());
            Assert.AreEqual(0, log.ID);
            Assert.AreEqual(0, logService.GetRead().Count());

            //-----------------------------------
            // doing property [LogCommand] of type [LogCommandEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Information] of type [String]
            //-----------------------------------

            log = null;
            log = GetFilledRandomLog("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            log = null;
            log = GetFilledRandomLog("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            log.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(1, log.LastUpdateContactTVItemID);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(0, logService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            log.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(2, log.LastUpdateContactTVItemID);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(0, logService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            log.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, logService.Add(log));
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LogLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, log.LastUpdateContactTVItemID);
            Assert.AreEqual(0, logService.GetRead().Count());

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
