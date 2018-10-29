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
        #region Functions private Generated FillMWQMAnalysisReportParameterExtraB
        private IQueryable<MWQMAnalysisReportParameterExtraB> FillMWQMAnalysisReportParameterExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AnalysisReportExportCommandEnumList = enums.GetEnumTextOrderedList(typeof(AnalysisReportExportCommandEnum));

             IQueryable<MWQMAnalysisReportParameterExtraB> MWQMAnalysisReportParameterExtraBQuery = (from c in db.MWQMAnalysisReportParameters
                let MWQMAnalysisReportParameterReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ExcelTVFileText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ExcelTVFileTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let CommandText = (from e in AnalysisReportExportCommandEnumList
                    where e.EnumID == (int?)c.Command
                    select e.EnumText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new MWQMAnalysisReportParameterExtraB
                    {
                        MWQMAnalysisReportParameterReportTest = MWQMAnalysisReportParameterReportTest,
                        ExcelTVFileText = ExcelTVFileText,
                        CommandText = CommandText,
                        LastUpdateContactText = LastUpdateContactText,
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
                    }).AsNoTracking();

            return MWQMAnalysisReportParameterExtraBQuery;
        }
        #endregion Functions private Generated FillMWQMAnalysisReportParameterExtraB

    }
}
