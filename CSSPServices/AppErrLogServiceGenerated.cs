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
    ///     <para>bonjour AppErrLog</para>
    /// </summary>
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
            appErrLog.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appErrLog.AppErrLogID == 0)
                {
                    appErrLog.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogAppErrLogID), new[] { "AppErrLogID" });
                }

                if (!GetRead().Where(c => c.AppErrLogID == appErrLog.AppErrLogID).Any())
                {
                    appErrLog.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AppErrLog, CSSPModelsRes.AppErrLogAppErrLogID, appErrLog.AppErrLogID.ToString()), new[] { "AppErrLogID" });
                }
            }

            //AppErrLogID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(appErrLog.Tag))
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogTag), new[] { "Tag" });
            }

            if (!string.IsNullOrWhiteSpace(appErrLog.Tag) && appErrLog.Tag.Length > 100)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppErrLogTag, "100"), new[] { "Tag" });
            }

            //LineNumber (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (appErrLog.LineNumber < 1)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.AppErrLogLineNumber, "1"), new[] { "LineNumber" });
            }

            if (string.IsNullOrWhiteSpace(appErrLog.Source))
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogSource), new[] { "Source" });
            }

            //Source has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(appErrLog.Message))
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogMessage), new[] { "Message" });
            }

            //Message has no StringLength Attribute

            if (appErrLog.DateTime_UTC.Year == 1)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogDateTime_UTC), new[] { "DateTime_UTC" });
            }
            else
            {
                if (appErrLog.DateTime_UTC.Year < 1980)
                {
                appErrLog.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppErrLogDateTime_UTC, "1980"), new[] { "DateTime_UTC" });
                }
            }

            if (appErrLog.LastUpdateDate_UTC.Year == 1)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AppErrLogLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appErrLog.LastUpdateDate_UTC.Year < 1980)
                {
                appErrLog.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AppErrLogLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appErrLog.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AppErrLogLastUpdateContactTVItemID, appErrLog.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    appErrLog.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AppErrLogLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(appErrLog.LastUpdateContactTVText) && appErrLog.LastUpdateContactTVText.Length > 200)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AppErrLogLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                appErrLog.HasErrors = true;
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
            appErrLog.ValidationResults = Validate(new ValidationContext(appErrLog), ActionDBTypeEnum.Delete);
            if (appErrLog.ValidationResults.Count() > 0) return false;

            db.AppErrLogs.Remove(appErrLog);

            if (!TryToSave(appErrLog)) return false;

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
