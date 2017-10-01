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
            // Need to implement (no items found, would need to add at least one in the TestDB) [SamplingPlan ProvinceTVItemID TVItem TVItemID]
            if (OmitPropName != "CreatorTVItemID") samplingPlan.CreatorTVItemID = 2;
            if (OmitPropName != "Year") samplingPlan.Year = GetRandomInt(2000, 2050);
            if (OmitPropName != "AccessCode") samplingPlan.AccessCode = GetRandomString("", 5);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") samplingPlan.DailyDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") samplingPlan.IntertechDuplicatePrecisionCriteria = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "IncludeLaboratoryQAQC") samplingPlan.IncludeLaboratoryQAQC = true;
            if (OmitPropName != "ApprovalCode") samplingPlan.ApprovalCode = GetRandomString("", 5);
            // Need to implement (no items found, would need to add at least one in the TestDB) [SamplingPlan SamplingPlanFileTVItemID TVItem TVItemID]
            //Error: property [SamplingPlanWeb] and type [SamplingPlan] is  not implemented
            //Error: property [SamplingPlanReport] and type [SamplingPlan] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlan.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlan.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") samplingPlan.HasErrors = true;

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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
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

                    Assert.AreEqual(samplingPlanService.GetRead().Count(), samplingPlanService.GetEdit().Count());

                    samplingPlanService.Add(samplingPlan);
                    if (samplingPlan.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, samplingPlanService.GetRead().Where(c => c == samplingPlan).Any());
                    samplingPlanService.Update(samplingPlan);
                    if (samplingPlan.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, samplingPlanService.GetRead().Count());
                    samplingPlanService.Delete(samplingPlan);
                    if (samplingPlan.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSamplingPlanID), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanID = 10000000;
                    samplingPlanService.Update(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlan, CSSPModelsRes.SamplingPlanSamplingPlanID, samplingPlan.SamplingPlanID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // samplingPlan.SamplingPlanName   (String)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("SamplingPlanName");
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
                    Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSamplingPlanName)).Any());
                    Assert.AreEqual(null, samplingPlan.SamplingPlanName);
                    Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanName = GetRandomString("", 201);
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanSamplingPlanName, "200"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanForGroupName)).Any());
                    Assert.AreEqual(null, samplingPlan.ForGroupName);
                    Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.ForGroupName = GetRandomString("", 101);
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanForGroupName, "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSampleType), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // samplingPlan.SamplingPlanType   (SamplingPlanTypeEnum)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanType = (SamplingPlanTypeEnum)1000000;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSamplingPlanType), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // samplingPlan.LabSheetType   (LabSheetTypeEnum)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.LabSheetType = (LabSheetTypeEnum)1000000;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanLabSheetType), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Province)]
                    // samplingPlan.ProvinceTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.ProvinceTVItemID = 0;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanProvinceTVItemID, samplingPlan.ProvinceTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.ProvinceTVItemID = 1;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanProvinceTVItemID, "Province"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlan.CreatorTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.CreatorTVItemID = 0;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanCreatorTVItemID, samplingPlan.CreatorTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.CreatorTVItemID = 1;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanCreatorTVItemID, "Contact"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(2000, 2050)]
                    // samplingPlan.Year   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.Year = 1999;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SamplingPlanYear, "2000", "2050"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetRead().Count());
                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.Year = 2051;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SamplingPlanYear, "2000", "2050"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanAccessCode)).Any());
                    Assert.AreEqual(null, samplingPlan.AccessCode);
                    Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.AccessCode = GetRandomString("", 16);
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanAccessCode, "15"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetRead().Count());
                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.DailyDuplicatePrecisionCriteria = 101.0D;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetRead().Count());
                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.IntertechDuplicatePrecisionCriteria = 101.0D;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanApprovalCode)).Any());
                    Assert.AreEqual(null, samplingPlan.ApprovalCode);
                    Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.ApprovalCode = GetRandomString("", 16);
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanApprovalCode, "15"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
                    // samplingPlan.SamplingPlanFileTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanFileTVItemID = 0;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSamplingPlanFileTVItemID, samplingPlan.SamplingPlanFileTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanFileTVItemID = 1;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSamplingPlanFileTVItemID, "File"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // samplingPlan.SamplingPlanWeb   (SamplingPlanWeb)
                    // -----------------------------------

                    //Error: Type not implemented [SamplingPlanWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // samplingPlan.SamplingPlanReport   (SamplingPlanReport)
                    // -----------------------------------

                    //Error: Type not implemented [SamplingPlanReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // samplingPlan.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlan.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.LastUpdateContactTVItemID = 0;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanLastUpdateContactTVItemID, samplingPlan.LastUpdateContactTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.LastUpdateContactTVItemID = 1;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanLastUpdateContactTVItemID, "Contact"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlan.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlan.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanService samplingPlanService = new SamplingPlanService(LanguageRequest, dbTestDB, ContactID);
                    SamplingPlan samplingPlan = (from c in samplingPlanService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlan);

                    SamplingPlan samplingPlanRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanRet = samplingPlanService.GetSamplingPlanWithSamplingPlanID(samplingPlan.SamplingPlanID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanRet = samplingPlanService.GetSamplingPlanWithSamplingPlanID(samplingPlan.SamplingPlanID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanRet = samplingPlanService.GetSamplingPlanWithSamplingPlanID(samplingPlan.SamplingPlanID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(samplingPlanRet.SamplingPlanID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanRet.SamplingPlanName));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanRet.ForGroupName));
                        Assert.IsNotNull(samplingPlanRet.SampleType);
                        Assert.IsNotNull(samplingPlanRet.SamplingPlanType);
                        Assert.IsNotNull(samplingPlanRet.LabSheetType);
                        Assert.IsNotNull(samplingPlanRet.ProvinceTVItemID);
                        Assert.IsNotNull(samplingPlanRet.CreatorTVItemID);
                        Assert.IsNotNull(samplingPlanRet.Year);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanRet.AccessCode));
                        Assert.IsNotNull(samplingPlanRet.DailyDuplicatePrecisionCriteria);
                        Assert.IsNotNull(samplingPlanRet.IntertechDuplicatePrecisionCriteria);
                        Assert.IsNotNull(samplingPlanRet.IncludeLaboratoryQAQC);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanRet.ApprovalCode));
                        if (samplingPlanRet.SamplingPlanFileTVItemID != null)
                        {
                            Assert.IsNotNull(samplingPlanRet.SamplingPlanFileTVItemID);
                        }
                        Assert.IsNotNull(samplingPlanRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(samplingPlanRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (samplingPlanRet.SamplingPlanWeb != null)
                            {
                                Assert.IsNull(samplingPlanRet.SamplingPlanWeb);
                            }
                            if (samplingPlanRet.SamplingPlanReport != null)
                            {
                                Assert.IsNull(samplingPlanRet.SamplingPlanReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (samplingPlanRet.SamplingPlanWeb != null)
                            {
                                Assert.IsNotNull(samplingPlanRet.SamplingPlanWeb);
                            }
                            if (samplingPlanRet.SamplingPlanReport != null)
                            {
                                Assert.IsNotNull(samplingPlanRet.SamplingPlanReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of SamplingPlan
        #endregion Tests Get List of SamplingPlan

    }
}
