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
        private MapInfoPointService mapInfoPointService { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointTest() : base()
        {
            mapInfoPointService = new MapInfoPointService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "LastUpdateDate_UTC") mapInfoPoint.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfoPoint.LastUpdateContactTVItemID = 2;

            return mapInfoPoint;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MapInfoPoint_Testing()
        {

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

            mapInfoPointService.Add(mapInfoPoint);
            if (mapInfoPoint.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mapInfoPointService.GetRead().Where(c => c == mapInfoPoint).Any());
            mapInfoPointService.Update(mapInfoPoint);
            if (mapInfoPoint.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mapInfoPointService.GetRead().Count());
            mapInfoPointService.Delete(mapInfoPoint);
            if (mapInfoPoint.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // mapInfoPoint.MapInfoPointID   (Int32)
            //-----------------------------------
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            mapInfoPoint.MapInfoPointID = 0;
            mapInfoPointService.Update(mapInfoPoint);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MapInfoPointMapInfoPointID), mapInfoPoint.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "MapInfo", Plurial = "s", FieldID = "MapInfoID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // mapInfoPoint.MapInfoID   (Int32)
            //-----------------------------------
            // MapInfoID will automatically be initialized at 0 --> not null


            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // MapInfoID has Min [1] and Max [empty]. At Min should return true and no errors
            mapInfoPoint.MapInfoID = 1;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(1, mapInfoPoint.MapInfoID);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // MapInfoID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mapInfoPoint.MapInfoID = 2;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(2, mapInfoPoint.MapInfoID);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // MapInfoID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mapInfoPoint.MapInfoID = 0;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointMapInfoID, "1")).Any());
            Assert.AreEqual(0, mapInfoPoint.MapInfoID);
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, -1)]
            // mapInfoPoint.Ordinal   (Int32)
            //-----------------------------------
            // Ordinal will automatically be initialized at 0 --> not null


            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // Ordinal has Min [0] and Max [empty]. At Min should return true and no errors
            mapInfoPoint.Ordinal = 0;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(0, mapInfoPoint.Ordinal);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Ordinal has Min [0] and Max [empty]. At Min + 1 should return true and no errors
            mapInfoPoint.Ordinal = 1;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(1, mapInfoPoint.Ordinal);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Ordinal has Min [0] and Max [empty]. At Min - 1 should return false with one error
            mapInfoPoint.Ordinal = -1;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointOrdinal, "0")).Any());
            Assert.AreEqual(-1, mapInfoPoint.Ordinal);
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-90, 90)]
            // mapInfoPoint.Lat   (Double)
            //-----------------------------------
            //Error: Type not implemented [Lat]


            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // Lat has Min [-90.0D] and Max [90.0D]. At Min should return true and no errors
            mapInfoPoint.Lat = -90.0D;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(-90.0D, mapInfoPoint.Lat);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Min + 1 should return true and no errors
            mapInfoPoint.Lat = -89.0D;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(-89.0D, mapInfoPoint.Lat);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Min - 1 should return false with one error
            mapInfoPoint.Lat = -91.0D;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLat, "-90", "90")).Any());
            Assert.AreEqual(-91.0D, mapInfoPoint.Lat);
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Max should return true and no errors
            mapInfoPoint.Lat = 90.0D;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(90.0D, mapInfoPoint.Lat);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Max - 1 should return true and no errors
            mapInfoPoint.Lat = 89.0D;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(89.0D, mapInfoPoint.Lat);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lat has Min [-90.0D] and Max [90.0D]. At Max + 1 should return false with one error
            mapInfoPoint.Lat = 91.0D;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLat, "-90", "90")).Any());
            Assert.AreEqual(91.0D, mapInfoPoint.Lat);
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(-180, 180)]
            // mapInfoPoint.Lng   (Double)
            //-----------------------------------
            //Error: Type not implemented [Lng]


            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // Lng has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            mapInfoPoint.Lng = -180.0D;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(-180.0D, mapInfoPoint.Lng);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            mapInfoPoint.Lng = -179.0D;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(-179.0D, mapInfoPoint.Lng);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            mapInfoPoint.Lng = -181.0D;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLng, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, mapInfoPoint.Lng);
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            mapInfoPoint.Lng = 180.0D;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(180.0D, mapInfoPoint.Lng);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            mapInfoPoint.Lng = 179.0D;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(179.0D, mapInfoPoint.Lng);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // Lng has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            mapInfoPoint.Lng = 181.0D;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MapInfoPointLng, "-180", "180")).Any());
            Assert.AreEqual(181.0D, mapInfoPoint.Lng);
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // mapInfoPoint.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // mapInfoPoint.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            mapInfoPoint = null;
            mapInfoPoint = GetFilledRandomMapInfoPoint("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mapInfoPoint.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(1, mapInfoPoint.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mapInfoPoint.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mapInfoPointService.Add(mapInfoPoint));
            Assert.AreEqual(0, mapInfoPoint.ValidationResults.Count());
            Assert.AreEqual(2, mapInfoPoint.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mapInfoPointService.Delete(mapInfoPoint));
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mapInfoPoint.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mapInfoPointService.Add(mapInfoPoint));
            Assert.IsTrue(mapInfoPoint.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MapInfoPointLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mapInfoPoint.LastUpdateContactTVItemID);
            Assert.AreEqual(count, mapInfoPointService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // mapInfoPoint.MapInfo   (MapInfo)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // mapInfoPoint.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
