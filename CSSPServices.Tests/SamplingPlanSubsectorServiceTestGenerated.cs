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
    public partial class SamplingPlanSubsectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SamplingPlanSubsectorService samplingPlanSubsectorService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorServiceTest() : base()
        {
            //samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SamplingPlanSubsector GetFilledRandomSamplingPlanSubsector(string OmitPropName)
        {
            SamplingPlanSubsector samplingPlanSubsector = new SamplingPlanSubsector();

            if (OmitPropName != "SamplingPlanID") samplingPlanSubsector.SamplingPlanID = 1;
            if (OmitPropName != "SubsectorTVItemID") samplingPlanSubsector.SubsectorTVItemID = 11;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsector.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "SubsectorTVText") samplingPlanSubsector.SubsectorTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") samplingPlanSubsector.LastUpdateContactTVText = GetRandomString("", 5);

            return samplingPlanSubsector;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlanSubsector_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                SamplingPlanSubsector samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = samplingPlanSubsectorService.GetRead().Count();

                samplingPlanSubsectorService.Add(samplingPlanSubsector);
                if (samplingPlanSubsector.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, samplingPlanSubsectorService.GetRead().Where(c => c == samplingPlanSubsector).Any());
                samplingPlanSubsectorService.Update(samplingPlanSubsector);
                if (samplingPlanSubsector.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, samplingPlanSubsectorService.GetRead().Count());
                samplingPlanSubsectorService.Delete(samplingPlanSubsector);
                if (samplingPlanSubsector.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // samplingPlanSubsector.SamplingPlanSubsectorID   (Int32)
                // -----------------------------------

                samplingPlanSubsector = null;
                samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                samplingPlanSubsector.SamplingPlanSubsectorID = 0;
                samplingPlanSubsectorService.Update(samplingPlanSubsector);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = Error)]
                // samplingPlanSubsector.SamplingPlanID   (Int32)
                // -----------------------------------

                samplingPlanSubsector = null;
                samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                samplingPlanSubsector.SamplingPlanID = 0;
                samplingPlanSubsectorService.Add(samplingPlanSubsector);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlan, ModelsRes.SamplingPlanSubsectorSamplingPlanID, samplingPlanSubsector.SamplingPlanID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                // samplingPlanSubsector.SubsectorTVItemID   (Int32)
                // -----------------------------------

                samplingPlanSubsector = null;
                samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                samplingPlanSubsector.SubsectorTVItemID = 0;
                samplingPlanSubsectorService.Add(samplingPlanSubsector);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorSubsectorTVItemID, samplingPlanSubsector.SubsectorTVItemID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                samplingPlanSubsector = null;
                samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                samplingPlanSubsector.SubsectorTVItemID = 1;
                samplingPlanSubsectorService.Add(samplingPlanSubsector);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanSubsectorSubsectorTVItemID, "Subsector"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // samplingPlanSubsector.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // samplingPlanSubsector.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                samplingPlanSubsector = null;
                samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                samplingPlanSubsector.LastUpdateContactTVItemID = 0;
                samplingPlanSubsectorService.Add(samplingPlanSubsector);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                samplingPlanSubsector = null;
                samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                samplingPlanSubsector.LastUpdateContactTVItemID = 1;
                samplingPlanSubsectorService.Add(samplingPlanSubsector);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, "Contact"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "SubsectorTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // samplingPlanSubsector.SubsectorTVText   (String)
                // -----------------------------------

                samplingPlanSubsector = null;
                samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                samplingPlanSubsector.SubsectorTVText = GetRandomString("", 201);
                Assert.AreEqual(false, samplingPlanSubsectorService.Add(samplingPlanSubsector));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSubsectorSubsectorTVText, "200"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // samplingPlanSubsector.LastUpdateContactTVText   (String)
                // -----------------------------------

                samplingPlanSubsector = null;
                samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                samplingPlanSubsector.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, samplingPlanSubsectorService.Add(samplingPlanSubsector));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVText, "200"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // samplingPlanSubsector.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void SamplingPlanSubsector_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, dbTestDB, ContactID);
                SamplingPlanSubsector samplingPlanSubsector = (from c in samplingPlanSubsectorService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(samplingPlanSubsector);

                SamplingPlanSubsector samplingPlanSubsectorRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID);
                Assert.AreEqual(samplingPlanSubsector.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);
                Assert.AreEqual(samplingPlanSubsector.SamplingPlanID, samplingPlanSubsectorRet.SamplingPlanID);
                Assert.AreEqual(samplingPlanSubsector.SubsectorTVItemID, samplingPlanSubsectorRet.SubsectorTVItemID);
                Assert.AreEqual(samplingPlanSubsector.LastUpdateDate_UTC, samplingPlanSubsectorRet.LastUpdateDate_UTC);
                Assert.AreEqual(samplingPlanSubsector.LastUpdateContactTVItemID, samplingPlanSubsectorRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(samplingPlanSubsectorRet.SubsectorTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorRet.SubsectorTVText));
                Assert.IsNotNull(samplingPlanSubsectorRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}
