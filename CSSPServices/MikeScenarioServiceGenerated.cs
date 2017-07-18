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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mikeScenario.MikeScenarioID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioID), new[] { ModelsRes.MikeScenarioMikeScenarioID });
                }
            }

            //MikeScenarioID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MikeScenarioTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.MikeScenarioTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioMikeScenarioTVItemID, "1"), new[] { ModelsRes.MikeScenarioMikeScenarioTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mikeScenario.MikeScenarioTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeScenarioMikeScenarioTVItemID, mikeScenario.MikeScenarioTVItemID.ToString()), new[] { ModelsRes.MikeScenarioMikeScenarioTVItemID });
            }

            if (mikeScenario.ParentMikeScenarioID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioParentMikeScenarioID, "1"), new[] { ModelsRes.MikeScenarioParentMikeScenarioID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mikeScenario.ParentMikeScenarioID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeScenarioParentMikeScenarioID, mikeScenario.ParentMikeScenarioID.ToString()), new[] { ModelsRes.MikeScenarioParentMikeScenarioID });
            }

            retStr = enums.ScenarioStatusOK(mikeScenario.ScenarioStatus);
            if (mikeScenario.ScenarioStatus == ScenarioStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioScenarioStatus), new[] { ModelsRes.MikeScenarioScenarioStatus });
            }

            if (string.IsNullOrWhiteSpace(mikeScenario.ErrorInfo))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioErrorInfo), new[] { ModelsRes.MikeScenarioErrorInfo });
            }

            //ErrorInfo has no StringLength Attribute

            if (mikeScenario.MikeScenarioStartDateTime_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioStartDateTime_Local), new[] { ModelsRes.MikeScenarioMikeScenarioStartDateTime_Local });
            }

            if (mikeScenario.MikeScenarioStartDateTime_Local.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeScenarioMikeScenarioStartDateTime_Local, "1980"), new[] { ModelsRes.MikeScenarioMikeScenarioStartDateTime_Local });
            }

            if (mikeScenario.MikeScenarioEndDateTime_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioEndDateTime_Local), new[] { ModelsRes.MikeScenarioMikeScenarioEndDateTime_Local });
            }

            if (mikeScenario.MikeScenarioEndDateTime_Local.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeScenarioMikeScenarioEndDateTime_Local, "1980"), new[] { ModelsRes.MikeScenarioMikeScenarioEndDateTime_Local });
            }

            if (mikeScenario.MikeScenarioStartExecutionDateTime_Local != null && ((DateTime)mikeScenario.MikeScenarioStartExecutionDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeScenarioMikeScenarioStartExecutionDateTime_Local, "1980"), new[] { ModelsRes.MikeScenarioMikeScenarioStartExecutionDateTime_Local });
            }

            if (mikeScenario.MikeScenarioExecutionTime_min < 1 || mikeScenario.MikeScenarioExecutionTime_min > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000"), new[] { ModelsRes.MikeScenarioMikeScenarioExecutionTime_min });
            }

            //WindSpeed_km_h (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.WindSpeed_km_h < 0 || mikeScenario.WindSpeed_km_h > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "100"), new[] { ModelsRes.MikeScenarioWindSpeed_km_h });
            }

            //WindDirection_deg (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.WindDirection_deg < 0 || mikeScenario.WindDirection_deg > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindDirection_deg, "0", "360"), new[] { ModelsRes.MikeScenarioWindDirection_deg });
            }

            //DecayFactor_per_day (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.DecayFactor_per_day < 0 || mikeScenario.DecayFactor_per_day > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "100"), new[] { ModelsRes.MikeScenarioDecayFactor_per_day });
            }

            //DecayIsConstant (bool) is required but no testing needed 

            //DecayFactorAmplitude (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.DecayFactorAmplitude < 0 || mikeScenario.DecayFactorAmplitude > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100"), new[] { ModelsRes.MikeScenarioDecayFactorAmplitude });
            }

            //ResultFrequency_min (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.ResultFrequency_min < 0 || mikeScenario.ResultFrequency_min > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "0", "100"), new[] { ModelsRes.MikeScenarioResultFrequency_min });
            }

            //AmbientTemperature_C (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.AmbientTemperature_C < -10 || mikeScenario.AmbientTemperature_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40"), new[] { ModelsRes.MikeScenarioAmbientTemperature_C });
            }

            //AmbientSalinity_PSU (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.AmbientSalinity_PSU < 0 || mikeScenario.AmbientSalinity_PSU > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40"), new[] { ModelsRes.MikeScenarioAmbientSalinity_PSU });
            }

            //ManningNumber (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.ManningNumber < 0 || mikeScenario.ManningNumber > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioManningNumber, "0", "100"), new[] { ModelsRes.MikeScenarioManningNumber });
            }

            if (mikeScenario.NumberOfElements < 1 || mikeScenario.NumberOfElements > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "10000"), new[] { ModelsRes.MikeScenarioNumberOfElements });
            }

            if (mikeScenario.NumberOfTimeSteps < 1 || mikeScenario.NumberOfTimeSteps > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000"), new[] { ModelsRes.MikeScenarioNumberOfTimeSteps });
            }

            if (mikeScenario.NumberOfSigmaLayers < 0 || mikeScenario.NumberOfSigmaLayers > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100"), new[] { ModelsRes.MikeScenarioNumberOfSigmaLayers });
            }

            if (mikeScenario.NumberOfZLayers < 0 || mikeScenario.NumberOfZLayers > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZLayers, "0", "100"), new[] { ModelsRes.MikeScenarioNumberOfZLayers });
            }

            if (mikeScenario.NumberOfHydroOutputParameters < 0 || mikeScenario.NumberOfHydroOutputParameters > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100"), new[] { ModelsRes.MikeScenarioNumberOfHydroOutputParameters });
            }

            if (mikeScenario.NumberOfTransOutputParameters < 0 || mikeScenario.NumberOfTransOutputParameters > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100"), new[] { ModelsRes.MikeScenarioNumberOfTransOutputParameters });
            }

            if (mikeScenario.EstimatedHydroFileSize < 0 || mikeScenario.EstimatedHydroFileSize > 100000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000"), new[] { ModelsRes.MikeScenarioEstimatedHydroFileSize });
            }

            if (mikeScenario.EstimatedTransFileSize < 0 || mikeScenario.EstimatedTransFileSize > 100000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000"), new[] { ModelsRes.MikeScenarioEstimatedTransFileSize });
            }

            if (mikeScenario.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioLastUpdateDate_UTC), new[] { ModelsRes.MikeScenarioLastUpdateDate_UTC });
            }

            if (mikeScenario.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeScenarioLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MikeScenarioLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeScenarioLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MikeScenarioLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mikeScenario.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeScenarioLastUpdateContactTVItemID, mikeScenario.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MikeScenarioLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

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
