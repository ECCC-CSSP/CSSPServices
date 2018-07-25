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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = emailDistributionListContactService.GetRead().Count();

                    Assert.AreEqual(emailDistributionListContactService.GetRead().Count(), emailDistributionListContactService.GetEdit().Count());

                    emailDistributionListContactService.Add(emailDistributionListContact);
                    if (emailDistributionListContact.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailDistributionListContactService.GetRead().Where(c => c == emailDistributionListContact).Any());
                    emailDistributionListContactService.Update(emailDistributionListContact);
                    if (emailDistributionListContact.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailDistributionListContactService.GetRead().Count());
                    emailDistributionListContactService.Delete(emailDistributionListContact);
                    if (emailDistributionListContact.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactEmailDistributionListContactID), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactID = 10000000;
                    emailDistributionListContactService.Update(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListContact, CSSPModelsRes.EmailDistributionListContactEmailDistributionListContactID, emailDistributionListContact.EmailDistributionListContactID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID", AllowableTVtypeList = Error)]
                    // emailDistributionListContact.EmailDistributionListID   (Int32)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListID = 0;
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionList, CSSPModelsRes.EmailDistributionListContactEmailDistributionListID, emailDistributionListContact.EmailDistributionListID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactName)).Any());
                    Assert.AreEqual(null, emailDistributionListContact.Name);
                    Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.Name = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailDistributionListContactName, "100"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

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
                    Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactEmail)).Any());
                    Assert.AreEqual(null, emailDistributionListContact.Email);
                    Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.Email = GetRandomString("", 201);
                    Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailDistributionListContactEmail, "200"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

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
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionListContact.EmailDistributionListContactWeb   (EmailDistributionListContactWeb)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactWeb = null;
                    Assert.IsNull(emailDistributionListContact.EmailDistributionListContactWeb);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactWeb = new EmailDistributionListContactWeb();
                    Assert.IsNotNull(emailDistributionListContact.EmailDistributionListContactWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionListContact.EmailDistributionListContactReport   (EmailDistributionListContactReport)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactReport = null;
                    Assert.IsNull(emailDistributionListContact.EmailDistributionListContactReport);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactReport = new EmailDistributionListContactReport();
                    Assert.IsNotNull(emailDistributionListContact.EmailDistributionListContactReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionListContact.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLastUpdateDate_UTC), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailDistributionListContactLastUpdateDate_UTC, "1980"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionListContact.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateContactTVItemID = 0;
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, emailDistributionListContact.LastUpdateContactTVItemID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateContactTVItemID = 1;
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, "Contact"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionListContact emailDistributionListContact = (from c in emailDistributionListContactService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListContact);

                    EmailDistributionListContact emailDistributionListContactRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListContactService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID);
                            Assert.IsNull(emailDistributionListContactRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListContactFields(new List<EmailDistributionListContact>() { emailDistributionListContactRet }, entityQueryDetailType);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionListContact emailDistributionListContact = (from c in emailDistributionListContactService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListContact);

                    List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListContactService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            Assert.AreEqual(0, emailDistributionListContactList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListContactFields(emailDistributionListContactList, entityQueryDetailType);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                    List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListContactDirectQueryList = emailDistributionListContactService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            Assert.AreEqual(0, emailDistributionListContactList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListContactFields(emailDistributionListContactList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        Assert.AreEqual(1, emailDistributionListContactList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                    List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 1, 1,  "EmailDistributionListContactID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListContactDirectQueryList = emailDistributionListContactService.GetRead().Skip(1).Take(1).OrderBy(c => c.EmailDistributionListContactID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            Assert.AreEqual(0, emailDistributionListContactList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListContactFields(emailDistributionListContactList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        Assert.AreEqual(1, emailDistributionListContactList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                    List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 1, 1, "EmailDistributionListContactID,EmailDistributionListID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListContactDirectQueryList = emailDistributionListContactService.GetRead().Skip(1).Take(1).OrderBy(c => c.EmailDistributionListContactID).ThenBy(c => c.EmailDistributionListID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            Assert.AreEqual(0, emailDistributionListContactList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListContactFields(emailDistributionListContactList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        Assert.AreEqual(1, emailDistributionListContactList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                    List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListContactID", "EmailDistributionListContactID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListContactDirectQueryList = emailDistributionListContactService.GetRead().Where(c => c.EmailDistributionListContactID == 4).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListContactID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            Assert.AreEqual(0, emailDistributionListContactList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListContactFields(emailDistributionListContactList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        Assert.AreEqual(1, emailDistributionListContactList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                    List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListContactID", "EmailDistributionListContactID,GT,2|EmailDistributionListContactID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListContactDirectQueryList = emailDistributionListContactService.GetRead().Where(c => c.EmailDistributionListContactID > 2 && c.EmailDistributionListContactID < 5).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListContactID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            Assert.AreEqual(0, emailDistributionListContactList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListContactFields(emailDistributionListContactList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        Assert.AreEqual(1, emailDistributionListContactList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<EmailDistributionListContact> emailDistributionListContactList = new List<EmailDistributionListContact>();
                    List<EmailDistributionListContact> emailDistributionListContactDirectQueryList = new List<EmailDistributionListContact>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListContactService.Query = emailDistributionListContactService.FillQuery(typeof(EmailDistributionListContact), culture.TwoLetterISOLanguageName, 0, 10000, "", "EmailDistributionListContactID,GT,2|EmailDistributionListContactID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        emailDistributionListContactDirectQueryList = emailDistributionListContactService.GetRead().Where(c => c.EmailDistributionListContactID > 2 && c.EmailDistributionListContactID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                            Assert.AreEqual(0, emailDistributionListContactList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactList = emailDistributionListContactService.GetEmailDistributionListContactList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckEmailDistributionListContactFields(emailDistributionListContactList, entityQueryDetailType);
                        Assert.AreEqual(emailDistributionListContactDirectQueryList[0].EmailDistributionListContactID, emailDistributionListContactList[0].EmailDistributionListContactID);
                        Assert.AreEqual(2, emailDistributionListContactList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListContactList() 2Where

        #region Functions private
        private void CheckEmailDistributionListContactFields(List<EmailDistributionListContact> emailDistributionListContactList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // EmailDistributionListContact fields
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

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // EmailDistributionListContactWeb and EmailDistributionListContactReport fields should be null here
                Assert.IsNull(emailDistributionListContactList[0].EmailDistributionListContactWeb);
                Assert.IsNull(emailDistributionListContactList[0].EmailDistributionListContactReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // EmailDistributionListContactWeb fields should not be null and EmailDistributionListContactReport fields should be null here
                if (!string.IsNullOrWhiteSpace(emailDistributionListContactList[0].EmailDistributionListContactWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactList[0].EmailDistributionListContactWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(emailDistributionListContactList[0].EmailDistributionListContactReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // EmailDistributionListContactWeb and EmailDistributionListContactReport fields should NOT be null here
                if (emailDistributionListContactList[0].EmailDistributionListContactWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactList[0].EmailDistributionListContactWeb.LastUpdateContactTVText));
                }
                if (emailDistributionListContactList[0].EmailDistributionListContactReport.EmailDistributionListContactReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactList[0].EmailDistributionListContactReport.EmailDistributionListContactReportTest));
                }
            }
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
