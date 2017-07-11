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
        public LabSheetA1SheetService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
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
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetError), new[] { ModelsRes.LabSheetA1SheetError });
            }

            //Error has no StringLength Attribute

            //Version (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheetA1Sheet.Version < 1 || labSheetA1Sheet.Version > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetA1SheetVersion, "1", "100"), new[] { ModelsRes.LabSheetA1SheetVersion });
            }

            retStr = enums.SamplingPlanTypeOK(labSheetA1Sheet.SamplingPlanType);
            if (labSheetA1Sheet.SamplingPlanType == SamplingPlanTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSamplingPlanType), new[] { ModelsRes.LabSheetA1SheetSamplingPlanType });
            }

            retStr = enums.SampleTypeOK(labSheetA1Sheet.SampleType);
            if (labSheetA1Sheet.SampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSampleType), new[] { ModelsRes.LabSheetA1SheetSampleType });
            }

            retStr = enums.LabSheetTypeOK(labSheetA1Sheet.LabSheetType);
            if (labSheetA1Sheet.LabSheetType == LabSheetTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetLabSheetType), new[] { ModelsRes.LabSheetA1SheetLabSheetType });
            }

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SubsectorName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSubsectorName), new[] { ModelsRes.LabSheetA1SheetSubsectorName });
            }

            //SubsectorName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SubsectorLocation))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSubsectorLocation), new[] { ModelsRes.LabSheetA1SheetSubsectorLocation });
            }

            //SubsectorLocation has no StringLength Attribute

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SubsectorTVItemID has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunYear), new[] { ModelsRes.LabSheetA1SheetRunYear });
            }

            //RunYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunMonth), new[] { ModelsRes.LabSheetA1SheetRunMonth });
            }

            //RunMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunDay), new[] { ModelsRes.LabSheetA1SheetRunDay });
            }

            //RunDay has no StringLength Attribute

            //RunNumber (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //RunNumber has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Tides))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTides), new[] { ModelsRes.LabSheetA1SheetTides });
            }

            //Tides has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SampleCrewInitials))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSampleCrewInitials), new[] { ModelsRes.LabSheetA1SheetSampleCrewInitials });
            }

            //SampleCrewInitials has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationStartSameDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationStartSameDay), new[] { ModelsRes.LabSheetA1SheetIncubationStartSameDay });
            }

            //IncubationStartSameDay has no StringLength Attribute

            //WaterBathCount (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //WaterBathCount has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath1StartTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath1StartTime), new[] { ModelsRes.LabSheetA1SheetIncubationBath1StartTime });
            }

            //IncubationBath1StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath2StartTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath2StartTime), new[] { ModelsRes.LabSheetA1SheetIncubationBath2StartTime });
            }

            //IncubationBath2StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath3StartTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath3StartTime), new[] { ModelsRes.LabSheetA1SheetIncubationBath3StartTime });
            }

            //IncubationBath3StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath1EndTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath1EndTime), new[] { ModelsRes.LabSheetA1SheetIncubationBath1EndTime });
            }

            //IncubationBath1EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath2EndTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath2EndTime), new[] { ModelsRes.LabSheetA1SheetIncubationBath2EndTime });
            }

            //IncubationBath2EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath3EndTime))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath3EndTime), new[] { ModelsRes.LabSheetA1SheetIncubationBath3EndTime });
            }

            //IncubationBath3EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath1TimeCalculated))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath1TimeCalculated), new[] { ModelsRes.LabSheetA1SheetIncubationBath1TimeCalculated });
            }

            //IncubationBath1TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath2TimeCalculated))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath2TimeCalculated), new[] { ModelsRes.LabSheetA1SheetIncubationBath2TimeCalculated });
            }

            //IncubationBath2TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath3TimeCalculated))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIncubationBath3TimeCalculated), new[] { ModelsRes.LabSheetA1SheetIncubationBath3TimeCalculated });
            }

            //IncubationBath3TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.WaterBath1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetWaterBath1), new[] { ModelsRes.LabSheetA1SheetWaterBath1 });
            }

            //WaterBath1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.WaterBath2))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetWaterBath2), new[] { ModelsRes.LabSheetA1SheetWaterBath2 });
            }

            //WaterBath2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.WaterBath3))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetWaterBath3), new[] { ModelsRes.LabSheetA1SheetWaterBath3 });
            }

            //WaterBath3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCField1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCField1), new[] { ModelsRes.LabSheetA1SheetTCField1 });
            }

            //TCField1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCLab1))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCLab1), new[] { ModelsRes.LabSheetA1SheetTCLab1 });
            }

            //TCLab1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCHas2Coolers))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCHas2Coolers), new[] { ModelsRes.LabSheetA1SheetTCHas2Coolers });
            }

            //TCHas2Coolers has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCField2))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCField2), new[] { ModelsRes.LabSheetA1SheetTCField2 });
            }

            //TCField2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCLab2))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCLab2), new[] { ModelsRes.LabSheetA1SheetTCLab2 });
            }

            //TCLab2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCFirst))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCFirst), new[] { ModelsRes.LabSheetA1SheetTCFirst });
            }

            //TCFirst has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCAverage))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetTCAverage), new[] { ModelsRes.LabSheetA1SheetTCAverage });
            }

            //TCAverage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ControlLot))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetControlLot), new[] { ModelsRes.LabSheetA1SheetControlLot });
            }

            //ControlLot has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Positive35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetPositive35), new[] { ModelsRes.LabSheetA1SheetPositive35 });
            }

            //Positive35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.NonTarget35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetNonTarget35), new[] { ModelsRes.LabSheetA1SheetNonTarget35 });
            }

            //NonTarget35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Negative35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetNegative35), new[] { ModelsRes.LabSheetA1SheetNegative35 });
            }

            //Negative35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1Positive44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath1Positive44_5), new[] { ModelsRes.LabSheetA1SheetBath1Positive44_5 });
            }

            //Bath1Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2Positive44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath2Positive44_5), new[] { ModelsRes.LabSheetA1SheetBath2Positive44_5 });
            }

            //Bath2Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3Positive44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath3Positive44_5), new[] { ModelsRes.LabSheetA1SheetBath3Positive44_5 });
            }

            //Bath3Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1NonTarget44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath1NonTarget44_5), new[] { ModelsRes.LabSheetA1SheetBath1NonTarget44_5 });
            }

            //Bath1NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2NonTarget44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath2NonTarget44_5), new[] { ModelsRes.LabSheetA1SheetBath2NonTarget44_5 });
            }

            //Bath2NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3NonTarget44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath3NonTarget44_5), new[] { ModelsRes.LabSheetA1SheetBath3NonTarget44_5 });
            }

            //Bath3NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1Negative44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath1Negative44_5), new[] { ModelsRes.LabSheetA1SheetBath1Negative44_5 });
            }

            //Bath1Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2Negative44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath2Negative44_5), new[] { ModelsRes.LabSheetA1SheetBath2Negative44_5 });
            }

            //Bath2Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3Negative44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath3Negative44_5), new[] { ModelsRes.LabSheetA1SheetBath3Negative44_5 });
            }

            //Bath3Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Blank35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBlank35), new[] { ModelsRes.LabSheetA1SheetBlank35 });
            }

            //Blank35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1Blank44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath1Blank44_5), new[] { ModelsRes.LabSheetA1SheetBath1Blank44_5 });
            }

            //Bath1Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2Blank44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath2Blank44_5), new[] { ModelsRes.LabSheetA1SheetBath2Blank44_5 });
            }

            //Bath2Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3Blank44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetBath3Blank44_5), new[] { ModelsRes.LabSheetA1SheetBath3Blank44_5 });
            }

            //Bath3Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Lot35))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetLot35), new[] { ModelsRes.LabSheetA1SheetLot35 });
            }

            //Lot35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Lot44_5))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetLot44_5), new[] { ModelsRes.LabSheetA1SheetLot44_5 });
            }

            //Lot44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunComment), new[] { ModelsRes.LabSheetA1SheetRunComment });
            }

            //RunComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunWeatherComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetRunWeatherComment), new[] { ModelsRes.LabSheetA1SheetRunWeatherComment });
            }

            //RunWeatherComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SampleBottleLotNumber))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSampleBottleLotNumber), new[] { ModelsRes.LabSheetA1SheetSampleBottleLotNumber });
            }

            //SampleBottleLotNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadBy))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSalinitiesReadBy), new[] { ModelsRes.LabSheetA1SheetSalinitiesReadBy });
            }

            //SalinitiesReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSalinitiesReadYear), new[] { ModelsRes.LabSheetA1SheetSalinitiesReadYear });
            }

            //SalinitiesReadYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSalinitiesReadMonth), new[] { ModelsRes.LabSheetA1SheetSalinitiesReadMonth });
            }

            //SalinitiesReadMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetSalinitiesReadDay), new[] { ModelsRes.LabSheetA1SheetSalinitiesReadDay });
            }

            //SalinitiesReadDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadBy))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsReadBy), new[] { ModelsRes.LabSheetA1SheetResultsReadBy });
            }

            //ResultsReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsReadYear), new[] { ModelsRes.LabSheetA1SheetResultsReadYear });
            }

            //ResultsReadYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsReadMonth), new[] { ModelsRes.LabSheetA1SheetResultsReadMonth });
            }

            //ResultsReadMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsReadDay), new[] { ModelsRes.LabSheetA1SheetResultsReadDay });
            }

            //ResultsReadDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedBy))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsRecordedBy), new[] { ModelsRes.LabSheetA1SheetResultsRecordedBy });
            }

            //ResultsRecordedBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsRecordedYear), new[] { ModelsRes.LabSheetA1SheetResultsRecordedYear });
            }

            //ResultsRecordedYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsRecordedMonth), new[] { ModelsRes.LabSheetA1SheetResultsRecordedMonth });
            }

            //ResultsRecordedMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetResultsRecordedDay), new[] { ModelsRes.LabSheetA1SheetResultsRecordedDay });
            }

            //ResultsRecordedDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.DailyDuplicateRLog))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetDailyDuplicateRLog), new[] { ModelsRes.LabSheetA1SheetDailyDuplicateRLog });
            }

            //DailyDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.DailyDuplicatePrecisionCriteria))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetDailyDuplicatePrecisionCriteria), new[] { ModelsRes.LabSheetA1SheetDailyDuplicatePrecisionCriteria });
            }

            //DailyDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.DailyDuplicateAcceptableOrUnacceptable))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable), new[] { ModelsRes.LabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable });
            }

            //DailyDuplicateAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechDuplicateRLog))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIntertechDuplicateRLog), new[] { ModelsRes.LabSheetA1SheetIntertechDuplicateRLog });
            }

            //IntertechDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechDuplicatePrecisionCriteria))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIntertechDuplicatePrecisionCriteria), new[] { ModelsRes.LabSheetA1SheetIntertechDuplicatePrecisionCriteria });
            }

            //IntertechDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechDuplicateAcceptableOrUnacceptable))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable), new[] { ModelsRes.LabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable });
            }

            //IntertechDuplicateAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechReadAcceptableOrUnacceptable))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetIntertechReadAcceptableOrUnacceptable), new[] { ModelsRes.LabSheetA1SheetIntertechReadAcceptableOrUnacceptable });
            }

            //IntertechReadAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovalYear))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetApprovalYear), new[] { ModelsRes.LabSheetA1SheetApprovalYear });
            }

            //ApprovalYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovalMonth))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetApprovalMonth), new[] { ModelsRes.LabSheetA1SheetApprovalMonth });
            }

            //ApprovalMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovalDay))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetApprovalDay), new[] { ModelsRes.LabSheetA1SheetApprovalDay });
            }

            //ApprovalDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovedBySupervisorInitials))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetApprovedBySupervisorInitials), new[] { ModelsRes.LabSheetA1SheetApprovedBySupervisorInitials });
            }

            //ApprovedBySupervisorInitials has no StringLength Attribute

            //IncludeLaboratoryQAQC (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Log))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1SheetLog), new[] { ModelsRes.LabSheetA1SheetLog });
            }

            //Log has no StringLength Attribute

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
