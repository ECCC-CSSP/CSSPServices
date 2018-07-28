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
    public partial class PolSourceSiteService 
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
        private IQueryable<PolSourceSite> FillPolSourceSiteReport(IQueryable<PolSourceSite> polSourceSiteQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> PolSourceInactiveReasonEnumList = enums.GetEnumTextOrderedList(typeof(PolSourceInactiveReasonEnum));

            polSourceSiteQuery = (from c in polSourceSiteQuery
                                  let PolSourceSiteTVText = (from cl in db.TVItemLanguages
                                                             where cl.TVItemID == c.PolSourceSiteTVItemID
                                                             && cl.Language == LanguageRequest
                                                             select cl.TVText).FirstOrDefault()
                                  let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl.TVText).FirstOrDefault()
                                  select new PolSourceSite
                                  {
                                      PolSourceSiteID = c.PolSourceSiteID,
                                      PolSourceSiteTVItemID = c.PolSourceSiteTVItemID,
                                      Temp_Locator_CanDelete = c.Temp_Locator_CanDelete,
                                      Oldsiteid = c.Oldsiteid,
                                      Site = c.Site,
                                      SiteID = c.SiteID,
                                      IsPointSource = c.IsPointSource,
                                      InactiveReason = c.InactiveReason,
                                      CivicAddressTVItemID = c.CivicAddressTVItemID,
                                      LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                      LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                      PolSourceSiteWeb = new PolSourceSiteWeb
                                      {
                                          PolSourceSiteTVText = PolSourceSiteTVText,
                                          LastUpdateContactTVText = LastUpdateContactTVText,
                                          InactiveReasonText = (from e in PolSourceInactiveReasonEnumList
                                                                where e.EnumID == (int?)c.InactiveReason
                                                                select e.EnumText).FirstOrDefault(),
                                      },
                                      PolSourceSiteReport = new PolSourceSiteReport
                                      {
                                          PolSourceSiteReportTest = "PolSourceSiteReportTest",
                                      },
                                      HasErrors = false,
                                      ValidationResults = null,
                                  });

            return polSourceSiteQuery;
        }
        #endregion Functions private
    }
}
