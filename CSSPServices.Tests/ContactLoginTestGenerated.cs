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
            //Error: property [PasswordHash] and type [ContactLogin] is  not implemented
            //Error: property [PasswordSalt] and type [ContactLogin] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") contactLogin.LastUpdateDate_UTC = GetRandomDateTime();
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

            contactLogin = GetFilledRandomContactLogin("");
            contactLogin.ContactLoginID = 0;
            contactLoginService.Update(contactLogin);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginContactLoginID), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "Contact", Plurial = "s", FieldID = "ContactID", TVType = TVTypeEnum.Error)]
            // [Range(1, -1)]
            // contactLogin.ContactID   (Int32)
            // -----------------------------------

            // ContactID will automatically be initialized at 0 --> not null


            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");
            // ContactID has Min [1] and Max [empty]. At Min should return true and no errors
            contactLogin.ContactID = 1;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(1, contactLogin.ContactID);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactLogin.ContactID = 2;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(2, contactLogin.ContactID);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactLogin.ContactID = 0;
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactLoginContactID, "1")).Any());
            Assert.AreEqual(0, contactLogin.ContactID);
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

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
            // [Range(1, -1)]
            // contactLogin.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            contactLogin.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(1, contactLogin.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactLogin.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(2, contactLogin.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(count, contactLoginService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactLogin.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactLoginLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, contactLogin.LastUpdateContactTVItemID);
            Assert.AreEqual(count, contactLoginService.GetRead().Count());

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
