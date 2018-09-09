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
    public partial class AppErrLogService
    {
        #region Functions private Generated FillAppErrLog_C
        private IQueryable<AppErrLog_C> FillAppErrLog_C()
        {
             IQueryable<AppErrLog_C> AppErrLog_CQuery = (from c in db.AppErrLogs
                let AppErrLogReportTest2 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new AppErrLog_C
                    {
                        AppErrLogReportTest2 = AppErrLogReportTest2,
                        AppErrLogReportTest = AppErrLogReportTest,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        AppErrLogID = c.AppErrLogID,
                        Tag = c.Tag,
                        LineNumber = c.LineNumber,
                        Source = c.Source,
                        Message = c.Message,
                        DateTime_UTC = c.DateTime_UTC,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return AppErrLog_CQuery;
        }
        #endregion Functions private Generated FillAppErrLog_C

    }
}
