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
        private int ClimateSiteID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateSiteTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ClimateSite GetFilledRandomClimateSite(string OmitPropName)
        {
            ClimateSiteID += 1;

            ClimateSite climateSite = new ClimateSite();

            if (OmitPropName != "ClimateSiteID") climateSite.ClimateSiteID = ClimateSiteID;
            if (OmitPropName != "ClimateSiteTVItemID") climateSite.ClimateSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "ECDBID") climateSite.ECDBID = GetRandomInt(1, 11);
            if (OmitPropName != "ClimateSiteName") climateSite.ClimateSiteName = GetRandomString("", 5);
            if (OmitPropName != "Province") climateSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") climateSite.Elevation_m = GetRandomDouble(1.0f, 1000.0f);
            if (OmitPropName != "ClimateID") climateSite.ClimateID = GetRandomString("", 5);
            if (OmitPropName != "WMOID") climateSite.WMOID = GetRandomInt(1, 1000000);
            if (OmitPropName != "TCID") climateSite.TCID = GetRandomString("", 3);
            if (OmitPropName != "IsProvincial") climateSite.IsProvincial = true;
            if (OmitPropName != "ProvSiteID") climateSite.ProvSiteID = GetRandomString("", 5);
            if (OmitPropName != "TimeOffset_hour") climateSite.TimeOffset_hour = GetRandomDouble(1.0f, 1000.0f);
            if (OmitPropName != "File_desc") climateSite.File_desc = GetRandomString("", 5);
            if (OmitPropName != "HourlyStartDate_Local") climateSite.HourlyStartDate_Local = GetRandomDateTime();
            if (OmitPropName != "HourlyEndDate_Local") climateSite.HourlyEndDate_Local = GetRandomDateTime();
            if (OmitPropName != "HourlyNow") climateSite.HourlyNow = true;
            if (OmitPropName != "DailyStartDate_Local") climateSite.DailyStartDate_Local = GetRandomDateTime();
            if (OmitPropName != "DailyEndDate_Local") climateSite.DailyEndDate_Local = GetRandomDateTime();
            if (OmitPropName != "DailyNow") climateSite.DailyNow = true;
            if (OmitPropName != "MonthlyStartDate_Local") climateSite.MonthlyStartDate_Local = GetRandomDateTime();
            if (OmitPropName != "MonthlyEndDate_Local") climateSite.MonthlyEndDate_Local = GetRandomDateTime();
            if (OmitPropName != "MonthlyNow") climateSite.MonthlyNow = true;
            if (OmitPropName != "LastUpdateDate_UTC") climateSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") climateSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return climateSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ClimateSite_Testing()
        {
            SetupTestHelper(culture);
            ClimateSiteService climateSiteService = new ClimateSiteService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            ClimateSite climateSite = GetFilledRandomClimateSite("");
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(true, climateSiteService.GetRead().Where(c => c == climateSite).Any());
            climateSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, climateSiteService.Update(climateSite));
            Assert.AreEqual(1, climateSiteService.GetRead().Count());
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // ClimateSiteTVItemID will automatically be initialized at 0 --> not null

            // ECDBID will automatically be initialized at 0 --> not null

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("ClimateSiteName");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteName)).Any());
            Assert.AreEqual(null, climateSite.ClimateSiteName);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("Province");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteProvince)).Any());
            Assert.AreEqual(null, climateSite.Province);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //Error: Type not implemented [Elevation_m]

            //Error: Type not implemented [TimeOffset_hour]

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("LastUpdateDate_UTC");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteLastUpdateDate_UTC)).Any());
            Assert.IsTrue(climateSite.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ClimateSiteID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClimateSiteTVItemID] of type [int]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // ClimateSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            climateSite.ClimateSiteTVItemID = 1;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1, climateSite.ClimateSiteTVItemID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // ClimateSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            climateSite.ClimateSiteTVItemID = 2;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(2, climateSite.ClimateSiteTVItemID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // ClimateSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            climateSite.ClimateSiteTVItemID = 0;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateSiteClimateSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, climateSite.ClimateSiteTVItemID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [ECDBID] of type [int]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // ECDBID has Min [1] and Max [empty]. At Min should return true and no errors
            climateSite.ECDBID = 1;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            climateSite.ECDBID = 2;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(2, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            climateSite.ECDBID = 0;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateSiteECDBID, "1")).Any());
            Assert.AreEqual(0, climateSite.ECDBID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [ClimateSiteName] of type [string]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            // ClimateSiteName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string climateSiteClimateSiteNameMin = GetRandomString("", 100);
            climateSite.ClimateSiteName = climateSiteClimateSiteNameMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteClimateSiteNameMin, climateSite.ClimateSiteName);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // ClimateSiteName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            climateSiteClimateSiteNameMin = GetRandomString("", 99);
            climateSite.ClimateSiteName = climateSiteClimateSiteNameMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteClimateSiteNameMin, climateSite.ClimateSiteName);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // ClimateSiteName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            climateSiteClimateSiteNameMin = GetRandomString("", 101);
            climateSite.ClimateSiteName = climateSiteClimateSiteNameMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateSiteName, "100")).Any());
            Assert.AreEqual(climateSiteClimateSiteNameMin, climateSite.ClimateSiteName);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [Province] of type [string]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            // Province has MinLength [empty] and MaxLength [4]. At Max should return true and no errors
            string climateSiteProvinceMin = GetRandomString("", 4);
            climateSite.Province = climateSiteProvinceMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteProvinceMin, climateSite.Province);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // Province has MinLength [empty] and MaxLength [4]. At Max - 1 should return true and no errors
            climateSiteProvinceMin = GetRandomString("", 3);
            climateSite.Province = climateSiteProvinceMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteProvinceMin, climateSite.Province);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // Province has MinLength [empty] and MaxLength [4]. At Max + 1 should return false with one error
            climateSiteProvinceMin = GetRandomString("", 5);
            climateSite.Province = climateSiteProvinceMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvince, "4")).Any());
            Assert.AreEqual(climateSiteProvinceMin, climateSite.Province);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [Elevation_m] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClimateID] of type [string]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            // ClimateID has MinLength [empty] and MaxLength [10]. At Max should return true and no errors
            string climateSiteClimateIDMin = GetRandomString("", 10);
            climateSite.ClimateID = climateSiteClimateIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteClimateIDMin, climateSite.ClimateID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // ClimateID has MinLength [empty] and MaxLength [10]. At Max - 1 should return true and no errors
            climateSiteClimateIDMin = GetRandomString("", 9);
            climateSite.ClimateID = climateSiteClimateIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteClimateIDMin, climateSite.ClimateID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // ClimateID has MinLength [empty] and MaxLength [10]. At Max + 1 should return false with one error
            climateSiteClimateIDMin = GetRandomString("", 11);
            climateSite.ClimateID = climateSiteClimateIDMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateID, "10")).Any());
            Assert.AreEqual(climateSiteClimateIDMin, climateSite.ClimateID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [WMOID] of type [int]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // WMOID has Min [1] and Max [1000000]. At Min should return true and no errors
            climateSite.WMOID = 1;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [1000000]. At Min + 1 should return true and no errors
            climateSite.WMOID = 2;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(2, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [1000000]. At Min - 1 should return false with one error
            climateSite.WMOID = 0;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "1000000")).Any());
            Assert.AreEqual(0, climateSite.WMOID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [1000000]. At Max should return true and no errors
            climateSite.WMOID = 1000000;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1000000, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [1000000]. At Max - 1 should return true and no errors
            climateSite.WMOID = 999999;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(999999, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [1000000]. At Max + 1 should return false with one error
            climateSite.WMOID = 1000001;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "1000000")).Any());
            Assert.AreEqual(1000001, climateSite.WMOID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [TCID] of type [string]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            // TCID has MinLength [empty] and MaxLength [3]. At Max should return true and no errors
            string climateSiteTCIDMin = GetRandomString("", 3);
            climateSite.TCID = climateSiteTCIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteTCIDMin, climateSite.TCID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // TCID has MinLength [empty] and MaxLength [3]. At Max - 1 should return true and no errors
            climateSiteTCIDMin = GetRandomString("", 2);
            climateSite.TCID = climateSiteTCIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteTCIDMin, climateSite.TCID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // TCID has MinLength [empty] and MaxLength [3]. At Max + 1 should return false with one error
            climateSiteTCIDMin = GetRandomString("", 4);
            climateSite.TCID = climateSiteTCIDMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteTCID, "3")).Any());
            Assert.AreEqual(climateSiteTCIDMin, climateSite.TCID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [IsProvincial] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [ProvSiteID] of type [string]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            // ProvSiteID has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string climateSiteProvSiteIDMin = GetRandomString("", 50);
            climateSite.ProvSiteID = climateSiteProvSiteIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteProvSiteIDMin, climateSite.ProvSiteID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // ProvSiteID has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            climateSiteProvSiteIDMin = GetRandomString("", 49);
            climateSite.ProvSiteID = climateSiteProvSiteIDMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteProvSiteIDMin, climateSite.ProvSiteID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // ProvSiteID has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            climateSiteProvSiteIDMin = GetRandomString("", 51);
            climateSite.ProvSiteID = climateSiteProvSiteIDMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvSiteID, "50")).Any());
            Assert.AreEqual(climateSiteProvSiteIDMin, climateSite.ProvSiteID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [TimeOffset_hour] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [File_desc] of type [string]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            // File_desc has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string climateSiteFile_descMin = GetRandomString("", 50);
            climateSite.File_desc = climateSiteFile_descMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteFile_descMin, climateSite.File_desc);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // File_desc has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            climateSiteFile_descMin = GetRandomString("", 49);
            climateSite.File_desc = climateSiteFile_descMin;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(climateSiteFile_descMin, climateSite.File_desc);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // File_desc has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            climateSiteFile_descMin = GetRandomString("", 51);
            climateSite.File_desc = climateSiteFile_descMin;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteFile_desc, "50")).Any());
            Assert.AreEqual(climateSiteFile_descMin, climateSite.File_desc);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [HourlyStartDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [HourlyEndDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [HourlyNow] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyStartDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyEndDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyNow] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [MonthlyStartDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [MonthlyEndDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [MonthlyNow] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            climateSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1, climateSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            climateSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(2, climateSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            climateSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, climateSite.LastUpdateContactTVItemID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
