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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [DrogueRunController](CSSPWebAPI.Controllers.DrogueRunController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.DrogueRun](CSSPModels.DrogueRun.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [DrogueTypeEnum](CSSPEnums.DrogueTypeEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class DrogueRunService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB DrogueRuns table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public DrogueRunService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all DrogueRunService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            DrogueRun drogueRun = validationContext.ObjectInstance as DrogueRun;
            drogueRun.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (drogueRun.DrogueRunID == 0)
                {
                    drogueRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DrogueRunID"), new[] { "DrogueRunID" });
                }

                if (!(from c in db.DrogueRuns select c).Where(c => c.DrogueRunID == drogueRun.DrogueRunID).Any())
                {
                    drogueRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", drogueRun.DrogueRunID.ToString()), new[] { "DrogueRunID" });
                }
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == drogueRun.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                drogueRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", drogueRun.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    drogueRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (drogueRun.DrogueNumber < 0 || drogueRun.DrogueNumber > 100)
            {
                drogueRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DrogueNumber", "0", "100"), new[] { "DrogueNumber" });
            }

            retStr = enums.EnumTypeOK(typeof(DrogueTypeEnum), (int?)drogueRun.DrogueType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                drogueRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DrogueType"), new[] { "DrogueType" });
            }

            if (drogueRun.RunStartDateTime.Year == 1)
            {
                drogueRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RunStartDateTime"), new[] { "RunStartDateTime" });
            }
            else
            {
                if (drogueRun.RunStartDateTime.Year < 1980)
                {
                drogueRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RunStartDateTime", "1980"), new[] { "RunStartDateTime" });
                }
            }

            if (drogueRun.LastUpdateDate_UTC.Year == 1)
            {
                drogueRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (drogueRun.LastUpdateDate_UTC.Year < 1980)
                {
                drogueRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == drogueRun.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                drogueRun.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", drogueRun.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    drogueRun.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                drogueRun.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the DrogueRun model with the DrogueRunID identifier
        /// </summary>
        /// <param name="DrogueRunID">Is the identifier of [DrogueRuns](CSSPModels.DrogueRun.html) table of CSSPDB</param>
        /// <returns>[DrogueRun](CSSPModels.DrogueRun.html) object connected to the CSSPDB</returns>
        public DrogueRun GetDrogueRunWithDrogueRunID(int DrogueRunID)
        {
            return (from c in db.DrogueRuns
                    where c.DrogueRunID == DrogueRunID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [DrogueRun](CSSPModels.DrogueRun.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [DrogueRun](CSSPModels.DrogueRun.html)</returns>
        public IQueryable<DrogueRun> GetDrogueRunList()
        {
            IQueryable<DrogueRun> DrogueRunQuery = (from c in db.DrogueRuns select c);

            DrogueRunQuery = EnhanceQueryStatements<DrogueRun>(DrogueRunQuery) as IQueryable<DrogueRun>;

            return DrogueRunQuery;
        }
        /// <summary>
        /// Gets the DrogueRunExtraA model with the DrogueRunID identifier
        /// </summary>
        /// <param name="DrogueRunID">Is the identifier of [DrogueRuns](CSSPModels.DrogueRun.html) table of CSSPDB</param>
        /// <returns>[DrogueRunExtraA](CSSPModels.DrogueRunExtraA.html) object connected to the CSSPDB</returns>
        public DrogueRunExtraA GetDrogueRunExtraAWithDrogueRunID(int DrogueRunID)
        {
            return FillDrogueRunExtraA().Where(c => c.DrogueRunID == DrogueRunID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [DrogueRunExtraA](CSSPModels.DrogueRunExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [DrogueRunExtraA](CSSPModels.DrogueRunExtraA.html)</returns>
        public IQueryable<DrogueRunExtraA> GetDrogueRunExtraAList()
        {
            IQueryable<DrogueRunExtraA> DrogueRunExtraAQuery = FillDrogueRunExtraA();

            DrogueRunExtraAQuery = EnhanceQueryStatements<DrogueRunExtraA>(DrogueRunExtraAQuery) as IQueryable<DrogueRunExtraA>;

            return DrogueRunExtraAQuery;
        }
        /// <summary>
        /// Gets the DrogueRunExtraB model with the DrogueRunID identifier
        /// </summary>
        /// <param name="DrogueRunID">Is the identifier of [DrogueRuns](CSSPModels.DrogueRun.html) table of CSSPDB</param>
        /// <returns>[DrogueRunExtraB](CSSPModels.DrogueRunExtraB.html) object connected to the CSSPDB</returns>
        public DrogueRunExtraB GetDrogueRunExtraBWithDrogueRunID(int DrogueRunID)
        {
            return FillDrogueRunExtraB().Where(c => c.DrogueRunID == DrogueRunID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [DrogueRunExtraB](CSSPModels.DrogueRunExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [DrogueRunExtraB](CSSPModels.DrogueRunExtraB.html)</returns>
        public IQueryable<DrogueRunExtraB> GetDrogueRunExtraBList()
        {
            IQueryable<DrogueRunExtraB> DrogueRunExtraBQuery = FillDrogueRunExtraB();

            DrogueRunExtraBQuery = EnhanceQueryStatements<DrogueRunExtraB>(DrogueRunExtraBQuery) as IQueryable<DrogueRunExtraB>;

            return DrogueRunExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [DrogueRun](CSSPModels.DrogueRun.html) item in CSSPDB
        /// </summary>
        /// <param name="drogueRun">Is the DrogueRun item the client want to add to CSSPDB</param>
        /// <returns>true if DrogueRun item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(DrogueRun drogueRun)
        {
            drogueRun.ValidationResults = Validate(new ValidationContext(drogueRun), ActionDBTypeEnum.Create);
            if (drogueRun.ValidationResults.Count() > 0) return false;

            db.DrogueRuns.Add(drogueRun);

            if (!TryToSave(drogueRun)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [DrogueRun](CSSPModels.DrogueRun.html) item in CSSPDB
        /// </summary>
        /// <param name="drogueRun">Is the DrogueRun item the client want to add to CSSPDB. What's important here is the DrogueRunID</param>
        /// <returns>true if DrogueRun item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(DrogueRun drogueRun)
        {
            drogueRun.ValidationResults = Validate(new ValidationContext(drogueRun), ActionDBTypeEnum.Delete);
            if (drogueRun.ValidationResults.Count() > 0) return false;

            db.DrogueRuns.Remove(drogueRun);

            if (!TryToSave(drogueRun)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [DrogueRun](CSSPModels.DrogueRun.html) item in CSSPDB
        /// </summary>
        /// <param name="drogueRun">Is the DrogueRun item the client want to add to CSSPDB. What's important here is the DrogueRunID</param>
        /// <returns>true if DrogueRun item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(DrogueRun drogueRun)
        {
            drogueRun.ValidationResults = Validate(new ValidationContext(drogueRun), ActionDBTypeEnum.Update);
            if (drogueRun.ValidationResults.Count() > 0) return false;

            db.DrogueRuns.Update(drogueRun);

            if (!TryToSave(drogueRun)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [DrogueRun](CSSPModels.DrogueRun.html) item
        /// </summary>
        /// <param name="drogueRun">Is the DrogueRun item the client want to add to CSSPDB. What's important here is the DrogueRunID</param>
        /// <returns>true if DrogueRun item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(DrogueRun drogueRun)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                drogueRun.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
