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
    /// <summary>
    ///     <para>bonjour ResetPassword</para>
    /// </summary>
    public partial class ResetPasswordService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ResetPasswordService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ResetPassword resetPassword = validationContext.ObjectInstance as ResetPassword;
            resetPassword.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (resetPassword.ResetPasswordID == 0)
                {
                    resetPassword.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ResetPasswordResetPasswordID"), new[] { "ResetPasswordID" });
                }

                if (!(from c in db.ResetPasswords select c).Where(c => c.ResetPasswordID == resetPassword.ResetPasswordID).Any())
                {
                    resetPassword.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ResetPassword", "ResetPasswordResetPasswordID", resetPassword.ResetPasswordID.ToString()), new[] { "ResetPasswordID" });
                }
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Email))
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ResetPasswordEmail"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Email) && resetPassword.Email.Length > 256)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ResetPasswordEmail", "256"), new[] { "Email" });
            }

            if (resetPassword.ExpireDate_Local.Year == 1)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ResetPasswordExpireDate_Local"), new[] { "ExpireDate_Local" });
            }
            else
            {
                if (resetPassword.ExpireDate_Local.Year < 1980)
                {
                resetPassword.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ResetPasswordExpireDate_Local", "1980"), new[] { "ExpireDate_Local" });
                }
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Code))
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ResetPasswordCode"), new[] { "Code" });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Code) && resetPassword.Code.Length > 8)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ResetPasswordCode", "8"), new[] { "Code" });
            }

            if (resetPassword.LastUpdateDate_UTC.Year == 1)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ResetPasswordLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (resetPassword.LastUpdateDate_UTC.Year < 1980)
                {
                resetPassword.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ResetPasswordLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == resetPassword.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ResetPasswordLastUpdateContactTVItemID", resetPassword.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    resetPassword.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ResetPasswordLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ResetPassword GetResetPasswordWithResetPasswordID(int ResetPasswordID)
        {
            return (from c in db.ResetPasswords
                    where c.ResetPasswordID == ResetPasswordID
                    select c).FirstOrDefault();

        }
        public IQueryable<ResetPassword> GetResetPasswordList()
        {
            IQueryable<ResetPassword> ResetPasswordQuery = (from c in db.ResetPasswords select c);

            ResetPasswordQuery = EnhanceQueryStatements<ResetPassword>(ResetPasswordQuery) as IQueryable<ResetPassword>;

            return ResetPasswordQuery;
        }
        public ResetPassword_A GetResetPassword_AWithResetPasswordID(int ResetPasswordID)
        {
            return FillResetPassword_A().Where(c => c.ResetPasswordID == ResetPasswordID).FirstOrDefault();

        }
        public IQueryable<ResetPassword_A> GetResetPassword_AList()
        {
            IQueryable<ResetPassword_A> ResetPassword_AQuery = FillResetPassword_A();

            ResetPassword_AQuery = EnhanceQueryStatements<ResetPassword_A>(ResetPassword_AQuery) as IQueryable<ResetPassword_A>;

            return ResetPassword_AQuery;
        }
        public ResetPassword_B GetResetPassword_BWithResetPasswordID(int ResetPasswordID)
        {
            return FillResetPassword_B().Where(c => c.ResetPasswordID == ResetPasswordID).FirstOrDefault();

        }
        public IQueryable<ResetPassword_B> GetResetPassword_BList()
        {
            IQueryable<ResetPassword_B> ResetPassword_BQuery = FillResetPassword_B();

            ResetPassword_BQuery = EnhanceQueryStatements<ResetPassword_B>(ResetPassword_BQuery) as IQueryable<ResetPassword_B>;

            return ResetPassword_BQuery;
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
        public bool Delete(ResetPassword resetPassword)
        {
            resetPassword.ValidationResults = Validate(new ValidationContext(resetPassword), ActionDBTypeEnum.Delete);
            if (resetPassword.ValidationResults.Count() > 0) return false;

            db.ResetPasswords.Remove(resetPassword);

            if (!TryToSave(resetPassword)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
