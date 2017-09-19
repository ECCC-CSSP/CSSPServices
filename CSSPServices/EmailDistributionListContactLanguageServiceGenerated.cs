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

            //EmailDistributionListContactLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //EmailDistributionListContactID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            EmailDistributionListContact EmailDistributionListContactEmailDistributionListContactID = (from c in db.EmailDistributionListContacts where c.EmailDistributionListContactID == emailDistributionListContactLanguage.EmailDistributionListContactID select c).FirstOrDefault();

            if (EmailDistributionListContactEmailDistributionListContactID == null)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListContact, CSSPModelsRes.EmailDistributionListContactLanguageEmailDistributionListContactID, emailDistributionListContactLanguage.EmailDistributionListContactID.ToString()), new[] { "EmailDistributionListContactID" });
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

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListContactLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateContactTVItemID, emailDistributionListContactLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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

            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguage.LastUpdateContactTVText) && emailDistributionListContactLanguage.LastUpdateContactTVText.Length > 200)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguage.LanguageText) && emailDistributionListContactLanguage.LanguageText.Length > 100)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailDistributionListContactLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguage.TranslationStatusText) && emailDistributionListContactLanguage.TranslationStatusText.Length > 100)
            {
                emailDistributionListContactLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailDistributionListContactLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            //HasErrors (bool) is required but no testing needed 

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
            IQueryable<EmailDistributionListContactLanguage> emailDistributionListContactLanguageQuery = (from c in GetRead()
                                                where c.EmailDistributionListContactLanguageID == EmailDistributionListContactLanguageID
                                                select c);

            return FillEmailDistributionListContactLanguage(emailDistributionListContactLanguageQuery).FirstOrDefault();
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

        #region Functions private Generated Fill Class
        private List<EmailDistributionListContactLanguage> FillEmailDistributionListContactLanguage(IQueryable<EmailDistributionListContactLanguage> emailDistributionListContactLanguageQuery)
        {
            List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList = (from c in emailDistributionListContactLanguageQuery
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
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (EmailDistributionListContactLanguage emailDistributionListContactLanguage in EmailDistributionListContactLanguageList)
            {
                emailDistributionListContactLanguage.LanguageText = enums.GetResValueForTypeAndID(typeof(LanguageEnum), (int?)emailDistributionListContactLanguage.Language);
                emailDistributionListContactLanguage.TranslationStatusText = enums.GetResValueForTypeAndID(typeof(TranslationStatusEnum), (int?)emailDistributionListContactLanguage.TranslationStatus);
            }

            return EmailDistributionListContactLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
