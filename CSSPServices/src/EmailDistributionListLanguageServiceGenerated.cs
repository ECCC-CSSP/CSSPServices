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
    ///     <para>bonjour EmailDistributionListLanguage</para>
    /// </summary>
    public partial class EmailDistributionListLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            EmailDistributionListLanguage emailDistributionListLanguage = validationContext.ObjectInstance as EmailDistributionListLanguage;
            emailDistributionListLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (emailDistributionListLanguage.EmailDistributionListLanguageID == 0)
                {
                    emailDistributionListLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageEmailDistributionListLanguageID"), new[] { "EmailDistributionListLanguageID" });
                }

                if (!(from c in db.EmailDistributionListLanguages select c).Where(c => c.EmailDistributionListLanguageID == emailDistributionListLanguage.EmailDistributionListLanguageID).Any())
                {
                    emailDistributionListLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListLanguage", "EmailDistributionListLanguageEmailDistributionListLanguageID", emailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), new[] { "EmailDistributionListLanguageID" });
                }
            }

            EmailDistributionList EmailDistributionListEmailDistributionListID = (from c in db.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListLanguage.EmailDistributionListID select c).FirstOrDefault();

            if (EmailDistributionListEmailDistributionListID == null)
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListLanguageEmailDistributionListID", emailDistributionListLanguage.EmailDistributionListID.ToString()), new[] { "EmailDistributionListID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)emailDistributionListLanguage.Language);
            if (emailDistributionListLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageLanguage"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListLanguage.RegionName))
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageRegionName"), new[] { "RegionName" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListLanguage.RegionName) && (emailDistributionListLanguage.RegionName.Length < 1 || emailDistributionListLanguage.RegionName.Length > 100))
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "EmailDistributionListLanguageRegionName", "1", "100"), new[] { "RegionName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)emailDistributionListLanguage.TranslationStatus);
            if (emailDistributionListLanguage.TranslationStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageTranslationStatus"), new[] { "TranslationStatus" });
            }

            if (emailDistributionListLanguage.LastUpdateDate_UTC.Year == 1)
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionListLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                emailDistributionListLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EmailDistributionListLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailDistributionListLanguageLastUpdateContactTVItemID", emailDistributionListLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    emailDistributionListLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "EmailDistributionListLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public EmailDistributionListLanguage GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID)
        {
            return (from c in db.EmailDistributionListLanguages
                    where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<EmailDistributionListLanguage> GetEmailDistributionListLanguageList()
        {
            IQueryable<EmailDistributionListLanguage> EmailDistributionListLanguageQuery = (from c in db.EmailDistributionListLanguages select c);

            EmailDistributionListLanguageQuery = EnhanceQueryStatements<EmailDistributionListLanguage>(EmailDistributionListLanguageQuery) as IQueryable<EmailDistributionListLanguage>;

            return EmailDistributionListLanguageQuery;
        }
        public EmailDistributionListLanguage_A GetEmailDistributionListLanguage_AWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID)
        {
            return FillEmailDistributionListLanguage_A().Where(c => c.EmailDistributionListLanguageID == EmailDistributionListLanguageID).FirstOrDefault();

        }
        public IQueryable<EmailDistributionListLanguage_A> GetEmailDistributionListLanguage_AList()
        {
            IQueryable<EmailDistributionListLanguage_A> EmailDistributionListLanguage_AQuery = FillEmailDistributionListLanguage_A();

            EmailDistributionListLanguage_AQuery = EnhanceQueryStatements<EmailDistributionListLanguage_A>(EmailDistributionListLanguage_AQuery) as IQueryable<EmailDistributionListLanguage_A>;

            return EmailDistributionListLanguage_AQuery;
        }
        public EmailDistributionListLanguage_B GetEmailDistributionListLanguage_BWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID)
        {
            return FillEmailDistributionListLanguage_B().Where(c => c.EmailDistributionListLanguageID == EmailDistributionListLanguageID).FirstOrDefault();

        }
        public IQueryable<EmailDistributionListLanguage_B> GetEmailDistributionListLanguage_BList()
        {
            IQueryable<EmailDistributionListLanguage_B> EmailDistributionListLanguage_BQuery = FillEmailDistributionListLanguage_B();

            EmailDistributionListLanguage_BQuery = EnhanceQueryStatements<EmailDistributionListLanguage_B>(EmailDistributionListLanguage_BQuery) as IQueryable<EmailDistributionListLanguage_B>;

            return EmailDistributionListLanguage_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            emailDistributionListLanguage.ValidationResults = Validate(new ValidationContext(emailDistributionListLanguage), ActionDBTypeEnum.Create);
            if (emailDistributionListLanguage.ValidationResults.Count() > 0) return false;

            db.EmailDistributionListLanguages.Add(emailDistributionListLanguage);

            if (!TryToSave(emailDistributionListLanguage)) return false;

            return true;
        }
        public bool Delete(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            emailDistributionListLanguage.ValidationResults = Validate(new ValidationContext(emailDistributionListLanguage), ActionDBTypeEnum.Delete);
            if (emailDistributionListLanguage.ValidationResults.Count() > 0) return false;

            db.EmailDistributionListLanguages.Remove(emailDistributionListLanguage);

            if (!TryToSave(emailDistributionListLanguage)) return false;

            return true;
        }
        public bool Update(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            emailDistributionListLanguage.ValidationResults = Validate(new ValidationContext(emailDistributionListLanguage), ActionDBTypeEnum.Update);
            if (emailDistributionListLanguage.ValidationResults.Count() > 0) return false;

            db.EmailDistributionListLanguages.Update(emailDistributionListLanguage);

            if (!TryToSave(emailDistributionListLanguage)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(EmailDistributionListLanguage emailDistributionListLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                emailDistributionListLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
