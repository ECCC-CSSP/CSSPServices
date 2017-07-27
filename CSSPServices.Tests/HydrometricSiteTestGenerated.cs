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
            if (OmitPropName != "Elevation_m") hydrometricSite.Elevation_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "StartDate_Local") hydrometricSite.StartDate_Local = GetRandomDateTime();
            if (OmitPropName != "EndDate_Local") hydrometricSite.EndDate_Local = GetRandomDateTime();
            if (OmitPropName != "TimeOffset_hour") hydrometricSite.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "DrainageArea_km2") hydrometricSite.DrainageArea_km2 = GetRandomDouble(0.0D, 1000000.0D);
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
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // hydrometricSite.HydrometricSiteID   (Int32)
            // -----------------------------------

            hydrometricSite = GetFilledRandomHydrometricSite("");
            hydrometricSite.HydrometricSiteID = 0;
            hydrometricSiteService.Update(hydrometricSite);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteHydrometricSiteID), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.HydrometricSite)]
            // [Range(1, -1)]
            // hydrometricSite.HydrometricSiteTVItemID   (Int32)
            // -----------------------------------

            // HydrometricSiteTVItemID will automatically be initialized at 0 --> not null


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // HydrometricSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            hydrometricSite.HydrometricSiteTVItemID = 1;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1, hydrometricSite.HydrometricSiteTVItemID);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // HydrometricSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            hydrometricSite.HydrometricSiteTVItemID = 2;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(2, hydrometricSite.HydrometricSiteTVItemID);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // HydrometricSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            hydrometricSite.HydrometricSiteTVItemID = 0;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricSiteHydrometricSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, hydrometricSite.HydrometricSiteTVItemID);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(7))]
            // hydrometricSite.FedSiteNumber   (String)
            // -----------------------------------


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // FedSiteNumber has MinLength [empty] and MaxLength [7]. At Max should return true and no errors
            string hydrometricSiteFedSiteNumberMin = GetRandomString("", 7);
            hydrometricSite.FedSiteNumber = hydrometricSiteFedSiteNumberMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteFedSiteNumberMin, hydrometricSite.FedSiteNumber);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // FedSiteNumber has MinLength [empty] and MaxLength [7]. At Max - 1 should return true and no errors
            hydrometricSiteFedSiteNumberMin = GetRandomString("", 6);
            hydrometricSite.FedSiteNumber = hydrometricSiteFedSiteNumberMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteFedSiteNumberMin, hydrometricSite.FedSiteNumber);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // FedSiteNumber has MinLength [empty] and MaxLength [7]. At Max + 1 should return false with one error
            hydrometricSiteFedSiteNumberMin = GetRandomString("", 8);
            hydrometricSite.FedSiteNumber = hydrometricSiteFedSiteNumberMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteFedSiteNumber, "7")).Any());
            Assert.AreEqual(hydrometricSiteFedSiteNumberMin, hydrometricSite.FedSiteNumber);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(7))]
            // hydrometricSite.QuebecSiteNumber   (String)
            // -----------------------------------


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // QuebecSiteNumber has MinLength [empty] and MaxLength [7]. At Max should return true and no errors
            string hydrometricSiteQuebecSiteNumberMin = GetRandomString("", 7);
            hydrometricSite.QuebecSiteNumber = hydrometricSiteQuebecSiteNumberMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteQuebecSiteNumberMin, hydrometricSite.QuebecSiteNumber);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // QuebecSiteNumber has MinLength [empty] and MaxLength [7]. At Max - 1 should return true and no errors
            hydrometricSiteQuebecSiteNumberMin = GetRandomString("", 6);
            hydrometricSite.QuebecSiteNumber = hydrometricSiteQuebecSiteNumberMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteQuebecSiteNumberMin, hydrometricSite.QuebecSiteNumber);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // QuebecSiteNumber has MinLength [empty] and MaxLength [7]. At Max + 1 should return false with one error
            hydrometricSiteQuebecSiteNumberMin = GetRandomString("", 8);
            hydrometricSite.QuebecSiteNumber = hydrometricSiteQuebecSiteNumberMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteQuebecSiteNumber, "7")).Any());
            Assert.AreEqual(hydrometricSiteQuebecSiteNumberMin, hydrometricSite.QuebecSiteNumber);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(200))]
            // hydrometricSite.HydrometricSiteName   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("HydrometricSiteName");
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteHydrometricSiteName)).Any());
            Assert.AreEqual(null, hydrometricSite.HydrometricSiteName);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // HydrometricSiteName has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string hydrometricSiteHydrometricSiteNameMin = GetRandomString("", 200);
            hydrometricSite.HydrometricSiteName = hydrometricSiteHydrometricSiteNameMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteHydrometricSiteNameMin, hydrometricSite.HydrometricSiteName);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // HydrometricSiteName has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            hydrometricSiteHydrometricSiteNameMin = GetRandomString("", 199);
            hydrometricSite.HydrometricSiteName = hydrometricSiteHydrometricSiteNameMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteHydrometricSiteNameMin, hydrometricSite.HydrometricSiteName);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // HydrometricSiteName has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            hydrometricSiteHydrometricSiteNameMin = GetRandomString("", 201);
            hydrometricSite.HydrometricSiteName = hydrometricSiteHydrometricSiteNameMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteHydrometricSiteName, "200")).Any());
            Assert.AreEqual(hydrometricSiteHydrometricSiteNameMin, hydrometricSite.HydrometricSiteName);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(200))]
            // hydrometricSite.Description   (String)
            // -----------------------------------


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // Description has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string hydrometricSiteDescriptionMin = GetRandomString("", 200);
            hydrometricSite.Description = hydrometricSiteDescriptionMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteDescriptionMin, hydrometricSite.Description);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // Description has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            hydrometricSiteDescriptionMin = GetRandomString("", 199);
            hydrometricSite.Description = hydrometricSiteDescriptionMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteDescriptionMin, hydrometricSite.Description);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // Description has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            hydrometricSiteDescriptionMin = GetRandomString("", 201);
            hydrometricSite.Description = hydrometricSiteDescriptionMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteDescription, "200")).Any());
            Assert.AreEqual(hydrometricSiteDescriptionMin, hydrometricSite.Description);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(4))]
            // hydrometricSite.Province   (String)
            // -----------------------------------

            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("Province");
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(1, hydrometricSite.ValidationResults.Count());
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteProvince)).Any());
            Assert.AreEqual(null, hydrometricSite.Province);
            Assert.AreEqual(0, hydrometricSiteService.GetRead().Count());


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");

            // Province has MinLength [empty] and MaxLength [4]. At Max should return true and no errors
            string hydrometricSiteProvinceMin = GetRandomString("", 4);
            hydrometricSite.Province = hydrometricSiteProvinceMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteProvinceMin, hydrometricSite.Province);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // Province has MinLength [empty] and MaxLength [4]. At Max - 1 should return true and no errors
            hydrometricSiteProvinceMin = GetRandomString("", 3);
            hydrometricSite.Province = hydrometricSiteProvinceMin;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(hydrometricSiteProvinceMin, hydrometricSite.Province);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // Province has MinLength [empty] and MaxLength [4]. At Max + 1 should return false with one error
            hydrometricSiteProvinceMin = GetRandomString("", 5);
            hydrometricSite.Province = hydrometricSiteProvinceMin;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteProvince, "4")).Any());
            Assert.AreEqual(hydrometricSiteProvinceMin, hydrometricSite.Province);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 10000)]
            // hydrometricSite.Elevation_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [Elevation_m]


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            hydrometricSite.Elevation_m = 0.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, hydrometricSite.Elevation_m);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            hydrometricSite.Elevation_m = 1.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1.0D, hydrometricSite.Elevation_m);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            hydrometricSite.Elevation_m = -1.0D;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteElevation_m, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, hydrometricSite.Elevation_m);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            hydrometricSite.Elevation_m = 10000.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(10000.0D, hydrometricSite.Elevation_m);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            hydrometricSite.Elevation_m = 9999.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(9999.0D, hydrometricSite.Elevation_m);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            hydrometricSite.Elevation_m = 10001.0D;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteElevation_m, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, hydrometricSite.Elevation_m);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // hydrometricSite.StartDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDate_Local)]
            // hydrometricSite.EndDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(-10, 0)]
            // hydrometricSite.TimeOffset_hour   (Double)
            // -----------------------------------

            //Error: Type not implemented [TimeOffset_hour]


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Min should return true and no errors
            hydrometricSite.TimeOffset_hour = -10.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(-10.0D, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Min + 1 should return true and no errors
            hydrometricSite.TimeOffset_hour = -9.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(-9.0D, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Min - 1 should return false with one error
            hydrometricSite.TimeOffset_hour = -11.0D;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteTimeOffset_hour, "-10", "0")).Any());
            Assert.AreEqual(-11.0D, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Max should return true and no errors
            hydrometricSite.TimeOffset_hour = 0.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Max - 1 should return true and no errors
            hydrometricSite.TimeOffset_hour = -1.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(-1.0D, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Max + 1 should return false with one error
            hydrometricSite.TimeOffset_hour = 1.0D;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteTimeOffset_hour, "-10", "0")).Any());
            Assert.AreEqual(1.0D, hydrometricSite.TimeOffset_hour);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 1000000)]
            // hydrometricSite.DrainageArea_km2   (Double)
            // -----------------------------------

            //Error: Type not implemented [DrainageArea_km2]


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // DrainageArea_km2 has Min [0.0D] and Max [1000000.0D]. At Min should return true and no errors
            hydrometricSite.DrainageArea_km2 = 0.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0.0D] and Max [1000000.0D]. At Min + 1 should return true and no errors
            hydrometricSite.DrainageArea_km2 = 1.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1.0D, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0.0D] and Max [1000000.0D]. At Min - 1 should return false with one error
            hydrometricSite.DrainageArea_km2 = -1.0D;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteDrainageArea_km2, "0", "1000000")).Any());
            Assert.AreEqual(-1.0D, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0.0D] and Max [1000000.0D]. At Max should return true and no errors
            hydrometricSite.DrainageArea_km2 = 1000000.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1000000.0D, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0.0D] and Max [1000000.0D]. At Max - 1 should return true and no errors
            hydrometricSite.DrainageArea_km2 = 999999.0D;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(999999.0D, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // DrainageArea_km2 has Min [0.0D] and Max [1000000.0D]. At Max + 1 should return false with one error
            hydrometricSite.DrainageArea_km2 = 1000001.0D;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteDrainageArea_km2, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0D, hydrometricSite.DrainageArea_km2);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // hydrometricSite.IsNatural   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.IsActive   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.Sediment   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.RHBN   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.RealTime   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // hydrometricSite.HasRatingCurve   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // hydrometricSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // hydrometricSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            hydrometricSite = null;
            hydrometricSite = GetFilledRandomHydrometricSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            hydrometricSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(1, hydrometricSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            hydrometricSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, hydrometricSiteService.Add(hydrometricSite));
            Assert.AreEqual(0, hydrometricSite.ValidationResults.Count());
            Assert.AreEqual(2, hydrometricSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, hydrometricSiteService.Delete(hydrometricSite));
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            hydrometricSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
            Assert.IsTrue(hydrometricSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, hydrometricSite.LastUpdateContactTVItemID);
            Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // hydrometricSite.HydrometricDataValues   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // hydrometricSite.RatingCurves   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // hydrometricSite.HydrometricSiteTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // hydrometricSite.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
