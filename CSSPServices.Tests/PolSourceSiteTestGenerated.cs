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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class PolSourceSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceSiteService polSourceSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteTest() : base()
        {
            polSourceSiteService = new PolSourceSiteService(LanguageRequest, dbTestDB, ContactID);
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

            return polSourceSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceSite_Testing()
        {

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
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.PolSourceSite)]
            // polSourceSite.PolSourceSiteTVItemID   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.PolSourceSiteTVItemID = 0;
            polSourceSiteService.Add(polSourceSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceSitePolSourceSiteTVItemID, polSourceSite.PolSourceSiteTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // PolSourceSiteTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is Nullable
            // [StringLength(50))]
            // polSourceSite.Temp_Locator_CanDelete   (String)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // Temp_Locator_CanDelete has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string polSourceSiteTemp_Locator_CanDeleteMin = GetRandomString("", 50);
            polSourceSite.Temp_Locator_CanDelete = polSourceSiteTemp_Locator_CanDeleteMin;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(polSourceSiteTemp_Locator_CanDeleteMin, polSourceSite.Temp_Locator_CanDelete);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

            // Temp_Locator_CanDelete has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            polSourceSiteTemp_Locator_CanDeleteMin = GetRandomString("", 49);
            polSourceSite.Temp_Locator_CanDelete = polSourceSiteTemp_Locator_CanDeleteMin;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(polSourceSiteTemp_Locator_CanDeleteMin, polSourceSite.Temp_Locator_CanDelete);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

            // Temp_Locator_CanDelete has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            polSourceSiteTemp_Locator_CanDeleteMin = GetRandomString("", 51);
            polSourceSite.Temp_Locator_CanDelete = polSourceSiteTemp_Locator_CanDeleteMin;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceSiteTemp_Locator_CanDelete, "50")).Any());
            Assert.AreEqual(polSourceSiteTemp_Locator_CanDeleteMin, polSourceSite.Temp_Locator_CanDelete);
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000)]
            // polSourceSite.Oldsiteid   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // Oldsiteid has Min [0] and Max [1000]. At Min should return true and no errors
            polSourceSite.Oldsiteid = 0;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(0, polSourceSite.Oldsiteid);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Oldsiteid has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            polSourceSite.Oldsiteid = 1;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1, polSourceSite.Oldsiteid);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Oldsiteid has Min [0] and Max [1000]. At Min - 1 should return false with one error
            polSourceSite.Oldsiteid = -1;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteOldsiteid, "0", "1000")).Any());
            Assert.AreEqual(-1, polSourceSite.Oldsiteid);
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Oldsiteid has Min [0] and Max [1000]. At Max should return true and no errors
            polSourceSite.Oldsiteid = 1000;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1000, polSourceSite.Oldsiteid);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Oldsiteid has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            polSourceSite.Oldsiteid = 999;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(999, polSourceSite.Oldsiteid);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Oldsiteid has Min [0] and Max [1000]. At Max + 1 should return false with one error
            polSourceSite.Oldsiteid = 1001;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteOldsiteid, "0", "1000")).Any());
            Assert.AreEqual(1001, polSourceSite.Oldsiteid);
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000)]
            // polSourceSite.Site   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // Site has Min [0] and Max [1000]. At Min should return true and no errors
            polSourceSite.Site = 0;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(0, polSourceSite.Site);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Site has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            polSourceSite.Site = 1;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1, polSourceSite.Site);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Site has Min [0] and Max [1000]. At Min - 1 should return false with one error
            polSourceSite.Site = -1;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSite, "0", "1000")).Any());
            Assert.AreEqual(-1, polSourceSite.Site);
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Site has Min [0] and Max [1000]. At Max should return true and no errors
            polSourceSite.Site = 1000;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1000, polSourceSite.Site);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Site has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            polSourceSite.Site = 999;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(999, polSourceSite.Site);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // Site has Min [0] and Max [1000]. At Max + 1 should return false with one error
            polSourceSite.Site = 1001;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSite, "0", "1000")).Any());
            Assert.AreEqual(1001, polSourceSite.Site);
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000)]
            // polSourceSite.SiteID   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // SiteID has Min [0] and Max [1000]. At Min should return true and no errors
            polSourceSite.SiteID = 0;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(0, polSourceSite.SiteID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // SiteID has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            polSourceSite.SiteID = 1;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1, polSourceSite.SiteID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // SiteID has Min [0] and Max [1000]. At Min - 1 should return false with one error
            polSourceSite.SiteID = -1;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSiteID, "0", "1000")).Any());
            Assert.AreEqual(-1, polSourceSite.SiteID);
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // SiteID has Min [0] and Max [1000]. At Max should return true and no errors
            polSourceSite.SiteID = 1000;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1000, polSourceSite.SiteID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // SiteID has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            polSourceSite.SiteID = 999;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(999, polSourceSite.SiteID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());
            // SiteID has Min [0] and Max [1000]. At Max + 1 should return false with one error
            polSourceSite.SiteID = 1001;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSiteID, "0", "1000")).Any());
            Assert.AreEqual(1001, polSourceSite.SiteID);
            Assert.AreEqual(count, polSourceSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // polSourceSite.IsPointSource   (Boolean)
            // -----------------------------------

            // IsPointSource will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // polSourceSite.InactiveReason   (PolSourceInactiveReasonEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Address)]
            // polSourceSite.CivicAddressTVItemID   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.CivicAddressTVItemID = 0;
            polSourceSiteService.Add(polSourceSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceSiteCivicAddressTVItemID, polSourceSite.CivicAddressTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // polSourceSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.LastUpdateContactTVItemID = 0;
            polSourceSiteService.Add(polSourceSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceSiteLastUpdateContactTVItemID, polSourceSite.LastUpdateContactTVItemID.ToString()), polSourceSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // polSourceSite.PolSourceObservations   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // polSourceSite.PolSourceSiteTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // polSourceSite.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
