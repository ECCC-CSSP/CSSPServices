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
    public partial class ClimateDataValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ClimateDataValueService climateDataValueService { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateDataValueServiceTest() : base()
        {
            //climateDataValueService = new ClimateDataValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ClimateDataValue GetFilledRandomClimateDataValue(string OmitPropName)
        {
            ClimateDataValue climateDataValue = new ClimateDataValue();

            if (OmitPropName != "ClimateSiteID") climateDataValue.ClimateSiteID = 1;
            if (OmitPropName != "DateTime_Local") climateDataValue.DateTime_Local = new DateTime(2005, 3, 6);
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
            if (OmitPropName != "LastUpdateDate_UTC") climateDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") climateDataValue.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") climateDataValue.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "StorageDataTypeEnumText") climateDataValue.StorageDataTypeEnumText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") climateDataValue.HasErrors = true;

            return climateDataValue;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ClimateDataValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClimateDataValueService climateDataValueService = new ClimateDataValueService(LanguageRequest, dbTestDB, ContactID);

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

                    Assert.AreEqual(climateDataValueService.GetRead().Count(), climateDataValueService.GetEdit().Count());

                    climateDataValueService.Add(climateDataValue);
                    if (climateDataValue.HasErrors)
                    {
                        Assert.AreEqual("", climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, climateDataValueService.GetRead().Where(c => c == climateDataValue).Any());
                    climateDataValueService.Update(climateDataValue);
                    if (climateDataValue.HasErrors)
                    {
                        Assert.AreEqual("", climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, climateDataValueService.GetRead().Count());
                    climateDataValueService.Delete(climateDataValue);
                    if (climateDataValue.HasErrors)
                    {
                        Assert.AreEqual("", climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // climateDataValue.ClimateDataValueID   (Int32)
                    // -----------------------------------

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.ClimateDataValueID = 0;
                    climateDataValueService.Update(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateDataValueClimateDataValueID), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.ClimateDataValueID = 10000000;
                    climateDataValueService.Update(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ClimateDataValue, CSSPModelsRes.ClimateDataValueClimateDataValueID, climateDataValue.ClimateDataValueID.ToString()), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "ClimateSite", ExistPlurial = "s", ExistFieldID = "ClimateSiteID", AllowableTVtypeList = Error)]
                    // climateDataValue.ClimateSiteID   (Int32)
                    // -----------------------------------

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.ClimateSiteID = 0;
                    climateDataValueService.Add(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ClimateSite, CSSPModelsRes.ClimateDataValueClimateSiteID, climateDataValue.ClimateSiteID.ToString()), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateDataValue.DateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // climateDataValue.Keep   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // climateDataValue.StorageDataType   (StorageDataTypeEnum)
                    // -----------------------------------

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.StorageDataType = (StorageDataTypeEnum)1000000;
                    climateDataValueService.Add(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateDataValueStorageDataType), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // climateDataValue.Snow_cm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Snow_cm]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.Snow_cm = -1.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueSnow_cm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.Snow_cm = 10001.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueSnow_cm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // climateDataValue.Rainfall_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Rainfall_mm]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.Rainfall_mm = -1.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueRainfall_mm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.Rainfall_mm = 10001.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueRainfall_mm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // climateDataValue.RainfallEntered_mm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RainfallEntered_mm]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.RainfallEntered_mm = -1.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueRainfallEntered_mm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.RainfallEntered_mm = 10001.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueRainfallEntered_mm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // climateDataValue.TotalPrecip_mm_cm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TotalPrecip_mm_cm]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.TotalPrecip_mm_cm = -1.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueTotalPrecip_mm_cm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.TotalPrecip_mm_cm = 10001.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueTotalPrecip_mm_cm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-50, 50)]
                    // climateDataValue.MaxTemp_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [MaxTemp_C]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.MaxTemp_C = -51.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueMaxTemp_C, "-50", "50"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.MaxTemp_C = 51.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueMaxTemp_C, "-50", "50"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-50, 50)]
                    // climateDataValue.MinTemp_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [MinTemp_C]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.MinTemp_C = -51.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueMinTemp_C, "-50", "50"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.MinTemp_C = 51.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueMinTemp_C, "-50", "50"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-1000, 100)]
                    // climateDataValue.HeatDegDays_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [HeatDegDays_C]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.HeatDegDays_C = -1001.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueHeatDegDays_C, "-1000", "100"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.HeatDegDays_C = 101.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueHeatDegDays_C, "-1000", "100"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-1000, 100)]
                    // climateDataValue.CoolDegDays_C   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [CoolDegDays_C]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.CoolDegDays_C = -1001.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueCoolDegDays_C, "-1000", "100"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.CoolDegDays_C = 101.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueCoolDegDays_C, "-1000", "100"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // climateDataValue.SnowOnGround_cm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SnowOnGround_cm]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.SnowOnGround_cm = -1.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueSnowOnGround_cm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.SnowOnGround_cm = 10001.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueSnowOnGround_cm, "0", "10000"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 360)]
                    // climateDataValue.DirMaxGust_0North   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DirMaxGust_0North]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.DirMaxGust_0North = -1.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueDirMaxGust_0North, "0", "360"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.DirMaxGust_0North = 361.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueDirMaxGust_0North, "0", "360"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 300)]
                    // climateDataValue.SpdMaxGust_kmh   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [SpdMaxGust_kmh]

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.SpdMaxGust_kmh = -1.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueSpdMaxGust_kmh, "0", "300"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.SpdMaxGust_kmh = 301.0D;
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueSpdMaxGust_kmh, "0", "300"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // climateDataValue.HourlyValues   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateDataValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // climateDataValue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.LastUpdateContactTVItemID = 0;
                    climateDataValueService.Add(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClimateDataValueLastUpdateContactTVItemID, climateDataValue.LastUpdateContactTVItemID.ToString()), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.LastUpdateContactTVItemID = 1;
                    climateDataValueService.Add(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClimateDataValueLastUpdateContactTVItemID, "Contact"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // climateDataValue.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateDataValueLastUpdateContactTVText, "200"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // climateDataValue.StorageDataTypeEnumText   (String)
                    // -----------------------------------

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.StorageDataTypeEnumText = GetRandomString("", 101);
                    Assert.AreEqual(false, climateDataValueService.Add(climateDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateDataValueStorageDataTypeEnumText, "100"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, climateDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // climateDataValue.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // climateDataValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ClimateDataValue_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClimateDataValueService climateDataValueService = new ClimateDataValueService(LanguageRequest, dbTestDB, ContactID);
                    ClimateDataValue climateDataValue = (from c in climateDataValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(climateDataValue);

                    ClimateDataValue climateDataValueRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityIncludingNotMapped })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            climateDataValueRet = climateDataValueService.GetClimateDataValueWithClimateDataValueID(climateDataValue.ClimateDataValueID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateDataValueRet = climateDataValueService.GetClimateDataValueWithClimateDataValueID(climateDataValue.ClimateDataValueID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityIncludingNotMapped)
                        {
                            climateDataValueRet = climateDataValueService.GetClimateDataValueWithClimateDataValueID(climateDataValue.ClimateDataValueID, EntityQueryDetailTypeEnum.EntityIncludingNotMapped);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(climateDataValueRet.ClimateDataValueID);
                        Assert.IsNotNull(climateDataValueRet.ClimateSiteID);
                        Assert.IsNotNull(climateDataValueRet.DateTime_Local);
                        Assert.IsNotNull(climateDataValueRet.Keep);
                        Assert.IsNotNull(climateDataValueRet.StorageDataType);
                        if (climateDataValueRet.Snow_cm != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.Snow_cm);
                        }
                        if (climateDataValueRet.Rainfall_mm != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.Rainfall_mm);
                        }
                        if (climateDataValueRet.RainfallEntered_mm != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.RainfallEntered_mm);
                        }
                        if (climateDataValueRet.TotalPrecip_mm_cm != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.TotalPrecip_mm_cm);
                        }
                        if (climateDataValueRet.MaxTemp_C != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.MaxTemp_C);
                        }
                        if (climateDataValueRet.MinTemp_C != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.MinTemp_C);
                        }
                        if (climateDataValueRet.HeatDegDays_C != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.HeatDegDays_C);
                        }
                        if (climateDataValueRet.CoolDegDays_C != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.CoolDegDays_C);
                        }
                        if (climateDataValueRet.SnowOnGround_cm != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.SnowOnGround_cm);
                        }
                        if (climateDataValueRet.DirMaxGust_0North != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.DirMaxGust_0North);
                        }
                        if (climateDataValueRet.SpdMaxGust_kmh != null)
                        {
                            Assert.IsNotNull(climateDataValueRet.SpdMaxGust_kmh);
                        }
                        if (climateDataValueRet.HourlyValues != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(climateDataValueRet.HourlyValues));
                        }
                        Assert.IsNotNull(climateDataValueRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(climateDataValueRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (climateDataValueRet.LastUpdateContactTVText != null)
                            {
                                Assert.IsTrue(string.IsNullOrWhiteSpace(climateDataValueRet.LastUpdateContactTVText));
                            }
                            if (climateDataValueRet.StorageDataTypeEnumText != null)
                            {
                                Assert.IsTrue(string.IsNullOrWhiteSpace(climateDataValueRet.StorageDataTypeEnumText));
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityIncludingNotMapped)
                        {
                            if (climateDataValueRet.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(climateDataValueRet.LastUpdateContactTVText));
                            }
                            if (climateDataValueRet.StorageDataTypeEnumText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(climateDataValueRet.StorageDataTypeEnumText));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of ClimateDataValue
        #endregion Tests Get List of ClimateDataValue

    }
}
