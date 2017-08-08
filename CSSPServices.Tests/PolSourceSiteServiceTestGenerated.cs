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

            if (OmitPropName != "PolSourceSiteTVItemID") polSourceSite.PolSourceSiteTVItemID = 21;
            if (OmitPropName != "Temp_Locator_CanDelete") polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 5);
            if (OmitPropName != "Oldsiteid") polSourceSite.Oldsiteid = GetRandomInt(0, 1000);
            if (OmitPropName != "Site") polSourceSite.Site = GetRandomInt(0, 1000);
            if (OmitPropName != "SiteID") polSourceSite.SiteID = GetRandomInt(0, 1000);
            if (OmitPropName != "IsPointSource") polSourceSite.IsPointSource = true;
            if (OmitPropName != "InactiveReason") polSourceSite.InactiveReason = (PolSourceInactiveReasonEnum)GetRandomEnumType(typeof(PolSourceInactiveReasonEnum));
            if (OmitPropName != "CivicAddressTVItemID") polSourceSite.CivicAddressTVItemID = 28;
            if (OmitPropName != "LastUpdateDate_UTC") polSourceSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceSite.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "PolSourceSiteTVText") polSourceSite.PolSourceSiteTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") polSourceSite.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "InactiveReasonText") polSourceSite.InactiveReasonText = GetRandomString("", 5);

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

                polSourceSiteService.Add(polSourceSite);
                if (polSourceSite.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, polSourceSiteService.GetRead().Where(c => c == polSourceSite).Any());
                polSourceSiteService.Update(polSourceSite);
                if (polSourceSite.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, polSourceSiteService.GetRead().Count());
                polSourceSiteService.Delete(polSourceSite);
                if (polSourceSite.ValidationResults.Count() > 0)
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceSitePolSourceSiteID), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = PolSourceSite)]
                // polSourceSite.PolSourceSiteTVItemID   (Int32)
                // -----------------------------------

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.PolSourceSiteTVItemID = 0;
                polSourceSiteService.Add(polSourceSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceSitePolSourceSiteTVItemID, polSourceSite.PolSourceSiteTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.PolSourceSiteTVItemID = 1;
                polSourceSiteService.Add(polSourceSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.PolSourceSitePolSourceSiteTVItemID, "PolSourceSite"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [StringLength(50))]
                // polSourceSite.Temp_Locator_CanDelete   (String)
                // -----------------------------------

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 51);
                Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceSiteTemp_Locator_CanDelete, "50"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteOldsiteid, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.Oldsiteid = 1001;
                Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteOldsiteid, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSite, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.Site = 1001;
                Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSite, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSiteID, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.SiteID = 1001;
                Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSiteID, "0", "1000"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceSiteInactiveReason), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Address)]
                // polSourceSite.CivicAddressTVItemID   (Int32)
                // -----------------------------------

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.CivicAddressTVItemID = 0;
                polSourceSiteService.Add(polSourceSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceSiteCivicAddressTVItemID, polSourceSite.CivicAddressTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.CivicAddressTVItemID = 1;
                polSourceSiteService.Add(polSourceSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.PolSourceSiteCivicAddressTVItemID, "Address"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // polSourceSite.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // polSourceSite.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.LastUpdateContactTVItemID = 0;
                polSourceSiteService.Add(polSourceSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceSiteLastUpdateContactTVItemID, polSourceSite.LastUpdateContactTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.LastUpdateContactTVItemID = 1;
                polSourceSiteService.Add(polSourceSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.PolSourceSiteLastUpdateContactTVItemID, "Contact"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // polSourceSite.PolSourceSiteTVText   (String)
                // -----------------------------------

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.PolSourceSiteTVText = GetRandomString("", 201);
                Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceSitePolSourceSiteTVText, "200"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // polSourceSite.LastUpdateContactTVText   (String)
                // -----------------------------------

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceSiteLastUpdateContactTVText, "200"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // polSourceSite.InactiveReasonText   (String)
                // -----------------------------------

                polSourceSite = null;
                polSourceSite = GetFilledRandomPolSourceSite("");
                polSourceSite.InactiveReasonText = GetRandomString("", 101);
                Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceSiteInactiveReasonText, "100"), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // polSourceSite.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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

                PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, dbTestDB, ContactID);

                PolSourceSite polSourceSite = (from c in polSourceSiteService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(polSourceSite);

                PolSourceSite polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteID(polSourceSite.PolSourceSiteID);
                Assert.AreEqual(polSourceSite.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);
            }
        }
        #endregion Tests Get With Key

    }
}
