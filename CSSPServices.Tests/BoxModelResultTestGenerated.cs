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
            if (OmitPropName != "Volume_m3") boxModelResult.Volume_m3 = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "Surface_m2") boxModelResult.Surface_m2 = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "Radius_m") boxModelResult.Radius_m = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "LeftSideDiameterLineAngle_deg") boxModelResult.LeftSideDiameterLineAngle_deg = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "CircleCenterLatitude") boxModelResult.CircleCenterLatitude = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "CircleCenterLongitude") boxModelResult.CircleCenterLongitude = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "FixLength") boxModelResult.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelResult.FixWidth = true;
            if (OmitPropName != "RectLength_m") boxModelResult.RectLength_m = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "RectWidth_m") boxModelResult.RectWidth_m = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "LeftSideLineAngle_deg") boxModelResult.LeftSideLineAngle_deg = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "LeftSideLineStartLatitude") boxModelResult.LeftSideLineStartLatitude = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "LeftSideLineStartLongitude") boxModelResult.LeftSideLineStartLongitude = GetRandomFloat(1.0f, 1000.0f);
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

            //-----------------------------------
            // doing property [Surface_m2] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");

            //-----------------------------------
            // doing property [Radius_m] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");

            //-----------------------------------
            // doing property [LeftSideDiameterLineAngle_deg] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");

            //-----------------------------------
            // doing property [CircleCenterLatitude] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");

            //-----------------------------------
            // doing property [CircleCenterLongitude] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");

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

            //-----------------------------------
            // doing property [RectWidth_m] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");

            //-----------------------------------
            // doing property [LeftSideLineAngle_deg] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");

            //-----------------------------------
            // doing property [LeftSideLineStartLatitude] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");

            //-----------------------------------
            // doing property [LeftSideLineStartLongitude] of type [Single]
            //-----------------------------------

            boxModelResult = null;
            boxModelResult = GetFilledRandomBoxModelResult("");

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
