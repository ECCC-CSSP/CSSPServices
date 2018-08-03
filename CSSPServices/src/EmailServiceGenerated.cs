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
        public EmailService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailEmailID"), new[] { "EmailID" });
                }

                if (!GetRead().Where(c => c.EmailID == email.EmailID).Any())
                {
                    email.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Email", "EmailEmailID", email.EmailID.ToString()), new[] { "EmailID" });
                }
            }

            TVItem TVItemEmailTVItemID = (from c in db.TVItems where c.TVItemID == email.EmailTVItemID select c).FirstOrDefault();

            if (TVItemEmailTVItemID == null)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailEmailTVItemID", email.EmailTVItemID.ToString()), new[] { "EmailTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "EmailEmailTVItemID", "Email"), new[] { "EmailTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailEmailAddress"), new[] { "EmailAddress" });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress) && email.EmailAddress.Length > 255)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "EmailEmailAddress", "255"), new[] { "EmailAddress" });
            }

            if (!string.IsNullOrWhiteSpace(email.EmailAddress))
            {
                Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
                if (!regex.IsMatch(email.EmailAddress))
                {
                    email.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotAValidEmail, "EmailEmailAddress"), new[] { "EmailAddress" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(EmailTypeEnum), (int?)email.EmailType);
            if (email.EmailType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailEmailType"), new[] { "EmailType" });
            }

            if (email.LastUpdateDate_UTC.Year == 1)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (email.LastUpdateDate_UTC.Year < 1980)
                {
                email.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EmailLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == email.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                email.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailLastUpdateContactTVItemID", email.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "EmailLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.EmailID == EmailID
                    select c).FirstOrDefault();

        }
        public IQueryable<Email> GetEmailList()
        {
            IQueryable<Email> EmailQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            EmailQuery = EnhanceQueryStatements<Email>(EmailQuery) as IQueryable<Email>;

            return EmailQuery;
        }
        public EmailWeb GetEmailWebWithEmailID(int EmailID)
        {
            return FillEmailWeb().FirstOrDefault();

        }
        public IQueryable<EmailWeb> GetEmailWebList()
        {
            IQueryable<EmailWeb> EmailWebQuery = FillEmailWeb();

            EmailWebQuery = EnhanceQueryStatements<EmailWeb>(EmailWebQuery) as IQueryable<EmailWeb>;

            return EmailWebQuery;
        }
        public EmailReport GetEmailReportWithEmailID(int EmailID)
        {
            return FillEmailReport().FirstOrDefault();

        }
        public IQueryable<EmailReport> GetEmailReportList()
        {
            IQueryable<EmailReport> EmailReportQuery = FillEmailReport();

            EmailReportQuery = EnhanceQueryStatements<EmailReport>(EmailReportQuery) as IQueryable<EmailReport>;

            return EmailReportQuery;
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
            IQueryable<Email> emailQuery = db.Emails.AsNoTracking();

            return emailQuery;
        }
        public IQueryable<Email> GetEdit()
        {
            IQueryable<Email> emailQuery = db.Emails;

            return emailQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated EmailFillWeb
        private IQueryable<EmailWeb> FillEmailWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> EmailTypeEnumList = enums.GetEnumTextOrderedList(typeof(EmailTypeEnum));

             IQueryable<EmailWeb>  EmailWebQuery = (from c in db.Emails
                let EmailTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.EmailTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new EmailWeb
                    {
                        EmailTVItemLanguage = EmailTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        EmailTypeText = (from e in EmailTypeEnumList
                                where e.EnumID == (int?)c.EmailType
                                select e.EnumText).FirstOrDefault(),
                        EmailID = c.EmailID,
                        EmailTVItemID = c.EmailTVItemID,
                        EmailAddress = c.EmailAddress,
                        EmailType = c.EmailType,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return EmailWebQuery;
        }
        #endregion Functions private Generated EmailFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}