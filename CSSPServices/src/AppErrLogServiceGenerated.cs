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
        public AppErrLogService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppErrLogAppErrLogID"), new[] { "AppErrLogID" });
                }

                if (!GetRead().Where(c => c.AppErrLogID == appErrLog.AppErrLogID).Any())
                {
                    appErrLog.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppErrLog", "AppErrLogAppErrLogID", appErrLog.AppErrLogID.ToString()), new[] { "AppErrLogID" });
                }
            }

            if (string.IsNullOrWhiteSpace(appErrLog.Tag))
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppErrLogTag"), new[] { "Tag" });
            }

            if (!string.IsNullOrWhiteSpace(appErrLog.Tag) && appErrLog.Tag.Length > 100)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "AppErrLogTag", "100"), new[] { "Tag" });
            }

            if (appErrLog.LineNumber < 1)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "AppErrLogLineNumber", "1"), new[] { "LineNumber" });
            }

            if (string.IsNullOrWhiteSpace(appErrLog.Source))
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppErrLogSource"), new[] { "Source" });
            }

            //Source has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(appErrLog.Message))
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppErrLogMessage"), new[] { "Message" });
            }

            //Message has no StringLength Attribute

            if (appErrLog.DateTime_UTC.Year == 1)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppErrLogDateTime_UTC"), new[] { "DateTime_UTC" });
            }
            else
            {
                if (appErrLog.DateTime_UTC.Year < 1980)
                {
                appErrLog.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppErrLogDateTime_UTC", "1980"), new[] { "DateTime_UTC" });
                }
            }

            if (appErrLog.LastUpdateDate_UTC.Year == 1)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppErrLogLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appErrLog.LastUpdateDate_UTC.Year < 1980)
                {
                appErrLog.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppErrLogLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appErrLog.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                appErrLog.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppErrLogLastUpdateContactTVItemID", appErrLog.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AppErrLogLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.AppErrLogID == AppErrLogID
                    select c).FirstOrDefault();

        }
        public IQueryable<AppErrLog> GetAppErrLogList()
        {
            IQueryable<AppErrLog> AppErrLogQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            AppErrLogQuery = EnhanceQueryStatements<AppErrLog>(AppErrLogQuery) as IQueryable<AppErrLog>;

            return AppErrLogQuery;
        }
        public AppErrLogWeb GetAppErrLogWebWithAppErrLogID(int AppErrLogID)
        {
            return FillAppErrLogWeb().FirstOrDefault();

        }
        public IQueryable<AppErrLogWeb> GetAppErrLogWebList()
        {
            IQueryable<AppErrLogWeb> AppErrLogWebQuery = FillAppErrLogWeb();

            AppErrLogWebQuery = EnhanceQueryStatements<AppErrLogWeb>(AppErrLogWebQuery) as IQueryable<AppErrLogWeb>;

            return AppErrLogWebQuery;
        }
        public AppErrLogReport GetAppErrLogReportWithAppErrLogID(int AppErrLogID)
        {
            return FillAppErrLogReport().FirstOrDefault();

        }
        public IQueryable<AppErrLogReport> GetAppErrLogReportList()
        {
            IQueryable<AppErrLogReport> AppErrLogReportQuery = FillAppErrLogReport();

            AppErrLogReportQuery = EnhanceQueryStatements<AppErrLogReport>(AppErrLogReportQuery) as IQueryable<AppErrLogReport>;

            return AppErrLogReportQuery;
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
            IQueryable<AppErrLog> appErrLogQuery = db.AppErrLogs.AsNoTracking();

            return appErrLogQuery;
        }
        public IQueryable<AppErrLog> GetEdit()
        {
            IQueryable<AppErrLog> appErrLogQuery = db.AppErrLogs;

            return appErrLogQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated AppErrLogFillWeb
        private IQueryable<AppErrLogWeb> FillAppErrLogWeb()
        {
             IQueryable<AppErrLogWeb>  AppErrLogWebQuery = (from c in db.AppErrLogs
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new AppErrLogWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        AppErrLogID = c.AppErrLogID,
                        Tag = c.Tag,
                        LineNumber = c.LineNumber,
                        Source = c.Source,
                        Message = c.Message,
                        DateTime_UTC = c.DateTime_UTC,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return AppErrLogWebQuery;
        }
        #endregion Functions private Generated AppErrLogFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}