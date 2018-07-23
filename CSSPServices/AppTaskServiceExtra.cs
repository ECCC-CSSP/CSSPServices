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
    public partial class AppTaskService
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
        private IQueryable<AppTask> FillAppTaskReport(IQueryable<AppTask> appTaskQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AppTaskCommandEnumList = enums.GetEnumTextOrderedList(typeof(AppTaskCommandEnum));
            List<EnumIDAndText> AppTaskStatusEnumList = enums.GetEnumTextOrderedList(typeof(AppTaskStatusEnum));
            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));

            appTaskQuery = (from c in appTaskQuery
                            let TVItemTVText = (from cl in db.TVItemLanguages
                                                where cl.TVItemID == c.TVItemID
                                                && cl.Language == LanguageRequest
                                                select cl.TVText).FirstOrDefault()
                            let TVItem2TVText = (from cl in db.TVItemLanguages
                                                 where cl.TVItemID == c.TVItemID2
                                                 && cl.Language == LanguageRequest
                                                 select cl.TVText).FirstOrDefault()
                            let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                           where cl.TVItemID == c.LastUpdateContactTVItemID
                                                           && cl.Language == LanguageRequest
                                                           select cl.TVText).FirstOrDefault()
                            select new AppTask
                            {
                                AppTaskID = c.AppTaskID,
                                TVItemID = c.TVItemID,
                                TVItemID2 = c.TVItemID2,
                                AppTaskCommand = c.AppTaskCommand,
                                AppTaskStatus = c.AppTaskStatus,
                                PercentCompleted = c.PercentCompleted,
                                Parameters = c.Parameters,
                                Language = c.Language,
                                StartDateTime_UTC = c.StartDateTime_UTC,
                                EndDateTime_UTC = c.EndDateTime_UTC,
                                EstimatedLength_second = c.EstimatedLength_second,
                                RemainingTime_second = c.RemainingTime_second,
                                LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                AppTaskWeb = new AppTaskWeb
                                {
                                    TVItemTVText = TVItemTVText,
                                    TVItem2TVText = TVItem2TVText,
                                    LastUpdateContactTVText = LastUpdateContactTVText,
                                    AppTaskCommandText = (from e in AppTaskCommandEnumList
                                                          where e.EnumID == (int?)c.AppTaskCommand
                                                          select e.EnumText).FirstOrDefault(),
                                    AppTaskStatusText = (from e in AppTaskStatusEnumList
                                                         where e.EnumID == (int?)c.AppTaskStatus
                                                         select e.EnumText).FirstOrDefault(),
                                    LanguageText = (from e in LanguageEnumList
                                                    where e.EnumID == (int?)c.Language
                                                    select e.EnumText).FirstOrDefault(),
                                },
                                AppTaskReport = new AppTaskReport
                                {
                                    AppTaskReportTest = "AppTaskReportTest",
                                },
                                HasErrors = false,
                                ValidationResults = null,
                            });

            return appTaskQuery;
        }
        #endregion Functions private
    }
}
