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
            if (OmitPropName != "Id") contact.Id = GetRandomString("", 5);
            if (OmitPropName != "ContactTVItemID") contact.ContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "LoginEmail") contact.LoginEmail = GetRandomEmail();
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
            if (OmitPropName != "ParentTVItemID") contact.ParentTVItemID = GetRandomInt(1, 11);

            return contact;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Contact_Testing()
        {
            SetupTestHelper(culture);
            ContactService contactService = new ContactService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            Contact contact = GetFilledRandomContact("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

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

            contact = null;
            contact = GetFilledRandomContact("Id");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactId)).Any());
            Assert.AreEqual(null, contact.Id);
            Assert.AreEqual(0, contactService.GetRead().Count());

            // ContactTVItemID will automatically be initialized at 0 --> not null

            contact = null;
            contact = GetFilledRandomContact("LoginEmail");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginEmail)).Any());
            Assert.AreEqual(null, contact.LoginEmail);
            Assert.AreEqual(0, contactService.GetRead().Count());

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

            //Error: Type not implemented [ContactTitle]

            // IsAdmin will automatically be initialized at 0 --> not null

            // EmailValidated will automatically be initialized at 0 --> not null

            // Disabled will automatically be initialized at 0 --> not null

            // IsNew will automatically be initialized at 0 --> not null

            contact = null;
            contact = GetFilledRandomContact("LastUpdateDate_UTC");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLastUpdateDate_UTC)).Any());
            Assert.IsTrue(contact.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, contactService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [ContactLogins]

            //Error: Type not implemented [ContactPreferences]

            //Error: Type not implemented [ContactShortcuts]

            //Error: Type not implemented [ContactTVItem]

            // ParentTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ContactID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [Id] of type [String]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            //-----------------------------------
            // doing property [ContactTVItemID] of type [Int32]
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
            // doing property [LoginEmail] of type [String]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            //-----------------------------------
            // doing property [FirstName] of type [String]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            //-----------------------------------
            // doing property [LastName] of type [String]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            //-----------------------------------
            // doing property [Initial] of type [String]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            //-----------------------------------
            // doing property [WebName] of type [String]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            //-----------------------------------
            // doing property [ContactTitle] of type [ContactTitleEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsAdmin] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [EmailValidated] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [Disabled] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsNew] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [SamplingPlanner_ProvincesTVItemID] of type [String]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [ContactLogins] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactPreferences] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactShortcuts] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ParentTVItemID] of type [Int32]
            //-----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            // ParentTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            contact.ParentTVItemID = 1;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(1, contact.ParentTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());
            // ParentTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contact.ParentTVItemID = 2;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(2, contact.ParentTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(0, contactService.GetRead().Count());
            // ParentTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contact.ParentTVItemID = 0;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactParentTVItemID, "1")).Any());
            Assert.AreEqual(0, contact.ParentTVItemID);
            Assert.AreEqual(0, contactService.GetRead().Count());

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
