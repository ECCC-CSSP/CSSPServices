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
    ///     <para>bonjour AppTaskLanguage</para>
    /// </summary>
    public partial class AppTaskLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskLanguageService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AppTaskLanguage appTaskLanguage = validationContext.ObjectInstance as AppTaskLanguage;
            appTaskLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appTaskLanguage.AppTaskLanguageID == 0)
                {
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageAppTaskLanguageID"), new[] { "AppTaskLanguageID" });
                }

                if (!(from c in db.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
                {
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageAppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString()), new[] { "AppTaskLanguageID" });
                }
            }

            AppTask AppTaskAppTaskID = (from c in db.AppTasks where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();

            if (AppTaskAppTaskID == null)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskLanguageAppTaskID", appTaskLanguage.AppTaskID.ToString()), new[] { "AppTaskID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLanguage.Language);
            if (appTaskLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageLanguage"), new[] { "Language" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.StatusText) && appTaskLanguage.StatusText.Length > 250)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "AppTaskLanguageStatusText", "250"), new[] { "StatusText" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.ErrorText) && appTaskLanguage.ErrorText.Length > 250)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "AppTaskLanguageErrorText", "250"), new[] { "ErrorText" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLanguage.TranslationStatus);
            if (appTaskLanguage.TranslationStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageTranslationStatus"), new[] { "TranslationStatus" });
            }

            if (appTaskLanguage.LastUpdateDate_UTC.Year == 1)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appTaskLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppTaskLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppTaskLanguageLastUpdateContactTVItemID", appTaskLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AppTaskLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public AppTaskLanguage GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            return (from c in db.AppTaskLanguages
                    where c.AppTaskLanguageID == AppTaskLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<AppTaskLanguage> GetAppTaskLanguageList()
        {
            IQueryable<AppTaskLanguage> AppTaskLanguageQuery = (from c in db.AppTaskLanguages select c);

            AppTaskLanguageQuery = EnhanceQueryStatements<AppTaskLanguage>(AppTaskLanguageQuery) as IQueryable<AppTaskLanguage>;

            return AppTaskLanguageQuery;
        }
        public AppTaskLanguageWeb GetAppTaskLanguageWebWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            return FillAppTaskLanguageWeb().Where(c => c.AppTaskLanguageID == AppTaskLanguageID).FirstOrDefault();

        }
        public IQueryable<AppTaskLanguageWeb> GetAppTaskLanguageWebList()
        {
            IQueryable<AppTaskLanguageWeb> AppTaskLanguageWebQuery = FillAppTaskLanguageWeb();

            AppTaskLanguageWebQuery = EnhanceQueryStatements<AppTaskLanguageWeb>(AppTaskLanguageWebQuery) as IQueryable<AppTaskLanguageWeb>;

            return AppTaskLanguageWebQuery;
        }
        public AppTaskLanguageReport GetAppTaskLanguageReportWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            return FillAppTaskLanguageReport().Where(c => c.AppTaskLanguageID == AppTaskLanguageID).FirstOrDefault();

        }
        public IQueryable<AppTaskLanguageReport> GetAppTaskLanguageReportList()
        {
            IQueryable<AppTaskLanguageReport> AppTaskLanguageReportQuery = FillAppTaskLanguageReport();

            AppTaskLanguageReportQuery = EnhanceQueryStatements<AppTaskLanguageReport>(AppTaskLanguageReportQuery) as IQueryable<AppTaskLanguageReport>;

            return AppTaskLanguageReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(AppTaskLanguage appTaskLanguage)
        {
            appTaskLanguage.ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Create);
            if (appTaskLanguage.ValidationResults.Count() > 0) return false;

            db.AppTaskLanguages.Add(appTaskLanguage);

            if (!TryToSave(appTaskLanguage)) return false;

            return true;
        }
        public bool Delete(AppTaskLanguage appTaskLanguage)
        {
            appTaskLanguage.ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Delete);
            if (appTaskLanguage.ValidationResults.Count() > 0) return false;

            db.AppTaskLanguages.Remove(appTaskLanguage);

            if (!TryToSave(appTaskLanguage)) return false;

            return true;
        }
        public bool Update(AppTaskLanguage appTaskLanguage)
        {
            appTaskLanguage.ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Update);
            if (appTaskLanguage.ValidationResults.Count() > 0) return false;

            db.AppTaskLanguages.Update(appTaskLanguage);

            if (!TryToSave(appTaskLanguage)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated AppTaskLanguageFillWeb
        private IQueryable<AppTaskLanguageWeb> FillAppTaskLanguageWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<AppTaskLanguageWeb> AppTaskLanguageWebQuery = (from c in db.AppTaskLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new AppTaskLanguageWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        AppTaskLanguageID = c.AppTaskLanguageID,
                        AppTaskID = c.AppTaskID,
                        Language = c.Language,
                        StatusText = c.StatusText,
                        ErrorText = c.ErrorText,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return AppTaskLanguageWebQuery;
        }
        #endregion Functions private Generated AppTaskLanguageFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(AppTaskLanguage appTaskLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                appTaskLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
