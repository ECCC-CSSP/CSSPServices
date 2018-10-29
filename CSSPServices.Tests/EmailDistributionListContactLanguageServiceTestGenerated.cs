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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void EmailDistributionListContactLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.EmailDistributionListContactLanguages select c).Count());

                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    if (emailDistributionListContactLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().Where(c => c == emailDistributionListContactLanguage).Any());
                    emailDistributionListContactLanguageService.Update(emailDistributionListContactLanguage);
                    if (emailDistributionListContactLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().Count());
                    emailDistributionListContactLanguageService.Delete(emailDistributionListContactLanguage);
                    if (emailDistributionListContactLanguage.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageEmailDistributionListContactLanguageID"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.EmailDistributionListContactLanguageID = 10000000;
                    emailDistributionListContactLanguageService.Update(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContactLanguage", "EmailDistributionListContactLanguageEmailDistributionListContactLanguageID", emailDistributionListContactLanguage.EmailDistributionListContactLanguageID.ToString()), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "EmailDistributionListContact", ExistPlurial = "s", ExistFieldID = "EmailDistributionListContactID", AllowableTVtypeList = )]
                    // emailDistributionListContactLanguage.EmailDistributionListContactID   (Int32)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.EmailDistributionListContactID = 0;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactLanguageEmailDistributionListContactID", emailDistributionListContactLanguage.EmailDistributionListContactID.ToString()), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListContactLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.Language = (LanguageEnum)1000000;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageLanguage"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100, MinimumLength = 1)]
                    // emailDistributionListContactLanguage.Agency   (String)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("Agency");
                    Assert.AreEqual(false, emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage));
                    Assert.AreEqual(1, emailDistributionListContactLanguage.ValidationResults.Count());
                    Assert.IsTrue(emailDistributionListContactLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageAgency")).Any());
                    Assert.AreEqual(null, emailDistributionListContactLanguage.Agency);
                    Assert.AreEqual(count, emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().Count());

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.Agency = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "EmailDistributionListContactLanguageAgency", "1", "100"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListContactLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageTranslationStatus"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionListContactLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLanguageLastUpdateDate_UTC"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EmailDistributionListContactLanguageLastUpdateDate_UTC", "1980"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionListContactLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.LastUpdateContactTVItemID = 0;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailDistributionListContactLanguageLastUpdateContactTVItemID", emailDistributionListContactLanguage.LastUpdateContactTVItemID.ToString()), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContactLanguage = null;
                    emailDistributionListContactLanguage = GetFilledRandomEmailDistributionListContactLanguage("");
                    emailDistributionListContactLanguage.LastUpdateContactTVItemID = 1;
                    emailDistributionListContactLanguageService.Add(emailDistributionListContactLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "EmailDistributionListContactLanguageLastUpdateContactTVItemID", "Contact"), emailDistributionListContactLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated for GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID)
        [TestMethod]
        public void GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID__emailDistributionListContactLanguage_EmailDistributionListContactLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionListContactLanguage emailDistributionListContactLanguage = (from c in dbTestDB.EmailDistributionListContactLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListContactLanguage);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        emailDistributionListContactLanguageService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            EmailDistributionListContactLanguage emailDistributionListContactLanguageRet = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID);
                            CheckEmailDistributionListContactLanguageFields(new List<EmailDistributionListContactLanguage>() { emailDistributionListContactLanguageRet });
                            Assert.AreEqual(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageRet.EmailDistributionListContactLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            EmailDistributionListContactLanguageExtraA emailDistributionListContactLanguageExtraARet = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID);
                            CheckEmailDistributionListContactLanguageExtraAFields(new List<EmailDistributionListContactLanguageExtraA>() { emailDistributionListContactLanguageExtraARet });
                            Assert.AreEqual(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraARet.EmailDistributionListContactLanguageID);
                        }
                        else if (extra == "ExtraB")
                        {
                            EmailDistributionListContactLanguageExtraB emailDistributionListContactLanguageExtraBRet = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID);
                            CheckEmailDistributionListContactLanguageExtraBFields(new List<EmailDistributionListContactLanguageExtraB>() { emailDistributionListContactLanguageExtraBRet });
                            Assert.AreEqual(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraBRet.EmailDistributionListContactLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactLanguageWithEmailDistributionListContactLanguageID(emailDistributionListContactLanguage.EmailDistributionListContactLanguageID)

        #region Tests Generated for GetEmailDistributionListContactLanguageList()
        [TestMethod]
        public void GetEmailDistributionListContactLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionListContactLanguage emailDistributionListContactLanguage = (from c in dbTestDB.EmailDistributionListContactLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListContactLanguage);

                    List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageDirectQueryList = new List<EmailDistributionListContactLanguage>();
                    emailDistributionListContactLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListContactLanguages select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        emailDistributionListContactLanguageService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
                            emailDistributionListContactLanguageList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().ToList();
                            CheckEmailDistributionListContactLanguageFields(emailDistributionListContactLanguageList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactLanguageExtraA> emailDistributionListContactLanguageExtraAList = new List<EmailDistributionListContactLanguageExtraA>();
                            emailDistributionListContactLanguageExtraAList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAList().ToList();
                            CheckEmailDistributionListContactLanguageExtraAFields(emailDistributionListContactLanguageExtraAList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactLanguageExtraB> emailDistributionListContactLanguageExtraBList = new List<EmailDistributionListContactLanguageExtraB>();
                            emailDistributionListContactLanguageExtraBList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBList().ToList();
                            CheckEmailDistributionListContactLanguageExtraBFields(emailDistributionListContactLanguageExtraBList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactLanguageList()

        #region Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take
        [TestMethod]
        public void GetEmailDistributionListContactLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageDirectQueryList = new List<EmailDistributionListContactLanguage>();
                        emailDistributionListContactLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListContactLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
                            emailDistributionListContactLanguageList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().ToList();
                            CheckEmailDistributionListContactLanguageFields(emailDistributionListContactLanguageList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactLanguageExtraA> emailDistributionListContactLanguageExtraAList = new List<EmailDistributionListContactLanguageExtraA>();
                            emailDistributionListContactLanguageExtraAList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAList().ToList();
                            CheckEmailDistributionListContactLanguageExtraAFields(emailDistributionListContactLanguageExtraAList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraAList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactLanguageExtraB> emailDistributionListContactLanguageExtraBList = new List<EmailDistributionListContactLanguageExtraB>();
                            emailDistributionListContactLanguageExtraBList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBList().ToList();
                            CheckEmailDistributionListContactLanguageExtraBFields(emailDistributionListContactLanguageExtraBList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take

        #region Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take Order
        [TestMethod]
        public void GetEmailDistributionListContactLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "EmailDistributionListContactLanguageID", "");

                        List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageDirectQueryList = new List<EmailDistributionListContactLanguage>();
                        emailDistributionListContactLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListContactLanguages select c).Skip(1).Take(1).OrderBy(c => c.EmailDistributionListContactLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
                            emailDistributionListContactLanguageList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().ToList();
                            CheckEmailDistributionListContactLanguageFields(emailDistributionListContactLanguageList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactLanguageExtraA> emailDistributionListContactLanguageExtraAList = new List<EmailDistributionListContactLanguageExtraA>();
                            emailDistributionListContactLanguageExtraAList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAList().ToList();
                            CheckEmailDistributionListContactLanguageExtraAFields(emailDistributionListContactLanguageExtraAList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraAList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactLanguageExtraB> emailDistributionListContactLanguageExtraBList = new List<EmailDistributionListContactLanguageExtraB>();
                            emailDistributionListContactLanguageExtraBList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBList().ToList();
                            CheckEmailDistributionListContactLanguageExtraBFields(emailDistributionListContactLanguageExtraBList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take Order

        #region Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetEmailDistributionListContactLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), culture.TwoLetterISOLanguageName, 1, 1, "EmailDistributionListContactLanguageID,EmailDistributionListContactID", "");

                        List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageDirectQueryList = new List<EmailDistributionListContactLanguage>();
                        emailDistributionListContactLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListContactLanguages select c).Skip(1).Take(1).OrderBy(c => c.EmailDistributionListContactLanguageID).ThenBy(c => c.EmailDistributionListContactID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
                            emailDistributionListContactLanguageList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().ToList();
                            CheckEmailDistributionListContactLanguageFields(emailDistributionListContactLanguageList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactLanguageExtraA> emailDistributionListContactLanguageExtraAList = new List<EmailDistributionListContactLanguageExtraA>();
                            emailDistributionListContactLanguageExtraAList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAList().ToList();
                            CheckEmailDistributionListContactLanguageExtraAFields(emailDistributionListContactLanguageExtraAList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraAList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactLanguageExtraB> emailDistributionListContactLanguageExtraBList = new List<EmailDistributionListContactLanguageExtraB>();
                            emailDistributionListContactLanguageExtraBList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBList().ToList();
                            CheckEmailDistributionListContactLanguageExtraBFields(emailDistributionListContactLanguageExtraBList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take 2Order

        #region Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetEmailDistributionListContactLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListContactLanguageID", "EmailDistributionListContactLanguageID,EQ,4", "");

                        List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageDirectQueryList = new List<EmailDistributionListContactLanguage>();
                        emailDistributionListContactLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListContactLanguages select c).Where(c => c.EmailDistributionListContactLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListContactLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
                            emailDistributionListContactLanguageList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().ToList();
                            CheckEmailDistributionListContactLanguageFields(emailDistributionListContactLanguageList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactLanguageExtraA> emailDistributionListContactLanguageExtraAList = new List<EmailDistributionListContactLanguageExtraA>();
                            emailDistributionListContactLanguageExtraAList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAList().ToList();
                            CheckEmailDistributionListContactLanguageExtraAFields(emailDistributionListContactLanguageExtraAList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraAList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactLanguageExtraB> emailDistributionListContactLanguageExtraBList = new List<EmailDistributionListContactLanguageExtraB>();
                            emailDistributionListContactLanguageExtraBList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBList().ToList();
                            CheckEmailDistributionListContactLanguageExtraBFields(emailDistributionListContactLanguageExtraBList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take Order Where

        #region Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetEmailDistributionListContactLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListContactLanguageID", "EmailDistributionListContactLanguageID,GT,2|EmailDistributionListContactLanguageID,LT,5", "");

                        List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageDirectQueryList = new List<EmailDistributionListContactLanguage>();
                        emailDistributionListContactLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListContactLanguages select c).Where(c => c.EmailDistributionListContactLanguageID > 2 && c.EmailDistributionListContactLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListContactLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
                            emailDistributionListContactLanguageList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().ToList();
                            CheckEmailDistributionListContactLanguageFields(emailDistributionListContactLanguageList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactLanguageExtraA> emailDistributionListContactLanguageExtraAList = new List<EmailDistributionListContactLanguageExtraA>();
                            emailDistributionListContactLanguageExtraAList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAList().ToList();
                            CheckEmailDistributionListContactLanguageExtraAFields(emailDistributionListContactLanguageExtraAList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraAList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactLanguageExtraB> emailDistributionListContactLanguageExtraBList = new List<EmailDistributionListContactLanguageExtraB>();
                            emailDistributionListContactLanguageExtraBList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBList().ToList();
                            CheckEmailDistributionListContactLanguageExtraBFields(emailDistributionListContactLanguageExtraBList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetEmailDistributionListContactLanguageList() 2Where
        [TestMethod]
        public void GetEmailDistributionListContactLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactLanguageService emailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactLanguageService.Query = emailDistributionListContactLanguageService.FillQuery(typeof(EmailDistributionListContactLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "EmailDistributionListContactLanguageID,GT,2|EmailDistributionListContactLanguageID,LT,5", "");

                        List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageDirectQueryList = new List<EmailDistributionListContactLanguage>();
                        emailDistributionListContactLanguageDirectQueryList = (from c in dbTestDB.EmailDistributionListContactLanguages select c).Where(c => c.EmailDistributionListContactLanguageID > 2 && c.EmailDistributionListContactLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
                            emailDistributionListContactLanguageList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageList().ToList();
                            CheckEmailDistributionListContactLanguageFields(emailDistributionListContactLanguageList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactLanguageExtraA> emailDistributionListContactLanguageExtraAList = new List<EmailDistributionListContactLanguageExtraA>();
                            emailDistributionListContactLanguageExtraAList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraAList().ToList();
                            CheckEmailDistributionListContactLanguageExtraAFields(emailDistributionListContactLanguageExtraAList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraAList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactLanguageExtraB> emailDistributionListContactLanguageExtraBList = new List<EmailDistributionListContactLanguageExtraB>();
                            emailDistributionListContactLanguageExtraBList = emailDistributionListContactLanguageService.GetEmailDistributionListContactLanguageExtraBList().ToList();
                            CheckEmailDistributionListContactLanguageExtraBFields(emailDistributionListContactLanguageExtraBList);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList[0].EmailDistributionListContactLanguageID, emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactLanguageID);
                            Assert.AreEqual(emailDistributionListContactLanguageDirectQueryList.Count, emailDistributionListContactLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactLanguageList() 2Where

        #region Functions private
        private void CheckEmailDistributionListContactLanguageFields(List<EmailDistributionListContactLanguage> emailDistributionListContactLanguageList)
        {
            Assert.IsNotNull(emailDistributionListContactLanguageList[0].EmailDistributionListContactLanguageID);
            Assert.IsNotNull(emailDistributionListContactLanguageList[0].EmailDistributionListContactID);
            Assert.IsNotNull(emailDistributionListContactLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageList[0].Agency));
            Assert.IsNotNull(emailDistributionListContactLanguageList[0].TranslationStatus);
            Assert.IsNotNull(emailDistributionListContactLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListContactLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListContactLanguageList[0].HasErrors);
        }
        private void CheckEmailDistributionListContactLanguageExtraAFields(List<EmailDistributionListContactLanguageExtraA> emailDistributionListContactLanguageExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraAList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraAList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraAList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraAList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraAList[0].TranslationStatusText));
            }
            Assert.IsNotNull(emailDistributionListContactLanguageExtraAList[0].EmailDistributionListContactLanguageID);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraAList[0].EmailDistributionListContactID);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraAList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraAList[0].Agency));
            Assert.IsNotNull(emailDistributionListContactLanguageExtraAList[0].TranslationStatus);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraAList[0].HasErrors);
        }
        private void CheckEmailDistributionListContactLanguageExtraBFields(List<EmailDistributionListContactLanguageExtraB> emailDistributionListContactLanguageExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactLanguageReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraBList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraBList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraBList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraBList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraBList[0].TranslationStatusText));
            }
            Assert.IsNotNull(emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactLanguageID);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraBList[0].EmailDistributionListContactID);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraBList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactLanguageExtraBList[0].Agency));
            Assert.IsNotNull(emailDistributionListContactLanguageExtraBList[0].TranslationStatus);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListContactLanguageExtraBList[0].HasErrors);
        }
        private EmailDistributionListContactLanguage GetFilledRandomEmailDistributionListContactLanguage(string OmitPropName)
        {
            EmailDistributionListContactLanguage emailDistributionListContactLanguage = new EmailDistributionListContactLanguage();

            if (OmitPropName != "EmailDistributionListContactID") emailDistributionListContactLanguage.EmailDistributionListContactID = 1;
            if (OmitPropName != "Language") emailDistributionListContactLanguage.Language = LanguageRequest;
            if (OmitPropName != "Agency") emailDistributionListContactLanguage.Agency = GetRandomString("", 6);
            if (OmitPropName != "TranslationStatus") emailDistributionListContactLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListContactLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListContactLanguage.LastUpdateContactTVItemID = 2;

            return emailDistributionListContactLanguage;
        }
        #endregion Functions private
    }
}
