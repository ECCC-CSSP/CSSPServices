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
    public partial class TideSiteService
    {
        #region Functions private Generated FillTideSiteExtraB
        private IQueryable<TideSiteExtraB> FillTideSiteExtraB()
        {
             IQueryable<TideSiteExtraB> TideSiteExtraBQuery = (from c in db.TideSites
                let TideSiteReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TideSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TideSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TideSiteExtraB
                    {
                        TideSiteReportTest = TideSiteReportTest,
                        TideSiteTVItemLanguage = TideSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TideSiteID = c.TideSiteID,
                        TideSiteTVItemID = c.TideSiteTVItemID,
                        WebTideModel = c.WebTideModel,
                        WebTideDatum_m = c.WebTideDatum_m,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TideSiteExtraBQuery;
        }
        #endregion Functions private Generated FillTideSiteExtraB

    }
}
