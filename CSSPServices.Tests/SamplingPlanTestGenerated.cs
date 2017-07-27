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
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") samplingPlan.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") samplingPlan.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
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
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // samplingPlan.SamplingPlanID   (Int32)
            // -----------------------------------

            samplingPlan = GetFilledRandomSamplingPlan("");
            samplingPlan.SamplingPlanID = 0;
            samplingPlanService.Update(samplingPlan);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanID), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(200))]
            // samplingPlan.SamplingPlanName   (String)
            // -----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("SamplingPlanName");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanName)).Any());
            Assert.AreEqual(null, samplingPlan.SamplingPlanName);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            // SamplingPlanName has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string samplingPlanSamplingPlanNameMin = GetRandomString("", 200);
            samplingPlan.SamplingPlanName = samplingPlanSamplingPlanNameMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanSamplingPlanNameMin, samplingPlan.SamplingPlanName);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // SamplingPlanName has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            samplingPlanSamplingPlanNameMin = GetRandomString("", 199);
            samplingPlan.SamplingPlanName = samplingPlanSamplingPlanNameMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanSamplingPlanNameMin, samplingPlan.SamplingPlanName);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // SamplingPlanName has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            samplingPlanSamplingPlanNameMin = GetRandomString("", 201);
            samplingPlan.SamplingPlanName = samplingPlanSamplingPlanNameMin;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSamplingPlanName, "200")).Any());
            Assert.AreEqual(samplingPlanSamplingPlanNameMin, samplingPlan.SamplingPlanName);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // samplingPlan.ForGroupName   (String)
            // -----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("ForGroupName");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanForGroupName)).Any());
            Assert.AreEqual(null, samplingPlan.ForGroupName);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            // ForGroupName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string samplingPlanForGroupNameMin = GetRandomString("", 100);
            samplingPlan.ForGroupName = samplingPlanForGroupNameMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanForGroupNameMin, samplingPlan.ForGroupName);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // ForGroupName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            samplingPlanForGroupNameMin = GetRandomString("", 99);
            samplingPlan.ForGroupName = samplingPlanForGroupNameMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanForGroupNameMin, samplingPlan.ForGroupName);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // ForGroupName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            samplingPlanForGroupNameMin = GetRandomString("", 101);
            samplingPlan.ForGroupName = samplingPlanForGroupNameMin;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanForGroupName, "100")).Any());
            Assert.AreEqual(samplingPlanForGroupNameMin, samplingPlan.ForGroupName);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // samplingPlan.SampleType   (SampleTypeEnum)
            // -----------------------------------

            // SampleType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // samplingPlan.SamplingPlanType   (SamplingPlanTypeEnum)
            // -----------------------------------

            // SamplingPlanType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // samplingPlan.LabSheetType   (LabSheetTypeEnum)
            // -----------------------------------

            // LabSheetType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Province)]
            // [Range(1, -1)]
            // samplingPlan.ProvinceTVItemID   (Int32)
            // -----------------------------------

            // ProvinceTVItemID will automatically be initialized at 0 --> not null


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // ProvinceTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlan.ProvinceTVItemID = 1;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlan.ProvinceTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // ProvinceTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlan.ProvinceTVItemID = 2;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlan.ProvinceTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // ProvinceTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlan.ProvinceTVItemID = 0;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanProvinceTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlan.ProvinceTVItemID);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // samplingPlan.CreatorTVItemID   (Int32)
            // -----------------------------------

            // CreatorTVItemID will automatically be initialized at 0 --> not null


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // CreatorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlan.CreatorTVItemID = 1;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlan.CreatorTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // CreatorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlan.CreatorTVItemID = 2;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlan.CreatorTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // CreatorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlan.CreatorTVItemID = 0;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanCreatorTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlan.CreatorTVItemID);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(2000, 2050)]
            // samplingPlan.Year   (Int32)
            // -----------------------------------

            // Year will automatically be initialized at 0 --> not null


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // Year has Min [2000] and Max [2050]. At Min should return true and no errors
            samplingPlan.Year = 2000;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2000, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Min + 1 should return true and no errors
            samplingPlan.Year = 2001;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2001, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Min - 1 should return false with one error
            samplingPlan.Year = 1999;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "2000", "2050")).Any());
            Assert.AreEqual(1999, samplingPlan.Year);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Max should return true and no errors
            samplingPlan.Year = 2050;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2050, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Max - 1 should return true and no errors
            samplingPlan.Year = 2049;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2049, samplingPlan.Year);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // Year has Min [2000] and Max [2050]. At Max + 1 should return false with one error
            samplingPlan.Year = 2051;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "2000", "2050")).Any());
            Assert.AreEqual(2051, samplingPlan.Year);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(15))]
            // samplingPlan.AccessCode   (String)
            // -----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("AccessCode");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanAccessCode)).Any());
            Assert.AreEqual(null, samplingPlan.AccessCode);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            // AccessCode has MinLength [empty] and MaxLength [15]. At Max should return true and no errors
            string samplingPlanAccessCodeMin = GetRandomString("", 15);
            samplingPlan.AccessCode = samplingPlanAccessCodeMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanAccessCodeMin, samplingPlan.AccessCode);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // AccessCode has MinLength [empty] and MaxLength [15]. At Max - 1 should return true and no errors
            samplingPlanAccessCodeMin = GetRandomString("", 14);
            samplingPlan.AccessCode = samplingPlanAccessCodeMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanAccessCodeMin, samplingPlan.AccessCode);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // AccessCode has MinLength [empty] and MaxLength [15]. At Max + 1 should return false with one error
            samplingPlanAccessCodeMin = GetRandomString("", 16);
            samplingPlan.AccessCode = samplingPlanAccessCodeMin;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanAccessCode, "15")).Any());
            Assert.AreEqual(samplingPlanAccessCodeMin, samplingPlan.AccessCode);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // samplingPlan.DailyDuplicatePrecisionCriteria   (Double)
            // -----------------------------------

            //Error: Type not implemented [DailyDuplicatePrecisionCriteria]


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            samplingPlan.DailyDuplicatePrecisionCriteria = 0.0D;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(0.0D, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            samplingPlan.DailyDuplicatePrecisionCriteria = 1.0D;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1.0D, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            samplingPlan.DailyDuplicatePrecisionCriteria = -1.0D;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(-1.0D, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            samplingPlan.DailyDuplicatePrecisionCriteria = 100.0D;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(100.0D, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            samplingPlan.DailyDuplicatePrecisionCriteria = 99.0D;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(99.0D, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // DailyDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            samplingPlan.DailyDuplicatePrecisionCriteria = 101.0D;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(101.0D, samplingPlan.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // samplingPlan.IntertechDuplicatePrecisionCriteria   (Double)
            // -----------------------------------

            //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            samplingPlan.IntertechDuplicatePrecisionCriteria = 0.0D;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(0.0D, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            samplingPlan.IntertechDuplicatePrecisionCriteria = 1.0D;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1.0D, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            samplingPlan.IntertechDuplicatePrecisionCriteria = -1.0D;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(-1.0D, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            samplingPlan.IntertechDuplicatePrecisionCriteria = 100.0D;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(100.0D, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            samplingPlan.IntertechDuplicatePrecisionCriteria = 99.0D;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(99.0D, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // IntertechDuplicatePrecisionCriteria has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            samplingPlan.IntertechDuplicatePrecisionCriteria = 101.0D;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100")).Any());
            Assert.AreEqual(101.0D, samplingPlan.IntertechDuplicatePrecisionCriteria);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // samplingPlan.IncludeLaboratoryQAQC   (Boolean)
            // -----------------------------------

            // IncludeLaboratoryQAQC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(15))]
            // samplingPlan.ApprovalCode   (String)
            // -----------------------------------

            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("ApprovalCode");
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanApprovalCode)).Any());
            Assert.AreEqual(null, samplingPlan.ApprovalCode);
            Assert.AreEqual(0, samplingPlanService.GetRead().Count());


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");

            // ApprovalCode has MinLength [empty] and MaxLength [15]. At Max should return true and no errors
            string samplingPlanApprovalCodeMin = GetRandomString("", 15);
            samplingPlan.ApprovalCode = samplingPlanApprovalCodeMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanApprovalCodeMin, samplingPlan.ApprovalCode);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // ApprovalCode has MinLength [empty] and MaxLength [15]. At Max - 1 should return true and no errors
            samplingPlanApprovalCodeMin = GetRandomString("", 14);
            samplingPlan.ApprovalCode = samplingPlanApprovalCodeMin;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(samplingPlanApprovalCodeMin, samplingPlan.ApprovalCode);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // ApprovalCode has MinLength [empty] and MaxLength [15]. At Max + 1 should return false with one error
            samplingPlanApprovalCodeMin = GetRandomString("", 16);
            samplingPlan.ApprovalCode = samplingPlanApprovalCodeMin;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanApprovalCode, "15")).Any());
            Assert.AreEqual(samplingPlanApprovalCodeMin, samplingPlan.ApprovalCode);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.File)]
            // [Range(1, -1)]
            // samplingPlan.SamplingPlanFileTVItemID   (Int32)
            // -----------------------------------


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // SamplingPlanFileTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlan.SamplingPlanFileTVItemID = 1;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlan.SamplingPlanFileTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // SamplingPlanFileTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlan.SamplingPlanFileTVItemID = 2;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlan.SamplingPlanFileTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // SamplingPlanFileTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlan.SamplingPlanFileTVItemID = 0;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSamplingPlanFileTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlan.SamplingPlanFileTVItemID);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // samplingPlan.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // samplingPlan.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            samplingPlan = null;
            samplingPlan = GetFilledRandomSamplingPlan("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            samplingPlan.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(1, samplingPlan.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            samplingPlan.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, samplingPlanService.Add(samplingPlan));
            Assert.AreEqual(0, samplingPlan.ValidationResults.Count());
            Assert.AreEqual(2, samplingPlan.LastUpdateContactTVItemID);
            Assert.AreEqual(true, samplingPlanService.Delete(samplingPlan));
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            samplingPlan.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
            Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, samplingPlan.LastUpdateContactTVItemID);
            Assert.AreEqual(count, samplingPlanService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlan.LabSheetDetails   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlan.LabSheets   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlan.SamplingPlanSubsectors   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlan.CreatorTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlan.ProvinceTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // samplingPlan.SamplingPlanFileTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // samplingPlan.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
