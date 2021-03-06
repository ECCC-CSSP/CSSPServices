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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [MapInfoPointController](CSSPWebAPI.Controllers.MapInfoPointController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.MapInfoPoint](CSSPModels.MapInfoPoint.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class MapInfoPointService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB MapInfoPoints table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public MapInfoPointService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all MapInfoPointService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MapInfoPoint mapInfoPoint = validationContext.ObjectInstance as MapInfoPoint;
            mapInfoPoint.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mapInfoPoint.MapInfoPointID == 0)
                {
                    mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MapInfoPointID"), new[] { "MapInfoPointID" });
                }

                if (!(from c in db.MapInfoPoints select c).Where(c => c.MapInfoPointID == mapInfoPoint.MapInfoPointID).Any())
                {
                    mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointID", mapInfoPoint.MapInfoPointID.ToString()), new[] { "MapInfoPointID" });
                }
            }

            MapInfo MapInfoMapInfoID = (from c in db.MapInfos where c.MapInfoID == mapInfoPoint.MapInfoID select c).FirstOrDefault();

            if (MapInfoMapInfoID == null)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoID", mapInfoPoint.MapInfoID.ToString()), new[] { "MapInfoID" });
            }

            if (mapInfoPoint.Ordinal < 0)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "Ordinal", "0"), new[] { "Ordinal" });
            }

            if (mapInfoPoint.Lat < -90 || mapInfoPoint.Lat > 90)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lat", "-90", "90"), new[] { "Lat" });
            }

            if (mapInfoPoint.Lng < -180 || mapInfoPoint.Lng > 180)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Lng", "-180", "180"), new[] { "Lng" });
            }

            if (mapInfoPoint.LastUpdateDate_UTC.Year == 1)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mapInfoPoint.LastUpdateDate_UTC.Year < 1980)
                {
                mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mapInfoPoint.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", mapInfoPoint.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the MapInfoPoint model with the MapInfoPointID identifier
        /// </summary>
        /// <param name="MapInfoPointID">Is the identifier of [MapInfoPoints](CSSPModels.MapInfoPoint.html) table of CSSPDB</param>
        /// <returns>[MapInfoPoint](CSSPModels.MapInfoPoint.html) object connected to the CSSPDB</returns>
        public MapInfoPoint GetMapInfoPointWithMapInfoPointID(int MapInfoPointID)
        {
            return (from c in db.MapInfoPoints
                    where c.MapInfoPointID == MapInfoPointID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [MapInfoPoint](CSSPModels.MapInfoPoint.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [MapInfoPoint](CSSPModels.MapInfoPoint.html)</returns>
        public IQueryable<MapInfoPoint> GetMapInfoPointList()
        {
            IQueryable<MapInfoPoint> MapInfoPointQuery = (from c in db.MapInfoPoints select c);

            MapInfoPointQuery = EnhanceQueryStatements<MapInfoPoint>(MapInfoPointQuery) as IQueryable<MapInfoPoint>;

            return MapInfoPointQuery;
        }
        /// <summary>
        /// Gets the MapInfoPointExtraA model with the MapInfoPointID identifier
        /// </summary>
        /// <param name="MapInfoPointID">Is the identifier of [MapInfoPoints](CSSPModels.MapInfoPoint.html) table of CSSPDB</param>
        /// <returns>[MapInfoPointExtraA](CSSPModels.MapInfoPointExtraA.html) object connected to the CSSPDB</returns>
        public MapInfoPointExtraA GetMapInfoPointExtraAWithMapInfoPointID(int MapInfoPointID)
        {
            return FillMapInfoPointExtraA().Where(c => c.MapInfoPointID == MapInfoPointID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [MapInfoPointExtraA](CSSPModels.MapInfoPointExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [MapInfoPointExtraA](CSSPModels.MapInfoPointExtraA.html)</returns>
        public IQueryable<MapInfoPointExtraA> GetMapInfoPointExtraAList()
        {
            IQueryable<MapInfoPointExtraA> MapInfoPointExtraAQuery = FillMapInfoPointExtraA();

            MapInfoPointExtraAQuery = EnhanceQueryStatements<MapInfoPointExtraA>(MapInfoPointExtraAQuery) as IQueryable<MapInfoPointExtraA>;

            return MapInfoPointExtraAQuery;
        }
        /// <summary>
        /// Gets the MapInfoPointExtraB model with the MapInfoPointID identifier
        /// </summary>
        /// <param name="MapInfoPointID">Is the identifier of [MapInfoPoints](CSSPModels.MapInfoPoint.html) table of CSSPDB</param>
        /// <returns>[MapInfoPointExtraB](CSSPModels.MapInfoPointExtraB.html) object connected to the CSSPDB</returns>
        public MapInfoPointExtraB GetMapInfoPointExtraBWithMapInfoPointID(int MapInfoPointID)
        {
            return FillMapInfoPointExtraB().Where(c => c.MapInfoPointID == MapInfoPointID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [MapInfoPointExtraB](CSSPModels.MapInfoPointExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [MapInfoPointExtraB](CSSPModels.MapInfoPointExtraB.html)</returns>
        public IQueryable<MapInfoPointExtraB> GetMapInfoPointExtraBList()
        {
            IQueryable<MapInfoPointExtraB> MapInfoPointExtraBQuery = FillMapInfoPointExtraB();

            MapInfoPointExtraBQuery = EnhanceQueryStatements<MapInfoPointExtraB>(MapInfoPointExtraBQuery) as IQueryable<MapInfoPointExtraB>;

            return MapInfoPointExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [MapInfoPoint](CSSPModels.MapInfoPoint.html) item in CSSPDB
        /// </summary>
        /// <param name="mapInfoPoint">Is the MapInfoPoint item the client want to add to CSSPDB</param>
        /// <returns>true if MapInfoPoint item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Create);
            if (mapInfoPoint.ValidationResults.Count() > 0) return false;

            db.MapInfoPoints.Add(mapInfoPoint);

            if (!TryToSave(mapInfoPoint)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [MapInfoPoint](CSSPModels.MapInfoPoint.html) item in CSSPDB
        /// </summary>
        /// <param name="mapInfoPoint">Is the MapInfoPoint item the client want to add to CSSPDB. What's important here is the MapInfoPointID</param>
        /// <returns>true if MapInfoPoint item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Delete);
            if (mapInfoPoint.ValidationResults.Count() > 0) return false;

            db.MapInfoPoints.Remove(mapInfoPoint);

            if (!TryToSave(mapInfoPoint)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [MapInfoPoint](CSSPModels.MapInfoPoint.html) item in CSSPDB
        /// </summary>
        /// <param name="mapInfoPoint">Is the MapInfoPoint item the client want to add to CSSPDB. What's important here is the MapInfoPointID</param>
        /// <returns>true if MapInfoPoint item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Update);
            if (mapInfoPoint.ValidationResults.Count() > 0) return false;

            db.MapInfoPoints.Update(mapInfoPoint);

            if (!TryToSave(mapInfoPoint)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [MapInfoPoint](CSSPModels.MapInfoPoint.html) item
        /// </summary>
        /// <param name="mapInfoPoint">Is the MapInfoPoint item the client want to add to CSSPDB. What's important here is the MapInfoPointID</param>
        /// <returns>true if MapInfoPoint item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(MapInfoPoint mapInfoPoint)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mapInfoPoint.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
