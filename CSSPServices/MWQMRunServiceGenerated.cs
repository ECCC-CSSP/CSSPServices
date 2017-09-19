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
    ///     <para>bonjour MWQMRun</para>
    /// </summary>
    public partial class MWQMRunService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMRunService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMRun mwqmRun = validationContext.ObjectInstance as MWQMRun;
            mwqmRun.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmRun.MWQMRunID == 0)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunMWQMRunID), new[] { "MWQMRunID" });
                }

                if (!GetRead().Where(c => c.MWQMRunID == mwqmRun.MWQMRunID).Any())
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMRun, CSSPModelsRes.MWQMRunMWQMRunID, mwqmRun.MWQMRunID.ToString()), new[] { "MWQMRunID" });
                }
            }

            //MWQMRunID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunSubsectorTVItemID, mwqmRun.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunSubsectorTVItemID, "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            //MWQMRunTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.MWQMRunTVItemID select c).FirstOrDefault();

            if (TVItemMWQMRunTVItemID == null)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunMWQMRunTVItemID, mwqmRun.MWQMRunTVItemID.ToString()), new[] { "MWQMRunTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMRun,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMRunTVItemID.TVType))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunMWQMRunTVItemID, "MWQMRun"), new[] { "MWQMRunTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)mwqmRun.RunSampleType);
            if (mwqmRun.RunSampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunRunSampleType), new[] { "RunSampleType" });
            }

            if (mwqmRun.DateTime_Local.Year == 1)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunDateTime_Local), new[] { "DateTime_Local" });
            }
            else
            {
                if (mwqmRun.DateTime_Local.Year < 1980)
                {
                mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunDateTime_Local, "1980"), new[] { "DateTime_Local" });
                }
            }

            //RunNumber (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmRun.RunNumber < 1 || mwqmRun.RunNumber > 1000)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRunNumber, "1", "1000"), new[] { "RunNumber" });
            }

            if (mwqmRun.StartDateTime_Local != null && ((DateTime)mwqmRun.StartDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunStartDateTime_Local, "1980"), new[] { CSSPModelsRes.MWQMRunStartDateTime_Local });
            }

            if (mwqmRun.EndDateTime_Local != null && ((DateTime)mwqmRun.EndDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunEndDateTime_Local, "1980"), new[] { CSSPModelsRes.MWQMRunEndDateTime_Local });
            }

            if (mwqmRun.StartDateTime_Local > mwqmRun.EndDateTime_Local)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, CSSPModelsRes.MWQMRunEndDateTime_Local, CSSPModelsRes.MWQMRunStartDateTime_Local), new[] { CSSPModelsRes.MWQMRunEndDateTime_Local });
            }

            if (mwqmRun.LabReceivedDateTime_Local != null && ((DateTime)mwqmRun.LabReceivedDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunLabReceivedDateTime_Local, "1980"), new[] { CSSPModelsRes.MWQMRunLabReceivedDateTime_Local });
            }

            if (mwqmRun.TemperatureControl1_C != null)
            {
                if (mwqmRun.TemperatureControl1_C < -10 || mwqmRun.TemperatureControl1_C > 40)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunTemperatureControl1_C, "-10", "40"), new[] { "TemperatureControl1_C" });
                }
            }

            if (mwqmRun.TemperatureControl2_C != null)
            {
                if (mwqmRun.TemperatureControl2_C < -10 || mwqmRun.TemperatureControl2_C > 40)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunTemperatureControl2_C, "-10", "40"), new[] { "TemperatureControl2_C" });
                }
            }

            if (mwqmRun.SeaStateAtStart_BeaufortScale != null)
            {
                retStr = enums.EnumTypeOK(typeof(BeaufortScaleEnum), (int?)mwqmRun.SeaStateAtStart_BeaufortScale);
                if (mwqmRun.SeaStateAtStart_BeaufortScale == BeaufortScaleEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunSeaStateAtStart_BeaufortScale), new[] { "SeaStateAtStart_BeaufortScale" });
                }
            }

            if (mwqmRun.SeaStateAtEnd_BeaufortScale != null)
            {
                retStr = enums.EnumTypeOK(typeof(BeaufortScaleEnum), (int?)mwqmRun.SeaStateAtEnd_BeaufortScale);
                if (mwqmRun.SeaStateAtEnd_BeaufortScale == BeaufortScaleEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunSeaStateAtEnd_BeaufortScale), new[] { "SeaStateAtEnd_BeaufortScale" });
                }
            }

            if (mwqmRun.WaterLevelAtBrook_m != null)
            {
                if (mwqmRun.WaterLevelAtBrook_m < 0 || mwqmRun.WaterLevelAtBrook_m > 100)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100"), new[] { "WaterLevelAtBrook_m" });
                }
            }

            if (mwqmRun.WaveHightAtStart_m != null)
            {
                if (mwqmRun.WaveHightAtStart_m < 0 || mwqmRun.WaveHightAtStart_m > 100)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunWaveHightAtStart_m, "0", "100"), new[] { "WaveHightAtStart_m" });
                }
            }

            if (mwqmRun.WaveHightAtEnd_m != null)
            {
                if (mwqmRun.WaveHightAtEnd_m < 0 || mwqmRun.WaveHightAtEnd_m > 100)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100"), new[] { "WaveHightAtEnd_m" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SampleCrewInitials) && mwqmRun.SampleCrewInitials.Length > 20)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunSampleCrewInitials, "20"), new[] { "SampleCrewInitials" });
            }

            if (mwqmRun.AnalyzeMethod != null)
            {
                retStr = enums.EnumTypeOK(typeof(AnalyzeMethodEnum), (int?)mwqmRun.AnalyzeMethod);
                if (mwqmRun.AnalyzeMethod == AnalyzeMethodEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunAnalyzeMethod), new[] { "AnalyzeMethod" });
                }
            }

            if (mwqmRun.SampleMatrix != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleMatrixEnum), (int?)mwqmRun.SampleMatrix);
                if (mwqmRun.SampleMatrix == SampleMatrixEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunSampleMatrix), new[] { "SampleMatrix" });
                }
            }

            if (mwqmRun.Laboratory != null)
            {
                retStr = enums.EnumTypeOK(typeof(LaboratoryEnum), (int?)mwqmRun.Laboratory);
                if (mwqmRun.Laboratory == LaboratoryEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLaboratory), new[] { "Laboratory" });
                }
            }

            if (mwqmRun.SampleStatus != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleStatusEnum), (int?)mwqmRun.SampleStatus);
                if (mwqmRun.SampleStatus == SampleStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunSampleStatus), new[] { "SampleStatus" });
                }
            }

            if (mwqmRun.LabSampleApprovalContactTVItemID != null)
            {
                TVItem TVItemLabSampleApprovalContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.LabSampleApprovalContactTVItemID select c).FirstOrDefault();

                if (TVItemLabSampleApprovalContactTVItemID == null)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunLabSampleApprovalContactTVItemID, mwqmRun.LabSampleApprovalContactTVItemID.ToString()), new[] { "LabSampleApprovalContactTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLabSampleApprovalContactTVItemID.TVType))
                    {
                        mwqmRun.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunLabSampleApprovalContactTVItemID, "Contact"), new[] { "LabSampleApprovalContactTVItemID" });
                    }
                }
            }

            if (mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local, "1980"), new[] { CSSPModelsRes.MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local });
            }

            if (mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local, "1980"), new[] { CSSPModelsRes.MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local });
            }

            if (mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local, "1980"), new[] { CSSPModelsRes.MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local });
            }

            if (mwqmRun.LabRunSampleApprovalDateTime_Local != null && ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunLabRunSampleApprovalDateTime_Local, "1980"), new[] { CSSPModelsRes.MWQMRunLabRunSampleApprovalDateTime_Local });
            }

            if (mwqmRun.Tide_Start != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)mwqmRun.Tide_Start);
                if (mwqmRun.Tide_Start == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunTide_Start), new[] { "Tide_Start" });
                }
            }

            if (mwqmRun.Tide_End != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)mwqmRun.Tide_End);
                if (mwqmRun.Tide_End == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunTide_End), new[] { "Tide_End" });
                }
            }

            if (mwqmRun.RainDay0_mm != null)
            {
                if (mwqmRun.RainDay0_mm < 0 || mwqmRun.RainDay0_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay0_mm, "0", "300"), new[] { "RainDay0_mm" });
                }
            }

            if (mwqmRun.RainDay1_mm != null)
            {
                if (mwqmRun.RainDay1_mm < 0 || mwqmRun.RainDay1_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay1_mm, "0", "300"), new[] { "RainDay1_mm" });
                }
            }

            if (mwqmRun.RainDay2_mm != null)
            {
                if (mwqmRun.RainDay2_mm < 0 || mwqmRun.RainDay2_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay2_mm, "0", "300"), new[] { "RainDay2_mm" });
                }
            }

            if (mwqmRun.RainDay3_mm != null)
            {
                if (mwqmRun.RainDay3_mm < 0 || mwqmRun.RainDay3_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay3_mm, "0", "300"), new[] { "RainDay3_mm" });
                }
            }

            if (mwqmRun.RainDay4_mm != null)
            {
                if (mwqmRun.RainDay4_mm < 0 || mwqmRun.RainDay4_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay4_mm, "0", "300"), new[] { "RainDay4_mm" });
                }
            }

            if (mwqmRun.RainDay5_mm != null)
            {
                if (mwqmRun.RainDay5_mm < 0 || mwqmRun.RainDay5_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay5_mm, "0", "300"), new[] { "RainDay5_mm" });
                }
            }

            if (mwqmRun.RainDay6_mm != null)
            {
                if (mwqmRun.RainDay6_mm < 0 || mwqmRun.RainDay6_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay6_mm, "0", "300"), new[] { "RainDay6_mm" });
                }
            }

            if (mwqmRun.RainDay7_mm != null)
            {
                if (mwqmRun.RainDay7_mm < 0 || mwqmRun.RainDay7_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay7_mm, "0", "300"), new[] { "RainDay7_mm" });
                }
            }

            if (mwqmRun.RainDay8_mm != null)
            {
                if (mwqmRun.RainDay8_mm < 0 || mwqmRun.RainDay8_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay8_mm, "0", "300"), new[] { "RainDay8_mm" });
                }
            }

            if (mwqmRun.RainDay9_mm != null)
            {
                if (mwqmRun.RainDay9_mm < 0 || mwqmRun.RainDay9_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay9_mm, "0", "300"), new[] { "RainDay9_mm" });
                }
            }

            if (mwqmRun.RainDay10_mm != null)
            {
                if (mwqmRun.RainDay10_mm < 0 || mwqmRun.RainDay10_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMRunRainDay10_mm, "0", "300"), new[] { "RainDay10_mm" });
                }
            }

            if (mwqmRun.LastUpdateDate_UTC.Year == 1)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMRunLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmRun.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMRunLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMRunLastUpdateContactTVItemID, mwqmRun.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMRunLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SubsectorTVText) && mwqmRun.SubsectorTVText.Length > 200)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunSubsectorTVText, "200"), new[] { "SubsectorTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.MWQMRunTVText) && mwqmRun.MWQMRunTVText.Length > 200)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunMWQMRunTVText, "200"), new[] { "MWQMRunTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.LabSampleApprovalContactTVText) && mwqmRun.LabSampleApprovalContactTVText.Length > 200)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunLabSampleApprovalContactTVText, "200"), new[] { "LabSampleApprovalContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.LastUpdateContactTVText) && mwqmRun.LastUpdateContactTVText.Length > 200)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.RunSampleTypeText) && mwqmRun.RunSampleTypeText.Length > 100)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunRunSampleTypeText, "100"), new[] { "RunSampleTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SeaStateAtStart_BeaufortScaleText) && mwqmRun.SeaStateAtStart_BeaufortScaleText.Length > 100)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunSeaStateAtStart_BeaufortScaleText, "100"), new[] { "SeaStateAtStart_BeaufortScaleText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SeaStateAtEnd_BeaufortScaleText) && mwqmRun.SeaStateAtEnd_BeaufortScaleText.Length > 100)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunSeaStateAtEnd_BeaufortScaleText, "100"), new[] { "SeaStateAtEnd_BeaufortScaleText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.AnalyzeMethodText) && mwqmRun.AnalyzeMethodText.Length > 100)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunAnalyzeMethodText, "100"), new[] { "AnalyzeMethodText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SampleMatrixText) && mwqmRun.SampleMatrixText.Length > 100)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunSampleMatrixText, "100"), new[] { "SampleMatrixText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.LaboratoryText) && mwqmRun.LaboratoryText.Length > 100)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunLaboratoryText, "100"), new[] { "LaboratoryText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SampleStatusText) && mwqmRun.SampleStatusText.Length > 100)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunSampleStatusText, "100"), new[] { "SampleStatusText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.Tide_StartText) && mwqmRun.Tide_StartText.Length > 100)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunTide_StartText, "100"), new[] { "Tide_StartText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.Tide_EndText) && mwqmRun.Tide_EndText.Length > 100)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMRunTide_EndText, "100"), new[] { "Tide_EndText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMRun GetMWQMRunWithMWQMRunID(int MWQMRunID)
        {
            IQueryable<MWQMRun> mwqmRunQuery = (from c in GetRead()
                                                where c.MWQMRunID == MWQMRunID
                                                select c);

            return FillMWQMRun(mwqmRunQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMRun mwqmRun)
        {
            mwqmRun.ValidationResults = Validate(new ValidationContext(mwqmRun), ActionDBTypeEnum.Create);
            if (mwqmRun.ValidationResults.Count() > 0) return false;

            db.MWQMRuns.Add(mwqmRun);

            if (!TryToSave(mwqmRun)) return false;

            return true;
        }
        public bool Delete(MWQMRun mwqmRun)
        {
            mwqmRun.ValidationResults = Validate(new ValidationContext(mwqmRun), ActionDBTypeEnum.Delete);
            if (mwqmRun.ValidationResults.Count() > 0) return false;

            db.MWQMRuns.Remove(mwqmRun);

            if (!TryToSave(mwqmRun)) return false;

            return true;
        }
        public bool Update(MWQMRun mwqmRun)
        {
            mwqmRun.ValidationResults = Validate(new ValidationContext(mwqmRun), ActionDBTypeEnum.Update);
            if (mwqmRun.ValidationResults.Count() > 0) return false;

            db.MWQMRuns.Update(mwqmRun);

            if (!TryToSave(mwqmRun)) return false;

            return true;
        }
        public IQueryable<MWQMRun> GetRead()
        {
            return db.MWQMRuns.AsNoTracking();
        }
        public IQueryable<MWQMRun> GetEdit()
        {
            return db.MWQMRuns;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MWQMRun> FillMWQMRun(IQueryable<MWQMRun> mwqmRunQuery)
        {
            List<MWQMRun> MWQMRunList = (from c in mwqmRunQuery
                                         let SubsectorTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.SubsectorTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let MWQMRunTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.MWQMRunTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LabSampleApprovalContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LabSampleApprovalContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MWQMRun
                                         {
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
                                             SubsectorTVText = SubsectorTVText,
                                             MWQMRunTVText = MWQMRunTVText,
                                             LabSampleApprovalContactTVText = LabSampleApprovalContactTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (MWQMRun mwqmRun in MWQMRunList)
            {
                mwqmRun.RunSampleTypeText = enums.GetResValueForTypeAndID(typeof(SampleTypeEnum), (int?)mwqmRun.RunSampleType);
                mwqmRun.SeaStateAtStart_BeaufortScaleText = enums.GetResValueForTypeAndID(typeof(BeaufortScaleEnum), (int?)mwqmRun.SeaStateAtStart_BeaufortScale);
                mwqmRun.SeaStateAtEnd_BeaufortScaleText = enums.GetResValueForTypeAndID(typeof(BeaufortScaleEnum), (int?)mwqmRun.SeaStateAtEnd_BeaufortScale);
                mwqmRun.AnalyzeMethodText = enums.GetResValueForTypeAndID(typeof(AnalyzeMethodEnum), (int?)mwqmRun.AnalyzeMethod);
                mwqmRun.SampleMatrixText = enums.GetResValueForTypeAndID(typeof(SampleMatrixEnum), (int?)mwqmRun.SampleMatrix);
                mwqmRun.LaboratoryText = enums.GetResValueForTypeAndID(typeof(LaboratoryEnum), (int?)mwqmRun.Laboratory);
                mwqmRun.SampleStatusText = enums.GetResValueForTypeAndID(typeof(SampleStatusEnum), (int?)mwqmRun.SampleStatus);
                mwqmRun.Tide_StartText = enums.GetResValueForTypeAndID(typeof(TideTextEnum), (int?)mwqmRun.Tide_Start);
                mwqmRun.Tide_EndText = enums.GetResValueForTypeAndID(typeof(TideTextEnum), (int?)mwqmRun.Tide_End);
            }

            return MWQMRunList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(MWQMRun mwqmRun)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmRun.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
