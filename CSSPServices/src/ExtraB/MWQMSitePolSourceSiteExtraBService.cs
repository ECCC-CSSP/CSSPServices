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
        #region Functions private Generated FillMWQMSitePolSourceSiteExtraB
        private IQueryable<MWQMSitePolSourceSiteExtraB> FillMWQMSitePolSourceSiteExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<MWQMSitePolSourceSiteExtraB> MWQMSitePolSourceSiteExtraBQuery = (from c in db.MWQMSitePolSourceSites
                let MWQMSitePolSourceSiteReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMSiteText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
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
                let TVTypeText = (from e in TVTypeEnumList
                    where e.EnumID == (int?)c.TVType
                    select e.EnumText).FirstOrDefault()
                    select new MWQMSitePolSourceSiteExtraB
                    {
                        MWQMSitePolSourceSiteReportTest = MWQMSitePolSourceSiteReportTest,
                        MWQMSiteText = MWQMSiteText,
                        PolSourceSiteText = PolSourceSiteText,
                        LastUpdateContactText = LastUpdateContactText,
                        TVTypeText = TVTypeText,
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

            return MWQMSitePolSourceSiteExtraBQuery;
        }
        #endregion Functions private Generated FillMWQMSitePolSourceSiteExtraB

    }
}
