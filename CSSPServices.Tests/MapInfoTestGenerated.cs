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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class MapInfoTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MapInfoID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MapInfo GetFilledRandomMapInfo(string OmitPropName)
        {
            MapInfoID += 1;

            MapInfo mapInfo = new MapInfo();

            if (OmitPropName != "MapInfoID") mapInfo.MapInfoID = MapInfoID;
            if (OmitPropName != "TVItemID") mapInfo.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TVType") mapInfo.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LatMin") mapInfo.LatMin = GetRandomFloat(-90, 90);
            if (OmitPropName != "LatMax") mapInfo.LatMax = GetRandomFloat(-90, 90);
            if (OmitPropName != "LngMin") mapInfo.LngMin = GetRandomFloat(-180, 180);
            if (OmitPropName != "LngMax") mapInfo.LngMax = GetRandomFloat(-180, 180);
            if (OmitPropName != "MapInfoDrawType") mapInfo.MapInfoDrawType = (MapInfoDrawTypeEnum)GetRandomEnumType(typeof(MapInfoDrawTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mapInfo.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfo.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mapInfo;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MapInfo_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MapInfo mapInfo = GetFilledRandomMapInfo("");
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(true, mapInfoService.GetRead().Where(c => c == mapInfo).Any());
            mapInfo.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mapInfoService.Update(mapInfo));
            Assert.AreEqual(1, mapInfoService.GetRead().Count());
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVItemID will automatically be initialized at 0 --> not null

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("TVType");
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(1, mapInfo.ValidationResults.Count());
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoTVType)).Any());
            Assert.AreEqual(TVTypeEnum.Error, mapInfo.TVType);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            // LatMin will automatically be initialized at 0.0f --> not null

            // LatMax will automatically be initialized at 0.0f --> not null

            // LngMin will automatically be initialized at 0.0f --> not null

            // LngMax will automatically be initialized at 0.0f --> not null

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("MapInfoDrawType");
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(1, mapInfo.ValidationResults.Count());
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoMapInfoDrawType)).Any());
            Assert.AreEqual(MapInfoDrawTypeEnum.Error, mapInfo.MapInfoDrawType);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("LastUpdateDate_UTC");
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(1, mapInfo.ValidationResults.Count());
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mapInfo.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MapInfoID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemID] of type [int]
            //-----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // TVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mapInfo.TVItemID = 1;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(1, mapInfo.TVItemID);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mapInfo.TVItemID = 2;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(2, mapInfo.TVItemID);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mapInfo.TVItemID = 0;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoTVItemID, "1")).Any());
            Assert.AreEqual(0, mapInfo.TVItemID);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            //-----------------------------------
            // doing property [TVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LatMin] of type [float]
            //-----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LatMin has Min [-90] and Max [90]. At Min should return true and no errors
            mapInfo.LatMin = -90.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-90.0f, mapInfo.LatMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMin has Min [-90] and Max [90]. At Min + 1 should return true and no errors
            mapInfo.LatMin = -89.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-89.0f, mapInfo.LatMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMin has Min [-90] and Max [90]. At Min - 1 should return false with one error
            mapInfo.LatMin = -91.0f;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMin, "-90", "90")).Any());
            Assert.AreEqual(-91.0f, mapInfo.LatMin);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMin has Min [-90] and Max [90]. At Max should return true and no errors
            mapInfo.LatMin = 90.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(90.0f, mapInfo.LatMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMin has Min [-90] and Max [90]. At Max - 1 should return true and no errors
            mapInfo.LatMin = 89.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(89.0f, mapInfo.LatMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMin has Min [-90] and Max [90]. At Max + 1 should return false with one error
            mapInfo.LatMin = 91.0f;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMin, "-90", "90")).Any());
            Assert.AreEqual(91.0f, mapInfo.LatMin);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            //-----------------------------------
            // doing property [LatMax] of type [float]
            //-----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LatMax has Min [-90] and Max [90]. At Min should return true and no errors
            mapInfo.LatMax = -90.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-90.0f, mapInfo.LatMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMax has Min [-90] and Max [90]. At Min + 1 should return true and no errors
            mapInfo.LatMax = -89.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-89.0f, mapInfo.LatMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMax has Min [-90] and Max [90]. At Min - 1 should return false with one error
            mapInfo.LatMax = -91.0f;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMax, "-90", "90")).Any());
            Assert.AreEqual(-91.0f, mapInfo.LatMax);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMax has Min [-90] and Max [90]. At Max should return true and no errors
            mapInfo.LatMax = 90.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(90.0f, mapInfo.LatMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMax has Min [-90] and Max [90]. At Max - 1 should return true and no errors
            mapInfo.LatMax = 89.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(89.0f, mapInfo.LatMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LatMax has Min [-90] and Max [90]. At Max + 1 should return false with one error
            mapInfo.LatMax = 91.0f;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMax, "-90", "90")).Any());
            Assert.AreEqual(91.0f, mapInfo.LatMax);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            //-----------------------------------
            // doing property [LngMin] of type [float]
            //-----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LngMin has Min [-180] and Max [180]. At Min should return true and no errors
            mapInfo.LngMin = -180.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-180.0f, mapInfo.LngMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMin has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            mapInfo.LngMin = -179.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-179.0f, mapInfo.LngMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMin has Min [-180] and Max [180]. At Min - 1 should return false with one error
            mapInfo.LngMin = -181.0f;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMin, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, mapInfo.LngMin);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMin has Min [-180] and Max [180]. At Max should return true and no errors
            mapInfo.LngMin = 180.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(180.0f, mapInfo.LngMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMin has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            mapInfo.LngMin = 179.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(179.0f, mapInfo.LngMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMin has Min [-180] and Max [180]. At Max + 1 should return false with one error
            mapInfo.LngMin = 181.0f;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMin, "-180", "180")).Any());
            Assert.AreEqual(181.0f, mapInfo.LngMin);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            //-----------------------------------
            // doing property [LngMax] of type [float]
            //-----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LngMax has Min [-180] and Max [180]. At Min should return true and no errors
            mapInfo.LngMax = -180.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-180.0f, mapInfo.LngMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMax has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            mapInfo.LngMax = -179.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-179.0f, mapInfo.LngMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMax has Min [-180] and Max [180]. At Min - 1 should return false with one error
            mapInfo.LngMax = -181.0f;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMax, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, mapInfo.LngMax);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMax has Min [-180] and Max [180]. At Max should return true and no errors
            mapInfo.LngMax = 180.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(180.0f, mapInfo.LngMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMax has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            mapInfo.LngMax = 179.0f;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(179.0f, mapInfo.LngMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LngMax has Min [-180] and Max [180]. At Max + 1 should return false with one error
            mapInfo.LngMax = 181.0f;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMax, "-180", "180")).Any());
            Assert.AreEqual(181.0f, mapInfo.LngMax);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            //-----------------------------------
            // doing property [MapInfoDrawType] of type [MapInfoDrawTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mapInfo.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(1, mapInfo.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mapInfo.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(2, mapInfo.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(0, mapInfoService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mapInfo.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mapInfo.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
