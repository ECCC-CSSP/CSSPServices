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
        private SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteTest() : base()
        {
            samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SamplingPlanSubsectorSite GetFilledRandomSamplingPlanSubsectorSite(string OmitPropName)
        {
            SamplingPlanSubsectorSite samplingPlanSubsectorSite = new SamplingPlanSubsectorSite();

            if (OmitPropName != "SamplingPlanSubsectorID") samplingPlanSubsectorSite.SamplingPlanSubsectorID = 1;
            if (OmitPropName != "MWQMSiteTVItemID") samplingPlanSubsectorSite.MWQMSiteTVItemID = 19;
            if (OmitPropName != "IsDuplicate") samplingPlanSubsectorSite.IsDuplicate = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsectorSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsectorSite.LastUpdateContactTVItemID = 2;

            return samplingPlanSubsectorSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SamplingPlanSubsectorSite_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            SamplingPlanSubsectorSite samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = samplingPlanSubsectorSiteService.GetRead().Count();

            samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.GetRead().Where(c => c == samplingPlanSubsectorSite).Any());
            samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, samplingPlanSubsectorSiteService.GetRead().Count());
            samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID   (Int32)
            //-----------------------------------
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;
            samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "SamplingPlanSubsector", Plurial = "s", FieldID = "SamplingPlanSubsectorID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // samplingPlanSubsectorSite.SamplingPlanSubsectorID   (Int32)
            //-----------------------------------
            // SamplingPlanSubsectorID will automatically be initialized at 0 --> not null


            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            // SamplingPlanSubsectorID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsectorSite.SamplingPlanSubsectorID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsectorSite.SamplingPlanSubsectorID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());
            // SamplingPlanSubsectorID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsectorSite.SamplingPlanSubsectorID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsectorSite.SamplingPlanSubsectorID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());
            // SamplingPlanSubsectorID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsectorSite.SamplingPlanSubsectorID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.IsTrue(samplingPlanSubsectorSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsectorSite.SamplingPlanSubsectorID);
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMSite)]
            //[Range(1, -1)]
            // samplingPlanSubsectorSite.MWQMSiteTVItemID   (Int32)
            //-----------------------------------
            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null


            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsectorSite.MWQMSiteTVItemID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsectorSite.MWQMSiteTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsectorSite.MWQMSiteTVItemID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsectorSite.MWQMSiteTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsectorSite.MWQMSiteTVItemID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.IsTrue(samplingPlanSubsectorSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsectorSite.MWQMSiteTVItemID);
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            // samplingPlanSubsectorSite.IsDuplicate   (Boolean)
            //-----------------------------------
            // IsDuplicate will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // samplingPlanSubsectorSite.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // samplingPlanSubsectorSite.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsectorSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.AreEqual(0, samplingPlanSubsectorSite.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsectorSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite));
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
            Assert.IsTrue(samplingPlanSubsectorSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsectorSite.LastUpdateContactTVItemID);
            Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // samplingPlanSubsectorSite.MWQMSiteTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // samplingPlanSubsectorSite.SamplingPlanSubsector   (SamplingPlanSubsector)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // samplingPlanSubsectorSite.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
