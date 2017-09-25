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
    public partial class RatingCurveServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private RatingCurveService ratingCurveService { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveServiceTest() : base()
        {
            //ratingCurveService = new RatingCurveService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private RatingCurve GetFilledRandomRatingCurve(string OmitPropName)
        {
            RatingCurve ratingCurve = new RatingCurve();

            if (OmitPropName != "HydrometricSiteID") ratingCurve.HydrometricSiteID = 1;
            if (OmitPropName != "RatingCurveNumber") ratingCurve.RatingCurveNumber = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurve.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurve.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") ratingCurve.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") ratingCurve.HasErrors = true;

            return ratingCurve;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RatingCurve_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveService ratingCurveService = new RatingCurveService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    RatingCurve ratingCurve = GetFilledRandomRatingCurve("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = ratingCurveService.GetRead().Count();

                    Assert.AreEqual(ratingCurveService.GetRead().Count(), ratingCurveService.GetEdit().Count());

                    ratingCurveService.Add(ratingCurve);
                    if (ratingCurve.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, ratingCurveService.GetRead().Where(c => c == ratingCurve).Any());
                    ratingCurveService.Update(ratingCurve);
                    if (ratingCurve.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, ratingCurveService.GetRead().Count());
                    ratingCurveService.Delete(ratingCurve);
                    if (ratingCurve.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // ratingCurve.RatingCurveID   (Int32)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveID = 0;
                    ratingCurveService.Update(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveRatingCurveID), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveID = 10000000;
                    ratingCurveService.Update(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RatingCurve, CSSPModelsRes.RatingCurveRatingCurveID, ratingCurve.RatingCurveID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = Error)]
                    // ratingCurve.HydrometricSiteID   (Int32)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.HydrometricSiteID = 0;
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.HydrometricSite, CSSPModelsRes.RatingCurveHydrometricSiteID, ratingCurve.HydrometricSiteID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // ratingCurve.RatingCurveNumber   (String)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("RatingCurveNumber");
                    Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                    Assert.AreEqual(1, ratingCurve.ValidationResults.Count());
                    Assert.IsTrue(ratingCurve.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveRatingCurveNumber)).Any());
                    Assert.AreEqual(null, ratingCurve.RatingCurveNumber);
                    Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveNumber = GetRandomString("", 51);
                    Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RatingCurveRatingCurveNumber, "50"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // ratingCurve.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // ratingCurve.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateContactTVItemID = 0;
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.RatingCurveLastUpdateContactTVItemID, ratingCurve.LastUpdateContactTVItemID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateContactTVItemID = 1;
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.RatingCurveLastUpdateContactTVItemID, "Contact"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // ratingCurve.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RatingCurveLastUpdateContactTVText, "200"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurve.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurve.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void RatingCurve_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveService ratingCurveService = new RatingCurveService(LanguageRequest, dbTestDB, ContactID);
                    RatingCurve ratingCurve = (from c in ratingCurveService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    RatingCurve ratingCurveRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityIncludingNotMapped })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityIncludingNotMapped)
                        {
                            ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID, EntityQueryDetailTypeEnum.EntityIncludingNotMapped);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(ratingCurveRet.RatingCurveID);
                        Assert.IsNotNull(ratingCurveRet.HydrometricSiteID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveRet.RatingCurveNumber));
                        Assert.IsNotNull(ratingCurveRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(ratingCurveRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (ratingCurveRet.LastUpdateContactTVText != null)
                            {
                                Assert.IsTrue(string.IsNullOrWhiteSpace(ratingCurveRet.LastUpdateContactTVText));
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityIncludingNotMapped)
                        {
                            if (ratingCurveRet.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveRet.LastUpdateContactTVText));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of RatingCurve
        #endregion Tests Get List of RatingCurve

    }
}
