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
    public partial class TVFileLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
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
            TVFileLanguage tvFileLanguage = validationContext.ObjectInstance as TVFileLanguage;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvFileLanguage.TVFileLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageTVFileLanguageID), new[] { ModelsRes.TVFileLanguageTVFileLanguageID });
                }
            }

            //TVFileID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.LanguageOK(tvFileLanguage.Language);
            if (tvFileLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageLanguage), new[] { ModelsRes.TVFileLanguageLanguage });
            }

            retStr = enums.TranslationStatusOK(tvFileLanguage.TranslationStatus);
            if (tvFileLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageTranslationStatus), new[] { ModelsRes.TVFileLanguageTranslationStatus });
            }

            if (tvFileLanguage.LastUpdateDate_UTC == null || tvFileLanguage.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageLastUpdateDate_UTC), new[] { ModelsRes.TVFileLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (tvFileLanguage.TVFileID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileLanguageTVFileID, "1"), new[] { ModelsRes.TVFileLanguageTVFileID });
            }

            // FileDescription has no validation

            if (tvFileLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TVFileLanguageLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(TVFileLanguage tvFileLanguage)
        {
            tvFileLanguage.ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Create);
            if (tvFileLanguage.ValidationResults.Count() > 0) return false;

            db.TVFileLanguages.Add(tvFileLanguage);

            if (!TryToSave(tvFileLanguage)) return false;

            return true;
        }
        public bool AddRange(List<TVFileLanguage> tvFileLanguageList)
        {
            foreach (TVFileLanguage tvFileLanguage in tvFileLanguageList)
            {
                tvFileLanguage.ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Create);
                if (tvFileLanguage.ValidationResults.Count() > 0) return false;
            }

            db.TVFileLanguages.AddRange(tvFileLanguageList);

            if (!TryToSaveRange(tvFileLanguageList)) return false;

            return true;
        }
        public bool Delete(TVFileLanguage tvFileLanguage)
        {
            if (!db.TVFileLanguages.Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
            {
                tvFileLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVFileLanguages.Remove(tvFileLanguage);

            if (!TryToSave(tvFileLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<TVFileLanguage> tvFileLanguageList)
        {
            foreach (TVFileLanguage tvFileLanguage in tvFileLanguageList)
            {
                if (!db.TVFileLanguages.Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
                {
                    tvFileLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVFileLanguages.RemoveRange(tvFileLanguageList);

            if (!TryToSaveRange(tvFileLanguageList)) return false;

            return true;
        }
        public bool Update(TVFileLanguage tvFileLanguage)
        {
            tvFileLanguage.ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Update);
            if (tvFileLanguage.ValidationResults.Count() > 0) return false;

            db.TVFileLanguages.Update(tvFileLanguage);

            if (!TryToSave(tvFileLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<TVFileLanguage> tvFileLanguageList)
        {
            foreach (TVFileLanguage tvFileLanguage in tvFileLanguageList)
            {
                tvFileLanguage.ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Update);
                if (tvFileLanguage.ValidationResults.Count() > 0) return false;
            }
            db.TVFileLanguages.UpdateRange(tvFileLanguageList);

            if (!TryToSaveRange(tvFileLanguageList)) return false;

            return true;
        }
        public IQueryable<TVFileLanguage> GetRead()
        {
            return db.TVFileLanguages.AsNoTracking();
        }
        public IQueryable<TVFileLanguage> GetEdit()
        {
            return db.TVFileLanguages;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TVFileLanguage tvFileLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvFileLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVFileLanguage> tvFileLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvFileLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
