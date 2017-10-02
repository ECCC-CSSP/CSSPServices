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
    public partial class RainExceedanceService 
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
        private IQueryable<RainExceedance> FillRainExceedanceReport(IQueryable<RainExceedance> rainExceedanceQuery, string FilterAndOrderText)
        {
            rainExceedanceQuery = (from c in rainExceedanceQuery
                                   let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                  where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                  && cl.Language == LanguageRequest
                                                                  select cl.TVText).FirstOrDefault()
                                   select new RainExceedance
                                   {
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
                                       RainExceedanceWeb = new RainExceedanceWeb
                                       {
                                           LastUpdateContactTVText = LastUpdateContactTVText,
                                       },
                                       RainExceedanceReport = new RainExceedanceReport
                                       {
                                           RainExceedanceReportTest = "RainExceedanceReportTest",
                                       },
                                       HasErrors = false,
                                       ValidationResults = null,
                                   });

            return rainExceedanceQuery;
        }
        #endregion Functions private
    }
}
