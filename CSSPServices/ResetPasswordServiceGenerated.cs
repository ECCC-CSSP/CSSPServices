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
    public partial class ResetPasswordService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            ResetPassword resetPassword = validationContext.ObjectInstance as ResetPassword;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (resetPassword.ResetPasswordID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordResetPasswordID), new[] { ModelsRes.ResetPasswordResetPasswordID });
                }
            }

            //ResetPasswordID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(resetPassword.Email))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordEmail), new[] { ModelsRes.ResetPasswordEmail });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Email) && resetPassword.Email.Length > 256)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ResetPasswordEmail, "256"), new[] { ModelsRes.ResetPasswordEmail });
            }

            if (resetPassword.ExpireDate_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordExpireDate_Local), new[] { ModelsRes.ResetPasswordExpireDate_Local });
            }

            if (resetPassword.ExpireDate_Local.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ResetPasswordExpireDate_Local, "1980"), new[] { ModelsRes.ResetPasswordExpireDate_Local });
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Code))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordCode), new[] { ModelsRes.ResetPasswordCode });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Code) && resetPassword.Code.Length > 8)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ResetPasswordCode, "8"), new[] { ModelsRes.ResetPasswordCode });
            }

            if (resetPassword.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordLastUpdateDate_UTC), new[] { ModelsRes.ResetPasswordLastUpdateDate_UTC });
            }

            if (resetPassword.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ResetPasswordLastUpdateDate_UTC, "1980"), new[] { ModelsRes.ResetPasswordLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (resetPassword.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ResetPasswordLastUpdateContactTVItemID, "1"), new[] { ModelsRes.ResetPasswordLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == resetPassword.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ResetPasswordLastUpdateContactTVItemID, resetPassword.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.ResetPasswordLastUpdateContactTVItemID });
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Password))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordPassword), new[] { ModelsRes.ResetPasswordPassword });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Password) && (resetPassword.Password.Length < 6 || resetPassword.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordPassword, "6", "100"), new[] { ModelsRes.ResetPasswordPassword });
            }

            if (string.IsNullOrWhiteSpace(resetPassword.ConfirmPassword))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordConfirmPassword), new[] { ModelsRes.ResetPasswordConfirmPassword });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.ConfirmPassword) && (resetPassword.ConfirmPassword.Length < 6 || resetPassword.ConfirmPassword.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordConfirmPassword, "6", "100"), new[] { ModelsRes.ResetPasswordConfirmPassword });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(ResetPassword resetPassword)
        {
            resetPassword.ValidationResults = Validate(new ValidationContext(resetPassword), ActionDBTypeEnum.Create);
            if (resetPassword.ValidationResults.Count() > 0) return false;

            db.ResetPasswords.Add(resetPassword);

            if (!TryToSave(resetPassword)) return false;

            return true;
        }
        public bool AddRange(List<ResetPassword> resetPasswordList)
        {
            foreach (ResetPassword resetPassword in resetPasswordList)
            {
                resetPassword.ValidationResults = Validate(new ValidationContext(resetPassword), ActionDBTypeEnum.Create);
                if (resetPassword.ValidationResults.Count() > 0) return false;
            }

            db.ResetPasswords.AddRange(resetPasswordList);

            if (!TryToSaveRange(resetPasswordList)) return false;

            return true;
        }
        public bool Delete(ResetPassword resetPassword)
        {
            if (!db.ResetPasswords.Where(c => c.ResetPasswordID == resetPassword.ResetPasswordID).Any())
            {
                resetPassword.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ResetPassword", "ResetPasswordID", resetPassword.ResetPasswordID.ToString())) }.AsEnumerable();
                return false;
            }

            db.ResetPasswords.Remove(resetPassword);

            if (!TryToSave(resetPassword)) return false;

            return true;
        }
        public bool DeleteRange(List<ResetPassword> resetPasswordList)
        {
            foreach (ResetPassword resetPassword in resetPasswordList)
            {
                if (!db.ResetPasswords.Where(c => c.ResetPasswordID == resetPassword.ResetPasswordID).Any())
                {
                    resetPasswordList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ResetPassword", "ResetPasswordID", resetPassword.ResetPasswordID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.ResetPasswords.RemoveRange(resetPasswordList);

            if (!TryToSaveRange(resetPasswordList)) return false;

            return true;
        }
        public bool Update(ResetPassword resetPassword)
        {
            resetPassword.ValidationResults = Validate(new ValidationContext(resetPassword), ActionDBTypeEnum.Update);
            if (resetPassword.ValidationResults.Count() > 0) return false;

            db.ResetPasswords.Update(resetPassword);

            if (!TryToSave(resetPassword)) return false;

            return true;
        }
        public bool UpdateRange(List<ResetPassword> resetPasswordList)
        {
            foreach (ResetPassword resetPassword in resetPasswordList)
            {
                resetPassword.ValidationResults = Validate(new ValidationContext(resetPassword), ActionDBTypeEnum.Update);
                if (resetPassword.ValidationResults.Count() > 0) return false;
            }
            db.ResetPasswords.UpdateRange(resetPasswordList);

            if (!TryToSaveRange(resetPasswordList)) return false;

            return true;
        }
        public IQueryable<ResetPassword> GetRead()
        {
            return db.ResetPasswords.AsNoTracking();
        }
        public IQueryable<ResetPassword> GetEdit()
        {
            return db.ResetPasswords;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(ResetPassword resetPassword)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                resetPassword.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<ResetPassword> resetPasswordList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                resetPasswordList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
