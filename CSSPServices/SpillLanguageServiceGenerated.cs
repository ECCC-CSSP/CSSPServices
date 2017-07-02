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
    public partial class SpillLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            SpillLanguage spillLanguage = validationContext.ObjectInstance as SpillLanguage;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (spillLanguage.SpillLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageSpillLanguageID), new[] { ModelsRes.SpillLanguageSpillLanguageID });
                }
            }

            //SpillID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.LanguageOK(spillLanguage.Language);
            if (spillLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageLanguage), new[] { ModelsRes.SpillLanguageLanguage });
            }

            if (string.IsNullOrWhiteSpace(spillLanguage.SpillComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageSpillComment), new[] { ModelsRes.SpillLanguageSpillComment });
            }

            retStr = enums.TranslationStatusOK(spillLanguage.TranslationStatus);
            if (spillLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageTranslationStatus), new[] { ModelsRes.SpillLanguageTranslationStatus });
            }

            if (spillLanguage.LastUpdateDate_UTC == null || spillLanguage.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageLastUpdateDate_UTC), new[] { ModelsRes.SpillLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (spillLanguage.SpillID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillLanguageSpillID, "1"), new[] { ModelsRes.SpillLanguageSpillID });
            }

            // SpillComment has no validation

            if (spillLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.SpillLanguageLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(SpillLanguage spillLanguage)
        {
            spillLanguage.ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Create);
            if (spillLanguage.ValidationResults.Count() > 0) return false;

            db.SpillLanguages.Add(spillLanguage);

            if (!TryToSave(spillLanguage)) return false;

            return true;
        }
        public bool AddRange(List<SpillLanguage> spillLanguageList)
        {
            foreach (SpillLanguage spillLanguage in spillLanguageList)
            {
                spillLanguage.ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Create);
                if (spillLanguage.ValidationResults.Count() > 0) return false;
            }

            db.SpillLanguages.AddRange(spillLanguageList);

            if (!TryToSaveRange(spillLanguageList)) return false;

            return true;
        }
        public bool Delete(SpillLanguage spillLanguage)
        {
            if (!db.SpillLanguages.Where(c => c.SpillLanguageID == spillLanguage.SpillLanguageID).Any())
            {
                spillLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", spillLanguage.SpillLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.SpillLanguages.Remove(spillLanguage);

            if (!TryToSave(spillLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<SpillLanguage> spillLanguageList)
        {
            foreach (SpillLanguage spillLanguage in spillLanguageList)
            {
                if (!db.SpillLanguages.Where(c => c.SpillLanguageID == spillLanguage.SpillLanguageID).Any())
                {
                    spillLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageID", spillLanguage.SpillLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.SpillLanguages.RemoveRange(spillLanguageList);

            if (!TryToSaveRange(spillLanguageList)) return false;

            return true;
        }
        public bool Update(SpillLanguage spillLanguage)
        {
            spillLanguage.ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Update);
            if (spillLanguage.ValidationResults.Count() > 0) return false;

            db.SpillLanguages.Update(spillLanguage);

            if (!TryToSave(spillLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<SpillLanguage> spillLanguageList)
        {
            foreach (SpillLanguage spillLanguage in spillLanguageList)
            {
                spillLanguage.ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Update);
                if (spillLanguage.ValidationResults.Count() > 0) return false;
            }
            db.SpillLanguages.UpdateRange(spillLanguageList);

            if (!TryToSaveRange(spillLanguageList)) return false;

            return true;
        }
        public IQueryable<SpillLanguage> GetRead()
        {
            return db.SpillLanguages.AsNoTracking();
        }
        public IQueryable<SpillLanguage> GetEdit()
        {
            return db.SpillLanguages;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(SpillLanguage spillLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                spillLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<SpillLanguage> spillLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                spillLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
