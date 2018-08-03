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
    public partial class PolSourceObservationService
    {
        #region Functions private Generated PolSourceObservationFillReport
        private IQueryable<PolSourceObservationReport> FillPolSourceObservationReport()
        {
             IQueryable<PolSourceObservationReport>  PolSourceObservationReportQuery = (from c in db.PolSourceObservations
                let PolSourceSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.PolSourceSiteID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let ContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new PolSourceObservationReport
                    {
                        PolSourceObservationReportTest = "Testing Report",
                        PolSourceSiteTVItemLanguage = PolSourceSiteTVItemLanguage,
                        ContactTVItemLanguage = ContactTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        PolSourceObservationID = c.PolSourceObservationID,
                        PolSourceSiteID = c.PolSourceSiteID,
                        ObservationDate_Local = c.ObservationDate_Local,
                        ContactTVItemID = c.ContactTVItemID,
                        Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return PolSourceObservationReportQuery;
        }
        #endregion Functions private Generated PolSourceObservationFillReport

    }
}
