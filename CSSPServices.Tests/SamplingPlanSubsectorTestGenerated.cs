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
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsector.LastUpdateDate_UTC = GetRandomDateTime();
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

            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            samplingPlanSubsector.SamplingPlanSubsectorID = 0;
            samplingPlanSubsectorService.Update(samplingPlanSubsector);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "SamplingPlan", Plurial = "s", FieldID = "SamplingPlanID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // samplingPlanSubsector.SamplingPlanID   (Int32)
            // -----------------------------------

            // SamplingPlanID will automatically be initialized at 0 --> not null


            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            // SamplingPlanID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsector.SamplingPlanID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsector.SamplingPlanID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsector.SamplingPlanID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsector.SamplingPlanID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsector.SamplingPlanID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.IsTrue(samplingPlanSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSamplingPlanID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsector.SamplingPlanID);
            Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Subsector)]
            // [Range(1, -1)]
            // samplingPlanSubsector.SubsectorTVItemID   (Int32)
            // -----------------------------------

            // SubsectorTVItemID will automatically be initialized at 0 --> not null


            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsector.SubsectorTVItemID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsector.SubsectorTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsector.SubsectorTVItemID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsector.SubsectorTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsector.SubsectorTVItemID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.IsTrue(samplingPlanSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsector.SubsectorTVItemID);
            Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // samplingPlanSubsector.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // samplingPlanSubsector.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsector.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsector.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsector.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.IsTrue(samplingPlanSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());

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
