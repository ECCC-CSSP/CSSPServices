using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class MapInfoServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MapInfoService mapInfoService { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoServiceTest() : base()
        {
            //mapInfoService = new MapInfoService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MapInfo GetFilledRandomMapInfo(string OmitPropName)
        {
            MapInfo mapInfo = new MapInfo();

            if (OmitPropName != "TVItemID") mapInfo.TVItemID = 1;
            if (OmitPropName != "TVType") mapInfo.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LatMin") mapInfo.LatMin = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "LatMax") mapInfo.LatMax = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "LngMin") mapInfo.LngMin = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LngMax") mapInfo.LngMax = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "MapInfoDrawType") mapInfo.MapInfoDrawType = (MapInfoDrawTypeEnum)GetRandomEnumType(typeof(MapInfoDrawTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mapInfo.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfo.LastUpdateContactTVItemID = 2;

            return mapInfo;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MapInfo_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoService mapInfoService = new MapInfoService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MapInfo mapInfo = GetFilledRandomMapInfo("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mapInfoService.GetRead().Count();

                    Assert.AreEqual(mapInfoService.GetRead().Count(), mapInfoService.GetEdit().Count());

                    mapInfoService.Add(mapInfo);
                    if (mapInfo.HasErrors)
                    {
                        Assert.AreEqual("", mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mapInfoService.GetRead().Where(c => c == mapInfo).Any());
                    mapInfoService.Update(mapInfo);
                    if (mapInfo.HasErrors)
                    {
                        Assert.AreEqual("", mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mapInfoService.GetRead().Count());
                    mapInfoService.Delete(mapInfo);
                    if (mapInfo.HasErrors)
                    {
                        Assert.AreEqual("", mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mapInfo.MapInfoID   (Int32)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.MapInfoID = 0;
                    mapInfoService.Update(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoMapInfoID), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.MapInfoID = 10000000;
                    mapInfoService.Update(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MapInfo, CSSPModelsRes.MapInfoMapInfoID, mapInfo.MapInfoID.ToString()), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow,Classification,Approved,Restricted,Prohibited,ConditionallyApproved,ConditionallyRestricted)]
                    // mapInfo.TVItemID   (Int32)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.TVItemID = 0;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MapInfoTVItemID, mapInfo.TVItemID.ToString()), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.TVItemID = 2;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MapInfoTVItemID, "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow,Classification,Approved,Restricted,Prohibited,ConditionallyApproved,ConditionallyRestricted"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mapInfo.TVType   (TVTypeEnum)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.TVType = (TVTypeEnum)1000000;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoTVType), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-90, 90)]
                    // mapInfo.LatMin   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LatMin]

                    //Error: Type not implemented [LatMin]

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LatMin = -91.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLatMin, "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LatMin = 91.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLatMin, "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-90, 90)]
                    // mapInfo.LatMax   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LatMax]

                    //Error: Type not implemented [LatMax]

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LatMax = -91.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLatMax, "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LatMax = 91.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLatMax, "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-180, 180)]
                    // mapInfo.LngMin   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LngMin]

                    //Error: Type not implemented [LngMin]

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LngMin = -181.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLngMin, "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LngMin = 181.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLngMin, "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-180, 180)]
                    // mapInfo.LngMax   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LngMax]

                    //Error: Type not implemented [LngMax]

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LngMax = -181.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLngMax, "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LngMax = 181.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoLngMax, "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mapInfo.MapInfoDrawType   (MapInfoDrawTypeEnum)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.MapInfoDrawType = (MapInfoDrawTypeEnum)1000000;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoMapInfoDrawType), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mapInfo.MapInfoWeb   (MapInfoWeb)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.MapInfoWeb = null;
                    Assert.IsNull(mapInfo.MapInfoWeb);

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.MapInfoWeb = new MapInfoWeb();
                    Assert.IsNotNull(mapInfo.MapInfoWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mapInfo.MapInfoReport   (MapInfoReport)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.MapInfoReport = null;
                    Assert.IsNull(mapInfo.MapInfoReport);

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.MapInfoReport = new MapInfoReport();
                    Assert.IsNotNull(mapInfo.MapInfoReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mapInfo.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LastUpdateDate_UTC = new DateTime();
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoLastUpdateDate_UTC), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MapInfoLastUpdateDate_UTC, "1980"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mapInfo.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LastUpdateContactTVItemID = 0;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MapInfoLastUpdateContactTVItemID, mapInfo.LastUpdateContactTVItemID.ToString()), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LastUpdateContactTVItemID = 1;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MapInfoLastUpdateContactTVItemID, "Contact"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mapInfo.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mapInfo.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMapInfoWithMapInfoID(mapInfo.MapInfoID)
        [TestMethod]
        public void GetMapInfoWithMapInfoID__mapInfo_MapInfoID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoService mapInfoService = new MapInfoService(new GetParam(), dbTestDB, ContactID);
                    MapInfo mapInfo = (from c in mapInfoService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfo);

                    MapInfo mapInfoRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mapInfoService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mapInfoRet = mapInfoService.GetMapInfoWithMapInfoID(mapInfo.MapInfoID);
                            Assert.IsNull(mapInfoRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mapInfoRet = mapInfoService.GetMapInfoWithMapInfoID(mapInfo.MapInfoID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mapInfoRet = mapInfoService.GetMapInfoWithMapInfoID(mapInfo.MapInfoID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mapInfoRet = mapInfoService.GetMapInfoWithMapInfoID(mapInfo.MapInfoID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MapInfo fields
                        Assert.IsNotNull(mapInfoRet.MapInfoID);
                        Assert.IsNotNull(mapInfoRet.TVItemID);
                        Assert.IsNotNull(mapInfoRet.TVType);
                        Assert.IsNotNull(mapInfoRet.LatMin);
                        Assert.IsNotNull(mapInfoRet.LatMax);
                        Assert.IsNotNull(mapInfoRet.LngMin);
                        Assert.IsNotNull(mapInfoRet.LngMax);
                        Assert.IsNotNull(mapInfoRet.MapInfoDrawType);
                        Assert.IsNotNull(mapInfoRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mapInfoRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MapInfoWeb and MapInfoReport fields should be null here
                            Assert.IsNull(mapInfoRet.MapInfoWeb);
                            Assert.IsNull(mapInfoRet.MapInfoReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MapInfoWeb fields should not be null and MapInfoReport fields should be null here
                            if (mapInfoRet.MapInfoWeb.TVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoRet.MapInfoWeb.TVText));
                            }
                            if (mapInfoRet.MapInfoWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoRet.MapInfoWeb.LastUpdateContactTVText));
                            }
                            if (mapInfoRet.MapInfoWeb.TVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoRet.MapInfoWeb.TVTypeText));
                            }
                            if (mapInfoRet.MapInfoWeb.MapInfoDrawTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoRet.MapInfoWeb.MapInfoDrawTypeText));
                            }
                            Assert.IsNull(mapInfoRet.MapInfoReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MapInfoWeb and MapInfoReport fields should NOT be null here
                            if (mapInfoRet.MapInfoWeb.TVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoRet.MapInfoWeb.TVText));
                            }
                            if (mapInfoRet.MapInfoWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoRet.MapInfoWeb.LastUpdateContactTVText));
                            }
                            if (mapInfoRet.MapInfoWeb.TVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoRet.MapInfoWeb.TVTypeText));
                            }
                            if (mapInfoRet.MapInfoWeb.MapInfoDrawTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoRet.MapInfoWeb.MapInfoDrawTypeText));
                            }
                            if (mapInfoRet.MapInfoReport.MapInfoReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoRet.MapInfoReport.MapInfoReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoWithMapInfoID(mapInfo.MapInfoID)

        #region Tests Generated for GetMapInfoList()
        [TestMethod]
        public void GetMapInfoList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoService mapInfoService = new MapInfoService(new GetParam(), dbTestDB, ContactID);
                    MapInfo mapInfo = (from c in mapInfoService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfo);

                    List<MapInfo> mapInfoList = new List<MapInfo>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mapInfoService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            Assert.AreEqual(0, mapInfoList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MapInfo fields
                        Assert.IsNotNull(mapInfoList[0].MapInfoID);
                        Assert.IsNotNull(mapInfoList[0].TVItemID);
                        Assert.IsNotNull(mapInfoList[0].TVType);
                        Assert.IsNotNull(mapInfoList[0].LatMin);
                        Assert.IsNotNull(mapInfoList[0].LatMax);
                        Assert.IsNotNull(mapInfoList[0].LngMin);
                        Assert.IsNotNull(mapInfoList[0].LngMax);
                        Assert.IsNotNull(mapInfoList[0].MapInfoDrawType);
                        Assert.IsNotNull(mapInfoList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(mapInfoList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MapInfoWeb and MapInfoReport fields should be null here
                            Assert.IsNull(mapInfoList[0].MapInfoWeb);
                            Assert.IsNull(mapInfoList[0].MapInfoReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MapInfoWeb fields should not be null and MapInfoReport fields should be null here
                            if (mapInfoList[0].MapInfoWeb.TVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoList[0].MapInfoWeb.TVText));
                            }
                            if (mapInfoList[0].MapInfoWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoList[0].MapInfoWeb.LastUpdateContactTVText));
                            }
                            if (mapInfoList[0].MapInfoWeb.TVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoList[0].MapInfoWeb.TVTypeText));
                            }
                            if (mapInfoList[0].MapInfoWeb.MapInfoDrawTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoList[0].MapInfoWeb.MapInfoDrawTypeText));
                            }
                            Assert.IsNull(mapInfoList[0].MapInfoReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MapInfoWeb and MapInfoReport fields should NOT be null here
                            if (mapInfoList[0].MapInfoWeb.TVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoList[0].MapInfoWeb.TVText));
                            }
                            if (mapInfoList[0].MapInfoWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoList[0].MapInfoWeb.LastUpdateContactTVText));
                            }
                            if (mapInfoList[0].MapInfoWeb.TVTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoList[0].MapInfoWeb.TVTypeText));
                            }
                            if (mapInfoList[0].MapInfoWeb.MapInfoDrawTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoList[0].MapInfoWeb.MapInfoDrawTypeText));
                            }
                            if (mapInfoList[0].MapInfoReport.MapInfoReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoList[0].MapInfoReport.MapInfoReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoList()

        #region Tests Generated for GetMapInfoList() Skip Take
        [TestMethod]
        public void GetMapInfoList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MapInfo> mapInfoList = new List<MapInfo>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(MapInfo), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        MapInfoService mapInfoService = new MapInfoService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            Assert.AreEqual(0, mapInfoList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, mapInfoList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoList() Skip Take

    }
}
