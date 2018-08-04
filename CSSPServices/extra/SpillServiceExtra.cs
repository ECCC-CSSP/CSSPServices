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
    public partial class SpillService
    {
        #region Functions private Generated SpillFillReport
        private IQueryable<SpillReport> FillSpillReport()
        {
             IQueryable<SpillReport>  SpillReportQuery = (from c in db.Spills
                let MunicipalityTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MunicipalityTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let InfrastructureTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.InfrastructureTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new SpillReport
                    {
                        SpillReportTest = "Testing Report",
                        MunicipalityTVItemLanguage = MunicipalityTVItemLanguage,
                        InfrastructureTVItemLanguage = InfrastructureTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        SpillID = c.SpillID,
                        MunicipalityTVItemID = c.MunicipalityTVItemID,
                        InfrastructureTVItemID = c.InfrastructureTVItemID,
                        StartDateTime_Local = c.StartDateTime_Local,
                        EndDateTime_Local = c.EndDateTime_Local,
                        AverageFlow_m3_day = c.AverageFlow_m3_day,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return SpillReportQuery;
        }
        #endregion Functions private Generated SpillFillReport

    }
}
