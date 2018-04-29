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
    ///     <para>bonjour ClimateSite</para>
    /// </summary>
    public partial class ClimateSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ClimateSiteService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateSiteClimateSiteID), new[] { "ClimateSiteID" });
                }

                if (!GetRead().Where(c => c.ClimateSiteID == climateSite.ClimateSiteID).Any())
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ClimateSite, CSSPModelsRes.ClimateSiteClimateSiteID, climateSite.ClimateSiteID.ToString()), new[] { "ClimateSiteID" });
                }
            }

            TVItem TVItemClimateSiteTVItemID = (from c in db.TVItems where c.TVItemID == climateSite.ClimateSiteTVItemID select c).FirstOrDefault();

            if (TVItemClimateSiteTVItemID == null)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClimateSiteClimateSiteTVItemID, (climateSite.ClimateSiteTVItemID == null ? "" : climateSite.ClimateSiteTVItemID.ToString())), new[] { "ClimateSiteTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClimateSiteClimateSiteTVItemID, "ClimateSite"), new[] { "ClimateSiteTVItemID" });
                }
            }

            if (climateSite.ECDBID < 1 || climateSite.ECDBID > 100000)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteECDBID, "1", "100000"), new[] { "ECDBID" });
            }

            if (string.IsNullOrWhiteSpace(climateSite.ClimateSiteName))
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateSiteClimateSiteName), new[] { "ClimateSiteName" });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateSiteName) && climateSite.ClimateSiteName.Length > 100)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteClimateSiteName, "100"), new[] { "ClimateSiteName" });
            }

            if (string.IsNullOrWhiteSpace(climateSite.Province))
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateSiteProvince), new[] { "Province" });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.Province) && climateSite.Province.Length > 4)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteProvince, "4"), new[] { "Province" });
            }

            if (climateSite.Elevation_m != null)
            {
                if (climateSite.Elevation_m < 0 || climateSite.Elevation_m > 10000)
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteElevation_m, "0", "10000"), new[] { "Elevation_m" });
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateID) && climateSite.ClimateID.Length > 10)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteClimateID, "10"), new[] { "ClimateID" });
            }

            if (climateSite.WMOID != null)
            {
                if (climateSite.WMOID < 1 || climateSite.WMOID > 100000)
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteWMOID, "1", "100000"), new[] { "WMOID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.TCID) && climateSite.TCID.Length > 3)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteTCID, "3"), new[] { "TCID" });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ProvSiteID) && climateSite.ProvSiteID.Length > 50)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteProvSiteID, "50"), new[] { "ProvSiteID" });
            }

            if (climateSite.TimeOffset_hour != null)
            {
                if (climateSite.TimeOffset_hour < -10 || climateSite.TimeOffset_hour > 0)
                {
                    climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ClimateSiteTimeOffset_hour, "-10", "0"), new[] { "TimeOffset_hour" });
                }
            }

            if (!string.IsNullOrWhiteSpace(climateSite.File_desc) && climateSite.File_desc.Length > 50)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ClimateSiteFile_desc, "50"), new[] { "File_desc" });
            }

            if (climateSite.HourlyStartDate_Local != null && ((DateTime)climateSite.HourlyStartDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteHourlyStartDate_Local, "1980"), new[] { CSSPModelsRes.ClimateSiteHourlyStartDate_Local });
            }

            if (climateSite.HourlyEndDate_Local != null && ((DateTime)climateSite.HourlyEndDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteHourlyEndDate_Local, "1980"), new[] { CSSPModelsRes.ClimateSiteHourlyEndDate_Local });
            }

            if (climateSite.DailyStartDate_Local != null && ((DateTime)climateSite.DailyStartDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteDailyStartDate_Local, "1980"), new[] { CSSPModelsRes.ClimateSiteDailyStartDate_Local });
            }

            if (climateSite.DailyEndDate_Local != null && ((DateTime)climateSite.DailyEndDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteDailyEndDate_Local, "1980"), new[] { CSSPModelsRes.ClimateSiteDailyEndDate_Local });
            }

            if (climateSite.MonthlyStartDate_Local != null && ((DateTime)climateSite.MonthlyStartDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteMonthlyStartDate_Local, "1980"), new[] { CSSPModelsRes.ClimateSiteMonthlyStartDate_Local });
            }

            if (climateSite.MonthlyEndDate_Local != null && ((DateTime)climateSite.MonthlyEndDate_Local).Year < 1980)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteMonthlyEndDate_Local, "1980"), new[] { CSSPModelsRes.ClimateSiteMonthlyEndDate_Local });
            }

            if (climateSite.LastUpdateDate_UTC.Year == 1)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ClimateSiteLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (climateSite.LastUpdateDate_UTC.Year < 1980)
                {
                climateSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ClimateSiteLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == climateSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ClimateSiteLastUpdateContactTVItemID, (climateSite.LastUpdateContactTVItemID == null ? "" : climateSite.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ClimateSiteLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                climateSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ClimateSite GetClimateSiteWithClimateSiteID(int ClimateSiteID, GetParam getParam)
        {
            IQueryable<ClimateSite> climateSiteQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ClimateSiteID == ClimateSiteID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return climateSiteQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillClimateSiteWeb(climateSiteQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillClimateSiteReport(climateSiteQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ClimateSite> GetClimateSiteList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<ClimateSite> climateSiteQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            climateSiteQuery  = climateSiteQuery.OrderByDescending(c => c.ClimateSiteID);
                        }
                        climateSiteQuery = climateSiteQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return climateSiteQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            climateSiteQuery = FillClimateSiteWeb(climateSiteQuery, FilterAndOrderText).OrderByDescending(c => c.ClimateSiteID);
                        }
                        climateSiteQuery = FillClimateSiteWeb(climateSiteQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return climateSiteQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            climateSiteQuery = FillClimateSiteReport(climateSiteQuery, FilterAndOrderText).OrderByDescending(c => c.ClimateSiteID);
                        }
                        climateSiteQuery = FillClimateSiteReport(climateSiteQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return climateSiteQuery;
                    }
                default:
                    return null;
            }
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
            if (GetParam.OrderAscending)
            {
                return db.ClimateSites.AsNoTracking();
            }
            else
            {
                return db.ClimateSites.AsNoTracking().OrderByDescending(c => c.ClimateSiteID);
            }
        }
        public IQueryable<ClimateSite> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.ClimateSites;
            }
            else
            {
                return db.ClimateSites.OrderByDescending(c => c.ClimateSiteID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ClimateSiteFillWeb
        private IQueryable<ClimateSite> FillClimateSiteWeb(IQueryable<ClimateSite> climateSiteQuery, string FilterAndOrderText)
        {
            climateSiteQuery = (from c in climateSiteQuery
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
                        ClimateSiteWeb = new ClimateSiteWeb
                        {
                            ClimateSiteTVText = ClimateSiteTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        ClimateSiteReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return climateSiteQuery;
        }
        #endregion Functions private Generated ClimateSiteFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
