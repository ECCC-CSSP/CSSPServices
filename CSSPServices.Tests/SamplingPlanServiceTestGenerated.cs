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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlan_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = samplingPlanService.GetSamplingPlanList().Count();

                    Assert.AreEqual(samplingPlanService.GetSamplingPlanList().Count(), (from c in dbTestDB.SamplingPlans select c).Take(200).Count());

                    samplingPlanService.Add(samplingPlan);
                    if (samplingPlan.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, samplingPlanService.GetSamplingPlanList().Where(c => c == samplingPlan).Any());
                    samplingPlanService.Update(samplingPlan);
                    if (samplingPlan.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, samplingPlanService.GetSamplingPlanList().Count());
                    samplingPlanService.Delete(samplingPlan);
                    if (samplingPlan.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSamplingPlanID"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanID = 10000000;
                    samplingPlanService.Update(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanSamplingPlanID", samplingPlan.SamplingPlanID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // samplingPlan.IsActive   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // samplingPlan.SamplingPlanName   (String)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("SamplingPlanName");
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
                    Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSamplingPlanName")).Any());
                    Assert.AreEqual(null, samplingPlan.SamplingPlanName);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanName = GetRandomString("", 201);
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanSamplingPlanName", "200"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // samplingPlan.ForGroupName   (String)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("ForGroupName");
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
                    Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "SamplingPlanForGroupName")).Any());
                    Assert.AreEqual(null, samplingPlan.ForGroupName);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.ForGroupName = GetRandomString("", 101);
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanForGroupName", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // samplingPlan.SampleType   (SampleTypeEnum)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SampleType = (SampleTypeEnum)1000000;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSampleType"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // samplingPlan.SamplingPlanType   (SamplingPlanTypeEnum)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanType = (SamplingPlanTypeEnum)1000000;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSamplingPlanType"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // samplingPlan.LabSheetType   (LabSheetTypeEnum)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.LabSheetType = (LabSheetTypeEnum)1000000;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanLabSheetType"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Province)]
                    // samplingPlan.ProvinceTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.ProvinceTVItemID = 0;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanProvinceTVItemID", samplingPlan.ProvinceTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.ProvinceTVItemID = 1;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanProvinceTVItemID", "Province"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlan.CreatorTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.CreatorTVItemID = 0;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanCreatorTVItemID", samplingPlan.CreatorTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.CreatorTVItemID = 1;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanCreatorTVItemID", "Contact"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(2000, 2050)]
                    // samplingPlan.Year   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.Year = 1999;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SamplingPlanYear", "2000", "2050"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());
                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.Year = 2051;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SamplingPlanYear", "2000", "2050"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(15))]
                    // samplingPlan.AccessCode   (String)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("AccessCode");
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
                    Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "SamplingPlanAccessCode")).Any());
                    Assert.AreEqual(null, samplingPlan.AccessCode);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.AccessCode = GetRandomString("", 16);
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanAccessCode", "15"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // samplingPlan.DailyDuplicatePrecisionCriteria   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DailyDuplicatePrecisionCriteria]

                    //Error: Type not implemented [DailyDuplicatePrecisionCriteria]

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.DailyDuplicatePrecisionCriteria = -1.0D;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SamplingPlanDailyDuplicatePrecisionCriteria", "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());
                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.DailyDuplicatePrecisionCriteria = 101.0D;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SamplingPlanDailyDuplicatePrecisionCriteria", "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // samplingPlan.IntertechDuplicatePrecisionCriteria   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]

                    //Error: Type not implemented [IntertechDuplicatePrecisionCriteria]

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.IntertechDuplicatePrecisionCriteria = -1.0D;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SamplingPlanIntertechDuplicatePrecisionCriteria", "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());
                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.IntertechDuplicatePrecisionCriteria = 101.0D;
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SamplingPlanIntertechDuplicatePrecisionCriteria", "0", "100"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

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
                    Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "SamplingPlanApprovalCode")).Any());
                    Assert.AreEqual(null, samplingPlan.ApprovalCode);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.ApprovalCode = GetRandomString("", 16);
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanApprovalCode", "15"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
                    // samplingPlan.SamplingPlanFileTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanFileTVItemID = 0;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSamplingPlanFileTVItemID", samplingPlan.SamplingPlanFileTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SamplingPlanFileTVItemID = 1;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSamplingPlanFileTVItemID", "File"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // samplingPlan.AnalyzeMethodDefault   (AnalyzeMethodEnum)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.AnalyzeMethodDefault = (AnalyzeMethodEnum)1000000;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanAnalyzeMethodDefault"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // samplingPlan.SampleMatrixDefault   (SampleMatrixEnum)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.SampleMatrixDefault = (SampleMatrixEnum)1000000;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSampleMatrixDefault"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // samplingPlan.LaboratoryDefault   (LaboratoryEnum)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.LaboratoryDefault = (LaboratoryEnum)1000000;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanLaboratoryDefault"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // samplingPlan.BackupDirectory   (String)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("BackupDirectory");
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(1, samplingPlan.ValidationResults.Count());
                    Assert.IsTrue(samplingPlan.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "SamplingPlanBackupDirectory")).Any());
                    Assert.AreEqual(null, samplingPlan.BackupDirectory);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.BackupDirectory = GetRandomString("", 251);
                    Assert.AreEqual(false, samplingPlanService.Add(samplingPlan));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanBackupDirectory", "250"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, samplingPlanService.GetSamplingPlanList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // samplingPlan.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.LastUpdateDate_UTC = new DateTime();
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanLastUpdateDate_UTC"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);
                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SamplingPlanLastUpdateDate_UTC", "1980"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlan.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.LastUpdateContactTVItemID = 0;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanLastUpdateContactTVItemID", samplingPlan.LastUpdateContactTVItemID.ToString()), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlan = null;
                    samplingPlan = GetFilledRandomSamplingPlan("");
                    samplingPlan.LastUpdateContactTVItemID = 1;
                    samplingPlanService.Add(samplingPlan);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanLastUpdateContactTVItemID", "Contact"), samplingPlan.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlan.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlan.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetSamplingPlanWithSamplingPlanID(samplingPlan.SamplingPlanID)
        [TestMethod]
        public void GetSamplingPlanWithSamplingPlanID__samplingPlan_SamplingPlanID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlan samplingPlan = (from c in dbTestDB.SamplingPlans select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlan);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        samplingPlanService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            SamplingPlan samplingPlanRet = samplingPlanService.GetSamplingPlanWithSamplingPlanID(samplingPlan.SamplingPlanID);
                            CheckSamplingPlanFields(new List<SamplingPlan>() { samplingPlanRet });
                            Assert.AreEqual(samplingPlan.SamplingPlanID, samplingPlanRet.SamplingPlanID);
                        }
                        else if (detail == "ExtraA")
                        {
                            SamplingPlanExtraA samplingPlanExtraARet = samplingPlanService.GetSamplingPlanExtraAWithSamplingPlanID(samplingPlan.SamplingPlanID);
                            CheckSamplingPlanExtraAFields(new List<SamplingPlanExtraA>() { samplingPlanExtraARet });
                            Assert.AreEqual(samplingPlan.SamplingPlanID, samplingPlanExtraARet.SamplingPlanID);
                        }
                        else if (detail == "ExtraB")
                        {
                            SamplingPlanExtraB samplingPlanExtraBRet = samplingPlanService.GetSamplingPlanExtraBWithSamplingPlanID(samplingPlan.SamplingPlanID);
                            CheckSamplingPlanExtraBFields(new List<SamplingPlanExtraB>() { samplingPlanExtraBRet });
                            Assert.AreEqual(samplingPlan.SamplingPlanID, samplingPlanExtraBRet.SamplingPlanID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanWithSamplingPlanID(samplingPlan.SamplingPlanID)

        #region Tests Generated for GetSamplingPlanList()
        [TestMethod]
        public void GetSamplingPlanList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlan samplingPlan = (from c in dbTestDB.SamplingPlans select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlan);

                    List<SamplingPlan> samplingPlanDirectQueryList = new List<SamplingPlan>();
                    samplingPlanDirectQueryList = (from c in dbTestDB.SamplingPlans select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        samplingPlanService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<SamplingPlan> samplingPlanList = new List<SamplingPlan>();
                            samplingPlanList = samplingPlanService.GetSamplingPlanList().ToList();
                            CheckSamplingPlanFields(samplingPlanList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<SamplingPlanExtraA> samplingPlanExtraAList = new List<SamplingPlanExtraA>();
                            samplingPlanExtraAList = samplingPlanService.GetSamplingPlanExtraAList().ToList();
                            CheckSamplingPlanExtraAFields(samplingPlanExtraAList);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<SamplingPlanExtraB> samplingPlanExtraBList = new List<SamplingPlanExtraB>();
                            samplingPlanExtraBList = samplingPlanService.GetSamplingPlanExtraBList().ToList();
                            CheckSamplingPlanExtraBFields(samplingPlanExtraBList);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanList()

        #region Tests Generated for GetSamplingPlanList() Skip Take
        [TestMethod]
        public void GetSamplingPlanList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanService.Query = samplingPlanService.FillQuery(typeof(SamplingPlan), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<SamplingPlan> samplingPlanDirectQueryList = new List<SamplingPlan>();
                        samplingPlanDirectQueryList = (from c in dbTestDB.SamplingPlans select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<SamplingPlan> samplingPlanList = new List<SamplingPlan>();
                            samplingPlanList = samplingPlanService.GetSamplingPlanList().ToList();
                            CheckSamplingPlanFields(samplingPlanList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanList[0].SamplingPlanID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<SamplingPlanExtraA> samplingPlanExtraAList = new List<SamplingPlanExtraA>();
                            samplingPlanExtraAList = samplingPlanService.GetSamplingPlanExtraAList().ToList();
                            CheckSamplingPlanExtraAFields(samplingPlanExtraAList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraAList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<SamplingPlanExtraB> samplingPlanExtraBList = new List<SamplingPlanExtraB>();
                            samplingPlanExtraBList = samplingPlanService.GetSamplingPlanExtraBList().ToList();
                            CheckSamplingPlanExtraBFields(samplingPlanExtraBList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraBList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanList() Skip Take

        #region Tests Generated for GetSamplingPlanList() Skip Take Order
        [TestMethod]
        public void GetSamplingPlanList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanService.Query = samplingPlanService.FillQuery(typeof(SamplingPlan), culture.TwoLetterISOLanguageName, 1, 1,  "SamplingPlanID", "");

                        List<SamplingPlan> samplingPlanDirectQueryList = new List<SamplingPlan>();
                        samplingPlanDirectQueryList = (from c in dbTestDB.SamplingPlans select c).Skip(1).Take(1).OrderBy(c => c.SamplingPlanID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<SamplingPlan> samplingPlanList = new List<SamplingPlan>();
                            samplingPlanList = samplingPlanService.GetSamplingPlanList().ToList();
                            CheckSamplingPlanFields(samplingPlanList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanList[0].SamplingPlanID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<SamplingPlanExtraA> samplingPlanExtraAList = new List<SamplingPlanExtraA>();
                            samplingPlanExtraAList = samplingPlanService.GetSamplingPlanExtraAList().ToList();
                            CheckSamplingPlanExtraAFields(samplingPlanExtraAList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraAList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<SamplingPlanExtraB> samplingPlanExtraBList = new List<SamplingPlanExtraB>();
                            samplingPlanExtraBList = samplingPlanService.GetSamplingPlanExtraBList().ToList();
                            CheckSamplingPlanExtraBFields(samplingPlanExtraBList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraBList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanList() Skip Take Order

        #region Tests Generated for GetSamplingPlanList() Skip Take 2Order
        [TestMethod]
        public void GetSamplingPlanList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanService.Query = samplingPlanService.FillQuery(typeof(SamplingPlan), culture.TwoLetterISOLanguageName, 1, 1, "SamplingPlanID,IsActive", "");

                        List<SamplingPlan> samplingPlanDirectQueryList = new List<SamplingPlan>();
                        samplingPlanDirectQueryList = (from c in dbTestDB.SamplingPlans select c).Skip(1).Take(1).OrderBy(c => c.SamplingPlanID).ThenBy(c => c.IsActive).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<SamplingPlan> samplingPlanList = new List<SamplingPlan>();
                            samplingPlanList = samplingPlanService.GetSamplingPlanList().ToList();
                            CheckSamplingPlanFields(samplingPlanList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanList[0].SamplingPlanID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<SamplingPlanExtraA> samplingPlanExtraAList = new List<SamplingPlanExtraA>();
                            samplingPlanExtraAList = samplingPlanService.GetSamplingPlanExtraAList().ToList();
                            CheckSamplingPlanExtraAFields(samplingPlanExtraAList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraAList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<SamplingPlanExtraB> samplingPlanExtraBList = new List<SamplingPlanExtraB>();
                            samplingPlanExtraBList = samplingPlanService.GetSamplingPlanExtraBList().ToList();
                            CheckSamplingPlanExtraBFields(samplingPlanExtraBList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraBList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanList() Skip Take 2Order

        #region Tests Generated for GetSamplingPlanList() Skip Take Order Where
        [TestMethod]
        public void GetSamplingPlanList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanService.Query = samplingPlanService.FillQuery(typeof(SamplingPlan), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanID", "SamplingPlanID,EQ,4", "");

                        List<SamplingPlan> samplingPlanDirectQueryList = new List<SamplingPlan>();
                        samplingPlanDirectQueryList = (from c in dbTestDB.SamplingPlans select c).Where(c => c.SamplingPlanID == 4).Skip(0).Take(1).OrderBy(c => c.SamplingPlanID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<SamplingPlan> samplingPlanList = new List<SamplingPlan>();
                            samplingPlanList = samplingPlanService.GetSamplingPlanList().ToList();
                            CheckSamplingPlanFields(samplingPlanList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanList[0].SamplingPlanID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<SamplingPlanExtraA> samplingPlanExtraAList = new List<SamplingPlanExtraA>();
                            samplingPlanExtraAList = samplingPlanService.GetSamplingPlanExtraAList().ToList();
                            CheckSamplingPlanExtraAFields(samplingPlanExtraAList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraAList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<SamplingPlanExtraB> samplingPlanExtraBList = new List<SamplingPlanExtraB>();
                            samplingPlanExtraBList = samplingPlanService.GetSamplingPlanExtraBList().ToList();
                            CheckSamplingPlanExtraBFields(samplingPlanExtraBList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraBList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanList() Skip Take Order Where

        #region Tests Generated for GetSamplingPlanList() Skip Take Order 2Where
        [TestMethod]
        public void GetSamplingPlanList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanService.Query = samplingPlanService.FillQuery(typeof(SamplingPlan), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanID", "SamplingPlanID,GT,2|SamplingPlanID,LT,5", "");

                        List<SamplingPlan> samplingPlanDirectQueryList = new List<SamplingPlan>();
                        samplingPlanDirectQueryList = (from c in dbTestDB.SamplingPlans select c).Where(c => c.SamplingPlanID > 2 && c.SamplingPlanID < 5).Skip(0).Take(1).OrderBy(c => c.SamplingPlanID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<SamplingPlan> samplingPlanList = new List<SamplingPlan>();
                            samplingPlanList = samplingPlanService.GetSamplingPlanList().ToList();
                            CheckSamplingPlanFields(samplingPlanList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanList[0].SamplingPlanID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<SamplingPlanExtraA> samplingPlanExtraAList = new List<SamplingPlanExtraA>();
                            samplingPlanExtraAList = samplingPlanService.GetSamplingPlanExtraAList().ToList();
                            CheckSamplingPlanExtraAFields(samplingPlanExtraAList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraAList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<SamplingPlanExtraB> samplingPlanExtraBList = new List<SamplingPlanExtraB>();
                            samplingPlanExtraBList = samplingPlanService.GetSamplingPlanExtraBList().ToList();
                            CheckSamplingPlanExtraBFields(samplingPlanExtraBList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraBList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanList() Skip Take Order 2Where

        #region Tests Generated for GetSamplingPlanList() 2Where
        [TestMethod]
        public void GetSamplingPlanList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        SamplingPlanService samplingPlanService = new SamplingPlanService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanService.Query = samplingPlanService.FillQuery(typeof(SamplingPlan), culture.TwoLetterISOLanguageName, 0, 10000, "", "SamplingPlanID,GT,2|SamplingPlanID,LT,5", "");

                        List<SamplingPlan> samplingPlanDirectQueryList = new List<SamplingPlan>();
                        samplingPlanDirectQueryList = (from c in dbTestDB.SamplingPlans select c).Where(c => c.SamplingPlanID > 2 && c.SamplingPlanID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<SamplingPlan> samplingPlanList = new List<SamplingPlan>();
                            samplingPlanList = samplingPlanService.GetSamplingPlanList().ToList();
                            CheckSamplingPlanFields(samplingPlanList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanList[0].SamplingPlanID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<SamplingPlanExtraA> samplingPlanExtraAList = new List<SamplingPlanExtraA>();
                            samplingPlanExtraAList = samplingPlanService.GetSamplingPlanExtraAList().ToList();
                            CheckSamplingPlanExtraAFields(samplingPlanExtraAList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraAList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<SamplingPlanExtraB> samplingPlanExtraBList = new List<SamplingPlanExtraB>();
                            samplingPlanExtraBList = samplingPlanService.GetSamplingPlanExtraBList().ToList();
                            CheckSamplingPlanExtraBFields(samplingPlanExtraBList);
                            Assert.AreEqual(samplingPlanDirectQueryList[0].SamplingPlanID, samplingPlanExtraBList[0].SamplingPlanID);
                            Assert.AreEqual(samplingPlanDirectQueryList.Count, samplingPlanExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanList() 2Where

        #region Functions private
        private void CheckSamplingPlanFields(List<SamplingPlan> samplingPlanList)
        {
            Assert.IsNotNull(samplingPlanList[0].SamplingPlanID);
            Assert.IsNotNull(samplingPlanList[0].IsActive);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanList[0].SamplingPlanName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanList[0].ForGroupName));
            Assert.IsNotNull(samplingPlanList[0].SampleType);
            Assert.IsNotNull(samplingPlanList[0].SamplingPlanType);
            Assert.IsNotNull(samplingPlanList[0].LabSheetType);
            Assert.IsNotNull(samplingPlanList[0].ProvinceTVItemID);
            Assert.IsNotNull(samplingPlanList[0].CreatorTVItemID);
            Assert.IsNotNull(samplingPlanList[0].Year);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanList[0].AccessCode));
            Assert.IsNotNull(samplingPlanList[0].DailyDuplicatePrecisionCriteria);
            Assert.IsNotNull(samplingPlanList[0].IntertechDuplicatePrecisionCriteria);
            Assert.IsNotNull(samplingPlanList[0].IncludeLaboratoryQAQC);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanList[0].ApprovalCode));
            if (samplingPlanList[0].SamplingPlanFileTVItemID != null)
            {
                Assert.IsNotNull(samplingPlanList[0].SamplingPlanFileTVItemID);
            }
            if (samplingPlanList[0].AnalyzeMethodDefault != null)
            {
                Assert.IsNotNull(samplingPlanList[0].AnalyzeMethodDefault);
            }
            if (samplingPlanList[0].SampleMatrixDefault != null)
            {
                Assert.IsNotNull(samplingPlanList[0].SampleMatrixDefault);
            }
            if (samplingPlanList[0].LaboratoryDefault != null)
            {
                Assert.IsNotNull(samplingPlanList[0].LaboratoryDefault);
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanList[0].BackupDirectory));
            Assert.IsNotNull(samplingPlanList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanList[0].HasErrors);
        }
        private void CheckSamplingPlanExtraAFields(List<SamplingPlanExtraA> samplingPlanExtraAList)
        {
            Assert.IsNotNull(samplingPlanExtraAList[0].ProvinceTVItemLanguage);
            Assert.IsNotNull(samplingPlanExtraAList[0].CreatorTVItemLanguage);
            Assert.IsNotNull(samplingPlanExtraAList[0].SamplingPlanFileTVItemLanguage);
            Assert.IsNotNull(samplingPlanExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].SampleTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].SampleTypeText));
            }
            if (!string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].SamplingPlanTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].SamplingPlanTypeText));
            }
            if (!string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].LabSheetTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].LabSheetTypeText));
            }
            Assert.IsNotNull(samplingPlanExtraAList[0].SamplingPlanID);
            Assert.IsNotNull(samplingPlanExtraAList[0].IsActive);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].SamplingPlanName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].ForGroupName));
            Assert.IsNotNull(samplingPlanExtraAList[0].SampleType);
            Assert.IsNotNull(samplingPlanExtraAList[0].SamplingPlanType);
            Assert.IsNotNull(samplingPlanExtraAList[0].LabSheetType);
            Assert.IsNotNull(samplingPlanExtraAList[0].ProvinceTVItemID);
            Assert.IsNotNull(samplingPlanExtraAList[0].CreatorTVItemID);
            Assert.IsNotNull(samplingPlanExtraAList[0].Year);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].AccessCode));
            Assert.IsNotNull(samplingPlanExtraAList[0].DailyDuplicatePrecisionCriteria);
            Assert.IsNotNull(samplingPlanExtraAList[0].IntertechDuplicatePrecisionCriteria);
            Assert.IsNotNull(samplingPlanExtraAList[0].IncludeLaboratoryQAQC);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].ApprovalCode));
            if (samplingPlanExtraAList[0].SamplingPlanFileTVItemID != null)
            {
                Assert.IsNotNull(samplingPlanExtraAList[0].SamplingPlanFileTVItemID);
            }
            if (samplingPlanExtraAList[0].AnalyzeMethodDefault != null)
            {
                Assert.IsNotNull(samplingPlanExtraAList[0].AnalyzeMethodDefault);
            }
            if (samplingPlanExtraAList[0].SampleMatrixDefault != null)
            {
                Assert.IsNotNull(samplingPlanExtraAList[0].SampleMatrixDefault);
            }
            if (samplingPlanExtraAList[0].LaboratoryDefault != null)
            {
                Assert.IsNotNull(samplingPlanExtraAList[0].LaboratoryDefault);
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraAList[0].BackupDirectory));
            Assert.IsNotNull(samplingPlanExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanExtraAList[0].HasErrors);
        }
        private void CheckSamplingPlanExtraBFields(List<SamplingPlanExtraB> samplingPlanExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].SamplingPlanReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].SamplingPlanReportTest));
            }
            Assert.IsNotNull(samplingPlanExtraBList[0].ProvinceTVItemLanguage);
            Assert.IsNotNull(samplingPlanExtraBList[0].CreatorTVItemLanguage);
            Assert.IsNotNull(samplingPlanExtraBList[0].SamplingPlanFileTVItemLanguage);
            Assert.IsNotNull(samplingPlanExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].SampleTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].SampleTypeText));
            }
            if (!string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].SamplingPlanTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].SamplingPlanTypeText));
            }
            if (!string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].LabSheetTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].LabSheetTypeText));
            }
            Assert.IsNotNull(samplingPlanExtraBList[0].SamplingPlanID);
            Assert.IsNotNull(samplingPlanExtraBList[0].IsActive);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].SamplingPlanName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].ForGroupName));
            Assert.IsNotNull(samplingPlanExtraBList[0].SampleType);
            Assert.IsNotNull(samplingPlanExtraBList[0].SamplingPlanType);
            Assert.IsNotNull(samplingPlanExtraBList[0].LabSheetType);
            Assert.IsNotNull(samplingPlanExtraBList[0].ProvinceTVItemID);
            Assert.IsNotNull(samplingPlanExtraBList[0].CreatorTVItemID);
            Assert.IsNotNull(samplingPlanExtraBList[0].Year);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].AccessCode));
            Assert.IsNotNull(samplingPlanExtraBList[0].DailyDuplicatePrecisionCriteria);
            Assert.IsNotNull(samplingPlanExtraBList[0].IntertechDuplicatePrecisionCriteria);
            Assert.IsNotNull(samplingPlanExtraBList[0].IncludeLaboratoryQAQC);
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].ApprovalCode));
            if (samplingPlanExtraBList[0].SamplingPlanFileTVItemID != null)
            {
                Assert.IsNotNull(samplingPlanExtraBList[0].SamplingPlanFileTVItemID);
            }
            if (samplingPlanExtraBList[0].AnalyzeMethodDefault != null)
            {
                Assert.IsNotNull(samplingPlanExtraBList[0].AnalyzeMethodDefault);
            }
            if (samplingPlanExtraBList[0].SampleMatrixDefault != null)
            {
                Assert.IsNotNull(samplingPlanExtraBList[0].SampleMatrixDefault);
            }
            if (samplingPlanExtraBList[0].LaboratoryDefault != null)
            {
                Assert.IsNotNull(samplingPlanExtraBList[0].LaboratoryDefault);
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanExtraBList[0].BackupDirectory));
            Assert.IsNotNull(samplingPlanExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanExtraBList[0].HasErrors);
        }
        private SamplingPlan GetFilledRandomSamplingPlan(string OmitPropName)
        {
            SamplingPlan samplingPlan = new SamplingPlan();

            if (OmitPropName != "IsActive") samplingPlan.IsActive = true;
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
            if (OmitPropName != "SamplingPlanFileTVItemID") samplingPlan.SamplingPlanFileTVItemID = 41;
            if (OmitPropName != "AnalyzeMethodDefault") samplingPlan.AnalyzeMethodDefault = (AnalyzeMethodEnum)GetRandomEnumType(typeof(AnalyzeMethodEnum));
            if (OmitPropName != "SampleMatrixDefault") samplingPlan.SampleMatrixDefault = (SampleMatrixEnum)GetRandomEnumType(typeof(SampleMatrixEnum));
            if (OmitPropName != "LaboratoryDefault") samplingPlan.LaboratoryDefault = (LaboratoryEnum)GetRandomEnumType(typeof(LaboratoryEnum));
            if (OmitPropName != "BackupDirectory") samplingPlan.BackupDirectory = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlan.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlan.LastUpdateContactTVItemID = 2;

            return samplingPlan;
        }
        #endregion Functions private
    }
}
