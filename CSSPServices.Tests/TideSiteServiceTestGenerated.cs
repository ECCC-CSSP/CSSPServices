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
    public partial class TideSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TideSiteService tideSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteServiceTest() : base()
        {
            //tideSiteService = new TideSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TideSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TideSite tideSite = GetFilledRandomTideSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tideSiteService.GetTideSiteList().Count();

                    Assert.AreEqual(tideSiteService.GetTideSiteList().Count(), (from c in dbTestDB.TideSites select c).Take(200).Count());

                    tideSiteService.Add(tideSite);
                    if (tideSite.HasErrors)
                    {
                        Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tideSiteService.GetTideSiteList().Where(c => c == tideSite).Any());
                    tideSiteService.Update(tideSite);
                    if (tideSite.HasErrors)
                    {
                        Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tideSiteService.GetTideSiteList().Count());
                    tideSiteService.Delete(tideSite);
                    if (tideSite.HasErrors)
                    {
                        Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tideSite.TideSiteID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteID = 0;
                    tideSiteService.Update(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TideSiteTideSiteID"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteID = 10000000;
                    tideSiteService.Update(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteTideSiteID", tideSite.TideSiteID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = TideSite)]
                    // tideSite.TideSiteTVItemID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteTVItemID = 0;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideSiteTideSiteTVItemID", tideSite.TideSiteTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteTVItemID = 1;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TideSiteTideSiteTVItemID", "TideSite"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideSite.WebTideModel   (String)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("WebTideModel");
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(1, tideSite.ValidationResults.Count());
                    Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TideSiteWebTideModel")).Any());
                    Assert.AreEqual(null, tideSite.WebTideModel);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.WebTideModel = GetRandomString("", 101);
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TideSiteWebTideModel", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-100, 100)]
                    // tideSite.WebTideDatum_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WebTideDatum_m]

                    //Error: Type not implemented [WebTideDatum_m]

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.WebTideDatum_m = -101.0D;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideSiteWebTideDatum_m", "-100", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());
                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.WebTideDatum_m = 101.0D;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideSiteWebTideDatum_m", "-100", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateDate_UTC = new DateTime();
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TideSiteLastUpdateDate_UTC"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TideSiteLastUpdateDate_UTC", "1980"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tideSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateContactTVItemID = 0;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideSiteLastUpdateContactTVItemID", tideSite.LastUpdateContactTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateContactTVItemID = 1;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TideSiteLastUpdateContactTVItemID", "Contact"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTideSiteWithTideSiteID(tideSite.TideSiteID)
        [TestMethod]
        public void GetTideSiteWithTideSiteID__tideSite_TideSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideSite tideSite = (from c in dbTestDB.TideSites select c).FirstOrDefault();
                    Assert.IsNotNull(tideSite);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tideSiteService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            TideSite tideSiteRet = tideSiteService.GetTideSiteWithTideSiteID(tideSite.TideSiteID);
                            CheckTideSiteFields(new List<TideSite>() { tideSiteRet });
                            Assert.AreEqual(tideSite.TideSiteID, tideSiteRet.TideSiteID);
                        }
                        else if (detail == "A")
                        {
                            TideSite_A tideSite_ARet = tideSiteService.GetTideSite_AWithTideSiteID(tideSite.TideSiteID);
                            CheckTideSite_AFields(new List<TideSite_A>() { tideSite_ARet });
                            Assert.AreEqual(tideSite.TideSiteID, tideSite_ARet.TideSiteID);
                        }
                        else if (detail == "B")
                        {
                            TideSite_B tideSite_BRet = tideSiteService.GetTideSite_BWithTideSiteID(tideSite.TideSiteID);
                            CheckTideSite_BFields(new List<TideSite_B>() { tideSite_BRet });
                            Assert.AreEqual(tideSite.TideSiteID, tideSite_BRet.TideSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteWithTideSiteID(tideSite.TideSiteID)

        #region Tests Generated for GetTideSiteList()
        [TestMethod]
        public void GetTideSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideSite tideSite = (from c in dbTestDB.TideSites select c).FirstOrDefault();
                    Assert.IsNotNull(tideSite);

                    List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                    tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tideSiteService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                        }
                        else if (detail == "A")
                        {
                            List<TideSite_A> tideSite_AList = new List<TideSite_A>();
                            tideSite_AList = tideSiteService.GetTideSite_AList().ToList();
                            CheckTideSite_AFields(tideSite_AList);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TideSite_B> tideSite_BList = new List<TideSite_B>();
                            tideSite_BList = tideSiteService.GetTideSite_BList().ToList();
                            CheckTideSite_BFields(tideSite_BList);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList()

        #region Tests Generated for GetTideSiteList() Skip Take
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<TideSite_A> tideSite_AList = new List<TideSite_A>();
                            tideSite_AList = tideSiteService.GetTideSite_AList().ToList();
                            CheckTideSite_AFields(tideSite_AList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_AList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TideSite_B> tideSite_BList = new List<TideSite_B>();
                            tideSite_BList = tideSiteService.GetTideSite_BList().ToList();
                            CheckTideSite_BFields(tideSite_BList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_BList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take

        #region Tests Generated for GetTideSiteList() Skip Take Order
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 1, 1,  "TideSiteID", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Skip(1).Take(1).OrderBy(c => c.TideSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<TideSite_A> tideSite_AList = new List<TideSite_A>();
                            tideSite_AList = tideSiteService.GetTideSite_AList().ToList();
                            CheckTideSite_AFields(tideSite_AList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_AList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TideSite_B> tideSite_BList = new List<TideSite_B>();
                            tideSite_BList = tideSiteService.GetTideSite_BList().ToList();
                            CheckTideSite_BFields(tideSite_BList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_BList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take Order

        #region Tests Generated for GetTideSiteList() Skip Take 2Order
        [TestMethod]
        public void GetTideSiteList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 1, 1, "TideSiteID,TideSiteTVItemID", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Skip(1).Take(1).OrderBy(c => c.TideSiteID).ThenBy(c => c.TideSiteTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<TideSite_A> tideSite_AList = new List<TideSite_A>();
                            tideSite_AList = tideSiteService.GetTideSite_AList().ToList();
                            CheckTideSite_AFields(tideSite_AList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_AList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TideSite_B> tideSite_BList = new List<TideSite_B>();
                            tideSite_BList = tideSiteService.GetTideSite_BList().ToList();
                            CheckTideSite_BFields(tideSite_BList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_BList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take 2Order

        #region Tests Generated for GetTideSiteList() Skip Take Order Where
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 0, 1, "TideSiteID", "TideSiteID,EQ,4", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Where(c => c.TideSiteID == 4).Skip(0).Take(1).OrderBy(c => c.TideSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<TideSite_A> tideSite_AList = new List<TideSite_A>();
                            tideSite_AList = tideSiteService.GetTideSite_AList().ToList();
                            CheckTideSite_AFields(tideSite_AList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_AList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TideSite_B> tideSite_BList = new List<TideSite_B>();
                            tideSite_BList = tideSiteService.GetTideSite_BList().ToList();
                            CheckTideSite_BFields(tideSite_BList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_BList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take Order Where

        #region Tests Generated for GetTideSiteList() Skip Take Order 2Where
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 0, 1, "TideSiteID", "TideSiteID,GT,2|TideSiteID,LT,5", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Where(c => c.TideSiteID > 2 && c.TideSiteID < 5).Skip(0).Take(1).OrderBy(c => c.TideSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<TideSite_A> tideSite_AList = new List<TideSite_A>();
                            tideSite_AList = tideSiteService.GetTideSite_AList().ToList();
                            CheckTideSite_AFields(tideSite_AList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_AList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TideSite_B> tideSite_BList = new List<TideSite_B>();
                            tideSite_BList = tideSiteService.GetTideSite_BList().ToList();
                            CheckTideSite_BFields(tideSite_BList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_BList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take Order 2Where

        #region Tests Generated for GetTideSiteList() 2Where
        [TestMethod]
        public void GetTideSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "TideSiteID,GT,2|TideSiteID,LT,5", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Where(c => c.TideSiteID > 2 && c.TideSiteID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else if (detail == "A")
                        {
                            List<TideSite_A> tideSite_AList = new List<TideSite_A>();
                            tideSite_AList = tideSiteService.GetTideSite_AList().ToList();
                            CheckTideSite_AFields(tideSite_AList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_AList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TideSite_B> tideSite_BList = new List<TideSite_B>();
                            tideSite_BList = tideSiteService.GetTideSite_BList().ToList();
                            CheckTideSite_BFields(tideSite_BList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSite_BList[0].TideSiteID);
                            Assert.AreEqual(tideSiteDirectQueryList.Count, tideSite_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() 2Where

        #region Functions private
        private void CheckTideSiteFields(List<TideSite> tideSiteList)
        {
            Assert.IsNotNull(tideSiteList[0].TideSiteID);
            Assert.IsNotNull(tideSiteList[0].TideSiteTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteList[0].WebTideModel));
            Assert.IsNotNull(tideSiteList[0].WebTideDatum_m);
            Assert.IsNotNull(tideSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tideSiteList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tideSiteList[0].HasErrors);
        }
        private void CheckTideSite_AFields(List<TideSite_A> tideSite_AList)
        {
            Assert.IsNotNull(tideSite_AList[0].TideSiteTVItemLanguage);
            Assert.IsNotNull(tideSite_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(tideSite_AList[0].TideSiteID);
            Assert.IsNotNull(tideSite_AList[0].TideSiteTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideSite_AList[0].WebTideModel));
            Assert.IsNotNull(tideSite_AList[0].WebTideDatum_m);
            Assert.IsNotNull(tideSite_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tideSite_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tideSite_AList[0].HasErrors);
        }
        private void CheckTideSite_BFields(List<TideSite_B> tideSite_BList)
        {
            if (!string.IsNullOrWhiteSpace(tideSite_BList[0].TideSiteReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSite_BList[0].TideSiteReportTest));
            }
            Assert.IsNotNull(tideSite_BList[0].TideSiteTVItemLanguage);
            Assert.IsNotNull(tideSite_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(tideSite_BList[0].TideSiteID);
            Assert.IsNotNull(tideSite_BList[0].TideSiteTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideSite_BList[0].WebTideModel));
            Assert.IsNotNull(tideSite_BList[0].WebTideDatum_m);
            Assert.IsNotNull(tideSite_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tideSite_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tideSite_BList[0].HasErrors);
        }
        private TideSite GetFilledRandomTideSite(string OmitPropName)
        {
            TideSite tideSite = new TideSite();

            if (OmitPropName != "TideSiteTVItemID") tideSite.TideSiteTVItemID = 37;
            if (OmitPropName != "WebTideModel") tideSite.WebTideModel = GetRandomString("", 5);
            if (OmitPropName != "WebTideDatum_m") tideSite.WebTideDatum_m = GetRandomDouble(-100.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideSite.LastUpdateContactTVItemID = 2;

            return tideSite;
        }
        #endregion Functions private
    }
}
