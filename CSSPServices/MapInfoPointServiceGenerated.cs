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
    public partial class MapInfoPointService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MapInfoPoint mapInfoPoint = validationContext.ObjectInstance as MapInfoPoint;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mapInfoPoint.MapInfoPointID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoPointMapInfoPointID), new[] { ModelsRes.MapInfoPointMapInfoPointID });
                }
            }

            //MapInfoPointID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MapInfoID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfoPoint.MapInfoID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointMapInfoID, "1"), new[] { ModelsRes.MapInfoPointMapInfoID });
            }

            if (!((from c in db.MapInfos where c.MapInfoID == mapInfoPoint.MapInfoID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MapInfo, ModelsRes.MapInfoPointMapInfoID, mapInfoPoint.MapInfoID.ToString()), new[] { ModelsRes.MapInfoPointMapInfoID });
            }

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfoPoint.Ordinal < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointOrdinal, "0"), new[] { ModelsRes.MapInfoPointOrdinal });
            }

            //Lat (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfoPoint.Lat < -90 || mapInfoPoint.Lat > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLat, "-90", "90"), new[] { ModelsRes.MapInfoPointLat });
            }

            //Lng (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfoPoint.Lng < -180 || mapInfoPoint.Lng > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLng, "-180", "180"), new[] { ModelsRes.MapInfoPointLng });
            }

            if (mapInfoPoint.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoPointLastUpdateDate_UTC), new[] { ModelsRes.MapInfoPointLastUpdateDate_UTC });
            }

            if (mapInfoPoint.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MapInfoPointLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MapInfoPointLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfoPoint.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MapInfoPointLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mapInfoPoint.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MapInfoPointLastUpdateContactTVItemID, mapInfoPoint.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MapInfoPointLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(MapInfoPoint mapInfoPoint)
        {
            mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Create);
            if (mapInfoPoint.ValidationResults.Count() > 0) return false;

            db.MapInfoPoints.Add(mapInfoPoint);

            if (!TryToSave(mapInfoPoint)) return false;

            return true;
        }
        public bool AddRange(List<MapInfoPoint> mapInfoPointList)
        {
            foreach (MapInfoPoint mapInfoPoint in mapInfoPointList)
            {
                mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Create);
                if (mapInfoPoint.ValidationResults.Count() > 0) return false;
            }

            db.MapInfoPoints.AddRange(mapInfoPointList);

            if (!TryToSaveRange(mapInfoPointList)) return false;

            return true;
        }
        public bool Delete(MapInfoPoint mapInfoPoint)
        {
            if (!db.MapInfoPoints.Where(c => c.MapInfoPointID == mapInfoPoint.MapInfoPointID).Any())
            {
                mapInfoPoint.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointID", mapInfoPoint.MapInfoPointID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MapInfoPoints.Remove(mapInfoPoint);

            if (!TryToSave(mapInfoPoint)) return false;

            return true;
        }
        public bool DeleteRange(List<MapInfoPoint> mapInfoPointList)
        {
            foreach (MapInfoPoint mapInfoPoint in mapInfoPointList)
            {
                if (!db.MapInfoPoints.Where(c => c.MapInfoPointID == mapInfoPoint.MapInfoPointID).Any())
                {
                    mapInfoPointList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointID", mapInfoPoint.MapInfoPointID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MapInfoPoints.RemoveRange(mapInfoPointList);

            if (!TryToSaveRange(mapInfoPointList)) return false;

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
        public bool UpdateRange(List<MapInfoPoint> mapInfoPointList)
        {
            foreach (MapInfoPoint mapInfoPoint in mapInfoPointList)
            {
                mapInfoPoint.ValidationResults = Validate(new ValidationContext(mapInfoPoint), ActionDBTypeEnum.Update);
                if (mapInfoPoint.ValidationResults.Count() > 0) return false;
            }
            db.MapInfoPoints.UpdateRange(mapInfoPointList);

            if (!TryToSaveRange(mapInfoPointList)) return false;

            return true;
        }
        public IQueryable<MapInfoPoint> GetRead()
        {
            return db.MapInfoPoints.AsNoTracking();
        }
        public IQueryable<MapInfoPoint> GetEdit()
        {
            return db.MapInfoPoints;
        }
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<MapInfoPoint> mapInfoPointList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mapInfoPointList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
