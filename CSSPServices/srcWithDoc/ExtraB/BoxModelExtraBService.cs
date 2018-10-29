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
    public partial class BoxModelService
    {
        #region Functions private Generated FillBoxModelExtraB
        private IQueryable<BoxModelExtraB> FillBoxModelExtraB()
        {
             IQueryable<BoxModelExtraB> BoxModelExtraBQuery = (from c in db.BoxModels
                let BoxModelReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let InfrastructureText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.InfrastructureTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new BoxModelExtraB
                    {
                        BoxModelReportTest = BoxModelReportTest,
                        InfrastructureText = InfrastructureText,
                        LastUpdateContactText = LastUpdateContactText,
                        BoxModelID = c.BoxModelID,
                        InfrastructureTVItemID = c.InfrastructureTVItemID,
                        Discharge_m3_day = c.Discharge_m3_day,
                        Depth_m = c.Depth_m,
                        Temperature_C = c.Temperature_C,
                        Dilution = c.Dilution,
                        DecayRate_per_day = c.DecayRate_per_day,
                        FCUntreated_MPN_100ml = c.FCUntreated_MPN_100ml,
                        FCPreDisinfection_MPN_100ml = c.FCPreDisinfection_MPN_100ml,
                        Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                        T90_hour = c.T90_hour,
                        FlowDuration_hour = c.FlowDuration_hour,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return BoxModelExtraBQuery;
        }
        #endregion Functions private Generated FillBoxModelExtraB

    }
}
