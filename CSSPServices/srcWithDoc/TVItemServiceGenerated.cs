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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [TVItemController](CSSPWebAPI.Controllers.TVItemController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.TVItem](CSSPModels.TVItem.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [TVTypeEnum](CSSPEnums.TVTypeEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class TVItemService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB TVItems table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public TVItemService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all TVItemService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItem tvItem = validationContext.ObjectInstance as TVItem;
            tvItem.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvItem.TVItemID == 0)
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemID"), new[] { "TVItemID" });
                }

                if (!(from c in db.TVItems select c).Where(c => c.TVItemID == tvItem.TVItemID).Any())
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", tvItem.TVItemID.ToString()), new[] { "TVItemID" });
                }
            }

            if (tvItem.TVType == TVTypeEnum.Root)
            {
                if ((from c in db.TVItems select c).Count() > 0)
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(CSSPServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { "TVItemTVItemID" });
                }
            }

            if (tvItem.TVLevel < 0 || tvItem.TVLevel > 100)
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVLevel", "0", "100"), new[] { "TVLevel" });
            }

            if (string.IsNullOrWhiteSpace(tvItem.TVPath))
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVPath"), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvItem.TVPath) && tvItem.TVPath.Length > 250)
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TVPath", "250"), new[] { "TVPath" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvItem.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVType"), new[] { "TVType" });
            }

            if (tvItem.TVType != TVTypeEnum.Root)
            {
                TVItem TVItemParentID = (from c in db.TVItems where c.TVItemID == tvItem.ParentID select c).FirstOrDefault();

                if (TVItemParentID == null)
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ParentID", tvItem.ParentID.ToString()), new[] { "ParentID" });
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
                        TVTypeEnum.HydrometricSite,
                        TVTypeEnum.Infrastructure,
                        TVTypeEnum.MikeBoundaryConditionWebTide,
                        TVTypeEnum.MikeBoundaryConditionMesh,
                        TVTypeEnum.MikeScenario,
                        TVTypeEnum.MikeSource,
                        TVTypeEnum.Municipality,
                        TVTypeEnum.MWQMSite,
                        TVTypeEnum.PolSourceSite,
                        TVTypeEnum.Province,
                        TVTypeEnum.Sector,
                        TVTypeEnum.Subsector,
                        TVTypeEnum.Tel,
                        TVTypeEnum.MWQMRun,
                        TVTypeEnum.Classification,
                    };
                    if (!AllowableTVTypes.Contains(TVItemParentID.TVType))
                    {
                        tvItem.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "ParentID", "Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,Classification"), new[] { "ParentID" });
                    }
                }
            }

            if (tvItem.LastUpdateDate_UTC.Year == 1)
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItem.LastUpdateDate_UTC.Year < 1980)
                {
                tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            if (tvItem.TVType != TVTypeEnum.Root)
            {
                TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItem.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    tvItem.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvItem.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                    {
                        tvItem.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                    }
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                tvItem.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the TVItem model with the TVItemID identifier
        /// </summary>
        /// <param name="TVItemID">Is the identifier of [TVItems](CSSPModels.TVItem.html) table of CSSPDB</param>
        /// <returns>[TVItem](CSSPModels.TVItem.html) object connected to the CSSPDB</returns>
        public TVItem GetTVItemWithTVItemID(int TVItemID)
        {
            return (from c in db.TVItems
                    where c.TVItemID == TVItemID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVItem](CSSPModels.TVItem.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVItem](CSSPModels.TVItem.html)</returns>
        public IQueryable<TVItem> GetTVItemList()
        {
            IQueryable<TVItem> TVItemQuery = (from c in db.TVItems select c);

            TVItemQuery = EnhanceQueryStatements<TVItem>(TVItemQuery) as IQueryable<TVItem>;

            return TVItemQuery;
        }
        /// <summary>
        /// Gets the TVItemExtraA model with the TVItemID identifier
        /// </summary>
        /// <param name="TVItemID">Is the identifier of [TVItems](CSSPModels.TVItem.html) table of CSSPDB</param>
        /// <returns>[TVItemExtraA](CSSPModels.TVItemExtraA.html) object connected to the CSSPDB</returns>
        public TVItemExtraA GetTVItemExtraAWithTVItemID(int TVItemID)
        {
            return FillTVItemExtraA().Where(c => c.TVItemID == TVItemID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVItemExtraA](CSSPModels.TVItemExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVItemExtraA](CSSPModels.TVItemExtraA.html)</returns>
        public IQueryable<TVItemExtraA> GetTVItemExtraAList()
        {
            IQueryable<TVItemExtraA> TVItemExtraAQuery = FillTVItemExtraA();

            TVItemExtraAQuery = EnhanceQueryStatements<TVItemExtraA>(TVItemExtraAQuery) as IQueryable<TVItemExtraA>;

            return TVItemExtraAQuery;
        }
        /// <summary>
        /// Gets the TVItemExtraB model with the TVItemID identifier
        /// </summary>
        /// <param name="TVItemID">Is the identifier of [TVItems](CSSPModels.TVItem.html) table of CSSPDB</param>
        /// <returns>[TVItemExtraB](CSSPModels.TVItemExtraB.html) object connected to the CSSPDB</returns>
        public TVItemExtraB GetTVItemExtraBWithTVItemID(int TVItemID)
        {
            return FillTVItemExtraB().Where(c => c.TVItemID == TVItemID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVItemExtraB](CSSPModels.TVItemExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVItemExtraB](CSSPModels.TVItemExtraB.html)</returns>
        public IQueryable<TVItemExtraB> GetTVItemExtraBList()
        {
            IQueryable<TVItemExtraB> TVItemExtraBQuery = FillTVItemExtraB();

            TVItemExtraBQuery = EnhanceQueryStatements<TVItemExtraB>(TVItemExtraBQuery) as IQueryable<TVItemExtraB>;

            return TVItemExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [TVItem](CSSPModels.TVItem.html) item in CSSPDB
        /// </summary>
        /// <param name="tvItem">Is the TVItem item the client want to add to CSSPDB</param>
        /// <returns>true if TVItem item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(TVItem tvItem)
        {
            tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Create);
            if (tvItem.ValidationResults.Count() > 0) return false;

            db.TVItems.Add(tvItem);

            if (!TryToSave(tvItem)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [TVItem](CSSPModels.TVItem.html) item in CSSPDB
        /// </summary>
        /// <param name="tvItem">Is the TVItem item the client want to add to CSSPDB. What's important here is the TVItemID</param>
        /// <returns>true if TVItem item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(TVItem tvItem)
        {
            tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Delete);
            if (tvItem.ValidationResults.Count() > 0) return false;

            db.TVItems.Remove(tvItem);

            if (!TryToSave(tvItem)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [TVItem](CSSPModels.TVItem.html) item in CSSPDB
        /// </summary>
        /// <param name="tvItem">Is the TVItem item the client want to add to CSSPDB. What's important here is the TVItemID</param>
        /// <returns>true if TVItem item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(TVItem tvItem)
        {
            tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Update);
            if (tvItem.ValidationResults.Count() > 0) return false;

            db.TVItems.Update(tvItem);

            if (!TryToSave(tvItem)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [TVItem](CSSPModels.TVItem.html) item
        /// </summary>
        /// <param name="tvItem">Is the TVItem item the client want to add to CSSPDB. What's important here is the TVItemID</param>
        /// <returns>true if TVItem item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(TVItem tvItem)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItem.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
