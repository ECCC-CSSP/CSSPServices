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
        #endregion Properties

        #region Constructors
        public AppTaskService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskAppTaskID), new[] { "AppTaskID" });
                }
            }

            //AppTaskID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskTVItemID, appTask.TVItemID.ToString()), new[] { "TVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Country,
                    TVTypeEnum.Province,
                    TVTypeEnum.Area,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.MWQMSiteSample,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.SamplingPlan,
                    TVTypeEnum.Spill,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.VisualPlumesScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppTaskTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite,VisualPlumesScenario"), new[] { "TVItemID" });
                }
            }

            //TVItemID2 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == appTask.TVItemID2 select c).FirstOrDefault();

            if (TVItemTVItemID2 == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskTVItemID2, appTask.TVItemID2.ToString()), new[] { "TVItemID2" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Country,
                    TVTypeEnum.Province,
                    TVTypeEnum.Area,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.MWQMSiteSample,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.SamplingPlan,
                    TVTypeEnum.Spill,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.VisualPlumesScenario,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID2.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppTaskTVItemID2, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite,VisualPlumesScenario"), new[] { "TVItemID2" });
                }
            }

            retStr = enums.AppTaskCommandOK(appTask.AppTaskCommand);
            if (appTask.AppTaskCommand == AppTaskCommandEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskAppTaskCommand), new[] { "AppTaskCommand" });
            }

            retStr = enums.AppTaskStatusOK(appTask.AppTaskStatus);
            if (appTask.AppTaskStatus == AppTaskStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskAppTaskStatus), new[] { "AppTaskStatus" });
            }

            //PercentCompleted (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (appTask.PercentCompleted < 0 || appTask.PercentCompleted > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskPercentCompleted, "0", "100"), new[] { "PercentCompleted" });
            }

            if (string.IsNullOrWhiteSpace(appTask.Parameters))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskParameters), new[] { "Parameters" });
            }

            //Parameters has no StringLength Attribute

            retStr = enums.LanguageOK(appTask.Language);
            if (appTask.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLanguage), new[] { "Language" });
            }

            if (appTask.StartDateTime_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskStartDateTime_UTC), new[] { "StartDateTime_UTC" });
            }
            else
            {
                if (appTask.StartDateTime_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AppTaskStartDateTime_UTC, "1980"), new[] { "StartDateTime_UTC" });
                }
            }

            if (appTask.EndDateTime_UTC != null && ((DateTime)appTask.EndDateTime_UTC).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AppTaskEndDateTime_UTC, "1980"), new[] { ModelsRes.AppTaskEndDateTime_UTC });
            }

            if (appTask.StartDateTime_UTC > appTask.EndDateTime_UTC)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.AppTaskEndDateTime_UTC, ModelsRes.AppTaskStartDateTime_UTC), new[] { ModelsRes.AppTaskEndDateTime_UTC });
            }

            if (appTask.EstimatedLength_second != null)
            {
                if (appTask.EstimatedLength_second < 0 || appTask.EstimatedLength_second > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskEstimatedLength_second, "0", "1000000"), new[] { "EstimatedLength_second" });
                }
            }

            if (appTask.RemainingTime_second != null)
            {
                if (appTask.RemainingTime_second < 0 || appTask.RemainingTime_second > 1000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppTaskRemainingTime_second, "0", "1000000"), new[] { "RemainingTime_second" });
                }
            }

            if (appTask.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppTaskLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appTask.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AppTaskLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTask.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppTaskLastUpdateContactTVItemID, appTask.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppTaskLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(appTask.AppTaskCommandText) && appTask.AppTaskCommandText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskAppTaskCommandText, "100"), new[] { "AppTaskCommandText" });
            }

            if (!string.IsNullOrWhiteSpace(appTask.AppTaskStatusText) && appTask.AppTaskStatusText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskAppTaskStatusText, "100"), new[] { "AppTaskStatusText" });
            }

            if (!string.IsNullOrWhiteSpace(appTask.LanguageText) && appTask.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppTaskLanguageText, "100"), new[] { "LanguageText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public AppTask GetAppTaskWithAppTaskID(int AppTaskID)
        {
            IQueryable<AppTask> appTaskQuery = (from c in GetRead()
                                                where c.AppTaskID == AppTaskID
                                                select c);

            return FillAppTask(appTaskQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<AppTask> FillAppTask(IQueryable<AppTask> appTaskQuery)
        {
            List<AppTask> AppTaskList = (from c in appTaskQuery
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
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (AppTask appTask in AppTaskList)
            {
                appTask.AppTaskCommandText = enums.GetEnumText_AppTaskCommandEnum(appTask.AppTaskCommand);
                appTask.AppTaskStatusText = enums.GetEnumText_AppTaskStatusEnum(appTask.AppTaskStatus);
                appTask.LanguageText = enums.GetEnumText_LanguageEnum(appTask.Language);
            }

            return AppTaskList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
