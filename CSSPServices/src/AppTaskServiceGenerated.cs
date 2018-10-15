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
        public AppTaskService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskAppTaskID"), new[] { "AppTaskID" });
                }

                if (!(from c in db.AppTasks select c).Where(c => c.AppTaskID == appTask.AppTaskID).Any())
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskAppTaskID", appTask.AppTaskID.ToString()), new[] { "AppTaskID" });
                }
            }

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == appTask.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppTaskTVItemID", appTask.TVItemID.ToString()), new[] { "TVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AppTaskTVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow"), new[] { "TVItemID" });
                }
            }

            TVItem TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == appTask.TVItemID2 select c).FirstOrDefault();

            if (TVItemTVItemID2 == null)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppTaskTVItemID2", appTask.TVItemID2.ToString()), new[] { "TVItemID2" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AppTaskTVItemID2", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow"), new[] { "TVItemID2" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskCommandEnum), (int?)appTask.AppTaskCommand);
            if (appTask.AppTaskCommand == null || !string.IsNullOrWhiteSpace(retStr))
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskAppTaskCommand"), new[] { "AppTaskCommand" });
            }

            retStr = enums.EnumTypeOK(typeof(AppTaskStatusEnum), (int?)appTask.AppTaskStatus);
            if (appTask.AppTaskStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskAppTaskStatus"), new[] { "AppTaskStatus" });
            }

            if (appTask.PercentCompleted < 0 || appTask.PercentCompleted > 100)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AppTaskPercentCompleted", "0", "100"), new[] { "PercentCompleted" });
            }

            if (string.IsNullOrWhiteSpace(appTask.Parameters))
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskParameters"), new[] { "Parameters" });
            }

            //Parameters has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTask.Language);
            if (appTask.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguage"), new[] { "Language" });
            }

            if (appTask.StartDateTime_UTC.Year == 1)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskStartDateTime_UTC"), new[] { "StartDateTime_UTC" });
            }
            else
            {
                if (appTask.StartDateTime_UTC.Year < 1980)
                {
                appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppTaskStartDateTime_UTC", "1980"), new[] { "StartDateTime_UTC" });
                }
            }

            if (appTask.EndDateTime_UTC != null && ((DateTime)appTask.EndDateTime_UTC).Year < 1980)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppTaskEndDateTime_UTC", "1980"), new[] { "AppTaskEndDateTime_UTC" });
            }

            if (appTask.StartDateTime_UTC > appTask.EndDateTime_UTC)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "AppTaskEndDateTime_UTC", "AppTaskStartDateTime_UTC"), new[] { "AppTaskEndDateTime_UTC" });
            }

            if (appTask.EstimatedLength_second != null)
            {
                if (appTask.EstimatedLength_second < 0 || appTask.EstimatedLength_second > 1000000)
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AppTaskEstimatedLength_second", "0", "1000000"), new[] { "EstimatedLength_second" });
                }
            }

            if (appTask.RemainingTime_second != null)
            {
                if (appTask.RemainingTime_second < 0 || appTask.RemainingTime_second > 1000000)
                {
                    appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AppTaskRemainingTime_second", "0", "1000000"), new[] { "RemainingTime_second" });
                }
            }

            if (appTask.LastUpdateDate_UTC.Year == 1)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appTask.LastUpdateDate_UTC.Year < 1980)
                {
                appTask.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppTaskLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTask.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                appTask.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppTaskLastUpdateContactTVItemID", appTask.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AppTaskLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            return (from c in db.AppTasks
                    where c.AppTaskID == AppTaskID
                    select c).FirstOrDefault();

        }
        public IQueryable<AppTask> GetAppTaskList()
        {
            IQueryable<AppTask> AppTaskQuery = (from c in db.AppTasks select c);

            AppTaskQuery = EnhanceQueryStatements<AppTask>(AppTaskQuery) as IQueryable<AppTask>;

            return AppTaskQuery;
        }
        public AppTaskExtraA GetAppTaskExtraAWithAppTaskID(int AppTaskID)
        {
            return FillAppTaskExtraA().Where(c => c.AppTaskID == AppTaskID).FirstOrDefault();

        }
        public IQueryable<AppTaskExtraA> GetAppTaskExtraAList()
        {
            IQueryable<AppTaskExtraA> AppTaskExtraAQuery = FillAppTaskExtraA();

            AppTaskExtraAQuery = EnhanceQueryStatements<AppTaskExtraA>(AppTaskExtraAQuery) as IQueryable<AppTaskExtraA>;

            return AppTaskExtraAQuery;
        }
        public AppTaskExtraB GetAppTaskExtraBWithAppTaskID(int AppTaskID)
        {
            return FillAppTaskExtraB().Where(c => c.AppTaskID == AppTaskID).FirstOrDefault();

        }
        public IQueryable<AppTaskExtraB> GetAppTaskExtraBList()
        {
            IQueryable<AppTaskExtraB> AppTaskExtraBQuery = FillAppTaskExtraB();

            AppTaskExtraBQuery = EnhanceQueryStatements<AppTaskExtraB>(AppTaskExtraBQuery) as IQueryable<AppTaskExtraB>;

            return AppTaskExtraBQuery;
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
        #endregion Functions public Generated CRUD

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
