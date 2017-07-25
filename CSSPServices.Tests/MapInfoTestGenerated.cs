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

            if (OmitPropName != "TVItemID") mapInfo.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TVType") mapInfo.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LatMin") mapInfo.LatMin = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LatMax") mapInfo.LatMax = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LngMin") mapInfo.LngMin = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LngMax") mapInfo.LngMax = GetRandomDouble(1.0D, 1000.0D);
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
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TVType]

            //Error: Type not implemented [LatMin]

            //Error: Type not implemented [LatMax]

            //Error: Type not implemented [LngMin]

            //Error: Type not implemented [LngMax]

            //Error: Type not implemented [MapInfoDrawType]

            mapInfo = null;
            mapInfo = GetFilledRandomMapInfo("LastUpdateDate_UTC");
            Assert.AreEqual(false, mapInfoService.Add(mapInfo));
            Assert.AreEqual(1, mapInfo.ValidationResults.Count());
            Assert.IsTrue(mapInfo.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mapInfo.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mapInfoService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MapInfoPoints]

            //Error: Type not implemented [TVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MapInfoID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemID] of type [Int32]
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
            // doing property [LatMin] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LatMax] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LngMin] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LngMax] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [MapInfoDrawType] of type [MapInfoDrawTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [MapInfoPoints] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
