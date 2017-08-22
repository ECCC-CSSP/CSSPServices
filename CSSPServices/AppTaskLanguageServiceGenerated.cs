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
            appTaskLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appTaskLanguage.AppTaskLanguageID == 0)
                {
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageAppTaskLanguageID), new[] { "AppTaskLanguageID" });
                }

                if (!GetRead().Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
                {
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.AppTaskLanguage, ModelsRes.AppTaskLanguageAppTaskLanguageID, appTaskLanguage.AppTaskLanguageID.ToString()), new[] { "AppTaskLanguageID" });
                }
            }

            //AppTaskLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //AppTaskID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            AppTask AppTaskAppTaskID = (from c in db.AppTasks where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();

            if (AppTaskAppTaskID == null)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.AppTask, ModelsRes.AppTaskLanguageAppTaskID, appTaskLanguage.AppTaskID.ToString()), new[] { "AppTaskID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLanguage.Language);
            if (appTaskLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLanguage), new[] { "Language" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.StatusText) && appTaskLanguage.StatusText.Length > 250)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageStatusText, "250"), new[] { "StatusText" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.ErrorText) && appTaskLanguage.ErrorText.Length > 250)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageErrorText, "250"), new[] { "ErrorText" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLanguage.TranslationStatus);
            if (appTaskLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (appTaskLanguage.LastUpdateDate_UTC.Year == 1)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appTaskLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AppTaskLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                appTaskLanguage.HasErrors = true;
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
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppTaskLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.LastUpdateContactTVText) && appTaskLanguage.LastUpdateContactTVText.Length > 200)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.LanguageText) && appTaskLanguage.LanguageText.Length > 100)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.TranslationStatusText) && appTaskLanguage.TranslationStatusText.Length > 100)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            //HasErrors (bool) is required but no testing needed 

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
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
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
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (AppTaskLanguage appTaskLanguage in AppTaskLanguageList)
            {
                appTaskLanguage.LanguageText = enums.GetResValueForTypeAndID(typeof(LanguageEnum), (int?)appTaskLanguage.Language);
                appTaskLanguage.TranslationStatusText = enums.GetResValueForTypeAndID(typeof(TranslationStatusEnum), (int?)appTaskLanguage.TranslationStatus);
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
        #endregion Functions private Generated

    }
}
