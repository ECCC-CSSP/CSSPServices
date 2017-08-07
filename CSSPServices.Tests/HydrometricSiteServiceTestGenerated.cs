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
    public partial class HydrometricSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private HydrometricSiteService hydrometricSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteServiceTest() : base()
        {
            //hydrometricSiteService = new HydrometricSiteService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "StartDate_Local") hydrometricSite.StartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate_Local") hydrometricSite.EndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "TimeOffset_hour") hydrometricSite.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "DrainageArea_km2") hydrometricSite.DrainageArea_km2 = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "IsNatural") hydrometricSite.IsNatural = true;
            if (OmitPropName != "IsActive") hydrometricSite.IsActive = true;
            if (OmitPropName != "Sediment") hydrometricSite.Sediment = true;
            if (OmitPropName != "RHBN") hydrometricSite.RHBN = true;
            if (OmitPropName != "RealTime") hydrometricSite.RealTime = true;
            if (OmitPropName != "HasRatingCurve") hydrometricSite.HasRatingCurve = true;
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricSite.LastUpdateContactTVItemID = 2;

            return hydrometricSite;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void HydrometricSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(LanguageRequest, dbTestDB, ContactID);

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

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.HydrometricSiteID = 0;
                hydrometricSiteService.Update(hydrometricSite);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteHydrometricSiteID), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = HydrometricSite)]
                // hydrometricSite.HydrometricSiteTVItemID   (Int32)
                // -----------------------------------

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.HydrometricSiteTVItemID = 0;
                hydrometricSiteService.Add(hydrometricSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.HydrometricSiteHydrometricSiteTVItemID, hydrometricSite.HydrometricSiteTVItemID.ToString()), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.HydrometricSiteTVItemID = 1;
                hydrometricSiteService.Add(hydrometricSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.HydrometricSiteHydrometricSiteTVItemID, "HydrometricSite"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [StringLength(7))]
                // hydrometricSite.FedSiteNumber   (String)
                // -----------------------------------

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.FedSiteNumber = GetRandomString("", 8);
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteFedSiteNumber, "7"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [StringLength(7))]
                // hydrometricSite.QuebecSiteNumber   (String)
                // -----------------------------------

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.QuebecSiteNumber = GetRandomString("", 8);
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteQuebecSiteNumber, "7"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.HydrometricSiteName = GetRandomString("", 201);
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteHydrometricSiteName, "200"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [StringLength(200))]
                // hydrometricSite.Description   (String)
                // -----------------------------------

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.Description = GetRandomString("", 201);
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteDescription, "200"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.Province = GetRandomString("", 5);
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteProvince, "4"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 10000)]
                // hydrometricSite.Elevation_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [Elevation_m]

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.Elevation_m = -1.0D;
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteElevation_m, "0", "10000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.Elevation_m = 10001.0D;
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteElevation_m, "0", "10000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                hydrometricSite.TimeOffset_hour = -11.0D;
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteTimeOffset_hour, "-10", "0"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.TimeOffset_hour = 1.0D;
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteTimeOffset_hour, "-10", "0"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 1000000)]
                // hydrometricSite.DrainageArea_km2   (Double)
                // -----------------------------------

                //Error: Type not implemented [DrainageArea_km2]

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.DrainageArea_km2 = -1.0D;
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteDrainageArea_km2, "0", "1000000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, hydrometricSiteService.GetRead().Count());
                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.DrainageArea_km2 = 1000001.0D;
                Assert.AreEqual(false, hydrometricSiteService.Add(hydrometricSite));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteDrainageArea_km2, "0", "1000000"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);
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


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // hydrometricSite.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.LastUpdateContactTVItemID = 0;
                hydrometricSiteService.Add(hydrometricSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.HydrometricSiteLastUpdateContactTVItemID, hydrometricSite.LastUpdateContactTVItemID.ToString()), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);

                hydrometricSite = null;
                hydrometricSite = GetFilledRandomHydrometricSite("");
                hydrometricSite.LastUpdateContactTVItemID = 1;
                hydrometricSiteService.Add(hydrometricSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.HydrometricSiteLastUpdateContactTVItemID, "Contact"), hydrometricSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // hydrometricSite.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void HydrometricSite_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(LanguageRequest, dbTestDB, ContactID);

                HydrometricSite hydrometricSite = (from c in hydrometricSiteService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(hydrometricSite);

                HydrometricSite hydrometricSiteRet = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteID(hydrometricSite.HydrometricSiteID);
                Assert.AreEqual(hydrometricSite.HydrometricSiteID, hydrometricSiteRet.HydrometricSiteID);
            }
        }
        #endregion Tests Get With Key

    }
}
