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
        public TVItemLanguageService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Contact,
                    TVTypeEnum.Country,
                    TVTypeEnum.Email,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.Tel,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.Classification,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    tvItemLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLanguageTVItemID, "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification"), new[] { "TVItemID" });
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
            IQueryable<TVItemLanguage> tvItemLanguageQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.TVItemLanguageID == TVItemLanguageID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return tvItemLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillTVItemLanguageWeb(tvItemLanguageQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTVItemLanguageReport(tvItemLanguageQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<TVItemLanguage> GetTVItemLanguageList()
        {
            IQueryable<TVItemLanguage> tvItemLanguageQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        tvItemLanguageQuery = EnhanceQueryStatements<TVItemLanguage>(tvItemLanguageQuery) as IQueryable<TVItemLanguage>;

                        return tvItemLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        tvItemLanguageQuery = FillTVItemLanguageWeb(tvItemLanguageQuery);

                        tvItemLanguageQuery = EnhanceQueryStatements<TVItemLanguage>(tvItemLanguageQuery) as IQueryable<TVItemLanguage>;

                        return tvItemLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        tvItemLanguageQuery = FillTVItemLanguageReport(tvItemLanguageQuery);

                        tvItemLanguageQuery = EnhanceQueryStatements<TVItemLanguage>(tvItemLanguageQuery) as IQueryable<TVItemLanguage>;

                        return tvItemLanguageQuery;
                    }
                default:
                    {
                        tvItemLanguageQuery = tvItemLanguageQuery.Where(c => c.TVItemLanguageID == 0);

                        return tvItemLanguageQuery;
                    }
            }
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
            IQueryable<TVItemLanguage> tvItemLanguageQuery = db.TVItemLanguages.AsNoTracking();

            return tvItemLanguageQuery;
        }
        public IQueryable<TVItemLanguage> GetEdit()
        {
            IQueryable<TVItemLanguage> tvItemLanguageQuery = db.TVItemLanguages;

            return tvItemLanguageQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVItemLanguageFillWeb
        private IQueryable<TVItemLanguage> FillTVItemLanguageWeb(IQueryable<TVItemLanguage> tvItemLanguageQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            tvItemLanguageQuery = (from c in tvItemLanguageQuery
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
                        TVItemLanguageWeb = new TVItemLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        },
                        TVItemLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return tvItemLanguageQuery;
        }
        #endregion Functions private Generated TVItemLanguageFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
