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
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Country,
                    TVTypeEnum.Province,
                    TVTypeEnum.Area,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.Infrastructure,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeScenario,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMRun,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.MWQMSiteSample,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.SamplingPlan,
                    TVTypeEnum.Spill,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.VisualPlumesScenario,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.LineOverflow,
                    TVTypeEnum.MeshNode,
                    TVTypeEnum.MikeSourceIncluded,
                    TVTypeEnum.MikeSourceIsRiver,
                    TVTypeEnum.MikeSourceNotIncluded,
                    TVTypeEnum.NoData,
                    TVTypeEnum.NoDepuration,
                    TVTypeEnum.Outfall,
                    TVTypeEnum.Passed,
                    TVTypeEnum.WebTideNode,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MapInfoTVItemID, "Root,Address,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite,VisualPlumesScenario,LiftStation,LineOverflow,MeshNode,MikeSourceIncluded,MikeSourceIsRiver,MikeSourceNotIncluded,NoData,NoDepuration,Outfall,Passed,WebTideNode"), new[] { "TVItemID" });
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
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MapInfoLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mapInfo.TVText) && mapInfo.TVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MapInfoTVText, "200"), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(mapInfo.LastUpdateContactTVText) && mapInfo.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MapInfoLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mapInfo.TVTypeText) && mapInfo.TVTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MapInfoTVTypeText, "100"), new[] { "TVTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(mapInfo.MapInfoDrawTypeText) && mapInfo.MapInfoDrawTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MapInfoMapInfoDrawTypeText, "100"), new[] { "MapInfoDrawTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MapInfo GetMapInfoWithMapInfoID(int MapInfoID)
        {
            IQueryable<MapInfo> mapInfoQuery = (from c in GetRead()
                                                where c.MapInfoID == MapInfoID
                                                select c);

            return FillMapInfo(mapInfoQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MapInfo mapInfo)
        {
            mapInfo.ValidationResults = Validate(new ValidationContext(mapInfo), ActionDBTypeEnum.Create);
            if (mapInfo.ValidationResults.Count() > 0) return false;

            db.MapInfos.Add(mapInfo);

            if (!TryToSave(mapInfo)) return false;

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
        public bool Update(MapInfo mapInfo)
        {
            if (!db.MapInfos.Where(c => c.MapInfoID == mapInfo.MapInfoID).Any())
            {
                mapInfo.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoID", mapInfo.MapInfoID.ToString())) }.AsEnumerable();
                return false;
            }

            mapInfo.ValidationResults = Validate(new ValidationContext(mapInfo), ActionDBTypeEnum.Update);
            if (mapInfo.ValidationResults.Count() > 0) return false;

            db.MapInfos.Update(mapInfo);

            if (!TryToSave(mapInfo)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MapInfo> FillMapInfo(IQueryable<MapInfo> mapInfoQuery)
        {
            List<MapInfo> MapInfoList = (from c in mapInfoQuery
                                         let TVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.TVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MapInfo
                                         {
                                             MapInfoID = c.MapInfoID,
                                             TVItemID = c.TVItemID,
                                             TVType = c.TVType,
                                             LatMin = c.LatMin,
                                             LatMax = c.LatMax,
                                             LngMin = c.LngMin,
                                             LngMax = c.LngMax,
                                             MapInfoDrawType = c.MapInfoDrawType,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             TVText = TVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (MapInfo mapInfo in MapInfoList)
            {
                mapInfo.TVTypeText = enums.GetEnumText_TVTypeEnum(mapInfo.TVType);
                mapInfo.MapInfoDrawTypeText = enums.GetEnumText_MapInfoDrawTypeEnum(mapInfo.MapInfoDrawType);
            }

            return MapInfoList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
