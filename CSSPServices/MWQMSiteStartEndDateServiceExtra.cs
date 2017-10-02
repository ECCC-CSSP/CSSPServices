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
    public partial class MWQMSiteStartEndDateService
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
        private IQueryable<MWQMSiteStartEndDate> FillMWQMSiteStartEndDateReport(IQueryable<MWQMSiteStartEndDate> mwqmSiteStartEndDateQuery, string FilterAndOrderText)
        {
            mwqmSiteStartEndDateQuery = (from c in mwqmSiteStartEndDateQuery
                                         let MWQMSiteTVText = (from cl in db.TVItemLanguages
                                                               where cl.TVItemID == c.MWQMSiteTVItemID
                                                               && cl.Language == LanguageRequest
                                                               select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                        where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                        && cl.Language == LanguageRequest
                                                                        select cl.TVText).FirstOrDefault()
                                         select new MWQMSiteStartEndDate
                                         {
                                             MWQMSiteStartEndDateID = c.MWQMSiteStartEndDateID,
                                             MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                             StartDate = c.StartDate,
                                             EndDate = c.EndDate,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             MWQMSiteStartEndDateWeb = new MWQMSiteStartEndDateWeb
                                             {
                                                 MWQMSiteTVText = MWQMSiteTVText,
                                                 LastUpdateContactTVText = LastUpdateContactTVText,
                                             },
                                             MWQMSiteStartEndDateReport = new MWQMSiteStartEndDateReport
                                             {
                                                 MWQMSiteStartEndDateReportTest = "MWQMSiteStartEndDateReportTest",
                                             },
                                             HasErrors = false,
                                             ValidationResults = null,
                                         });

            return mwqmSiteStartEndDateQuery;
        }
        #endregion Functions private
    }
}
