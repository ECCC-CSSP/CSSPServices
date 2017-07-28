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
    public partial class LabSheetA1SheetService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetA1SheetService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheetA1Sheet labSheetA1Sheet = validationContext.ObjectInstance as LabSheetA1Sheet;

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Error))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetError), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            //Version (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheetA1Sheet.Version < 1 || labSheetA1Sheet.Version > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetA1SheetVersion, "1", "100"), new[] { "Version" });
            }

            retStr = enums.SamplingPlanTypeOK(labSheetA1Sheet.SamplingPlanType);
            if (labSheetA1Sheet.SamplingPlanType == SamplingPlanTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSamplingPlanType), new[] { "SamplingPlanType" });
            }

            retStr = enums.SampleTypeOK(labSheetA1Sheet.SampleType);
            if (labSheetA1Sheet.SampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSampleType), new[] { "SampleType" });
            }

            retStr = enums.LabSheetTypeOK(labSheetA1Sheet.LabSheetType);
            if (labSheetA1Sheet.LabSheetType == LabSheetTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetLabSheetType), new[] { "LabSheetType" });
            }

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SubsectorName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSubsectorName), new[] { "SubsectorName" });
            }

            //SubsectorName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SubsectorLocation))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSubsectorLocation), new[] { "SubsectorLocation" });
            }

            //SubsectorLocation has no StringLength Attribute

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SubsectorTVItemID has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunYear), new[] { "RunYear" });
            }

            //RunYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunMonth), new[] { "RunMonth" });
            }

            //RunMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunDay), new[] { "RunDay" });
            }

            //RunDay has no StringLength Attribute

            //RunNumber (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //RunNumber has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Tides))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTides), new[] { "Tides" });
            }

            //Tides has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SampleCrewInitials))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSampleCrewInitials), new[] { "SampleCrewInitials" });
            }

            //SampleCrewInitials has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationStartSameDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationStartSameDay), new[] { "IncubationStartSameDay" });
            }

            //IncubationStartSameDay has no StringLength Attribute

            //WaterBathCount (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //WaterBathCount has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath1StartTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath1StartTime), new[] { "IncubationBath1StartTime" });
            }

            //IncubationBath1StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath2StartTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath2StartTime), new[] { "IncubationBath2StartTime" });
            }

            //IncubationBath2StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath3StartTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath3StartTime), new[] { "IncubationBath3StartTime" });
            }

            //IncubationBath3StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath1EndTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath1EndTime), new[] { "IncubationBath1EndTime" });
            }

            //IncubationBath1EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath2EndTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath2EndTime), new[] { "IncubationBath2EndTime" });
            }

            //IncubationBath2EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath3EndTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath3EndTime), new[] { "IncubationBath3EndTime" });
            }

            //IncubationBath3EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath1TimeCalculated))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath1TimeCalculated), new[] { "IncubationBath1TimeCalculated" });
            }

            //IncubationBath1TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath2TimeCalculated))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath2TimeCalculated), new[] { "IncubationBath2TimeCalculated" });
            }

            //IncubationBath2TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath3TimeCalculated))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath3TimeCalculated), new[] { "IncubationBath3TimeCalculated" });
            }

            //IncubationBath3TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.WaterBath1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetWaterBath1), new[] { "WaterBath1" });
            }

            //WaterBath1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.WaterBath2))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetWaterBath2), new[] { "WaterBath2" });
            }

            //WaterBath2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.WaterBath3))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetWaterBath3), new[] { "WaterBath3" });
            }

            //WaterBath3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCField1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCField1), new[] { "TCField1" });
            }

            //TCField1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCLab1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCLab1), new[] { "TCLab1" });
            }

            //TCLab1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCHas2Coolers))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCHas2Coolers), new[] { "TCHas2Coolers" });
            }

            //TCHas2Coolers has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCField2))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCField2), new[] { "TCField2" });
            }

            //TCField2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCLab2))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCLab2), new[] { "TCLab2" });
            }

            //TCLab2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCFirst))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCFirst), new[] { "TCFirst" });
            }

            //TCFirst has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCAverage))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCAverage), new[] { "TCAverage" });
            }

            //TCAverage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ControlLot))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetControlLot), new[] { "ControlLot" });
            }

            //ControlLot has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Positive35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetPositive35), new[] { "Positive35" });
            }

            //Positive35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.NonTarget35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetNonTarget35), new[] { "NonTarget35" });
            }

            //NonTarget35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Negative35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetNegative35), new[] { "Negative35" });
            }

            //Negative35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1Positive44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath1Positive44_5), new[] { "Bath1Positive44_5" });
            }

            //Bath1Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2Positive44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath2Positive44_5), new[] { "Bath2Positive44_5" });
            }

            //Bath2Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3Positive44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath3Positive44_5), new[] { "Bath3Positive44_5" });
            }

            //Bath3Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1NonTarget44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath1NonTarget44_5), new[] { "Bath1NonTarget44_5" });
            }

            //Bath1NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2NonTarget44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath2NonTarget44_5), new[] { "Bath2NonTarget44_5" });
            }

            //Bath2NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3NonTarget44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath3NonTarget44_5), new[] { "Bath3NonTarget44_5" });
            }

            //Bath3NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1Negative44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath1Negative44_5), new[] { "Bath1Negative44_5" });
            }

            //Bath1Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2Negative44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath2Negative44_5), new[] { "Bath2Negative44_5" });
            }

            //Bath2Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3Negative44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath3Negative44_5), new[] { "Bath3Negative44_5" });
            }

            //Bath3Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Blank35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBlank35), new[] { "Blank35" });
            }

            //Blank35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1Blank44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath1Blank44_5), new[] { "Bath1Blank44_5" });
            }

            //Bath1Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2Blank44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath2Blank44_5), new[] { "Bath2Blank44_5" });
            }

            //Bath2Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3Blank44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath3Blank44_5), new[] { "Bath3Blank44_5" });
            }

            //Bath3Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Lot35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetLot35), new[] { "Lot35" });
            }

            //Lot35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Lot44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetLot44_5), new[] { "Lot44_5" });
            }

            //Lot44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunComment), new[] { "RunComment" });
            }

            //RunComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunWeatherComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunWeatherComment), new[] { "RunWeatherComment" });
            }

            //RunWeatherComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SampleBottleLotNumber))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSampleBottleLotNumber), new[] { "SampleBottleLotNumber" });
            }

            //SampleBottleLotNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadBy))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSalinitiesReadBy), new[] { "SalinitiesReadBy" });
            }

            //SalinitiesReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSalinitiesReadYear), new[] { "SalinitiesReadYear" });
            }

            //SalinitiesReadYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSalinitiesReadMonth), new[] { "SalinitiesReadMonth" });
            }

            //SalinitiesReadMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSalinitiesReadDay), new[] { "SalinitiesReadDay" });
            }

            //SalinitiesReadDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadBy))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsReadBy), new[] { "ResultsReadBy" });
            }

            //ResultsReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsReadYear), new[] { "ResultsReadYear" });
            }

            //ResultsReadYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsReadMonth), new[] { "ResultsReadMonth" });
            }

            //ResultsReadMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsReadDay), new[] { "ResultsReadDay" });
            }

            //ResultsReadDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedBy))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsRecordedBy), new[] { "ResultsRecordedBy" });
            }

            //ResultsRecordedBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsRecordedYear), new[] { "ResultsRecordedYear" });
            }

            //ResultsRecordedYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsRecordedMonth), new[] { "ResultsRecordedMonth" });
            }

            //ResultsRecordedMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsRecordedDay), new[] { "ResultsRecordedDay" });
            }

            //ResultsRecordedDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.DailyDuplicateRLog))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetDailyDuplicateRLog), new[] { "DailyDuplicateRLog" });
            }

            //DailyDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.DailyDuplicatePrecisionCriteria))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetDailyDuplicatePrecisionCriteria), new[] { "DailyDuplicatePrecisionCriteria" });
            }

            //DailyDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.DailyDuplicateAcceptableOrUnacceptable))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable), new[] { "DailyDuplicateAcceptableOrUnacceptable" });
            }

            //DailyDuplicateAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechDuplicateRLog))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIntertechDuplicateRLog), new[] { "IntertechDuplicateRLog" });
            }

            //IntertechDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechDuplicatePrecisionCriteria))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIntertechDuplicatePrecisionCriteria), new[] { "IntertechDuplicatePrecisionCriteria" });
            }

            //IntertechDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechDuplicateAcceptableOrUnacceptable))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable), new[] { "IntertechDuplicateAcceptableOrUnacceptable" });
            }

            //IntertechDuplicateAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechReadAcceptableOrUnacceptable))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIntertechReadAcceptableOrUnacceptable), new[] { "IntertechReadAcceptableOrUnacceptable" });
            }

            //IntertechReadAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovalYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetApprovalYear), new[] { "ApprovalYear" });
            }

            //ApprovalYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovalMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetApprovalMonth), new[] { "ApprovalMonth" });
            }

            //ApprovalMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovalDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetApprovalDay), new[] { "ApprovalDay" });
            }

            //ApprovalDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovedBySupervisorInitials))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetApprovedBySupervisorInitials), new[] { "ApprovedBySupervisorInitials" });
            }

            //ApprovedBySupervisorInitials has no StringLength Attribute

            //IncludeLaboratoryQAQC (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Log))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetLog), new[] { "Log" });
            }

            //Log has no StringLength Attribute

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
