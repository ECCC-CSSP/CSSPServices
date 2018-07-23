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
    public partial class UseOfSiteService
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
        private IQueryable<UseOfSite> FillUseOfSiteReport(IQueryable<UseOfSite> useOfSiteQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SiteTypeEnumList = enums.GetEnumTextOrderedList(typeof(SiteTypeEnum));

            useOfSiteQuery = (from c in useOfSiteQuery
                              let SiteTVText = (from cl in db.TVItemLanguages
                                                where cl.TVItemID == c.SiteTVItemID
                                                && cl.Language == LanguageRequest
                                                select cl.TVText).FirstOrDefault()
                              let SubsectorTVText = (from cl in db.TVItemLanguages
                                                     where cl.TVItemID == c.SubsectorTVItemID
                                                     && cl.Language == LanguageRequest
                                                     select cl.TVText).FirstOrDefault()
                              let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                             where cl.TVItemID == c.LastUpdateContactTVItemID
                                                             && cl.Language == LanguageRequest
                                                             select cl.TVText).FirstOrDefault()
                              select new UseOfSite
                              {
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
                                  UseOfSiteWeb = new UseOfSiteWeb
                                  {
                                      SiteTVText = SiteTVText,
                                      SubsectorTVText = SubsectorTVText,
                                      LastUpdateContactTVText = LastUpdateContactTVText,
                                      SiteTypeText = (from e in SiteTypeEnumList
                                                      where e.EnumID == (int?)c.SiteType
                                                      select e.EnumText).FirstOrDefault(),
                                  },
                                  UseOfSiteReport = new UseOfSiteReport
                                  {
                                      UseOfSiteReportTest = "UseOfSiteReportTest",
                                  },
                                  HasErrors = false,
                                  ValidationResults = null,
                              });

            return useOfSiteQuery;
        }
        #endregion Functions private
    }
}
