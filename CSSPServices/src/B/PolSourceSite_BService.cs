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
    public partial class PolSourceSiteService
    {
        #region Functions private Generated FillPolSourceSite_B
        private IQueryable<PolSourceSite_B> FillPolSourceSite_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> PolSourceInactiveReasonEnumList = enums.GetEnumTextOrderedList(typeof(PolSourceInactiveReasonEnum));

             IQueryable<PolSourceSite_B> PolSourceSite_BQuery = (from c in db.PolSourceSites
                let PolSourceSiteReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let PolSourceSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.PolSourceSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new PolSourceSite_B
                    {
                        PolSourceSiteReportTest = PolSourceSiteReportTest,
                        PolSourceSiteTVItemLanguage = PolSourceSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        InactiveReasonText = (from e in PolSourceInactiveReasonEnumList
                                where e.EnumID == (int?)c.InactiveReason
                                select e.EnumText).FirstOrDefault(),
                        PolSourceSiteID = c.PolSourceSiteID,
                        PolSourceSiteTVItemID = c.PolSourceSiteTVItemID,
                        Temp_Locator_CanDelete = c.Temp_Locator_CanDelete,
                        Oldsiteid = c.Oldsiteid,
                        Site = c.Site,
                        SiteID = c.SiteID,
                        IsPointSource = c.IsPointSource,
                        InactiveReason = c.InactiveReason,
                        CivicAddressTVItemID = c.CivicAddressTVItemID,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return PolSourceSite_BQuery;
        }
        #endregion Functions private Generated FillPolSourceSite_B

    }
}
