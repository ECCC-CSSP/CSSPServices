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
    public partial class HydrometricSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private HydrometricSiteService hydrometricSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteTest() : base()
        {
            hydrometricSiteService = new HydrometricSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private HydrometricSite GetFilledRandomHydrometricSite(string OmitPropName)
        {
            HydrometricSite hydrometricSite = new HydrometricSite();

            if (OmitPropName != "HydrometricSiteTVItemID") hydrometricSite.HydrometricSiteTVItemID = 8;
            if (OmitPropName != "FedSiteNumber") hydrometricSite.FedSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "QuebecSiteNumber") hydrometricSite.QuebecSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "HydrometricSiteName") hydrometricSite.HydrometricSiteName = GetRandomString("", 5);
            if (OmitPropName != "Description") hydrometricSite.Description = GetRandomString("", 5);
            if (OmitPropName != "Province") hydrometricSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") hydrometricSite.Elevation_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "StartDate_Local") hydrometricSite.StartDate_Local = GetRandomDateTime();
            if (OmitPropName != "EndDate_Local") hydrometricSite.EndDate_Local = GetRandomDateTime();
            if (OmitPropName != "TimeOffset_hour") hydrometricSite.TimeOffset_hour = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "DrainageArea_km2") hydrometricSite.DrainageArea_km2 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "IsNatural") hydrometricSite.IsNatural = true;
            if (OmitPropName != "IsActive") hydrometricSite.IsActive = true;
            if (OmitPropName != "Sediment") hydrometricSite.Sediment = true;
            if (OmitPropName != "RHBN") hydrometricSite.RHBN = true;
            if (OmitPropName != "RealTime") hydrometricSite.RealTime = true;
            if (OmitPropName != "HasRatingCurve") hydrometricSite.HasRatingCurve = true;
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricSite.LastUpdateContactTVItemID = 2;

            return hydrometricSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void HydrometricSite_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            HydrometricSite hydrometricSite = GetFilledRandomHydrometricSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = hydrometricSiteService.GetRead().Count();

            hydrometricSiteService.Add(hydrometricSite);
            if (hydrometricSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, hydrometricSiteService.GetRead().Where(c => c == hydrometricSite).Any());
            hydrometricSiteService.Update(hydrometricSite);
            if (hydrometricSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, hydrometricSiteService.GetRead().Count());
            hydrometricSiteService.Delete(hydrometricSite);
            if (hydrometricSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // HydrometricSiteTVItemID will automatically be initialized at 0 --> not null

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("FedSiteNumber");
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteFedSiteNumber)).Any());
            Assert.AreEqual(null, hydrometricSite.FedSiteNumber);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("QuebecSiteNumber");
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteQuebecSiteNumber)).Any());
            Assert.AreEqual(null, hydrometricSite.QuebecSiteNumber);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("Description");
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteDescription)).Any());
            Assert.AreEqual(null, hydrometricSite.Description);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //Error: Type not implemented [Elevation_m]

            //Error: Type not implemented [TimeOffset_hour]

            //Error: Type not implemented [DrainageArea_km2]

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("LastUpdateDate_UTC");
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteLastUpdateDate_UTC)).Any());
            Assert.IsTrue(hydrometricSite.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [HydrometricDataValues]

            //Error: Type not implemented [RatingCurves]

            //Error: Type not implemented [HydrometricSiteTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [HydrometricSiteID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [HydrometricSiteTVItemID] of type [Int32]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // HydrometricSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            hydrometricSite.HydrometricSiteTVItemID = 1;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1, hydrometricSite.HydrometricSiteTVItemID);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // HydrometricSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            hydrometricSite.HydrometricSiteTVItemID = 2;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(2, hydrometricSite.HydrometricSiteTVItemID);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // HydrometricSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            hydrometricSite.HydrometricSiteTVItemID = 0;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricSiteHydrometricSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, hydrometricSite.HydrometricSiteTVItemID);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [FedSiteNumber] of type [String]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            //-----------------------------------
            // doing property [QuebecSiteNumber] of type [String]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            //-----------------------------------
            // doing property [HydrometricSiteName] of type [String]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            //-----------------------------------
            // doing property [Description] of type [String]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            //-----------------------------------
            // doing property [Province] of type [String]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            //-----------------------------------
            // doing property [Elevation_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [StartDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EndDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [TimeOffset_hour] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [DrainageArea_km2] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsNatural] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsActive] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [Sediment] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [RHBN] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [RealTime] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [HasRatingCurve] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            hydrometricSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1, hydrometricSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            hydrometricSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(2, hydrometricSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            hydrometricSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, hydrometricSite.LastUpdateContactTVItemID);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [HydrometricDataValues] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [RatingCurves] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [HydrometricSiteTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
