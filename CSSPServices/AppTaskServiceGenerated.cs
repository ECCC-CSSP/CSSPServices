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
        public AppTaskService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (appTask.AppTaskID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskAppTaskID), new[] { ModelsRes.AppTaskAppTaskID });
                }
            }

            //AppTaskID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (appTask.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskTVItemID, "1"), new[] { ModelsRes.AppTaskTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == appTask.TVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskTVItemID, appTask.TVItemID.ToString()), new[] { ModelsRes.AppTaskTVItemID });
            }

            //TVItemID2 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (appTask.TVItemID2 < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskTVItemID2, "1"), new[] { ModelsRes.AppTaskTVItemID2 });
            }

            if (!((from c in db.TVItems where c.TVItemID == appTask.TVItemID2 select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskTVItemID2, appTask.TVItemID2.ToString()), new[] { ModelsRes.AppTaskTVItemID2 });
            }

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

            //PercentCompleted (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (appTask.PercentCompleted < 0 || appTask.PercentCompleted > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskPercentCompleted, "0", "100"), new[] { ModelsRes.AppTaskPercentCompleted });
            }

            if (string.IsNullOrWhiteSpace(appTask.Parameters))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskParameters), new[] { ModelsRes.AppTaskParameters });
            }

            // Parameters has no validation

            retStr = enums.LanguageOK(appTask.Language);
            if (appTask.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguage), new[] { ModelsRes.AppTaskLanguage });
            }

            if (appTask.StartDateTime_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskStartDateTime_UTC), new[] { ModelsRes.AppTaskStartDateTime_UTC });
            }

            if (appTask.StartDateTime_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AppTaskStartDateTime_UTC, "1980"), new[] { ModelsRes.AppTaskStartDateTime_UTC });
            }

            if (appTask.EndDateTime_UTC < appTask.StartDateTime_UTC)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.AppTaskStartDateTime_UTC, ModelsRes.AppTaskEndDateTime_UTC), new[] { ModelsRes.AppTaskStartDateTime_UTC });
            }

                //Error: Type not implemented [EndDateTime_UTC] of type [Nullable`1]

                //Error: Type not implemented [EstimatedLength_second] of type [Nullable`1]

            if (appTask.EstimatedLength_second < 0 || appTask.EstimatedLength_second > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskEstimatedLength_second, "0", "1000000"), new[] { ModelsRes.AppTaskEstimatedLength_second });
            }

                //Error: Type not implemented [RemainingTime_second] of type [Nullable`1]

            if (appTask.RemainingTime_second < 0 || appTask.RemainingTime_second > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskRemainingTime_second, "0", "1000000"), new[] { ModelsRes.AppTaskRemainingTime_second });
            }

            if (appTask.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLastUpdateDate_UTC), new[] { ModelsRes.AppTaskLastUpdateDate_UTC });
            }

            if (appTask.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AppTaskLastUpdateDate_UTC, "1980"), new[] { ModelsRes.AppTaskLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (appTask.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppTaskLastUpdateContactTVItemID, "1"), new[] { ModelsRes.AppTaskLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == appTask.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskLastUpdateContactTVItemID, appTask.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.AppTaskLastUpdateContactTVItemID });
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
