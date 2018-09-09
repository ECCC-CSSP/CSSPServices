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
        #region Functions private Generated FillMWQMSite_A
        private IQueryable<MWQMSite_A> FillMWQMSite_A()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> MWQMSiteLatestClassificationEnumList = enums.GetEnumTextOrderedList(typeof(MWQMSiteLatestClassificationEnum));

             IQueryable<MWQMSite_A> MWQMSite_AQuery = (from c in db.MWQMSites
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSite_A
                    {
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

            return MWQMSite_AQuery;
        }
        #endregion Functions private Generated FillMWQMSite_A

    }
}
