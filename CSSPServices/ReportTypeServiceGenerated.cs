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
        public ReportTypeService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeReportTypeID), new[] { "ReportTypeID" });
                }

                if (!GetRead().Where(c => c.ReportTypeID == reportType.ReportTypeID).Any())
                {
                    reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportType, CSSPModelsRes.ReportTypeReportTypeID, reportType.ReportTypeID.ToString()), new[] { "ReportTypeID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)reportType.TVType);
            if (reportType.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeTVType), new[] { "TVType" });
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)reportType.FileType);
            if (reportType.FileType == FileTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeFileType), new[] { "FileType" });
            }

            if (string.IsNullOrWhiteSpace(reportType.UniqueCode))
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeUniqueCode), new[] { "UniqueCode" });
            }

            if (!string.IsNullOrWhiteSpace(reportType.UniqueCode) && reportType.UniqueCode.Length > 100)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportTypeUniqueCode, "100"), new[] { "UniqueCode" });
            }

            if (reportType.LastUpdateDate_UTC.Year == 1)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (reportType.LastUpdateDate_UTC.Year < 1980)
                {
                reportType.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ReportTypeLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == reportType.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                reportType.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportTypeLastUpdateContactTVItemID, (reportType.LastUpdateContactTVItemID == null ? "" : reportType.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportTypeLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public ReportType GetReportTypeWithReportTypeID(int ReportTypeID, GetParam getParam)
        {
            IQueryable<ReportType> reportTypeQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ReportTypeID == ReportTypeID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return reportTypeQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillReportTypeWeb(reportTypeQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillReportTypeReport(reportTypeQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ReportType> GetReportTypeList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<ReportType> reportTypeQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            reportTypeQuery  = reportTypeQuery.OrderByDescending(c => c.ReportTypeID);
                        }
                        reportTypeQuery = reportTypeQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return reportTypeQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            reportTypeQuery = FillReportTypeWeb(reportTypeQuery, FilterAndOrderText).OrderByDescending(c => c.ReportTypeID);
                        }
                        reportTypeQuery = FillReportTypeWeb(reportTypeQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return reportTypeQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            reportTypeQuery = FillReportTypeReport(reportTypeQuery, FilterAndOrderText).OrderByDescending(c => c.ReportTypeID);
                        }
                        reportTypeQuery = FillReportTypeReport(reportTypeQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return reportTypeQuery;
                    }
                default:
                    return null;
            }
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
            return db.ReportTypes.AsNoTracking();
        }
        public IQueryable<ReportType> GetEdit()
        {
            return db.ReportTypes;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ReportTypeFillWeb
        private IQueryable<ReportType> FillReportTypeWeb(IQueryable<ReportType> reportTypeQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);


            reportTypeQuery = (from c in reportTypeQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ReportType
                    {
                        ReportTypeID = c.ReportTypeID,
                        TVType = c.TVType,
                        FileType = c.FileType,
                        UniqueCode = c.UniqueCode,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ReportTypeWeb = new ReportTypeWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        ReportTypeReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return reportTypeQuery;
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