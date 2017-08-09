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
    public partial class SamplingPlanSubsectorSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteServiceTest() : base()
        {
            //samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "MWQMSiteTVText") samplingPlanSubsectorSite.MWQMSiteTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") samplingPlanSubsectorSite.LastUpdateContactTVText = GetRandomString("", 5);

            return samplingPlanSubsectorSite;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlanSubsectorSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, dbTestDB, ContactID);

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
                // [CSSPExist(ExistTypeName = "SamplingPlanSubsector", ExistPlurial = "s", ExistFieldID = "SamplingPlanSubsectorID", AllowableTVtypeList = Error)]
                // samplingPlanSubsectorSite.SamplingPlanSubsectorID   (Int32)
                // -----------------------------------

                samplingPlanSubsectorSite = null;
                samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                samplingPlanSubsectorSite.SamplingPlanSubsectorID = 0;
                samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlanSubsector, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID, samplingPlanSubsectorSite.SamplingPlanSubsectorID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                // samplingPlanSubsectorSite.MWQMSiteTVItemID   (Int32)
                // -----------------------------------

                samplingPlanSubsectorSite = null;
                samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                samplingPlanSubsectorSite.MWQMSiteTVItemID = 0;
                samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, samplingPlanSubsectorSite.MWQMSiteTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                samplingPlanSubsectorSite = null;
                samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                samplingPlanSubsectorSite.MWQMSiteTVItemID = 1;
                samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, "MWQMSite"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // samplingPlanSubsectorSite.IsDuplicate   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // samplingPlanSubsectorSite.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // samplingPlanSubsectorSite.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                samplingPlanSubsectorSite = null;
                samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                samplingPlanSubsectorSite.LastUpdateContactTVItemID = 0;
                samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, samplingPlanSubsectorSite.LastUpdateContactTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                samplingPlanSubsectorSite = null;
                samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                samplingPlanSubsectorSite.LastUpdateContactTVItemID = 1;
                samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, "Contact"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "MWQMSiteTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // samplingPlanSubsectorSite.MWQMSiteTVText   (String)
                // -----------------------------------

                samplingPlanSubsectorSite = null;
                samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                samplingPlanSubsectorSite.MWQMSiteTVText = GetRandomString("", 201);
                Assert.AreEqual(false, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVText, "200"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // samplingPlanSubsectorSite.LastUpdateContactTVText   (String)
                // -----------------------------------

                samplingPlanSubsectorSite = null;
                samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                samplingPlanSubsectorSite.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVText, "200"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // samplingPlanSubsectorSite.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void SamplingPlanSubsectorSite_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, dbTestDB, ContactID);
                SamplingPlanSubsectorSite samplingPlanSubsectorSite = (from c in samplingPlanSubsectorSiteService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(samplingPlanSubsectorSite);

                SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
                Assert.IsNotNull(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);
                Assert.IsNotNull(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorID);
                Assert.IsNotNull(samplingPlanSubsectorSiteRet.MWQMSiteTVItemID);
                Assert.IsNotNull(samplingPlanSubsectorSiteRet.IsDuplicate);
                Assert.IsNotNull(samplingPlanSubsectorSiteRet.LastUpdateDate_UTC);
                Assert.IsNotNull(samplingPlanSubsectorSiteRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(samplingPlanSubsectorSiteRet.MWQMSiteTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteRet.MWQMSiteTVText));
                Assert.IsNotNull(samplingPlanSubsectorSiteRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}
