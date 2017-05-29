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
        private int HydrometricSiteID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private HydrometricSite GetFilledRandomHydrometricSite(string OmitPropName)
        {
            HydrometricSiteID += 1;

            HydrometricSite hydrometricSite = new HydrometricSite();

            if (OmitPropName != "HydrometricSiteID") hydrometricSite.HydrometricSiteID = HydrometricSiteID;
            if (OmitPropName != "HydrometricSiteTVItemID") hydrometricSite.HydrometricSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "FedSiteNumber") hydrometricSite.FedSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "QuebecSiteNumber") hydrometricSite.QuebecSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "HydrometricSiteName") hydrometricSite.HydrometricSiteName = GetRandomString("", 5);
            if (OmitPropName != "Description") hydrometricSite.Description = GetRandomString("", 5);
            if (OmitPropName != "Province") hydrometricSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") hydrometricSite.Elevation_m = GetRandomFloat(0, 10000);
            if (OmitPropName != "StartDate_Local") hydrometricSite.StartDate_Local = GetRandomDateTime();
            if (OmitPropName != "EndDate_Local") hydrometricSite.EndDate_Local = GetRandomDateTime();
            if (OmitPropName != "TimeOffset_hour") hydrometricSite.TimeOffset_hour = GetRandomFloat(-12, 12);
            if (OmitPropName != "DrainageArea_km2") hydrometricSite.DrainageArea_km2 = GetRandomFloat(0, 1000000);
            if (OmitPropName != "IsNatural") hydrometricSite.IsNatural = true;
            if (OmitPropName != "IsActive") hydrometricSite.IsActive = true;
            if (OmitPropName != "Sediment") hydrometricSite.Sediment = true;
            if (OmitPropName != "RHBN") hydrometricSite.RHBN = true;
            if (OmitPropName != "RealTime") hydrometricSite.RealTime = true;
            if (OmitPropName != "HasRatingCurve") hydrometricSite.HasRatingCurve = true;
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return hydrometricSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void HydrometricSite_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            HydrometricSite hydrometricSite = GetFilledRandomHydrometricSite("");
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(true, hydrometricSiteService.GetRead().Where(c => c == hydrometricSite).Any());
            hydrometricSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, hydrometricSiteService.Update(hydrometricSite));
            Assert.AreEqual(1, hydrometricSiteService.GetRead().Count());
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // HydrometricSiteTVItemID will automatically be initialized at 0 --> not null

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("HydrometricSiteName");
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteHydrometricSiteName)).Any());
            Assert.AreEqual(null, hydrometricSite.HydrometricSiteName);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("Province");
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteProvince)).Any());
            Assert.AreEqual(null, hydrometricSite.Province);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("LastUpdateDate_UTC");
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteLastUpdateDate_UTC)).Any());
            Assert.IsTrue(hydrometricSite.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [HydrometricSiteID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [HydrometricSiteTVItemID] of type [int]
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
            // doing property [FedSiteNumber] of type [string]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // FedSiteNumber has MinLength [empty] and MaxLength [7]. At Max should return true and no errors
            string hydrometricSiteFedSiteNumberMin = GetRandomString("", 7);
            hydrometricSite.FedSiteNumber = hydrometricSiteFedSiteNumberMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteFedSiteNumberMin, hydrometricSite.FedSiteNumber);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // FedSiteNumber has MinLength [empty] and MaxLength [7]. At Max - 1 should return true and no errors
            hydrometricSiteFedSiteNumberMin = GetRandomString("", 6);
            hydrometricSite.FedSiteNumber = hydrometricSiteFedSiteNumberMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteFedSiteNumberMin, hydrometricSite.FedSiteNumber);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // FedSiteNumber has MinLength [empty] and MaxLength [7]. At Max + 1 should return false with one error
            hydrometricSiteFedSiteNumberMin = GetRandomString("", 8);
            hydrometricSite.FedSiteNumber = hydrometricSiteFedSiteNumberMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteFedSiteNumber, "7")).Any());
            Assert.AreEqual(hydrometricSiteFedSiteNumberMin, hydrometricSite.FedSiteNumber);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [QuebecSiteNumber] of type [string]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // QuebecSiteNumber has MinLength [empty] and MaxLength [7]. At Max should return true and no errors
            string hydrometricSiteQuebecSiteNumberMin = GetRandomString("", 7);
            hydrometricSite.QuebecSiteNumber = hydrometricSiteQuebecSiteNumberMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteQuebecSiteNumberMin, hydrometricSite.QuebecSiteNumber);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // QuebecSiteNumber has MinLength [empty] and MaxLength [7]. At Max - 1 should return true and no errors
            hydrometricSiteQuebecSiteNumberMin = GetRandomString("", 6);
            hydrometricSite.QuebecSiteNumber = hydrometricSiteQuebecSiteNumberMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteQuebecSiteNumberMin, hydrometricSite.QuebecSiteNumber);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // QuebecSiteNumber has MinLength [empty] and MaxLength [7]. At Max + 1 should return false with one error
            hydrometricSiteQuebecSiteNumberMin = GetRandomString("", 8);
            hydrometricSite.QuebecSiteNumber = hydrometricSiteQuebecSiteNumberMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteQuebecSiteNumber, "7")).Any());
            Assert.AreEqual(hydrometricSiteQuebecSiteNumberMin, hydrometricSite.QuebecSiteNumber);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [HydrometricSiteName] of type [string]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // HydrometricSiteName has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string hydrometricSiteHydrometricSiteNameMin = GetRandomString("", 200);
            hydrometricSite.HydrometricSiteName = hydrometricSiteHydrometricSiteNameMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteHydrometricSiteNameMin, hydrometricSite.HydrometricSiteName);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // HydrometricSiteName has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            hydrometricSiteHydrometricSiteNameMin = GetRandomString("", 199);
            hydrometricSite.HydrometricSiteName = hydrometricSiteHydrometricSiteNameMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteHydrometricSiteNameMin, hydrometricSite.HydrometricSiteName);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // HydrometricSiteName has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            hydrometricSiteHydrometricSiteNameMin = GetRandomString("", 201);
            hydrometricSite.HydrometricSiteName = hydrometricSiteHydrometricSiteNameMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteHydrometricSiteName, "200")).Any());
            Assert.AreEqual(hydrometricSiteHydrometricSiteNameMin, hydrometricSite.HydrometricSiteName);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [Description] of type [string]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // Description has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string hydrometricSiteDescriptionMin = GetRandomString("", 200);
            hydrometricSite.Description = hydrometricSiteDescriptionMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteDescriptionMin, hydrometricSite.Description);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // Description has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            hydrometricSiteDescriptionMin = GetRandomString("", 199);
            hydrometricSite.Description = hydrometricSiteDescriptionMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteDescriptionMin, hydrometricSite.Description);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // Description has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            hydrometricSiteDescriptionMin = GetRandomString("", 201);
            hydrometricSite.Description = hydrometricSiteDescriptionMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteDescription, "200")).Any());
            Assert.AreEqual(hydrometricSiteDescriptionMin, hydrometricSite.Description);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [Province] of type [string]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // Province has MinLength [empty] and MaxLength [4]. At Max should return true and no errors
            string hydrometricSiteProvinceMin = GetRandomString("", 4);
            hydrometricSite.Province = hydrometricSiteProvinceMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteProvinceMin, hydrometricSite.Province);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // Province has MinLength [empty] and MaxLength [4]. At Max - 1 should return true and no errors
            hydrometricSiteProvinceMin = GetRandomString("", 3);
            hydrometricSite.Province = hydrometricSiteProvinceMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteProvinceMin, hydrometricSite.Province);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            // Province has MinLength [empty] and MaxLength [4]. At Max + 1 should return false with one error
            hydrometricSiteProvinceMin = GetRandomString("", 5);
            hydrometricSite.Province = hydrometricSiteProvinceMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteProvince, "4")).Any());
            Assert.AreEqual(hydrometricSiteProvinceMin, hydrometricSite.Province);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [Elevation_m] of type [float]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // Elevation_m has Min [0] and Max [10000]. At Min should return true and no errors
            hydrometricSite.Elevation_m = 0.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(0.0f, hydrometricSite.Elevation_m);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            hydrometricSite.Elevation_m = 1.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1.0f, hydrometricSite.Elevation_m);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0] and Max [10000]. At Min - 1 should return false with one error
            hydrometricSite.Elevation_m = -1.0f;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteElevation_m, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, hydrometricSite.Elevation_m);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0] and Max [10000]. At Max should return true and no errors
            hydrometricSite.Elevation_m = 10000.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(10000.0f, hydrometricSite.Elevation_m);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            hydrometricSite.Elevation_m = 9999.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(9999.0f, hydrometricSite.Elevation_m);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0] and Max [10000]. At Max + 1 should return false with one error
            hydrometricSite.Elevation_m = 10001.0f;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteElevation_m, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, hydrometricSite.Elevation_m);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [StartDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EndDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [TimeOffset_hour] of type [float]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // TimeOffset_hour has Min [-12] and Max [12]. At Min should return true and no errors
            hydrometricSite.TimeOffset_hour = -12.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(-12.0f, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Min + 1 should return true and no errors
            hydrometricSite.TimeOffset_hour = -11.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(-11.0f, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Min - 1 should return false with one error
            hydrometricSite.TimeOffset_hour = -13.0f;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteTimeOffset_hour, "-12", "12")).Any());
            Assert.AreEqual(-13.0f, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Max should return true and no errors
            hydrometricSite.TimeOffset_hour = 12.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(12.0f, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Max - 1 should return true and no errors
            hydrometricSite.TimeOffset_hour = 11.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(11.0f, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-12] and Max [12]. At Max + 1 should return false with one error
            hydrometricSite.TimeOffset_hour = 13.0f;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteTimeOffset_hour, "-12", "12")).Any());
            Assert.AreEqual(13.0f, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [DrainageArea_km2] of type [float]
            //-----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // DrainageArea_km2 has Min [0] and Max [1000000]. At Min should return true and no errors
            hydrometricSite.DrainageArea_km2 = 0.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(0.0f, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            hydrometricSite.DrainageArea_km2 = 1.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1.0f, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            hydrometricSite.DrainageArea_km2 = -1.0f;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteDrainageArea_km2, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0] and Max [1000000]. At Max should return true and no errors
            hydrometricSite.DrainageArea_km2 = 1000000.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            hydrometricSite.DrainageArea_km2 = 999999.0f;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(999999.0f, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            hydrometricSite.DrainageArea_km2 = 1000001.0f;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteDrainageArea_km2, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [IsNatural] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsActive] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [Sediment] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [RHBN] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [RealTime] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [HasRatingCurve] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
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

        }
        #endregion Tests Generated
    }
}
