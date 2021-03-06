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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [BoxModelResultController](CSSPWebAPI.Controllers.BoxModelResultController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.BoxModelResult](CSSPModels.BoxModelResult.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [BoxModelResultTypeEnum](CSSPEnums.BoxModelResultTypeEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class BoxModelResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB BoxModelResults table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public BoxModelResultService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all BoxModelResultService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            BoxModelResult boxModelResult = validationContext.ObjectInstance as BoxModelResult;
            boxModelResult.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (boxModelResult.BoxModelResultID == 0)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelResultID"), new[] { "BoxModelResultID" });
                }

                if (!(from c in db.BoxModelResults select c).Where(c => c.BoxModelResultID == boxModelResult.BoxModelResultID).Any())
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModelResult", "BoxModelResultID", boxModelResult.BoxModelResultID.ToString()), new[] { "BoxModelResultID" });
                }
            }

            BoxModel BoxModelBoxModelID = (from c in db.BoxModels where c.BoxModelID == boxModelResult.BoxModelID select c).FirstOrDefault();

            if (BoxModelBoxModelID == null)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelID", boxModelResult.BoxModelID.ToString()), new[] { "BoxModelID" });
            }

            retStr = enums.EnumTypeOK(typeof(BoxModelResultTypeEnum), (int?)boxModelResult.BoxModelResultType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelResultType"), new[] { "BoxModelResultType" });
            }

            if (boxModelResult.Volume_m3 < 0)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "Volume_m3", "0"), new[] { "Volume_m3" });
            }

            if (boxModelResult.Surface_m2 < 0)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "Surface_m2", "0"), new[] { "Surface_m2" });
            }

            if (boxModelResult.Radius_m < 0 || boxModelResult.Radius_m > 100000)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Radius_m", "0", "100000"), new[] { "Radius_m" });
            }

            if (boxModelResult.LeftSideDiameterLineAngle_deg != null)
            {
                if (boxModelResult.LeftSideDiameterLineAngle_deg < 0 || boxModelResult.LeftSideDiameterLineAngle_deg > 360)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LeftSideDiameterLineAngle_deg", "0", "360"), new[] { "LeftSideDiameterLineAngle_deg" });
                }
            }

            if (boxModelResult.CircleCenterLatitude != null)
            {
                if (boxModelResult.CircleCenterLatitude < -90 || boxModelResult.CircleCenterLatitude > 90)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CircleCenterLatitude", "-90", "90"), new[] { "CircleCenterLatitude" });
                }
            }

            if (boxModelResult.CircleCenterLongitude != null)
            {
                if (boxModelResult.CircleCenterLongitude < -180 || boxModelResult.CircleCenterLongitude > 180)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CircleCenterLongitude", "-180", "180"), new[] { "CircleCenterLongitude" });
                }
            }

            if (boxModelResult.RectLength_m < 0 || boxModelResult.RectLength_m > 100000)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RectLength_m", "0", "100000"), new[] { "RectLength_m" });
            }

            if (boxModelResult.RectWidth_m < 0 || boxModelResult.RectWidth_m > 100000)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RectWidth_m", "0", "100000"), new[] { "RectWidth_m" });
            }

            if (boxModelResult.LeftSideLineAngle_deg != null)
            {
                if (boxModelResult.LeftSideLineAngle_deg < 0 || boxModelResult.LeftSideLineAngle_deg > 360)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LeftSideLineAngle_deg", "0", "360"), new[] { "LeftSideLineAngle_deg" });
                }
            }

            if (boxModelResult.LeftSideLineStartLatitude != null)
            {
                if (boxModelResult.LeftSideLineStartLatitude < -90 || boxModelResult.LeftSideLineStartLatitude > 90)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LeftSideLineStartLatitude", "-90", "90"), new[] { "LeftSideLineStartLatitude" });
                }
            }

            if (boxModelResult.LeftSideLineStartLongitude != null)
            {
                if (boxModelResult.LeftSideLineStartLongitude < -180 || boxModelResult.LeftSideLineStartLongitude > 180)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LeftSideLineStartLongitude", "-180", "180"), new[] { "LeftSideLineStartLongitude" });
                }
            }

            if (boxModelResult.LastUpdateDate_UTC.Year == 1)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModelResult.LastUpdateDate_UTC.Year < 1980)
                {
                boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModelResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", boxModelResult.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the BoxModelResult model with the BoxModelResultID identifier
        /// </summary>
        /// <param name="BoxModelResultID">Is the identifier of [BoxModelResults](CSSPModels.BoxModelResult.html) table of CSSPDB</param>
        /// <returns>[BoxModelResult](CSSPModels.BoxModelResult.html) object connected to the CSSPDB</returns>
        public BoxModelResult GetBoxModelResultWithBoxModelResultID(int BoxModelResultID)
        {
            return (from c in db.BoxModelResults
                    where c.BoxModelResultID == BoxModelResultID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [BoxModelResult](CSSPModels.BoxModelResult.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [BoxModelResult](CSSPModels.BoxModelResult.html)</returns>
        public IQueryable<BoxModelResult> GetBoxModelResultList()
        {
            IQueryable<BoxModelResult> BoxModelResultQuery = (from c in db.BoxModelResults select c);

            BoxModelResultQuery = EnhanceQueryStatements<BoxModelResult>(BoxModelResultQuery) as IQueryable<BoxModelResult>;

            return BoxModelResultQuery;
        }
        /// <summary>
        /// Gets the BoxModelResultExtraA model with the BoxModelResultID identifier
        /// </summary>
        /// <param name="BoxModelResultID">Is the identifier of [BoxModelResults](CSSPModels.BoxModelResult.html) table of CSSPDB</param>
        /// <returns>[BoxModelResultExtraA](CSSPModels.BoxModelResultExtraA.html) object connected to the CSSPDB</returns>
        public BoxModelResultExtraA GetBoxModelResultExtraAWithBoxModelResultID(int BoxModelResultID)
        {
            return FillBoxModelResultExtraA().Where(c => c.BoxModelResultID == BoxModelResultID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [BoxModelResultExtraA](CSSPModels.BoxModelResultExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [BoxModelResultExtraA](CSSPModels.BoxModelResultExtraA.html)</returns>
        public IQueryable<BoxModelResultExtraA> GetBoxModelResultExtraAList()
        {
            IQueryable<BoxModelResultExtraA> BoxModelResultExtraAQuery = FillBoxModelResultExtraA();

            BoxModelResultExtraAQuery = EnhanceQueryStatements<BoxModelResultExtraA>(BoxModelResultExtraAQuery) as IQueryable<BoxModelResultExtraA>;

            return BoxModelResultExtraAQuery;
        }
        /// <summary>
        /// Gets the BoxModelResultExtraB model with the BoxModelResultID identifier
        /// </summary>
        /// <param name="BoxModelResultID">Is the identifier of [BoxModelResults](CSSPModels.BoxModelResult.html) table of CSSPDB</param>
        /// <returns>[BoxModelResultExtraB](CSSPModels.BoxModelResultExtraB.html) object connected to the CSSPDB</returns>
        public BoxModelResultExtraB GetBoxModelResultExtraBWithBoxModelResultID(int BoxModelResultID)
        {
            return FillBoxModelResultExtraB().Where(c => c.BoxModelResultID == BoxModelResultID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [BoxModelResultExtraB](CSSPModels.BoxModelResultExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [BoxModelResultExtraB](CSSPModels.BoxModelResultExtraB.html)</returns>
        public IQueryable<BoxModelResultExtraB> GetBoxModelResultExtraBList()
        {
            IQueryable<BoxModelResultExtraB> BoxModelResultExtraBQuery = FillBoxModelResultExtraB();

            BoxModelResultExtraBQuery = EnhanceQueryStatements<BoxModelResultExtraB>(BoxModelResultExtraBQuery) as IQueryable<BoxModelResultExtraB>;

            return BoxModelResultExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [BoxModelResult](CSSPModels.BoxModelResult.html) item in CSSPDB
        /// </summary>
        /// <param name="boxModelResult">Is the BoxModelResult item the client want to add to CSSPDB</param>
        /// <returns>true if BoxModelResult item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(BoxModelResult boxModelResult)
        {
            boxModelResult.ValidationResults = Validate(new ValidationContext(boxModelResult), ActionDBTypeEnum.Create);
            if (boxModelResult.ValidationResults.Count() > 0) return false;

            db.BoxModelResults.Add(boxModelResult);

            if (!TryToSave(boxModelResult)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [BoxModelResult](CSSPModels.BoxModelResult.html) item in CSSPDB
        /// </summary>
        /// <param name="boxModelResult">Is the BoxModelResult item the client want to add to CSSPDB. What's important here is the BoxModelResultID</param>
        /// <returns>true if BoxModelResult item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(BoxModelResult boxModelResult)
        {
            boxModelResult.ValidationResults = Validate(new ValidationContext(boxModelResult), ActionDBTypeEnum.Delete);
            if (boxModelResult.ValidationResults.Count() > 0) return false;

            db.BoxModelResults.Remove(boxModelResult);

            if (!TryToSave(boxModelResult)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [BoxModelResult](CSSPModels.BoxModelResult.html) item in CSSPDB
        /// </summary>
        /// <param name="boxModelResult">Is the BoxModelResult item the client want to add to CSSPDB. What's important here is the BoxModelResultID</param>
        /// <returns>true if BoxModelResult item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(BoxModelResult boxModelResult)
        {
            boxModelResult.ValidationResults = Validate(new ValidationContext(boxModelResult), ActionDBTypeEnum.Update);
            if (boxModelResult.ValidationResults.Count() > 0) return false;

            db.BoxModelResults.Update(boxModelResult);

            if (!TryToSave(boxModelResult)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [BoxModelResult](CSSPModels.BoxModelResult.html) item
        /// </summary>
        /// <param name="boxModelResult">Is the BoxModelResult item the client want to add to CSSPDB. What's important here is the BoxModelResultID</param>
        /// <returns>true if BoxModelResult item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(BoxModelResult boxModelResult)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                boxModelResult.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
