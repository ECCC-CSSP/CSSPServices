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

            //Snow_cm has no Range Attribute

            //Rainfall_mm has no Range Attribute

            //RainfallEntered_mm has no Range Attribute

            //TotalPrecip_mm_cm has no Range Attribute

            //MaxTemp_C has no Range Attribute

            //MinTemp_C has no Range Attribute

            //HeatDegDays_C has no Range Attribute

            //CoolDegDays_C has no Range Attribute

            //SnowOnGround_cm has no Range Attribute

            //DirMaxGust_0North has no Range Attribute

            //SpdMaxGust_kmh has no Range Attribute

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
