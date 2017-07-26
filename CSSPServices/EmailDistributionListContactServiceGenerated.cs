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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactEmailDistributionListContactID), new[] { ModelsRes.EmailDistributionListContactEmailDistributionListContactID });
                }
            }

            //EmailDistributionListContactID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EmailDistributionListID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (emailDistributionListContact.EmailDistributionListID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailDistributionListContactEmailDistributionListID, "1"), new[] { ModelsRes.EmailDistributionListContactEmailDistributionListID });
            }

            if (!((from c in db.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListContact.EmailDistributionListID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.EmailDistributionList, ModelsRes.EmailDistributionListContactEmailDistributionListID, emailDistributionListContact.EmailDistributionListID.ToString()), new[] { ModelsRes.EmailDistributionListContactEmailDistributionListID });
            }

            //IsCC (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Agency))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactAgency), new[] { ModelsRes.EmailDistributionListContactAgency });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Agency) && emailDistributionListContact.Agency.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactAgency, "20"), new[] { ModelsRes.EmailDistributionListContactAgency });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Name))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactName), new[] { ModelsRes.EmailDistributionListContactName });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Name) && emailDistributionListContact.Name.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactName, "100"), new[] { ModelsRes.EmailDistributionListContactName });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactEmail), new[] { ModelsRes.EmailDistributionListContactEmail });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email) && emailDistributionListContact.Email.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactEmail, "200"), new[] { ModelsRes.EmailDistributionListContactEmail });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContact.Email))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(emailDistributionListContact.Email))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes.EmailDistributionListContactEmail), new[] { ModelsRes.EmailDistributionListContactEmail });
                }
            }

            //CMPRainfallSeasonal (bool) is required but no testing needed 

            //CMPWastewater (bool) is required but no testing needed 

            //EmergencyWeather (bool) is required but no testing needed 

            //EmergencyWastewater (bool) is required but no testing needed 

            //ReopeningAllTypes (bool) is required but no testing needed 

            if (emailDistributionListContact.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactLastUpdateDate_UTC), new[] { ModelsRes.EmailDistributionListContactLastUpdateDate_UTC });
            }
            else
            {
                if (emailDistributionListContact.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.EmailDistributionListContactLastUpdateDate_UTC, "1980"), new[] { ModelsRes.EmailDistributionListContactLastUpdateDate_UTC });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (emailDistributionListContact.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, "1"), new[] { ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == emailDistributionListContact.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, emailDistributionListContact.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
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
        #endregion Functions public

        #region Functions private
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
        #endregion Functions private
    }
}
