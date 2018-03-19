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
    public partial class BoxModelLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private BoxModelLanguageService boxModelLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageServiceTest() : base()
        {
            //boxModelLanguageService = new BoxModelLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModelLanguage GetFilledRandomBoxModelLanguage(string OmitPropName)
        {
            BoxModelLanguage boxModelLanguage = new BoxModelLanguage();

            if (OmitPropName != "BoxModelID") boxModelLanguage.BoxModelID = 0;
            if (OmitPropName != "Language") boxModelLanguage.Language = LanguageRequest;
            if (OmitPropName != "ScenarioName") boxModelLanguage.ScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") boxModelLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") boxModelLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelLanguage.LastUpdateContactTVItemID = 2;

            return boxModelLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void BoxModelLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    BoxModelLanguage boxModelLanguage = GetFilledRandomBoxModelLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = boxModelLanguageService.GetRead().Count();

                    Assert.AreEqual(boxModelLanguageService.GetRead().Count(), boxModelLanguageService.GetEdit().Count());

                    boxModelLanguageService.Add(boxModelLanguage);
                    if (boxModelLanguage.HasErrors)
                    {
                        Assert.AreEqual("", boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, boxModelLanguageService.GetRead().Where(c => c == boxModelLanguage).Any());
                    boxModelLanguageService.Update(boxModelLanguage);
                    if (boxModelLanguage.HasErrors)
                    {
                        Assert.AreEqual("", boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, boxModelLanguageService.GetRead().Count());
                    boxModelLanguageService.Delete(boxModelLanguage);
                    if (boxModelLanguage.HasErrors)
                    {
                        Assert.AreEqual("", boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // boxModelLanguage.BoxModelLanguageID   (Int32)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelLanguageID = 0;
                    boxModelLanguageService.Update(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelLanguageBoxModelLanguageID), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelLanguageID = 10000000;
                    boxModelLanguageService.Update(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.BoxModelLanguage, CSSPModelsRes.BoxModelLanguageBoxModelLanguageID, boxModelLanguage.BoxModelLanguageID.ToString()), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID", AllowableTVtypeList = Error)]
                    // boxModelLanguage.BoxModelID   (Int32)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelID = 0;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.BoxModel, CSSPModelsRes.BoxModelLanguageBoxModelID, boxModelLanguage.BoxModelID.ToString()), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // boxModelLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.Language = (LanguageEnum)1000000;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelLanguageLanguage), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // boxModelLanguage.ScenarioName   (String)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("ScenarioName");
                    Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
                    Assert.AreEqual(1, boxModelLanguage.ValidationResults.Count());
                    Assert.IsTrue(boxModelLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelLanguageScenarioName)).Any());
                    Assert.AreEqual(null, boxModelLanguage.ScenarioName);
                    Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.ScenarioName = GetRandomString("", 251);
                    Assert.AreEqual(false, boxModelLanguageService.Add(boxModelLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.BoxModelLanguageScenarioName, "250"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // boxModelLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelLanguageTranslationStatus), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // boxModelLanguage.BoxModelLanguageWeb   (BoxModelLanguageWeb)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelLanguageWeb = null;
                    Assert.IsNull(boxModelLanguage.BoxModelLanguageWeb);

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelLanguageWeb = new BoxModelLanguageWeb();
                    Assert.IsNotNull(boxModelLanguage.BoxModelLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // boxModelLanguage.BoxModelLanguageReport   (BoxModelLanguageReport)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelLanguageReport = null;
                    Assert.IsNull(boxModelLanguage.BoxModelLanguageReport);

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.BoxModelLanguageReport = new BoxModelLanguageReport();
                    Assert.IsNotNull(boxModelLanguage.BoxModelLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // boxModelLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.LastUpdateDate_UTC = new DateTime();
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelLanguageLastUpdateDate_UTC), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.BoxModelLanguageLastUpdateDate_UTC, "1980"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // boxModelLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.LastUpdateContactTVItemID = 0;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.BoxModelLanguageLastUpdateContactTVItemID, boxModelLanguage.LastUpdateContactTVItemID.ToString()), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModelLanguage = null;
                    boxModelLanguage = GetFilledRandomBoxModelLanguage("");
                    boxModelLanguage.LastUpdateContactTVItemID = 1;
                    boxModelLanguageService.Add(boxModelLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.BoxModelLanguageLastUpdateContactTVItemID, "Contact"), boxModelLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // boxModelLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // boxModelLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void BoxModelLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    BoxModelLanguageService boxModelLanguageService = new BoxModelLanguageService(new GetParam(), dbTestDB, ContactID);
                    BoxModelLanguage boxModelLanguage = (from c in boxModelLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(boxModelLanguage);

                    BoxModelLanguage boxModelLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            boxModelLanguageRet = boxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(boxModelLanguage.BoxModelLanguageID, getParam);
                            Assert.IsNull(boxModelLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            boxModelLanguageRet = boxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(boxModelLanguage.BoxModelLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            boxModelLanguageRet = boxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(boxModelLanguage.BoxModelLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            boxModelLanguageRet = boxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(boxModelLanguage.BoxModelLanguageID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // BoxModelLanguage fields
                        Assert.IsNotNull(boxModelLanguageRet.BoxModelLanguageID);
                        Assert.IsNotNull(boxModelLanguageRet.BoxModelID);
                        Assert.IsNotNull(boxModelLanguageRet.Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguageRet.ScenarioName));
                        Assert.IsNotNull(boxModelLanguageRet.TranslationStatus);
                        Assert.IsNotNull(boxModelLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(boxModelLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // BoxModelLanguageWeb and BoxModelLanguageReport fields should be null here
                            Assert.IsNull(boxModelLanguageRet.BoxModelLanguageWeb);
                            Assert.IsNull(boxModelLanguageRet.BoxModelLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // BoxModelLanguageWeb fields should not be null and BoxModelLanguageReport fields should be null here
                            if (boxModelLanguageRet.BoxModelLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguageRet.BoxModelLanguageWeb.LastUpdateContactTVText));
                            }
                            if (boxModelLanguageRet.BoxModelLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguageRet.BoxModelLanguageWeb.LanguageText));
                            }
                            if (boxModelLanguageRet.BoxModelLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguageRet.BoxModelLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(boxModelLanguageRet.BoxModelLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // BoxModelLanguageWeb and BoxModelLanguageReport fields should NOT be null here
                            if (boxModelLanguageRet.BoxModelLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguageRet.BoxModelLanguageWeb.LastUpdateContactTVText));
                            }
                            if (boxModelLanguageRet.BoxModelLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguageRet.BoxModelLanguageWeb.LanguageText));
                            }
                            if (boxModelLanguageRet.BoxModelLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguageRet.BoxModelLanguageWeb.TranslationStatusText));
                            }
                            if (boxModelLanguageRet.BoxModelLanguageReport.BoxModelLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelLanguageRet.BoxModelLanguageReport.BoxModelLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of BoxModelLanguage
        #endregion Tests Get List of BoxModelLanguage

    }
}
