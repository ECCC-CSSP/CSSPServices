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
    /// <summary>
    ///     <para>bonjour LabSheetDetail</para>
    /// </summary>
    public partial class LabSheetDetailService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetDetailService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheetDetail labSheetDetail = validationContext.ObjectInstance as LabSheetDetail;
            labSheetDetail.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (labSheetDetail.LabSheetDetailID == 0)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetDetailLabSheetDetailID"), new[] { "LabSheetDetailID" });
                }

                if (!(from c in db.LabSheetDetails select c).Where(c => c.LabSheetDetailID == labSheetDetail.LabSheetDetailID).Any())
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheetDetail", "LabSheetDetailLabSheetDetailID", labSheetDetail.LabSheetDetailID.ToString()), new[] { "LabSheetDetailID" });
                }
            }

            LabSheet LabSheetLabSheetID = (from c in db.LabSheets where c.LabSheetID == labSheetDetail.LabSheetID select c).FirstOrDefault();

            if (LabSheetLabSheetID == null)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetDetailLabSheetID", labSheetDetail.LabSheetID.ToString()), new[] { "LabSheetID" });
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == labSheetDetail.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "LabSheetDetailSamplingPlanID", labSheetDetail.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == labSheetDetail.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetDetailSubsectorTVItemID", labSheetDetail.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetDetailSubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (labSheetDetail.Version < 1 || labSheetDetail.Version > 5)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailVersion", "1", "5"), new[] { "Version" });
            }

            if (labSheetDetail.RunDate.Year == 1)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetDetailRunDate"), new[] { "RunDate" });
            }
            else
            {
                if (labSheetDetail.RunDate.Year < 1980)
                {
                labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailRunDate", "1980"), new[] { "RunDate" });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheetDetail.Tides))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetDetailTides"), new[] { "Tides" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Tides) && (labSheetDetail.Tides.Length < 1 || labSheetDetail.Tides.Length > 7))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailTides", "1", "7"), new[] { "Tides" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SampleCrewInitials) && labSheetDetail.SampleCrewInitials.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailSampleCrewInitials", "20"), new[] { "SampleCrewInitials" });
            }

            if (labSheetDetail.WaterBathCount != null)
            {
                if (labSheetDetail.WaterBathCount < 1 || labSheetDetail.WaterBathCount > 3)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailWaterBathCount", "1", "3"), new[] { "WaterBathCount" });
                }
            }

            if (labSheetDetail.IncubationBath1StartTime != null && ((DateTime)labSheetDetail.IncubationBath1StartTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailIncubationBath1StartTime", "1980"), new[] { "LabSheetDetailIncubationBath1StartTime" });
            }

            if (labSheetDetail.IncubationBath2StartTime != null && ((DateTime)labSheetDetail.IncubationBath2StartTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailIncubationBath2StartTime", "1980"), new[] { "LabSheetDetailIncubationBath2StartTime" });
            }

            if (labSheetDetail.IncubationBath3StartTime != null && ((DateTime)labSheetDetail.IncubationBath3StartTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailIncubationBath3StartTime", "1980"), new[] { "LabSheetDetailIncubationBath3StartTime" });
            }

            if (labSheetDetail.IncubationBath1EndTime != null && ((DateTime)labSheetDetail.IncubationBath1EndTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailIncubationBath1EndTime", "1980"), new[] { "LabSheetDetailIncubationBath1EndTime" });
            }

            if (labSheetDetail.IncubationBath2EndTime != null && ((DateTime)labSheetDetail.IncubationBath2EndTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailIncubationBath2EndTime", "1980"), new[] { "LabSheetDetailIncubationBath2EndTime" });
            }

            if (labSheetDetail.IncubationBath3EndTime != null && ((DateTime)labSheetDetail.IncubationBath3EndTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailIncubationBath3EndTime", "1980"), new[] { "LabSheetDetailIncubationBath3EndTime" });
            }

            if (labSheetDetail.IncubationBath1TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath1TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath1TimeCalculated_minutes > 10000)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailIncubationBath1TimeCalculated_minutes", "0", "10000"), new[] { "IncubationBath1TimeCalculated_minutes" });
                }
            }

            if (labSheetDetail.IncubationBath2TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath2TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath2TimeCalculated_minutes > 10000)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailIncubationBath2TimeCalculated_minutes", "0", "10000"), new[] { "IncubationBath2TimeCalculated_minutes" });
                }
            }

            if (labSheetDetail.IncubationBath3TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath3TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath3TimeCalculated_minutes > 10000)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailIncubationBath3TimeCalculated_minutes", "0", "10000"), new[] { "IncubationBath3TimeCalculated_minutes" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath1) && labSheetDetail.WaterBath1.Length > 10)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailWaterBath1", "10"), new[] { "WaterBath1" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath2) && labSheetDetail.WaterBath2.Length > 10)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailWaterBath2", "10"), new[] { "WaterBath2" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath3) && labSheetDetail.WaterBath3.Length > 10)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailWaterBath3", "10"), new[] { "WaterBath3" });
            }

            if (labSheetDetail.TCField1 != null)
            {
                if (labSheetDetail.TCField1 < -10 || labSheetDetail.TCField1 > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailTCField1", "-10", "40"), new[] { "TCField1" });
                }
            }

            if (labSheetDetail.TCLab1 != null)
            {
                if (labSheetDetail.TCLab1 < -10 || labSheetDetail.TCLab1 > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailTCLab1", "-10", "40"), new[] { "TCLab1" });
                }
            }

            if (labSheetDetail.TCField2 != null)
            {
                if (labSheetDetail.TCField2 < -10 || labSheetDetail.TCField2 > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailTCField2", "-10", "40"), new[] { "TCField2" });
                }
            }

            if (labSheetDetail.TCLab2 != null)
            {
                if (labSheetDetail.TCLab2 < -10 || labSheetDetail.TCLab2 > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailTCLab2", "-10", "40"), new[] { "TCLab2" });
                }
            }

            if (labSheetDetail.TCFirst != null)
            {
                if (labSheetDetail.TCFirst < -10 || labSheetDetail.TCFirst > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailTCFirst", "-10", "40"), new[] { "TCFirst" });
                }
            }

            if (labSheetDetail.TCAverage != null)
            {
                if (labSheetDetail.TCAverage < -10 || labSheetDetail.TCAverage > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailTCAverage", "-10", "40"), new[] { "TCAverage" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ControlLot) && labSheetDetail.ControlLot.Length > 100)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailControlLot", "100"), new[] { "ControlLot" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Positive35) && (labSheetDetail.Positive35.Length < 1 || labSheetDetail.Positive35.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailPositive35", "1", "1"), new[] { "Positive35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.NonTarget35) && (labSheetDetail.NonTarget35.Length < 1 || labSheetDetail.NonTarget35.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailNonTarget35", "1", "1"), new[] { "NonTarget35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Negative35) && (labSheetDetail.Negative35.Length < 1 || labSheetDetail.Negative35.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailNegative35", "1", "1"), new[] { "Negative35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Positive44_5) && (labSheetDetail.Bath1Positive44_5.Length < 1 || labSheetDetail.Bath1Positive44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath1Positive44_5", "1", "1"), new[] { "Bath1Positive44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Positive44_5) && (labSheetDetail.Bath2Positive44_5.Length < 1 || labSheetDetail.Bath2Positive44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath2Positive44_5", "1", "1"), new[] { "Bath2Positive44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Positive44_5) && (labSheetDetail.Bath3Positive44_5.Length < 1 || labSheetDetail.Bath3Positive44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath3Positive44_5", "1", "1"), new[] { "Bath3Positive44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1NonTarget44_5) && (labSheetDetail.Bath1NonTarget44_5.Length < 1 || labSheetDetail.Bath1NonTarget44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath1NonTarget44_5", "1", "1"), new[] { "Bath1NonTarget44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2NonTarget44_5) && (labSheetDetail.Bath2NonTarget44_5.Length < 1 || labSheetDetail.Bath2NonTarget44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath2NonTarget44_5", "1", "1"), new[] { "Bath2NonTarget44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3NonTarget44_5) && (labSheetDetail.Bath3NonTarget44_5.Length < 1 || labSheetDetail.Bath3NonTarget44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath3NonTarget44_5", "1", "1"), new[] { "Bath3NonTarget44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Negative44_5) && (labSheetDetail.Bath1Negative44_5.Length < 1 || labSheetDetail.Bath1Negative44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath1Negative44_5", "1", "1"), new[] { "Bath1Negative44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Negative44_5) && (labSheetDetail.Bath2Negative44_5.Length < 1 || labSheetDetail.Bath2Negative44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath2Negative44_5", "1", "1"), new[] { "Bath2Negative44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Negative44_5) && (labSheetDetail.Bath3Negative44_5.Length < 1 || labSheetDetail.Bath3Negative44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath3Negative44_5", "1", "1"), new[] { "Bath3Negative44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Blank35) && (labSheetDetail.Blank35.Length < 1 || labSheetDetail.Blank35.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBlank35", "1", "1"), new[] { "Blank35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Blank44_5) && (labSheetDetail.Bath1Blank44_5.Length < 1 || labSheetDetail.Bath1Blank44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath1Blank44_5", "1", "1"), new[] { "Bath1Blank44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Blank44_5) && (labSheetDetail.Bath2Blank44_5.Length < 1 || labSheetDetail.Bath2Blank44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath2Blank44_5", "1", "1"), new[] { "Bath2Blank44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Blank44_5) && (labSheetDetail.Bath3Blank44_5.Length < 1 || labSheetDetail.Bath3Blank44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetDetailBath3Blank44_5", "1", "1"), new[] { "Bath3Blank44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Lot35) && labSheetDetail.Lot35.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailLot35", "20"), new[] { "Lot35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Lot44_5) && labSheetDetail.Lot44_5.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailLot44_5", "20"), new[] { "Lot44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Weather) && labSheetDetail.Weather.Length > 250)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailWeather", "250"), new[] { "Weather" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.RunComment) && labSheetDetail.RunComment.Length > 250)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailRunComment", "250"), new[] { "RunComment" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.RunWeatherComment) && labSheetDetail.RunWeatherComment.Length > 250)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailRunWeatherComment", "250"), new[] { "RunWeatherComment" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SampleBottleLotNumber) && labSheetDetail.SampleBottleLotNumber.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailSampleBottleLotNumber", "20"), new[] { "SampleBottleLotNumber" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SalinitiesReadBy) && labSheetDetail.SalinitiesReadBy.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailSalinitiesReadBy", "20"), new[] { "SalinitiesReadBy" });
            }

            if (labSheetDetail.SalinitiesReadDate != null && ((DateTime)labSheetDetail.SalinitiesReadDate).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailSalinitiesReadDate", "1980"), new[] { "LabSheetDetailSalinitiesReadDate" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ResultsReadBy) && labSheetDetail.ResultsReadBy.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailResultsReadBy", "20"), new[] { "ResultsReadBy" });
            }

            if (labSheetDetail.ResultsReadDate != null && ((DateTime)labSheetDetail.ResultsReadDate).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailResultsReadDate", "1980"), new[] { "LabSheetDetailResultsReadDate" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ResultsRecordedBy) && labSheetDetail.ResultsRecordedBy.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetDetailResultsRecordedBy", "20"), new[] { "ResultsRecordedBy" });
            }

            if (labSheetDetail.ResultsRecordedDate != null && ((DateTime)labSheetDetail.ResultsRecordedDate).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailResultsRecordedDate", "1980"), new[] { "LabSheetDetailResultsRecordedDate" });
            }

            if (labSheetDetail.DailyDuplicateRLog != null)
            {
                if (labSheetDetail.DailyDuplicateRLog < 0 || labSheetDetail.DailyDuplicateRLog > 100)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailDailyDuplicateRLog", "0", "100"), new[] { "DailyDuplicateRLog" });
                }
            }

            if (labSheetDetail.DailyDuplicatePrecisionCriteria != null)
            {
                if (labSheetDetail.DailyDuplicatePrecisionCriteria < 0 || labSheetDetail.DailyDuplicatePrecisionCriteria > 100)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailDailyDuplicatePrecisionCriteria", "0", "100"), new[] { "DailyDuplicatePrecisionCriteria" });
                }
            }

            if (labSheetDetail.IntertechDuplicateRLog != null)
            {
                if (labSheetDetail.IntertechDuplicateRLog < 0 || labSheetDetail.IntertechDuplicateRLog > 100)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailIntertechDuplicateRLog", "0", "100"), new[] { "IntertechDuplicateRLog" });
                }
            }

            if (labSheetDetail.IntertechDuplicatePrecisionCriteria != null)
            {
                if (labSheetDetail.IntertechDuplicatePrecisionCriteria < 0 || labSheetDetail.IntertechDuplicatePrecisionCriteria > 100)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDetailIntertechDuplicatePrecisionCriteria", "0", "100"), new[] { "IntertechDuplicatePrecisionCriteria" });
                }
            }

            if (labSheetDetail.LastUpdateDate_UTC.Year == 1)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetDetailLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheetDetail.LastUpdateDate_UTC.Year < 1980)
                {
                labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetDetailLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheetDetail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetDetailLastUpdateContactTVItemID", labSheetDetail.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetDetailLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public LabSheetDetail GetLabSheetDetailWithLabSheetDetailID(int LabSheetDetailID)
        {
            return (from c in db.LabSheetDetails
                    where c.LabSheetDetailID == LabSheetDetailID
                    select c).FirstOrDefault();

        }
        public IQueryable<LabSheetDetail> GetLabSheetDetailList()
        {
            IQueryable<LabSheetDetail> LabSheetDetailQuery = (from c in db.LabSheetDetails select c);

            LabSheetDetailQuery = EnhanceQueryStatements<LabSheetDetail>(LabSheetDetailQuery) as IQueryable<LabSheetDetail>;

            return LabSheetDetailQuery;
        }
        public LabSheetDetailExtraA GetLabSheetDetailExtraAWithLabSheetDetailID(int LabSheetDetailID)
        {
            return FillLabSheetDetailExtraA().Where(c => c.LabSheetDetailID == LabSheetDetailID).FirstOrDefault();

        }
        public IQueryable<LabSheetDetailExtraA> GetLabSheetDetailExtraAList()
        {
            IQueryable<LabSheetDetailExtraA> LabSheetDetailExtraAQuery = FillLabSheetDetailExtraA();

            LabSheetDetailExtraAQuery = EnhanceQueryStatements<LabSheetDetailExtraA>(LabSheetDetailExtraAQuery) as IQueryable<LabSheetDetailExtraA>;

            return LabSheetDetailExtraAQuery;
        }
        public LabSheetDetailExtraB GetLabSheetDetailExtraBWithLabSheetDetailID(int LabSheetDetailID)
        {
            return FillLabSheetDetailExtraB().Where(c => c.LabSheetDetailID == LabSheetDetailID).FirstOrDefault();

        }
        public IQueryable<LabSheetDetailExtraB> GetLabSheetDetailExtraBList()
        {
            IQueryable<LabSheetDetailExtraB> LabSheetDetailExtraBQuery = FillLabSheetDetailExtraB();

            LabSheetDetailExtraBQuery = EnhanceQueryStatements<LabSheetDetailExtraB>(LabSheetDetailExtraBQuery) as IQueryable<LabSheetDetailExtraB>;

            return LabSheetDetailExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(LabSheetDetail labSheetDetail)
        {
            labSheetDetail.ValidationResults = Validate(new ValidationContext(labSheetDetail), ActionDBTypeEnum.Create);
            if (labSheetDetail.ValidationResults.Count() > 0) return false;

            db.LabSheetDetails.Add(labSheetDetail);

            if (!TryToSave(labSheetDetail)) return false;

            return true;
        }
        public bool Delete(LabSheetDetail labSheetDetail)
        {
            labSheetDetail.ValidationResults = Validate(new ValidationContext(labSheetDetail), ActionDBTypeEnum.Delete);
            if (labSheetDetail.ValidationResults.Count() > 0) return false;

            db.LabSheetDetails.Remove(labSheetDetail);

            if (!TryToSave(labSheetDetail)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
