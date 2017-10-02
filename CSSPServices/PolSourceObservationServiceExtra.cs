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
    public partial class PolSourceObservationService
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
        #endregion Function public

        #region Function private
        private IQueryable<PolSourceObservation> FillPolSourceObservationReport(IQueryable<PolSourceObservation> polSourceObservationQuery, string FilterAndOrderText)
        {
            polSourceObservationQuery = (from c in polSourceObservationQuery
                                         let PolSourceSiteTVText = (from cl in db.TVItemLanguages
                                                                    where cl.TVItemID == c.PolSourceSiteID
                                                                    && cl.Language == LanguageRequest
                                                                    select cl.TVText).FirstOrDefault()
                                         let ContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.ContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                        where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                        && cl.Language == LanguageRequest
                                                                        select cl.TVText).FirstOrDefault()
                                         select new PolSourceObservation
                                         {
                                             PolSourceObservationID = c.PolSourceObservationID,
                                             PolSourceSiteID = c.PolSourceSiteID,
                                             ObservationDate_Local = c.ObservationDate_Local,
                                             ContactTVItemID = c.ContactTVItemID,
                                             Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             PolSourceObservationWeb = new PolSourceObservationWeb
                                             {
                                                 PolSourceSiteTVText = PolSourceSiteTVText,
                                                 ContactTVText = ContactTVText,
                                                 LastUpdateContactTVText = LastUpdateContactTVText,
                                             },
                                             PolSourceObservationReport = new PolSourceObservationReport
                                             {
                                                 PolSourceObservationReportTest = "PolSourceObservationReportTest",
                                             },
                                             HasErrors = false,
                                             ValidationResults = null,
                                         });

            return polSourceObservationQuery;
        }
        #endregion Functions private    
    }
}
