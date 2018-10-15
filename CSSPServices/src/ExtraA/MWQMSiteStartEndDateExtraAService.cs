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
    public partial class MWQMSiteStartEndDateService
    {
        #region Functions private Generated FillMWQMSiteStartEndDateExtraA
        private IQueryable<MWQMSiteStartEndDateExtraA> FillMWQMSiteStartEndDateExtraA()
        {
             IQueryable<MWQMSiteStartEndDateExtraA> MWQMSiteStartEndDateExtraAQuery = (from c in db.MWQMSiteStartEndDates
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSiteStartEndDateExtraA
                    {
                        MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MWQMSiteStartEndDateID = c.MWQMSiteStartEndDateID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMSiteStartEndDateExtraAQuery;
        }
        #endregion Functions private Generated FillMWQMSiteStartEndDateExtraA

    }
}
