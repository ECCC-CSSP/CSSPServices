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
    public partial class SamplingPlanSubsectorService
    {
        #region Functions private Generated FillSamplingPlanSubsectorExtraB
        private IQueryable<SamplingPlanSubsectorExtraB> FillSamplingPlanSubsectorExtraB()
        {
             IQueryable<SamplingPlanSubsectorExtraB> SamplingPlanSubsectorExtraBQuery = (from c in db.SamplingPlanSubsectors
                let SamplingPlanSubsectorReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SubsectorText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new SamplingPlanSubsectorExtraB
                    {
                        SamplingPlanSubsectorReportTest = SamplingPlanSubsectorReportTest,
                        SubsectorText = SubsectorText,
                        LastUpdateContactText = LastUpdateContactText,
                        SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                        SamplingPlanID = c.SamplingPlanID,
                        SubsectorTVItemID = c.SubsectorTVItemID,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return SamplingPlanSubsectorExtraBQuery;
        }
        #endregion Functions private Generated FillSamplingPlanSubsectorExtraB

    }
}