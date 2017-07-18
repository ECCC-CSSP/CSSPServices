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

            if (OmitPropName != "TideLocationID") tideLocation.TideLocationID = TideLocationID;
            if (OmitPropName != "Zone") tideLocation.Zone = GetRandomInt(0, 10000);
            if (OmitPropName != "Name") tideLocation.Name = GetRandomString("", 5);
            if (OmitPropName != "Prov") tideLocation.Prov = GetRandomString("", 5);
            if (OmitPropName != "sid") tideLocation.sid = GetRandomInt(0, 100000);
            if (OmitPropName != "Lat") tideLocation.Lat = GetRandomFloat(-90.0f, 90.0f);
            if (OmitPropName != "Lng") tideLocation.Lng = GetRandomFloat(-180.0f, 180.0f);

            return tideLocation;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TideLocation_Testing()
        {
            SetupTestHelper(culture);
            TideLocationService tideLocationService = new TideLocationService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            TideLocation tideLocation = GetFilledRandomTideLocation("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(true, tideLocationService.GetRead().Where(c => c == tideLocation).Any());
            tideLocation.Zone = GetRandomInt(0, 10000);
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

            // Lat will automatically be initialized at 0 --> not null

            // Lng will automatically be initialized at 0 --> not null

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TideLocationID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [Zone] of type [Int32]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // Zone has Min [0] and Max [10000]. At Min should return true and no errors
            tideLocation.Zone = 0;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(0, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            tideLocation.Zone = 1;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(1, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Min - 1 should return false with one error
            tideLocation.Zone = -1;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationZone, "0", "10000")).Any());
            Assert.AreEqual(-1, tideLocation.Zone);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Max should return true and no errors
            tideLocation.Zone = 10000;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(10000, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            tideLocation.Zone = 9999;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(9999, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Max + 1 should return false with one error
            tideLocation.Zone = 10001;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationZone, "0", "10000")).Any());
            Assert.AreEqual(10001, tideLocation.Zone);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            //-----------------------------------
            // doing property [Name] of type [String]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");

            //-----------------------------------
            // doing property [Prov] of type [String]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");

            //-----------------------------------
            // doing property [sid] of type [Int32]
            //-----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // sid has Min [0] and Max [100000]. At Min should return true and no errors
            tideLocation.sid = 0;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(0, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            tideLocation.sid = 1;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(1, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Min - 1 should return false with one error
            tideLocation.sid = -1;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationsid, "0", "100000")).Any());
            Assert.AreEqual(-1, tideLocation.sid);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Max should return true and no errors
            tideLocation.sid = 100000;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(100000, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            tideLocation.sid = 99999;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(99999, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(0, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Max + 1 should return false with one error
            tideLocation.sid = 100001;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationsid, "0", "100000")).Any());
            Assert.AreEqual(100001, tideLocation.sid);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            //-----------------------------------
            // doing property [Lat] of type [Single]
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
            // doing property [Lng] of type [Single]
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

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
