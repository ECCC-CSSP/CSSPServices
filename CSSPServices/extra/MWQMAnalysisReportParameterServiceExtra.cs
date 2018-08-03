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
    public partial class MWQMAnalysisReportParameterService
    {
        #region Functions private Generated MWQMAnalysisReportParameterFillReport
        private IQueryable<MWQMAnalysisReportParameterReport> FillMWQMAnalysisReportParameterReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AnalysisReportExportCommandEnumList = enums.GetEnumTextOrderedList(typeof(AnalysisReportExportCommandEnum));

             IQueryable<MWQMAnalysisReportParameterReport>  MWQMAnalysisReportParameterReportQuery = (from c in db.MWQMAnalysisReportParameters
                let ExcelTVFileTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ExcelTVFileTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMAnalysisReportParameterReport
                    {
                        MWQMAnalysisReportParameterReportTest = "Testing Report",
                        ExcelTVFileTVItemLanguage = ExcelTVFileTVItemLanguage,
                        CommandText = (from e in AnalysisReportExportCommandEnumList
                                where e.EnumID == (int?)c.Command
                                select e.EnumText).FirstOrDefault(),
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MWQMAnalysisReportParameterID = c.MWQMAnalysisReportParameterID,
                        SubsectorTVItemID = c.SubsectorTVItemID,
                        AnalysisName = c.AnalysisName,
                        AnalysisReportYear = c.AnalysisReportYear,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        AnalysisCalculationType = c.AnalysisCalculationType,
                        NumberOfRuns = c.NumberOfRuns,
                        FullYear = c.FullYear,
                        SalinityHighlightDeviationFromAverage = c.SalinityHighlightDeviationFromAverage,
                        ShortRangeNumberOfDays = c.ShortRangeNumberOfDays,
                        MidRangeNumberOfDays = c.MidRangeNumberOfDays,
                        DryLimit24h = c.DryLimit24h,
                        DryLimit48h = c.DryLimit48h,
                        DryLimit72h = c.DryLimit72h,
                        DryLimit96h = c.DryLimit96h,
                        WetLimit24h = c.WetLimit24h,
                        WetLimit48h = c.WetLimit48h,
                        WetLimit72h = c.WetLimit72h,
                        WetLimit96h = c.WetLimit96h,
                        RunsToOmit = c.RunsToOmit,
                        ShowDataTypes = c.ShowDataTypes,
                        ExcelTVFileTVItemID = c.ExcelTVFileTVItemID,
                        Command = c.Command,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return MWQMAnalysisReportParameterReportQuery;
        }
        #endregion Functions private Generated MWQMAnalysisReportParameterFillReport

    }
}
