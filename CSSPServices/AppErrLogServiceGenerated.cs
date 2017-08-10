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
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AppErrLogLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(appErrLog.LastUpdateContactTVText) && appErrLog.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AppErrLogLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public AppErrLog GetAppErrLogWithAppErrLogID(int AppErrLogID)
        {
            IQueryable<AppErrLog> appErrLogQuery = (from c in GetRead()
                                                where c.AppErrLogID == AppErrLogID
                                                select c);

            return FillAppErrLog(appErrLogQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(AppErrLog appErrLog)
        {
            appErrLog.ValidationResults = Validate(new ValidationContext(appErrLog), ActionDBTypeEnum.Create);
            if (appErrLog.ValidationResults.Count() > 0) return false;

            db.AppErrLogs.Add(appErrLog);

            if (!TryToSave(appErrLog)) return false;

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
        public bool Update(AppErrLog appErrLog)
        {
            if (!db.AppErrLogs.Where(c => c.AppErrLogID == appErrLog.AppErrLogID).Any())
            {
                appErrLog.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogID", appErrLog.AppErrLogID.ToString())) }.AsEnumerable();
                return false;
            }

            appErrLog.ValidationResults = Validate(new ValidationContext(appErrLog), ActionDBTypeEnum.Update);
            if (appErrLog.ValidationResults.Count() > 0) return false;

            db.AppErrLogs.Update(appErrLog);

            if (!TryToSave(appErrLog)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<AppErrLog> FillAppErrLog(IQueryable<AppErrLog> appErrLogQuery)
        {
            List<AppErrLog> AppErrLogList = (from c in appErrLogQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
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
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return AppErrLogList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
