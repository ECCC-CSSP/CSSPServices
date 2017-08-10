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
        #endregion Properties

        #region Constructors
        public MikeScenarioService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioID), new[] { "MikeScenarioID" });
                }
            }

            //MikeScenarioID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MikeScenarioTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMikeScenarioTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.MikeScenarioTVItemID select c).FirstOrDefault();

            if (TVItemMikeScenarioTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeScenarioMikeScenarioTVItemID, mikeScenario.MikeScenarioTVItemID.ToString()), new[] { "MikeScenarioTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeScenarioTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeScenarioMikeScenarioTVItemID, "MikeScenario"), new[] { "MikeScenarioTVItemID" });
                }
            }

            if (mikeScenario.ParentMikeScenarioID != null)
            {
                TVItem TVItemParentMikeScenarioID = (from c in db.TVItems where c.TVItemID == mikeScenario.ParentMikeScenarioID select c).FirstOrDefault();

                if (TVItemParentMikeScenarioID == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeScenarioParentMikeScenarioID, mikeScenario.ParentMikeScenarioID.ToString()), new[] { "ParentMikeScenarioID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.MikeScenario,
                    };
                    if (!AllowableTVTypes.Contains(TVItemParentMikeScenarioID.TVType))
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeScenarioParentMikeScenarioID, "MikeScenario"), new[] { "ParentMikeScenarioID" });
                    }
                }
            }

            retStr = enums.ScenarioStatusOK(mikeScenario.ScenarioStatus);
            if (mikeScenario.ScenarioStatus == ScenarioStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioScenarioStatus), new[] { "ScenarioStatus" });
            }

            //ErrorInfo has no StringLength Attribute

            if (mikeScenario.MikeScenarioStartDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioStartDateTime_Local), new[] { "MikeScenarioStartDateTime_Local" });
            }
            else
            {
                if (mikeScenario.MikeScenarioStartDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeScenarioMikeScenarioStartDateTime_Local, "1980"), new[] { "MikeScenarioStartDateTime_Local" });
                }
            }

            if (mikeScenario.MikeScenarioEndDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioMikeScenarioEndDateTime_Local), new[] { "MikeScenarioEndDateTime_Local" });
            }
            else
            {
                if (mikeScenario.MikeScenarioEndDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeScenarioMikeScenarioEndDateTime_Local, "1980"), new[] { "MikeScenarioEndDateTime_Local" });
                }
            }

            if (mikeScenario.MikeScenarioStartExecutionDateTime_Local != null && ((DateTime)mikeScenario.MikeScenarioStartExecutionDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeScenarioMikeScenarioStartExecutionDateTime_Local, "1980"), new[] { ModelsRes.MikeScenarioMikeScenarioStartExecutionDateTime_Local });
            }

            if (mikeScenario.MikeScenarioExecutionTime_min != null)
            {
                if (mikeScenario.MikeScenarioExecutionTime_min < 1 || mikeScenario.MikeScenarioExecutionTime_min > 100000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioMikeScenarioExecutionTime_min, "1", "100000"), new[] { "MikeScenarioExecutionTime_min" });
                }
            }

            //WindSpeed_km_h (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.WindSpeed_km_h < 0 || mikeScenario.WindSpeed_km_h > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindSpeed_km_h, "0", "100"), new[] { "WindSpeed_km_h" });
            }

            //WindDirection_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.WindDirection_deg < 0 || mikeScenario.WindDirection_deg > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioWindDirection_deg, "0", "360"), new[] { "WindDirection_deg" });
            }

            //DecayFactor_per_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.DecayFactor_per_day < 0 || mikeScenario.DecayFactor_per_day > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactor_per_day, "0", "100"), new[] { "DecayFactor_per_day" });
            }

            //DecayIsConstant (bool) is required but no testing needed 

            //DecayFactorAmplitude (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.DecayFactorAmplitude < 0 || mikeScenario.DecayFactorAmplitude > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioDecayFactorAmplitude, "0", "100"), new[] { "DecayFactorAmplitude" });
            }

            //ResultFrequency_min (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.ResultFrequency_min < 0 || mikeScenario.ResultFrequency_min > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioResultFrequency_min, "0", "100"), new[] { "ResultFrequency_min" });
            }

            //AmbientTemperature_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.AmbientTemperature_C < -10 || mikeScenario.AmbientTemperature_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientTemperature_C, "-10", "40"), new[] { "AmbientTemperature_C" });
            }

            //AmbientSalinity_PSU (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.AmbientSalinity_PSU < 0 || mikeScenario.AmbientSalinity_PSU > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioAmbientSalinity_PSU, "0", "40"), new[] { "AmbientSalinity_PSU" });
            }

            //ManningNumber (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeScenario.ManningNumber < 0 || mikeScenario.ManningNumber > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioManningNumber, "0", "100"), new[] { "ManningNumber" });
            }

            if (mikeScenario.NumberOfElements != null)
            {
                if (mikeScenario.NumberOfElements < 1 || mikeScenario.NumberOfElements > 10000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfElements, "1", "10000"), new[] { "NumberOfElements" });
                }
            }

            if (mikeScenario.NumberOfTimeSteps != null)
            {
                if (mikeScenario.NumberOfTimeSteps < 1 || mikeScenario.NumberOfTimeSteps > 10000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTimeSteps, "1", "10000"), new[] { "NumberOfTimeSteps" });
                }
            }

            if (mikeScenario.NumberOfSigmaLayers != null)
            {
                if (mikeScenario.NumberOfSigmaLayers < 0 || mikeScenario.NumberOfSigmaLayers > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfSigmaLayers, "0", "100"), new[] { "NumberOfSigmaLayers" });
                }
            }

            if (mikeScenario.NumberOfZLayers != null)
            {
                if (mikeScenario.NumberOfZLayers < 0 || mikeScenario.NumberOfZLayers > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfZLayers, "0", "100"), new[] { "NumberOfZLayers" });
                }
            }

            if (mikeScenario.NumberOfHydroOutputParameters != null)
            {
                if (mikeScenario.NumberOfHydroOutputParameters < 0 || mikeScenario.NumberOfHydroOutputParameters > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfHydroOutputParameters, "0", "100"), new[] { "NumberOfHydroOutputParameters" });
                }
            }

            if (mikeScenario.NumberOfTransOutputParameters != null)
            {
                if (mikeScenario.NumberOfTransOutputParameters < 0 || mikeScenario.NumberOfTransOutputParameters > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioNumberOfTransOutputParameters, "0", "100"), new[] { "NumberOfTransOutputParameters" });
                }
            }

            if (mikeScenario.EstimatedHydroFileSize != null)
            {
                if (mikeScenario.EstimatedHydroFileSize < 0 || mikeScenario.EstimatedHydroFileSize > 100000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedHydroFileSize, "0", "100000000"), new[] { "EstimatedHydroFileSize" });
                }
            }

            if (mikeScenario.EstimatedTransFileSize != null)
            {
                if (mikeScenario.EstimatedTransFileSize < 0 || mikeScenario.EstimatedTransFileSize > 100000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeScenarioEstimatedTransFileSize, "0", "100000000"), new[] { "EstimatedTransFileSize" });
                }
            }

            if (mikeScenario.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeScenarioLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeScenario.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeScenarioLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeScenarioLastUpdateContactTVItemID, mikeScenario.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeScenarioLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mikeScenario.MikeScenarioTVText) && mikeScenario.MikeScenarioTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeScenarioMikeScenarioTVText, "200"), new[] { "MikeScenarioTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mikeScenario.LastUpdateContactTVText) && mikeScenario.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeScenarioLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mikeScenario.ScenarioStatusText) && mikeScenario.ScenarioStatusText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeScenarioScenarioStatusText, "100"), new[] { "ScenarioStatusText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MikeScenario GetMikeScenarioWithMikeScenarioID(int MikeScenarioID)
        {
            IQueryable<MikeScenario> mikeScenarioQuery = (from c in GetRead()
                                                where c.MikeScenarioID == MikeScenarioID
                                                select c);

            return FillMikeScenario(mikeScenarioQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MikeScenario mikeScenario)
        {
            mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Create);
            if (mikeScenario.ValidationResults.Count() > 0) return false;

            db.MikeScenarios.Add(mikeScenario);

            if (!TryToSave(mikeScenario)) return false;

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
        public bool Update(MikeScenario mikeScenario)
        {
            if (!db.MikeScenarios.Where(c => c.MikeScenarioID == mikeScenario.MikeScenarioID).Any())
            {
                mikeScenario.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioID", mikeScenario.MikeScenarioID.ToString())) }.AsEnumerable();
                return false;
            }

            mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Update);
            if (mikeScenario.ValidationResults.Count() > 0) return false;

            db.MikeScenarios.Update(mikeScenario);

            if (!TryToSave(mikeScenario)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MikeScenario> FillMikeScenario(IQueryable<MikeScenario> mikeScenarioQuery)
        {
            List<MikeScenario> MikeScenarioList = (from c in mikeScenarioQuery
                                         let MikeScenarioTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.MikeScenarioTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MikeScenario
                                         {
                                             MikeScenarioID = c.MikeScenarioID,
                                             MikeScenarioTVItemID = c.MikeScenarioTVItemID,
                                             ParentMikeScenarioID = c.ParentMikeScenarioID,
                                             ScenarioStatus = c.ScenarioStatus,
                                             ErrorInfo = c.ErrorInfo,
                                             MikeScenarioStartDateTime_Local = c.MikeScenarioStartDateTime_Local,
                                             MikeScenarioEndDateTime_Local = c.MikeScenarioEndDateTime_Local,
                                             MikeScenarioStartExecutionDateTime_Local = c.MikeScenarioStartExecutionDateTime_Local,
                                             MikeScenarioExecutionTime_min = c.MikeScenarioExecutionTime_min,
                                             WindSpeed_km_h = c.WindSpeed_km_h,
                                             WindDirection_deg = c.WindDirection_deg,
                                             DecayFactor_per_day = c.DecayFactor_per_day,
                                             DecayIsConstant = c.DecayIsConstant,
                                             DecayFactorAmplitude = c.DecayFactorAmplitude,
                                             ResultFrequency_min = c.ResultFrequency_min,
                                             AmbientTemperature_C = c.AmbientTemperature_C,
                                             AmbientSalinity_PSU = c.AmbientSalinity_PSU,
                                             ManningNumber = c.ManningNumber,
                                             NumberOfElements = c.NumberOfElements,
                                             NumberOfTimeSteps = c.NumberOfTimeSteps,
                                             NumberOfSigmaLayers = c.NumberOfSigmaLayers,
                                             NumberOfZLayers = c.NumberOfZLayers,
                                             NumberOfHydroOutputParameters = c.NumberOfHydroOutputParameters,
                                             NumberOfTransOutputParameters = c.NumberOfTransOutputParameters,
                                             EstimatedHydroFileSize = c.EstimatedHydroFileSize,
                                             EstimatedTransFileSize = c.EstimatedTransFileSize,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             MikeScenarioTVText = MikeScenarioTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (MikeScenario mikeScenario in MikeScenarioList)
            {
                mikeScenario.ScenarioStatusText = enums.GetEnumText_ScenarioStatusEnum(mikeScenario.ScenarioStatus);
            }

            return MikeScenarioList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
