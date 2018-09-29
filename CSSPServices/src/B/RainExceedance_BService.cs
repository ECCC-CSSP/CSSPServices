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
    public partial class RainExceedanceService
    {
        #region Functions private Generated FillRainExceedance_B
        private IQueryable<RainExceedance_B> FillRainExceedance_B()
        {
             IQueryable<RainExceedance_B> RainExceedance_BQuery = (from c in db.RainExceedances
                let RainExceedanceReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new RainExceedance_B
                    {
                        RainExceedanceReportTest = RainExceedanceReportTest,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        RainExceedanceID = c.RainExceedanceID,
                        YearRound = c.YearRound,
                        StartDate_Local = c.StartDate_Local,
                        EndDate_Local = c.EndDate_Local,
                        RainMaximum_mm = c.RainMaximum_mm,
                        RainExtreme_mm = c.RainExtreme_mm,
                        DaysPriorToStart = c.DaysPriorToStart,
                        RepeatEveryYear = c.RepeatEveryYear,
                        ProvinceTVItemIDs = c.ProvinceTVItemIDs,
                        SubsectorTVItemIDs = c.SubsectorTVItemIDs,
                        ClimateSiteTVItemIDs = c.ClimateSiteTVItemIDs,
                        EmailDistributionListIDs = c.EmailDistributionListIDs,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return RainExceedance_BQuery;
        }
        #endregion Functions private Generated FillRainExceedance_B

    }
}