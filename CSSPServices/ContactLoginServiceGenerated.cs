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
        #endregion Properties

        #region Constructors
        public ContactLoginService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ContactLogin contactLogin = validationContext.ObjectInstance as ContactLogin;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (contactLogin.ContactLoginID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginContactLoginID), new[] { "ContactLoginID" });
                }
            }

            //ContactLoginID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ContactID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactLogin.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ContactLoginContactID, contactLogin.ContactID.ToString()), new[] { "ContactID" });
            }

            if (string.IsNullOrWhiteSpace(contactLogin.LoginEmail))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginLoginEmail), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.LoginEmail) && contactLogin.LoginEmail.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactLoginLoginEmail, "200"), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.LoginEmail))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(contactLogin.LoginEmail))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes.ContactLoginLoginEmail), new[] { "LoginEmail" });
                }
            }

                //Error: Type not implemented [PasswordHash] of type [Byte[]]

                //Error: Type not implemented [PasswordHash] of type [Byte[]]
                //Error: Type not implemented [PasswordSalt] of type [Byte[]]

                //Error: Type not implemented [PasswordSalt] of type [Byte[]]
            if (contactLogin.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactLogin.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ContactLoginLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactLogin.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactLoginLastUpdateContactTVItemID, contactLogin.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactLoginLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(contactLogin.Password))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginPassword), new[] { "Password" });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.Password) && (contactLogin.Password.Length < 6 || contactLogin.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginPassword, "6", "100"), new[] { "Password" });
            }

            if (string.IsNullOrWhiteSpace(contactLogin.ConfirmPassword))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginConfirmPassword), new[] { "ConfirmPassword" });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.ConfirmPassword) && (contactLogin.ConfirmPassword.Length < 6 || contactLogin.ConfirmPassword.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginConfirmPassword, "6", "100"), new[] { "ConfirmPassword" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ContactLogin GetContactLoginWithContactLoginID(int ContactLoginID)
        {
            IQueryable<ContactLogin> contactLoginQuery = (from c in GetRead()
                                                where c.ContactLoginID == ContactLoginID
                                                select c);

            return FillContactLogin(contactLoginQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<ContactLogin> FillContactLogin(IQueryable<ContactLogin> contactLoginQuery)
        {
            List<ContactLogin> ContactLoginList = (from c in contactLoginQuery
                                         select new ContactLogin
                                         {
                                             ContactLoginID = c.ContactLoginID,
                                             ContactID = c.ContactID,
                                             LoginEmail = c.LoginEmail,
                                             PasswordHash = c.PasswordHash,
                                             PasswordSalt = c.PasswordSalt,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            return ContactLoginList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
