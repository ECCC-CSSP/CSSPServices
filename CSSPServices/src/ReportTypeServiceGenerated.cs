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
    ///     <para>bonjour ReportType</para>
    /// </summary>
    public partial class ReportTypeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportTypeService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ReportType reportType = validationContext.ObjectInstance as ReportType;
            reportType.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (reportType.ReportTypeID == 0)
                {
                    reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ReportTypeReportTypeID"), new[] { "ReportTypeID" });
                }

                if (!GetRead().Where(c => c.ReportTypeID == reportType.ReportTypeID).Any())
                {
                    reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeReportTypeID", reportType.ReportTypeID.ToString()), new[] { "ReportTypeID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)reportType.TVType);
            if (reportType.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ReportTypeTVType"), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)reportType.FileType);
            if (reportType.FileType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ReportTypeFileType"), new[] { "FileType" });
            }

            if (string.IsNullOrWhiteSpace(reportType.UniqueCode))
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ReportTypeUniqueCode"), new[] { "UniqueCode" });
            }

            if (!string.IsNullOrWhiteSpace(reportType.UniqueCode) && reportType.UniqueCode.Length > 100)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportTypeUniqueCode", "100"), new[] { "UniqueCode" });
            }

            if (reportType.LastUpdateDate_UTC.Year == 1)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ReportTypeLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (reportType.LastUpdateDate_UTC.Year < 1980)
                {
                reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ReportTypeLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == reportType.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ReportTypeLastUpdateContactTVItemID", reportType.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ReportTypeLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                reportType.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ReportType GetReportTypeWithReportTypeID(int ReportTypeID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.ReportTypeID == ReportTypeID
                    select c).FirstOrDefault();

        }
        public IQueryable<ReportType> GetReportTypeList()
        {
            IQueryable<ReportType> ReportTypeQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            ReportTypeQuery = EnhanceQueryStatements<ReportType>(ReportTypeQuery) as IQueryable<ReportType>;

            return ReportTypeQuery;
        }
        public ReportTypeWeb GetReportTypeWebWithReportTypeID(int ReportTypeID)
        {
            return FillReportTypeWeb().FirstOrDefault();

        }
        public IQueryable<ReportTypeWeb> GetReportTypeWebList()
        {
            IQueryable<ReportTypeWeb> ReportTypeWebQuery = FillReportTypeWeb();

            ReportTypeWebQuery = EnhanceQueryStatements<ReportTypeWeb>(ReportTypeWebQuery) as IQueryable<ReportTypeWeb>;

            return ReportTypeWebQuery;
        }
        public ReportTypeReport GetReportTypeReportWithReportTypeID(int ReportTypeID)
        {
            return FillReportTypeReport().FirstOrDefault();

        }
        public IQueryable<ReportTypeReport> GetReportTypeReportList()
        {
            IQueryable<ReportTypeReport> ReportTypeReportQuery = FillReportTypeReport();

            ReportTypeReportQuery = EnhanceQueryStatements<ReportTypeReport>(ReportTypeReportQuery) as IQueryable<ReportTypeReport>;

            return ReportTypeReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(ReportType reportType)
        {
            reportType.ValidationResults = Validate(new ValidationContext(reportType), ActionDBTypeEnum.Create);
            if (reportType.ValidationResults.Count() > 0) return false;

            db.ReportTypes.Add(reportType);

            if (!TryToSave(reportType)) return false;

            return true;
        }
        public bool Delete(ReportType reportType)
        {
            reportType.ValidationResults = Validate(new ValidationContext(reportType), ActionDBTypeEnum.Delete);
            if (reportType.ValidationResults.Count() > 0) return false;

            db.ReportTypes.Remove(reportType);

            if (!TryToSave(reportType)) return false;

            return true;
        }
        public bool Update(ReportType reportType)
        {
            reportType.ValidationResults = Validate(new ValidationContext(reportType), ActionDBTypeEnum.Update);
            if (reportType.ValidationResults.Count() > 0) return false;

            db.ReportTypes.Update(reportType);

            if (!TryToSave(reportType)) return false;

            return true;
        }
        public IQueryable<ReportType> GetRead()
        {
            IQueryable<ReportType> reportTypeQuery = db.ReportTypes.AsNoTracking();

            return reportTypeQuery;
        }
        public IQueryable<ReportType> GetEdit()
        {
            IQueryable<ReportType> reportTypeQuery = db.ReportTypes;

            return reportTypeQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ReportTypeFillWeb
        private IQueryable<ReportTypeWeb> FillReportTypeWeb()
        {
            Enums enums = new Enums(LanguageRequest);


             IQueryable<ReportTypeWeb>  ReportTypeWebQuery = (from c in db.ReportTypes
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ReportTypeWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        ReportTypeID = c.ReportTypeID,
                        TVType = c.TVType,
                        FileType = c.FileType,
                        UniqueCode = c.UniqueCode,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return ReportTypeWebQuery;
        }
        #endregion Functions private Generated ReportTypeFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(ReportType reportType)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                reportType.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}