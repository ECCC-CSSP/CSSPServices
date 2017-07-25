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

            if (OmitPropName != "BoxModelID") boxModelResult.BoxModelID = GetRandomInt(1, 11);
            if (OmitPropName != "BoxModelResultType") boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "Volume_m3") boxModelResult.Volume_m3 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Surface_m2") boxModelResult.Surface_m2 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Radius_m") boxModelResult.Radius_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LeftSideDiameterLineAngle_deg") boxModelResult.LeftSideDiameterLineAngle_deg = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "CircleCenterLatitude") boxModelResult.CircleCenterLatitude = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "CircleCenterLongitude") boxModelResult.CircleCenterLongitude = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "FixLength") boxModelResult.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelResult.FixWidth = true;
            if (OmitPropName != "RectLength_m") boxModelResult.RectLength_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "RectWidth_m") boxModelResult.RectWidth_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LeftSideLineAngle_deg") boxModelResult.LeftSideLineAngle_deg = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LeftSideLineStartLatitude") boxModelResult.LeftSideLineStartLatitude = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LeftSideLineStartLongitude") boxModelResult.LeftSideLineStartLongitude = GetRandomDouble(1.0D, 1000.0D);
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
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // BoxModelID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [BoxModelResultType]

            //Error: Type not implemented [Volume_m3]

            //Error: Type not implemented [Surface_m2]

            //Error: Type not implemented [Radius_m]

            //Error: Type not implemented [LeftSideDiameterLineAngle_deg]

            //Error: Type not implemented [CircleCenterLatitude]

            //Error: Type not implemented [CircleCenterLongitude]

            // FixLength will automatically be initialized at 0 --> not null

            // FixWidth will automatically be initialized at 0 --> not null

            //Error: Type not implemented [RectLength_m]

            //Error: Type not implemented [RectWidth_m]

            //Error: Type not implemented [LeftSideLineAngle_deg]

            //Error: Type not implemented [LeftSideLineStartLatitude]

            //Error: Type not implemented [LeftSideLineStartLongitude]

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
            // doing property [Volume_m3] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Surface_m2] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Radius_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LeftSideDiameterLineAngle_deg] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [CircleCenterLatitude] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [CircleCenterLongitude] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [FixLength] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [FixWidth] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [RectLength_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [RectWidth_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LeftSideLineAngle_deg] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LeftSideLineStartLatitude] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LeftSideLineStartLongitude] of type [Double]
            //-----------------------------------

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
