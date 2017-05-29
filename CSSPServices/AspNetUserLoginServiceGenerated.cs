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
    public partial class AspNetUserLoginService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserLoginService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            AspNetUserLogin aspNetUserLogin = validationContext.ObjectInstance as AspNetUserLogin;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (string.IsNullOrWhiteSpace(aspNetUserLogin.LoginProvider))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetUserLoginLoginProvider), new[] { ModelsRes.AspNetUserLoginLoginProvider });
                }
                if (string.IsNullOrWhiteSpace(aspNetUserLogin.ProviderKey))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetUserLoginProviderKey), new[] { ModelsRes.AspNetUserLoginProviderKey });
                }
                if (string.IsNullOrWhiteSpace(aspNetUserLogin.UserId))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetUserLoginUserId), new[] { ModelsRes.AspNetUserLoginUserId });
                }
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------


        }
        #endregion Validation

        #region Functions public
        public bool Add(AspNetUserLogin aspNetUserLogin)
        {
            aspNetUserLogin.ValidationResults = Validate(new ValidationContext(aspNetUserLogin), ActionDBTypeEnum.Create);
            if (aspNetUserLogin.ValidationResults.Count() > 0) return false;

            db.AspNetUserLogins.Add(aspNetUserLogin);

            if (!TryToSave(aspNetUserLogin)) return false;

            return true;
        }
        public bool AddRange(List<AspNetUserLogin> aspNetUserLoginList)
        {
            foreach (AspNetUserLogin aspNetUserLogin in aspNetUserLoginList)
            {
                aspNetUserLogin.ValidationResults = Validate(new ValidationContext(aspNetUserLogin), ActionDBTypeEnum.Create);
                if (aspNetUserLogin.ValidationResults.Count() > 0) return false;
            }

            db.AspNetUserLogins.AddRange(aspNetUserLoginList);

            if (!TryToSaveRange(aspNetUserLoginList)) return false;

            return true;
        }
        public bool Delete(AspNetUserLogin aspNetUserLogin)
        {
            if (!db.AspNetUserLogins.Where(c => c.UserId == aspNetUserLogin.UserId).Any())
            {
                aspNetUserLogin.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetUserLogin", "UserId", aspNetUserLogin.UserId.ToString())) }.AsEnumerable();
                return false;
            }

            db.AspNetUserLogins.Remove(aspNetUserLogin);

            if (!TryToSave(aspNetUserLogin)) return false;

            return true;
        }
        public bool DeleteRange(List<AspNetUserLogin> aspNetUserLoginList)
        {
            foreach (AspNetUserLogin aspNetUserLogin in aspNetUserLoginList)
            {
                if (!db.AspNetUserLogins.Where(c => c.UserId == aspNetUserLogin.UserId).Any())
                {
                    aspNetUserLoginList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetUserLogin", "UserId", aspNetUserLogin.UserId.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.AspNetUserLogins.RemoveRange(aspNetUserLoginList);

            if (!TryToSaveRange(aspNetUserLoginList)) return false;

            return true;
        }
        public bool Update(AspNetUserLogin aspNetUserLogin)
        {
            aspNetUserLogin.ValidationResults = Validate(new ValidationContext(aspNetUserLogin), ActionDBTypeEnum.Update);
            if (aspNetUserLogin.ValidationResults.Count() > 0) return false;

            db.AspNetUserLogins.Update(aspNetUserLogin);

            if (!TryToSave(aspNetUserLogin)) return false;

            return true;
        }
        public bool UpdateRange(List<AspNetUserLogin> aspNetUserLoginList)
        {
            foreach (AspNetUserLogin aspNetUserLogin in aspNetUserLoginList)
            {
                aspNetUserLogin.ValidationResults = Validate(new ValidationContext(aspNetUserLogin), ActionDBTypeEnum.Update);
                if (aspNetUserLogin.ValidationResults.Count() > 0) return false;
            }
            db.AspNetUserLogins.UpdateRange(aspNetUserLoginList);

            if (!TryToSaveRange(aspNetUserLoginList)) return false;

            return true;
        }
        public IQueryable<AspNetUserLogin> GetRead()
        {
            return db.AspNetUserLogins.AsNoTracking();
        }
        public IQueryable<AspNetUserLogin> GetEdit()
        {
            return db.AspNetUserLogins;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(AspNetUserLogin aspNetUserLogin)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUserLogin.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<AspNetUserLogin> aspNetUserLoginList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUserLoginList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
