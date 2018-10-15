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
    public partial class HydrometricSiteService
    {
        #region Functions private Generated FillHydrometricSiteExtraA
        private IQueryable<HydrometricSiteExtraA> FillHydrometricSiteExtraA()
        {
             IQueryable<HydrometricSiteExtraA> HydrometricSiteExtraAQuery = (from c in db.HydrometricSites
                let HydrometricTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.HydrometricSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new HydrometricSiteExtraA
                    {
                        HydrometricTVItemLanguage = HydrometricTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
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
                        HasDischarge = c.HasDischarge,
                        HasLevel = c.HasLevel,
                        HasRatingCurve = c.HasRatingCurve,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return HydrometricSiteExtraAQuery;
        }
        #endregion Functions private Generated FillHydrometricSiteExtraA

    }
}
