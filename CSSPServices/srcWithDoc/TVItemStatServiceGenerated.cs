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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [TVItemStatController](CSSPWebAPI.Controllers.TVItemStatController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.TVItemStat](CSSPModels.TVItemStat.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [TVTypeEnum](CSSPEnums.TVTypeEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class TVItemStatService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB TVItemStats table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public TVItemStatService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all TVItemStatService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemStat tvItemStat = validationContext.ObjectInstance as TVItemStat;
            tvItemStat.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemStat.TVItemStatID == 0)
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemStatID"), new[] { "TVItemStatID" });
                }

                if (!(from c in db.TVItemStats select c).Where(c => c.TVItemStatID == tvItemStat.TVItemStatID).Any())
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatID", tvItemStat.TVItemStatID.ToString()), new[] { "TVItemStatID" });
                }
            }

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == tvItemStat.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", tvItemStat.TVItemID.ToString()), new[] { "TVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Contact,
                    TVTypeEnum.Country,
                    TVTypeEnum.Email,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.Tel,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.BoxModel,
                    TVTypeEnum.VisualPlumesScenario,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.MeshNode,
                    TVTypeEnum.WebTideNode,
                    TVTypeEnum.SamplingPlan,
                    TVTypeEnum.SeeOther,
                    TVTypeEnum.LineOverflow,
                    TVTypeEnum.MapInfo,
                    TVTypeEnum.MapInfoPoint,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemID", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItemStat.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            if (tvItemStat.ChildCount < 0 || tvItemStat.ChildCount > 10000000)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ChildCount", "0", "10000000"), new[] { "ChildCount" });
            }

            if (tvItemStat.LastUpdateDate_UTC.Year == 1)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemStat.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemStat.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvItemStat.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvItemStat.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                tvItemStat.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the TVItemStat model with the TVItemStatID identifier
        /// </summary>
        /// <param name="TVItemStatID">Is the identifier of [TVItemStats](CSSPModels.TVItemStat.html) table of CSSPDB</param>
        /// <returns>[TVItemStat](CSSPModels.TVItemStat.html) object connected to the CSSPDB</returns>
        public TVItemStat GetTVItemStatWithTVItemStatID(int TVItemStatID)
        {
            return (from c in db.TVItemStats
                    where c.TVItemStatID == TVItemStatID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVItemStat](CSSPModels.TVItemStat.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVItemStat](CSSPModels.TVItemStat.html)</returns>
        public IQueryable<TVItemStat> GetTVItemStatList()
        {
            IQueryable<TVItemStat> TVItemStatQuery = (from c in db.TVItemStats select c);

            TVItemStatQuery = EnhanceQueryStatements<TVItemStat>(TVItemStatQuery) as IQueryable<TVItemStat>;

            return TVItemStatQuery;
        }
        /// <summary>
        /// Gets the TVItemStatExtraA model with the TVItemStatID identifier
        /// </summary>
        /// <param name="TVItemStatID">Is the identifier of [TVItemStats](CSSPModels.TVItemStat.html) table of CSSPDB</param>
        /// <returns>[TVItemStatExtraA](CSSPModels.TVItemStatExtraA.html) object connected to the CSSPDB</returns>
        public TVItemStatExtraA GetTVItemStatExtraAWithTVItemStatID(int TVItemStatID)
        {
            return FillTVItemStatExtraA().Where(c => c.TVItemStatID == TVItemStatID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVItemStatExtraA](CSSPModels.TVItemStatExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVItemStatExtraA](CSSPModels.TVItemStatExtraA.html)</returns>
        public IQueryable<TVItemStatExtraA> GetTVItemStatExtraAList()
        {
            IQueryable<TVItemStatExtraA> TVItemStatExtraAQuery = FillTVItemStatExtraA();

            TVItemStatExtraAQuery = EnhanceQueryStatements<TVItemStatExtraA>(TVItemStatExtraAQuery) as IQueryable<TVItemStatExtraA>;

            return TVItemStatExtraAQuery;
        }
        /// <summary>
        /// Gets the TVItemStatExtraB model with the TVItemStatID identifier
        /// </summary>
        /// <param name="TVItemStatID">Is the identifier of [TVItemStats](CSSPModels.TVItemStat.html) table of CSSPDB</param>
        /// <returns>[TVItemStatExtraB](CSSPModels.TVItemStatExtraB.html) object connected to the CSSPDB</returns>
        public TVItemStatExtraB GetTVItemStatExtraBWithTVItemStatID(int TVItemStatID)
        {
            return FillTVItemStatExtraB().Where(c => c.TVItemStatID == TVItemStatID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVItemStatExtraB](CSSPModels.TVItemStatExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVItemStatExtraB](CSSPModels.TVItemStatExtraB.html)</returns>
        public IQueryable<TVItemStatExtraB> GetTVItemStatExtraBList()
        {
            IQueryable<TVItemStatExtraB> TVItemStatExtraBQuery = FillTVItemStatExtraB();

            TVItemStatExtraBQuery = EnhanceQueryStatements<TVItemStatExtraB>(TVItemStatExtraBQuery) as IQueryable<TVItemStatExtraB>;

            return TVItemStatExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [TVItemStat](CSSPModels.TVItemStat.html) item in CSSPDB
        /// </summary>
        /// <param name="tvItemStat">Is the TVItemStat item the client want to add to CSSPDB</param>
        /// <returns>true if TVItemStat item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Create);
            if (tvItemStat.ValidationResults.Count() > 0) return false;

            db.TVItemStats.Add(tvItemStat);

            if (!TryToSave(tvItemStat)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [TVItemStat](CSSPModels.TVItemStat.html) item in CSSPDB
        /// </summary>
        /// <param name="tvItemStat">Is the TVItemStat item the client want to add to CSSPDB. What's important here is the TVItemStatID</param>
        /// <returns>true if TVItemStat item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Delete);
            if (tvItemStat.ValidationResults.Count() > 0) return false;

            db.TVItemStats.Remove(tvItemStat);

            if (!TryToSave(tvItemStat)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [TVItemStat](CSSPModels.TVItemStat.html) item in CSSPDB
        /// </summary>
        /// <param name="tvItemStat">Is the TVItemStat item the client want to add to CSSPDB. What's important here is the TVItemStatID</param>
        /// <returns>true if TVItemStat item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Update);
            if (tvItemStat.ValidationResults.Count() > 0) return false;

            db.TVItemStats.Update(tvItemStat);

            if (!TryToSave(tvItemStat)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [TVItemStat](CSSPModels.TVItemStat.html) item
        /// </summary>
        /// <param name="tvItemStat">Is the TVItemStat item the client want to add to CSSPDB. What's important here is the TVItemStatID</param>
        /// <returns>true if TVItemStat item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(TVItemStat tvItemStat)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemStat.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
