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
    public partial class TVItemLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemLanguage tvItemLanguage = validationContext.ObjectInstance as TVItemLanguage;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvItemLanguage.TVItemLanguageID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVItemLanguageID), new[] { "TVItemLanguageID" });
                }
            }

            //TVItemLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLanguage.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLanguageTVItemID, tvItemLanguage.TVItemID.ToString()), new[] { "TVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Country,
                    TVTypeEnum.Province,
                    TVTypeEnum.Area,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.MWQMSiteSample,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.SamplingPlan,
                    TVTypeEnum.Spill,
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLanguageTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), new[] { "TVItemID" });
                }
            }

            retStr = enums.LanguageOK(tvItemLanguage.Language);
            if (tvItemLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(tvItemLanguage.TVText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVText), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLanguage.TVText) && tvItemLanguage.TVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageTVText, "200"), new[] { "TVText" });
            }

            retStr = enums.TranslationStatusOK(tvItemLanguage.TranslationStatus);
            if (tvItemLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (tvItemLanguage.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, tvItemLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvItemLanguage.LanguageText) && tvItemLanguage.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLanguage.TranslationStatusText) && tvItemLanguage.TranslationStatusText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVItemLanguage GetTVItemLanguageWithTVItemLanguageID(int TVItemLanguageID)
        {
            IQueryable<TVItemLanguage> tvItemLanguageQuery = (from c in GetRead()
                                                where c.TVItemLanguageID == TVItemLanguageID
                                                select c);

            return FillTVItemLanguage(tvItemLanguageQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TVItemLanguage tvItemLanguage)
        {
            tvItemLanguage.ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Create);
            if (tvItemLanguage.ValidationResults.Count() > 0) return false;

            db.TVItemLanguages.Add(tvItemLanguage);

            if (!TryToSave(tvItemLanguage)) return false;

            return true;
        }
        public bool AddRange(List<TVItemLanguage> tvItemLanguageList)
        {
            foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                tvItemLanguage.ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Create);
                if (tvItemLanguage.ValidationResults.Count() > 0) return false;
            }

            db.TVItemLanguages.AddRange(tvItemLanguageList);

            if (!TryToSaveRange(tvItemLanguageList)) return false;

            return true;
        }
        public bool Delete(TVItemLanguage tvItemLanguage)
        {
            if (!db.TVItemLanguages.Where(c => c.TVItemLanguageID == tvItemLanguage.TVItemLanguageID).Any())
            {
                tvItemLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageID", tvItemLanguage.TVItemLanguageID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVItemLanguages.Remove(tvItemLanguage);

            if (!TryToSave(tvItemLanguage)) return false;

            return true;
        }
        public bool DeleteRange(List<TVItemLanguage> tvItemLanguageList)
        {
            foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                if (!db.TVItemLanguages.Where(c => c.TVItemLanguageID == tvItemLanguage.TVItemLanguageID).Any())
                {
                    tvItemLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemLanguage", "TVItemLanguageID", tvItemLanguage.TVItemLanguageID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVItemLanguages.RemoveRange(tvItemLanguageList);

            if (!TryToSaveRange(tvItemLanguageList)) return false;

            return true;
        }
        public bool Update(TVItemLanguage tvItemLanguage)
        {
            tvItemLanguage.ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Update);
            if (tvItemLanguage.ValidationResults.Count() > 0) return false;

            db.TVItemLanguages.Update(tvItemLanguage);

            if (!TryToSave(tvItemLanguage)) return false;

            return true;
        }
        public bool UpdateRange(List<TVItemLanguage> tvItemLanguageList)
        {
            foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                tvItemLanguage.ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Update);
                if (tvItemLanguage.ValidationResults.Count() > 0) return false;
            }
            db.TVItemLanguages.UpdateRange(tvItemLanguageList);

            if (!TryToSaveRange(tvItemLanguageList)) return false;

            return true;
        }
        public IQueryable<TVItemLanguage> GetRead()
        {
            return db.TVItemLanguages.AsNoTracking();
        }
        public IQueryable<TVItemLanguage> GetEdit()
        {
            return db.TVItemLanguages;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<TVItemLanguage> FillTVItemLanguage(IQueryable<TVItemLanguage> tvItemLanguageQuery)
        {
            List<TVItemLanguage> TVItemLanguageList = (from c in tvItemLanguageQuery
                                         select new TVItemLanguage
                                         {
                                             TVItemLanguageID = c.TVItemLanguageID,
                                             TVItemID = c.TVItemID,
                                             Language = c.Language,
                                             TVText = c.TVText,
                                             TranslationStatus = c.TranslationStatus,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (TVItemLanguage tvItemLanguage in TVItemLanguageList)
            {
                tvItemLanguage.LanguageText = enums.GetEnumText_LanguageEnum(tvItemLanguage.Language);
                tvItemLanguage.TranslationStatusText = enums.GetEnumText_TranslationStatusEnum(tvItemLanguage.TranslationStatus);
            }

            return TVItemLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(TVItemLanguage tvItemLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVItemLanguage> tvItemLanguageList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemLanguageList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
