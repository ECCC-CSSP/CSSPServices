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
    public partial class ContactLoginService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public ContactLoginService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            ContactLogin contactLogin = validationContext.ObjectInstance as ContactLogin;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (contactLogin.ContactLoginID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginContactLoginID), new[] { ModelsRes.ContactLoginContactLoginID });
                }
            }

            //ContactID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(contactLogin.LoginEmail))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginLoginEmail), new[] { ModelsRes.ContactLoginLoginEmail });
            }

                //Error: Type not implemented [PasswordHash] of type [Byte[]]

                //Error: Type not implemented [PasswordSalt] of type [Byte[]]

            if (contactLogin.LastUpdateDate_UTC == null || contactLogin.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginLastUpdateDate_UTC), new[] { ModelsRes.ContactLoginLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(contactLogin.Password))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginPassword), new[] { ModelsRes.ContactLoginPassword });
            }

            if (string.IsNullOrWhiteSpace(contactLogin.ConfirmPassword))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginConfirmPassword), new[] { ModelsRes.ContactLoginConfirmPassword });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (contactLogin.ContactID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactLoginContactID, "1"), new[] { ModelsRes.ContactLoginContactID });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.LoginEmail) && contactLogin.LoginEmail.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactLoginLoginEmail, "200"), new[] { ModelsRes.ContactLoginLoginEmail });
            }

                //Error: Type not implemented [PasswordHash] of type [Byte[]]
                //Error: Type not implemented [PasswordSalt] of type [Byte[]]
            if (contactLogin.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactLoginLastUpdateContactTVItemID, "1"), new[] { ModelsRes.ContactLoginLastUpdateContactTVItemID });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.Password) && (contactLogin.Password.Length < 6) || (contactLogin.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginPassword, "6", "100"), new[] { ModelsRes.ContactLoginPassword });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.ConfirmPassword) && (contactLogin.ConfirmPassword.Length < 6) || (contactLogin.ConfirmPassword.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginConfirmPassword, "6", "100"), new[] { ModelsRes.ContactLoginConfirmPassword });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.LoginEmail))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(contactLogin.LoginEmail))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes.ContactLoginLoginEmail), new[] { ModelsRes.ContactLoginLoginEmail });
                }
            }

                //Error: Type not implemented [PasswordHash] of type [Byte[]]
                //Error: Type not implemented [PasswordSalt] of type [Byte[]]

        }
        #endregion Validation

        #region Functions public
        public bool Add(ContactLogin contactLogin)
        {
            contactLogin.ValidationResults = Validate(new ValidationContext(contactLogin), ActionDBTypeEnum.Create);
            if (contactLogin.ValidationResults.Count() > 0) return false;

            db.ContactLogins.Add(contactLogin);

            if (!TryToSave(contactLogin)) return false;

            return true;
        }
        public bool AddRange(List<ContactLogin> contactLoginList)
        {
            foreach (ContactLogin contactLogin in contactLoginList)
            {
                contactLogin.ValidationResults = Validate(new ValidationContext(contactLogin), ActionDBTypeEnum.Create);
                if (contactLogin.ValidationResults.Count() > 0) return false;
            }

            db.ContactLogins.AddRange(contactLoginList);

            if (!TryToSaveRange(contactLoginList)) return false;

            return true;
        }
        public bool Delete(ContactLogin contactLogin)
        {
            if (!db.ContactLogins.Where(c => c.ContactLoginID == contactLogin.ContactLoginID).Any())
            {
                contactLogin.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ContactLogin", "ContactLoginID", contactLogin.ContactLoginID.ToString())) }.AsEnumerable();
                return false;
            }

            db.ContactLogins.Remove(contactLogin);

            if (!TryToSave(contactLogin)) return false;

            return true;
        }
        public bool DeleteRange(List<ContactLogin> contactLoginList)
        {
            foreach (ContactLogin contactLogin in contactLoginList)
            {
                if (!db.ContactLogins.Where(c => c.ContactLoginID == contactLogin.ContactLoginID).Any())
                {
                    contactLoginList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "ContactLogin", "ContactLoginID", contactLogin.ContactLoginID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.ContactLogins.RemoveRange(contactLoginList);

            if (!TryToSaveRange(contactLoginList)) return false;

            return true;
        }
        public bool Update(ContactLogin contactLogin)
        {
            contactLogin.ValidationResults = Validate(new ValidationContext(contactLogin), ActionDBTypeEnum.Update);
            if (contactLogin.ValidationResults.Count() > 0) return false;

            db.ContactLogins.Update(contactLogin);

            if (!TryToSave(contactLogin)) return false;

            return true;
        }
        public bool UpdateRange(List<ContactLogin> contactLoginList)
        {
            foreach (ContactLogin contactLogin in contactLoginList)
            {
                contactLogin.ValidationResults = Validate(new ValidationContext(contactLogin), ActionDBTypeEnum.Update);
                if (contactLogin.ValidationResults.Count() > 0) return false;
            }
            db.ContactLogins.UpdateRange(contactLoginList);

            if (!TryToSaveRange(contactLoginList)) return false;

            return true;
        }
        public IQueryable<ContactLogin> GetRead()
        {
            return db.ContactLogins.AsNoTracking();
        }
        public IQueryable<ContactLogin> GetEdit()
        {
            return db.ContactLogins;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(ContactLogin contactLogin)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                contactLogin.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<ContactLogin> contactLoginList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                contactLoginList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
