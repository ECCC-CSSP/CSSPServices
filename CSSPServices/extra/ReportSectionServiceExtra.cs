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
    public partial class ReportSectionService
    {
        #region Functions private Generated ReportSectionFillReport
        private IQueryable<ReportSectionReport> FillReportSectionReport()
        {
             IQueryable<ReportSectionReport>  ReportSectionReportQuery = (from c in db.ReportSections
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let ReportSectionName = (from cl in db.ReportSectionLanguages
                    where cl.ReportSectionID == c.ReportSectionID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let ReportSectionText = (from cl in db.ReportSectionLanguages
                    where cl.ReportSectionID == c.ReportSectionID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ReportSectionReport
                    {
                        ReportSectionReportTest = "Testing Report",
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        ReportSectionName = ReportSectionName,
                        ReportSectionText = ReportSectionText,
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
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ReportSectionReportQuery;
        }
        #endregion Functions private Generated ReportSectionFillReport

    }
}
