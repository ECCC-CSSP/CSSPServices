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
        #region Functions private Generated FillPolSourceObservationExtraB
        private IQueryable<PolSourceObservationExtraB> FillPolSourceObservationExtraB()
        {
             IQueryable<PolSourceObservationExtraB> PolSourceObservationExtraBQuery = (from c in db.PolSourceObservations
                let PolSourceObservationReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let PolSourceSiteText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.PolSourceSiteID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ContactName = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new PolSourceObservationExtraB
                    {
                        PolSourceObservationReportTest = PolSourceObservationReportTest,
                        PolSourceSiteText = PolSourceSiteText,
                        ContactName = ContactName,
                        LastUpdateContactText = LastUpdateContactText,
                        PolSourceObservationID = c.PolSourceObservationID,
                        PolSourceSiteID = c.PolSourceSiteID,
                        ObservationDate_Local = c.ObservationDate_Local,
                        ContactTVItemID = c.ContactTVItemID,
                        Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return PolSourceObservationExtraBQuery;
        }
        #endregion Functions private Generated FillPolSourceObservationExtraB

    }
}