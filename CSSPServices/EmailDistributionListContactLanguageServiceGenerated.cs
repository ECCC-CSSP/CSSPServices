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
        public EmailDistributionListContactLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageEmailDistributionListContactLanguageID), new[] { "EmailDistributionListContactLanguageID" });
                }

                if (!GetRead().Where(c => c.EmailDistributionListContactLanguageID == emailDistributionListContactLanguage.EmailDistributionListContactLanguageID).Any())
                {
                    emailDistributionListContactLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListContactLanguage, CSSPModelsRes.EmailDistributionListContactLanguageEmailDistributionListContactLanguageID, emailDistributionListContactLanguage.EmailDistributionListContactLanguageID.ToString()), new[] { "EmailDistributionListContactLanguageID" });
                }
            }

            EmailDistributionListContact EmailDistributionListContactEmailDistributionListContactID = (from c in db.EmailDistributionListContacts where c.EmailDistributionListContactID == emailDistributionListContactLanguage.EmailDistributionListContactID select c).FirstOrDefault();

            if (EmailDistributionListContactEmailDistributionListContactID == null)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListContact, CSSPModelsRes.EmailDistributionListContactLanguageEmailDistributionListContactID, (emailDistributionListContactLanguage.EmailDistributionListContactID == null ? "" : emailDistributionListContactLanguage.EmailDistributionListContactID.ToString())), new[] { "EmailDistributionListContactID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)emailDistributionListContactLanguage.Language);
            if (emailDistributionListContactLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListContactLanguage.Agency))
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageAgency), new[] { "Agency" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguage.Agency) && (emailDistributionListContactLanguage.Agency.Length < 1 || emailDistributionListContactLanguage.Agency.Length > 100))
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.EmailDistributionListContactLanguageAgency, "1", "100"), new[] { "Agency" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)emailDistributionListContactLanguage.TranslationStatus);
            if (emailDistributionListContactLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (emailDistributionListContactLanguage.LastUpdateDate_UTC.Year == 1)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionListContactLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                emailDistributionListContactLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListContactLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateContactTVItemID, (emailDistributionListContactLanguage.LastUpdateContactTVItemID == null ? "" : emailDistributionListContactLanguage.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public EmailDistributionListContactLanguage GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(int EmailDistributionListContactLanguageID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<EmailDistributionListContactLanguage> emailDistributionListContactLanguageQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.EmailDistributionListContactLanguageID == EmailDistributionListContactLanguageID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return emailDistributionListContactLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillEmailDistributionListContactLanguageWeb(emailDistributionListContactLanguageQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillEmailDistributionListContactLanguageReport(emailDistributionListContactLanguageQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<EmailDistributionListContactLanguage> GetEmailDistributionListContactLanguageList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<EmailDistributionListContactLanguage> emailDistributionListContactLanguageQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return emailDistributionListContactLanguageQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillEmailDistributionListContactLanguageWeb(emailDistributionListContactLanguageQuery, FilterAndOrderText).Take(MaxGetCount);
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillEmailDistributionListContactLanguageReport(emailDistributionListContactLanguageQuery, FilterAndOrderText).Take(MaxGetCount);
                default:
                    return null;
            }
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
        public IQueryable<EmailDistributionListContactLanguage> GetRead()
        {
            return db.EmailDistributionListContactLanguages.AsNoTracking();
        }
        public IQueryable<EmailDistributionListContactLanguage> GetEdit()
        {
            return db.EmailDistributionListContactLanguages;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated EmailDistributionListContactLanguageFillWeb
        private IQueryable<EmailDistributionListContactLanguage> FillEmailDistributionListContactLanguageWeb(IQueryable<EmailDistributionListContactLanguage> emailDistributionListContactLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            emailDistributionListContactLanguageQuery = (from c in emailDistributionListContactLanguageQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new EmailDistributionListContactLanguage
                    {
                        EmailDistributionListContactLanguageID = c.EmailDistributionListContactLanguageID,
                        EmailDistributionListContactID = c.EmailDistributionListContactID,
                        Language = c.Language,
                        Agency = c.Agency,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        EmailDistributionListContactLanguageWeb = new EmailDistributionListContactLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        },
                        EmailDistributionListContactLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return emailDistributionListContactLanguageQuery;
        }
        #endregion Functions private Generated EmailDistributionListContactLanguageFillWeb

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
