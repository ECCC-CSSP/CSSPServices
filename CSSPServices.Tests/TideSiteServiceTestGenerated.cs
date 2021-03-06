 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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

        #region Tests Generated CRUD
        [TestMethod]
        public void TideSite_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    Assert.AreEqual(count, (from c in dbTestDB.TideSites select c).Count());

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

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [TestMethod]
        public void TideSite_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = tideSiteService.GetTideSiteList().Count();

                    TideSite tideSite = GetFilledRandomTideSite("");

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TideSiteID"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteID = 10000000;
                    tideSiteService.Update(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", tideSite.TideSiteID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = TideSite)]
                    // tideSite.TideSiteTVItemID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteTVItemID = 0;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideSiteTVItemID", tideSite.TideSiteTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteTVItemID = 1;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TideSiteTVItemID", "TideSite"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideSite.TideSiteName   (String)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("TideSiteName");
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(1, tideSite.ValidationResults.Count());
                    Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TideSiteName")).Any());
                    Assert.AreEqual(null, tideSite.TideSiteName);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteName = GetRandomString("", 101);
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TideSiteName", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(2, MinimumLength = 2)]
                    // tideSite.Province   (String)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("Province");
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(1, tideSite.ValidationResults.Count());
                    Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Province")).Any());
                    Assert.AreEqual(null, tideSite.Province);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.Province = GetRandomString("", 1);
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "Province", "2", "2"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());
                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.Province = GetRandomString("", 3);
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "Province", "2", "2"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // tideSite.sid   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.sid = -1;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "sid", "0", "10000"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());
                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.sid = 10001;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "sid", "0", "10000"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // tideSite.Zone   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.Zone = -1;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Zone", "0", "10000"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());
                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.Zone = 10001;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Zone", "0", "10000"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tideSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateContactTVItemID = 0;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tideSite.LastUpdateContactTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateContactTVItemID = 1;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


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
        #endregion Tests Generated Properties

        #region Tests Generated for GetTideSiteWithTideSiteID(tideSite.TideSiteID)
        [TestMethod]
        public void GetTideSiteWithTideSiteID__tideSite_TideSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideSite tideSite = (from c in dbTestDB.TideSites select c).FirstOrDefault();
                    Assert.IsNotNull(tideSite);

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        tideSiteService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            TideSite tideSiteRet = tideSiteService.GetTideSiteWithTideSiteID(tideSite.TideSiteID);
                            CheckTideSiteFields(new List<TideSite>() { tideSiteRet });
                            Assert.AreEqual(tideSite.TideSiteID, tideSiteRet.TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideSite tideSite = (from c in dbTestDB.TideSites select c).FirstOrDefault();
                    Assert.IsNotNull(tideSite);

                    List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                    tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        tideSiteService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", "", extra);

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take

        #region Tests Generated for GetTideSiteList() Skip Take Asc
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 1, 1,  "TideSiteID", "", "", extra);

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).OrderBy(c => c.TideSiteID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take Asc

        #region Tests Generated for GetTideSiteList() Skip Take 2 Asc
        [TestMethod]
        public void GetTideSiteList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 1, 1, "TideSiteID,TideSiteTVItemID", "", "", extra);

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).OrderBy(c => c.TideSiteID).ThenBy(c => c.TideSiteTVItemID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take 2 Asc

        #region Tests Generated for GetTideSiteList() Skip Take Asc Where
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 0, 1, "TideSiteID", "", "TideSiteID,EQ,4", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Where(c => c.TideSiteID == 4).OrderBy(c => c.TideSiteID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take Asc Where

        #region Tests Generated for GetTideSiteList() Skip Take Asc 2 Where
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 0, 1, "TideSiteID", "", "TideSiteID,GT,2|TideSiteID,LT,5", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Where(c => c.TideSiteID > 2 && c.TideSiteID < 5).Skip(0).Take(1).OrderBy(c => c.TideSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take Asc 2 Where

        #region Tests Generated for GetTideSiteList() Skip Take Desc
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 1, 1, "", "TideSiteID", "", extra);

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).OrderByDescending(c => c.TideSiteID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take Desc

        #region Tests Generated for GetTideSiteList() Skip Take 2 Desc
        [TestMethod]
        public void GetTideSiteList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 1, 1, "", "TideSiteID,TideSiteTVItemID", "", extra);

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).OrderByDescending(c => c.TideSiteID).ThenByDescending(c => c.TideSiteTVItemID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take 2 Desc

        #region Tests Generated for GetTideSiteList() Skip Take Desc Where
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 0, 1, "TideSiteID", "", "TideSiteID,EQ,4", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Where(c => c.TideSiteID == 4).OrderByDescending(c => c.TideSiteID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take Desc Where

        #region Tests Generated for GetTideSiteList() Skip Take Desc 2 Where
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 0, 1, "", "TideSiteID", "TideSiteID,GT,2|TideSiteID,LT,5", "");

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Where(c => c.TideSiteID > 2 && c.TideSiteID < 5).OrderByDescending(c => c.TideSiteID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take Desc 2 Where

        #region Tests Generated for GetTideSiteList() 2 Where
        [TestMethod]
        public void GetTideSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        TideSiteService tideSiteService = new TideSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideSiteService.Query = tideSiteService.FillQuery(typeof(TideSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "TideSiteID,GT,2|TideSiteID,LT,5", extra);

                        List<TideSite> tideSiteDirectQueryList = new List<TideSite>();
                        tideSiteDirectQueryList = (from c in dbTestDB.TideSites select c).Where(c => c.TideSiteID > 2 && c.TideSiteID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<TideSite> tideSiteList = new List<TideSite>();
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            CheckTideSiteFields(tideSiteList);
                            Assert.AreEqual(tideSiteDirectQueryList[0].TideSiteID, tideSiteList[0].TideSiteID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() 2 Where

        #region Functions private
        private void CheckTideSiteFields(List<TideSite> tideSiteList)
        {
            Assert.IsNotNull(tideSiteList[0].TideSiteID);
            Assert.IsNotNull(tideSiteList[0].TideSiteTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteList[0].TideSiteName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteList[0].Province));
            Assert.IsNotNull(tideSiteList[0].sid);
            Assert.IsNotNull(tideSiteList[0].Zone);
            Assert.IsNotNull(tideSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tideSiteList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tideSiteList[0].HasErrors);
        }
        private TideSite GetFilledRandomTideSite(string OmitPropName)
        {
            TideSite tideSite = new TideSite();

            if (OmitPropName != "TideSiteTVItemID") tideSite.TideSiteTVItemID = 38;
            if (OmitPropName != "TideSiteName") tideSite.TideSiteName = GetRandomString("", 5);
            if (OmitPropName != "Province") tideSite.Province = GetRandomString("", 2);
            if (OmitPropName != "sid") tideSite.sid = GetRandomInt(0, 10000);
            if (OmitPropName != "Zone") tideSite.Zone = GetRandomInt(0, 10000);
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideSite.LastUpdateContactTVItemID = 2;

            return tideSite;
        }
        #endregion Functions private
    }
}
