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
    ///     <para>bonjour Log</para>
    /// </summary>
    public partial class LogService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LogService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Log log = validationContext.ObjectInstance as Log;
            log.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (log.LogID == 0)
                {
                    log.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LogLogID"), new[] { "LogID" });
                }

                if (!(from c in db.Logs select c).Where(c => c.LogID == log.LogID).Any())
                {
                    log.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Log", "LogLogID", log.LogID.ToString()), new[] { "LogID" });
                }
            }

            if (string.IsNullOrWhiteSpace(log.TableName))
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LogTableName"), new[] { "TableName" });
            }

            if (!string.IsNullOrWhiteSpace(log.TableName) && log.TableName.Length > 50)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LogTableName", "50"), new[] { "TableName" });
            }

            if (log.ID < 1)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "LogID", "1"), new[] { "ID" });
            }

            retStr = enums.EnumTypeOK(typeof(LogCommandEnum), (int?)log.LogCommand);
            if (log.LogCommand == null || !string.IsNullOrWhiteSpace(retStr))
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LogLogCommand"), new[] { "LogCommand" });
            }

            if (string.IsNullOrWhiteSpace(log.Information))
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LogInformation"), new[] { "Information" });
            }

            //Information has no StringLength Attribute

            if (log.LastUpdateDate_UTC.Year == 1)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LogLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (log.LastUpdateDate_UTC.Year < 1980)
                {
                log.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LogLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == log.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LogLastUpdateContactTVItemID", log.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    log.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LogLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                log.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Log GetLogWithLogID(int LogID)
        {
            return (from c in db.Logs
                    where c.LogID == LogID
                    select c).FirstOrDefault();

        }
        public IQueryable<Log> GetLogList()
        {
            IQueryable<Log> LogQuery = (from c in db.Logs select c);

            LogQuery = EnhanceQueryStatements<Log>(LogQuery) as IQueryable<Log>;

            return LogQuery;
        }
        public Log_A GetLog_AWithLogID(int LogID)
        {
            return FillLog_A().Where(c => c.LogID == LogID).FirstOrDefault();

        }
        public IQueryable<Log_A> GetLog_AList()
        {
            IQueryable<Log_A> Log_AQuery = FillLog_A();

            Log_AQuery = EnhanceQueryStatements<Log_A>(Log_AQuery) as IQueryable<Log_A>;

            return Log_AQuery;
        }
        public Log_B GetLog_BWithLogID(int LogID)
        {
            return FillLog_B().Where(c => c.LogID == LogID).FirstOrDefault();

        }
        public IQueryable<Log_B> GetLog_BList()
        {
            IQueryable<Log_B> Log_BQuery = FillLog_B();

            Log_BQuery = EnhanceQueryStatements<Log_B>(Log_BQuery) as IQueryable<Log_B>;

            return Log_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(Log log)
        {
            log.ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Create);
            if (log.ValidationResults.Count() > 0) return false;

            db.Logs.Add(log);

            if (!TryToSave(log)) return false;

            return true;
        }
        public bool Delete(Log log)
        {
            log.ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Delete);
            if (log.ValidationResults.Count() > 0) return false;

            db.Logs.Remove(log);

            if (!TryToSave(log)) return false;

            return true;
        }
        public bool Update(Log log)
        {
            log.ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Update);
            if (log.ValidationResults.Count() > 0) return false;

            db.Logs.Update(log);

            if (!TryToSave(log)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(Log log)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                log.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
