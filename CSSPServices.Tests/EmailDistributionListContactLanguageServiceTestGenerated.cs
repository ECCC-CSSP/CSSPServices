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
    public partial class EmailDistributionListContactLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private EmailDistributionListContactLanguageService emailDistributionListContactLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageServiceTest() : base()
        {
            //emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private EmailDistributionListContactLanguage GetFilledRandomEmailDistributionListContactLanguage(string OmitPropName)
        {
            EmailDistributionListContactLanguage emailDistributionListContactLanguage = new EmailDistributionListContactLanguage();

            if (OmitPropName != "EmailDistributionListContactID") emailDistributionListContactLanguage.EmailDistributionListContactID = 0;
            if (OmitPropName != "Language") emailDistributionListContactLanguage.Language = LanguageRequest;
            if (OmitPropName != "Agency") emailDistributionListContactLanguage.Agency = GetRandomString("", 6);
            if (OmitPropName != "TranslationStatus") emailDistributionListContactLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListContactLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListContactLanguage.LastUpdateContactTVItemID = 2;

            return emailDistributionListContactLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void EmailDistributionListContactLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    EmailDistributionListContactLanguage emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = emailDistributionListContactLanguageService.GetRead().Count();

                    Assert.AreEqual(emailDistributionListContactLanguageService.GetRead().Count(), emailDistributionListContactLanguageService.GetEdit().Count());

                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    if (emailDistributionListContactLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailDistributionListContactLanguageService.GetRead().Where(c => c == emailDistributionListContactLanguage).Any());
                    emailDistributionListContactLanguageService.Update(emailDistributionListContactLanguage);
                    if (emailDistributionListContactLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailDistributionListContactLanguageService.GetRead().Count());
                    emailDistributionListContactLanguageService.Delete(emailDistributionListContactLanguage);
                    if (emailDistributionListContactLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailDistributionListContactLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // emailDistributionListContactLanguage.EmailDistributionListContactLanguageID   (Int32)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.EmailDistributionListContactLanguageID = 0;
                    emailDistributionListContactLanguageService.Update(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageEmailDistributionListContactLanguageID), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.EmailDistributionListContactLanguageID = 10000000;
                    emailDistributionListContactLanguageService.Update(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListContactLanguage, CSSPModelsRes.EmailDistributionListContactLanguageEmailDistributionListContactLanguageID, emailDistributionListContactLanguage.EmailDistributionListContactLanguageID.ToString()), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "EmailDistributionListContact", ExistPlurial = "s", ExistFieldID = "EmailDistributionListContactID", AllowableTVtypeList = Error)]
                    // emailDistributionListContactLanguage.EmailDistributionListContactID   (Int32)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.EmailDistributionListContactID = 0;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListContact, CSSPModelsRes.EmailDistributionListContactLanguageEmailDistributionListContactID, emailDistributionListContactLanguage.EmailDistributionListContactID.ToString()), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListContactLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.Language = (LanguageEnum)1000000;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageLanguage), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100, MinimumLength = 1)]
                    // emailDistributionListContactLanguage.Agency   (String)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("Agency");
                    Assert.AreEqual(false, emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage));
                    Assert.AreEqual(1, emailDistributionListContactLanguage.ValidationResults.Count());
                    Assert.IsTrue(emailDistributionListContactLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageAgency)).Any());
                    Assert.AreEqual(null, emailDistributionListContactLanguage.Agency);
                    Assert.AreEqual(count, emailDistributionListContactLanguageService.GetRead().Count());

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.Agency = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.EmailDistributionListContactLanguageAgency, "1", "100"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListContactLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListContactLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageTranslationStatus), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionListContactLanguage.EmailDistributionListContactLanguageWeb   (EmailDistributionListContactLanguageWeb)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.EmailDistributionListContactLanguageWeb = null;
                    Assert.IsNull(emailDistributionListContactLanguage.EmailDistributionListContactLanguageWeb);

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.EmailDistributionListContactLanguageWeb = new EmailDistributionListContactLanguageWeb();
                    Assert.IsNotNull(emailDistributionListContactLanguage.EmailDistributionListContactLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionListContactLanguage.EmailDistributionListContactLanguageReport   (EmailDistributionListContactLanguageReport)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.EmailDistributionListContactLanguageReport = null;
                    Assert.IsNull(emailDistributionListContactLanguage.EmailDistributionListContactLanguageReport);

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.EmailDistributionListContactLanguageReport = new EmailDistributionListContactLanguageReport();
                    Assert.IsNotNull(emailDistributionListContactLanguage.EmailDistributionListContactLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionListContactLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateDate_UTC), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateDate_UTC, "1980"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionListContactLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.LastUpdateContactTVItemID = 0;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateContactTVItemID, emailDistributionListContactLanguage.LastUpdateContactTVItemID.ToString()), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.LastUpdateContactTVItemID = 1;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailDistributionListContactLanguageLastUpdateContactTVItemID, "Contact"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListContactLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListContactLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void EmailDistributionListContactLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new GetParam(), dbTestDB, ContactID);
                    EmailDistributionListContactLanguage emailDistributionListContactLanguage = (from c in emailDistributionListContactLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListContactLanguage);

                    EmailDistributionListContactLanguage emailDistributionListContactLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactLanguageRet = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID, getParam);
                            Assert.IsNull(emailDistributionListContactLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactLanguageRet = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactLanguageRet = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactLanguageRet = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // EmailDistributionListContactLanguage fields
                        Assert.IsNotNull(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID);
                        Assert.IsNotNull(emailDistributionListContactLanguageRet.EmailDistributionListContactID);
                        Assert.IsNotNull(emailDistributionListContactLanguageRet.Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageRet.Agency));
                        Assert.IsNotNull(emailDistributionListContactLanguageRet.TranslationStatus);
                        Assert.IsNotNull(emailDistributionListContactLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(emailDistributionListContactLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // EmailDistributionListContactLanguageWeb and EmailDistributionListContactLanguageReport fields should be null here
                            Assert.IsNull(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb);
                            Assert.IsNull(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // EmailDistributionListContactLanguageWeb fields should not be null and EmailDistributionListContactLanguageReport fields should be null here
                            if (emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.LastUpdateContactTVText));
                            }
                            if (emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.LanguageText));
                            }
                            if (emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.TranslationStatusText));
                            }
                            Assert.IsNull(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // EmailDistributionListContactLanguageWeb and EmailDistributionListContactLanguageReport fields should NOT be null here
                            if (emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.LastUpdateContactTVText));
                            }
                            if (emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.LanguageText));
                            }
                            if (emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.TranslationStatusText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageWeb.TranslationStatusText));
                            }
                            if (emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageReport.EmailDistributionListContactLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageReport.EmailDistributionListContactLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of EmailDistributionListContactLanguage
        #endregion Tests Get List of EmailDistributionListContactLanguage

    }
}
