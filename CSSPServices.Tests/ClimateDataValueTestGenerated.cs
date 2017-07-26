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
        private ClimateDataValueService climateDataValueService { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateDataValueTest() : base()
        {
            climateDataValueService = new ClimateDataValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ClimateDataValue GetFilledRandomClimateDataValue(string OmitPropName)
        {
            ClimateDataValue climateDataValue = new ClimateDataValue();

            if (OmitPropName != "ClimateSiteID") climateDataValue.ClimateSiteID = 1;
            if (OmitPropName != "DateTime_Local") climateDataValue.DateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Keep") climateDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") climateDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Snow_cm") climateDataValue.Snow_cm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "Rainfall_mm") climateDataValue.Rainfall_mm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "RainfallEntered_mm") climateDataValue.RainfallEntered_mm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "TotalPrecip_mm_cm") climateDataValue.TotalPrecip_mm_cm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "MaxTemp_C") climateDataValue.MaxTemp_C = GetRandomDouble(-50.0D, 50.0D);
            if (OmitPropName != "MinTemp_C") climateDataValue.MinTemp_C = GetRandomDouble(-50.0D, 50.0D);
            if (OmitPropName != "HeatDegDays_C") climateDataValue.HeatDegDays_C = GetRandomDouble(-1000.0D, 100.0D);
            if (OmitPropName != "CoolDegDays_C") climateDataValue.CoolDegDays_C = GetRandomDouble(-1000.0D, 100.0D);
            if (OmitPropName != "SnowOnGround_cm") climateDataValue.SnowOnGround_cm = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "DirMaxGust_0North") climateDataValue.DirMaxGust_0North = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "SpdMaxGust_kmh") climateDataValue.SpdMaxGust_kmh = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "HourlyValues") climateDataValue.HourlyValues = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") climateDataValue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") climateDataValue.LastUpdateContactTVItemID = 2;

            return climateDataValue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ClimateDataValue_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            ClimateDataValue climateDataValue = GetFilledRandomClimateDataValue("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = climateDataValueService.GetRead().Count();

            climateDataValueService.Add(climateDataValue);
            if (climateDataValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, climateDataValueService.GetRead().Where(c => c == climateDataValue).Any());
            climateDataValueService.Update(climateDataValue);
            if (climateDataValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, climateDataValueService.GetRead().Count());
            climateDataValueService.Delete(climateDataValue);
            if (climateDataValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // climateDataValue.ClimateDataValueID   (Int32)
            //-----------------------------------
            climateDataValue = GetFilledRandomClimateDataValue("");
            climateDataValue.ClimateDataValueID = 0;
            climateDataValueService.Update(climateDataValue);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueClimateDataValueID), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "ClimateSite", Plurial = "s", FieldID = "ClimateSiteID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // climateDataValue.ClimateSiteID   (Int32)
            //-----------------------------------
            // ClimateSiteID will automatically be initialized at 0 --> not null


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // ClimateSiteID has Min [1] and Max [empty]. At Min should return true and no errors
            climateDataValue.ClimateSiteID = 1;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1, climateDataValue.ClimateSiteID);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // ClimateSiteID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            climateDataValue.ClimateSiteID = 2;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(2, climateDataValue.ClimateSiteID);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // ClimateSiteID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            climateDataValue.ClimateSiteID = 0;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateDataValueClimateSiteID, "1")).Any());
            Assert.AreEqual(0, climateDataValue.ClimateSiteID);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // climateDataValue.DateTime_Local   (DateTime)
            //-----------------------------------
            // DateTime_Local will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            // climateDataValue.Keep   (Boolean)
            //-----------------------------------
            // Keep will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // climateDataValue.StorageDataType   (StorageDataTypeEnum)
            //-----------------------------------
            // StorageDataType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is Nullable
            //[Range(0, 10000)]
            // climateDataValue.Snow_cm   (Double)
            //-----------------------------------
            //Error: Type not implemented [Snow_cm]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // Snow_cm has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            climateDataValue.Snow_cm = 0.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, climateDataValue.Snow_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            climateDataValue.Snow_cm = 1.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, climateDataValue.Snow_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            climateDataValue.Snow_cm = -1.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnow_cm, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, climateDataValue.Snow_cm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            climateDataValue.Snow_cm = 10000.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0D, climateDataValue.Snow_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            climateDataValue.Snow_cm = 9999.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0D, climateDataValue.Snow_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Snow_cm has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            climateDataValue.Snow_cm = 10001.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnow_cm, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, climateDataValue.Snow_cm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 10000)]
            // climateDataValue.Rainfall_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [Rainfall_mm]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // Rainfall_mm has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            climateDataValue.Rainfall_mm = 0.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, climateDataValue.Rainfall_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            climateDataValue.Rainfall_mm = 1.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, climateDataValue.Rainfall_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            climateDataValue.Rainfall_mm = -1.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfall_mm, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, climateDataValue.Rainfall_mm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            climateDataValue.Rainfall_mm = 10000.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0D, climateDataValue.Rainfall_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            climateDataValue.Rainfall_mm = 9999.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0D, climateDataValue.Rainfall_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // Rainfall_mm has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            climateDataValue.Rainfall_mm = 10001.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfall_mm, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, climateDataValue.Rainfall_mm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 10000)]
            // climateDataValue.RainfallEntered_mm   (Double)
            //-----------------------------------
            //Error: Type not implemented [RainfallEntered_mm]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // RainfallEntered_mm has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            climateDataValue.RainfallEntered_mm = 0.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            climateDataValue.RainfallEntered_mm = 1.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            climateDataValue.RainfallEntered_mm = -1.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfallEntered_mm, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            climateDataValue.RainfallEntered_mm = 10000.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0D, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            climateDataValue.RainfallEntered_mm = 9999.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0D, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // RainfallEntered_mm has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            climateDataValue.RainfallEntered_mm = 10001.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfallEntered_mm, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, climateDataValue.RainfallEntered_mm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 10000)]
            // climateDataValue.TotalPrecip_mm_cm   (Double)
            //-----------------------------------
            //Error: Type not implemented [TotalPrecip_mm_cm]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // TotalPrecip_mm_cm has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            climateDataValue.TotalPrecip_mm_cm = 0.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            climateDataValue.TotalPrecip_mm_cm = 1.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            climateDataValue.TotalPrecip_mm_cm = -1.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueTotalPrecip_mm_cm, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            climateDataValue.TotalPrecip_mm_cm = 10000.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0D, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            climateDataValue.TotalPrecip_mm_cm = 9999.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0D, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // TotalPrecip_mm_cm has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            climateDataValue.TotalPrecip_mm_cm = 10001.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueTotalPrecip_mm_cm, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, climateDataValue.TotalPrecip_mm_cm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-50, 50)]
            // climateDataValue.MaxTemp_C   (Double)
            //-----------------------------------
            //Error: Type not implemented [MaxTemp_C]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // MaxTemp_C has Min [-50.0D] and Max [50.0D]. At Min should return true and no errors
            climateDataValue.MaxTemp_C = -50.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-50.0D, climateDataValue.MaxTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50.0D] and Max [50.0D]. At Min + 1 should return true and no errors
            climateDataValue.MaxTemp_C = -49.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-49.0D, climateDataValue.MaxTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50.0D] and Max [50.0D]. At Min - 1 should return false with one error
            climateDataValue.MaxTemp_C = -51.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMaxTemp_C, "-50", "50")).Any());
            Assert.AreEqual(-51.0D, climateDataValue.MaxTemp_C);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50.0D] and Max [50.0D]. At Max should return true and no errors
            climateDataValue.MaxTemp_C = 50.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(50.0D, climateDataValue.MaxTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50.0D] and Max [50.0D]. At Max - 1 should return true and no errors
            climateDataValue.MaxTemp_C = 49.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(49.0D, climateDataValue.MaxTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MaxTemp_C has Min [-50.0D] and Max [50.0D]. At Max + 1 should return false with one error
            climateDataValue.MaxTemp_C = 51.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMaxTemp_C, "-50", "50")).Any());
            Assert.AreEqual(51.0D, climateDataValue.MaxTemp_C);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-50, 50)]
            // climateDataValue.MinTemp_C   (Double)
            //-----------------------------------
            //Error: Type not implemented [MinTemp_C]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // MinTemp_C has Min [-50.0D] and Max [50.0D]. At Min should return true and no errors
            climateDataValue.MinTemp_C = -50.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-50.0D, climateDataValue.MinTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50.0D] and Max [50.0D]. At Min + 1 should return true and no errors
            climateDataValue.MinTemp_C = -49.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-49.0D, climateDataValue.MinTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50.0D] and Max [50.0D]. At Min - 1 should return false with one error
            climateDataValue.MinTemp_C = -51.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMinTemp_C, "-50", "50")).Any());
            Assert.AreEqual(-51.0D, climateDataValue.MinTemp_C);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50.0D] and Max [50.0D]. At Max should return true and no errors
            climateDataValue.MinTemp_C = 50.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(50.0D, climateDataValue.MinTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50.0D] and Max [50.0D]. At Max - 1 should return true and no errors
            climateDataValue.MinTemp_C = 49.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(49.0D, climateDataValue.MinTemp_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // MinTemp_C has Min [-50.0D] and Max [50.0D]. At Max + 1 should return false with one error
            climateDataValue.MinTemp_C = 51.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMinTemp_C, "-50", "50")).Any());
            Assert.AreEqual(51.0D, climateDataValue.MinTemp_C);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-1000, 100)]
            // climateDataValue.HeatDegDays_C   (Double)
            //-----------------------------------
            //Error: Type not implemented [HeatDegDays_C]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // HeatDegDays_C has Min [-1000.0D] and Max [100.0D]. At Min should return true and no errors
            climateDataValue.HeatDegDays_C = -1000.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-1000.0D, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            climateDataValue.HeatDegDays_C = -999.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-999.0D, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000.0D] and Max [100.0D]. At Min - 1 should return false with one error
            climateDataValue.HeatDegDays_C = -1001.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueHeatDegDays_C, "-1000", "100")).Any());
            Assert.AreEqual(-1001.0D, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000.0D] and Max [100.0D]. At Max should return true and no errors
            climateDataValue.HeatDegDays_C = 100.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(100.0D, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            climateDataValue.HeatDegDays_C = 99.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(99.0D, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // HeatDegDays_C has Min [-1000.0D] and Max [100.0D]. At Max + 1 should return false with one error
            climateDataValue.HeatDegDays_C = 101.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueHeatDegDays_C, "-1000", "100")).Any());
            Assert.AreEqual(101.0D, climateDataValue.HeatDegDays_C);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(-1000, 100)]
            // climateDataValue.CoolDegDays_C   (Double)
            //-----------------------------------
            //Error: Type not implemented [CoolDegDays_C]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // CoolDegDays_C has Min [-1000.0D] and Max [100.0D]. At Min should return true and no errors
            climateDataValue.CoolDegDays_C = -1000.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-1000.0D, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            climateDataValue.CoolDegDays_C = -999.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(-999.0D, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000.0D] and Max [100.0D]. At Min - 1 should return false with one error
            climateDataValue.CoolDegDays_C = -1001.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueCoolDegDays_C, "-1000", "100")).Any());
            Assert.AreEqual(-1001.0D, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000.0D] and Max [100.0D]. At Max should return true and no errors
            climateDataValue.CoolDegDays_C = 100.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(100.0D, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            climateDataValue.CoolDegDays_C = 99.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(99.0D, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // CoolDegDays_C has Min [-1000.0D] and Max [100.0D]. At Max + 1 should return false with one error
            climateDataValue.CoolDegDays_C = 101.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueCoolDegDays_C, "-1000", "100")).Any());
            Assert.AreEqual(101.0D, climateDataValue.CoolDegDays_C);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 10000)]
            // climateDataValue.SnowOnGround_cm   (Double)
            //-----------------------------------
            //Error: Type not implemented [SnowOnGround_cm]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // SnowOnGround_cm has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            climateDataValue.SnowOnGround_cm = 0.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            climateDataValue.SnowOnGround_cm = 1.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            climateDataValue.SnowOnGround_cm = -1.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnowOnGround_cm, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            climateDataValue.SnowOnGround_cm = 10000.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0D, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            climateDataValue.SnowOnGround_cm = 9999.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0D, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SnowOnGround_cm has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            climateDataValue.SnowOnGround_cm = 10001.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnowOnGround_cm, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, climateDataValue.SnowOnGround_cm);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 360)]
            // climateDataValue.DirMaxGust_0North   (Double)
            //-----------------------------------
            //Error: Type not implemented [DirMaxGust_0North]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // DirMaxGust_0North has Min [0.0D] and Max [360.0D]. At Min should return true and no errors
            climateDataValue.DirMaxGust_0North = 0.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0.0D] and Max [360.0D]. At Min + 1 should return true and no errors
            climateDataValue.DirMaxGust_0North = 1.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0.0D] and Max [360.0D]. At Min - 1 should return false with one error
            climateDataValue.DirMaxGust_0North = -1.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueDirMaxGust_0North, "0", "360")).Any());
            Assert.AreEqual(-1.0D, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0.0D] and Max [360.0D]. At Max should return true and no errors
            climateDataValue.DirMaxGust_0North = 360.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(360.0D, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0.0D] and Max [360.0D]. At Max - 1 should return true and no errors
            climateDataValue.DirMaxGust_0North = 359.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(359.0D, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // DirMaxGust_0North has Min [0.0D] and Max [360.0D]. At Max + 1 should return false with one error
            climateDataValue.DirMaxGust_0North = 361.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueDirMaxGust_0North, "0", "360")).Any());
            Assert.AreEqual(361.0D, climateDataValue.DirMaxGust_0North);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[Range(0, 300)]
            // climateDataValue.SpdMaxGust_kmh   (Double)
            //-----------------------------------
            //Error: Type not implemented [SpdMaxGust_kmh]


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // SpdMaxGust_kmh has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            climateDataValue.SpdMaxGust_kmh = 0.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            climateDataValue.SpdMaxGust_kmh = 1.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            climateDataValue.SpdMaxGust_kmh = -1.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSpdMaxGust_kmh, "0", "300")).Any());
            Assert.AreEqual(-1.0D, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            climateDataValue.SpdMaxGust_kmh = 300.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(300.0D, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            climateDataValue.SpdMaxGust_kmh = 299.0D;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(299.0D, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // SpdMaxGust_kmh has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            climateDataValue.SpdMaxGust_kmh = 301.0D;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSpdMaxGust_kmh, "0", "300")).Any());
            Assert.AreEqual(301.0D, climateDataValue.SpdMaxGust_kmh);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            // climateDataValue.HourlyValues   (String)
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // climateDataValue.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // climateDataValue.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            climateDataValue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(1, climateDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            climateDataValue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(0, climateDataValue.ValidationResults.Count());
            Assert.AreEqual(2, climateDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, climateDataValueService.Delete(climateDataValue));
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            climateDataValue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateDataValueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, climateDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(count, climateDataValueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // climateDataValue.ClimateSite   (ClimateSite)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // climateDataValue.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
