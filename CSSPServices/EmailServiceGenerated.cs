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
    public partial class EmailService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Email email = validationContext.ObjectInstance as Email;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (email.EmailID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailEmailID), new[] { ModelsRes.EmailEmailID });
                }
            }

            //EmailID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EmailTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (email.EmailTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailEmailTVItemID, "1"), new[] { ModelsRes.EmailEmailTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == email.EmailTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailEmailTVItemID, email.EmailTVItemID.ToString()), new[] { ModelsRes.EmailEmailTVItemID });
            }

            if (string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailEmailAddress), new[] { ModelsRes.EmailEmailAddress });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress) && email.EmailAddress.Length > 255)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailEmailAddress, "255"), new[] { ModelsRes.EmailEmailAddress });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(email.EmailAddress))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotAValidEmail, ModelsRes.EmailEmailAddress), new[] { ModelsRes.EmailEmailAddress });
                }
            }

            retStr = enums.EmailTypeOK(email.EmailType);
            if (email.EmailType == EmailTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailEmailType), new[] { ModelsRes.EmailEmailType });
            }

            if (email.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.EmailLastUpdateDate_UTC), new[] { ModelsRes.EmailLastUpdateDate_UTC });
            }

            if (email.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.EmailLastUpdateDate_UTC, "1980"), new[] { ModelsRes.EmailLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (email.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailLastUpdateContactTVItemID, "1"), new[] { ModelsRes.EmailLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == email.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailLastUpdateContactTVItemID, email.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.EmailLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(Email email)
        {
            email.ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Create);
            if (email.ValidationResults.Count() > 0) return false;

            db.Emails.Add(email);

            if (!TryToSave(email)) return false;

            return true;
        }
        public bool AddRange(List<Email> emailList)
        {
            foreach (Email email in emailList)
            {
                email.ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Create);
                if (email.ValidationResults.Count() > 0) return false;
            }

            db.Emails.AddRange(emailList);

            if (!TryToSaveRange(emailList)) return false;

            return true;
        }
        public bool Delete(Email email)
        {
            if (!db.Emails.Where(c => c.EmailID == email.EmailID).Any())
            {
                email.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Email", "EmailID", email.EmailID.ToString())) }.AsEnumerable();
                return false;
            }

            db.Emails.Remove(email);

            if (!TryToSave(email)) return false;

            return true;
        }
        public bool DeleteRange(List<Email> emailList)
        {
            foreach (Email email in emailList)
            {
                if (!db.Emails.Where(c => c.EmailID == email.EmailID).Any())
                {
                    emailList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Email", "EmailID", email.EmailID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.Emails.RemoveRange(emailList);

            if (!TryToSaveRange(emailList)) return false;

            return true;
        }
        public bool Update(Email email)
        {
            email.ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Update);
            if (email.ValidationResults.Count() > 0) return false;

            db.Emails.Update(email);

            if (!TryToSave(email)) return false;

            return true;
        }
        public bool UpdateRange(List<Email> emailList)
        {
            foreach (Email email in emailList)
            {
                email.ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Update);
                if (email.ValidationResults.Count() > 0) return false;
            }
            db.Emails.UpdateRange(emailList);

            if (!TryToSaveRange(emailList)) return false;

            return true;
        }
        public IQueryable<Email> GetRead()
        {
            return db.Emails.AsNoTracking();
        }
        public IQueryable<Email> GetEdit()
        {
            return db.Emails;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(Email email)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                email.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<Email> emailList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                emailList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
