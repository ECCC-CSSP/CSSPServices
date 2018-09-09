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
    public partial class SamplingPlanService
    {
        #region Functions private Generated FillSamplingPlan_B
        private IQueryable<SamplingPlan_B> FillSamplingPlan_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));
            List<EnumIDAndText> SamplingPlanTypeEnumList = enums.GetEnumTextOrderedList(typeof(SamplingPlanTypeEnum));
            List<EnumIDAndText> LabSheetTypeEnumList = enums.GetEnumTextOrderedList(typeof(LabSheetTypeEnum));

             IQueryable<SamplingPlan_B> SamplingPlan_BQuery = (from c in db.SamplingPlans
                let SamplingPlanReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ProvinceTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ProvinceTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let CreatorTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.CreatorTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let SamplingPlanFileTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SamplingPlanFileTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new SamplingPlan_B
                    {
                        SamplingPlanReportTest = SamplingPlanReportTest,
                        ProvinceTVItemLanguage = ProvinceTVItemLanguage,
                        CreatorTVItemLanguage = CreatorTVItemLanguage,
                        SamplingPlanFileTVItemLanguage = SamplingPlanFileTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        SampleTypeText = (from e in SampleTypeEnumList
                                where e.EnumID == (int?)c.SampleType
                                select e.EnumText).FirstOrDefault(),
                        SamplingPlanTypeText = (from e in SamplingPlanTypeEnumList
                                where e.EnumID == (int?)c.SamplingPlanType
                                select e.EnumText).FirstOrDefault(),
                        LabSheetTypeText = (from e in LabSheetTypeEnumList
                                where e.EnumID == (int?)c.LabSheetType
                                select e.EnumText).FirstOrDefault(),
                        SamplingPlanID = c.SamplingPlanID,
                        IsActive = c.IsActive,
                        SamplingPlanName = c.SamplingPlanName,
                        ForGroupName = c.ForGroupName,
                        SampleType = c.SampleType,
                        SamplingPlanType = c.SamplingPlanType,
                        LabSheetType = c.LabSheetType,
                        ProvinceTVItemID = c.ProvinceTVItemID,
                        CreatorTVItemID = c.CreatorTVItemID,
                        Year = c.Year,
                        AccessCode = c.AccessCode,
                        DailyDuplicatePrecisionCriteria = c.DailyDuplicatePrecisionCriteria,
                        IntertechDuplicatePrecisionCriteria = c.IntertechDuplicatePrecisionCriteria,
                        IncludeLaboratoryQAQC = c.IncludeLaboratoryQAQC,
                        ApprovalCode = c.ApprovalCode,
                        SamplingPlanFileTVItemID = c.SamplingPlanFileTVItemID,
                        AnalyzeMethodDefault = c.AnalyzeMethodDefault,
                        SampleMatrixDefault = c.SampleMatrixDefault,
                        LaboratoryDefault = c.LaboratoryDefault,
                        BackupDirectory = c.BackupDirectory,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return SamplingPlan_BQuery;
        }
        #endregion Functions private Generated FillSamplingPlan_B

    }
}
