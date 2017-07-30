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
    public partial class SamplingPlanSubsectorTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SamplingPlanSubsectorService samplingPlanSubsectorService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorTest() : base()
        {
            samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, dbTestDB, ContactID);
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

            return samplingPlanSubsector;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SamplingPlanSubsector_Testing()
        {

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
            // [CSSPExist(TypeName = "SamplingPlan", Plurial = "s", FieldID = "SamplingPlanID", TVType = TVTypeEnum.Error)]
            // samplingPlanSubsector.SamplingPlanID   (Int32)
            // -----------------------------------

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.SamplingPlanID = 0;
            samplingPlanSubsectorService.Add(samplingPlanSubsector);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlan, ModelsRes.SamplingPlanSubsectorSamplingPlanID, samplingPlanSubsector.SamplingPlanID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Subsector)]
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
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
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
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlanSubsector.SamplingPlanSubsectorSites   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlanSubsector.SamplingPlan   (SamplingPlan)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlanSubsector.SubsectorTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // samplingPlanSubsector.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
