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
        #endregion Properties

        #region Constructors
        public MapInfoService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MapInfo mapInfo = validationContext.ObjectInstance as MapInfo;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mapInfo.MapInfoID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoMapInfoID), new[] { "MapInfoID" });
                }
            }

            //MapInfoID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == mapInfo.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MapInfoTVItemID, mapInfo.TVItemID.ToString()), new[] { "TVItemID" });
            }
            else
            {
                if (TVItemTVItemID.TVType != TVTypeEnum.Error)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MapInfoTVItemID, "Error"), new[] { "TVItemID" });
                }
            }

            retStr = enums.TVTypeOK(mapInfo.TVType);
            if (mapInfo.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoTVType), new[] { "TVType" });
            }

            //LatMin (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfo.LatMin < -90 || mapInfo.LatMin > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMin, "-90", "90"), new[] { "LatMin" });
            }

            //LatMax (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfo.LatMax < -90 || mapInfo.LatMax > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMax, "-90", "90"), new[] { "LatMax" });
            }

            //LngMin (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfo.LngMin < -180 || mapInfo.LngMin > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMin, "-180", "180"), new[] { "LngMin" });
            }

            //LngMax (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mapInfo.LngMax < -180 || mapInfo.LngMax > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMax, "-180", "180"), new[] { "LngMax" });
            }

            retStr = enums.MapInfoDrawTypeOK(mapInfo.MapInfoDrawType);
            if (mapInfo.MapInfoDrawType == MapInfoDrawTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoMapInfoDrawType), new[] { "MapInfoDrawType" });
            }

            if (mapInfo.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mapInfo.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MapInfoLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mapInfo.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MapInfoLastUpdateContactTVItemID, mapInfo.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MapInfoLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
