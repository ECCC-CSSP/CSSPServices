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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [TVItemUserAuthorizationController](CSSPWebAPI.Controllers.TVItemUserAuthorizationController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.TVItemUserAuthorization](CSSPModels.TVItemUserAuthorization.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [TVAuthEnum](CSSPEnums.TVAuthEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class TVItemUserAuthorizationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB TVItemUserAuthorizations table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public TVItemUserAuthorizationService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all TVItemUserAuthorizationService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemUserAuthorization tvItemUserAuthorization = validationContext.ObjectInstance as TVItemUserAuthorization;
            tvItemUserAuthorization.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItemUserAuthorization.TVItemUserAuthorizationID == 0)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemUserAuthorizationID"), new[] { "TVItemUserAuthorizationID" });
                }

                if (!(from c in db.TVItemUserAuthorizations select c).Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorization.TVItemUserAuthorizationID).Any())
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItemUserAuthorization", "TVItemUserAuthorizationID", tvItemUserAuthorization.TVItemUserAuthorizationID.ToString()), new[] { "TVItemUserAuthorizationID" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactTVItemID", tvItemUserAuthorization.ContactTVItemID.ToString()), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ContactTVItemID", "Contact"), new[] { "ContactTVItemID" });
                }
            }

            TVItem TVItemTVItemID1 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID1 select c).FirstOrDefault();

            if (TVItemTVItemID1 == null)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID1", tvItemUserAuthorization.TVItemID1.ToString()), new[] { "TVItemID1" });
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
                if (!AllowableTVTypes.Contains(TVItemTVItemID1.TVType))
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemID1", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID1" });
                }
            }

            if (tvItemUserAuthorization.TVItemID2 != null)
            {
                TVItem TVItemTVItemID2 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID2 select c).FirstOrDefault();

                if (TVItemTVItemID2 == null)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID2", (tvItemUserAuthorization.TVItemID2 == null ? "" : tvItemUserAuthorization.TVItemID2.ToString())), new[] { "TVItemID2" });
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
                    if (!AllowableTVTypes.Contains(TVItemTVItemID2.TVType))
                    {
                        tvItemUserAuthorization.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemID2", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID2" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID3 != null)
            {
                TVItem TVItemTVItemID3 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID3 select c).FirstOrDefault();

                if (TVItemTVItemID3 == null)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID3", (tvItemUserAuthorization.TVItemID3 == null ? "" : tvItemUserAuthorization.TVItemID3.ToString())), new[] { "TVItemID3" });
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
                    if (!AllowableTVTypes.Contains(TVItemTVItemID3.TVType))
                    {
                        tvItemUserAuthorization.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemID3", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID3" });
                    }
                }
            }

            if (tvItemUserAuthorization.TVItemID4 != null)
            {
                TVItem TVItemTVItemID4 = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.TVItemID4 select c).FirstOrDefault();

                if (TVItemTVItemID4 == null)
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID4", (tvItemUserAuthorization.TVItemID4 == null ? "" : tvItemUserAuthorization.TVItemID4.ToString())), new[] { "TVItemID4" });
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
                    if (!AllowableTVTypes.Contains(TVItemTVItemID4.TVType))
                    {
                        tvItemUserAuthorization.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVItemID4", "Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOther,LineOverflow,MapInfo,MapInfoPoint"), new[] { "TVItemID4" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvItemUserAuthorization.TVAuth);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVAuth"), new[] { "TVAuth" });
            }

            if (tvItemUserAuthorization.LastUpdateDate_UTC.Year == 1)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemUserAuthorization.LastUpdateDate_UTC.Year < 1980)
                {
                tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemUserAuthorization.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvItemUserAuthorization.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                tvItemUserAuthorization.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the TVItemUserAuthorization model with the TVItemUserAuthorizationID identifier
        /// </summary>
        /// <param name="TVItemUserAuthorizationID">Is the identifier of [TVItemUserAuthorizations](CSSPModels.TVItemUserAuthorization.html) table of CSSPDB</param>
        /// <returns>[TVItemUserAuthorization](CSSPModels.TVItemUserAuthorization.html) object connected to the CSSPDB</returns>
        public TVItemUserAuthorization GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID)
        {
            return (from c in db.TVItemUserAuthorizations
                    where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVItemUserAuthorization](CSSPModels.TVItemUserAuthorization.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVItemUserAuthorization](CSSPModels.TVItemUserAuthorization.html)</returns>
        public IQueryable<TVItemUserAuthorization> GetTVItemUserAuthorizationList()
        {
            IQueryable<TVItemUserAuthorization> TVItemUserAuthorizationQuery = (from c in db.TVItemUserAuthorizations select c);

            TVItemUserAuthorizationQuery = EnhanceQueryStatements<TVItemUserAuthorization>(TVItemUserAuthorizationQuery) as IQueryable<TVItemUserAuthorization>;

            return TVItemUserAuthorizationQuery;
        }
        /// <summary>
        /// Gets the TVItemUserAuthorizationExtraA model with the TVItemUserAuthorizationID identifier
        /// </summary>
        /// <param name="TVItemUserAuthorizationID">Is the identifier of [TVItemUserAuthorizations](CSSPModels.TVItemUserAuthorization.html) table of CSSPDB</param>
        /// <returns>[TVItemUserAuthorizationExtraA](CSSPModels.TVItemUserAuthorizationExtraA.html) object connected to the CSSPDB</returns>
        public TVItemUserAuthorizationExtraA GetTVItemUserAuthorizationExtraAWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID)
        {
            return FillTVItemUserAuthorizationExtraA().Where(c => c.TVItemUserAuthorizationID == TVItemUserAuthorizationID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVItemUserAuthorizationExtraA](CSSPModels.TVItemUserAuthorizationExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVItemUserAuthorizationExtraA](CSSPModels.TVItemUserAuthorizationExtraA.html)</returns>
        public IQueryable<TVItemUserAuthorizationExtraA> GetTVItemUserAuthorizationExtraAList()
        {
            IQueryable<TVItemUserAuthorizationExtraA> TVItemUserAuthorizationExtraAQuery = FillTVItemUserAuthorizationExtraA();

            TVItemUserAuthorizationExtraAQuery = EnhanceQueryStatements<TVItemUserAuthorizationExtraA>(TVItemUserAuthorizationExtraAQuery) as IQueryable<TVItemUserAuthorizationExtraA>;

            return TVItemUserAuthorizationExtraAQuery;
        }
        /// <summary>
        /// Gets the TVItemUserAuthorizationExtraB model with the TVItemUserAuthorizationID identifier
        /// </summary>
        /// <param name="TVItemUserAuthorizationID">Is the identifier of [TVItemUserAuthorizations](CSSPModels.TVItemUserAuthorization.html) table of CSSPDB</param>
        /// <returns>[TVItemUserAuthorizationExtraB](CSSPModels.TVItemUserAuthorizationExtraB.html) object connected to the CSSPDB</returns>
        public TVItemUserAuthorizationExtraB GetTVItemUserAuthorizationExtraBWithTVItemUserAuthorizationID(int TVItemUserAuthorizationID)
        {
            return FillTVItemUserAuthorizationExtraB().Where(c => c.TVItemUserAuthorizationID == TVItemUserAuthorizationID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVItemUserAuthorizationExtraB](CSSPModels.TVItemUserAuthorizationExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVItemUserAuthorizationExtraB](CSSPModels.TVItemUserAuthorizationExtraB.html)</returns>
        public IQueryable<TVItemUserAuthorizationExtraB> GetTVItemUserAuthorizationExtraBList()
        {
            IQueryable<TVItemUserAuthorizationExtraB> TVItemUserAuthorizationExtraBQuery = FillTVItemUserAuthorizationExtraB();

            TVItemUserAuthorizationExtraBQuery = EnhanceQueryStatements<TVItemUserAuthorizationExtraB>(TVItemUserAuthorizationExtraBQuery) as IQueryable<TVItemUserAuthorizationExtraB>;

            return TVItemUserAuthorizationExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [TVItemUserAuthorization](CSSPModels.TVItemUserAuthorization.html) item in CSSPDB
        /// </summary>
        /// <param name="tvItemUserAuthorization">Is the TVItemUserAuthorization item the client want to add to CSSPDB</param>
        /// <returns>true if TVItemUserAuthorization item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(TVItemUserAuthorization tvItemUserAuthorization)
        {
            tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Create);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVItemUserAuthorizations.Add(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [TVItemUserAuthorization](CSSPModels.TVItemUserAuthorization.html) item in CSSPDB
        /// </summary>
        /// <param name="tvItemUserAuthorization">Is the TVItemUserAuthorization item the client want to add to CSSPDB. What's important here is the TVItemUserAuthorizationID</param>
        /// <returns>true if TVItemUserAuthorization item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(TVItemUserAuthorization tvItemUserAuthorization)
        {
            tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Delete);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVItemUserAuthorizations.Remove(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [TVItemUserAuthorization](CSSPModels.TVItemUserAuthorization.html) item in CSSPDB
        /// </summary>
        /// <param name="tvItemUserAuthorization">Is the TVItemUserAuthorization item the client want to add to CSSPDB. What's important here is the TVItemUserAuthorizationID</param>
        /// <returns>true if TVItemUserAuthorization item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(TVItemUserAuthorization tvItemUserAuthorization)
        {
            tvItemUserAuthorization.ValidationResults = Validate(new ValidationContext(tvItemUserAuthorization), ActionDBTypeEnum.Update);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0) return false;

            db.TVItemUserAuthorizations.Update(tvItemUserAuthorization);

            if (!TryToSave(tvItemUserAuthorization)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [TVItemUserAuthorization](CSSPModels.TVItemUserAuthorization.html) item
        /// </summary>
        /// <param name="tvItemUserAuthorization">Is the TVItemUserAuthorization item the client want to add to CSSPDB. What's important here is the TVItemUserAuthorizationID</param>
        /// <returns>true if TVItemUserAuthorization item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(TVItemUserAuthorization tvItemUserAuthorization)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemUserAuthorization.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
