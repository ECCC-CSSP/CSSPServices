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
    public partial class BoxModelService
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
        private IQueryable<BoxModel> FillBoxModel(IQueryable<BoxModel> boxModelQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            boxModelQuery = (from c in boxModelQuery
                             let InfrastructureTVText = (from cl in db.TVItemLanguages
                                                         where cl.TVItemID == c.InfrastructureTVItemID
                                                         && cl.Language == LanguageRequest
                                                         select cl.TVText).FirstOrDefault()
                             let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                            where cl.TVItemID == c.LastUpdateContactTVItemID
                                                            && cl.Language == LanguageRequest
                                                            select cl.TVText).FirstOrDefault()
                             select new BoxModel
                             {
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
                                 BoxModelWeb = new BoxModelWeb
                                 {
                                     InfrastructureTVText = InfrastructureTVText,
                                     LastUpdateContactTVText = LastUpdateContactTVText,
                                 },
                                 BoxModelReport = new BoxModelReport
                                 {
                                     BoxModelReportTest = "BoxModelReportTest",
                                 },
                                 HasErrors = false,
                                 ValidationResults = null,
                             });

            return boxModelQuery;
        }
        #endregion Functions private
    }
}
