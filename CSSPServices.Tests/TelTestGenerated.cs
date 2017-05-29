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
    public partial class TelTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TelID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TelTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Tel GetFilledRandomTel(string OmitPropName)
        {
            TelID += 1;

            Tel tel = new Tel();

            if (OmitPropName != "TelID") tel.TelID = TelID;
            if (OmitPropName != "TelTVItemID") tel.TelTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TelNumber") tel.TelNumber = GetRandomString("", 5);
            if (OmitPropName != "TelType") tel.TelType = (TelTypeEnum)GetRandomEnumType(typeof(TelTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tel.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tel.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tel;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Tel_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            TelService telService = new TelService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Tel tel = GetFilledRandomTel("");
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(true, telService.GetRead().Where(c => c == tel).Any());
            tel.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, telService.Update(tel));
            Assert.AreEqual(1, telService.GetRead().Count());
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(0, telService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TelTVItemID will automatically be initialized at 0 --> not null

            tel = null;
            tel = GetFilledRandomTel("TelNumber");
            Assert.AreEqual(false, telService.Add(tel));
            Assert.AreEqual(1, tel.ValidationResults.Count());
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TelTelNumber)).Any());
            Assert.AreEqual(null, tel.TelNumber);
            Assert.AreEqual(0, telService.GetRead().Count());

            tel = null;
            tel = GetFilledRandomTel("TelType");
            Assert.AreEqual(false, telService.Add(tel));
            Assert.AreEqual(1, tel.ValidationResults.Count());
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TelTelType)).Any());
            Assert.AreEqual(TelTypeEnum.Error, tel.TelType);
            Assert.AreEqual(0, telService.GetRead().Count());

            tel = null;
            tel = GetFilledRandomTel("LastUpdateDate_UTC");
            Assert.AreEqual(false, telService.Add(tel));
            Assert.AreEqual(1, tel.ValidationResults.Count());
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TelLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tel.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, telService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TelID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [TelTVItemID] of type [int]
            //-----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            // TelTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tel.TelTVItemID = 1;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(1, tel.TelTVItemID);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(0, telService.GetRead().Count());
            // TelTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tel.TelTVItemID = 2;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(2, tel.TelTVItemID);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(0, telService.GetRead().Count());
            // TelTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tel.TelTVItemID = 0;
            Assert.AreEqual(false, telService.Add(tel));
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TelTelTVItemID, "1")).Any());
            Assert.AreEqual(0, tel.TelTVItemID);
            Assert.AreEqual(0, telService.GetRead().Count());

            //-----------------------------------
            // doing property [TelNumber] of type [string]
            //-----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");

            // TelNumber has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string telTelNumberMin = GetRandomString("", 50);
            tel.TelNumber = telTelNumberMin;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(telTelNumberMin, tel.TelNumber);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(0, telService.GetRead().Count());

            // TelNumber has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            telTelNumberMin = GetRandomString("", 49);
            tel.TelNumber = telTelNumberMin;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(telTelNumberMin, tel.TelNumber);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(0, telService.GetRead().Count());

            // TelNumber has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            telTelNumberMin = GetRandomString("", 51);
            tel.TelNumber = telTelNumberMin;
            Assert.AreEqual(false, telService.Add(tel));
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TelTelNumber, "50")).Any());
            Assert.AreEqual(telTelNumberMin, tel.TelNumber);
            Assert.AreEqual(0, telService.GetRead().Count());

            //-----------------------------------
            // doing property [TelType] of type [TelTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tel.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(1, tel.LastUpdateContactTVItemID);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(0, telService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tel.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(2, tel.LastUpdateContactTVItemID);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(0, telService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tel.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, telService.Add(tel));
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TelLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tel.LastUpdateContactTVItemID);
            Assert.AreEqual(0, telService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
