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
    public partial class MWQMSiteStartEndDateService
    {
        #region Functions private Generated MWQMSiteStartEndDateFillReport
        private IQueryable<MWQMSiteStartEndDateReport> FillMWQMSiteStartEndDateReport()
        {
             IQueryable<MWQMSiteStartEndDateReport>  MWQMSiteStartEndDateReportQuery = (from c in db.MWQMSiteStartEndDates
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSiteStartEndDateReport
                    {
                        MWQMSiteStartEndDateReportTest = "Testing Report",
                        MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MWQMSiteStartEndDateID = c.MWQMSiteStartEndDateID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return MWQMSiteStartEndDateReportQuery;
        }
        #endregion Functions private Generated MWQMSiteStartEndDateFillReport

    }
}
