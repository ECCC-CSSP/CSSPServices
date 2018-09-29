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
    public partial class EmailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private EmailService emailService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailServiceTest() : base()
        {
            //emailService = new EmailService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Email_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailService emailService = new EmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Email email = GetFilledRandomEmail("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = emailService.GetEmailList().Count();

                    Assert.AreEqual(emailService.GetEmailList().Count(), (from c in dbTestDB.Emails select c).Take(200).Count());

                    emailService.Add(email);
                    if (email.HasErrors)
                    {
                        Assert.AreEqual("", email.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailService.GetEmailList().Where(c => c == email).Any());
                    emailService.Update(email);
                    if (email.HasErrors)
                    {
                        Assert.AreEqual("", email.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailService.GetEmailList().Count());
                    emailService.Delete(email);
                    if (email.HasErrors)
                    {
                        Assert.AreEqual("", email.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailService.GetEmailList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // email.EmailID   (Int32)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailID = 0;
                    emailService.Update(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailEmailID"), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailID = 10000000;
                    emailService.Update(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Email", "EmailEmailID", email.EmailID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Email)]
                    // email.EmailTVItemID   (Int32)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailTVItemID = 0;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailEmailTVItemID", email.EmailTVItemID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailTVItemID = 1;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "EmailEmailTVItemID", "Email"), email.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [DataType(DataType.EmailAddress)]
                    // [StringLength(255))]
                    // email.EmailAddress   (String)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("EmailAddress");
                    Assert.AreEqual(false, emailService.Add(email));
                    Assert.AreEqual(1, email.ValidationResults.Count());
                    Assert.IsTrue(email.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "EmailEmailAddress")).Any());
                    Assert.AreEqual(null, email.EmailAddress);
                    Assert.AreEqual(count, emailService.GetEmailList().Count());

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailAddress = GetRandomString("", 256);
                    Assert.AreEqual(false, emailService.Add(email));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "EmailEmailAddress", "255"), email.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailService.GetEmailList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // email.EmailType   (EmailTypeEnum)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailType = (EmailTypeEnum)1000000;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailEmailType"), email.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // email.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateDate_UTC = new DateTime();
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailLastUpdateDate_UTC"), email.ValidationResults.FirstOrDefault().ErrorMessage);
                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EmailLastUpdateDate_UTC", "1980"), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // email.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateContactTVItemID = 0;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailLastUpdateContactTVItemID", email.LastUpdateContactTVItemID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateContactTVItemID = 1;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "EmailLastUpdateContactTVItemID", "Contact"), email.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // email.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // email.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetEmailWithEmailID(email.EmailID)
        [TestMethod]
        public void GetEmailWithEmailID__email_EmailID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailService emailService = new EmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Email email = (from c in dbTestDB.Emails select c).FirstOrDefault();
                    Assert.IsNotNull(email);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        emailService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            Email emailRet = emailService.GetEmailWithEmailID(email.EmailID);
                            CheckEmailFields(new List<Email>() { emailRet });
                            Assert.AreEqual(email.EmailID, emailRet.EmailID);
                        }
                        else if (detail == "A")
                        {
                            Email_A email_ARet = emailService.GetEmail_AWithEmailID(email.EmailID);
                            CheckEmail_AFields(new List<Email_A>() { email_ARet });
                            Assert.AreEqual(email.EmailID, email_ARet.EmailID);
                        }
                        else if (detail == "B")
                        {
                            Email_B email_BRet = emailService.GetEmail_BWithEmailID(email.EmailID);
                            CheckEmail_BFields(new List<Email_B>() { email_BRet });
                            Assert.AreEqual(email.EmailID, email_BRet.EmailID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailWithEmailID(email.EmailID)

        #region Tests Generated for GetEmailList()
        [TestMethod]
        public void GetEmailList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailService emailService = new EmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Email email = (from c in dbTestDB.Emails select c).FirstOrDefault();
                    Assert.IsNotNull(email);

                    List<Email> emailDirectQueryList = new List<Email>();
                    emailDirectQueryList = (from c in dbTestDB.Emails select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        emailService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Email> emailList = new List<Email>();
                            emailList = emailService.GetEmailList().ToList();
                            CheckEmailFields(emailList);
                        }
                        else if (detail == "A")
                        {
                            List<Email_A> email_AList = new List<Email_A>();
                            email_AList = emailService.GetEmail_AList().ToList();
                            CheckEmail_AFields(email_AList);
                            Assert.AreEqual(emailDirectQueryList.Count, email_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Email_B> email_BList = new List<Email_B>();
                            email_BList = emailService.GetEmail_BList().ToList();
                            CheckEmail_BFields(email_BList);
                            Assert.AreEqual(emailDirectQueryList.Count, email_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailList()

        #region Tests Generated for GetEmailList() Skip Take
        [TestMethod]
        public void GetEmailList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailService emailService = new EmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailService.Query = emailService.FillQuery(typeof(Email), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<Email> emailDirectQueryList = new List<Email>();
                        emailDirectQueryList = (from c in dbTestDB.Emails select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Email> emailList = new List<Email>();
                            emailList = emailService.GetEmailList().ToList();
                            CheckEmailFields(emailList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, emailList[0].EmailID);
                        }
                        else if (detail == "A")
                        {
                            List<Email_A> email_AList = new List<Email_A>();
                            email_AList = emailService.GetEmail_AList().ToList();
                            CheckEmail_AFields(email_AList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_AList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Email_B> email_BList = new List<Email_B>();
                            email_BList = emailService.GetEmail_BList().ToList();
                            CheckEmail_BFields(email_BList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_BList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailList() Skip Take

        #region Tests Generated for GetEmailList() Skip Take Order
        [TestMethod]
        public void GetEmailList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailService emailService = new EmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailService.Query = emailService.FillQuery(typeof(Email), culture.TwoLetterISOLanguageName, 1, 1,  "EmailID", "");

                        List<Email> emailDirectQueryList = new List<Email>();
                        emailDirectQueryList = (from c in dbTestDB.Emails select c).Skip(1).Take(1).OrderBy(c => c.EmailID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Email> emailList = new List<Email>();
                            emailList = emailService.GetEmailList().ToList();
                            CheckEmailFields(emailList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, emailList[0].EmailID);
                        }
                        else if (detail == "A")
                        {
                            List<Email_A> email_AList = new List<Email_A>();
                            email_AList = emailService.GetEmail_AList().ToList();
                            CheckEmail_AFields(email_AList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_AList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Email_B> email_BList = new List<Email_B>();
                            email_BList = emailService.GetEmail_BList().ToList();
                            CheckEmail_BFields(email_BList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_BList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailList() Skip Take Order

        #region Tests Generated for GetEmailList() Skip Take 2Order
        [TestMethod]
        public void GetEmailList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailService emailService = new EmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailService.Query = emailService.FillQuery(typeof(Email), culture.TwoLetterISOLanguageName, 1, 1, "EmailID,EmailTVItemID", "");

                        List<Email> emailDirectQueryList = new List<Email>();
                        emailDirectQueryList = (from c in dbTestDB.Emails select c).Skip(1).Take(1).OrderBy(c => c.EmailID).ThenBy(c => c.EmailTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Email> emailList = new List<Email>();
                            emailList = emailService.GetEmailList().ToList();
                            CheckEmailFields(emailList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, emailList[0].EmailID);
                        }
                        else if (detail == "A")
                        {
                            List<Email_A> email_AList = new List<Email_A>();
                            email_AList = emailService.GetEmail_AList().ToList();
                            CheckEmail_AFields(email_AList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_AList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Email_B> email_BList = new List<Email_B>();
                            email_BList = emailService.GetEmail_BList().ToList();
                            CheckEmail_BFields(email_BList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_BList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailList() Skip Take 2Order

        #region Tests Generated for GetEmailList() Skip Take Order Where
        [TestMethod]
        public void GetEmailList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailService emailService = new EmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailService.Query = emailService.FillQuery(typeof(Email), culture.TwoLetterISOLanguageName, 0, 1, "EmailID", "EmailID,EQ,4", "");

                        List<Email> emailDirectQueryList = new List<Email>();
                        emailDirectQueryList = (from c in dbTestDB.Emails select c).Where(c => c.EmailID == 4).Skip(0).Take(1).OrderBy(c => c.EmailID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Email> emailList = new List<Email>();
                            emailList = emailService.GetEmailList().ToList();
                            CheckEmailFields(emailList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, emailList[0].EmailID);
                        }
                        else if (detail == "A")
                        {
                            List<Email_A> email_AList = new List<Email_A>();
                            email_AList = emailService.GetEmail_AList().ToList();
                            CheckEmail_AFields(email_AList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_AList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Email_B> email_BList = new List<Email_B>();
                            email_BList = emailService.GetEmail_BList().ToList();
                            CheckEmail_BFields(email_BList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_BList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailList() Skip Take Order Where

        #region Tests Generated for GetEmailList() Skip Take Order 2Where
        [TestMethod]
        public void GetEmailList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailService emailService = new EmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailService.Query = emailService.FillQuery(typeof(Email), culture.TwoLetterISOLanguageName, 0, 1, "EmailID", "EmailID,GT,2|EmailID,LT,5", "");

                        List<Email> emailDirectQueryList = new List<Email>();
                        emailDirectQueryList = (from c in dbTestDB.Emails select c).Where(c => c.EmailID > 2 && c.EmailID < 5).Skip(0).Take(1).OrderBy(c => c.EmailID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Email> emailList = new List<Email>();
                            emailList = emailService.GetEmailList().ToList();
                            CheckEmailFields(emailList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, emailList[0].EmailID);
                        }
                        else if (detail == "A")
                        {
                            List<Email_A> email_AList = new List<Email_A>();
                            email_AList = emailService.GetEmail_AList().ToList();
                            CheckEmail_AFields(email_AList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_AList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Email_B> email_BList = new List<Email_B>();
                            email_BList = emailService.GetEmail_BList().ToList();
                            CheckEmail_BFields(email_BList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_BList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailList() Skip Take Order 2Where

        #region Tests Generated for GetEmailList() 2Where
        [TestMethod]
        public void GetEmailList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailService emailService = new EmailService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailService.Query = emailService.FillQuery(typeof(Email), culture.TwoLetterISOLanguageName, 0, 10000, "", "EmailID,GT,2|EmailID,LT,5", "");

                        List<Email> emailDirectQueryList = new List<Email>();
                        emailDirectQueryList = (from c in dbTestDB.Emails select c).Where(c => c.EmailID > 2 && c.EmailID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Email> emailList = new List<Email>();
                            emailList = emailService.GetEmailList().ToList();
                            CheckEmailFields(emailList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, emailList[0].EmailID);
                        }
                        else if (detail == "A")
                        {
                            List<Email_A> email_AList = new List<Email_A>();
                            email_AList = emailService.GetEmail_AList().ToList();
                            CheckEmail_AFields(email_AList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_AList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Email_B> email_BList = new List<Email_B>();
                            email_BList = emailService.GetEmail_BList().ToList();
                            CheckEmail_BFields(email_BList);
                            Assert.AreEqual(emailDirectQueryList[0].EmailID, email_BList[0].EmailID);
                            Assert.AreEqual(emailDirectQueryList.Count, email_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailList() 2Where

        #region Functions private
        private void CheckEmailFields(List<Email> emailList)
        {
            Assert.IsNotNull(emailList[0].EmailID);
            Assert.IsNotNull(emailList[0].EmailTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailList[0].EmailAddress));
            Assert.IsNotNull(emailList[0].EmailType);
            Assert.IsNotNull(emailList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailList[0].HasErrors);
        }
        private void CheckEmail_AFields(List<Email_A> email_AList)
        {
            Assert.IsNotNull(email_AList[0].EmailTVItemLanguage);
            Assert.IsNotNull(email_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(email_AList[0].EmailTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(email_AList[0].EmailTypeText));
            }
            Assert.IsNotNull(email_AList[0].EmailID);
            Assert.IsNotNull(email_AList[0].EmailTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(email_AList[0].EmailAddress));
            Assert.IsNotNull(email_AList[0].EmailType);
            Assert.IsNotNull(email_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(email_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(email_AList[0].HasErrors);
        }
        private void CheckEmail_BFields(List<Email_B> email_BList)
        {
            if (!string.IsNullOrWhiteSpace(email_BList[0].EmailReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(email_BList[0].EmailReportTest));
            }
            Assert.IsNotNull(email_BList[0].EmailTVItemLanguage);
            Assert.IsNotNull(email_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(email_BList[0].EmailTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(email_BList[0].EmailTypeText));
            }
            Assert.IsNotNull(email_BList[0].EmailID);
            Assert.IsNotNull(email_BList[0].EmailTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(email_BList[0].EmailAddress));
            Assert.IsNotNull(email_BList[0].EmailType);
            Assert.IsNotNull(email_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(email_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(email_BList[0].HasErrors);
        }
        private Email GetFilledRandomEmail(string OmitPropName)
        {
            Email email = new Email();

            if (OmitPropName != "EmailTVItemID") email.EmailTVItemID = 53;
            if (OmitPropName != "EmailAddress") email.EmailAddress = GetRandomEmail();
            if (OmitPropName != "EmailType") email.EmailType = (EmailTypeEnum)GetRandomEnumType(typeof(EmailTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") email.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") email.LastUpdateContactTVItemID = 2;

            return email;
        }
        #endregion Functions private
    }
}
