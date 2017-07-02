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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public VPAmbientService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            VPAmbient vpAmbient = validationContext.ObjectInstance as VPAmbient;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (vpAmbient.VPAmbientID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPAmbientVPAmbientID), new[] { ModelsRes.VPAmbientVPAmbientID });
                }
            }

            //VPScenarioID (int) is required but no testing needed as it is automatically set to 0

            //Row (int) is required but no testing needed as it is automatically set to 0

            //MeasurementDepth_m (float) is required but no testing needed as it is automatically set to 0.0f

            //CurrentSpeed_m_s (float) is required but no testing needed as it is automatically set to 0.0f

            //CurrentDirection_deg (float) is required but no testing needed as it is automatically set to 0.0f

            //AmbientSalinity_PSU (float) is required but no testing needed as it is automatically set to 0.0f

            //AmbientTemperature_C (float) is required but no testing needed as it is automatically set to 0.0f

            //BackgroundConcentration_MPN_100ml (int) is required but no testing needed as it is automatically set to 0

            //PollutantDecayRate_per_day (float) is required but no testing needed as it is automatically set to 0.0f

            //FarFieldCurrentSpeed_m_s (float) is required but no testing needed as it is automatically set to 0.0f

            //FarFieldCurrentDirection_deg (float) is required but no testing needed as it is automatically set to 0.0f

            //FarFieldDiffusionCoefficient (float) is required but no testing needed as it is automatically set to 0.0f

            if (vpAmbient.LastUpdateDate_UTC == null || vpAmbient.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.VPAmbientLastUpdateDate_UTC), new[] { ModelsRes.VPAmbientLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (vpAmbient.VPScenarioID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPAmbientVPScenarioID, "1"), new[] { ModelsRes.VPAmbientVPScenarioID });
            }

            if (vpAmbient.Row < 1 || vpAmbient.Row > 8)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientRow, "1", "8"), new[] { ModelsRes.VPAmbientRow });
            }

            if (vpAmbient.MeasurementDepth_m < 0 || vpAmbient.MeasurementDepth_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientMeasurementDepth_m, "0", "1000"), new[] { ModelsRes.VPAmbientMeasurementDepth_m });
            }

            if (vpAmbient.CurrentSpeed_m_s < 0 || vpAmbient.CurrentSpeed_m_s > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentSpeed_m_s, "0", "10"), new[] { ModelsRes.VPAmbientCurrentSpeed_m_s });
            }

            if (vpAmbient.CurrentDirection_deg < 0 || vpAmbient.CurrentDirection_deg > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientCurrentDirection_deg, "0", "360"), new[] { ModelsRes.VPAmbientCurrentDirection_deg });
            }

            if (vpAmbient.AmbientSalinity_PSU < 0 || vpAmbient.AmbientSalinity_PSU > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientSalinity_PSU, "0", "40"), new[] { ModelsRes.VPAmbientAmbientSalinity_PSU });
            }

            if (vpAmbient.AmbientTemperature_C < 0 || vpAmbient.AmbientTemperature_C > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientAmbientTemperature_C, "0", "50"), new[] { ModelsRes.VPAmbientAmbientTemperature_C });
            }

            if (vpAmbient.BackgroundConcentration_MPN_100ml < 0 || vpAmbient.BackgroundConcentration_MPN_100ml > 100000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml, "0", "100000000"), new[] { ModelsRes.VPAmbientBackgroundConcentration_MPN_100ml });
            }

            if (vpAmbient.PollutantDecayRate_per_day < 0 || vpAmbient.PollutantDecayRate_per_day > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientPollutantDecayRate_per_day, "0", "1000"), new[] { ModelsRes.VPAmbientPollutantDecayRate_per_day });
            }

            if (vpAmbient.FarFieldCurrentSpeed_m_s < 0 || vpAmbient.FarFieldCurrentSpeed_m_s > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s, "0", "10"), new[] { ModelsRes.VPAmbientFarFieldCurrentSpeed_m_s });
            }

            if (vpAmbient.FarFieldCurrentDirection_deg < 0 || vpAmbient.FarFieldCurrentDirection_deg > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldCurrentDirection_deg, "0", "360"), new[] { ModelsRes.VPAmbientFarFieldCurrentDirection_deg });
            }

            if (vpAmbient.FarFieldDiffusionCoefficient < 0 || vpAmbient.FarFieldDiffusionCoefficient > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.VPAmbientFarFieldDiffusionCoefficient, "0", "10"), new[] { ModelsRes.VPAmbientFarFieldDiffusionCoefficient });
            }

            if (vpAmbient.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPAmbientLastUpdateContactTVItemID, "1"), new[] { ModelsRes.VPAmbientLastUpdateContactTVItemID });
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
