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

            if (OmitPropName != "EmailTVItemID") email.EmailTVItemID = 29;
            if (OmitPropName != "EmailAddress") email.EmailAddress = GetRandomEmail();
            if (OmitPropName != "EmailType") email.EmailType = (EmailTypeEnum)GetRandomEnumType(typeof(EmailTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") email.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") email.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "EmailTVText") email.EmailTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") email.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "EmailTypeText") email.EmailTypeText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") email.HasErrors = true;

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
                    EmailService emailService = new EmailService(LanguageRequest, dbTestDB, ContactID);

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
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.EmailEmailID), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailID = 10000000;
                    emailService.Update(email);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Email, ModelsRes.EmailEmailID, email.EmailID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Email)]
                    // email.EmailTVItemID   (Int32)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailTVItemID = 0;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailEmailTVItemID, email.EmailTVItemID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailTVItemID = 1;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.EmailEmailTVItemID, "Email"), email.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.IsTrue(email.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailEmailAddress)).Any());
                    Assert.AreEqual(null, email.EmailAddress);
                    Assert.AreEqual(count, emailService.GetRead().Count());

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailAddress = GetRandomString("", 256);
                    Assert.AreEqual(false, emailService.Add(email));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailEmailAddress, "255"), email.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.EmailEmailType), email.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // email.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // email.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateContactTVItemID = 0;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailLastUpdateContactTVItemID, email.LastUpdateContactTVItemID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateContactTVItemID = 1;
                    emailService.Add(email);
                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.EmailLastUpdateContactTVItemID, "Contact"), email.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "EmailTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // email.EmailTVText   (String)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, emailService.Add(email));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailEmailTVText, "200"), email.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // email.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, emailService.Add(email));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailLastUpdateContactTVText, "200"), email.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // email.EmailTypeText   (String)
                    // -----------------------------------

                    email = null;
                    email = GetFilledRandomEmail("");
                    email.EmailTypeText = GetRandomString("", 101);
                    Assert.AreEqual(false, emailService.Add(email));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailEmailTypeText, "100"), email.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // email.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // email.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void Email_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailService emailService = new EmailService(LanguageRequest, dbTestDB, ContactID);
                    Email email = (from c in emailService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(email);

                    Email emailRet = emailService.GetEmailWithEmailID(email.EmailID);
                    Assert.IsNotNull(emailRet.EmailID);
                    Assert.IsNotNull(emailRet.EmailTVItemID);
                    Assert.IsNotNull(emailRet.EmailAddress);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailAddress));
                    Assert.IsNotNull(emailRet.EmailType);
                    Assert.IsNotNull(emailRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(emailRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(emailRet.EmailTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailTVText));
                    Assert.IsNotNull(emailRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.LastUpdateContactTVText));
                    Assert.IsNotNull(emailRet.EmailTypeText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailRet.EmailTypeText));
                    Assert.IsNotNull(emailRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
