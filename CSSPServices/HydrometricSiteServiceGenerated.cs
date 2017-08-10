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
    public partial class HydrometricSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricSiteService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            HydrometricSite hydrometricSite = validationContext.ObjectInstance as HydrometricSite;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (hydrometricSite.HydrometricSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteHydrometricSiteID), new[] { "HydrometricSiteID" });
                }
            }

            //HydrometricSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //HydrometricSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemHydrometricSiteTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricSite.HydrometricSiteTVItemID select c).FirstOrDefault();

            if (TVItemHydrometricSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.HydrometricSiteHydrometricSiteTVItemID, hydrometricSite.HydrometricSiteTVItemID.ToString()), new[] { "HydrometricSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.HydrometricSite,
                };
                if (!AllowableTVTypes.Contains(TVItemHydrometricSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.HydrometricSiteHydrometricSiteTVItemID, "HydrometricSite"), new[] { "HydrometricSiteTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.FedSiteNumber) && hydrometricSite.FedSiteNumber.Length > 7)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteFedSiteNumber, "7"), new[] { "FedSiteNumber" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.QuebecSiteNumber) && hydrometricSite.QuebecSiteNumber.Length > 7)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteQuebecSiteNumber, "7"), new[] { "QuebecSiteNumber" });
            }

            if (string.IsNullOrWhiteSpace(hydrometricSite.HydrometricSiteName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteHydrometricSiteName), new[] { "HydrometricSiteName" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.HydrometricSiteName) && hydrometricSite.HydrometricSiteName.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteHydrometricSiteName, "200"), new[] { "HydrometricSiteName" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.Description) && hydrometricSite.Description.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteDescription, "200"), new[] { "Description" });
            }

            if (string.IsNullOrWhiteSpace(hydrometricSite.Province))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteProvince), new[] { "Province" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.Province) && hydrometricSite.Province.Length > 4)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteProvince, "4"), new[] { "Province" });
            }

            if (hydrometricSite.Elevation_m != null)
            {
                if (hydrometricSite.Elevation_m < 0 || hydrometricSite.Elevation_m > 10000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteElevation_m, "0", "10000"), new[] { "Elevation_m" });
                }
            }

            if (hydrometricSite.StartDate_Local != null && ((DateTime)hydrometricSite.StartDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.HydrometricSiteStartDate_Local, "1980"), new[] { ModelsRes.HydrometricSiteStartDate_Local });
            }

            if (hydrometricSite.EndDate_Local != null && ((DateTime)hydrometricSite.EndDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.HydrometricSiteEndDate_Local, "1980"), new[] { ModelsRes.HydrometricSiteEndDate_Local });
            }

            if (hydrometricSite.StartDate_Local > hydrometricSite.EndDate_Local)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.HydrometricSiteEndDate_Local, ModelsRes.HydrometricSiteStartDate_Local), new[] { ModelsRes.HydrometricSiteEndDate_Local });
            }

            if (hydrometricSite.TimeOffset_hour != null)
            {
                if (hydrometricSite.TimeOffset_hour < -10 || hydrometricSite.TimeOffset_hour > 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteTimeOffset_hour, "-10", "0"), new[] { "TimeOffset_hour" });
                }
            }

            if (hydrometricSite.DrainageArea_km2 != null)
            {
                if (hydrometricSite.DrainageArea_km2 < 0 || hydrometricSite.DrainageArea_km2 > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricSiteDrainageArea_km2, "0", "1000000"), new[] { "DrainageArea_km2" });
                }
            }

            if (hydrometricSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricSiteLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (hydrometricSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.HydrometricSiteLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.HydrometricSiteLastUpdateContactTVItemID, hydrometricSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.HydrometricSiteLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.HydrometricTVText) && hydrometricSite.HydrometricTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteHydrometricTVText, "200"), new[] { "HydrometricTVText" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.LastUpdateContactTVText) && hydrometricSite.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricSiteLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public HydrometricSite GetHydrometricSiteWithHydrometricSiteID(int HydrometricSiteID)
        {
            IQueryable<HydrometricSite> hydrometricSiteQuery = (from c in GetRead()
                                                where c.HydrometricSiteID == HydrometricSiteID
                                                select c);

            return FillHydrometricSite(hydrometricSiteQuery).FirstOrDefault();
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
            if (!db.HydrometricSites.Where(c => c.HydrometricSiteID == hydrometricSite.HydrometricSiteID).Any())
            {
                hydrometricSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricSite.HydrometricSiteID.ToString())) }.AsEnumerable();
                return false;
            }

            db.HydrometricSites.Remove(hydrometricSite);

            if (!TryToSave(hydrometricSite)) return false;

            return true;
        }
        public bool Update(HydrometricSite hydrometricSite)
        {
            if (!db.HydrometricSites.Where(c => c.HydrometricSiteID == hydrometricSite.HydrometricSiteID).Any())
            {
                hydrometricSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricSite.HydrometricSiteID.ToString())) }.AsEnumerable();
                return false;
            }

            hydrometricSite.ValidationResults = Validate(new ValidationContext(hydrometricSite), ActionDBTypeEnum.Update);
            if (hydrometricSite.ValidationResults.Count() > 0) return false;

            db.HydrometricSites.Update(hydrometricSite);

            if (!TryToSave(hydrometricSite)) return false;

            return true;
        }
        public IQueryable<HydrometricSite> GetRead()
        {
            return db.HydrometricSites.AsNoTracking();
        }
        public IQueryable<HydrometricSite> GetEdit()
        {
            return db.HydrometricSites;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<HydrometricSite> FillHydrometricSite(IQueryable<HydrometricSite> hydrometricSiteQuery)
        {
            List<HydrometricSite> HydrometricSiteList = (from c in hydrometricSiteQuery
                                         let HydrometricTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.HydrometricSiteTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new HydrometricSite
                                         {
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
                                             HydrometricTVText = HydrometricTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return HydrometricSiteList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
