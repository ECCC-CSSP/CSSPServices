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
        public MWQMRunService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
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

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmRun.MWQMRunID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunMWQMRunID), new[] { ModelsRes.MWQMRunMWQMRunID });
                }
            }

            //SubsectorTVItemID (int) is required but no testing needed as it is automatically set to 0

            //MWQMRunTVItemID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.SampleTypeOK(mwqmRun.RunSampleType);
            if (mwqmRun.RunSampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunRunSampleType), new[] { ModelsRes.MWQMRunRunSampleType });
            }

            if (mwqmRun.DateTime_Local == null || mwqmRun.DateTime_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunDateTime_Local), new[] { ModelsRes.MWQMRunDateTime_Local });
            }

            //RunNumber (int) is required but no testing needed as it is automatically set to 0

            if (mwqmRun.LastUpdateDate_UTC == null || mwqmRun.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMRunLastUpdateDate_UTC), new[] { ModelsRes.MWQMRunLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (mwqmRun.SubsectorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunSubsectorTVItemID, "1"), new[] { ModelsRes.MWQMRunSubsectorTVItemID });
            }

            if (mwqmRun.MWQMRunTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunMWQMRunTVItemID, "1"), new[] { ModelsRes.MWQMRunMWQMRunTVItemID });
            }

            if (mwqmRun.RunNumber < 1 || mwqmRun.RunNumber > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRunNumber, "1", "1000"), new[] { ModelsRes.MWQMRunRunNumber });
            }

            if (mwqmRun.TemperatureControl1_C < 0 || mwqmRun.TemperatureControl1_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl1_C, "0", "40"), new[] { ModelsRes.MWQMRunTemperatureControl1_C });
            }

            if (mwqmRun.TemperatureControl2_C < 0 || mwqmRun.TemperatureControl2_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunTemperatureControl2_C, "0", "40"), new[] { ModelsRes.MWQMRunTemperatureControl2_C });
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

            if (mwqmRun.WaterLevelAtBrook_m < 0 || mwqmRun.WaterLevelAtBrook_m > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaterLevelAtBrook_m, "0", "100"), new[] { ModelsRes.MWQMRunWaterLevelAtBrook_m });
            }

            if (mwqmRun.WaveHightAtStart_m < 0 || mwqmRun.WaveHightAtStart_m > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtStart_m, "0", "100"), new[] { ModelsRes.MWQMRunWaveHightAtStart_m });
            }

            if (mwqmRun.WaveHightAtEnd_m < 0 || mwqmRun.WaveHightAtEnd_m > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunWaveHightAtEnd_m, "0", "100"), new[] { ModelsRes.MWQMRunWaveHightAtEnd_m });
            }

            // SampleCrewInitials has no validation

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

            if (mwqmRun.LabSampleApprovalContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLabSampleApprovalContactTVItemID, "1"), new[] { ModelsRes.MWQMRunLabSampleApprovalContactTVItemID });
            }

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

            if (mwqmRun.RainDay0_mm < 0 || mwqmRun.RainDay0_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay0_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay0_mm });
            }

            if (mwqmRun.RainDay1_mm < 0 || mwqmRun.RainDay1_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay1_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay1_mm });
            }

            if (mwqmRun.RainDay2_mm < 0 || mwqmRun.RainDay2_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay2_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay2_mm });
            }

            if (mwqmRun.RainDay3_mm < 0 || mwqmRun.RainDay3_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay3_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay3_mm });
            }

            if (mwqmRun.RainDay4_mm < 0 || mwqmRun.RainDay4_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay4_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay4_mm });
            }

            if (mwqmRun.RainDay5_mm < 0 || mwqmRun.RainDay5_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay5_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay5_mm });
            }

            if (mwqmRun.RainDay6_mm < 0 || mwqmRun.RainDay6_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay6_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay6_mm });
            }

            if (mwqmRun.RainDay7_mm < 0 || mwqmRun.RainDay7_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay7_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay7_mm });
            }

            if (mwqmRun.RainDay8_mm < 0 || mwqmRun.RainDay8_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay8_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay8_mm });
            }

            if (mwqmRun.RainDay9_mm < 0 || mwqmRun.RainDay9_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay9_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay9_mm });
            }

            if (mwqmRun.RainDay10_mm < 0 || mwqmRun.RainDay10_mm > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMRunRainDay10_mm, "0", "1000"), new[] { ModelsRes.MWQMRunRainDay10_mm });
            }

            if (mwqmRun.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMRunLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMRunLastUpdateContactTVItemID });
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
