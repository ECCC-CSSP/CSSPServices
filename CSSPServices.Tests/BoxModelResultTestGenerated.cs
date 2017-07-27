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
        private BoxModelResultService boxModelResultService { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelResultTest() : base()
        {
            boxModelResultService = new BoxModelResultService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModelResult GetFilledRandomBoxModelResult(string OmitPropName)
        {
            BoxModelResult boxModelResult = new BoxModelResult();

            if (OmitPropName != "BoxModelID") boxModelResult.BoxModelID = 1;
            if (OmitPropName != "BoxModelResultType") boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "Volume_m3") boxModelResult.Volume_m3 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Surface_m2") boxModelResult.Surface_m2 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Radius_m") boxModelResult.Radius_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideDiameterLineAngle_deg") boxModelResult.LeftSideDiameterLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "CircleCenterLatitude") boxModelResult.CircleCenterLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "CircleCenterLongitude") boxModelResult.CircleCenterLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "FixLength") boxModelResult.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelResult.FixWidth = true;
            if (OmitPropName != "RectLength_m") boxModelResult.RectLength_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "RectWidth_m") boxModelResult.RectWidth_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideLineAngle_deg") boxModelResult.LeftSideLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "LeftSideLineStartLatitude") boxModelResult.LeftSideLineStartLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "LeftSideLineStartLongitude") boxModelResult.LeftSideLineStartLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") boxModelResult.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelResult.LastUpdateContactTVItemID = 2;

            return boxModelResult;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void BoxModelResult_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            BoxModelResult boxModelResult = GetFilledRandomBoxModelResult("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = boxModelResultService.GetRead().Count();

            boxModelResultService.Add(boxModelResult);
            if (boxModelResult.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, boxModelResultService.GetRead().Where(c => c == boxModelResult).Any());
            boxModelResultService.Update(boxModelResult);
            if (boxModelResult.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, boxModelResultService.GetRead().Count());
            boxModelResultService.Delete(boxModelResult);
            if (boxModelResult.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // boxModelResult.BoxModelResultID   (Int32)
            // -----------------------------------

            boxModelResult = GetFilledRandomBoxModelResult("");
            boxModelResult.BoxModelResultID = 0;
            boxModelResultService.Update(boxModelResult);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultID), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "BoxModel", Plurial = "s", FieldID = "BoxModelID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // boxModelResult.BoxModelID   (Int32)
            // -----------------------------------

            // BoxModelID will automatically be initialized at 0 --> not null


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // BoxModelID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModelResult.BoxModelID = 1;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1, boxModelResult.BoxModelID);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // BoxModelID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModelResult.BoxModelID = 2;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(2, boxModelResult.BoxModelID);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // BoxModelID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModelResult.BoxModelID = 0;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultBoxModelID, "1")).Any());
            Assert.AreEqual(0, boxModelResult.BoxModelID);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // boxModelResult.BoxModelResultType   (BoxModelResultTypeEnum)
            // -----------------------------------

            // BoxModelResultType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, -1)]
            // boxModelResult.Volume_m3   (Double)
            // -----------------------------------

            //Error: Type not implemented [Volume_m3]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // Volume_m3 has Min [0.0D] and Max [empty]. At Min should return true and no errors
            boxModelResult.Volume_m3 = 0.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModelResult.Volume_m3);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // Volume_m3 has Min [0.0D] and Max [empty]. At Min + 1 should return true and no errors
            boxModelResult.Volume_m3 = 1.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModelResult.Volume_m3);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // Volume_m3 has Min [0.0D] and Max [empty]. At Min - 1 should return false with one error
            boxModelResult.Volume_m3 = -1.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultVolume_m3, "0")).Any());
            Assert.AreEqual(-1.0D, boxModelResult.Volume_m3);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, -1)]
            // boxModelResult.Surface_m2   (Double)
            // -----------------------------------

            //Error: Type not implemented [Surface_m2]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // Surface_m2 has Min [0.0D] and Max [empty]. At Min should return true and no errors
            boxModelResult.Surface_m2 = 0.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModelResult.Surface_m2);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // Surface_m2 has Min [0.0D] and Max [empty]. At Min + 1 should return true and no errors
            boxModelResult.Surface_m2 = 1.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModelResult.Surface_m2);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // Surface_m2 has Min [0.0D] and Max [empty]. At Min - 1 should return false with one error
            boxModelResult.Surface_m2 = -1.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultSurface_m2, "0")).Any());
            Assert.AreEqual(-1.0D, boxModelResult.Surface_m2);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100000)]
            // boxModelResult.Radius_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [Radius_m]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // Radius_m has Min [0.0D] and Max [100000.0D]. At Min should return true and no errors
            boxModelResult.Radius_m = 0.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModelResult.Radius_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0.0D] and Max [100000.0D]. At Min + 1 should return true and no errors
            boxModelResult.Radius_m = 1.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModelResult.Radius_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0.0D] and Max [100000.0D]. At Min - 1 should return false with one error
            boxModelResult.Radius_m = -1.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRadius_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0D, boxModelResult.Radius_m);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0.0D] and Max [100000.0D]. At Max should return true and no errors
            boxModelResult.Radius_m = 100000.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(100000.0D, boxModelResult.Radius_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0.0D] and Max [100000.0D]. At Max - 1 should return true and no errors
            boxModelResult.Radius_m = 99999.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(99999.0D, boxModelResult.Radius_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // Radius_m has Min [0.0D] and Max [100000.0D]. At Max + 1 should return false with one error
            boxModelResult.Radius_m = 100001.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRadius_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0D, boxModelResult.Radius_m);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 360)]
            // boxModelResult.LeftSideDiameterLineAngle_deg   (Double)
            // -----------------------------------

            //Error: Type not implemented [LeftSideDiameterLineAngle_deg]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LeftSideDiameterLineAngle_deg has Min [0.0D] and Max [360.0D]. At Min should return true and no errors
            boxModelResult.LeftSideDiameterLineAngle_deg = 0.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0.0D] and Max [360.0D]. At Min + 1 should return true and no errors
            boxModelResult.LeftSideDiameterLineAngle_deg = 1.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0.0D] and Max [360.0D]. At Min - 1 should return false with one error
            boxModelResult.LeftSideDiameterLineAngle_deg = -1.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360")).Any());
            Assert.AreEqual(-1.0D, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0.0D] and Max [360.0D]. At Max should return true and no errors
            boxModelResult.LeftSideDiameterLineAngle_deg = 360.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(360.0D, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0.0D] and Max [360.0D]. At Max - 1 should return true and no errors
            boxModelResult.LeftSideDiameterLineAngle_deg = 359.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(359.0D, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideDiameterLineAngle_deg has Min [0.0D] and Max [360.0D]. At Max + 1 should return false with one error
            boxModelResult.LeftSideDiameterLineAngle_deg = 361.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360")).Any());
            Assert.AreEqual(361.0D, boxModelResult.LeftSideDiameterLineAngle_deg);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-90, 90)]
            // boxModelResult.CircleCenterLatitude   (Double)
            // -----------------------------------

            //Error: Type not implemented [CircleCenterLatitude]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // CircleCenterLatitude has Min [-90.0D] and Max [90.0D]. At Min should return true and no errors
            boxModelResult.CircleCenterLatitude = -90.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-90.0D, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90.0D] and Max [90.0D]. At Min + 1 should return true and no errors
            boxModelResult.CircleCenterLatitude = -89.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-89.0D, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90.0D] and Max [90.0D]. At Min - 1 should return false with one error
            boxModelResult.CircleCenterLatitude = -91.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90")).Any());
            Assert.AreEqual(-91.0D, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90.0D] and Max [90.0D]. At Max should return true and no errors
            boxModelResult.CircleCenterLatitude = 90.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(90.0D, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90.0D] and Max [90.0D]. At Max - 1 should return true and no errors
            boxModelResult.CircleCenterLatitude = 89.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(89.0D, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLatitude has Min [-90.0D] and Max [90.0D]. At Max + 1 should return false with one error
            boxModelResult.CircleCenterLatitude = 91.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90")).Any());
            Assert.AreEqual(91.0D, boxModelResult.CircleCenterLatitude);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-180, 180)]
            // boxModelResult.CircleCenterLongitude   (Double)
            // -----------------------------------

            //Error: Type not implemented [CircleCenterLongitude]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // CircleCenterLongitude has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            boxModelResult.CircleCenterLongitude = -180.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-180.0D, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            boxModelResult.CircleCenterLongitude = -179.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-179.0D, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            boxModelResult.CircleCenterLongitude = -181.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            boxModelResult.CircleCenterLongitude = 180.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(180.0D, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            boxModelResult.CircleCenterLongitude = 179.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(179.0D, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // CircleCenterLongitude has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            boxModelResult.CircleCenterLongitude = 181.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180")).Any());
            Assert.AreEqual(181.0D, boxModelResult.CircleCenterLongitude);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // boxModelResult.FixLength   (Boolean)
            // -----------------------------------

            // FixLength will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // boxModelResult.FixWidth   (Boolean)
            // -----------------------------------

            // FixWidth will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100000)]
            // boxModelResult.RectLength_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [RectLength_m]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // RectLength_m has Min [0.0D] and Max [100000.0D]. At Min should return true and no errors
            boxModelResult.RectLength_m = 0.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModelResult.RectLength_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0.0D] and Max [100000.0D]. At Min + 1 should return true and no errors
            boxModelResult.RectLength_m = 1.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModelResult.RectLength_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0.0D] and Max [100000.0D]. At Min - 1 should return false with one error
            boxModelResult.RectLength_m = -1.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectLength_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0D, boxModelResult.RectLength_m);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0.0D] and Max [100000.0D]. At Max should return true and no errors
            boxModelResult.RectLength_m = 100000.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(100000.0D, boxModelResult.RectLength_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0.0D] and Max [100000.0D]. At Max - 1 should return true and no errors
            boxModelResult.RectLength_m = 99999.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(99999.0D, boxModelResult.RectLength_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectLength_m has Min [0.0D] and Max [100000.0D]. At Max + 1 should return false with one error
            boxModelResult.RectLength_m = 100001.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectLength_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0D, boxModelResult.RectLength_m);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100000)]
            // boxModelResult.RectWidth_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [RectWidth_m]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // RectWidth_m has Min [0.0D] and Max [100000.0D]. At Min should return true and no errors
            boxModelResult.RectWidth_m = 0.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModelResult.RectWidth_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0.0D] and Max [100000.0D]. At Min + 1 should return true and no errors
            boxModelResult.RectWidth_m = 1.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModelResult.RectWidth_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0.0D] and Max [100000.0D]. At Min - 1 should return false with one error
            boxModelResult.RectWidth_m = -1.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectWidth_m, "0", "100000")).Any());
            Assert.AreEqual(-1.0D, boxModelResult.RectWidth_m);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0.0D] and Max [100000.0D]. At Max should return true and no errors
            boxModelResult.RectWidth_m = 100000.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(100000.0D, boxModelResult.RectWidth_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0.0D] and Max [100000.0D]. At Max - 1 should return true and no errors
            boxModelResult.RectWidth_m = 99999.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(99999.0D, boxModelResult.RectWidth_m);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // RectWidth_m has Min [0.0D] and Max [100000.0D]. At Max + 1 should return false with one error
            boxModelResult.RectWidth_m = 100001.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectWidth_m, "0", "100000")).Any());
            Assert.AreEqual(100001.0D, boxModelResult.RectWidth_m);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 360)]
            // boxModelResult.LeftSideLineAngle_deg   (Double)
            // -----------------------------------

            //Error: Type not implemented [LeftSideLineAngle_deg]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LeftSideLineAngle_deg has Min [0.0D] and Max [360.0D]. At Min should return true and no errors
            boxModelResult.LeftSideLineAngle_deg = 0.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(0.0D, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0.0D] and Max [360.0D]. At Min + 1 should return true and no errors
            boxModelResult.LeftSideLineAngle_deg = 1.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1.0D, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0.0D] and Max [360.0D]. At Min - 1 should return false with one error
            boxModelResult.LeftSideLineAngle_deg = -1.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360")).Any());
            Assert.AreEqual(-1.0D, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0.0D] and Max [360.0D]. At Max should return true and no errors
            boxModelResult.LeftSideLineAngle_deg = 360.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(360.0D, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0.0D] and Max [360.0D]. At Max - 1 should return true and no errors
            boxModelResult.LeftSideLineAngle_deg = 359.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(359.0D, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineAngle_deg has Min [0.0D] and Max [360.0D]. At Max + 1 should return false with one error
            boxModelResult.LeftSideLineAngle_deg = 361.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360")).Any());
            Assert.AreEqual(361.0D, boxModelResult.LeftSideLineAngle_deg);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-90, 90)]
            // boxModelResult.LeftSideLineStartLatitude   (Double)
            // -----------------------------------

            //Error: Type not implemented [LeftSideLineStartLatitude]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LeftSideLineStartLatitude has Min [-90.0D] and Max [90.0D]. At Min should return true and no errors
            boxModelResult.LeftSideLineStartLatitude = -90.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-90.0D, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90.0D] and Max [90.0D]. At Min + 1 should return true and no errors
            boxModelResult.LeftSideLineStartLatitude = -89.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-89.0D, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90.0D] and Max [90.0D]. At Min - 1 should return false with one error
            boxModelResult.LeftSideLineStartLatitude = -91.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90")).Any());
            Assert.AreEqual(-91.0D, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90.0D] and Max [90.0D]. At Max should return true and no errors
            boxModelResult.LeftSideLineStartLatitude = 90.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(90.0D, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90.0D] and Max [90.0D]. At Max - 1 should return true and no errors
            boxModelResult.LeftSideLineStartLatitude = 89.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(89.0D, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLatitude has Min [-90.0D] and Max [90.0D]. At Max + 1 should return false with one error
            boxModelResult.LeftSideLineStartLatitude = 91.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90")).Any());
            Assert.AreEqual(91.0D, boxModelResult.LeftSideLineStartLatitude);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-180, 180)]
            // boxModelResult.LeftSideLineStartLongitude   (Double)
            // -----------------------------------

            //Error: Type not implemented [LeftSideLineStartLongitude]


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LeftSideLineStartLongitude has Min [-180.0D] and Max [180.0D]. At Min should return true and no errors
            boxModelResult.LeftSideLineStartLongitude = -180.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-180.0D, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180.0D] and Max [180.0D]. At Min + 1 should return true and no errors
            boxModelResult.LeftSideLineStartLongitude = -179.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(-179.0D, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180.0D] and Max [180.0D]. At Min - 1 should return false with one error
            boxModelResult.LeftSideLineStartLongitude = -181.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180")).Any());
            Assert.AreEqual(-181.0D, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180.0D] and Max [180.0D]. At Max should return true and no errors
            boxModelResult.LeftSideLineStartLongitude = 180.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(180.0D, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180.0D] and Max [180.0D]. At Max - 1 should return true and no errors
            boxModelResult.LeftSideLineStartLongitude = 179.0D;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(179.0D, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LeftSideLineStartLongitude has Min [-180.0D] and Max [180.0D]. At Max + 1 should return false with one error
            boxModelResult.LeftSideLineStartLongitude = 181.0D;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180")).Any());
            Assert.AreEqual(181.0D, boxModelResult.LeftSideLineStartLongitude);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // boxModelResult.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // boxModelResult.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            boxModelResult.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(1, boxModelResult.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            boxModelResult.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, boxModelResultService.Add(boxModelResult));
            Assert.AreEqual(0, boxModelResult.ValidationResults.Count());
            Assert.AreEqual(2, boxModelResult.LastUpdateContactTVItemID);
            Assert.AreEqual(true, boxModelResultService.Delete(boxModelResult));
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            boxModelResult.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
            Assert.IsTrue(boxModelResult.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, boxModelResult.LastUpdateContactTVItemID);
            Assert.AreEqual(count, boxModelResultService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // boxModelResult.BoxModel   (BoxModel)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // boxModelResult.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
