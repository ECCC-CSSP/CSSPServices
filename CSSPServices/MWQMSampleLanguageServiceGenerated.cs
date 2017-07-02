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
    public partial class MWQMSampleLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            MWQMSampleLanguage mwqmSampleLanguage = validationContext.ObjectInstance as MWQMSampleLanguage;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmSampleLanguage.MWQMSampleLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageMWQMSampleLanguageID), new[] { ModelsRes.MWQMSampleLanguageMWQMSampleLanguageID });
                }
            }

            //MWQMSampleID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.LanguageOK(mwqmSampleLanguage.Language);
            if (mwqmSampleLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageLanguage), new[] { ModelsRes.MWQMSampleLanguageLanguage });
            }

            if (string.IsNullOrWhiteSpace(mwqmSampleLanguage.MWQMSampleNote))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageMWQMSampleNote), new[] { ModelsRes.MWQMSampleLanguageMWQMSampleNote });
            }

            retStr = enums.TranslationStatusOK(mwqmSampleLanguage.TranslationStatus);
            if (mwqmSampleLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageTranslationStatus), new[] { ModelsRes.MWQMSampleLanguageTranslationStatus });
            }

            if (mwqmSampleLanguage.LastUpdateDate_UTC == null || mwqmSampleLanguage.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLanguageLastUpdateDate_UTC), new[] { ModelsRes.MWQMSampleLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (mwqmSampleLanguage.MWQMSampleID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleLanguageMWQMSampleID, "1"), new[] { ModelsRes.MWQMSampleLanguageMWQMSampleID });
            }

            // MWQMSampleNote has no validation

            if (mwqmSampleLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMSampleLanguageLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(MWQMSampleLanguage mwqmSampleLanguage)
        {
            mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Create);
            if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSampleLanguages.Add(mwqmSampleLanguage);

            if (!TryToSave(mwqmSampleLanguage)) return false;

            return true;
        }
        public bool AddRange(List<MWQMSampleLanguage> mwqmSampleLanguageList)
        {
            foreach (MWQMSampleLanguage mwqmSampleLanguage in mwqmSampleLanguageList)
            {
                mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Create);
                if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;
            }

            db.MWQMSampleLanguages.AddRange(mwqmSampleLanguageList);

            if (!TryToSaveRange(mwqmSampleLanguageList)) return false;

            return true;
        }
        public bool Delete(MWQMSampleLanguage mwqmSampleLanguage)
        {
            if (!db.MWQMSampleLanguages.Where(c => c.MWQMSampleLanguageID == mwqmSampleLanguage.MWQMSampleLanguageID).Any())
            {
                mwqmSampleLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSampleLanguage", "MWQMSampleLanguageID", mwqmSampleLanguage.MWQMSampleLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMSampleLanguages.Remove(mwqmSampleLanguage);

            if (!TryToSave(mwqmSampleLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<MWQMSampleLanguage> mwqmSampleLanguageList)
        {
            foreach (MWQMSampleLanguage mwqmSampleLanguage in mwqmSampleLanguageList)
            {
                if (!db.MWQMSampleLanguages.Where(c => c.MWQMSampleLanguageID == mwqmSampleLanguage.MWQMSampleLanguageID).Any())
                {
                    mwqmSampleLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSampleLanguage", "MWQMSampleLanguageID", mwqmSampleLanguage.MWQMSampleLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMSampleLanguages.RemoveRange(mwqmSampleLanguageList);

            if (!TryToSaveRange(mwqmSampleLanguageList)) return false;

            return true;
        }
        public bool Update(MWQMSampleLanguage mwqmSampleLanguage)
        {
            mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Update);
            if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSampleLanguages.Update(mwqmSampleLanguage);

            if (!TryToSave(mwqmSampleLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<MWQMSampleLanguage> mwqmSampleLanguageList)
        {
            foreach (MWQMSampleLanguage mwqmSampleLanguage in mwqmSampleLanguageList)
            {
                mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Update);
                if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;
            }
            db.MWQMSampleLanguages.UpdateRange(mwqmSampleLanguageList);

            if (!TryToSaveRange(mwqmSampleLanguageList)) return false;

            return true;
        }
        public IQueryable<MWQMSampleLanguage> GetRead()
        {
            return db.MWQMSampleLanguages.AsNoTracking();
        }
        public IQueryable<MWQMSampleLanguage> GetEdit()
        {
            return db.MWQMSampleLanguages;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(MWQMSampleLanguage mwqmSampleLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSampleLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MWQMSampleLanguage> mwqmSampleLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSampleLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
