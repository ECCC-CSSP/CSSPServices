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
    ///     <para>bonjour MapInfo</para>
    /// </summary>
    public partial class MapInfoService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MapInfoService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MapInfo mapInfo = validationContext.ObjectInstance as MapInfo;
            mapInfo.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mapInfo.MapInfoID == 0)
                {
                    mapInfo.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoMapInfoID), new[] { "MapInfoID" });
                }

                if (!GetRead().Where(c => c.MapInfoID == mapInfo.MapInfoID).Any())
                {
                    mapInfo.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MapInfo, CSSPModelsRes.MapInfoMapInfoID, mapInfo.MapInfoID.ToString()), new[] { "MapInfoID" });
                }
            }

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == mapInfo.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MapInfoTVItemID, mapInfo.TVItemID.ToString()), new[] { "TVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Root,
                    TVTypeEnum.Address,
                    TVTypeEnum.Area,
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.Country,
                    TVTypeEnum.File,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.MikeBoundaryConditionWebTide,
                    TVTypeEnum.MikeBoundaryConditionMesh,
                    TVTypeEnum.MikeSource,
                    TVTypeEnum.Municipality,
                    TVTypeEnum.MWQMSite,
                    TVTypeEnum.PolSourceSite,
                    TVTypeEnum.Province,
                    TVTypeEnum.Sector,
                    TVTypeEnum.Subsector,
                    TVTypeEnum.TideSite,
                    TVTypeEnum.WasteWaterTreatmentPlant,
                    TVTypeEnum.LiftStation,
                    TVTypeEnum.Spill,
                    TVTypeEnum.Outfall,
                    TVTypeEnum.OtherInfrastructure,
                    TVTypeEnum.SeeOther,
                    TVTypeEnum.LineOverflow,
                    TVTypeEnum.Classification,
                    TVTypeEnum.Approved,
                    TVTypeEnum.Restricted,
                    TVTypeEnum.Prohibited,
                    TVTypeEnum.ConditionallyApproved,
                    TVTypeEnum.ConditionallyRestricted,
                };
                if (!AllowableTVTypes.Contains(TVItemTVItemID.TVType))
                {
                    mapInfo.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MapInfoTVItemID, "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow,Classification,Approved,Restricted,Prohibited,ConditionallyApproved,ConditionallyRestricted"), new[] { "TVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mapInfo.TVType);
            if (mapInfo.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoTVType), new[] { "TVType" });
            }

            if (mapInfo.LatMin < -90 || mapInfo.LatMin > 90)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLatMin, "-90", "90"), new[] { "LatMin" });
            }

            if (mapInfo.LatMax < -90 || mapInfo.LatMax > 90)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLatMax, "-90", "90"), new[] { "LatMax" });
            }

            if (mapInfo.LngMin < -180 || mapInfo.LngMin > 180)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLngMin, "-180", "180"), new[] { "LngMin" });
            }

            if (mapInfo.LngMax < -180 || mapInfo.LngMax > 180)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLngMax, "-180", "180"), new[] { "LngMax" });
            }

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)mapInfo.MapInfoDrawType);
            if (mapInfo.MapInfoDrawType == MapInfoDrawTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoMapInfoDrawType), new[] { "MapInfoDrawType" });
            }

            if (mapInfo.LastUpdateDate_UTC.Year == 1)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mapInfo.LastUpdateDate_UTC.Year < 1980)
                {
                mapInfo.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MapInfoLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mapInfo.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MapInfoLastUpdateContactTVItemID, mapInfo.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mapInfo.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MapInfoLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MapInfo GetMapInfoWithMapInfoID(int MapInfoID)
        {
            IQueryable<MapInfo> mapInfoQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MapInfoID == MapInfoID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mapInfoQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillMapInfoWeb(mapInfoQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMapInfoReport(mapInfoQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MapInfo> GetMapInfoList()
        {
            IQueryable<MapInfo> mapInfoQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        mapInfoQuery = EnhanceQueryStatements<MapInfo>(mapInfoQuery) as IQueryable<MapInfo>;

                        return mapInfoQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        mapInfoQuery = FillMapInfoWeb(mapInfoQuery);

                        mapInfoQuery = EnhanceQueryStatements<MapInfo>(mapInfoQuery) as IQueryable<MapInfo>;

                        return mapInfoQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        mapInfoQuery = FillMapInfoReport(mapInfoQuery);

                        mapInfoQuery = EnhanceQueryStatements<MapInfo>(mapInfoQuery) as IQueryable<MapInfo>;

                        return mapInfoQuery;
                    }
                default:
                    {
                        mapInfoQuery = mapInfoQuery.Where(c => c.MapInfoID == 0);

                        return mapInfoQuery;
                    }
            }
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
            mapInfo.ValidationResults = Validate(new ValidationContext(mapInfo), ActionDBTypeEnum.Delete);
            if (mapInfo.ValidationResults.Count() > 0) return false;

            db.MapInfos.Remove(mapInfo);

            if (!TryToSave(mapInfo)) return false;

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
        public IQueryable<MapInfo> GetRead()
        {
            IQueryable<MapInfo> mapInfoQuery = db.MapInfos.AsNoTracking();

            return mapInfoQuery;
        }
        public IQueryable<MapInfo> GetEdit()
        {
            IQueryable<MapInfo> mapInfoQuery = db.MapInfos;

            return mapInfoQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MapInfoFillWeb
        private IQueryable<MapInfo> FillMapInfoWeb(IQueryable<MapInfo> mapInfoQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> MapInfoDrawTypeEnumList = enums.GetEnumTextOrderedList(typeof(MapInfoDrawTypeEnum));

            mapInfoQuery = (from c in mapInfoQuery
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
                        MapInfoWeb = new MapInfoWeb
                        {
                            TVText = TVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                            MapInfoDrawTypeText = (from e in MapInfoDrawTypeEnumList
                                where e.EnumID == (int?)c.MapInfoDrawType
                                select e.EnumText).FirstOrDefault(),
                        },
                        MapInfoReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mapInfoQuery;
        }
        #endregion Functions private Generated MapInfoFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
