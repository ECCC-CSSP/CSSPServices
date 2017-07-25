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
    public partial class ClimateSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateSiteService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ClimateSite climateSite = validationContext.ObjectInstance as ClimateSite;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (climateSite.ClimateSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteID), new[] { ModelsRes.ClimateSiteClimateSiteID });
                }
            }

            //ClimateSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ClimateSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (climateSite.ClimateSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateSiteClimateSiteTVItemID, "1"), new[] { ModelsRes.ClimateSiteClimateSiteTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == climateSite.ClimateSiteTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ClimateSiteClimateSiteTVItemID, climateSite.ClimateSiteTVItemID.ToString()), new[] { ModelsRes.ClimateSiteClimateSiteTVItemID });
            }

            //ECDBID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (climateSite.ECDBID < 1 || climateSite.ECDBID > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteECDBID, "1", "100000"), new[] { ModelsRes.ClimateSiteECDBID });
            }

            if (string.IsNullOrWhiteSpace(climateSite.ClimateSiteName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteName), new[] { ModelsRes.ClimateSiteClimateSiteName });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateSiteName) && climateSite.ClimateSiteName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateSiteName, "100"), new[] { ModelsRes.ClimateSiteClimateSiteName });
            }

            if (string.IsNullOrWhiteSpace(climateSite.Province))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteProvince), new[] { ModelsRes.ClimateSiteProvince });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.Province) && climateSite.Province.Length > 4)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvince, "4"), new[] { ModelsRes.ClimateSiteProvince });
            }

            if (climateSite.Elevation_m != null)
            {
                if (climateSite.Elevation_m < 0 || climateSite.Elevation_m > 10000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteElevation_m, "0", "10000"), new[] { ModelsRes.ClimateSiteElevation_m });
                }
            }

            if (string.IsNullOrWhiteSpace(climateSite.ClimateID))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateID), new[] { ModelsRes.ClimateSiteClimateID });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateID) && climateSite.ClimateID.Length > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateID, "10"), new[] { ModelsRes.ClimateSiteClimateID });
            }

            if (climateSite.WMOID != null)
            {
                if (climateSite.WMOID < 1 || climateSite.WMOID > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "100000"), new[] { ModelsRes.ClimateSiteWMOID });
                }
            }

            if (string.IsNullOrWhiteSpace(climateSite.TCID))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteTCID), new[] { ModelsRes.ClimateSiteTCID });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.TCID) && climateSite.TCID.Length > 3)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteTCID, "3"), new[] { ModelsRes.ClimateSiteTCID });
            }

            if (string.IsNullOrWhiteSpace(climateSite.ProvSiteID))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteProvSiteID), new[] { ModelsRes.ClimateSiteProvSiteID });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ProvSiteID) && climateSite.ProvSiteID.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvSiteID, "50"), new[] { ModelsRes.ClimateSiteProvSiteID });
            }

            if (climateSite.TimeOffset_hour != null)
            {
                if (climateSite.TimeOffset_hour < -10 || climateSite.TimeOffset_hour > 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteTimeOffset_hour, "-10", "0"), new[] { ModelsRes.ClimateSiteTimeOffset_hour });
                }
            }

            if (string.IsNullOrWhiteSpace(climateSite.File_desc))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteFile_desc), new[] { ModelsRes.ClimateSiteFile_desc });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.File_desc) && climateSite.File_desc.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteFile_desc, "50"), new[] { ModelsRes.ClimateSiteFile_desc });
            }

            if (climateSite.HourlyStartDate_Local != null && ((DateTime)climateSite.HourlyStartDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteHourlyStartDate_Local, "1980"), new[] { ModelsRes.ClimateSiteHourlyStartDate_Local });
            }

            if (climateSite.HourlyEndDate_Local != null && ((DateTime)climateSite.HourlyEndDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteHourlyEndDate_Local, "1980"), new[] { ModelsRes.ClimateSiteHourlyEndDate_Local });
            }

            if (climateSite.DailyStartDate_Local != null && ((DateTime)climateSite.DailyStartDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteDailyStartDate_Local, "1980"), new[] { ModelsRes.ClimateSiteDailyStartDate_Local });
            }

            if (climateSite.DailyEndDate_Local != null && ((DateTime)climateSite.DailyEndDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteDailyEndDate_Local, "1980"), new[] { ModelsRes.ClimateSiteDailyEndDate_Local });
            }

            if (climateSite.MonthlyStartDate_Local != null && ((DateTime)climateSite.MonthlyStartDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteMonthlyStartDate_Local, "1980"), new[] { ModelsRes.ClimateSiteMonthlyStartDate_Local });
            }

            if (climateSite.MonthlyEndDate_Local != null && ((DateTime)climateSite.MonthlyEndDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteMonthlyEndDate_Local, "1980"), new[] { ModelsRes.ClimateSiteMonthlyEndDate_Local });
            }

            if (climateSite.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteLastUpdateDate_UTC), new[] { ModelsRes.ClimateSiteLastUpdateDate_UTC });
            }

            if (climateSite.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteLastUpdateDate_UTC, "1980"), new[] { ModelsRes.ClimateSiteLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (climateSite.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateSiteLastUpdateContactTVItemID, "1"), new[] { ModelsRes.ClimateSiteLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == climateSite.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ClimateSiteLastUpdateContactTVItemID, climateSite.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.ClimateSiteLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(ClimateSite climateSite)
        {
            climateSite.ValidationResults = Validate(new ValidationContext(climateSite), ActionDBTypeEnum.Create);
            if (climateSite.ValidationResults.Count() > 0) return false;

            db.ClimateSites.Add(climateSite);

            if (!TryToSave(climateSite)) return false;

            return true;
        }
        public bool AddRange(List<ClimateSite> climateSiteList)
        {
            foreach (ClimateSite climateSite in climateSiteList)
            {
                climateSite.ValidationResults = Validate(new ValidationContext(climateSite), ActionDBTypeEnum.Create);
                if (climateSite.ValidationResults.Count() > 0) return false;
            }

            db.ClimateSites.AddRange(climateSiteList);

            if (!TryToSaveRange(climateSiteList)) return false;

            return true;
        }
        public bool Delete(ClimateSite climateSite)
        {
            if (!db.ClimateSites.Where(c => c.ClimateSiteID == climateSite.ClimateSiteID).Any())
            {
                climateSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ClimateSite", "ClimateSiteID", climateSite.ClimateSiteID.ToString())) }.AsEnumerable();
                return false;
            }

            db.ClimateSites.Remove(climateSite);

            if (!TryToSave(climateSite)) return false;

            return true;
        }
        public bool DeleteRange(List<ClimateSite> climateSiteList)
        {
            foreach (ClimateSite climateSite in climateSiteList)
            {
                if (!db.ClimateSites.Where(c => c.ClimateSiteID == climateSite.ClimateSiteID).Any())
                {
                    climateSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ClimateSite", "ClimateSiteID", climateSite.ClimateSiteID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.ClimateSites.RemoveRange(climateSiteList);

            if (!TryToSaveRange(climateSiteList)) return false;

            return true;
        }
        public bool Update(ClimateSite climateSite)
        {
            climateSite.ValidationResults = Validate(new ValidationContext(climateSite), ActionDBTypeEnum.Update);
            if (climateSite.ValidationResults.Count() > 0) return false;

            db.ClimateSites.Update(climateSite);

            if (!TryToSave(climateSite)) return false;

            return true;
        }
        public bool UpdateRange(List<ClimateSite> climateSiteList)
        {
            foreach (ClimateSite climateSite in climateSiteList)
            {
                climateSite.ValidationResults = Validate(new ValidationContext(climateSite), ActionDBTypeEnum.Update);
                if (climateSite.ValidationResults.Count() > 0) return false;
            }
            db.ClimateSites.UpdateRange(climateSiteList);

            if (!TryToSaveRange(climateSiteList)) return false;

            return true;
        }
        public IQueryable<ClimateSite> GetRead()
        {
            return db.ClimateSites.AsNoTracking();
        }
        public IQueryable<ClimateSite> GetEdit()
        {
            return db.ClimateSites;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(ClimateSite climateSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                climateSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<ClimateSite> climateSiteList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                climateSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
