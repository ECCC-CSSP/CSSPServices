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
                    TelService telService = new TelService(new GetParam(), dbTestDB, ContactID);

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
                    // Is Nullable
                    // [NotMapped]
                    // tel.TelWeb   (TelWeb)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelWeb = null;
                    Assert.IsNull(tel.TelWeb);

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelWeb = new TelWeb();
                    Assert.IsNotNull(tel.TelWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tel.TelReport   (TelReport)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelReport = null;
                    Assert.IsNull(tel.TelReport);

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelReport = new TelReport();
                    Assert.IsNotNull(tel.TelReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tel.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.LastUpdateDate_UTC = new DateTime();
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TelLastUpdateDate_UTC), tel.ValidationResults.FirstOrDefault().ErrorMessage);
                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TelLastUpdateDate_UTC, "1980"), tel.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    // Is NOT Nullable
                    // [NotMapped]
                    // tel.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tel.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
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
                    GetParam getParam = new GetParam();
                    TelService telService = new TelService(new GetParam(), dbTestDB, ContactID);
                    Tel tel = (from c in telService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tel);

                    Tel telRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            telRet = telService.GetTelWithTelID(tel.TelID, getParam);
                            Assert.IsNull(telRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            telRet = telService.GetTelWithTelID(tel.TelID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            telRet = telService.GetTelWithTelID(tel.TelID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            telRet = telService.GetTelWithTelID(tel.TelID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Tel fields
                        Assert.IsNotNull(telRet.TelID);
                        Assert.IsNotNull(telRet.TelTVItemID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelNumber));
                        Assert.IsNotNull(telRet.TelType);
                        Assert.IsNotNull(telRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(telRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // TelWeb and TelReport fields should be null here
                            Assert.IsNull(telRet.TelWeb);
                            Assert.IsNull(telRet.TelReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // TelWeb fields should not be null and TelReport fields should be null here
                            if (telRet.TelWeb.TelTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelWeb.TelTVText));
                            }
                            if (telRet.TelWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelWeb.LastUpdateContactTVText));
                            }
                            if (telRet.TelWeb.TelTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelWeb.TelTypeText));
                            }
                            Assert.IsNull(telRet.TelReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // TelWeb and TelReport fields should NOT be null here
                            if (telRet.TelWeb.TelTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelWeb.TelTVText));
                            }
                            if (telRet.TelWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelWeb.LastUpdateContactTVText));
                            }
                            if (telRet.TelWeb.TelTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelWeb.TelTypeText));
                            }
                            if (telRet.TelReport.TelReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(telRet.TelReport.TelReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of Tel
        #endregion Tests Get List of Tel

    }
}
