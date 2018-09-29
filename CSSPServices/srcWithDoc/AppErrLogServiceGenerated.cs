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
        public AppErrLogService(Query query, CSSPDBContext db, int ContactID)
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

                if (!(from c in db.AppErrLogs select c).Where(c => c.AppErrLogID == appErrLog.AppErrLogID).Any())
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
            return (from c in db.AppErrLogs
                    where c.AppErrLogID == AppErrLogID
                    select c).FirstOrDefault();

        }
        public IQueryable<AppErrLog> GetAppErrLogList()
        {
            IQueryable<AppErrLog> AppErrLogQuery = (from c in db.AppErrLogs select c);

            AppErrLogQuery = EnhanceQueryStatements<AppErrLog>(AppErrLogQuery) as IQueryable<AppErrLog>;

            return AppErrLogQuery;
        }
        public AppErrLog_A GetAppErrLog_AWithAppErrLogID(int AppErrLogID)
        {
            return FillAppErrLog_A().Where(c => c.AppErrLogID == AppErrLogID).FirstOrDefault();

        }
        public IQueryable<AppErrLog_A> GetAppErrLog_AList()
        {
            IQueryable<AppErrLog_A> AppErrLog_AQuery = FillAppErrLog_A();

            AppErrLog_AQuery = EnhanceQueryStatements<AppErrLog_A>(AppErrLog_AQuery) as IQueryable<AppErrLog_A>;

            return AppErrLog_AQuery;
        }
        public AppErrLog_B GetAppErrLog_BWithAppErrLogID(int AppErrLogID)
        {
            return FillAppErrLog_B().Where(c => c.AppErrLogID == AppErrLogID).FirstOrDefault();

        }
        public IQueryable<AppErrLog_B> GetAppErrLog_BList()
        {
            IQueryable<AppErrLog_B> AppErrLog_BQuery = FillAppErrLog_B();

            AppErrLog_BQuery = EnhanceQueryStatements<AppErrLog_B>(AppErrLog_BQuery) as IQueryable<AppErrLog_B>;

            return AppErrLog_BQuery;
        }
        public AppErrLog_C GetAppErrLog_CWithAppErrLogID(int AppErrLogID)
        {
            return FillAppErrLog_C().Where(c => c.AppErrLogID == AppErrLogID).FirstOrDefault();

        }
        public IQueryable<AppErrLog_C> GetAppErrLog_CList()
        {
            IQueryable<AppErrLog_C> AppErrLog_CQuery = FillAppErrLog_C();

            AppErrLog_CQuery = EnhanceQueryStatements<AppErrLog_C>(AppErrLog_CQuery) as IQueryable<AppErrLog_C>;

            return AppErrLog_CQuery;
        }
        public AppErrLog_D GetAppErrLog_DWithAppErrLogID(int AppErrLogID)
        {
            return FillAppErrLog_D().Where(c => c.AppErrLogID == AppErrLogID).FirstOrDefault();

        }
        public IQueryable<AppErrLog_D> GetAppErrLog_DList()
        {
            IQueryable<AppErrLog_D> AppErrLog_DQuery = FillAppErrLog_D();

            AppErrLog_DQuery = EnhanceQueryStatements<AppErrLog_D>(AppErrLog_DQuery) as IQueryable<AppErrLog_D>;

            return AppErrLog_DQuery;
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
        #endregion Functions public Generated CRUD

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
