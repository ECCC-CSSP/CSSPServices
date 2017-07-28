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
            Assert.AreEqual(0, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");
            // Id has MinLength [empty] and MaxLength [128]. At Max should return true and no errors
            string contactIdMin = GetRandomString("", 128);
            contact.Id = contactIdMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactIdMin, contact.Id);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // Id has MinLength [empty] and MaxLength [128]. At Max - 1 should return true and no errors
            contactIdMin = GetRandomString("", 127);
            contact.Id = contactIdMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactIdMin, contact.Id);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // Id has MinLength [empty] and MaxLength [128]. At Max + 1 should return false with one error
            contactIdMin = GetRandomString("", 129);
            contact.Id = contactIdMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactId, "128")).Any());
            Assert.AreEqual(contactIdMin, contact.Id);
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

            // ContactTVItemID will automatically be initialized at 0 --> not null


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
            Assert.AreEqual(0, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");

            // LoginEmail has MinLength [6] and MaxLength [255]. At Min should return true and no errors
            string contactLoginEmailMin = GetRandomEmail();
            contact.LoginEmail = contactLoginEmailMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLoginEmailMin, contact.LoginEmail);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // LoginEmail has MinLength [6] and MaxLength [255]. At Min + 1 should return true and no errors
            contactLoginEmailMin = GetRandomEmail();
            contact.LoginEmail = contactLoginEmailMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLoginEmailMin, contact.LoginEmail);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // LoginEmail has MinLength [6] and MaxLength [255]. At Max should return true and no errors
            contactLoginEmailMin = GetRandomEmail();
            contact.LoginEmail = contactLoginEmailMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLoginEmailMin, contact.LoginEmail);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // LoginEmail has MinLength [6] and MaxLength [255]. At Max - 1 should return true and no errors
            contactLoginEmailMin = GetRandomEmail();
            contact.LoginEmail = contactLoginEmailMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLoginEmailMin, contact.LoginEmail);
            Assert.AreEqual(true, contactService.Delete(contact));
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
            Assert.AreEqual(0, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");
            // FirstName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string contactFirstNameMin = GetRandomString("", 100);
            contact.FirstName = contactFirstNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactFirstNameMin, contact.FirstName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // FirstName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            contactFirstNameMin = GetRandomString("", 99);
            contact.FirstName = contactFirstNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactFirstNameMin, contact.FirstName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // FirstName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            contactFirstNameMin = GetRandomString("", 101);
            contact.FirstName = contactFirstNameMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactFirstName, "100")).Any());
            Assert.AreEqual(contactFirstNameMin, contact.FirstName);
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
            Assert.AreEqual(0, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");
            // LastName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string contactLastNameMin = GetRandomString("", 100);
            contact.LastName = contactLastNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLastNameMin, contact.LastName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // LastName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            contactLastNameMin = GetRandomString("", 99);
            contact.LastName = contactLastNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactLastNameMin, contact.LastName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // LastName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            contactLastNameMin = GetRandomString("", 101);
            contact.LastName = contactLastNameMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactLastName, "100")).Any());
            Assert.AreEqual(contactLastNameMin, contact.LastName);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(50))]
            // contact.Initial   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            // Initial has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string contactInitialMin = GetRandomString("", 50);
            contact.Initial = contactInitialMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactInitialMin, contact.Initial);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // Initial has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            contactInitialMin = GetRandomString("", 49);
            contact.Initial = contactInitialMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactInitialMin, contact.Initial);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // Initial has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            contactInitialMin = GetRandomString("", 51);
            contact.Initial = contactInitialMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactInitial, "50")).Any());
            Assert.AreEqual(contactInitialMin, contact.Initial);
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
            Assert.AreEqual(0, contactService.GetRead().Count());

            contact = null;
            contact = GetFilledRandomContact("");
            // WebName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string contactWebNameMin = GetRandomString("", 100);
            contact.WebName = contactWebNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactWebNameMin, contact.WebName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // WebName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            contactWebNameMin = GetRandomString("", 99);
            contact.WebName = contactWebNameMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactWebNameMin, contact.WebName);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // WebName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            contactWebNameMin = GetRandomString("", 101);
            contact.WebName = contactWebNameMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactWebName, "100")).Any());
            Assert.AreEqual(contactWebNameMin, contact.WebName);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // contact.ContactTitle   (ContactTitleEnum)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // contact.IsAdmin   (Boolean)
            // -----------------------------------

            // IsAdmin will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // contact.EmailValidated   (Boolean)
            // -----------------------------------

            // EmailValidated will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // contact.Disabled   (Boolean)
            // -----------------------------------

            // Disabled will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // contact.IsNew   (Boolean)
            // -----------------------------------

            // IsNew will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is Nullable
            // [StringLength(200))]
            // contact.SamplingPlanner_ProvincesTVItemID   (String)
            // -----------------------------------

            contact = null;
            contact = GetFilledRandomContact("");
            // SamplingPlanner_ProvincesTVItemID has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string contactSamplingPlanner_ProvincesTVItemIDMin = GetRandomString("", 200);
            contact.SamplingPlanner_ProvincesTVItemID = contactSamplingPlanner_ProvincesTVItemIDMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactSamplingPlanner_ProvincesTVItemIDMin, contact.SamplingPlanner_ProvincesTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // SamplingPlanner_ProvincesTVItemID has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            contactSamplingPlanner_ProvincesTVItemIDMin = GetRandomString("", 199);
            contact.SamplingPlanner_ProvincesTVItemID = contactSamplingPlanner_ProvincesTVItemIDMin;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(contactSamplingPlanner_ProvincesTVItemIDMin, contact.SamplingPlanner_ProvincesTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());

            // SamplingPlanner_ProvincesTVItemID has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            contactSamplingPlanner_ProvincesTVItemIDMin = GetRandomString("", 201);
            contact.SamplingPlanner_ProvincesTVItemID = contactSamplingPlanner_ProvincesTVItemIDMin;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactSamplingPlanner_ProvincesTVItemID, "200")).Any());
            Assert.AreEqual(contactSamplingPlanner_ProvincesTVItemIDMin, contact.SamplingPlanner_ProvincesTVItemID);
            Assert.AreEqual(count, contactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // contact.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


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

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


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

            // ParentTVItemID will automatically be initialized at 0 --> not null

            contact = null;
            contact = GetFilledRandomContact("");
            // ParentTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            contact.ParentTVItemID = 1;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(1, contact.ParentTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());
            // ParentTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contact.ParentTVItemID = 2;
            Assert.AreEqual(true, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.AreEqual(0, contact.ValidationResults.Count());
            Assert.AreEqual(2, contact.ParentTVItemID);
            Assert.AreEqual(true, contactService.Delete(contact));
            Assert.AreEqual(count, contactService.GetRead().Count());
            // ParentTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contact.ParentTVItemID = 0;
            Assert.AreEqual(false, contactService.Add(contact, ContactService.AddContactType.First));
            Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactParentTVItemID, "1")).Any());
            Assert.AreEqual(0, contact.ParentTVItemID);
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
