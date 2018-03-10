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
        public LabSheetDetailService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetDetailLabSheetDetailID), new[] { "LabSheetDetailID" });
                }

                if (!GetRead().Where(c => c.LabSheetDetailID == labSheetDetail.LabSheetDetailID).Any())
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.LabSheetDetail, CSSPModelsRes.LabSheetDetailLabSheetDetailID, labSheetDetail.LabSheetDetailID.ToString()), new[] { "LabSheetDetailID" });
                }
            }

            LabSheet LabSheetLabSheetID = (from c in db.LabSheets where c.LabSheetID == labSheetDetail.LabSheetID select c).FirstOrDefault();

            if (LabSheetLabSheetID == null)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.LabSheet, CSSPModelsRes.LabSheetDetailLabSheetID, (labSheetDetail.LabSheetID == null ? "" : labSheetDetail.LabSheetID.ToString())), new[] { "LabSheetID" });
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == labSheetDetail.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlan, CSSPModelsRes.LabSheetDetailSamplingPlanID, (labSheetDetail.SamplingPlanID == null ? "" : labSheetDetail.SamplingPlanID.ToString())), new[] { "SamplingPlanID" });
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == labSheetDetail.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetDetailSubsectorTVItemID, (labSheetDetail.SubsectorTVItemID == null ? "" : labSheetDetail.SubsectorTVItemID.ToString())), new[] { "SubsectorTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetDetailSubsectorTVItemID, "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (labSheetDetail.Version < 1 || labSheetDetail.Version > 5)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailVersion, "1", "5"), new[] { "Version" });
            }

            if (labSheetDetail.RunDate.Year == 1)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetDetailRunDate), new[] { "RunDate" });
            }
            else
            {
                if (labSheetDetail.RunDate.Year < 1980)
                {
                labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailRunDate, "1980"), new[] { "RunDate" });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheetDetail.Tides))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetDetailTides), new[] { "Tides" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Tides) && (labSheetDetail.Tides.Length < 1 || labSheetDetail.Tides.Length > 7))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTides, "1", "7"), new[] { "Tides" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SampleCrewInitials) && labSheetDetail.SampleCrewInitials.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailSampleCrewInitials, "20"), new[] { "SampleCrewInitials" });
            }

            if (labSheetDetail.WaterBathCount != null)
            {
                if (labSheetDetail.WaterBathCount < 1 || labSheetDetail.WaterBathCount > 3)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailWaterBathCount, "1", "3"), new[] { "WaterBathCount" });
                }
            }

            if (labSheetDetail.IncubationBath1StartTime != null && ((DateTime)labSheetDetail.IncubationBath1StartTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath1StartTime, "1980"), new[] { CSSPModelsRes.LabSheetDetailIncubationBath1StartTime });
            }

            if (labSheetDetail.IncubationBath2StartTime != null && ((DateTime)labSheetDetail.IncubationBath2StartTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath2StartTime, "1980"), new[] { CSSPModelsRes.LabSheetDetailIncubationBath2StartTime });
            }

            if (labSheetDetail.IncubationBath3StartTime != null && ((DateTime)labSheetDetail.IncubationBath3StartTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath3StartTime, "1980"), new[] { CSSPModelsRes.LabSheetDetailIncubationBath3StartTime });
            }

            if (labSheetDetail.IncubationBath1EndTime != null && ((DateTime)labSheetDetail.IncubationBath1EndTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath1EndTime, "1980"), new[] { CSSPModelsRes.LabSheetDetailIncubationBath1EndTime });
            }

            if (labSheetDetail.IncubationBath2EndTime != null && ((DateTime)labSheetDetail.IncubationBath2EndTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath2EndTime, "1980"), new[] { CSSPModelsRes.LabSheetDetailIncubationBath2EndTime });
            }

            if (labSheetDetail.IncubationBath3EndTime != null && ((DateTime)labSheetDetail.IncubationBath3EndTime).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailIncubationBath3EndTime, "1980"), new[] { CSSPModelsRes.LabSheetDetailIncubationBath3EndTime });
            }

            if (labSheetDetail.IncubationBath1TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath1TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath1TimeCalculated_minutes > 10000)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIncubationBath1TimeCalculated_minutes, "0", "10000"), new[] { "IncubationBath1TimeCalculated_minutes" });
                }
            }

            if (labSheetDetail.IncubationBath2TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath2TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath2TimeCalculated_minutes > 10000)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIncubationBath2TimeCalculated_minutes, "0", "10000"), new[] { "IncubationBath2TimeCalculated_minutes" });
                }
            }

            if (labSheetDetail.IncubationBath3TimeCalculated_minutes != null)
            {
                if (labSheetDetail.IncubationBath3TimeCalculated_minutes < 0 || labSheetDetail.IncubationBath3TimeCalculated_minutes > 10000)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIncubationBath3TimeCalculated_minutes, "0", "10000"), new[] { "IncubationBath3TimeCalculated_minutes" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath1) && labSheetDetail.WaterBath1.Length > 10)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailWaterBath1, "10"), new[] { "WaterBath1" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath2) && labSheetDetail.WaterBath2.Length > 10)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailWaterBath2, "10"), new[] { "WaterBath2" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.WaterBath3) && labSheetDetail.WaterBath3.Length > 10)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailWaterBath3, "10"), new[] { "WaterBath3" });
            }

            if (labSheetDetail.TCField1 != null)
            {
                if (labSheetDetail.TCField1 < -10 || labSheetDetail.TCField1 > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCField1, "-10", "40"), new[] { "TCField1" });
                }
            }

            if (labSheetDetail.TCLab1 != null)
            {
                if (labSheetDetail.TCLab1 < -10 || labSheetDetail.TCLab1 > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCLab1, "-10", "40"), new[] { "TCLab1" });
                }
            }

            if (labSheetDetail.TCField2 != null)
            {
                if (labSheetDetail.TCField2 < -10 || labSheetDetail.TCField2 > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCField2, "-10", "40"), new[] { "TCField2" });
                }
            }

            if (labSheetDetail.TCLab2 != null)
            {
                if (labSheetDetail.TCLab2 < -10 || labSheetDetail.TCLab2 > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCLab2, "-10", "40"), new[] { "TCLab2" });
                }
            }

            if (labSheetDetail.TCFirst != null)
            {
                if (labSheetDetail.TCFirst < -10 || labSheetDetail.TCFirst > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCFirst, "-10", "40"), new[] { "TCFirst" });
                }
            }

            if (labSheetDetail.TCAverage != null)
            {
                if (labSheetDetail.TCAverage < -10 || labSheetDetail.TCAverage > 40)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailTCAverage, "-10", "40"), new[] { "TCAverage" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ControlLot) && labSheetDetail.ControlLot.Length > 100)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailControlLot, "100"), new[] { "ControlLot" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Positive35) && (labSheetDetail.Positive35.Length < 1 || labSheetDetail.Positive35.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailPositive35, "1", "1"), new[] { "Positive35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.NonTarget35) && (labSheetDetail.NonTarget35.Length < 1 || labSheetDetail.NonTarget35.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailNonTarget35, "1", "1"), new[] { "NonTarget35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Negative35) && (labSheetDetail.Negative35.Length < 1 || labSheetDetail.Negative35.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailNegative35, "1", "1"), new[] { "Negative35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Positive44_5) && (labSheetDetail.Bath1Positive44_5.Length < 1 || labSheetDetail.Bath1Positive44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath1Positive44_5, "1", "1"), new[] { "Bath1Positive44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Positive44_5) && (labSheetDetail.Bath2Positive44_5.Length < 1 || labSheetDetail.Bath2Positive44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath2Positive44_5, "1", "1"), new[] { "Bath2Positive44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Positive44_5) && (labSheetDetail.Bath3Positive44_5.Length < 1 || labSheetDetail.Bath3Positive44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath3Positive44_5, "1", "1"), new[] { "Bath3Positive44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1NonTarget44_5) && (labSheetDetail.Bath1NonTarget44_5.Length < 1 || labSheetDetail.Bath1NonTarget44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath1NonTarget44_5, "1", "1"), new[] { "Bath1NonTarget44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2NonTarget44_5) && (labSheetDetail.Bath2NonTarget44_5.Length < 1 || labSheetDetail.Bath2NonTarget44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath2NonTarget44_5, "1", "1"), new[] { "Bath2NonTarget44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3NonTarget44_5) && (labSheetDetail.Bath3NonTarget44_5.Length < 1 || labSheetDetail.Bath3NonTarget44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath3NonTarget44_5, "1", "1"), new[] { "Bath3NonTarget44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Negative44_5) && (labSheetDetail.Bath1Negative44_5.Length < 1 || labSheetDetail.Bath1Negative44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath1Negative44_5, "1", "1"), new[] { "Bath1Negative44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Negative44_5) && (labSheetDetail.Bath2Negative44_5.Length < 1 || labSheetDetail.Bath2Negative44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath2Negative44_5, "1", "1"), new[] { "Bath2Negative44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Negative44_5) && (labSheetDetail.Bath3Negative44_5.Length < 1 || labSheetDetail.Bath3Negative44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath3Negative44_5, "1", "1"), new[] { "Bath3Negative44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Blank35) && (labSheetDetail.Blank35.Length < 1 || labSheetDetail.Blank35.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBlank35, "1", "1"), new[] { "Blank35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath1Blank44_5) && (labSheetDetail.Bath1Blank44_5.Length < 1 || labSheetDetail.Bath1Blank44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath1Blank44_5, "1", "1"), new[] { "Bath1Blank44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath2Blank44_5) && (labSheetDetail.Bath2Blank44_5.Length < 1 || labSheetDetail.Bath2Blank44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath2Blank44_5, "1", "1"), new[] { "Bath2Blank44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Bath3Blank44_5) && (labSheetDetail.Bath3Blank44_5.Length < 1 || labSheetDetail.Bath3Blank44_5.Length > 1))
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailBath3Blank44_5, "1", "1"), new[] { "Bath3Blank44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Lot35) && labSheetDetail.Lot35.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailLot35, "20"), new[] { "Lot35" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Lot44_5) && labSheetDetail.Lot44_5.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailLot44_5, "20"), new[] { "Lot44_5" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.Weather) && labSheetDetail.Weather.Length > 250)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailWeather, "250"), new[] { "Weather" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.RunComment) && labSheetDetail.RunComment.Length > 250)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailRunComment, "250"), new[] { "RunComment" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.RunWeatherComment) && labSheetDetail.RunWeatherComment.Length > 250)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailRunWeatherComment, "250"), new[] { "RunWeatherComment" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SampleBottleLotNumber) && labSheetDetail.SampleBottleLotNumber.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailSampleBottleLotNumber, "20"), new[] { "SampleBottleLotNumber" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.SalinitiesReadBy) && labSheetDetail.SalinitiesReadBy.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailSalinitiesReadBy, "20"), new[] { "SalinitiesReadBy" });
            }

            if (labSheetDetail.SalinitiesReadDate != null && ((DateTime)labSheetDetail.SalinitiesReadDate).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailSalinitiesReadDate, "1980"), new[] { CSSPModelsRes.LabSheetDetailSalinitiesReadDate });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ResultsReadBy) && labSheetDetail.ResultsReadBy.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailResultsReadBy, "20"), new[] { "ResultsReadBy" });
            }

            if (labSheetDetail.ResultsReadDate != null && ((DateTime)labSheetDetail.ResultsReadDate).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailResultsReadDate, "1980"), new[] { CSSPModelsRes.LabSheetDetailResultsReadDate });
            }

            if (!string.IsNullOrWhiteSpace(labSheetDetail.ResultsRecordedBy) && labSheetDetail.ResultsRecordedBy.Length > 20)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetDetailResultsRecordedBy, "20"), new[] { "ResultsRecordedBy" });
            }

            if (labSheetDetail.ResultsRecordedDate != null && ((DateTime)labSheetDetail.ResultsRecordedDate).Year < 1980)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailResultsRecordedDate, "1980"), new[] { CSSPModelsRes.LabSheetDetailResultsRecordedDate });
            }

            if (labSheetDetail.DailyDuplicateRLog != null)
            {
                if (labSheetDetail.DailyDuplicateRLog < 0 || labSheetDetail.DailyDuplicateRLog > 100)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailDailyDuplicateRLog, "0", "100"), new[] { "DailyDuplicateRLog" });
                }
            }

            if (labSheetDetail.DailyDuplicatePrecisionCriteria != null)
            {
                if (labSheetDetail.DailyDuplicatePrecisionCriteria < 0 || labSheetDetail.DailyDuplicatePrecisionCriteria > 100)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailDailyDuplicatePrecisionCriteria, "0", "100"), new[] { "DailyDuplicatePrecisionCriteria" });
                }
            }

            if (labSheetDetail.IntertechDuplicateRLog != null)
            {
                if (labSheetDetail.IntertechDuplicateRLog < 0 || labSheetDetail.IntertechDuplicateRLog > 100)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIntertechDuplicateRLog, "0", "100"), new[] { "IntertechDuplicateRLog" });
                }
            }

            if (labSheetDetail.IntertechDuplicatePrecisionCriteria != null)
            {
                if (labSheetDetail.IntertechDuplicatePrecisionCriteria < 0 || labSheetDetail.IntertechDuplicatePrecisionCriteria > 100)
                {
                    labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetDetailIntertechDuplicatePrecisionCriteria, "0", "100"), new[] { "IntertechDuplicatePrecisionCriteria" });
                }
            }

            if (labSheetDetail.LastUpdateDate_UTC.Year == 1)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetDetailLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheetDetail.LastUpdateDate_UTC.Year < 1980)
                {
                labSheetDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetDetailLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheetDetail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                labSheetDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetDetailLastUpdateContactTVItemID, (labSheetDetail.LastUpdateContactTVItemID == null ? "" : labSheetDetail.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetDetailLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public LabSheetDetail GetLabSheetDetailWithLabSheetDetailID(int LabSheetDetailID, GetParam getParam)
        {
            IQueryable<LabSheetDetail> labSheetDetailQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.LabSheetDetailID == LabSheetDetailID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return labSheetDetailQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillLabSheetDetailWeb(labSheetDetailQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillLabSheetDetailReport(labSheetDetailQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<LabSheetDetail> GetLabSheetDetailList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<LabSheetDetail> labSheetDetailQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            labSheetDetailQuery  = labSheetDetailQuery.OrderByDescending(c => c.LabSheetDetailID);
                        }
                        labSheetDetailQuery = labSheetDetailQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return labSheetDetailQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            labSheetDetailQuery = FillLabSheetDetailWeb(labSheetDetailQuery, FilterAndOrderText).OrderByDescending(c => c.LabSheetDetailID);
                        }
                        labSheetDetailQuery = FillLabSheetDetailWeb(labSheetDetailQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return labSheetDetailQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            labSheetDetailQuery = FillLabSheetDetailReport(labSheetDetailQuery, FilterAndOrderText).OrderByDescending(c => c.LabSheetDetailID);
                        }
                        labSheetDetailQuery = FillLabSheetDetailReport(labSheetDetailQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return labSheetDetailQuery;
                    }
                default:
                    return null;
            }
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
        public IQueryable<LabSheetDetail> GetRead()
        {
            return db.LabSheetDetails.AsNoTracking();
        }
        public IQueryable<LabSheetDetail> GetEdit()
        {
            return db.LabSheetDetails;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated LabSheetDetailFillWeb
        private IQueryable<LabSheetDetail> FillLabSheetDetailWeb(IQueryable<LabSheetDetail> labSheetDetailQuery, string FilterAndOrderText)
        {
            labSheetDetailQuery = (from c in labSheetDetailQuery
                let SubsectorTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new LabSheetDetail
                    {
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
                        LabSheetDetailWeb = new LabSheetDetailWeb
                        {
                            SubsectorTVText = SubsectorTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        LabSheetDetailReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return labSheetDetailQuery;
        }
        #endregion Functions private Generated LabSheetDetailFillWeb

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
