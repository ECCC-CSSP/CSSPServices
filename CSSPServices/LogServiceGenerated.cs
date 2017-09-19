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
            log.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (log.LogID == 0)
                {
                    log.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogLogID), new[] { "LogID" });
                }

                if (!GetRead().Where(c => c.LogID == log.LogID).Any())
                {
                    log.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Log, CSSPModelsRes.LogLogID, log.LogID.ToString()), new[] { "LogID" });
                }
            }

            //LogID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(log.TableName))
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogTableName), new[] { "TableName" });
            }

            if (!string.IsNullOrWhiteSpace(log.TableName) && log.TableName.Length > 50)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LogTableName, "50"), new[] { "TableName" });
            }

            //ID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (log.ID < 1)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.LogID, "1"), new[] { "ID" });
            }

            retStr = enums.EnumTypeOK(typeof(LogCommandEnum), (int?)log.LogCommand);
            if (log.LogCommand == LogCommandEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogLogCommand), new[] { "LogCommand" });
            }

            if (string.IsNullOrWhiteSpace(log.Information))
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogInformation), new[] { "Information" });
            }

            //Information has no StringLength Attribute

            if (log.LastUpdateDate_UTC.Year == 1)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LogLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (log.LastUpdateDate_UTC.Year < 1980)
                {
                log.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LogLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == log.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LogLastUpdateContactTVItemID, log.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LogLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(log.LastUpdateContactTVText) && log.LastUpdateContactTVText.Length > 200)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LogLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(log.LogCommandText) && log.LogCommandText.Length > 100)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LogLogCommandText, "100"), new[] { "LogCommandText" });
            }

            //HasErrors (bool) is required but no testing needed 

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
            IQueryable<Log> logQuery = (from c in GetRead()
                                                where c.LogID == LogID
                                                select c);

            return FillLog(logQuery).FirstOrDefault();
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
        public IQueryable<Log> GetRead()
        {
            return db.Logs.AsNoTracking();
        }
        public IQueryable<Log> GetEdit()
        {
            return db.Logs;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<Log> FillLog(IQueryable<Log> logQuery)
        {
            List<Log> LogList = (from c in logQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new Log
                                         {
                                             LogID = c.LogID,
                                             TableName = c.TableName,
                                             ID = c.ID,
                                             LogCommand = c.LogCommand,
                                             Information = c.Information,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (Log log in LogList)
            {
                log.LogCommandText = enums.GetResValueForTypeAndID(typeof(LogCommandEnum), (int?)log.LogCommand);
            }

            return LogList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
