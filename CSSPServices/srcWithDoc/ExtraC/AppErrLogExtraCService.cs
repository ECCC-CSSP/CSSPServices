/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
        #region Functions private Generated FillAppErrLogExtraC
        /// <summary>
        /// Fills items [AppErrLogExtraC](CSSPModels.AppErrLogExtraC.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of AppErrLogExtraC</returns>
        private IQueryable<AppErrLogExtraC> FillAppErrLogExtraC()
        {
             IQueryable<AppErrLogExtraC> AppErrLogExtraCQuery = (from c in db.AppErrLogs
                let AppErrLogReportTest2 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppErrLogReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new AppErrLogExtraC
                    {
                        AppErrLogReportTest2 = AppErrLogReportTest2,
                        AppErrLogReportTest = AppErrLogReportTest,
                        LastUpdateContactText = LastUpdateContactText,
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

            return AppErrLogExtraCQuery;
        }
        #endregion Functions private Generated FillAppErrLogExtraC

    }
}
