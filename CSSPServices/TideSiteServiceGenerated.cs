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
    public partial class TideSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            TideSite tideSite = validationContext.ObjectInstance as TideSite;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tideSite.TideSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteTideSiteID), new[] { ModelsRes.TideSiteTideSiteID });
                }
            }

            //TideSiteTVItemID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(tideSite.WebTideModel))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteWebTideModel), new[] { ModelsRes.TideSiteWebTideModel });
            }

            //WebTideDatum_m (float) is required but no testing needed as it is automatically set to 0.0f

            if (tideSite.LastUpdateDate_UTC == null || tideSite.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteLastUpdateDate_UTC), new[] { ModelsRes.TideSiteLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (tideSite.TideSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TideSiteTideSiteTVItemID, "1"), new[] { ModelsRes.TideSiteTideSiteTVItemID });
            }

            if (!string.IsNullOrWhiteSpace(tideSite.WebTideModel) && tideSite.WebTideModel.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideSiteWebTideModel, "100"), new[] { ModelsRes.TideSiteWebTideModel });
            }

            if (tideSite.WebTideDatum_m < 0 || tideSite.WebTideDatum_m > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideSiteWebTideDatum_m, "0", "100"), new[] { ModelsRes.TideSiteWebTideDatum_m });
            }

            if (tideSite.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TideSiteLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TideSiteLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Create);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Add(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool AddRange(List<TideSite> tideSiteList)
        {
            foreach (TideSite tideSite in tideSiteList)
            {
                tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Create);
                if (tideSite.ValidationResults.Count() > 0) return false;
            }

            db.TideSites.AddRange(tideSiteList);

            if (!TryToSaveRange(tideSiteList)) return false;

            return true;
        }
        public bool Delete(TideSite tideSite)
        {
            if (!db.TideSites.Where(c => c.TideSiteID == tideSite.TideSiteID).Any())
            {
                tideSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", tideSite.TideSiteID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TideSites.Remove(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool DeleteRange(List<TideSite> tideSiteList)
        {
            foreach (TideSite tideSite in tideSiteList)
            {
                if (!db.TideSites.Where(c => c.TideSiteID == tideSite.TideSiteID).Any())
                {
                    tideSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", tideSite.TideSiteID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TideSites.RemoveRange(tideSiteList);

            if (!TryToSaveRange(tideSiteList)) return false;

            return true;
        }
        public bool Update(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Update);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Update(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool UpdateRange(List<TideSite> tideSiteList)
        {
            foreach (TideSite tideSite in tideSiteList)
            {
                tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Update);
                if (tideSite.ValidationResults.Count() > 0) return false;
            }
            db.TideSites.UpdateRange(tideSiteList);

            if (!TryToSaveRange(tideSiteList)) return false;

            return true;
        }
        public IQueryable<TideSite> GetRead()
        {
            return db.TideSites.AsNoTracking();
        }
        public IQueryable<TideSite> GetEdit()
        {
            return db.TideSites;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TideSite tideSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TideSite> tideSiteList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
