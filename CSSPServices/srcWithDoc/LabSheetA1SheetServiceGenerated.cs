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
    ///     <para>bonjour LabSheetA1Sheet</para>
    /// </summary>
    public partial class LabSheetA1SheetService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetA1SheetService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheetA1Sheet labSheetA1Sheet = validationContext.ObjectInstance as LabSheetA1Sheet;
            labSheetA1Sheet.HasErrors = false;

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Error))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetError"), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            if (labSheetA1Sheet.Version < 1 || labSheetA1Sheet.Version > 100)
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetA1SheetVersion", "1", "100"), new[] { "Version" });
            }

            retStr = enums.EnumTypeOK(typeof(SamplingPlanTypeEnum), (int?)labSheetA1Sheet.SamplingPlanType);
            if (labSheetA1Sheet.SamplingPlanType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSamplingPlanType"), new[] { "SamplingPlanType" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheetA1Sheet.SampleType);
            if (labSheetA1Sheet.SampleType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSampleType"), new[] { "SampleType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetTypeEnum), (int?)labSheetA1Sheet.LabSheetType);
            if (labSheetA1Sheet.LabSheetType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetLabSheetType"), new[] { "LabSheetType" });
            }

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SubsectorName))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSubsectorName"), new[] { "SubsectorName" });
            }

            //SubsectorName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SubsectorLocation))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSubsectorLocation"), new[] { "SubsectorLocation" });
            }

            //SubsectorLocation has no StringLength Attribute

            //SubsectorTVItemID has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunYear))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetRunYear"), new[] { "RunYear" });
            }

            //RunYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunMonth))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetRunMonth"), new[] { "RunMonth" });
            }

            //RunMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunDay))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetRunDay"), new[] { "RunDay" });
            }

            //RunDay has no StringLength Attribute

            //RunNumber has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Tides))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetTides"), new[] { "Tides" });
            }

            //Tides has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SampleCrewInitials))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSampleCrewInitials"), new[] { "SampleCrewInitials" });
            }

            //SampleCrewInitials has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationStartSameDay))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationStartSameDay"), new[] { "IncubationStartSameDay" });
            }

            //IncubationStartSameDay has no StringLength Attribute

            //WaterBathCount has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath1StartTime))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationBath1StartTime"), new[] { "IncubationBath1StartTime" });
            }

            //IncubationBath1StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath2StartTime))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationBath2StartTime"), new[] { "IncubationBath2StartTime" });
            }

            //IncubationBath2StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath3StartTime))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationBath3StartTime"), new[] { "IncubationBath3StartTime" });
            }

            //IncubationBath3StartTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath1EndTime))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationBath1EndTime"), new[] { "IncubationBath1EndTime" });
            }

            //IncubationBath1EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath2EndTime))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationBath2EndTime"), new[] { "IncubationBath2EndTime" });
            }

            //IncubationBath2EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath3EndTime))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationBath3EndTime"), new[] { "IncubationBath3EndTime" });
            }

            //IncubationBath3EndTime has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath1TimeCalculated))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationBath1TimeCalculated"), new[] { "IncubationBath1TimeCalculated" });
            }

            //IncubationBath1TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath2TimeCalculated))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationBath2TimeCalculated"), new[] { "IncubationBath2TimeCalculated" });
            }

            //IncubationBath2TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IncubationBath3TimeCalculated))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIncubationBath3TimeCalculated"), new[] { "IncubationBath3TimeCalculated" });
            }

            //IncubationBath3TimeCalculated has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.WaterBath1))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetWaterBath1"), new[] { "WaterBath1" });
            }

            //WaterBath1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.WaterBath2))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetWaterBath2"), new[] { "WaterBath2" });
            }

            //WaterBath2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.WaterBath3))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetWaterBath3"), new[] { "WaterBath3" });
            }

            //WaterBath3 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCField1))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetTCField1"), new[] { "TCField1" });
            }

            //TCField1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCLab1))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetTCLab1"), new[] { "TCLab1" });
            }

            //TCLab1 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCHas2Coolers))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetTCHas2Coolers"), new[] { "TCHas2Coolers" });
            }

            //TCHas2Coolers has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCField2))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetTCField2"), new[] { "TCField2" });
            }

            //TCField2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCLab2))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetTCLab2"), new[] { "TCLab2" });
            }

            //TCLab2 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCFirst))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetTCFirst"), new[] { "TCFirst" });
            }

            //TCFirst has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.TCAverage))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetTCAverage"), new[] { "TCAverage" });
            }

            //TCAverage has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ControlLot))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetControlLot"), new[] { "ControlLot" });
            }

            //ControlLot has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Positive35))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetPositive35"), new[] { "Positive35" });
            }

            //Positive35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.NonTarget35))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetNonTarget35"), new[] { "NonTarget35" });
            }

            //NonTarget35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Negative35))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetNegative35"), new[] { "Negative35" });
            }

            //Negative35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1Positive44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath1Positive44_5"), new[] { "Bath1Positive44_5" });
            }

            //Bath1Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2Positive44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath2Positive44_5"), new[] { "Bath2Positive44_5" });
            }

            //Bath2Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3Positive44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath3Positive44_5"), new[] { "Bath3Positive44_5" });
            }

            //Bath3Positive44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1NonTarget44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath1NonTarget44_5"), new[] { "Bath1NonTarget44_5" });
            }

            //Bath1NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2NonTarget44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath2NonTarget44_5"), new[] { "Bath2NonTarget44_5" });
            }

            //Bath2NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3NonTarget44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath3NonTarget44_5"), new[] { "Bath3NonTarget44_5" });
            }

            //Bath3NonTarget44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1Negative44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath1Negative44_5"), new[] { "Bath1Negative44_5" });
            }

            //Bath1Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2Negative44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath2Negative44_5"), new[] { "Bath2Negative44_5" });
            }

            //Bath2Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3Negative44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath3Negative44_5"), new[] { "Bath3Negative44_5" });
            }

            //Bath3Negative44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Blank35))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBlank35"), new[] { "Blank35" });
            }

            //Blank35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath1Blank44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath1Blank44_5"), new[] { "Bath1Blank44_5" });
            }

            //Bath1Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath2Blank44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath2Blank44_5"), new[] { "Bath2Blank44_5" });
            }

            //Bath2Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Bath3Blank44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBath3Blank44_5"), new[] { "Bath3Blank44_5" });
            }

            //Bath3Blank44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Lot35))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetLot35"), new[] { "Lot35" });
            }

            //Lot35 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Lot44_5))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetLot44_5"), new[] { "Lot44_5" });
            }

            //Lot44_5 has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunComment))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetRunComment"), new[] { "RunComment" });
            }

            //RunComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.RunWeatherComment))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetRunWeatherComment"), new[] { "RunWeatherComment" });
            }

            //RunWeatherComment has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SampleBottleLotNumber))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSampleBottleLotNumber"), new[] { "SampleBottleLotNumber" });
            }

            //SampleBottleLotNumber has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadBy))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSalinitiesReadBy"), new[] { "SalinitiesReadBy" });
            }

            //SalinitiesReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadYear))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSalinitiesReadYear"), new[] { "SalinitiesReadYear" });
            }

            //SalinitiesReadYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadMonth))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSalinitiesReadMonth"), new[] { "SalinitiesReadMonth" });
            }

            //SalinitiesReadMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.SalinitiesReadDay))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetSalinitiesReadDay"), new[] { "SalinitiesReadDay" });
            }

            //SalinitiesReadDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadBy))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetResultsReadBy"), new[] { "ResultsReadBy" });
            }

            //ResultsReadBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadYear))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetResultsReadYear"), new[] { "ResultsReadYear" });
            }

            //ResultsReadYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadMonth))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetResultsReadMonth"), new[] { "ResultsReadMonth" });
            }

            //ResultsReadMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsReadDay))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetResultsReadDay"), new[] { "ResultsReadDay" });
            }

            //ResultsReadDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedBy))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetResultsRecordedBy"), new[] { "ResultsRecordedBy" });
            }

            //ResultsRecordedBy has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedYear))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetResultsRecordedYear"), new[] { "ResultsRecordedYear" });
            }

            //ResultsRecordedYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedMonth))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetResultsRecordedMonth"), new[] { "ResultsRecordedMonth" });
            }

            //ResultsRecordedMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ResultsRecordedDay))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetResultsRecordedDay"), new[] { "ResultsRecordedDay" });
            }

            //ResultsRecordedDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.DailyDuplicateRLog))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetDailyDuplicateRLog"), new[] { "DailyDuplicateRLog" });
            }

            //DailyDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.DailyDuplicatePrecisionCriteria))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetDailyDuplicatePrecisionCriteria"), new[] { "DailyDuplicatePrecisionCriteria" });
            }

            //DailyDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.DailyDuplicateAcceptableOrUnacceptable))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetDailyDuplicateAcceptableOrUnacceptable"), new[] { "DailyDuplicateAcceptableOrUnacceptable" });
            }

            //DailyDuplicateAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechDuplicateRLog))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIntertechDuplicateRLog"), new[] { "IntertechDuplicateRLog" });
            }

            //IntertechDuplicateRLog has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechDuplicatePrecisionCriteria))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIntertechDuplicatePrecisionCriteria"), new[] { "IntertechDuplicatePrecisionCriteria" });
            }

            //IntertechDuplicatePrecisionCriteria has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechDuplicateAcceptableOrUnacceptable))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIntertechDuplicateAcceptableOrUnacceptable"), new[] { "IntertechDuplicateAcceptableOrUnacceptable" });
            }

            //IntertechDuplicateAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.IntertechReadAcceptableOrUnacceptable))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetIntertechReadAcceptableOrUnacceptable"), new[] { "IntertechReadAcceptableOrUnacceptable" });
            }

            //IntertechReadAcceptableOrUnacceptable has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovalYear))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetApprovalYear"), new[] { "ApprovalYear" });
            }

            //ApprovalYear has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovalMonth))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetApprovalMonth"), new[] { "ApprovalMonth" });
            }

            //ApprovalMonth has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovalDay))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetApprovalDay"), new[] { "ApprovalDay" });
            }

            //ApprovalDay has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.ApprovedBySupervisorInitials))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetApprovedBySupervisorInitials"), new[] { "ApprovedBySupervisorInitials" });
            }

            //ApprovedBySupervisorInitials has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.BackupDirectory))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetBackupDirectory"), new[] { "BackupDirectory" });
            }

            //BackupDirectory has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Sheet.Log))
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetA1SheetLog"), new[] { "Log" });
            }

            //Log has no StringLength Attribute

            if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.SamplingPlanTypeText) && labSheetA1Sheet.SamplingPlanTypeText.Length > 100)
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetA1SheetSamplingPlanTypeText", "100"), new[] { "SamplingPlanTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.SampleTypeText) && labSheetA1Sheet.SampleTypeText.Length > 100)
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetA1SheetSampleTypeText", "100"), new[] { "SampleTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.LabSheetTypeText) && labSheetA1Sheet.LabSheetTypeText.Length > 100)
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetA1SheetLabSheetTypeText", "100"), new[] { "LabSheetTypeText" });
            }

                //Error: Type not implemented [LabSheetA1MeasurementList] of type [List`1]

                //Error: Type not implemented [LabSheetA1MeasurementList] of type [LabSheetA1Measurement]
            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                labSheetA1Sheet.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
