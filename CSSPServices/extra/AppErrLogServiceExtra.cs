using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class AppErrLogService
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
        #endregion Functions public

        #region Functions private
        private IQueryable<AppErrLog> FillAppErrLogReport(IQueryable<AppErrLog> appErrLogQuery)
        {
            appErrLogQuery = (from c in appErrLogQuery
                              let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                             where cl.TVItemID == c.LastUpdateContactTVItemID
                                                             && cl.Language == LanguageRequest
                                                             select cl).FirstOrDefault()
                              select new AppErrLog
                              {
                                  AppErrLogID = c.AppErrLogID,
                                  Tag = c.Tag,
                                  LineNumber = c.LineNumber,
                                  Source = c.Source,
                                  Message = c.Message,
                                  DateTime_UTC = c.DateTime_UTC,
                                  LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                  LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                  AppErrLogWeb = new AppErrLogWeb
                                  {
                                      LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                  },
                                  AppErrLogReport = new AppErrLogReport
                                  {
                                      AppErrLogTest = "AppErrLogTest",
                                  },
                                  HasErrors = false,
                                  ValidationResults = null,
                              });

            return appErrLogQuery;
        }
        #endregion Functions private
    }
}
