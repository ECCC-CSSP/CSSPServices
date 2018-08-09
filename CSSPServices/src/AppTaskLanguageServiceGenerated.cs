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
        public AppTaskLanguage_A GetAppTaskLanguage_AWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            return FillAppTaskLanguage_A().Where(c => c.AppTaskLanguageID == AppTaskLanguageID).FirstOrDefault();

        }
        public IQueryable<AppTaskLanguage_A> GetAppTaskLanguage_AList()
        {
            IQueryable<AppTaskLanguage_A> AppTaskLanguage_AQuery = FillAppTaskLanguage_A();

            AppTaskLanguage_AQuery = EnhanceQueryStatements<AppTaskLanguage_A>(AppTaskLanguage_AQuery) as IQueryable<AppTaskLanguage_A>;

            return AppTaskLanguage_AQuery;
        }
        public AppTaskLanguage_B GetAppTaskLanguage_BWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            return FillAppTaskLanguage_B().Where(c => c.AppTaskLanguageID == AppTaskLanguageID).FirstOrDefault();

        }
        public IQueryable<AppTaskLanguage_B> GetAppTaskLanguage_BList()
        {
            IQueryable<AppTaskLanguage_B> AppTaskLanguage_BQuery = FillAppTaskLanguage_B();

            AppTaskLanguage_BQuery = EnhanceQueryStatements<AppTaskLanguage_B>(AppTaskLanguage_BQuery) as IQueryable<AppTaskLanguage_B>;

            return AppTaskLanguage_BQuery;
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
