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
    public partial class MikeSourceService
    {
        #region Functions private Generated MikeSourceFillReport
        private IQueryable<MikeSourceReport> FillMikeSourceReport()
        {
             IQueryable<MikeSourceReport>  MikeSourceReportQuery = (from c in db.MikeSources
                let MikeSourceTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MikeSourceTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MikeSourceReport
                    {
                        MikeSourceReportTest = "Testing Report",
                        MikeSourceTVItemLanguage = MikeSourceTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MikeSourceID = c.MikeSourceID,
                        MikeSourceTVItemID = c.MikeSourceTVItemID,
                        IsContinuous = c.IsContinuous,
                        Include = c.Include,
                        IsRiver = c.IsRiver,
                        SourceNumberString = c.SourceNumberString,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MikeSourceReportQuery;
        }
        #endregion Functions private Generated MikeSourceFillReport

    }
}
