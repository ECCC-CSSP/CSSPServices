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
    ///     <para>bonjour MapInfoPoint</para>
    /// </summary>
    public partial class MapInfoPointService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MapInfoPointService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MapInfoPointMapInfoPointID"), new[] { "MapInfoPointID" });
                }

                if (!GetRead().Where(c => c.MapInfoPointID == mapInfoPoint.MapInfoPointID).Any())
                {
                    mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointMapInfoPointID", mapInfoPoint.MapInfoPointID.ToString()), new[] { "MapInfoPointID" });
                }
            }

            MapInfo MapInfoMapInfoID = (from c in db.MapInfos where c.MapInfoID == mapInfoPoint.MapInfoID select c).FirstOrDefault();

            if (MapInfoMapInfoID == null)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoPointMapInfoID", mapInfoPoint.MapInfoID.ToString()), new[] { "MapInfoID" });
            }

            if (mapInfoPoint.Ordinal < 0)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "MapInfoPointOrdinal", "0"), new[] { "Ordinal" });
            }

            if (mapInfoPoint.Lat < -90 || mapInfoPoint.Lat > 90)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoPointLat", "-90", "90"), new[] { "Lat" });
            }

            if (mapInfoPoint.Lng < -180 || mapInfoPoint.Lng > 180)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoPointLng", "-180", "180"), new[] { "Lng" });
            }

            if (mapInfoPoint.LastUpdateDate_UTC.Year == 1)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MapInfoPointLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mapInfoPoint.LastUpdateDate_UTC.Year < 1980)
                {
                mapInfoPoint.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MapInfoPointLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mapInfoPoint.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MapInfoPointLastUpdateContactTVItemID", mapInfoPoint.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MapInfoPointLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mapInfoPoint.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MapInfoPoint GetMapInfoPointWithMapInfoPointID(int MapInfoPointID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.MapInfoPointID == MapInfoPointID
                    select c).FirstOrDefault();

        }
        public IQueryable<MapInfoPoint> GetMapInfoPointList()
        {
            IQueryable<MapInfoPoint> MapInfoPointQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            MapInfoPointQuery = EnhanceQueryStatements<MapInfoPoint>(MapInfoPointQuery) as IQueryable<MapInfoPoint>;

            return MapInfoPointQuery;
        }
        public MapInfoPointWeb GetMapInfoPointWebWithMapInfoPointID(int MapInfoPointID)
        {
            return FillMapInfoPointWeb().FirstOrDefault();

        }
        public IQueryable<MapInfoPointWeb> GetMapInfoPointWebList()
        {
            IQueryable<MapInfoPointWeb> MapInfoPointWebQuery = FillMapInfoPointWeb();

            MapInfoPointWebQuery = EnhanceQueryStatements<MapInfoPointWeb>(MapInfoPointWebQuery) as IQueryable<MapInfoPointWeb>;

            return MapInfoPointWebQuery;
        }
        public MapInfoPointReport GetMapInfoPointReportWithMapInfoPointID(int MapInfoPointID)
        {
            return FillMapInfoPointReport().FirstOrDefault();

        }
        public IQueryable<MapInfoPointReport> GetMapInfoPointReportList()
        {
            IQueryable<MapInfoPointReport> MapInfoPointReportQuery = FillMapInfoPointReport();

            MapInfoPointReportQuery = EnhanceQueryStatements<MapInfoPointReport>(MapInfoPointReportQuery) as IQueryable<MapInfoPointReport>;

            return MapInfoPointReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Create);
            if (mapInfoPoint.ValidationResults.Count() > 0) return false;

            db.MapInfoPoints.Add(mapInfoPoint);

            if (!TryToSave(mapInfoPoint)) return false;

            return true;
        }
        public bool Delete(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Delete);
            if (mapInfoPoint.ValidationResults.Count() > 0) return false;

            db.MapInfoPoints.Remove(mapInfoPoint);

            if (!TryToSave(mapInfoPoint)) return false;

            return true;
        }
        public bool Update(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Update);
            if (mapInfoPoint.ValidationResults.Count() > 0) return false;

            db.MapInfoPoints.Update(mapInfoPoint);

            if (!TryToSave(mapInfoPoint)) return false;

            return true;
        }
        public IQueryable<MapInfoPoint> GetRead()
        {
            IQueryable<MapInfoPoint> mapInfoPointQuery = db.MapInfoPoints.AsNoTracking();

            return mapInfoPointQuery;
        }
        public IQueryable<MapInfoPoint> GetEdit()
        {
            IQueryable<MapInfoPoint> mapInfoPointQuery = db.MapInfoPoints;

            return mapInfoPointQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MapInfoPointFillWeb
        private IQueryable<MapInfoPointWeb> FillMapInfoPointWeb()
        {
             IQueryable<MapInfoPointWeb>  MapInfoPointWebQuery = (from c in db.MapInfoPoints
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MapInfoPointWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MapInfoPointID = c.MapInfoPointID,
                        MapInfoID = c.MapInfoID,
                        Ordinal = c.Ordinal,
                        Lat = c.Lat,
                        Lng = c.Lng,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return MapInfoPointWebQuery;
        }
        #endregion Functions private Generated MapInfoPointFillWeb

        #region Functions private Generated TryToSave
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