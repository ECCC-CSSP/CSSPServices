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
    public partial class BoxModelResultTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int BoxModelResultID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelResultTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModelResult GetFilledRandomBoxModelResult(string OmitPropName)
        {
            BoxModelResultID += 1;

            BoxModelResult boxModelResult = new BoxModelResult();

            if (OmitPropName != "BoxModelResultID") boxModelResult.BoxModelResultID = BoxModelResultID;
            if (OmitPropName != "BoxModelID") boxModelResult.BoxModelID = GetRandomInt(1, 11);
            if (OmitPropName != "BoxModelResultType") boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "Volume_m3") boxModelResult.Volume_m3 = GetRandomFloat(0.0f, 10.0f);
            if (OmitPropName != "Surface_m2") boxModelResult.Surface_m2 = GetRandomFloat(0.0f, 10.0f);
            if (OmitPropName != "Radius_m") boxModelResult.Radius_m = GetRandomFloat(0.0f, 100000.0f);
            if (OmitPropName != "LeftSideDiameterLineAngle_deg") boxModelResult.LeftSideDiameterLineAngle_deg = GetRandomFloat(0.0f, 360.0f);
            if (OmitPropName != "CircleCenterLatitude") boxModelResult.CircleCenterLatitude = GetRandomFloat(-90.0f, 90.0f);
            if (OmitPropName != "CircleCenterLongitude") boxModelResult.CircleCenterLongitude = GetRandomFloat(-180.0f, 180.0f);
            if (OmitPropName != "FixLength") boxModelResult.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelResult.FixWidth = true;
            if (OmitPropName != "RectLength_m") boxModelResult.RectLength_m = GetRandomFloat(0.0f, 100000.0f);
            if (OmitPropName != "RectWidth_m") boxModelResult.RectWidth_m = GetRandomFloat(0.0f, 100000.0f);
            if (OmitPropName != "LeftSideLineAngle_deg") boxModelResult.LeftSideLineAngle_deg = GetRandomFloat(0.0f, 360.0f);
            if (OmitPropName != "LeftSideLineStartLatitude") boxModelResult.LeftSideLineStartLatitude = GetRandomFloat(-90.0f, 90.0f);
            if (OmitPropName != "LeftSideLineStartLongitude") boxModelResult.LeftSideLineStartLongitude = GetRandomFloat(-180.0f, 180.0f);
            if (OmitPropName != "LastUpdateDate_UTC") boxModelResult.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelResult.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return boxModelResult;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void BoxModelResult_Testing()
        {
            SetupTestHelper(culture);
            BoxModelResultService boxModelResultService = new BoxModelResultService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            BoxModelResult boxModelResult = GetFilledRandomBoxModelResult("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(true, boxModelResultService.GetRead().Where(c => c == boxModelResult).Any());
            boxModelResult.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, boxModelResultService.Update(boxModelResult));
            Assert.AreEqual(1, boxModelResultService.GetRead().Count());
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // BoxModelID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [BoxModelResultType]

            // Volume_m3 will automatically be initialized at 0 --> not null

            // Surface_m2 will automatically be initialized at 0 --> not null

            // Radius_m will automatically be initialized at 0 --> not null

            // LeftSideDiameterLineAngle_deg will automatically be initialized at 0 --> not null

            // CircleCenterLatitude will automatically be initialized at 0 --> not null

            // CircleCenterLongitude will automatically be initialized at 0 --> not null

            // FixLength will automatically be initialized at 0 --> not null

            // FixWidth will automatically be initialized at 0 --> not null

            // RectLength_m will automatically be initialized at 0 --> not null

            // RectWidth_m will automatically be initialized at 0 --> not null

            // LeftSideLineAngle_deg will automatically be initialized at 0 --> not null

            // LeftSideLineStartLatitude will automatically be initialized at 0 --> not null

            // LeftSideLineStartLongitude will automatically be initialized at 0 --> not null

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("LastUpdateDate_UTC");
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(1, boxModelResult.ValidationResults.Count());
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultLastUpdateDate_UTC)).Any());
            Assert.IsTrue(boxModelResult.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [BoxModel]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [BoxModelResultID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [BoxModelID] of type [Int32]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // BoxModelID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModelResult.BoxModelID = 1;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1, boxModelResult.BoxModelID);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // BoxModelID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModelResult.BoxModelID = 2;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(2, boxModelResult.BoxModelID);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // BoxModelID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModelResult.BoxModelID = 0;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultBoxModelID, "1")).Any());
            Assert.AreEqual(0, boxModelResult.BoxModelID);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [BoxModelResultType] of type [BoxModelResultTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Volume_m3] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // Volume_m3 has Min [0] and Max [empty]. At Min should return true and no errors
            boxModelResult.Volume_m3 = 0.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModelResult.Volume_m3);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // Volume_m3 has Min [0] and Max [empty]. At Min + 1 should return true and no errors
            boxModelResult.Volume_m3 = 1.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModelResult.Volume_m3);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // Volume_m3 has Min [0] and Max [empty]. At Min - 1 should return false with one error
            boxModelResult.Volume_m3 = -1.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultVolume_m3, "0")).Any());
            Assert.AreEqual(-1.0f, boxModelResult.Volume_m3);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [Surface_m2] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // Surface_m2 has Min [0] and Max [empty]. At Min should return true and no errors
            boxModelResult.Surface_m2 = 0.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModelResult.Surface_m2);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // Surface_m2 has Min [0] and Max [empty]. At Min + 1 should return true and no errors
            boxModelResult.Surface_m2 = 1.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModelResult.Surface_m2);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // Surface_m2 has Min [0] and Max [empty]. At Min - 1 should return false with one error
            boxModelResult.Surface_m2 = -1.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultSurface_m2, "0")).Any());
            Assert.AreEqual(-1.0f, boxModelResult.Surface_m2);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [Radius_m] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // Radius_m has Min [0] and Max [100000]. At Min should return true and no errors
            boxModelResult.Radius_m = 0.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModelResult.Radius_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            boxModelResult.Radius_m = 1.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModelResult.Radius_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0] and Max [100000]. At Min - 1 should return false with one error
            boxModelResult.Radius_m = -1.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRadius_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0f, boxModelResult.Radius_m);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0] and Max [100000]. At Max should return true and no errors
            boxModelResult.Radius_m = 100000.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(100000.0f, boxModelResult.Radius_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            boxModelResult.Radius_m = 99999.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(99999.0f, boxModelResult.Radius_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0] and Max [100000]. At Max + 1 should return false with one error
            boxModelResult.Radius_m = 100001.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRadius_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0f, boxModelResult.Radius_m);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [LeftSideDiameterLineAngle_deg] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LeftSideDiameterLineAngle_deg has Min [0] and Max [360]. At Min should return true and no errors
            boxModelResult.LeftSideDiameterLineAngle_deg = 0.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0] and Max [360]. At Min + 1 should return true and no errors
            boxModelResult.LeftSideDiameterLineAngle_deg = 1.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0] and Max [360]. At Min - 1 should return false with one error
            boxModelResult.LeftSideDiameterLineAngle_deg = -1.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360")).Any());
            Assert.AreEqual(-1.0f, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0] and Max [360]. At Max should return true and no errors
            boxModelResult.LeftSideDiameterLineAngle_deg = 360.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(360.0f, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0] and Max [360]. At Max - 1 should return true and no errors
            boxModelResult.LeftSideDiameterLineAngle_deg = 359.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(359.0f, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0] and Max [360]. At Max + 1 should return false with one error
            boxModelResult.LeftSideDiameterLineAngle_deg = 361.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360")).Any());
            Assert.AreEqual(361.0f, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [CircleCenterLatitude] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // CircleCenterLatitude has Min [-90] and Max [90]. At Min should return true and no errors
            boxModelResult.CircleCenterLatitude = -90.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-90.0f, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90] and Max [90]. At Min + 1 should return true and no errors
            boxModelResult.CircleCenterLatitude = -89.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-89.0f, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90] and Max [90]. At Min - 1 should return false with one error
            boxModelResult.CircleCenterLatitude = -91.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90")).Any());
            Assert.AreEqual(-91.0f, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90] and Max [90]. At Max should return true and no errors
            boxModelResult.CircleCenterLatitude = 90.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(90.0f, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90] and Max [90]. At Max - 1 should return true and no errors
            boxModelResult.CircleCenterLatitude = 89.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(89.0f, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90] and Max [90]. At Max + 1 should return false with one error
            boxModelResult.CircleCenterLatitude = 91.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90")).Any());
            Assert.AreEqual(91.0f, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [CircleCenterLongitude] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // CircleCenterLongitude has Min [-180] and Max [180]. At Min should return true and no errors
            boxModelResult.CircleCenterLongitude = -180.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-180.0f, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            boxModelResult.CircleCenterLongitude = -179.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-179.0f, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180] and Max [180]. At Min - 1 should return false with one error
            boxModelResult.CircleCenterLongitude = -181.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180] and Max [180]. At Max should return true and no errors
            boxModelResult.CircleCenterLongitude = 180.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(180.0f, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            boxModelResult.CircleCenterLongitude = 179.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(179.0f, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180] and Max [180]. At Max + 1 should return false with one error
            boxModelResult.CircleCenterLongitude = 181.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180")).Any());
            Assert.AreEqual(181.0f, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [FixLength] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [FixWidth] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [RectLength_m] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // RectLength_m has Min [0] and Max [100000]. At Min should return true and no errors
            boxModelResult.RectLength_m = 0.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModelResult.RectLength_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            boxModelResult.RectLength_m = 1.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModelResult.RectLength_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0] and Max [100000]. At Min - 1 should return false with one error
            boxModelResult.RectLength_m = -1.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectLength_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0f, boxModelResult.RectLength_m);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0] and Max [100000]. At Max should return true and no errors
            boxModelResult.RectLength_m = 100000.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(100000.0f, boxModelResult.RectLength_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            boxModelResult.RectLength_m = 99999.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(99999.0f, boxModelResult.RectLength_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0] and Max [100000]. At Max + 1 should return false with one error
            boxModelResult.RectLength_m = 100001.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectLength_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0f, boxModelResult.RectLength_m);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [RectWidth_m] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // RectWidth_m has Min [0] and Max [100000]. At Min should return true and no errors
            boxModelResult.RectWidth_m = 0.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModelResult.RectWidth_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            boxModelResult.RectWidth_m = 1.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModelResult.RectWidth_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0] and Max [100000]. At Min - 1 should return false with one error
            boxModelResult.RectWidth_m = -1.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectWidth_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0f, boxModelResult.RectWidth_m);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0] and Max [100000]. At Max should return true and no errors
            boxModelResult.RectWidth_m = 100000.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(100000.0f, boxModelResult.RectWidth_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            boxModelResult.RectWidth_m = 99999.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(99999.0f, boxModelResult.RectWidth_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0] and Max [100000]. At Max + 1 should return false with one error
            boxModelResult.RectWidth_m = 100001.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectWidth_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0f, boxModelResult.RectWidth_m);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [LeftSideLineAngle_deg] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LeftSideLineAngle_deg has Min [0] and Max [360]. At Min should return true and no errors
            boxModelResult.LeftSideLineAngle_deg = 0.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0f, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0] and Max [360]. At Min + 1 should return true and no errors
            boxModelResult.LeftSideLineAngle_deg = 1.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0f, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0] and Max [360]. At Min - 1 should return false with one error
            boxModelResult.LeftSideLineAngle_deg = -1.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360")).Any());
            Assert.AreEqual(-1.0f, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0] and Max [360]. At Max should return true and no errors
            boxModelResult.LeftSideLineAngle_deg = 360.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(360.0f, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0] and Max [360]. At Max - 1 should return true and no errors
            boxModelResult.LeftSideLineAngle_deg = 359.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(359.0f, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0] and Max [360]. At Max + 1 should return false with one error
            boxModelResult.LeftSideLineAngle_deg = 361.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360")).Any());
            Assert.AreEqual(361.0f, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [LeftSideLineStartLatitude] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LeftSideLineStartLatitude has Min [-90] and Max [90]. At Min should return true and no errors
            boxModelResult.LeftSideLineStartLatitude = -90.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-90.0f, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90] and Max [90]. At Min + 1 should return true and no errors
            boxModelResult.LeftSideLineStartLatitude = -89.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-89.0f, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90] and Max [90]. At Min - 1 should return false with one error
            boxModelResult.LeftSideLineStartLatitude = -91.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90")).Any());
            Assert.AreEqual(-91.0f, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90] and Max [90]. At Max should return true and no errors
            boxModelResult.LeftSideLineStartLatitude = 90.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(90.0f, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90] and Max [90]. At Max - 1 should return true and no errors
            boxModelResult.LeftSideLineStartLatitude = 89.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(89.0f, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90] and Max [90]. At Max + 1 should return false with one error
            boxModelResult.LeftSideLineStartLatitude = 91.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90")).Any());
            Assert.AreEqual(91.0f, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [LeftSideLineStartLongitude] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LeftSideLineStartLongitude has Min [-180] and Max [180]. At Min should return true and no errors
            boxModelResult.LeftSideLineStartLongitude = -180.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-180.0f, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180] and Max [180]. At Min + 1 should return true and no errors
            boxModelResult.LeftSideLineStartLongitude = -179.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-179.0f, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180] and Max [180]. At Min - 1 should return false with one error
            boxModelResult.LeftSideLineStartLongitude = -181.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180")).Any());
            Assert.AreEqual(-181.0f, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180] and Max [180]. At Max should return true and no errors
            boxModelResult.LeftSideLineStartLongitude = 180.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(180.0f, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180] and Max [180]. At Max - 1 should return true and no errors
            boxModelResult.LeftSideLineStartLongitude = 179.0f;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(179.0f, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180] and Max [180]. At Max + 1 should return false with one error
            boxModelResult.LeftSideLineStartLongitude = 181.0f;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180")).Any());
            Assert.AreEqual(181.0f, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModelResult.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1, boxModelResult.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModelResult.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(2, boxModelResult.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModelResult.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, boxModelResult.LastUpdateContactTVItemID);
            Assert.AreEqual(0, boxModelResultService.GetRead().Count());

            //-----------------------------------
            // doing property [BoxModel] of type [BoxModel]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
