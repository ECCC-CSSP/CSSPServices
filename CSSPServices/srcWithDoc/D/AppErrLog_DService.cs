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
        #region Functions private Generated FillAppErrLog_D
        private IQueryable<AppErrLog_D> FillAppErrLog_D()
        {
             IQueryable<AppErrLog_D> AppErrLog_DQuery = (from c in db.AppErrLogs
                let AppErrLogReportTest2K = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest2H = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest2D = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest2G = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest2S = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest2L = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest2C = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest2B = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest2A = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
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
                    select new AppErrLog_D
                    {
                        AppErrLogReportTest2K = AppErrLogReportTest2K,
                        AppErrLogReportTest2H = AppErrLogReportTest2H,
                        AppErrLogReportTest2D = AppErrLogReportTest2D,
                        AppErrLogReportTest2G = AppErrLogReportTest2G,
                        AppErrLogReportTest2S = AppErrLogReportTest2S,
                        AppErrLogReportTest2L = AppErrLogReportTest2L,
                        AppErrLogReportTest2C = AppErrLogReportTest2C,
                        AppErrLogReportTest2B = AppErrLogReportTest2B,
                        AppErrLogReportTest2A = AppErrLogReportTest2A,
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

            return AppErrLog_DQuery;
        }
        #endregion Functions private Generated FillAppErrLog_D

    }
}
