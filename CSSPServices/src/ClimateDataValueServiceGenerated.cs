/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
        #endregion Properties

        #region Constructors
        public ClimateDataValueService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ClimateDataValueID"), new[] { "ClimateDataValueID" });
                }

                if (!(from c in db.ClimateDataValues select c).Where(c => c.ClimateDataValueID == climateDataValue.ClimateDataValueID).Any())
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ClimateDataValue", "ClimateDataValueID", climateDataValue.ClimateDataValueID.ToString()), new[] { "ClimateDataValueID" });
                }
            }

            ClimateSite ClimateSiteClimateSiteID = (from c in db.ClimateSites where c.ClimateSiteID == climateDataValue.ClimateSiteID select c).FirstOrDefault();

            if (ClimateSiteClimateSiteID == null)
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ClimateSite", "ClimateSiteID", climateDataValue.ClimateSiteID.ToString()), new[] { "ClimateSiteID" });
            }

            if (climateDataValue.DateTime_Local.Year == 1)
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DateTime_Local"), new[] { "DateTime_Local" });
            }
            else
            {
                if (climateDataValue.DateTime_Local.Year < 1980)
                {
                climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { "DateTime_Local" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)climateDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StorageDataType"), new[] { "StorageDataType" });
            }

            if (climateDataValue.Snow_cm != null)
            {
                if (climateDataValue.Snow_cm < 0 || climateDataValue.Snow_cm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Snow_cm", "0", "10000"), new[] { "Snow_cm" });
                }
            }

            if (climateDataValue.Rainfall_mm != null)
            {
                if (climateDataValue.Rainfall_mm < 0 || climateDataValue.Rainfall_mm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Rainfall_mm", "0", "10000"), new[] { "Rainfall_mm" });
                }
            }

            if (climateDataValue.RainfallEntered_mm != null)
            {
                if (climateDataValue.RainfallEntered_mm < 0 || climateDataValue.RainfallEntered_mm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainfallEntered_mm", "0", "10000"), new[] { "RainfallEntered_mm" });
                }
            }

            if (climateDataValue.TotalPrecip_mm_cm != null)
            {
                if (climateDataValue.TotalPrecip_mm_cm < 0 || climateDataValue.TotalPrecip_mm_cm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TotalPrecip_mm_cm", "0", "10000"), new[] { "TotalPrecip_mm_cm" });
                }
            }

            if (climateDataValue.MaxTemp_C != null)
            {
                if (climateDataValue.MaxTemp_C < -50 || climateDataValue.MaxTemp_C > 50)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MaxTemp_C", "-50", "50"), new[] { "MaxTemp_C" });
                }
            }

            if (climateDataValue.MinTemp_C != null)
            {
                if (climateDataValue.MinTemp_C < -50 || climateDataValue.MinTemp_C > 50)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MinTemp_C", "-50", "50"), new[] { "MinTemp_C" });
                }
            }

            if (climateDataValue.HeatDegDays_C != null)
            {
                if (climateDataValue.HeatDegDays_C < -1000 || climateDataValue.HeatDegDays_C > 100)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HeatDegDays_C", "-1000", "100"), new[] { "HeatDegDays_C" });
                }
            }

            if (climateDataValue.CoolDegDays_C != null)
            {
                if (climateDataValue.CoolDegDays_C < -1000 || climateDataValue.CoolDegDays_C > 100)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CoolDegDays_C", "-1000", "100"), new[] { "CoolDegDays_C" });
                }
            }

            if (climateDataValue.SnowOnGround_cm != null)
            {
                if (climateDataValue.SnowOnGround_cm < 0 || climateDataValue.SnowOnGround_cm > 10000)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SnowOnGround_cm", "0", "10000"), new[] { "SnowOnGround_cm" });
                }
            }

            if (climateDataValue.DirMaxGust_0North != null)
            {
                if (climateDataValue.DirMaxGust_0North < 0 || climateDataValue.DirMaxGust_0North > 360)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DirMaxGust_0North", "0", "360"), new[] { "DirMaxGust_0North" });
                }
            }

            if (climateDataValue.SpdMaxGust_kmh != null)
            {
                if (climateDataValue.SpdMaxGust_kmh < 0 || climateDataValue.SpdMaxGust_kmh > 300)
                {
                    climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SpdMaxGust_kmh", "0", "300"), new[] { "SpdMaxGust_kmh" });
                }
            }

            //HourlyValues has no StringLength Attribute

            if (climateDataValue.LastUpdateDate_UTC.Year == 1)
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (climateDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                climateDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == climateDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", climateDataValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                climateDataValue.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ClimateDataValue GetClimateDataValueWithClimateDataValueID(int ClimateDataValueID)
        {
            return (from c in db.ClimateDataValues
                    where c.ClimateDataValueID == ClimateDataValueID
                    select c).FirstOrDefault();

        }
        public IQueryable<ClimateDataValue> GetClimateDataValueList()
        {
            IQueryable<ClimateDataValue> ClimateDataValueQuery = (from c in db.ClimateDataValues select c);

            ClimateDataValueQuery = EnhanceQueryStatements<ClimateDataValue>(ClimateDataValueQuery) as IQueryable<ClimateDataValue>;

            return ClimateDataValueQuery;
        }
        public ClimateDataValueExtraA GetClimateDataValueExtraAWithClimateDataValueID(int ClimateDataValueID)
        {
            return FillClimateDataValueExtraA().Where(c => c.ClimateDataValueID == ClimateDataValueID).FirstOrDefault();

        }
        public IQueryable<ClimateDataValueExtraA> GetClimateDataValueExtraAList()
        {
            IQueryable<ClimateDataValueExtraA> ClimateDataValueExtraAQuery = FillClimateDataValueExtraA();

            ClimateDataValueExtraAQuery = EnhanceQueryStatements<ClimateDataValueExtraA>(ClimateDataValueExtraAQuery) as IQueryable<ClimateDataValueExtraA>;

            return ClimateDataValueExtraAQuery;
        }
        public ClimateDataValueExtraB GetClimateDataValueExtraBWithClimateDataValueID(int ClimateDataValueID)
        {
            return FillClimateDataValueExtraB().Where(c => c.ClimateDataValueID == ClimateDataValueID).FirstOrDefault();

        }
        public IQueryable<ClimateDataValueExtraB> GetClimateDataValueExtraBList()
        {
            IQueryable<ClimateDataValueExtraB> ClimateDataValueExtraBQuery = FillClimateDataValueExtraB();

            ClimateDataValueExtraBQuery = EnhanceQueryStatements<ClimateDataValueExtraB>(ClimateDataValueExtraBQuery) as IQueryable<ClimateDataValueExtraB>;

            return ClimateDataValueExtraBQuery;
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
        #endregion Functions public Generated CRUD

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
