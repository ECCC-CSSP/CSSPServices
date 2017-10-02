using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CSSPServices
{
    public partial class LogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        //public static string GetInformation(object obj)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties().Where(c => !c.PropertyType.ToString().StartsWith("EdoodiaDBD") || !c.PropertyType.ToString().StartsWith("CSSPWebToolsDB") || !c.PropertyType.ToString().StartsWith("System.Collections")))
        //    {
        //        sb.AppendLine(string.Format("{0}\t{1}",
        //            propertyInfo.Name, propertyInfo.GetValue(obj, null)));
        //    }

        //    return sb.ToString();
        //}
        #endregion Functions public

        #region Functions private
        private IQueryable<Log> FillLogReport(IQueryable<Log> logQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LogCommandEnumList = enums.GetEnumTextOrderedList(typeof(LogCommandEnum));

            logQuery = (from c in logQuery
                        let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                       where cl.TVItemID == c.LastUpdateContactTVItemID
                                                       && cl.Language == LanguageRequest
                                                       select cl.TVText).FirstOrDefault()
                        select new Log
                        {
                            LogID = c.LogID,
                            TableName = c.TableName,
                            ID = c.ID,
                            LogCommand = c.LogCommand,
                            Information = c.Information,
                            LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                            LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                            LogWeb = new LogWeb
                            {
                                LastUpdateContactTVText = LastUpdateContactTVText,
                                LogCommandText = (from e in LogCommandEnumList
                                                  where e.EnumID == (int?)c.LogCommand
                                                  select e.EnumText).FirstOrDefault(),
                            },
                            LogReport = new LogReport
                            {
                                LogReportTest = "LogReportTest",
                            },
                            HasErrors = false,
                            ValidationResults = null,
                        });

            return logQuery;
        }
        #endregion Functions private 
    }
}
