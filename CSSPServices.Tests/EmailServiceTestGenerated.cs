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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Email GetFilledRandomEmail(string OmitPropName)
        {
            Email email = new Email();

            if (OmitPropName != "EmailTVItemID") email.EmailTVItemID = 50;
            if (OmitPropName != "EmailAddress") email.EmailAddress = GetRandomEmail();
            if (OmitPropName != "EmailType") email.EmailType = (EmailTypeEnum)GetRandomEnumType(typeof(EmailTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") email.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") email.LastUpdateContactTVItemID = 2;

            return email;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Email_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailService emailService = new EmailService(new GetParam(), dbTestDB, ContactID);

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

                    count = emailService.GetRead().Count();

                    Assert.AreEqual(emailService.GetRead().Count(), emailService.GetEdit().Count());

                    emailService.Add(email);
                    if (email.HasErrors)
                    {
                        Assert.AreEqual("", email.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailService.GetRead().Where(c => c == email).Any());
                    emailService.Update(email);
                    if (email.HasErrors)
                    {
                        Assert.AreEqual("", email.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailService.GetRead().Count());
                    emailService.Delete(email);
                    if (email.HasErrors)
                    {
                        Assert.AreEqual("", email.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailEmailID), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailID = 10000000;
                    emailService.Update(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Email, CSSPModelsRes.EmailEmailID, email.EmailID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Email)]
                    // email.EmailTVItemID   (Int32)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailTVItemID = 0;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailEmailTVItemID, email.EmailTVItemID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailTVItemID = 1;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailEmailTVItemID, "Email"), email.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.IsTrue(email.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailEmailAddress)).Any());
                    Assert.AreEqual(null, email.EmailAddress);
                    Assert.AreEqual(count, emailService.GetRead().Count());

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailAddress = GetRandomString("", 256);
                    Assert.AreEqual(false, emailService.Add(email));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailEmailAddress, "255"), email.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // email.EmailType   (EmailTypeEnum)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailType = (EmailTypeEnum)1000000;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailEmailType), email.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // email.EmailWeb   (EmailWeb)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailWeb = null;
                    Assert.IsNull(email.EmailWeb);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailWeb = new EmailWeb();
                    Assert.IsNotNull(email.EmailWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // email.EmailReport   (EmailReport)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailReport = null;
                    Assert.IsNull(email.EmailReport);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailReport = new EmailReport();
                    Assert.IsNotNull(email.EmailReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // email.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateDate_UTC = new DateTime();
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailLastUpdateDate_UTC), email.ValidationResults.FirstOrDefault().ErrorMessage);
                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailLastUpdateDate_UTC, "1980"), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // email.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateContactTVItemID = 0;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailLastUpdateContactTVItemID, email.LastUpdateContactTVItemID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateContactTVItemID = 1;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailLastUpdateContactTVItemID, "Contact"), email.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailService emailService = new EmailService(new GetParam(), dbTestDB, ContactID);
                    Email email = (from c in emailService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(email);

                    Email emailRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailRet = emailService.GetEmailWithEmailID(email.EmailID);
                            Assert.IsNull(emailRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailRet = emailService.GetEmailWithEmailID(email.EmailID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailRet = emailService.GetEmailWithEmailID(email.EmailID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailRet = emailService.GetEmailWithEmailID(email.EmailID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Email fields
                        Assert.IsNotNull(emailRet.EmailID);
                        Assert.IsNotNull(emailRet.EmailTVItemID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailAddress));
                        Assert.IsNotNull(emailRet.EmailType);
                        Assert.IsNotNull(emailRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(emailRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // EmailWeb and EmailReport fields should be null here
                            Assert.IsNull(emailRet.EmailWeb);
                            Assert.IsNull(emailRet.EmailReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // EmailWeb fields should not be null and EmailReport fields should be null here
                            if (emailRet.EmailWeb.EmailTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailWeb.EmailTVText));
                            }
                            if (emailRet.EmailWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailWeb.LastUpdateContactTVText));
                            }
                            if (emailRet.EmailWeb.EmailTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailWeb.EmailTypeText));
                            }
                            Assert.IsNull(emailRet.EmailReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // EmailWeb and EmailReport fields should NOT be null here
                            if (emailRet.EmailWeb.EmailTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailWeb.EmailTVText));
                            }
                            if (emailRet.EmailWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailWeb.LastUpdateContactTVText));
                            }
                            if (emailRet.EmailWeb.EmailTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailWeb.EmailTypeText));
                            }
                            if (emailRet.EmailReport.EmailReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailReport.EmailReportTest));
                            }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailService emailService = new EmailService(new GetParam(), dbTestDB, ContactID);
                    Email email = (from c in emailService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(email);

                    List<Email> emailList = new List<Email>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailList = emailService.GetEmailList().ToList();
                            Assert.AreEqual(0, emailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailList = emailService.GetEmailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailList = emailService.GetEmailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailList = emailService.GetEmailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Email fields
                        Assert.IsNotNull(emailList[0].EmailID);
                        Assert.IsNotNull(emailList[0].EmailTVItemID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(emailList[0].EmailAddress));
                        Assert.IsNotNull(emailList[0].EmailType);
                        Assert.IsNotNull(emailList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(emailList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // EmailWeb and EmailReport fields should be null here
                            Assert.IsNull(emailList[0].EmailWeb);
                            Assert.IsNull(emailList[0].EmailReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // EmailWeb fields should not be null and EmailReport fields should be null here
                            if (emailList[0].EmailWeb.EmailTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailList[0].EmailWeb.EmailTVText));
                            }
                            if (emailList[0].EmailWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailList[0].EmailWeb.LastUpdateContactTVText));
                            }
                            if (emailList[0].EmailWeb.EmailTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailList[0].EmailWeb.EmailTypeText));
                            }
                            Assert.IsNull(emailList[0].EmailReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // EmailWeb and EmailReport fields should NOT be null here
                            if (emailList[0].EmailWeb.EmailTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailList[0].EmailWeb.EmailTVText));
                            }
                            if (emailList[0].EmailWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailList[0].EmailWeb.LastUpdateContactTVText));
                            }
                            if (emailList[0].EmailWeb.EmailTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailList[0].EmailWeb.EmailTypeText));
                            }
                            if (emailList[0].EmailReport.EmailReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailList[0].EmailReport.EmailReportTest));
                            }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<Email> emailList = new List<Email>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(Email), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        EmailService emailService = new EmailService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailList = emailService.GetEmailList().ToList();
                            Assert.AreEqual(0, emailList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailList = emailService.GetEmailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailList = emailService.GetEmailList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailList = emailService.GetEmailList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, emailList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailList() Skip Take

    }
}
