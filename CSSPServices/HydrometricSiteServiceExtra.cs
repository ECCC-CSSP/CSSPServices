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
    public partial class HydrometricSiteService
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
        private IQueryable<HydrometricSite> FillHydrometricSiteReport(IQueryable<HydrometricSite> hydrometricSiteQuery)
        {
            hydrometricSiteQuery = (from c in hydrometricSiteQuery
                                    let HydrometricTVText = (from cl in db.TVItemLanguages
                                                             where cl.TVItemID == c.HydrometricSiteTVItemID
                                                             && cl.Language == LanguageRequest
                                                             select cl.TVText).FirstOrDefault()
                                    let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                   where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                   && cl.Language == LanguageRequest
                                                                   select cl.TVText).FirstOrDefault()
                                    select new HydrometricSite
                                    {
                                        HydrometricSiteID = c.HydrometricSiteID,
                                        HydrometricSiteTVItemID = c.HydrometricSiteTVItemID,
                                        FedSiteNumber = c.FedSiteNumber,
                                        QuebecSiteNumber = c.QuebecSiteNumber,
                                        HydrometricSiteName = c.HydrometricSiteName,
                                        Description = c.Description,
                                        Province = c.Province,
                                        Elevation_m = c.Elevation_m,
                                        StartDate_Local = c.StartDate_Local,
                                        EndDate_Local = c.EndDate_Local,
                                        TimeOffset_hour = c.TimeOffset_hour,
                                        DrainageArea_km2 = c.DrainageArea_km2,
                                        IsNatural = c.IsNatural,
                                        IsActive = c.IsActive,
                                        Sediment = c.Sediment,
                                        RHBN = c.RHBN,
                                        RealTime = c.RealTime,
                                        HasRatingCurve = c.HasRatingCurve,
                                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                        HydrometricSiteWeb = new HydrometricSiteWeb
                                        {
                                            HydrometricTVText = HydrometricTVText,
                                            LastUpdateContactTVText = LastUpdateContactTVText,
                                        },
                                        HydrometricSiteReport = new HydrometricSiteReport
                                        {
                                            HydrometricSiteReportTest = "HydrometricSiteReportTest",
                                        },
                                        HasErrors = false,
                                        ValidationResults = null,
                                    });

            return hydrometricSiteQuery;
        }
        #endregion Functions private
    }
}
