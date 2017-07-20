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
    public partial class MWQMSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMSiteID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSite GetFilledRandomMWQMSite(string OmitPropName)
        {
            MWQMSiteID += 1;

            MWQMSite mwqmSite = new MWQMSite();

            if (OmitPropName != "MWQMSiteID") mwqmSite.MWQMSiteID = MWQMSiteID;
            if (OmitPropName != "MWQMSiteTVItemID") mwqmSite.MWQMSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "MWQMSiteNumber") mwqmSite.MWQMSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "MWQMSiteDescription") mwqmSite.MWQMSiteDescription = GetRandomString("", 5);
            if (OmitPropName != "MWQMSiteLatestClassification") mwqmSite.MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)GetRandomEnumType(typeof(MWQMSiteLatestClassificationEnum));
            if (OmitPropName != "Ordinal") mwqmSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mwqmSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSite_Testing()
        {
            SetupTestHelper(culture);
            MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            MWQMSite mwqmSite = GetFilledRandomMWQMSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(true, mwqmSiteService.GetRead().Where(c => c == mwqmSite).Any());
            mwqmSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mwqmSiteService.Update(mwqmSite));
            Assert.AreEqual(1, mwqmSiteService.GetRead().Count());
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("MWQMSiteNumber");
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(1, mwqmSite.ValidationResults.Count());
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteMWQMSiteNumber)).Any());
            Assert.AreEqual(null, mwqmSite.MWQMSiteNumber);
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("MWQMSiteDescription");
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(1, mwqmSite.ValidationResults.Count());
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteMWQMSiteDescription)).Any());
            Assert.AreEqual(null, mwqmSite.MWQMSiteDescription);
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());

            //Error: Type not implemented [MWQMSiteLatestClassification]

            // Ordinal will automatically be initialized at 0 --> not null

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(1, mwqmSite.ValidationResults.Count());
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmSite.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MWQMSiteTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMSiteID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSiteTVItemID] of type [Int32]
            //-----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSite.MWQMSiteTVItemID = 1;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSite.MWQMSiteTVItemID);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSite.MWQMSiteTVItemID = 2;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSite.MWQMSiteTVItemID);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSite.MWQMSiteTVItemID = 0;
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSiteMWQMSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSite.MWQMSiteTVItemID);
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMSiteNumber] of type [String]
            //-----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");

            //-----------------------------------
            // doing property [MWQMSiteDescription] of type [String]
            //-----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");

            //-----------------------------------
            // doing property [MWQMSiteLatestClassification] of type [MWQMSiteLatestClassificationEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Ordinal] of type [Int32]
            //-----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSite.Ordinal = 0;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSite.Ordinal);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSite.Ordinal = 1;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSite.Ordinal);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSite.Ordinal = -1;
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSiteOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, mwqmSite.Ordinal);
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSite.Ordinal = 1000;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(1000, mwqmSite.Ordinal);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSite.Ordinal = 999;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(999, mwqmSite.Ordinal);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSite.Ordinal = 1001;
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSiteOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, mwqmSite.Ordinal);
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSite.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMSiteTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
