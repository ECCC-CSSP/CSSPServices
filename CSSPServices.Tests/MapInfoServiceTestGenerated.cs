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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = mapInfoService.GetMapInfoList().Count();

                    Assert.AreEqual(mapInfoService.GetMapInfoList().Count(), (from c in dbTestDB.MapInfos select c).Take(200).Count());

                    mapInfoService.Add(mapInfo);
                    if (mapInfo.HasErrors)
                    {
                        Assert.AreEqual("", mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mapInfoService.GetMapInfoList().Where(c => c == mapInfo).Any());
                    mapInfoService.Update(mapInfo);
                    if (mapInfo.HasErrors)
                    {
                        Assert.AreEqual("", mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mapInfoService.GetMapInfoList().Count());
                    mapInfoService.Delete(mapInfo);
                    if (mapInfo.HasErrors)
                    {
                        Assert.AreEqual("", mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());

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
                    Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LatMin = 91.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLatMin", "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());

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
                    Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LatMax = 91.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLatMax", "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());

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
                    Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LngMin = 181.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLngMin", "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());

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
                    Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());
                    mapInfo = null;
                    mapInfo = GetFilledRandomMapInfo("");
                    mapInfo.LngMax = 181.0D;
                    Assert.AreEqual(false, mapInfoService.Add(mapInfo));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MapInfoLngMax", "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mapInfoService.GetMapInfoList().Count());

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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MapInfo mapInfo = (from c in dbTestDB.MapInfos select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfo);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mapInfoService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            MapInfo mapInfoRet = mapInfoService.GetMapInfoWithMapInfoID(mapInfo.MapInfoID);
                            CheckMapInfoFields(new List<MapInfo>() { mapInfoRet });
                            Assert.AreEqual(mapInfo.MapInfoID, mapInfoRet.MapInfoID);
                        }
                        else if (detail == "ExtraA")
                        {
                            MapInfoExtraA mapInfoExtraARet = mapInfoService.GetMapInfoExtraAWithMapInfoID(mapInfo.MapInfoID);
                            CheckMapInfoExtraAFields(new List<MapInfoExtraA>() { mapInfoExtraARet });
                            Assert.AreEqual(mapInfo.MapInfoID, mapInfoExtraARet.MapInfoID);
                        }
                        else if (detail == "ExtraB")
                        {
                            MapInfoExtraB mapInfoExtraBRet = mapInfoService.GetMapInfoExtraBWithMapInfoID(mapInfo.MapInfoID);
                            CheckMapInfoExtraBFields(new List<MapInfoExtraB>() { mapInfoExtraBRet });
                            Assert.AreEqual(mapInfo.MapInfoID, mapInfoExtraBRet.MapInfoID);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MapInfo mapInfo = (from c in dbTestDB.MapInfos select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfo);

                    List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                    mapInfoDirectQueryList = (from c in dbTestDB.MapInfos select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mapInfoService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MapInfoExtraA> mapInfoExtraAList = new List<MapInfoExtraA>();
                            mapInfoExtraAList = mapInfoService.GetMapInfoExtraAList().ToList();
                            CheckMapInfoExtraAFields(mapInfoExtraAList);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MapInfoExtraB> mapInfoExtraBList = new List<MapInfoExtraB>();
                            mapInfoExtraBList = mapInfoService.GetMapInfoExtraBList().ToList();
                            CheckMapInfoExtraBFields(mapInfoExtraBList);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = (from c in dbTestDB.MapInfos select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MapInfoExtraA> mapInfoExtraAList = new List<MapInfoExtraA>();
                            mapInfoExtraAList = mapInfoService.GetMapInfoExtraAList().ToList();
                            CheckMapInfoExtraAFields(mapInfoExtraAList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraAList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MapInfoExtraB> mapInfoExtraBList = new List<MapInfoExtraB>();
                            mapInfoExtraBList = mapInfoService.GetMapInfoExtraBList().ToList();
                            CheckMapInfoExtraBFields(mapInfoExtraBList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraBList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 1, 1,  "MapInfoID", "");

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = (from c in dbTestDB.MapInfos select c).Skip(1).Take(1).OrderBy(c => c.MapInfoID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MapInfoExtraA> mapInfoExtraAList = new List<MapInfoExtraA>();
                            mapInfoExtraAList = mapInfoService.GetMapInfoExtraAList().ToList();
                            CheckMapInfoExtraAFields(mapInfoExtraAList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraAList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MapInfoExtraB> mapInfoExtraBList = new List<MapInfoExtraB>();
                            mapInfoExtraBList = mapInfoService.GetMapInfoExtraBList().ToList();
                            CheckMapInfoExtraBFields(mapInfoExtraBList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraBList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 1, 1, "MapInfoID,TVItemID", "");

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = (from c in dbTestDB.MapInfos select c).Skip(1).Take(1).OrderBy(c => c.MapInfoID).ThenBy(c => c.TVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MapInfoExtraA> mapInfoExtraAList = new List<MapInfoExtraA>();
                            mapInfoExtraAList = mapInfoService.GetMapInfoExtraAList().ToList();
                            CheckMapInfoExtraAFields(mapInfoExtraAList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraAList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MapInfoExtraB> mapInfoExtraBList = new List<MapInfoExtraB>();
                            mapInfoExtraBList = mapInfoService.GetMapInfoExtraBList().ToList();
                            CheckMapInfoExtraBFields(mapInfoExtraBList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraBList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 0, 1, "MapInfoID", "MapInfoID,EQ,4", "");

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = (from c in dbTestDB.MapInfos select c).Where(c => c.MapInfoID == 4).Skip(0).Take(1).OrderBy(c => c.MapInfoID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MapInfoExtraA> mapInfoExtraAList = new List<MapInfoExtraA>();
                            mapInfoExtraAList = mapInfoService.GetMapInfoExtraAList().ToList();
                            CheckMapInfoExtraAFields(mapInfoExtraAList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraAList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MapInfoExtraB> mapInfoExtraBList = new List<MapInfoExtraB>();
                            mapInfoExtraBList = mapInfoService.GetMapInfoExtraBList().ToList();
                            CheckMapInfoExtraBFields(mapInfoExtraBList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraBList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 0, 1, "MapInfoID", "MapInfoID,GT,2|MapInfoID,LT,5", "");

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = (from c in dbTestDB.MapInfos select c).Where(c => c.MapInfoID > 2 && c.MapInfoID < 5).Skip(0).Take(1).OrderBy(c => c.MapInfoID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MapInfoExtraA> mapInfoExtraAList = new List<MapInfoExtraA>();
                            mapInfoExtraAList = mapInfoService.GetMapInfoExtraAList().ToList();
                            CheckMapInfoExtraAFields(mapInfoExtraAList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraAList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MapInfoExtraB> mapInfoExtraBList = new List<MapInfoExtraB>();
                            mapInfoExtraBList = mapInfoService.GetMapInfoExtraBList().ToList();
                            CheckMapInfoExtraBFields(mapInfoExtraBList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraBList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MapInfoService mapInfoService = new MapInfoService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mapInfoService.Query = mapInfoService.FillQuery(typeof(MapInfo), culture.TwoLetterISOLanguageName, 0, 10000, "", "MapInfoID,GT,2|MapInfoID,LT,5", "");

                        List<MapInfo> mapInfoDirectQueryList = new List<MapInfo>();
                        mapInfoDirectQueryList = (from c in dbTestDB.MapInfos select c).Where(c => c.MapInfoID > 2 && c.MapInfoID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MapInfo> mapInfoList = new List<MapInfo>();
                            mapInfoList = mapInfoService.GetMapInfoList().ToList();
                            CheckMapInfoFields(mapInfoList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoList[0].MapInfoID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MapInfoExtraA> mapInfoExtraAList = new List<MapInfoExtraA>();
                            mapInfoExtraAList = mapInfoService.GetMapInfoExtraAList().ToList();
                            CheckMapInfoExtraAFields(mapInfoExtraAList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraAList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MapInfoExtraB> mapInfoExtraBList = new List<MapInfoExtraB>();
                            mapInfoExtraBList = mapInfoService.GetMapInfoExtraBList().ToList();
                            CheckMapInfoExtraBFields(mapInfoExtraBList);
                            Assert.AreEqual(mapInfoDirectQueryList[0].MapInfoID, mapInfoExtraBList[0].MapInfoID);
                            Assert.AreEqual(mapInfoDirectQueryList.Count, mapInfoExtraBList.Count);
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
        private void CheckMapInfoExtraAFields(List<MapInfoExtraA> mapInfoExtraAList)
        {
            Assert.IsNotNull(mapInfoExtraAList[0].TVItemLanguage);
            Assert.IsNotNull(mapInfoExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mapInfoExtraAList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoExtraAList[0].TVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(mapInfoExtraAList[0].MapInfoDrawTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoExtraAList[0].MapInfoDrawTypeText));
            }
            Assert.IsNotNull(mapInfoExtraAList[0].MapInfoID);
            Assert.IsNotNull(mapInfoExtraAList[0].TVItemID);
            Assert.IsNotNull(mapInfoExtraAList[0].TVType);
            Assert.IsNotNull(mapInfoExtraAList[0].LatMin);
            Assert.IsNotNull(mapInfoExtraAList[0].LatMax);
            Assert.IsNotNull(mapInfoExtraAList[0].LngMin);
            Assert.IsNotNull(mapInfoExtraAList[0].LngMax);
            Assert.IsNotNull(mapInfoExtraAList[0].MapInfoDrawType);
            Assert.IsNotNull(mapInfoExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mapInfoExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mapInfoExtraAList[0].HasErrors);
        }
        private void CheckMapInfoExtraBFields(List<MapInfoExtraB> mapInfoExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(mapInfoExtraBList[0].MapInfoReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoExtraBList[0].MapInfoReportTest));
            }
            Assert.IsNotNull(mapInfoExtraBList[0].TVItemLanguage);
            Assert.IsNotNull(mapInfoExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(mapInfoExtraBList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoExtraBList[0].TVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(mapInfoExtraBList[0].MapInfoDrawTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mapInfoExtraBList[0].MapInfoDrawTypeText));
            }
            Assert.IsNotNull(mapInfoExtraBList[0].MapInfoID);
            Assert.IsNotNull(mapInfoExtraBList[0].TVItemID);
            Assert.IsNotNull(mapInfoExtraBList[0].TVType);
            Assert.IsNotNull(mapInfoExtraBList[0].LatMin);
            Assert.IsNotNull(mapInfoExtraBList[0].LatMax);
            Assert.IsNotNull(mapInfoExtraBList[0].LngMin);
            Assert.IsNotNull(mapInfoExtraBList[0].LngMax);
            Assert.IsNotNull(mapInfoExtraBList[0].MapInfoDrawType);
            Assert.IsNotNull(mapInfoExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mapInfoExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mapInfoExtraBList[0].HasErrors);
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
