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
        public TVFileLanguageService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguageTVFileLanguageID"), new[] { "TVFileLanguageID" });
                }

                if (!(from c in db.TVFileLanguages select c).Where(c => c.TVFileLanguageID == tvFileLanguage.TVFileLanguageID).Any())
                {
                    tvFileLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVFileLanguage", "TVFileLanguageTVFileLanguageID", tvFileLanguage.TVFileLanguageID.ToString()), new[] { "TVFileLanguageID" });
                }
            }

            TVFile TVFileTVFileID = (from c in db.TVFiles where c.TVFileID == tvFileLanguage.TVFileID select c).FirstOrDefault();

            if (TVFileTVFileID == null)
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileLanguageTVFileID", tvFileLanguage.TVFileID.ToString()), new[] { "TVFileID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvFileLanguage.Language);
            if (tvFileLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguageLanguage"), new[] { "Language" });
            }

            //FileDescription has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)tvFileLanguage.TranslationStatus);
            if (tvFileLanguage.TranslationStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguageTranslationStatus"), new[] { "TranslationStatus" });
            }

            if (tvFileLanguage.LastUpdateDate_UTC.Year == 1)
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvFileLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                tvFileLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVFileLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvFileLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvFileLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileLanguageLastUpdateContactTVItemID", tvFileLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVFileLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            return (from c in db.TVFileLanguages
                    where c.TVFileLanguageID == TVFileLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<TVFileLanguage> GetTVFileLanguageList()
        {
            IQueryable<TVFileLanguage> TVFileLanguageQuery = (from c in db.TVFileLanguages select c);

            TVFileLanguageQuery = EnhanceQueryStatements<TVFileLanguage>(TVFileLanguageQuery) as IQueryable<TVFileLanguage>;

            return TVFileLanguageQuery;
        }
        public TVFileLanguageWeb GetTVFileLanguageWebWithTVFileLanguageID(int TVFileLanguageID)
        {
            return FillTVFileLanguageWeb().Where(c => c.TVFileLanguageID == TVFileLanguageID).FirstOrDefault();

        }
        public IQueryable<TVFileLanguageWeb> GetTVFileLanguageWebList()
        {
            IQueryable<TVFileLanguageWeb> TVFileLanguageWebQuery = FillTVFileLanguageWeb();

            TVFileLanguageWebQuery = EnhanceQueryStatements<TVFileLanguageWeb>(TVFileLanguageWebQuery) as IQueryable<TVFileLanguageWeb>;

            return TVFileLanguageWebQuery;
        }
        public TVFileLanguageReport GetTVFileLanguageReportWithTVFileLanguageID(int TVFileLanguageID)
        {
            return FillTVFileLanguageReport().Where(c => c.TVFileLanguageID == TVFileLanguageID).FirstOrDefault();

        }
        public IQueryable<TVFileLanguageReport> GetTVFileLanguageReportList()
        {
            IQueryable<TVFileLanguageReport> TVFileLanguageReportQuery = FillTVFileLanguageReport();

            TVFileLanguageReportQuery = EnhanceQueryStatements<TVFileLanguageReport>(TVFileLanguageReportQuery) as IQueryable<TVFileLanguageReport>;

            return TVFileLanguageReportQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVFileLanguageFillWeb
        private IQueryable<TVFileLanguageWeb> FillTVFileLanguageWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<TVFileLanguageWeb>  TVFileLanguageWebQuery = (from c in db.TVFileLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TVFileLanguageWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        TVFileLanguageID = c.TVFileLanguageID,
                        TVFileID = c.TVFileID,
                        Language = c.Language,
                        FileDescription = c.FileDescription,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVFileLanguageWebQuery;
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
