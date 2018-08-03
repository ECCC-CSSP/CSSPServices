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
    ///     <para>bonjour MWQMSampleLanguage</para>
    /// </summary>
    public partial class MWQMSampleLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSampleLanguage mwqmSampleLanguage = validationContext.ObjectInstance as MWQMSampleLanguage;
            mwqmSampleLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSampleLanguage.MWQMSampleLanguageID == 0)
                {
                    mwqmSampleLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageMWQMSampleLanguageID"), new[] { "MWQMSampleLanguageID" });
                }

                if (!GetRead().Where(c => c.MWQMSampleLanguageID == mwqmSampleLanguage.MWQMSampleLanguageID).Any())
                {
                    mwqmSampleLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSampleLanguage", "MWQMSampleLanguageMWQMSampleLanguageID", mwqmSampleLanguage.MWQMSampleLanguageID.ToString()), new[] { "MWQMSampleLanguageID" });
                }
            }

            MWQMSample MWQMSampleMWQMSampleID = (from c in db.MWQMSamples where c.MWQMSampleID == mwqmSampleLanguage.MWQMSampleID select c).FirstOrDefault();

            if (MWQMSampleMWQMSampleID == null)
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleLanguageMWQMSampleID", mwqmSampleLanguage.MWQMSampleID.ToString()), new[] { "MWQMSampleID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)mwqmSampleLanguage.Language);
            if (mwqmSampleLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageLanguage"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(mwqmSampleLanguage.MWQMSampleNote))
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageMWQMSampleNote"), new[] { "MWQMSampleNote" });
            }

            //MWQMSampleNote has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)mwqmSampleLanguage.TranslationStatus);
            if (mwqmSampleLanguage.TranslationStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageTranslationStatus"), new[] { "TranslationStatus" });
            }

            if (mwqmSampleLanguage.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSampleLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSampleLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSampleLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSampleLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSampleLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSampleLanguageLastUpdateContactTVItemID", mwqmSampleLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSampleLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSampleLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSampleLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSampleLanguage GetMWQMSampleLanguageWithMWQMSampleLanguageID(int MWQMSampleLanguageID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.MWQMSampleLanguageID == MWQMSampleLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMSampleLanguage> GetMWQMSampleLanguageList()
        {
            IQueryable<MWQMSampleLanguage> MWQMSampleLanguageQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            MWQMSampleLanguageQuery = EnhanceQueryStatements<MWQMSampleLanguage>(MWQMSampleLanguageQuery) as IQueryable<MWQMSampleLanguage>;

            return MWQMSampleLanguageQuery;
        }
        public MWQMSampleLanguageWeb GetMWQMSampleLanguageWebWithMWQMSampleLanguageID(int MWQMSampleLanguageID)
        {
            return FillMWQMSampleLanguageWeb().FirstOrDefault();

        }
        public IQueryable<MWQMSampleLanguageWeb> GetMWQMSampleLanguageWebList()
        {
            IQueryable<MWQMSampleLanguageWeb> MWQMSampleLanguageWebQuery = FillMWQMSampleLanguageWeb();

            MWQMSampleLanguageWebQuery = EnhanceQueryStatements<MWQMSampleLanguageWeb>(MWQMSampleLanguageWebQuery) as IQueryable<MWQMSampleLanguageWeb>;

            return MWQMSampleLanguageWebQuery;
        }
        public MWQMSampleLanguageReport GetMWQMSampleLanguageReportWithMWQMSampleLanguageID(int MWQMSampleLanguageID)
        {
            return FillMWQMSampleLanguageReport().FirstOrDefault();

        }
        public IQueryable<MWQMSampleLanguageReport> GetMWQMSampleLanguageReportList()
        {
            IQueryable<MWQMSampleLanguageReport> MWQMSampleLanguageReportQuery = FillMWQMSampleLanguageReport();

            MWQMSampleLanguageReportQuery = EnhanceQueryStatements<MWQMSampleLanguageReport>(MWQMSampleLanguageReportQuery) as IQueryable<MWQMSampleLanguageReport>;

            return MWQMSampleLanguageReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMSampleLanguage mwqmSampleLanguage)
        {
            mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Create);
            if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSampleLanguages.Add(mwqmSampleLanguage);

            if (!TryToSave(mwqmSampleLanguage)) return false;

            return true;
        }
        public bool Delete(MWQMSampleLanguage mwqmSampleLanguage)
        {
            mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Delete);
            if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSampleLanguages.Remove(mwqmSampleLanguage);

            if (!TryToSave(mwqmSampleLanguage)) return false;

            return true;
        }
        public bool Update(MWQMSampleLanguage mwqmSampleLanguage)
        {
            mwqmSampleLanguage.ValidationResults = Validate(new ValidationContext(mwqmSampleLanguage), ActionDBTypeEnum.Update);
            if (mwqmSampleLanguage.ValidationResults.Count() > 0) return false;

            db.MWQMSampleLanguages.Update(mwqmSampleLanguage);

            if (!TryToSave(mwqmSampleLanguage)) return false;

            return true;
        }
        public IQueryable<MWQMSampleLanguage> GetRead()
        {
            IQueryable<MWQMSampleLanguage> mwqmSampleLanguageQuery = db.MWQMSampleLanguages.AsNoTracking();

            return mwqmSampleLanguageQuery;
        }
        public IQueryable<MWQMSampleLanguage> GetEdit()
        {
            IQueryable<MWQMSampleLanguage> mwqmSampleLanguageQuery = db.MWQMSampleLanguages;

            return mwqmSampleLanguageQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MWQMSampleLanguageFillWeb
        private IQueryable<MWQMSampleLanguageWeb> FillMWQMSampleLanguageWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<MWQMSampleLanguageWeb>  MWQMSampleLanguageWebQuery = (from c in db.MWQMSampleLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSampleLanguageWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        MWQMSampleLanguageID = c.MWQMSampleLanguageID,
                        MWQMSampleID = c.MWQMSampleID,
                        Language = c.Language,
                        MWQMSampleNote = c.MWQMSampleNote,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return MWQMSampleLanguageWebQuery;
        }
        #endregion Functions private Generated MWQMSampleLanguageFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(MWQMSampleLanguage mwqmSampleLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSampleLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}