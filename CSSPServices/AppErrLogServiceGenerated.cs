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
    public partial class AppErrLogService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AppErrLogService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            AppErrLog appErrLog = validationContext.ObjectInstance as AppErrLog;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (appErrLog.AppErrLogID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogAppErrLogID), new[] { ModelsRes.AppErrLogAppErrLogID });
                }
            }

            if (string.IsNullOrWhiteSpace(appErrLog.Tag))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogTag), new[] { ModelsRes.AppErrLogTag });
            }

            //LineNumber (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(appErrLog.Source))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogSource), new[] { ModelsRes.AppErrLogSource });
            }

            if (string.IsNullOrWhiteSpace(appErrLog.Message))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogMessage), new[] { ModelsRes.AppErrLogMessage });
            }

            if (appErrLog.DateTime_UTC == null || appErrLog.DateTime_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogDateTime_UTC), new[] { ModelsRes.AppErrLogDateTime_UTC });
            }

            if (appErrLog.LastUpdateDate_UTC == null || appErrLog.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogLastUpdateDate_UTC), new[] { ModelsRes.AppErrLogLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(appErrLog.Tag) && appErrLog.Tag.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppErrLogTag, "100"), new[] { ModelsRes.AppErrLogTag });
            }

            if (appErrLog.LineNumber < 1 || appErrLog.LineNumber > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.AppErrLogLineNumber, "1", "100000"), new[] { ModelsRes.AppErrLogLineNumber });
            }

            // Source has no validation

            // Message has no validation

            if (appErrLog.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppErrLogLastUpdateContactTVItemID, "1"), new[] { ModelsRes.AppErrLogLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(AppErrLog appErrLog)
        {
            appErrLog.ValidationResults = Validate(new ValidationContext(appErrLog), ActionDBTypeEnum.Create);
            if (appErrLog.ValidationResults.Count() > 0) return false;

            db.AppErrLogs.Add(appErrLog);

            if (!TryToSave(appErrLog)) return false;

            return true;
        }
        public bool AddRange(List<AppErrLog> appErrLogList)
        {
            foreach (AppErrLog appErrLog in appErrLogList)
            {
                appErrLog.ValidationResults = Validate(new ValidationContext(appErrLog), ActionDBTypeEnum.Create);
                if (appErrLog.ValidationResults.Count() > 0) return false;
            }

            db.AppErrLogs.AddRange(appErrLogList);

            if (!TryToSaveRange(appErrLogList)) return false;

            return true;
        }
        public bool Delete(AppErrLog appErrLog)
        {
            if (!db.AppErrLogs.Where(c => c.AppErrLogID == appErrLog.AppErrLogID).Any())
            {
                appErrLog.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogID", appErrLog.AppErrLogID.ToString())) }.AsEnumerable();
                return false;
            }

            db.AppErrLogs.Remove(appErrLog);

            if (!TryToSave(appErrLog)) return false;

            return true;
        }
        public bool DeleteRange(List<AppErrLog> appErrLogList)
        {
            foreach (AppErrLog appErrLog in appErrLogList)
            {
                if (!db.AppErrLogs.Where(c => c.AppErrLogID == appErrLog.AppErrLogID).Any())
                {
                    appErrLogList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogID", appErrLog.AppErrLogID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.AppErrLogs.RemoveRange(appErrLogList);

            if (!TryToSaveRange(appErrLogList)) return false;

            return true;
        }
        public bool Update(AppErrLog appErrLog)
        {
            appErrLog.ValidationResults = Validate(new ValidationContext(appErrLog), ActionDBTypeEnum.Update);
            if (appErrLog.ValidationResults.Count() > 0) return false;

            db.AppErrLogs.Update(appErrLog);

            if (!TryToSave(appErrLog)) return false;

            return true;
        }
        public bool UpdateRange(List<AppErrLog> appErrLogList)
        {
            foreach (AppErrLog appErrLog in appErrLogList)
            {
                appErrLog.ValidationResults = Validate(new ValidationContext(appErrLog), ActionDBTypeEnum.Update);
                if (appErrLog.ValidationResults.Count() > 0) return false;
            }
            db.AppErrLogs.UpdateRange(appErrLogList);

            if (!TryToSaveRange(appErrLogList)) return false;

            return true;
        }
        public IQueryable<AppErrLog> GetRead()
        {
            return db.AppErrLogs.AsNoTracking();
        }
        public IQueryable<AppErrLog> GetEdit()
        {
            return db.AppErrLogs;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(AppErrLog appErrLog)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                appErrLog.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<AppErrLog> appErrLogList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                appErrLogList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
