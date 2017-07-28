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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class ContactLoginTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ContactLoginService contactLoginService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactLoginTest() : base()
        {
            contactLoginService = new ContactLoginService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "Password") contactLogin.Password = GetRandomString("", 11);
            if (OmitPropName != "ConfirmPassword") contactLogin.ConfirmPassword = GetRandomString("", 11);

            return contactLogin;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContactLogin_Testing()
        {

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
            // [CSSPExist(TypeName = "Contact", Plurial = "s", FieldID = "ContactID", TVType = TVTypeEnum.Error)]
            // contactLogin.ContactID   (Int32)
            // -----------------------------------

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");
            contactLogin.ContactID = 0;
            contactLoginService.Add(contactLogin);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ContactLoginContactID, contactLogin.ContactID.ToString()), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);

            // ContactID will automatically be initialized at 0 --> not null


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
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");
            // LoginEmail has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string contactLoginLoginEmailMin = GetRandomEmail();
            contactLogin.LoginEmail = contactLoginLoginEmailMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginLoginEmailMin, contactLogin.LoginEmail);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // LoginEmail has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            contactLoginLoginEmailMin = GetRandomEmail();
            contactLogin.LoginEmail = contactLoginLoginEmailMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginLoginEmailMin, contactLogin.LoginEmail);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
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

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // contactLogin.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");
            contactLogin.LastUpdateContactTVItemID = 0;
            contactLoginService.Add(contactLogin);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactLoginLastUpdateContactTVItemID, contactLogin.LastUpdateContactTVItemID.ToString()), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // contactLogin.Contact   (Contact)
            // -----------------------------------


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
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");

            // Password has MinLength [6] and MaxLength [100]. At Min should return true and no errors
            string contactLoginPasswordMin = GetRandomString("", 6);
            contactLogin.Password = contactLoginPasswordMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginPasswordMin, contactLogin.Password);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Min + 1 should return true and no errors
            contactLoginPasswordMin = GetRandomString("", 7);
            contactLogin.Password = contactLoginPasswordMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginPasswordMin, contactLogin.Password);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Min - 1 should return false with one error
            contactLoginPasswordMin = GetRandomString("", 5);
            contactLogin.Password = contactLoginPasswordMin;
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginPassword, "6", "100")).Any());
            Assert.AreEqual(contactLoginPasswordMin, contactLogin.Password);
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Max should return true and no errors
            contactLoginPasswordMin = GetRandomString("", 100);
            contactLogin.Password = contactLoginPasswordMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginPasswordMin, contactLogin.Password);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Max - 1 should return true and no errors
            contactLoginPasswordMin = GetRandomString("", 99);
            contactLogin.Password = contactLoginPasswordMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginPasswordMin, contactLogin.Password);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Max + 1 should return false with one error
            contactLoginPasswordMin = GetRandomString("", 101);
            contactLogin.Password = contactLoginPasswordMin;
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginPassword, "6", "100")).Any());
            Assert.AreEqual(contactLoginPasswordMin, contactLogin.Password);
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
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Min should return true and no errors
            string contactLoginConfirmPasswordMin = GetRandomString("", 6);
            contactLogin.ConfirmPassword = contactLoginConfirmPasswordMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginConfirmPasswordMin, contactLogin.ConfirmPassword);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Min + 1 should return true and no errors
            contactLoginConfirmPasswordMin = GetRandomString("", 7);
            contactLogin.ConfirmPassword = contactLoginConfirmPasswordMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginConfirmPasswordMin, contactLogin.ConfirmPassword);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Min - 1 should return false with one error
            contactLoginConfirmPasswordMin = GetRandomString("", 5);
            contactLogin.ConfirmPassword = contactLoginConfirmPasswordMin;
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginConfirmPassword, "6", "100")).Any());
            Assert.AreEqual(contactLoginConfirmPasswordMin, contactLogin.ConfirmPassword);
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Max should return true and no errors
            contactLoginConfirmPasswordMin = GetRandomString("", 100);
            contactLogin.ConfirmPassword = contactLoginConfirmPasswordMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginConfirmPasswordMin, contactLogin.ConfirmPassword);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Max - 1 should return true and no errors
            contactLoginConfirmPasswordMin = GetRandomString("", 99);
            contactLogin.ConfirmPassword = contactLoginConfirmPasswordMin;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(contactLoginConfirmPasswordMin, contactLogin.ConfirmPassword);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Max + 1 should return false with one error
            contactLoginConfirmPasswordMin = GetRandomString("", 101);
            contactLogin.ConfirmPassword = contactLoginConfirmPasswordMin;
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginConfirmPassword, "6", "100")).Any());
            Assert.AreEqual(contactLoginConfirmPasswordMin, contactLogin.ConfirmPassword);
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // contactLogin.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
