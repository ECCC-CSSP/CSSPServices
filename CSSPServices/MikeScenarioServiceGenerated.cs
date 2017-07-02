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
    public partial class MikeScenarioService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            MikeScenario mikeScenario = validationContext.ObjectInstance as MikeScenario;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mikeScenario.MikeScenarioID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioID), new[] { ModelsRes.MikeScenarioMikeScenarioID });
                }
            }

            //MikeScenarioTVItemID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.ScenarioStatusOK(mikeScenario.ScenarioStatus);
            if (mikeScenario.ScenarioStatus == ScenarioStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioScenarioStatus), new[] { ModelsRes.MikeScenarioScenarioStatus });
            }

            if (mikeScenario.MikeScenarioStartDateTime_Local == null || mikeScenario.MikeScenarioStartDateTime_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioStartDateTime_Local), new[] { ModelsRes.MikeScenarioMikeScenarioStartDateTime_Local });
            }

            if (mikeScenario.MikeScenarioEndDateTime_Local == null || mikeScenario.MikeScenarioEndDateTime_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioEndDateTime_Local), new[] { ModelsRes.MikeScenarioMikeScenarioEndDateTime_Local });
            }

            //WindSpeed_km_h (float) is required but no testing needed as it is automatically set to 0.0f

            //WindDirection_deg (float) is required but no testing needed as it is automatically set to 0.0f

            //DecayFactor_per_day (float) is required but no testing needed as it is automatically set to 0.0f

            //DecayIsConstant (bool) is required but no testing needed 

            //DecayFactorAmplitude (float) is required but no testing needed as it is automatically set to 0.0f

            //ResultFrequency_min (int) is required but no testing needed as it is automatically set to 0

            //AmbientTemperature_C (float) is required but no testing needed as it is automatically set to 0.0f

            //AmbientSalinity_PSU (float) is required but no testing needed as it is automatically set to 0.0f

            //ManningNumber (float) is required but no testing needed as it is automatically set to 0.0f

            if (mikeScenario.LastUpdateDate_UTC == null || mikeScenario.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioLastUpdateDate_UTC), new[] { ModelsRes.MikeScenarioLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (mikeScenario.MikeScenarioTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioMikeScenarioTVItemID, "1"), new[] { ModelsRes.MikeScenarioMikeScenarioTVItemID });
            }

            if (mikeScenario.ParentMikeScenarioID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioParentMikeScenarioID, "1"), new[] { ModelsRes.MikeScenarioParentMikeScenarioID });
            }

            // ErrorInfo has no validation

            if (mikeScenario.MikeScenarioExecutionTime_min < 0 || mikeScenario.MikeScenarioExecutionTime_min > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "0", "10000"), new[] { ModelsRes.MikeScenarioMikeScenarioExecutionTime_min });
            }

            if (mikeScenario.WindSpeed_km_h < 0 || mikeScenario.WindSpeed_km_h > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "200"), new[] { ModelsRes.MikeScenarioWindSpeed_km_h });
            }

            if (mikeScenario.WindDirection_deg < 0 || mikeScenario.WindDirection_deg > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindDirection_deg, "0", "360"), new[] { ModelsRes.MikeScenarioWindDirection_deg });
            }

            if (mikeScenario.DecayFactor_per_day < 0 || mikeScenario.DecayFactor_per_day > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "1000"), new[] { ModelsRes.MikeScenarioDecayFactor_per_day });
            }

            if (mikeScenario.DecayFactorAmplitude < 0 || mikeScenario.DecayFactorAmplitude > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "1000"), new[] { ModelsRes.MikeScenarioDecayFactorAmplitude });
            }

            if (mikeScenario.ResultFrequency_min < 15 || mikeScenario.ResultFrequency_min > 60)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "15", "60"), new[] { ModelsRes.MikeScenarioResultFrequency_min });
            }

            if (mikeScenario.AmbientTemperature_C < 0 || mikeScenario.AmbientTemperature_C > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "0", "50"), new[] { ModelsRes.MikeScenarioAmbientTemperature_C });
            }

            if (mikeScenario.AmbientSalinity_PSU < 0 || mikeScenario.AmbientSalinity_PSU > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40"), new[] { ModelsRes.MikeScenarioAmbientSalinity_PSU });
            }

            if (mikeScenario.ManningNumber < 0 || mikeScenario.ManningNumber > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioManningNumber, "0", "100"), new[] { ModelsRes.MikeScenarioManningNumber });
            }

            if (mikeScenario.NumberOfElements < 1 || mikeScenario.NumberOfElements > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "1000000"), new[] { ModelsRes.MikeScenarioNumberOfElements });
            }

            if (mikeScenario.NumberOfTimeSteps < 1 || mikeScenario.NumberOfTimeSteps > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "1000000"), new[] { ModelsRes.MikeScenarioNumberOfTimeSteps });
            }

            if (mikeScenario.NumberOfSigmaLayers < 1 || mikeScenario.NumberOfSigmaLayers > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "1", "1000000"), new[] { ModelsRes.MikeScenarioNumberOfSigmaLayers });
            }

            if (mikeScenario.NumberOfZlayers < 1 || mikeScenario.NumberOfZlayers > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZlayers, "1", "1000000"), new[] { ModelsRes.MikeScenarioNumberOfZlayers });
            }

            if (mikeScenario.NumberOfHydroOutputParameters < 1 || mikeScenario.NumberOfHydroOutputParameters > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "1", "1000000"), new[] { ModelsRes.MikeScenarioNumberOfHydroOutputParameters });
            }

            if (mikeScenario.NumberOfTransOutputParameters < 1 || mikeScenario.NumberOfTransOutputParameters > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "1", "1000000"), new[] { ModelsRes.MikeScenarioNumberOfTransOutputParameters });
            }

                //Error: Type not implemented [EstimatedHydroFileSize] of type [long]
                //Error: Type not implemented [EstimatedTransFileSize] of type [long]
            if (mikeScenario.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MikeScenarioLastUpdateContactTVItemID });
            }

                //Error: Type not implemented [EstimatedHydroFileSize] of type [long]
                //Error: Type not implemented [EstimatedTransFileSize] of type [long]

        }
        #endregion Validation

        #region Functions public
        public bool Add(MikeScenario mikeScenario)
        {
            mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Create);
            if (mikeScenario.ValidationResults.Count() > 0) return false;

            db.MikeScenarios.Add(mikeScenario);

            if (!TryToSave(mikeScenario)) return false;

            return true;
        }
        public bool AddRange(List<MikeScenario> mikeScenarioList)
        {
            foreach (MikeScenario mikeScenario in mikeScenarioList)
            {
                mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Create);
                if (mikeScenario.ValidationResults.Count() > 0) return false;
            }

            db.MikeScenarios.AddRange(mikeScenarioList);

            if (!TryToSaveRange(mikeScenarioList)) return false;

            return true;
        }
        public bool Delete(MikeScenario mikeScenario)
        {
            if (!db.MikeScenarios.Where(c => c.MikeScenarioID == mikeScenario.MikeScenarioID).Any())
            {
                mikeScenario.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", mikeScenario.MikeScenarioID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MikeScenarios.Remove(mikeScenario);

            if (!TryToSave(mikeScenario)) return false;

            return true;
        }
        public bool DeleteRange(List<MikeScenario> mikeScenarioList)
        {
            foreach (MikeScenario mikeScenario in mikeScenarioList)
            {
                if (!db.MikeScenarios.Where(c => c.MikeScenarioID == mikeScenario.MikeScenarioID).Any())
                {
                    mikeScenarioList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", mikeScenario.MikeScenarioID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MikeScenarios.RemoveRange(mikeScenarioList);

            if (!TryToSaveRange(mikeScenarioList)) return false;

            return true;
        }
        public bool Update(MikeScenario mikeScenario)
        {
            mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Update);
            if (mikeScenario.ValidationResults.Count() > 0) return false;

            db.MikeScenarios.Update(mikeScenario);

            if (!TryToSave(mikeScenario)) return false;

            return true;
        }
        public bool UpdateRange(List<MikeScenario> mikeScenarioList)
        {
            foreach (MikeScenario mikeScenario in mikeScenarioList)
            {
                mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Update);
                if (mikeScenario.ValidationResults.Count() > 0) return false;
            }
            db.MikeScenarios.UpdateRange(mikeScenarioList);

            if (!TryToSaveRange(mikeScenarioList)) return false;

            return true;
        }
        public IQueryable<MikeScenario> GetRead()
        {
            return db.MikeScenarios.AsNoTracking();
        }
        public IQueryable<MikeScenario> GetEdit()
        {
            return db.MikeScenarios;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(MikeScenario mikeScenario)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeScenario.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MikeScenario> mikeScenarioList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeScenarioList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
