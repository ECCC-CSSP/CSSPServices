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
    public partial class AppTaskLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AppTaskLanguage appTaskLanguage = validationContext.ObjectInstance as AppTaskLanguage;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (appTaskLanguage.AppTaskLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageAppTaskLanguageID), new[] { ModelsRes.AppTaskLanguageAppTaskLanguageID });
                }
            }

            //AppTaskID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.LanguageOK(appTaskLanguage.Language);
            if (appTaskLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLanguage), new[] { ModelsRes.AppTaskLanguageLanguage });
            }

            retStr = enums.TranslationStatusOK(appTaskLanguage.TranslationStatus);
            if (appTaskLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageTranslationStatus), new[] { ModelsRes.AppTaskLanguageTranslationStatus });
            }

            if (appTaskLanguage.LastUpdateDate_UTC == null || appTaskLanguage.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLastUpdateDate_UTC), new[] { ModelsRes.AppTaskLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (appTaskLanguage.AppTaskID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLanguageAppTaskID, "1"), new[] { ModelsRes.AppTaskLanguageAppTaskID });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.StatusText) && appTaskLanguage.StatusText.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageStatusText, "250"), new[] { ModelsRes.AppTaskLanguageStatusText });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.ErrorText) && appTaskLanguage.ErrorText.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageErrorText, "250"), new[] { ModelsRes.AppTaskLanguageErrorText });
            }

            if (appTaskLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.AppTaskLanguageLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(AppTaskLanguage appTaskLanguage)
        {
            appTaskLanguage.ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Create);
            if (appTaskLanguage.ValidationResults.Count() > 0) return false;

            db.AppTaskLanguages.Add(appTaskLanguage);

            if (!TryToSave(appTaskLanguage)) return false;

            return true;
        }
        public bool AddRange(List<AppTaskLanguage> appTaskLanguageList)
        {
            foreach (AppTaskLanguage appTaskLanguage in appTaskLanguageList)
            {
                appTaskLanguage.ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Create);
                if (appTaskLanguage.ValidationResults.Count() > 0) return false;
            }

            db.AppTaskLanguages.AddRange(appTaskLanguageList);

            if (!TryToSaveRange(appTaskLanguageList)) return false;

            return true;
        }
        public bool Delete(AppTaskLanguage appTaskLanguage)
        {
            if (!db.AppTaskLanguages.Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
            {
                appTaskLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.AppTaskLanguages.Remove(appTaskLanguage);

            if (!TryToSave(appTaskLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<AppTaskLanguage> appTaskLanguageList)
        {
            foreach (AppTaskLanguage appTaskLanguage in appTaskLanguageList)
            {
                if (!db.AppTaskLanguages.Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
                {
                    appTaskLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.AppTaskLanguages.RemoveRange(appTaskLanguageList);

            if (!TryToSaveRange(appTaskLanguageList)) return false;

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
        public bool UpdateRange(List<AppTaskLanguage> appTaskLanguageList)
        {
            foreach (AppTaskLanguage appTaskLanguage in appTaskLanguageList)
            {
                appTaskLanguage.ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Update);
                if (appTaskLanguage.ValidationResults.Count() > 0) return false;
            }
            db.AppTaskLanguages.UpdateRange(appTaskLanguageList);

            if (!TryToSaveRange(appTaskLanguageList)) return false;

            return true;
        }
        public IQueryable<AppTaskLanguage> GetRead()
        {
            return db.AppTaskLanguages.AsNoTracking();
        }
        public IQueryable<AppTaskLanguage> GetEdit()
        {
            return db.AppTaskLanguages;
        }
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<AppTaskLanguage> appTaskLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                appTaskLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
