using CSSPEnums;
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
    public partial class VPAmbientService
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
        private IQueryable<VPAmbient> FillVPAmbientReport(IQueryable<VPAmbient> vpAmbientQuery)
        {
            vpAmbientQuery = (from c in vpAmbientQuery
                              let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                             where cl.TVItemID == c.LastUpdateContactTVItemID
                                                             && cl.Language == LanguageRequest
                                                             select cl).FirstOrDefault()
                              select new VPAmbient
                              {
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
                                  VPAmbientWeb = new VPAmbientWeb
                                  {
                                      LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                  },
                                  VPAmbientReport = new VPAmbientReport
                                  {
                                      VPAmbientReportTest = "VPAmbientReportTest",
                                  },
                                  HasErrors = false,
                                  ValidationResults = null,
                              });

            return vpAmbientQuery;
        }
        #endregion Functions private
    }
}
