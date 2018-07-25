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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ClimateDataValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.DateTime_Local = new DateTime();
                    climateDataValueService.Add(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateDataValueDateTime_Local), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.DateTime_Local = new DateTime(1979, 1, 1);
                    climateDataValueService.Add(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateDataValueDateTime_Local, "1980"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    // Is NOT Nullable
                    // climateDataValue.HasBeenRead   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // climateDataValue.Snow_cm   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Snow_cm]

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
                    // Is Nullable
                    // [NotMapped]
                    // climateDataValue.ClimateDataValueWeb   (ClimateDataValueWeb)
                    // -----------------------------------

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.ClimateDataValueWeb = null;
                    Assert.IsNull(climateDataValue.ClimateDataValueWeb);

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.ClimateDataValueWeb = new ClimateDataValueWeb();
                    Assert.IsNotNull(climateDataValue.ClimateDataValueWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // climateDataValue.ClimateDataValueReport   (ClimateDataValueReport)
                    // -----------------------------------

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.ClimateDataValueReport = null;
                    Assert.IsNull(climateDataValue.ClimateDataValueReport);

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.ClimateDataValueReport = new ClimateDataValueReport();
                    Assert.IsNotNull(climateDataValue.ClimateDataValueReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // climateDataValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.LastUpdateDate_UTC = new DateTime();
                    climateDataValueService.Add(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateDataValueLastUpdateDate_UTC), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    climateDataValue = null;
                    climateDataValue = GetFilledRandomClimateDataValue("");
                    climateDataValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    climateDataValueService.Add(climateDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateDataValueLastUpdateDate_UTC, "1980"), climateDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    // Is NOT Nullable
                    // [NotMapped]
                    // climateDataValue.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // climateDataValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetClimateDataValueWithClimateDataValueID(climateDataValue.ClimateDataValueID)
        [TestMethod]
        public void GetClimateDataValueWithClimateDataValueID__climateDataValue_ClimateDataValueID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ClimateDataValue climateDataValue = (from c in climateDataValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(climateDataValue);

                    ClimateDataValue climateDataValueRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        climateDataValueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateDataValueRet = climateDataValueService.GetClimateDataValueWithClimateDataValueID(climateDataValue.ClimateDataValueID);
                            Assert.IsNull(climateDataValueRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateDataValueRet = climateDataValueService.GetClimateDataValueWithClimateDataValueID(climateDataValue.ClimateDataValueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateDataValueRet = climateDataValueService.GetClimateDataValueWithClimateDataValueID(climateDataValue.ClimateDataValueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateDataValueRet = climateDataValueService.GetClimateDataValueWithClimateDataValueID(climateDataValue.ClimateDataValueID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateDataValueFields(new List<ClimateDataValue>() { climateDataValueRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateDataValueWithClimateDataValueID(climateDataValue.ClimateDataValueID)

        #region Tests Generated for GetClimateDataValueList()
        [TestMethod]
        public void GetClimateDataValueList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ClimateDataValue climateDataValue = (from c in climateDataValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(climateDataValue);

                    List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        climateDataValueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                            Assert.AreEqual(0, climateDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateDataValueFields(climateDataValueList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateDataValueList()

        #region Tests Generated for GetClimateDataValueList() Skip Take
        [TestMethod]
        public void GetClimateDataValueList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                    List<ClimateDataValue> climateDataValueDirectQueryList = new List<ClimateDataValue>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateDataValueDirectQueryList = climateDataValueService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                            Assert.AreEqual(0, climateDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateDataValueFields(climateDataValueList, entityQueryDetailType);
                        Assert.AreEqual(climateDataValueDirectQueryList[0].ClimateDataValueID, climateDataValueList[0].ClimateDataValueID);
                        Assert.AreEqual(1, climateDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateDataValueList() Skip Take

        #region Tests Generated for GetClimateDataValueList() Skip Take Order
        [TestMethod]
        public void GetClimateDataValueList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                    List<ClimateDataValue> climateDataValueDirectQueryList = new List<ClimateDataValue>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), culture.TwoLetterISOLanguageName, 1, 1,  "ClimateDataValueID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateDataValueDirectQueryList = climateDataValueService.GetRead().Skip(1).Take(1).OrderBy(c => c.ClimateDataValueID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                            Assert.AreEqual(0, climateDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateDataValueFields(climateDataValueList, entityQueryDetailType);
                        Assert.AreEqual(climateDataValueDirectQueryList[0].ClimateDataValueID, climateDataValueList[0].ClimateDataValueID);
                        Assert.AreEqual(1, climateDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateDataValueList() Skip Take Order

        #region Tests Generated for GetClimateDataValueList() Skip Take 2Order
        [TestMethod]
        public void GetClimateDataValueList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                    List<ClimateDataValue> climateDataValueDirectQueryList = new List<ClimateDataValue>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), culture.TwoLetterISOLanguageName, 1, 1, "ClimateDataValueID,ClimateSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateDataValueDirectQueryList = climateDataValueService.GetRead().Skip(1).Take(1).OrderBy(c => c.ClimateDataValueID).ThenBy(c => c.ClimateSiteID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                            Assert.AreEqual(0, climateDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateDataValueFields(climateDataValueList, entityQueryDetailType);
                        Assert.AreEqual(climateDataValueDirectQueryList[0].ClimateDataValueID, climateDataValueList[0].ClimateDataValueID);
                        Assert.AreEqual(1, climateDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateDataValueList() Skip Take 2Order

        #region Tests Generated for GetClimateDataValueList() Skip Take Order Where
        [TestMethod]
        public void GetClimateDataValueList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                    List<ClimateDataValue> climateDataValueDirectQueryList = new List<ClimateDataValue>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), culture.TwoLetterISOLanguageName, 0, 1, "ClimateDataValueID", "ClimateDataValueID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateDataValueDirectQueryList = climateDataValueService.GetRead().Where(c => c.ClimateDataValueID == 4).Skip(0).Take(1).OrderBy(c => c.ClimateDataValueID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                            Assert.AreEqual(0, climateDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateDataValueFields(climateDataValueList, entityQueryDetailType);
                        Assert.AreEqual(climateDataValueDirectQueryList[0].ClimateDataValueID, climateDataValueList[0].ClimateDataValueID);
                        Assert.AreEqual(1, climateDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateDataValueList() Skip Take Order Where

        #region Tests Generated for GetClimateDataValueList() Skip Take Order 2Where
        [TestMethod]
        public void GetClimateDataValueList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                    List<ClimateDataValue> climateDataValueDirectQueryList = new List<ClimateDataValue>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), culture.TwoLetterISOLanguageName, 0, 1, "ClimateDataValueID", "ClimateDataValueID,GT,2|ClimateDataValueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateDataValueDirectQueryList = climateDataValueService.GetRead().Where(c => c.ClimateDataValueID > 2 && c.ClimateDataValueID < 5).Skip(0).Take(1).OrderBy(c => c.ClimateDataValueID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                            Assert.AreEqual(0, climateDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateDataValueFields(climateDataValueList, entityQueryDetailType);
                        Assert.AreEqual(climateDataValueDirectQueryList[0].ClimateDataValueID, climateDataValueList[0].ClimateDataValueID);
                        Assert.AreEqual(1, climateDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateDataValueList() Skip Take Order 2Where

        #region Tests Generated for GetClimateDataValueList() 2Where
        [TestMethod]
        public void GetClimateDataValueList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                    List<ClimateDataValue> climateDataValueDirectQueryList = new List<ClimateDataValue>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ClimateDataValueService climateDataValueService = new ClimateDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        climateDataValueService.Query = climateDataValueService.FillQuery(typeof(ClimateDataValue), culture.TwoLetterISOLanguageName, 0, 10000, "", "ClimateDataValueID,GT,2|ClimateDataValueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        climateDataValueDirectQueryList = climateDataValueService.GetRead().Where(c => c.ClimateDataValueID > 2 && c.ClimateDataValueID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                            Assert.AreEqual(0, climateDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            climateDataValueList = climateDataValueService.GetClimateDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckClimateDataValueFields(climateDataValueList, entityQueryDetailType);
                        Assert.AreEqual(climateDataValueDirectQueryList[0].ClimateDataValueID, climateDataValueList[0].ClimateDataValueID);
                        Assert.AreEqual(2, climateDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetClimateDataValueList() 2Where

        #region Functions private
        private void CheckClimateDataValueFields(List<ClimateDataValue> climateDataValueList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // ClimateDataValue fields
            Assert.IsNotNull(climateDataValueList[0].ClimateDataValueID);
            Assert.IsNotNull(climateDataValueList[0].ClimateSiteID);
            Assert.IsNotNull(climateDataValueList[0].DateTime_Local);
            Assert.IsNotNull(climateDataValueList[0].Keep);
            Assert.IsNotNull(climateDataValueList[0].StorageDataType);
            Assert.IsNotNull(climateDataValueList[0].HasBeenRead);
            if (climateDataValueList[0].Snow_cm != null)
            {
                Assert.IsNotNull(climateDataValueList[0].Snow_cm);
            }
            if (climateDataValueList[0].Rainfall_mm != null)
            {
                Assert.IsNotNull(climateDataValueList[0].Rainfall_mm);
            }
            if (climateDataValueList[0].RainfallEntered_mm != null)
            {
                Assert.IsNotNull(climateDataValueList[0].RainfallEntered_mm);
            }
            if (climateDataValueList[0].TotalPrecip_mm_cm != null)
            {
                Assert.IsNotNull(climateDataValueList[0].TotalPrecip_mm_cm);
            }
            if (climateDataValueList[0].MaxTemp_C != null)
            {
                Assert.IsNotNull(climateDataValueList[0].MaxTemp_C);
            }
            if (climateDataValueList[0].MinTemp_C != null)
            {
                Assert.IsNotNull(climateDataValueList[0].MinTemp_C);
            }
            if (climateDataValueList[0].HeatDegDays_C != null)
            {
                Assert.IsNotNull(climateDataValueList[0].HeatDegDays_C);
            }
            if (climateDataValueList[0].CoolDegDays_C != null)
            {
                Assert.IsNotNull(climateDataValueList[0].CoolDegDays_C);
            }
            if (climateDataValueList[0].SnowOnGround_cm != null)
            {
                Assert.IsNotNull(climateDataValueList[0].SnowOnGround_cm);
            }
            if (climateDataValueList[0].DirMaxGust_0North != null)
            {
                Assert.IsNotNull(climateDataValueList[0].DirMaxGust_0North);
            }
            if (climateDataValueList[0].SpdMaxGust_kmh != null)
            {
                Assert.IsNotNull(climateDataValueList[0].SpdMaxGust_kmh);
            }
            if (!string.IsNullOrWhiteSpace(climateDataValueList[0].HourlyValues))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(climateDataValueList[0].HourlyValues));
            }
            Assert.IsNotNull(climateDataValueList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(climateDataValueList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // ClimateDataValueWeb and ClimateDataValueReport fields should be null here
                Assert.IsNull(climateDataValueList[0].ClimateDataValueWeb);
                Assert.IsNull(climateDataValueList[0].ClimateDataValueReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // ClimateDataValueWeb fields should not be null and ClimateDataValueReport fields should be null here
                if (!string.IsNullOrWhiteSpace(climateDataValueList[0].ClimateDataValueWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateDataValueList[0].ClimateDataValueWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(climateDataValueList[0].ClimateDataValueWeb.StorageDataTypeEnumText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateDataValueList[0].ClimateDataValueWeb.StorageDataTypeEnumText));
                }
                Assert.IsNull(climateDataValueList[0].ClimateDataValueReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // ClimateDataValueWeb and ClimateDataValueReport fields should NOT be null here
                if (climateDataValueList[0].ClimateDataValueWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateDataValueList[0].ClimateDataValueWeb.LastUpdateContactTVText));
                }
                if (climateDataValueList[0].ClimateDataValueWeb.StorageDataTypeEnumText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateDataValueList[0].ClimateDataValueWeb.StorageDataTypeEnumText));
                }
                if (climateDataValueList[0].ClimateDataValueReport.ClimateDataValueReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(climateDataValueList[0].ClimateDataValueReport.ClimateDataValueReportTest));
                }
            }
        }
        private ClimateDataValue GetFilledRandomClimateDataValue(string OmitPropName)
        {
            ClimateDataValue climateDataValue = new ClimateDataValue();

            if (OmitPropName != "ClimateSiteID") climateDataValue.ClimateSiteID = 1;
            if (OmitPropName != "DateTime_Local") climateDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") climateDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") climateDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "HasBeenRead") climateDataValue.HasBeenRead = true;
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

            return climateDataValue;
        }
        #endregion Functions private
    }
}
