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
    public partial class MWQMSiteService
    {
        #region Functions private Generated FillMWQMSiteExtraB
        private IQueryable<MWQMSiteExtraB> FillMWQMSiteExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> MWQMSiteLatestClassificationEnumList = enums.GetEnumTextOrderedList(typeof(MWQMSiteLatestClassificationEnum));

             IQueryable<MWQMSiteExtraB> MWQMSiteExtraBQuery = (from c in db.MWQMSites
                let MWQMSiteReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSiteExtraB
                    {
                        MWQMSiteReportTest = MWQMSiteReportTest,
                        MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MWQMSiteLatestClassificationText = (from e in MWQMSiteLatestClassificationEnumList
                                where e.EnumID == (int?)c.MWQMSiteLatestClassification
                                select e.EnumText).FirstOrDefault(),
                        MWQMSiteID = c.MWQMSiteID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        MWQMSiteNumber = c.MWQMSiteNumber,
                        MWQMSiteDescription = c.MWQMSiteDescription,
                        MWQMSiteLatestClassification = c.MWQMSiteLatestClassification,
                        Ordinal = c.Ordinal,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMSiteExtraBQuery;
        }
        #endregion Functions private Generated FillMWQMSiteExtraB

    }
}
