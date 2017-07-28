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
    public partial class RatingCurveTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private RatingCurveService ratingCurveService { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveTest() : base()
        {
            ratingCurveService = new RatingCurveService(LanguageRequest, dbTestDB, ContactID);
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

            return ratingCurve;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void RatingCurve_Testing()
        {

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
            // [CSSPExist(TypeName = "HydrometricSite", Plurial = "s", FieldID = "HydrometricSiteID", TVType = TVTypeEnum.Error)]
            // ratingCurve.HydrometricSiteID   (Int32)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.HydrometricSiteID = 0;
            ratingCurveService.Add(ratingCurve);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.HydrometricSite, ModelsRes.RatingCurveHydrometricSiteID, ratingCurve.HydrometricSiteID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

            // HydrometricSiteID will automatically be initialized at 0 --> not null


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
            Assert.AreEqual(0, ratingCurveService.GetRead().Count());

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            // RatingCurveNumber has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string ratingCurveRatingCurveNumberMin = GetRandomString("", 50);
            ratingCurve.RatingCurveNumber = ratingCurveRatingCurveNumberMin;
            Assert.AreEqual(true, ratingCurveService.Add(ratingCurve));
            Assert.AreEqual(0, ratingCurve.ValidationResults.Count());
            Assert.AreEqual(ratingCurveRatingCurveNumberMin, ratingCurve.RatingCurveNumber);
            Assert.AreEqual(true, ratingCurveService.Delete(ratingCurve));
            Assert.AreEqual(count, ratingCurveService.GetRead().Count());

            // RatingCurveNumber has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            ratingCurveRatingCurveNumberMin = GetRandomString("", 49);
            ratingCurve.RatingCurveNumber = ratingCurveRatingCurveNumberMin;
            Assert.AreEqual(true, ratingCurveService.Add(ratingCurve));
            Assert.AreEqual(0, ratingCurve.ValidationResults.Count());
            Assert.AreEqual(ratingCurveRatingCurveNumberMin, ratingCurve.RatingCurveNumber);
            Assert.AreEqual(true, ratingCurveService.Delete(ratingCurve));
            Assert.AreEqual(count, ratingCurveService.GetRead().Count());

            // RatingCurveNumber has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            ratingCurveRatingCurveNumberMin = GetRandomString("", 51);
            ratingCurve.RatingCurveNumber = ratingCurveRatingCurveNumberMin;
            Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
            Assert.IsTrue(ratingCurve.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RatingCurveRatingCurveNumber, "50")).Any());
            Assert.AreEqual(ratingCurveRatingCurveNumberMin, ratingCurve.RatingCurveNumber);
            Assert.AreEqual(count, ratingCurveService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // ratingCurve.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // ratingCurve.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            ratingCurve.LastUpdateContactTVItemID = 0;
            ratingCurveService.Add(ratingCurve);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.RatingCurveLastUpdateContactTVItemID, ratingCurve.LastUpdateContactTVItemID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // ratingCurve.RatingCurveValues   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // ratingCurve.HydrometricSite   (HydrometricSite)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // ratingCurve.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
