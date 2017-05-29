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
    public partial class SamplingPlanSubsectorSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int SamplingPlanSubsectorSiteID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SamplingPlanSubsectorSite GetFilledRandomSamplingPlanSubsectorSite(string OmitPropName)
        {
            SamplingPlanSubsectorSiteID += 1;

            SamplingPlanSubsectorSite samplingPlanSubsectorSite = new SamplingPlanSubsectorSite();

            if (OmitPropName != "SamplingPlanSubsectorSiteID") samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = SamplingPlanSubsectorSiteID;
            if (OmitPropName != "SamplingPlanSubsectorID") samplingPlanSubsectorSite.SamplingPlanSubsectorID = GetRandomInt(1, 11);
            if (OmitPropName != "MWQMSiteTVItemID") samplingPlanSubsectorSite.MWQMSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "IsDuplicate") samplingPlanSubsectorSite.IsDuplicate = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsectorSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsectorSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return samplingPlanSubsectorSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SamplingPlanSubsectorSite_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            SamplingPlanSubsectorSite samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.GetRead().Where(c => c == samplingPlanSubsectorSite).Any());
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite));
            Assert.AreEqual(1, samplingPlanSubsectorSiteService.GetRead().Count());
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // SamplingPlanSubsectorID will automatically be initialized at 0 --> not null

            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null

            // IsDuplicate will automatically be initialized at false --> not null

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("LastUpdateDate_UTC");
            Assert.AreEqual(false, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(1, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.IsTrue(samplingPlanSubsectorSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC)).Any());
            Assert.IsTrue(samplingPlanSubsectorSite.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [SamplingPlanSubsectorSiteID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanSubsectorID] of type [int]
            //-----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            // SamplingPlanSubsectorID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsectorSite.SamplingPlanSubsectorID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsectorSite.SamplingPlanSubsectorID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());
            // SamplingPlanSubsectorID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsectorSite.SamplingPlanSubsectorID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsectorSite.SamplingPlanSubsectorID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());
            // SamplingPlanSubsectorID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsectorSite.SamplingPlanSubsectorID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.IsTrue(samplingPlanSubsectorSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsectorSite.SamplingPlanSubsectorID);
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [MWQMSiteTVItemID] of type [int]
            //-----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsectorSite.MWQMSiteTVItemID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsectorSite.MWQMSiteTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsectorSite.MWQMSiteTVItemID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsectorSite.MWQMSiteTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsectorSite.MWQMSiteTVItemID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.IsTrue(samplingPlanSubsectorSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsectorSite.MWQMSiteTVItemID);
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [IsDuplicate] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsectorSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsectorSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.IsTrue(samplingPlanSubsectorSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsectorSite.LastUpdateContactTVItemID);
            Assert.AreEqual(0, samplingPlanSubsectorSiteService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
