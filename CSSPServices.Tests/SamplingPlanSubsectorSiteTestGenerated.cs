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
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID   (Int32)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;
            samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "SamplingPlanSubsector", Plurial = "s", FieldID = "SamplingPlanSubsectorID", TVType = TVTypeEnum.Error)]
            // samplingPlanSubsectorSite.SamplingPlanSubsectorID   (Int32)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.SamplingPlanSubsectorID = 0;
            samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlanSubsector, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID, samplingPlanSubsectorSite.SamplingPlanSubsectorID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // SamplingPlanSubsectorID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMSite)]
            // samplingPlanSubsectorSite.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.MWQMSiteTVItemID = 0;
            samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, samplingPlanSubsectorSite.MWQMSiteTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // samplingPlanSubsectorSite.IsDuplicate   (Boolean)
            // -----------------------------------

            // IsDuplicate will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // samplingPlanSubsectorSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // samplingPlanSubsectorSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            samplingPlanSubsectorSite = null;
            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
            samplingPlanSubsectorSite.LastUpdateContactTVItemID = 0;
            samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, samplingPlanSubsectorSite.LastUpdateContactTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlanSubsectorSite.MWQMSiteTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlanSubsectorSite.SamplingPlanSubsector   (SamplingPlanSubsector)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // samplingPlanSubsectorSite.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
