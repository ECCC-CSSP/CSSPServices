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
    public partial class TelServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TelService telService { get; set; }
        #endregion Properties

        #region Constructors
        public TelServiceTest() : base()
        {
            //telService = new TelService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "TelTVText") tel.TelTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") tel.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "TelTypeText") tel.TelTypeText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") tel.HasErrors = true;

            return tel;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Tel_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TelService telService = new TelService(LanguageRequest, dbTestDB, ContactID);

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

                Assert.AreEqual(telService.GetRead().Count(), telService.GetEdit().Count());

                telService.Add(tel);
                if (tel.HasErrors)
                {
                    Assert.AreEqual("", tel.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, telService.GetRead().Where(c => c == tel).Any());
                telService.Update(tel);
                if (tel.HasErrors)
                {
                    Assert.AreEqual("", tel.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, telService.GetRead().Count());
                telService.Delete(tel);
                if (tel.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TelTelID), tel.ValidationResults.FirstOrDefault().ErrorMessage);

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelID = 10000000;
                    telService.Update(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Tel, CSSPModelsRes.TelTelID, tel.TelID.ToString()), tel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Tel)]
                    // tel.TelTVItemID   (Int32)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelTVItemID = 0;
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TelTelTVItemID, tel.TelTVItemID.ToString()), tel.ValidationResults.FirstOrDefault().ErrorMessage);

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelTVItemID = 1;
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TelTelTVItemID, "Tel"), tel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // tel.TelNumber   (String)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("TelNumber");
                    Assert.AreEqual(false, telService.Add(tel));
                    Assert.AreEqual(1, tel.ValidationResults.Count());
                    Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TelTelNumber)).Any());
                    Assert.AreEqual(null, tel.TelNumber);
                    Assert.AreEqual(count, telService.GetRead().Count());

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelNumber = GetRandomString("", 51);
                    Assert.AreEqual(false, telService.Add(tel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TelTelNumber, "50"), tel.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TelTelType), tel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tel.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tel.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.LastUpdateContactTVItemID = 0;
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TelLastUpdateContactTVItemID, tel.LastUpdateContactTVItemID.ToString()), tel.ValidationResults.FirstOrDefault().ErrorMessage);

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.LastUpdateContactTVItemID = 1;
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TelLastUpdateContactTVItemID, "Contact"), tel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TelTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // tel.TelTVText   (String)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, telService.Add(tel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TelTelTVText, "200"), tel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, telService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // tel.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, telService.Add(tel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TelLastUpdateContactTVText, "200"), tel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, telService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // tel.TelTypeText   (String)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelTypeText = GetRandomString("", 101);
                    Assert.AreEqual(false, telService.Add(tel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TelTelTypeText, "100"), tel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, telService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tel.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tel.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void Tel_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TelService telService = new TelService(LanguageRequest, dbTestDB, ContactID);
                    Tel tel = (from c in telService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tel);

                    Tel telRet = telService.GetTelWithTelID(tel.TelID);
                    Assert.IsNotNull(telRet.TelID);
                    Assert.IsNotNull(telRet.TelTVItemID);
                    Assert.IsNotNull(telRet.TelNumber);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelNumber));
                    Assert.IsNotNull(telRet.TelType);
                    Assert.IsNotNull(telRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(telRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(telRet.TelTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelTVText));
                    Assert.IsNotNull(telRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.LastUpdateContactTVText));
                    Assert.IsNotNull(telRet.TelTypeText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelTypeText));
                    Assert.IsNotNull(telRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
