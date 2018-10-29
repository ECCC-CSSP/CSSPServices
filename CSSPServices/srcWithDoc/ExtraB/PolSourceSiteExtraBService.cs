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
        #region Functions private Generated FillPolSourceSiteExtraB
        private IQueryable<PolSourceSiteExtraB> FillPolSourceSiteExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> PolSourceInactiveReasonEnumList = enums.GetEnumTextOrderedList(typeof(PolSourceInactiveReasonEnum));

             IQueryable<PolSourceSiteExtraB> PolSourceSiteExtraBQuery = (from c in db.PolSourceSites
                let PolSourceSiteReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let PolSourceSiteText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.PolSourceSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let InactiveReasonText = (from e in PolSourceInactiveReasonEnumList
                    where e.EnumID == (int?)c.InactiveReason
                    select e.EnumText).FirstOrDefault()
                    select new PolSourceSiteExtraB
                    {
                        PolSourceSiteReportTest = PolSourceSiteReportTest,
                        PolSourceSiteText = PolSourceSiteText,
                        LastUpdateContactText = LastUpdateContactText,
                        InactiveReasonText = InactiveReasonText,
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

            return PolSourceSiteExtraBQuery;
        }
        #endregion Functions private Generated FillPolSourceSiteExtraB

    }
}
