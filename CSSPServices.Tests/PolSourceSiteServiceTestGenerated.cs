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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceSite GetFilledRandomPolSourceSite(string OmitPropName)
        {
            PolSourceSite polSourceSite = new PolSourceSite();

            // Need to implement (no items found, would need to add at least one in the TestDB) [PolSourceSite PolSourceSiteTVItemID TVItem TVItemID]
            if (OmitPropName != "Temp_Locator_CanDelete") polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 5);
            if (OmitPropName != "Oldsiteid") polSourceSite.Oldsiteid = GetRandomInt(0, 1000);
            if (OmitPropName != "Site") polSourceSite.Site = GetRandomInt(0, 1000);
            if (OmitPropName != "SiteID") polSourceSite.SiteID = GetRandomInt(0, 1000);
            if (OmitPropName != "IsPointSource") polSourceSite.IsPointSource = true;
            if (OmitPropName != "InactiveReason") polSourceSite.InactiveReason = (PolSourceInactiveReasonEnum)GetRandomEnumType(typeof(PolSourceInactiveReasonEnum));
            // Need to implement (no items found, would need to add at least one in the TestDB) [PolSourceSite CivicAddressTVItemID TVItem TVItemID]
            //Error: property [PolSourceSiteWeb] and type [PolSourceSite] is  not implemented
            //Error: property [PolSourceSiteReport] and type [PolSourceSite] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") polSourceSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceSite.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") polSourceSite.HasErrors = true;

            return polSourceSite;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void PolSourceSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, dbTestDB, ContactID);

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

                    //Error: Type not implemented [PolSourceSiteWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // polSourceSite.PolSourceSiteReport   (PolSourceSiteReport)
                    // -----------------------------------

                    //Error: Type not implemented [PolSourceSiteReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


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


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void PolSourceSite_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, dbTestDB, ContactID);
                    PolSourceSite polSourceSite = (from c in polSourceSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceSite);

                    PolSourceSite polSourceSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(polSourceSiteRet.PolSourceSiteID);
                        Assert.IsNotNull(polSourceSiteRet.PolSourceSiteTVItemID);
                        if (polSourceSiteRet.Temp_Locator_CanDelete != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceSiteRet.Temp_Locator_CanDelete));
                        }
                        if (polSourceSiteRet.Oldsiteid != null)
                        {
                            Assert.IsNotNull(polSourceSiteRet.Oldsiteid);
                        }
                        if (polSourceSiteRet.Site != null)
                        {
                            Assert.IsNotNull(polSourceSiteRet.Site);
                        }
                        if (polSourceSiteRet.SiteID != null)
                        {
                            Assert.IsNotNull(polSourceSiteRet.SiteID);
                        }
                        Assert.IsNotNull(polSourceSiteRet.IsPointSource);
                        if (polSourceSiteRet.InactiveReason != null)
                        {
                            Assert.IsNotNull(polSourceSiteRet.InactiveReason);
                        }
                        if (polSourceSiteRet.CivicAddressTVItemID != null)
                        {
                            Assert.IsNotNull(polSourceSiteRet.CivicAddressTVItemID);
                        }
                        Assert.IsNotNull(polSourceSiteRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(polSourceSiteRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (polSourceSiteRet.PolSourceSiteWeb != null)
                            {
                                Assert.IsNull(polSourceSiteRet.PolSourceSiteWeb);
                            }
                            if (polSourceSiteRet.PolSourceSiteReport != null)
                            {
                                Assert.IsNull(polSourceSiteRet.PolSourceSiteReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (polSourceSiteRet.PolSourceSiteWeb != null)
                            {
                                Assert.IsNotNull(polSourceSiteRet.PolSourceSiteWeb);
                            }
                            if (polSourceSiteRet.PolSourceSiteReport != null)
                            {
                                Assert.IsNotNull(polSourceSiteRet.PolSourceSiteReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of PolSourceSite
        #endregion Tests Get List of PolSourceSite

    }
}
