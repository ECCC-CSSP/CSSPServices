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
    public partial class LogService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LogService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Log log = validationContext.ObjectInstance as Log;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (log.LogID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LogLogID), new[] { ModelsRes.LogLogID });
                }
            }

            //LogID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(log.TableName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LogTableName), new[] { ModelsRes.LogTableName });
            }

            if (!string.IsNullOrWhiteSpace(log.TableName) && log.TableName.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LogTableName, "50"), new[] { ModelsRes.LogTableName });
            }

            //ID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (log.ID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LogID, "1"), new[] { ModelsRes.LogID });
            }

            retStr = enums.LogCommandOK(log.LogCommand);
            if (log.LogCommand == LogCommandEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LogLogCommand), new[] { ModelsRes.LogLogCommand });
            }

            if (string.IsNullOrWhiteSpace(log.Information))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LogInformation), new[] { ModelsRes.LogInformation });
            }

            //Information has no StringLength Attribute

            if (log.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LogLastUpdateDate_UTC), new[] { ModelsRes.LogLastUpdateDate_UTC });
            }
            else
            {
                if (log.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LogLastUpdateDate_UTC, "1980"), new[] { ModelsRes.LogLastUpdateDate_UTC });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (log.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LogLastUpdateContactTVItemID, "1"), new[] { ModelsRes.LogLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == log.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LogLastUpdateContactTVItemID, log.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.LogLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(Log log)
        {
            log.ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Create);
            if (log.ValidationResults.Count() > 0) return false;

            db.Logs.Add(log);

            if (!TryToSave(log)) return false;

            return true;
        }
        public bool AddRange(List<Log> logList)
        {
            foreach (Log log in logList)
            {
                log.ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Create);
                if (log.ValidationResults.Count() > 0) return false;
            }

            db.Logs.AddRange(logList);

            if (!TryToSaveRange(logList)) return false;

            return true;
        }
        public bool Delete(Log log)
        {
            if (!db.Logs.Where(c => c.LogID == log.LogID).Any())
            {
                log.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", log.LogID.ToString())) }.AsEnumerable();
                return false;
            }

            db.Logs.Remove(log);

            if (!TryToSave(log)) return false;

            return true;
        }
        public bool DeleteRange(List<Log> logList)
        {
            foreach (Log log in logList)
            {
                if (!db.Logs.Where(c => c.LogID == log.LogID).Any())
                {
                    logList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", log.LogID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.Logs.RemoveRange(logList);

            if (!TryToSaveRange(logList)) return false;

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
        public bool UpdateRange(List<Log> logList)
        {
            foreach (Log log in logList)
            {
                log.ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Update);
                if (log.ValidationResults.Count() > 0) return false;
            }
            db.Logs.UpdateRange(logList);

            if (!TryToSaveRange(logList)) return false;

            return true;
        }
        public IQueryable<Log> GetRead()
        {
            return db.Logs.AsNoTracking();
        }
        public IQueryable<Log> GetEdit()
        {
            return db.Logs;
        }
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<Log> logList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                logList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
