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
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class RatingCurveValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private RatingCurveValueService ratingCurveValueService { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueServiceTest() : base()
        {
            //ratingCurveValueService = new RatingCurveValueService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurveValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurveValue.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") ratingCurveValue.LastUpdateContactTVText = GetRandomString("", 5);

            return ratingCurveValue;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RatingCurveValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(LanguageRequest, dbTestDB, ContactID);

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


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // ratingCurveValue.RatingCurveValueID   (Int32)
                // -----------------------------------

                ratingCurveValue = null;
                ratingCurveValue = GetFilledRandomRatingCurveValue("");
                ratingCurveValue.RatingCurveValueID = 0;
                ratingCurveValueService.Update(ratingCurveValue);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveValueRatingCurveValueID), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "RatingCurve", ExistPlurial = "s", ExistFieldID = "RatingCurveID", AllowableTVtypeList = Error)]
                // ratingCurveValue.RatingCurveID   (Int32)
                // -----------------------------------

                ratingCurveValue = null;
                ratingCurveValue = GetFilledRandomRatingCurveValue("");
                ratingCurveValue.RatingCurveID = 0;
                ratingCurveValueService.Add(ratingCurveValue);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.RatingCurve, ModelsRes.RatingCurveValueRatingCurveID, ratingCurveValue.RatingCurveID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 1000)]
                // ratingCurveValue.StageValue_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [StageValue_m]

                ratingCurveValue = null;
                ratingCurveValue = GetFilledRandomRatingCurveValue("");
                ratingCurveValue.StageValue_m = -1.0D;
                Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueStageValue_m, "0", "1000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
                ratingCurveValue = null;
                ratingCurveValue = GetFilledRandomRatingCurveValue("");
                ratingCurveValue.StageValue_m = 1001.0D;
                Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueStageValue_m, "0", "1000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 1000000)]
                // ratingCurveValue.DischargeValue_m3_s   (Double)
                // -----------------------------------

                //Error: Type not implemented [DischargeValue_m3_s]

                ratingCurveValue = null;
                ratingCurveValue = GetFilledRandomRatingCurveValue("");
                ratingCurveValue.DischargeValue_m3_s = -1.0D;
                Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
                ratingCurveValue = null;
                ratingCurveValue = GetFilledRandomRatingCurveValue("");
                ratingCurveValue.DischargeValue_m3_s = 1000001.0D;
                Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // ratingCurveValue.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // ratingCurveValue.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                ratingCurveValue = null;
                ratingCurveValue = GetFilledRandomRatingCurveValue("");
                ratingCurveValue.LastUpdateContactTVItemID = 0;
                ratingCurveValueService.Add(ratingCurveValue);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.RatingCurveValueLastUpdateContactTVItemID, ratingCurveValue.LastUpdateContactTVItemID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

                ratingCurveValue = null;
                ratingCurveValue = GetFilledRandomRatingCurveValue("");
                ratingCurveValue.LastUpdateContactTVItemID = 1;
                ratingCurveValueService.Add(ratingCurveValue);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.RatingCurveValueLastUpdateContactTVItemID, "Contact"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // ratingCurveValue.LastUpdateContactTVText   (String)
                // -----------------------------------

                ratingCurveValue = null;
                ratingCurveValue = GetFilledRandomRatingCurveValue("");
                ratingCurveValue.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RatingCurveValueLastUpdateContactTVText, "200"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // ratingCurveValue.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void RatingCurveValue_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(LanguageRequest, dbTestDB, ContactID);
                RatingCurveValue ratingCurveValue = (from c in ratingCurveValueService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(ratingCurveValue);

                RatingCurveValue ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID);
                Assert.AreEqual(ratingCurveValue.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);
                Assert.AreEqual(ratingCurveValue.RatingCurveID, ratingCurveValueRet.RatingCurveID);
                Assert.AreEqual(ratingCurveValue.StageValue_m, ratingCurveValueRet.StageValue_m);
                Assert.AreEqual(ratingCurveValue.DischargeValue_m3_s, ratingCurveValueRet.DischargeValue_m3_s);
                Assert.AreEqual(ratingCurveValue.LastUpdateDate_UTC, ratingCurveValueRet.LastUpdateDate_UTC);
                Assert.AreEqual(ratingCurveValue.LastUpdateContactTVItemID, ratingCurveValueRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(ratingCurveValueRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveValueRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}
