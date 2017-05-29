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
        public ResetPasswordService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            ResetPassword resetPassword = validationContext.ObjectInstance as ResetPassword;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (resetPassword.ResetPasswordID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordResetPasswordID), new[] { ModelsRes.ResetPasswordResetPasswordID });
                }
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Email))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordEmail), new[] { ModelsRes.ResetPasswordEmail });
            }

            if (resetPassword.ExpireDate_Local == null || resetPassword.ExpireDate_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordExpireDate_Local), new[] { ModelsRes.ResetPasswordExpireDate_Local });
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Code))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordCode), new[] { ModelsRes.ResetPasswordCode });
            }

            if (resetPassword.LastUpdateDate_UTC == null || resetPassword.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordLastUpdateDate_UTC), new[] { ModelsRes.ResetPasswordLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(resetPassword.Email) && resetPassword.Email.Length > 256)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ResetPasswordEmail, "256"), new[] { ModelsRes.ResetPasswordEmail });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Code) && (resetPassword.Code.Length < 8 || resetPassword.Code.Length > 8))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordCode, "8", "8"), new[] { ModelsRes.ResetPasswordCode });
            }

            if (resetPassword.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ResetPasswordLastUpdateContactTVItemID, "1"), new[] { ModelsRes.ResetPasswordLastUpdateContactTVItemID });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Password) && (resetPassword.Password.Length < 6) || (resetPassword.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordPassword, "6", "100"), new[] { ModelsRes.ResetPasswordPassword });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.ConfirmPassword) && (resetPassword.ConfirmPassword.Length < 6) || (resetPassword.ConfirmPassword.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordConfirmPassword, "6", "100"), new[] { ModelsRes.ResetPasswordConfirmPassword });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(resetPassword.Email))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes.ResetPasswordEmail), new[] { ModelsRes.ResetPasswordEmail });
                }
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Password) && (resetPassword.Password.Length < 6) || (resetPassword.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordPassword, "6", "100"), new[] { ModelsRes.ResetPasswordPassword });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.ConfirmPassword) && (resetPassword.ConfirmPassword.Length < 6) || (resetPassword.ConfirmPassword.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordConfirmPassword, "6", "100"), new[] { ModelsRes.ResetPasswordConfirmPassword });
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
