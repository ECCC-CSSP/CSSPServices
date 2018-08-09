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
    public partial class VPResultService
    {
        #region Functions private Generated FillVPResult_B
        private IQueryable<VPResult_B> FillVPResult_B()
        {
             IQueryable<VPResult_B> VPResult_BQuery = (from c in db.VPResults
                let VPResultReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new VPResult_B
                    {
                        VPResultReportTest = VPResultReportTest,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
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
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return VPResult_BQuery;
        }
        #endregion Functions private Generated FillVPResult_B

    }
}
