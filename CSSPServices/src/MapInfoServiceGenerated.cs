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
        public MapInfoService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MapInfoMapInfoID"), new[] { "MapInfoID" });
                }

                if (!(from c in db.MapInfos select c).Where(c => c.MapInfoID == mapInfo.MapInfoID).Any())
                {
                    mapInfo.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoMapInfoID", mapInfo.MapInfoID.ToString()), new[] { "MapInfoID" });
                }
            }

            TVItem TVItemTVItemID = (from c in db.TVItems where c.TVItemID == mapInfo.TVItemID select c).FirstOrDefault();

            if (TVItemTVItemID == null)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MapInfoTVItemID", mapInfo.TVItemID.ToString()), new[] { "TVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MapInfoTVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow,Classification,Approved,Restricted,Prohibited,ConditionallyApproved,ConditionallyRestricted"), new[] { "TVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mapInfo.TVType);
            if (mapInfo.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MapInfoTVType"), new[] { "TVType" });
            }

            if (mapInfo.LatMin < -90 || mapInfo.LatMin > 90)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLatMin", "-90", "90"), new[] { "LatMin" });
            }

            if (mapInfo.LatMax < -90 || mapInfo.LatMax > 90)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLatMax", "-90", "90"), new[] { "LatMax" });
            }

            if (mapInfo.LngMin < -180 || mapInfo.LngMin > 180)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLngMin", "-180", "180"), new[] { "LngMin" });
            }

            if (mapInfo.LngMax < -180 || mapInfo.LngMax > 180)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLngMax", "-180", "180"), new[] { "LngMax" });
            }

            retStr = enums.EnumTypeOK(typeof(MapInfoDrawTypeEnum), (int?)mapInfo.MapInfoDrawType);
            if (mapInfo.MapInfoDrawType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MapInfoMapInfoDrawType"), new[] { "MapInfoDrawType" });
            }

            if (mapInfo.LastUpdateDate_UTC.Year == 1)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MapInfoLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mapInfo.LastUpdateDate_UTC.Year < 1980)
                {
                mapInfo.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MapInfoLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mapInfo.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mapInfo.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MapInfoLastUpdateContactTVItemID", mapInfo.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MapInfoLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            return (from c in db.MapInfos
                    where c.MapInfoID == MapInfoID
                    select c).FirstOrDefault();

        }
        public IQueryable<MapInfo> GetMapInfoList()
        {
            IQueryable<MapInfo> MapInfoQuery = (from c in db.MapInfos select c);

            MapInfoQuery = EnhanceQueryStatements<MapInfo>(MapInfoQuery) as IQueryable<MapInfo>;

            return MapInfoQuery;
        }
        public MapInfo_A GetMapInfo_AWithMapInfoID(int MapInfoID)
        {
            return FillMapInfo_A().Where(c => c.MapInfoID == MapInfoID).FirstOrDefault();

        }
        public IQueryable<MapInfo_A> GetMapInfo_AList()
        {
            IQueryable<MapInfo_A> MapInfo_AQuery = FillMapInfo_A();

            MapInfo_AQuery = EnhanceQueryStatements<MapInfo_A>(MapInfo_AQuery) as IQueryable<MapInfo_A>;

            return MapInfo_AQuery;
        }
        public MapInfo_B GetMapInfo_BWithMapInfoID(int MapInfoID)
        {
            return FillMapInfo_B().Where(c => c.MapInfoID == MapInfoID).FirstOrDefault();

        }
        public IQueryable<MapInfo_B> GetMapInfo_BList()
        {
            IQueryable<MapInfo_B> MapInfo_BQuery = FillMapInfo_B();

            MapInfo_BQuery = EnhanceQueryStatements<MapInfo_B>(MapInfo_BQuery) as IQueryable<MapInfo_B>;

            return MapInfo_BQuery;
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
        #endregion Functions public Generated CRUD

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
