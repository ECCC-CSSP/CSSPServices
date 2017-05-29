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
    public partial class AspNetUserService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            AspNetUser aspNetUser = validationContext.ObjectInstance as AspNetUser;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (string.IsNullOrWhiteSpace(aspNetUser.Id))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetUserId), new[] { ModelsRes.AspNetUserId });
                }
            }

            //EmailConfirmed (bool) is required but no testing needed 

            //PhoneNumberConfirmed (bool) is required but no testing needed 

            //TwoFactorEnabled (bool) is required but no testing needed 

            //LockoutEnabled (bool) is required but no testing needed 

            //AccessFailedCount (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(aspNetUser.UserName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AspNetUserUserName), new[] { ModelsRes.AspNetUserUserName });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(aspNetUser.Email) && aspNetUser.Email.Length > 256)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AspNetUserEmail, "256"), new[] { ModelsRes.AspNetUserEmail });
            }

            // PasswordHash has no validation

            // SecurityStamp has no validation

            // PhoneNumber has no validation

            if (aspNetUser.AccessFailedCount < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AspNetUserAccessFailedCount, "0"), new[] { ModelsRes.AspNetUserAccessFailedCount });
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.UserName) && aspNetUser.UserName.Length > 256)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AspNetUserUserName, "256"), new[] { ModelsRes.AspNetUserUserName });
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.Password) && (aspNetUser.Password.Length < 6) || (aspNetUser.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AspNetUserPassword, "6", "100"), new[] { ModelsRes.AspNetUserPassword });
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(aspNetUser.Email))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes.AspNetUserEmail), new[] { ModelsRes.AspNetUserEmail });
                }
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.UserName))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(aspNetUser.UserName))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes.AspNetUserUserName), new[] { ModelsRes.AspNetUserUserName });
                }
            }

            if (!string.IsNullOrWhiteSpace(aspNetUser.Password) && (aspNetUser.Password.Length < 6) || (aspNetUser.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AspNetUserPassword, "6", "100"), new[] { ModelsRes.AspNetUserPassword });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(AspNetUser aspNetUser)
        {
            aspNetUser.ValidationResults = Validate(new ValidationContext(aspNetUser), ActionDBTypeEnum.Create);
            if (aspNetUser.ValidationResults.Count() > 0) return false;

            db.AspNetUsers.Add(aspNetUser);

            if (!TryToSave(aspNetUser)) return false;

            return true;
        }
        public bool AddRange(List<AspNetUser> aspNetUserList)
        {
            foreach (AspNetUser aspNetUser in aspNetUserList)
            {
                aspNetUser.ValidationResults = Validate(new ValidationContext(aspNetUser), ActionDBTypeEnum.Create);
                if (aspNetUser.ValidationResults.Count() > 0) return false;
            }

            db.AspNetUsers.AddRange(aspNetUserList);

            if (!TryToSaveRange(aspNetUserList)) return false;

            return true;
        }
        public bool Delete(AspNetUser aspNetUser)
        {
            if (!db.AspNetUsers.Where(c => c.Id == aspNetUser.Id).Any())
            {
                aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetUser", "Id", aspNetUser.Id.ToString())) }.AsEnumerable();
                return false;
            }

            db.AspNetUsers.Remove(aspNetUser);

            if (!TryToSave(aspNetUser)) return false;

            return true;
        }
        public bool DeleteRange(List<AspNetUser> aspNetUserList)
        {
            foreach (AspNetUser aspNetUser in aspNetUserList)
            {
                if (!db.AspNetUsers.Where(c => c.Id == aspNetUser.Id).Any())
                {
                    aspNetUserList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AspNetUser", "Id", aspNetUser.Id.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.AspNetUsers.RemoveRange(aspNetUserList);

            if (!TryToSaveRange(aspNetUserList)) return false;

            return true;
        }
        public bool Update(AspNetUser aspNetUser)
        {
            aspNetUser.ValidationResults = Validate(new ValidationContext(aspNetUser), ActionDBTypeEnum.Update);
            if (aspNetUser.ValidationResults.Count() > 0) return false;

            db.AspNetUsers.Update(aspNetUser);

            if (!TryToSave(aspNetUser)) return false;

            return true;
        }
        public bool UpdateRange(List<AspNetUser> aspNetUserList)
        {
            foreach (AspNetUser aspNetUser in aspNetUserList)
            {
                aspNetUser.ValidationResults = Validate(new ValidationContext(aspNetUser), ActionDBTypeEnum.Update);
                if (aspNetUser.ValidationResults.Count() > 0) return false;
            }
            db.AspNetUsers.UpdateRange(aspNetUserList);

            if (!TryToSaveRange(aspNetUserList)) return false;

            return true;
        }
        public IQueryable<AspNetUser> GetRead()
        {
            return db.AspNetUsers.AsNoTracking();
        }
        public IQueryable<AspNetUser> GetEdit()
        {
            return db.AspNetUsers;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(AspNetUser aspNetUser)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUser.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<AspNetUser> aspNetUserList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                aspNetUserList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
