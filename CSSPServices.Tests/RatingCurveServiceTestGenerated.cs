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

                ratingCurveService.Add(ratingCurve);
                if (ratingCurve.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, ratingCurveService.GetRead().Where(c => c == ratingCurve).Any());
                ratingCurveService.Update(ratingCurve);
                if (ratingCurve.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, ratingCurveService.GetRead().Count());
                ratingCurveService.Delete(ratingCurve);
                if (ratingCurve.ValidationResults.Count() > 0)
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveRatingCurveID), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "HydrometricSite", Plurial = "s", FieldID = "HydrometricSiteID", AllowableTVtypeList = Error)]
                // ratingCurve.HydrometricSiteID   (Int32)
                // -----------------------------------

                ratingCurve = null;
                ratingCurve = GetFilledRandomRatingCurve("");
                ratingCurve.HydrometricSiteID = 0;
                ratingCurveService.Add(ratingCurve);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.HydrometricSite, ModelsRes.RatingCurveHydrometricSiteID, ratingCurve.HydrometricSiteID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [StringLength(50))]
                // ratingCurve.RatingCurveNumber   (String)
                // -----------------------------------

                ratingCurve = null;
                ratingCurve = GetFilledRandomRatingCurve("RatingCurveNumber");
                Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                Assert.AreEqual(1, ratingCurve.ValidationResults.Count());
                Assert.IsTrue(ratingCurve.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveRatingCurveNumber)).Any());
                Assert.AreEqual(null, ratingCurve.RatingCurveNumber);
                Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                ratingCurve = null;
                ratingCurve = GetFilledRandomRatingCurve("");
                ratingCurve.RatingCurveNumber = GetRandomString("", 51);
                Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RatingCurveRatingCurveNumber, "50"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // ratingCurve.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // ratingCurve.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                ratingCurve = null;
                ratingCurve = GetFilledRandomRatingCurve("");
                ratingCurve.LastUpdateContactTVItemID = 0;
                ratingCurveService.Add(ratingCurve);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.RatingCurveLastUpdateContactTVItemID, ratingCurve.LastUpdateContactTVItemID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

                ratingCurve = null;
                ratingCurve = GetFilledRandomRatingCurve("");
                ratingCurve.LastUpdateContactTVItemID = 1;
                ratingCurveService.Add(ratingCurve);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.RatingCurveLastUpdateContactTVItemID, "Contact"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // ratingCurve.LastUpdateContactTVText   (String)
                // -----------------------------------

                ratingCurve = null;
                ratingCurve = GetFilledRandomRatingCurve("");
                ratingCurve.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RatingCurveLastUpdateContactTVText, "200"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // ratingCurve.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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

                RatingCurveService ratingCurveService = new RatingCurveService(LanguageRequest, dbTestDB, ContactID);

                RatingCurve ratingCurve = (from c in ratingCurveService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(ratingCurve);

                RatingCurve ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID);
                Assert.AreEqual(ratingCurve.RatingCurveID, ratingCurveRet.RatingCurveID);
            }
        }
        #endregion Tests Get With Key

    }
}
