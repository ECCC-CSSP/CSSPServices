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
    public partial class EmailDistributionListService
    {
        #region Functions private Generated EmailDistributionListFillReport
        private IQueryable<EmailDistributionListReport> FillEmailDistributionListReport()
        {
             IQueryable<EmailDistributionListReport>  EmailDistributionListReportQuery = (from c in db.EmailDistributionLists
                let CountryTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.CountryTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new EmailDistributionListReport
                    {
                        EmailDistributionListReportTest = "Testing Report",
                        CountryTVItemLanguage = CountryTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        EmailDistributionListID = c.EmailDistributionListID,
                        CountryTVItemID = c.CountryTVItemID,
                        Ordinal = c.Ordinal,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return EmailDistributionListReportQuery;
        }
        #endregion Functions private Generated EmailDistributionListFillReport

    }
}
