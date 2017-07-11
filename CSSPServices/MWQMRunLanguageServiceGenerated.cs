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
    public partial class MWQMRunLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            MWQMRunLanguage mwqmRunLanguage = validationContext.ObjectInstance as MWQMRunLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmRunLanguage.MWQMRunLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageMWQMRunLanguageID), new[] { ModelsRes.MWQMRunLanguageMWQMRunLanguageID });
                }
            }

            //MWQMRunLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMRunID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmRunLanguage.MWQMRunID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLanguageMWQMRunID, "1"), new[] { ModelsRes.MWQMRunLanguageMWQMRunID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmRunLanguage.MWQMRunID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLanguageMWQMRunID, mwqmRunLanguage.MWQMRunID.ToString()), new[] { ModelsRes.MWQMRunLanguageMWQMRunID });
            }

            retStr = enums.LanguageOK(mwqmRunLanguage.Language);
            if (mwqmRunLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageLanguage), new[] { ModelsRes.MWQMRunLanguageLanguage });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageRunComment), new[] { ModelsRes.MWQMRunLanguageRunComment });
            }

            //RunComment has no StringLength Attribute

            retStr = enums.TranslationStatusOK(mwqmRunLanguage.TranslationStatusRunComment);
            if (mwqmRunLanguage.TranslationStatusRunComment == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageTranslationStatusRunComment), new[] { ModelsRes.MWQMRunLanguageTranslationStatusRunComment });
            }

            if (string.IsNullOrWhiteSpace(mwqmRunLanguage.RunWeatherComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageRunWeatherComment), new[] { ModelsRes.MWQMRunLanguageRunWeatherComment });
            }

            //RunWeatherComment has no StringLength Attribute

            retStr = enums.TranslationStatusOK(mwqmRunLanguage.TranslationStatusRunWeatherComment);
            if (mwqmRunLanguage.TranslationStatusRunWeatherComment == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageTranslationStatusRunWeatherComment), new[] { ModelsRes.MWQMRunLanguageTranslationStatusRunWeatherComment });
            }

            if (mwqmRunLanguage.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLanguageLastUpdateDate_UTC), new[] { ModelsRes.MWQMRunLanguageLastUpdateDate_UTC });
            }

            if (mwqmRunLanguage.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunLanguageLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MWQMRunLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmRunLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmRunLanguage.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID, mwqmRunLanguage.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MWQMRunLanguageLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(MWQMRunLanguage mwqmRunLanguage)
        {
            mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Create);
            if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMRunLanguages.Add(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

            return true;
        }
        public bool AddRange(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            foreach (MWQMRunLanguage mwqmRunLanguage in mwqmRunLanguageList)
            {
                mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Create);
                if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;
            }

            db.MWQMRunLanguages.AddRange(mwqmRunLanguageList);

            if (!TryToSaveRange(mwqmRunLanguageList)) return false;

            return true;
        }
        public bool Delete(MWQMRunLanguage mwqmRunLanguage)
        {
            if (!db.MWQMRunLanguages.Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
            {
                mwqmRunLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMRunLanguages.Remove(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            foreach (MWQMRunLanguage mwqmRunLanguage in mwqmRunLanguageList)
            {
                if (!db.MWQMRunLanguages.Where(c => c.MWQMRunLanguageID == mwqmRunLanguage.MWQMRunLanguageID).Any())
                {
                    mwqmRunLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMRunLanguage", "MWQMRunLanguageID", mwqmRunLanguage.MWQMRunLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMRunLanguages.RemoveRange(mwqmRunLanguageList);

            if (!TryToSaveRange(mwqmRunLanguageList)) return false;

            return true;
        }
        public bool Update(MWQMRunLanguage mwqmRunLanguage)
        {
            mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Update);
            if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMRunLanguages.Update(mwqmRunLanguage);

            if (!TryToSave(mwqmRunLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            foreach (MWQMRunLanguage mwqmRunLanguage in mwqmRunLanguageList)
            {
                mwqmRunLanguage.ValidationResults = Validate(new ValidationContext(mwqmRunLanguage), ActionDBTypeEnum.Update);
                if (mwqmRunLanguage.ValidationResults.Count() > 0) return false;
            }
            db.MWQMRunLanguages.UpdateRange(mwqmRunLanguageList);

            if (!TryToSaveRange(mwqmRunLanguageList)) return false;

            return true;
        }
        public IQueryable<MWQMRunLanguage> GetRead()
        {
            return db.MWQMRunLanguages.AsNoTracking();
        }
        public IQueryable<MWQMRunLanguage> GetEdit()
        {
            return db.MWQMRunLanguages;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(MWQMRunLanguage mwqmRunLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmRunLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MWQMRunLanguage> mwqmRunLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmRunLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
