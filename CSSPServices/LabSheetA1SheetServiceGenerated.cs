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

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //Version is required but no testing needed as it is automatically set to 0

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

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // Error no min or max length set
            if (labSheetA1Sheet.Version < 1 || labSheetA1Sheet.Version > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetA1SheetVersion, "1", "100"), new[] { ModelsRes.LabSheetA1SheetVersion });
            }

            // SamplingPlanType no min or max length set
            // SampleType no min or max length set
            // LabSheetType no min or max length set
            // SubsectorName no min or max length set
            // SubsectorLocation no min or max length set
            // SubsectorTVItemID no min or max length set
            // RunYear no min or max length set
            // RunMonth no min or max length set
            // RunDay no min or max length set
            // RunNumber no min or max length set
            // Tides no min or max length set
            // SampleCrewInitials no min or max length set
            // IncubationStartSameDay no min or max length set
            // WaterBathCount no min or max length set
            // IncubationBath1StartTime no min or max length set
            // IncubationBath2StartTime no min or max length set
            // IncubationBath3StartTime no min or max length set
            // IncubationBath1EndTime no min or max length set
            // IncubationBath2EndTime no min or max length set
            // IncubationBath3EndTime no min or max length set
            // IncubationBath1TimeCalculated no min or max length set
            // IncubationBath2TimeCalculated no min or max length set
            // IncubationBath3TimeCalculated no min or max length set
            // WaterBath1 no min or max length set
            // WaterBath2 no min or max length set
            // WaterBath3 no min or max length set
            // TCField1 no min or max length set
            // TCLab1 no min or max length set
            // TCHas2Coolers no min or max length set
            // TCField2 no min or max length set
            // TCLab2 no min or max length set
            // TCFirst no min or max length set
            // TCAverage no min or max length set
            // ControlLot no min or max length set
            // Positive35 no min or max length set
            // NonTarget35 no min or max length set
            // Negative35 no min or max length set
            // Bath1Positive44_5 no min or max length set
            // Bath2Positive44_5 no min or max length set
            // Bath3Positive44_5 no min or max length set
            // Bath1NonTarget44_5 no min or max length set
            // Bath2NonTarget44_5 no min or max length set
            // Bath3NonTarget44_5 no min or max length set
            // Bath1Negative44_5 no min or max length set
            // Bath2Negative44_5 no min or max length set
            // Bath3Negative44_5 no min or max length set
            // Blank35 no min or max length set
            // Bath1Blank44_5 no min or max length set
            // Bath2Blank44_5 no min or max length set
            // Bath3Blank44_5 no min or max length set
            // Lot35 no min or max length set
            // Lot44_5 no min or max length set
            // RunComment no min or max length set
            // RunWeatherComment no min or max length set
            // SampleBottleLotNumber no min or max length set
            // SalinitiesReadBy no min or max length set
            // SalinitiesReadYear no min or max length set
            // SalinitiesReadMonth no min or max length set
            // SalinitiesReadDay no min or max length set
            // ResultsReadBy no min or max length set
            // ResultsReadYear no min or max length set
            // ResultsReadMonth no min or max length set
            // ResultsReadDay no min or max length set
            // ResultsRecordedBy no min or max length set
            // ResultsRecordedYear no min or max length set
            // ResultsRecordedMonth no min or max length set
            // ResultsRecordedDay no min or max length set
            // DailyDuplicateRLog no min or max length set
            // DailyDuplicatePrecisionCriteria no min or max length set
            // DailyDuplicateAcceptableOrUnacceptable no min or max length set
            // IntertechDuplicateRLog no min or max length set
            // IntertechDuplicatePrecisionCriteria no min or max length set
            // IntertechDuplicateAcceptableOrUnacceptable no min or max length set
            // IntertechReadAcceptableOrUnacceptable no min or max length set
            // ApprovalYear no min or max length set
            // ApprovalMonth no min or max length set
            // ApprovalDay no min or max length set
            // ApprovedBySupervisorInitials no min or max length set
            // Log no min or max length set

        }
        #endregion Validation

    }
}
