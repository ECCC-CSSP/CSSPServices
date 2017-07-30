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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmRun.MWQMRunID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunMWQMRunID), new[] { "MWQMRunID" });
                }
            }

            //MWQMRunID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunSubsectorTVItemID, mwqmRun.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                if (TVItemSubsectorTVItemID.TVType != TVTypeEnum.Subsector)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunSubsectorTVItemID, "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            //MWQMRunTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.MWQMRunTVItemID select c).FirstOrDefault();

            if (TVItemMWQMRunTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunMWQMRunTVItemID, mwqmRun.MWQMRunTVItemID.ToString()), new[] { "MWQMRunTVItemID" });
            }
            else
            {
                if (TVItemMWQMRunTVItemID.TVType != TVTypeEnum.MWQMRun)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunMWQMRunTVItemID, "MWQMRun"), new[] { "MWQMRunTVItemID" });
                }
            }

            retStr = enums.SampleTypeOK(mwqmRun.RunSampleType);
            if (mwqmRun.RunSampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunRunSampleType), new[] { "RunSampleType" });
            }

            if (mwqmRun.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunDateTime_Local), new[] { "DateTime_Local" });
            }
            else
            {
                if (mwqmRun.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunDateTime_Local, "1980"), new[] { "DateTime_Local" });
                }
            }

            //RunNumber (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmRun.RunNumber < 1 || mwqmRun.RunNumber > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRunNumber, "1", "1000"), new[] { "RunNumber" });
            }

            if (mwqmRun.StartDateTime_Local != null && ((DateTime)mwqmRun.StartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunStartDateTime_Local, "1980"), new[] { ModelsRes.MWQMRunStartDateTime_Local });
            }

            if (mwqmRun.EndDateTime_Local != null && ((DateTime)mwqmRun.EndDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunEndDateTime_Local, "1980"), new[] { ModelsRes.MWQMRunEndDateTime_Local });
            }

            if (mwqmRun.StartDateTime_Local > mwqmRun.EndDateTime_Local)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.MWQMRunEndDateTime_Local, ModelsRes.MWQMRunStartDateTime_Local), new[] { ModelsRes.MWQMRunEndDateTime_Local });
            }

            if (mwqmRun.LabReceivedDateTime_Local != null && ((DateTime)mwqmRun.LabReceivedDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunLabReceivedDateTime_Local, "1980"), new[] { ModelsRes.MWQMRunLabReceivedDateTime_Local });
            }

            if (mwqmRun.TemperatureControl1_C != null)
            {
                if (mwqmRun.TemperatureControl1_C < -10 || mwqmRun.TemperatureControl1_C > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl1_C, "-10", "40"), new[] { "TemperatureControl1_C" });
                }
            }

            if (mwqmRun.TemperatureControl2_C != null)
            {
                if (mwqmRun.TemperatureControl2_C < -10 || mwqmRun.TemperatureControl2_C > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl2_C, "-10", "40"), new[] { "TemperatureControl2_C" });
                }
            }

            if (mwqmRun.SeaStateAtStart_BeaufortScale != null)
            {
                retStr = enums.BeaufortScaleOK(mwqmRun.SeaStateAtStart_BeaufortScale);
                if (mwqmRun.SeaStateAtStart_BeaufortScale == BeaufortScaleEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunSeaStateAtStart_BeaufortScale), new[] { "SeaStateAtStart_BeaufortScale" });
                }
            }

            if (mwqmRun.SeaStateAtEnd_BeaufortScale != null)
            {
                retStr = enums.BeaufortScaleOK(mwqmRun.SeaStateAtEnd_BeaufortScale);
                if (mwqmRun.SeaStateAtEnd_BeaufortScale == BeaufortScaleEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunSeaStateAtEnd_BeaufortScale), new[] { "SeaStateAtEnd_BeaufortScale" });
                }
            }

            if (mwqmRun.WaterLevelAtBrook_m != null)
            {
                if (mwqmRun.WaterLevelAtBrook_m < 0 || mwqmRun.WaterLevelAtBrook_m > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100"), new[] { "WaterLevelAtBrook_m" });
                }
            }

            if (mwqmRun.WaveHightAtStart_m != null)
            {
                if (mwqmRun.WaveHightAtStart_m < 0 || mwqmRun.WaveHightAtStart_m > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtStart_m, "0", "100"), new[] { "WaveHightAtStart_m" });
                }
            }

            if (mwqmRun.WaveHightAtEnd_m != null)
            {
                if (mwqmRun.WaveHightAtEnd_m < 0 || mwqmRun.WaveHightAtEnd_m > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100"), new[] { "WaveHightAtEnd_m" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SampleCrewInitials) && mwqmRun.SampleCrewInitials.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunSampleCrewInitials, "20"), new[] { "SampleCrewInitials" });
            }

            if (mwqmRun.AnalyzeMethod != null)
            {
                retStr = enums.AnalyzeMethodOK(mwqmRun.AnalyzeMethod);
                if (mwqmRun.AnalyzeMethod == AnalyzeMethodEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunAnalyzeMethod), new[] { "AnalyzeMethod" });
                }
            }

            if (mwqmRun.SampleMatrix != null)
            {
                retStr = enums.SampleMatrixOK(mwqmRun.SampleMatrix);
                if (mwqmRun.SampleMatrix == SampleMatrixEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunSampleMatrix), new[] { "SampleMatrix" });
                }
            }

            if (mwqmRun.Laboratory != null)
            {
                retStr = enums.LaboratoryOK(mwqmRun.Laboratory);
                if (mwqmRun.Laboratory == LaboratoryEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLaboratory), new[] { "Laboratory" });
                }
            }

            if (mwqmRun.SampleStatus != null)
            {
                retStr = enums.SampleStatusOK(mwqmRun.SampleStatus);
                if (mwqmRun.SampleStatus == SampleStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunSampleStatus), new[] { "SampleStatus" });
                }
            }

            if (mwqmRun.LabSampleApprovalContactTVItemID != null)
            {
                TVItem TVItemLabSampleApprovalContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.LabSampleApprovalContactTVItemID select c).FirstOrDefault();

                if (TVItemLabSampleApprovalContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLabSampleApprovalContactTVItemID, mwqmRun.LabSampleApprovalContactTVItemID.ToString()), new[] { "LabSampleApprovalContactTVItemID" });
                }
                else
                {
                    if (TVItemLabSampleApprovalContactTVItemID.TVType != TVTypeEnum.Contact)
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunLabSampleApprovalContactTVItemID, "Contact"), new[] { "LabSampleApprovalContactTVItemID" });
                    }
                }
            }

            if (mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local, "1980"), new[] { ModelsRes.MWQMRunLabAnalyzeBath1IncubationStartDateTime_Local });
            }

            if (mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local, "1980"), new[] { ModelsRes.MWQMRunLabAnalyzeBath2IncubationStartDateTime_Local });
            }

            if (mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local != null && ((DateTime)mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local, "1980"), new[] { ModelsRes.MWQMRunLabAnalyzeBath3IncubationStartDateTime_Local });
            }

            if (mwqmRun.LabRunSampleApprovalDateTime_Local != null && ((DateTime)mwqmRun.LabRunSampleApprovalDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunLabRunSampleApprovalDateTime_Local, "1980"), new[] { ModelsRes.MWQMRunLabRunSampleApprovalDateTime_Local });
            }

            if (mwqmRun.Tide_Start != null)
            {
                retStr = enums.TideTextOK(mwqmRun.Tide_Start);
                if (mwqmRun.Tide_Start == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunTide_Start), new[] { "Tide_Start" });
                }
            }

            if (mwqmRun.Tide_End != null)
            {
                retStr = enums.TideTextOK(mwqmRun.Tide_End);
                if (mwqmRun.Tide_End == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunTide_End), new[] { "Tide_End" });
                }
            }

            if (mwqmRun.RainDay0_mm != null)
            {
                if (mwqmRun.RainDay0_mm < 0 || mwqmRun.RainDay0_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay0_mm, "0", "300"), new[] { "RainDay0_mm" });
                }
            }

            if (mwqmRun.RainDay1_mm != null)
            {
                if (mwqmRun.RainDay1_mm < 0 || mwqmRun.RainDay1_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay1_mm, "0", "300"), new[] { "RainDay1_mm" });
                }
            }

            if (mwqmRun.RainDay2_mm != null)
            {
                if (mwqmRun.RainDay2_mm < 0 || mwqmRun.RainDay2_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay2_mm, "0", "300"), new[] { "RainDay2_mm" });
                }
            }

            if (mwqmRun.RainDay3_mm != null)
            {
                if (mwqmRun.RainDay3_mm < 0 || mwqmRun.RainDay3_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay3_mm, "0", "300"), new[] { "RainDay3_mm" });
                }
            }

            if (mwqmRun.RainDay4_mm != null)
            {
                if (mwqmRun.RainDay4_mm < 0 || mwqmRun.RainDay4_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay4_mm, "0", "300"), new[] { "RainDay4_mm" });
                }
            }

            if (mwqmRun.RainDay5_mm != null)
            {
                if (mwqmRun.RainDay5_mm < 0 || mwqmRun.RainDay5_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay5_mm, "0", "300"), new[] { "RainDay5_mm" });
                }
            }

            if (mwqmRun.RainDay6_mm != null)
            {
                if (mwqmRun.RainDay6_mm < 0 || mwqmRun.RainDay6_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay6_mm, "0", "300"), new[] { "RainDay6_mm" });
                }
            }

            if (mwqmRun.RainDay7_mm != null)
            {
                if (mwqmRun.RainDay7_mm < 0 || mwqmRun.RainDay7_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay7_mm, "0", "300"), new[] { "RainDay7_mm" });
                }
            }

            if (mwqmRun.RainDay8_mm != null)
            {
                if (mwqmRun.RainDay8_mm < 0 || mwqmRun.RainDay8_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay8_mm, "0", "300"), new[] { "RainDay8_mm" });
                }
            }

            if (mwqmRun.RainDay9_mm != null)
            {
                if (mwqmRun.RainDay9_mm < 0 || mwqmRun.RainDay9_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay9_mm, "0", "300"), new[] { "RainDay9_mm" });
                }
            }

            if (mwqmRun.RainDay10_mm != null)
            {
                if (mwqmRun.RainDay10_mm < 0 || mwqmRun.RainDay10_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay10_mm, "0", "300"), new[] { "RainDay10_mm" });
                }
            }

            if (mwqmRun.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmRun.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmRun.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLastUpdateContactTVItemID, mwqmRun.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMRunLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public bool Add(MWQMRun mwqmRun)
        {
            mwqmRun.ValidationResults = Validate(new ValidationContext(mwqmRun), ActionDBTypeEnum.Create);
            if (mwqmRun.ValidationResults.Count() > 0) return false;

            db.MWQMRuns.Add(mwqmRun);

            if (!TryToSave(mwqmRun)) return false;

            return true;
        }
        public bool AddRange(List<MWQMRun> mwqmRunList)
        {
            foreach (MWQMRun mwqmRun in mwqmRunList)
            {
                mwqmRun.ValidationResults = Validate(new ValidationContext(mwqmRun), ActionDBTypeEnum.Create);
                if (mwqmRun.ValidationResults.Count() > 0) return false;
            }

            db.MWQMRuns.AddRange(mwqmRunList);

            if (!TryToSaveRange(mwqmRunList)) return false;

            return true;
        }
        public bool Delete(MWQMRun mwqmRun)
        {
            if (!db.MWQMRuns.Where(c => c.MWQMRunID == mwqmRun.MWQMRunID).Any())
            {
                mwqmRun.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", mwqmRun.MWQMRunID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMRuns.Remove(mwqmRun);

            if (!TryToSave(mwqmRun)) return false;

            return true;
        }
        public bool DeleteRange(List<MWQMRun> mwqmRunList)
        {
            foreach (MWQMRun mwqmRun in mwqmRunList)
            {
                if (!db.MWQMRuns.Where(c => c.MWQMRunID == mwqmRun.MWQMRunID).Any())
                {
                    mwqmRunList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMRun", "MWQMRunID", mwqmRun.MWQMRunID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMRuns.RemoveRange(mwqmRunList);

            if (!TryToSaveRange(mwqmRunList)) return false;

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
        public bool UpdateRange(List<MWQMRun> mwqmRunList)
        {
            foreach (MWQMRun mwqmRun in mwqmRunList)
            {
                mwqmRun.ValidationResults = Validate(new ValidationContext(mwqmRun), ActionDBTypeEnum.Update);
                if (mwqmRun.ValidationResults.Count() > 0) return false;
            }
            db.MWQMRuns.UpdateRange(mwqmRunList);

            if (!TryToSaveRange(mwqmRunList)) return false;

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
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<MWQMRun> mwqmRunList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmRunList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
