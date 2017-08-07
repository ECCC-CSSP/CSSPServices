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
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPScenarioLanguage vpScenarioLanguage = validationContext.ObjectInstance as VPScenarioLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (vpScenarioLanguage.VPScenarioLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageVPScenarioLanguageID), new[] { "VPScenarioLanguageID" });
                }
            }

            //VPScenarioLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //VPScenarioID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            VPScenario VPScenarioVPScenarioID = (from c in db.VPScenarios where c.VPScenarioID == vpScenarioLanguage.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.VPScenario, ModelsRes.VPScenarioLanguageVPScenarioID, vpScenarioLanguage.VPScenarioID.ToString()), new[] { "VPScenarioID" });
            }

            retStr = enums.LanguageOK(vpScenarioLanguage.Language);
            if (vpScenarioLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(vpScenarioLanguage.VPScenarioName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageVPScenarioName), new[] { "VPScenarioName" });
            }

            if (!string.IsNullOrWhiteSpace(vpScenarioLanguage.VPScenarioName) && vpScenarioLanguage.VPScenarioName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.VPScenarioLanguageVPScenarioName, "100"), new[] { "VPScenarioName" });
            }

            retStr = enums.TranslationStatusOK(vpScenarioLanguage.TranslationStatus);
            if (vpScenarioLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (vpScenarioLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPScenarioLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpScenarioLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.VPScenarioLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpScenarioLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, vpScenarioLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(vpScenarioLanguage.LanguageText) && vpScenarioLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.VPScenarioLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(vpScenarioLanguage.TranslationStatusText) && vpScenarioLanguage.TranslationStatusText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.VPScenarioLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public VPScenarioLanguage GetVPScenarioLanguageWithVPScenarioLanguageID(int VPScenarioLanguageID)
        {
            IQueryable<VPScenarioLanguage> vpScenarioLanguageQuery = (from c in GetRead()
                                                where c.VPScenarioLanguageID == VPScenarioLanguageID
                                                select c);

            return FillVPScenarioLanguage(vpScenarioLanguageQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<VPScenarioLanguage> FillVPScenarioLanguage(IQueryable<VPScenarioLanguage> vpScenarioLanguageQuery)
        {
            List<VPScenarioLanguage> VPScenarioLanguageList = (from c in vpScenarioLanguageQuery
                                         select new VPScenarioLanguage
                                         {
                                             VPScenarioLanguageID = c.VPScenarioLanguageID,
                                             VPScenarioID = c.VPScenarioID,
                                             Language = c.Language,
                                             VPScenarioName = c.VPScenarioName,
                                             TranslationStatus = c.TranslationStatus,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (VPScenarioLanguage vpScenarioLanguage in VPScenarioLanguageList)
            {
                vpScenarioLanguage.LanguageText = enums.GetEnumText_LanguageEnum(vpScenarioLanguage.Language);
                vpScenarioLanguage.TranslationStatusText = enums.GetEnumText_TranslationStatusEnum(vpScenarioLanguage.TranslationStatus);
            }

            return VPScenarioLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
