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
    ///     <para>bonjour SpillLanguage</para>
    /// </summary>
    public partial class SpillLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillLanguageService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SpillLanguage spillLanguage = validationContext.ObjectInstance as SpillLanguage;
            spillLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (spillLanguage.SpillLanguageID == 0)
                {
                    spillLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageSpillLanguageID"), new[] { "SpillLanguageID" });
                }

                if (!GetRead().Where(c => c.SpillLanguageID == spillLanguage.SpillLanguageID).Any())
                {
                    spillLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageSpillLanguageID", spillLanguage.SpillLanguageID.ToString()), new[] { "SpillLanguageID" });
                }
            }

            Spill SpillSpillID = (from c in db.Spills where c.SpillID == spillLanguage.SpillID select c).FirstOrDefault();

            if (SpillSpillID == null)
            {
                spillLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillLanguageSpillID", spillLanguage.SpillID.ToString()), new[] { "SpillID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)spillLanguage.Language);
            if (spillLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                spillLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageLanguage"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(spillLanguage.SpillComment))
            {
                spillLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageSpillComment"), new[] { "SpillComment" });
            }

            //SpillComment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)spillLanguage.TranslationStatus);
            if (spillLanguage.TranslationStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                spillLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageTranslationStatus"), new[] { "TranslationStatus" });
            }

            if (spillLanguage.LastUpdateDate_UTC.Year == 1)
            {
                spillLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (spillLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                spillLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SpillLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spillLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                spillLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SpillLanguageLastUpdateContactTVItemID", spillLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    spillLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SpillLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                spillLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public SpillLanguage GetSpillLanguageWithSpillLanguageID(int SpillLanguageID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.SpillLanguageID == SpillLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<SpillLanguage> GetSpillLanguageList()
        {
            IQueryable<SpillLanguage> SpillLanguageQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            SpillLanguageQuery = EnhanceQueryStatements<SpillLanguage>(SpillLanguageQuery) as IQueryable<SpillLanguage>;

            return SpillLanguageQuery;
        }
        public SpillLanguageWeb GetSpillLanguageWebWithSpillLanguageID(int SpillLanguageID)
        {
            return FillSpillLanguageWeb().FirstOrDefault();

        }
        public IQueryable<SpillLanguageWeb> GetSpillLanguageWebList()
        {
            IQueryable<SpillLanguageWeb> SpillLanguageWebQuery = FillSpillLanguageWeb();

            SpillLanguageWebQuery = EnhanceQueryStatements<SpillLanguageWeb>(SpillLanguageWebQuery) as IQueryable<SpillLanguageWeb>;

            return SpillLanguageWebQuery;
        }
        public SpillLanguageReport GetSpillLanguageReportWithSpillLanguageID(int SpillLanguageID)
        {
            return FillSpillLanguageReport().FirstOrDefault();

        }
        public IQueryable<SpillLanguageReport> GetSpillLanguageReportList()
        {
            IQueryable<SpillLanguageReport> SpillLanguageReportQuery = FillSpillLanguageReport();

            SpillLanguageReportQuery = EnhanceQueryStatements<SpillLanguageReport>(SpillLanguageReportQuery) as IQueryable<SpillLanguageReport>;

            return SpillLanguageReportQuery;
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
        public bool Delete(SpillLanguage spillLanguage)
        {
            spillLanguage.ValidationResults = Validate(new ValidationContext(spillLanguage), ActionDBTypeEnum.Delete);
            if (spillLanguage.ValidationResults.Count() > 0) return false;

            db.SpillLanguages.Remove(spillLanguage);

            if (!TryToSave(spillLanguage)) return false;

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
        public IQueryable<SpillLanguage> GetRead()
        {
            IQueryable<SpillLanguage> spillLanguageQuery = db.SpillLanguages.AsNoTracking();

            return spillLanguageQuery;
        }
        public IQueryable<SpillLanguage> GetEdit()
        {
            IQueryable<SpillLanguage> spillLanguageQuery = db.SpillLanguages;

            return spillLanguageQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated SpillLanguageFillWeb
        private IQueryable<SpillLanguageWeb> FillSpillLanguageWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<SpillLanguageWeb>  SpillLanguageWebQuery = (from c in db.SpillLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new SpillLanguageWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        SpillLanguageID = c.SpillLanguageID,
                        SpillID = c.SpillID,
                        Language = c.Language,
                        SpillComment = c.SpillComment,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return SpillLanguageWebQuery;
        }
        #endregion Functions private Generated SpillLanguageFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
