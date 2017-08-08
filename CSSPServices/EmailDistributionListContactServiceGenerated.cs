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
    public partial class EmailDistributionListContactService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            EmailDistributionListContact emailDistributionListContact = validationContext.ObjectInstance as EmailDistributionListContact;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (emailDistributionListContact.EmailDistributionListContactID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactEmailDistributionListContactID), new[] { "EmailDistributionListContactID" });
                }
            }

            //EmailDistributionListContactID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EmailDistributionListID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            EmailDistributionList EmailDistributionListEmailDistributionListID = (from c in db.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListContact.EmailDistributionListID select c).FirstOrDefault();

            if (EmailDistributionListEmailDistributionListID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.EmailDistributionList, ModelsRes.EmailDistributionListContactEmailDistributionListID, emailDistributionListContact.EmailDistributionListID.ToString()), new[] { "EmailDistributionListID" });
            }

            //IsCC (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Agency))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactAgency), new[] { "Agency" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Agency) && emailDistributionListContact.Agency.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactAgency, "20"), new[] { "Agency" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Name))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactName), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Name) && emailDistributionListContact.Name.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactName, "100"), new[] { "Name" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactEmail), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email) && emailDistributionListContact.Email.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactEmail, "200"), new[] { "Email" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(emailDistributionListContact.Email))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes.EmailDistributionListContactEmail), new[] { "Email" });
                }
            }

            //CMPRainfallSeasonal (bool) is required but no testing needed 

            //CMPWastewater (bool) is required but no testing needed 

            //EmergencyWeather (bool) is required but no testing needed 

            //EmergencyWastewater (bool) is required but no testing needed 

            //ReopeningAllTypes (bool) is required but no testing needed 

            if (emailDistributionListContact.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionListContact.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.EmailDistributionListContactLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListContact.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, emailDistributionListContact.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.LastUpdateContactTVText) && emailDistributionListContact.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public EmailDistributionListContact GetEmailDistributionListContactWithEmailDistributionListContactID(int EmailDistributionListContactID)
        {
            IQueryable<EmailDistributionListContact> emailDistributionListContactQuery = (from c in GetRead()
                                                where c.EmailDistributionListContactID == EmailDistributionListContactID
                                                select c);

            return FillEmailDistributionListContact(emailDistributionListContactQuery).FirstOrDefault();
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
        public bool AddRange(List<EmailDistributionListContact> emailDistributionListContactList)
        {
            foreach (EmailDistributionListContact emailDistributionListContact in emailDistributionListContactList)
            {
                emailDistributionListContact.ValidationResults = Validate(new ValidationContext(emailDistributionListContact), ActionDBTypeEnum.Create);
                if (emailDistributionListContact.ValidationResults.Count() > 0) return false;
            }

            db.EmailDistributionListContacts.AddRange(emailDistributionListContactList);

            if (!TryToSaveRange(emailDistributionListContactList)) return false;

            return true;
        }
        public bool Delete(EmailDistributionListContact emailDistributionListContact)
        {
            if (!db.EmailDistributionListContacts.Where(c => c.EmailDistributionListContactID == emailDistributionListContact.EmailDistributionListContactID).Any())
            {
                emailDistributionListContact.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", emailDistributionListContact.EmailDistributionListContactID.ToString())) }.AsEnumerable();
                return false;
            }

            db.EmailDistributionListContacts.Remove(emailDistributionListContact);

            if (!TryToSave(emailDistributionListContact)) return false;

            return true;
        }
        public bool DeleteRange(List<EmailDistributionListContact> emailDistributionListContactList)
        {
            foreach (EmailDistributionListContact emailDistributionListContact in emailDistributionListContactList)
            {
                if (!db.EmailDistributionListContacts.Where(c => c.EmailDistributionListContactID == emailDistributionListContact.EmailDistributionListContactID).Any())
                {
                    emailDistributionListContactList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactID", emailDistributionListContact.EmailDistributionListContactID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.EmailDistributionListContacts.RemoveRange(emailDistributionListContactList);

            if (!TryToSaveRange(emailDistributionListContactList)) return false;

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
        public bool UpdateRange(List<EmailDistributionListContact> emailDistributionListContactList)
        {
            foreach (EmailDistributionListContact emailDistributionListContact in emailDistributionListContactList)
            {
                emailDistributionListContact.ValidationResults = Validate(new ValidationContext(emailDistributionListContact), ActionDBTypeEnum.Update);
                if (emailDistributionListContact.ValidationResults.Count() > 0) return false;
            }
            db.EmailDistributionListContacts.UpdateRange(emailDistributionListContactList);

            if (!TryToSaveRange(emailDistributionListContactList)) return false;

            return true;
        }
        public IQueryable<EmailDistributionListContact> GetRead()
        {
            return db.EmailDistributionListContacts.AsNoTracking();
        }
        public IQueryable<EmailDistributionListContact> GetEdit()
        {
            return db.EmailDistributionListContacts;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<EmailDistributionListContact> FillEmailDistributionListContact(IQueryable<EmailDistributionListContact> emailDistributionListContactQuery)
        {
            List<EmailDistributionListContact> EmailDistributionListContactList = (from c in emailDistributionListContactQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new EmailDistributionListContact
                                         {
                                             EmailDistributionListContactID = c.EmailDistributionListContactID,
                                             EmailDistributionListID = c.EmailDistributionListID,
                                             IsCC = c.IsCC,
                                             Agency = c.Agency,
                                             Name = c.Name,
                                             Email = c.Email,
                                             CMPRainfallSeasonal = c.CMPRainfallSeasonal,
                                             CMPWastewater = c.CMPWastewater,
                                             EmergencyWeather = c.EmergencyWeather,
                                             EmergencyWastewater = c.EmergencyWastewater,
                                             ReopeningAllTypes = c.ReopeningAllTypes,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return EmailDistributionListContactList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        private bool TryToSaveRange(List<EmailDistributionListContact> emailDistributionListContactList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                emailDistributionListContactList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
