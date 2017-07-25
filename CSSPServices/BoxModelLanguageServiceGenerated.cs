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
    public partial class BoxModelLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            BoxModelLanguage boxModelLanguage = validationContext.ObjectInstance as BoxModelLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (boxModelLanguage.BoxModelLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageBoxModelLanguageID), new[] { ModelsRes.BoxModelLanguageBoxModelLanguageID });
                }
            }

            //BoxModelLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //BoxModelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelLanguage.BoxModelID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelLanguageBoxModelID, "1"), new[] { ModelsRes.BoxModelLanguageBoxModelID });
            }

            if (!((from c in db.BoxModels where c.BoxModelID == boxModelLanguage.BoxModelID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.BoxModel, ModelsRes.BoxModelLanguageBoxModelID, boxModelLanguage.BoxModelID.ToString()), new[] { ModelsRes.BoxModelLanguageBoxModelID });
            }

            retStr = enums.LanguageOK(boxModelLanguage.Language);
            if (boxModelLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageLanguage), new[] { ModelsRes.BoxModelLanguageLanguage });
            }

            if (string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageScenarioName), new[] { ModelsRes.BoxModelLanguageScenarioName });
            }

            if (!string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName) && boxModelLanguage.ScenarioName.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelLanguageScenarioName, "250"), new[] { ModelsRes.BoxModelLanguageScenarioName });
            }

            retStr = enums.TranslationStatusOK(boxModelLanguage.TranslationStatus);
            if (boxModelLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageTranslationStatus), new[] { ModelsRes.BoxModelLanguageTranslationStatus });
            }

            if (boxModelLanguage.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageLastUpdateDate_UTC), new[] { ModelsRes.BoxModelLanguageLastUpdateDate_UTC });
            }

            if (boxModelLanguage.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.BoxModelLanguageLastUpdateDate_UTC, "1980"), new[] { ModelsRes.BoxModelLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.BoxModelLanguageLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == boxModelLanguage.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelLanguageLastUpdateContactTVItemID, boxModelLanguage.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.BoxModelLanguageLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(BoxModelLanguage boxModelLanguage)
        {
            boxModelLanguage.ValidationResults = Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Create);
            if (boxModelLanguage.ValidationResults.Count() > 0) return false;

            db.BoxModelLanguages.Add(boxModelLanguage);

            if (!TryToSave(boxModelLanguage)) return false;

            return true;
        }
        public bool AddRange(List<BoxModelLanguage> boxModelLanguageList)
        {
            foreach (BoxModelLanguage boxModelLanguage in boxModelLanguageList)
            {
                boxModelLanguage.ValidationResults = Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Create);
                if (boxModelLanguage.ValidationResults.Count() > 0) return false;
            }

            db.BoxModelLanguages.AddRange(boxModelLanguageList);

            if (!TryToSaveRange(boxModelLanguageList)) return false;

            return true;
        }
        public bool Delete(BoxModelLanguage boxModelLanguage)
        {
            if (!db.BoxModelLanguages.Where(c => c.BoxModelLanguageID == boxModelLanguage.BoxModelLanguageID).Any())
            {
                boxModelLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageID", boxModelLanguage.BoxModelLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.BoxModelLanguages.Remove(boxModelLanguage);

            if (!TryToSave(boxModelLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<BoxModelLanguage> boxModelLanguageList)
        {
            foreach (BoxModelLanguage boxModelLanguage in boxModelLanguageList)
            {
                if (!db.BoxModelLanguages.Where(c => c.BoxModelLanguageID == boxModelLanguage.BoxModelLanguageID).Any())
                {
                    boxModelLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageID", boxModelLanguage.BoxModelLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.BoxModelLanguages.RemoveRange(boxModelLanguageList);

            if (!TryToSaveRange(boxModelLanguageList)) return false;

            return true;
        }
        public bool Update(BoxModelLanguage boxModelLanguage)
        {
            boxModelLanguage.ValidationResults = Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Update);
            if (boxModelLanguage.ValidationResults.Count() > 0) return false;

            db.BoxModelLanguages.Update(boxModelLanguage);

            if (!TryToSave(boxModelLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<BoxModelLanguage> boxModelLanguageList)
        {
            foreach (BoxModelLanguage boxModelLanguage in boxModelLanguageList)
            {
                boxModelLanguage.ValidationResults = Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Update);
                if (boxModelLanguage.ValidationResults.Count() > 0) return false;
            }
            db.BoxModelLanguages.UpdateRange(boxModelLanguageList);

            if (!TryToSaveRange(boxModelLanguageList)) return false;

            return true;
        }
        public IQueryable<BoxModelLanguage> GetRead()
        {
            return db.BoxModelLanguages.AsNoTracking();
        }
        public IQueryable<BoxModelLanguage> GetEdit()
        {
            return db.BoxModelLanguages;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(BoxModelLanguage boxModelLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                boxModelLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<BoxModelLanguage> boxModelLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                boxModelLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
