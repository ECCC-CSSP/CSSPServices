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
            if (OmitPropName != "LastUpdateDate_UTC") tel.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelID = 0;
            telService.Update(tel);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TelTelID), tel.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Tel)]
            // tel.TelTVItemID   (Int32)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelTVItemID = 0;
            telService.Add(tel);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TelTelTVItemID, tel.TelTVItemID.ToString()), tel.ValidationResults.FirstOrDefault().ErrorMessage);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelTVItemID = 1;
            telService.Add(tel);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TelTelTVItemID, "Tel"), tel.ValidationResults.FirstOrDefault().ErrorMessage);


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
            Assert.AreEqual(count, telService.GetRead().Count());

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelNumber = GetRandomString("", 51);
            Assert.AreEqual(false, telService.Add(tel));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TelTelNumber, "50"), tel.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, telService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tel.TelType   (TelTypeEnum)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.TelType = (TelTypeEnum)1000000;
            telService.Add(tel);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TelTelType), tel.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tel.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tel.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateContactTVItemID = 0;
            telService.Add(tel);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TelLastUpdateContactTVItemID, tel.LastUpdateContactTVItemID.ToString()), tel.ValidationResults.FirstOrDefault().ErrorMessage);

            tel = null;
            tel = GetFilledRandomTel("");
            tel.LastUpdateContactTVItemID = 1;
            telService.Add(tel);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TelLastUpdateContactTVItemID, "Contact"), tel.ValidationResults.FirstOrDefault().ErrorMessage);


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
