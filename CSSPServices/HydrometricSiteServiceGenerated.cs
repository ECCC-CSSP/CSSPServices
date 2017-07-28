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
                if (TVItemHydrometricSiteTVItemID.TVType != TVTypeEnum.HydrometricSite)
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
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.HydrometricSiteLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(HydrometricSite hydrometricSite)
        {
            hydrometricSite.ValidationResults = Validate(new ValidationContext(hydrometricSite), ActionDBTypeEnum.Create);
            if (hydrometricSite.ValidationResults.Count() > 0) return false;

            db.HydrometricSites.Add(hydrometricSite);

            if (!TryToSave(hydrometricSite)) return false;

            return true;
        }
        public bool AddRange(List<HydrometricSite> hydrometricSiteList)
        {
            foreach (HydrometricSite hydrometricSite in hydrometricSiteList)
            {
                hydrometricSite.ValidationResults = Validate(new ValidationContext(hydrometricSite), ActionDBTypeEnum.Create);
                if (hydrometricSite.ValidationResults.Count() > 0) return false;
            }

            db.HydrometricSites.AddRange(hydrometricSiteList);

            if (!TryToSaveRange(hydrometricSiteList)) return false;

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
        public bool DeleteRange(List<HydrometricSite> hydrometricSiteList)
        {
            foreach (HydrometricSite hydrometricSite in hydrometricSiteList)
            {
                if (!db.HydrometricSites.Where(c => c.HydrometricSiteID == hydrometricSite.HydrometricSiteID).Any())
                {
                    hydrometricSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricSite.HydrometricSiteID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.HydrometricSites.RemoveRange(hydrometricSiteList);

            if (!TryToSaveRange(hydrometricSiteList)) return false;

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
        public bool UpdateRange(List<HydrometricSite> hydrometricSiteList)
        {
            foreach (HydrometricSite hydrometricSite in hydrometricSiteList)
            {
                hydrometricSite.ValidationResults = Validate(new ValidationContext(hydrometricSite), ActionDBTypeEnum.Update);
                if (hydrometricSite.ValidationResults.Count() > 0) return false;
            }
            db.HydrometricSites.UpdateRange(hydrometricSiteList);

            if (!TryToSaveRange(hydrometricSiteList)) return false;

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
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<HydrometricSite> hydrometricSiteList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                hydrometricSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
