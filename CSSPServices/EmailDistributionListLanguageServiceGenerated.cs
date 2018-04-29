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
        public EmailDistributionListLanguageService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageEmailDistributionListLanguageID), new[] { "EmailDistributionListLanguageID" });
                }

                if (!GetRead().Where(c => c.EmailDistributionListLanguageID == emailDistributionListLanguage.EmailDistributionListLanguageID).Any())
                {
                    emailDistributionListLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListLanguage, CSSPModelsRes.EmailDistributionListLanguageEmailDistributionListLanguageID, emailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), new[] { "EmailDistributionListLanguageID" });
                }
            }

            EmailDistributionList EmailDistributionListEmailDistributionListID = (from c in db.EmailDistributionLists where c.EmailDistributionListID == emailDistributionListLanguage.EmailDistributionListID select c).FirstOrDefault();

            if (EmailDistributionListEmailDistributionListID == null)
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionList, CSSPModelsRes.EmailDistributionListLanguageEmailDistributionListID, (emailDistributionListLanguage.EmailDistributionListID == null ? "" : emailDistributionListLanguage.EmailDistributionListID.ToString())), new[] { "EmailDistributionListID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)emailDistributionListLanguage.Language);
            if (emailDistributionListLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(emailDistributionListLanguage.RegionName))
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageRegionName), new[] { "RegionName" });
            }

            if (!string.IsNullOrWhiteSpace(emailDistributionListLanguage.RegionName) && (emailDistributionListLanguage.RegionName.Length < 1 || emailDistributionListLanguage.RegionName.Length > 100))
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.EmailDistributionListLanguageRegionName, "1", "100"), new[] { "RegionName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)emailDistributionListLanguage.TranslationStatus);
            if (emailDistributionListLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (emailDistributionListLanguage.LastUpdateDate_UTC.Year == 1)
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (emailDistributionListLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                emailDistributionListLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailDistributionListLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == emailDistributionListLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                emailDistributionListLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListLanguageLastUpdateContactTVItemID, (emailDistributionListLanguage.LastUpdateContactTVItemID == null ? "" : emailDistributionListLanguage.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailDistributionListLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public EmailDistributionListLanguage GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(int EmailDistributionListLanguageID, GetParam getParam)
        {
            IQueryable<EmailDistributionListLanguage> emailDistributionListLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.EmailDistributionListLanguageID == EmailDistributionListLanguageID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return emailDistributionListLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillEmailDistributionListLanguageWeb(emailDistributionListLanguageQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillEmailDistributionListLanguageReport(emailDistributionListLanguageQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<EmailDistributionListLanguage> GetEmailDistributionListLanguageList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<EmailDistributionListLanguage> emailDistributionListLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            emailDistributionListLanguageQuery  = emailDistributionListLanguageQuery.OrderByDescending(c => c.EmailDistributionListLanguageID);
                        }
                        emailDistributionListLanguageQuery = emailDistributionListLanguageQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return emailDistributionListLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            emailDistributionListLanguageQuery = FillEmailDistributionListLanguageWeb(emailDistributionListLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.EmailDistributionListLanguageID);
                        }
                        emailDistributionListLanguageQuery = FillEmailDistributionListLanguageWeb(emailDistributionListLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return emailDistributionListLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            emailDistributionListLanguageQuery = FillEmailDistributionListLanguageReport(emailDistributionListLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.EmailDistributionListLanguageID);
                        }
                        emailDistributionListLanguageQuery = FillEmailDistributionListLanguageReport(emailDistributionListLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return emailDistributionListLanguageQuery;
                    }
                default:
                    return null;
            }
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
        public IQueryable<EmailDistributionListLanguage> GetRead()
        {
            if (GetParam.OrderAscending)
            {
                return db.EmailDistributionListLanguages.AsNoTracking();
            }
            else
            {
                return db.EmailDistributionListLanguages.AsNoTracking().OrderByDescending(c => c.EmailDistributionListLanguageID);
            }
        }
        public IQueryable<EmailDistributionListLanguage> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.EmailDistributionListLanguages;
            }
            else
            {
                return db.EmailDistributionListLanguages.OrderByDescending(c => c.EmailDistributionListLanguageID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated EmailDistributionListLanguageFillWeb
        private IQueryable<EmailDistributionListLanguage> FillEmailDistributionListLanguageWeb(IQueryable<EmailDistributionListLanguage> emailDistributionListLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            emailDistributionListLanguageQuery = (from c in emailDistributionListLanguageQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new EmailDistributionListLanguage
                    {
                        EmailDistributionListLanguageID = c.EmailDistributionListLanguageID,
                        EmailDistributionListID = c.EmailDistributionListID,
                        Language = c.Language,
                        RegionName = c.RegionName,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        EmailDistributionListLanguageWeb = new EmailDistributionListLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        },
                        EmailDistributionListLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return emailDistributionListLanguageQuery;
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
