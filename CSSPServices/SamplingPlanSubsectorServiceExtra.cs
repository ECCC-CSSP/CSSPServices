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
    public partial class SamplingPlanSubsectorService
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
        private IQueryable<SamplingPlanSubsector> FillSamplingPlanSubsectorReport(IQueryable<SamplingPlanSubsector> samplingPlanSubsectorQuery, string FilterAndOrderText)
        {
            samplingPlanSubsectorQuery = (from c in samplingPlanSubsectorQuery
                                          let SubsectorTVText = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.SubsectorTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl.TVText).FirstOrDefault()
                                          let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                         where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                         && cl.Language == LanguageRequest
                                                                         select cl.TVText).FirstOrDefault()
                                          select new SamplingPlanSubsector
                                          {
                                              SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                              SamplingPlanID = c.SamplingPlanID,
                                              SubsectorTVItemID = c.SubsectorTVItemID,
                                              LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                              LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                              SamplingPlanSubsectorWeb = new SamplingPlanSubsectorWeb
                                              {
                                                  SubsectorTVText = SubsectorTVText,
                                                  LastUpdateContactTVText = LastUpdateContactTVText,
                                              },
                                              SamplingPlanSubsectorReport = new SamplingPlanSubsectorReport
                                              {
                                                  SamplingPlanSubsectorReportTest = "SamplingPlanSubsectorReportTest",
                                              },
                                              HasErrors = false,
                                              ValidationResults = null,
                                          });

            return samplingPlanSubsectorQuery;
        }
        #endregion Functions private
    }
}
