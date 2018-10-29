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
        #region Functions private Generated FillEmailDistributionListExtraB
        private IQueryable<EmailDistributionListExtraB> FillEmailDistributionListExtraB()
        {
             IQueryable<EmailDistributionListExtraB> EmailDistributionListExtraBQuery = (from c in db.EmailDistributionLists
                let EmailDistributionListReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let CountryText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.CountryTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new EmailDistributionListExtraB
                    {
                        EmailDistributionListReportTest = EmailDistributionListReportTest,
                        CountryText = CountryText,
                        LastUpdateContactText = LastUpdateContactText,
                        EmailDistributionListID = c.EmailDistributionListID,
                        CountryTVItemID = c.CountryTVItemID,
                        Ordinal = c.Ordinal,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return EmailDistributionListExtraBQuery;
        }
        #endregion Functions private Generated FillEmailDistributionListExtraB

    }
}
