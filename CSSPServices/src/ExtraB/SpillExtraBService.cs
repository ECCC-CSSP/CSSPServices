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
        #region Functions private Generated FillSpillExtraB
        private IQueryable<SpillExtraB> FillSpillExtraB()
        {
             IQueryable<SpillExtraB> SpillExtraBQuery = (from c in db.Spills
                let SpillReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MunicipalityText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MunicipalityTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let InfrastructureText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.InfrastructureTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new SpillExtraB
                    {
                        SpillReportTest = SpillReportTest,
                        MunicipalityText = MunicipalityText,
                        InfrastructureText = InfrastructureText,
                        LastUpdateContactText = LastUpdateContactText,
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

            return SpillExtraBQuery;
        }
        #endregion Functions private Generated FillSpillExtraB

    }
}