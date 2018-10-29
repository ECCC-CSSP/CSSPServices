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
    public partial class EmailDistributionListContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private EmailDistributionListContactService emailDistributionListContactService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactServiceTest() : base()
        {
            //emailDistributionListContactService = new EmailDistributionListContactService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void EmailDistributionListContact_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    EmailDistributionListContact emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = emailDistributionListContactService.GetEmailDistributionListContactList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.EmailDistributionListContacts select c).Count());

                    emailDistributionListContactService.Add(emailDistributionListContact);
                    if (emailDistributionListContact.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailDistributionListContactService.GetEmailDistributionListContactList().Where(c => c == emailDistributionListContact).Any());
                    emailDistributionListContactService.Update(emailDistributionListContact);
                    if (emailDistributionListContact.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailDistributionListContactService.GetEmailDistributionListContactList().Count());
                    emailDistributionListContactService.Delete(emailDistributionListContact);
                    if (emailDistributionListContact.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailDistributionListContactService.GetEmailDistributionListContactList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // emailDistributionListContact.EmailDistributionListContactID   (Int32)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactID = 0;
                    emailDistributionListContactService.Update(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactEmailDistributionListContactID"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactID = 10000000;
                    emailDistributionListContactService.Update(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionListContact", "EmailDistributionListContactEmailDistributionListContactID", emailDistributionListContact.EmailDistributionListContactID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID", AllowableTVtypeList = )]
                    // emailDistributionListContact.EmailDistributionListID   (Int32)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListID = 0;
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListContactEmailDistributionListID", emailDistributionListContact.EmailDistributionListID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // emailDistributionListContact.IsCC   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // emailDistributionListContact.Name   (String)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("Name");
                    Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                    Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
                    Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactName")).Any());
                    Assert.AreEqual(null, emailDistributionListContact.Name);
                    Assert.AreEqual(count, emailDistributionListContactService.GetEmailDistributionListContactList().Count());

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.Name = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "EmailDistributionListContactName", "100"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListContactService.GetEmailDistributionListContactList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [DataType(DataType.EmailAddress)]
                    // [StringLength(200))]
                    // emailDistributionListContact.Email   (String)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("Email");
                    Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                    Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
                    Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactEmail")).Any());
                    Assert.AreEqual(null, emailDistributionListContact.Email);
                    Assert.AreEqual(count, emailDistributionListContactService.GetEmailDistributionListContactList().Count());

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.Email = GetRandomString("", 201);
                    Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "EmailDistributionListContactEmail", "200"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListContactService.GetEmailDistributionListContactList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // emailDistributionListContact.CMPRainfallSeasonal   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // emailDistributionListContact.CMPWastewater   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // emailDistributionListContact.EmergencyWeather   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // emailDistributionListContact.EmergencyWastewater   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // emailDistributionListContact.ReopeningAllTypes   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionListContact.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListContactLastUpdateDate_UTC"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EmailDistributionListContactLastUpdateDate_UTC", "1980"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionListContact.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateContactTVItemID = 0;
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailDistributionListContactLastUpdateContactTVItemID", emailDistributionListContact.LastUpdateContactTVItemID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateContactTVItemID = 1;
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "EmailDistributionListContactLastUpdateContactTVItemID", "Contact"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListContact.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListContact.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID)
        [TestMethod]
        public void GetEmailDistributionListContactWithEmailDistributionListContactID__emailDistributionListContact_EmailDistributionListContactID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionListContact emailDistributionListContact = (from c in dbTestDB.EmailDistributionListContacts select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListContact);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        emailDistributionListContactService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            EmailDistributionListContact emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID);
                            CheckEmailDistributionListContactFields(new List<EmailDistributionListContact>() { emailDistributionListContactRet });
                            Assert.AreEqual(emailDistributionListContact.EmailDistributionListContactID, emailDistributionListContactRet.EmailDistributionListContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            EmailDistributionListContactExtraA emailDistributionListContactExtraARet = emailDistributionListContactService.GetEmailDistributionListContactExtraAWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID);
                            CheckEmailDistributionListContactExtraAFields(new List<EmailDistributionListContactExtraA>() { emailDistributionListContactExtraARet });
                            Assert.AreEqual(emailDistributionListContact.EmailDistributionListContactID, emailDistributionListContactExtraARet.EmailDistributionListContactID);
                        }
                        else if (extra == "ExtraB")
                        {
                            EmailDistributionListContactExtraB emailDistributionListContactExtraBRet = emailDistributionListContactService.GetEmailDistributionListContactExtraBWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID);
                            CheckEmailDistributionListContactExtraBFields(new List<EmailDistributionListContactExtraB>() { emailDistributionListContactExtraBRet });
                            Assert.AreEqual(emailDistributionListContact.EmailDistributionListContactID, emailDistributionListContactExtraBRet.EmailDistributionListContactID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID)

        #region Tests Generated for GetEmailDistributionListContactList()
        [TestMethod]
        public void GetEmailDistributionListContactList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionListContact emailDistributionListContact = (from c in dbTestDB.EmailDistributionListContacts select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListContact);

                    List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                    emailDistributionListContactDirectQueryList = (from c in dbTestDB.EmailDistributionListContacts select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        emailDistributionListContactService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            CheckEmailDistributionListContactFields(emailDistributionListContactList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactExtraA> emailDistributionListContactExtraAList = new List<EmailDistributionListContactExtraA>();
                            emailDistributionListContactExtraAList = emailDistributionListContactService.GetEmailDistributionListContactExtraAList().ToList();
                            CheckEmailDistributionListContactExtraAFields(emailDistributionListContactExtraAList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactExtraB> emailDistributionListContactExtraBList = new List<EmailDistributionListContactExtraB>();
                            emailDistributionListContactExtraBList = emailDistributionListContactService.GetEmailDistributionListContactExtraBList().ToList();
                            CheckEmailDistributionListContactExtraBFields(emailDistributionListContactExtraBList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactList()

        #region Tests Generated for GetEmailDistributionListContactList() Skip Take
        [TestMethod]
        public void GetEmailDistributionListContactList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                        emailDistributionListContactDirectQueryList = (from c in dbTestDB.EmailDistributionListContacts select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            CheckEmailDistributionListContactFields(emailDistributionListContactList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactExtraA> emailDistributionListContactExtraAList = new List<EmailDistributionListContactExtraA>();
                            emailDistributionListContactExtraAList = emailDistributionListContactService.GetEmailDistributionListContactExtraAList().ToList();
                            CheckEmailDistributionListContactExtraAFields(emailDistributionListContactExtraAList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraAList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactExtraB> emailDistributionListContactExtraBList = new List<EmailDistributionListContactExtraB>();
                            emailDistributionListContactExtraBList = emailDistributionListContactService.GetEmailDistributionListContactExtraBList().ToList();
                            CheckEmailDistributionListContactExtraBFields(emailDistributionListContactExtraBList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraBList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactList() Skip Take

        #region Tests Generated for GetEmailDistributionListContactList() Skip Take Order
        [TestMethod]
        public void GetEmailDistributionListContactList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 1, 1,  "EmailDistributionListContactID", "");

                        List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                        emailDistributionListContactDirectQueryList = (from c in dbTestDB.EmailDistributionListContacts select c).Skip(1).Take(1).OrderBy(c => c.EmailDistributionListContactID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            CheckEmailDistributionListContactFields(emailDistributionListContactList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactExtraA> emailDistributionListContactExtraAList = new List<EmailDistributionListContactExtraA>();
                            emailDistributionListContactExtraAList = emailDistributionListContactService.GetEmailDistributionListContactExtraAList().ToList();
                            CheckEmailDistributionListContactExtraAFields(emailDistributionListContactExtraAList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraAList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactExtraB> emailDistributionListContactExtraBList = new List<EmailDistributionListContactExtraB>();
                            emailDistributionListContactExtraBList = emailDistributionListContactService.GetEmailDistributionListContactExtraBList().ToList();
                            CheckEmailDistributionListContactExtraBFields(emailDistributionListContactExtraBList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraBList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactList() Skip Take Order

        #region Tests Generated for GetEmailDistributionListContactList() Skip Take 2Order
        [TestMethod]
        public void GetEmailDistributionListContactList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 1, 1, "EmailDistributionListContactID,EmailDistributionListID", "");

                        List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                        emailDistributionListContactDirectQueryList = (from c in dbTestDB.EmailDistributionListContacts select c).Skip(1).Take(1).OrderBy(c => c.EmailDistributionListContactID).ThenBy(c => c.EmailDistributionListID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            CheckEmailDistributionListContactFields(emailDistributionListContactList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactExtraA> emailDistributionListContactExtraAList = new List<EmailDistributionListContactExtraA>();
                            emailDistributionListContactExtraAList = emailDistributionListContactService.GetEmailDistributionListContactExtraAList().ToList();
                            CheckEmailDistributionListContactExtraAFields(emailDistributionListContactExtraAList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraAList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactExtraB> emailDistributionListContactExtraBList = new List<EmailDistributionListContactExtraB>();
                            emailDistributionListContactExtraBList = emailDistributionListContactService.GetEmailDistributionListContactExtraBList().ToList();
                            CheckEmailDistributionListContactExtraBFields(emailDistributionListContactExtraBList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraBList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactList() Skip Take 2Order

        #region Tests Generated for GetEmailDistributionListContactList() Skip Take Order Where
        [TestMethod]
        public void GetEmailDistributionListContactList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListContactID", "EmailDistributionListContactID,EQ,4", "");

                        List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                        emailDistributionListContactDirectQueryList = (from c in dbTestDB.EmailDistributionListContacts select c).Where(c => c.EmailDistributionListContactID == 4).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListContactID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            CheckEmailDistributionListContactFields(emailDistributionListContactList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactExtraA> emailDistributionListContactExtraAList = new List<EmailDistributionListContactExtraA>();
                            emailDistributionListContactExtraAList = emailDistributionListContactService.GetEmailDistributionListContactExtraAList().ToList();
                            CheckEmailDistributionListContactExtraAFields(emailDistributionListContactExtraAList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraAList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactExtraB> emailDistributionListContactExtraBList = new List<EmailDistributionListContactExtraB>();
                            emailDistributionListContactExtraBList = emailDistributionListContactService.GetEmailDistributionListContactExtraBList().ToList();
                            CheckEmailDistributionListContactExtraBFields(emailDistributionListContactExtraBList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraBList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactList() Skip Take Order Where

        #region Tests Generated for GetEmailDistributionListContactList() Skip Take Order 2Where
        [TestMethod]
        public void GetEmailDistributionListContactList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListContactID", "EmailDistributionListContactID,GT,2|EmailDistributionListContactID,LT,5", "");

                        List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                        emailDistributionListContactDirectQueryList = (from c in dbTestDB.EmailDistributionListContacts select c).Where(c => c.EmailDistributionListContactID > 2 && c.EmailDistributionListContactID < 5).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListContactID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            CheckEmailDistributionListContactFields(emailDistributionListContactList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactExtraA> emailDistributionListContactExtraAList = new List<EmailDistributionListContactExtraA>();
                            emailDistributionListContactExtraAList = emailDistributionListContactService.GetEmailDistributionListContactExtraAList().ToList();
                            CheckEmailDistributionListContactExtraAFields(emailDistributionListContactExtraAList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraAList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactExtraB> emailDistributionListContactExtraBList = new List<EmailDistributionListContactExtraB>();
                            emailDistributionListContactExtraBList = emailDistributionListContactService.GetEmailDistributionListContactExtraBList().ToList();
                            CheckEmailDistributionListContactExtraBFields(emailDistributionListContactExtraBList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraBList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactList() Skip Take Order 2Where

        #region Tests Generated for GetEmailDistributionListContactList() 2Where
        [TestMethod]
        public void GetEmailDistributionListContactList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 0, 10000, "", "EmailDistributionListContactID,GT,2|EmailDistributionListContactID,LT,5", "");

                        List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                        emailDistributionListContactDirectQueryList = (from c in dbTestDB.EmailDistributionListContacts select c).Where(c => c.EmailDistributionListContactID > 2 && c.EmailDistributionListContactID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            CheckEmailDistributionListContactFields(emailDistributionListContactList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<EmailDistributionListContactExtraA> emailDistributionListContactExtraAList = new List<EmailDistributionListContactExtraA>();
                            emailDistributionListContactExtraAList = emailDistributionListContactService.GetEmailDistributionListContactExtraAList().ToList();
                            CheckEmailDistributionListContactExtraAFields(emailDistributionListContactExtraAList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraAList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<EmailDistributionListContactExtraB> emailDistributionListContactExtraBList = new List<EmailDistributionListContactExtraB>();
                            emailDistributionListContactExtraBList = emailDistributionListContactService.GetEmailDistributionListContactExtraBList().ToList();
                            CheckEmailDistributionListContactExtraBFields(emailDistributionListContactExtraBList);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactExtraBList[0].EmailDistributionListContactID);
                            Assert.AreEqual(emailDistributionListContactDirectQueryList.Count, emailDistributionListContactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactList() 2Where

        #region Functions private
        private void CheckEmailDistributionListContactFields(List<EmailDistributionListContact> emailDistributionListContactList)
        {
            Assert.IsNotNull(emailDistributionListContactList[0].EmailDistributionListContactID);
            Assert.IsNotNull(emailDistributionListContactList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListContactList[0].IsCC);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactList[0].Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactList[0].Email));
            Assert.IsNotNull(emailDistributionListContactList[0].CMPRainfallSeasonal);
            Assert.IsNotNull(emailDistributionListContactList[0].CMPWastewater);
            Assert.IsNotNull(emailDistributionListContactList[0].EmergencyWeather);
            Assert.IsNotNull(emailDistributionListContactList[0].EmergencyWastewater);
            Assert.IsNotNull(emailDistributionListContactList[0].ReopeningAllTypes);
            Assert.IsNotNull(emailDistributionListContactList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListContactList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListContactList[0].HasErrors);
        }
        private void CheckEmailDistributionListContactExtraAFields(List<EmailDistributionListContactExtraA> emailDistributionListContactExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactExtraAList[0].LastUpdateContactText));
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].EmailDistributionListContactID);
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].IsCC);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactExtraAList[0].Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactExtraAList[0].Email));
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].CMPRainfallSeasonal);
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].CMPWastewater);
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].EmergencyWeather);
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].EmergencyWastewater);
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].ReopeningAllTypes);
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListContactExtraAList[0].HasErrors);
        }
        private void CheckEmailDistributionListContactExtraBFields(List<EmailDistributionListContactExtraB> emailDistributionListContactExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(emailDistributionListContactExtraBList[0].EmailDistributionListContactReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactExtraBList[0].EmailDistributionListContactReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactExtraBList[0].LastUpdateContactText));
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].EmailDistributionListContactID);
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].IsCC);
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactExtraBList[0].Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactExtraBList[0].Email));
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].CMPRainfallSeasonal);
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].CMPWastewater);
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].EmergencyWeather);
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].EmergencyWastewater);
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].ReopeningAllTypes);
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListContactExtraBList[0].HasErrors);
        }
        private EmailDistributionListContact GetFilledRandomEmailDistributionListContact(string OmitPropName)
        {
            EmailDistributionListContact emailDistributionListContact = new EmailDistributionListContact();

            if (OmitPropName != "EmailDistributionListID") emailDistributionListContact.EmailDistributionListID = 1;
            if (OmitPropName != "IsCC") emailDistributionListContact.IsCC = true;
            if (OmitPropName != "Name") emailDistributionListContact.Name = GetRandomString("", 5);
            if (OmitPropName != "Email") emailDistributionListContact.Email = GetRandomEmail();
            if (OmitPropName != "CMPRainfallSeasonal") emailDistributionListContact.CMPRainfallSeasonal = true;
            if (OmitPropName != "CMPWastewater") emailDistributionListContact.CMPWastewater = true;
            if (OmitPropName != "EmergencyWeather") emailDistributionListContact.EmergencyWeather = true;
            if (OmitPropName != "EmergencyWastewater") emailDistributionListContact.EmergencyWastewater = true;
            if (OmitPropName != "ReopeningAllTypes") emailDistributionListContact.ReopeningAllTypes = true;
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListContact.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListContact.LastUpdateContactTVItemID = 2;

            return emailDistributionListContact;
        }
        #endregion Functions private
    }
}
