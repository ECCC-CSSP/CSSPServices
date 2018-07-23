using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class TideSiteService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        #endregion Functions public

        #region Functions private
        private IQueryable<TideSite> FillTideSiteReport(IQueryable<TideSite> tideSiteQuery)
        {
            tideSiteQuery = (from c in tideSiteQuery
                             let TideSiteTVText = (from cl in db.TVItemLanguages
                                                   where cl.TVItemID == c.TideSiteTVItemID
                                                   && cl.Language == LanguageRequest
                                                   select cl.TVText).FirstOrDefault()
                             let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                            where cl.TVItemID == c.LastUpdateContactTVItemID
                                                            && cl.Language == LanguageRequest
                                                            select cl.TVText).FirstOrDefault()
                             select new TideSite
                             {
                                 TideSiteID = c.TideSiteID,
                                 TideSiteTVItemID = c.TideSiteTVItemID,
                                 WebTideModel = c.WebTideModel,
                                 WebTideDatum_m = c.WebTideDatum_m,
                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                 TideSiteWeb = new TideSiteWeb
                                 {
                                     TideSiteTVText = TideSiteTVText,
                                     LastUpdateContactTVText = LastUpdateContactTVText,
                                 },
                                 TideSiteReport = new TideSiteReport
                                 {
                                     TideSiteReportTest = "TideSiteReportTest",
                                 },
                                 HasErrors = false,
                                 ValidationResults = null,
                             });

            return tideSiteQuery;
        }
        #endregion Functions private
    }
}
