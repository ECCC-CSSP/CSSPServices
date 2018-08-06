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
    ///     <para>bonjour InfrastructureLanguage</para>
    /// </summary>
    public partial class InfrastructureLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            InfrastructureLanguage infrastructureLanguage = validationContext.ObjectInstance as InfrastructureLanguage;
            infrastructureLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (infrastructureLanguage.InfrastructureLanguageID == 0)
                {
                    infrastructureLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageInfrastructureLanguageID"), new[] { "InfrastructureLanguageID" });
                }

                if (!(from c in db.InfrastructureLanguages select c).Where(c => c.InfrastructureLanguageID == infrastructureLanguage.InfrastructureLanguageID).Any())
                {
                    infrastructureLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageInfrastructureLanguageID", infrastructureLanguage.InfrastructureLanguageID.ToString()), new[] { "InfrastructureLanguageID" });
                }
            }

            Infrastructure InfrastructureInfrastructureID = (from c in db.Infrastructures where c.InfrastructureID == infrastructureLanguage.InfrastructureID select c).FirstOrDefault();

            if (InfrastructureInfrastructureID == null)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureLanguageInfrastructureID", infrastructureLanguage.InfrastructureID.ToString()), new[] { "InfrastructureID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)infrastructureLanguage.Language);
            if (infrastructureLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageLanguage"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(infrastructureLanguage.Comment))
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageComment"), new[] { "Comment" });
            }

            //Comment has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)infrastructureLanguage.TranslationStatus);
            if (infrastructureLanguage.TranslationStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageTranslationStatus"), new[] { "TranslationStatus" });
            }

            if (infrastructureLanguage.LastUpdateDate_UTC.Year == 1)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (infrastructureLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                infrastructureLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "InfrastructureLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == infrastructureLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureLanguageLastUpdateContactTVItemID", infrastructureLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    infrastructureLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                infrastructureLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public InfrastructureLanguage GetInfrastructureLanguageWithInfrastructureLanguageID(int InfrastructureLanguageID)
        {
            return (from c in db.InfrastructureLanguages
                    where c.InfrastructureLanguageID == InfrastructureLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<InfrastructureLanguage> GetInfrastructureLanguageList()
        {
            IQueryable<InfrastructureLanguage> InfrastructureLanguageQuery = (from c in db.InfrastructureLanguages select c);

            InfrastructureLanguageQuery = EnhanceQueryStatements<InfrastructureLanguage>(InfrastructureLanguageQuery) as IQueryable<InfrastructureLanguage>;

            return InfrastructureLanguageQuery;
        }
        public InfrastructureLanguageWeb GetInfrastructureLanguageWebWithInfrastructureLanguageID(int InfrastructureLanguageID)
        {
            return FillInfrastructureLanguageWeb().Where(c => c.InfrastructureLanguageID == InfrastructureLanguageID).FirstOrDefault();

        }
        public IQueryable<InfrastructureLanguageWeb> GetInfrastructureLanguageWebList()
        {
            IQueryable<InfrastructureLanguageWeb> InfrastructureLanguageWebQuery = FillInfrastructureLanguageWeb();

            InfrastructureLanguageWebQuery = EnhanceQueryStatements<InfrastructureLanguageWeb>(InfrastructureLanguageWebQuery) as IQueryable<InfrastructureLanguageWeb>;

            return InfrastructureLanguageWebQuery;
        }
        public InfrastructureLanguageReport GetInfrastructureLanguageReportWithInfrastructureLanguageID(int InfrastructureLanguageID)
        {
            return FillInfrastructureLanguageReport().Where(c => c.InfrastructureLanguageID == InfrastructureLanguageID).FirstOrDefault();

        }
        public IQueryable<InfrastructureLanguageReport> GetInfrastructureLanguageReportList()
        {
            IQueryable<InfrastructureLanguageReport> InfrastructureLanguageReportQuery = FillInfrastructureLanguageReport();

            InfrastructureLanguageReportQuery = EnhanceQueryStatements<InfrastructureLanguageReport>(InfrastructureLanguageReportQuery) as IQueryable<InfrastructureLanguageReport>;

            return InfrastructureLanguageReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(InfrastructureLanguage infrastructureLanguage)
        {
            infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Create);
            if (infrastructureLanguage.ValidationResults.Count() > 0) return false;

            db.InfrastructureLanguages.Add(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        public bool Delete(InfrastructureLanguage infrastructureLanguage)
        {
            infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Delete);
            if (infrastructureLanguage.ValidationResults.Count() > 0) return false;

            db.InfrastructureLanguages.Remove(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        public bool Update(InfrastructureLanguage infrastructureLanguage)
        {
            infrastructureLanguage.ValidationResults = Validate(new ValidationContext(infrastructureLanguage), ActionDBTypeEnum.Update);
            if (infrastructureLanguage.ValidationResults.Count() > 0) return false;

            db.InfrastructureLanguages.Update(infrastructureLanguage);

            if (!TryToSave(infrastructureLanguage)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated InfrastructureLanguageFillWeb
        private IQueryable<InfrastructureLanguageWeb> FillInfrastructureLanguageWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<InfrastructureLanguageWeb> InfrastructureLanguageWebQuery = (from c in db.InfrastructureLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new InfrastructureLanguageWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        InfrastructureLanguageID = c.InfrastructureLanguageID,
                        InfrastructureID = c.InfrastructureID,
                        Language = c.Language,
                        Comment = c.Comment,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return InfrastructureLanguageWebQuery;
        }
        #endregion Functions private Generated InfrastructureLanguageFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(InfrastructureLanguage infrastructureLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                infrastructureLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
