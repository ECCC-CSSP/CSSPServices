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
    ///     <para>bonjour EmailDistributionListContactLanguage</para>
    /// </summary>
    public partial class EmailDistributionListContactLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            EmailDistributionListContactLanguage emailDistributionListContactLanguage = validationContext.ObjectInstance as EmailDistributionListContactLanguage;
            emailDistributionListContactLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionListContactLanguage.EmailDistributionListContactLanguageID == 0)
                {
                    emailDistributionListContactLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageEmailDistributionListContactLanguageID"), new[] { "EmailDistributionListContactLanguageID" });
                }

                if (!(from c in db.EmailDistributionListContactLanguages select c).Where(c => c.EmailDistributionListContactLanguageID == emailDistributionListContactLanguage.EmailDistributionListContactLanguageID).Any())
                {
                    emailDistributionListContactLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContactLanguage", "EmailDistributionListContactLanguageEmailDistributionListContactLanguageID", emailDistributionListContactLanguage.EmailDistributionListContactLanguageID.ToString()), new[] { "EmailDistributionListContactLanguageID" });
                }
            }

            EmailDistributionListContact EmailDistributionListContactEmailDistributionListContactID = (from c in db.EmailDistributionListContacts where c.EmailDistributionListContactID == emailDistributionListContactLanguage.EmailDistributionListContactID select c).FirstOrDefault();

            if (EmailDistributionListContactEmailDistributionListContactID == null)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactLanguageEmailDistributionListContactID", emailDistributionListContactLanguage.EmailDistributionListContactID.ToString()), new[] { "EmailDistributionListContactID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)emailDistributionListContactLanguage.Language);
            if (emailDistributionListContactLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageLanguage"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContactLanguage.Agency))
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageAgency"), new[] { "Agency" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguage.Agency) && (emailDistributionListContactLanguage.Agency.Length < 1 || emailDistributionListContactLanguage.Agency.Length > 100))
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "EmailDistributionListContactLanguageAgency", "1", "100"), new[] { "Agency" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)emailDistributionListContactLanguage.TranslationStatus);
            if (emailDistributionListContactLanguage.TranslationStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageTranslationStatus"), new[] { "TranslationStatus" });
            }

            if (emailDistributionListContactLanguage.LastUpdateDate_UTC.Year == 1)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionListContactLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                emailDistributionListContactLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EmailDistributionListContactLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListContactLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailDistributionListContactLanguageLastUpdateContactTVItemID", emailDistributionListContactLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    emailDistributionListContactLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "EmailDistributionListContactLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public EmailDistributionListContactLanguage GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(int EmailDistributionListContactLanguageID)
        {
            return (from c in db.EmailDistributionListContactLanguages
                    where c.EmailDistributionListContactLanguageID == EmailDistributionListContactLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<EmailDistributionListContactLanguage> GetEmailDistributionListContactLanguageList()
        {
            IQueryable<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageQuery = (from c in db.EmailDistributionListContactLanguages select c);

            EmailDistributionListContactLanguageQuery = EnhanceQueryStatements<EmailDistributionListContactLanguage>(EmailDistributionListContactLanguageQuery) as IQueryable<EmailDistributionListContactLanguage>;

            return EmailDistributionListContactLanguageQuery;
        }
        public EmailDistributionListContactLanguage_A GetEmailDistributionListContactLanguage_AWithEmailDistributionListContactLanguageID(int EmailDistributionListContactLanguageID)
        {
            return FillEmailDistributionListContactLanguage_A().Where(c => c.EmailDistributionListContactLanguageID == EmailDistributionListContactLanguageID).FirstOrDefault();

        }
        public IQueryable<EmailDistributionListContactLanguage_A> GetEmailDistributionListContactLanguage_AList()
        {
            IQueryable<EmailDistributionListContactLanguage_A> EmailDistributionListContactLanguage_AQuery = FillEmailDistributionListContactLanguage_A();

            EmailDistributionListContactLanguage_AQuery = EnhanceQueryStatements<EmailDistributionListContactLanguage_A>(EmailDistributionListContactLanguage_AQuery) as IQueryable<EmailDistributionListContactLanguage_A>;

            return EmailDistributionListContactLanguage_AQuery;
        }
        public EmailDistributionListContactLanguage_B GetEmailDistributionListContactLanguage_BWithEmailDistributionListContactLanguageID(int EmailDistributionListContactLanguageID)
        {
            return FillEmailDistributionListContactLanguage_B().Where(c => c.EmailDistributionListContactLanguageID == EmailDistributionListContactLanguageID).FirstOrDefault();

        }
        public IQueryable<EmailDistributionListContactLanguage_B> GetEmailDistributionListContactLanguage_BList()
        {
            IQueryable<EmailDistributionListContactLanguage_B> EmailDistributionListContactLanguage_BQuery = FillEmailDistributionListContactLanguage_B();

            EmailDistributionListContactLanguage_BQuery = EnhanceQueryStatements<EmailDistributionListContactLanguage_B>(EmailDistributionListContactLanguage_BQuery) as IQueryable<EmailDistributionListContactLanguage_B>;

            return EmailDistributionListContactLanguage_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
        {
            emailDistributionListContactLanguage.ValidationResults = Validate(new ValidationContext(emailDistributionListContactLanguage), ActionDBTypeEnum.Create);
            if (emailDistributionListContactLanguage.ValidationResults.Count() > 0) return false;

            db.EmailDistributionListContactLanguages.Add(emailDistributionListContactLanguage);

            if (!TryToSave(emailDistributionListContactLanguage)) return false;

            return true;
        }
        public bool Delete(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
        {
            emailDistributionListContactLanguage.ValidationResults = Validate(new ValidationContext(emailDistributionListContactLanguage), ActionDBTypeEnum.Delete);
            if (emailDistributionListContactLanguage.ValidationResults.Count() > 0) return false;

            db.EmailDistributionListContactLanguages.Remove(emailDistributionListContactLanguage);

            if (!TryToSave(emailDistributionListContactLanguage)) return false;

            return true;
        }
        public bool Update(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
        {
            emailDistributionListContactLanguage.ValidationResults = Validate(new ValidationContext(emailDistributionListContactLanguage), ActionDBTypeEnum.Update);
            if (emailDistributionListContactLanguage.ValidationResults.Count() > 0) return false;

            db.EmailDistributionListContactLanguages.Update(emailDistributionListContactLanguage);

            if (!TryToSave(emailDistributionListContactLanguage)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(EmailDistributionListContactLanguage emailDistributionListContactLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                emailDistributionListContactLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
