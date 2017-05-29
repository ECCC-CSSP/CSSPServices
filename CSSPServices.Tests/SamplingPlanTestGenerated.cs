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
        private int SamplingPlanID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SamplingPlan GetFilledRandomSamplingPlan(string OmitPropName)
        {
            SamplingPlanID += 1;

            SamplingPlan samplingPlan = new SamplingPlan();

            if (OmitPropName != "SamplingPlanID") samplingPlan.SamplingPlanID = SamplingPlanID;
            if (OmitPropName != "SamplingPlanName") samplingPlan.SamplingPlanName = GetRandomString("", 5);
            if (OmitPropName != "ForGroupName") samplingPlan.ForGroupName = GetRandomString("", 5);
            if (OmitPropName != "SampleType") samplingPlan.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SamplingPlanType") samplingPlan.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "LabSheetType") samplingPlan.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "ProvinceTVItemID") samplingPlan.ProvinceTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "CreatorTVItemID") samplingPlan.CreatorTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Year") samplingPlan.Year = GetRandomInt(1980, 2050);
            if (OmitPropName != "AccessCode") samplingPlan.AccessCode = GetRandomString("", 8);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") samplingPlan.DailyDuplicatePrecisionCriteria = GetRandomFloat(0, 100);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") samplingPlan.IntertechDuplicatePrecisionCriteria = GetRandomFloat(0, 100);
            if (OmitPropName != "IncludeLaboratoryQAQC") samplingPlan.IncludeLaboratoryQAQC = true;
            if (OmitPropName != "SamplingPlanFileTVItemID") samplingPlan.SamplingPlanFileTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlan.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlan.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return samplingPlan;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SamplingPlan_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            SamplingPlanService samplingPlanService = new SamplingPlanService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            SamplingPlan samplingPlan = GetFilledRandomSamplingPlan("");
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(true, samplingPlanService.GetRead().Where(c => c == samplingPlan).Any());
            samplingPlan.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, samplingPlanService.Update(samplingPlan));
            Assert.AreEqual(1, samplingPlanService.GetRead().Count());
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

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

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("SampleType");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSampleType)).Any());
            Assert.AreEqual(SampleTypeEnum.Error, samplingPlan.SampleType);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("SamplingPlanType");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanType)).Any());
            Assert.AreEqual(SamplingPlanTypeEnum.Error, samplingPlan.SamplingPlanType);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("LabSheetType");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanLabSheetType)).Any());
            Assert.AreEqual(LabSheetTypeEnum.Error, samplingPlan.LabSheetType);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

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

            // DailyDuplicatePrecisionCriteria will automatically be initialized at 0.0f --> not null

            // IntertechDuplicatePrecisionCriteria will automatically be initialized at 0.0f --> not null

            // IncludeLaboratoryQAQC will automatically be initialized at false --> not null

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("LastUpdateDate_UTC");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanLastUpdateDate_UTC)).Any());
            Assert.IsTrue(samplingPlan.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [SamplingPlanID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanName] of type [string]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            // SamplingPlanName has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string samplingPlanSamplingPlanNameMin = GetRandomString("", 200);
            samplingPlan.SamplingPlanName = samplingPlanSamplingPlanNameMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanSamplingPlanNameMin, samplingPlan.SamplingPlanName);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // SamplingPlanName has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            samplingPlanSamplingPlanNameMin = GetRandomString("", 199);
            samplingPlan.SamplingPlanName = samplingPlanSamplingPlanNameMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanSamplingPlanNameMin, samplingPlan.SamplingPlanName);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // SamplingPlanName has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            samplingPlanSamplingPlanNameMin = GetRandomString("", 201);
            samplingPlan.SamplingPlanName = samplingPlanSamplingPlanNameMin;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSamplingPlanName, "200")).Any());
            Assert.AreEqual(samplingPlanSamplingPlanNameMin, samplingPlan.SamplingPlanName);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [ForGroupName] of type [string]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            // ForGroupName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string samplingPlanForGroupNameMin = GetRandomString("", 100);
            samplingPlan.ForGroupName = samplingPlanForGroupNameMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanForGroupNameMin, samplingPlan.ForGroupName);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // ForGroupName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            samplingPlanForGroupNameMin = GetRandomString("", 99);
            samplingPlan.ForGroupName = samplingPlanForGroupNameMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanForGroupNameMin, samplingPlan.ForGroupName);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // ForGroupName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            samplingPlanForGroupNameMin = GetRandomString("", 101);
            samplingPlan.ForGroupName = samplingPlanForGroupNameMin;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanForGroupName, "100")).Any());
            Assert.AreEqual(samplingPlanForGroupNameMin, samplingPlan.ForGroupName);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

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
            // doing property [ProvinceTVItemID] of type [int]
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
            // doing property [CreatorTVItemID] of type [int]
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
            // doing property [Year] of type [int]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // Year has Min [1980] and Max [2050]. At Min should return true and no errors
            samplingPlan.Year = 1980;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1980, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [1980] and Max [2050]. At Min + 1 should return true and no errors
            samplingPlan.Year = 1981;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1981, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [1980] and Max [2050]. At Min - 1 should return false with one error
            samplingPlan.Year = 1979;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "1980", "2050")).Any());
            Assert.AreEqual(1979, samplingPlan.Year);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [1980] and Max [2050]. At Max should return true and no errors
            samplingPlan.Year = 2050;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2050, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [1980] and Max [2050]. At Max - 1 should return true and no errors
            samplingPlan.Year = 2049;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2049, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // Year has Min [1980] and Max [2050]. At Max + 1 should return false with one error
            samplingPlan.Year = 2051;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "1980", "2050")).Any());
            Assert.AreEqual(2051, samplingPlan.Year);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [AccessCode] of type [string]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            // AccessCode has MinLength [3] and MaxLength [15]. At Min should return true and no errors
            string samplingPlanAccessCodeMin = GetRandomString("", 3);
            samplingPlan.AccessCode = samplingPlanAccessCodeMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanAccessCodeMin, samplingPlan.AccessCode);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // AccessCode has MinLength [3] and MaxLength [15]. At Min + 1 should return true and no errors
            samplingPlanAccessCodeMin = GetRandomString("", 4);
            samplingPlan.AccessCode = samplingPlanAccessCodeMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanAccessCodeMin, samplingPlan.AccessCode);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // AccessCode has MinLength [3] and MaxLength [15]. At Min - 1 should return false with one error
            samplingPlanAccessCodeMin = GetRandomString("", 2);
            samplingPlan.AccessCode = samplingPlanAccessCodeMin;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.SamplingPlanAccessCode, "3", "15")).Any());
            Assert.AreEqual(samplingPlanAccessCodeMin, samplingPlan.AccessCode);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // AccessCode has MinLength [3] and MaxLength [15]. At Max should return true and no errors
            samplingPlanAccessCodeMin = GetRandomString("", 15);
            samplingPlan.AccessCode = samplingPlanAccessCodeMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanAccessCodeMin, samplingPlan.AccessCode);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // AccessCode has MinLength [3] and MaxLength [15]. At Max - 1 should return true and no errors
            samplingPlanAccessCodeMin = GetRandomString("", 14);
            samplingPlan.AccessCode = samplingPlanAccessCodeMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanAccessCodeMin, samplingPlan.AccessCode);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            // AccessCode has MinLength [3] and MaxLength [15]. At Max + 1 should return false with one error
            samplingPlanAccessCodeMin = GetRandomString("", 16);
            samplingPlan.AccessCode = samplingPlanAccessCodeMin;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.SamplingPlanAccessCode, "3", "15")).Any());
            Assert.AreEqual(samplingPlanAccessCodeMin, samplingPlan.AccessCode);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [DailyDuplicatePrecisionCriteria] of type [float]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [100]. At Min should return true and no errors
            samplingPlan.DailyDuplicatePrecisionCriteria = 0.0f;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(0.0f, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [100]. At Min + 1 should return true and no errors
            samplingPlan.DailyDuplicatePrecisionCriteria = 1.0f;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1.0f, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [100]. At Min - 1 should return false with one error
            samplingPlan.DailyDuplicatePrecisionCriteria = -1.0f;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(-1.0f, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [100]. At Max should return true and no errors
            samplingPlan.DailyDuplicatePrecisionCriteria = 100.0f;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(100.0f, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [100]. At Max - 1 should return true and no errors
            samplingPlan.DailyDuplicatePrecisionCriteria = 99.0f;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(99.0f, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0] and Max [100]. At Max + 1 should return false with one error
            samplingPlan.DailyDuplicatePrecisionCriteria = 101.0f;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(101.0f, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [IntertechDuplicatePrecisionCriteria] of type [float]
            //-----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [100]. At Min should return true and no errors
            samplingPlan.IntertechDuplicatePrecisionCriteria = 0.0f;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(0.0f, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [100]. At Min + 1 should return true and no errors
            samplingPlan.IntertechDuplicatePrecisionCriteria = 1.0f;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1.0f, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [100]. At Min - 1 should return false with one error
            samplingPlan.IntertechDuplicatePrecisionCriteria = -1.0f;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(-1.0f, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [100]. At Max should return true and no errors
            samplingPlan.IntertechDuplicatePrecisionCriteria = 100.0f;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(100.0f, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [100]. At Max - 1 should return true and no errors
            samplingPlan.IntertechDuplicatePrecisionCriteria = 99.0f;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(99.0f, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0] and Max [100]. At Max + 1 should return false with one error
            samplingPlan.IntertechDuplicatePrecisionCriteria = 101.0f;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(101.0f, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());

            //-----------------------------------
            // doing property [IncludeLaboratoryQAQC] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanFileTVItemID] of type [int]
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
            // doing property [LastUpdateContactTVItemID] of type [int]
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

        }
        #endregion Tests Generated
    }
}
