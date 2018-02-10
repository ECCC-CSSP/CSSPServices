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
    ///     <para>bonjour ContactLogin</para>
    /// </summary>
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
            contactLogin.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (contactLogin.ContactLoginID == 0)
                {
                    contactLogin.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginContactLoginID), new[] { "ContactLoginID" });
                }

                if (!GetRead().Where(c => c.ContactLoginID == contactLogin.ContactLoginID).Any())
                {
                    contactLogin.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ContactLogin, CSSPModelsRes.ContactLoginContactLoginID, contactLogin.ContactLoginID.ToString()), new[] { "ContactLoginID" });
                }
            }

            Contact ContactContactID = (from c in db.Contacts where c.ContactID == contactLogin.ContactID select c).FirstOrDefault();

            if (ContactContactID == null)
            {
                contactLogin.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactLoginContactID, (contactLogin.ContactID == null ? "" : contactLogin.ContactID.ToString())), new[] { "ContactID" });
            }

            if (string.IsNullOrWhiteSpace(contactLogin.LoginEmail))
            {
                contactLogin.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginLoginEmail), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.LoginEmail) && contactLogin.LoginEmail.Length > 200)
            {
                contactLogin.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactLoginLoginEmail, "200"), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(contactLogin.LoginEmail))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(contactLogin.LoginEmail))
                {
                    contactLogin.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, CSSPModelsRes.ContactLoginLoginEmail), new[] { "LoginEmail" });
                }
            }

                //Error: Type not implemented [PasswordHash] of type [Byte[]]

                //Error: Type not implemented [PasswordHash] of type [Byte[]]
                //Error: Type not implemented [PasswordSalt] of type [Byte[]]

                //Error: Type not implemented [PasswordSalt] of type [Byte[]]
            if (contactLogin.LastUpdateDate_UTC.Year == 1)
            {
                contactLogin.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (contactLogin.LastUpdateDate_UTC.Year < 1980)
                {
                contactLogin.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ContactLoginLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == contactLogin.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                contactLogin.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactLoginLastUpdateContactTVItemID, (contactLogin.LastUpdateContactTVItemID == null ? "" : contactLogin.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    contactLogin.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactLoginLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                contactLogin.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ContactLogin GetContactLoginWithContactLoginID(int ContactLoginID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<ContactLogin> contactLoginQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ContactLoginID == ContactLoginID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return contactLoginQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillContactLoginWeb(contactLoginQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillContactLoginReport(contactLoginQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ContactLogin> GetContactLoginList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<ContactLogin> contactLoginQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return contactLoginQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillContactLoginWeb(contactLoginQuery, FilterAndOrderText).Take(MaxGetCount);
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillContactLoginReport(contactLoginQuery, FilterAndOrderText).Take(MaxGetCount);
                default:
                    return null;
            }
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
        public bool Delete(ContactLogin contactLogin)
        {
            contactLogin.ValidationResults = Validate(new ValidationContext(contactLogin), ActionDBTypeEnum.Delete);
            if (contactLogin.ValidationResults.Count() > 0) return false;

            db.ContactLogins.Remove(contactLogin);

            if (!TryToSave(contactLogin)) return false;

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
        public IQueryable<ContactLogin> GetRead()
        {
            return db.ContactLogins.AsNoTracking();
        }
        public IQueryable<ContactLogin> GetEdit()
        {
            return db.ContactLogins;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ContactLoginFillWeb
        private IQueryable<ContactLogin> FillContactLoginWeb(IQueryable<ContactLogin> contactLoginQuery, string FilterAndOrderText)
        {
            contactLoginQuery = (from c in contactLoginQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ContactLogin
                    {
                        ContactLoginID = c.ContactLoginID,
                        ContactID = c.ContactID,
                        LoginEmail = c.LoginEmail,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ContactLoginWeb = new ContactLoginWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        ContactLoginReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return contactLoginQuery;
        }
        #endregion Functions private Generated ContactLoginFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
