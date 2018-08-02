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
    public partial class MWQMSiteService
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
        private IQueryable<MWQMSite> FillMWQMSiteReport(IQueryable<MWQMSite> mwqmSiteQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> MWQMSiteLatestClassificationEnumList = enums.GetEnumTextOrderedList(typeof(MWQMSiteLatestClassificationEnum));

            mwqmSiteQuery = (from c in mwqmSiteQuery
                             let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                                                   where cl.TVItemID == c.MWQMSiteTVItemID
                                                   && cl.Language == LanguageRequest
                                                   select cl).FirstOrDefault()
                             let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                            where cl.TVItemID == c.LastUpdateContactTVItemID
                                                            && cl.Language == LanguageRequest
                                                            select cl).FirstOrDefault()
                             select new MWQMSite
                             {
                                 MWQMSiteID = c.MWQMSiteID,
                                 MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                 MWQMSiteNumber = c.MWQMSiteNumber,
                                 MWQMSiteDescription = c.MWQMSiteDescription,
                                 MWQMSiteLatestClassification = c.MWQMSiteLatestClassification,
                                 Ordinal = c.Ordinal,
                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                 MWQMSiteWeb = new MWQMSiteWeb
                                 {
                                     MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                                     LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                     MWQMSiteLatestClassificationText = (from e in MWQMSiteLatestClassificationEnumList
                                                                         where e.EnumID == (int?)c.MWQMSiteLatestClassification
                                                                         select e.EnumText).FirstOrDefault(),
                                 },
                                 MWQMSiteReport = new MWQMSiteReport
                                 {
                                     MWQMSiteReportTest = "MWQMSiteReportTest",
                                 },
                                 HasErrors = false,
                                 ValidationResults = null,
                             });

            return mwqmSiteQuery;
        }
        #endregion Functions private
    }
}
