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
    public partial class TideLocationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TideLocationService tideLocationService { get; set; }
        #endregion Properties

        #region Constructors
        public TideLocationServiceTest() : base()
        {
            //tideLocationService = new TideLocationService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "HasErrors") tideLocation.HasErrors = true;

            return tideLocation;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TideLocation_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TideLocationService tideLocationService = new TideLocationService(LanguageRequest, dbTestDB, ContactID);

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

                Assert.AreEqual(tideLocationService.GetRead().Count(), tideLocationService.GetEdit().Count());

                tideLocationService.Add(tideLocation);
                if (tideLocation.HasErrors)
                {
                    Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, tideLocationService.GetRead().Where(c => c == tideLocation).Any());
                tideLocationService.Update(tideLocation);
                if (tideLocation.HasErrors)
                {
                    Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, tideLocationService.GetRead().Count());
                tideLocationService.Delete(tideLocation);
                if (tideLocation.HasErrors)
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

                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.TideLocationID = 10000000;
                tideLocationService.Update(tideLocation);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TideLocation, ModelsRes.TideLocationTideLocationID, tideLocation.TideLocationID.ToString()), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 10000)]
                // tideLocation.Zone   (Int32)
                // -----------------------------------

                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.Zone = -1;
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationZone, "0", "10000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tideLocationService.GetRead().Count());
                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.Zone = 10001;
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationZone, "0", "10000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, tideLocationService.GetRead().Count());

                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.Name = GetRandomString("", 101);
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideLocationName, "100"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, tideLocationService.GetRead().Count());

                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.Prov = GetRandomString("", 101);
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideLocationProv, "100"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tideLocationService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100000)]
                // tideLocation.sid   (Int32)
                // -----------------------------------

                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.sid = -1;
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationsid, "0", "100000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tideLocationService.GetRead().Count());
                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.sid = 100001;
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationsid, "0", "100000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tideLocationService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-90, 90)]
                // tideLocation.Lat   (Double)
                // -----------------------------------

                //Error: Type not implemented [Lat]

                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.Lat = -91.0D;
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLat, "-90", "90"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tideLocationService.GetRead().Count());
                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.Lat = 91.0D;
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLat, "-90", "90"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tideLocationService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-180, 180)]
                // tideLocation.Lng   (Double)
                // -----------------------------------

                //Error: Type not implemented [Lng]

                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.Lng = -181.0D;
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLng, "-180", "180"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tideLocationService.GetRead().Count());
                tideLocation = null;
                tideLocation = GetFilledRandomTideLocation("");
                tideLocation.Lng = 181.0D;
                Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLng, "-180", "180"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tideLocationService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // tideLocation.HasErrors   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // tideLocation.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TideLocation_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TideLocationService tideLocationService = new TideLocationService(LanguageRequest, dbTestDB, ContactID);
                TideLocation tideLocation = (from c in tideLocationService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(tideLocation);

                TideLocation tideLocationRet = tideLocationService.GetTideLocationWithTideLocationID(tideLocation.TideLocationID);
                Assert.IsNotNull(tideLocationRet.TideLocationID);
                Assert.IsNotNull(tideLocationRet.Zone);
                Assert.IsNotNull(tideLocationRet.Name);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationRet.Name));
                Assert.IsNotNull(tideLocationRet.Prov);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationRet.Prov));
                Assert.IsNotNull(tideLocationRet.sid);
                Assert.IsNotNull(tideLocationRet.Lat);
                Assert.IsNotNull(tideLocationRet.Lng);

                Assert.IsNotNull(tideLocationRet.HasErrors);
            }
        }
        #endregion Tests Get With Key

    }
}
