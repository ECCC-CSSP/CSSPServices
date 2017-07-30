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
    public partial class ContactTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ContactService contactService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactTest() : base()
        {
            contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Contact GetFilledRandomContact(string OmitPropName)
        {
            Contact contact = new Contact();

            if (OmitPropName != "Id") contact.Id = GetRandomString("", 5);
            if (OmitPropName != "ContactTVItemID") contact.ContactTVItemID = 2;
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
            if (OmitPropName != "LastUpdateDate_UTC") contact.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contact.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "ParentTVItemID") contact.ParentTVItemID = GetRandomInt(1, 11);

            return contact;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Contact_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Contact contact = GetFilledRandomContact("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = contactService.GetRead().Count();

            contactService.Add(contact, ContactService.AddContactType.LoggedIn);
            if (contact.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", contact.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, contactService.GetRead().Where(c => c == contact).Any());
            contactService.Update(contact);
            if (contact.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", contact.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, contactService.GetRead().Count());
            contactService.Delete(contact);
            if (contact.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", contact.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // contact.ContactID   (Int32)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactID = 0;
            contactService.Update(contact);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactContactID), contact.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(128))]
            // contact.Id   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("Id");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.LoggedIn));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactId)).Any());
            Assert.AreEqual(null, contact.Id);
            Assert.AreEqual(count, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");
            contact.Id = GetRandomString("", 129);
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactId, "128"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // contact.ContactTVItemID   (Int32)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactTVItemID = 0;
            contactService.Add(contact, ContactService.AddContactType.LoggedIn);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactContactTVItemID, contact.ContactTVItemID.ToString()), contact.ValidationResults.FirstOrDefault().ErrorMessage);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactTVItemID = 1;
            contactService.Add(contact, ContactService.AddContactType.LoggedIn);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactContactTVItemID, "Contact"), contact.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [DataType(DataType.EmailAddress)]
            // [StringLength(255, MinimumLength = 6)]
            // contact.LoginEmail   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("LoginEmail");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.LoggedIn));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLoginEmail)).Any());
            Assert.AreEqual(null, contact.LoginEmail);
            Assert.AreEqual(count, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LoginEmail = GetRandomString("", 5);
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginEmail, "6", "255"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, contactService.GetRead().Count());
            contact = null;
            contact = GetFilledRandomContact("");
            contact.LoginEmail = GetRandomString("", 256);
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactLoginEmail, "6", "255"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // contact.FirstName   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("FirstName");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.LoggedIn));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactFirstName)).Any());
            Assert.AreEqual(null, contact.FirstName);
            Assert.AreEqual(count, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");
            contact.FirstName = GetRandomString("", 101);
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactFirstName, "100"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // contact.LastName   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("LastName");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.LoggedIn));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactLastName)).Any());
            Assert.AreEqual(null, contact.LastName);
            Assert.AreEqual(count, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastName = GetRandomString("", 101);
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactLastName, "100"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(50))]
            // contact.Initial   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.Initial = GetRandomString("", 51);
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactInitial, "50"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // contact.WebName   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("WebName");
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.LoggedIn));
            Assert.AreEqual(1, contact.ValidationResults.Count());
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactWebName)).Any());
            Assert.AreEqual(null, contact.WebName);
            Assert.AreEqual(count, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");
            contact.WebName = GetRandomString("", 101);
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactWebName, "100"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // contact.ContactTitle   (ContactTitleEnum)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ContactTitle = (ContactTitleEnum)1000000;
            contactService.Add(contact, ContactService.AddContactType.LoggedIn);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactContactTitle), contact.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // contact.IsAdmin   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // contact.EmailValidated   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // contact.Disabled   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // contact.IsNew   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [StringLength(200))]
            // contact.SamplingPlanner_ProvincesTVItemID   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.SamplingPlanner_ProvincesTVItemID = GetRandomString("", 201);
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactSamplingPlanner_ProvincesTVItemID, "200"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // contact.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // contact.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateContactTVItemID = 0;
            contactService.Add(contact, ContactService.AddContactType.LoggedIn);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactLastUpdateContactTVItemID, contact.LastUpdateContactTVItemID.ToString()), contact.ValidationResults.FirstOrDefault().ErrorMessage);

            contact = null;
            contact = GetFilledRandomContact("");
            contact.LastUpdateContactTVItemID = 1;
            contactService.Add(contact, ContactService.AddContactType.LoggedIn);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactLastUpdateContactTVItemID, "Contact"), contact.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // contact.ContactLogins   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // contact.ContactPreferences   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // contact.ContactShortcuts   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // contact.ContactTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // [Range(1, -1)]
            // contact.ParentTVItemID   (Int32)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            contact.ParentTVItemID = 0;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactParentTVItemID, "1"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // contact.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
