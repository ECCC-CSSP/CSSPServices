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
    public partial class LabSheetService
    {
        #region Functions private Generated LabSheetFillReport
        private IQueryable<LabSheetReport> FillLabSheetReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SamplingPlanTypeEnumList = enums.GetEnumTextOrderedList(typeof(SamplingPlanTypeEnum));
            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));
            List<EnumIDAndText> LabSheetTypeEnumList = enums.GetEnumTextOrderedList(typeof(LabSheetTypeEnum));
            List<EnumIDAndText> LabSheetStatusEnumList = enums.GetEnumTextOrderedList(typeof(LabSheetStatusEnum));

             IQueryable<LabSheetReport>  LabSheetReportQuery = (from c in db.LabSheets
                let SubsectorTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let MWQMRunTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMRunTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let AcceptedOrRejectedByContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.AcceptedOrRejectedByContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new LabSheetReport
                    {
                        LabSheetReportTest = "Testing Report",
                        SubsectorTVItemLanguage = SubsectorTVItemLanguage,
                        MWQMRunTVItemLanguage = MWQMRunTVItemLanguage,
                        AcceptedOrRejectedByContactTVItemLanguage = AcceptedOrRejectedByContactTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        SamplingPlanTypeText = (from e in SamplingPlanTypeEnumList
                                where e.EnumID == (int?)c.SamplingPlanType
                                select e.EnumText).FirstOrDefault(),
                        SampleTypeText = (from e in SampleTypeEnumList
                                where e.EnumID == (int?)c.SampleType
                                select e.EnumText).FirstOrDefault(),
                        LabSheetTypeText = (from e in LabSheetTypeEnumList
                                where e.EnumID == (int?)c.LabSheetType
                                select e.EnumText).FirstOrDefault(),
                        LabSheetStatusText = (from e in LabSheetStatusEnumList
                                where e.EnumID == (int?)c.LabSheetStatus
                                select e.EnumText).FirstOrDefault(),
                        LabSheetID = c.LabSheetID,
                        OtherServerLabSheetID = c.OtherServerLabSheetID,
                        SamplingPlanID = c.SamplingPlanID,
                        SamplingPlanName = c.SamplingPlanName,
                        Year = c.Year,
                        Month = c.Month,
                        Day = c.Day,
                        RunNumber = c.RunNumber,
                        SubsectorTVItemID = c.SubsectorTVItemID,
                        MWQMRunTVItemID = c.MWQMRunTVItemID,
                        SamplingPlanType = c.SamplingPlanType,
                        SampleType = c.SampleType,
                        LabSheetType = c.LabSheetType,
                        LabSheetStatus = c.LabSheetStatus,
                        FileName = c.FileName,
                        FileLastModifiedDate_Local = c.FileLastModifiedDate_Local,
                        FileContent = c.FileContent,
                        AcceptedOrRejectedByContactTVItemID = c.AcceptedOrRejectedByContactTVItemID,
                        AcceptedOrRejectedDateTime = c.AcceptedOrRejectedDateTime,
                        RejectReason = c.RejectReason,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return LabSheetReportQuery;
        }
        #endregion Functions private Generated LabSheetFillReport

    }
}
