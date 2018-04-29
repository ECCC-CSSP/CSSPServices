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
        public AppTaskLanguageService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguageAppTaskLanguageID), new[] { "AppTaskLanguageID" });
                }

                if (!GetRead().Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
                {
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AppTaskLanguage, CSSPModelsRes.AppTaskLanguageAppTaskLanguageID, appTaskLanguage.AppTaskLanguageID.ToString()), new[] { "AppTaskLanguageID" });
                }
            }

            AppTask AppTaskAppTaskID = (from c in db.AppTasks where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();

            if (AppTaskAppTaskID == null)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AppTask, CSSPModelsRes.AppTaskLanguageAppTaskID, (appTaskLanguage.AppTaskID == null ? "" : appTaskLanguage.AppTaskID.ToString())), new[] { "AppTaskID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLanguage.Language);
            if (appTaskLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguageLanguage), new[] { "Language" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.StatusText) && appTaskLanguage.StatusText.Length > 250)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskLanguageStatusText, "250"), new[] { "StatusText" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.ErrorText) && appTaskLanguage.ErrorText.Length > 250)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppTaskLanguageErrorText, "250"), new[] { "ErrorText" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLanguage.TranslationStatus);
            if (appTaskLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (appTaskLanguage.LastUpdateDate_UTC.Year == 1)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appTaskLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppTaskLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppTaskLanguageLastUpdateContactTVItemID, (appTaskLanguage.LastUpdateContactTVItemID == null ? "" : appTaskLanguage.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public AppTaskLanguage GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID, GetParam getParam)
        {
            IQueryable<AppTaskLanguage> appTaskLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.AppTaskLanguageID == AppTaskLanguageID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return appTaskLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillAppTaskLanguageWeb(appTaskLanguageQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillAppTaskLanguageReport(appTaskLanguageQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<AppTaskLanguage> GetAppTaskLanguageList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<AppTaskLanguage> appTaskLanguageQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            appTaskLanguageQuery  = appTaskLanguageQuery.OrderByDescending(c => c.AppTaskLanguageID);
                        }
                        appTaskLanguageQuery = appTaskLanguageQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return appTaskLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            appTaskLanguageQuery = FillAppTaskLanguageWeb(appTaskLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.AppTaskLanguageID);
                        }
                        appTaskLanguageQuery = FillAppTaskLanguageWeb(appTaskLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return appTaskLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            appTaskLanguageQuery = FillAppTaskLanguageReport(appTaskLanguageQuery, FilterAndOrderText).OrderByDescending(c => c.AppTaskLanguageID);
                        }
                        appTaskLanguageQuery = FillAppTaskLanguageReport(appTaskLanguageQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return appTaskLanguageQuery;
                    }
                default:
                    return null;
            }
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
            if (GetParam.OrderAscending)
            {
                return db.AppTaskLanguages.AsNoTracking();
            }
            else
            {
                return db.AppTaskLanguages.AsNoTracking().OrderByDescending(c => c.AppTaskLanguageID);
            }
        }
        public IQueryable<AppTaskLanguage> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.AppTaskLanguages;
            }
            else
            {
                return db.AppTaskLanguages.OrderByDescending(c => c.AppTaskLanguageID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated AppTaskLanguageFillWeb
        private IQueryable<AppTaskLanguage> FillAppTaskLanguageWeb(IQueryable<AppTaskLanguage> appTaskLanguageQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            appTaskLanguageQuery = (from c in appTaskLanguageQuery
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
                        AppTaskLanguageWeb = new AppTaskLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        },
                        AppTaskLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return appTaskLanguageQuery;
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
