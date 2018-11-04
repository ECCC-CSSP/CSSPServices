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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [RatingCurveController](CSSPWebAPI.Controllers.RatingCurveController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.RatingCurve](CSSPModels.RatingCurve.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class RatingCurveService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB RatingCurves table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public RatingCurveService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all RatingCurveService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RatingCurve ratingCurve = validationContext.ObjectInstance as RatingCurve;
            ratingCurve.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (ratingCurve.RatingCurveID == 0)
                {
                    ratingCurve.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveRatingCurveID"), new[] { "RatingCurveID" });
                }

                if (!(from c in db.RatingCurves select c).Where(c => c.RatingCurveID == ratingCurve.RatingCurveID).Any())
                {
                    ratingCurve.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveRatingCurveID", ratingCurve.RatingCurveID.ToString()), new[] { "RatingCurveID" });
                }
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == ratingCurve.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "RatingCurveHydrometricSiteID", ratingCurve.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber))
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveRatingCurveNumber"), new[] { "RatingCurveNumber" });
            }

            if (!string.IsNullOrWhiteSpace(ratingCurve.RatingCurveNumber) && ratingCurve.RatingCurveNumber.Length > 50)
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "RatingCurveRatingCurveNumber", "50"), new[] { "RatingCurveNumber" });
            }

            if (ratingCurve.LastUpdateDate_UTC.Year == 1)
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RatingCurveLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (ratingCurve.LastUpdateDate_UTC.Year < 1980)
                {
                ratingCurve.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RatingCurveLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == ratingCurve.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "RatingCurveLastUpdateContactTVItemID", ratingCurve.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    ratingCurve.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "RatingCurveLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                ratingCurve.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the RatingCurve model with the RatingCurveID identifier
        /// </summary>
        /// <param name="RatingCurveID">Is the identifier of [RatingCurves](CSSPModels.RatingCurve.html) table of CSSPDB</param>
        /// <returns>[RatingCurve](CSSPModels.RatingCurve.html) object connected to the CSSPDB</returns>
        public RatingCurve GetRatingCurveWithRatingCurveID(int RatingCurveID)
        {
            return (from c in db.RatingCurves
                    where c.RatingCurveID == RatingCurveID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [RatingCurve](CSSPModels.RatingCurve.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [RatingCurve](CSSPModels.RatingCurve.html)</returns>
        public IQueryable<RatingCurve> GetRatingCurveList()
        {
            IQueryable<RatingCurve> RatingCurveQuery = (from c in db.RatingCurves select c);

            RatingCurveQuery = EnhanceQueryStatements<RatingCurve>(RatingCurveQuery) as IQueryable<RatingCurve>;

            return RatingCurveQuery;
        }
        /// <summary>
        /// Gets the RatingCurveExtraA model with the RatingCurveID identifier
        /// </summary>
        /// <param name="RatingCurveID">Is the identifier of [RatingCurves](CSSPModels.RatingCurve.html) table of CSSPDB</param>
        /// <returns>[RatingCurveExtraA](CSSPModels.RatingCurveExtraA.html) object connected to the CSSPDB</returns>
        public RatingCurveExtraA GetRatingCurveExtraAWithRatingCurveID(int RatingCurveID)
        {
            return FillRatingCurveExtraA().Where(c => c.RatingCurveID == RatingCurveID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [RatingCurveExtraA](CSSPModels.RatingCurveExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [RatingCurveExtraA](CSSPModels.RatingCurveExtraA.html)</returns>
        public IQueryable<RatingCurveExtraA> GetRatingCurveExtraAList()
        {
            IQueryable<RatingCurveExtraA> RatingCurveExtraAQuery = FillRatingCurveExtraA();

            RatingCurveExtraAQuery = EnhanceQueryStatements<RatingCurveExtraA>(RatingCurveExtraAQuery) as IQueryable<RatingCurveExtraA>;

            return RatingCurveExtraAQuery;
        }
        /// <summary>
        /// Gets the RatingCurveExtraB model with the RatingCurveID identifier
        /// </summary>
        /// <param name="RatingCurveID">Is the identifier of [RatingCurves](CSSPModels.RatingCurve.html) table of CSSPDB</param>
        /// <returns>[RatingCurveExtraB](CSSPModels.RatingCurveExtraB.html) object connected to the CSSPDB</returns>
        public RatingCurveExtraB GetRatingCurveExtraBWithRatingCurveID(int RatingCurveID)
        {
            return FillRatingCurveExtraB().Where(c => c.RatingCurveID == RatingCurveID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [RatingCurveExtraB](CSSPModels.RatingCurveExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [RatingCurveExtraB](CSSPModels.RatingCurveExtraB.html)</returns>
        public IQueryable<RatingCurveExtraB> GetRatingCurveExtraBList()
        {
            IQueryable<RatingCurveExtraB> RatingCurveExtraBQuery = FillRatingCurveExtraB();

            RatingCurveExtraBQuery = EnhanceQueryStatements<RatingCurveExtraB>(RatingCurveExtraBQuery) as IQueryable<RatingCurveExtraB>;

            return RatingCurveExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [RatingCurve](CSSPModels.RatingCurve.html) item in CSSPDB
        /// </summary>
        /// <param name="ratingCurve">Is the RatingCurve item the client want to add to CSSPDB</param>
        /// <returns>true if RatingCurve item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(RatingCurve ratingCurve)
        {
            ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Create);
            if (ratingCurve.ValidationResults.Count() > 0) return false;

            db.RatingCurves.Add(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [RatingCurve](CSSPModels.RatingCurve.html) item in CSSPDB
        /// </summary>
        /// <param name="ratingCurve">Is the RatingCurve item the client want to add to CSSPDB. What's important here is the RatingCurveID</param>
        /// <returns>true if RatingCurve item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(RatingCurve ratingCurve)
        {
            ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Delete);
            if (ratingCurve.ValidationResults.Count() > 0) return false;

            db.RatingCurves.Remove(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [RatingCurve](CSSPModels.RatingCurve.html) item in CSSPDB
        /// </summary>
        /// <param name="ratingCurve">Is the RatingCurve item the client want to add to CSSPDB. What's important here is the RatingCurveID</param>
        /// <returns>true if RatingCurve item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(RatingCurve ratingCurve)
        {
            ratingCurve.ValidationResults = Validate(new ValidationContext(ratingCurve), ActionDBTypeEnum.Update);
            if (ratingCurve.ValidationResults.Count() > 0) return false;

            db.RatingCurves.Update(ratingCurve);

            if (!TryToSave(ratingCurve)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [RatingCurve](CSSPModels.RatingCurve.html) item
        /// </summary>
        /// <param name="ratingCurve">Is the RatingCurve item the client want to add to CSSPDB. What's important here is the RatingCurveID</param>
        /// <returns>true if RatingCurve item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(RatingCurve ratingCurve)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ratingCurve.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
