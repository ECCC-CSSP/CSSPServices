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
    public partial class SamplingPlanTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SamplingPlanService samplingPlanService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanTest() : base()
        {
            samplingPlanService = new SamplingPlanService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SamplingPlan GetFilledRandomSamplingPlan(string OmitPropName)
        {
            SamplingPlan samplingPlan = new SamplingPlan();

            if (OmitPropName != "SamplingPlanName") samplingPlan.SamplingPlanName = GetRandomString("", 5);
            if (OmitPropName != "ForGroupName") samplingPlan.ForGroupName = GetRandomString("", 5);
            if (OmitPropName != "SampleType") samplingPlan.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SamplingPlanType") samplingPlan.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "LabSheetType") samplingPlan.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "ProvinceTVItemID") samplingPlan.ProvinceTVItemID = 6;
            if (OmitPropName != "CreatorTVItemID") samplingPlan.CreatorTVItemID = 2;
            if (OmitPropName != "Year") samplingPlan.Year = GetRandomInt(2000, 2050);
            if (OmitPropName != "AccessCode") samplingPlan.AccessCode = GetRandomString("", 5);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") samplingPlan.DailyDuplicatePrecisionCriteria = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") samplingPlan.IntertechDuplicatePrecisionCriteria = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "IncludeLaboratoryQAQC") samplingPlan.IncludeLaboratoryQAQC = true;
            if (OmitPropName != "ApprovalCode") samplingPlan.ApprovalCode = GetRandomString("", 5);
            if (OmitPropName != "SamplingPlanFileTVItemID") samplingPlan.SamplingPlanFileTVItemID = 17;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlan.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlan.LastUpdateContactTVItemID = 2;

            return samplingPlan;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SamplingPlan_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            SamplingPlan samplingPlan = GetFilledRandomSamplingPlan("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = samplingPlanService.GetRead().Count();

            samplingPlanService.Add(samplingPlan);
            if (samplingPlan.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, samplingPlanService.GetRead().Where(c => c == samplingPlan).Any());
            samplingPlanService.Update(samplingPlan);
            if (samplingPlan.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, samplingPlanService.GetRead().Count());
            samplingPlanService.Delete(samplingPlan);
            if (samplingPlan.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("SamplingPlanName");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanName)).Any());
            Assert.AreEqual(null, samplingPlan.SamplingPlanName);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("ForGroupName");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanForGroupName)).Any());
            Assert.AreEqual(null, samplingPlan.ForGroupName);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //Error: Type not implemented [SampleType]

            //Error: Type not implemented [SamplingPlanType]

            //Error: Type not implemented [LabSheetType]

            // ProvinceTVItemID will automatically be initialized at 0 --> not null

            // CreatorTVItemID will automatically be initialized at 0 --> not null

            // Year will automatically be initialized at 0 --> not null

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("AccessCode");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanAccessCode)).Any());
            Assert.AreEqual(null, samplingPlan.AccessCode);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //Error: Type not implemented [DailyDuplicatePrecisionCriteria]

            //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]

            // IncludeLaboratoryQAQC will automatically be initialized at 0 --> not null

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("ApprovalCode");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanApprovalCode)).Any());
            Assert.AreEqual(null, samplingPlan.ApprovalCode);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("LastUpdateDate_UTC");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanLastUpdateDate_UTC)).Any());
            Assert.IsTrue(samplingPlan.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [LabSheetDetails]

            //Error: Type not implemented [LabSheets]

            //Error: Type not implemented [SamplingPlanSubsectors]

            //Error: Type not implemented [CreatorTVItem]

            //Error: Type not implemented [ProvinceTVItem]

            //Error: Type not implemented [SamplingPlanFileTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [SamplingPlanID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanName] of type [String]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            //-----------------------------------
            // doing property [ForGroupName] of type [String]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            //-----------------------------------
            // doing property [SampleType] of type [SampleTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanType] of type [SamplingPlanTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheetType] of type [LabSheetTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [ProvinceTVItemID] of type [Int32]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // ProvinceTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlan.ProvinceTVItemID = 1;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlan.ProvinceTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // ProvinceTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlan.ProvinceTVItemID = 2;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlan.ProvinceTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // ProvinceTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlan.ProvinceTVItemID = 0;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanProvinceTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlan.ProvinceTVItemID);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [CreatorTVItemID] of type [Int32]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // CreatorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlan.CreatorTVItemID = 1;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlan.CreatorTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // CreatorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlan.CreatorTVItemID = 2;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlan.CreatorTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // CreatorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlan.CreatorTVItemID = 0;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanCreatorTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlan.CreatorTVItemID);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [Year] of type [Int32]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // Year has Min [2000] and Max [2050]. At Min should return true and no errors
            samplingPlan.Year = 2000;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2000, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Min + 1 should return true and no errors
            samplingPlan.Year = 2001;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2001, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Min - 1 should return false with one error
            samplingPlan.Year = 1999;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "2000", "2050")).Any());
            Assert.AreEqual(1999, samplingPlan.Year);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Max should return true and no errors
            samplingPlan.Year = 2050;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2050, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Max - 1 should return true and no errors
            samplingPlan.Year = 2049;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2049, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Max + 1 should return false with one error
            samplingPlan.Year = 2051;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "2000", "2050")).Any());
            Assert.AreEqual(2051, samplingPlan.Year);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [AccessCode] of type [String]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            //-----------------------------------
            // doing property [DailyDuplicatePrecisionCriteria] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [IntertechDuplicatePrecisionCriteria] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [IncludeLaboratoryQAQC] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [ApprovalCode] of type [String]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            //-----------------------------------
            // doing property [SamplingPlanFileTVItemID] of type [Int32]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // SamplingPlanFileTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlan.SamplingPlanFileTVItemID = 1;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlan.SamplingPlanFileTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // SamplingPlanFileTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlan.SamplingPlanFileTVItemID = 2;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlan.SamplingPlanFileTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // SamplingPlanFileTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlan.SamplingPlanFileTVItemID = 0;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSamplingPlanFileTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlan.SamplingPlanFileTVItemID);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlan.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlan.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlan.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlan.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlan.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlan.LastUpdateContactTVItemID);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [LabSheetDetails] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [LabSheets] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanSubsectors] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [CreatorTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ProvinceTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanFileTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
