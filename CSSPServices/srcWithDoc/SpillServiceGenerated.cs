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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [SpillController](CSSPWebAPI.Controllers.SpillController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.Spill](CSSPModels.Spill.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class SpillService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB Spills table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public SpillService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all SpillService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Spill spill = validationContext.ObjectInstance as Spill;
            spill.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (spill.SpillID == 0)
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillSpillID"), new[] { "SpillID" });
                }

                if (!(from c in db.Spills select c).Where(c => c.SpillID == spill.SpillID).Any())
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillSpillID", spill.SpillID.ToString()), new[] { "SpillID" });
                }
            }

            TVItem TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == spill.MunicipalityTVItemID select c).FirstOrDefault();

            if (TVItemMunicipalityTVItemID == null)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SpillMunicipalityTVItemID", spill.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Municipality,
                };
                if (!AllowableTVTypes.Contains(TVItemMunicipalityTVItemID.TVType))
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SpillMunicipalityTVItemID", "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (spill.InfrastructureTVItemID != null)
            {
                TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == spill.InfrastructureTVItemID select c).FirstOrDefault();

                if (TVItemInfrastructureTVItemID == null)
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SpillInfrastructureTVItemID", (spill.InfrastructureTVItemID == null ? "" : spill.InfrastructureTVItemID.ToString())), new[] { "InfrastructureTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                    {
                        spill.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SpillInfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                    }
                }
            }

            if (spill.StartDateTime_Local.Year == 1)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillStartDateTime_Local"), new[] { "StartDateTime_Local" });
            }
            else
            {
                if (spill.StartDateTime_Local.Year < 1980)
                {
                spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SpillStartDateTime_Local", "1980"), new[] { "StartDateTime_Local" });
                }
            }

            if (spill.EndDateTime_Local != null && ((DateTime)spill.EndDateTime_Local).Year < 1980)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SpillEndDateTime_Local", "1980"), new[] { "SpillEndDateTime_Local" });
            }

            if (spill.StartDateTime_Local > spill.EndDateTime_Local)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "SpillEndDateTime_Local", "SpillStartDateTime_Local"), new[] { "SpillEndDateTime_Local" });
            }

            if (spill.AverageFlow_m3_day < 0 || spill.AverageFlow_m3_day > 1000000)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SpillAverageFlow_m3_day", "0", "1000000"), new[] { "AverageFlow_m3_day" });
            }

            if (spill.LastUpdateDate_UTC.Year == 1)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (spill.LastUpdateDate_UTC.Year < 1980)
                {
                spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SpillLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spill.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SpillLastUpdateContactTVItemID", spill.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SpillLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                spill.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the Spill model with the SpillID identifier
        /// </summary>
        /// <param name="SpillID">Is the identifier of [Spills](CSSPModels.Spill.html) table of CSSPDB</param>
        /// <returns>[Spill](CSSPModels.Spill.html) object connected to the CSSPDB</returns>
        public Spill GetSpillWithSpillID(int SpillID)
        {
            return (from c in db.Spills
                    where c.SpillID == SpillID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [Spill](CSSPModels.Spill.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [Spill](CSSPModels.Spill.html)</returns>
        public IQueryable<Spill> GetSpillList()
        {
            IQueryable<Spill> SpillQuery = (from c in db.Spills select c);

            SpillQuery = EnhanceQueryStatements<Spill>(SpillQuery) as IQueryable<Spill>;

            return SpillQuery;
        }
        /// <summary>
        /// Gets the SpillExtraA model with the SpillID identifier
        /// </summary>
        /// <param name="SpillID">Is the identifier of [Spills](CSSPModels.Spill.html) table of CSSPDB</param>
        /// <returns>[SpillExtraA](CSSPModels.SpillExtraA.html) object connected to the CSSPDB</returns>
        public SpillExtraA GetSpillExtraAWithSpillID(int SpillID)
        {
            return FillSpillExtraA().Where(c => c.SpillID == SpillID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [SpillExtraA](CSSPModels.SpillExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [SpillExtraA](CSSPModels.SpillExtraA.html)</returns>
        public IQueryable<SpillExtraA> GetSpillExtraAList()
        {
            IQueryable<SpillExtraA> SpillExtraAQuery = FillSpillExtraA();

            SpillExtraAQuery = EnhanceQueryStatements<SpillExtraA>(SpillExtraAQuery) as IQueryable<SpillExtraA>;

            return SpillExtraAQuery;
        }
        /// <summary>
        /// Gets the SpillExtraB model with the SpillID identifier
        /// </summary>
        /// <param name="SpillID">Is the identifier of [Spills](CSSPModels.Spill.html) table of CSSPDB</param>
        /// <returns>[SpillExtraB](CSSPModels.SpillExtraB.html) object connected to the CSSPDB</returns>
        public SpillExtraB GetSpillExtraBWithSpillID(int SpillID)
        {
            return FillSpillExtraB().Where(c => c.SpillID == SpillID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [SpillExtraB](CSSPModels.SpillExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [SpillExtraB](CSSPModels.SpillExtraB.html)</returns>
        public IQueryable<SpillExtraB> GetSpillExtraBList()
        {
            IQueryable<SpillExtraB> SpillExtraBQuery = FillSpillExtraB();

            SpillExtraBQuery = EnhanceQueryStatements<SpillExtraB>(SpillExtraBQuery) as IQueryable<SpillExtraB>;

            return SpillExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [Spill](CSSPModels.Spill.html) item in CSSPDB
        /// </summary>
        /// <param name="spill">Is the Spill item the client want to add to CSSPDB</param>
        /// <returns>true if Spill item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(Spill spill)
        {
            spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Create);
            if (spill.ValidationResults.Count() > 0) return false;

            db.Spills.Add(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [Spill](CSSPModels.Spill.html) item in CSSPDB
        /// </summary>
        /// <param name="spill">Is the Spill item the client want to add to CSSPDB. What's important here is the SpillID</param>
        /// <returns>true if Spill item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(Spill spill)
        {
            spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Delete);
            if (spill.ValidationResults.Count() > 0) return false;

            db.Spills.Remove(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [Spill](CSSPModels.Spill.html) item in CSSPDB
        /// </summary>
        /// <param name="spill">Is the Spill item the client want to add to CSSPDB. What's important here is the SpillID</param>
        /// <returns>true if Spill item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(Spill spill)
        {
            spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Update);
            if (spill.ValidationResults.Count() > 0) return false;

            db.Spills.Update(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [Spill](CSSPModels.Spill.html) item
        /// </summary>
        /// <param name="spill">Is the Spill item the client want to add to CSSPDB. What's important here is the SpillID</param>
        /// <returns>true if Spill item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(Spill spill)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                spill.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
