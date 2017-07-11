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
    public partial class MWQMSubsectorLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            MWQMSubsectorLanguage mwqmSubsectorLanguage = validationContext.ObjectInstance as MWQMSubsectorLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmSubsectorLanguage.MWQMSubsectorLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageMWQMSubsectorLanguageID), new[] { ModelsRes.MWQMSubsectorLanguageMWQMSubsectorLanguageID });
                }
            }

            //MWQMSubsectorLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSubsectorID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmSubsectorLanguage.MWQMSubsectorID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorLanguageMWQMSubsectorID, "1"), new[] { ModelsRes.MWQMSubsectorLanguageMWQMSubsectorID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmSubsectorLanguage.MWQMSubsectorID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorLanguageMWQMSubsectorID, mwqmSubsectorLanguage.MWQMSubsectorID.ToString()), new[] { ModelsRes.MWQMSubsectorLanguageMWQMSubsectorID });
            }

            retStr = enums.LanguageOK(mwqmSubsectorLanguage.Language);
            if (mwqmSubsectorLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageLanguage), new[] { ModelsRes.MWQMSubsectorLanguageLanguage });
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageSubsectorDesc), new[] { ModelsRes.MWQMSubsectorLanguageSubsectorDesc });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguage.SubsectorDesc) && mwqmSubsectorLanguage.SubsectorDesc.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorLanguageSubsectorDesc, "250"), new[] { ModelsRes.MWQMSubsectorLanguageSubsectorDesc });
            }

            retStr = enums.TranslationStatusOK(mwqmSubsectorLanguage.TranslationStatus);
            if (mwqmSubsectorLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageTranslationStatus), new[] { ModelsRes.MWQMSubsectorLanguageTranslationStatus });
            }

            if (mwqmSubsectorLanguage.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC), new[] { ModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC });
            }

            if (mwqmSubsectorLanguage.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MWQMSubsectorLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmSubsectorLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmSubsectorLanguage.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID, mwqmSubsectorLanguage.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MWQMSubsectorLanguageLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            mwqmSubsectorLanguage.ValidationResults = Validate(new ValidationContext(mwqmSubsectorLanguage), ActionDBTypeEnum.Create);
            if (mwqmSubsectorLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectorLanguages.Add(mwqmSubsectorLanguage);

            if (!TryToSave(mwqmSubsectorLanguage)) return false;

            return true;
        }
        public bool AddRange(List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList)
        {
            foreach (MWQMSubsectorLanguage mwqmSubsectorLanguage in mwqmSubsectorLanguageList)
            {
                mwqmSubsectorLanguage.ValidationResults = Validate(new ValidationContext(mwqmSubsectorLanguage), ActionDBTypeEnum.Create);
                if (mwqmSubsectorLanguage.ValidationResults.Count() > 0) return false;
            }

            db.MWQMSubsectorLanguages.AddRange(mwqmSubsectorLanguageList);

            if (!TryToSaveRange(mwqmSubsectorLanguageList)) return false;

            return true;
        }
        public bool Delete(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            if (!db.MWQMSubsectorLanguages.Where(c => c.MWQMSubsectorLanguageID == mwqmSubsectorLanguage.MWQMSubsectorLanguageID).Any())
            {
                mwqmSubsectorLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageID", mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMSubsectorLanguages.Remove(mwqmSubsectorLanguage);

            if (!TryToSave(mwqmSubsectorLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList)
        {
            foreach (MWQMSubsectorLanguage mwqmSubsectorLanguage in mwqmSubsectorLanguageList)
            {
                if (!db.MWQMSubsectorLanguages.Where(c => c.MWQMSubsectorLanguageID == mwqmSubsectorLanguage.MWQMSubsectorLanguageID).Any())
                {
                    mwqmSubsectorLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSubsectorLanguage", "MWQMSubsectorLanguageID", mwqmSubsectorLanguage.MWQMSubsectorLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMSubsectorLanguages.RemoveRange(mwqmSubsectorLanguageList);

            if (!TryToSaveRange(mwqmSubsectorLanguageList)) return false;

            return true;
        }
        public bool Update(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            mwqmSubsectorLanguage.ValidationResults = Validate(new ValidationContext(mwqmSubsectorLanguage), ActionDBTypeEnum.Update);
            if (mwqmSubsectorLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectorLanguages.Update(mwqmSubsectorLanguage);

            if (!TryToSave(mwqmSubsectorLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList)
        {
            foreach (MWQMSubsectorLanguage mwqmSubsectorLanguage in mwqmSubsectorLanguageList)
            {
                mwqmSubsectorLanguage.ValidationResults = Validate(new ValidationContext(mwqmSubsectorLanguage), ActionDBTypeEnum.Update);
                if (mwqmSubsectorLanguage.ValidationResults.Count() > 0) return false;
            }
            db.MWQMSubsectorLanguages.UpdateRange(mwqmSubsectorLanguageList);

            if (!TryToSaveRange(mwqmSubsectorLanguageList)) return false;

            return true;
        }
        public IQueryable<MWQMSubsectorLanguage> GetRead()
        {
            return db.MWQMSubsectorLanguages.AsNoTracking();
        }
        public IQueryable<MWQMSubsectorLanguage> GetEdit()
        {
            return db.MWQMSubsectorLanguages;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(MWQMSubsectorLanguage mwqmSubsectorLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSubsectorLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSubsectorLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
