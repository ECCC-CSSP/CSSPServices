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

        #region Functions public
        #endregion Functions public

        #region Functions private
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Contact_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactService contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);

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

                    Assert.AreEqual(contactService.GetRead().Count(), contactService.GetEdit().Count());

                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    if (contact.HasErrors)
                    {
                        Assert.AreEqual("", contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, contactService.GetRead().Where(c => c == contact).Any());
                    contactService.Update(contact);
                    if (contact.HasErrors)
                    {
                        Assert.AreEqual("", contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, contactService.GetRead().Count());
                    contactService.Delete(contact);
                    if (contact.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactContactID), contact.ValidationResults.FirstOrDefault().ErrorMessage);

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactID = 10000000;
                    contactService.Update(contact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactContactID, contact.ContactID.ToString()), contact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "AspNetUser", ExistPlurial = "s", ExistFieldID = "Id", AllowableTVtypeList = Error)]
                    // [StringLength(128))]
                    // contact.Id   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("Id");
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.LoggedIn));
                    Assert.AreEqual(2, contact.ValidationResults.Count());
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactId)).Any());
                    Assert.AreEqual(null, contact.Id);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.Id = GetRandomString("", 129);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactId, "128"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contact.ContactTVItemID   (Int32)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactTVItemID = 0;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactContactTVItemID, contact.ContactTVItemID.ToString()), contact.ValidationResults.FirstOrDefault().ErrorMessage);

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactTVItemID = 1;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactContactTVItemID, "Contact"), contact.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginEmail)).Any());
                    Assert.AreEqual(null, contact.LoginEmail);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LoginEmail = GetRandomString("", 5);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ContactLoginEmail, "6", "255"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetRead().Count());
                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LoginEmail = GetRandomString("", 256);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ContactLoginEmail, "6", "255"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // contact.FirstName   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("FirstName");
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.LoggedIn));
                    Assert.AreEqual(1, contact.ValidationResults.Count());
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactFirstName)).Any());
                    Assert.AreEqual(null, contact.FirstName);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.FirstName = GetRandomString("", 101);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactFirstName, "100"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // contact.LastName   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("LastName");
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.LoggedIn));
                    Assert.AreEqual(1, contact.ValidationResults.Count());
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLastName)).Any());
                    Assert.AreEqual(null, contact.LastName);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastName = GetRandomString("", 101);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactLastName, "100"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(50))]
                    // contact.Initial   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.Initial = GetRandomString("", 51);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactInitial, "50"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // contact.WebName   (String)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("WebName");
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.LoggedIn));
                    Assert.AreEqual(1, contact.ValidationResults.Count());
                    Assert.IsTrue(contact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactWebName)).Any());
                    Assert.AreEqual(null, contact.WebName);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.WebName = GetRandomString("", 101);
                    Assert.AreEqual(false, contactService.Add(contact, AddContactTypeEnum.First));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactWebName, "100"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // contact.ContactTitle   (ContactTitleEnum)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactTitle = (ContactTitleEnum)1000000;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactContactTitle), contact.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactSamplingPlanner_ProvincesTVItemID, "200"), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contact.ContactWeb   (ContactWeb)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactWeb = null;
                    Assert.IsNull(contact.ContactWeb);

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactWeb = new ContactWeb();
                    Assert.IsNotNull(contact.ContactWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contact.ContactReport   (ContactReport)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactReport = null;
                    Assert.IsNull(contact.ContactReport);

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.ContactReport = new ContactReport();
                    Assert.IsNotNull(contact.ContactReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contact.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastUpdateDate_UTC = new DateTime();
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLastUpdateDate_UTC), contact.ValidationResults.FirstOrDefault().ErrorMessage);
                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ContactLastUpdateDate_UTC, "1980"), contact.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contact.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastUpdateContactTVItemID = 0;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactLastUpdateContactTVItemID, contact.LastUpdateContactTVItemID.ToString()), contact.ValidationResults.FirstOrDefault().ErrorMessage);

                    contact = null;
                    contact = GetFilledRandomContact("");
                    contact.LastUpdateContactTVItemID = 1;
                    contactService.Add(contact, AddContactTypeEnum.LoggedIn);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactLastUpdateContactTVItemID, "Contact"), contact.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated Get With Key
        [TestMethod]
        public void Contact_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactService contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);
                    Contact contact = (from c in contactService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(contact);

                    Contact contactRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            contactRet = contactService.GetContactWithContactID(contact.ContactID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactRet = contactService.GetContactWithContactID(contact.ContactID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactRet = contactService.GetContactWithContactID(contact.ContactID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactRet = contactService.GetContactWithContactID(contact.ContactID, EntityQueryDetailTypeEnum.EntityReport);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Contact fields
                        Assert.IsNotNull(contactRet.ContactID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.Id));
                        Assert.IsNotNull(contactRet.ContactTVItemID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.LoginEmail));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.FirstName));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.LastName));
                        if (contactRet.Initial != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.Initial));
                        }
                        Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.WebName));
                        if (contactRet.ContactTitle != null)
                        {
                            Assert.IsNotNull(contactRet.ContactTitle);
                        }
                        Assert.IsNotNull(contactRet.IsAdmin);
                        Assert.IsNotNull(contactRet.EmailValidated);
                        Assert.IsNotNull(contactRet.Disabled);
                        Assert.IsNotNull(contactRet.IsNew);
                        if (contactRet.SamplingPlanner_ProvincesTVItemID != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.SamplingPlanner_ProvincesTVItemID));
                        }
                        Assert.IsNotNull(contactRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(contactRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ContactWeb and ContactReport fields should be null here
                            Assert.IsNull(contactRet.ContactWeb);
                            Assert.IsNull(contactRet.ContactReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ContactWeb fields should not be null and ContactReport fields should be null here
                            if (contactRet.ContactWeb.ContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.ContactWeb.ContactTVText));
                            }
                            if (contactRet.ContactWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.ContactWeb.LastUpdateContactTVText));
                            }
                            Assert.IsTrue(contactRet.ContactWeb.ParentTVItemID > 0);
                            if (contactRet.ContactWeb.ContactTitleText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.ContactWeb.ContactTitleText));
                            }
                            Assert.IsNull(contactRet.ContactReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ContactWeb and ContactReport fields should NOT be null here
                            if (contactRet.ContactWeb.ContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.ContactWeb.ContactTVText));
                            }
                            if (contactRet.ContactWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.ContactWeb.LastUpdateContactTVText));
                            }
                            Assert.IsTrue(contactRet.ContactWeb.ParentTVItemID > 0);
                            if (contactRet.ContactWeb.ContactTitleText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.ContactWeb.ContactTitleText));
                            }
                            if (contactRet.ContactReport.ContactReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactRet.ContactReport.ContactReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of Contact
        #endregion Tests Get List of Contact

    }
}
