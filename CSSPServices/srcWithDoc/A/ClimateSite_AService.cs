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
    public partial class ClimateSiteService
    {
        #region Functions private Generated FillClimateSite_A
        private IQueryable<ClimateSite_A> FillClimateSite_A()
        {
             IQueryable<ClimateSite_A> ClimateSite_AQuery = (from c in db.ClimateSites
                let ClimateSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ClimateSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ClimateSite_A
                    {
                        ClimateSiteTVItemLanguage = ClimateSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        ClimateSiteID = c.ClimateSiteID,
                        ClimateSiteTVItemID = c.ClimateSiteTVItemID,
                        ECDBID = c.ECDBID,
                        ClimateSiteName = c.ClimateSiteName,
                        Province = c.Province,
                        Elevation_m = c.Elevation_m,
                        ClimateID = c.ClimateID,
                        WMOID = c.WMOID,
                        TCID = c.TCID,
                        IsProvincial = c.IsProvincial,
                        ProvSiteID = c.ProvSiteID,
                        TimeOffset_hour = c.TimeOffset_hour,
                        File_desc = c.File_desc,
                        HourlyStartDate_Local = c.HourlyStartDate_Local,
                        HourlyEndDate_Local = c.HourlyEndDate_Local,
                        HourlyNow = c.HourlyNow,
                        DailyStartDate_Local = c.DailyStartDate_Local,
                        DailyEndDate_Local = c.DailyEndDate_Local,
                        DailyNow = c.DailyNow,
                        MonthlyStartDate_Local = c.MonthlyStartDate_Local,
                        MonthlyEndDate_Local = c.MonthlyEndDate_Local,
                        MonthlyNow = c.MonthlyNow,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ClimateSite_AQuery;
        }
        #endregion Functions private Generated FillClimateSite_A

    }
}
