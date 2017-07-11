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
    public partial class TideLocationTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TideLocationID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TideLocationTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideLocation GetFilledRandomTideLocation(string OmitPropName)
        {
            TideLocationID += 1;

            TideLocation tideLocation = new TideLocation();

            if (OmitPropName != "TideLocationID") tideLocation.TideLocationID = GetRandomInt(1, 5);
            if (OmitPropName != "Zone") tideLocation.Zone = GetRandomInt(1, 11);
            if (OmitPropName != "Name") tideLocation.Name = GetRandomString("", 5);
            if (OmitPropName != "Prov") tideLocation.Prov = GetRandomString("", 5);
            if (OmitPropName != "sid") tideLocation.sid = GetRandomInt(1, 11);
            if (OmitPropName != "Lat") tideLocation.Lat = GetRandomFloat(-90, 90);
            if (OmitPropName != "Lng") tideLocation.Lng = GetRandomFloat(-180, 180);

            return tideLocation;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TideLocation_Testing()
        {
            SetupTestHelper(culture);
            TideLocationService tideLocationService = new TideLocationService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            TideLocation tideLocation = GetFilledRandomTideLocation("");
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(true, tideLocationService.GetRead().Where(c => c == tideLocation).Any());
            tideLocation.Zone = GetRandomInt(1, 11);
            Assert.AreEqual(true, tideLocationService.Update(tideLocation));
            Assert.AreEqual(1, tideLocationService.GetRead().Count());
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // Zone will automatically be initialized at 0 --> not null

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("Name");
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.AreEqual(1, tideLocation.ValidationResults.Count());
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideLocationName)).Any());
            Assert.AreEqual(null, tideLocation.Name);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("Prov");
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.AreEqual(1, tideLocation.ValidationResults.Count());
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideLocationProv)).Any());
            Assert.AreEqual(null, tideLocation.Prov);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            // sid will automatically be initialized at 0 --> not null

            // Lat will automatically be initialized at 0.0f --> not null

            // Lng will automatically be initialized at 0.0f --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TideLocationID] of type [string]
            //-----------------------------------

            //-----------------------------------
            // doing property [Zone] of type [int]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // Zone has Min [1] and Max [empty]. At Min should return true and no errors
            tideLocation.Zone = 1;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(1, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Zone has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideLocation.Zone = 2;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(2, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Zone has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideLocation.Zone = 0;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideLocationZone, "1")).Any());
            Assert.AreEqual(0, tideLocation.Zone);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            //-----------------------------------
            // doing property [Name] of type [string]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");

            // Name has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string tideLocationNameMin = GetRandomString("", 100);
            tideLocation.Name = tideLocationNameMin;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(tideLocationNameMin, tideLocation.Name);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            // Name has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            tideLocationNameMin = GetRandomString("", 99);
            tideLocation.Name = tideLocationNameMin;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(tideLocationNameMin, tideLocation.Name);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            // Name has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            tideLocationNameMin = GetRandomString("", 101);
            tideLocation.Name = tideLocationNameMin;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideLocationName, "100")).Any());
            Assert.AreEqual(tideLocationNameMin, tideLocation.Name);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            //-----------------------------------
            // doing property [Prov] of type [string]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");

            // Prov has MinLength [empty] and MaxLength [10]. At Max should return true and no errors
            string tideLocationProvMin = GetRandomString("", 10);
            tideLocation.Prov = tideLocationProvMin;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(tideLocationProvMin, tideLocation.Prov);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            // Prov has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            tideLocationProvMin = GetRandomString("", 9);
            tideLocation.Prov = tideLocationProvMin;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(tideLocationProvMin, tideLocation.Prov);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            // Prov has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            tideLocationProvMin = GetRandomString("", 11);
            tideLocation.Prov = tideLocationProvMin;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideLocationProv, "10")).Any());
            Assert.AreEqual(tideLocationProvMin, tideLocation.Prov);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            //-----------------------------------
            // doing property [sid] of type [int]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // sid has Min [1] and Max [empty]. At Min should return true and no errors
            tideLocation.sid = 1;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(1, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // sid has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideLocation.sid = 2;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(2, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // sid has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideLocation.sid = 0;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideLocationsid, "1")).Any());
            Assert.AreEqual(0, tideLocation.sid);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            //-----------------------------------
            // doing property [Lat] of type [float]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // Lat has Min [-90] and Max [90]. At Min should return true and no errors
            tideLocation.Lat = -90.0f;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(-90.0f, tideLocation.Lat);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Min + 1 should return true and no errors
            tideLocation.Lat = -89.0f;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(-89.0f, tideLocation.Lat);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Min - 1 should return false with one error
            tideLocation.Lat = -91.0f;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLat, "-90", "90")).Any());
            Assert.AreEqual(-91.0f, tideLocation.Lat);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Max should return true and no errors
            tideLocation.Lat = 90.0f;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(90.0f, tideLocation.Lat);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Max - 1 should return true and no errors
            tideLocation.Lat = 89.0f;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(89.0f, tideLocation.Lat);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Max + 1 should return false with one error
            tideLocation.Lat = 91.0f;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLat, "-90", "90")).Any());
            Assert.AreEqual(91.0f, tideLocation.Lat);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            //-----------------------------------
            // doing property [Lng] of type [float]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // Lng has Min [-180] and Max [180]. At Min should return true and no errors
            tideLocation.Lng = -180.0f;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(-180.0f, tideLocation.Lng);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            tideLocation.Lng = -179.0f;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(-179.0f, tideLocation.Lng);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Min - 1 should return false with one error
            tideLocation.Lng = -181.0f;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLng, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, tideLocation.Lng);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Max should return true and no errors
            tideLocation.Lng = 180.0f;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(180.0f, tideLocation.Lng);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            tideLocation.Lng = 179.0f;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(179.0f, tideLocation.Lng);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Max + 1 should return false with one error
            tideLocation.Lng = 181.0f;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLng, "-180", "180")).Any());
            Assert.AreEqual(181.0f, tideLocation.Lng);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
