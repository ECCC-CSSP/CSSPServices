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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [VPResultController](CSSPWebAPI.Controllers.VPResultController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.VPResult](CSSPModels.VPResult.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class VPResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB VPResults table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public VPResultService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all VPResultService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPResult vpResult = validationContext.ObjectInstance as VPResult;
            vpResult.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpResult.VPResultID == 0)
                {
                    vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPResultID"), new[] { "VPResultID" });
                }

                if (!(from c in db.VPResults select c).Where(c => c.VPResultID == vpResult.VPResultID).Any())
                {
                    vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPResult", "VPResultID", vpResult.VPResultID.ToString()), new[] { "VPResultID" });
                }
            }

            VPScenario VPScenarioVPScenarioID = (from c in db.VPScenarios where c.VPScenarioID == vpResult.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioID", vpResult.VPScenarioID.ToString()), new[] { "VPScenarioID" });
            }

            if (vpResult.Ordinal < 0 || vpResult.Ordinal > 1000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Ordinal", "0", "1000"), new[] { "Ordinal" });
            }

            if (vpResult.Concentration_MPN_100ml < 0 || vpResult.Concentration_MPN_100ml > 10000000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Concentration_MPN_100ml", "0", "10000000"), new[] { "Concentration_MPN_100ml" });
            }

            if (vpResult.Dilution < 0 || vpResult.Dilution > 1000000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Dilution", "0", "1000000"), new[] { "Dilution" });
            }

            if (vpResult.FarFieldWidth_m < 0 || vpResult.FarFieldWidth_m > 10000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "FarFieldWidth_m", "0", "10000"), new[] { "FarFieldWidth_m" });
            }

            if (vpResult.DispersionDistance_m < 0 || vpResult.DispersionDistance_m > 100000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DispersionDistance_m", "0", "100000"), new[] { "DispersionDistance_m" });
            }

            if (vpResult.TravelTime_hour < 0 || vpResult.TravelTime_hour > 100)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TravelTime_hour", "0", "100"), new[] { "TravelTime_hour" });
            }

            if (vpResult.LastUpdateDate_UTC.Year == 1)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpResult.LastUpdateDate_UTC.Year < 1980)
                {
                vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", vpResult.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the VPResult model with the VPResultID identifier
        /// </summary>
        /// <param name="VPResultID">Is the identifier of [VPResults](CSSPModels.VPResult.html) table of CSSPDB</param>
        /// <returns>[VPResult](CSSPModels.VPResult.html) object connected to the CSSPDB</returns>
        public VPResult GetVPResultWithVPResultID(int VPResultID)
        {
            return (from c in db.VPResults
                    where c.VPResultID == VPResultID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [VPResult](CSSPModels.VPResult.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [VPResult](CSSPModels.VPResult.html)</returns>
        public IQueryable<VPResult> GetVPResultList()
        {
            IQueryable<VPResult> VPResultQuery = (from c in db.VPResults select c);

            VPResultQuery = EnhanceQueryStatements<VPResult>(VPResultQuery) as IQueryable<VPResult>;

            return VPResultQuery;
        }
        /// <summary>
        /// Gets the VPResultExtraA model with the VPResultID identifier
        /// </summary>
        /// <param name="VPResultID">Is the identifier of [VPResults](CSSPModels.VPResult.html) table of CSSPDB</param>
        /// <returns>[VPResultExtraA](CSSPModels.VPResultExtraA.html) object connected to the CSSPDB</returns>
        public VPResultExtraA GetVPResultExtraAWithVPResultID(int VPResultID)
        {
            return FillVPResultExtraA().Where(c => c.VPResultID == VPResultID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [VPResultExtraA](CSSPModels.VPResultExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [VPResultExtraA](CSSPModels.VPResultExtraA.html)</returns>
        public IQueryable<VPResultExtraA> GetVPResultExtraAList()
        {
            IQueryable<VPResultExtraA> VPResultExtraAQuery = FillVPResultExtraA();

            VPResultExtraAQuery = EnhanceQueryStatements<VPResultExtraA>(VPResultExtraAQuery) as IQueryable<VPResultExtraA>;

            return VPResultExtraAQuery;
        }
        /// <summary>
        /// Gets the VPResultExtraB model with the VPResultID identifier
        /// </summary>
        /// <param name="VPResultID">Is the identifier of [VPResults](CSSPModels.VPResult.html) table of CSSPDB</param>
        /// <returns>[VPResultExtraB](CSSPModels.VPResultExtraB.html) object connected to the CSSPDB</returns>
        public VPResultExtraB GetVPResultExtraBWithVPResultID(int VPResultID)
        {
            return FillVPResultExtraB().Where(c => c.VPResultID == VPResultID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [VPResultExtraB](CSSPModels.VPResultExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [VPResultExtraB](CSSPModels.VPResultExtraB.html)</returns>
        public IQueryable<VPResultExtraB> GetVPResultExtraBList()
        {
            IQueryable<VPResultExtraB> VPResultExtraBQuery = FillVPResultExtraB();

            VPResultExtraBQuery = EnhanceQueryStatements<VPResultExtraB>(VPResultExtraBQuery) as IQueryable<VPResultExtraB>;

            return VPResultExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [VPResult](CSSPModels.VPResult.html) item in CSSPDB
        /// </summary>
        /// <param name="vpResult">Is the VPResult item the client want to add to CSSPDB</param>
        /// <returns>true if VPResult item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Create);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Add(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [VPResult](CSSPModels.VPResult.html) item in CSSPDB
        /// </summary>
        /// <param name="vpResult">Is the VPResult item the client want to add to CSSPDB. What's important here is the VPResultID</param>
        /// <returns>true if VPResult item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Delete);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Remove(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [VPResult](CSSPModels.VPResult.html) item in CSSPDB
        /// </summary>
        /// <param name="vpResult">Is the VPResult item the client want to add to CSSPDB. What's important here is the VPResultID</param>
        /// <returns>true if VPResult item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Update);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Update(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [VPResult](CSSPModels.VPResult.html) item
        /// </summary>
        /// <param name="vpResult">Is the VPResult item the client want to add to CSSPDB. What's important here is the VPResultID</param>
        /// <returns>true if VPResult item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(VPResult vpResult)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpResult.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
