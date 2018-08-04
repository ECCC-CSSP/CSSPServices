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
    public partial class LogService
    {
        #region Functions private Generated LogFillReport
        private IQueryable<LogReport> FillLogReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LogCommandEnumList = enums.GetEnumTextOrderedList(typeof(LogCommandEnum));

             IQueryable<LogReport>  LogReportQuery = (from c in db.Logs
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new LogReport
                    {
                        LogReportTest = "Testing Report",
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LogCommandText = (from e in LogCommandEnumList
                                where e.EnumID == (int?)c.LogCommand
                                select e.EnumText).FirstOrDefault(),
                        LogID = c.LogID,
                        TableName = c.TableName,
                        ID = c.ID,
                        LogCommand = c.LogCommand,
                        Information = c.Information,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return LogReportQuery;
        }
        #endregion Functions private Generated LogFillReport

    }
}
