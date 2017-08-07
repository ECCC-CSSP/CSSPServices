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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageSpillLanguageID), new[] { "SpillLanguageID" });
                }
            }

            //SpillLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SpillID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            Spill SpillSpillID = (from c in db.Spills where c.SpillID == spillLanguage.SpillID select c).FirstOrDefault();

            if (SpillSpillID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Spill, ModelsRes.SpillLanguageSpillID, spillLanguage.SpillID.ToString()), new[] { "SpillID" });
            }

            retStr = enums.LanguageOK(spillLanguage.Language);
            if (spillLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(spillLanguage.SpillComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageSpillComment), new[] { "SpillComment" });
            }

            //SpillComment has no StringLength Attribute

            retStr = enums.TranslationStatusOK(spillLanguage.TranslationStatus);
            if (spillLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (spillLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (spillLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SpillLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spillLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillLanguageLastUpdateContactTVItemID, spillLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SpillLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(spillLanguage.LanguageText) && spillLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SpillLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(spillLanguage.TranslationStatusText) && spillLanguage.TranslationStatusText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SpillLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public SpillLanguage GetSpillLanguageWithSpillLanguageID(int SpillLanguageID)
        {
            IQueryable<SpillLanguage> spillLanguageQuery = (from c in GetRead()
                                                where c.SpillLanguageID == SpillLanguageID
                                                select c);

            return FillSpillLanguage(spillLanguageQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<SpillLanguage> FillSpillLanguage(IQueryable<SpillLanguage> spillLanguageQuery)
        {
            List<SpillLanguage> SpillLanguageList = (from c in spillLanguageQuery
                                         select new SpillLanguage
                                         {
                                             SpillLanguageID = c.SpillLanguageID,
                                             SpillID = c.SpillID,
                                             Language = c.Language,
                                             SpillComment = c.SpillComment,
                                             TranslationStatus = c.TranslationStatus,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (SpillLanguage spillLanguage in SpillLanguageList)
            {
                spillLanguage.LanguageText = enums.GetEnumText_LanguageEnum(spillLanguage.Language);
                spillLanguage.TranslationStatusText = enums.GetEnumText_TranslationStatusEnum(spillLanguage.TranslationStatus);
            }

            return SpillLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
