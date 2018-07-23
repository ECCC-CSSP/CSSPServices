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
    /// <summary>
    ///     <para>bonjour AppTask</para>
    /// </summary>
    public partial class AppTaskService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AppTaskService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AppTask appTask = validationContext.ObjectInstance as AppTask;
            appTask.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appTask.AppTaskID == 0)
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskAppTaskID), new[] { "AppTaskID" });
                }

                if (!GetRead().Where(c => c.AppTaskID == appTask.AppTaskID).Any())
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AppTask, CSSPModelsRes.AppTaskAppTaskID, appTask.AppTaskID.ToString()), new[] { "AppTaskID" });
                }
            }

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppTaskTVItemID, appTask.TVItemID.ToString()), new[] { "TVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Country,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.Outfall,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.SeeOther,
                    TVTypeEnum.LineOverflow,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskTVItemID, "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow"), new[] { "TVItemID" });
                }
            }

            TVItem TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == appTask.TVItemID2 select c).FirstOrDefault();

            if (TVItemTVItemID2 == null)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppTaskTVItemID2, appTask.TVItemID2.ToString()), new[] { "TVItemID2" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Country,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.Outfall,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.SeeOther,
                    TVTypeEnum.LineOverflow,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID2.TVType))
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskTVItemID2, "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow"), new[] { "TVItemID2" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTask.AppTaskCommand);
            if (appTask.AppTaskCommand == AppTaskCommandEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskAppTaskCommand), new[] { "AppTaskCommand" });
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTask.AppTaskStatus);
            if (appTask.AppTaskStatus == AppTaskStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskAppTaskStatus), new[] { "AppTaskStatus" });
            }

            if (appTask.PercentCompleted < 0 || appTask.PercentCompleted > 100)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AppTaskPercentCompleted, "0", "100"), new[] { "PercentCompleted" });
            }

            if (string.IsNullOrWhiteSpace(appTask.Parameters))
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskParameters), new[] { "Parameters" });
            }

            //Parameters has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTask.Language);
            if (appTask.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLanguage), new[] { "Language" });
            }

            if (appTask.StartDateTime_UTC.Year == 1)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskStartDateTime_UTC), new[] { "StartDateTime_UTC" });
            }
            else
            {
                if (appTask.StartDateTime_UTC.Year < 1980)
                {
                appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppTaskStartDateTime_UTC, "1980"), new[] { "StartDateTime_UTC" });
                }
            }

            if (appTask.EndDateTime_UTC != null && ((DateTime)appTask.EndDateTime_UTC).Year < 1980)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppTaskEndDateTime_UTC, "1980"), new[] { CSSPModelsRes.AppTaskEndDateTime_UTC });
            }

            if (appTask.StartDateTime_UTC > appTask.EndDateTime_UTC)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, CSSPModelsRes.AppTaskEndDateTime_UTC, CSSPModelsRes.AppTaskStartDateTime_UTC), new[] { CSSPModelsRes.AppTaskEndDateTime_UTC });
            }

            if (appTask.EstimatedLength_second != null)
            {
                if (appTask.EstimatedLength_second < 0 || appTask.EstimatedLength_second > 1000000)
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AppTaskEstimatedLength_second, "0", "1000000"), new[] { "EstimatedLength_second" });
                }
            }

            if (appTask.RemainingTime_second != null)
            {
                if (appTask.RemainingTime_second < 0 || appTask.RemainingTime_second > 1000000)
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AppTaskRemainingTime_second, "0", "1000000"), new[] { "RemainingTime_second" });
                }
            }

            if (appTask.LastUpdateDate_UTC.Year == 1)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppTaskLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appTask.LastUpdateDate_UTC.Year < 1980)
                {
                appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppTaskLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTask.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppTaskLastUpdateContactTVItemID, appTask.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppTaskLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                appTask.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public AppTask GetAppTaskWithAppTaskID(int AppTaskID)
        {
            IQueryable<AppTask> appTaskQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.AppTaskID == AppTaskID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return appTaskQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillAppTaskWeb(appTaskQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillAppTaskReport(appTaskQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<AppTask> GetAppTaskList()
        {
            IQueryable<AppTask> appTaskQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        appTaskQuery = EnhanceQueryStatements<AppTask>(appTaskQuery) as IQueryable<AppTask>;

                        return appTaskQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        appTaskQuery = FillAppTaskWeb(appTaskQuery);

                        appTaskQuery = EnhanceQueryStatements<AppTask>(appTaskQuery) as IQueryable<AppTask>;

                        return appTaskQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        appTaskQuery = FillAppTaskReport(appTaskQuery);

                        appTaskQuery = EnhanceQueryStatements<AppTask>(appTaskQuery) as IQueryable<AppTask>;

                        return appTaskQuery;
                    }
                default:
                    {
                        appTaskQuery = appTaskQuery.Where(c => c.AppTaskID == 0);

                        return appTaskQuery;
                    }
            }
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
        public bool Delete(AppTask appTask)
        {
            appTask.ValidationResults = Validate(new ValidationContext(appTask), ActionDBTypeEnum.Delete);
            if (appTask.ValidationResults.Count() > 0) return false;

            db.AppTasks.Remove(appTask);

            if (!TryToSave(appTask)) return false;

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
        public IQueryable<AppTask> GetRead()
        {
            IQueryable<AppTask> appTaskQuery = db.AppTasks.AsNoTracking();

            return appTaskQuery;
        }
        public IQueryable<AppTask> GetEdit()
        {
            IQueryable<AppTask> appTaskQuery = db.AppTasks;

            return appTaskQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated AppTaskFillWeb
        private IQueryable<AppTask> FillAppTaskWeb(IQueryable<AppTask> appTaskQuery)
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
                        AppTaskReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return appTaskQuery;
        }
        #endregion Functions private Generated AppTaskFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
