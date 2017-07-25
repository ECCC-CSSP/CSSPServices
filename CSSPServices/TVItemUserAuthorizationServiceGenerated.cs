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
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemUserAuthorization tvItemUserAuthorization = validationContext.ObjectInstance as TVItemUserAuthorization;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvItemUserAuthorization.TVItemUserAuthorizationID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID), new[] { ModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID });
                }
            }

            //TVItemUserAuthorizationID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemUserAuthorization.ContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationContactTVItemID, "1"), new[] { ModelsRes.TVItemUserAuthorizationContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.ContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationContactTVItemID, tvItemUserAuthorization.ContactTVItemID.ToString()), new[] { ModelsRes.TVItemUserAuthorizationContactTVItemID });
            }

            //TVItemID1 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemUserAuthorization.TVItemID1 < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID1, "1"), new[] { ModelsRes.TVItemUserAuthorizationTVItemID1 });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID1 select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID1, tvItemUserAuthorization.TVItemID1.ToString()), new[] { ModelsRes.TVItemUserAuthorizationTVItemID1 });
            }

            if (tvItemUserAuthorization.TVItemID2 != null)
            {
                if (tvItemUserAuthorization.TVItemID2 < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID2, "1"), new[] { ModelsRes.TVItemUserAuthorizationTVItemID2 });
                }
            }

            if (tvItemUserAuthorization.TVItemID2 != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID2 select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID2, tvItemUserAuthorization.TVItemID2.ToString()), new[] { ModelsRes.TVItemUserAuthorizationTVItemID2 });
                }
            }

            if (tvItemUserAuthorization.TVItemID3 != null)
            {
                if (tvItemUserAuthorization.TVItemID3 < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID3, "1"), new[] { ModelsRes.TVItemUserAuthorizationTVItemID3 });
                }
            }

            if (tvItemUserAuthorization.TVItemID3 != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID3 select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID3, tvItemUserAuthorization.TVItemID3.ToString()), new[] { ModelsRes.TVItemUserAuthorizationTVItemID3 });
                }
            }

            if (tvItemUserAuthorization.TVItemID4 != null)
            {
                if (tvItemUserAuthorization.TVItemID4 < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID4, "1"), new[] { ModelsRes.TVItemUserAuthorizationTVItemID4 });
                }
            }

            if (tvItemUserAuthorization.TVItemID4 != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID4 select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID4, tvItemUserAuthorization.TVItemID4.ToString()), new[] { ModelsRes.TVItemUserAuthorizationTVItemID4 });
                }
            }

            retStr = enums.TVAuthOK(tvItemUserAuthorization.TVAuth);
            if (tvItemUserAuthorization.TVAuth == TVAuthEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVAuth), new[] { ModelsRes.TVItemUserAuthorizationTVAuth });
            }

            if (tvItemUserAuthorization.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC), new[] { ModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC });
            }

            if (tvItemUserAuthorization.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC, "1980"), new[] { ModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemUserAuthorization.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
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
