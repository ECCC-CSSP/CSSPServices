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
        #endregion Properties

        #region Constructors
        public SpillLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SpillLanguage spillLanguage = validationContext.ObjectInstance as SpillLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (spillLanguage.SpillLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageSpillLanguageID), new[] { ModelsRes.SpillLanguageSpillLanguageID });
                }
            }

            //SpillLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SpillID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (spillLanguage.SpillID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillLanguageSpillID, "1"), new[] { ModelsRes.SpillLanguageSpillID });
            }

            if (!((from c in db.Spills where c.SpillID == spillLanguage.SpillID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Spill, ModelsRes.SpillLanguageSpillID, spillLanguage.SpillID.ToString()), new[] { ModelsRes.SpillLanguageSpillID });
            }

            retStr = enums.LanguageOK(spillLanguage.Language);
            if (spillLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageLanguage), new[] { ModelsRes.SpillLanguageLanguage });
            }

            if (string.IsNullOrWhiteSpace(spillLanguage.SpillComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageSpillComment), new[] { ModelsRes.SpillLanguageSpillComment });
            }

            //SpillComment has no StringLength Attribute

            retStr = enums.TranslationStatusOK(spillLanguage.TranslationStatus);
            if (spillLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageTranslationStatus), new[] { ModelsRes.SpillLanguageTranslationStatus });
            }

            if (spillLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageLastUpdateDate_UTC), new[] { ModelsRes.SpillLanguageLastUpdateDate_UTC });
            }
            else
            {
                if (spillLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SpillLanguageLastUpdateDate_UTC, "1980"), new[] { ModelsRes.SpillLanguageLastUpdateDate_UTC });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (spillLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.SpillLanguageLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == spillLanguage.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillLanguageLastUpdateContactTVItemID, spillLanguage.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.SpillLanguageLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
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
