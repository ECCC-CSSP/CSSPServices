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
    public partial class MikeSourceStartEndService
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
        private IQueryable<MikeSourceStartEnd> FillMikeSourceStartEndReport(IQueryable<MikeSourceStartEnd> mikeSourceStartEndQuery)
        {
            mikeSourceStartEndQuery = (from c in mikeSourceStartEndQuery
                                       let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                      where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                      && cl.Language == LanguageRequest
                                                                      select cl.TVText).FirstOrDefault()
                                       select new MikeSourceStartEnd
                                       {
                                           MikeSourceStartEndID = c.MikeSourceStartEndID,
                                           MikeSourceID = c.MikeSourceID,
                                           StartDateAndTime_Local = c.StartDateAndTime_Local,
                                           EndDateAndTime_Local = c.EndDateAndTime_Local,
                                           SourceFlowStart_m3_day = c.SourceFlowStart_m3_day,
                                           SourceFlowEnd_m3_day = c.SourceFlowEnd_m3_day,
                                           SourcePollutionStart_MPN_100ml = c.SourcePollutionStart_MPN_100ml,
                                           SourcePollutionEnd_MPN_100ml = c.SourcePollutionEnd_MPN_100ml,
                                           SourceTemperatureStart_C = c.SourceTemperatureStart_C,
                                           SourceTemperatureEnd_C = c.SourceTemperatureEnd_C,
                                           SourceSalinityStart_PSU = c.SourceSalinityStart_PSU,
                                           SourceSalinityEnd_PSU = c.SourceSalinityEnd_PSU,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           MikeSourceStartEndWeb = new MikeSourceStartEndWeb
                                           {
                                               LastUpdateContactTVText = LastUpdateContactTVText,
                                           },
                                           MikeSourceStartEndReport = new MikeSourceStartEndReport
                                           {
                                               MikeSourceStartEndReportTest = "MikeSourceStartEndReportTest",
                                           },
                                           HasErrors = false,
                                           ValidationResults = null,
                                       });

            return mikeSourceStartEndQuery;
        }
        #endregion Functions private
    }
}
