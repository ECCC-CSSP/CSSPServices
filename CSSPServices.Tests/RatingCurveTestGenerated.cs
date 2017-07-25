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

            if (OmitPropName != "HydrometricSiteID") ratingCurve.HydrometricSiteID = GetRandomInt(1, 11);
            if (OmitPropName != "RatingCurveNumber") ratingCurve.RatingCurveNumber = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurve.LastUpdateDate_UTC = GetRandomDateTime();
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
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // HydrometricSiteID will automatically be initialized at 0 --> not null

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("RatingCurveNumber");
            Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
            Assert.AreEqual(1, ratingCurve.ValidationResults.Count());
            Assert.IsTrue(ratingCurve.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveRatingCurveNumber)).Any());
            Assert.AreEqual(null, ratingCurve.RatingCurveNumber);
            Assert.AreEqual(0, ratingCurveService.GetRead().Count());

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("LastUpdateDate_UTC");
            Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
            Assert.AreEqual(1, ratingCurve.ValidationResults.Count());
            Assert.IsTrue(ratingCurve.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.RatingCurveLastUpdateDate_UTC)).Any());
            Assert.IsTrue(ratingCurve.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, ratingCurveService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [RatingCurveValues]

            //Error: Type not implemented [HydrometricSite]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [RatingCurveID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [HydrometricSiteID] of type [Int32]
            //-----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            // HydrometricSiteID has Min [1] and Max [empty]. At Min should return true and no errors
            ratingCurve.HydrometricSiteID = 1;
            Assert.AreEqual(true, ratingCurveService.Add(ratingCurve));
            Assert.AreEqual(0, ratingCurve.ValidationResults.Count());
            Assert.AreEqual(1, ratingCurve.HydrometricSiteID);
            Assert.AreEqual(true, ratingCurveService.Delete(ratingCurve));
            Assert.AreEqual(0, ratingCurveService.GetRead().Count());
            // HydrometricSiteID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            ratingCurve.HydrometricSiteID = 2;
            Assert.AreEqual(true, ratingCurveService.Add(ratingCurve));
            Assert.AreEqual(0, ratingCurve.ValidationResults.Count());
            Assert.AreEqual(2, ratingCurve.HydrometricSiteID);
            Assert.AreEqual(true, ratingCurveService.Delete(ratingCurve));
            Assert.AreEqual(0, ratingCurveService.GetRead().Count());
            // HydrometricSiteID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            ratingCurve.HydrometricSiteID = 0;
            Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
            Assert.IsTrue(ratingCurve.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveHydrometricSiteID, "1")).Any());
            Assert.AreEqual(0, ratingCurve.HydrometricSiteID);
            Assert.AreEqual(0, ratingCurveService.GetRead().Count());

            //-----------------------------------
            // doing property [RatingCurveNumber] of type [String]
            //-----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            ratingCurve = null;
            ratingCurve = GetFilledRandomRatingCurve("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            ratingCurve.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, ratingCurveService.Add(ratingCurve));
            Assert.AreEqual(0, ratingCurve.ValidationResults.Count());
            Assert.AreEqual(1, ratingCurve.LastUpdateContactTVItemID);
            Assert.AreEqual(true, ratingCurveService.Delete(ratingCurve));
            Assert.AreEqual(0, ratingCurveService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            ratingCurve.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, ratingCurveService.Add(ratingCurve));
            Assert.AreEqual(0, ratingCurve.ValidationResults.Count());
            Assert.AreEqual(2, ratingCurve.LastUpdateContactTVItemID);
            Assert.AreEqual(true, ratingCurveService.Delete(ratingCurve));
            Assert.AreEqual(0, ratingCurveService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            ratingCurve.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
            Assert.IsTrue(ratingCurve.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.RatingCurveLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, ratingCurve.LastUpdateContactTVItemID);
            Assert.AreEqual(0, ratingCurveService.GetRead().Count());

            //-----------------------------------
            // doing property [RatingCurveValues] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [HydrometricSite] of type [HydrometricSite]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
