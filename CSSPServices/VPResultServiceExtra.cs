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
    public partial class VPResultService
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
        private IQueryable<VPResult> FillVPResultReport(IQueryable<VPResult> vpResultQuery)
        {
            vpResultQuery = (from c in vpResultQuery
                             let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                            where cl.TVItemID == c.LastUpdateContactTVItemID
                                                            && cl.Language == LanguageRequest
                                                            select cl.TVText).FirstOrDefault()
                             select new VPResult
                             {
                                 VPResultID = c.VPResultID,
                                 VPScenarioID = c.VPScenarioID,
                                 Ordinal = c.Ordinal,
                                 Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                                 Dilution = c.Dilution,
                                 FarFieldWidth_m = c.FarFieldWidth_m,
                                 DispersionDistance_m = c.DispersionDistance_m,
                                 TravelTime_hour = c.TravelTime_hour,
                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                 VPResultWeb = new VPResultWeb
                                 {
                                     LastUpdateContactTVText = LastUpdateContactTVText,
                                 },
                                 VPResultReport = new VPResultReport
                                 {
                                     VPResultReportTest = "VPResultReportTest",
                                 },
                                 HasErrors = false,
                                 ValidationResults = null,
                             });

            return vpResultQuery;
        }
        #endregion Functions private
    }
}
