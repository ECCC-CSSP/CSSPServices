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
    ///     <para>bonjour TVFileLanguage</para>
    /// </summary>
    public partial class TVFileLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileLanguageService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVFileLanguage tvFileLanguage = validationContext.ObjectInstance as TVFileLanguage;
            tvFileLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvFileLanguage.TVFileLanguageID == 0)
                {
                    tvFileLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguageTVFileLanguageID), new[] { "TVFileLanguageID" });
                }

                if (!GetRead().Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
                {
                    tvFileLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVFileLanguage, CSSPModelsRes.TVFileLanguageTVFileLanguageID, tvFileLanguage.TVFileLanguageID.ToString()), new[] { "TVFileLanguageID" });
                }
            }

            TVFile TVFileTVFileID = (from c in db.TVFiles where c.TVFileID == tvFileLanguage.TVFileID select c).FirstOrDefault();

            if (TVFileTVFileID == null)
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVFile, CSSPModelsRes.TVFileLanguageTVFileID, tvFileLanguage.TVFileID.ToString()), new[] { "TVFileID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvFileLanguage.Language);
            if (tvFileLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguageLanguage), new[] { "Language" });
            }

            //FileDescription has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)tvFileLanguage.TranslationStatus);
            if (tvFileLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (tvFileLanguage.LastUpdateDate_UTC.Year == 1)
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvFileLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                tvFileLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVFileLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvFileLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVFileLanguageLastUpdateContactTVItemID, tvFileLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvFileLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVFileLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVFileLanguage GetTVFileLanguageWithTVFileLanguageID(int TVFileLanguageID)
        {
            IQueryable<TVFileLanguage> tvFileLanguageQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.TVFileLanguageID == TVFileLanguageID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return tvFileLanguageQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillTVFileLanguageWeb(tvFileLanguageQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTVFileLanguageReport(tvFileLanguageQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<TVFileLanguage> GetTVFileLanguageList()
        {
            IQueryable<TVFileLanguage> tvFileLanguageQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        tvFileLanguageQuery = EnhanceQueryStatements<TVFileLanguage>(tvFileLanguageQuery) as IQueryable<TVFileLanguage>;

                        return tvFileLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        tvFileLanguageQuery = FillTVFileLanguageWeb(tvFileLanguageQuery);

                        tvFileLanguageQuery = EnhanceQueryStatements<TVFileLanguage>(tvFileLanguageQuery) as IQueryable<TVFileLanguage>;

                        return tvFileLanguageQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        tvFileLanguageQuery = FillTVFileLanguageReport(tvFileLanguageQuery);

                        tvFileLanguageQuery = EnhanceQueryStatements<TVFileLanguage>(tvFileLanguageQuery) as IQueryable<TVFileLanguage>;

                        return tvFileLanguageQuery;
                    }
                default:
                    {
                        tvFileLanguageQuery = tvFileLanguageQuery.Where(c => c.TVFileLanguageID == 0);

                        return tvFileLanguageQuery;
                    }
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TVFileLanguage tvFileLanguage)
        {
            tvFileLanguage.ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Create);
            if (tvFileLanguage.ValidationResults.Count() > 0) return false;

            db.TVFileLanguages.Add(tvFileLanguage);

            if (!TryToSave(tvFileLanguage)) return false;

            return true;
        }
        public bool Delete(TVFileLanguage tvFileLanguage)
        {
            tvFileLanguage.ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Delete);
            if (tvFileLanguage.ValidationResults.Count() > 0) return false;

            db.TVFileLanguages.Remove(tvFileLanguage);

            if (!TryToSave(tvFileLanguage)) return false;

            return true;
        }
        public bool Update(TVFileLanguage tvFileLanguage)
        {
            tvFileLanguage.ValidationResults = Validate(new ValidationContext(tvFileLanguage), ActionDBTypeEnum.Update);
            if (tvFileLanguage.ValidationResults.Count() > 0) return false;

            db.TVFileLanguages.Update(tvFileLanguage);

            if (!TryToSave(tvFileLanguage)) return false;

            return true;
        }
        public IQueryable<TVFileLanguage> GetRead()
        {
            IQueryable<TVFileLanguage> tvFileLanguageQuery = db.TVFileLanguages.AsNoTracking();

            return tvFileLanguageQuery;
        }
        public IQueryable<TVFileLanguage> GetEdit()
        {
            IQueryable<TVFileLanguage> tvFileLanguageQuery = db.TVFileLanguages;

            return tvFileLanguageQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVFileLanguageFillWeb
        private IQueryable<TVFileLanguage> FillTVFileLanguageWeb(IQueryable<TVFileLanguage> tvFileLanguageQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            tvFileLanguageQuery = (from c in tvFileLanguageQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new TVFileLanguage
                    {
                        TVFileLanguageID = c.TVFileLanguageID,
                        TVFileID = c.TVFileID,
                        Language = c.Language,
                        FileDescription = c.FileDescription,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        TVFileLanguageWeb = new TVFileLanguageWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        },
                        TVFileLanguageReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return tvFileLanguageQuery;
        }
        #endregion Functions private Generated TVFileLanguageFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(TVFileLanguage tvFileLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvFileLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
