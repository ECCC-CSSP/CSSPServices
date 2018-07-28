using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class SamplingPlanService 
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        #endregion Functions public

        #region Functions private
        private IQueryable<SamplingPlan> FillSamplingPlanReport(IQueryable<SamplingPlan> samplingPlanQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));
            List<EnumIDAndText> SamplingPlanTypeEnumList = enums.GetEnumTextOrderedList(typeof(SamplingPlanTypeEnum));
            List<EnumIDAndText> LabSheetTypeEnumList = enums.GetEnumTextOrderedList(typeof(LabSheetTypeEnum));

            samplingPlanQuery = (from c in samplingPlanQuery
                                 let ProvinceTVText = (from cl in db.TVItemLanguages
                                                       where cl.TVItemID == c.ProvinceTVItemID
                                                       && cl.Language == LanguageRequest
                                                       select cl.TVText).FirstOrDefault()
                                 let CreatorTVText = (from cl in db.TVItemLanguages
                                                      where cl.TVItemID == c.CreatorTVItemID
                                                      && cl.Language == LanguageRequest
                                                      select cl.TVText).FirstOrDefault()
                                 let SamplingPlanFileTVText = (from cl in db.TVItemLanguages
                                                               where cl.TVItemID == c.SamplingPlanFileTVItemID
                                                               && cl.Language == LanguageRequest
                                                               select cl.TVText).FirstOrDefault()
                                 let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                && cl.Language == LanguageRequest
                                                                select cl.TVText).FirstOrDefault()
                                 select new SamplingPlan
                                 {
                                     SamplingPlanID = c.SamplingPlanID,
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
                                     SamplingPlanWeb = new SamplingPlanWeb
                                     {
                                         ProvinceTVText = ProvinceTVText,
                                         CreatorTVText = CreatorTVText,
                                         SamplingPlanFileTVText = SamplingPlanFileTVText,
                                         LastUpdateContactTVText = LastUpdateContactTVText,
                                         SampleTypeText = (from e in SampleTypeEnumList
                                                           where e.EnumID == (int?)c.SampleType
                                                           select e.EnumText).FirstOrDefault(),
                                         SamplingPlanTypeText = (from e in SamplingPlanTypeEnumList
                                                                 where e.EnumID == (int?)c.SamplingPlanType
                                                                 select e.EnumText).FirstOrDefault(),
                                         LabSheetTypeText = (from e in LabSheetTypeEnumList
                                                             where e.EnumID == (int?)c.LabSheetType
                                                             select e.EnumText).FirstOrDefault(),
                                     },
                                     SamplingPlanReport = new SamplingPlanReport
                                     {
                                         SamplingPlanReportTest = "SamplingPlanReportTest",
                                     },
                                     HasErrors = false,
                                     ValidationResults = null,
                                 });

            return samplingPlanQuery;
        }
        #endregion Functions private
    }
}
