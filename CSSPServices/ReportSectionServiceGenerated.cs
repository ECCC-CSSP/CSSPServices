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
    ///     <para>bonjour ReportSection</para>
    /// </summary>
    public partial class ReportSectionService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportSectionService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ReportSection reportSection = validationContext.ObjectInstance as ReportSection;
            reportSection.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (reportSection.ReportSectionID == 0)
                {
                    reportSection.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionReportSectionID), new[] { "ReportSectionID" });
                }

                if (!GetRead().Where(c => c.ReportSectionID == reportSection.ReportSectionID).Any())
                {
                    reportSection.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSection, CSSPModelsRes.ReportSectionReportSectionID, reportSection.ReportSectionID.ToString()), new[] { "ReportSectionID" });
                }
            }

            ReportType ReportTypeReportTypeID = (from c in db.ReportTypes where c.ReportTypeID == reportSection.ReportTypeID select c).FirstOrDefault();

            if (ReportTypeReportTypeID == null)
            {
                reportSection.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportType, CSSPModelsRes.ReportSectionReportTypeID, (reportSection.ReportTypeID == null ? "" : reportSection.ReportTypeID.ToString())), new[] { "ReportTypeID" });
            }

            if (reportSection.TVItemID != null)
            {
                TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == reportSection.TVItemID select c).FirstOrDefault();

                if (TVItemTVItemID == null)
                {
                    reportSection.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportSectionTVItemID, (reportSection.TVItemID == null ? "" : reportSection.TVItemID.ToString())), new[] { "TVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Error,
                    };
                    if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                    {
                        reportSection.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportSectionTVItemID, "Error"), new[] { "TVItemID" });
                    }
                }
            }

            if (reportSection.Ordinal < 0 || reportSection.Ordinal > 1000)
            {
                reportSection.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ReportSectionOrdinal, "0", "1000"), new[] { "Ordinal" });
            }

            if (reportSection.ParentReportSectionID != null)
            {
                ReportSection ReportSectionParentReportSectionID = (from c in db.ReportSections where c.ReportSectionID == reportSection.ParentReportSectionID select c).FirstOrDefault();

                if (ReportSectionParentReportSectionID == null)
                {
                    reportSection.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSection, CSSPModelsRes.ReportSectionParentReportSectionID, (reportSection.ParentReportSectionID == null ? "" : reportSection.ParentReportSectionID.ToString())), new[] { "ParentReportSectionID" });
                }
            }

            if (reportSection.Year != null)
            {
                if (reportSection.Year < 1979 || reportSection.Year > 2050)
                {
                    reportSection.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ReportSectionYear, "1979", "2050"), new[] { "Year" });
                }
            }

            if (reportSection.TemplateReportSectionID != null)
            {
                ReportSection ReportSectionTemplateReportSectionID = (from c in db.ReportSections where c.ReportSectionID == reportSection.TemplateReportSectionID select c).FirstOrDefault();

                if (ReportSectionTemplateReportSectionID == null)
                {
                    reportSection.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSection, CSSPModelsRes.ReportSectionTemplateReportSectionID, (reportSection.TemplateReportSectionID == null ? "" : reportSection.TemplateReportSectionID.ToString())), new[] { "TemplateReportSectionID" });
                }
            }

            if (reportSection.LastUpdateDate_UTC.Year == 1)
            {
                reportSection.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (reportSection.LastUpdateDate_UTC.Year < 1980)
                {
                reportSection.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ReportSectionLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == reportSection.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                reportSection.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportSectionLastUpdateContactTVItemID, (reportSection.LastUpdateContactTVItemID == null ? "" : reportSection.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    reportSection.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportSectionLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                reportSection.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public ReportSection GetReportSectionWithReportSectionID(int ReportSectionID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<ReportSection> reportSectionQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.ReportSectionID == ReportSectionID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return reportSectionQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillReportSectionWeb(reportSectionQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillReportSectionReport(reportSectionQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<ReportSection> GetReportSectionList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<ReportSection> reportSectionQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return reportSectionQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillReportSectionWeb(reportSectionQuery, FilterAndOrderText).Take(MaxGetCount);
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillReportSectionReport(reportSectionQuery, FilterAndOrderText).Take(MaxGetCount);
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(ReportSection reportSection)
        {
            reportSection.ValidationResults = Validate(new ValidationContext(reportSection), ActionDBTypeEnum.Create);
            if (reportSection.ValidationResults.Count() > 0) return false;

            db.ReportSections.Add(reportSection);

            if (!TryToSave(reportSection)) return false;

            return true;
        }
        public bool Delete(ReportSection reportSection)
        {
            reportSection.ValidationResults = Validate(new ValidationContext(reportSection), ActionDBTypeEnum.Delete);
            if (reportSection.ValidationResults.Count() > 0) return false;

            db.ReportSections.Remove(reportSection);

            if (!TryToSave(reportSection)) return false;

            return true;
        }
        public bool Update(ReportSection reportSection)
        {
            reportSection.ValidationResults = Validate(new ValidationContext(reportSection), ActionDBTypeEnum.Update);
            if (reportSection.ValidationResults.Count() > 0) return false;

            db.ReportSections.Update(reportSection);

            if (!TryToSave(reportSection)) return false;

            return true;
        }
        public IQueryable<ReportSection> GetRead()
        {
            return db.ReportSections.AsNoTracking();
        }
        public IQueryable<ReportSection> GetEdit()
        {
            return db.ReportSections;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated ReportSectionFillWeb
        private IQueryable<ReportSection> FillReportSectionWeb(IQueryable<ReportSection> reportSectionQuery, string FilterAndOrderText)
        {
            reportSectionQuery = (from c in reportSectionQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ReportSectionName = (from cl in db.ReportSectionLanguages
                    where cl.ReportSectionID == c.ReportSectionID
                    && cl.Language == LanguageRequest
                    select cl.ReportSectionName).FirstOrDefault()
                let ReportSectionText = (from cl in db.ReportSectionLanguages
                    where cl.ReportSectionID == c.ReportSectionID
                    && cl.Language == LanguageRequest
                    select cl.ReportSectionText).FirstOrDefault()
                    select new ReportSection
                    {
                        ReportSectionID = c.ReportSectionID,
                        ReportTypeID = c.ReportTypeID,
                        TVItemID = c.TVItemID,
                        Ordinal = c.Ordinal,
                        IsStatic = c.IsStatic,
                        ParentReportSectionID = c.ParentReportSectionID,
                        Year = c.Year,
                        Locked = c.Locked,
                        TemplateReportSectionID = c.TemplateReportSectionID,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        ReportSectionWeb = new ReportSectionWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            ReportSectionName = ReportSectionName,
                            ReportSectionText = ReportSectionText,
                        },
                        ReportSectionReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return reportSectionQuery;
        }
        #endregion Functions private Generated ReportSectionFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(ReportSection reportSection)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                reportSection.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
