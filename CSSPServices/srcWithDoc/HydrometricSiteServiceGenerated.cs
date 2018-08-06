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
    ///     <para>bonjour HydrometricSite</para>
    /// </summary>
    public partial class HydrometricSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricSiteService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            HydrometricSite hydrometricSite = validationContext.ObjectInstance as HydrometricSite;
            hydrometricSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (hydrometricSite.HydrometricSiteID == 0)
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteHydrometricSiteID"), new[] { "HydrometricSiteID" });
                }

                if (!(from c in db.HydrometricSites select c).Where(c => c.HydrometricSiteID == hydrometricSite.HydrometricSiteID).Any())
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteHydrometricSiteID", hydrometricSite.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
                }
            }

            TVItem TVItemHydrometricSiteTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricSite.HydrometricSiteTVItemID select c).FirstOrDefault();

            if (TVItemHydrometricSiteTVItemID == null)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricSiteHydrometricSiteTVItemID", hydrometricSite.HydrometricSiteTVItemID.ToString()), new[] { "HydrometricSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.HydrometricSite,
                };
                if (!AllowableTVTypes.Contains(TVItemHydrometricSiteTVItemID.TVType))
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricSiteHydrometricSiteTVItemID", "HydrometricSite"), new[] { "HydrometricSiteTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.FedSiteNumber) && hydrometricSite.FedSiteNumber.Length > 7)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteFedSiteNumber", "7"), new[] { "FedSiteNumber" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.QuebecSiteNumber) && hydrometricSite.QuebecSiteNumber.Length > 7)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteQuebecSiteNumber", "7"), new[] { "QuebecSiteNumber" });
            }

            if (string.IsNullOrWhiteSpace(hydrometricSite.HydrometricSiteName))
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteHydrometricSiteName"), new[] { "HydrometricSiteName" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.HydrometricSiteName) && hydrometricSite.HydrometricSiteName.Length > 200)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteHydrometricSiteName", "200"), new[] { "HydrometricSiteName" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.Description) && hydrometricSite.Description.Length > 200)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteDescription", "200"), new[] { "Description" });
            }

            if (string.IsNullOrWhiteSpace(hydrometricSite.Province))
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteProvince"), new[] { "Province" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.Province) && hydrometricSite.Province.Length > 4)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteProvince", "4"), new[] { "Province" });
            }

            if (hydrometricSite.Elevation_m != null)
            {
                if (hydrometricSite.Elevation_m < 0 || hydrometricSite.Elevation_m > 10000)
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricSiteElevation_m", "0", "10000"), new[] { "Elevation_m" });
                }
            }

            if (hydrometricSite.StartDate_Local != null && ((DateTime)hydrometricSite.StartDate_Local).Year < 1849)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricSiteStartDate_Local", "1849"), new[] { "HydrometricSiteStartDate_Local" });
            }

            if (hydrometricSite.EndDate_Local != null && ((DateTime)hydrometricSite.EndDate_Local).Year < 1849)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricSiteEndDate_Local", "1849"), new[] { "HydrometricSiteEndDate_Local" });
            }

            if (hydrometricSite.StartDate_Local > hydrometricSite.EndDate_Local)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "HydrometricSiteEndDate_Local", "HydrometricSiteStartDate_Local"), new[] { "HydrometricSiteEndDate_Local" });
            }

            if (hydrometricSite.TimeOffset_hour != null)
            {
                if (hydrometricSite.TimeOffset_hour < -10 || hydrometricSite.TimeOffset_hour > 0)
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricSiteTimeOffset_hour", "-10", "0"), new[] { "TimeOffset_hour" });
                }
            }

            if (hydrometricSite.DrainageArea_km2 != null)
            {
                if (hydrometricSite.DrainageArea_km2 < 0 || hydrometricSite.DrainageArea_km2 > 1000000)
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricSiteDrainageArea_km2", "0", "1000000"), new[] { "DrainageArea_km2" });
                }
            }

            if (hydrometricSite.LastUpdateDate_UTC.Year == 1)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (hydrometricSite.LastUpdateDate_UTC.Year < 1980)
                {
                hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricSiteLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricSiteLastUpdateContactTVItemID", hydrometricSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricSiteLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public HydrometricSite GetHydrometricSiteWithHydrometricSiteID(int HydrometricSiteID)
        {
            return (from c in db.HydrometricSites
                    where c.HydrometricSiteID == HydrometricSiteID
                    select c).FirstOrDefault();

        }
        public IQueryable<HydrometricSite> GetHydrometricSiteList()
        {
            IQueryable<HydrometricSite> HydrometricSiteQuery = (from c in db.HydrometricSites select c);

            HydrometricSiteQuery = EnhanceQueryStatements<HydrometricSite>(HydrometricSiteQuery) as IQueryable<HydrometricSite>;

            return HydrometricSiteQuery;
        }
        public HydrometricSiteWeb GetHydrometricSiteWebWithHydrometricSiteID(int HydrometricSiteID)
        {
            return FillHydrometricSiteWeb().Where(c => c.HydrometricSiteID == HydrometricSiteID).FirstOrDefault();

        }
        public IQueryable<HydrometricSiteWeb> GetHydrometricSiteWebList()
        {
            IQueryable<HydrometricSiteWeb> HydrometricSiteWebQuery = FillHydrometricSiteWeb();

            HydrometricSiteWebQuery = EnhanceQueryStatements<HydrometricSiteWeb>(HydrometricSiteWebQuery) as IQueryable<HydrometricSiteWeb>;

            return HydrometricSiteWebQuery;
        }
        public HydrometricSiteReport GetHydrometricSiteReportWithHydrometricSiteID(int HydrometricSiteID)
        {
            return FillHydrometricSiteReport().Where(c => c.HydrometricSiteID == HydrometricSiteID).FirstOrDefault();

        }
        public IQueryable<HydrometricSiteReport> GetHydrometricSiteReportList()
        {
            IQueryable<HydrometricSiteReport> HydrometricSiteReportQuery = FillHydrometricSiteReport();

            HydrometricSiteReportQuery = EnhanceQueryStatements<HydrometricSiteReport>(HydrometricSiteReportQuery) as IQueryable<HydrometricSiteReport>;

            return HydrometricSiteReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(HydrometricSite hydrometricSite)
        {
            hydrometricSite.ValidationResults = Validate(new ValidationContext(hydrometricSite), ActionDBTypeEnum.Create);
            if (hydrometricSite.ValidationResults.Count() > 0) return false;

            db.HydrometricSites.Add(hydrometricSite);

            if (!TryToSave(hydrometricSite)) return false;

            return true;
        }
        public bool Delete(HydrometricSite hydrometricSite)
        {
            hydrometricSite.ValidationResults = Validate(new ValidationContext(hydrometricSite), ActionDBTypeEnum.Delete);
            if (hydrometricSite.ValidationResults.Count() > 0) return false;

            db.HydrometricSites.Remove(hydrometricSite);

            if (!TryToSave(hydrometricSite)) return false;

            return true;
        }
        public bool Update(HydrometricSite hydrometricSite)
        {
            hydrometricSite.ValidationResults = Validate(new ValidationContext(hydrometricSite), ActionDBTypeEnum.Update);
            if (hydrometricSite.ValidationResults.Count() > 0) return false;

            db.HydrometricSites.Update(hydrometricSite);

            if (!TryToSave(hydrometricSite)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated HydrometricSiteFillWeb
        private IQueryable<HydrometricSiteWeb> FillHydrometricSiteWeb()
        {
             IQueryable<HydrometricSiteWeb> HydrometricSiteWebQuery = (from c in db.HydrometricSites
                let HydrometricTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.HydrometricSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new HydrometricSiteWeb
                    {
                        HydrometricTVItemLanguage = HydrometricTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        HydrometricSiteID = c.HydrometricSiteID,
                        HydrometricSiteTVItemID = c.HydrometricSiteTVItemID,
                        FedSiteNumber = c.FedSiteNumber,
                        QuebecSiteNumber = c.QuebecSiteNumber,
                        HydrometricSiteName = c.HydrometricSiteName,
                        Description = c.Description,
                        Province = c.Province,
                        Elevation_m = c.Elevation_m,
                        StartDate_Local = c.StartDate_Local,
                        EndDate_Local = c.EndDate_Local,
                        TimeOffset_hour = c.TimeOffset_hour,
                        DrainageArea_km2 = c.DrainageArea_km2,
                        IsNatural = c.IsNatural,
                        IsActive = c.IsActive,
                        Sediment = c.Sediment,
                        RHBN = c.RHBN,
                        RealTime = c.RealTime,
                        HasRatingCurve = c.HasRatingCurve,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return HydrometricSiteWebQuery;
        }
        #endregion Functions private Generated HydrometricSiteFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(HydrometricSite hydrometricSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                hydrometricSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
