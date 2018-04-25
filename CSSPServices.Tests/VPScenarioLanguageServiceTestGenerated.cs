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
    public partial class VPScenarioLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPScenarioLanguageService vpScenarioLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageServiceTest() : base()
        {
            //vpScenarioLanguageService = new VPScenarioLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPScenarioLanguage GetFilledRandomVPScenarioLanguage(string OmitPropName)
        {
            VPScenarioLanguage vpScenarioLanguage = new VPScenarioLanguage();

            if (OmitPropName != "VPScenarioID") vpScenarioLanguage.VPScenarioID = 1;
            if (OmitPropName != "Language") vpScenarioLanguage.Language = LanguageRequest;
            if (OmitPropName != "VPScenarioName") vpScenarioLanguage.VPScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") vpScenarioLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") vpScenarioLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpScenarioLanguage.LastUpdateContactTVItemID = 2;

            return vpScenarioLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPScenarioLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    VPScenarioLanguage vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = vpScenarioLanguageService.GetRead().Count();

                    Assert.AreEqual(vpScenarioLanguageService.GetRead().Count(), vpScenarioLanguageService.GetEdit().Count());

                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    if (vpScenarioLanguage.HasErrors)
                    {
                        Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, vpScenarioLanguageService.GetRead().Where(c => c == vpScenarioLanguage).Any());
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    if (vpScenarioLanguage.HasErrors)
                    {
                        Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, vpScenarioLanguageService.GetRead().Count());
                    vpScenarioLanguageService.Delete(vpScenarioLanguage);
                    if (vpScenarioLanguage.HasErrors)
                    {
                        Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // vpScenarioLanguage.VPScenarioLanguageID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageID = 0;
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageVPScenarioLanguageID), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageID = 10000000;
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenarioLanguage, CSSPModelsRes.VPScenarioLanguageVPScenarioLanguageID, vpScenarioLanguage.VPScenarioLanguageID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = Error)]
                    // vpScenarioLanguage.VPScenarioID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioID = 0;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenario, CSSPModelsRes.VPScenarioLanguageVPScenarioID, vpScenarioLanguage.VPScenarioID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // vpScenarioLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.Language = (LanguageEnum)1000000;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageLanguage), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // vpScenarioLanguage.VPScenarioName   (String)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("VPScenarioName");
                    Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
                    Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
                    Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageVPScenarioName)).Any());
                    Assert.AreEqual(null, vpScenarioLanguage.VPScenarioName);
                    Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioName = GetRandomString("", 101);
                    Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.VPScenarioLanguageVPScenarioName, "100"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // vpScenarioLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageTranslationStatus), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.VPScenarioLanguageWeb   (VPScenarioLanguageWeb)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageWeb = null;
                    Assert.IsNull(vpScenarioLanguage.VPScenarioLanguageWeb);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageWeb = new VPScenarioLanguageWeb();
                    Assert.IsNotNull(vpScenarioLanguage.VPScenarioLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.VPScenarioLanguageReport   (VPScenarioLanguageReport)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageReport = null;
                    Assert.IsNull(vpScenarioLanguage.VPScenarioLanguageReport);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageReport = new VPScenarioLanguageReport();
                    Assert.IsNotNull(vpScenarioLanguage.VPScenarioLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpScenarioLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateDate_UTC = new DateTime();
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageLastUpdateDate_UTC), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.VPScenarioLanguageLastUpdateDate_UTC, "1980"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpScenarioLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateContactTVItemID = 0;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, vpScenarioLanguage.LastUpdateContactTVItemID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateContactTVItemID = 1;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, "Contact"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void VPScenarioLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new GetParam(), dbTestDB, ContactID);
                    VPScenarioLanguage vpScenarioLanguage = (from c in vpScenarioLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenarioLanguage);

                    VPScenarioLanguage vpScenarioLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            vpScenarioLanguageRet = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID, getParam);
                            Assert.IsNull(vpScenarioLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioLanguageRet = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioLanguageRet = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioLanguageRet = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // VPScenarioLanguage fields
                        Assert.IsNotNull(vpScenarioLanguageRet.VPScenarioLanguageID);
                        Assert.IsNotNull(vpScenarioLanguageRet.VPScenarioID);
                        Assert.IsNotNull(vpScenarioLanguageRet.Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageRet.VPScenarioName));
                        Assert.IsNotNull(vpScenarioLanguageRet.TranslationStatus);
                        Assert.IsNotNull(vpScenarioLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(vpScenarioLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // VPScenarioLanguageWeb and VPScenarioLanguageReport fields should be null here
                            Assert.IsNull(vpScenarioLanguageRet.VPScenarioLanguageWeb);
                            Assert.IsNull(vpScenarioLanguageRet.VPScenarioLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // VPScenarioLanguageWeb fields should not be null and VPScenarioLanguageReport fields should be null here
                            if (vpScenarioLanguageRet.VPScenarioLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageRet.VPScenarioLanguageWeb.LastUpdateContactTVText));
                            }
                            if (vpScenarioLanguageRet.VPScenarioLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageRet.VPScenarioLanguageWeb.LanguageText));
                            }
                            if (vpScenarioLanguageRet.VPScenarioLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageRet.VPScenarioLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(vpScenarioLanguageRet.VPScenarioLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // VPScenarioLanguageWeb and VPScenarioLanguageReport fields should NOT be null here
                            if (vpScenarioLanguageRet.VPScenarioLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageRet.VPScenarioLanguageWeb.LastUpdateContactTVText));
                            }
                            if (vpScenarioLanguageRet.VPScenarioLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageRet.VPScenarioLanguageWeb.LanguageText));
                            }
                            if (vpScenarioLanguageRet.VPScenarioLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageRet.VPScenarioLanguageWeb.TranslationStatusText));
                            }
                            if (vpScenarioLanguageRet.VPScenarioLanguageReport.VPScenarioLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageRet.VPScenarioLanguageReport.VPScenarioLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of VPScenarioLanguage
        #endregion Tests Get List of VPScenarioLanguage

    }
}
