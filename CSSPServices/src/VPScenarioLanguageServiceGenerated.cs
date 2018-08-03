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
    ///     <para>bonjour VPScenarioLanguage</para>
    /// </summary>
    public partial class VPScenarioLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPScenarioLanguage vpScenarioLanguage = validationContext.ObjectInstance as VPScenarioLanguage;
            vpScenarioLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpScenarioLanguage.VPScenarioLanguageID == 0)
                {
                    vpScenarioLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageVPScenarioLanguageID"), new[] { "VPScenarioLanguageID" });
                }

                if (!GetRead().Where(c => c.VPScenarioLanguageID == vpScenarioLanguage.VPScenarioLanguageID).Any())
                {
                    vpScenarioLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenarioLanguage", "VPScenarioLanguageVPScenarioLanguageID", vpScenarioLanguage.VPScenarioLanguageID.ToString()), new[] { "VPScenarioLanguageID" });
                }
            }

            VPScenario VPScenarioVPScenarioID = (from c in db.VPScenarios where c.VPScenarioID == vpScenarioLanguage.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioLanguageVPScenarioID", vpScenarioLanguage.VPScenarioID.ToString()), new[] { "VPScenarioID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)vpScenarioLanguage.Language);
            if (vpScenarioLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageLanguage"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(vpScenarioLanguage.VPScenarioName))
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageVPScenarioName"), new[] { "VPScenarioName" });
            }

            if (!string.IsNullOrWhiteSpace(vpScenarioLanguage.VPScenarioName) && vpScenarioLanguage.VPScenarioName.Length > 100)
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "VPScenarioLanguageVPScenarioName", "100"), new[] { "VPScenarioName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)vpScenarioLanguage.TranslationStatus);
            if (vpScenarioLanguage.TranslationStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageTranslationStatus"), new[] { "TranslationStatus" });
            }

            if (vpScenarioLanguage.LastUpdateDate_UTC.Year == 1)
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpScenarioLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                vpScenarioLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "VPScenarioLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpScenarioLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "VPScenarioLanguageLastUpdateContactTVItemID", vpScenarioLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    vpScenarioLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "VPScenarioLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                vpScenarioLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public VPScenarioLanguage GetVPScenarioLanguageWithVPScenarioLanguageID(int VPScenarioLanguageID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.VPScenarioLanguageID == VPScenarioLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<VPScenarioLanguage> GetVPScenarioLanguageList()
        {
            IQueryable<VPScenarioLanguage> VPScenarioLanguageQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            VPScenarioLanguageQuery = EnhanceQueryStatements<VPScenarioLanguage>(VPScenarioLanguageQuery) as IQueryable<VPScenarioLanguage>;

            return VPScenarioLanguageQuery;
        }
        public VPScenarioLanguageWeb GetVPScenarioLanguageWebWithVPScenarioLanguageID(int VPScenarioLanguageID)
        {
            return FillVPScenarioLanguageWeb().FirstOrDefault();

        }
        public IQueryable<VPScenarioLanguageWeb> GetVPScenarioLanguageWebList()
        {
            IQueryable<VPScenarioLanguageWeb> VPScenarioLanguageWebQuery = FillVPScenarioLanguageWeb();

            VPScenarioLanguageWebQuery = EnhanceQueryStatements<VPScenarioLanguageWeb>(VPScenarioLanguageWebQuery) as IQueryable<VPScenarioLanguageWeb>;

            return VPScenarioLanguageWebQuery;
        }
        public VPScenarioLanguageReport GetVPScenarioLanguageReportWithVPScenarioLanguageID(int VPScenarioLanguageID)
        {
            return FillVPScenarioLanguageReport().FirstOrDefault();

        }
        public IQueryable<VPScenarioLanguageReport> GetVPScenarioLanguageReportList()
        {
            IQueryable<VPScenarioLanguageReport> VPScenarioLanguageReportQuery = FillVPScenarioLanguageReport();

            VPScenarioLanguageReportQuery = EnhanceQueryStatements<VPScenarioLanguageReport>(VPScenarioLanguageReportQuery) as IQueryable<VPScenarioLanguageReport>;

            return VPScenarioLanguageReportQuery;
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
        public bool Delete(VPScenarioLanguage vpScenarioLanguage)
        {
            vpScenarioLanguage.ValidationResults = Validate(new ValidationContext(vpScenarioLanguage), ActionDBTypeEnum.Delete);
            if (vpScenarioLanguage.ValidationResults.Count() > 0) return false;

            db.VPScenarioLanguages.Remove(vpScenarioLanguage);

            if (!TryToSave(vpScenarioLanguage)) return false;

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
        public IQueryable<VPScenarioLanguage> GetRead()
        {
            IQueryable<VPScenarioLanguage> vpScenarioLanguageQuery = db.VPScenarioLanguages.AsNoTracking();

            return vpScenarioLanguageQuery;
        }
        public IQueryable<VPScenarioLanguage> GetEdit()
        {
            IQueryable<VPScenarioLanguage> vpScenarioLanguageQuery = db.VPScenarioLanguages;

            return vpScenarioLanguageQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated VPScenarioLanguageFillWeb
        private IQueryable<VPScenarioLanguageWeb> FillVPScenarioLanguageWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<VPScenarioLanguageWeb>  VPScenarioLanguageWebQuery = (from c in db.VPScenarioLanguages
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new VPScenarioLanguageWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TranslationStatusText = (from e in TranslationStatusEnumList
                                where e.EnumID == (int?)c.TranslationStatus
                                select e.EnumText).FirstOrDefault(),
                        VPScenarioLanguageID = c.VPScenarioLanguageID,
                        VPScenarioID = c.VPScenarioID,
                        Language = c.Language,
                        VPScenarioName = c.VPScenarioName,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return VPScenarioLanguageWebQuery;
        }
        #endregion Functions private Generated VPScenarioLanguageFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}