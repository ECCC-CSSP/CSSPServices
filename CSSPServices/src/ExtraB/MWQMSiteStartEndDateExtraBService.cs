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
        #region Functions private Generated FillMWQMSiteStartEndDateExtraB
        private IQueryable<MWQMSiteStartEndDateExtraB> FillMWQMSiteStartEndDateExtraB()
        {
             IQueryable<MWQMSiteStartEndDateExtraB> MWQMSiteStartEndDateExtraBQuery = (from c in db.MWQMSiteStartEndDates
                let MWQMSiteStartEndDateReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMSiteText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new MWQMSiteStartEndDateExtraB
                    {
                        MWQMSiteStartEndDateReportTest = MWQMSiteStartEndDateReportTest,
                        MWQMSiteText = MWQMSiteText,
                        LastUpdateContactText = LastUpdateContactText,
                        MWQMSiteStartEndDateID = c.MWQMSiteStartEndDateID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMSiteStartEndDateExtraBQuery;
        }
        #endregion Functions private Generated FillMWQMSiteStartEndDateExtraB

    }
}
