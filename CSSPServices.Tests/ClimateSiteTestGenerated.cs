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
            if (OmitPropName != "ECDBID") climateSite.ECDBID = GetRandomInt(1, 100000);
            if (OmitPropName != "ClimateSiteName") climateSite.ClimateSiteName = GetRandomString("", 5);
            if (OmitPropName != "Province") climateSite.Province = GetRandomString("", 4);
            if (OmitPropName != "Elevation_m") climateSite.Elevation_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "ClimateID") climateSite.ClimateID = GetRandomString("", 5);
            if (OmitPropName != "WMOID") climateSite.WMOID = GetRandomInt(1, 100000);
            if (OmitPropName != "TCID") climateSite.TCID = GetRandomString("", 3);
            if (OmitPropName != "IsProvincial") climateSite.IsProvincial = true;
            if (OmitPropName != "ProvSiteID") climateSite.ProvSiteID = GetRandomString("", 5);
            if (OmitPropName != "TimeOffset_hour") climateSite.TimeOffset_hour = GetRandomDouble(1.0D, 1000.0D);
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
            ClimateSiteService climateSiteService = new ClimateSiteService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            ClimateSite climateSite = GetFilledRandomClimateSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

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

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("ClimateID");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateID)).Any());
            Assert.AreEqual(null, climateSite.ClimateID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("TCID");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteTCID)).Any());
            Assert.AreEqual(null, climateSite.TCID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("ProvSiteID");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteProvSiteID)).Any());
            Assert.AreEqual(null, climateSite.ProvSiteID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //Error: Type not implemented [TimeOffset_hour]

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("File_desc");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteFile_desc)).Any());
            Assert.AreEqual(null, climateSite.File_desc);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("LastUpdateDate_UTC");
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.AreEqual(1, climateSite.ValidationResults.Count());
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteLastUpdateDate_UTC)).Any());
            Assert.IsTrue(climateSite.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [ClimateDataValues]

            //Error: Type not implemented [ClimateSiteTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ClimateSiteID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClimateSiteTVItemID] of type [Int32]
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
            // doing property [ECDBID] of type [Int32]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // ECDBID has Min [1] and Max [100000]. At Min should return true and no errors
            climateSite.ECDBID = 1;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Min + 1 should return true and no errors
            climateSite.ECDBID = 2;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(2, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Min - 1 should return false with one error
            climateSite.ECDBID = 0;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteECDBID, "1", "100000")).Any());
            Assert.AreEqual(0, climateSite.ECDBID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Max should return true and no errors
            climateSite.ECDBID = 100000;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(100000, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Max - 1 should return true and no errors
            climateSite.ECDBID = 99999;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(99999, climateSite.ECDBID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // ECDBID has Min [1] and Max [100000]. At Max + 1 should return false with one error
            climateSite.ECDBID = 100001;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteECDBID, "1", "100000")).Any());
            Assert.AreEqual(100001, climateSite.ECDBID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [ClimateSiteName] of type [String]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            //-----------------------------------
            // doing property [Province] of type [String]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            //-----------------------------------
            // doing property [Elevation_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClimateID] of type [String]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            //-----------------------------------
            // doing property [WMOID] of type [Int32]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");
            // WMOID has Min [1] and Max [100000]. At Min should return true and no errors
            climateSite.WMOID = 1;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(1, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Min + 1 should return true and no errors
            climateSite.WMOID = 2;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(2, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Min - 1 should return false with one error
            climateSite.WMOID = 0;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "100000")).Any());
            Assert.AreEqual(0, climateSite.WMOID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Max should return true and no errors
            climateSite.WMOID = 100000;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(100000, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Max - 1 should return true and no errors
            climateSite.WMOID = 99999;
            Assert.AreEqual(true, climateSiteService.Add(climateSite));
            Assert.AreEqual(0, climateSite.ValidationResults.Count());
            Assert.AreEqual(99999, climateSite.WMOID);
            Assert.AreEqual(true, climateSiteService.Delete(climateSite));
            Assert.AreEqual(0, climateSiteService.GetRead().Count());
            // WMOID has Min [1] and Max [100000]. At Max + 1 should return false with one error
            climateSite.WMOID = 100001;
            Assert.AreEqual(false, climateSiteService.Add(climateSite));
            Assert.IsTrue(climateSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "100000")).Any());
            Assert.AreEqual(100001, climateSite.WMOID);
            Assert.AreEqual(0, climateSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [TCID] of type [String]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            //-----------------------------------
            // doing property [IsProvincial] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [ProvSiteID] of type [String]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            //-----------------------------------
            // doing property [TimeOffset_hour] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [File_desc] of type [String]
            //-----------------------------------

            climateSite = null;
            climateSite = GetFilledRandomClimateSite("");

            //-----------------------------------
            // doing property [HourlyStartDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [HourlyEndDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [HourlyNow] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyStartDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyEndDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [DailyNow] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [MonthlyStartDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [MonthlyEndDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [MonthlyNow] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [ClimateDataValues] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClimateSiteTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
