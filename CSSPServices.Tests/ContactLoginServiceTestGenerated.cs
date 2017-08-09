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
    public partial class ContactLoginServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactLoginService contactLoginService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactLoginServiceTest() : base()
        {
            //contactLoginService = new ContactLoginService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactLogin GetFilledRandomContactLogin(string OmitPropName)
        {
            ContactLogin contactLogin = new ContactLogin();

            if (OmitPropName != "ContactID") contactLogin.ContactID = 1;
            if (OmitPropName != "LoginEmail") contactLogin.LoginEmail = GetRandomEmail();
            ContactService contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);

            Register register = new Register();
            register.Password = GetRandomPassword(); // the only thing needed for CreatePasswordHashAndSalt

            byte[] passwordHash;
            byte[] passwordSalt;
            contactService.CreatePasswordHashAndSalt(register, out passwordHash, out passwordSalt);

            if (OmitPropName != "PasswordHash") contactLogin.PasswordHash = passwordHash;
            if (OmitPropName != "PasswordSalt") contactLogin.PasswordSalt = passwordSalt;
            if (OmitPropName != "LastUpdateDate_UTC") contactLogin.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactLogin.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") contactLogin.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "Password") contactLogin.Password = GetRandomString("", 11);
            if (OmitPropName != "ConfirmPassword") contactLogin.ConfirmPassword = GetRandomString("", 11);

            return contactLogin;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ContactLogin_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                ContactLoginService contactLoginService = new ContactLoginService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                ContactLogin contactLogin = GetFilledRandomContactLogin("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = contactLoginService.GetRead().Count();

                contactLoginService.Add(contactLogin);
                if (contactLogin.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, contactLoginService.GetRead().Where(c => c == contactLogin).Any());
                contactLoginService.Update(contactLogin);
                if (contactLogin.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, contactLoginService.GetRead().Count());
                contactLoginService.Delete(contactLogin);
                if (contactLogin.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, contactLoginService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // contactLogin.ContactLoginID   (Int32)
                // -----------------------------------

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.ContactLoginID = 0;
                contactLoginService.Update(contactLogin);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginContactLoginID), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = Error)]
                // contactLogin.ContactID   (Int32)
                // -----------------------------------

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.ContactID = 0;
                contactLoginService.Add(contactLogin);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ContactLoginContactID, contactLogin.ContactID.ToString()), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [DataType(DataType.EmailAddress)]
                // [StringLength(200))]
                // contactLogin.LoginEmail   (String)
                // -----------------------------------

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("LoginEmail");
                Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                Assert.AreEqual(1, contactLogin.ValidationResults.Count());
                Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginLoginEmail)).Any());
                Assert.AreEqual(null, contactLogin.LoginEmail);
                Assert.AreEqual(count, contactLoginService.GetRead().Count());

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.LoginEmail = GetRandomString("", 201);
                Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactLoginLoginEmail, "200"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactLoginService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // contactLogin.PasswordHash   (Byte[])
                // -----------------------------------

                //Error: Type not implemented [PasswordHash]


                // -----------------------------------
                // Is NOT Nullable
                // contactLogin.PasswordSalt   (Byte[])
                // -----------------------------------

                //Error: Type not implemented [PasswordSalt]


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // contactLogin.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // contactLogin.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.LastUpdateContactTVItemID = 0;
                contactLoginService.Add(contactLogin);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactLoginLastUpdateContactTVItemID, contactLogin.LastUpdateContactTVItemID.ToString()), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.LastUpdateContactTVItemID = 1;
                contactLoginService.Add(contactLogin);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactLoginLastUpdateContactTVItemID, "Contact"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // contactLogin.LastUpdateContactTVText   (String)
                // -----------------------------------

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactLoginLastUpdateContactTVText, "200"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactLoginService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // [StringLength(100, MinimumLength = 6)]
                // contactLogin.Password   (String)
                // -----------------------------------

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("Password");
                Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                Assert.AreEqual(1, contactLogin.ValidationResults.Count());
                Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginPassword)).Any());
                Assert.AreEqual(null, contactLogin.Password);
                Assert.AreEqual(count, contactLoginService.GetRead().Count());

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.Password = GetRandomString("", 5);
                Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginPassword, "6", "100"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactLoginService.GetRead().Count());
                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.Password = GetRandomString("", 101);
                Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginPassword, "6", "100"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactLoginService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // [StringLength(100, MinimumLength = 6)]
                // contactLogin.ConfirmPassword   (String)
                // -----------------------------------

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("ConfirmPassword");
                Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                Assert.AreEqual(1, contactLogin.ValidationResults.Count());
                Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginConfirmPassword)).Any());
                Assert.AreEqual(null, contactLogin.ConfirmPassword);
                Assert.AreEqual(count, contactLoginService.GetRead().Count());

                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.ConfirmPassword = GetRandomString("", 5);
                Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginConfirmPassword, "6", "100"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactLoginService.GetRead().Count());
                contactLogin = null;
                contactLogin = GetFilledRandomContactLogin("");
                contactLogin.ConfirmPassword = GetRandomString("", 101);
                Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginConfirmPassword, "6", "100"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactLoginService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // contactLogin.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ContactLogin_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                ContactLoginService contactLoginService = new ContactLoginService(LanguageRequest, dbTestDB, ContactID);
                ContactLogin contactLogin = (from c in contactLoginService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(contactLogin);

                ContactLogin contactLoginRet = contactLoginService.GetContactLoginWithContactLoginID(contactLogin.ContactLoginID);
                Assert.IsNotNull(contactLoginRet.ContactLoginID);
                Assert.IsNotNull(contactLoginRet.ContactID);
                Assert.IsNotNull(contactLoginRet.LoginEmail);
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactLoginRet.LoginEmail));
                Assert.IsNotNull(contactLoginRet.PasswordHash);
                Assert.IsNotNull(contactLoginRet.PasswordSalt);
                Assert.IsNotNull(contactLoginRet.LastUpdateDate_UTC);
                Assert.IsNotNull(contactLoginRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(contactLoginRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactLoginRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}
