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
    public partial class MWQMSubsectorService
    {
        #region Functions private Generated MWQMSubsectorFillReport
        private IQueryable<MWQMSubsectorReport> FillMWQMSubsectorReport()
        {
             IQueryable<MWQMSubsectorReport>  MWQMSubsectorReportQuery = (from c in db.MWQMSubsectors
                let SubsectorTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSubsectorReport
                    {
                        MWQMSubsectorReportTest = "Testing Report",
                        SubsectorTVItemLanguage = SubsectorTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MWQMSubsectorID = c.MWQMSubsectorID,
                        MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                        SubsectorHistoricKey = c.SubsectorHistoricKey,
                        TideLocationSIDText = c.TideLocationSIDText,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMSubsectorReportQuery;
        }
        #endregion Functions private Generated MWQMSubsectorFillReport

    }
}
