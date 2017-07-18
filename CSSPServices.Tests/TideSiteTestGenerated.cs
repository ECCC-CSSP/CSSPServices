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
        private int TideSiteID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideSite GetFilledRandomTideSite(string OmitPropName)
        {
            TideSiteID += 1;

            TideSite tideSite = new TideSite();

            if (OmitPropName != "TideSiteID") tideSite.TideSiteID = TideSiteID;
            if (OmitPropName != "TideSiteTVItemID") tideSite.TideSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "WebTideModel") tideSite.WebTideModel = GetRandomString("", 5);
            if (OmitPropName != "WebTideDatum_m") tideSite.WebTideDatum_m = GetRandomFloat(-100.0f, 100.0f);
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tideSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tideSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TideSite_Testing()
        {
            SetupTestHelper(culture);
            TideSiteService tideSiteService = new TideSiteService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            TideSite tideSite = GetFilledRandomTideSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(true, tideSiteService.GetRead().Where(c => c == tideSite).Any());
            tideSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tideSiteService.Update(tideSite));
            Assert.AreEqual(1, tideSiteService.GetRead().Count());
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(0, tideSiteService.GetRead().Count());

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

            // WebTideDatum_m will automatically be initialized at 0 --> not null

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
            // doing property [WebTideDatum_m] of type [Single]
            //-----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            // WebTideDatum_m has Min [-100] and Max [100]. At Min should return true and no errors
            tideSite.WebTideDatum_m = -100.0f;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(-100.0f, tideSite.WebTideDatum_m);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(0, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100] and Max [100]. At Min + 1 should return true and no errors
            tideSite.WebTideDatum_m = -99.0f;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(-99.0f, tideSite.WebTideDatum_m);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(0, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100] and Max [100]. At Min - 1 should return false with one error
            tideSite.WebTideDatum_m = -101.0f;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideSiteWebTideDatum_m, "-100", "100")).Any());
            Assert.AreEqual(-101.0f, tideSite.WebTideDatum_m);
            Assert.AreEqual(0, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100] and Max [100]. At Max should return true and no errors
            tideSite.WebTideDatum_m = 100.0f;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(100.0f, tideSite.WebTideDatum_m);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(0, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100] and Max [100]. At Max - 1 should return true and no errors
            tideSite.WebTideDatum_m = 99.0f;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(99.0f, tideSite.WebTideDatum_m);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(0, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100] and Max [100]. At Max + 1 should return false with one error
            tideSite.WebTideDatum_m = 101.0f;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideSiteWebTideDatum_m, "-100", "100")).Any());
            Assert.AreEqual(101.0f, tideSite.WebTideDatum_m);
            Assert.AreEqual(0, tideSiteService.GetRead().Count());

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
