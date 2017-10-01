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

            // Need to implement (no items found, would need to add at least one in the TestDB) [MapInfoPoint MapInfoID MapInfo MapInfoID]
            if (OmitPropName != "Ordinal") mapInfoPoint.Ordinal = GetRandomInt(0, 10);
            if (OmitPropName != "Lat") mapInfoPoint.Lat = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Lng") mapInfoPoint.Lng = GetRandomDouble(-180.0D, 180.0D);
            //Error: property [MapInfoPointWeb] and type [MapInfoPoint] is  not implemented
            //Error: property [MapInfoPointReport] and type [MapInfoPoint] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") mapInfoPoint.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfoPoint.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") mapInfoPoint.HasErrors = true;

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
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(LanguageRequest, dbTestDB, ContactID);

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

                    //Error: Type not implemented [MapInfoPointWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mapInfoPoint.MapInfoPointReport   (MapInfoPointReport)
                    // -----------------------------------

                    //Error: Type not implemented [MapInfoPointReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mapInfoPoint.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


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


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mapInfoPoint.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MapInfoPoint_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapInfoPointService mapInfoPointService = new MapInfoPointService(LanguageRequest, dbTestDB, ContactID);
                    MapInfoPoint mapInfoPoint = (from c in mapInfoPointService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mapInfoPoint);

                    MapInfoPoint mapInfoPointRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointID(mapInfoPoint.MapInfoPointID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(mapInfoPointRet.MapInfoPointID);
                        Assert.IsNotNull(mapInfoPointRet.MapInfoID);
                        Assert.IsNotNull(mapInfoPointRet.Ordinal);
                        Assert.IsNotNull(mapInfoPointRet.Lat);
                        Assert.IsNotNull(mapInfoPointRet.Lng);
                        Assert.IsNotNull(mapInfoPointRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mapInfoPointRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (mapInfoPointRet.MapInfoPointWeb != null)
                            {
                                Assert.IsNull(mapInfoPointRet.MapInfoPointWeb);
                            }
                            if (mapInfoPointRet.MapInfoPointReport != null)
                            {
                                Assert.IsNull(mapInfoPointRet.MapInfoPointReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (mapInfoPointRet.MapInfoPointWeb != null)
                            {
                                Assert.IsNotNull(mapInfoPointRet.MapInfoPointWeb);
                            }
                            if (mapInfoPointRet.MapInfoPointReport != null)
                            {
                                Assert.IsNotNull(mapInfoPointRet.MapInfoPointReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of MapInfoPoint
        #endregion Tests Get List of MapInfoPoint

    }
}
