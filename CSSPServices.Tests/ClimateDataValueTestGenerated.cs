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
            SetupTestHelper(LoginEmail, culture);
            ClimateDataValueService climateDataValueService = new ClimateDataValueService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            ClimateDataValue climateDataValue = GetFilledRandomClimateDataValue("");
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

            // Keep will automatically be initialized at false --> not null

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("StorageDataType");
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(1, climateDataValue.ValidationResults.Count());
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueStorageDataType)).Any());
            Assert.AreEqual(StorageDataTypeEnum.Error, climateDataValue.StorageDataType);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

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
            climateDataValue = GetFilledRandomClimateDataValue("LastUpdateDate_UTC");
            Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
            Assert.AreEqual(1, climateDataValue.ValidationResults.Count());
            Assert.IsTrue(climateDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueLastUpdateDate_UTC)).Any());
            Assert.IsTrue(climateDataValue.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, climateDataValueService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ClimateDataValueID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClimateSiteID] of type [int]
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
            // doing property [Keep] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [StorageDataType] of type [StorageDataTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Snow_cm] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Rainfall_mm] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RainfallEntered_mm] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TotalPrecip_mm_cm] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [MaxTemp_C] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [MinTemp_C] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [HeatDegDays_C] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [CoolDegDays_C] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SnowOnGround_cm] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [DirMaxGust_0North] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [SpdMaxGust_kmh] of type [double]
            //-----------------------------------

            //-----------------------------------
            // doing property [HourlyValues] of type [string]
            //-----------------------------------

            climateDataValue = null;
            climateDataValue = GetFilledRandomClimateDataValue("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
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

        }
        #endregion Tests Generated
    }
}
