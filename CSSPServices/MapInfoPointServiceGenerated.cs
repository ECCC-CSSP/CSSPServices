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
        #endregion Properties

        #region Constructors
        public MapInfoPointService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoPointMapInfoPointID), new[] { "MapInfoPointID" });
                }
            }

            //MapInfoPointID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MapInfoID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            MapInfo MapInfoMapInfoID = (from c in db.MapInfos where c.MapInfoID == mapInfoPoint.MapInfoID select c).FirstOrDefault();

            if (MapInfoMapInfoID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MapInfo, ModelsRes.MapInfoPointMapInfoID, mapInfoPoint.MapInfoID.ToString()), new[] { "MapInfoID" });
            }

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfoPoint.Ordinal < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointOrdinal, "0"), new[] { "Ordinal" });
            }

            //Lat (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfoPoint.Lat < -90 || mapInfoPoint.Lat > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLat, "-90", "90"), new[] { "Lat" });
            }

            //Lng (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfoPoint.Lng < -180 || mapInfoPoint.Lng > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLng, "-180", "180"), new[] { "Lng" });
            }

            if (mapInfoPoint.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoPointLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mapInfoPoint.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MapInfoPointLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mapInfoPoint.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MapInfoPointLastUpdateContactTVItemID, mapInfoPoint.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MapInfoPointLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
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
