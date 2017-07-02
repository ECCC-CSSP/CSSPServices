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
    public partial class TVItemUserAuthorizationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemUserAuthorization tvItemUserAuthorization = validationContext.ObjectInstance as TVItemUserAuthorization;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvItemUserAuthorization.TVItemUserAuthorizationID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID), new[] { ModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID });
                }
            }

            //ContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            //TVItemID1 (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.TVAuthOK(tvItemUserAuthorization.TVAuth);
            if (tvItemUserAuthorization.TVAuth == TVAuthEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVAuth), new[] { ModelsRes.TVItemUserAuthorizationTVAuth });
            }

            if (tvItemUserAuthorization.LastUpdateDate_UTC == null || tvItemUserAuthorization.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC), new[] { ModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (tvItemUserAuthorization.ContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationContactTVItemID, "1"), new[] { ModelsRes.TVItemUserAuthorizationContactTVItemID });
            }

            if (tvItemUserAuthorization.TVItemID1 < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID1, "1"), new[] { ModelsRes.TVItemUserAuthorizationTVItemID1 });
            }

            if (tvItemUserAuthorization.TVItemID2 < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID2, "1"), new[] { ModelsRes.TVItemUserAuthorizationTVItemID2 });
            }

            if (tvItemUserAuthorization.TVItemID3 < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID3, "1"), new[] { ModelsRes.TVItemUserAuthorizationTVItemID3 });
            }

            if (tvItemUserAuthorization.TVItemID4 < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID4, "1"), new[] { ModelsRes.TVItemUserAuthorizationTVItemID4 });
            }

            if (tvItemUserAuthorization.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(TVItemUserAuthorization tvItemUserAuthorization)
        {
            tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Create);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVItemUserAuthorizations.Add(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        public bool AddRange(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
            foreach (TVItemUserAuthorization tvItemUserAuthorization in tvItemUserAuthorizationList)
            {
                tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Create);
                if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;
            }

            db.TVItemUserAuthorizations.AddRange(tvItemUserAuthorizationList);

            if (!TryToSaveRange(tvItemUserAuthorizationList)) return false;

            return true;
        }
        public bool Delete(TVItemUserAuthorization tvItemUserAuthorization)
        {
            if (!db.TVItemUserAuthorizations.Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorization.TVItemUserAuthorizationID).Any())
            {
                tvItemUserAuthorization.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", tvItemUserAuthorization.TVItemUserAuthorizationID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVItemUserAuthorizations.Remove(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        public bool DeleteRange(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
            foreach (TVItemUserAuthorization tvItemUserAuthorization in tvItemUserAuthorizationList)
            {
                if (!db.TVItemUserAuthorizations.Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorization.TVItemUserAuthorizationID).Any())
                {
                    tvItemUserAuthorizationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", tvItemUserAuthorization.TVItemUserAuthorizationID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVItemUserAuthorizations.RemoveRange(tvItemUserAuthorizationList);

            if (!TryToSaveRange(tvItemUserAuthorizationList)) return false;

            return true;
        }
        public bool Update(TVItemUserAuthorization tvItemUserAuthorization)
        {
            tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Update);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVItemUserAuthorizations.Update(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        public bool UpdateRange(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
            foreach (TVItemUserAuthorization tvItemUserAuthorization in tvItemUserAuthorizationList)
            {
                tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Update);
                if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;
            }
            db.TVItemUserAuthorizations.UpdateRange(tvItemUserAuthorizationList);

            if (!TryToSaveRange(tvItemUserAuthorizationList)) return false;

            return true;
        }
        public IQueryable<TVItemUserAuthorization> GetRead()
        {
            return db.TVItemUserAuthorizations.AsNoTracking();
        }
        public IQueryable<TVItemUserAuthorization> GetEdit()
        {
            return db.TVItemUserAuthorizations;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TVItemUserAuthorization tvItemUserAuthorization)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemUserAuthorization.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemUserAuthorizationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
