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
        private int PolSourceSiteID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceSite GetFilledRandomPolSourceSite(string OmitPropName)
        {
            PolSourceSiteID += 1;

            PolSourceSite polSourceSite = new PolSourceSite();

            if (OmitPropName != "PolSourceSiteID") polSourceSite.PolSourceSiteID = PolSourceSiteID;
            if (OmitPropName != "PolSourceSiteTVItemID") polSourceSite.PolSourceSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Temp_Locator_CanDelete") polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 5);
            if (OmitPropName != "Oldsiteid") polSourceSite.Oldsiteid = GetRandomInt(0, 10);
            if (OmitPropName != "Site") polSourceSite.Site = GetRandomInt(0, 10);
            if (OmitPropName != "SiteID") polSourceSite.SiteID = GetRandomInt(0, 10);
            if (OmitPropName != "IsPointSource") polSourceSite.IsPointSource = true;
            if (OmitPropName != "InactiveReason") polSourceSite.InactiveReason = (PolSourceInactiveReasonEnum)GetRandomEnumType(typeof(PolSourceInactiveReasonEnum));
            if (OmitPropName != "CivicAddressTVItemID") polSourceSite.CivicAddressTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return polSourceSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceSite_Testing()
        {
            SetupTestHelper(culture);
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            PolSourceSite polSourceSite = GetFilledRandomPolSourceSite("");
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(true, polSourceSiteService.GetRead().Where(c => c == polSourceSite).Any());
            polSourceSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, polSourceSiteService.Update(polSourceSite));
            Assert.AreEqual(1, polSourceSiteService.GetRead().Count());
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // PolSourceSiteTVItemID will automatically be initialized at 0 --> not null

            // IsPointSource will automatically be initialized at false --> not null

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("LastUpdateDate_UTC");
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(1, polSourceSite.ValidationResults.Count());
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceSiteLastUpdateDate_UTC)).Any());
            Assert.IsTrue(polSourceSite.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [PolSourceSiteID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [PolSourceSiteTVItemID] of type [int]
            //-----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // PolSourceSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceSite.PolSourceSiteTVItemID = 1;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1, polSourceSite.PolSourceSiteTVItemID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // PolSourceSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceSite.PolSourceSiteTVItemID = 2;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(2, polSourceSite.PolSourceSiteTVItemID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // PolSourceSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceSite.PolSourceSiteTVItemID = 0;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceSitePolSourceSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceSite.PolSourceSiteTVItemID);
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [Temp_Locator_CanDelete] of type [string]
            //-----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");

            // Temp_Locator_CanDelete has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string polSourceSiteTemp_Locator_CanDeleteMin = GetRandomString("", 50);
            polSourceSite.Temp_Locator_CanDelete = polSourceSiteTemp_Locator_CanDeleteMin;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(polSourceSiteTemp_Locator_CanDeleteMin, polSourceSite.Temp_Locator_CanDelete);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            // Temp_Locator_CanDelete has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            polSourceSiteTemp_Locator_CanDeleteMin = GetRandomString("", 49);
            polSourceSite.Temp_Locator_CanDelete = polSourceSiteTemp_Locator_CanDeleteMin;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(polSourceSiteTemp_Locator_CanDeleteMin, polSourceSite.Temp_Locator_CanDelete);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            // Temp_Locator_CanDelete has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            polSourceSiteTemp_Locator_CanDeleteMin = GetRandomString("", 51);
            polSourceSite.Temp_Locator_CanDelete = polSourceSiteTemp_Locator_CanDeleteMin;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceSiteTemp_Locator_CanDelete, "50")).Any());
            Assert.AreEqual(polSourceSiteTemp_Locator_CanDeleteMin, polSourceSite.Temp_Locator_CanDelete);
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [Oldsiteid] of type [int]
            //-----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // Oldsiteid has Min [0] and Max [empty]. At Min should return true and no errors
            polSourceSite.Oldsiteid = 0;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(0, polSourceSite.Oldsiteid);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // Oldsiteid has Min [0] and Max [empty]. At Min + 1 should return true and no errors
            polSourceSite.Oldsiteid = 1;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1, polSourceSite.Oldsiteid);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // Oldsiteid has Min [0] and Max [empty]. At Min - 1 should return false with one error
            polSourceSite.Oldsiteid = -1;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceSiteOldsiteid, "0")).Any());
            Assert.AreEqual(-1, polSourceSite.Oldsiteid);
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [Site] of type [int]
            //-----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // Site has Min [0] and Max [empty]. At Min should return true and no errors
            polSourceSite.Site = 0;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(0, polSourceSite.Site);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // Site has Min [0] and Max [empty]. At Min + 1 should return true and no errors
            polSourceSite.Site = 1;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1, polSourceSite.Site);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // Site has Min [0] and Max [empty]. At Min - 1 should return false with one error
            polSourceSite.Site = -1;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceSiteSite, "0")).Any());
            Assert.AreEqual(-1, polSourceSite.Site);
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [SiteID] of type [int]
            //-----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // SiteID has Min [0] and Max [empty]. At Min should return true and no errors
            polSourceSite.SiteID = 0;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(0, polSourceSite.SiteID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // SiteID has Min [0] and Max [empty]. At Min + 1 should return true and no errors
            polSourceSite.SiteID = 1;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1, polSourceSite.SiteID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // SiteID has Min [0] and Max [empty]. At Min - 1 should return false with one error
            polSourceSite.SiteID = -1;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceSiteSiteID, "0")).Any());
            Assert.AreEqual(-1, polSourceSite.SiteID);
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [IsPointSource] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [InactiveReason] of type [PolSourceInactiveReasonEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [CivicAddressTVItemID] of type [int]
            //-----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // CivicAddressTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceSite.CivicAddressTVItemID = 1;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1, polSourceSite.CivicAddressTVItemID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // CivicAddressTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceSite.CivicAddressTVItemID = 2;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(2, polSourceSite.CivicAddressTVItemID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // CivicAddressTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceSite.CivicAddressTVItemID = 0;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceSiteCivicAddressTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceSite.CivicAddressTVItemID);
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            polSourceSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(1, polSourceSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            polSourceSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, polSourceSiteService.Add(polSourceSite));
            Assert.AreEqual(0, polSourceSite.ValidationResults.Count());
            Assert.AreEqual(2, polSourceSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, polSourceSiteService.Delete(polSourceSite));
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            polSourceSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, polSourceSiteService.Add(polSourceSite));
            Assert.IsTrue(polSourceSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, polSourceSite.LastUpdateContactTVItemID);
            Assert.AreEqual(0, polSourceSiteService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
