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
    ///     <para>bonjour EmailDistributionListContact</para>
    /// </summary>
    public partial class EmailDistributionListContactService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            EmailDistributionListContact emailDistributionListContact = validationContext.ObjectInstance as EmailDistributionListContact;
            emailDistributionListContact.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionListContact.EmailDistributionListContactID == 0)
                {
                    emailDistributionListContact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactEmailDistributionListContactID), new[] { "EmailDistributionListContactID" });
                }

                if (!GetRead().Where(c => c.EmailDistributionListContactID == emailDistributionListContact.EmailDistributionListContactID).Any())
                {
                    emailDistributionListContact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListContact, CSSPModelsRes.EmailDistributionListContactEmailDistributionListContactID, emailDistributionListContact.EmailDistributionListContactID.ToString()), new[] { "EmailDistributionListContactID" });
                }
            }

            EmailDistributionList EmailDistributionListEmailDistributionListID = (from c in db.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListContact.EmailDistributionListID select c).FirstOrDefault();

            if (EmailDistributionListEmailDistributionListID == null)
            {
                emailDistributionListContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionList, CSSPModelsRes.EmailDistributionListContactEmailDistributionListID, emailDistributionListContact.EmailDistributionListID.ToString()), new[] { "EmailDistributionListID" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Name))
            {
                emailDistributionListContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactName), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Name) && emailDistributionListContact.Name.Length > 100)
            {
                emailDistributionListContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailDistributionListContactName, "100"), new[] { "Name" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                emailDistributionListContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactEmail), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email) && emailDistributionListContact.Email.Length > 200)
            {
                emailDistributionListContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailDistributionListContactEmail, "200"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(emailDistributionListContact.Email))
                {
                    emailDistributionListContact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, CSSPModelsRes.EmailDistributionListContactEmail), new[] { "Email" });
                }
            }

            if (emailDistributionListContact.LastUpdateDate_UTC.Year == 1)
            {
                emailDistributionListContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionListContact.LastUpdateDate_UTC.Year < 1980)
                {
                emailDistributionListContact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailDistributionListContactLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListContact.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                emailDistributionListContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, emailDistributionListContact.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    emailDistributionListContact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                emailDistributionListContact.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public EmailDistributionListContact GetEmailDistributionListContactWithEmailDistributionListContactID(int EmailDistributionListContactID)
        {
            IQueryable<EmailDistributionListContact> emailDistributionListContactQuery = (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.EmailDistributionListContactID == EmailDistributionListContactID
                                                select c);

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return emailDistributionListContactQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillEmailDistributionListContactWeb(emailDistributionListContactQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillEmailDistributionListContactReport(emailDistributionListContactQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<EmailDistributionListContact> GetEmailDistributionListContactList()
        {
            IQueryable<EmailDistributionListContact> emailDistributionListContactQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        emailDistributionListContactQuery = EnhanceQueryStatements<EmailDistributionListContact>(emailDistributionListContactQuery) as IQueryable<EmailDistributionListContact>;

                        return emailDistributionListContactQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        emailDistributionListContactQuery = FillEmailDistributionListContactWeb(emailDistributionListContactQuery);

                        emailDistributionListContactQuery = EnhanceQueryStatements<EmailDistributionListContact>(emailDistributionListContactQuery) as IQueryable<EmailDistributionListContact>;

                        return emailDistributionListContactQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        emailDistributionListContactQuery = FillEmailDistributionListContactReport(emailDistributionListContactQuery);

                        emailDistributionListContactQuery = EnhanceQueryStatements<EmailDistributionListContact>(emailDistributionListContactQuery) as IQueryable<EmailDistributionListContact>;

                        return emailDistributionListContactQuery;
                    }
                default:
                    {
                        emailDistributionListContactQuery = emailDistributionListContactQuery.Where(c => c.EmailDistributionListContactID == 0);

                        return emailDistributionListContactQuery;
                    }
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(EmailDistributionListContact emailDistributionListContact)
        {
            emailDistributionListContact.ValidationResults = Validate(new ValidationContext(emailDistributionListContact), ActionDBTypeEnum.Create);
            if (emailDistributionListContact.ValidationResults.Count() > 0) return false;

            db.EmailDistributionListContacts.Add(emailDistributionListContact);

            if (!TryToSave(emailDistributionListContact)) return false;

            return true;
        }
        public bool Delete(EmailDistributionListContact emailDistributionListContact)
        {
            emailDistributionListContact.ValidationResults = Validate(new ValidationContext(emailDistributionListContact), ActionDBTypeEnum.Delete);
            if (emailDistributionListContact.ValidationResults.Count() > 0) return false;

            db.EmailDistributionListContacts.Remove(emailDistributionListContact);

            if (!TryToSave(emailDistributionListContact)) return false;

            return true;
        }
        public bool Update(EmailDistributionListContact emailDistributionListContact)
        {
            emailDistributionListContact.ValidationResults = Validate(new ValidationContext(emailDistributionListContact), ActionDBTypeEnum.Update);
            if (emailDistributionListContact.ValidationResults.Count() > 0) return false;

            db.EmailDistributionListContacts.Update(emailDistributionListContact);

            if (!TryToSave(emailDistributionListContact)) return false;

            return true;
        }
        public IQueryable<EmailDistributionListContact> GetRead()
        {
            IQueryable<EmailDistributionListContact> emailDistributionListContactQuery = db.EmailDistributionListContacts.AsNoTracking();

            return emailDistributionListContactQuery;
        }
        public IQueryable<EmailDistributionListContact> GetEdit()
        {
            IQueryable<EmailDistributionListContact> emailDistributionListContactQuery = db.EmailDistributionListContacts;

            return emailDistributionListContactQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated EmailDistributionListContactFillWeb
        private IQueryable<EmailDistributionListContact> FillEmailDistributionListContactWeb(IQueryable<EmailDistributionListContact> emailDistributionListContactQuery)
        {
            emailDistributionListContactQuery = (from c in emailDistributionListContactQuery
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new EmailDistributionListContact
                    {
                        EmailDistributionListContactID = c.EmailDistributionListContactID,
                        EmailDistributionListID = c.EmailDistributionListID,
                        IsCC = c.IsCC,
                        Name = c.Name,
                        Email = c.Email,
                        CMPRainfallSeasonal = c.CMPRainfallSeasonal,
                        CMPWastewater = c.CMPWastewater,
                        EmergencyWeather = c.EmergencyWeather,
                        EmergencyWastewater = c.EmergencyWastewater,
                        ReopeningAllTypes = c.ReopeningAllTypes,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        EmailDistributionListContactWeb = new EmailDistributionListContactWeb
                        {
                            LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        },
                        EmailDistributionListContactReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return emailDistributionListContactQuery;
        }
        #endregion Functions private Generated EmailDistributionListContactFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(EmailDistributionListContact emailDistributionListContact)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                emailDistributionListContact.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
