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
    public partial class InfrastructureLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            InfrastructureLanguage infrastructureLanguage = validationContext.ObjectInstance as InfrastructureLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (infrastructureLanguage.InfrastructureLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageInfrastructureLanguageID), new[] { ModelsRes.InfrastructureLanguageInfrastructureLanguageID });
                }
            }

            //InfrastructureLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (infrastructureLanguage.InfrastructureID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLanguageInfrastructureID, "1"), new[] { ModelsRes.InfrastructureLanguageInfrastructureID });
            }

            if (!((from c in db.Infrastructures where c.InfrastructureID == infrastructureLanguage.InfrastructureID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Infrastructure, ModelsRes.InfrastructureLanguageInfrastructureID, infrastructureLanguage.InfrastructureID.ToString()), new[] { ModelsRes.InfrastructureLanguageInfrastructureID });
            }

            retStr = enums.LanguageOK(infrastructureLanguage.Language);
            if (infrastructureLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageLanguage), new[] { ModelsRes.InfrastructureLanguageLanguage });
            }

            if (string.IsNullOrWhiteSpace(infrastructureLanguage.Comment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageComment), new[] { ModelsRes.InfrastructureLanguageComment });
            }

            //Comment has no StringLength Attribute

            retStr = enums.TranslationStatusOK(infrastructureLanguage.TranslationStatus);
            if (infrastructureLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageTranslationStatus), new[] { ModelsRes.InfrastructureLanguageTranslationStatus });
            }

            if (infrastructureLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageLastUpdateDate_UTC), new[] { ModelsRes.InfrastructureLanguageLastUpdateDate_UTC });
            }
            else
            {
                if (infrastructureLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.InfrastructureLanguageLastUpdateDate_UTC, "1980"), new[] { ModelsRes.InfrastructureLanguageLastUpdateDate_UTC });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (infrastructureLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == infrastructureLanguage.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, infrastructureLanguage.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(InfrastructureLanguage infrastructureLanguage)
        {
            infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Create);
            if (infrastructureLanguage.ValidationResults.Count() > 0) return false;

            db.InfrastructureLanguages.Add(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        public bool AddRange(List<InfrastructureLanguage> infrastructureLanguageList)
        {
            foreach (InfrastructureLanguage infrastructureLanguage in infrastructureLanguageList)
            {
                infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Create);
                if (infrastructureLanguage.ValidationResults.Count() > 0) return false;
            }

            db.InfrastructureLanguages.AddRange(infrastructureLanguageList);

            if (!TryToSaveRange(infrastructureLanguageList)) return false;

            return true;
        }
        public bool Delete(InfrastructureLanguage infrastructureLanguage)
        {
            if (!db.InfrastructureLanguages.Where(c => c.InfrastructureLanguageID == infrastructureLanguage.InfrastructureLanguageID).Any())
            {
                infrastructureLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageID", infrastructureLanguage.InfrastructureLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.InfrastructureLanguages.Remove(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<InfrastructureLanguage> infrastructureLanguageList)
        {
            foreach (InfrastructureLanguage infrastructureLanguage in infrastructureLanguageList)
            {
                if (!db.InfrastructureLanguages.Where(c => c.InfrastructureLanguageID == infrastructureLanguage.InfrastructureLanguageID).Any())
                {
                    infrastructureLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageID", infrastructureLanguage.InfrastructureLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.InfrastructureLanguages.RemoveRange(infrastructureLanguageList);

            if (!TryToSaveRange(infrastructureLanguageList)) return false;

            return true;
        }
        public bool Update(InfrastructureLanguage infrastructureLanguage)
        {
            infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Update);
            if (infrastructureLanguage.ValidationResults.Count() > 0) return false;

            db.InfrastructureLanguages.Update(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<InfrastructureLanguage> infrastructureLanguageList)
        {
            foreach (InfrastructureLanguage infrastructureLanguage in infrastructureLanguageList)
            {
                infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Update);
                if (infrastructureLanguage.ValidationResults.Count() > 0) return false;
            }
            db.InfrastructureLanguages.UpdateRange(infrastructureLanguageList);

            if (!TryToSaveRange(infrastructureLanguageList)) return false;

            return true;
        }
        public IQueryable<InfrastructureLanguage> GetRead()
        {
            return db.InfrastructureLanguages.AsNoTracking();
        }
        public IQueryable<InfrastructureLanguage> GetEdit()
        {
            return db.InfrastructureLanguages;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(InfrastructureLanguage infrastructureLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                infrastructureLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<InfrastructureLanguage> infrastructureLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                infrastructureLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
