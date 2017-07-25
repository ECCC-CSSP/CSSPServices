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
    public partial class RatingCurveValueTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private RatingCurveValueService ratingCurveValueService { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueTest() : base()
        {
            ratingCurveValueService = new RatingCurveValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private RatingCurveValue GetFilledRandomRatingCurveValue(string OmitPropName)
        {
            RatingCurveValue ratingCurveValue = new RatingCurveValue();

            if (OmitPropName != "RatingCurveID") ratingCurveValue.RatingCurveID = GetRandomInt(1, 11);
            if (OmitPropName != "StageValue_m") ratingCurveValue.StageValue_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "DischargeValue_m3_s") ratingCurveValue.DischargeValue_m3_s = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurveValue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurveValue.LastUpdateContactTVItemID = 2;

            return ratingCurveValue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void RatingCurveValue_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            RatingCurveValue ratingCurveValue = GetFilledRandomRatingCurveValue("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = ratingCurveValueService.GetRead().Count();

            ratingCurveValueService.Add(ratingCurveValue);
            if (ratingCurveValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, ratingCurveValueService.GetRead().Where(c => c == ratingCurveValue).Any());
            ratingCurveValueService.Update(ratingCurveValue);
            if (ratingCurveValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, ratingCurveValueService.GetRead().Count());
            ratingCurveValueService.Delete(ratingCurveValue);
            if (ratingCurveValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // RatingCurveID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [StageValue_m]

            //Error: Type not implemented [DischargeValue_m3_s]

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("LastUpdateDate_UTC");
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(1, ratingCurveValue.ValidationResults.Count());
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveValueLastUpdateDate_UTC)).Any());
            Assert.IsTrue(ratingCurveValue.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [RatingCurve]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [RatingCurveValueID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [RatingCurveID] of type [Int32]
            //-----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            // RatingCurveID has Min [1] and Max [empty]. At Min should return true and no errors
            ratingCurveValue.RatingCurveID = 1;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1, ratingCurveValue.RatingCurveID);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // RatingCurveID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            ratingCurveValue.RatingCurveID = 2;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(2, ratingCurveValue.RatingCurveID);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // RatingCurveID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            ratingCurveValue.RatingCurveID = 0;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveValueRatingCurveID, "1")).Any());
            Assert.AreEqual(0, ratingCurveValue.RatingCurveID);
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());

            //-----------------------------------
            // doing property [StageValue_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [DischargeValue_m3_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            ratingCurveValue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1, ratingCurveValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            ratingCurveValue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(2, ratingCurveValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            ratingCurveValue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveValueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, ratingCurveValue.LastUpdateContactTVItemID);
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());

            //-----------------------------------
            // doing property [RatingCurve] of type [RatingCurve]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
