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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [DrogueRunPositionController](CSSPWebAPI.Controllers.DrogueRunPositionController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.DrogueRunPosition](CSSPModels.DrogueRunPosition.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class DrogueRunPositionService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB DrogueRunPositions table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public DrogueRunPositionService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all DrogueRunPositionService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            DrogueRunPosition drogueRunPosition = validationContext.ObjectInstance as DrogueRunPosition;
            drogueRunPosition.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (drogueRunPosition.DrogueRunPositionID == 0)
                {
                    drogueRunPosition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DrogueRunPositionID"), new[] { "DrogueRunPositionID" });
                }

                if (!(from c in db.DrogueRunPositions select c).Where(c => c.DrogueRunPositionID == drogueRunPosition.DrogueRunPositionID).Any())
                {
                    drogueRunPosition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "DrogueRunPosition", "DrogueRunPositionID", drogueRunPosition.DrogueRunPositionID.ToString()), new[] { "DrogueRunPositionID" });
                }
            }

            DrogueRun DrogueRunDrogueRunID = (from c in db.DrogueRuns where c.DrogueRunID == drogueRunPosition.DrogueRunID select c).FirstOrDefault();

            if (DrogueRunDrogueRunID == null)
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "DrogueRun", "DrogueRunID", drogueRunPosition.DrogueRunID.ToString()), new[] { "DrogueRunID" });
            }

            if (drogueRunPosition.Ordinal < 0)
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "Ordinal", "0"), new[] { "Ordinal" });
            }

            if (drogueRunPosition.StepLat < -180 || drogueRunPosition.StepLat > 180)
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "StepLat", "-180", "180"), new[] { "StepLat" });
            }

            if (drogueRunPosition.StepLng < -90 || drogueRunPosition.StepLng > 90)
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "StepLng", "-90", "90"), new[] { "StepLng" });
            }

            if (drogueRunPosition.StepDateTime_Local.Year == 1)
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StepDateTime_Local"), new[] { "StepDateTime_Local" });
            }
            else
            {
                if (drogueRunPosition.StepDateTime_Local.Year < 1980)
                {
                drogueRunPosition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "StepDateTime_Local", "1980"), new[] { "StepDateTime_Local" });
                }
            }

            if (drogueRunPosition.CalculatedSpeed_m_s < 0 || drogueRunPosition.CalculatedSpeed_m_s > 10)
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CalculatedSpeed_m_s", "0", "10"), new[] { "CalculatedSpeed_m_s" });
            }

            if (drogueRunPosition.CalculatedDirection_deg < 0 || drogueRunPosition.CalculatedDirection_deg > 360)
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CalculatedDirection_deg", "0", "360"), new[] { "CalculatedDirection_deg" });
            }

            if (drogueRunPosition.LastUpdateDate_UTC.Year == 1)
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (drogueRunPosition.LastUpdateDate_UTC.Year < 1980)
                {
                drogueRunPosition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == drogueRunPosition.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", drogueRunPosition.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    drogueRunPosition.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                drogueRunPosition.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the DrogueRunPosition model with the DrogueRunPositionID identifier
        /// </summary>
        /// <param name="DrogueRunPositionID">Is the identifier of [DrogueRunPositions](CSSPModels.DrogueRunPosition.html) table of CSSPDB</param>
        /// <returns>[DrogueRunPosition](CSSPModels.DrogueRunPosition.html) object connected to the CSSPDB</returns>
        public DrogueRunPosition GetDrogueRunPositionWithDrogueRunPositionID(int DrogueRunPositionID)
        {
            return (from c in db.DrogueRunPositions
                    where c.DrogueRunPositionID == DrogueRunPositionID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [DrogueRunPosition](CSSPModels.DrogueRunPosition.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [DrogueRunPosition](CSSPModels.DrogueRunPosition.html)</returns>
        public IQueryable<DrogueRunPosition> GetDrogueRunPositionList()
        {
            IQueryable<DrogueRunPosition> DrogueRunPositionQuery = (from c in db.DrogueRunPositions select c);

            DrogueRunPositionQuery = EnhanceQueryStatements<DrogueRunPosition>(DrogueRunPositionQuery) as IQueryable<DrogueRunPosition>;

            return DrogueRunPositionQuery;
        }
        /// <summary>
        /// Gets the DrogueRunPositionExtraA model with the DrogueRunPositionID identifier
        /// </summary>
        /// <param name="DrogueRunPositionID">Is the identifier of [DrogueRunPositions](CSSPModels.DrogueRunPosition.html) table of CSSPDB</param>
        /// <returns>[DrogueRunPositionExtraA](CSSPModels.DrogueRunPositionExtraA.html) object connected to the CSSPDB</returns>
        public DrogueRunPositionExtraA GetDrogueRunPositionExtraAWithDrogueRunPositionID(int DrogueRunPositionID)
        {
            return FillDrogueRunPositionExtraA().Where(c => c.DrogueRunPositionID == DrogueRunPositionID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [DrogueRunPositionExtraA](CSSPModels.DrogueRunPositionExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [DrogueRunPositionExtraA](CSSPModels.DrogueRunPositionExtraA.html)</returns>
        public IQueryable<DrogueRunPositionExtraA> GetDrogueRunPositionExtraAList()
        {
            IQueryable<DrogueRunPositionExtraA> DrogueRunPositionExtraAQuery = FillDrogueRunPositionExtraA();

            DrogueRunPositionExtraAQuery = EnhanceQueryStatements<DrogueRunPositionExtraA>(DrogueRunPositionExtraAQuery) as IQueryable<DrogueRunPositionExtraA>;

            return DrogueRunPositionExtraAQuery;
        }
        /// <summary>
        /// Gets the DrogueRunPositionExtraB model with the DrogueRunPositionID identifier
        /// </summary>
        /// <param name="DrogueRunPositionID">Is the identifier of [DrogueRunPositions](CSSPModels.DrogueRunPosition.html) table of CSSPDB</param>
        /// <returns>[DrogueRunPositionExtraB](CSSPModels.DrogueRunPositionExtraB.html) object connected to the CSSPDB</returns>
        public DrogueRunPositionExtraB GetDrogueRunPositionExtraBWithDrogueRunPositionID(int DrogueRunPositionID)
        {
            return FillDrogueRunPositionExtraB().Where(c => c.DrogueRunPositionID == DrogueRunPositionID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [DrogueRunPositionExtraB](CSSPModels.DrogueRunPositionExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [DrogueRunPositionExtraB](CSSPModels.DrogueRunPositionExtraB.html)</returns>
        public IQueryable<DrogueRunPositionExtraB> GetDrogueRunPositionExtraBList()
        {
            IQueryable<DrogueRunPositionExtraB> DrogueRunPositionExtraBQuery = FillDrogueRunPositionExtraB();

            DrogueRunPositionExtraBQuery = EnhanceQueryStatements<DrogueRunPositionExtraB>(DrogueRunPositionExtraBQuery) as IQueryable<DrogueRunPositionExtraB>;

            return DrogueRunPositionExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [DrogueRunPosition](CSSPModels.DrogueRunPosition.html) item in CSSPDB
        /// </summary>
        /// <param name="drogueRunPosition">Is the DrogueRunPosition item the client want to add to CSSPDB</param>
        /// <returns>true if DrogueRunPosition item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(DrogueRunPosition drogueRunPosition)
        {
            drogueRunPosition.ValidationResults = Validate(new ValidationContext(drogueRunPosition), ActionDBTypeEnum.Create);
            if (drogueRunPosition.ValidationResults.Count() > 0) return false;

            db.DrogueRunPositions.Add(drogueRunPosition);

            if (!TryToSave(drogueRunPosition)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [DrogueRunPosition](CSSPModels.DrogueRunPosition.html) item in CSSPDB
        /// </summary>
        /// <param name="drogueRunPosition">Is the DrogueRunPosition item the client want to add to CSSPDB. What's important here is the DrogueRunPositionID</param>
        /// <returns>true if DrogueRunPosition item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(DrogueRunPosition drogueRunPosition)
        {
            drogueRunPosition.ValidationResults = Validate(new ValidationContext(drogueRunPosition), ActionDBTypeEnum.Delete);
            if (drogueRunPosition.ValidationResults.Count() > 0) return false;

            db.DrogueRunPositions.Remove(drogueRunPosition);

            if (!TryToSave(drogueRunPosition)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [DrogueRunPosition](CSSPModels.DrogueRunPosition.html) item in CSSPDB
        /// </summary>
        /// <param name="drogueRunPosition">Is the DrogueRunPosition item the client want to add to CSSPDB. What's important here is the DrogueRunPositionID</param>
        /// <returns>true if DrogueRunPosition item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(DrogueRunPosition drogueRunPosition)
        {
            drogueRunPosition.ValidationResults = Validate(new ValidationContext(drogueRunPosition), ActionDBTypeEnum.Update);
            if (drogueRunPosition.ValidationResults.Count() > 0) return false;

            db.DrogueRunPositions.Update(drogueRunPosition);

            if (!TryToSave(drogueRunPosition)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [DrogueRunPosition](CSSPModels.DrogueRunPosition.html) item
        /// </summary>
        /// <param name="drogueRunPosition">Is the DrogueRunPosition item the client want to add to CSSPDB. What's important here is the DrogueRunPositionID</param>
        /// <returns>true if DrogueRunPosition item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(DrogueRunPosition drogueRunPosition)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                drogueRunPosition.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
