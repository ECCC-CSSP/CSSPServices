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
    public partial class HydrometricSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public HydrometricSiteService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteID"), new[] { "HydrometricSiteID" });
                }

                if (!(from c in db.HydrometricSites select c).Where(c => c.HydrometricSiteID == hydrometricSite.HydrometricSiteID).Any())
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricSite.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
                }
            }

            TVItem TVItemHydrometricSiteTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricSite.HydrometricSiteTVItemID select c).FirstOrDefault();

            if (TVItemHydrometricSiteTVItemID == null)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricSiteTVItemID", hydrometricSite.HydrometricSiteTVItemID.ToString()), new[] { "HydrometricSiteTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricSiteTVItemID", "HydrometricSite"), new[] { "HydrometricSiteTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.FedSiteNumber) && hydrometricSite.FedSiteNumber.Length > 7)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "FedSiteNumber", "7"), new[] { "FedSiteNumber" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.QuebecSiteNumber) && hydrometricSite.QuebecSiteNumber.Length > 7)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "QuebecSiteNumber", "7"), new[] { "QuebecSiteNumber" });
            }

            if (string.IsNullOrWhiteSpace(hydrometricSite.HydrometricSiteName))
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricSiteName"), new[] { "HydrometricSiteName" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.HydrometricSiteName) && hydrometricSite.HydrometricSiteName.Length > 200)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "HydrometricSiteName", "200"), new[] { "HydrometricSiteName" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.Description) && hydrometricSite.Description.Length > 200)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "Description", "200"), new[] { "Description" });
            }

            if (string.IsNullOrWhiteSpace(hydrometricSite.Province))
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Province"), new[] { "Province" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricSite.Province) && hydrometricSite.Province.Length > 4)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "Province", "4"), new[] { "Province" });
            }

            if (hydrometricSite.Elevation_m != null)
            {
                if (hydrometricSite.Elevation_m < 0 || hydrometricSite.Elevation_m > 10000)
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Elevation_m", "0", "10000"), new[] { "Elevation_m" });
                }
            }

            if (hydrometricSite.StartDate_Local != null && ((DateTime)hydrometricSite.StartDate_Local).Year < 1849)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "StartDate_Local", "1849"), new[] { "StartDate_Local" });
            }

            if (hydrometricSite.EndDate_Local != null && ((DateTime)hydrometricSite.EndDate_Local).Year < 1849)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EndDate_Local", "1849"), new[] { "EndDate_Local" });
            }

            if (hydrometricSite.StartDate_Local > hydrometricSite.EndDate_Local)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "EndDate_Local", "HydrometricSiteStartDate_Local"), new[] { "EndDate_Local" });
            }

            if (hydrometricSite.TimeOffset_hour != null)
            {
                if (hydrometricSite.TimeOffset_hour < -10 || hydrometricSite.TimeOffset_hour > 0)
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TimeOffset_hour", "-10", "0"), new[] { "TimeOffset_hour" });
                }
            }

            if (hydrometricSite.DrainageArea_km2 != null)
            {
                if (hydrometricSite.DrainageArea_km2 < 0 || hydrometricSite.DrainageArea_km2 > 1000000)
                {
                    hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DrainageArea_km2", "0", "1000000"), new[] { "DrainageArea_km2" });
                }
            }

            if (hydrometricSite.LastUpdateDate_UTC.Year == 1)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (hydrometricSite.LastUpdateDate_UTC.Year < 1980)
                {
                hydrometricSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                hydrometricSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", hydrometricSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
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
