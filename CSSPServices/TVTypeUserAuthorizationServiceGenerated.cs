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
    public partial class TVTypeUserAuthorizationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVTypeUserAuthorization tvTypeUserAuthorization = validationContext.ObjectInstance as TVTypeUserAuthorization;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvTypeUserAuthorization.TVTypeUserAuthorizationID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID), new[] { ModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID });
                }
            }

            //TVTypeUserAuthorizationID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvTypeUserAuthorization.ContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVTypeUserAuthorizationContactTVItemID, "1"), new[] { ModelsRes.TVTypeUserAuthorizationContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.ContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVTypeUserAuthorizationContactTVItemID, tvTypeUserAuthorization.ContactTVItemID.ToString()), new[] { ModelsRes.TVTypeUserAuthorizationContactTVItemID });
            }

            retStr = enums.TVTypeOK(tvTypeUserAuthorization.TVType);
            if (tvTypeUserAuthorization.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVType), new[] { ModelsRes.TVTypeUserAuthorizationTVType });
            }

            retStr = enums.TVAuthOK(tvTypeUserAuthorization.TVAuth);
            if (tvTypeUserAuthorization.TVAuth == TVAuthEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVAuth), new[] { ModelsRes.TVTypeUserAuthorizationTVAuth });
            }

            if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC), new[] { ModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC });
            }
            else
            {
                if (tvTypeUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC, "1980"), new[] { ModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvTypeUserAuthorization.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvTypeUserAuthorization.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            tvTypeUserAuthorization.ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Create);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVTypeUserAuthorizations.Add(tvTypeUserAuthorization);

            if (!TryToSave(tvTypeUserAuthorization)) return false;

            return true;
        }
        public bool AddRange(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
            foreach (TVTypeUserAuthorization tvTypeUserAuthorization in tvTypeUserAuthorizationList)
            {
                tvTypeUserAuthorization.ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Create);
                if (tvTypeUserAuthorization.ValidationResults.Count() > 0) return false;
            }

            db.TVTypeUserAuthorizations.AddRange(tvTypeUserAuthorizationList);

            if (!TryToSaveRange(tvTypeUserAuthorizationList)) return false;

            return true;
        }
        public bool Delete(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            if (!db.TVTypeUserAuthorizations.Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorization.TVTypeUserAuthorizationID).Any())
            {
                tvTypeUserAuthorization.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVTypeUserAuthorizations.Remove(tvTypeUserAuthorization);

            if (!TryToSave(tvTypeUserAuthorization)) return false;

            return true;
        }
        public bool DeleteRange(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
            foreach (TVTypeUserAuthorization tvTypeUserAuthorization in tvTypeUserAuthorizationList)
            {
                if (!db.TVTypeUserAuthorizations.Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorization.TVTypeUserAuthorizationID).Any())
                {
                    tvTypeUserAuthorizationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationID", tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVTypeUserAuthorizations.RemoveRange(tvTypeUserAuthorizationList);

            if (!TryToSaveRange(tvTypeUserAuthorizationList)) return false;

            return true;
        }
        public bool Update(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            tvTypeUserAuthorization.ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Update);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVTypeUserAuthorizations.Update(tvTypeUserAuthorization);

            if (!TryToSave(tvTypeUserAuthorization)) return false;

            return true;
        }
        public bool UpdateRange(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
            foreach (TVTypeUserAuthorization tvTypeUserAuthorization in tvTypeUserAuthorizationList)
            {
                tvTypeUserAuthorization.ValidationResults = Validate(new ValidationContext(tvTypeUserAuthorization), ActionDBTypeEnum.Update);
                if (tvTypeUserAuthorization.ValidationResults.Count() > 0) return false;
            }
            db.TVTypeUserAuthorizations.UpdateRange(tvTypeUserAuthorizationList);

            if (!TryToSaveRange(tvTypeUserAuthorizationList)) return false;

            return true;
        }
        public IQueryable<TVTypeUserAuthorization> GetRead()
        {
            return db.TVTypeUserAuthorizations.AsNoTracking();
        }
        public IQueryable<TVTypeUserAuthorization> GetEdit()
        {
            return db.TVTypeUserAuthorizations;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TVTypeUserAuthorization tvTypeUserAuthorization)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvTypeUserAuthorization.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvTypeUserAuthorizationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
