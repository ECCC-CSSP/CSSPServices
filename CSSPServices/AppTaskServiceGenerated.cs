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
    public partial class AppTaskService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AppTask appTask = validationContext.ObjectInstance as AppTask;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (appTask.AppTaskID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskAppTaskID), new[] { ModelsRes.AppTaskAppTaskID });
                }
            }

            //TVItemID (int) is required but no testing needed as it is automatically set to 0

            //TVItemID2 (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.AppTaskCommandOK(appTask.Command);
            if (appTask.Command == AppTaskCommandEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskCommand), new[] { ModelsRes.AppTaskCommand });
            }

            retStr = enums.AppTaskStatusOK(appTask.Status);
            if (appTask.Status == AppTaskStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskStatus), new[] { ModelsRes.AppTaskStatus });
            }

            //PercentCompleted (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(appTask.Parameters))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskParameters), new[] { ModelsRes.AppTaskParameters });
            }

            retStr = enums.LanguageOK(appTask.Language);
            if (appTask.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguage), new[] { ModelsRes.AppTaskLanguage });
            }

            if (appTask.StartDateTime_UTC == null || appTask.StartDateTime_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskStartDateTime_UTC), new[] { ModelsRes.AppTaskStartDateTime_UTC });
            }

            if (appTask.LastUpdateDate_UTC == null || appTask.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLastUpdateDate_UTC), new[] { ModelsRes.AppTaskLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (appTask.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskTVItemID, "1"), new[] { ModelsRes.AppTaskTVItemID });
            }

            if (appTask.TVItemID2 < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskTVItemID2, "1"), new[] { ModelsRes.AppTaskTVItemID2 });
            }

            if (appTask.PercentCompleted < 0 || appTask.PercentCompleted > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskPercentCompleted, "0", "100"), new[] { ModelsRes.AppTaskPercentCompleted });
            }

            // Parameters has no validation

            if (appTask.EstimatedLength_second < 0 || appTask.EstimatedLength_second > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskEstimatedLength_second, "0", "1000000"), new[] { ModelsRes.AppTaskEstimatedLength_second });
            }

            if (appTask.RemainingTime_second < 0 || appTask.RemainingTime_second > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskRemainingTime_second, "0", "1000000"), new[] { ModelsRes.AppTaskRemainingTime_second });
            }

            if (appTask.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLastUpdateContactTVItemID, "1"), new[] { ModelsRes.AppTaskLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(AppTask appTask)
        {
            appTask.ValidationResults = Validate(new ValidationContext(appTask), ActionDBTypeEnum.Create);
            if (appTask.ValidationResults.Count() > 0) return false;

            db.AppTasks.Add(appTask);

            if (!TryToSave(appTask)) return false;

            return true;
        }
        public bool AddRange(List<AppTask> appTaskList)
        {
            foreach (AppTask appTask in appTaskList)
            {
                appTask.ValidationResults = Validate(new ValidationContext(appTask), ActionDBTypeEnum.Create);
                if (appTask.ValidationResults.Count() > 0) return false;
            }

            db.AppTasks.AddRange(appTaskList);

            if (!TryToSaveRange(appTaskList)) return false;

            return true;
        }
        public bool Delete(AppTask appTask)
        {
            if (!db.AppTasks.Where(c => c.AppTaskID == appTask.AppTaskID).Any())
            {
                appTask.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTask.AppTaskID.ToString())) }.AsEnumerable();
                return false;
            }

            db.AppTasks.Remove(appTask);

            if (!TryToSave(appTask)) return false;

            return true;
        }
        public bool DeleteRange(List<AppTask> appTaskList)
        {
            foreach (AppTask appTask in appTaskList)
            {
                if (!db.AppTasks.Where(c => c.AppTaskID == appTask.AppTaskID).Any())
                {
                    appTaskList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTask.AppTaskID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.AppTasks.RemoveRange(appTaskList);

            if (!TryToSaveRange(appTaskList)) return false;

            return true;
        }
        public bool Update(AppTask appTask)
        {
            appTask.ValidationResults = Validate(new ValidationContext(appTask), ActionDBTypeEnum.Update);
            if (appTask.ValidationResults.Count() > 0) return false;

            db.AppTasks.Update(appTask);

            if (!TryToSave(appTask)) return false;

            return true;
        }
        public bool UpdateRange(List<AppTask> appTaskList)
        {
            foreach (AppTask appTask in appTaskList)
            {
                appTask.ValidationResults = Validate(new ValidationContext(appTask), ActionDBTypeEnum.Update);
                if (appTask.ValidationResults.Count() > 0) return false;
            }
            db.AppTasks.UpdateRange(appTaskList);

            if (!TryToSaveRange(appTaskList)) return false;

            return true;
        }
        public IQueryable<AppTask> GetRead()
        {
            return db.AppTasks.AsNoTracking();
        }
        public IQueryable<AppTask> GetEdit()
        {
            return db.AppTasks;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(AppTask appTask)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                appTask.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<AppTask> appTaskList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                appTaskList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
