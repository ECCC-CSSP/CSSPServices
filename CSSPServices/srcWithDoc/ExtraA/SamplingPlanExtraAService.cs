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
        #region Functions private Generated FillSamplingPlanExtraA
        private IQueryable<SamplingPlanExtraA> FillSamplingPlanExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));
            List<EnumIDAndText> SamplingPlanTypeEnumList = enums.GetEnumTextOrderedList(typeof(SamplingPlanTypeEnum));
            List<EnumIDAndText> LabSheetTypeEnumList = enums.GetEnumTextOrderedList(typeof(LabSheetTypeEnum));

             IQueryable<SamplingPlanExtraA> SamplingPlanExtraAQuery = (from c in db.SamplingPlans
                let ProvinceText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ProvinceTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let CreatorName = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.CreatorTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SamplingPlanFileName = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SamplingPlanFileTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SampleTypeText = (from e in SampleTypeEnumList
                    where e.EnumID == (int?)c.SampleType
                    select e.EnumText).FirstOrDefault()
                let SamplingPlanTypeText = (from e in SamplingPlanTypeEnumList
                    where e.EnumID == (int?)c.SamplingPlanType
                    select e.EnumText).FirstOrDefault()
                let LabSheetTypeText = (from e in LabSheetTypeEnumList
                    where e.EnumID == (int?)c.LabSheetType
                    select e.EnumText).FirstOrDefault()
                    select new SamplingPlanExtraA
                    {
                        ProvinceText = ProvinceText,
                        CreatorName = CreatorName,
                        SamplingPlanFileName = SamplingPlanFileName,
                        LastUpdateContactText = LastUpdateContactText,
                        SampleTypeText = SampleTypeText,
                        SamplingPlanTypeText = SamplingPlanTypeText,
                        LabSheetTypeText = LabSheetTypeText,
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

            return SamplingPlanExtraAQuery;
        }
        #endregion Functions private Generated FillSamplingPlanExtraA

    }
}