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
    public partial class MWQMSitePolSourceSiteService
    {
        #region Functions private Generated FillMWQMSitePolSourceSite_A
        private IQueryable<MWQMSitePolSourceSite_A> FillMWQMSitePolSourceSite_A()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<MWQMSitePolSourceSite_A> MWQMSitePolSourceSite_AQuery = (from c in db.MWQMSitePolSourceSites
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let PolSourceSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.PolSourceSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSitePolSourceSite_A
                    {
                        MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                        PolSourceSiteTVItemLanguage = PolSourceSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        MWQMSitePolSourceSiteID = c.MWQMSitePolSourceSiteID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        PolSourceSiteTVItemID = c.PolSourceSiteTVItemID,
                        TVType = c.TVType,
                        LinkReasons = c.LinkReasons,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMSitePolSourceSite_AQuery;
        }
        #endregion Functions private Generated FillMWQMSitePolSourceSite_A

    }
}
