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
        private TideLocationService tideLocationService { get; set; }
        #endregion Properties

        #region Constructors
        public TideLocationTest() : base()
        {
            tideLocationService = new TideLocationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideLocation GetFilledRandomTideLocation(string OmitPropName)
        {
            TideLocation tideLocation = new TideLocation();

            if (OmitPropName != "Zone") tideLocation.Zone = GetRandomInt(0, 10000);
            if (OmitPropName != "Name") tideLocation.Name = GetRandomString("", 5);
            if (OmitPropName != "Prov") tideLocation.Prov = GetRandomString("", 5);
            if (OmitPropName != "sid") tideLocation.sid = GetRandomInt(0, 100000);
            if (OmitPropName != "Lat") tideLocation.Lat = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Lng") tideLocation.Lng = GetRandomDouble(-180.0D, 180.0D);

            return tideLocation;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TideLocation_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TideLocation tideLocation = GetFilledRandomTideLocation("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tideLocationService.GetRead().Count();

            tideLocationService.Add(tideLocation);
            if (tideLocation.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tideLocationService.GetRead().Where(c => c == tideLocation).Any());
            tideLocationService.Update(tideLocation);
            if (tideLocation.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tideLocationService.GetRead().Count());
            tideLocationService.Delete(tideLocation);
            if (tideLocation.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tideLocation.TideLocationID   (Int32)
            // -----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            tideLocation.TideLocationID = 0;
            tideLocationService.Update(tideLocation);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TideLocationTideLocationID), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000)]
            // tideLocation.Zone   (Int32)
            // -----------------------------------

            // Zone will automatically be initialized at 0 --> not null

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // Zone has Min [0] and Max [10000]. At Min should return true and no errors
            tideLocation.Zone = 0;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(0, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            tideLocation.Zone = 1;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(1, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Min - 1 should return false with one error
            tideLocation.Zone = -1;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationZone, "0", "10000")).Any());
            Assert.AreEqual(-1, tideLocation.Zone);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Max should return true and no errors
            tideLocation.Zone = 10000;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(10000, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            tideLocation.Zone = 9999;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(9999, tideLocation.Zone);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Zone has Min [0] and Max [10000]. At Max + 1 should return false with one error
            tideLocation.Zone = 10001;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationZone, "0", "10000")).Any());
            Assert.AreEqual(10001, tideLocation.Zone);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // tideLocation.Name   (String)
            // -----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("Name");
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.AreEqual(1, tideLocation.ValidationResults.Count());
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideLocationName)).Any());
            Assert.AreEqual(null, tideLocation.Name);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // Name has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string tideLocationNameMin = GetRandomString("", 100);
            tideLocation.Name = tideLocationNameMin;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(tideLocationNameMin, tideLocation.Name);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // Name has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            tideLocationNameMin = GetRandomString("", 99);
            tideLocation.Name = tideLocationNameMin;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(tideLocationNameMin, tideLocation.Name);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // Name has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            tideLocationNameMin = GetRandomString("", 101);
            tideLocation.Name = tideLocationNameMin;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideLocationName, "100")).Any());
            Assert.AreEqual(tideLocationNameMin, tideLocation.Name);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // tideLocation.Prov   (String)
            // -----------------------------------

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("Prov");
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.AreEqual(1, tideLocation.ValidationResults.Count());
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideLocationProv)).Any());
            Assert.AreEqual(null, tideLocation.Prov);
            Assert.AreEqual(0, tideLocationService.GetRead().Count());

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // Prov has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string tideLocationProvMin = GetRandomString("", 100);
            tideLocation.Prov = tideLocationProvMin;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(tideLocationProvMin, tideLocation.Prov);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // Prov has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            tideLocationProvMin = GetRandomString("", 99);
            tideLocation.Prov = tideLocationProvMin;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(tideLocationProvMin, tideLocation.Prov);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // Prov has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            tideLocationProvMin = GetRandomString("", 101);
            tideLocation.Prov = tideLocationProvMin;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideLocationProv, "100")).Any());
            Assert.AreEqual(tideLocationProvMin, tideLocation.Prov);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100000)]
            // tideLocation.sid   (Int32)
            // -----------------------------------

            // sid will automatically be initialized at 0 --> not null

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // sid has Min [0] and Max [100000]. At Min should return true and no errors
            tideLocation.sid = 0;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(0, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            tideLocation.sid = 1;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(1, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Min - 1 should return false with one error
            tideLocation.sid = -1;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationsid, "0", "100000")).Any());
            Assert.AreEqual(-1, tideLocation.sid);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Max should return true and no errors
            tideLocation.sid = 100000;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(100000, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            tideLocation.sid = 99999;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(99999, tideLocation.sid);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // sid has Min [0] and Max [100000]. At Max + 1 should return false with one error
            tideLocation.sid = 100001;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationsid, "0", "100000")).Any());
            Assert.AreEqual(100001, tideLocation.sid);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-90, 90)]
            // tideLocation.Lat   (Double)
            // -----------------------------------

            //Error: Type not implemented [Lat]

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // Lat has Min [-90.0D] and Max [90.0D]. At Min should return true and no errors
            tideLocation.Lat = -90.0D;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(-90.0D, tideLocation.Lat);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Min + 1 should return true and no errors
            tideLocation.Lat = -89.0D;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(-89.0D, tideLocation.Lat);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Min - 1 should return false with one error
            tideLocation.Lat = -91.0D;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLat, "-90", "90")).Any());
            Assert.AreEqual(-91.0D, tideLocation.Lat);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Max should return true and no errors
            tideLocation.Lat = 90.0D;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(90.0D, tideLocation.Lat);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Max - 1 should return true and no errors
            tideLocation.Lat = 89.0D;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(89.0D, tideLocation.Lat);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Max + 1 should return false with one error
            tideLocation.Lat = 91.0D;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLat, "-90", "90")).Any());
            Assert.AreEqual(91.0D, tideLocation.Lat);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-180, 180)]
            // tideLocation.Lng   (Double)
            // -----------------------------------

            //Error: Type not implemented [Lng]

            tideLocation = null;
            tideLocation = GetFilledRandomTideLocation("");
            // Lng has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            tideLocation.Lng = -180.0D;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(-180.0D, tideLocation.Lng);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            tideLocation.Lng = -179.0D;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(-179.0D, tideLocation.Lng);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            tideLocation.Lng = -181.0D;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLng, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, tideLocation.Lng);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            tideLocation.Lng = 180.0D;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(180.0D, tideLocation.Lng);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            tideLocation.Lng = 179.0D;
            Assert.AreEqual(true, tideLocationService.Add(tideLocation));
            Assert.AreEqual(0, tideLocation.ValidationResults.Count());
            Assert.AreEqual(179.0D, tideLocation.Lng);
            Assert.AreEqual(true, tideLocationService.Delete(tideLocation));
            Assert.AreEqual(count, tideLocationService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            tideLocation.Lng = 181.0D;
            Assert.AreEqual(false, tideLocationService.Add(tideLocation));
            Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLng, "-180", "180")).Any());
            Assert.AreEqual(181.0D, tideLocation.Lng);
            Assert.AreEqual(count, tideLocationService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tideLocation.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
