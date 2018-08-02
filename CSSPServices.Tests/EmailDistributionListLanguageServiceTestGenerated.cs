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

                    count = emailDistributionListLanguageService.GetRead().Count();

                    Assert.AreEqual(emailDistributionListLanguageService.GetRead().Count(), emailDistributionListLanguageService.GetEdit().Count());

                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    if (emailDistributionListLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailDistributionListLanguageService.GetRead().Where(c => c == emailDistributionListLanguage).Any());
                    emailDistributionListLanguageService.Update(emailDistributionListLanguage);
                    if (emailDistributionListLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailDistributionListLanguageService.GetRead().Count());
                    emailDistributionListLanguageService.Delete(emailDistributionListLanguage);
                    if (emailDistributionListLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageEmailDistributionListLanguageID), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListLanguageID = 10000000;
                    emailDistributionListLanguageService.Update(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListLanguage, CSSPModelsRes.EmailDistributionListLanguageEmailDistributionListLanguageID, emailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID", AllowableTVtypeList = )]
                    // emailDistributionListLanguage.EmailDistributionListID   (Int32)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListID = 0;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionList, CSSPModelsRes.EmailDistributionListLanguageEmailDistributionListID, emailDistributionListLanguage.EmailDistributionListID.ToString()), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.Language = (LanguageEnum)1000000;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageLanguage), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100, MinimumLength = 1)]
                    // emailDistributionListLanguage.RegionName   (String)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("RegionName");
                    Assert.AreEqual(false, emailDistributionListLanguageService.Add(emailDistributionListLanguage));
                    Assert.AreEqual(1, emailDistributionListLanguage.ValidationResults.Count());
                    Assert.IsTrue(emailDistributionListLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageRegionName)).Any());
                    Assert.AreEqual(null, emailDistributionListLanguage.RegionName);
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetRead().Count());

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.RegionName = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListLanguageService.Add(emailDistributionListLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.EmailDistributionListLanguageRegionName, "1", "100"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageTranslationStatus), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionListLanguage.EmailDistributionListLanguageWeb   (EmailDistributionListLanguageWeb)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListLanguageWeb = null;
                    Assert.IsNull(emailDistributionListLanguage.EmailDistributionListLanguageWeb);

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListLanguageWeb = new EmailDistributionListLanguageWeb();
                    Assert.IsNotNull(emailDistributionListLanguage.EmailDistributionListLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionListLanguage.EmailDistributionListLanguageReport   (EmailDistributionListLanguageReport)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListLanguageReport = null;
                    Assert.IsNull(emailDistributionListLanguage.EmailDistributionListLanguageReport);

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListLanguageReport = new EmailDistributionListLanguageReport();
                    Assert.IsNotNull(emailDistributionListLanguage.EmailDistributionListLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionListLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLanguageLastUpdateDate_UTC), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailDistributionListLanguageLastUpdateDate_UTC, "1980"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionListLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateContactTVItemID = 0;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListLanguageLastUpdateContactTVItemID, emailDistributionListLanguage.LastUpdateContactTVItemID.ToString()), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateContactTVItemID = 1;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailDistributionListLanguageLastUpdateContactTVItemID, "Contact"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    EmailDistributionListLanguage emailDistributionListLanguage = (from c in emailDistributionListLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListLanguage);

                    EmailDistributionListLanguage emailDistributionListLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            emailDistributionListLanguageRet = emailDistributionListLanguageService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID);
                            Assert.IsNull(emailDistributionListLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListLanguageRet = emailDistributionListLanguageService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListLanguageRet = emailDistributionListLanguageService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListLanguageRet = emailDistributionListLanguageService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListLanguageFields(new List<EmailDistributionListLanguage>() { emailDistributionListLanguageRet }, entityQueryDetailType);
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
                    EmailDistributionListLanguage emailDistributionListLanguage = (from c in emailDistributionListLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListLanguage);

                    List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            Assert.AreEqual(0, emailDistributionListLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList, entityQueryDetailType);
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
                    List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                    List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListLanguageDirectQueryList = emailDistributionListLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            Assert.AreEqual(0, emailDistributionListLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                        Assert.AreEqual(1, emailDistributionListLanguageList.Count);
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
                    List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                    List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "EmailDistributionListLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListLanguageDirectQueryList = emailDistributionListLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.EmailDistributionListLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            Assert.AreEqual(0, emailDistributionListLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                        Assert.AreEqual(1, emailDistributionListLanguageList.Count);
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
                    List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                    List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 1, 1, "EmailDistributionListLanguageID,EmailDistributionListID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListLanguageDirectQueryList = emailDistributionListLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.EmailDistributionListLanguageID).ThenBy(c => c.EmailDistributionListID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            Assert.AreEqual(0, emailDistributionListLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                        Assert.AreEqual(1, emailDistributionListLanguageList.Count);
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
                    List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                    List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListLanguageID", "EmailDistributionListLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListLanguageDirectQueryList = emailDistributionListLanguageService.GetRead().Where(c => c.EmailDistributionListLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            Assert.AreEqual(0, emailDistributionListLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                        Assert.AreEqual(1, emailDistributionListLanguageList.Count);
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
                    List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                    List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListLanguageID", "EmailDistributionListLanguageID,GT,2|EmailDistributionListLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListLanguageDirectQueryList = emailDistributionListLanguageService.GetRead().Where(c => c.EmailDistributionListLanguageID > 2 && c.EmailDistributionListLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            Assert.AreEqual(0, emailDistributionListLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                        Assert.AreEqual(1, emailDistributionListLanguageList.Count);
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
                    List<EmailDistributionListLanguage> emailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
                    List<EmailDistributionListLanguage> emailDistributionListLanguageDirectQueryList = new List<EmailDistributionListLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListLanguageService.Query = emailDistributionListLanguageService.FillQuery(typeof(EmailDistributionListLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "EmailDistributionListLanguageID,GT,2|EmailDistributionListLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListLanguageDirectQueryList = emailDistributionListLanguageService.GetRead().Where(c => c.EmailDistributionListLanguageID > 2 && c.EmailDistributionListLanguageID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                            Assert.AreEqual(0, emailDistributionListLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListLanguageList = emailDistributionListLanguageService.GetEmailDistributionListLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListLanguageFields(emailDistributionListLanguageList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListLanguageDirectQueryList[0].EmailDistributionListLanguageID, emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
                        Assert.AreEqual(2, emailDistributionListLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListLanguageList() 2Where

        #region Functions private
        private void CheckEmailDistributionListLanguageFields(List<EmailDistributionListLanguage> emailDistributionListLanguageList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // EmailDistributionListLanguage fields
            Assert.IsNotNull(emailDistributionListLanguageList[0].EmailDistributionListLanguageID);
            Assert.IsNotNull(emailDistributionListLanguageList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].RegionName));
            Assert.IsNotNull(emailDistributionListLanguageList[0].TranslationStatus);
            Assert.IsNotNull(emailDistributionListLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListLanguageList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // EmailDistributionListLanguageWeb and EmailDistributionListLanguageReport fields should be null here
                Assert.IsNull(emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb);
                Assert.IsNull(emailDistributionListLanguageList[0].EmailDistributionListLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // EmailDistributionListLanguageWeb fields should not be null and EmailDistributionListLanguageReport fields should be null here
                Assert.IsNotNull(emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.LastUpdateContactTVItemLanguage);
                if (!string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.LanguageText));
                }
                if (!string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.TranslationStatusText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.TranslationStatusText));
                }
                Assert.IsNull(emailDistributionListLanguageList[0].EmailDistributionListLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // EmailDistributionListLanguageWeb and EmailDistributionListLanguageReport fields should NOT be null here
                Assert.IsNotNull(emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.LastUpdateContactTVItemLanguage);
                if (emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.LanguageText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.LanguageText));
                }
                if (emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.TranslationStatusText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].EmailDistributionListLanguageWeb.TranslationStatusText));
                }
                if (emailDistributionListLanguageList[0].EmailDistributionListLanguageReport.EmailDistributionListLanguageReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageList[0].EmailDistributionListLanguageReport.EmailDistributionListLanguageReportTest));
                }
            }
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
