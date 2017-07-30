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
    public partial class MapInfoTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MapInfoService mapInfoService { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoTest() : base()
        {
            mapInfoService = new MapInfoService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MapInfo GetFilledRandomMapInfo(string OmitPropName)
        {
            MapInfo mapInfo = new MapInfo();

            if (OmitPropName != "TVItemID") mapInfo.TVItemID = 2;
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

        #region Tests Generated
        [TestMethod]
        public void MapInfo_Testing()
        {

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

            mapInfoService.Add(mapInfo);
            if (mapInfo.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mapInfoService.GetRead().Where(c => c == mapInfo).Any());
            mapInfoService.Update(mapInfo);
            if (mapInfo.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mapInfoService.GetRead().Count());
            mapInfoService.Delete(mapInfo);
            if (mapInfo.ValidationResults.Count() > 0)
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
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoMapInfoID), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // mapInfo.TVItemID   (Int32)
            // -----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.TVItemID = 0;
            mapInfoService.Add(mapInfo);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MapInfoTVItemID, mapInfo.TVItemID.ToString()), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mapInfo.TVType   (TVTypeEnum)
            // -----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.TVType = (TVTypeEnum)1000000;
            mapInfoService.Add(mapInfo);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoTVType), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [Range(-90, 90)]
            // mapInfo.LatMin   (Double)
            // -----------------------------------

            //Error: Type not implemented [LatMin]

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LatMin = -91.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMin, "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LatMin = 91.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMin, "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-90, 90)]
            // mapInfo.LatMax   (Double)
            // -----------------------------------

            //Error: Type not implemented [LatMax]

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LatMax = -91.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMax, "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LatMax = 91.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMax, "-90", "90"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-180, 180)]
            // mapInfo.LngMin   (Double)
            // -----------------------------------

            //Error: Type not implemented [LngMin]

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LngMin = -181.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMin, "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LngMin = 181.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMin, "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-180, 180)]
            // mapInfo.LngMax   (Double)
            // -----------------------------------

            //Error: Type not implemented [LngMax]

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LngMax = -181.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMax, "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LngMax = 181.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMax, "-180", "180"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoMapInfoDrawType), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mapInfo.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // mapInfo.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LastUpdateContactTVItemID = 0;
            mapInfoService.Add(mapInfo);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MapInfoLastUpdateContactTVItemID, mapInfo.LastUpdateContactTVItemID.ToString()), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.LastUpdateContactTVItemID = 1;
            mapInfoService.Add(mapInfo);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MapInfoLastUpdateContactTVItemID, "Contact"), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mapInfo.MapInfoPoints   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mapInfo.TVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mapInfo.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
