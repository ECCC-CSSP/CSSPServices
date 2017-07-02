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
        private int RatingCurveValueID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private RatingCurveValue GetFilledRandomRatingCurveValue(string OmitPropName)
        {
            RatingCurveValueID += 1;

            RatingCurveValue ratingCurveValue = new RatingCurveValue();

            if (OmitPropName != "RatingCurveValueID") ratingCurveValue.RatingCurveValueID = RatingCurveValueID;
            if (OmitPropName != "RatingCurveID") ratingCurveValue.RatingCurveID = GetRandomInt(1, 11);
            if (OmitPropName != "StageValue_m") ratingCurveValue.StageValue_m = GetRandomFloat(0, 1000);
            if (OmitPropName != "DischargeValue_m3_s") ratingCurveValue.DischargeValue_m3_s = GetRandomFloat(0, 1000000);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurveValue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurveValue.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return ratingCurveValue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void RatingCurveValue_Testing()
        {
            SetupTestHelper(culture);
            RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            RatingCurveValue ratingCurveValue = GetFilledRandomRatingCurveValue("");
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(true, ratingCurveValueService.GetRead().Where(c => c == ratingCurveValue).Any());
            ratingCurveValue.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, ratingCurveValueService.Update(ratingCurveValue));
            Assert.AreEqual(1, ratingCurveValueService.GetRead().Count());
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // RatingCurveID will automatically be initialized at 0 --> not null

            // StageValue_m will automatically be initialized at 0.0f --> not null

            // DischargeValue_m3_s will automatically be initialized at 0.0f --> not null

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("LastUpdateDate_UTC");
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(1, ratingCurveValue.ValidationResults.Count());
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveValueLastUpdateDate_UTC)).Any());
            Assert.IsTrue(ratingCurveValue.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [RatingCurveValueID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [RatingCurveID] of type [int]
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
            // doing property [StageValue_m] of type [float]
            //-----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            // StageValue_m has Min [0] and Max [1000]. At Min should return true and no errors
            ratingCurveValue.StageValue_m = 0.0f;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, ratingCurveValue.StageValue_m);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            ratingCurveValue.StageValue_m = 1.0f;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, ratingCurveValue.StageValue_m);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0] and Max [1000]. At Min - 1 should return false with one error
            ratingCurveValue.StageValue_m = -1.0f;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueStageValue_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0f, ratingCurveValue.StageValue_m);
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0] and Max [1000]. At Max should return true and no errors
            ratingCurveValue.StageValue_m = 1000.0f;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1000.0f, ratingCurveValue.StageValue_m);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            ratingCurveValue.StageValue_m = 999.0f;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(999.0f, ratingCurveValue.StageValue_m);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0] and Max [1000]. At Max + 1 should return false with one error
            ratingCurveValue.StageValue_m = 1001.0f;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueStageValue_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0f, ratingCurveValue.StageValue_m);
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());

            //-----------------------------------
            // doing property [DischargeValue_m3_s] of type [float]
            //-----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            // DischargeValue_m3_s has Min [0] and Max [1000000]. At Min should return true and no errors
            ratingCurveValue.DischargeValue_m3_s = 0.0f;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(0.0f, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            ratingCurveValue.DischargeValue_m3_s = 1.0f;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1.0f, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            ratingCurveValue.DischargeValue_m3_s = -1.0f;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0] and Max [1000000]. At Max should return true and no errors
            ratingCurveValue.DischargeValue_m3_s = 1000000.0f;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            ratingCurveValue.DischargeValue_m3_s = 999999.0f;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(999999.0f, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            ratingCurveValue.DischargeValue_m3_s = 1000001.0f;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(0, ratingCurveValueService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
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

        }
        #endregion Tests Generated
    }
}
