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
    public partial class VPAmbientService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPAmbientService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPAmbient vpAmbient = validationContext.ObjectInstance as VPAmbient;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (vpAmbient.VPAmbientID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPAmbientVPAmbientID), new[] { ModelsRes.VPAmbientVPAmbientID });
                }
            }

            //VPAmbientID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //VPScenarioID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.VPScenarioID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPAmbientVPScenarioID, "1"), new[] { ModelsRes.VPAmbientVPScenarioID });
            }

            if (!((from c in db.VPScenarios where c.VPScenarioID == vpAmbient.VPScenarioID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.VPScenario, ModelsRes.VPAmbientVPScenarioID, vpAmbient.VPScenarioID.ToString()), new[] { ModelsRes.VPAmbientVPScenarioID });
            }

            //Row (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.Row < 0 || vpAmbient.Row > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "0", "10"), new[] { ModelsRes.VPAmbientRow });
            }

            //MeasurementDepth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.MeasurementDepth_m < 0 || vpAmbient.MeasurementDepth_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientMeasurementDepth_m, "0", "1000"), new[] { ModelsRes.VPAmbientMeasurementDepth_m });
            }

            //CurrentSpeed_m_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.CurrentSpeed_m_s < 0 || vpAmbient.CurrentSpeed_m_s > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10"), new[] { ModelsRes.VPAmbientCurrentSpeed_m_s });
            }

            //CurrentDirection_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.CurrentDirection_deg < -180 || vpAmbient.CurrentDirection_deg > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "-180", "180"), new[] { ModelsRes.VPAmbientCurrentDirection_deg });
            }

            //AmbientSalinity_PSU (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.AmbientSalinity_PSU < 0 || vpAmbient.AmbientSalinity_PSU > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40"), new[] { ModelsRes.VPAmbientAmbientSalinity_PSU });
            }

            //AmbientTemperature_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.AmbientTemperature_C < -10 || vpAmbient.AmbientTemperature_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "-10", "40"), new[] { ModelsRes.VPAmbientAmbientTemperature_C });
            }

            //BackgroundConcentration_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.BackgroundConcentration_MPN_100ml < 0 || vpAmbient.BackgroundConcentration_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "10000000"), new[] { ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml });
            }

            //PollutantDecayRate_per_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.PollutantDecayRate_per_day < 0 || vpAmbient.PollutantDecayRate_per_day > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "100"), new[] { ModelsRes.VPAmbientPollutantDecayRate_per_day });
            }

            //FarFieldCurrentSpeed_m_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.FarFieldCurrentSpeed_m_s < 0 || vpAmbient.FarFieldCurrentSpeed_m_s > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10"), new[] { ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s });
            }

            //FarFieldCurrentDirection_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.FarFieldCurrentDirection_deg < -180 || vpAmbient.FarFieldCurrentDirection_deg > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "-180", "180"), new[] { ModelsRes.VPAmbientFarFieldCurrentDirection_deg });
            }

            //FarFieldDiffusionCoefficient (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.FarFieldDiffusionCoefficient < 0 || vpAmbient.FarFieldDiffusionCoefficient > 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "1"), new[] { ModelsRes.VPAmbientFarFieldDiffusionCoefficient });
            }

            if (vpAmbient.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPAmbientLastUpdateDate_UTC), new[] { ModelsRes.VPAmbientLastUpdateDate_UTC });
            }

            if (vpAmbient.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.VPAmbientLastUpdateDate_UTC, "1980"), new[] { ModelsRes.VPAmbientLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpAmbient.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPAmbientLastUpdateContactTVItemID, "1"), new[] { ModelsRes.VPAmbientLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == vpAmbient.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.VPAmbientLastUpdateContactTVItemID, vpAmbient.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.VPAmbientLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Create);
            if (vpAmbient.ValidationResults.Count() > 0) return false;

            db.VPAmbients.Add(vpAmbient);

            if (!TryToSave(vpAmbient)) return false;

            return true;
        }
        public bool AddRange(List<VPAmbient> vpAmbientList)
        {
            foreach (VPAmbient vpAmbient in vpAmbientList)
            {
                vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Create);
                if (vpAmbient.ValidationResults.Count() > 0) return false;
            }

            db.VPAmbients.AddRange(vpAmbientList);

            if (!TryToSaveRange(vpAmbientList)) return false;

            return true;
        }
        public bool Delete(VPAmbient vpAmbient)
        {
            if (!db.VPAmbients.Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
            {
                vpAmbient.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", vpAmbient.VPAmbientID.ToString())) }.AsEnumerable();
                return false;
            }

            db.VPAmbients.Remove(vpAmbient);

            if (!TryToSave(vpAmbient)) return false;

            return true;
        }
        public bool DeleteRange(List<VPAmbient> vpAmbientList)
        {
            foreach (VPAmbient vpAmbient in vpAmbientList)
            {
                if (!db.VPAmbients.Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
                {
                    vpAmbientList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientID", vpAmbient.VPAmbientID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.VPAmbients.RemoveRange(vpAmbientList);

            if (!TryToSaveRange(vpAmbientList)) return false;

            return true;
        }
        public bool Update(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Update);
            if (vpAmbient.ValidationResults.Count() > 0) return false;

            db.VPAmbients.Update(vpAmbient);

            if (!TryToSave(vpAmbient)) return false;

            return true;
        }
        public bool UpdateRange(List<VPAmbient> vpAmbientList)
        {
            foreach (VPAmbient vpAmbient in vpAmbientList)
            {
                vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Update);
                if (vpAmbient.ValidationResults.Count() > 0) return false;
            }
            db.VPAmbients.UpdateRange(vpAmbientList);

            if (!TryToSaveRange(vpAmbientList)) return false;

            return true;
        }
        public IQueryable<VPAmbient> GetRead()
        {
            return db.VPAmbients.AsNoTracking();
        }
        public IQueryable<VPAmbient> GetEdit()
        {
            return db.VPAmbients;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(VPAmbient vpAmbient)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpAmbient.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<VPAmbient> vpAmbientList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpAmbientList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
