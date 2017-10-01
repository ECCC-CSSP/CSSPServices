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
        public ContactService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactContactID), new[] { "ContactID" });
                }

                if (!GetRead().Where(c => c.ContactID == contact.ContactID).Any())
                {
                    contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactContactID, contact.ContactID.ToString()), new[] { "ContactID" });
                }
            }

            //ContactID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(contact.Id))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactId), new[] { "Id" });
            }

            if (!string.IsNullOrWhiteSpace(contact.Id) && contact.Id.Length > 128)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactId, "128"), new[] { "Id" });
            }

            //ContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == contact.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactContactTVItemID, contact.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactContactTVItemID, "Contact"), new[] { "ContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.LoginEmail))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginEmail), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contact.LoginEmail) && (contact.LoginEmail.Length < 6 || contact.LoginEmail.Length > 255))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ContactLoginEmail, "6", "255"), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contact.LoginEmail))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(contact.LoginEmail))
                {
                    contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, CSSPModelsRes.ContactLoginEmail), new[] { "LoginEmail" });
                }
            }

            if (string.IsNullOrWhiteSpace(contact.FirstName))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactFirstName), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.FirstName) && contact.FirstName.Length > 100)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactFirstName, "100"), new[] { "FirstName" });
            }

            if (string.IsNullOrWhiteSpace(contact.LastName))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLastName), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.LastName) && contact.LastName.Length > 100)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactLastName, "100"), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.Initial) && contact.Initial.Length > 50)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactInitial, "50"), new[] { "Initial" });
            }

            if (string.IsNullOrWhiteSpace(contact.WebName))
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactWebName), new[] { "WebName" });
            }

            if (!string.IsNullOrWhiteSpace(contact.WebName) && contact.WebName.Length > 100)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactWebName, "100"), new[] { "WebName" });
            }

            if (contact.ContactTitle != null)
            {
                retStr = enums.EnumTypeOK(typeof(ContactTitleEnum), (int?)contact.ContactTitle);
                if (contact.ContactTitle == ContactTitleEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactContactTitle), new[] { "ContactTitle" });
                }
            }

            //IsAdmin (bool) is required but no testing needed 

            //EmailValidated (bool) is required but no testing needed 

            //Disabled (bool) is required but no testing needed 

            //IsNew (bool) is required but no testing needed 

            if (!string.IsNullOrWhiteSpace(contact.SamplingPlanner_ProvincesTVItemID) && contact.SamplingPlanner_ProvincesTVItemID.Length > 200)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactSamplingPlanner_ProvincesTVItemID, "200"), new[] { "SamplingPlanner_ProvincesTVItemID" });
            }

                //Error: Type not implemented [ContactWeb] of type [ContactWeb]
                //Error: Type not implemented [ContactReport] of type [ContactReport]
            if (contact.LastUpdateDate_UTC.Year == 1)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contact.LastUpdateDate_UTC.Year < 1980)
                {
                contact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ContactLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contact.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                contact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactLastUpdateContactTVItemID, contact.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                contact.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Contact GetContactWithContactID(int ContactID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<Contact> contactQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ContactID == ContactID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return contactQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillContact(contactQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<Contact> GetContactList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<Contact> contactQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return contactQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillContact(contactQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
                default:
                    return null;
            }
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
        public IQueryable<Contact> GetRead()
        {
            return db.Contacts.AsNoTracking();
        }
        public IQueryable<Contact> GetEdit()
        {
            return db.Contacts;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<Contact> FillContact_Show_Copy_To_ContactServiceExtra_As_Fill_Contact(IQueryable<Contact> contactQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ContactTitleEnumList = enums.GetEnumTextOrderedList(typeof(ContactTitleEnum));

            contactQuery = (from c in contactQuery
                let ContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new Contact
                    {
                        ContactID = c.ContactID,
                        Id = c.Id,
                        ContactTVItemID = c.ContactTVItemID,
                        LoginEmail = c.LoginEmail,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Initial = c.Initial,
                        WebName = c.WebName,
                        ContactTitle = c.ContactTitle,
                        IsAdmin = c.IsAdmin,
                        EmailValidated = c.EmailValidated,
                        Disabled = c.Disabled,
                        IsNew = c.IsNew,
                        SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ContactWeb = new ContactWeb
                        {
                            ContactTVText = ContactTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            ParentTVItemID = ParentTVItemID,
                            ContactTitleText = (from e in ContactTitleEnumList
                                where e.EnumID == (int?)c.ContactTitle
                                select e.EnumText).FirstOrDefault(),
                        },
                        ContactReport = new ContactReport
                        {
                            ContactReportTest = "ContactReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return contactQuery;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
