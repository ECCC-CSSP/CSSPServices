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
        public TVFileLanguageService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvFileLanguage.TVFileLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageTVFileLanguageID), new[] { ModelsRes.TVFileLanguageTVFileLanguageID });
                }
            }

            //TVFileLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVFileID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvFileLanguage.TVFileID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileLanguageTVFileID, "1"), new[] { ModelsRes.TVFileLanguageTVFileID });
            }

            if (!((from c in db.TVFiles where c.TVFileID == tvFileLanguage.TVFileID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVFile, ModelsRes.TVFileLanguageTVFileID, tvFileLanguage.TVFileID.ToString()), new[] { ModelsRes.TVFileLanguageTVFileID });
            }

            retStr = enums.LanguageOK(tvFileLanguage.Language);
            if (tvFileLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageLanguage), new[] { ModelsRes.TVFileLanguageLanguage });
            }

            if (string.IsNullOrWhiteSpace(tvFileLanguage.FileDescription))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageFileDescription), new[] { ModelsRes.TVFileLanguageFileDescription });
            }

            //FileDescription has no StringLength Attribute

            retStr = enums.TranslationStatusOK(tvFileLanguage.TranslationStatus);
            if (tvFileLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageTranslationStatus), new[] { ModelsRes.TVFileLanguageTranslationStatus });
            }

            if (tvFileLanguage.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguageLastUpdateDate_UTC), new[] { ModelsRes.TVFileLanguageLastUpdateDate_UTC });
            }

            if (tvFileLanguage.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVFileLanguageLastUpdateDate_UTC, "1980"), new[] { ModelsRes.TVFileLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvFileLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TVFileLanguageLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvFileLanguage.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVFileLanguageLastUpdateContactTVItemID, tvFileLanguage.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.TVFileLanguageLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
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
