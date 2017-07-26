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
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // log.LogID   (Int32)
            //-----------------------------------
            log = GetFilledRandomLog("");
            log.LogID = 0;
            logService.Update(log);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.LogLogID), log.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(50))]
            // log.TableName   (String)
            //-----------------------------------
            log = null;
            log = GetFilledRandomLog("TableName");
            Assert.AreEqual(false, logService.Add(log));
            Assert.AreEqual(1, log.ValidationResults.Count());
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LogTableName)).Any());
            Assert.AreEqual(null, log.TableName);
            Assert.AreEqual(0, logService.GetRead().Count());


            log = null;
            log = GetFilledRandomLog("");

            // TableName has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string logTableNameMin = GetRandomString("", 50);
            log.TableName = logTableNameMin;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(logTableNameMin, log.TableName);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(count, logService.GetRead().Count());

            // TableName has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            logTableNameMin = GetRandomString("", 49);
            log.TableName = logTableNameMin;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(logTableNameMin, log.TableName);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(count, logService.GetRead().Count());

            // TableName has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            logTableNameMin = GetRandomString("", 51);
            log.TableName = logTableNameMin;
            Assert.AreEqual(false, logService.Add(log));
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LogTableName, "50")).Any());
            Assert.AreEqual(logTableNameMin, log.TableName);
            Assert.AreEqual(count, logService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(1, -1)]
            // log.ID   (Int32)
            //-----------------------------------
            // ID will automatically be initialized at 0 --> not null


            log = null;
            log = GetFilledRandomLog("");
            // ID has Min [1] and Max [empty]. At Min should return true and no errors
            log.ID = 1;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(1, log.ID);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(count, logService.GetRead().Count());
            // ID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            log.ID = 2;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(2, log.ID);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(count, logService.GetRead().Count());
            // ID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            log.ID = 0;
            Assert.AreEqual(false, logService.Add(log));
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LogID, "1")).Any());
            Assert.AreEqual(0, log.ID);
            Assert.AreEqual(count, logService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // log.LogCommand   (LogCommandEnum)
            //-----------------------------------
            // LogCommand will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            // log.Information   (String)
            //-----------------------------------
            log = null;
            log = GetFilledRandomLog("Information");
            Assert.AreEqual(false, logService.Add(log));
            Assert.AreEqual(1, log.ValidationResults.Count());
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.LogInformation)).Any());
            Assert.AreEqual(null, log.Information);
            Assert.AreEqual(0, logService.GetRead().Count());


            log = null;
            log = GetFilledRandomLog("");

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // log.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // log.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            log = null;
            log = GetFilledRandomLog("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            log.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(1, log.LastUpdateContactTVItemID);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(count, logService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            log.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, logService.Add(log));
            Assert.AreEqual(0, log.ValidationResults.Count());
            Assert.AreEqual(2, log.LastUpdateContactTVItemID);
            Assert.AreEqual(true, logService.Delete(log));
            Assert.AreEqual(count, logService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            log.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, logService.Add(log));
            Assert.IsTrue(log.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.LogLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, log.LastUpdateContactTVItemID);
            Assert.AreEqual(count, logService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // log.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
