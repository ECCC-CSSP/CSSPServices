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
        private TelService telService { get; set; }
        #endregion Properties

        #region Constructors
        public TelTest() : base()
        {
            telService = new TelService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Tel GetFilledRandomTel(string OmitPropName)
        {
            Tel tel = new Tel();

            if (OmitPropName != "TelTVItemID") tel.TelTVItemID = 30;
            if (OmitPropName != "TelNumber") tel.TelNumber = GetRandomString("", 5);
            if (OmitPropName != "TelType") tel.TelType = (TelTypeEnum)GetRandomEnumType(typeof(TelTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tel.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tel.LastUpdateContactTVItemID = 2;

            return tel;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Tel_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Tel tel = GetFilledRandomTel("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = telService.GetRead().Count();

            telService.Add(tel);
            if (tel.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tel.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, telService.GetRead().Where(c => c == tel).Any());
            telService.Update(tel);
            if (tel.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tel.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, telService.GetRead().Count());
            telService.Delete(tel);
            if (tel.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tel.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, telService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tel.TelID   (Int32)
            // -----------------------------------

            tel = GetFilledRandomTel("");
            tel.TelID = 0;
            telService.Update(tel);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TelTelID), tel.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Tel)]
            // [Range(1, -1)]
            // tel.TelTVItemID   (Int32)
            // -----------------------------------

            // TelTVItemID will automatically be initialized at 0 --> not null


            tel = null;
            tel = GetFilledRandomTel("");
            // TelTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tel.TelTVItemID = 1;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(1, tel.TelTVItemID);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(count, telService.GetRead().Count());
            // TelTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tel.TelTVItemID = 2;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(2, tel.TelTVItemID);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(count, telService.GetRead().Count());
            // TelTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tel.TelTVItemID = 0;
            Assert.AreEqual(false, telService.Add(tel));
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TelTelTVItemID, "1")).Any());
            Assert.AreEqual(0, tel.TelTVItemID);
            Assert.AreEqual(count, telService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(50))]
            // tel.TelNumber   (String)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("TelNumber");
            Assert.AreEqual(false, telService.Add(tel));
            Assert.AreEqual(1, tel.ValidationResults.Count());
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TelTelNumber)).Any());
            Assert.AreEqual(null, tel.TelNumber);
            Assert.AreEqual(0, telService.GetRead().Count());


            tel = null;
            tel = GetFilledRandomTel("");

            // TelNumber has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string telTelNumberMin = GetRandomString("", 50);
            tel.TelNumber = telTelNumberMin;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(telTelNumberMin, tel.TelNumber);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(count, telService.GetRead().Count());

            // TelNumber has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            telTelNumberMin = GetRandomString("", 49);
            tel.TelNumber = telTelNumberMin;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(telTelNumberMin, tel.TelNumber);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(count, telService.GetRead().Count());

            // TelNumber has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            telTelNumberMin = GetRandomString("", 51);
            tel.TelNumber = telTelNumberMin;
            Assert.AreEqual(false, telService.Add(tel));
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TelTelNumber, "50")).Any());
            Assert.AreEqual(telTelNumberMin, tel.TelNumber);
            Assert.AreEqual(count, telService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tel.TelType   (TelTypeEnum)
            // -----------------------------------

            // TelType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tel.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // tel.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            tel = null;
            tel = GetFilledRandomTel("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tel.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(1, tel.LastUpdateContactTVItemID);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(count, telService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tel.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, telService.Add(tel));
            Assert.AreEqual(0, tel.ValidationResults.Count());
            Assert.AreEqual(2, tel.LastUpdateContactTVItemID);
            Assert.AreEqual(true, telService.Delete(tel));
            Assert.AreEqual(count, telService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tel.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, telService.Add(tel));
            Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TelLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tel.LastUpdateContactTVItemID);
            Assert.AreEqual(count, telService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tel.TelTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tel.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
