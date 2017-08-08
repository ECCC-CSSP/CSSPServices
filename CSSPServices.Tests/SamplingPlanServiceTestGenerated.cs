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
    public partial class SamplingPlanServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SamplingPlanService samplingPlanService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanServiceTest() : base()
        {
            //samplingPlanService = new SamplingPlanService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlan.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlan.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "ProvinceTVText") samplingPlan.ProvinceTVText = GetRandomString("", 5);
            if (OmitPropName != "CreatorTVText") samplingPlan.CreatorTVText = GetRandomString("", 5);
            if (OmitPropName != "SamplingPlanFileTVText") samplingPlan.SamplingPlanFileTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") samplingPlan.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "SampleTypeText") samplingPlan.SampleTypeText = GetRandomString("", 5);
            if (OmitPropName != "SamplingPlanTypeText") samplingPlan.SamplingPlanTypeText = GetRandomString("", 5);
            if (OmitPropName != "LabSheetTypeText") samplingPlan.LabSheetTypeText = GetRandomString("", 5);

            return samplingPlan;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlan_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                SamplingPlanService samplingPlanService = new SamplingPlanService(LanguageRequest, dbTestDB, ContactID);

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

                samplingPlan = null;
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
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.SamplingPlanName = GetRandomString("", 201);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSamplingPlanName, "200"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.ForGroupName = GetRandomString("", 101);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanForGroupName, "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // samplingPlan.SampleType   (SampleTypeEnum)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.SampleType = (SampleTypeEnum)1000000;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSampleType), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // samplingPlan.SamplingPlanType   (SamplingPlanTypeEnum)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.SamplingPlanType = (SamplingPlanTypeEnum)1000000;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanType), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // samplingPlan.LabSheetType   (LabSheetTypeEnum)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.LabSheetType = (LabSheetTypeEnum)1000000;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanLabSheetType), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Province)]
                // samplingPlan.ProvinceTVItemID   (Int32)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.ProvinceTVItemID = 0;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanProvinceTVItemID, samplingPlan.ProvinceTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.ProvinceTVItemID = 1;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanProvinceTVItemID, "Province"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // samplingPlan.CreatorTVItemID   (Int32)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.CreatorTVItemID = 0;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanCreatorTVItemID, samplingPlan.CreatorTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.CreatorTVItemID = 1;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanCreatorTVItemID, "Contact"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(2000, 2050)]
                // samplingPlan.Year   (Int32)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.Year = 1999;
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "2000", "2050"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());
                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.Year = 2051;
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "2000", "2050"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.AccessCode = GetRandomString("", 16);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanAccessCode, "15"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100)]
                // samplingPlan.DailyDuplicatePrecisionCriteria   (Double)
                // -----------------------------------

                //Error: Type not implemented [DailyDuplicatePrecisionCriteria]

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.DailyDuplicatePrecisionCriteria = -1.0D;
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());
                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.DailyDuplicatePrecisionCriteria = 101.0D;
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100)]
                // samplingPlan.IntertechDuplicatePrecisionCriteria   (Double)
                // -----------------------------------

                //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.IntertechDuplicatePrecisionCriteria = -1.0D;
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());
                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.IntertechDuplicatePrecisionCriteria = 101.0D;
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // samplingPlan.IncludeLaboratoryQAQC   (Boolean)
                // -----------------------------------


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
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.ApprovalCode = GetRandomString("", 16);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanApprovalCode, "15"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = File)]
                // samplingPlan.SamplingPlanFileTVItemID   (Int32)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.SamplingPlanFileTVItemID = 0;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSamplingPlanFileTVItemID, samplingPlan.SamplingPlanFileTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.SamplingPlanFileTVItemID = 1;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanSamplingPlanFileTVItemID, "File"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // samplingPlan.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // samplingPlan.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.LastUpdateContactTVItemID = 0;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanLastUpdateContactTVItemID, samplingPlan.LastUpdateContactTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.LastUpdateContactTVItemID = 1;
                samplingPlanService.Add(samplingPlan);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanLastUpdateContactTVItemID, "Contact"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // samplingPlan.ProvinceTVText   (String)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.ProvinceTVText = GetRandomString("", 201);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanProvinceTVText, "200"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // samplingPlan.CreatorTVText   (String)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.CreatorTVText = GetRandomString("", 201);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanCreatorTVText, "200"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // samplingPlan.SamplingPlanFileTVText   (String)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.SamplingPlanFileTVText = GetRandomString("", 201);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSamplingPlanFileTVText, "200"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // samplingPlan.LastUpdateContactTVText   (String)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanLastUpdateContactTVText, "200"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // samplingPlan.SampleTypeText   (String)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.SampleTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSampleTypeText, "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // samplingPlan.SamplingPlanTypeText   (String)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.SamplingPlanTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSamplingPlanTypeText, "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // samplingPlan.LabSheetTypeText   (String)
                // -----------------------------------

                samplingPlan = null;
                samplingPlan = GetFilledRandomSamplingPlan("");
                samplingPlan.LabSheetTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanLabSheetTypeText, "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // samplingPlan.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void SamplingPlan_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                SamplingPlanService samplingPlanService = new SamplingPlanService(LanguageRequest, dbTestDB, ContactID);

                SamplingPlan samplingPlan = (from c in samplingPlanService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(samplingPlan);

                SamplingPlan samplingPlanRet = samplingPlanService.GetSamplingPlanWithSamplingPlanID(samplingPlan.SamplingPlanID);
                Assert.AreEqual(samplingPlan.SamplingPlanID, samplingPlanRet.SamplingPlanID);
            }
        }
        #endregion Tests Get With Key

    }
}
