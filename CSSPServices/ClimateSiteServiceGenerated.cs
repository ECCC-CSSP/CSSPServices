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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateSiteService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            ClimateSite climateSite = validationContext.ObjectInstance as ClimateSite;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (climateSite.ClimateSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteID), new[] { ModelsRes.ClimateSiteClimateSiteID });
                }
            }

            //ClimateSiteTVItemID (int) is required but no testing needed as it is automatically set to 0

            //ECDBID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(climateSite.ClimateSiteName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteClimateSiteName), new[] { ModelsRes.ClimateSiteClimateSiteName });
            }

            if (string.IsNullOrWhiteSpace(climateSite.Province))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteProvince), new[] { ModelsRes.ClimateSiteProvince });
            }

            if (climateSite.LastUpdateDate_UTC == null || climateSite.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ClimateSiteLastUpdateDate_UTC), new[] { ModelsRes.ClimateSiteLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (climateSite.ClimateSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateSiteClimateSiteTVItemID, "1"), new[] { ModelsRes.ClimateSiteClimateSiteTVItemID });
            }

            if (climateSite.ECDBID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateSiteECDBID, "1"), new[] { ModelsRes.ClimateSiteECDBID });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ClimateSiteName) && climateSite.ClimateSiteName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateSiteName, "100"), new[] { ModelsRes.ClimateSiteClimateSiteName });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.Province) && climateSite.Province.Length > 4)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvince, "4"), new[] { ModelsRes.ClimateSiteProvince });
            }

                //Error: Type not implemented [Elevation_m] of type [double]
            if (!string.IsNullOrWhiteSpace(climateSite.ClimateID) && climateSite.ClimateID.Length > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteClimateID, "10"), new[] { ModelsRes.ClimateSiteClimateID });
            }

            if (climateSite.WMOID < 1 || climateSite.WMOID > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.ClimateSiteWMOID, "1", "1000000"), new[] { ModelsRes.ClimateSiteWMOID });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.TCID) && climateSite.TCID.Length > 3)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteTCID, "3"), new[] { ModelsRes.ClimateSiteTCID });
            }

            if (!string.IsNullOrWhiteSpace(climateSite.ProvSiteID) && climateSite.ProvSiteID.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteProvSiteID, "50"), new[] { ModelsRes.ClimateSiteProvSiteID });
            }

                //Error: Type not implemented [TimeOffset_hour] of type [double]
            if (!string.IsNullOrWhiteSpace(climateSite.File_desc) && climateSite.File_desc.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ClimateSiteFile_desc, "50"), new[] { ModelsRes.ClimateSiteFile_desc });
            }

            if (climateSite.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ClimateSiteLastUpdateContactTVItemID, "1"), new[] { ModelsRes.ClimateSiteLastUpdateContactTVItemID });
            }

                //Error: Type not implemented [Elevation_m] of type [double]
                //Error: Type not implemented [TimeOffset_hour] of type [double]

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
