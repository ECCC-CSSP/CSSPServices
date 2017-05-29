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
        public MapInfoPointService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            MapInfoPoint mapInfoPoint = validationContext.ObjectInstance as MapInfoPoint;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mapInfoPoint.MapInfoPointID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoPointMapInfoPointID), new[] { ModelsRes.MapInfoPointMapInfoPointID });
                }
            }

            //MapInfoID (int) is required but no testing needed as it is automatically set to 0

            //Ordinal (int) is required but no testing needed as it is automatically set to 0

            //Lat (float) is required but no testing needed as it is automatically set to 0.0f

            //Lng (float) is required but no testing needed as it is automatically set to 0.0f

            if (mapInfoPoint.LastUpdateDate_UTC == null || mapInfoPoint.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoPointLastUpdateDate_UTC), new[] { ModelsRes.MapInfoPointLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (mapInfoPoint.MapInfoID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointMapInfoID, "1"), new[] { ModelsRes.MapInfoPointMapInfoID });
            }

            if (mapInfoPoint.Ordinal < 0 || mapInfoPoint.Ordinal > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointOrdinal, "0", "1000000"), new[] { ModelsRes.MapInfoPointOrdinal });
            }

            if (mapInfoPoint.Lat < -90 || mapInfoPoint.Lat > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLat, "-90", "90"), new[] { ModelsRes.MapInfoPointLat });
            }

            if (mapInfoPoint.Lng < -180 || mapInfoPoint.Lng > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLng, "-180", "180"), new[] { ModelsRes.MapInfoPointLng });
            }

            if (mapInfoPoint.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MapInfoPointLastUpdateContactTVItemID });
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
