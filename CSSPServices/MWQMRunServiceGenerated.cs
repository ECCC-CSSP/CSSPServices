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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunMWQMRunID), new[] { ModelsRes.MWQMRunMWQMRunID });
                }
            }

            //MWQMRunID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmRun.SubsectorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunSubsectorTVItemID, "1"), new[] { ModelsRes.MWQMRunSubsectorTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmRun.SubsectorTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunSubsectorTVItemID, mwqmRun.SubsectorTVItemID.ToString()), new[] { ModelsRes.MWQMRunSubsectorTVItemID });
            }

            //MWQMRunTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmRun.MWQMRunTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunMWQMRunTVItemID, "1"), new[] { ModelsRes.MWQMRunMWQMRunTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmRun.MWQMRunTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunMWQMRunTVItemID, mwqmRun.MWQMRunTVItemID.ToString()), new[] { ModelsRes.MWQMRunMWQMRunTVItemID });
            }

            retStr = enums.SampleTypeOK(mwqmRun.RunSampleType);
            if (mwqmRun.RunSampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunRunSampleType), new[] { ModelsRes.MWQMRunRunSampleType });
            }

            if (mwqmRun.DateTime_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunDateTime_Local), new[] { ModelsRes.MWQMRunDateTime_Local });
            }

            if (mwqmRun.DateTime_Local.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunDateTime_Local, "1980"), new[] { ModelsRes.MWQMRunDateTime_Local });
            }

            //RunNumber (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmRun.RunNumber < 1 || mwqmRun.RunNumber > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRunNumber, "1", "1000"), new[] { ModelsRes.MWQMRunRunNumber });
            }

                //Error: Type not implemented [StartDateTime_Local] of type [Nullable`1]

                //Error: Type not implemented [EndDateTime_Local] of type [Nullable`1]

                //Error: Type not implemented [LabReceivedDateTime_Local] of type [Nullable`1]

                //Error: Type not implemented [TemperatureControl1_C] of type [Nullable`1]

            if (mwqmRun.TemperatureControl1_C < -10 || mwqmRun.TemperatureControl1_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl1_C, "-10", "40"), new[] { ModelsRes.MWQMRunTemperatureControl1_C });
            }

                //Error: Type not implemented [TemperatureControl2_C] of type [Nullable`1]

            if (mwqmRun.TemperatureControl2_C < -10 || mwqmRun.TemperatureControl2_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl2_C, "-10", "40"), new[] { ModelsRes.MWQMRunTemperatureControl2_C });
            }

            if (mwqmRun.SeaStateAtStart_BeaufortScale != null)
            {
                retStr = enums.BeaufortScaleOK(mwqmRun.SeaStateAtStart_BeaufortScale);
                if (mwqmRun.SeaStateAtStart_BeaufortScale == BeaufortScaleEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.MWQMRunSeaStateAtStart_BeaufortScale });
                }
            }

            if (mwqmRun.SeaStateAtEnd_BeaufortScale != null)
            {
                retStr = enums.BeaufortScaleOK(mwqmRun.SeaStateAtEnd_BeaufortScale);
                if (mwqmRun.SeaStateAtEnd_BeaufortScale == BeaufortScaleEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.MWQMRunSeaStateAtEnd_BeaufortScale });
                }
            }

                //Error: Type not implemented [WaterLevelAtBrook_m] of type [Nullable`1]

            if (mwqmRun.WaterLevelAtBrook_m < 0 || mwqmRun.WaterLevelAtBrook_m > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100"), new[] { ModelsRes.MWQMRunWaterLevelAtBrook_m });
            }

                //Error: Type not implemented [WaveHightAtStart_m] of type [Nullable`1]

            if (mwqmRun.WaveHightAtStart_m < 0 || mwqmRun.WaveHightAtStart_m > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtStart_m, "0", "100"), new[] { ModelsRes.MWQMRunWaveHightAtStart_m });
            }

                //Error: Type not implemented [WaveHightAtEnd_m] of type [Nullable`1]

            if (mwqmRun.WaveHightAtEnd_m < 0 || mwqmRun.WaveHightAtEnd_m > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100"), new[] { ModelsRes.MWQMRunWaveHightAtEnd_m });
            }

            if (!string.IsNullOrWhiteSpace(mwqmRun.SampleCrewInitials) && mwqmRun.SampleCrewInitials.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMRunSampleCrewInitials, "20"), new[] { ModelsRes.MWQMRunSampleCrewInitials });
            }

            if (mwqmRun.AnalyzeMethod != null)
            {
                retStr = enums.AnalyzeMethodOK(mwqmRun.AnalyzeMethod);
                if (mwqmRun.AnalyzeMethod == AnalyzeMethodEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.MWQMRunAnalyzeMethod });
                }
            }

            if (mwqmRun.SampleMatrix != null)
            {
                retStr = enums.SampleMatrixOK(mwqmRun.SampleMatrix);
                if (mwqmRun.SampleMatrix == SampleMatrixEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.MWQMRunSampleMatrix });
                }
            }

            if (mwqmRun.Laboratory != null)
            {
                retStr = enums.LaboratoryOK(mwqmRun.Laboratory);
                if (mwqmRun.Laboratory == LaboratoryEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.MWQMRunLaboratory });
                }
            }

            if (mwqmRun.SampleStatus != null)
            {
                retStr = enums.SampleStatusOK(mwqmRun.SampleStatus);
                if (mwqmRun.SampleStatus == SampleStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.MWQMRunSampleStatus });
                }
            }

                //Error: Type not implemented [LabSampleApprovalContactTVItemID] of type [Nullable`1]

            //LabSampleApprovalContactTVItemID has no Range Attribute

            if (!((from c in db.TVItems where c.TVItemID == mwqmRun.LabSampleApprovalContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLabSampleApprovalContactTVItemID, mwqmRun.LabSampleApprovalContactTVItemID.ToString()), new[] { ModelsRes.MWQMRunLabSampleApprovalContactTVItemID });
            }

                //Error: Type not implemented [LabAnalyzeBath1IncubationStartDateTime_Local] of type [Nullable`1]

                //Error: Type not implemented [LabAnalyzeBath2IncubationStartDateTime_Local] of type [Nullable`1]

                //Error: Type not implemented [LabAnalyzeBath3IncubationStartDateTime_Local] of type [Nullable`1]

                //Error: Type not implemented [LabRunSampleApprovalDateTime_Local] of type [Nullable`1]

            if (mwqmRun.Tide_Start != null)
            {
                retStr = enums.TideTextOK(mwqmRun.Tide_Start);
                if (mwqmRun.Tide_Start == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.MWQMRunTide_Start });
                }
            }

            if (mwqmRun.Tide_End != null)
            {
                retStr = enums.TideTextOK(mwqmRun.Tide_End);
                if (mwqmRun.Tide_End == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.MWQMRunTide_End });
                }
            }

                //Error: Type not implemented [RainDay0_mm] of type [Nullable`1]

            if (mwqmRun.RainDay0_mm < 0 || mwqmRun.RainDay0_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay0_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay0_mm });
            }

                //Error: Type not implemented [RainDay1_mm] of type [Nullable`1]

            if (mwqmRun.RainDay1_mm < 0 || mwqmRun.RainDay1_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay1_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay1_mm });
            }

                //Error: Type not implemented [RainDay2_mm] of type [Nullable`1]

            if (mwqmRun.RainDay2_mm < 0 || mwqmRun.RainDay2_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay2_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay2_mm });
            }

                //Error: Type not implemented [RainDay3_mm] of type [Nullable`1]

            if (mwqmRun.RainDay3_mm < 0 || mwqmRun.RainDay3_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay3_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay3_mm });
            }

                //Error: Type not implemented [RainDay4_mm] of type [Nullable`1]

            if (mwqmRun.RainDay4_mm < 0 || mwqmRun.RainDay4_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay4_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay4_mm });
            }

                //Error: Type not implemented [RainDay5_mm] of type [Nullable`1]

            if (mwqmRun.RainDay5_mm < 0 || mwqmRun.RainDay5_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay5_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay5_mm });
            }

                //Error: Type not implemented [RainDay6_mm] of type [Nullable`1]

            if (mwqmRun.RainDay6_mm < 0 || mwqmRun.RainDay6_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay6_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay6_mm });
            }

                //Error: Type not implemented [RainDay7_mm] of type [Nullable`1]

            if (mwqmRun.RainDay7_mm < 0 || mwqmRun.RainDay7_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay7_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay7_mm });
            }

                //Error: Type not implemented [RainDay8_mm] of type [Nullable`1]

            if (mwqmRun.RainDay8_mm < 0 || mwqmRun.RainDay8_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay8_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay8_mm });
            }

                //Error: Type not implemented [RainDay9_mm] of type [Nullable`1]

            if (mwqmRun.RainDay9_mm < 0 || mwqmRun.RainDay9_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay9_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay9_mm });
            }

                //Error: Type not implemented [RainDay10_mm] of type [Nullable`1]

            if (mwqmRun.RainDay10_mm < 0 || mwqmRun.RainDay10_mm > 300)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay10_mm, "0", "300"), new[] { ModelsRes.MWQMRunRainDay10_mm });
            }

                //Error: Type not implemented [RemoveFromStat] of type [Nullable`1]

            if (mwqmRun.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLastUpdateDate_UTC), new[] { ModelsRes.MWQMRunLastUpdateDate_UTC });
            }

            if (mwqmRun.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMRunLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MWQMRunLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmRun.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMRunLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmRun.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMRunLastUpdateContactTVItemID, mwqmRun.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MWQMRunLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
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
