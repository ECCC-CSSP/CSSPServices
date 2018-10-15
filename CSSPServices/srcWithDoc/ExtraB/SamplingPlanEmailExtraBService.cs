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
        #region Functions private Generated FillSamplingPlanEmailExtraB
        private IQueryable<SamplingPlanEmailExtraB> FillSamplingPlanEmailExtraB()
        {
             IQueryable<SamplingPlanEmailExtraB> SamplingPlanEmailExtraBQuery = (from c in db.SamplingPlanEmails
                let SamplingPlanEmailReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new SamplingPlanEmailExtraB
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

            return SamplingPlanEmailExtraBQuery;
        }
        #endregion Functions private Generated FillSamplingPlanEmailExtraB

    }
}
