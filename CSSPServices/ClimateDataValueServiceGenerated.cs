using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    /// <summary>
    ///     <para>bonjour ClimateDataValue</para>
    /// </summary>
    public partial class ClimateDataValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateDataValueService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ClimateDataValue climateDataValue = validationContext.ObjectInstance as ClimateDataValue;
            climateDataValue.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (climateDataValue.ClimateDataValueID == 0)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateDataValueClimateDataValueID), new[] { "ClimateDataValueID" });
                }

                if (!GetRead().Where(c => c.ClimateDataValueID == climateDataValue.ClimateDataValueID).Any())
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ClimateDataValue, CSSPModelsRes.ClimateDataValueClimateDataValueID, climateDataValue.ClimateDataValueID.ToString()), new[] { "ClimateDataValueID" });
                }
            }

            ClimateSite ClimateSiteClimateSiteID = (from c in db.ClimateSites where c.ClimateSiteID == climateDataValue.ClimateSiteID select c).FirstOrDefault();

            if (ClimateSiteClimateSiteID == null)
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ClimateSite, CSSPModelsRes.ClimateDataValueClimateSiteID, (climateDataValue.ClimateSiteID == null ? "" : climateDataValue.ClimateSiteID.ToString())), new[] { "ClimateSiteID" });
            }

            if (climateDataValue.DateTime_Local.Year == 1)
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateDataValueDateTime_Local), new[] { "DateTime_Local" });
            }
            else
            {
                if (climateDataValue.DateTime_Local.Year < 1980)
                {
                climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateDataValueDateTime_Local, "1980"), new[] { "DateTime_Local" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)climateDataValue.StorageDataType);
            if (climateDataValue.StorageDataType == StorageDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateDataValueStorageDataType), new[] { "StorageDataType" });
            }

            if (climateDataValue.Snow_cm != null)
            {
                if (climateDataValue.Snow_cm < 0 || climateDataValue.Snow_cm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueSnow_cm, "0", "10000"), new[] { "Snow_cm" });
                }
            }

            if (climateDataValue.Rainfall_mm != null)
            {
                if (climateDataValue.Rainfall_mm < 0 || climateDataValue.Rainfall_mm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueRainfall_mm, "0", "10000"), new[] { "Rainfall_mm" });
                }
            }

            if (climateDataValue.RainfallEntered_mm != null)
            {
                if (climateDataValue.RainfallEntered_mm < 0 || climateDataValue.RainfallEntered_mm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueRainfallEntered_mm, "0", "10000"), new[] { "RainfallEntered_mm" });
                }
            }

            if (climateDataValue.TotalPrecip_mm_cm != null)
            {
                if (climateDataValue.TotalPrecip_mm_cm < 0 || climateDataValue.TotalPrecip_mm_cm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueTotalPrecip_mm_cm, "0", "10000"), new[] { "TotalPrecip_mm_cm" });
                }
            }

            if (climateDataValue.MaxTemp_C != null)
            {
                if (climateDataValue.MaxTemp_C < -50 || climateDataValue.MaxTemp_C > 50)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueMaxTemp_C, "-50", "50"), new[] { "MaxTemp_C" });
                }
            }

            if (climateDataValue.MinTemp_C != null)
            {
                if (climateDataValue.MinTemp_C < -50 || climateDataValue.MinTemp_C > 50)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueMinTemp_C, "-50", "50"), new[] { "MinTemp_C" });
                }
            }

            if (climateDataValue.HeatDegDays_C != null)
            {
                if (climateDataValue.HeatDegDays_C < -1000 || climateDataValue.HeatDegDays_C > 100)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueHeatDegDays_C, "-1000", "100"), new[] { "HeatDegDays_C" });
                }
            }

            if (climateDataValue.CoolDegDays_C != null)
            {
                if (climateDataValue.CoolDegDays_C < -1000 || climateDataValue.CoolDegDays_C > 100)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueCoolDegDays_C, "-1000", "100"), new[] { "CoolDegDays_C" });
                }
            }

            if (climateDataValue.SnowOnGround_cm != null)
            {
                if (climateDataValue.SnowOnGround_cm < 0 || climateDataValue.SnowOnGround_cm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueSnowOnGround_cm, "0", "10000"), new[] { "SnowOnGround_cm" });
                }
            }

            if (climateDataValue.DirMaxGust_0North != null)
            {
                if (climateDataValue.DirMaxGust_0North < 0 || climateDataValue.DirMaxGust_0North > 360)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueDirMaxGust_0North, "0", "360"), new[] { "DirMaxGust_0North" });
                }
            }

            if (climateDataValue.SpdMaxGust_kmh != null)
            {
                if (climateDataValue.SpdMaxGust_kmh < 0 || climateDataValue.SpdMaxGust_kmh > 300)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateDataValueSpdMaxGust_kmh, "0", "300"), new[] { "SpdMaxGust_kmh" });
                }
            }

            //HourlyValues has no StringLength Attribute

            if (climateDataValue.LastUpdateDate_UTC.Year == 1)
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateDataValueLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (climateDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateDataValueLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == climateDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClimateDataValueLastUpdateContactTVItemID, (climateDataValue.LastUpdateContactTVItemID == null ? "" : climateDataValue.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClimateDataValueLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ClimateDataValue GetClimateDataValueWithClimateDataValueID(int ClimateDataValueID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<ClimateDataValue> climateDataValueQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ClimateDataValueID == ClimateDataValueID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return climateDataValueQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillClimateDataValueWeb(climateDataValueQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillClimateDataValueReport(climateDataValueQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ClimateDataValue> GetClimateDataValueList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<ClimateDataValue> climateDataValueQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return climateDataValueQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillClimateDataValueWeb(climateDataValueQuery, FilterAndOrderText).Take(MaxGetCount);
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillClimateDataValueReport(climateDataValueQuery, FilterAndOrderText).Take(MaxGetCount);
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(ClimateDataValue climateDataValue)
        {
            climateDataValue.ValidationResults = Validate(new ValidationContext(climateDataValue), ActionDBTypeEnum.Create);
            if (climateDataValue.ValidationResults.Count() > 0) return false;

            db.ClimateDataValues.Add(climateDataValue);

            if (!TryToSave(climateDataValue)) return false;

            return true;
        }
        public bool Delete(ClimateDataValue climateDataValue)
        {
            climateDataValue.ValidationResults = Validate(new ValidationContext(climateDataValue), ActionDBTypeEnum.Delete);
            if (climateDataValue.ValidationResults.Count() > 0) return false;

            db.ClimateDataValues.Remove(climateDataValue);

            if (!TryToSave(climateDataValue)) return false;

            return true;
        }
        public bool Update(ClimateDataValue climateDataValue)
        {
            climateDataValue.ValidationResults = Validate(new ValidationContext(climateDataValue), ActionDBTypeEnum.Update);
            if (climateDataValue.ValidationResults.Count() > 0) return false;

            db.ClimateDataValues.Update(climateDataValue);

            if (!TryToSave(climateDataValue)) return false;

            return true;
        }
        public IQueryable<ClimateDataValue> GetRead()
        {
            return db.ClimateDataValues.AsNoTracking();
        }
        public IQueryable<ClimateDataValue> GetEdit()
        {
            return db.ClimateDataValues;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ClimateDataValueFillWeb
        private IQueryable<ClimateDataValue> FillClimateDataValueWeb(IQueryable<ClimateDataValue> climateDataValueQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));

            climateDataValueQuery = (from c in climateDataValueQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ClimateDataValue
                    {
                        ClimateDataValueID = c.ClimateDataValueID,
                        ClimateSiteID = c.ClimateSiteID,
                        DateTime_Local = c.DateTime_Local,
                        Keep = c.Keep,
                        StorageDataType = c.StorageDataType,
                        Snow_cm = c.Snow_cm,
                        Rainfall_mm = c.Rainfall_mm,
                        RainfallEntered_mm = c.RainfallEntered_mm,
                        TotalPrecip_mm_cm = c.TotalPrecip_mm_cm,
                        MaxTemp_C = c.MaxTemp_C,
                        MinTemp_C = c.MinTemp_C,
                        HeatDegDays_C = c.HeatDegDays_C,
                        CoolDegDays_C = c.CoolDegDays_C,
                        SnowOnGround_cm = c.SnowOnGround_cm,
                        DirMaxGust_0North = c.DirMaxGust_0North,
                        SpdMaxGust_kmh = c.SpdMaxGust_kmh,
                        HourlyValues = c.HourlyValues,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ClimateDataValueWeb = new ClimateDataValueWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            StorageDataTypeEnumText = (from e in StorageDataTypeEnumList
                                where e.EnumID == (int?)c.StorageDataType
                                select e.EnumText).FirstOrDefault(),
                        },
                        ClimateDataValueReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return climateDataValueQuery;
        }
        #endregion Functions private Generated ClimateDataValueFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(ClimateDataValue climateDataValue)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                climateDataValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
