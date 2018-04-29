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
        public ResetPasswordService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordResetPasswordID), new[] { "ResetPasswordID" });
                }

                if (!GetRead().Where(c => c.ResetPasswordID == resetPassword.ResetPasswordID).Any())
                {
                    resetPassword.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ResetPassword, CSSPModelsRes.ResetPasswordResetPasswordID, resetPassword.ResetPasswordID.ToString()), new[] { "ResetPasswordID" });
                }
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Email))
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordEmail), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Email) && resetPassword.Email.Length > 256)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ResetPasswordEmail, "256"), new[] { "Email" });
            }

            if (resetPassword.ExpireDate_Local.Year == 1)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordExpireDate_Local), new[] { "ExpireDate_Local" });
            }
            else
            {
                if (resetPassword.ExpireDate_Local.Year < 1980)
                {
                resetPassword.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ResetPasswordExpireDate_Local, "1980"), new[] { "ExpireDate_Local" });
                }
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Code))
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordCode), new[] { "Code" });
            }

            if (!string.IsNullOrWhiteSpace(resetPassword.Code) && resetPassword.Code.Length > 8)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ResetPasswordCode, "8"), new[] { "Code" });
            }

            if (resetPassword.LastUpdateDate_UTC.Year == 1)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (resetPassword.LastUpdateDate_UTC.Year < 1980)
                {
                resetPassword.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ResetPasswordLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == resetPassword.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                resetPassword.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ResetPasswordLastUpdateContactTVItemID, (resetPassword.LastUpdateContactTVItemID == null ? "" : resetPassword.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ResetPasswordLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public ResetPassword GetResetPasswordWithResetPasswordID(int ResetPasswordID, GetParam getParam)
        {
            IQueryable<ResetPassword> resetPasswordQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ResetPasswordID == ResetPasswordID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return resetPasswordQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillResetPasswordWeb(resetPasswordQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillResetPasswordReport(resetPasswordQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ResetPassword> GetResetPasswordList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<ResetPassword> resetPasswordQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            resetPasswordQuery  = resetPasswordQuery.OrderByDescending(c => c.ResetPasswordID);
                        }
                        resetPasswordQuery = resetPasswordQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return resetPasswordQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            resetPasswordQuery = FillResetPasswordWeb(resetPasswordQuery, FilterAndOrderText).OrderByDescending(c => c.ResetPasswordID);
                        }
                        resetPasswordQuery = FillResetPasswordWeb(resetPasswordQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return resetPasswordQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            resetPasswordQuery = FillResetPasswordReport(resetPasswordQuery, FilterAndOrderText).OrderByDescending(c => c.ResetPasswordID);
                        }
                        resetPasswordQuery = FillResetPasswordReport(resetPasswordQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return resetPasswordQuery;
                    }
                default:
                    return null;
            }
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
        public IQueryable<ResetPassword> GetRead()
        {
            if (GetParam.OrderAscending)
            {
                return db.ResetPasswords.AsNoTracking();
            }
            else
            {
                return db.ResetPasswords.AsNoTracking().OrderByDescending(c => c.ResetPasswordID);
            }
        }
        public IQueryable<ResetPassword> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.ResetPasswords;
            }
            else
            {
                return db.ResetPasswords.OrderByDescending(c => c.ResetPasswordID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ResetPasswordFillWeb
        private IQueryable<ResetPassword> FillResetPasswordWeb(IQueryable<ResetPassword> resetPasswordQuery, string FilterAndOrderText)
        {
            resetPasswordQuery = (from c in resetPasswordQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ResetPassword
                    {
                        ResetPasswordID = c.ResetPasswordID,
                        Email = c.Email,
                        ExpireDate_Local = c.ExpireDate_Local,
                        Code = c.Code,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ResetPasswordWeb = new ResetPasswordWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        ResetPasswordReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return resetPasswordQuery;
        }
        #endregion Functions private Generated ResetPasswordFillWeb

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
