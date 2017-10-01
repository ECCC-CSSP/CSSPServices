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

            // Need to implement (no items found, would need to add at least one in the TestDB) [RatingCurveValue RatingCurveID RatingCurve RatingCurveID]
            if (OmitPropName != "StageValue_m") ratingCurveValue.StageValue_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "DischargeValue_m3_s") ratingCurveValue.DischargeValue_m3_s = GetRandomDouble(0.0D, 1000000.0D);
            //Error: property [RatingCurveValueWeb] and type [RatingCurveValue] is  not implemented
            //Error: property [RatingCurveValueReport] and type [RatingCurveValue] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurveValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurveValue.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") ratingCurveValue.HasErrors = true;

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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
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

                    Assert.AreEqual(ratingCurveValueService.GetRead().Count(), ratingCurveValueService.GetEdit().Count());

                    ratingCurveValueService.Add(ratingCurveValue);
                    if (ratingCurveValue.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, ratingCurveValueService.GetRead().Where(c => c == ratingCurveValue).Any());
                    ratingCurveValueService.Update(ratingCurveValue);
                    if (ratingCurveValue.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, ratingCurveValueService.GetRead().Count());
                    ratingCurveValueService.Delete(ratingCurveValue);
                    if (ratingCurveValue.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveValueRatingCurveValueID), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveValueID = 10000000;
                    ratingCurveValueService.Update(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RatingCurveValue, CSSPModelsRes.RatingCurveValueRatingCurveValueID, ratingCurveValue.RatingCurveValueID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "RatingCurve", ExistPlurial = "s", ExistFieldID = "RatingCurveID", AllowableTVtypeList = Error)]
                    // ratingCurveValue.RatingCurveID   (Int32)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveID = 0;
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RatingCurve, CSSPModelsRes.RatingCurveValueRatingCurveID, ratingCurveValue.RatingCurveID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueStageValue_m, "0", "1000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.StageValue_m = 1001.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueStageValue_m, "0", "1000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.DischargeValue_m3_s = 1000001.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // ratingCurveValue.RatingCurveValueWeb   (RatingCurveValueWeb)
                    // -----------------------------------

                    //Error: Type not implemented [RatingCurveValueWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // ratingCurveValue.RatingCurveValueReport   (RatingCurveValueReport)
                    // -----------------------------------

                    //Error: Type not implemented [RatingCurveValueReport]


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
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.RatingCurveValueLastUpdateContactTVItemID, ratingCurveValue.LastUpdateContactTVItemID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.LastUpdateContactTVItemID = 1;
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.RatingCurveValueLastUpdateContactTVItemID, "Contact"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurveValue.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurveValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(LanguageRequest, dbTestDB, ContactID);
                    RatingCurveValue ratingCurveValue = (from c in ratingCurveValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurveValue);

                    RatingCurveValue ratingCurveValueRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(ratingCurveValueRet.RatingCurveValueID);
                        Assert.IsNotNull(ratingCurveValueRet.RatingCurveID);
                        Assert.IsNotNull(ratingCurveValueRet.StageValue_m);
                        Assert.IsNotNull(ratingCurveValueRet.DischargeValue_m3_s);
                        Assert.IsNotNull(ratingCurveValueRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(ratingCurveValueRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (ratingCurveValueRet.RatingCurveValueWeb != null)
                            {
                                Assert.IsNull(ratingCurveValueRet.RatingCurveValueWeb);
                            }
                            if (ratingCurveValueRet.RatingCurveValueReport != null)
                            {
                                Assert.IsNull(ratingCurveValueRet.RatingCurveValueReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (ratingCurveValueRet.RatingCurveValueWeb != null)
                            {
                                Assert.IsNotNull(ratingCurveValueRet.RatingCurveValueWeb);
                            }
                            if (ratingCurveValueRet.RatingCurveValueReport != null)
                            {
                                Assert.IsNotNull(ratingCurveValueRet.RatingCurveValueReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of RatingCurveValue
        #endregion Tests Get List of RatingCurveValue

    }
}
