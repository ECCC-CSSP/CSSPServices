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
        public EmailDistributionListLanguageService(Query query, CSSPWebToolsDBContext db, int ContactID)
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
        public EmailDistributionListLanguageWeb GetEmailDistributionListLanguageWebWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID)
        {
            return FillEmailDistributionListLanguageWeb().Where(c => c.EmailDistributionListLanguageID == EmailDistributionListLanguageID).FirstOrDefault();

        }
        public IQueryable<EmailDistributionListLanguageWeb> GetEmailDistributionListLanguageWebList()
        {
            IQueryable<EmailDistributionListLanguageWeb> EmailDistributionListLanguageWebQuery = FillEmailDistributionListLanguageWeb();

            EmailDistributionListLanguageWebQuery = EnhanceQueryStatements<EmailDistributionListLanguageWeb>(EmailDistributionListLanguageWebQuery) as IQueryable<EmailDistributionListLanguageWeb>;

            return EmailDistributionListLanguageWebQuery;
        }
        public EmailDistributionListLanguageReport GetEmailDistributionListLanguageReportWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID)
        {
            return FillEmailDistributionListLanguageReport().Where(c => c.EmailDistributionListLanguageID == EmailDistributionListLanguageID).FirstOrDefault();

        }
        public IQueryable<EmailDistributionListLanguageReport> GetEmailDistributionListLanguageReportList()
        {
            IQueryable<EmailDistributionListLanguageReport> EmailDistributionListLanguageReportQuery = FillEmailDistributionListLanguageReport();

            EmailDistributionListLanguageReportQuery = EnhanceQueryStatements<EmailDistributionListLanguageReport>(EmailDistributionListLanguageReportQuery) as IQueryable<EmailDistributionListLanguageReport>;

            return EmailDistributionListLanguageReportQuery;
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

        #region Functions private Generated EmailDistributionListLanguageFillWeb
        private IQueryable<EmailDistributionListLanguageWeb> FillEmailDistributionListLanguageWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<EmailDistributionListLanguageWeb>  EmailDistributionListLanguageWebQuery = (from c in db.EmailDistributionListLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new EmailDistributionListLanguageWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        EmailDistributionListLanguageID = c.EmailDistributionListLanguageID,
                        EmailDistributionListID = c.EmailDistributionListID,
                        Language = c.Language,
                        RegionName = c.RegionName,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return EmailDistributionListLanguageWebQuery;
        }
        #endregion Functions private Generated EmailDistributionListLanguageFillWeb

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
