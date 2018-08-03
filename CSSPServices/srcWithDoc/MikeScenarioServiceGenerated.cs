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
    ///     <para>bonjour MikeScenario</para>
    /// </summary>
    public partial class MikeScenarioService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeScenarioService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MikeScenario mikeScenario = validationContext.ObjectInstance as MikeScenario;
            mikeScenario.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeScenario.MikeScenarioID == 0)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioMikeScenarioID"), new[] { "MikeScenarioID" });
                }

                if (!GetRead().Where(c => c.MikeScenarioID == mikeScenario.MikeScenarioID).Any())
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeScenario", "MikeScenarioMikeScenarioID", mikeScenario.MikeScenarioID.ToString()), new[] { "MikeScenarioID" });
                }
            }

            TVItem TVItemMikeScenarioTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.MikeScenarioTVItemID select c).FirstOrDefault();

            if (TVItemMikeScenarioTVItemID == null)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioMikeScenarioTVItemID", mikeScenario.MikeScenarioTVItemID.ToString()), new[] { "MikeScenarioTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeScenarioTVItemID.TVType))
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeScenarioMikeScenarioTVItemID", "MikeScenario"), new[] { "MikeScenarioTVItemID" });
                }
            }

            if (mikeScenario.ParentMikeScenarioID != null)
            {
                TVItem TVItemParentMikeScenarioID = (from c in db.TVItems where c.TVItemID == mikeScenario.ParentMikeScenarioID select c).FirstOrDefault();

                if (TVItemParentMikeScenarioID == null)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioParentMikeScenarioID", (mikeScenario.ParentMikeScenarioID == null ? "" : mikeScenario.ParentMikeScenarioID.ToString())), new[] { "ParentMikeScenarioID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.MikeScenario,
                    };
                    if (!AllowableTVTypes.Contains(TVItemParentMikeScenarioID.TVType))
                    {
                        mikeScenario.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeScenarioParentMikeScenarioID", "MikeScenario"), new[] { "ParentMikeScenarioID" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(ScenarioStatusEnum), (int?)mikeScenario.ScenarioStatus);
            if (mikeScenario.ScenarioStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioScenarioStatus"), new[] { "ScenarioStatus" });
            }

            //ErrorInfo has no StringLength Attribute

            if (mikeScenario.MikeScenarioStartDateTime_Local.Year == 1)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioMikeScenarioStartDateTime_Local"), new[] { "MikeScenarioStartDateTime_Local" });
            }
            else
            {
                if (mikeScenario.MikeScenarioStartDateTime_Local.Year < 1980)
                {
                mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioMikeScenarioStartDateTime_Local", "1980"), new[] { "MikeScenarioStartDateTime_Local" });
                }
            }

            if (mikeScenario.MikeScenarioEndDateTime_Local.Year == 1)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioMikeScenarioEndDateTime_Local"), new[] { "MikeScenarioEndDateTime_Local" });
            }
            else
            {
                if (mikeScenario.MikeScenarioEndDateTime_Local.Year < 1980)
                {
                mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioMikeScenarioEndDateTime_Local", "1980"), new[] { "MikeScenarioEndDateTime_Local" });
                }
            }

            if (mikeScenario.MikeScenarioStartExecutionDateTime_Local != null && ((DateTime)mikeScenario.MikeScenarioStartExecutionDateTime_Local).Year < 1980)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioMikeScenarioStartExecutionDateTime_Local", "1980"), new[] { "MikeScenarioMikeScenarioStartExecutionDateTime_Local" });
            }

            if (mikeScenario.MikeScenarioExecutionTime_min != null)
            {
                if (mikeScenario.MikeScenarioExecutionTime_min < 1 || mikeScenario.MikeScenarioExecutionTime_min > 100000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioMikeScenarioExecutionTime_min", "1", "100000"), new[] { "MikeScenarioExecutionTime_min" });
                }
            }

            if (mikeScenario.WindSpeed_km_h < 0 || mikeScenario.WindSpeed_km_h > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioWindSpeed_km_h", "0", "100"), new[] { "WindSpeed_km_h" });
            }

            if (mikeScenario.WindDirection_deg < 0 || mikeScenario.WindDirection_deg > 360)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioWindDirection_deg", "0", "360"), new[] { "WindDirection_deg" });
            }

            if (mikeScenario.DecayFactor_per_day < 0 || mikeScenario.DecayFactor_per_day > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioDecayFactor_per_day", "0", "100"), new[] { "DecayFactor_per_day" });
            }

            if (mikeScenario.DecayFactorAmplitude < 0 || mikeScenario.DecayFactorAmplitude > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioDecayFactorAmplitude", "0", "100"), new[] { "DecayFactorAmplitude" });
            }

            if (mikeScenario.ResultFrequency_min < 0 || mikeScenario.ResultFrequency_min > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioResultFrequency_min", "0", "100"), new[] { "ResultFrequency_min" });
            }

            if (mikeScenario.AmbientTemperature_C < -10 || mikeScenario.AmbientTemperature_C > 40)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioAmbientTemperature_C", "-10", "40"), new[] { "AmbientTemperature_C" });
            }

            if (mikeScenario.AmbientSalinity_PSU < 0 || mikeScenario.AmbientSalinity_PSU > 40)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioAmbientSalinity_PSU", "0", "40"), new[] { "AmbientSalinity_PSU" });
            }

            if (mikeScenario.ManningNumber < 0 || mikeScenario.ManningNumber > 100)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioManningNumber", "0", "100"), new[] { "ManningNumber" });
            }

            if (mikeScenario.NumberOfElements != null)
            {
                if (mikeScenario.NumberOfElements < 1 || mikeScenario.NumberOfElements > 1000000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfElements", "1", "1000000"), new[] { "NumberOfElements" });
                }
            }

            if (mikeScenario.NumberOfTimeSteps != null)
            {
                if (mikeScenario.NumberOfTimeSteps < 1 || mikeScenario.NumberOfTimeSteps > 1000000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfTimeSteps", "1", "1000000"), new[] { "NumberOfTimeSteps" });
                }
            }

            if (mikeScenario.NumberOfSigmaLayers != null)
            {
                if (mikeScenario.NumberOfSigmaLayers < 0 || mikeScenario.NumberOfSigmaLayers > 100)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfSigmaLayers", "0", "100"), new[] { "NumberOfSigmaLayers" });
                }
            }

            if (mikeScenario.NumberOfZLayers != null)
            {
                if (mikeScenario.NumberOfZLayers < 0 || mikeScenario.NumberOfZLayers > 100)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfZLayers", "0", "100"), new[] { "NumberOfZLayers" });
                }
            }

            if (mikeScenario.NumberOfHydroOutputParameters != null)
            {
                if (mikeScenario.NumberOfHydroOutputParameters < 0 || mikeScenario.NumberOfHydroOutputParameters > 100)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfHydroOutputParameters", "0", "100"), new[] { "NumberOfHydroOutputParameters" });
                }
            }

            if (mikeScenario.NumberOfTransOutputParameters != null)
            {
                if (mikeScenario.NumberOfTransOutputParameters < 0 || mikeScenario.NumberOfTransOutputParameters > 100)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioNumberOfTransOutputParameters", "0", "100"), new[] { "NumberOfTransOutputParameters" });
                }
            }

            if (mikeScenario.EstimatedHydroFileSize != null)
            {
                if (mikeScenario.EstimatedHydroFileSize < 0 || mikeScenario.EstimatedHydroFileSize > 100000000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioEstimatedHydroFileSize", "0", "100000000"), new[] { "EstimatedHydroFileSize" });
                }
            }

            if (mikeScenario.EstimatedTransFileSize != null)
            {
                if (mikeScenario.EstimatedTransFileSize < 0 || mikeScenario.EstimatedTransFileSize > 100000000)
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeScenarioEstimatedTransFileSize", "0", "100000000"), new[] { "EstimatedTransFileSize" });
                }
            }

            if (mikeScenario.LastUpdateDate_UTC.Year == 1)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeScenarioLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeScenario.LastUpdateDate_UTC.Year < 1980)
                {
                mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeScenarioLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeScenario.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeScenarioLastUpdateContactTVItemID", mikeScenario.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mikeScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeScenarioLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mikeScenario.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MikeScenario GetMikeScenarioWithMikeScenarioID(int MikeScenarioID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.MikeScenarioID == MikeScenarioID
                    select c).FirstOrDefault();

        }
        public IQueryable<MikeScenario> GetMikeScenarioList()
        {
            IQueryable<MikeScenario> MikeScenarioQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            MikeScenarioQuery = EnhanceQueryStatements<MikeScenario>(MikeScenarioQuery) as IQueryable<MikeScenario>;

            return MikeScenarioQuery;
        }
        public MikeScenarioWeb GetMikeScenarioWebWithMikeScenarioID(int MikeScenarioID)
        {
            return FillMikeScenarioWeb().FirstOrDefault();

        }
        public IQueryable<MikeScenarioWeb> GetMikeScenarioWebList()
        {
            IQueryable<MikeScenarioWeb> MikeScenarioWebQuery = FillMikeScenarioWeb();

            MikeScenarioWebQuery = EnhanceQueryStatements<MikeScenarioWeb>(MikeScenarioWebQuery) as IQueryable<MikeScenarioWeb>;

            return MikeScenarioWebQuery;
        }
        public MikeScenarioReport GetMikeScenarioReportWithMikeScenarioID(int MikeScenarioID)
        {
            return FillMikeScenarioReport().FirstOrDefault();

        }
        public IQueryable<MikeScenarioReport> GetMikeScenarioReportList()
        {
            IQueryable<MikeScenarioReport> MikeScenarioReportQuery = FillMikeScenarioReport();

            MikeScenarioReportQuery = EnhanceQueryStatements<MikeScenarioReport>(MikeScenarioReportQuery) as IQueryable<MikeScenarioReport>;

            return MikeScenarioReportQuery;
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
            mikeScenario.ValidationResults = Validate(new ValidationContext(mikeScenario), ActionDBTypeEnum.Delete);
            if (mikeScenario.ValidationResults.Count() > 0) return false;

            db.MikeScenarios.Remove(mikeScenario);

            if (!TryToSave(mikeScenario)) return false;

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
        public IQueryable<MikeScenario> GetRead()
        {
            IQueryable<MikeScenario> mikeScenarioQuery = db.MikeScenarios.AsNoTracking();

            return mikeScenarioQuery;
        }
        public IQueryable<MikeScenario> GetEdit()
        {
            IQueryable<MikeScenario> mikeScenarioQuery = db.MikeScenarios;

            return mikeScenarioQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MikeScenarioFillWeb
        private IQueryable<MikeScenarioWeb> FillMikeScenarioWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ScenarioStatusEnumList = enums.GetEnumTextOrderedList(typeof(ScenarioStatusEnum));

             IQueryable<MikeScenarioWeb>  MikeScenarioWebQuery = (from c in db.MikeScenarios
                let MikeScenarioTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MikeScenarioTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MikeScenarioWeb
                    {
                        MikeScenarioTVItemLanguage = MikeScenarioTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        ScenarioStatusText = (from e in ScenarioStatusEnumList
                                where e.EnumID == (int?)c.ScenarioStatus
                                select e.EnumText).FirstOrDefault(),
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
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return MikeScenarioWebQuery;
        }
        #endregion Functions private Generated MikeScenarioFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}