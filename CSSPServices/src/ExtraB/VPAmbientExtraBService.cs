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
    public partial class VPAmbientService
    {
        #region Functions private Generated FillVPAmbientExtraB
        private IQueryable<VPAmbientExtraB> FillVPAmbientExtraB()
        {
             IQueryable<VPAmbientExtraB> VPAmbientExtraBQuery = (from c in db.VPAmbients
                let VPAmbientReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new VPAmbientExtraB
                    {
                        VPAmbientReportTest = VPAmbientReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        VPAmbientID = c.VPAmbientID,
                        VPScenarioID = c.VPScenarioID,
                        Row = c.Row,
                        MeasurementDepth_m = c.MeasurementDepth_m,
                        CurrentSpeed_m_s = c.CurrentSpeed_m_s,
                        CurrentDirection_deg = c.CurrentDirection_deg,
                        AmbientSalinity_PSU = c.AmbientSalinity_PSU,
                        AmbientTemperature_C = c.AmbientTemperature_C,
                        BackgroundConcentration_MPN_100ml = c.BackgroundConcentration_MPN_100ml,
                        PollutantDecayRate_per_day = c.PollutantDecayRate_per_day,
                        FarFieldCurrentSpeed_m_s = c.FarFieldCurrentSpeed_m_s,
                        FarFieldCurrentDirection_deg = c.FarFieldCurrentDirection_deg,
                        FarFieldDiffusionCoefficient = c.FarFieldDiffusionCoefficient,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return VPAmbientExtraBQuery;
        }
        #endregion Functions private Generated FillVPAmbientExtraB

    }
}
