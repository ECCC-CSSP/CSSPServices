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
    public partial class MikeScenarioService
    {
        #region Functions private Generated FillMikeScenarioExtraB
        private IQueryable<MikeScenarioExtraB> FillMikeScenarioExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ScenarioStatusEnumList = enums.GetEnumTextOrderedList(typeof(ScenarioStatusEnum));

             IQueryable<MikeScenarioExtraB> MikeScenarioExtraBQuery = (from c in db.MikeScenarios
                let MikeScenarioReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MikeScenarioText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MikeScenarioTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ScenarioStatusText = (from e in ScenarioStatusEnumList
                    where e.EnumID == (int?)c.ScenarioStatus
                    select e.EnumText).FirstOrDefault()
                    select new MikeScenarioExtraB
                    {
                        MikeScenarioReportTest = MikeScenarioReportTest,
                        MikeScenarioText = MikeScenarioText,
                        LastUpdateContactText = LastUpdateContactText,
                        ScenarioStatusText = ScenarioStatusText,
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
                        GenerateDecouplingFiles = c.GenerateDecouplingFiles,
                        UseDecouplingFiles = c.UseDecouplingFiles,
                        UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = c.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID,
                        ForSimulatingMWQMRunTVItemID = c.ForSimulatingMWQMRunTVItemID,
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
                    }).AsNoTracking();

            return MikeScenarioExtraBQuery;
        }
        #endregion Functions private Generated FillMikeScenarioExtraB

    }
}
