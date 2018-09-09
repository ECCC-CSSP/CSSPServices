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
    public partial class VPScenarioService
    {
        #region Functions private Generated FillVPScenario_B
        private IQueryable<VPScenario_B> FillVPScenario_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ScenarioStatusEnumList = enums.GetEnumTextOrderedList(typeof(ScenarioStatusEnum));

             IQueryable<VPScenario_B> VPScenario_BQuery = (from c in db.VPScenarios
                let VPScenarioReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SubsectorTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.InfrastructureTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new VPScenario_B
                    {
                        VPScenarioReportTest = VPScenarioReportTest,
                        SubsectorTVItemLanguage = SubsectorTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        VPScenarioStatusText = (from e in ScenarioStatusEnumList
                                where e.EnumID == (int?)c.VPScenarioStatus
                                select e.EnumText).FirstOrDefault(),
                        VPScenarioID = c.VPScenarioID,
                        InfrastructureTVItemID = c.InfrastructureTVItemID,
                        VPScenarioStatus = c.VPScenarioStatus,
                        UseAsBestEstimate = c.UseAsBestEstimate,
                        EffluentFlow_m3_s = c.EffluentFlow_m3_s,
                        EffluentConcentration_MPN_100ml = c.EffluentConcentration_MPN_100ml,
                        FroudeNumber = c.FroudeNumber,
                        PortDiameter_m = c.PortDiameter_m,
                        PortDepth_m = c.PortDepth_m,
                        PortElevation_m = c.PortElevation_m,
                        VerticalAngle_deg = c.VerticalAngle_deg,
                        HorizontalAngle_deg = c.HorizontalAngle_deg,
                        NumberOfPorts = c.NumberOfPorts,
                        PortSpacing_m = c.PortSpacing_m,
                        AcuteMixZone_m = c.AcuteMixZone_m,
                        ChronicMixZone_m = c.ChronicMixZone_m,
                        EffluentSalinity_PSU = c.EffluentSalinity_PSU,
                        EffluentTemperature_C = c.EffluentTemperature_C,
                        EffluentVelocity_m_s = c.EffluentVelocity_m_s,
                        RawResults = c.RawResults,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return VPScenario_BQuery;
        }
        #endregion Functions private Generated FillVPScenario_B

    }
}
