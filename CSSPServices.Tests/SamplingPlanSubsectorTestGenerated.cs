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
        private int SamplingPlanSubsectorID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SamplingPlanSubsector GetFilledRandomSamplingPlanSubsector(string OmitPropName)
        {
            SamplingPlanSubsectorID += 1;

            SamplingPlanSubsector samplingPlanSubsector = new SamplingPlanSubsector();

            if (OmitPropName != "SamplingPlanSubsectorID") samplingPlanSubsector.SamplingPlanSubsectorID = SamplingPlanSubsectorID;
            if (OmitPropName != "SamplingPlanID") samplingPlanSubsector.SamplingPlanID = GetRandomInt(1, 11);
            if (OmitPropName != "SubsectorTVItemID") samplingPlanSubsector.SubsectorTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsector.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsector.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return samplingPlanSubsector;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SamplingPlanSubsector_Testing()
        {
            SetupTestHelper(culture);
            SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            SamplingPlanSubsector samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(true, samplingPlanSubsectorService.GetRead().Where(c => c == samplingPlanSubsector).Any());
            samplingPlanSubsector.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, samplingPlanSubsectorService.Update(samplingPlanSubsector));
            Assert.AreEqual(1, samplingPlanSubsectorService.GetRead().Count());
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // SamplingPlanID will automatically be initialized at 0 --> not null

            // SubsectorTVItemID will automatically be initialized at 0 --> not null

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("LastUpdateDate_UTC");
            Assert.AreEqual(false, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(1, samplingPlanSubsector.ValidationResults.Count());
            Assert.IsTrue(samplingPlanSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC)).Any());
            Assert.IsTrue(samplingPlanSubsector.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [SamplingPlanSubsectorSites]

            //Error: Type not implemented [SamplingPlan]

            //Error: Type not implemented [SubsectorTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [SamplingPlanSubsectorID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanID] of type [Int32]
            //-----------------------------------

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            // SamplingPlanID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsector.SamplingPlanID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsector.SamplingPlanID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsector.SamplingPlanID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsector.SamplingPlanID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());
            // SamplingPlanID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsector.SamplingPlanID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.IsTrue(samplingPlanSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSamplingPlanID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsector.SamplingPlanID);
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [SubsectorTVItemID] of type [Int32]
            //-----------------------------------

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsector.SubsectorTVItemID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsector.SubsectorTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsector.SubsectorTVItemID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsector.SubsectorTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsector.SubsectorTVItemID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.IsTrue(samplingPlanSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsector.SubsectorTVItemID);
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            samplingPlanSubsector = null;
            samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlanSubsector.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlanSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlanSubsector.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsector.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlanSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanSubsectorService.Delete(samplingPlanSubsector));
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlanSubsector.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, samplingPlanSubsectorService.Add(samplingPlanSubsector));
            Assert.IsTrue(samplingPlanSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlanSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(0, samplingPlanSubsectorService.GetRead().Count());

            //-----------------------------------
            // doing property [SamplingPlanSubsectorSites] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlan] of type [SamplingPlan]
            //-----------------------------------

            //-----------------------------------
            // doing property [SubsectorTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
