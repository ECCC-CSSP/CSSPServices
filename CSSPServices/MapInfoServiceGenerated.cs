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
    public partial class MapInfoService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            MapInfo mapInfo = validationContext.ObjectInstance as MapInfo;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mapInfo.MapInfoID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoMapInfoID), new[] { ModelsRes.MapInfoMapInfoID });
                }
            }

            //TVItemID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.TVTypeOK(mapInfo.TVType);
            if (mapInfo.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoTVType), new[] { ModelsRes.MapInfoTVType });
            }

            //LatMin (float) is required but no testing needed as it is automatically set to 0.0f

            //LatMax (float) is required but no testing needed as it is automatically set to 0.0f

            //LngMin (float) is required but no testing needed as it is automatically set to 0.0f

            //LngMax (float) is required but no testing needed as it is automatically set to 0.0f

            retStr = enums.MapInfoDrawTypeOK(mapInfo.MapInfoDrawType);
            if (mapInfo.MapInfoDrawType == MapInfoDrawTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoMapInfoDrawType), new[] { ModelsRes.MapInfoMapInfoDrawType });
            }

            if (mapInfo.LastUpdateDate_UTC == null || mapInfo.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoLastUpdateDate_UTC), new[] { ModelsRes.MapInfoLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (mapInfo.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoTVItemID, "1"), new[] { ModelsRes.MapInfoTVItemID });
            }

            if (mapInfo.LatMin < -90 || mapInfo.LatMin > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMin, "-90", "90"), new[] { ModelsRes.MapInfoLatMin });
            }

            if (mapInfo.LatMax < -90 || mapInfo.LatMax > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMax, "-90", "90"), new[] { ModelsRes.MapInfoLatMax });
            }

            if (mapInfo.LngMin < -180 || mapInfo.LngMin > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMin, "-180", "180"), new[] { ModelsRes.MapInfoLngMin });
            }

            if (mapInfo.LngMax < -180 || mapInfo.LngMax > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMax, "-180", "180"), new[] { ModelsRes.MapInfoLngMax });
            }

            if (mapInfo.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MapInfoLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(MapInfo mapInfo)
        {
            mapInfo.ValidationResults = Validate(new ValidationContext(mapInfo), ActionDBTypeEnum.Create);
            if (mapInfo.ValidationResults.Count() > 0) return false;

            db.MapInfos.Add(mapInfo);

            if (!TryToSave(mapInfo)) return false;

            return true;
        }
        public bool AddRange(List<MapInfo> mapInfoList)
        {
            foreach (MapInfo mapInfo in mapInfoList)
            {
                mapInfo.ValidationResults = Validate(new ValidationContext(mapInfo), ActionDBTypeEnum.Create);
                if (mapInfo.ValidationResults.Count() > 0) return false;
            }

            db.MapInfos.AddRange(mapInfoList);

            if (!TryToSaveRange(mapInfoList)) return false;

            return true;
        }
        public bool Delete(MapInfo mapInfo)
        {
            if (!db.MapInfos.Where(c => c.MapInfoID == mapInfo.MapInfoID).Any())
            {
                mapInfo.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoID", mapInfo.MapInfoID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MapInfos.Remove(mapInfo);

            if (!TryToSave(mapInfo)) return false;

            return true;
        }
        public bool DeleteRange(List<MapInfo> mapInfoList)
        {
            foreach (MapInfo mapInfo in mapInfoList)
            {
                if (!db.MapInfos.Where(c => c.MapInfoID == mapInfo.MapInfoID).Any())
                {
                    mapInfoList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoID", mapInfo.MapInfoID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MapInfos.RemoveRange(mapInfoList);

            if (!TryToSaveRange(mapInfoList)) return false;

            return true;
        }
        public bool Update(MapInfo mapInfo)
        {
            mapInfo.ValidationResults = Validate(new ValidationContext(mapInfo), ActionDBTypeEnum.Update);
            if (mapInfo.ValidationResults.Count() > 0) return false;

            db.MapInfos.Update(mapInfo);

            if (!TryToSave(mapInfo)) return false;

            return true;
        }
        public bool UpdateRange(List<MapInfo> mapInfoList)
        {
            foreach (MapInfo mapInfo in mapInfoList)
            {
                mapInfo.ValidationResults = Validate(new ValidationContext(mapInfo), ActionDBTypeEnum.Update);
                if (mapInfo.ValidationResults.Count() > 0) return false;
            }
            db.MapInfos.UpdateRange(mapInfoList);

            if (!TryToSaveRange(mapInfoList)) return false;

            return true;
        }
        public IQueryable<MapInfo> GetRead()
        {
            return db.MapInfos.AsNoTracking();
        }
        public IQueryable<MapInfo> GetEdit()
        {
            return db.MapInfos;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(MapInfo mapInfo)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mapInfo.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MapInfo> mapInfoList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mapInfoList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
