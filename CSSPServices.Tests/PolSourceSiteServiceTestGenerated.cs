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
    public partial class PolSourceSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceSiteService polSourceSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteServiceTest() : base()
        {
            //polSourceSiteService = new PolSourceSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void PolSourceSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    PolSourceSite polSourceSite = GetFilledRandomPolSourceSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = polSourceSiteService.GetPolSourceSiteList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.PolSourceSites select c).Count());

                    polSourceSiteService.Add(polSourceSite);
                    if (polSourceSite.HasErrors)
                    {
                        Assert.AreEqual("", polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, polSourceSiteService.GetPolSourceSiteList().Where(c => c == polSourceSite).Any());
                    polSourceSiteService.Update(polSourceSite);
                    if (polSourceSite.HasErrors)
                    {
                        Assert.AreEqual("", polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, polSourceSiteService.GetPolSourceSiteList().Count());
                    polSourceSiteService.Delete(polSourceSite);
                    if (polSourceSite.HasErrors)
                    {
                        Assert.AreEqual("", polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // polSourceSite.PolSourceSiteID   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteID = 0;
                    polSourceSiteService.Update(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceSitePolSourceSiteID"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteID = 10000000;
                    polSourceSiteService.Update(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSitePolSourceSiteID", polSourceSite.PolSourceSiteID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = PolSourceSite)]
                    // polSourceSite.PolSourceSiteTVItemID   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteTVItemID = 0;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSitePolSourceSiteTVItemID", polSourceSite.PolSourceSiteTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteTVItemID = 1;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceSitePolSourceSiteTVItemID", "PolSourceSite"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(50))]
                    // polSourceSite.Temp_Locator_CanDelete   (String)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 51);
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "PolSourceSiteTemp_Locator_CanDelete", "50"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // polSourceSite.Oldsiteid   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Oldsiteid = -1;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceSiteOldsiteid", "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());
                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Oldsiteid = 1001;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceSiteOldsiteid", "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // polSourceSite.Site   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Site = -1;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceSiteSite", "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());
                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Site = 1001;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceSiteSite", "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // polSourceSite.SiteID   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.SiteID = -1;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceSiteSiteID", "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());
                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.SiteID = 1001;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceSiteSiteID", "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // polSourceSite.IsPointSource   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // polSourceSite.InactiveReason   (PolSourceInactiveReasonEnum)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.InactiveReason = (PolSourceInactiveReasonEnum)1000000;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceSiteInactiveReason"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Address)]
                    // polSourceSite.CivicAddressTVItemID   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.CivicAddressTVItemID = 0;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSiteCivicAddressTVItemID", polSourceSite.CivicAddressTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.CivicAddressTVItemID = 1;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceSiteCivicAddressTVItemID", "Address"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.LastUpdateDate_UTC = new DateTime();
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceSiteLastUpdateDate_UTC"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "PolSourceSiteLastUpdateDate_UTC", "1980"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.LastUpdateContactTVItemID = 0;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceSiteLastUpdateContactTVItemID", polSourceSite.LastUpdateContactTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.LastUpdateContactTVItemID = 1;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceSiteLastUpdateContactTVItemID", "Contact"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID)
        [TestMethod]
        public void GetPolSourceSiteWithPolSourceSiteID__polSourceSite_PolSourceSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceSite polSourceSite = (from c in dbTestDB.PolSourceSites select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceSite);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        polSourceSiteService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            PolSourceSite polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID);
                            CheckPolSourceSiteFields(new List<PolSourceSite>() { polSourceSiteRet });
                            Assert.AreEqual(polSourceSite.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            PolSourceSiteExtraA polSourceSiteExtraARet = polSourceSiteService.GetPolSourceSiteExtraAWithPolSourceSiteID(polSourceSite.PolSourceSiteID);
                            CheckPolSourceSiteExtraAFields(new List<PolSourceSiteExtraA>() { polSourceSiteExtraARet });
                            Assert.AreEqual(polSourceSite.PolSourceSiteID, polSourceSiteExtraARet.PolSourceSiteID);
                        }
                        else if (extra == "ExtraB")
                        {
                            PolSourceSiteExtraB polSourceSiteExtraBRet = polSourceSiteService.GetPolSourceSiteExtraBWithPolSourceSiteID(polSourceSite.PolSourceSiteID);
                            CheckPolSourceSiteExtraBFields(new List<PolSourceSiteExtraB>() { polSourceSiteExtraBRet });
                            Assert.AreEqual(polSourceSite.PolSourceSiteID, polSourceSiteExtraBRet.PolSourceSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID)

        #region Tests Generated for GetPolSourceSiteList()
        [TestMethod]
        public void GetPolSourceSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceSite polSourceSite = (from c in dbTestDB.PolSourceSites select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceSite);

                    List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                    polSourceSiteDirectQueryList = (from c in dbTestDB.PolSourceSites select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        polSourceSiteService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            CheckPolSourceSiteFields(polSourceSiteList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<PolSourceSiteExtraA> polSourceSiteExtraAList = new List<PolSourceSiteExtraA>();
                            polSourceSiteExtraAList = polSourceSiteService.GetPolSourceSiteExtraAList().ToList();
                            CheckPolSourceSiteExtraAFields(polSourceSiteExtraAList);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<PolSourceSiteExtraB> polSourceSiteExtraBList = new List<PolSourceSiteExtraB>();
                            polSourceSiteExtraBList = polSourceSiteService.GetPolSourceSiteExtraBList().ToList();
                            CheckPolSourceSiteExtraBFields(polSourceSiteExtraBList);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceSiteList()

        #region Tests Generated for GetPolSourceSiteList() Skip Take
        [TestMethod]
        public void GetPolSourceSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                        polSourceSiteDirectQueryList = (from c in dbTestDB.PolSourceSites select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            CheckPolSourceSiteFields(polSourceSiteList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<PolSourceSiteExtraA> polSourceSiteExtraAList = new List<PolSourceSiteExtraA>();
                            polSourceSiteExtraAList = polSourceSiteService.GetPolSourceSiteExtraAList().ToList();
                            CheckPolSourceSiteExtraAFields(polSourceSiteExtraAList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraAList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<PolSourceSiteExtraB> polSourceSiteExtraBList = new List<PolSourceSiteExtraB>();
                            polSourceSiteExtraBList = polSourceSiteService.GetPolSourceSiteExtraBList().ToList();
                            CheckPolSourceSiteExtraBFields(polSourceSiteExtraBList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraBList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceSiteList() Skip Take

        #region Tests Generated for GetPolSourceSiteList() Skip Take Order
        [TestMethod]
        public void GetPolSourceSiteList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceSiteID", "");

                        List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                        polSourceSiteDirectQueryList = (from c in dbTestDB.PolSourceSites select c).Skip(1).Take(1).OrderBy(c => c.PolSourceSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            CheckPolSourceSiteFields(polSourceSiteList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<PolSourceSiteExtraA> polSourceSiteExtraAList = new List<PolSourceSiteExtraA>();
                            polSourceSiteExtraAList = polSourceSiteService.GetPolSourceSiteExtraAList().ToList();
                            CheckPolSourceSiteExtraAFields(polSourceSiteExtraAList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraAList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<PolSourceSiteExtraB> polSourceSiteExtraBList = new List<PolSourceSiteExtraB>();
                            polSourceSiteExtraBList = polSourceSiteService.GetPolSourceSiteExtraBList().ToList();
                            CheckPolSourceSiteExtraBFields(polSourceSiteExtraBList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraBList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceSiteList() Skip Take Order

        #region Tests Generated for GetPolSourceSiteList() Skip Take 2Order
        [TestMethod]
        public void GetPolSourceSiteList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceSiteID,PolSourceSiteTVItemID", "");

                        List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                        polSourceSiteDirectQueryList = (from c in dbTestDB.PolSourceSites select c).Skip(1).Take(1).OrderBy(c => c.PolSourceSiteID).ThenBy(c => c.PolSourceSiteTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            CheckPolSourceSiteFields(polSourceSiteList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<PolSourceSiteExtraA> polSourceSiteExtraAList = new List<PolSourceSiteExtraA>();
                            polSourceSiteExtraAList = polSourceSiteService.GetPolSourceSiteExtraAList().ToList();
                            CheckPolSourceSiteExtraAFields(polSourceSiteExtraAList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraAList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<PolSourceSiteExtraB> polSourceSiteExtraBList = new List<PolSourceSiteExtraB>();
                            polSourceSiteExtraBList = polSourceSiteService.GetPolSourceSiteExtraBList().ToList();
                            CheckPolSourceSiteExtraBFields(polSourceSiteExtraBList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraBList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceSiteList() Skip Take 2Order

        #region Tests Generated for GetPolSourceSiteList() Skip Take Order Where
        [TestMethod]
        public void GetPolSourceSiteList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceSiteID", "PolSourceSiteID,EQ,4", "");

                        List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                        polSourceSiteDirectQueryList = (from c in dbTestDB.PolSourceSites select c).Where(c => c.PolSourceSiteID == 4).Skip(0).Take(1).OrderBy(c => c.PolSourceSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            CheckPolSourceSiteFields(polSourceSiteList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<PolSourceSiteExtraA> polSourceSiteExtraAList = new List<PolSourceSiteExtraA>();
                            polSourceSiteExtraAList = polSourceSiteService.GetPolSourceSiteExtraAList().ToList();
                            CheckPolSourceSiteExtraAFields(polSourceSiteExtraAList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraAList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<PolSourceSiteExtraB> polSourceSiteExtraBList = new List<PolSourceSiteExtraB>();
                            polSourceSiteExtraBList = polSourceSiteService.GetPolSourceSiteExtraBList().ToList();
                            CheckPolSourceSiteExtraBFields(polSourceSiteExtraBList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraBList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceSiteList() Skip Take Order Where

        #region Tests Generated for GetPolSourceSiteList() Skip Take Order 2Where
        [TestMethod]
        public void GetPolSourceSiteList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceSiteID", "PolSourceSiteID,GT,2|PolSourceSiteID,LT,5", "");

                        List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                        polSourceSiteDirectQueryList = (from c in dbTestDB.PolSourceSites select c).Where(c => c.PolSourceSiteID > 2 && c.PolSourceSiteID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            CheckPolSourceSiteFields(polSourceSiteList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<PolSourceSiteExtraA> polSourceSiteExtraAList = new List<PolSourceSiteExtraA>();
                            polSourceSiteExtraAList = polSourceSiteService.GetPolSourceSiteExtraAList().ToList();
                            CheckPolSourceSiteExtraAFields(polSourceSiteExtraAList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraAList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<PolSourceSiteExtraB> polSourceSiteExtraBList = new List<PolSourceSiteExtraB>();
                            polSourceSiteExtraBList = polSourceSiteService.GetPolSourceSiteExtraBList().ToList();
                            CheckPolSourceSiteExtraBFields(polSourceSiteExtraBList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraBList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceSiteList() Skip Take Order 2Where

        #region Tests Generated for GetPolSourceSiteList() 2Where
        [TestMethod]
        public void GetPolSourceSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "PolSourceSiteID,GT,2|PolSourceSiteID,LT,5", "");

                        List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                        polSourceSiteDirectQueryList = (from c in dbTestDB.PolSourceSites select c).Where(c => c.PolSourceSiteID > 2 && c.PolSourceSiteID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            CheckPolSourceSiteFields(polSourceSiteList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<PolSourceSiteExtraA> polSourceSiteExtraAList = new List<PolSourceSiteExtraA>();
                            polSourceSiteExtraAList = polSourceSiteService.GetPolSourceSiteExtraAList().ToList();
                            CheckPolSourceSiteExtraAFields(polSourceSiteExtraAList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraAList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<PolSourceSiteExtraB> polSourceSiteExtraBList = new List<PolSourceSiteExtraB>();
                            polSourceSiteExtraBList = polSourceSiteService.GetPolSourceSiteExtraBList().ToList();
                            CheckPolSourceSiteExtraBFields(polSourceSiteExtraBList);
                            Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteExtraBList[0].PolSourceSiteID);
                            Assert.AreEqual(polSourceSiteDirectQueryList.Count, polSourceSiteExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceSiteList() 2Where

        #region Functions private
        private void CheckPolSourceSiteFields(List<PolSourceSite> polSourceSiteList)
        {
            Assert.IsNotNull(polSourceSiteList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceSiteList[0].PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteList[0].Temp_Locator_CanDelete))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteList[0].Temp_Locator_CanDelete));
            }
            if (polSourceSiteList[0].Oldsiteid != null)
            {
                Assert.IsNotNull(polSourceSiteList[0].Oldsiteid);
            }
            if (polSourceSiteList[0].Site != null)
            {
                Assert.IsNotNull(polSourceSiteList[0].Site);
            }
            if (polSourceSiteList[0].SiteID != null)
            {
                Assert.IsNotNull(polSourceSiteList[0].SiteID);
            }
            Assert.IsNotNull(polSourceSiteList[0].IsPointSource);
            if (polSourceSiteList[0].InactiveReason != null)
            {
                Assert.IsNotNull(polSourceSiteList[0].InactiveReason);
            }
            if (polSourceSiteList[0].CivicAddressTVItemID != null)
            {
                Assert.IsNotNull(polSourceSiteList[0].CivicAddressTVItemID);
            }
            Assert.IsNotNull(polSourceSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceSiteList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceSiteList[0].HasErrors);
        }
        private void CheckPolSourceSiteExtraAFields(List<PolSourceSiteExtraA> polSourceSiteExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteExtraAList[0].PolSourceSiteText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteExtraAList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(polSourceSiteExtraAList[0].InactiveReasonText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteExtraAList[0].InactiveReasonText));
            }
            Assert.IsNotNull(polSourceSiteExtraAList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceSiteExtraAList[0].PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteExtraAList[0].Temp_Locator_CanDelete))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteExtraAList[0].Temp_Locator_CanDelete));
            }
            if (polSourceSiteExtraAList[0].Oldsiteid != null)
            {
                Assert.IsNotNull(polSourceSiteExtraAList[0].Oldsiteid);
            }
            if (polSourceSiteExtraAList[0].Site != null)
            {
                Assert.IsNotNull(polSourceSiteExtraAList[0].Site);
            }
            if (polSourceSiteExtraAList[0].SiteID != null)
            {
                Assert.IsNotNull(polSourceSiteExtraAList[0].SiteID);
            }
            Assert.IsNotNull(polSourceSiteExtraAList[0].IsPointSource);
            if (polSourceSiteExtraAList[0].InactiveReason != null)
            {
                Assert.IsNotNull(polSourceSiteExtraAList[0].InactiveReason);
            }
            if (polSourceSiteExtraAList[0].CivicAddressTVItemID != null)
            {
                Assert.IsNotNull(polSourceSiteExtraAList[0].CivicAddressTVItemID);
            }
            Assert.IsNotNull(polSourceSiteExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceSiteExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceSiteExtraAList[0].HasErrors);
        }
        private void CheckPolSourceSiteExtraBFields(List<PolSourceSiteExtraB> polSourceSiteExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(polSourceSiteExtraBList[0].PolSourceSiteReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteExtraBList[0].PolSourceSiteReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteExtraBList[0].PolSourceSiteText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteExtraBList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(polSourceSiteExtraBList[0].InactiveReasonText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteExtraBList[0].InactiveReasonText));
            }
            Assert.IsNotNull(polSourceSiteExtraBList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceSiteExtraBList[0].PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteExtraBList[0].Temp_Locator_CanDelete))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteExtraBList[0].Temp_Locator_CanDelete));
            }
            if (polSourceSiteExtraBList[0].Oldsiteid != null)
            {
                Assert.IsNotNull(polSourceSiteExtraBList[0].Oldsiteid);
            }
            if (polSourceSiteExtraBList[0].Site != null)
            {
                Assert.IsNotNull(polSourceSiteExtraBList[0].Site);
            }
            if (polSourceSiteExtraBList[0].SiteID != null)
            {
                Assert.IsNotNull(polSourceSiteExtraBList[0].SiteID);
            }
            Assert.IsNotNull(polSourceSiteExtraBList[0].IsPointSource);
            if (polSourceSiteExtraBList[0].InactiveReason != null)
            {
                Assert.IsNotNull(polSourceSiteExtraBList[0].InactiveReason);
            }
            if (polSourceSiteExtraBList[0].CivicAddressTVItemID != null)
            {
                Assert.IsNotNull(polSourceSiteExtraBList[0].CivicAddressTVItemID);
            }
            Assert.IsNotNull(polSourceSiteExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceSiteExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceSiteExtraBList[0].HasErrors);
        }
        private PolSourceSite GetFilledRandomPolSourceSite(string OmitPropName)
        {
            PolSourceSite polSourceSite = new PolSourceSite();

            if (OmitPropName != "PolSourceSiteTVItemID") polSourceSite.PolSourceSiteTVItemID = 46;
            if (OmitPropName != "Temp_Locator_CanDelete") polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 5);
            if (OmitPropName != "Oldsiteid") polSourceSite.Oldsiteid = GetRandomInt(0, 1000);
            if (OmitPropName != "Site") polSourceSite.Site = GetRandomInt(0, 1000);
            if (OmitPropName != "SiteID") polSourceSite.SiteID = GetRandomInt(0, 1000);
            if (OmitPropName != "IsPointSource") polSourceSite.IsPointSource = true;
            if (OmitPropName != "InactiveReason") polSourceSite.InactiveReason = (PolSourceInactiveReasonEnum)GetRandomEnumType(typeof(PolSourceInactiveReasonEnum));
            if (OmitPropName != "CivicAddressTVItemID") polSourceSite.CivicAddressTVItemID = 45;
            if (OmitPropName != "LastUpdateDate_UTC") polSourceSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceSite.LastUpdateContactTVItemID = 2;

            return polSourceSite;
        }
        #endregion Functions private
    }
}
