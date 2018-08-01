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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = polSourceSiteService.GetRead().Count();

                    Assert.AreEqual(polSourceSiteService.GetRead().Count(), polSourceSiteService.GetEdit().Count());

                    polSourceSiteService.Add(polSourceSite);
                    if (polSourceSite.HasErrors)
                    {
                        Assert.AreEqual("", polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, polSourceSiteService.GetRead().Where(c => c == polSourceSite).Any());
                    polSourceSiteService.Update(polSourceSite);
                    if (polSourceSite.HasErrors)
                    {
                        Assert.AreEqual("", polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, polSourceSiteService.GetRead().Count());
                    polSourceSiteService.Delete(polSourceSite);
                    if (polSourceSite.HasErrors)
                    {
                        Assert.AreEqual("", polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceSitePolSourceSiteID), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteID = 10000000;
                    polSourceSiteService.Update(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceSite, CSSPModelsRes.PolSourceSitePolSourceSiteID, polSourceSite.PolSourceSiteID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = PolSourceSite)]
                    // polSourceSite.PolSourceSiteTVItemID   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteTVItemID = 0;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceSitePolSourceSiteTVItemID, polSourceSite.PolSourceSiteTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteTVItemID = 1;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceSitePolSourceSiteTVItemID, "PolSourceSite"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(50))]
                    // polSourceSite.Temp_Locator_CanDelete   (String)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 51);
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.PolSourceSiteTemp_Locator_CanDelete, "50"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // polSourceSite.Oldsiteid   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Oldsiteid = -1;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceSiteOldsiteid, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Oldsiteid = 1001;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceSiteOldsiteid, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // polSourceSite.Site   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Site = -1;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceSiteSite, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.Site = 1001;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceSiteSite, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 1000)]
                    // polSourceSite.SiteID   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.SiteID = -1;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceSiteSiteID, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.SiteID = 1001;
                    Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceSiteSiteID, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceSiteInactiveReason), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Address)]
                    // polSourceSite.CivicAddressTVItemID   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.CivicAddressTVItemID = 0;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceSiteCivicAddressTVItemID, polSourceSite.CivicAddressTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.CivicAddressTVItemID = 1;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceSiteCivicAddressTVItemID, "Address"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // polSourceSite.PolSourceSiteWeb   (PolSourceSiteWeb)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteWeb = null;
                    Assert.IsNull(polSourceSite.PolSourceSiteWeb);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteWeb = new PolSourceSiteWeb();
                    Assert.IsNotNull(polSourceSite.PolSourceSiteWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // polSourceSite.PolSourceSiteReport   (PolSourceSiteReport)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteReport = null;
                    Assert.IsNull(polSourceSite.PolSourceSiteReport);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.PolSourceSiteReport = new PolSourceSiteReport();
                    Assert.IsNotNull(polSourceSite.PolSourceSiteReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.LastUpdateDate_UTC = new DateTime();
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceSiteLastUpdateDate_UTC), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.PolSourceSiteLastUpdateDate_UTC, "1980"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.LastUpdateContactTVItemID = 0;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceSiteLastUpdateContactTVItemID, polSourceSite.LastUpdateContactTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceSite = null;
                    polSourceSite = GetFilledRandomPolSourceSite("");
                    polSourceSite.LastUpdateContactTVItemID = 1;
                    polSourceSiteService.Add(polSourceSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceSiteLastUpdateContactTVItemID, "Contact"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceSite polSourceSite = (from c in polSourceSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceSite);

                    PolSourceSite polSourceSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        polSourceSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID);
                            Assert.IsNull(polSourceSiteRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceSiteFields(new List<PolSourceSite>() { polSourceSiteRet }, entityQueryDetailType);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceSite polSourceSite = (from c in polSourceSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceSite);

                    List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        polSourceSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            Assert.AreEqual(0, polSourceSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceSiteFields(polSourceSiteList, entityQueryDetailType);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                    List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceSiteDirectQueryList = polSourceSiteService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            Assert.AreEqual(0, polSourceSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceSiteFields(polSourceSiteList, entityQueryDetailType);
                        Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        Assert.AreEqual(1, polSourceSiteList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                    List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceSiteDirectQueryList = polSourceSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.PolSourceSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            Assert.AreEqual(0, polSourceSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceSiteFields(polSourceSiteList, entityQueryDetailType);
                        Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        Assert.AreEqual(1, polSourceSiteList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                    List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceSiteID,PolSourceSiteTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceSiteDirectQueryList = polSourceSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.PolSourceSiteID).ThenBy(c => c.PolSourceSiteTVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            Assert.AreEqual(0, polSourceSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceSiteFields(polSourceSiteList, entityQueryDetailType);
                        Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        Assert.AreEqual(1, polSourceSiteList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                    List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceSiteID", "PolSourceSiteID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceSiteDirectQueryList = polSourceSiteService.GetRead().Where(c => c.PolSourceSiteID == 4).Skip(0).Take(1).OrderBy(c => c.PolSourceSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            Assert.AreEqual(0, polSourceSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceSiteFields(polSourceSiteList, entityQueryDetailType);
                        Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        Assert.AreEqual(1, polSourceSiteList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                    List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceSiteID", "PolSourceSiteID,GT,2|PolSourceSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceSiteDirectQueryList = polSourceSiteService.GetRead().Where(c => c.PolSourceSiteID > 2 && c.PolSourceSiteID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            Assert.AreEqual(0, polSourceSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceSiteFields(polSourceSiteList, entityQueryDetailType);
                        Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        Assert.AreEqual(1, polSourceSiteList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceSite> polSourceSiteList = new List<PolSourceSite>();
                    List<PolSourceSite> polSourceSiteDirectQueryList = new List<PolSourceSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceSiteService polSourceSiteService = new PolSourceSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceSiteService.Query = polSourceSiteService.FillQuery(typeof(PolSourceSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "PolSourceSiteID,GT,2|PolSourceSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceSiteDirectQueryList = polSourceSiteService.GetRead().Where(c => c.PolSourceSiteID > 2 && c.PolSourceSiteID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                            Assert.AreEqual(0, polSourceSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceSiteList = polSourceSiteService.GetPolSourceSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceSiteFields(polSourceSiteList, entityQueryDetailType);
                        Assert.AreEqual(polSourceSiteDirectQueryList[0].PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);
                        Assert.AreEqual(2, polSourceSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceSiteList() 2Where

        #region Functions private
        private void CheckPolSourceSiteFields(List<PolSourceSite> polSourceSiteList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // PolSourceSite fields
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

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // PolSourceSiteWeb and PolSourceSiteReport fields should be null here
                Assert.IsNull(polSourceSiteList[0].PolSourceSiteWeb);
                Assert.IsNull(polSourceSiteList[0].PolSourceSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // PolSourceSiteWeb fields should not be null and PolSourceSiteReport fields should be null here
                if (!string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteWeb.PolSourceSiteTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteWeb.PolSourceSiteTVText));
                }
                if (!string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteWeb.InactiveReasonText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteWeb.InactiveReasonText));
                }
                Assert.IsNull(polSourceSiteList[0].PolSourceSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // PolSourceSiteWeb and PolSourceSiteReport fields should NOT be null here
                if (polSourceSiteList[0].PolSourceSiteWeb.PolSourceSiteTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteWeb.PolSourceSiteTVText));
                }
                if (polSourceSiteList[0].PolSourceSiteWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteWeb.LastUpdateContactTVText));
                }
                if (polSourceSiteList[0].PolSourceSiteWeb.InactiveReasonText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteWeb.InactiveReasonText));
                }
                if (polSourceSiteList[0].PolSourceSiteReport.PolSourceSiteReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteList[0].PolSourceSiteReport.PolSourceSiteReportTest));
                }
            }
        }
        private PolSourceSite GetFilledRandomPolSourceSite(string OmitPropName)
        {
            PolSourceSite polSourceSite = new PolSourceSite();

            if (OmitPropName != "PolSourceSiteTVItemID") polSourceSite.PolSourceSiteTVItemID = 43;
            if (OmitPropName != "Temp_Locator_CanDelete") polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 5);
            if (OmitPropName != "Oldsiteid") polSourceSite.Oldsiteid = GetRandomInt(0, 1000);
            if (OmitPropName != "Site") polSourceSite.Site = GetRandomInt(0, 1000);
            if (OmitPropName != "SiteID") polSourceSite.SiteID = GetRandomInt(0, 1000);
            if (OmitPropName != "IsPointSource") polSourceSite.IsPointSource = true;
            if (OmitPropName != "InactiveReason") polSourceSite.InactiveReason = (PolSourceInactiveReasonEnum)GetRandomEnumType(typeof(PolSourceInactiveReasonEnum));
            if (OmitPropName != "CivicAddressTVItemID") polSourceSite.CivicAddressTVItemID = 42;
            if (OmitPropName != "LastUpdateDate_UTC") polSourceSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceSite.LastUpdateContactTVItemID = 2;

            return polSourceSite;
        }
        #endregion Functions private
    }
}
