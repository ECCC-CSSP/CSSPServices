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
        private int LogID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LogTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Log GetFilledRandomLog(string OmitPropName)
        {
            LogID += 1;

            Log log = new Log();

            if (OmitPropName != "LogID") log.LogID = LogID;
            if (OmitPropName != "TableName") log.TableName = GetRandomString("", 5);
            if (OmitPropName != "ID") log.ID = GetRandomInt(1, 11);
            if (OmitPropName != "LogCommand") log.LogCommand = (LogCommandEnum)GetRandomEnumType(typeof(LogCommandEnum));
            if (OmitPropName != "Information") log.Information = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") log.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") log.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return log;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Log_Testing()
        {
            SetupTestHelper(culture);
            LogService logService = new LogService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Log log = GetFilledRandomLog("");
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(true, logService.GetRead().Where(c => c == log).Any());
            log.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, logService.Update(log));
            Assert.AreEqual(1, logService.GetRead().Count());
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(0, logService.GetRead().Count());

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

            log = null;
            log = GetFilledRandomLog("LogCommand");
            Assert.AreEqual(false, logService.Add(log));
            Assert.AreEqual(1, log.ValidationResults.Count());
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LogLogCommand)).Any());
            Assert.AreEqual(LogCommandEnum.Error, log.LogCommand);
            Assert.AreEqual(0, logService.GetRead().Count());

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


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [LogID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [TableName] of type [string]
            //-----------------------------------

            log = null;
            log = GetFilledRandomLog("");

            // TableName has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string logTableNameMin = GetRandomString("", 50);
            log.TableName = logTableNameMin;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(logTableNameMin, log.TableName);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(0, logService.GetRead().Count());

            // TableName has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            logTableNameMin = GetRandomString("", 49);
            log.TableName = logTableNameMin;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(logTableNameMin, log.TableName);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(0, logService.GetRead().Count());

            // TableName has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            logTableNameMin = GetRandomString("", 51);
            log.TableName = logTableNameMin;
            Assert.AreEqual(false, logService.Add(log));
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LogTableName, "50")).Any());
            Assert.AreEqual(logTableNameMin, log.TableName);
            Assert.AreEqual(0, logService.GetRead().Count());

            //-----------------------------------
            // doing property [ID] of type [int]
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
            // doing property [Information] of type [string]
            //-----------------------------------

            log = null;
            log = GetFilledRandomLog("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
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

        }
        #endregion Tests Generated
    }
}
