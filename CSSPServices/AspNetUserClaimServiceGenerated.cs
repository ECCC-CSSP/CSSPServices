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
    public partial class AspNetUserClaimService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserClaimService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            AspNetUserClaim aspNetUserClaim = validationContext.ObjectInstance as AspNetUserClaim;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (aspNetUserClaim.Id == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetUserClaimId), new[] { ModelsRes.AspNetUserClaimId });
                }
            }

            if (string.IsNullOrWhiteSpace(aspNetUserClaim.UserId))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetUserClaimUserId), new[] { ModelsRes.AspNetUserClaimUserId });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(aspNetUserClaim.UserId) && aspNetUserClaim.UserId.Length > 128)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AspNetUserClaimUserId, "128"), new[] { ModelsRes.AspNetUserClaimUserId });
            }

            // ClaimType has no validation

            // ClaimValue has no validation


        }
        #endregion Validation

        #region Functions public
        public bool Add(AspNetUserClaim aspNetUserClaim)
        {
            aspNetUserClaim.ValidationResults = Validate(new ValidationContext(aspNetUserClaim), ActionDBTypeEnum.Create);
            if (aspNetUserClaim.ValidationResults.Count() > 0) return false;

            db.AspNetUserClaims.Add(aspNetUserClaim);

            if (!TryToSave(aspNetUserClaim)) return false;

            return true;
        }
        public bool AddRange(List<AspNetUserClaim> aspNetUserClaimList)
        {
            foreach (AspNetUserClaim aspNetUserClaim in aspNetUserClaimList)
            {
                aspNetUserClaim.ValidationResults = Validate(new ValidationContext(aspNetUserClaim), ActionDBTypeEnum.Create);
                if (aspNetUserClaim.ValidationResults.Count() > 0) return false;
            }

            db.AspNetUserClaims.AddRange(aspNetUserClaimList);

            if (!TryToSaveRange(aspNetUserClaimList)) return false;

            return true;
        }
        public bool Delete(AspNetUserClaim aspNetUserClaim)
        {
            if (!db.AspNetUserClaims.Where(c => c.Id == aspNetUserClaim.Id).Any())
            {
                aspNetUserClaim.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetUserClaim", "Id", aspNetUserClaim.Id.ToString())) }.AsEnumerable();
                return false;
            }

            db.AspNetUserClaims.Remove(aspNetUserClaim);

            if (!TryToSave(aspNetUserClaim)) return false;

            return true;
        }
        public bool DeleteRange(List<AspNetUserClaim> aspNetUserClaimList)
        {
            foreach (AspNetUserClaim aspNetUserClaim in aspNetUserClaimList)
            {
                if (!db.AspNetUserClaims.Where(c => c.Id == aspNetUserClaim.Id).Any())
                {
                    aspNetUserClaimList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetUserClaim", "Id", aspNetUserClaim.Id.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.AspNetUserClaims.RemoveRange(aspNetUserClaimList);

            if (!TryToSaveRange(aspNetUserClaimList)) return false;

            return true;
        }
        public bool Update(AspNetUserClaim aspNetUserClaim)
        {
            aspNetUserClaim.ValidationResults = Validate(new ValidationContext(aspNetUserClaim), ActionDBTypeEnum.Update);
            if (aspNetUserClaim.ValidationResults.Count() > 0) return false;

            db.AspNetUserClaims.Update(aspNetUserClaim);

            if (!TryToSave(aspNetUserClaim)) return false;

            return true;
        }
        public bool UpdateRange(List<AspNetUserClaim> aspNetUserClaimList)
        {
            foreach (AspNetUserClaim aspNetUserClaim in aspNetUserClaimList)
            {
                aspNetUserClaim.ValidationResults = Validate(new ValidationContext(aspNetUserClaim), ActionDBTypeEnum.Update);
                if (aspNetUserClaim.ValidationResults.Count() > 0) return false;
            }
            db.AspNetUserClaims.UpdateRange(aspNetUserClaimList);

            if (!TryToSaveRange(aspNetUserClaimList)) return false;

            return true;
        }
        public IQueryable<AspNetUserClaim> GetRead()
        {
            return db.AspNetUserClaims.AsNoTracking();
        }
        public IQueryable<AspNetUserClaim> GetEdit()
        {
            return db.AspNetUserClaims;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(AspNetUserClaim aspNetUserClaim)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUserClaim.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<AspNetUserClaim> aspNetUserClaimList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUserClaimList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
