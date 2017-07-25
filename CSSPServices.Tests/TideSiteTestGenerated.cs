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
    public partial class TideSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TideSiteService tideSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteTest() : base()
        {
            tideSiteService = new TideSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideSite GetFilledRandomTideSite(string OmitPropName)
        {
            TideSite tideSite = new TideSite();

            if (OmitPropName != "TideSiteTVItemID") tideSite.TideSiteTVItemID = 13;
            if (OmitPropName != "WebTideModel") tideSite.WebTideModel = GetRandomString("", 5);
            if (OmitPropName != "WebTideDatum_m") tideSite.WebTideDatum_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tideSite.LastUpdateContactTVItemID = 2;

            return tideSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TideSite_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TideSite tideSite = GetFilledRandomTideSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tideSiteService.GetRead().Count();

            tideSiteService.Add(tideSite);
            if (tideSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tideSiteService.GetRead().Where(c => c == tideSite).Any());
            tideSiteService.Update(tideSite);
            if (tideSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tideSiteService.GetRead().Count());
            tideSiteService.Delete(tideSite);
            if (tideSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TideSiteTVItemID will automatically be initialized at 0 --> not null

            tideSite = null;
            tideSite = GetFilledRandomTideSite("WebTideModel");
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.AreEqual(1, tideSite.ValidationResults.Count());
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteWebTideModel)).Any());
            Assert.AreEqual(null, tideSite.WebTideModel);
            Assert.AreEqual(0, tideSiteService.GetRead().Count());

            //Error: Type not implemented [WebTideDatum_m]

            tideSite = null;
            tideSite = GetFilledRandomTideSite("LastUpdateDate_UTC");
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.AreEqual(1, tideSite.ValidationResults.Count());
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tideSite.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tideSiteService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TideSiteTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TideSiteID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideSiteTVItemID] of type [Int32]
            //-----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tideSite.TideSiteTVItemID = 1;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(1, tideSite.TideSiteTVItemID);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(0, tideSiteService.GetRead().Count());
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideSite.TideSiteTVItemID = 2;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(2, tideSite.TideSiteTVItemID);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(0, tideSiteService.GetRead().Count());
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideSite.TideSiteTVItemID = 0;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideSiteTideSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, tideSite.TideSiteTVItemID);
            Assert.AreEqual(0, tideSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [WebTideModel] of type [String]
            //-----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");

            //-----------------------------------
            // doing property [WebTideDatum_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tideSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(1, tideSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(0, tideSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(2, tideSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(0, tideSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tideSite.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tideSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [TideSiteTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
