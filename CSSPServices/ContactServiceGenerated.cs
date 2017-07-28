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
    public partial class ContactService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType, AddContactType addContactType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Contact contact = validationContext.ObjectInstance as Contact;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (contact.ContactID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactContactID), new[] { "ContactID" });
                }
            }

            //ContactID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(contact.Id))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactId), new[] { "Id" });
            }

            if (!string.IsNullOrWhiteSpace(contact.Id) && contact.Id.Length > 128)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactId, "128"), new[] { "Id" });
            }

            //ContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == contact.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactContactTVItemID, contact.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                if (TVItemContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactContactTVItemID, "Contact"), new[] { "ContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.LoginEmail))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginEmail), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contact.LoginEmail) && (contact.LoginEmail.Length < 6 || contact.LoginEmail.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginEmail, "6", "255"), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contact.LoginEmail))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(contact.LoginEmail))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes.ContactLoginEmail), new[] { "LoginEmail" });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.FirstName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactFirstName), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.FirstName) && contact.FirstName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactFirstName, "100"), new[] { "FirstName" });
            }

            if (string.IsNullOrWhiteSpace(contact.LastName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLastName), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.LastName) && contact.LastName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactLastName, "100"), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.Initial) && contact.Initial.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactInitial, "50"), new[] { "Initial" });
            }

            if (string.IsNullOrWhiteSpace(contact.WebName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactWebName), new[] { "WebName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.WebName) && contact.WebName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactWebName, "100"), new[] { "WebName" });
            }

            if (contact.ContactTitle != null)
            {
                retStr = enums.ContactTitleOK(contact.ContactTitle);
                if (contact.ContactTitle == ContactTitleEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.ContactContactTitle });
                }
            }

            //IsAdmin (bool) is required but no testing needed 

            //EmailValidated (bool) is required but no testing needed 

            //Disabled (bool) is required but no testing needed 

            //IsNew (bool) is required but no testing needed 

            if (!string.IsNullOrWhiteSpace(contact.SamplingPlanner_ProvincesTVItemID) && contact.SamplingPlanner_ProvincesTVItemID.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactSamplingPlanner_ProvincesTVItemID, "200"), new[] { "SamplingPlanner_ProvincesTVItemID" });
            }

            if (contact.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contact.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.ContactLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contact.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactLastUpdateContactTVItemID, contact.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            //ParentTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (contact.ParentTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactParentTVItemID, "1"), new[] { "ParentTVItemID" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(Contact contact, AddContactType addContactType)
        {
            contact.ValidationResults = Validate(new ValidationContext(contact), ActionDBTypeEnum.Create, addContactType);
            if (contact.ValidationResults.Count() > 0) return false;

            db.Contacts.Add(contact);

            if (!TryToSave(contact)) return false;

            return true;
        }
        public bool AddRange(List<Contact> contactList)
        {
            foreach (Contact contact in contactList)
            {
                contact.ValidationResults = Validate(new ValidationContext(contact), ActionDBTypeEnum.Create, ContactService.AddContactType.LoggedIn);
                if (contact.ValidationResults.Count() > 0) return false;
            }

            db.Contacts.AddRange(contactList);

            if (!TryToSaveRange(contactList)) return false;

            return true;
        }
        public bool Delete(Contact contact)
        {
            if (!db.Contacts.Where(c => c.ContactID == contact.ContactID).Any())
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contact.ContactID.ToString())) }.AsEnumerable();
                return false;
            }

            db.Contacts.Remove(contact);

            if (!TryToSave(contact)) return false;

            return true;
        }
        public bool DeleteRange(List<Contact> contactList)
        {
            foreach (Contact contact in contactList)
            {
                if (!db.Contacts.Where(c => c.ContactID == contact.ContactID).Any())
                {
                    contactList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactID", contact.ContactID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.Contacts.RemoveRange(contactList);

            if (!TryToSaveRange(contactList)) return false;

            return true;
        }
        public bool Update(Contact contact)
        {
            contact.ValidationResults = Validate(new ValidationContext(contact), ActionDBTypeEnum.Update, ContactService.AddContactType.LoggedIn);
            if (contact.ValidationResults.Count() > 0) return false;

            db.Contacts.Update(contact);

            if (!TryToSave(contact)) return false;

            return true;
        }
        public bool UpdateRange(List<Contact> contactList)
        {
            foreach (Contact contact in contactList)
            {
                contact.ValidationResults = Validate(new ValidationContext(contact), ActionDBTypeEnum.Update, ContactService.AddContactType.LoggedIn);
                if (contact.ValidationResults.Count() > 0) return false;
            }
            db.Contacts.UpdateRange(contactList);

            if (!TryToSaveRange(contactList)) return false;

            return true;
        }
        public IQueryable<Contact> GetRead()
        {
            return db.Contacts.AsNoTracking();
        }
        public IQueryable<Contact> GetEdit()
        {
            return db.Contacts;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(Contact contact)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                contact.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<Contact> contactList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                contactList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
