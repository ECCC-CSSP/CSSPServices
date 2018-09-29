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
        #region Functions private Generated FillSamplingPlanSubsector_B
        private IQueryable<SamplingPlanSubsector_B> FillSamplingPlanSubsector_B()
        {
             IQueryable<SamplingPlanSubsector_B> SamplingPlanSubsector_BQuery = (from c in db.SamplingPlanSubsectors
                let SamplingPlanSubsectorReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SubsectorTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new SamplingPlanSubsector_B
                    {
                        SamplingPlanSubsectorReportTest = SamplingPlanSubsectorReportTest,
                        SubsectorTVItemLanguage = SubsectorTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                        SamplingPlanID = c.SamplingPlanID,
                        SubsectorTVItemID = c.SubsectorTVItemID,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return SamplingPlanSubsector_BQuery;
        }
        #endregion Functions private Generated FillSamplingPlanSubsector_B

    }
}