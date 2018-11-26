/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    /// > [!NOTE]
    /// > 
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [LogController](CSSPWebAPI.Controllers.LogController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.Log](CSSPModels.Log.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [LogCommandEnum](CSSPEnums.LogCommandEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class LogService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB Logs table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public LogService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all LogService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LogID"), new[] { "LogID" });
                }

                if (!(from c in db.Logs select c).Where(c => c.LogID == log.LogID).Any())
                {
                    log.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Log", "LogID", log.LogID.ToString()), new[] { "LogID" });
                }
            }

            if (string.IsNullOrWhiteSpace(log.TableName))
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TableName"), new[] { "TableName" });
            }

            if (!string.IsNullOrWhiteSpace(log.TableName) && log.TableName.Length > 50)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TableName", "50"), new[] { "TableName" });
            }

            if (log.ID < 1)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "ID", "1"), new[] { "ID" });
            }

            retStr = enums.EnumTypeOK(typeof(LogCommandEnum), (int?)log.LogCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LogCommand"), new[] { "LogCommand" });
            }

            if (string.IsNullOrWhiteSpace(log.Information))
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Information"), new[] { "Information" });
            }

            //Information has no StringLength Attribute

            if (log.LastUpdateDate_UTC.Year == 1)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (log.LastUpdateDate_UTC.Year < 1980)
                {
                log.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == log.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                log.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", log.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                log.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the Log model with the LogID identifier
        /// </summary>
        /// <param name="LogID">Is the identifier of [Logs](CSSPModels.Log.html) table of CSSPDB</param>
        /// <returns>[Log](CSSPModels.Log.html) object connected to the CSSPDB</returns>
        public Log GetLogWithLogID(int LogID)
        {
            return (from c in db.Logs
                    where c.LogID == LogID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [Log](CSSPModels.Log.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [Log](CSSPModels.Log.html)</returns>
        public IQueryable<Log> GetLogList()
        {
            IQueryable<Log> LogQuery = (from c in db.Logs select c);

            LogQuery = EnhanceQueryStatements<Log>(LogQuery) as IQueryable<Log>;

            return LogQuery;
        }
        /// <summary>
        /// Gets the LogExtraA model with the LogID identifier
        /// </summary>
        /// <param name="LogID">Is the identifier of [Logs](CSSPModels.Log.html) table of CSSPDB</param>
        /// <returns>[LogExtraA](CSSPModels.LogExtraA.html) object connected to the CSSPDB</returns>
        public LogExtraA GetLogExtraAWithLogID(int LogID)
        {
            return FillLogExtraA().Where(c => c.LogID == LogID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [LogExtraA](CSSPModels.LogExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [LogExtraA](CSSPModels.LogExtraA.html)</returns>
        public IQueryable<LogExtraA> GetLogExtraAList()
        {
            IQueryable<LogExtraA> LogExtraAQuery = FillLogExtraA();

            LogExtraAQuery = EnhanceQueryStatements<LogExtraA>(LogExtraAQuery) as IQueryable<LogExtraA>;

            return LogExtraAQuery;
        }
        /// <summary>
        /// Gets the LogExtraB model with the LogID identifier
        /// </summary>
        /// <param name="LogID">Is the identifier of [Logs](CSSPModels.Log.html) table of CSSPDB</param>
        /// <returns>[LogExtraB](CSSPModels.LogExtraB.html) object connected to the CSSPDB</returns>
        public LogExtraB GetLogExtraBWithLogID(int LogID)
        {
            return FillLogExtraB().Where(c => c.LogID == LogID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [LogExtraB](CSSPModels.LogExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [LogExtraB](CSSPModels.LogExtraB.html)</returns>
        public IQueryable<LogExtraB> GetLogExtraBList()
        {
            IQueryable<LogExtraB> LogExtraBQuery = FillLogExtraB();

            LogExtraBQuery = EnhanceQueryStatements<LogExtraB>(LogExtraBQuery) as IQueryable<LogExtraB>;

            return LogExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [Log](CSSPModels.Log.html) item in CSSPDB
        /// </summary>
        /// <param name="log">Is the Log item the client want to add to CSSPDB</param>
        /// <returns>true if Log item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(Log log)
        {
            log.ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Create);
            if (log.ValidationResults.Count() > 0) return false;

            db.Logs.Add(log);

            if (!TryToSave(log)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [Log](CSSPModels.Log.html) item in CSSPDB
        /// </summary>
        /// <param name="log">Is the Log item the client want to add to CSSPDB. What's important here is the LogID</param>
        /// <returns>true if Log item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(Log log)
        {
            log.ValidationResults = Validate(new ValidationContext(log), ActionDBTypeEnum.Delete);
            if (log.ValidationResults.Count() > 0) return false;

            db.Logs.Remove(log);

            if (!TryToSave(log)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [Log](CSSPModels.Log.html) item in CSSPDB
        /// </summary>
        /// <param name="log">Is the Log item the client want to add to CSSPDB. What's important here is the LogID</param>
        /// <returns>true if Log item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
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
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [Log](CSSPModels.Log.html) item
        /// </summary>
        /// <param name="log">Is the Log item the client want to add to CSSPDB. What's important here is the LogID</param>
        /// <returns>true if Log item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
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
