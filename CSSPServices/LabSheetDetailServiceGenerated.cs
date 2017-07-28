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
    public partial class LabSheetDetailService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetDetailService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheetDetail labSheetDetail = validationContext.ObjectInstance as LabSheetDetail;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (labSheetDetail.LabSheetDetailID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailLabSheetDetailID), new[] { "LabSheetDetailID" });
                }
            }

            //LabSheetDetailID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //LabSheetID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            LabSheet LabSheetLabSheetID = (from c in db.LabSheets where c.LabSheetID == labSheetDetail.LabSheetID select c).FirstOrDefault();

            if (LabSheetLabSheetID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.LabSheet, ModelsRes.LabSheetDetailLabSheetID, labSheetDetail.LabSheetID.ToString()), new[] { "LabSheetID" });
            }

            //SamplingPlanID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            LabSheet LabSheetSamplingPlanID = (from c in db.LabSheets where c.LabSheetID == labSheetDetail.SamplingPlanID select c).FirstOrDefault();

            if (LabSheetSamplingPlanID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.LabSheet, ModelsRes.LabSheetDetailSamplingPlanID, labSheetDetail.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            LabSheet LabSheetSubsectorTVItemID = (from c in db.LabSheets where c.LabSheetID == labSheetDetail.SubsectorTVItemID select c).FirstOrDefault();

            if (LabSheetSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.LabSheet, ModelsRes.LabSheetDetailSubsectorTVItemID, labSheetDetail.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }

            //Version (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheetDetail.Version < 1 || labSheetDetail.Version > 5)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailVersion, "1", "5"), new[] { "Version" });
            }

            if (labSheetDetail.RunDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailRunDate), new[] { "RunDate" });
            }
            else
            {
                if (labSheetDetail.RunDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailRunDate, "1980"), new[] { "RunDate" });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheetDetail.Tides))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailTides), new[] { "Tides" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Tides) && (labSheetDetail.Tides.Length < 1 || labSheetDetail.Tides.Length > 7))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailTides, "1", "7"), new[] { "Tides" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SampleCrewInitials) && labSheetDetail.SampleCrewInitials.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSampleCrewInitials, "20"), new[] { "SampleCrewInitials" });
            }

            if (labSheetDetail.WaterBathCount != null)
            {
                if (labSheetDetail.WaterBathCount < 1 || labSheetDetail.WaterBathCount > 3)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailWaterBathCount, "1", "3"), new[] { "WaterBathCount" });
                }
            }

            if (labSheetDetail.IncubationBath1StartTime != null && ((DateTime)labSheetDetail.IncubationBath1StartTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailIncubationBath1StartTime, "1980"), new[] { ModelsRes.LabSheetDetailIncubationBath1StartTime });
            }

            if (labSheetDetail.IncubationBath2StartTime != null && ((DateTime)labSheetDetail.IncubationBath2StartTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailIncubationBath2StartTime, "1980"), new[] { ModelsRes.LabSheetDetailIncubationBath2StartTime });
            }

            if (labSheetDetail.IncubationBath3StartTime != null && ((DateTime)labSheetDetail.IncubationBath3StartTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailIncubationBath3StartTime, "1980"), new[] { ModelsRes.LabSheetDetailIncubationBath3StartTime });
            }

            if (labSheetDetail.IncubationBath1EndTime != null && ((DateTime)labSheetDetail.IncubationBath1EndTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailIncubationBath1EndTime, "1980"), new[] { ModelsRes.LabSheetDetailIncubationBath1EndTime });
            }

            if (labSheetDetail.IncubationBath2EndTime != null && ((DateTime)labSheetDetail.IncubationBath2EndTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailIncubationBath2EndTime, "1980"), new[] { ModelsRes.LabSheetDetailIncubationBath2EndTime });
            }

            if (labSheetDetail.IncubationBath3EndTime != null && ((DateTime)labSheetDetail.IncubationBath3EndTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailIncubationBath3EndTime, "1980"), new[] { ModelsRes.LabSheetDetailIncubationBath3EndTime });
            }

            if (labSheetDetail.IncubationBath1TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath1TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath1TimeCalculated_minutes > 10000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000"), new[] { "IncubationBath1TimeCalculated_minutes" });
                }
            }

            if (labSheetDetail.IncubationBath2TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath2TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath2TimeCalculated_minutes > 10000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000"), new[] { "IncubationBath2TimeCalculated_minutes" });
                }
            }

            if (labSheetDetail.IncubationBath3TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath3TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath3TimeCalculated_minutes > 10000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000"), new[] { "IncubationBath3TimeCalculated_minutes" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath1) && labSheetDetail.WaterBath1.Length > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath1, "10"), new[] { "WaterBath1" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath2) && labSheetDetail.WaterBath2.Length > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath2, "10"), new[] { "WaterBath2" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath3) && labSheetDetail.WaterBath3.Length > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWaterBath3, "10"), new[] { "WaterBath3" });
            }

            if (labSheetDetail.TCField1 != null)
            {
                if (labSheetDetail.TCField1 < -10 || labSheetDetail.TCField1 > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField1, "-10", "40"), new[] { "TCField1" });
                }
            }

            if (labSheetDetail.TCLab1 != null)
            {
                if (labSheetDetail.TCLab1 < -10 || labSheetDetail.TCLab1 > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab1, "-10", "40"), new[] { "TCLab1" });
                }
            }

            if (labSheetDetail.TCField2 != null)
            {
                if (labSheetDetail.TCField2 < -10 || labSheetDetail.TCField2 > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCField2, "-10", "40"), new[] { "TCField2" });
                }
            }

            if (labSheetDetail.TCLab2 != null)
            {
                if (labSheetDetail.TCLab2 < -10 || labSheetDetail.TCLab2 > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCLab2, "-10", "40"), new[] { "TCLab2" });
                }
            }

            if (labSheetDetail.TCFirst != null)
            {
                if (labSheetDetail.TCFirst < -10 || labSheetDetail.TCFirst > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCFirst, "-10", "40"), new[] { "TCFirst" });
                }
            }

            if (labSheetDetail.TCAverage != null)
            {
                if (labSheetDetail.TCAverage < -10 || labSheetDetail.TCAverage > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailTCAverage, "-10", "40"), new[] { "TCAverage" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ControlLot) && labSheetDetail.ControlLot.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailControlLot, "100"), new[] { "ControlLot" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Positive35) && (labSheetDetail.Positive35.Length < 1 || labSheetDetail.Positive35.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailPositive35, "1", "1"), new[] { "Positive35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.NonTarget35) && (labSheetDetail.NonTarget35.Length < 1 || labSheetDetail.NonTarget35.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailNonTarget35, "1", "1"), new[] { "NonTarget35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Negative35) && (labSheetDetail.Negative35.Length < 1 || labSheetDetail.Negative35.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailNegative35, "1", "1"), new[] { "Negative35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Positive44_5) && (labSheetDetail.Bath1Positive44_5.Length < 1 || labSheetDetail.Bath1Positive44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1Positive44_5, "1", "1"), new[] { "Bath1Positive44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Positive44_5) && (labSheetDetail.Bath2Positive44_5.Length < 1 || labSheetDetail.Bath2Positive44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2Positive44_5, "1", "1"), new[] { "Bath2Positive44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Positive44_5) && (labSheetDetail.Bath3Positive44_5.Length < 1 || labSheetDetail.Bath3Positive44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3Positive44_5, "1", "1"), new[] { "Bath3Positive44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1NonTarget44_5) && (labSheetDetail.Bath1NonTarget44_5.Length < 1 || labSheetDetail.Bath1NonTarget44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1NonTarget44_5, "1", "1"), new[] { "Bath1NonTarget44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2NonTarget44_5) && (labSheetDetail.Bath2NonTarget44_5.Length < 1 || labSheetDetail.Bath2NonTarget44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2NonTarget44_5, "1", "1"), new[] { "Bath2NonTarget44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3NonTarget44_5) && (labSheetDetail.Bath3NonTarget44_5.Length < 1 || labSheetDetail.Bath3NonTarget44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3NonTarget44_5, "1", "1"), new[] { "Bath3NonTarget44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Negative44_5) && (labSheetDetail.Bath1Negative44_5.Length < 1 || labSheetDetail.Bath1Negative44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1Negative44_5, "1", "1"), new[] { "Bath1Negative44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Negative44_5) && (labSheetDetail.Bath2Negative44_5.Length < 1 || labSheetDetail.Bath2Negative44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2Negative44_5, "1", "1"), new[] { "Bath2Negative44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Negative44_5) && (labSheetDetail.Bath3Negative44_5.Length < 1 || labSheetDetail.Bath3Negative44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3Negative44_5, "1", "1"), new[] { "Bath3Negative44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Blank35) && (labSheetDetail.Blank35.Length < 1 || labSheetDetail.Blank35.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBlank35, "1", "1"), new[] { "Blank35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Blank44_5) && (labSheetDetail.Bath1Blank44_5.Length < 1 || labSheetDetail.Bath1Blank44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath1Blank44_5, "1", "1"), new[] { "Bath1Blank44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Blank44_5) && (labSheetDetail.Bath2Blank44_5.Length < 1 || labSheetDetail.Bath2Blank44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath2Blank44_5, "1", "1"), new[] { "Bath2Blank44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Blank44_5) && (labSheetDetail.Bath3Blank44_5.Length < 1 || labSheetDetail.Bath3Blank44_5.Length > 1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetDetailBath3Blank44_5, "1", "1"), new[] { "Bath3Blank44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Lot35) && labSheetDetail.Lot35.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailLot35, "20"), new[] { "Lot35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Lot44_5) && labSheetDetail.Lot44_5.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailLot44_5, "20"), new[] { "Lot44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Weather) && labSheetDetail.Weather.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailWeather, "250"), new[] { "Weather" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.RunComment) && labSheetDetail.RunComment.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailRunComment, "250"), new[] { "RunComment" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.RunWeatherComment) && labSheetDetail.RunWeatherComment.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailRunWeatherComment, "250"), new[] { "RunWeatherComment" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SampleBottleLotNumber) && labSheetDetail.SampleBottleLotNumber.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSampleBottleLotNumber, "20"), new[] { "SampleBottleLotNumber" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SalinitiesReadBy) && labSheetDetail.SalinitiesReadBy.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailSalinitiesReadBy, "20"), new[] { "SalinitiesReadBy" });
            }

            if (labSheetDetail.SalinitiesReadDate != null && ((DateTime)labSheetDetail.SalinitiesReadDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailSalinitiesReadDate, "1980"), new[] { ModelsRes.LabSheetDetailSalinitiesReadDate });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ResultsReadBy) && labSheetDetail.ResultsReadBy.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailResultsReadBy, "20"), new[] { "ResultsReadBy" });
            }

            if (labSheetDetail.ResultsReadDate != null && ((DateTime)labSheetDetail.ResultsReadDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailResultsReadDate, "1980"), new[] { ModelsRes.LabSheetDetailResultsReadDate });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ResultsRecordedBy) && labSheetDetail.ResultsRecordedBy.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetDetailResultsRecordedBy, "20"), new[] { "ResultsRecordedBy" });
            }

            if (labSheetDetail.ResultsRecordedDate != null && ((DateTime)labSheetDetail.ResultsRecordedDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailResultsRecordedDate, "1980"), new[] { ModelsRes.LabSheetDetailResultsRecordedDate });
            }

            if (labSheetDetail.DailyDuplicateRLog != null)
            {
                if (labSheetDetail.DailyDuplicateRLog < 0 || labSheetDetail.DailyDuplicateRLog > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicateRLog, "0", "100"), new[] { "DailyDuplicateRLog" });
                }
            }

            if (labSheetDetail.DailyDuplicatePrecisionCriteria != null)
            {
                if (labSheetDetail.DailyDuplicatePrecisionCriteria < 0 || labSheetDetail.DailyDuplicatePrecisionCriteria > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "100"), new[] { "DailyDuplicatePrecisionCriteria" });
                }
            }

            if (labSheetDetail.IntertechDuplicateRLog != null)
            {
                if (labSheetDetail.IntertechDuplicateRLog < 0 || labSheetDetail.IntertechDuplicateRLog > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicateRLog, "0", "100"), new[] { "IntertechDuplicateRLog" });
                }
            }

            if (labSheetDetail.IntertechDuplicatePrecisionCriteria != null)
            {
                if (labSheetDetail.IntertechDuplicatePrecisionCriteria < 0 || labSheetDetail.IntertechDuplicatePrecisionCriteria > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "100"), new[] { "IntertechDuplicatePrecisionCriteria" });
                }
            }

            if (labSheetDetail.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetDetailLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheetDetail.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetDetailLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheetDetail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetDetailLastUpdateContactTVItemID, labSheetDetail.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetDetailLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(LabSheetDetail labSheetDetail)
        {
            labSheetDetail.ValidationResults = Validate(new ValidationContext(labSheetDetail), ActionDBTypeEnum.Create);
            if (labSheetDetail.ValidationResults.Count() > 0) return false;

            db.LabSheetDetails.Add(labSheetDetail);

            if (!TryToSave(labSheetDetail)) return false;

            return true;
        }
        public bool AddRange(List<LabSheetDetail> labSheetDetailList)
        {
            foreach (LabSheetDetail labSheetDetail in labSheetDetailList)
            {
                labSheetDetail.ValidationResults = Validate(new ValidationContext(labSheetDetail), ActionDBTypeEnum.Create);
                if (labSheetDetail.ValidationResults.Count() > 0) return false;
            }

            db.LabSheetDetails.AddRange(labSheetDetailList);

            if (!TryToSaveRange(labSheetDetailList)) return false;

            return true;
        }
        public bool Delete(LabSheetDetail labSheetDetail)
        {
            if (!db.LabSheetDetails.Where(c => c.LabSheetDetailID == labSheetDetail.LabSheetDetailID).Any())
            {
                labSheetDetail.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "LabSheetDetail", "LabSheetDetailID", labSheetDetail.LabSheetDetailID.ToString())) }.AsEnumerable();
                return false;
            }

            db.LabSheetDetails.Remove(labSheetDetail);

            if (!TryToSave(labSheetDetail)) return false;

            return true;
        }
        public bool DeleteRange(List<LabSheetDetail> labSheetDetailList)
        {
            foreach (LabSheetDetail labSheetDetail in labSheetDetailList)
            {
                if (!db.LabSheetDetails.Where(c => c.LabSheetDetailID == labSheetDetail.LabSheetDetailID).Any())
                {
                    labSheetDetailList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "LabSheetDetail", "LabSheetDetailID", labSheetDetail.LabSheetDetailID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.LabSheetDetails.RemoveRange(labSheetDetailList);

            if (!TryToSaveRange(labSheetDetailList)) return false;

            return true;
        }
        public bool Update(LabSheetDetail labSheetDetail)
        {
            labSheetDetail.ValidationResults = Validate(new ValidationContext(labSheetDetail), ActionDBTypeEnum.Update);
            if (labSheetDetail.ValidationResults.Count() > 0) return false;

            db.LabSheetDetails.Update(labSheetDetail);

            if (!TryToSave(labSheetDetail)) return false;

            return true;
        }
        public bool UpdateRange(List<LabSheetDetail> labSheetDetailList)
        {
            foreach (LabSheetDetail labSheetDetail in labSheetDetailList)
            {
                labSheetDetail.ValidationResults = Validate(new ValidationContext(labSheetDetail), ActionDBTypeEnum.Update);
                if (labSheetDetail.ValidationResults.Count() > 0) return false;
            }
            db.LabSheetDetails.UpdateRange(labSheetDetailList);

            if (!TryToSaveRange(labSheetDetailList)) return false;

            return true;
        }
        public IQueryable<LabSheetDetail> GetRead()
        {
            return db.LabSheetDetails.AsNoTracking();
        }
        public IQueryable<LabSheetDetail> GetEdit()
        {
            return db.LabSheetDetails;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(LabSheetDetail labSheetDetail)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                labSheetDetail.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<LabSheetDetail> labSheetDetailList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                labSheetDetailList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
