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

            if (OmitPropName != "RatingCurveID") ratingCurveValue.RatingCurveID = 1;
            if (OmitPropName != "StageValue_m") ratingCurveValue.StageValue_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "DischargeValue_m3_s") ratingCurveValue.DischargeValue_m3_s = GetRandomDouble(0.0D, 1000000.0D);
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
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // ratingCurveValue.RatingCurveValueID   (Int32)
            //-----------------------------------
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.RatingCurveValueID = 0;
            ratingCurveValueService.Update(ratingCurveValue);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveValueRatingCurveValueID), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "RatingCurve", Plurial = "s", FieldID = "RatingCurveID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // ratingCurveValue.RatingCurveID   (Int32)
            //-----------------------------------
            // RatingCurveID will automatically be initialized at 0 --> not null


            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            // RatingCurveID has Min [1] and Max [empty]. At Min should return true and no errors
            ratingCurveValue.RatingCurveID = 1;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1, ratingCurveValue.RatingCurveID);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // RatingCurveID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            ratingCurveValue.RatingCurveID = 2;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(2, ratingCurveValue.RatingCurveID);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // RatingCurveID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            ratingCurveValue.RatingCurveID = 0;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveValueRatingCurveID, "1")).Any());
            Assert.AreEqual(0, ratingCurveValue.RatingCurveID);
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000)]
            // ratingCurveValue.StageValue_m   (Double)
            //-----------------------------------
            //Error: Type not implemented [StageValue_m]


            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            // StageValue_m has Min [0.0D] and Max [1000.0D]. At Min should return true and no errors
            ratingCurveValue.StageValue_m = 0.0D;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, ratingCurveValue.StageValue_m);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0.0D] and Max [1000.0D]. At Min + 1 should return true and no errors
            ratingCurveValue.StageValue_m = 1.0D;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, ratingCurveValue.StageValue_m);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0.0D] and Max [1000.0D]. At Min - 1 should return false with one error
            ratingCurveValue.StageValue_m = -1.0D;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueStageValue_m, "0", "1000")).Any());
            Assert.AreEqual(-1.0D, ratingCurveValue.StageValue_m);
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0.0D] and Max [1000.0D]. At Max should return true and no errors
            ratingCurveValue.StageValue_m = 1000.0D;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1000.0D, ratingCurveValue.StageValue_m);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0.0D] and Max [1000.0D]. At Max - 1 should return true and no errors
            ratingCurveValue.StageValue_m = 999.0D;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(999.0D, ratingCurveValue.StageValue_m);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // StageValue_m has Min [0.0D] and Max [1000.0D]. At Max + 1 should return false with one error
            ratingCurveValue.StageValue_m = 1001.0D;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueStageValue_m, "0", "1000")).Any());
            Assert.AreEqual(1001.0D, ratingCurveValue.StageValue_m);
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 1000000)]
            // ratingCurveValue.DischargeValue_m3_s   (Double)
            //-----------------------------------
            //Error: Type not implemented [DischargeValue_m3_s]


            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            // DischargeValue_m3_s has Min [0.0D] and Max [1000000.0D]. At Min should return true and no errors
            ratingCurveValue.DischargeValue_m3_s = 0.0D;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0.0D] and Max [1000000.0D]. At Min + 1 should return true and no errors
            ratingCurveValue.DischargeValue_m3_s = 1.0D;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0.0D] and Max [1000000.0D]. At Min - 1 should return false with one error
            ratingCurveValue.DischargeValue_m3_s = -1.0D;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000")).Any());
            Assert.AreEqual(-1.0D, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0.0D] and Max [1000000.0D]. At Max should return true and no errors
            ratingCurveValue.DischargeValue_m3_s = 1000000.0D;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1000000.0D, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0.0D] and Max [1000000.0D]. At Max - 1 should return true and no errors
            ratingCurveValue.DischargeValue_m3_s = 999999.0D;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(999999.0D, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // DischargeValue_m3_s has Min [0.0D] and Max [1000000.0D]. At Max + 1 should return false with one error
            ratingCurveValue.DischargeValue_m3_s = 1000001.0D;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0D, ratingCurveValue.DischargeValue_m3_s);
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // ratingCurveValue.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // ratingCurveValue.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            ratingCurveValue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(1, ratingCurveValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            ratingCurveValue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, ratingCurveValueService.Add(ratingCurveValue));
            Assert.AreEqual(0, ratingCurveValue.ValidationResults.Count());
            Assert.AreEqual(2, ratingCurveValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, ratingCurveValueService.Delete(ratingCurveValue));
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            ratingCurveValue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
            Assert.IsTrue(ratingCurveValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveValueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, ratingCurveValue.LastUpdateContactTVItemID);
            Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // ratingCurveValue.RatingCurve   (RatingCurve)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // ratingCurveValue.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
