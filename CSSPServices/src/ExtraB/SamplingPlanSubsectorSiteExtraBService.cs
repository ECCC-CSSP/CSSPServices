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
        #region Functions private Generated FillSamplingPlanSubsectorSiteExtraB
        private IQueryable<SamplingPlanSubsectorSiteExtraB> FillSamplingPlanSubsectorSiteExtraB()
        {
             IQueryable<SamplingPlanSubsectorSiteExtraB> SamplingPlanSubsectorSiteExtraBQuery = (from c in db.SamplingPlanSubsectorSites
                let SamplingPlanSubsectorSiteReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMSiteText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new SamplingPlanSubsectorSiteExtraB
                    {
                        SamplingPlanSubsectorSiteReportTest = SamplingPlanSubsectorSiteReportTest,
                        MWQMSiteText = MWQMSiteText,
                        LastUpdateContactText = LastUpdateContactText,
                        SamplingPlanSubsectorSiteID = c.SamplingPlanSubsectorSiteID,
                        SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        IsDuplicate = c.IsDuplicate,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return SamplingPlanSubsectorSiteExtraBQuery;
        }
        #endregion Functions private Generated FillSamplingPlanSubsectorSiteExtraB

    }
}