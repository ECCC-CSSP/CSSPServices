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
    public partial class ContactShortcutServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactShortcutService contactShortcutService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutServiceTest() : base()
        {
            //contactShortcutService = new ContactShortcutService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ContactShortcut_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ContactShortcut contactShortcut = GetFilledRandomContactShortcut("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = contactShortcutService.GetContactShortcutList().Count();

                    Assert.AreEqual(contactShortcutService.GetContactShortcutList().Count(), (from c in dbTestDB.ContactShortcuts select c).Take(200).Count());

                    contactShortcutService.Add(contactShortcut);
                    if (contactShortcut.HasErrors)
                    {
                        Assert.AreEqual("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, contactShortcutService.GetContactShortcutList().Where(c => c == contactShortcut).Any());
                    contactShortcutService.Update(contactShortcut);
                    if (contactShortcut.HasErrors)
                    {
                        Assert.AreEqual("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, contactShortcutService.GetContactShortcutList().Count());
                    contactShortcutService.Delete(contactShortcut);
                    if (contactShortcut.HasErrors)
                    {
                        Assert.AreEqual("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, contactShortcutService.GetContactShortcutList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // contactShortcut.ContactShortcutID   (Int32)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactShortcutID = 0;
                    contactShortcutService.Update(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ContactShortcutContactShortcutID"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactShortcutID = 10000000;
                    contactShortcutService.Update(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ContactShortcut", "ContactShortcutContactShortcutID", contactShortcut.ContactShortcutID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = )]
                    // contactShortcut.ContactID   (Int32)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactID = 0;
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactShortcutContactID", contactShortcut.ContactID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // contactShortcut.ShortCutText   (String)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("ShortCutText");
                    Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                    Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
                    Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ContactShortcutShortCutText")).Any());
                    Assert.AreEqual(null, contactShortcut.ShortCutText);
                    Assert.AreEqual(count, contactShortcutService.GetContactShortcutList().Count());

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ShortCutText = GetRandomString("", 101);
                    Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactShortcutShortCutText", "100"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactShortcutService.GetContactShortcutList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // contactShortcut.ShortCutAddress   (String)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("ShortCutAddress");
                    Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                    Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
                    Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ContactShortcutShortCutAddress")).Any());
                    Assert.AreEqual(null, contactShortcut.ShortCutAddress);
                    Assert.AreEqual(count, contactShortcutService.GetContactShortcutList().Count());

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ShortCutAddress = GetRandomString("", 201);
                    Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactShortcutShortCutAddress", "200"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactShortcutService.GetContactShortcutList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contactShortcut.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateDate_UTC = new DateTime();
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ContactShortcutLastUpdateDate_UTC"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ContactShortcutLastUpdateDate_UTC", "1980"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contactShortcut.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateContactTVItemID = 0;
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactShortcutLastUpdateContactTVItemID", contactShortcut.LastUpdateContactTVItemID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateContactTVItemID = 1;
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ContactShortcutLastUpdateContactTVItemID", "Contact"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactShortcut.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactShortcut.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID)
        [TestMethod]
        public void GetContactShortcutWithContactShortcutID__contactShortcut_ContactShortcutID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactShortcut contactShortcut = (from c in dbTestDB.ContactShortcuts select c).FirstOrDefault();
                    Assert.IsNotNull(contactShortcut);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        contactShortcutService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            ContactShortcut contactShortcutRet = contactShortcutService.GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID);
                            CheckContactShortcutFields(new List<ContactShortcut>() { contactShortcutRet });
                            Assert.AreEqual(contactShortcut.ContactShortcutID, contactShortcutRet.ContactShortcutID);
                        }
                        else if (detail == "A")
                        {
                            ContactShortcut_A contactShortcut_ARet = contactShortcutService.GetContactShortcut_AWithContactShortcutID(contactShortcut.ContactShortcutID);
                            CheckContactShortcut_AFields(new List<ContactShortcut_A>() { contactShortcut_ARet });
                            Assert.AreEqual(contactShortcut.ContactShortcutID, contactShortcut_ARet.ContactShortcutID);
                        }
                        else if (detail == "B")
                        {
                            ContactShortcut_B contactShortcut_BRet = contactShortcutService.GetContactShortcut_BWithContactShortcutID(contactShortcut.ContactShortcutID);
                            CheckContactShortcut_BFields(new List<ContactShortcut_B>() { contactShortcut_BRet });
                            Assert.AreEqual(contactShortcut.ContactShortcutID, contactShortcut_BRet.ContactShortcutID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID)

        #region Tests Generated for GetContactShortcutList()
        [TestMethod]
        public void GetContactShortcutList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactShortcut contactShortcut = (from c in dbTestDB.ContactShortcuts select c).FirstOrDefault();
                    Assert.IsNotNull(contactShortcut);

                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        contactShortcutService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            CheckContactShortcutFields(contactShortcutList);
                        }
                        else if (detail == "A")
                        {
                            List<ContactShortcut_A> contactShortcut_AList = new List<ContactShortcut_A>();
                            contactShortcut_AList = contactShortcutService.GetContactShortcut_AList().ToList();
                            CheckContactShortcut_AFields(contactShortcut_AList);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ContactShortcut_B> contactShortcut_BList = new List<ContactShortcut_B>();
                            contactShortcut_BList = contactShortcutService.GetContactShortcut_BList().ToList();
                            CheckContactShortcut_BFields(contactShortcut_BList);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList()

        #region Tests Generated for GetContactShortcutList() Skip Take
        [TestMethod]
        public void GetContactShortcutList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                        contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            CheckContactShortcutFields(contactShortcutList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        }
                        else if (detail == "A")
                        {
                            List<ContactShortcut_A> contactShortcut_AList = new List<ContactShortcut_A>();
                            contactShortcut_AList = contactShortcutService.GetContactShortcut_AList().ToList();
                            CheckContactShortcut_AFields(contactShortcut_AList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_AList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ContactShortcut_B> contactShortcut_BList = new List<ContactShortcut_B>();
                            contactShortcut_BList = contactShortcutService.GetContactShortcut_BList().ToList();
                            CheckContactShortcut_BFields(contactShortcut_BList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_BList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take

        #region Tests Generated for GetContactShortcutList() Skip Take Order
        [TestMethod]
        public void GetContactShortcutList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1,  "ContactShortcutID", "");

                        List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                        contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Skip(1).Take(1).OrderBy(c => c.ContactShortcutID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            CheckContactShortcutFields(contactShortcutList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        }
                        else if (detail == "A")
                        {
                            List<ContactShortcut_A> contactShortcut_AList = new List<ContactShortcut_A>();
                            contactShortcut_AList = contactShortcutService.GetContactShortcut_AList().ToList();
                            CheckContactShortcut_AFields(contactShortcut_AList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_AList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ContactShortcut_B> contactShortcut_BList = new List<ContactShortcut_B>();
                            contactShortcut_BList = contactShortcutService.GetContactShortcut_BList().ToList();
                            CheckContactShortcut_BFields(contactShortcut_BList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_BList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take Order

        #region Tests Generated for GetContactShortcutList() Skip Take 2Order
        [TestMethod]
        public void GetContactShortcutList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1, "ContactShortcutID,ContactID", "");

                        List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                        contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Skip(1).Take(1).OrderBy(c => c.ContactShortcutID).ThenBy(c => c.ContactID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            CheckContactShortcutFields(contactShortcutList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        }
                        else if (detail == "A")
                        {
                            List<ContactShortcut_A> contactShortcut_AList = new List<ContactShortcut_A>();
                            contactShortcut_AList = contactShortcutService.GetContactShortcut_AList().ToList();
                            CheckContactShortcut_AFields(contactShortcut_AList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_AList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ContactShortcut_B> contactShortcut_BList = new List<ContactShortcut_B>();
                            contactShortcut_BList = contactShortcutService.GetContactShortcut_BList().ToList();
                            CheckContactShortcut_BFields(contactShortcut_BList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_BList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take 2Order

        #region Tests Generated for GetContactShortcutList() Skip Take Order Where
        [TestMethod]
        public void GetContactShortcutList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 1, "ContactShortcutID", "ContactShortcutID,EQ,4", "");

                        List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                        contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Where(c => c.ContactShortcutID == 4).Skip(0).Take(1).OrderBy(c => c.ContactShortcutID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            CheckContactShortcutFields(contactShortcutList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        }
                        else if (detail == "A")
                        {
                            List<ContactShortcut_A> contactShortcut_AList = new List<ContactShortcut_A>();
                            contactShortcut_AList = contactShortcutService.GetContactShortcut_AList().ToList();
                            CheckContactShortcut_AFields(contactShortcut_AList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_AList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ContactShortcut_B> contactShortcut_BList = new List<ContactShortcut_B>();
                            contactShortcut_BList = contactShortcutService.GetContactShortcut_BList().ToList();
                            CheckContactShortcut_BFields(contactShortcut_BList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_BList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take Order Where

        #region Tests Generated for GetContactShortcutList() Skip Take Order 2Where
        [TestMethod]
        public void GetContactShortcutList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 1, "ContactShortcutID", "ContactShortcutID,GT,2|ContactShortcutID,LT,5", "");

                        List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                        contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Where(c => c.ContactShortcutID > 2 && c.ContactShortcutID < 5).Skip(0).Take(1).OrderBy(c => c.ContactShortcutID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            CheckContactShortcutFields(contactShortcutList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        }
                        else if (detail == "A")
                        {
                            List<ContactShortcut_A> contactShortcut_AList = new List<ContactShortcut_A>();
                            contactShortcut_AList = contactShortcutService.GetContactShortcut_AList().ToList();
                            CheckContactShortcut_AFields(contactShortcut_AList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_AList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ContactShortcut_B> contactShortcut_BList = new List<ContactShortcut_B>();
                            contactShortcut_BList = contactShortcutService.GetContactShortcut_BList().ToList();
                            CheckContactShortcut_BFields(contactShortcut_BList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_BList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() Skip Take Order 2Where

        #region Tests Generated for GetContactShortcutList() 2Where
        [TestMethod]
        public void GetContactShortcutList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 10000, "", "ContactShortcutID,GT,2|ContactShortcutID,LT,5", "");

                        List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                        contactShortcutDirectQueryList = (from c in dbTestDB.ContactShortcuts select c).Where(c => c.ContactShortcutID > 2 && c.ContactShortcutID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            CheckContactShortcutFields(contactShortcutList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        }
                        else if (detail == "A")
                        {
                            List<ContactShortcut_A> contactShortcut_AList = new List<ContactShortcut_A>();
                            contactShortcut_AList = contactShortcutService.GetContactShortcut_AList().ToList();
                            CheckContactShortcut_AFields(contactShortcut_AList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_AList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<ContactShortcut_B> contactShortcut_BList = new List<ContactShortcut_B>();
                            contactShortcut_BList = contactShortcutService.GetContactShortcut_BList().ToList();
                            CheckContactShortcut_BFields(contactShortcut_BList);
                            Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcut_BList[0].ContactShortcutID);
                            Assert.AreEqual(contactShortcutDirectQueryList.Count, contactShortcut_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() 2Where

        #region Functions private
        private void CheckContactShortcutFields(List<ContactShortcut> contactShortcutList)
        {
            Assert.IsNotNull(contactShortcutList[0].ContactShortcutID);
            Assert.IsNotNull(contactShortcutList[0].ContactID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutList[0].ShortCutText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutList[0].ShortCutAddress));
            Assert.IsNotNull(contactShortcutList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactShortcutList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(contactShortcutList[0].HasErrors);
        }
        private void CheckContactShortcut_AFields(List<ContactShortcut_A> contactShortcut_AList)
        {
            Assert.IsNotNull(contactShortcut_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(contactShortcut_AList[0].ContactShortcutID);
            Assert.IsNotNull(contactShortcut_AList[0].ContactID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcut_AList[0].ShortCutText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcut_AList[0].ShortCutAddress));
            Assert.IsNotNull(contactShortcut_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactShortcut_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(contactShortcut_AList[0].HasErrors);
        }
        private void CheckContactShortcut_BFields(List<ContactShortcut_B> contactShortcut_BList)
        {
            if (!string.IsNullOrWhiteSpace(contactShortcut_BList[0].ContactShortcutReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcut_BList[0].ContactShortcutReportTest));
            }
            Assert.IsNotNull(contactShortcut_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(contactShortcut_BList[0].ContactShortcutID);
            Assert.IsNotNull(contactShortcut_BList[0].ContactID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcut_BList[0].ShortCutText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcut_BList[0].ShortCutAddress));
            Assert.IsNotNull(contactShortcut_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactShortcut_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(contactShortcut_BList[0].HasErrors);
        }
        private ContactShortcut GetFilledRandomContactShortcut(string OmitPropName)
        {
            ContactShortcut contactShortcut = new ContactShortcut();

            if (OmitPropName != "ContactID") contactShortcut.ContactID = 1;
            if (OmitPropName != "ShortCutText") contactShortcut.ShortCutText = GetRandomString("", 5);
            if (OmitPropName != "ShortCutAddress") contactShortcut.ShortCutAddress = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") contactShortcut.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactShortcut.LastUpdateContactTVItemID = 2;

            return contactShortcut;
        }
        #endregion Functions private
    }
}
