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
            climateSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (climateSite.ClimateSiteID == 0)
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteID), new[] { "ClimateSiteID" });
                }

                if (!GetRead().Where(c => c.ClimateSiteID == climateSite.ClimateSiteID).Any())
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.ClimateSite, ModelsRes.ClimateSiteClimateSiteID, climateSite.ClimateSiteID.ToString()), new[] { "ClimateSiteID" });
                }
            }

            //ClimateSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ClimateSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemClimateSiteTVItemID = (from c in db.TVItems where c.TVItemID == climateSite.ClimateSiteTVItemID select c).FirstOrDefault();

            if (TVItemClimateSiteTVItemID == null)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ClimateSiteClimateSiteTVItemID, climateSite.ClimateSiteTVItemID.ToString()), new[] { "ClimateSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.ClimateSite,
                };
                if (!AllowableTVTypes.Contains(TVItemClimateSiteTVItemID.TVType))
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ClimateSiteClimateSiteTVItemID, "ClimateSite"), new[] { "ClimateSiteTVItemID" });
                }
            }

            //ECDBID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (climateSite.ECDBID < 1 || climateSite.ECDBID > 100000)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteECDBID, "1", "100000"), new[] { "ECDBID" });
            }

            if (string.IsNullOrWhiteSpace(climateSite.ClimateSiteName))
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteName), new[] { "ClimateSiteName" });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateSiteName) && climateSite.ClimateSiteName.Length > 100)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateSiteName, "100"), new[] { "ClimateSiteName" });
            }

            if (string.IsNullOrWhiteSpace(climateSite.Province))
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteProvince), new[] { "Province" });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.Province) && climateSite.Province.Length > 4)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvince, "4"), new[] { "Province" });
            }

            if (climateSite.Elevation_m != null)
            {
                if (climateSite.Elevation_m < 0 || climateSite.Elevation_m > 10000)
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteElevation_m, "0", "10000"), new[] { "Elevation_m" });
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateID) && climateSite.ClimateID.Length > 10)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateID, "10"), new[] { "ClimateID" });
            }

            if (climateSite.WMOID != null)
            {
                if (climateSite.WMOID < 1 || climateSite.WMOID > 100000)
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "100000"), new[] { "WMOID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.TCID) && climateSite.TCID.Length > 3)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteTCID, "3"), new[] { "TCID" });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ProvSiteID) && climateSite.ProvSiteID.Length > 50)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvSiteID, "50"), new[] { "ProvSiteID" });
            }

            if (climateSite.TimeOffset_hour != null)
            {
                if (climateSite.TimeOffset_hour < -10 || climateSite.TimeOffset_hour > 0)
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteTimeOffset_hour, "-10", "0"), new[] { "TimeOffset_hour" });
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.File_desc) && climateSite.File_desc.Length > 50)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteFile_desc, "50"), new[] { "File_desc" });
            }

            if (climateSite.HourlyStartDate_Local != null && ((DateTime)climateSite.HourlyStartDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteHourlyStartDate_Local, "1980"), new[] { ModelsRes.ClimateSiteHourlyStartDate_Local });
            }

            if (climateSite.HourlyEndDate_Local != null && ((DateTime)climateSite.HourlyEndDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteHourlyEndDate_Local, "1980"), new[] { ModelsRes.ClimateSiteHourlyEndDate_Local });
            }

            if (climateSite.DailyStartDate_Local != null && ((DateTime)climateSite.DailyStartDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteDailyStartDate_Local, "1980"), new[] { ModelsRes.ClimateSiteDailyStartDate_Local });
            }

            if (climateSite.DailyEndDate_Local != null && ((DateTime)climateSite.DailyEndDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteDailyEndDate_Local, "1980"), new[] { ModelsRes.ClimateSiteDailyEndDate_Local });
            }

            if (climateSite.MonthlyStartDate_Local != null && ((DateTime)climateSite.MonthlyStartDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteMonthlyStartDate_Local, "1980"), new[] { ModelsRes.ClimateSiteMonthlyStartDate_Local });
            }

            if (climateSite.MonthlyEndDate_Local != null && ((DateTime)climateSite.MonthlyEndDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteMonthlyEndDate_Local, "1980"), new[] { ModelsRes.ClimateSiteMonthlyEndDate_Local });
            }

            if (climateSite.LastUpdateDate_UTC.Year == 1)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (climateSite.LastUpdateDate_UTC.Year < 1980)
                {
                climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ClimateSiteLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == climateSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ClimateSiteLastUpdateContactTVItemID, climateSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ClimateSiteLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateSiteTVText) && climateSite.ClimateSiteTVText.Length > 200)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateSiteTVText, "200"), new[] { "ClimateSiteTVText" });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.LastUpdateContactTVText) && climateSite.LastUpdateContactTVText.Length > 200)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ClimateSite GetClimateSiteWithClimateSiteID(int ClimateSiteID)
        {
            IQueryable<ClimateSite> climateSiteQuery = (from c in GetRead()
                                                where c.ClimateSiteID == ClimateSiteID
                                                select c);

            return FillClimateSite(climateSiteQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(ClimateSite climateSite)
        {
            climateSite.ValidationResults = Validate(new ValidationContext(climateSite), ActionDBTypeEnum.Create);
            if (climateSite.ValidationResults.Count() > 0) return false;

            db.ClimateSites.Add(climateSite);

            if (!TryToSave(climateSite)) return false;

            return true;
        }
        public bool Delete(ClimateSite climateSite)
        {
            climateSite.ValidationResults = Validate(new ValidationContext(climateSite), ActionDBTypeEnum.Delete);
            if (climateSite.ValidationResults.Count() > 0) return false;

            db.ClimateSites.Remove(climateSite);

            if (!TryToSave(climateSite)) return false;

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
        public IQueryable<ClimateSite> GetRead()
        {
            return db.ClimateSites.AsNoTracking();
        }
        public IQueryable<ClimateSite> GetEdit()
        {
            return db.ClimateSites;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<ClimateSite> FillClimateSite(IQueryable<ClimateSite> climateSiteQuery)
        {
            List<ClimateSite> ClimateSiteList = (from c in climateSiteQuery
                                         let ClimateSiteTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.ClimateSiteTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new ClimateSite
                                         {
                                             ClimateSiteID = c.ClimateSiteID,
                                             ClimateSiteTVItemID = c.ClimateSiteTVItemID,
                                             ECDBID = c.ECDBID,
                                             ClimateSiteName = c.ClimateSiteName,
                                             Province = c.Province,
                                             Elevation_m = c.Elevation_m,
                                             ClimateID = c.ClimateID,
                                             WMOID = c.WMOID,
                                             TCID = c.TCID,
                                             IsProvincial = c.IsProvincial,
                                             ProvSiteID = c.ProvSiteID,
                                             TimeOffset_hour = c.TimeOffset_hour,
                                             File_desc = c.File_desc,
                                             HourlyStartDate_Local = c.HourlyStartDate_Local,
                                             HourlyEndDate_Local = c.HourlyEndDate_Local,
                                             HourlyNow = c.HourlyNow,
                                             DailyStartDate_Local = c.DailyStartDate_Local,
                                             DailyEndDate_Local = c.DailyEndDate_Local,
                                             DailyNow = c.DailyNow,
                                             MonthlyStartDate_Local = c.MonthlyStartDate_Local,
                                             MonthlyEndDate_Local = c.MonthlyEndDate_Local,
                                             MonthlyNow = c.MonthlyNow,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ClimateSiteTVText = ClimateSiteTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return ClimateSiteList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
