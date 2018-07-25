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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Tel_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

        #region Tests Generated for GetTelWithTelID(tel.TelID)
        [TestMethod]
        public void GetTelWithTelID__tel_TelID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Tel tel = (from c in telService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tel);

                    Tel telRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        telService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            telRet = telService.GetTelWithTelID(tel.TelID);
                            Assert.IsNull(telRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            telRet = telService.GetTelWithTelID(tel.TelID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            telRet = telService.GetTelWithTelID(tel.TelID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            telRet = telService.GetTelWithTelID(tel.TelID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTelFields(new List<Tel>() { telRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTelWithTelID(tel.TelID)

        #region Tests Generated for GetTelList()
        [TestMethod]
        public void GetTelList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Tel tel = (from c in telService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tel);

                    List<Tel> telList = new List<Tel>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        telService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            telList = telService.GetTelList().ToList();
                            Assert.AreEqual(0, telList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTelFields(telList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTelList()

        #region Tests Generated for GetTelList() Skip Take
        [TestMethod]
        public void GetTelList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<Tel> telList = new List<Tel>();
                    List<Tel> telDirectQueryList = new List<Tel>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        telDirectQueryList = telService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            telList = telService.GetTelList().ToList();
                            Assert.AreEqual(0, telList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTelFields(telList, entityQueryDetailType);
                        Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        Assert.AreEqual(1, telList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTelList() Skip Take

        #region Tests Generated for GetTelList() Skip Take Order
        [TestMethod]
        public void GetTelList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<Tel> telList = new List<Tel>();
                    List<Tel> telDirectQueryList = new List<Tel>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 1, 1,  "TelID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        telDirectQueryList = telService.GetRead().Skip(1).Take(1).OrderBy(c => c.TelID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            telList = telService.GetTelList().ToList();
                            Assert.AreEqual(0, telList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTelFields(telList, entityQueryDetailType);
                        Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        Assert.AreEqual(1, telList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTelList() Skip Take Order

        #region Tests Generated for GetTelList() Skip Take 2Order
        [TestMethod]
        public void GetTelList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<Tel> telList = new List<Tel>();
                    List<Tel> telDirectQueryList = new List<Tel>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 1, 1, "TelID,TelTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        telDirectQueryList = telService.GetRead().Skip(1).Take(1).OrderBy(c => c.TelID).ThenBy(c => c.TelTVItemID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            telList = telService.GetTelList().ToList();
                            Assert.AreEqual(0, telList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTelFields(telList, entityQueryDetailType);
                        Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        Assert.AreEqual(1, telList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTelList() Skip Take 2Order

        #region Tests Generated for GetTelList() Skip Take Order Where
        [TestMethod]
        public void GetTelList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<Tel> telList = new List<Tel>();
                    List<Tel> telDirectQueryList = new List<Tel>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 0, 1, "TelID", "TelID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        telDirectQueryList = telService.GetRead().Where(c => c.TelID == 4).Skip(0).Take(1).OrderBy(c => c.TelID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            telList = telService.GetTelList().ToList();
                            Assert.AreEqual(0, telList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTelFields(telList, entityQueryDetailType);
                        Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        Assert.AreEqual(1, telList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTelList() Skip Take Order Where

        #region Tests Generated for GetTelList() Skip Take Order 2Where
        [TestMethod]
        public void GetTelList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<Tel> telList = new List<Tel>();
                    List<Tel> telDirectQueryList = new List<Tel>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 0, 1, "TelID", "TelID,GT,2|TelID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        telDirectQueryList = telService.GetRead().Where(c => c.TelID > 2 && c.TelID < 5).Skip(0).Take(1).OrderBy(c => c.TelID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            telList = telService.GetTelList().ToList();
                            Assert.AreEqual(0, telList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTelFields(telList, entityQueryDetailType);
                        Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        Assert.AreEqual(1, telList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTelList() Skip Take Order 2Where

        #region Tests Generated for GetTelList() 2Where
        [TestMethod]
        public void GetTelList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<Tel> telList = new List<Tel>();
                    List<Tel> telDirectQueryList = new List<Tel>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 0, 10000, "", "TelID,GT,2|TelID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        telDirectQueryList = telService.GetRead().Where(c => c.TelID > 2 && c.TelID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            telList = telService.GetTelList().ToList();
                            Assert.AreEqual(0, telList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            telList = telService.GetTelList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTelFields(telList, entityQueryDetailType);
                        Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        Assert.AreEqual(2, telList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTelList() 2Where

        #region Functions private
        private void CheckTelFields(List<Tel> telList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // Tel fields
            Assert.IsNotNull(telList[0].TelID);
            Assert.IsNotNull(telList[0].TelTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(telList[0].TelNumber));
            Assert.IsNotNull(telList[0].TelType);
            Assert.IsNotNull(telList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(telList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // TelWeb and TelReport fields should be null here
                Assert.IsNull(telList[0].TelWeb);
                Assert.IsNull(telList[0].TelReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // TelWeb fields should not be null and TelReport fields should be null here
                if (!string.IsNullOrWhiteSpace(telList[0].TelWeb.TelTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telList[0].TelWeb.TelTVText));
                }
                if (!string.IsNullOrWhiteSpace(telList[0].TelWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telList[0].TelWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(telList[0].TelWeb.TelTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telList[0].TelWeb.TelTypeText));
                }
                Assert.IsNull(telList[0].TelReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // TelWeb and TelReport fields should NOT be null here
                if (telList[0].TelWeb.TelTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telList[0].TelWeb.TelTVText));
                }
                if (telList[0].TelWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telList[0].TelWeb.LastUpdateContactTVText));
                }
                if (telList[0].TelWeb.TelTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telList[0].TelWeb.TelTypeText));
                }
                if (telList[0].TelReport.TelReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(telList[0].TelReport.TelReportTest));
                }
            }
        }
        private Tel GetFilledRandomTel(string OmitPropName)
        {
            Tel tel = new Tel();

            if (OmitPropName != "TelTVItemID") tel.TelTVItemID = 51;
            if (OmitPropName != "TelNumber") tel.TelNumber = GetRandomString("", 5);
            if (OmitPropName != "TelType") tel.TelType = (TelTypeEnum)GetRandomEnumType(typeof(TelTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tel.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tel.LastUpdateContactTVItemID = 2;

            return tel;
        }
        #endregion Functions private
    }
}
