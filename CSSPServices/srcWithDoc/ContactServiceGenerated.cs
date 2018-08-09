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
    ///     <para>bonjour Contact</para>
    /// </summary>
    public partial class ContactService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType, AddContactTypeEnum addContactType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Contact contact = validationContext.ObjectInstance as Contact;
            contact.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (contact.ContactID == 0)
                {
                    contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactContactID"), new[] { "ContactID" });
                }

                if (!(from c in db.Contacts select c).Where(c => c.ContactID == contact.ContactID).Any())
                {
                    contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactContactID", contact.ContactID.ToString()), new[] { "ContactID" });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.Id))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactId"), new[] { "Id" });
            }

            if (!string.IsNullOrWhiteSpace(contact.Id) && contact.Id.Length > 128)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactId", "128"), new[] { "Id" });
            }

            AspNetUser AspNetUserId = (from c in db.AspNetUsers where c.Id == contact.Id select c).FirstOrDefault();

            if (AspNetUserId == null)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AspNetUser", "ContactId", (contact.Id == null ? "" : contact.Id.ToString())), new[] { "Id" });
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == contact.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactContactTVItemID", contact.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ContactContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.LoginEmail))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactLoginEmail"), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contact.LoginEmail) && (contact.LoginEmail.Length < 6 || contact.LoginEmail.Length > 255))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "ContactLoginEmail", "6", "255"), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contact.LoginEmail))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(contact.LoginEmail))
                {
                    contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, "ContactLoginEmail"), new[] { "LoginEmail" });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.FirstName))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactFirstName"), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.FirstName) && contact.FirstName.Length > 100)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactFirstName", "100"), new[] { "FirstName" });
            }

            if (string.IsNullOrWhiteSpace(contact.LastName))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactLastName"), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.LastName) && contact.LastName.Length > 100)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactLastName", "100"), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.Initial) && contact.Initial.Length > 50)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactInitial", "50"), new[] { "Initial" });
            }

            if (string.IsNullOrWhiteSpace(contact.WebName))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactWebName"), new[] { "WebName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.WebName) && contact.WebName.Length > 100)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactWebName", "100"), new[] { "WebName" });
            }

            if (contact.ContactTitle != null)
            {
                retStr = enums.EnumTypeOK(typeof(ContactTitleEnum), (int?)contact.ContactTitle);
                if (contact.ContactTitle == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactContactTitle"), new[] { "ContactTitle" });
                }
            }

            if (!string.IsNullOrWhiteSpace(contact.SamplingPlanner_ProvincesTVItemID) && contact.SamplingPlanner_ProvincesTVItemID.Length > 200)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactSamplingPlanner_ProvincesTVItemID", "200"), new[] { "SamplingPlanner_ProvincesTVItemID" });
            }

            if (contact.LastUpdateDate_UTC.Year == 1)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contact.LastUpdateDate_UTC.Year < 1980)
                {
                contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ContactLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contact.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactLastUpdateContactTVItemID", contact.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ContactLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                contact.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Contact GetContactWithContactID(int ContactID)
        {
            return (from c in db.Contacts
                    where c.ContactID == ContactID
                    select c).FirstOrDefault();

        }
        public IQueryable<Contact> GetContactList()
        {
            IQueryable<Contact> ContactQuery = (from c in db.Contacts select c);

            ContactQuery = EnhanceQueryStatements<Contact>(ContactQuery) as IQueryable<Contact>;

            return ContactQuery;
        }
        public Contact_A GetContact_AWithContactID(int ContactID)
        {
            return FillContact_A().Where(c => c.ContactID == ContactID).FirstOrDefault();

        }
        public IQueryable<Contact_A> GetContact_AList()
        {
            IQueryable<Contact_A> Contact_AQuery = FillContact_A();

            Contact_AQuery = EnhanceQueryStatements<Contact_A>(Contact_AQuery) as IQueryable<Contact_A>;

            return Contact_AQuery;
        }
        public Contact_B GetContact_BWithContactID(int ContactID)
        {
            return FillContact_B().Where(c => c.ContactID == ContactID).FirstOrDefault();

        }
        public IQueryable<Contact_B> GetContact_BList()
        {
            IQueryable<Contact_B> Contact_BQuery = FillContact_B();

            Contact_BQuery = EnhanceQueryStatements<Contact_B>(Contact_BQuery) as IQueryable<Contact_B>;

            return Contact_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(Contact contact, AddContactTypeEnum addContactType)
        {
            contact.ValidationResults = Validate(new ValidationContext(contact), ActionDBTypeEnum.Create, addContactType);
            if (contact.ValidationResults.Count() > 0) return false;

            db.Contacts.Add(contact);

            if (!TryToSave(contact)) return false;

            return true;
        }
        public bool Delete(Contact contact)
        {
            contact.ValidationResults = Validate(new ValidationContext(contact), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);
            if (contact.ValidationResults.Count() > 0) return false;

            db.Contacts.Remove(contact);

            if (!TryToSave(contact)) return false;

            return true;
        }
        public bool Update(Contact contact)
        {
            contact.ValidationResults = Validate(new ValidationContext(contact), ActionDBTypeEnum.Update, AddContactTypeEnum.LoggedIn);
            if (contact.ValidationResults.Count() > 0) return false;

            db.Contacts.Update(contact);

            if (!TryToSave(contact)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
