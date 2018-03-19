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
    public partial class InfrastructureLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private InfrastructureLanguageService infrastructureLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageServiceTest() : base()
        {
            //infrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private InfrastructureLanguage GetFilledRandomInfrastructureLanguage(string OmitPropName)
        {
            InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();

            if (OmitPropName != "InfrastructureID") infrastructureLanguage.InfrastructureID = 0;
            if (OmitPropName != "Language") infrastructureLanguage.Language = LanguageRequest;
            if (OmitPropName != "Comment") infrastructureLanguage.Comment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") infrastructureLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructureLanguage.LastUpdateContactTVItemID = 2;

            return infrastructureLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void InfrastructureLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    InfrastructureLanguage infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = infrastructureLanguageService.GetRead().Count();

                    Assert.AreEqual(infrastructureLanguageService.GetRead().Count(), infrastructureLanguageService.GetEdit().Count());

                    infrastructureLanguageService.Add(infrastructureLanguage);
                    if (infrastructureLanguage.HasErrors)
                    {
                        Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, infrastructureLanguageService.GetRead().Where(c => c == infrastructureLanguage).Any());
                    infrastructureLanguageService.Update(infrastructureLanguage);
                    if (infrastructureLanguage.HasErrors)
                    {
                        Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, infrastructureLanguageService.GetRead().Count());
                    infrastructureLanguageService.Delete(infrastructureLanguage);
                    if (infrastructureLanguage.HasErrors)
                    {
                        Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // infrastructureLanguage.InfrastructureLanguageID   (Int32)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageID = 0;
                    infrastructureLanguageService.Update(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageInfrastructureLanguageID), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageID = 10000000;
                    infrastructureLanguageService.Update(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.InfrastructureLanguage, CSSPModelsRes.InfrastructureLanguageInfrastructureLanguageID, infrastructureLanguage.InfrastructureLanguageID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Infrastructure", ExistPlurial = "s", ExistFieldID = "InfrastructureID", AllowableTVtypeList = Error)]
                    // infrastructureLanguage.InfrastructureID   (Int32)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureID = 0;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Infrastructure, CSSPModelsRes.InfrastructureLanguageInfrastructureID, infrastructureLanguage.InfrastructureID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // infrastructureLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.Language = (LanguageEnum)1000000;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageLanguage), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // infrastructureLanguage.Comment   (String)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("Comment");
                    Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
                    Assert.AreEqual(1, infrastructureLanguage.ValidationResults.Count());
                    Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageComment)).Any());
                    Assert.AreEqual(null, infrastructureLanguage.Comment);
                    Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // infrastructureLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageTranslationStatus), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // infrastructureLanguage.InfrastructureLanguageWeb   (InfrastructureLanguageWeb)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageWeb = null;
                    Assert.IsNull(infrastructureLanguage.InfrastructureLanguageWeb);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageWeb = new InfrastructureLanguageWeb();
                    Assert.IsNotNull(infrastructureLanguage.InfrastructureLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // infrastructureLanguage.InfrastructureLanguageReport   (InfrastructureLanguageReport)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageReport = null;
                    Assert.IsNull(infrastructureLanguage.InfrastructureLanguageReport);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageReport = new InfrastructureLanguageReport();
                    Assert.IsNotNull(infrastructureLanguage.InfrastructureLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // infrastructureLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateDate_UTC = new DateTime();
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageLastUpdateDate_UTC), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.InfrastructureLanguageLastUpdateDate_UTC, "1980"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // infrastructureLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateContactTVItemID = 0;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, infrastructureLanguage.LastUpdateContactTVItemID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateContactTVItemID = 1;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, "Contact"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // infrastructureLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // infrastructureLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void InfrastructureLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new GetParam(), dbTestDB, ContactID);
                    InfrastructureLanguage infrastructureLanguage = (from c in infrastructureLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructureLanguage);

                    InfrastructureLanguage infrastructureLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID, getParam);
                            Assert.IsNull(infrastructureLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // InfrastructureLanguage fields
                        Assert.IsNotNull(infrastructureLanguageRet.InfrastructureLanguageID);
                        Assert.IsNotNull(infrastructureLanguageRet.InfrastructureID);
                        Assert.IsNotNull(infrastructureLanguageRet.Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.Comment));
                        Assert.IsNotNull(infrastructureLanguageRet.TranslationStatus);
                        Assert.IsNotNull(infrastructureLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(infrastructureLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // InfrastructureLanguageWeb and InfrastructureLanguageReport fields should be null here
                            Assert.IsNull(infrastructureLanguageRet.InfrastructureLanguageWeb);
                            Assert.IsNull(infrastructureLanguageRet.InfrastructureLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // InfrastructureLanguageWeb fields should not be null and InfrastructureLanguageReport fields should be null here
                            if (infrastructureLanguageRet.InfrastructureLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.InfrastructureLanguageWeb.LastUpdateContactTVText));
                            }
                            if (infrastructureLanguageRet.InfrastructureLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.InfrastructureLanguageWeb.LanguageText));
                            }
                            if (infrastructureLanguageRet.InfrastructureLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.InfrastructureLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(infrastructureLanguageRet.InfrastructureLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // InfrastructureLanguageWeb and InfrastructureLanguageReport fields should NOT be null here
                            if (infrastructureLanguageRet.InfrastructureLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.InfrastructureLanguageWeb.LastUpdateContactTVText));
                            }
                            if (infrastructureLanguageRet.InfrastructureLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.InfrastructureLanguageWeb.LanguageText));
                            }
                            if (infrastructureLanguageRet.InfrastructureLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.InfrastructureLanguageWeb.TranslationStatusText));
                            }
                            if (infrastructureLanguageRet.InfrastructureLanguageReport.InfrastructureLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.InfrastructureLanguageReport.InfrastructureLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of InfrastructureLanguage
        #endregion Tests Get List of InfrastructureLanguage

    }
}
