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
    ///     <para>bonjour Email</para>
    /// </summary>
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
            email.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (email.EmailID == 0)
                {
                    email.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailEmailID), new[] { "EmailID" });
                }

                if (!GetRead().Where(c => c.EmailID == email.EmailID).Any())
                {
                    email.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Email, CSSPModelsRes.EmailEmailID, email.EmailID.ToString()), new[] { "EmailID" });
                }
            }

            //EmailID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EmailTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemEmailTVItemID = (from c in db.TVItems where c.TVItemID == email.EmailTVItemID select c).FirstOrDefault();

            if (TVItemEmailTVItemID == null)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailEmailTVItemID, email.EmailTVItemID.ToString()), new[] { "EmailTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Email,
                };
                if (!AllowableTVTypes.Contains(TVItemEmailTVItemID.TVType))
                {
                    email.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailEmailTVItemID, "Email"), new[] { "EmailTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailEmailAddress), new[] { "EmailAddress" });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress) && email.EmailAddress.Length > 255)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailEmailAddress, "255"), new[] { "EmailAddress" });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(email.EmailAddress))
                {
                    email.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, CSSPModelsRes.EmailEmailAddress), new[] { "EmailAddress" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(EmailTypeEnum), (int?)email.EmailType);
            if (email.EmailType == EmailTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailEmailType), new[] { "EmailType" });
            }

            if (email.LastUpdateDate_UTC.Year == 1)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (email.LastUpdateDate_UTC.Year < 1980)
                {
                email.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == email.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailLastUpdateContactTVItemID, email.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    email.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(email.EmailTVText) && email.EmailTVText.Length > 200)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailEmailTVText, "200"), new[] { "EmailTVText" });
            }

            if (!string.IsNullOrWhiteSpace(email.LastUpdateContactTVText) && email.LastUpdateContactTVText.Length > 200)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailTypeText) && email.EmailTypeText.Length > 100)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailEmailTypeText, "100"), new[] { "EmailTypeText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                email.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Email GetEmailWithEmailID(int EmailID)
        {
            IQueryable<Email> emailQuery = (from c in GetRead()
                                                where c.EmailID == EmailID
                                                select c);

            return FillEmail(emailQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(Email email)
        {
            email.ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Create);
            if (email.ValidationResults.Count() > 0) return false;

            db.Emails.Add(email);

            if (!TryToSave(email)) return false;

            return true;
        }
        public bool Delete(Email email)
        {
            email.ValidationResults = Validate(new ValidationContext(email), ActionDBTypeEnum.Delete);
            if (email.ValidationResults.Count() > 0) return false;

            db.Emails.Remove(email);

            if (!TryToSave(email)) return false;

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
        public IQueryable<Email> GetRead()
        {
            return db.Emails.AsNoTracking();
        }
        public IQueryable<Email> GetEdit()
        {
            return db.Emails;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<Email> FillEmail(IQueryable<Email> emailQuery)
        {
            List<Email> EmailList = (from c in emailQuery
                                         let EmailTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.EmailTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new Email
                                         {
                                             EmailID = c.EmailID,
                                             EmailTVItemID = c.EmailTVItemID,
                                             EmailAddress = c.EmailAddress,
                                             EmailType = c.EmailType,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             EmailTVText = EmailTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (Email email in EmailList)
            {
                email.EmailTypeText = enums.GetResValueForTypeAndID(typeof(EmailTypeEnum), (int?)email.EmailType);
            }

            return EmailList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
