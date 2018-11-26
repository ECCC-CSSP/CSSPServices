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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [PolSourceObservationController](CSSPWebAPI.Controllers.PolSourceObservationController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.PolSourceObservation](CSSPModels.PolSourceObservation.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class PolSourceObservationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB PolSourceObservations table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public PolSourceObservationService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all PolSourceObservationService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceObservation polSourceObservation = validationContext.ObjectInstance as PolSourceObservation;
            polSourceObservation.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceObservation.PolSourceObservationID == 0)
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationID"), new[] { "PolSourceObservationID" });
                }

                if (!(from c in db.PolSourceObservations select c).Where(c => c.PolSourceObservationID == polSourceObservation.PolSourceObservationID).Any())
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationID", polSourceObservation.PolSourceObservationID.ToString()), new[] { "PolSourceObservationID" });
                }
            }

            PolSourceSite PolSourceSitePolSourceSiteID = (from c in db.PolSourceSites where c.PolSourceSiteID == polSourceObservation.PolSourceSiteID select c).FirstOrDefault();

            if (PolSourceSitePolSourceSiteID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceObservation.PolSourceSiteID.ToString()), new[] { "PolSourceSiteID" });
            }

            if (polSourceObservation.ObservationDate_Local.Year == 1)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ObservationDate_Local"), new[] { "ObservationDate_Local" });
            }
            else
            {
                if (polSourceObservation.ObservationDate_Local.Year < 1980)
                {
                polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ObservationDate_Local", "1980"), new[] { "ObservationDate_Local" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", polSourceObservation.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceObservation.Observation_ToBeDeleted))
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Observation_ToBeDeleted"), new[] { "Observation_ToBeDeleted" });
            }

            //Observation_ToBeDeleted has no StringLength Attribute

            if (polSourceObservation.LastUpdateDate_UTC.Year == 1)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceObservation.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceObservation.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the PolSourceObservation model with the PolSourceObservationID identifier
        /// </summary>
        /// <param name="PolSourceObservationID">Is the identifier of [PolSourceObservations](CSSPModels.PolSourceObservation.html) table of CSSPDB</param>
        /// <returns>[PolSourceObservation](CSSPModels.PolSourceObservation.html) object connected to the CSSPDB</returns>
        public PolSourceObservation GetPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID)
        {
            return (from c in db.PolSourceObservations
                    where c.PolSourceObservationID == PolSourceObservationID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [PolSourceObservation](CSSPModels.PolSourceObservation.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [PolSourceObservation](CSSPModels.PolSourceObservation.html)</returns>
        public IQueryable<PolSourceObservation> GetPolSourceObservationList()
        {
            IQueryable<PolSourceObservation> PolSourceObservationQuery = (from c in db.PolSourceObservations select c);

            PolSourceObservationQuery = EnhanceQueryStatements<PolSourceObservation>(PolSourceObservationQuery) as IQueryable<PolSourceObservation>;

            return PolSourceObservationQuery;
        }
        /// <summary>
        /// Gets the PolSourceObservationExtraA model with the PolSourceObservationID identifier
        /// </summary>
        /// <param name="PolSourceObservationID">Is the identifier of [PolSourceObservations](CSSPModels.PolSourceObservation.html) table of CSSPDB</param>
        /// <returns>[PolSourceObservationExtraA](CSSPModels.PolSourceObservationExtraA.html) object connected to the CSSPDB</returns>
        public PolSourceObservationExtraA GetPolSourceObservationExtraAWithPolSourceObservationID(int PolSourceObservationID)
        {
            return FillPolSourceObservationExtraA().Where(c => c.PolSourceObservationID == PolSourceObservationID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [PolSourceObservationExtraA](CSSPModels.PolSourceObservationExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [PolSourceObservationExtraA](CSSPModels.PolSourceObservationExtraA.html)</returns>
        public IQueryable<PolSourceObservationExtraA> GetPolSourceObservationExtraAList()
        {
            IQueryable<PolSourceObservationExtraA> PolSourceObservationExtraAQuery = FillPolSourceObservationExtraA();

            PolSourceObservationExtraAQuery = EnhanceQueryStatements<PolSourceObservationExtraA>(PolSourceObservationExtraAQuery) as IQueryable<PolSourceObservationExtraA>;

            return PolSourceObservationExtraAQuery;
        }
        /// <summary>
        /// Gets the PolSourceObservationExtraB model with the PolSourceObservationID identifier
        /// </summary>
        /// <param name="PolSourceObservationID">Is the identifier of [PolSourceObservations](CSSPModels.PolSourceObservation.html) table of CSSPDB</param>
        /// <returns>[PolSourceObservationExtraB](CSSPModels.PolSourceObservationExtraB.html) object connected to the CSSPDB</returns>
        public PolSourceObservationExtraB GetPolSourceObservationExtraBWithPolSourceObservationID(int PolSourceObservationID)
        {
            return FillPolSourceObservationExtraB().Where(c => c.PolSourceObservationID == PolSourceObservationID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [PolSourceObservationExtraB](CSSPModels.PolSourceObservationExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [PolSourceObservationExtraB](CSSPModels.PolSourceObservationExtraB.html)</returns>
        public IQueryable<PolSourceObservationExtraB> GetPolSourceObservationExtraBList()
        {
            IQueryable<PolSourceObservationExtraB> PolSourceObservationExtraBQuery = FillPolSourceObservationExtraB();

            PolSourceObservationExtraBQuery = EnhanceQueryStatements<PolSourceObservationExtraB>(PolSourceObservationExtraBQuery) as IQueryable<PolSourceObservationExtraB>;

            return PolSourceObservationExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [PolSourceObservation](CSSPModels.PolSourceObservation.html) item in CSSPDB
        /// </summary>
        /// <param name="polSourceObservation">Is the PolSourceObservation item the client want to add to CSSPDB</param>
        /// <returns>true if PolSourceObservation item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Create);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Add(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [PolSourceObservation](CSSPModels.PolSourceObservation.html) item in CSSPDB
        /// </summary>
        /// <param name="polSourceObservation">Is the PolSourceObservation item the client want to add to CSSPDB. What's important here is the PolSourceObservationID</param>
        /// <returns>true if PolSourceObservation item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Delete);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Remove(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [PolSourceObservation](CSSPModels.PolSourceObservation.html) item in CSSPDB
        /// </summary>
        /// <param name="polSourceObservation">Is the PolSourceObservation item the client want to add to CSSPDB. What's important here is the PolSourceObservationID</param>
        /// <returns>true if PolSourceObservation item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Update);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Update(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [PolSourceObservation](CSSPModels.PolSourceObservation.html) item
        /// </summary>
        /// <param name="polSourceObservation">Is the PolSourceObservation item the client want to add to CSSPDB. What's important here is the PolSourceObservationID</param>
        /// <returns>true if PolSourceObservation item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(PolSourceObservation polSourceObservation)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceObservation.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
