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
    public partial class UseOfSiteService
    {
        #region Functions private Generated FillUseOfSite_B
        private IQueryable<UseOfSite_B> FillUseOfSite_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SiteTypeEnumList = enums.GetEnumTextOrderedList(typeof(SiteTypeEnum));

             IQueryable<UseOfSite_B> UseOfSite_BQuery = (from c in db.UseOfSites
                let UseOfSiteReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let SubsectorTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new UseOfSite_B
                    {
                        UseOfSiteReportTest = UseOfSiteReportTest,
                        SiteTVItemLanguage = SiteTVItemLanguage,
                        SubsectorTVItemLanguage = SubsectorTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        SiteTypeText = (from e in SiteTypeEnumList
                                where e.EnumID == (int?)c.SiteType
                                select e.EnumText).FirstOrDefault(),
                        UseOfSiteID = c.UseOfSiteID,
                        SiteTVItemID = c.SiteTVItemID,
                        SubsectorTVItemID = c.SubsectorTVItemID,
                        SiteType = c.SiteType,
                        Ordinal = c.Ordinal,
                        StartYear = c.StartYear,
                        EndYear = c.EndYear,
                        UseWeight = c.UseWeight,
                        Weight_perc = c.Weight_perc,
                        UseEquation = c.UseEquation,
                        Param1 = c.Param1,
                        Param2 = c.Param2,
                        Param3 = c.Param3,
                        Param4 = c.Param4,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return UseOfSite_BQuery;
        }
        #endregion Functions private Generated FillUseOfSite_B

    }
}
