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
    public partial class EmailDistributionListLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private EmailDistributionListLanguageService emailDistributionListLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageServiceTest() : base()
        {
            //emailDistributionListLanguageService = new EmailDistributionListLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void EmailDistributionListLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    EmailDistributionListLanguage emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().Count();

                    Assert.AreEqual(emailDistributionListLanguageService.GetEmailDistributionListLanguageList().Count(), (from c in dbTestDB.EmailDistributionListLanguages select c).Take(200).Count());

                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    if (emailDistributionListLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailDistributionListLanguageService.GetEmailDistributionListLanguageList().Where(c => c == emailDistributionListLanguage).Any());
                    emailDistributionListLanguageService.Update(emailDistributionListLanguage);
                    if (emailDistributionListLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailDistributionListLanguageService.GetEmailDistributionListLanguageList().Count());
                    emailDistributionListLanguageService.Delete(emailDistributionListLanguage);
                    if (emailDistributionListLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetEmailDistributionListLanguageList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // emailDistributionListLanguage.EmailDistributionListLanguageID   (Int32)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListLanguageID = 0;
                    emailDistributionListLanguageService.Update(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageEmailDistributionListLanguageID"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListLanguageID = 10000000;
                    emailDistributionListLanguageService.Update(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListLanguage", "EmailDistributionListLanguageEmailDistributionListLanguageID", emailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID", AllowableTVtypeList = )]
                    // emailDistributionListLanguage.EmailDistributionListID   (Int32)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListID = 0;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListLanguageEmailDistributionListID", emailDistributionListLanguage.EmailDistributionListID.ToString()), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.Language = (LanguageEnum)1000000;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageLanguage"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100, MinimumLength = 1)]
                    // emailDistributionListLanguage.RegionName   (String)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("RegionName");
                    Assert.AreEqual(false, emailDistributionListLanguageService.Add(emailDistributionListLanguage));
                    Assert.AreEqual(1, emailDistributionListLanguage.ValidationResults.Count());
                    Assert.IsTrue(emailDistributionListLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageRegionName")).Any());
                    Assert.AreEqual(null, emailDistributionListLanguage.RegionName);
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetEmailDistributionListLanguageList().Count());

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.RegionName = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListLanguageService.Add(emailDistributionListLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "EmailDistributionListLanguageRegionName", "1", "100"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetEmailDistributionListLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageTranslationStatus"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionListLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLanguageLastUpdateDate_UTC"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EmailDistributionListLanguageLastUpdateDate_UTC", "1980"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionListLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateContactTVItemID = 0;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailDistributionListLanguageLastUpdateContactTVItemID", emailDistributionListLanguage.LastUpdateContactTVItemID.ToString()), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateContactTVItemID = 1;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "EmailDistributionListLanguageLastUpdateContactTVItemID", "Contact"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID)
        [TestMethod]
        public void GetEmailDistributionListLanguageWithEmailDistributionListLanguageID__emailDistributionListLanguage_EmailDistributionListLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionListLanguage emailDistributionListLanguage = (from c in dbTestDB.EmailDistributionListLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListLanguage);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            EmailDistributionListLanguage emailDistributionListLanguageRet = emailDistributionListLanguageService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID);
                            CheckEmailDistributionListLanguageFields(new List<EmailDistributionListLanguage>() { emailDistributionListLanguageRet });
                            Assert.AreEqual(emailDistributionListLanguage.EmailDistributionListLanguageID, emailDistributionListLanguageRet.EmailDistributionListLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            EmailDistributionListLanguageWeb emailDistributionListLanguageWebRet = emailDistributionListLanguageService.GetEmailDistributionListLanguageWebWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID);
                            CheckEmailDistributionListLanguageWebFields(new List<EmailDistributionListLanguageWeb>() { emailDistributionListLanguageWebRet });
                            Assert.AreEqual(emailDistributionListLanguage.EmailDistributionListLanguageID, emailDistributionListLanguageWebRet.EmailDistributionListLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            EmailDistributionListLanguageReport emailDistributionListLanguageReportRet = emailDistributionListLanguageService.GetEmailDistributionListLanguageReportWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID);
                            CheckEmailDistributionListLanguageReportFields(new List<EmailDistributionListLanguageReport>() { emailDistributionListLanguageReportRet });
                            Assert.AreEqual(emailDistributionListLanguage.EmailDistributionListLanguageID, emailDistributionListLanguageReportRet.EmailDistributionListLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID)

        #region Tests Generated for GetEmailDistributionListLanguageList()
        [TestMethod]
        public void GetEmailDistributionListLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionListLanguage emailDistributionListLanguage = (from c in dbTestDB.EmailDistributionListLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListLanguage);

                    List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                    emailDistributionListLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListLanguages select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListLanguageWeb> emailDistributionListLanguageWebList = new List<EmailDistributionListLanguageWeb>();
                            emailDistributionListLanguageWebList = emailDistributionListLanguageService.GetEmailDistributionListLanguageWebList().ToList();
                            CheckEmailDistributionListLanguageWebFields(emailDistributionListLanguageWebList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListLanguageReport> emailDistributionListLanguageReportList = new List<EmailDistributionListLanguageReport>();
                            emailDistributionListLanguageReportList = emailDistributionListLanguageService.GetEmailDistributionListLanguageReportList().ToList();
                            CheckEmailDistributionListLanguageReportFields(emailDistributionListLanguageReportList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListLanguageList()

        #region Tests Generated for GetEmailDistributionListLanguageList() Skip Take
        [TestMethod]
        public void GetEmailDistributionListLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                        emailDistributionListLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListLanguages select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListLanguageWeb> emailDistributionListLanguageWebList = new List<EmailDistributionListLanguageWeb>();
                            emailDistributionListLanguageWebList = emailDistributionListLanguageService.GetEmailDistributionListLanguageWebList().ToList();
                            CheckEmailDistributionListLanguageWebFields(emailDistributionListLanguageWebList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageWebList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListLanguageReport> emailDistributionListLanguageReportList = new List<EmailDistributionListLanguageReport>();
                            emailDistributionListLanguageReportList = emailDistributionListLanguageService.GetEmailDistributionListLanguageReportList().ToList();
                            CheckEmailDistributionListLanguageReportFields(emailDistributionListLanguageReportList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageReportList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListLanguageList() Skip Take

        #region Tests Generated for GetEmailDistributionListLanguageList() Skip Take Order
        [TestMethod]
        public void GetEmailDistributionListLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "EmailDistributionListLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                        emailDistributionListLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListLanguages select c).Skip(1).Take(1).OrderBy(c => c.EmailDistributionListLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListLanguageWeb> emailDistributionListLanguageWebList = new List<EmailDistributionListLanguageWeb>();
                            emailDistributionListLanguageWebList = emailDistributionListLanguageService.GetEmailDistributionListLanguageWebList().ToList();
                            CheckEmailDistributionListLanguageWebFields(emailDistributionListLanguageWebList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageWebList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListLanguageReport> emailDistributionListLanguageReportList = new List<EmailDistributionListLanguageReport>();
                            emailDistributionListLanguageReportList = emailDistributionListLanguageService.GetEmailDistributionListLanguageReportList().ToList();
                            CheckEmailDistributionListLanguageReportFields(emailDistributionListLanguageReportList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageReportList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListLanguageList() Skip Take Order

        #region Tests Generated for GetEmailDistributionListLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetEmailDistributionListLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 1, 1, "EmailDistributionListLanguageID,EmailDistributionListID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                        emailDistributionListLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListLanguages select c).Skip(1).Take(1).OrderBy(c => c.EmailDistributionListLanguageID).ThenBy(c => c.EmailDistributionListID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListLanguageWeb> emailDistributionListLanguageWebList = new List<EmailDistributionListLanguageWeb>();
                            emailDistributionListLanguageWebList = emailDistributionListLanguageService.GetEmailDistributionListLanguageWebList().ToList();
                            CheckEmailDistributionListLanguageWebFields(emailDistributionListLanguageWebList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageWebList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListLanguageReport> emailDistributionListLanguageReportList = new List<EmailDistributionListLanguageReport>();
                            emailDistributionListLanguageReportList = emailDistributionListLanguageService.GetEmailDistributionListLanguageReportList().ToList();
                            CheckEmailDistributionListLanguageReportFields(emailDistributionListLanguageReportList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageReportList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListLanguageList() Skip Take 2Order

        #region Tests Generated for GetEmailDistributionListLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetEmailDistributionListLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListLanguageID", "EmailDistributionListLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                        emailDistributionListLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListLanguages select c).Where(c => c.EmailDistributionListLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListLanguageWeb> emailDistributionListLanguageWebList = new List<EmailDistributionListLanguageWeb>();
                            emailDistributionListLanguageWebList = emailDistributionListLanguageService.GetEmailDistributionListLanguageWebList().ToList();
                            CheckEmailDistributionListLanguageWebFields(emailDistributionListLanguageWebList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageWebList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListLanguageReport> emailDistributionListLanguageReportList = new List<EmailDistributionListLanguageReport>();
                            emailDistributionListLanguageReportList = emailDistributionListLanguageService.GetEmailDistributionListLanguageReportList().ToList();
                            CheckEmailDistributionListLanguageReportFields(emailDistributionListLanguageReportList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageReportList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListLanguageList() Skip Take Order Where

        #region Tests Generated for GetEmailDistributionListLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetEmailDistributionListLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListLanguageID", "EmailDistributionListLanguageID,GT,2|EmailDistributionListLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                        emailDistributionListLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListLanguages select c).Where(c => c.EmailDistributionListLanguageID > 2 && c.EmailDistributionListLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListLanguageWeb> emailDistributionListLanguageWebList = new List<EmailDistributionListLanguageWeb>();
                            emailDistributionListLanguageWebList = emailDistributionListLanguageService.GetEmailDistributionListLanguageWebList().ToList();
                            CheckEmailDistributionListLanguageWebFields(emailDistributionListLanguageWebList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageWebList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListLanguageReport> emailDistributionListLanguageReportList = new List<EmailDistributionListLanguageReport>();
                            emailDistributionListLanguageReportList = emailDistributionListLanguageService.GetEmailDistributionListLanguageReportList().ToList();
                            CheckEmailDistributionListLanguageReportFields(emailDistributionListLanguageReportList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageReportList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetEmailDistributionListLanguageList() 2Where
        [TestMethod]
        public void GetEmailDistributionListLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "EmailDistributionListLanguageID,GT,2|EmailDistributionListLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                        emailDistributionListLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListLanguages select c).Where(c => c.EmailDistributionListLanguageID > 2 && c.EmailDistributionListLanguageID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListLanguageWeb> emailDistributionListLanguageWebList = new List<EmailDistributionListLanguageWeb>();
                            emailDistributionListLanguageWebList = emailDistributionListLanguageService.GetEmailDistributionListLanguageWebList().ToList();
                            CheckEmailDistributionListLanguageWebFields(emailDistributionListLanguageWebList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageWebList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListLanguageReport> emailDistributionListLanguageReportList = new List<EmailDistributionListLanguageReport>();
                            emailDistributionListLanguageReportList = emailDistributionListLanguageService.GetEmailDistributionListLanguageReportList().ToList();
                            CheckEmailDistributionListLanguageReportFields(emailDistributionListLanguageReportList);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageReportList[0].EmailDistributionListLanguageID);
                            Assert.AreEqual(emailDistributionListLanguageDirectQueryList.Count, emailDistributionListLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListLanguageList() 2Where

        #region Functions private
        private void CheckEmailDistributionListLanguageFields(List<EmailDistributionListLanguage> emailDistributionListLanguageList)
        {
            Assert.IsNotNull(emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
            Assert.IsNotNull(emailDistributionListLanguageList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].RegionName));
            Assert.IsNotNull(emailDistributionListLanguageList[0].TranslationStatus);
            Assert.IsNotNull(emailDistributionListLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListLanguageList[0].HasErrors);
        }
        private void CheckEmailDistributionListLanguageWebFields(List<EmailDistributionListLanguageWeb> emailDistributionListLanguageWebList)
        {
            Assert.IsNotNull(emailDistributionListLanguageWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(emailDistributionListLanguageWebList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageWebList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(emailDistributionListLanguageWebList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageWebList[0].TranslationStatusText));
            }
            Assert.IsNotNull(emailDistributionListLanguageWebList[0].EmailDistributionListLanguageID);
            Assert.IsNotNull(emailDistributionListLanguageWebList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListLanguageWebList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageWebList[0].RegionName));
            Assert.IsNotNull(emailDistributionListLanguageWebList[0].TranslationStatus);
            Assert.IsNotNull(emailDistributionListLanguageWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListLanguageWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListLanguageWebList[0].HasErrors);
        }
        private void CheckEmailDistributionListLanguageReportFields(List<EmailDistributionListLanguageReport> emailDistributionListLanguageReportList)
        {
            if (!string.IsNullOrWhiteSpace(emailDistributionListLanguageReportList[0].EmailDistributionListLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageReportList[0].EmailDistributionListLanguageReportTest));
            }
            Assert.IsNotNull(emailDistributionListLanguageReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(emailDistributionListLanguageReportList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageReportList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(emailDistributionListLanguageReportList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageReportList[0].TranslationStatusText));
            }
            Assert.IsNotNull(emailDistributionListLanguageReportList[0].EmailDistributionListLanguageID);
            Assert.IsNotNull(emailDistributionListLanguageReportList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListLanguageReportList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageReportList[0].RegionName));
            Assert.IsNotNull(emailDistributionListLanguageReportList[0].TranslationStatus);
            Assert.IsNotNull(emailDistributionListLanguageReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListLanguageReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListLanguageReportList[0].HasErrors);
        }
        private EmailDistributionListLanguage GetFilledRandomEmailDistributionListLanguage(string OmitPropName)
        {
            EmailDistributionListLanguage emailDistributionListLanguage = new EmailDistributionListLanguage();

            if (OmitPropName != "EmailDistributionListID") emailDistributionListLanguage.EmailDistributionListID = 1;
            if (OmitPropName != "Language") emailDistributionListLanguage.Language = LanguageRequest;
            if (OmitPropName != "RegionName") emailDistributionListLanguage.RegionName = GetRandomString("", 6);
            if (OmitPropName != "TranslationStatus") emailDistributionListLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListLanguage.LastUpdateContactTVItemID = 2;

            return emailDistributionListLanguage;
        }
        #endregion Functions private
    }
}
