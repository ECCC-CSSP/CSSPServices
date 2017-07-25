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

            if (OmitPropName != "ClimateSiteID") climateDataValue.ClimateSiteID = GetRandomInt(1, 11);
            if (OmitPropName != "DateTime_Local") climateDataValue.DateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Keep") climateDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") climateDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Snow_cm") climateDataValue.Snow_cm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Rainfall_mm") climateDataValue.Rainfall_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RainfallEntered_mm") climateDataValue.RainfallEntered_mm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TotalPrecip_mm_cm") climateDataValue.TotalPrecip_mm_cm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "MaxTemp_C") climateDataValue.MaxTemp_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "MinTemp_C") climateDataValue.MinTemp_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "HeatDegDays_C") climateDataValue.HeatDegDays_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "CoolDegDays_C") climateDataValue.CoolDegDays_C = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SnowOnGround_cm") climateDataValue.SnowOnGround_cm = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "DirMaxGust_0North") climateDataValue.DirMaxGust_0North = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SpdMaxGust_kmh") climateDataValue.SpdMaxGust_kmh = GetRandomDouble(1.0D, 1000.0D);
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

            //Error: Type not implemented [Snow_cm]

            //Error: Type not implemented [Rainfall_mm]

            //Error: Type not implemented [RainfallEntered_mm]

            //Error: Type not implemented [TotalPrecip_mm_cm]

            //Error: Type not implemented [MaxTemp_C]

            //Error: Type not implemented [MinTemp_C]

            //Error: Type not implemented [HeatDegDays_C]

            //Error: Type not implemented [CoolDegDays_C]

            //Error: Type not implemented [SnowOnGround_cm]

            //Error: Type not implemented [DirMaxGust_0North]

            //Error: Type not implemented [SpdMaxGust_kmh]

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
            // doing property [Snow_cm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Rainfall_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainfallEntered_mm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TotalPrecip_mm_cm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [MaxTemp_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [MinTemp_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [HeatDegDays_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [CoolDegDays_C] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SnowOnGround_cm] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [DirMaxGust_0North] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SpdMaxGust_kmh] of type [Double]
            //-----------------------------------

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
