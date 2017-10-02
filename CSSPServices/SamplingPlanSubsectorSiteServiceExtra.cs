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
    public partial class SamplingPlanSubsectorSiteService
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
        private IQueryable<SamplingPlanSubsectorSite> FillSamplingPlanSubsectorSiteReport(IQueryable<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteQuery, string FilterAndOrderText)
        {
            samplingPlanSubsectorSiteQuery = (from c in samplingPlanSubsectorSiteQuery
                                              let MWQMSiteTVText = (from cl in db.TVItemLanguages
                                                                    where cl.TVItemID == c.MWQMSiteTVItemID
                                                                    && cl.Language == LanguageRequest
                                                                    select cl.TVText).FirstOrDefault()
                                              let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                             where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                             && cl.Language == LanguageRequest
                                                                             select cl.TVText).FirstOrDefault()
                                              select new SamplingPlanSubsectorSite
                                              {
                                                  SamplingPlanSubsectorSiteID = c.SamplingPlanSubsectorSiteID,
                                                  SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                                  MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                  IsDuplicate = c.IsDuplicate,
                                                  LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                  LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                  SamplingPlanSubsectorSiteWeb = new SamplingPlanSubsectorSiteWeb
                                                  {
                                                      MWQMSiteTVText = MWQMSiteTVText,
                                                      LastUpdateContactTVText = LastUpdateContactTVText,
                                                  },
                                                  SamplingPlanSubsectorSiteReport = new SamplingPlanSubsectorSiteReport
                                                  {
                                                      SamplingPlanSubsectorSiteReportTest = "SamplingPlanSubsectorSiteReportTest",
                                                  },
                                                  HasErrors = false,
                                                  ValidationResults = null,
                                              });

            return samplingPlanSubsectorSiteQuery;
        }
        #endregion Functions private
    }
}
