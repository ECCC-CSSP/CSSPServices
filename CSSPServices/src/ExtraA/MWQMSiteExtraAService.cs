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
        #region Functions private Generated FillMWQMSiteExtraA
        private IQueryable<MWQMSiteExtraA> FillMWQMSiteExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> MWQMSiteLatestClassificationEnumList = enums.GetEnumTextOrderedList(typeof(MWQMSiteLatestClassificationEnum));

             IQueryable<MWQMSiteExtraA> MWQMSiteExtraAQuery = (from c in db.MWQMSites
                let MWQMSiteText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMSiteLatestClassificationText = (from e in MWQMSiteLatestClassificationEnumList
                    where e.EnumID == (int?)c.MWQMSiteLatestClassification
                    select e.EnumText).FirstOrDefault()
                    select new MWQMSiteExtraA
                    {
                        MWQMSiteText = MWQMSiteText,
                        LastUpdateContactText = LastUpdateContactText,
                        MWQMSiteLatestClassificationText = MWQMSiteLatestClassificationText,
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

            return MWQMSiteExtraAQuery;
        }
        #endregion Functions private Generated FillMWQMSiteExtraA

    }
}
