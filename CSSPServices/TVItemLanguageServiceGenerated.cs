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
    /// <summary>
    ///     <para>bonjour TVItemLanguage</para>
    /// </summary>
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
            tvItemLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemLanguage.TVItemLanguageID == 0)
                {
                    tvItemLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageTVItemLanguageID), new[] { "TVItemLanguageID" });
                }

                if (!GetRead().Where(c => c.TVItemLanguageID == tvItemLanguage.TVItemLanguageID).Any())
                {
                    tvItemLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemLanguage, CSSPModelsRes.TVItemLanguageTVItemLanguageID, tvItemLanguage.TVItemLanguageID.ToString()), new[] { "TVItemLanguageID" });
                }
            }

            //TVItemLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLanguage.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLanguageTVItemID, tvItemLanguage.TVItemID.ToString()), new[] { "TVItemID" });
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
                    tvItemLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLanguageTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), new[] { "TVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvItemLanguage.Language);
            if (tvItemLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(tvItemLanguage.TVText))
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageTVText), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLanguage.TVText) && tvItemLanguage.TVText.Length > 200)
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemLanguageTVText, "200"), new[] { "TVText" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)tvItemLanguage.TranslationStatus);
            if (tvItemLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (tvItemLanguage.LastUpdateDate_UTC.Year == 1)
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVItemLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLanguageLastUpdateContactTVItemID, tvItemLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvItemLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvItemLanguage.LastUpdateContactTVText) && tvItemLanguage.LastUpdateContactTVText.Length > 200)
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLanguage.LanguageText) && tvItemLanguage.LanguageText.Length > 100)
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLanguage.TranslationStatusText) && tvItemLanguage.TranslationStatusText.Length > 100)
            {
                tvItemLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvItemLanguage.HasErrors = true;
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
        public bool Delete(TVItemLanguage tvItemLanguage)
        {
            tvItemLanguage.ValidationResults = Validate(new ValidationContext(tvItemLanguage), ActionDBTypeEnum.Delete);
            if (tvItemLanguage.ValidationResults.Count() > 0) return false;

            db.TVItemLanguages.Remove(tvItemLanguage);

            if (!TryToSave(tvItemLanguage)) return false;

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
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new TVItemLanguage
                                         {
                                             TVItemLanguageID = c.TVItemLanguageID,
                                             TVItemID = c.TVItemID,
                                             Language = c.Language,
                                             TVText = c.TVText,
                                             TranslationStatus = c.TranslationStatus,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (TVItemLanguage tvItemLanguage in TVItemLanguageList)
            {
                tvItemLanguage.LanguageText = enums.GetResValueForTypeAndID(typeof(LanguageEnum), (int?)tvItemLanguage.Language);
                tvItemLanguage.TranslationStatusText = enums.GetResValueForTypeAndID(typeof(TranslationStatusEnum), (int?)tvItemLanguage.TranslationStatus);
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
        #endregion Functions private Generated

    }
}
