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
        private int ContactLoginID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ContactLoginTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactLogin GetFilledRandomContactLogin(string OmitPropName)
        {
            ContactLoginID += 1;

            ContactLogin contactLogin = new ContactLogin();

            if (OmitPropName != "ContactLoginID") contactLogin.ContactLoginID = ContactLoginID;
            if (OmitPropName != "ContactID") contactLogin.ContactID = GetRandomInt(1, 11);
            if (OmitPropName != "LoginEmail") contactLogin.LoginEmail = GetRandomEmail();
            //Error: Type not implemented [PasswordHash]
            //Error: Type not implemented [PasswordSalt]
            if (OmitPropName != "LastUpdateDate_UTC") contactLogin.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") contactLogin.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Password") contactLogin.Password = GetRandomString("", 5);
            if (OmitPropName != "ConfirmPassword") contactLogin.ConfirmPassword = GetRandomString("", 5);

            return contactLogin;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContactLogin_Testing()
        {
            SetupTestHelper(culture);
            ContactLoginService contactLoginService = new ContactLoginService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            ContactLogin contactLogin = GetFilledRandomContactLogin("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(true, contactLoginService.GetRead().Where(c => c == contactLogin).Any());
            contactLogin.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, contactLoginService.Update(contactLogin));
            Assert.AreEqual(1, contactLoginService.GetRead().Count());
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // ContactID will automatically be initialized at 0 --> not null

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("LoginEmail");
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.AreEqual(1, contactLogin.ValidationResults.Count());
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginLoginEmail)).Any());
            Assert.AreEqual(null, contactLogin.LoginEmail);
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            //Error: Type not implemented [PasswordHash]

            //Error: Type not implemented [PasswordSalt]

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("LastUpdateDate_UTC");
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.AreEqual(1, contactLogin.ValidationResults.Count());
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginLastUpdateDate_UTC)).Any());
            Assert.IsTrue(contactLogin.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Contact]

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("Password");
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.AreEqual(1, contactLogin.ValidationResults.Count());
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginPassword)).Any());
            Assert.AreEqual(null, contactLogin.Password);
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("ConfirmPassword");
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.AreEqual(1, contactLogin.ValidationResults.Count());
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginConfirmPassword)).Any());
            Assert.AreEqual(null, contactLogin.ConfirmPassword);
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ContactLoginID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactID] of type [Int32]
            //-----------------------------------

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");
            // ContactID has Min [1] and Max [empty]. At Min should return true and no errors
            contactLogin.ContactID = 1;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(1, contactLogin.ContactID);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(0, contactLoginService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactLogin.ContactID = 2;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(2, contactLogin.ContactID);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(0, contactLoginService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactLogin.ContactID = 0;
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactLoginContactID, "1")).Any());
            Assert.AreEqual(0, contactLogin.ContactID);
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            //-----------------------------------
            // doing property [LoginEmail] of type [String]
            //-----------------------------------

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");

            //-----------------------------------
            // doing property [PasswordHash] of type [Byte[]]
            //-----------------------------------

            //-----------------------------------
            // doing property [PasswordSalt] of type [Byte[]]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            contactLogin.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(1, contactLogin.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(0, contactLoginService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactLogin.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, contactLoginService.Add(contactLogin));
            Assert.AreEqual(0, contactLogin.ValidationResults.Count());
            Assert.AreEqual(2, contactLogin.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactLoginService.Delete(contactLogin));
            Assert.AreEqual(0, contactLoginService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactLogin.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, contactLoginService.Add(contactLogin));
            Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactLoginLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, contactLogin.LastUpdateContactTVItemID);
            Assert.AreEqual(0, contactLoginService.GetRead().Count());

            //-----------------------------------
            // doing property [Contact] of type [Contact]
            //-----------------------------------

            //-----------------------------------
            // doing property [Password] of type [String]
            //-----------------------------------

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");

            //-----------------------------------
            // doing property [ConfirmPassword] of type [String]
            //-----------------------------------

            contactLogin = null;
            contactLogin = GetFilledRandomContactLogin("");

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
