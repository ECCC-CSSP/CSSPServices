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
    public partial class MapInfoPointTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MapInfoPointID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MapInfoPoint GetFilledRandomMapInfoPoint(string OmitPropName)
        {
            MapInfoPointID += 1;

            MapInfoPoint mapInfoPoint = new MapInfoPoint();

            if (OmitPropName != "MapInfoPointID") mapInfoPoint.MapInfoPointID = MapInfoPointID;
            if (OmitPropName != "MapInfoID") mapInfoPoint.MapInfoID = GetRandomInt(1, 11);
            if (OmitPropName != "Ordinal") mapInfoPoint.Ordinal = GetRandomInt(0, 1000000);
            if (OmitPropName != "Lat") mapInfoPoint.Lat = GetRandomFloat(-90, 90);
            if (OmitPropName != "Lng") mapInfoPoint.Lng = GetRandomFloat(-180, 180);
            if (OmitPropName != "LastUpdateDate_UTC") mapInfoPoint.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfoPoint.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mapInfoPoint;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MapInfoPoint_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            MapInfoPointService mapInfoPointService = new MapInfoPointService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MapInfoPoint mapInfoPoint = GetFilledRandomMapInfoPoint("");
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(true, mapInfoPointService.GetRead().Where(c => c == mapInfoPoint).Any());
            mapInfoPoint.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mapInfoPointService.Update(mapInfoPoint));
            Assert.AreEqual(1, mapInfoPointService.GetRead().Count());
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MapInfoID will automatically be initialized at 0 --> not null

            // Ordinal will automatically be initialized at 0 --> not null

            // Lat will automatically be initialized at 0.0f --> not null

            // Lng will automatically be initialized at 0.0f --> not null

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("LastUpdateDate_UTC");
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(1, mapInfoPoint.ValidationResults.Count());
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoPointLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mapInfoPoint.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MapInfoPointID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [MapInfoID] of type [int]
            //-----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // MapInfoID has Min [1] and Max [empty]. At Min should return true and no errors
            mapInfoPoint.MapInfoID = 1;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(1, mapInfoPoint.MapInfoID);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // MapInfoID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mapInfoPoint.MapInfoID = 2;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(2, mapInfoPoint.MapInfoID);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // MapInfoID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mapInfoPoint.MapInfoID = 0;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointMapInfoID, "1")).Any());
            Assert.AreEqual(0, mapInfoPoint.MapInfoID);
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());

            //-----------------------------------
            // doing property [Ordinal] of type [int]
            //-----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // Ordinal has Min [0] and Max [1000000]. At Min should return true and no errors
            mapInfoPoint.Ordinal = 0;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(0, mapInfoPoint.Ordinal);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            mapInfoPoint.Ordinal = 1;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(1, mapInfoPoint.Ordinal);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            mapInfoPoint.Ordinal = -1;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointOrdinal, "0", "1000000")).Any());
            Assert.AreEqual(-1, mapInfoPoint.Ordinal);
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000000]. At Max should return true and no errors
            mapInfoPoint.Ordinal = 1000000;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(1000000, mapInfoPoint.Ordinal);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            mapInfoPoint.Ordinal = 999999;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(999999, mapInfoPoint.Ordinal);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            mapInfoPoint.Ordinal = 1000001;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointOrdinal, "0", "1000000")).Any());
            Assert.AreEqual(1000001, mapInfoPoint.Ordinal);
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());

            //-----------------------------------
            // doing property [Lat] of type [float]
            //-----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // Lat has Min [-90] and Max [90]. At Min should return true and no errors
            mapInfoPoint.Lat = -90.0f;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(-90.0f, mapInfoPoint.Lat);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Min + 1 should return true and no errors
            mapInfoPoint.Lat = -89.0f;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(-89.0f, mapInfoPoint.Lat);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Min - 1 should return false with one error
            mapInfoPoint.Lat = -91.0f;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLat, "-90", "90")).Any());
            Assert.AreEqual(-91.0f, mapInfoPoint.Lat);
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Max should return true and no errors
            mapInfoPoint.Lat = 90.0f;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(90.0f, mapInfoPoint.Lat);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Max - 1 should return true and no errors
            mapInfoPoint.Lat = 89.0f;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(89.0f, mapInfoPoint.Lat);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90] and Max [90]. At Max + 1 should return false with one error
            mapInfoPoint.Lat = 91.0f;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLat, "-90", "90")).Any());
            Assert.AreEqual(91.0f, mapInfoPoint.Lat);
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());

            //-----------------------------------
            // doing property [Lng] of type [float]
            //-----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // Lng has Min [-180] and Max [180]. At Min should return true and no errors
            mapInfoPoint.Lng = -180.0f;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(-180.0f, mapInfoPoint.Lng);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            mapInfoPoint.Lng = -179.0f;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(-179.0f, mapInfoPoint.Lng);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Min - 1 should return false with one error
            mapInfoPoint.Lng = -181.0f;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLng, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, mapInfoPoint.Lng);
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Max should return true and no errors
            mapInfoPoint.Lng = 180.0f;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(180.0f, mapInfoPoint.Lng);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            mapInfoPoint.Lng = 179.0f;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(179.0f, mapInfoPoint.Lng);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180] and Max [180]. At Max + 1 should return false with one error
            mapInfoPoint.Lng = 181.0f;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLng, "-180", "180")).Any());
            Assert.AreEqual(181.0f, mapInfoPoint.Lng);
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mapInfoPoint.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(1, mapInfoPoint.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mapInfoPoint.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(2, mapInfoPoint.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mapInfoPoint.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mapInfoPoint.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mapInfoPointService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
