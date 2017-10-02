﻿using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class MikeScenarioService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        #endregion Functions public

        #region Functions private
        private IQueryable<MikeScenario> FillMikeScenarioReport(IQueryable<MikeScenario> mikeScenarioQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ScenarioStatusEnumList = enums.GetEnumTextOrderedList(typeof(ScenarioStatusEnum));

            mikeScenarioQuery = (from c in mikeScenarioQuery
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
                                     MikeScenarioWeb = new MikeScenarioWeb
                                     {
                                         MikeScenarioTVText = MikeScenarioTVText,
                                         LastUpdateContactTVText = LastUpdateContactTVText,
                                         ScenarioStatusText = (from e in ScenarioStatusEnumList
                                                               where e.EnumID == (int?)c.ScenarioStatus
                                                               select e.EnumText).FirstOrDefault(),
                                     },
                                     MikeScenarioReport = new MikeScenarioReport
                                     {
                                         MikeScenarioReportTest = "MikeScenarioReportTest",
                                     },
                                     HasErrors = false,
                                     ValidationResults = null,
                                 });

            return mikeScenarioQuery;
        }
        #endregion Functions private
    }
}
