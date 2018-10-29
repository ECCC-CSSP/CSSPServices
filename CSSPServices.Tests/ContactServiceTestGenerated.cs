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
    public partial class ContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactService contactService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactServiceTest() : base()
        {
            //contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Contact_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactService contactService = new ContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = contactService.GetContactList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.Contacts select c).Count());

                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    if (contact.HasErrors)
                    {
                        Assert.AreEqual("", contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, contactService.GetContactList().Where(c => c == contact).Any());
                    contactService.Update(contact);
                    if (contact.HasErrors)
                    {
                        Assert.AreEqual("", contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, contactService.GetContactList().Count());
                    contactService.Delete(contact);
                    if (contact.HasErrors)
                    {
                        Assert.AreEqual("", contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, contactService.GetContactList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ContactContactID"), contact.ValidationResults.FirstOrDefault().ErrorMessage);

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactID = 10000000;
                    contactService.Update(contact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactContactID", contact.ContactID.ToString()), contact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "AspNetUser", ExistPlurial = "s", ExistFieldID = "Id", AllowableTVtypeList = )]
                    // [StringLength(128))]
                    // contact.Id   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("Id");
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.LoggedIn));
                    Assert.AreEqual(2, contact.ValidationResults.Count());
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ContactId")).Any());
                    Assert.AreEqual(null, contact.Id);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.Id = GetRandomString("", 129);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactId", "128"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contact.ContactTVItemID   (Int32)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactTVItemID = 0;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactContactTVItemID", contact.ContactTVItemID.ToString()), contact.ValidationResults.FirstOrDefault().ErrorMessage);

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactTVItemID = 1;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ContactContactTVItemID", "Contact"), contact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [DataType(DataType.EmailAddress)]
                    // [StringLength(255, MinimumLength = 6)]
                    // contact.LoginEmail   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("LoginEmail");
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.LoggedIn));
                    Assert.AreEqual(1, contact.ValidationResults.Count());
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ContactLoginEmail")).Any());
                    Assert.AreEqual(null, contact.LoginEmail);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LoginEmail = GetRandomString("", 5);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "ContactLoginEmail", "6", "255"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetContactList().Count());
                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LoginEmail = GetRandomString("", 256);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "ContactLoginEmail", "6", "255"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // contact.FirstName   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("FirstName");
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.LoggedIn));
                    Assert.AreEqual(1, contact.ValidationResults.Count());
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ContactFirstName")).Any());
                    Assert.AreEqual(null, contact.FirstName);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.FirstName = GetRandomString("", 101);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactFirstName", "100"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // contact.LastName   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("LastName");
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.LoggedIn));
                    Assert.AreEqual(1, contact.ValidationResults.Count());
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ContactLastName")).Any());
                    Assert.AreEqual(null, contact.LastName);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastName = GetRandomString("", 101);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactLastName", "100"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(50))]
                    // contact.Initial   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.Initial = GetRandomString("", 51);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactInitial", "50"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // contact.WebName   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("WebName");
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.LoggedIn));
                    Assert.AreEqual(1, contact.ValidationResults.Count());
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ContactWebName")).Any());
                    Assert.AreEqual(null, contact.WebName);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.WebName = GetRandomString("", 101);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactWebName", "100"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // contact.ContactTitle   (ContactTitleEnum)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactTitle = (ContactTitleEnum)1000000;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ContactContactTitle"), contact.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactSamplingPlanner_ProvincesTVItemID", "200"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetContactList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contact.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastUpdateDate_UTC = new DateTime();
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ContactLastUpdateDate_UTC"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ContactLastUpdateDate_UTC", "1980"), contact.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contact.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastUpdateContactTVItemID = 0;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactLastUpdateContactTVItemID", contact.LastUpdateContactTVItemID.ToString()), contact.ValidationResults.FirstOrDefault().ErrorMessage);

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastUpdateContactTVItemID = 1;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ContactLastUpdateContactTVItemID", "Contact"), contact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contact.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contact.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetContactWithContactID(contact.ContactID)
        [TestMethod]
        public void GetContactWithContactID__contact_ContactID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactService contactService = new ContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Contact contact = (from c in dbTestDB.Contacts select c).FirstOrDefault();
                    Assert.IsNotNull(contact);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        contactService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            Contact contactRet = contactService.GetContactWithContactID(contact.ContactID);
                            CheckContactFields(new List<Contact>() { contactRet });
                            Assert.AreEqual(contact.ContactID, contactRet.ContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            ContactExtraA contactExtraARet = contactService.GetContactExtraAWithContactID(contact.ContactID);
                            CheckContactExtraAFields(new List<ContactExtraA>() { contactExtraARet });
                            Assert.AreEqual(contact.ContactID, contactExtraARet.ContactID);
                        }
                        else if (extra == "ExtraB")
                        {
                            ContactExtraB contactExtraBRet = contactService.GetContactExtraBWithContactID(contact.ContactID);
                            CheckContactExtraBFields(new List<ContactExtraB>() { contactExtraBRet });
                            Assert.AreEqual(contact.ContactID, contactExtraBRet.ContactID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactWithContactID(contact.ContactID)

        #region Tests Generated for GetContactList()
        [TestMethod]
        public void GetContactList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactService contactService = new ContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Contact contact = (from c in dbTestDB.Contacts select c).FirstOrDefault();
                    Assert.IsNotNull(contact);

                    List<Contact> contactDirectQueryList = new List<Contact>();
                    contactDirectQueryList = (from c in dbTestDB.Contacts select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        contactService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Contact> contactList = new List<Contact>();
                            contactList = contactService.GetContactList().ToList();
                            CheckContactFields(contactList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ContactExtraA> contactExtraAList = new List<ContactExtraA>();
                            contactExtraAList = contactService.GetContactExtraAList().ToList();
                            CheckContactExtraAFields(contactExtraAList);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ContactExtraB> contactExtraBList = new List<ContactExtraB>();
                            contactExtraBList = contactService.GetContactExtraBList().ToList();
                            CheckContactExtraBFields(contactExtraBList);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactList()

        #region Tests Generated for GetContactList() Skip Take
        [TestMethod]
        public void GetContactList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactService contactService = new ContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactService.Query = contactService.FillQuery(typeof(Contact), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<Contact> contactDirectQueryList = new List<Contact>();
                        contactDirectQueryList = (from c in dbTestDB.Contacts select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Contact> contactList = new List<Contact>();
                            contactList = contactService.GetContactList().ToList();
                            CheckContactFields(contactList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactList[0].ContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ContactExtraA> contactExtraAList = new List<ContactExtraA>();
                            contactExtraAList = contactService.GetContactExtraAList().ToList();
                            CheckContactExtraAFields(contactExtraAList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraAList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ContactExtraB> contactExtraBList = new List<ContactExtraB>();
                            contactExtraBList = contactService.GetContactExtraBList().ToList();
                            CheckContactExtraBFields(contactExtraBList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraBList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactList() Skip Take

        #region Tests Generated for GetContactList() Skip Take Order
        [TestMethod]
        public void GetContactList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactService contactService = new ContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactService.Query = contactService.FillQuery(typeof(Contact), culture.TwoLetterISOLanguageName, 1, 1,  "ContactID", "");

                        List<Contact> contactDirectQueryList = new List<Contact>();
                        contactDirectQueryList = (from c in dbTestDB.Contacts select c).Skip(1).Take(1).OrderBy(c => c.ContactID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Contact> contactList = new List<Contact>();
                            contactList = contactService.GetContactList().ToList();
                            CheckContactFields(contactList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactList[0].ContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ContactExtraA> contactExtraAList = new List<ContactExtraA>();
                            contactExtraAList = contactService.GetContactExtraAList().ToList();
                            CheckContactExtraAFields(contactExtraAList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraAList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ContactExtraB> contactExtraBList = new List<ContactExtraB>();
                            contactExtraBList = contactService.GetContactExtraBList().ToList();
                            CheckContactExtraBFields(contactExtraBList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraBList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactList() Skip Take Order

        #region Tests Generated for GetContactList() Skip Take 2Order
        [TestMethod]
        public void GetContactList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactService contactService = new ContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactService.Query = contactService.FillQuery(typeof(Contact), culture.TwoLetterISOLanguageName, 1, 1, "ContactID,Id", "");

                        List<Contact> contactDirectQueryList = new List<Contact>();
                        contactDirectQueryList = (from c in dbTestDB.Contacts select c).Skip(1).Take(1).OrderBy(c => c.ContactID).ThenBy(c => c.Id).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Contact> contactList = new List<Contact>();
                            contactList = contactService.GetContactList().ToList();
                            CheckContactFields(contactList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactList[0].ContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ContactExtraA> contactExtraAList = new List<ContactExtraA>();
                            contactExtraAList = contactService.GetContactExtraAList().ToList();
                            CheckContactExtraAFields(contactExtraAList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraAList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ContactExtraB> contactExtraBList = new List<ContactExtraB>();
                            contactExtraBList = contactService.GetContactExtraBList().ToList();
                            CheckContactExtraBFields(contactExtraBList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraBList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactList() Skip Take 2Order

        #region Tests Generated for GetContactList() Skip Take Order Where
        [TestMethod]
        public void GetContactList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactService contactService = new ContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactService.Query = contactService.FillQuery(typeof(Contact), culture.TwoLetterISOLanguageName, 0, 1, "ContactID", "ContactID,EQ,4", "");

                        List<Contact> contactDirectQueryList = new List<Contact>();
                        contactDirectQueryList = (from c in dbTestDB.Contacts select c).Where(c => c.ContactID == 4).Skip(0).Take(1).OrderBy(c => c.ContactID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Contact> contactList = new List<Contact>();
                            contactList = contactService.GetContactList().ToList();
                            CheckContactFields(contactList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactList[0].ContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ContactExtraA> contactExtraAList = new List<ContactExtraA>();
                            contactExtraAList = contactService.GetContactExtraAList().ToList();
                            CheckContactExtraAFields(contactExtraAList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraAList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ContactExtraB> contactExtraBList = new List<ContactExtraB>();
                            contactExtraBList = contactService.GetContactExtraBList().ToList();
                            CheckContactExtraBFields(contactExtraBList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraBList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactList() Skip Take Order Where

        #region Tests Generated for GetContactList() Skip Take Order 2Where
        [TestMethod]
        public void GetContactList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactService contactService = new ContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactService.Query = contactService.FillQuery(typeof(Contact), culture.TwoLetterISOLanguageName, 0, 1, "ContactID", "ContactID,GT,2|ContactID,LT,5", "");

                        List<Contact> contactDirectQueryList = new List<Contact>();
                        contactDirectQueryList = (from c in dbTestDB.Contacts select c).Where(c => c.ContactID > 2 && c.ContactID < 5).Skip(0).Take(1).OrderBy(c => c.ContactID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Contact> contactList = new List<Contact>();
                            contactList = contactService.GetContactList().ToList();
                            CheckContactFields(contactList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactList[0].ContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ContactExtraA> contactExtraAList = new List<ContactExtraA>();
                            contactExtraAList = contactService.GetContactExtraAList().ToList();
                            CheckContactExtraAFields(contactExtraAList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraAList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ContactExtraB> contactExtraBList = new List<ContactExtraB>();
                            contactExtraBList = contactService.GetContactExtraBList().ToList();
                            CheckContactExtraBFields(contactExtraBList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraBList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactList() Skip Take Order 2Where

        #region Tests Generated for GetContactList() 2Where
        [TestMethod]
        public void GetContactList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactService contactService = new ContactService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactService.Query = contactService.FillQuery(typeof(Contact), culture.TwoLetterISOLanguageName, 0, 10000, "", "ContactID,GT,2|ContactID,LT,5", "");

                        List<Contact> contactDirectQueryList = new List<Contact>();
                        contactDirectQueryList = (from c in dbTestDB.Contacts select c).Where(c => c.ContactID > 2 && c.ContactID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<Contact> contactList = new List<Contact>();
                            contactList = contactService.GetContactList().ToList();
                            CheckContactFields(contactList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactList[0].ContactID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ContactExtraA> contactExtraAList = new List<ContactExtraA>();
                            contactExtraAList = contactService.GetContactExtraAList().ToList();
                            CheckContactExtraAFields(contactExtraAList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraAList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ContactExtraB> contactExtraBList = new List<ContactExtraB>();
                            contactExtraBList = contactService.GetContactExtraBList().ToList();
                            CheckContactExtraBFields(contactExtraBList);
                            Assert.AreEqual(contactDirectQueryList[0].ContactID, contactExtraBList[0].ContactID);
                            Assert.AreEqual(contactDirectQueryList.Count, contactExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactList() 2Where

        #region Functions private
        private void CheckContactFields(List<Contact> contactList)
        {
            Assert.IsNotNull(contactList[0].ContactID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactList[0].Id));
            Assert.IsNotNull(contactList[0].ContactTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactList[0].LoginEmail));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactList[0].FirstName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactList[0].LastName));
            if (!string.IsNullOrWhiteSpace(contactList[0].Initial))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactList[0].Initial));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactList[0].WebName));
            if (contactList[0].ContactTitle != null)
            {
                Assert.IsNotNull(contactList[0].ContactTitle);
            }
            Assert.IsNotNull(contactList[0].IsAdmin);
            Assert.IsNotNull(contactList[0].EmailValidated);
            Assert.IsNotNull(contactList[0].Disabled);
            Assert.IsNotNull(contactList[0].IsNew);
            if (!string.IsNullOrWhiteSpace(contactList[0].SamplingPlanner_ProvincesTVItemID))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactList[0].SamplingPlanner_ProvincesTVItemID));
            }
            Assert.IsNotNull(contactList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(contactList[0].HasErrors);
        }
        private void CheckContactExtraAFields(List<ContactExtraA> contactExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].ContactName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(contactExtraAList[0].ContactTitleText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].ContactTitleText));
            }
            Assert.IsNotNull(contactExtraAList[0].ContactID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].Id));
            Assert.IsNotNull(contactExtraAList[0].ContactTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].LoginEmail));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].FirstName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].LastName));
            if (!string.IsNullOrWhiteSpace(contactExtraAList[0].Initial))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].Initial));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].WebName));
            if (contactExtraAList[0].ContactTitle != null)
            {
                Assert.IsNotNull(contactExtraAList[0].ContactTitle);
            }
            Assert.IsNotNull(contactExtraAList[0].IsAdmin);
            Assert.IsNotNull(contactExtraAList[0].EmailValidated);
            Assert.IsNotNull(contactExtraAList[0].Disabled);
            Assert.IsNotNull(contactExtraAList[0].IsNew);
            if (!string.IsNullOrWhiteSpace(contactExtraAList[0].SamplingPlanner_ProvincesTVItemID))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraAList[0].SamplingPlanner_ProvincesTVItemID));
            }
            Assert.IsNotNull(contactExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(contactExtraAList[0].HasErrors);
        }
        private void CheckContactExtraBFields(List<ContactExtraB> contactExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(contactExtraBList[0].ContactReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].ContactReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].ContactName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(contactExtraBList[0].ContactTitleText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].ContactTitleText));
            }
            Assert.IsNotNull(contactExtraBList[0].ContactID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].Id));
            Assert.IsNotNull(contactExtraBList[0].ContactTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].LoginEmail));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].FirstName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].LastName));
            if (!string.IsNullOrWhiteSpace(contactExtraBList[0].Initial))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].Initial));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].WebName));
            if (contactExtraBList[0].ContactTitle != null)
            {
                Assert.IsNotNull(contactExtraBList[0].ContactTitle);
            }
            Assert.IsNotNull(contactExtraBList[0].IsAdmin);
            Assert.IsNotNull(contactExtraBList[0].EmailValidated);
            Assert.IsNotNull(contactExtraBList[0].Disabled);
            Assert.IsNotNull(contactExtraBList[0].IsNew);
            if (!string.IsNullOrWhiteSpace(contactExtraBList[0].SamplingPlanner_ProvincesTVItemID))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactExtraBList[0].SamplingPlanner_ProvincesTVItemID));
            }
            Assert.IsNotNull(contactExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(contactExtraBList[0].HasErrors);
        }
        private Contact GetFilledRandomContact(string OmitPropName)
        {
            Contact contact = new Contact();

            if (OmitPropName != "Id") contact.Id = "023566a4-4a25-4484-88f5-584aa8e1da38";
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

            return contact;
        }
        #endregion Functions private
    }
}
