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
    public partial class MapInfoPointServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MapInfoPointService mapInfoPointService { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointServiceTest() : base()
        {
            //mapInfoPointService = new MapInfoPointService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MapInfoPoint GetFilledRandomMapInfoPoint(string OmitPropName)
        {
            MapInfoPoint mapInfoPoint = new MapInfoPoint();

            if (OmitPropName != "MapInfoID") mapInfoPoint.MapInfoID = 1;
            if (OmitPropName != "Ordinal") mapInfoPoint.Ordinal = GetRandomInt(0, 10);
            if (OmitPropName != "Lat") mapInfoPoint.Lat = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Lng") mapInfoPoint.Lng = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mapInfoPoint.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfoPoint.LastUpdateContactTVItemID = 2;

            return mapInfoPoint;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MapInfoPoint_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MapInfoPoint mapInfoPoint = GetFilledRandomMapInfoPoint("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mapInfoPointService.GetRead().Count();

                    Assert.AreEqual(mapInfoPointService.GetRead().Count(), mapInfoPointService.GetEdit().Count());

                    mapInfoPointService.Add(mapInfoPoint);
                    if (mapInfoPoint.HasErrors)
                    {
                        Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mapInfoPointService.GetRead().Where(c => c == mapInfoPoint).Any());
                    mapInfoPointService.Update(mapInfoPoint);
                    if (mapInfoPoint.HasErrors)
                    {
                        Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mapInfoPointService.GetRead().Count());
                    mapInfoPointService.Delete(mapInfoPoint);
                    if (mapInfoPoint.HasErrors)
                    {
                        Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mapInfoPoint.MapInfoPointID   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoPointID = 0;
                    mapInfoPointService.Update(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoPointMapInfoPointID), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoPointID = 10000000;
                    mapInfoPointService.Update(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MapInfoPoint, CSSPModelsRes.MapInfoPointMapInfoPointID, mapInfoPoint.MapInfoPointID.ToString()), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MapInfo", ExistPlurial = "s", ExistFieldID = "MapInfoID", AllowableTVtypeList = Error)]
                    // mapInfoPoint.MapInfoID   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoID = 0;
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MapInfo, CSSPModelsRes.MapInfoPointMapInfoID, mapInfoPoint.MapInfoID.ToString()), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, -1)]
                    // mapInfoPoint.Ordinal   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Ordinal = -1;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.MapInfoPointOrdinal, "0"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-90, 90)]
                    // mapInfoPoint.Lat   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Lat]

                    //Error: Type not implemented [Lat]

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lat = -91.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoPointLat, "-90", "90"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lat = 91.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoPointLat, "-90", "90"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-180, 180)]
                    // mapInfoPoint.Lng   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Lng]

                    //Error: Type not implemented [Lng]

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lng = -181.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoPointLng, "-180", "180"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lng = 181.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MapInfoPointLng, "-180", "180"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mapInfoPoint.MapInfoPointWeb   (MapInfoPointWeb)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoPointWeb = null;
                    Assert.IsNull(mapInfoPoint.MapInfoPointWeb);

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoPointWeb = new MapInfoPointWeb();
                    Assert.IsNotNull(mapInfoPoint.MapInfoPointWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mapInfoPoint.MapInfoPointReport   (MapInfoPointReport)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoPointReport = null;
                    Assert.IsNull(mapInfoPoint.MapInfoPointReport);

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoPointReport = new MapInfoPointReport();
                    Assert.IsNotNull(mapInfoPoint.MapInfoPointReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mapInfoPoint.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateDate_UTC = new DateTime();
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MapInfoPointLastUpdateDate_UTC), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MapInfoPointLastUpdateDate_UTC, "1980"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mapInfoPoint.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateContactTVItemID = 0;
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MapInfoPointLastUpdateContactTVItemID, mapInfoPoint.LastUpdateContactTVItemID.ToString()), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateContactTVItemID = 1;
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MapInfoPointLastUpdateContactTVItemID, "Contact"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mapInfoPoint.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mapInfoPoint.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID)
        [TestMethod]
        public void GetMapInfoPointWithMapInfoPointID__mapInfoPoint_MapInfoPointID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new GetParam(), dbTestDB, ContactID);
                    MapInfoPoint mapInfoPoint = (from c in mapInfoPointService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfoPoint);

                    MapInfoPoint mapInfoPointRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mapInfoPointService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID);
                            Assert.IsNull(mapInfoPointRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MapInfoPoint fields
                        Assert.IsNotNull(mapInfoPointRet.MapInfoPointID);
                        Assert.IsNotNull(mapInfoPointRet.MapInfoID);
                        Assert.IsNotNull(mapInfoPointRet.Ordinal);
                        Assert.IsNotNull(mapInfoPointRet.Lat);
                        Assert.IsNotNull(mapInfoPointRet.Lng);
                        Assert.IsNotNull(mapInfoPointRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mapInfoPointRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MapInfoPointWeb and MapInfoPointReport fields should be null here
                            Assert.IsNull(mapInfoPointRet.MapInfoPointWeb);
                            Assert.IsNull(mapInfoPointRet.MapInfoPointReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MapInfoPointWeb fields should not be null and MapInfoPointReport fields should be null here
                            if (mapInfoPointRet.MapInfoPointWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoPointRet.MapInfoPointWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(mapInfoPointRet.MapInfoPointReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MapInfoPointWeb and MapInfoPointReport fields should NOT be null here
                            if (mapInfoPointRet.MapInfoPointWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoPointRet.MapInfoPointWeb.LastUpdateContactTVText));
                            }
                            if (mapInfoPointRet.MapInfoPointReport.MapInfoPointReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoPointRet.MapInfoPointReport.MapInfoPointReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID)

        #region Tests Generated for GetMapInfoPointList()
        [TestMethod]
        public void GetMapInfoPointList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new GetParam(), dbTestDB, ContactID);
                    MapInfoPoint mapInfoPoint = (from c in mapInfoPointService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfoPoint);

                    List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mapInfoPointService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            Assert.AreEqual(0, mapInfoPointList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MapInfoPoint fields
                        Assert.IsNotNull(mapInfoPointList[0].MapInfoPointID);
                        Assert.IsNotNull(mapInfoPointList[0].MapInfoID);
                        Assert.IsNotNull(mapInfoPointList[0].Ordinal);
                        Assert.IsNotNull(mapInfoPointList[0].Lat);
                        Assert.IsNotNull(mapInfoPointList[0].Lng);
                        Assert.IsNotNull(mapInfoPointList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(mapInfoPointList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MapInfoPointWeb and MapInfoPointReport fields should be null here
                            Assert.IsNull(mapInfoPointList[0].MapInfoPointWeb);
                            Assert.IsNull(mapInfoPointList[0].MapInfoPointReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MapInfoPointWeb fields should not be null and MapInfoPointReport fields should be null here
                            if (mapInfoPointList[0].MapInfoPointWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoPointList[0].MapInfoPointWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(mapInfoPointList[0].MapInfoPointReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MapInfoPointWeb and MapInfoPointReport fields should NOT be null here
                            if (mapInfoPointList[0].MapInfoPointWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoPointList[0].MapInfoPointWeb.LastUpdateContactTVText));
                            }
                            if (mapInfoPointList[0].MapInfoPointReport.MapInfoPointReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoPointList[0].MapInfoPointReport.MapInfoPointReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList()

        #region Tests Generated for GetMapInfoPointList() Skip Take
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(MapInfoPoint), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            Assert.AreEqual(0, mapInfoPointList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, mapInfoPointList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take

    }
}
