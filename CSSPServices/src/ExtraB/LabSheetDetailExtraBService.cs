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
    public partial class LabSheetDetailService
    {
        #region Functions private Generated FillLabSheetDetailExtraB
        private IQueryable<LabSheetDetailExtraB> FillLabSheetDetailExtraB()
        {
             IQueryable<LabSheetDetailExtraB> LabSheetDetailExtraBQuery = (from c in db.LabSheetDetails
                let LabSheetDetailReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SubsectorText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new LabSheetDetailExtraB
                    {
                        LabSheetDetailReportTest = LabSheetDetailReportTest,
                        SubsectorText = SubsectorText,
                        LastUpdateContactText = LastUpdateContactText,
                        LabSheetDetailID = c.LabSheetDetailID,
                        LabSheetID = c.LabSheetID,
                        SamplingPlanID = c.SamplingPlanID,
                        SubsectorTVItemID = c.SubsectorTVItemID,
                        Version = c.Version,
                        RunDate = c.RunDate,
                        Tides = c.Tides,
                        SampleCrewInitials = c.SampleCrewInitials,
                        WaterBathCount = c.WaterBathCount,
                        IncubationBath1StartTime = c.IncubationBath1StartTime,
                        IncubationBath2StartTime = c.IncubationBath2StartTime,
                        IncubationBath3StartTime = c.IncubationBath3StartTime,
                        IncubationBath1EndTime = c.IncubationBath1EndTime,
                        IncubationBath2EndTime = c.IncubationBath2EndTime,
                        IncubationBath3EndTime = c.IncubationBath3EndTime,
                        IncubationBath1TimeCalculated_minutes = c.IncubationBath1TimeCalculated_minutes,
                        IncubationBath2TimeCalculated_minutes = c.IncubationBath2TimeCalculated_minutes,
                        IncubationBath3TimeCalculated_minutes = c.IncubationBath3TimeCalculated_minutes,
                        WaterBath1 = c.WaterBath1,
                        WaterBath2 = c.WaterBath2,
                        WaterBath3 = c.WaterBath3,
                        TCField1 = c.TCField1,
                        TCLab1 = c.TCLab1,
                        TCField2 = c.TCField2,
                        TCLab2 = c.TCLab2,
                        TCFirst = c.TCFirst,
                        TCAverage = c.TCAverage,
                        ControlLot = c.ControlLot,
                        Positive35 = c.Positive35,
                        NonTarget35 = c.NonTarget35,
                        Negative35 = c.Negative35,
                        Bath1Positive44_5 = c.Bath1Positive44_5,
                        Bath2Positive44_5 = c.Bath2Positive44_5,
                        Bath3Positive44_5 = c.Bath3Positive44_5,
                        Bath1NonTarget44_5 = c.Bath1NonTarget44_5,
                        Bath2NonTarget44_5 = c.Bath2NonTarget44_5,
                        Bath3NonTarget44_5 = c.Bath3NonTarget44_5,
                        Bath1Negative44_5 = c.Bath1Negative44_5,
                        Bath2Negative44_5 = c.Bath2Negative44_5,
                        Bath3Negative44_5 = c.Bath3Negative44_5,
                        Blank35 = c.Blank35,
                        Bath1Blank44_5 = c.Bath1Blank44_5,
                        Bath2Blank44_5 = c.Bath2Blank44_5,
                        Bath3Blank44_5 = c.Bath3Blank44_5,
                        Lot35 = c.Lot35,
                        Lot44_5 = c.Lot44_5,
                        Weather = c.Weather,
                        RunComment = c.RunComment,
                        RunWeatherComment = c.RunWeatherComment,
                        SampleBottleLotNumber = c.SampleBottleLotNumber,
                        SalinitiesReadBy = c.SalinitiesReadBy,
                        SalinitiesReadDate = c.SalinitiesReadDate,
                        ResultsReadBy = c.ResultsReadBy,
                        ResultsReadDate = c.ResultsReadDate,
                        ResultsRecordedBy = c.ResultsRecordedBy,
                        ResultsRecordedDate = c.ResultsRecordedDate,
                        DailyDuplicateRLog = c.DailyDuplicateRLog,
                        DailyDuplicatePrecisionCriteria = c.DailyDuplicatePrecisionCriteria,
                        DailyDuplicateAcceptable = c.DailyDuplicateAcceptable,
                        IntertechDuplicateRLog = c.IntertechDuplicateRLog,
                        IntertechDuplicatePrecisionCriteria = c.IntertechDuplicatePrecisionCriteria,
                        IntertechDuplicateAcceptable = c.IntertechDuplicateAcceptable,
                        IntertechReadAcceptable = c.IntertechReadAcceptable,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return LabSheetDetailExtraBQuery;
        }
        #endregion Functions private Generated FillLabSheetDetailExtraB

    }
}
