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

                    count = telService.GetTelList().Count();

                    Assert.AreEqual(telService.GetTelList().Count(), (from c in dbTestDB.Tels select c).Take(200).Count());

                    telService.Add(tel);
                    if (tel.HasErrors)
                    {
                        Assert.AreEqual("", tel.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, telService.GetTelList().Where(c => c == tel).Any());
                    telService.Update(tel);
                    if (tel.HasErrors)
                    {
                        Assert.AreEqual("", tel.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, telService.GetTelList().Count());
                    telService.Delete(tel);
                    if (tel.HasErrors)
                    {
                        Assert.AreEqual("", tel.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, telService.GetTelList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TelTelID"), tel.ValidationResults.FirstOrDefault().ErrorMessage);

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelID = 10000000;
                    telService.Update(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Tel", "TelTelID", tel.TelID.ToString()), tel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Tel)]
                    // tel.TelTVItemID   (Int32)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelTVItemID = 0;
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TelTelTVItemID", tel.TelTVItemID.ToString()), tel.ValidationResults.FirstOrDefault().ErrorMessage);

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelTVItemID = 1;
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TelTelTVItemID", "Tel"), tel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // tel.TelNumber   (String)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("TelNumber");
                    Assert.AreEqual(false, telService.Add(tel));
                    Assert.AreEqual(1, tel.ValidationResults.Count());
                    Assert.IsTrue(tel.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TelTelNumber")).Any());
                    Assert.AreEqual(null, tel.TelNumber);
                    Assert.AreEqual(count, telService.GetTelList().Count());

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelNumber = GetRandomString("", 51);
                    Assert.AreEqual(false, telService.Add(tel));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TelTelNumber", "50"), tel.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, telService.GetTelList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tel.TelType   (TelTypeEnum)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.TelType = (TelTypeEnum)1000000;
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TelTelType"), tel.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tel.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.LastUpdateDate_UTC = new DateTime();
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TelLastUpdateDate_UTC"), tel.ValidationResults.FirstOrDefault().ErrorMessage);
                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TelLastUpdateDate_UTC", "1980"), tel.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tel.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.LastUpdateContactTVItemID = 0;
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TelLastUpdateContactTVItemID", tel.LastUpdateContactTVItemID.ToString()), tel.ValidationResults.FirstOrDefault().ErrorMessage);

                    tel = null;
                    tel = GetFilledRandomTel("");
                    tel.LastUpdateContactTVItemID = 1;
                    telService.Add(tel);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TelLastUpdateContactTVItemID", "Contact"), tel.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Tel tel = (from c in dbTestDB.Tels select c).FirstOrDefault();
                    Assert.IsNotNull(tel);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        telService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            Tel telRet = telService.GetTelWithTelID(tel.TelID);
                            CheckTelFields(new List<Tel>() { telRet });
                            Assert.AreEqual(tel.TelID, telRet.TelID);
                        }
                        else if (detail == "A")
                        {
                            Tel_A tel_ARet = telService.GetTel_AWithTelID(tel.TelID);
                            CheckTel_AFields(new List<Tel_A>() { tel_ARet });
                            Assert.AreEqual(tel.TelID, tel_ARet.TelID);
                        }
                        else if (detail == "B")
                        {
                            Tel_B tel_BRet = telService.GetTel_BWithTelID(tel.TelID);
                            CheckTel_BFields(new List<Tel_B>() { tel_BRet });
                            Assert.AreEqual(tel.TelID, tel_BRet.TelID);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    Tel tel = (from c in dbTestDB.Tels select c).FirstOrDefault();
                    Assert.IsNotNull(tel);

                    List<Tel> telDirectQueryList = new List<Tel>();
                    telDirectQueryList = (from c in dbTestDB.Tels select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        telService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Tel> telList = new List<Tel>();
                            telList = telService.GetTelList().ToList();
                            CheckTelFields(telList);
                        }
                        else if (detail == "A")
                        {
                            List<Tel_A> tel_AList = new List<Tel_A>();
                            tel_AList = telService.GetTel_AList().ToList();
                            CheckTel_AFields(tel_AList);
                            Assert.AreEqual(telDirectQueryList.Count, tel_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Tel_B> tel_BList = new List<Tel_B>();
                            tel_BList = telService.GetTel_BList().ToList();
                            CheckTel_BFields(tel_BList);
                            Assert.AreEqual(telDirectQueryList.Count, tel_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<Tel> telDirectQueryList = new List<Tel>();
                        telDirectQueryList = (from c in dbTestDB.Tels select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Tel> telList = new List<Tel>();
                            telList = telService.GetTelList().ToList();
                            CheckTelFields(telList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        }
                        else if (detail == "A")
                        {
                            List<Tel_A> tel_AList = new List<Tel_A>();
                            tel_AList = telService.GetTel_AList().ToList();
                            CheckTel_AFields(tel_AList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_AList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Tel_B> tel_BList = new List<Tel_B>();
                            tel_BList = telService.GetTel_BList().ToList();
                            CheckTel_BFields(tel_BList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_BList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 1, 1,  "TelID", "");

                        List<Tel> telDirectQueryList = new List<Tel>();
                        telDirectQueryList = (from c in dbTestDB.Tels select c).Skip(1).Take(1).OrderBy(c => c.TelID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Tel> telList = new List<Tel>();
                            telList = telService.GetTelList().ToList();
                            CheckTelFields(telList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        }
                        else if (detail == "A")
                        {
                            List<Tel_A> tel_AList = new List<Tel_A>();
                            tel_AList = telService.GetTel_AList().ToList();
                            CheckTel_AFields(tel_AList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_AList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Tel_B> tel_BList = new List<Tel_B>();
                            tel_BList = telService.GetTel_BList().ToList();
                            CheckTel_BFields(tel_BList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_BList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 1, 1, "TelID,TelTVItemID", "");

                        List<Tel> telDirectQueryList = new List<Tel>();
                        telDirectQueryList = (from c in dbTestDB.Tels select c).Skip(1).Take(1).OrderBy(c => c.TelID).ThenBy(c => c.TelTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Tel> telList = new List<Tel>();
                            telList = telService.GetTelList().ToList();
                            CheckTelFields(telList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        }
                        else if (detail == "A")
                        {
                            List<Tel_A> tel_AList = new List<Tel_A>();
                            tel_AList = telService.GetTel_AList().ToList();
                            CheckTel_AFields(tel_AList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_AList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Tel_B> tel_BList = new List<Tel_B>();
                            tel_BList = telService.GetTel_BList().ToList();
                            CheckTel_BFields(tel_BList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_BList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 0, 1, "TelID", "TelID,EQ,4", "");

                        List<Tel> telDirectQueryList = new List<Tel>();
                        telDirectQueryList = (from c in dbTestDB.Tels select c).Where(c => c.TelID == 4).Skip(0).Take(1).OrderBy(c => c.TelID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Tel> telList = new List<Tel>();
                            telList = telService.GetTelList().ToList();
                            CheckTelFields(telList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        }
                        else if (detail == "A")
                        {
                            List<Tel_A> tel_AList = new List<Tel_A>();
                            tel_AList = telService.GetTel_AList().ToList();
                            CheckTel_AFields(tel_AList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_AList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Tel_B> tel_BList = new List<Tel_B>();
                            tel_BList = telService.GetTel_BList().ToList();
                            CheckTel_BFields(tel_BList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_BList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 0, 1, "TelID", "TelID,GT,2|TelID,LT,5", "");

                        List<Tel> telDirectQueryList = new List<Tel>();
                        telDirectQueryList = (from c in dbTestDB.Tels select c).Where(c => c.TelID > 2 && c.TelID < 5).Skip(0).Take(1).OrderBy(c => c.TelID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Tel> telList = new List<Tel>();
                            telList = telService.GetTelList().ToList();
                            CheckTelFields(telList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        }
                        else if (detail == "A")
                        {
                            List<Tel_A> tel_AList = new List<Tel_A>();
                            tel_AList = telService.GetTel_AList().ToList();
                            CheckTel_AFields(tel_AList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_AList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Tel_B> tel_BList = new List<Tel_B>();
                            tel_BList = telService.GetTel_BList().ToList();
                            CheckTel_BFields(tel_BList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_BList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TelService telService = new TelService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        telService.Query = telService.FillQuery(typeof(Tel), culture.TwoLetterISOLanguageName, 0, 10000, "", "TelID,GT,2|TelID,LT,5", "");

                        List<Tel> telDirectQueryList = new List<Tel>();
                        telDirectQueryList = (from c in dbTestDB.Tels select c).Where(c => c.TelID > 2 && c.TelID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Tel> telList = new List<Tel>();
                            telList = telService.GetTelList().ToList();
                            CheckTelFields(telList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, telList[0].TelID);
                        }
                        else if (detail == "A")
                        {
                            List<Tel_A> tel_AList = new List<Tel_A>();
                            tel_AList = telService.GetTel_AList().ToList();
                            CheckTel_AFields(tel_AList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_AList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Tel_B> tel_BList = new List<Tel_B>();
                            tel_BList = telService.GetTel_BList().ToList();
                            CheckTel_BFields(tel_BList);
                            Assert.AreEqual(telDirectQueryList[0].TelID, tel_BList[0].TelID);
                            Assert.AreEqual(telDirectQueryList.Count, tel_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTelList() 2Where

        #region Functions private
        private void CheckTelFields(List<Tel> telList)
        {
            Assert.IsNotNull(telList[0].TelID);
            Assert.IsNotNull(telList[0].TelTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(telList[0].TelNumber));
            Assert.IsNotNull(telList[0].TelType);
            Assert.IsNotNull(telList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(telList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(telList[0].HasErrors);
        }
        private void CheckTel_AFields(List<Tel_A> tel_AList)
        {
            Assert.IsNotNull(tel_AList[0].TelTVItemLanguage);
            Assert.IsNotNull(tel_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tel_AList[0].TelTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tel_AList[0].TelTypeText));
            }
            Assert.IsNotNull(tel_AList[0].TelID);
            Assert.IsNotNull(tel_AList[0].TelTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tel_AList[0].TelNumber));
            Assert.IsNotNull(tel_AList[0].TelType);
            Assert.IsNotNull(tel_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tel_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tel_AList[0].HasErrors);
        }
        private void CheckTel_BFields(List<Tel_B> tel_BList)
        {
            if (!string.IsNullOrWhiteSpace(tel_BList[0].TelReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tel_BList[0].TelReportTest));
            }
            Assert.IsNotNull(tel_BList[0].TelTVItemLanguage);
            Assert.IsNotNull(tel_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tel_BList[0].TelTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tel_BList[0].TelTypeText));
            }
            Assert.IsNotNull(tel_BList[0].TelID);
            Assert.IsNotNull(tel_BList[0].TelTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tel_BList[0].TelNumber));
            Assert.IsNotNull(tel_BList[0].TelType);
            Assert.IsNotNull(tel_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tel_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tel_BList[0].HasErrors);
        }
        private Tel GetFilledRandomTel(string OmitPropName)
        {
            Tel tel = new Tel();

            if (OmitPropName != "TelTVItemID") tel.TelTVItemID = 54;
            if (OmitPropName != "TelNumber") tel.TelNumber = GetRandomString("", 5);
            if (OmitPropName != "TelType") tel.TelType = (TelTypeEnum)GetRandomEnumType(typeof(TelTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tel.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tel.LastUpdateContactTVItemID = 2;

            return tel;
        }
        #endregion Functions private
    }
}
