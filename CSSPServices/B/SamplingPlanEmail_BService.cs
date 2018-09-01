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
    public partial class SamplingPlanEmailService
    {
        #region Functions private Generated FillSamplingPlanEmail_B
        private IQueryable<SamplingPlanEmail_B> FillSamplingPlanEmail_B()
        {
             IQueryable<SamplingPlanEmail_B> SamplingPlanEmail_BQuery = (from c in db.SamplingPlanEmails
                let SamplingPlanEmailReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new SamplingPlanEmail_B
                    {
                        SamplingPlanEmailReportTest = SamplingPlanEmailReportTest,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        SamplingPlanEmailID = c.SamplingPlanEmailID,
                        SamplingPlanID = c.SamplingPlanID,
                        Email = c.Email,
                        IsContractor = c.IsContractor,
                        LabSheetHasValueOver500 = c.LabSheetHasValueOver500,
                        LabSheetReceived = c.LabSheetReceived,
                        LabSheetAccepted = c.LabSheetAccepted,
                        LabSheetRejected = c.LabSheetRejected,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return SamplingPlanEmail_BQuery;
        }
        #endregion Functions private Generated FillSamplingPlanEmail_B

    }
}
