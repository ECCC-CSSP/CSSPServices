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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MapInfo_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MapInfoMapInfoID"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.MapInfoID = 10000000;
                    mapInfoService.Update(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoMapInfoID", mapInfo.MapInfoID.ToString()), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow,Classification,Approved,Restricted,Prohibited,ConditionallyApproved,ConditionallyRestricted)]
                    // mapInfo.TVItemID   (Int32)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.TVItemID = 0;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MapInfoTVItemID", mapInfo.TVItemID.ToString()), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.TVItemID = 2;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MapInfoTVItemID", "Root,Address,Area,ClimateSite,Country,File,HydrometricSite,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,Outfall,OtherInfrastructure,SeeOther,LineOverflow,Classification,Approved,Restricted,Prohibited,ConditionallyApproved,ConditionallyRestricted"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mapInfo.TVType   (TVTypeEnum)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.TVType = (TVTypeEnum)1000000;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MapInfoTVType"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLatMin", "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LatMin = 91.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLatMin", "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLatMax", "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LatMax = 91.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLatMax", "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLngMin", "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LngMin = 181.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLngMin", "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLngMax", "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetRead().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LngMax = 181.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLngMax", "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MapInfoMapInfoDrawType"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mapInfo.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LastUpdateDate_UTC = new DateTime();
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MapInfoLastUpdateDate_UTC"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MapInfoLastUpdateDate_UTC", "1980"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mapInfo.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LastUpdateContactTVItemID = 0;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MapInfoLastUpdateContactTVItemID", mapInfo.LastUpdateContactTVItemID.ToString()), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LastUpdateContactTVItemID = 1;
                    mapInfoService.Add(mapInfo);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MapInfoLastUpdateContactTVItemID", "Contact"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MapInfo mapInfo = (from c in mapInfoService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfo);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mapInfoService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            MapInfo mapInfoRet = mapInfoService.GetMapInfoWithMapInfoID(mapInfo.MapInfoID);
                            CheckMapInfoFields(new List<MapInfo>() { mapInfoRet });
                            Assert.AreEqual(mapInfo.MapInfoID, mapInfoRet.MapInfoID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            MapInfoWeb mapInfoWebRet = mapInfoService.GetMapInfoWebWithMapInfoID(mapInfo.MapInfoID);
                            CheckMapInfoWebFields(new List<MapInfoWeb>() { mapInfoWebRet });
                            Assert.AreEqual(mapInfo.MapInfoID, mapInfoWebRet.MapInfoID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            MapInfoReport mapInfoReportRet = mapInfoService.GetMapInfoReportWithMapInfoID(mapInfo.MapInfoID);
                            CheckMapInfoReportFields(new List<MapInfoReport>() { mapInfoReportRet });
                            Assert.AreEqual(mapInfo.MapInfoID, mapInfoReportRet.MapInfoID);
                        }
                        else
                        {
                            // nothing for now
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
                    MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MapInfo mapInfo = (from c in mapInfoService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfo);

                    List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                    mapInfoDirectQueryList = mapInfoService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mapInfoService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoWeb> mapInfoWebList = new List<MapInfoWeb>();
                            mapInfoWebList = mapInfoService.GetMapInfoWebList().ToList();
                            CheckMapInfoWebFields(mapInfoWebList);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoReport> mapInfoReportList = new List<MapInfoReport>();
                            mapInfoReportList = mapInfoService.GetMapInfoReportList().ToList();
                            CheckMapInfoReportFields(mapInfoReportList);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoReportList.Count);
                        }
                        else
                        {
                            // nothing for now
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = mapInfoService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoWeb> mapInfoWebList = new List<MapInfoWeb>();
                            mapInfoWebList = mapInfoService.GetMapInfoWebList().ToList();
                            CheckMapInfoWebFields(mapInfoWebList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoWebList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoReport> mapInfoReportList = new List<MapInfoReport>();
                            mapInfoReportList = mapInfoService.GetMapInfoReportList().ToList();
                            CheckMapInfoReportFields(mapInfoReportList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoReportList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoList() Skip Take

        #region Tests Generated for GetMapInfoList() Skip Take Order
        [TestMethod]
        public void GetMapInfoList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 1, 1,  "MapInfoID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = mapInfoService.GetRead().Skip(1).Take(1).OrderBy(c => c.MapInfoID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoWeb> mapInfoWebList = new List<MapInfoWeb>();
                            mapInfoWebList = mapInfoService.GetMapInfoWebList().ToList();
                            CheckMapInfoWebFields(mapInfoWebList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoWebList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoReport> mapInfoReportList = new List<MapInfoReport>();
                            mapInfoReportList = mapInfoService.GetMapInfoReportList().ToList();
                            CheckMapInfoReportFields(mapInfoReportList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoReportList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoList() Skip Take Order

        #region Tests Generated for GetMapInfoList() Skip Take 2Order
        [TestMethod]
        public void GetMapInfoList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 1, 1, "MapInfoID,TVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = mapInfoService.GetRead().Skip(1).Take(1).OrderBy(c => c.MapInfoID).ThenBy(c => c.TVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoWeb> mapInfoWebList = new List<MapInfoWeb>();
                            mapInfoWebList = mapInfoService.GetMapInfoWebList().ToList();
                            CheckMapInfoWebFields(mapInfoWebList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoWebList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoReport> mapInfoReportList = new List<MapInfoReport>();
                            mapInfoReportList = mapInfoService.GetMapInfoReportList().ToList();
                            CheckMapInfoReportFields(mapInfoReportList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoReportList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoList() Skip Take 2Order

        #region Tests Generated for GetMapInfoList() Skip Take Order Where
        [TestMethod]
        public void GetMapInfoList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 0, 1, "MapInfoID", "MapInfoID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = mapInfoService.GetRead().Where(c => c.MapInfoID == 4).Skip(0).Take(1).OrderBy(c => c.MapInfoID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoWeb> mapInfoWebList = new List<MapInfoWeb>();
                            mapInfoWebList = mapInfoService.GetMapInfoWebList().ToList();
                            CheckMapInfoWebFields(mapInfoWebList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoWebList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoReport> mapInfoReportList = new List<MapInfoReport>();
                            mapInfoReportList = mapInfoService.GetMapInfoReportList().ToList();
                            CheckMapInfoReportFields(mapInfoReportList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoReportList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoList() Skip Take Order Where

        #region Tests Generated for GetMapInfoList() Skip Take Order 2Where
        [TestMethod]
        public void GetMapInfoList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 0, 1, "MapInfoID", "MapInfoID,GT,2|MapInfoID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = mapInfoService.GetRead().Where(c => c.MapInfoID > 2 && c.MapInfoID < 5).Skip(0).Take(1).OrderBy(c => c.MapInfoID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoWeb> mapInfoWebList = new List<MapInfoWeb>();
                            mapInfoWebList = mapInfoService.GetMapInfoWebList().ToList();
                            CheckMapInfoWebFields(mapInfoWebList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoWebList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoReport> mapInfoReportList = new List<MapInfoReport>();
                            mapInfoReportList = mapInfoService.GetMapInfoReportList().ToList();
                            CheckMapInfoReportFields(mapInfoReportList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoReportList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoList() Skip Take Order 2Where

        #region Tests Generated for GetMapInfoList() 2Where
        [TestMethod]
        public void GetMapInfoList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 0, 10000, "", "MapInfoID,GT,2|MapInfoID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = mapInfoService.GetRead().Where(c => c.MapInfoID > 2 && c.MapInfoID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoWeb> mapInfoWebList = new List<MapInfoWeb>();
                            mapInfoWebList = mapInfoService.GetMapInfoWebList().ToList();
                            CheckMapInfoWebFields(mapInfoWebList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoWebList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoReport> mapInfoReportList = new List<MapInfoReport>();
                            mapInfoReportList = mapInfoService.GetMapInfoReportList().ToList();
                            CheckMapInfoReportFields(mapInfoReportList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoReportList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoList() 2Where

        #region Functions private
        private void CheckMapInfoFields(List<MapInfo> mapInfoList)
        {
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
            Assert.IsNotNull(mapInfoList[0].HasErrors);
        }
        private void CheckMapInfoWebFields(List<MapInfoWeb> mapInfoWebList)
        {
            Assert.IsNotNull(mapInfoWebList[0].TVItemLanguage);
            Assert.IsNotNull(mapInfoWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mapInfoWebList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoWebList[0].TVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(mapInfoWebList[0].MapInfoDrawTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoWebList[0].MapInfoDrawTypeText));
            }
            Assert.IsNotNull(mapInfoWebList[0].MapInfoID);
            Assert.IsNotNull(mapInfoWebList[0].TVItemID);
            Assert.IsNotNull(mapInfoWebList[0].TVType);
            Assert.IsNotNull(mapInfoWebList[0].LatMin);
            Assert.IsNotNull(mapInfoWebList[0].LatMax);
            Assert.IsNotNull(mapInfoWebList[0].LngMin);
            Assert.IsNotNull(mapInfoWebList[0].LngMax);
            Assert.IsNotNull(mapInfoWebList[0].MapInfoDrawType);
            Assert.IsNotNull(mapInfoWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mapInfoWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mapInfoWebList[0].HasErrors);
        }
        private void CheckMapInfoReportFields(List<MapInfoReport> mapInfoReportList)
        {
            if (!string.IsNullOrWhiteSpace(mapInfoReportList[0].MapInfoReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoReportList[0].MapInfoReportTest));
            }
            Assert.IsNotNull(mapInfoReportList[0].TVItemLanguage);
            Assert.IsNotNull(mapInfoReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mapInfoReportList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoReportList[0].TVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(mapInfoReportList[0].MapInfoDrawTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoReportList[0].MapInfoDrawTypeText));
            }
            Assert.IsNotNull(mapInfoReportList[0].MapInfoID);
            Assert.IsNotNull(mapInfoReportList[0].TVItemID);
            Assert.IsNotNull(mapInfoReportList[0].TVType);
            Assert.IsNotNull(mapInfoReportList[0].LatMin);
            Assert.IsNotNull(mapInfoReportList[0].LatMax);
            Assert.IsNotNull(mapInfoReportList[0].LngMin);
            Assert.IsNotNull(mapInfoReportList[0].LngMax);
            Assert.IsNotNull(mapInfoReportList[0].MapInfoDrawType);
            Assert.IsNotNull(mapInfoReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mapInfoReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mapInfoReportList[0].HasErrors);
        }
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
    }
}
