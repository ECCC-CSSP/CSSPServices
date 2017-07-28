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
    public partial class ClimateSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ClimateSiteService climateSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateSiteTest() : base()
        {
            climateSiteService = new ClimateSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ClimateSite GetFilledRandomClimateSite(string OmitPropName)
        {
            ClimateSite climateSite = new ClimateSite();

            if (OmitPropName != "ClimateSiteTVItemID") climateSite.ClimateSiteTVItemID = 7;
            if (OmitPropName != "ECDBID") climateSite.ECDBID = GetRandomInt(1, 100000);
            if (OmitPropName != "ClimateSiteName") climateSite.ClimateSiteName = GetRandomString("", 5);
            if (OmitPropName != "Province") climateSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") climateSite.Elevation_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "ClimateID") climateSite.ClimateID = GetRandomString("", 5);
            if (OmitPropName != "WMOID") climateSite.WMOID = GetRandomInt(1, 100000);
            if (OmitPropName != "TCID") climateSite.TCID = GetRandomString("", 3);
            if (OmitPropName != "IsProvincial") climateSite.IsProvincial = true;
            if (OmitPropName != "ProvSiteID") climateSite.ProvSiteID = GetRandomString("", 5);
            if (OmitPropName != "TimeOffset_hour") climateSite.TimeOffset_hour = GetRandomDouble(-10.0D, 0.0D);
            if (OmitPropName != "File_desc") climateSite.File_desc = GetRandomString("", 5);
            if (OmitPropName != "HourlyStartDate_Local") climateSite.HourlyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "HourlyEndDate_Local") climateSite.HourlyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "HourlyNow") climateSite.HourlyNow = true;
            if (OmitPropName != "DailyStartDate_Local") climateSite.DailyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "DailyEndDate_Local") climateSite.DailyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "DailyNow") climateSite.DailyNow = true;
            if (OmitPropName != "MonthlyStartDate_Local") climateSite.MonthlyStartDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "MonthlyEndDate_Local") climateSite.MonthlyEndDate_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "MonthlyNow") climateSite.MonthlyNow = true;
            if (OmitPropName != "LastUpdateDate_UTC") climateSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") climateSite.LastUpdateContactTVItemID = 2;

            return climateSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ClimateSite_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            ClimateSite climateSite = GetFilledRandomClimateSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = climateSiteService.GetRead().Count();

            climateSiteService.Add(climateSite);
            if (climateSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, climateSiteService.GetRead().Where(c => c == climateSite).Any());
            climateSiteService.Update(climateSite);
            if (climateSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, climateSiteService.GetRead().Count());
            climateSiteService.Delete(climateSite);
            if (climateSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", climateSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // climateSite.ClimateSiteID   (Int32)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            climateSite.ClimateSiteID = 0;
            climateSiteService.Update(climateSite);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteID), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.ClimateSite)]
            // climateSite.ClimateSiteTVItemID   (Int32)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            climateSite.ClimateSiteTVItemID = 0;
            climateSiteService.Add(climateSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ClimateSiteClimateSiteTVItemID, climateSite.ClimateSiteTVItemID.ToString()), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // ClimateSiteTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(1, 100000)]
            // climateSite.ECDBID   (Int32)
            // -----------------------------------

            // ECDBID will automatically be initialized at 0 --> not null

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // ECDBID has Min [1] and Max [100000]. At Min should return true and no errors
            climateSite.ECDBID = 1;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Min + 1 should return true and no errors
            climateSite.ECDBID = 2;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(2, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Min - 1 should return false with one error
            climateSite.ECDBID = 0;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteECDBID, "1", "100000")).Any());
            Assert.AreEqual(0, climateSite.ECDBID);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Max should return true and no errors
            climateSite.ECDBID = 100000;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(100000, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Max - 1 should return true and no errors
            climateSite.ECDBID = 99999;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(99999, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Max + 1 should return false with one error
            climateSite.ECDBID = 100001;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteECDBID, "1", "100000")).Any());
            Assert.AreEqual(100001, climateSite.ECDBID);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // climateSite.ClimateSiteName   (String)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("ClimateSiteName");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteName)).Any());
            Assert.AreEqual(null, climateSite.ClimateSiteName);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // ClimateSiteName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string climateSiteClimateSiteNameMin = GetRandomString("", 100);
            climateSite.ClimateSiteName = climateSiteClimateSiteNameMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteClimateSiteNameMin, climateSite.ClimateSiteName);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // ClimateSiteName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            climateSiteClimateSiteNameMin = GetRandomString("", 99);
            climateSite.ClimateSiteName = climateSiteClimateSiteNameMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteClimateSiteNameMin, climateSite.ClimateSiteName);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // ClimateSiteName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            climateSiteClimateSiteNameMin = GetRandomString("", 101);
            climateSite.ClimateSiteName = climateSiteClimateSiteNameMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateSiteName, "100")).Any());
            Assert.AreEqual(climateSiteClimateSiteNameMin, climateSite.ClimateSiteName);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(4))]
            // climateSite.Province   (String)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("Province");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteProvince)).Any());
            Assert.AreEqual(null, climateSite.Province);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // Province has MinLength [empty] and MaxLength [4]. At Max should return true and no errors
            string climateSiteProvinceMin = GetRandomString("", 4);
            climateSite.Province = climateSiteProvinceMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteProvinceMin, climateSite.Province);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // Province has MinLength [empty] and MaxLength [4]. At Max - 1 should return true and no errors
            climateSiteProvinceMin = GetRandomString("", 3);
            climateSite.Province = climateSiteProvinceMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteProvinceMin, climateSite.Province);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // Province has MinLength [empty] and MaxLength [4]. At Max + 1 should return false with one error
            climateSiteProvinceMin = GetRandomString("", 5);
            climateSite.Province = climateSiteProvinceMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvince, "4")).Any());
            Assert.AreEqual(climateSiteProvinceMin, climateSite.Province);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 10000)]
            // climateSite.Elevation_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [Elevation_m]

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            climateSite.Elevation_m = 0.0D;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, climateSite.Elevation_m);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            climateSite.Elevation_m = 1.0D;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1.0D, climateSite.Elevation_m);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            climateSite.Elevation_m = -1.0D;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteElevation_m, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, climateSite.Elevation_m);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            climateSite.Elevation_m = 10000.0D;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(10000.0D, climateSite.Elevation_m);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            climateSite.Elevation_m = 9999.0D;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(9999.0D, climateSite.Elevation_m);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // Elevation_m has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            climateSite.Elevation_m = 10001.0D;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteElevation_m, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, climateSite.Elevation_m);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(10))]
            // climateSite.ClimateID   (String)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // ClimateID has MinLength [empty] and MaxLength [10]. At Max should return true and no errors
            string climateSiteClimateIDMin = GetRandomString("", 10);
            climateSite.ClimateID = climateSiteClimateIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteClimateIDMin, climateSite.ClimateID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // ClimateID has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            climateSiteClimateIDMin = GetRandomString("", 9);
            climateSite.ClimateID = climateSiteClimateIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteClimateIDMin, climateSite.ClimateID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // ClimateID has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            climateSiteClimateIDMin = GetRandomString("", 11);
            climateSite.ClimateID = climateSiteClimateIDMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateID, "10")).Any());
            Assert.AreEqual(climateSiteClimateIDMin, climateSite.ClimateID);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(1, 100000)]
            // climateSite.WMOID   (Int32)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // WMOID has Min [1] and Max [100000]. At Min should return true and no errors
            climateSite.WMOID = 1;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Min + 1 should return true and no errors
            climateSite.WMOID = 2;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(2, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Min - 1 should return false with one error
            climateSite.WMOID = 0;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "100000")).Any());
            Assert.AreEqual(0, climateSite.WMOID);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Max should return true and no errors
            climateSite.WMOID = 100000;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(100000, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Max - 1 should return true and no errors
            climateSite.WMOID = 99999;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(99999, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Max + 1 should return false with one error
            climateSite.WMOID = 100001;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "100000")).Any());
            Assert.AreEqual(100001, climateSite.WMOID);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(3))]
            // climateSite.TCID   (String)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // TCID has MinLength [empty] and MaxLength [3]. At Max should return true and no errors
            string climateSiteTCIDMin = GetRandomString("", 3);
            climateSite.TCID = climateSiteTCIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteTCIDMin, climateSite.TCID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // TCID has MinLength [empty] and MaxLength [3]. At Max - 1 should return true and no errors
            climateSiteTCIDMin = GetRandomString("", 2);
            climateSite.TCID = climateSiteTCIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteTCIDMin, climateSite.TCID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // TCID has MinLength [empty] and MaxLength [3]. At Max + 1 should return false with one error
            climateSiteTCIDMin = GetRandomString("", 4);
            climateSite.TCID = climateSiteTCIDMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteTCID, "3")).Any());
            Assert.AreEqual(climateSiteTCIDMin, climateSite.TCID);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // climateSite.IsProvincial   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [StringLength(50))]
            // climateSite.ProvSiteID   (String)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // ProvSiteID has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string climateSiteProvSiteIDMin = GetRandomString("", 50);
            climateSite.ProvSiteID = climateSiteProvSiteIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteProvSiteIDMin, climateSite.ProvSiteID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // ProvSiteID has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            climateSiteProvSiteIDMin = GetRandomString("", 49);
            climateSite.ProvSiteID = climateSiteProvSiteIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteProvSiteIDMin, climateSite.ProvSiteID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // ProvSiteID has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            climateSiteProvSiteIDMin = GetRandomString("", 51);
            climateSite.ProvSiteID = climateSiteProvSiteIDMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvSiteID, "50")).Any());
            Assert.AreEqual(climateSiteProvSiteIDMin, climateSite.ProvSiteID);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(-10, 0)]
            // climateSite.TimeOffset_hour   (Double)
            // -----------------------------------

            //Error: Type not implemented [TimeOffset_hour]

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Min should return true and no errors
            climateSite.TimeOffset_hour = -10.0D;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(-10.0D, climateSite.TimeOffset_hour);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Min + 1 should return true and no errors
            climateSite.TimeOffset_hour = -9.0D;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(-9.0D, climateSite.TimeOffset_hour);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Min - 1 should return false with one error
            climateSite.TimeOffset_hour = -11.0D;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteTimeOffset_hour, "-10", "0")).Any());
            Assert.AreEqual(-11.0D, climateSite.TimeOffset_hour);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Max should return true and no errors
            climateSite.TimeOffset_hour = 0.0D;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, climateSite.TimeOffset_hour);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Max - 1 should return true and no errors
            climateSite.TimeOffset_hour = -1.0D;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(-1.0D, climateSite.TimeOffset_hour);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());
            // TimeOffset_hour has Min [-10.0D] and Max [0.0D]. At Max + 1 should return false with one error
            climateSite.TimeOffset_hour = 1.0D;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteTimeOffset_hour, "-10", "0")).Any());
            Assert.AreEqual(1.0D, climateSite.TimeOffset_hour);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(50))]
            // climateSite.File_desc   (String)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // File_desc has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string climateSiteFile_descMin = GetRandomString("", 50);
            climateSite.File_desc = climateSiteFile_descMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteFile_descMin, climateSite.File_desc);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // File_desc has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            climateSiteFile_descMin = GetRandomString("", 49);
            climateSite.File_desc = climateSiteFile_descMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteFile_descMin, climateSite.File_desc);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // File_desc has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            climateSiteFile_descMin = GetRandomString("", 51);
            climateSite.File_desc = climateSiteFile_descMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteFile_desc, "50")).Any());
            Assert.AreEqual(climateSiteFile_descMin, climateSite.File_desc);
            Assert.AreEqual(count, climateSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // climateSite.HourlyStartDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // climateSite.HourlyEndDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // climateSite.HourlyNow   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // climateSite.DailyStartDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // climateSite.DailyEndDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // climateSite.DailyNow   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // climateSite.MonthlyStartDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // climateSite.MonthlyEndDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // climateSite.MonthlyNow   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // climateSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // climateSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            climateSite.LastUpdateContactTVItemID = 0;
            climateSiteService.Add(climateSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ClimateSiteLastUpdateContactTVItemID, climateSite.LastUpdateContactTVItemID.ToString()), climateSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // climateSite.ClimateDataValues   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // climateSite.ClimateSiteTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // climateSite.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
