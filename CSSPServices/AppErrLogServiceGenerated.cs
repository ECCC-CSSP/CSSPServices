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
        #endregion Properties

        #region Constructors
        public AppErrLogService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AppErrLog appErrLog = validationContext.ObjectInstance as AppErrLog;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (appErrLog.AppErrLogID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogAppErrLogID), new[] { "AppErrLogID" });
                }
            }

            //AppErrLogID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(appErrLog.Tag))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogTag), new[] { "Tag" });
            }

            if (!string.IsNullOrWhiteSpace(appErrLog.Tag) && appErrLog.Tag.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppErrLogTag, "100"), new[] { "Tag" });
            }

            //LineNumber (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (appErrLog.LineNumber < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AppErrLogLineNumber, "1"), new[] { "LineNumber" });
            }

            if (string.IsNullOrWhiteSpace(appErrLog.Source))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogSource), new[] { "Source" });
            }

            //Source has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(appErrLog.Message))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogMessage), new[] { "Message" });
            }

            //Message has no StringLength Attribute

            if (appErrLog.DateTime_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogDateTime_UTC), new[] { "DateTime_UTC" });
            }
            else
            {
                if (appErrLog.DateTime_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AppErrLogDateTime_UTC, "1980"), new[] { "DateTime_UTC" });
                }
            }

            if (appErrLog.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AppErrLogLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appErrLog.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AppErrLogLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appErrLog.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AppErrLogLastUpdateContactTVItemID, appErrLog.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppErrLogLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
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
