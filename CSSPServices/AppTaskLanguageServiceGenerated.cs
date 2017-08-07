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
        #endregion Properties

        #region Constructors
        public AppTaskLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AppTaskLanguage appTaskLanguage = validationContext.ObjectInstance as AppTaskLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (appTaskLanguage.AppTaskLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageAppTaskLanguageID), new[] { "AppTaskLanguageID" });
                }
            }

            //AppTaskLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //AppTaskID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            AppTask AppTaskAppTaskID = (from c in db.AppTasks where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();

            if (AppTaskAppTaskID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.AppTask, ModelsRes.AppTaskLanguageAppTaskID, appTaskLanguage.AppTaskID.ToString()), new[] { "AppTaskID" });
            }

            retStr = enums.LanguageOK(appTaskLanguage.Language);
            if (appTaskLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLanguage), new[] { "Language" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.StatusText) && appTaskLanguage.StatusText.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageStatusText, "250"), new[] { "StatusText" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.ErrorText) && appTaskLanguage.ErrorText.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageErrorText, "250"), new[] { "ErrorText" });
            }

            retStr = enums.TranslationStatusOK(appTaskLanguage.TranslationStatus);
            if (appTaskLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (appTaskLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appTaskLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AppTaskLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskLanguageLastUpdateContactTVItemID, appTaskLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppTaskLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.LanguageText) && appTaskLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.TranslationStatusText) && appTaskLanguage.TranslationStatusText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public AppTaskLanguage GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            IQueryable<AppTaskLanguage> appTaskLanguageQuery = (from c in GetRead()
                                                where c.AppTaskLanguageID == AppTaskLanguageID
                                                select c);

            return FillAppTaskLanguage(appTaskLanguageQuery).FirstOrDefault();
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<AppTaskLanguage> FillAppTaskLanguage(IQueryable<AppTaskLanguage> appTaskLanguageQuery)
        {
            List<AppTaskLanguage> AppTaskLanguageList = (from c in appTaskLanguageQuery
                                         select new AppTaskLanguage
                                         {
                                             AppTaskLanguageID = c.AppTaskLanguageID,
                                             AppTaskID = c.AppTaskID,
                                             Language = c.Language,
                                             StatusText = c.StatusText,
                                             ErrorText = c.ErrorText,
                                             TranslationStatus = c.TranslationStatus,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (AppTaskLanguage appTaskLanguage in AppTaskLanguageList)
            {
                appTaskLanguage.LanguageText = enums.GetEnumText_LanguageEnum(appTaskLanguage.Language);
                appTaskLanguage.TranslationStatusText = enums.GetEnumText_TranslationStatusEnum(appTaskLanguage.TranslationStatus);
            }

            return AppTaskLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
