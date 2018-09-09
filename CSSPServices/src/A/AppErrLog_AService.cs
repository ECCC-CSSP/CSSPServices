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
        #region Functions private Generated FillAppErrLog_A
        private IQueryable<AppErrLog_A> FillAppErrLog_A()
        {
             IQueryable<AppErrLog_A> AppErrLog_AQuery = (from c in db.AppErrLogs
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new AppErrLog_A
                    {
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

            return AppErrLog_AQuery;
        }
        #endregion Functions private Generated FillAppErrLog_A

    }
}
