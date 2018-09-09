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
    public partial class SamplingPlanSubsectorSiteService
    {
        #region Functions private Generated FillSamplingPlanSubsectorSite_A
        private IQueryable<SamplingPlanSubsectorSite_A> FillSamplingPlanSubsectorSite_A()
        {
             IQueryable<SamplingPlanSubsectorSite_A> SamplingPlanSubsectorSite_AQuery = (from c in db.SamplingPlanSubsectorSites
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new SamplingPlanSubsectorSite_A
                    {
                        MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        SamplingPlanSubsectorSiteID = c.SamplingPlanSubsectorSiteID,
                        SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        IsDuplicate = c.IsDuplicate,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return SamplingPlanSubsectorSite_AQuery;
        }
        #endregion Functions private Generated FillSamplingPlanSubsectorSite_A

    }
}
