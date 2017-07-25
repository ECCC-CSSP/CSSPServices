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
    public partial class TVItemLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemLanguage tvItemLanguage = validationContext.ObjectInstance as TVItemLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvItemLanguage.TVItemLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVItemLanguageID), new[] { ModelsRes.TVItemLanguageTVItemLanguageID });
                }
            }

            //TVItemLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemLanguage.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLanguageTVItemID, "1"), new[] { ModelsRes.TVItemLanguageTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvItemLanguage.TVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLanguageTVItemID, tvItemLanguage.TVItemID.ToString()), new[] { ModelsRes.TVItemLanguageTVItemID });
            }

            retStr = enums.LanguageOK(tvItemLanguage.Language);
            if (tvItemLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageLanguage), new[] { ModelsRes.TVItemLanguageLanguage });
            }

            if (string.IsNullOrWhiteSpace(tvItemLanguage.TVText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVText), new[] { ModelsRes.TVItemLanguageTVText });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLanguage.TVText) && tvItemLanguage.TVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageTVText, "200"), new[] { ModelsRes.TVItemLanguageTVText });
            }

            retStr = enums.TranslationStatusOK(tvItemLanguage.TranslationStatus);
            if (tvItemLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTranslationStatus), new[] { ModelsRes.TVItemLanguageTranslationStatus });
            }

            if (tvItemLanguage.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageLastUpdateDate_UTC), new[] { ModelsRes.TVItemLanguageLastUpdateDate_UTC });
            }

            if (tvItemLanguage.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLanguageLastUpdateDate_UTC, "1980"), new[] { ModelsRes.TVItemLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TVItemLanguageLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvItemLanguage.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, tvItemLanguage.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.TVItemLanguageLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(TVItemLanguage tvItemLanguage)
        {
            tvItemLanguage.ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Create);
            if (tvItemLanguage.ValidationResults.Count() > 0) return false;

            db.TVItemLanguages.Add(tvItemLanguage);

            if (!TryToSave(tvItemLanguage)) return false;

            return true;
        }
        public bool AddRange(List<TVItemLanguage> tvItemLanguageList)
        {
            foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                tvItemLanguage.ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Create);
                if (tvItemLanguage.ValidationResults.Count() > 0) return false;
            }

            db.TVItemLanguages.AddRange(tvItemLanguageList);

            if (!TryToSaveRange(tvItemLanguageList)) return false;

            return true;
        }
        public bool Delete(TVItemLanguage tvItemLanguage)
        {
            if (!db.TVItemLanguages.Where(c => c.TVItemLanguageID == tvItemLanguage.TVItemLanguageID).Any())
            {
                tvItemLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageID", tvItemLanguage.TVItemLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVItemLanguages.Remove(tvItemLanguage);

            if (!TryToSave(tvItemLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<TVItemLanguage> tvItemLanguageList)
        {
            foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                if (!db.TVItemLanguages.Where(c => c.TVItemLanguageID == tvItemLanguage.TVItemLanguageID).Any())
                {
                    tvItemLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageID", tvItemLanguage.TVItemLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVItemLanguages.RemoveRange(tvItemLanguageList);

            if (!TryToSaveRange(tvItemLanguageList)) return false;

            return true;
        }
        public bool Update(TVItemLanguage tvItemLanguage)
        {
            tvItemLanguage.ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Update);
            if (tvItemLanguage.ValidationResults.Count() > 0) return false;

            db.TVItemLanguages.Update(tvItemLanguage);

            if (!TryToSave(tvItemLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<TVItemLanguage> tvItemLanguageList)
        {
            foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                tvItemLanguage.ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Update);
                if (tvItemLanguage.ValidationResults.Count() > 0) return false;
            }
            db.TVItemLanguages.UpdateRange(tvItemLanguageList);

            if (!TryToSaveRange(tvItemLanguageList)) return false;

            return true;
        }
        public IQueryable<TVItemLanguage> GetRead()
        {
            return db.TVItemLanguages.AsNoTracking();
        }
        public IQueryable<TVItemLanguage> GetEdit()
        {
            return db.TVItemLanguages;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TVItemLanguage tvItemLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVItemLanguage> tvItemLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
