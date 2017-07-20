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
    public partial class ClimateDataValueTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int ClimateDataValueID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateDataValueTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ClimateDataValue GetFilledRandomClimateDataValue(string OmitPropName)
        {
            ClimateDataValueID += 1;

            ClimateDataValue climateDataValue = new ClimateDataValue();

            if (OmitPropName != "ClimateDataValueID") climateDataValue.ClimateDataValueID = ClimateDataValueID;
            if (OmitPropName != "ClimateSiteID") climateDataValue.ClimateSiteID = GetRandomInt(1, 11);
            if (OmitPropName != "DateTime_Local") climateDataValue.DateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Keep") climateDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") climateDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Snow_cm") climateDataValue.Snow_cm = GetRandomFloat(0.0f, 10000.0f);
            if (OmitPropName != "Rainfall_mm") climateDataValue.Rainfall_mm = GetRandomFloat(0.0f, 10000.0f);
            if (OmitPropName != "RainfallEntered_mm") climateDataValue.RainfallEntered_mm = GetRandomFloat(0.0f, 10000.0f);
            if (OmitPropName != "TotalPrecip_mm_cm") climateDataValue.TotalPrecip_mm_cm = GetRandomFloat(0.0f, 10000.0f);
            if (OmitPropName != "MaxTemp_C") climateDataValue.MaxTemp_C = GetRandomFloat(-50.0f, 50.0f);
            if (OmitPropName != "MinTemp_C") climateDataValue.MinTemp_C = GetRandomFloat(-50.0f, 50.0f);
            if (OmitPropName != "HeatDegDays_C") climateDataValue.HeatDegDays_C = GetRandomFloat(-1000.0f, 100.0f);
            if (OmitPropName != "CoolDegDays_C") climateDataValue.CoolDegDays_C = GetRandomFloat(-1000.0f, 100.0f);
            if (OmitPropName != "SnowOnGround_cm") climateDataValue.SnowOnGround_cm = GetRandomFloat(0.0f, 10000.0f);
            if (OmitPropName != "DirMaxGust_0North") climateDataValue.DirMaxGust_0North = GetRandomFloat(0.0f, 360.0f);
            if (OmitPropName != "SpdMaxGust_kmh") climateDataValue.SpdMaxGust_kmh = GetRandomFloat(0.0f, 300.0f);
            if (OmitPropName != "HourlyValues") climateDataValue.HourlyValues = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") climateDataValue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") climateDataValue.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return climateDataValue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ClimateDataValue_Testing()
        {
            SetupTestHelper(culture);
            ClimateDataValueService climateDataValueService = new ClimateDataValueService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            ClimateDataValue climateDataValue = GetFilledRandomClimateDataValue("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(true, climateDataValueService.GetRead().Where(c => c == climateDataValue).Any());
            climateDataValue.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, climateDataValueService.Update(climateDataValue));
            Assert.AreEqual(1, climateDataValueService.GetRead().Count());
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // ClimateSiteID will automatically be initialized at 0 --> not null

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("DateTime_Local");
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(1, climateDataValue.ValidationResults.Count());
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueDateTime_Local)).Any());
            Assert.IsTrue(climateDataValue.DateTime_Local.Year < 1900);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            // Keep will automatically be initialized at 0 --> not null

            //Error: Type not implemented [StorageDataType]

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("HourlyValues");
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(1, climateDataValue.ValidationResults.Count());
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueHourlyValues)).Any());
            Assert.AreEqual(null, climateDataValue.HourlyValues);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("LastUpdateDate_UTC");
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(1, climateDataValue.ValidationResults.Count());
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueLastUpdateDate_UTC)).Any());
            Assert.IsTrue(climateDataValue.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [ClimateSite]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ClimateDataValueID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClimateSiteID] of type [Int32]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // ClimateSiteID has Min [1] and Max [empty]. At Min should return true and no errors
            climateDataValue.ClimateSiteID = 1;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1, climateDataValue.ClimateSiteID);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // ClimateSiteID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            climateDataValue.ClimateSiteID = 2;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(2, climateDataValue.ClimateSiteID);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // ClimateSiteID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            climateDataValue.ClimateSiteID = 0;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateDataValueClimateSiteID, "1")).Any());
            Assert.AreEqual(0, climateDataValue.ClimateSiteID);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [DateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Keep] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [StorageDataType] of type [StorageDataTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Snow_cm] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // Snow_cm has Min [0] and Max [10000]. At Min should return true and no errors
            climateDataValue.Snow_cm = 0.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, climateDataValue.Snow_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            climateDataValue.Snow_cm = 1.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, climateDataValue.Snow_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0] and Max [10000]. At Min - 1 should return false with one error
            climateDataValue.Snow_cm = -1.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnow_cm, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, climateDataValue.Snow_cm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0] and Max [10000]. At Max should return true and no errors
            climateDataValue.Snow_cm = 10000.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0f, climateDataValue.Snow_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            climateDataValue.Snow_cm = 9999.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0f, climateDataValue.Snow_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0] and Max [10000]. At Max + 1 should return false with one error
            climateDataValue.Snow_cm = 10001.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnow_cm, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, climateDataValue.Snow_cm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [Rainfall_mm] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // Rainfall_mm has Min [0] and Max [10000]. At Min should return true and no errors
            climateDataValue.Rainfall_mm = 0.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, climateDataValue.Rainfall_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            climateDataValue.Rainfall_mm = 1.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, climateDataValue.Rainfall_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0] and Max [10000]. At Min - 1 should return false with one error
            climateDataValue.Rainfall_mm = -1.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfall_mm, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, climateDataValue.Rainfall_mm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0] and Max [10000]. At Max should return true and no errors
            climateDataValue.Rainfall_mm = 10000.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0f, climateDataValue.Rainfall_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            climateDataValue.Rainfall_mm = 9999.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0f, climateDataValue.Rainfall_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0] and Max [10000]. At Max + 1 should return false with one error
            climateDataValue.Rainfall_mm = 10001.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfall_mm, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, climateDataValue.Rainfall_mm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [RainfallEntered_mm] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // RainfallEntered_mm has Min [0] and Max [10000]. At Min should return true and no errors
            climateDataValue.RainfallEntered_mm = 0.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            climateDataValue.RainfallEntered_mm = 1.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0] and Max [10000]. At Min - 1 should return false with one error
            climateDataValue.RainfallEntered_mm = -1.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfallEntered_mm, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0] and Max [10000]. At Max should return true and no errors
            climateDataValue.RainfallEntered_mm = 10000.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0f, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            climateDataValue.RainfallEntered_mm = 9999.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0f, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0] and Max [10000]. At Max + 1 should return false with one error
            climateDataValue.RainfallEntered_mm = 10001.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfallEntered_mm, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [TotalPrecip_mm_cm] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // TotalPrecip_mm_cm has Min [0] and Max [10000]. At Min should return true and no errors
            climateDataValue.TotalPrecip_mm_cm = 0.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            climateDataValue.TotalPrecip_mm_cm = 1.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0] and Max [10000]. At Min - 1 should return false with one error
            climateDataValue.TotalPrecip_mm_cm = -1.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueTotalPrecip_mm_cm, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0] and Max [10000]. At Max should return true and no errors
            climateDataValue.TotalPrecip_mm_cm = 10000.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0f, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            climateDataValue.TotalPrecip_mm_cm = 9999.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0f, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0] and Max [10000]. At Max + 1 should return false with one error
            climateDataValue.TotalPrecip_mm_cm = 10001.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueTotalPrecip_mm_cm, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [MaxTemp_C] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // MaxTemp_C has Min [-50] and Max [50]. At Min should return true and no errors
            climateDataValue.MaxTemp_C = -50.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-50.0f, climateDataValue.MaxTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50] and Max [50]. At Min + 1 should return true and no errors
            climateDataValue.MaxTemp_C = -49.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-49.0f, climateDataValue.MaxTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50] and Max [50]. At Min - 1 should return false with one error
            climateDataValue.MaxTemp_C = -51.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMaxTemp_C, "-50", "50")).Any());
            Assert.AreEqual(-51.0f, climateDataValue.MaxTemp_C);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50] and Max [50]. At Max should return true and no errors
            climateDataValue.MaxTemp_C = 50.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(50.0f, climateDataValue.MaxTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50] and Max [50]. At Max - 1 should return true and no errors
            climateDataValue.MaxTemp_C = 49.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(49.0f, climateDataValue.MaxTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50] and Max [50]. At Max + 1 should return false with one error
            climateDataValue.MaxTemp_C = 51.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMaxTemp_C, "-50", "50")).Any());
            Assert.AreEqual(51.0f, climateDataValue.MaxTemp_C);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [MinTemp_C] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // MinTemp_C has Min [-50] and Max [50]. At Min should return true and no errors
            climateDataValue.MinTemp_C = -50.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-50.0f, climateDataValue.MinTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50] and Max [50]. At Min + 1 should return true and no errors
            climateDataValue.MinTemp_C = -49.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-49.0f, climateDataValue.MinTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50] and Max [50]. At Min - 1 should return false with one error
            climateDataValue.MinTemp_C = -51.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMinTemp_C, "-50", "50")).Any());
            Assert.AreEqual(-51.0f, climateDataValue.MinTemp_C);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50] and Max [50]. At Max should return true and no errors
            climateDataValue.MinTemp_C = 50.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(50.0f, climateDataValue.MinTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50] and Max [50]. At Max - 1 should return true and no errors
            climateDataValue.MinTemp_C = 49.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(49.0f, climateDataValue.MinTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50] and Max [50]. At Max + 1 should return false with one error
            climateDataValue.MinTemp_C = 51.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMinTemp_C, "-50", "50")).Any());
            Assert.AreEqual(51.0f, climateDataValue.MinTemp_C);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [HeatDegDays_C] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // HeatDegDays_C has Min [-1000] and Max [100]. At Min should return true and no errors
            climateDataValue.HeatDegDays_C = -1000.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-1000.0f, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000] and Max [100]. At Min + 1 should return true and no errors
            climateDataValue.HeatDegDays_C = -999.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-999.0f, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000] and Max [100]. At Min - 1 should return false with one error
            climateDataValue.HeatDegDays_C = -1001.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueHeatDegDays_C, "-1000", "100")).Any());
            Assert.AreEqual(-1001.0f, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000] and Max [100]. At Max should return true and no errors
            climateDataValue.HeatDegDays_C = 100.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(100.0f, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000] and Max [100]. At Max - 1 should return true and no errors
            climateDataValue.HeatDegDays_C = 99.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(99.0f, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000] and Max [100]. At Max + 1 should return false with one error
            climateDataValue.HeatDegDays_C = 101.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueHeatDegDays_C, "-1000", "100")).Any());
            Assert.AreEqual(101.0f, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [CoolDegDays_C] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // CoolDegDays_C has Min [-1000] and Max [100]. At Min should return true and no errors
            climateDataValue.CoolDegDays_C = -1000.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-1000.0f, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000] and Max [100]. At Min + 1 should return true and no errors
            climateDataValue.CoolDegDays_C = -999.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-999.0f, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000] and Max [100]. At Min - 1 should return false with one error
            climateDataValue.CoolDegDays_C = -1001.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueCoolDegDays_C, "-1000", "100")).Any());
            Assert.AreEqual(-1001.0f, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000] and Max [100]. At Max should return true and no errors
            climateDataValue.CoolDegDays_C = 100.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(100.0f, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000] and Max [100]. At Max - 1 should return true and no errors
            climateDataValue.CoolDegDays_C = 99.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(99.0f, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000] and Max [100]. At Max + 1 should return false with one error
            climateDataValue.CoolDegDays_C = 101.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueCoolDegDays_C, "-1000", "100")).Any());
            Assert.AreEqual(101.0f, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [SnowOnGround_cm] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // SnowOnGround_cm has Min [0] and Max [10000]. At Min should return true and no errors
            climateDataValue.SnowOnGround_cm = 0.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0] and Max [10000]. At Min + 1 should return true and no errors
            climateDataValue.SnowOnGround_cm = 1.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0] and Max [10000]. At Min - 1 should return false with one error
            climateDataValue.SnowOnGround_cm = -1.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnowOnGround_cm, "0", "10000")).Any());
            Assert.AreEqual(-1.0f, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0] and Max [10000]. At Max should return true and no errors
            climateDataValue.SnowOnGround_cm = 10000.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0f, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0] and Max [10000]. At Max - 1 should return true and no errors
            climateDataValue.SnowOnGround_cm = 9999.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0f, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0] and Max [10000]. At Max + 1 should return false with one error
            climateDataValue.SnowOnGround_cm = 10001.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnowOnGround_cm, "0", "10000")).Any());
            Assert.AreEqual(10001.0f, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [DirMaxGust_0North] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // DirMaxGust_0North has Min [0] and Max [360]. At Min should return true and no errors
            climateDataValue.DirMaxGust_0North = 0.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0] and Max [360]. At Min + 1 should return true and no errors
            climateDataValue.DirMaxGust_0North = 1.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0] and Max [360]. At Min - 1 should return false with one error
            climateDataValue.DirMaxGust_0North = -1.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueDirMaxGust_0North, "0", "360")).Any());
            Assert.AreEqual(-1.0f, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0] and Max [360]. At Max should return true and no errors
            climateDataValue.DirMaxGust_0North = 360.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(360.0f, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0] and Max [360]. At Max - 1 should return true and no errors
            climateDataValue.DirMaxGust_0North = 359.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(359.0f, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0] and Max [360]. At Max + 1 should return false with one error
            climateDataValue.DirMaxGust_0North = 361.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueDirMaxGust_0North, "0", "360")).Any());
            Assert.AreEqual(361.0f, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [SpdMaxGust_kmh] of type [Single]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // SpdMaxGust_kmh has Min [0] and Max [300]. At Min should return true and no errors
            climateDataValue.SpdMaxGust_kmh = 0.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0] and Max [300]. At Min + 1 should return true and no errors
            climateDataValue.SpdMaxGust_kmh = 1.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0] and Max [300]. At Min - 1 should return false with one error
            climateDataValue.SpdMaxGust_kmh = -1.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSpdMaxGust_kmh, "0", "300")).Any());
            Assert.AreEqual(-1.0f, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0] and Max [300]. At Max should return true and no errors
            climateDataValue.SpdMaxGust_kmh = 300.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(300.0f, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0] and Max [300]. At Max - 1 should return true and no errors
            climateDataValue.SpdMaxGust_kmh = 299.0f;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(299.0f, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0] and Max [300]. At Max + 1 should return false with one error
            climateDataValue.SpdMaxGust_kmh = 301.0f;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSpdMaxGust_kmh, "0", "300")).Any());
            Assert.AreEqual(301.0f, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [HourlyValues] of type [String]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            climateDataValue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1, climateDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            climateDataValue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(2, climateDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            climateDataValue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateDataValueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, climateDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [ClimateSite] of type [ClimateSite]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
