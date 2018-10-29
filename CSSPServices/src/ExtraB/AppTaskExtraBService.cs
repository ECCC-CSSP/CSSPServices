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
    public partial class AppTaskService
    {
        #region Functions private Generated FillAppTaskExtraB
        private IQueryable<AppTaskExtraB> FillAppTaskExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AppTaskCommandEnumList = enums.GetEnumTextOrderedList(typeof(AppTaskCommandEnum));
            List<EnumIDAndText> AppTaskStatusEnumList = enums.GetEnumTextOrderedList(typeof(AppTaskStatusEnum));
            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));

             IQueryable<AppTaskExtraB> AppTaskExtraBQuery = (from c in db.AppTasks
                let AppTaskReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVItemText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVItem2Text = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID2
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let AppTaskCommandText = (from e in AppTaskCommandEnumList
                    where e.EnumID == (int?)c.AppTaskCommand
                    select e.EnumText).FirstOrDefault()
                let AppTaskStatusText = (from e in AppTaskStatusEnumList
                    where e.EnumID == (int?)c.AppTaskStatus
                    select e.EnumText).FirstOrDefault()
                let LanguageText = (from e in LanguageEnumList
                    where e.EnumID == (int?)c.Language
                    select e.EnumText).FirstOrDefault()
                    select new AppTaskExtraB
                    {
                        AppTaskReportTest = AppTaskReportTest,
                        TVItemText = TVItemText,
                        TVItem2Text = TVItem2Text,
                        LastUpdateContactText = LastUpdateContactText,
                        AppTaskCommandText = AppTaskCommandText,
                        AppTaskStatusText = AppTaskStatusText,
                        LanguageText = LanguageText,
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
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return AppTaskExtraBQuery;
        }
        #endregion Functions private Generated FillAppTaskExtraB

    }
}
