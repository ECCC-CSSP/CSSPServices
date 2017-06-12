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
    public partial class ContactTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int ContactID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ContactTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Contact GetFilledRandomContact(string OmitPropName)
        {
            ContactID += 1;

            Contact contact = new Contact();

            if (OmitPropName != "ContactID") contact.ContactID = ContactID;
            if (OmitPropName != "ContactTVItemID") contact.ContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "LoginEmail") contact.LoginEmail = GetRandomEmail();
            //Error: Type not implemented [PasswordHash]
            //Error: Type not implemented [PasswordSalt]
            if (OmitPropName != "Token") contact.Token = GetRandomString("", 5);
            if (OmitPropName != "RandomToken") contact.RandomToken = GetRandomString("", 5);
            if (OmitPropName != "FirstName") contact.FirstName = GetRandomString("", 5);
            if (OmitPropName != "LastName") contact.LastName = GetRandomString("", 5);
            if (OmitPropName != "Initial") contact.Initial = GetRandomString("", 5);
            if (OmitPropName != "WebName") contact.WebName = GetRandomString("", 5);
            if (OmitPropName != "ContactTitle") contact.ContactTitle = (ContactTitleEnum)GetRandomEnumType(typeof(ContactTitleEnum));
            if (OmitPropName != "IsAdmin") contact.IsAdmin = true;
            if (OmitPropName != "EmailValidated") contact.EmailValidated = true;
            if (OmitPropName != "Disabled") contact.Disabled = true;
            if (OmitPropName != "IsNew") contact.IsNew = true;
            if (OmitPropName != "SamplingPlanner_ProvincesTVItemID") contact.SamplingPlanner_ProvincesTVItemID = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") contact.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") contact.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Password") contact.Password = GetRandomString("", 6);
            if (OmitPropName != "ConfirmPassword") contact.ConfirmPassword = GetRandomString("", 6);
            if (OmitPropName != "ParentTVItemID") contact.ParentTVItemID = GetRandomInt(1, 11);

            return contact;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Contact_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            ContactService contactService = new ContactService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Contact contact = GetFilledRandomContact("");
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(true, contactService.GetRead().Where(c => c == contact).Any());
            contact.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, contactService.Update(contact));
            Assert.AreEqual(1, contactService.GetRead().Count());
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // ContactTVItemID will automatically be initialized at 0 --> not null

            contact = null;
            contact = GetFilledRandomContact("LoginEmail");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginEmail)).Any());
            Assert.AreEqual(null, contact.LoginEmail);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //Error: Type not implemented [PasswordHash]

            //Error: Type not implemented [PasswordSalt]

            contact = null;
            contact = GetFilledRandomContact("FirstName");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactFirstName)).Any());
            Assert.AreEqual(null, contact.FirstName);
            Assert.AreEqual(0, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("LastName");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLastName)).Any());
            Assert.AreEqual(null, contact.LastName);
            Assert.AreEqual(0, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("WebName");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactWebName)).Any());
            Assert.AreEqual(null, contact.WebName);
            Assert.AreEqual(0, contactService.GetRead().Count());

            // IsAdmin will automatically be initialized at false --> not null

            // EmailValidated will automatically be initialized at false --> not null

            // Disabled will automatically be initialized at false --> not null

            // IsNew will automatically be initialized at false --> not null

            contact = null;
            contact = GetFilledRandomContact("LastUpdateDate_UTC");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLastUpdateDate_UTC)).Any());
            Assert.IsTrue(contact.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, contactService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ContactID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactTVItemID] of type [int]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            // ContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            contact.ContactTVItemID = 1;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(1, contact.ContactTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contact.ContactTVItemID = 2;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(2, contact.ContactTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contact.ContactTVItemID = 0;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactContactTVItemID, "1")).Any());
            Assert.AreEqual(0, contact.ContactTVItemID);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [LoginEmail] of type [string]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            // LoginEmail has MinLength [empty] and MaxLength [255]. At Max should return true and no errors
            string contactLoginEmailMin = GetRandomEmail();
            contact.LoginEmail = contactLoginEmailMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLoginEmailMin, contact.LoginEmail);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // LoginEmail has MinLength [empty] and MaxLength [255]. At Max - 1 should return true and no errors
            contactLoginEmailMin = GetRandomEmail();
            contact.LoginEmail = contactLoginEmailMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLoginEmailMin, contact.LoginEmail);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [PasswordHash] of type [Byte[]]
            //-----------------------------------

            //-----------------------------------
            // doing property [PasswordSalt] of type [Byte[]]
            //-----------------------------------

            //-----------------------------------
            // doing property [Token] of type [string]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            // Token has MinLength [empty] and MaxLength [255]. At Max should return true and no errors
            string contactTokenMin = GetRandomString("", 255);
            contact.Token = contactTokenMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactTokenMin, contact.Token);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // Token has MinLength [empty] and MaxLength [255]. At Max - 1 should return true and no errors
            contactTokenMin = GetRandomString("", 254);
            contact.Token = contactTokenMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactTokenMin, contact.Token);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // Token has MinLength [empty] and MaxLength [255]. At Max + 1 should return false with one error
            contactTokenMin = GetRandomString("", 256);
            contact.Token = contactTokenMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactToken, "255")).Any());
            Assert.AreEqual(contactTokenMin, contact.Token);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [RandomToken] of type [string]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            // RandomToken has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string contactRandomTokenMin = GetRandomString("", 50);
            contact.RandomToken = contactRandomTokenMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactRandomTokenMin, contact.RandomToken);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // RandomToken has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            contactRandomTokenMin = GetRandomString("", 49);
            contact.RandomToken = contactRandomTokenMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactRandomTokenMin, contact.RandomToken);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // RandomToken has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            contactRandomTokenMin = GetRandomString("", 51);
            contact.RandomToken = contactRandomTokenMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactRandomToken, "50")).Any());
            Assert.AreEqual(contactRandomTokenMin, contact.RandomToken);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [FirstName] of type [string]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            // FirstName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string contactFirstNameMin = GetRandomString("", 100);
            contact.FirstName = contactFirstNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactFirstNameMin, contact.FirstName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // FirstName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            contactFirstNameMin = GetRandomString("", 99);
            contact.FirstName = contactFirstNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactFirstNameMin, contact.FirstName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // FirstName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            contactFirstNameMin = GetRandomString("", 101);
            contact.FirstName = contactFirstNameMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactFirstName, "100")).Any());
            Assert.AreEqual(contactFirstNameMin, contact.FirstName);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [LastName] of type [string]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            // LastName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string contactLastNameMin = GetRandomString("", 100);
            contact.LastName = contactLastNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLastNameMin, contact.LastName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // LastName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            contactLastNameMin = GetRandomString("", 99);
            contact.LastName = contactLastNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLastNameMin, contact.LastName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // LastName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            contactLastNameMin = GetRandomString("", 101);
            contact.LastName = contactLastNameMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactLastName, "100")).Any());
            Assert.AreEqual(contactLastNameMin, contact.LastName);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [Initial] of type [string]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            // Initial has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string contactInitialMin = GetRandomString("", 50);
            contact.Initial = contactInitialMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactInitialMin, contact.Initial);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // Initial has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            contactInitialMin = GetRandomString("", 49);
            contact.Initial = contactInitialMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactInitialMin, contact.Initial);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // Initial has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            contactInitialMin = GetRandomString("", 51);
            contact.Initial = contactInitialMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactInitial, "50")).Any());
            Assert.AreEqual(contactInitialMin, contact.Initial);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [WebName] of type [string]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            // WebName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string contactWebNameMin = GetRandomString("", 100);
            contact.WebName = contactWebNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactWebNameMin, contact.WebName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // WebName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            contactWebNameMin = GetRandomString("", 99);
            contact.WebName = contactWebNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactWebNameMin, contact.WebName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // WebName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            contactWebNameMin = GetRandomString("", 101);
            contact.WebName = contactWebNameMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactWebName, "100")).Any());
            Assert.AreEqual(contactWebNameMin, contact.WebName);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [ContactTitle] of type [ContactTitleEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsAdmin] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [EmailValidated] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [Disabled] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsNew] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanner_ProvincesTVItemID] of type [string]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            // SamplingPlanner_ProvincesTVItemID has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string contactSamplingPlanner_ProvincesTVItemIDMin = GetRandomString("", 200);
            contact.SamplingPlanner_ProvincesTVItemID = contactSamplingPlanner_ProvincesTVItemIDMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactSamplingPlanner_ProvincesTVItemIDMin, contact.SamplingPlanner_ProvincesTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // SamplingPlanner_ProvincesTVItemID has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            contactSamplingPlanner_ProvincesTVItemIDMin = GetRandomString("", 199);
            contact.SamplingPlanner_ProvincesTVItemID = contactSamplingPlanner_ProvincesTVItemIDMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactSamplingPlanner_ProvincesTVItemIDMin, contact.SamplingPlanner_ProvincesTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());

            // SamplingPlanner_ProvincesTVItemID has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            contactSamplingPlanner_ProvincesTVItemIDMin = GetRandomString("", 201);
            contact.SamplingPlanner_ProvincesTVItemID = contactSamplingPlanner_ProvincesTVItemIDMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactSamplingPlanner_ProvincesTVItemID, "200")).Any());
            Assert.AreEqual(contactSamplingPlanner_ProvincesTVItemIDMin, contact.SamplingPlanner_ProvincesTVItemID);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            contact.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(1, contact.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contact.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(2, contact.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contact.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, contact.LastUpdateContactTVItemID);
            Assert.AreEqual(0, contactService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
