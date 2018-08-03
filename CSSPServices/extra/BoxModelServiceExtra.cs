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
        #region Functions private Generated BoxModelFillReport
        private IQueryable<BoxModelReport> FillBoxModelReport()
        {
             IQueryable<BoxModelReport>  BoxModelReportQuery = (from c in db.BoxModels
                let InfrastructureTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.InfrastructureTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new BoxModelReport
                    {
                        BoxModelReportTest = "Testing Report",
                        InfrastructureTVItemLanguage = InfrastructureTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        BoxModelID = c.BoxModelID,
                        InfrastructureTVItemID = c.InfrastructureTVItemID,
                        Flow_m3_day = c.Flow_m3_day,
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
                    });

            return BoxModelReportQuery;
        }
        #endregion Functions private Generated BoxModelFillReport

    }
}
