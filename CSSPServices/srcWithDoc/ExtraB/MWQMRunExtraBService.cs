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
    public partial class MWQMRunService
    {
        #region Functions private Generated FillMWQMRunExtraB
        private IQueryable<MWQMRunExtraB> FillMWQMRunExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));
            List<EnumIDAndText> BeaufortScaleEnumList = enums.GetEnumTextOrderedList(typeof(BeaufortScaleEnum));
            List<EnumIDAndText> AnalyzeMethodEnumList = enums.GetEnumTextOrderedList(typeof(AnalyzeMethodEnum));
            List<EnumIDAndText> SampleMatrixEnumList = enums.GetEnumTextOrderedList(typeof(SampleMatrixEnum));
            List<EnumIDAndText> LaboratoryEnumList = enums.GetEnumTextOrderedList(typeof(LaboratoryEnum));
            List<EnumIDAndText> SampleStatusEnumList = enums.GetEnumTextOrderedList(typeof(SampleStatusEnum));
            List<EnumIDAndText> TideTextEnumList = enums.GetEnumTextOrderedList(typeof(TideTextEnum));

             IQueryable<MWQMRunExtraB> MWQMRunExtraBQuery = (from c in db.MWQMRuns
                let MWQMRunReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SubsectorText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMRunText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMRunTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LabSampleApprovalContactName = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LabSampleApprovalContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let RunSampleTypeText = (from e in SampleTypeEnumList
                    where e.EnumID == (int?)c.RunSampleType
                    select e.EnumText).FirstOrDefault()
                let SeaStateAtStart_BeaufortScaleText = (from e in BeaufortScaleEnumList
                    where e.EnumID == (int?)c.SeaStateAtStart_BeaufortScale
                    select e.EnumText).FirstOrDefault()
                let SeaStateAtEnd_BeaufortScaleText = (from e in BeaufortScaleEnumList
                    where e.EnumID == (int?)c.SeaStateAtEnd_BeaufortScale
                    select e.EnumText).FirstOrDefault()
                let AnalyzeMethodText = (from e in AnalyzeMethodEnumList
                    where e.EnumID == (int?)c.AnalyzeMethod
                    select e.EnumText).FirstOrDefault()
                let SampleMatrixText = (from e in SampleMatrixEnumList
                    where e.EnumID == (int?)c.SampleMatrix
                    select e.EnumText).FirstOrDefault()
                let LaboratoryText = (from e in LaboratoryEnumList
                    where e.EnumID == (int?)c.Laboratory
                    select e.EnumText).FirstOrDefault()
                let SampleStatusText = (from e in SampleStatusEnumList
                    where e.EnumID == (int?)c.SampleStatus
                    select e.EnumText).FirstOrDefault()
                let Tide_StartText = (from e in TideTextEnumList
                    where e.EnumID == (int?)c.Tide_Start
                    select e.EnumText).FirstOrDefault()
                let Tide_EndText = (from e in TideTextEnumList
                    where e.EnumID == (int?)c.Tide_End
                    select e.EnumText).FirstOrDefault()
                    select new MWQMRunExtraB
                    {
                        MWQMRunReportTest = MWQMRunReportTest,
                        SubsectorText = SubsectorText,
                        MWQMRunText = MWQMRunText,
                        LabSampleApprovalContactName = LabSampleApprovalContactName,
                        LastUpdateContactText = LastUpdateContactText,
                        RunSampleTypeText = RunSampleTypeText,
                        SeaStateAtStart_BeaufortScaleText = SeaStateAtStart_BeaufortScaleText,
                        SeaStateAtEnd_BeaufortScaleText = SeaStateAtEnd_BeaufortScaleText,
                        AnalyzeMethodText = AnalyzeMethodText,
                        SampleMatrixText = SampleMatrixText,
                        LaboratoryText = LaboratoryText,
                        SampleStatusText = SampleStatusText,
                        Tide_StartText = Tide_StartText,
                        Tide_EndText = Tide_EndText,
                        MWQMRunID = c.MWQMRunID,
                        SubsectorTVItemID = c.SubsectorTVItemID,
                        MWQMRunTVItemID = c.MWQMRunTVItemID,
                        RunSampleType = c.RunSampleType,
                        DateTime_Local = c.DateTime_Local,
                        RunNumber = c.RunNumber,
                        StartDateTime_Local = c.StartDateTime_Local,
                        EndDateTime_Local = c.EndDateTime_Local,
                        LabReceivedDateTime_Local = c.LabReceivedDateTime_Local,
                        TemperatureControl1_C = c.TemperatureControl1_C,
                        TemperatureControl2_C = c.TemperatureControl2_C,
                        SeaStateAtStart_BeaufortScale = c.SeaStateAtStart_BeaufortScale,
                        SeaStateAtEnd_BeaufortScale = c.SeaStateAtEnd_BeaufortScale,
                        WaterLevelAtBrook_m = c.WaterLevelAtBrook_m,
                        WaveHightAtStart_m = c.WaveHightAtStart_m,
                        WaveHightAtEnd_m = c.WaveHightAtEnd_m,
                        SampleCrewInitials = c.SampleCrewInitials,
                        AnalyzeMethod = c.AnalyzeMethod,
                        SampleMatrix = c.SampleMatrix,
                        Laboratory = c.Laboratory,
                        SampleStatus = c.SampleStatus,
                        LabSampleApprovalContactTVItemID = c.LabSampleApprovalContactTVItemID,
                        LabAnalyzeBath1IncubationStartDateTime_Local = c.LabAnalyzeBath1IncubationStartDateTime_Local,
                        LabAnalyzeBath2IncubationStartDateTime_Local = c.LabAnalyzeBath2IncubationStartDateTime_Local,
                        LabAnalyzeBath3IncubationStartDateTime_Local = c.LabAnalyzeBath3IncubationStartDateTime_Local,
                        LabRunSampleApprovalDateTime_Local = c.LabRunSampleApprovalDateTime_Local,
                        Tide_Start = c.Tide_Start,
                        Tide_End = c.Tide_End,
                        RainDay0_mm = c.RainDay0_mm,
                        RainDay1_mm = c.RainDay1_mm,
                        RainDay2_mm = c.RainDay2_mm,
                        RainDay3_mm = c.RainDay3_mm,
                        RainDay4_mm = c.RainDay4_mm,
                        RainDay5_mm = c.RainDay5_mm,
                        RainDay6_mm = c.RainDay6_mm,
                        RainDay7_mm = c.RainDay7_mm,
                        RainDay8_mm = c.RainDay8_mm,
                        RainDay9_mm = c.RainDay9_mm,
                        RainDay10_mm = c.RainDay10_mm,
                        RemoveFromStat = c.RemoveFromStat,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMRunExtraBQuery;
        }
        #endregion Functions private Generated FillMWQMRunExtraB

    }
}
