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
        public MWQMRunService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunMWQMRunID"), new[] { "MWQMRunID" });
                }

                if (!(from c in db.MWQMRuns select c).Where(c => c.MWQMRunID == mwqmRun.MWQMRunID).Any())
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunMWQMRunID", mwqmRun.MWQMRunID.ToString()), new[] { "MWQMRunID" });
                }
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunSubsectorTVItemID", mwqmRun.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunSubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            TVItem TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.MWQMRunTVItemID select c).FirstOrDefault();

            if (TVItemMWQMRunTVItemID == null)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunMWQMRunTVItemID", mwqmRun.MWQMRunTVItemID.ToString()), new[] { "MWQMRunTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunMWQMRunTVItemID", "MWQMRun"), new[] { "MWQMRunTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)mwqmRun.RunSampleType);
            if (mwqmRun.RunSampleType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunRunSampleType"), new[] { "RunSampleType" });
            }

            if (mwqmRun.DateTime_Local.Year == 1)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunDateTime_Local"), new[] { "DateTime_Local" });
            }
            else
            {
                if (mwqmRun.DateTime_Local.Year < 1980)
                {
                mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunDateTime_Local", "1980"), new[] { "DateTime_Local" });
                }
            }

            if (mwqmRun.RunNumber < 1 || mwqmRun.RunNumber > 1000)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRunNumber", "1", "1000"), new[] { "RunNumber" });
            }

            if (mwqmRun.StartDateTime_Local != null && ((DateTime)mwqmRun.StartDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunStartDateTime_Local", "1980"), new[] { "MWQMRunStartDateTime_Local" });
            }

            if (mwqmRun.EndDateTime_Local != null && ((DateTime)mwqmRun.EndDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunEndDateTime_Local", "1980"), new[] { "MWQMRunEndDateTime_Local" });
            }

            if (mwqmRun.StartDateTime_Local > mwqmRun.EndDateTime_Local)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "MWQMRunEndDateTime_Local", "MWQMRunStartDateTime_Local"), new[] { "MWQMRunEndDateTime_Local" });
            }

            if (mwqmRun.LabReceivedDateTime_Local != null && ((DateTime)mwqmRun.LabReceivedDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabReceivedDateTime_Local", "1980"), new[] { "MWQMRunLabReceivedDateTime_Local" });
            }

            if (mwqmRun.TemperatureControl1_C != null)
            {
                if (mwqmRun.TemperatureControl1_C < -10 || mwqmRun.TemperatureControl1_C > 40)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunTemperatureControl1_C", "-10", "40"), new[] { "TemperatureControl1_C" });
                }
            }

            if (mwqmRun.TemperatureControl2_C != null)
            {
                if (mwqmRun.TemperatureControl2_C < -10 || mwqmRun.TemperatureControl2_C > 40)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunTemperatureControl2_C", "-10", "40"), new[] { "TemperatureControl2_C" });
                }
            }

            if (mwqmRun.SeaStateAtStart_BeaufortScale != null)
            {
                retStr = enums.EnumTypeOK(typeof(BeaufortScaleEnum), (int?)mwqmRun.SeaStateAtStart_BeaufortScale);
                if (mwqmRun.SeaStateAtStart_BeaufortScale == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunSeaStateAtStart_BeaufortScale"), new[] { "SeaStateAtStart_BeaufortScale" });
                }
            }

            if (mwqmRun.SeaStateAtEnd_BeaufortScale != null)
            {
                retStr = enums.EnumTypeOK(typeof(BeaufortScaleEnum), (int?)mwqmRun.SeaStateAtEnd_BeaufortScale);
                if (mwqmRun.SeaStateAtEnd_BeaufortScale == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunSeaStateAtEnd_BeaufortScale"), new[] { "SeaStateAtEnd_BeaufortScale" });
                }
            }

            if (mwqmRun.WaterLevelAtBrook_m != null)
            {
                if (mwqmRun.WaterLevelAtBrook_m < 0 || mwqmRun.WaterLevelAtBrook_m > 100)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunWaterLevelAtBrook_m", "0", "100"), new[] { "WaterLevelAtBrook_m" });
                }
            }

            if (mwqmRun.WaveHightAtStart_m != null)
            {
                if (mwqmRun.WaveHightAtStart_m < 0 || mwqmRun.WaveHightAtStart_m > 100)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunWaveHightAtStart_m", "0", "100"), new[] { "WaveHightAtStart_m" });
                }
            }

            if (mwqmRun.WaveHightAtEnd_m != null)
            {
                if (mwqmRun.WaveHightAtEnd_m < 0 || mwqmRun.WaveHightAtEnd_m > 100)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunWaveHightAtEnd_m", "0", "100"), new[] { "WaveHightAtEnd_m" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SampleCrewInitials) && mwqmRun.SampleCrewInitials.Length > 20)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMRunSampleCrewInitials", "20"), new[] { "SampleCrewInitials" });
            }

            if (mwqmRun.AnalyzeMethod != null)
            {
                retStr = enums.EnumTypeOK(typeof(AnalyzeMethodEnum), (int?)mwqmRun.AnalyzeMethod);
                if (mwqmRun.AnalyzeMethod == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunAnalyzeMethod"), new[] { "AnalyzeMethod" });
                }
            }

            if (mwqmRun.SampleMatrix != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleMatrixEnum), (int?)mwqmRun.SampleMatrix);
                if (mwqmRun.SampleMatrix == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunSampleMatrix"), new[] { "SampleMatrix" });
                }
            }

            if (mwqmRun.Laboratory != null)
            {
                retStr = enums.EnumTypeOK(typeof(LaboratoryEnum), (int?)mwqmRun.Laboratory);
                if (mwqmRun.Laboratory == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLaboratory"), new[] { "Laboratory" });
                }
            }

            if (mwqmRun.SampleStatus != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleStatusEnum), (int?)mwqmRun.SampleStatus);
                if (mwqmRun.SampleStatus == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunSampleStatus"), new[] { "SampleStatus" });
                }
            }

            if (mwqmRun.LabSampleApprovalContactTVItemID != null)
            {
                TVItem TVItemLabSampleApprovalContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.LabSampleApprovalContactTVItemID select c).FirstOrDefault();

                if (TVItemLabSampleApprovalContactTVItemID == null)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunLabSampleApprovalContactTVItemID", (mwqmRun.LabSampleApprovalContactTVItemID == null ? "" : mwqmRun.LabSampleApprovalContactTVItemID.ToString())), new[] { "LabSampleApprovalContactTVItemID" });
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
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunLabSampleApprovalContactTVItemID", "Contact"), new[] { "LabSampleApprovalContactTVItemID" });
                    }
                }
            }

            if (mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local", "1980"), new[] { "MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local" });
            }

            if (mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local", "1980"), new[] { "MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local" });
            }

            if (mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local", "1980"), new[] { "MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local" });
            }

            if (mwqmRun.LabRunSampleApprovalDateTime_Local != null && ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Year < 1980)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLabRunSampleApprovalDateTime_Local", "1980"), new[] { "MWQMRunLabRunSampleApprovalDateTime_Local" });
            }

            if (mwqmRun.Tide_Start != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)mwqmRun.Tide_Start);
                if (mwqmRun.Tide_Start == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunTide_Start"), new[] { "Tide_Start" });
                }
            }

            if (mwqmRun.Tide_End != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)mwqmRun.Tide_End);
                if (mwqmRun.Tide_End == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunTide_End"), new[] { "Tide_End" });
                }
            }

            if (mwqmRun.RainDay0_mm != null)
            {
                if (mwqmRun.RainDay0_mm < 0 || mwqmRun.RainDay0_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay0_mm", "0", "300"), new[] { "RainDay0_mm" });
                }
            }

            if (mwqmRun.RainDay1_mm != null)
            {
                if (mwqmRun.RainDay1_mm < 0 || mwqmRun.RainDay1_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay1_mm", "0", "300"), new[] { "RainDay1_mm" });
                }
            }

            if (mwqmRun.RainDay2_mm != null)
            {
                if (mwqmRun.RainDay2_mm < 0 || mwqmRun.RainDay2_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay2_mm", "0", "300"), new[] { "RainDay2_mm" });
                }
            }

            if (mwqmRun.RainDay3_mm != null)
            {
                if (mwqmRun.RainDay3_mm < 0 || mwqmRun.RainDay3_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay3_mm", "0", "300"), new[] { "RainDay3_mm" });
                }
            }

            if (mwqmRun.RainDay4_mm != null)
            {
                if (mwqmRun.RainDay4_mm < 0 || mwqmRun.RainDay4_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay4_mm", "0", "300"), new[] { "RainDay4_mm" });
                }
            }

            if (mwqmRun.RainDay5_mm != null)
            {
                if (mwqmRun.RainDay5_mm < 0 || mwqmRun.RainDay5_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay5_mm", "0", "300"), new[] { "RainDay5_mm" });
                }
            }

            if (mwqmRun.RainDay6_mm != null)
            {
                if (mwqmRun.RainDay6_mm < 0 || mwqmRun.RainDay6_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay6_mm", "0", "300"), new[] { "RainDay6_mm" });
                }
            }

            if (mwqmRun.RainDay7_mm != null)
            {
                if (mwqmRun.RainDay7_mm < 0 || mwqmRun.RainDay7_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay7_mm", "0", "300"), new[] { "RainDay7_mm" });
                }
            }

            if (mwqmRun.RainDay8_mm != null)
            {
                if (mwqmRun.RainDay8_mm < 0 || mwqmRun.RainDay8_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay8_mm", "0", "300"), new[] { "RainDay8_mm" });
                }
            }

            if (mwqmRun.RainDay9_mm != null)
            {
                if (mwqmRun.RainDay9_mm < 0 || mwqmRun.RainDay9_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay9_mm", "0", "300"), new[] { "RainDay9_mm" });
                }
            }

            if (mwqmRun.RainDay10_mm != null)
            {
                if (mwqmRun.RainDay10_mm < 0 || mwqmRun.RainDay10_mm > 300)
                {
                    mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMRunRainDay10_mm", "0", "300"), new[] { "RainDay10_mm" });
                }
            }

            if (mwqmRun.LastUpdateDate_UTC.Year == 1)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMRunLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmRun.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMRunLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunLastUpdateContactTVItemID", mwqmRun.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            return (from c in db.MWQMRuns
                    where c.MWQMRunID == MWQMRunID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMRun> GetMWQMRunList()
        {
            IQueryable<MWQMRun> MWQMRunQuery = (from c in db.MWQMRuns select c);

            MWQMRunQuery = EnhanceQueryStatements<MWQMRun>(MWQMRunQuery) as IQueryable<MWQMRun>;

            return MWQMRunQuery;
        }
        public MWQMRun_A GetMWQMRun_AWithMWQMRunID(int MWQMRunID)
        {
            return FillMWQMRun_A().Where(c => c.MWQMRunID == MWQMRunID).FirstOrDefault();

        }
        public IQueryable<MWQMRun_A> GetMWQMRun_AList()
        {
            IQueryable<MWQMRun_A> MWQMRun_AQuery = FillMWQMRun_A();

            MWQMRun_AQuery = EnhanceQueryStatements<MWQMRun_A>(MWQMRun_AQuery) as IQueryable<MWQMRun_A>;

            return MWQMRun_AQuery;
        }
        public MWQMRun_B GetMWQMRun_BWithMWQMRunID(int MWQMRunID)
        {
            return FillMWQMRun_B().Where(c => c.MWQMRunID == MWQMRunID).FirstOrDefault();

        }
        public IQueryable<MWQMRun_B> GetMWQMRun_BList()
        {
            IQueryable<MWQMRun_B> MWQMRun_BQuery = FillMWQMRun_B();

            MWQMRun_BQuery = EnhanceQueryStatements<MWQMRun_B>(MWQMRun_BQuery) as IQueryable<MWQMRun_B>;

            return MWQMRun_BQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
