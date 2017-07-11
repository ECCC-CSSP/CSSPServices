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
    public partial class VPScenarioLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            VPScenarioLanguage vpScenarioLanguage = validationContext.ObjectInstance as VPScenarioLanguage;

            //VPScenarioLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //VPScenarioLanguageID has no Range Attribute

            //VPScenarioID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //VPScenarioID has no Range Attribute

                //Error: Type not implemented [Language] of type [LanguageEnum]

                //Error: Type not implemented [Language] of type [LanguageEnum]
            if (string.IsNullOrWhiteSpace(vpScenarioLanguage.VPScenarioName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageVPScenarioName), new[] { ModelsRes.VPScenarioLanguageVPScenarioName });
            }

            //VPScenarioName has no StringLength Attribute

                //Error: Type not implemented [TranslationStatus] of type [TranslationStatusEnum]

                //Error: Type not implemented [TranslationStatus] of type [TranslationStatusEnum]
            if (vpScenarioLanguage.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageLastUpdateDate_UTC), new[] { ModelsRes.VPScenarioLanguageLastUpdateDate_UTC });
            }

            if (vpScenarioLanguage.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.VPScenarioLanguageLastUpdateDate_UTC, "1980"), new[] { ModelsRes.VPScenarioLanguageLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenarioLanguage.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, "1"), new[] { ModelsRes.VPScenarioLanguageLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == vpScenarioLanguage.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, vpScenarioLanguage.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.VPScenarioLanguageLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(VPScenarioLanguage vpScenarioLanguage)
        {
            vpScenarioLanguage.ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Create);
            if (vpScenarioLanguage.ValidationResults.Count() > 0) return false;

            db.VPScenarioLanguages.Add(vpScenarioLanguage);

            if (!TryToSave(vpScenarioLanguage)) return false;

            return true;
        }
        public bool AddRange(List<VPScenarioLanguage> vpScenarioLanguageList)
        {
            foreach (VPScenarioLanguage vpScenarioLanguage in vpScenarioLanguageList)
            {
                vpScenarioLanguage.ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Create);
                if (vpScenarioLanguage.ValidationResults.Count() > 0) return false;
            }

            db.VPScenarioLanguages.AddRange(vpScenarioLanguageList);

            if (!TryToSaveRange(vpScenarioLanguageList)) return false;

            return true;
        }
        public bool Delete(VPScenarioLanguage vpScenarioLanguage)
        {
            if (!db.VPScenarioLanguages.Where(c => c.VPScenarioLanguageID == vpScenarioLanguage.VPScenarioLanguageID).Any())
            {
                vpScenarioLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPScenarioLanguage", "VPScenarioLanguageID", vpScenarioLanguage.VPScenarioLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.VPScenarioLanguages.Remove(vpScenarioLanguage);

            if (!TryToSave(vpScenarioLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<VPScenarioLanguage> vpScenarioLanguageList)
        {
            foreach (VPScenarioLanguage vpScenarioLanguage in vpScenarioLanguageList)
            {
                if (!db.VPScenarioLanguages.Where(c => c.VPScenarioLanguageID == vpScenarioLanguage.VPScenarioLanguageID).Any())
                {
                    vpScenarioLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPScenarioLanguage", "VPScenarioLanguageID", vpScenarioLanguage.VPScenarioLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.VPScenarioLanguages.RemoveRange(vpScenarioLanguageList);

            if (!TryToSaveRange(vpScenarioLanguageList)) return false;

            return true;
        }
        public bool Update(VPScenarioLanguage vpScenarioLanguage)
        {
            vpScenarioLanguage.ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Update);
            if (vpScenarioLanguage.ValidationResults.Count() > 0) return false;

            db.VPScenarioLanguages.Update(vpScenarioLanguage);

            if (!TryToSave(vpScenarioLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<VPScenarioLanguage> vpScenarioLanguageList)
        {
            foreach (VPScenarioLanguage vpScenarioLanguage in vpScenarioLanguageList)
            {
                vpScenarioLanguage.ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Update);
                if (vpScenarioLanguage.ValidationResults.Count() > 0) return false;
            }
            db.VPScenarioLanguages.UpdateRange(vpScenarioLanguageList);

            if (!TryToSaveRange(vpScenarioLanguageList)) return false;

            return true;
        }
        public IQueryable<VPScenarioLanguage> GetRead()
        {
            return db.VPScenarioLanguages.AsNoTracking();
        }
        public IQueryable<VPScenarioLanguage> GetEdit()
        {
            return db.VPScenarioLanguages;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(VPScenarioLanguage vpScenarioLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpScenarioLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<VPScenarioLanguage> vpScenarioLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpScenarioLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
