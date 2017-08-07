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
        #endregion Properties

        #region Constructors
        public ResetPasswordService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordResetPasswordID), new[] { "ResetPasswordID" });
                }
            }

            //ResetPasswordID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(resetPassword.Email))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordEmail), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Email) && resetPassword.Email.Length > 256)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ResetPasswordEmail, "256"), new[] { "Email" });
            }

            if (resetPassword.ExpireDate_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordExpireDate_Local), new[] { "ExpireDate_Local" });
            }
            else
            {
                if (resetPassword.ExpireDate_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ResetPasswordExpireDate_Local, "1980"), new[] { "ExpireDate_Local" });
                }
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Code))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordCode), new[] { "Code" });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Code) && resetPassword.Code.Length > 8)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ResetPasswordCode, "8"), new[] { "Code" });
            }

            if (resetPassword.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (resetPassword.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ResetPasswordLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == resetPassword.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ResetPasswordLastUpdateContactTVItemID, resetPassword.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ResetPasswordLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Password))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordPassword), new[] { "Password" });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Password) && (resetPassword.Password.Length < 6 || resetPassword.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordPassword, "6", "100"), new[] { "Password" });
            }

            if (string.IsNullOrWhiteSpace(resetPassword.ConfirmPassword))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordConfirmPassword), new[] { "ConfirmPassword" });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.ConfirmPassword) && (resetPassword.ConfirmPassword.Length < 6 || resetPassword.ConfirmPassword.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordConfirmPassword, "6", "100"), new[] { "ConfirmPassword" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ResetPassword GetResetPasswordWithResetPasswordID(int ResetPasswordID)
        {
            IQueryable<ResetPassword> resetPasswordQuery = (from c in GetRead()
                                                where c.ResetPasswordID == ResetPasswordID
                                                select c);

            return FillResetPassword(resetPasswordQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<ResetPassword> FillResetPassword(IQueryable<ResetPassword> resetPasswordQuery)
        {
            List<ResetPassword> ResetPasswordList = (from c in resetPasswordQuery
                                         select new ResetPassword
                                         {
                                             ResetPasswordID = c.ResetPasswordID,
                                             Email = c.Email,
                                             ExpireDate_Local = c.ExpireDate_Local,
                                             Code = c.Code,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            return ResetPasswordList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
