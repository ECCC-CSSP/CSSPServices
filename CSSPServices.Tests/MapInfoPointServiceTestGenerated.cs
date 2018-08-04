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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MapInfoPoint_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = mapInfoPointService.GetMapInfoPointList().Count();

                    Assert.AreEqual(mapInfoPointService.GetMapInfoPointList().Count(), (from c in dbTestDB.MapInfoPoints select c).Take(200).Count());

                    mapInfoPointService.Add(mapInfoPoint);
                    if (mapInfoPoint.HasErrors)
                    {
                        Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mapInfoPointService.GetMapInfoPointList().Where(c => c == mapInfoPoint).Any());
                    mapInfoPointService.Update(mapInfoPoint);
                    if (mapInfoPoint.HasErrors)
                    {
                        Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mapInfoPointService.GetMapInfoPointList().Count());
                    mapInfoPointService.Delete(mapInfoPoint);
                    if (mapInfoPoint.HasErrors)
                    {
                        Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MapInfoPointMapInfoPointID"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoPointID = 10000000;
                    mapInfoPointService.Update(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfoPoint", "MapInfoPointMapInfoPointID", mapInfoPoint.MapInfoPointID.ToString()), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "MapInfo", ExistPlurial = "s", ExistFieldID = "MapInfoID", AllowableTVtypeList = )]
                    // mapInfoPoint.MapInfoID   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.MapInfoID = 0;
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MapInfo", "MapInfoPointMapInfoID", mapInfoPoint.MapInfoID.ToString()), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, -1)]
                    // mapInfoPoint.Ordinal   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Ordinal = -1;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "MapInfoPointOrdinal", "0"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoPointLat", "-90", "90"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());
                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lat = 91.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoPointLat", "-90", "90"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoPointLng", "-180", "180"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());
                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.Lng = 181.0D;
                    Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoPointLng", "-180", "180"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoPointService.GetMapInfoPointList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mapInfoPoint.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateDate_UTC = new DateTime();
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MapInfoPointLastUpdateDate_UTC"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MapInfoPointLastUpdateDate_UTC", "1980"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mapInfoPoint.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateContactTVItemID = 0;
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MapInfoPointLastUpdateContactTVItemID", mapInfoPoint.LastUpdateContactTVItemID.ToString()), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

                    mapInfoPoint = null;
                    mapInfoPoint = GetFilledRandomMapInfoPoint("");
                    mapInfoPoint.LastUpdateContactTVItemID = 1;
                    mapInfoPointService.Add(mapInfoPoint);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MapInfoPointLastUpdateContactTVItemID", "Contact"), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MapInfoPoint mapInfoPoint = (from c in dbTestDB.MapInfoPoints select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfoPoint);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mapInfoPointService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            MapInfoPoint mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID);
                            CheckMapInfoPointFields(new List<MapInfoPoint>() { mapInfoPointRet });
                            Assert.AreEqual(mapInfoPoint.MapInfoPointID, mapInfoPointRet.MapInfoPointID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            MapInfoPointWeb mapInfoPointWebRet = mapInfoPointService.GetMapInfoPointWebWithMapInfoPointID(mapInfoPoint.MapInfoPointID);
                            CheckMapInfoPointWebFields(new List<MapInfoPointWeb>() { mapInfoPointWebRet });
                            Assert.AreEqual(mapInfoPoint.MapInfoPointID, mapInfoPointWebRet.MapInfoPointID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            MapInfoPointReport mapInfoPointReportRet = mapInfoPointService.GetMapInfoPointReportWithMapInfoPointID(mapInfoPoint.MapInfoPointID);
                            CheckMapInfoPointReportFields(new List<MapInfoPointReport>() { mapInfoPointReportRet });
                            Assert.AreEqual(mapInfoPoint.MapInfoPointID, mapInfoPointReportRet.MapInfoPointID);
                        }
                        else
                        {
                            // nothing for now
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
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MapInfoPoint mapInfoPoint = (from c in dbTestDB.MapInfoPoints select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfoPoint);

                    List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                    mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mapInfoPointService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoPointWeb> mapInfoPointWebList = new List<MapInfoPointWeb>();
                            mapInfoPointWebList = mapInfoPointService.GetMapInfoPointWebList().ToList();
                            CheckMapInfoPointWebFields(mapInfoPointWebList);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoPointReport> mapInfoPointReportList = new List<MapInfoPointReport>();
                            mapInfoPointReportList = mapInfoPointService.GetMapInfoPointReportList().ToList();
                            CheckMapInfoPointReportFields(mapInfoPointReportList);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointReportList.Count);
                        }
                        else
                        {
                            // nothing for now
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoPointWeb> mapInfoPointWebList = new List<MapInfoPointWeb>();
                            mapInfoPointWebList = mapInfoPointService.GetMapInfoPointWebList().ToList();
                            CheckMapInfoPointWebFields(mapInfoPointWebList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointWebList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoPointReport> mapInfoPointReportList = new List<MapInfoPointReport>();
                            mapInfoPointReportList = mapInfoPointService.GetMapInfoPointReportList().ToList();
                            CheckMapInfoPointReportFields(mapInfoPointReportList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointReportList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take

        #region Tests Generated for GetMapInfoPointList() Skip Take Order
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 1, 1,  "MapInfoPointID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Skip(1).Take(1).OrderBy(c => c.MapInfoPointID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoPointWeb> mapInfoPointWebList = new List<MapInfoPointWeb>();
                            mapInfoPointWebList = mapInfoPointService.GetMapInfoPointWebList().ToList();
                            CheckMapInfoPointWebFields(mapInfoPointWebList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointWebList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoPointReport> mapInfoPointReportList = new List<MapInfoPointReport>();
                            mapInfoPointReportList = mapInfoPointService.GetMapInfoPointReportList().ToList();
                            CheckMapInfoPointReportFields(mapInfoPointReportList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointReportList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take Order

        #region Tests Generated for GetMapInfoPointList() Skip Take 2Order
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 1, 1, "MapInfoPointID,MapInfoID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Skip(1).Take(1).OrderBy(c => c.MapInfoPointID).ThenBy(c => c.MapInfoID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoPointWeb> mapInfoPointWebList = new List<MapInfoPointWeb>();
                            mapInfoPointWebList = mapInfoPointService.GetMapInfoPointWebList().ToList();
                            CheckMapInfoPointWebFields(mapInfoPointWebList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointWebList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoPointReport> mapInfoPointReportList = new List<MapInfoPointReport>();
                            mapInfoPointReportList = mapInfoPointService.GetMapInfoPointReportList().ToList();
                            CheckMapInfoPointReportFields(mapInfoPointReportList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointReportList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take 2Order

        #region Tests Generated for GetMapInfoPointList() Skip Take Order Where
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 0, 1, "MapInfoPointID", "MapInfoPointID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Where(c => c.MapInfoPointID == 4).Skip(0).Take(1).OrderBy(c => c.MapInfoPointID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoPointWeb> mapInfoPointWebList = new List<MapInfoPointWeb>();
                            mapInfoPointWebList = mapInfoPointService.GetMapInfoPointWebList().ToList();
                            CheckMapInfoPointWebFields(mapInfoPointWebList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointWebList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoPointReport> mapInfoPointReportList = new List<MapInfoPointReport>();
                            mapInfoPointReportList = mapInfoPointService.GetMapInfoPointReportList().ToList();
                            CheckMapInfoPointReportFields(mapInfoPointReportList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointReportList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take Order Where

        #region Tests Generated for GetMapInfoPointList() Skip Take Order 2Where
        [TestMethod]
        public void GetMapInfoPointList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 0, 1, "MapInfoPointID", "MapInfoPointID,GT,2|MapInfoPointID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Where(c => c.MapInfoPointID > 2 && c.MapInfoPointID < 5).Skip(0).Take(1).OrderBy(c => c.MapInfoPointID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoPointWeb> mapInfoPointWebList = new List<MapInfoPointWeb>();
                            mapInfoPointWebList = mapInfoPointService.GetMapInfoPointWebList().ToList();
                            CheckMapInfoPointWebFields(mapInfoPointWebList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointWebList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoPointReport> mapInfoPointReportList = new List<MapInfoPointReport>();
                            mapInfoPointReportList = mapInfoPointService.GetMapInfoPointReportList().ToList();
                            CheckMapInfoPointReportFields(mapInfoPointReportList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointReportList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() Skip Take Order 2Where

        #region Tests Generated for GetMapInfoPointList() 2Where
        [TestMethod]
        public void GetMapInfoPointList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        MapInfoPointService mapInfoPointService = new MapInfoPointService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoPointService.Query = mapInfoPointService.FillQuery(typeof(MapInfoPoint), culture.TwoLetterISOLanguageName, 0, 10000, "", "MapInfoPointID,GT,2|MapInfoPointID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<MapInfoPoint> mapInfoPointDirectQueryList = new List<MapInfoPoint>();
                        mapInfoPointDirectQueryList = (from c in dbTestDB.MapInfoPoints select c).Where(c => c.MapInfoPointID > 2 && c.MapInfoPointID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();
                            mapInfoPointList = mapInfoPointService.GetMapInfoPointList().ToList();
                            CheckMapInfoPointFields(mapInfoPointList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<MapInfoPointWeb> mapInfoPointWebList = new List<MapInfoPointWeb>();
                            mapInfoPointWebList = mapInfoPointService.GetMapInfoPointWebList().ToList();
                            CheckMapInfoPointWebFields(mapInfoPointWebList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointWebList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<MapInfoPointReport> mapInfoPointReportList = new List<MapInfoPointReport>();
                            mapInfoPointReportList = mapInfoPointService.GetMapInfoPointReportList().ToList();
                            CheckMapInfoPointReportFields(mapInfoPointReportList);
                            Assert.AreEqual(mapInfoPointDirectQueryList[0].MapInfoPointID, mapInfoPointReportList[0].MapInfoPointID);
                            Assert.AreEqual(mapInfoPointDirectQueryList.Count, mapInfoPointReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMapInfoPointList() 2Where

        #region Functions private
        private void CheckMapInfoPointFields(List<MapInfoPoint> mapInfoPointList)
        {
            Assert.IsNotNull(mapInfoPointList[0].MapInfoPointID);
            Assert.IsNotNull(mapInfoPointList[0].MapInfoID);
            Assert.IsNotNull(mapInfoPointList[0].Ordinal);
            Assert.IsNotNull(mapInfoPointList[0].Lat);
            Assert.IsNotNull(mapInfoPointList[0].Lng);
            Assert.IsNotNull(mapInfoPointList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mapInfoPointList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mapInfoPointList[0].HasErrors);
        }
        private void CheckMapInfoPointWebFields(List<MapInfoPointWeb> mapInfoPointWebList)
        {
            Assert.IsNotNull(mapInfoPointWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mapInfoPointWebList[0].MapInfoPointID);
            Assert.IsNotNull(mapInfoPointWebList[0].MapInfoID);
            Assert.IsNotNull(mapInfoPointWebList[0].Ordinal);
            Assert.IsNotNull(mapInfoPointWebList[0].Lat);
            Assert.IsNotNull(mapInfoPointWebList[0].Lng);
            Assert.IsNotNull(mapInfoPointWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mapInfoPointWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mapInfoPointWebList[0].HasErrors);
        }
        private void CheckMapInfoPointReportFields(List<MapInfoPointReport> mapInfoPointReportList)
        {
            if (!string.IsNullOrWhiteSpace(mapInfoPointReportList[0].MapInfoPointReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoPointReportList[0].MapInfoPointReportTest));
            }
            Assert.IsNotNull(mapInfoPointReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mapInfoPointReportList[0].MapInfoPointID);
            Assert.IsNotNull(mapInfoPointReportList[0].MapInfoID);
            Assert.IsNotNull(mapInfoPointReportList[0].Ordinal);
            Assert.IsNotNull(mapInfoPointReportList[0].Lat);
            Assert.IsNotNull(mapInfoPointReportList[0].Lng);
            Assert.IsNotNull(mapInfoPointReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mapInfoPointReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mapInfoPointReportList[0].HasErrors);
        }
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
    }
}
