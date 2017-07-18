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
    public partial class ClimateDataValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateDataValueService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ClimateDataValue climateDataValue = validationContext.ObjectInstance as ClimateDataValue;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (climateDataValue.ClimateDataValueID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueClimateDataValueID), new[] { ModelsRes.ClimateDataValueClimateDataValueID });
                }
            }

            //ClimateDataValueID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ClimateSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (climateDataValue.ClimateSiteID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateDataValueClimateSiteID, "1"), new[] { ModelsRes.ClimateDataValueClimateSiteID });
            }

            if (!((from c in db.ClimateSites where c.ClimateSiteID == climateDataValue.ClimateSiteID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.ClimateSite, ModelsRes.ClimateDataValueClimateSiteID, climateDataValue.ClimateSiteID.ToString()), new[] { ModelsRes.ClimateDataValueClimateSiteID });
            }

            if (climateDataValue.DateTime_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueDateTime_Local), new[] { ModelsRes.ClimateDataValueDateTime_Local });
            }

            if (climateDataValue.DateTime_Local.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateDataValueDateTime_Local, "1980"), new[] { ModelsRes.ClimateDataValueDateTime_Local });
            }

            //Keep (bool) is required but no testing needed 

            retStr = enums.StorageDataTypeOK(climateDataValue.StorageDataType);
            if (climateDataValue.StorageDataType == StorageDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueStorageDataType), new[] { ModelsRes.ClimateDataValueStorageDataType });
            }

            if (climateDataValue.Snow_cm < 0 || climateDataValue.Snow_cm > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnow_cm, "0", "10000"), new[] { ModelsRes.ClimateDataValueSnow_cm });
            }

            if (climateDataValue.Rainfall_mm < 0 || climateDataValue.Rainfall_mm > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfall_mm, "0", "10000"), new[] { ModelsRes.ClimateDataValueRainfall_mm });
            }

            if (climateDataValue.RainfallEntered_mm < 0 || climateDataValue.RainfallEntered_mm > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueRainfallEntered_mm, "0", "10000"), new[] { ModelsRes.ClimateDataValueRainfallEntered_mm });
            }

            if (climateDataValue.TotalPrecip_mm_cm < 0 || climateDataValue.TotalPrecip_mm_cm > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueTotalPrecip_mm_cm, "0", "10000"), new[] { ModelsRes.ClimateDataValueTotalPrecip_mm_cm });
            }

            if (climateDataValue.MaxTemp_C < -50 || climateDataValue.MaxTemp_C > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMaxTemp_C, "-50", "50"), new[] { ModelsRes.ClimateDataValueMaxTemp_C });
            }

            if (climateDataValue.MinTemp_C < -50 || climateDataValue.MinTemp_C > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueMinTemp_C, "-50", "50"), new[] { ModelsRes.ClimateDataValueMinTemp_C });
            }

            if (climateDataValue.HeatDegDays_C < -1000 || climateDataValue.HeatDegDays_C > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueHeatDegDays_C, "-1000", "100"), new[] { ModelsRes.ClimateDataValueHeatDegDays_C });
            }

            if (climateDataValue.CoolDegDays_C < -1000 || climateDataValue.CoolDegDays_C > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueCoolDegDays_C, "-1000", "100"), new[] { ModelsRes.ClimateDataValueCoolDegDays_C });
            }

            if (climateDataValue.SnowOnGround_cm < 0 || climateDataValue.SnowOnGround_cm > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSnowOnGround_cm, "0", "10000"), new[] { ModelsRes.ClimateDataValueSnowOnGround_cm });
            }

            if (climateDataValue.DirMaxGust_0North < 0 || climateDataValue.DirMaxGust_0North > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueDirMaxGust_0North, "0", "360"), new[] { ModelsRes.ClimateDataValueDirMaxGust_0North });
            }

            if (climateDataValue.SpdMaxGust_kmh < 0 || climateDataValue.SpdMaxGust_kmh > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateDataValueSpdMaxGust_kmh, "0", "300"), new[] { ModelsRes.ClimateDataValueSpdMaxGust_kmh });
            }

            if (string.IsNullOrWhiteSpace(climateDataValue.HourlyValues))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueHourlyValues), new[] { ModelsRes.ClimateDataValueHourlyValues });
            }

            //HourlyValues has no StringLength Attribute

            if (climateDataValue.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateDataValueLastUpdateDate_UTC), new[] { ModelsRes.ClimateDataValueLastUpdateDate_UTC });
            }

            if (climateDataValue.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateDataValueLastUpdateDate_UTC, "1980"), new[] { ModelsRes.ClimateDataValueLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (climateDataValue.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateDataValueLastUpdateContactTVItemID, "1"), new[] { ModelsRes.ClimateDataValueLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == climateDataValue.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ClimateDataValueLastUpdateContactTVItemID, climateDataValue.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.ClimateDataValueLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(ClimateDataValue climateDataValue)
        {
            climateDataValue.ValidationResults = Validate(new ValidationContext(climateDataValue), ActionDBTypeEnum.Create);
            if (climateDataValue.ValidationResults.Count() > 0) return false;

            db.ClimateDataValues.Add(climateDataValue);

            if (!TryToSave(climateDataValue)) return false;

            return true;
        }
        public bool AddRange(List<ClimateDataValue> climateDataValueList)
        {
            foreach (ClimateDataValue climateDataValue in climateDataValueList)
            {
                climateDataValue.ValidationResults = Validate(new ValidationContext(climateDataValue), ActionDBTypeEnum.Create);
                if (climateDataValue.ValidationResults.Count() > 0) return false;
            }

            db.ClimateDataValues.AddRange(climateDataValueList);

            if (!TryToSaveRange(climateDataValueList)) return false;

            return true;
        }
        public bool Delete(ClimateDataValue climateDataValue)
        {
            if (!db.ClimateDataValues.Where(c => c.ClimateDataValueID == climateDataValue.ClimateDataValueID).Any())
            {
                climateDataValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ClimateDataValue", "ClimateDataValueID", climateDataValue.ClimateDataValueID.ToString())) }.AsEnumerable();
                return false;
            }

            db.ClimateDataValues.Remove(climateDataValue);

            if (!TryToSave(climateDataValue)) return false;

            return true;
        }
        public bool DeleteRange(List<ClimateDataValue> climateDataValueList)
        {
            foreach (ClimateDataValue climateDataValue in climateDataValueList)
            {
                if (!db.ClimateDataValues.Where(c => c.ClimateDataValueID == climateDataValue.ClimateDataValueID).Any())
                {
                    climateDataValueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ClimateDataValue", "ClimateDataValueID", climateDataValue.ClimateDataValueID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.ClimateDataValues.RemoveRange(climateDataValueList);

            if (!TryToSaveRange(climateDataValueList)) return false;

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
        public bool UpdateRange(List<ClimateDataValue> climateDataValueList)
        {
            foreach (ClimateDataValue climateDataValue in climateDataValueList)
            {
                climateDataValue.ValidationResults = Validate(new ValidationContext(climateDataValue), ActionDBTypeEnum.Update);
                if (climateDataValue.ValidationResults.Count() > 0) return false;
            }
            db.ClimateDataValues.UpdateRange(climateDataValueList);

            if (!TryToSaveRange(climateDataValueList)) return false;

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
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<ClimateDataValue> climateDataValueList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                climateDataValueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
