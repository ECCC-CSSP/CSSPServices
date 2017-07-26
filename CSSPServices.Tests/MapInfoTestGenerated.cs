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
            if (OmitPropName != "LastUpdateDate_UTC") mapInfo.LastUpdateDate_UTC = GetRandomDateTime();
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


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // mapInfo.MapInfoID   (Int32)
            //-----------------------------------
            mapInfo = GetFilledRandomMapInfo("");
            mapInfo.MapInfoID = 0;
            mapInfoService.Update(mapInfo);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoMapInfoID), mapInfo.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // mapInfo.TVItemID   (Int32)
            //-----------------------------------
            // TVItemID will automatically be initialized at 0 --> not null


            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // TVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mapInfo.TVItemID = 1;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(1, mapInfo.TVItemID);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mapInfo.TVItemID = 2;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(2, mapInfo.TVItemID);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mapInfo.TVItemID = 0;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoTVItemID, "1")).Any());
            Assert.AreEqual(0, mapInfo.TVItemID);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // mapInfo.TVType   (TVTypeEnum)
            //-----------------------------------
            // TVType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[Range(-90, 90)]
            // mapInfo.LatMin   (Double)
            //-----------------------------------
            //Error: Type not implemented [LatMin]


            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LatMin has Min [-90.0D] and Max [90.0D]. At Min should return true and no errors
            mapInfo.LatMin = -90.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-90.0D, mapInfo.LatMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMin has Min [-90.0D] and Max [90.0D]. At Min + 1 should return true and no errors
            mapInfo.LatMin = -89.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-89.0D, mapInfo.LatMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMin has Min [-90.0D] and Max [90.0D]. At Min - 1 should return false with one error
            mapInfo.LatMin = -91.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMin, "-90", "90")).Any());
            Assert.AreEqual(-91.0D, mapInfo.LatMin);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMin has Min [-90.0D] and Max [90.0D]. At Max should return true and no errors
            mapInfo.LatMin = 90.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(90.0D, mapInfo.LatMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMin has Min [-90.0D] and Max [90.0D]. At Max - 1 should return true and no errors
            mapInfo.LatMin = 89.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(89.0D, mapInfo.LatMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMin has Min [-90.0D] and Max [90.0D]. At Max + 1 should return false with one error
            mapInfo.LatMin = 91.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMin, "-90", "90")).Any());
            Assert.AreEqual(91.0D, mapInfo.LatMin);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-90, 90)]
            // mapInfo.LatMax   (Double)
            //-----------------------------------
            //Error: Type not implemented [LatMax]


            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LatMax has Min [-90.0D] and Max [90.0D]. At Min should return true and no errors
            mapInfo.LatMax = -90.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-90.0D, mapInfo.LatMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMax has Min [-90.0D] and Max [90.0D]. At Min + 1 should return true and no errors
            mapInfo.LatMax = -89.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-89.0D, mapInfo.LatMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMax has Min [-90.0D] and Max [90.0D]. At Min - 1 should return false with one error
            mapInfo.LatMax = -91.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMax, "-90", "90")).Any());
            Assert.AreEqual(-91.0D, mapInfo.LatMax);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMax has Min [-90.0D] and Max [90.0D]. At Max should return true and no errors
            mapInfo.LatMax = 90.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(90.0D, mapInfo.LatMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMax has Min [-90.0D] and Max [90.0D]. At Max - 1 should return true and no errors
            mapInfo.LatMax = 89.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(89.0D, mapInfo.LatMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LatMax has Min [-90.0D] and Max [90.0D]. At Max + 1 should return false with one error
            mapInfo.LatMax = 91.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLatMax, "-90", "90")).Any());
            Assert.AreEqual(91.0D, mapInfo.LatMax);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-180, 180)]
            // mapInfo.LngMin   (Double)
            //-----------------------------------
            //Error: Type not implemented [LngMin]


            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LngMin has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            mapInfo.LngMin = -180.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-180.0D, mapInfo.LngMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMin has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            mapInfo.LngMin = -179.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-179.0D, mapInfo.LngMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMin has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            mapInfo.LngMin = -181.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMin, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, mapInfo.LngMin);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMin has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            mapInfo.LngMin = 180.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(180.0D, mapInfo.LngMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMin has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            mapInfo.LngMin = 179.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(179.0D, mapInfo.LngMin);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMin has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            mapInfo.LngMin = 181.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMin, "-180", "180")).Any());
            Assert.AreEqual(181.0D, mapInfo.LngMin);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-180, 180)]
            // mapInfo.LngMax   (Double)
            //-----------------------------------
            //Error: Type not implemented [LngMax]


            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LngMax has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            mapInfo.LngMax = -180.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-180.0D, mapInfo.LngMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMax has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            mapInfo.LngMax = -179.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(-179.0D, mapInfo.LngMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMax has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            mapInfo.LngMax = -181.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMax, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, mapInfo.LngMax);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMax has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            mapInfo.LngMax = 180.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(180.0D, mapInfo.LngMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMax has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            mapInfo.LngMax = 179.0D;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(179.0D, mapInfo.LngMax);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LngMax has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            mapInfo.LngMax = 181.0D;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoLngMax, "-180", "180")).Any());
            Assert.AreEqual(181.0D, mapInfo.LngMax);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // mapInfo.MapInfoDrawType   (MapInfoDrawTypeEnum)
            //-----------------------------------
            // MapInfoDrawType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // mapInfo.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // mapInfo.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mapInfo.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(1, mapInfo.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mapInfo.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mapInfoService.Add(mapInfo));
            Assert.AreEqual(0, mapInfo.ValidationResults.Count());
            Assert.AreEqual(2, mapInfo.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mapInfoService.Delete(mapInfo));
            Assert.AreEqual(count, mapInfoService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mapInfo.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mapInfo.LastUpdateContactTVItemID);
            Assert.AreEqual(count, mapInfoService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mapInfo.MapInfoPoints   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mapInfo.TVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // mapInfo.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
