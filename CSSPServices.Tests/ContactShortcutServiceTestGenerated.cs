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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = contactShortcutService.GetRead().Count();

                    Assert.AreEqual(contactShortcutService.GetRead().Count(), contactShortcutService.GetEdit().Count());

                    contactShortcutService.Add(contactShortcut);
                    if (contactShortcut.HasErrors)
                    {
                        Assert.AreEqual("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, contactShortcutService.GetRead().Where(c => c == contactShortcut).Any());
                    contactShortcutService.Update(contactShortcut);
                    if (contactShortcut.HasErrors)
                    {
                        Assert.AreEqual("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, contactShortcutService.GetRead().Count());
                    contactShortcutService.Delete(contactShortcut);
                    if (contactShortcut.HasErrors)
                    {
                        Assert.AreEqual("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, contactShortcutService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactShortcutContactShortcutID), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactShortcutID = 10000000;
                    contactShortcutService.Update(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ContactShortcut, CSSPModelsRes.ContactShortcutContactShortcutID, contactShortcut.ContactShortcutID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = )]
                    // contactShortcut.ContactID   (Int32)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactID = 0;
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactShortcutContactID, contactShortcut.ContactID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // contactShortcut.ShortCutText   (String)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("ShortCutText");
                    Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                    Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
                    Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactShortcutShortCutText)).Any());
                    Assert.AreEqual(null, contactShortcut.ShortCutText);
                    Assert.AreEqual(count, contactShortcutService.GetRead().Count());

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ShortCutText = GetRandomString("", 101);
                    Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactShortcutShortCutText, "100"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactShortcutService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(200))]
                    // contactShortcut.ShortCutAddress   (String)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("ShortCutAddress");
                    Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                    Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
                    Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactShortcutShortCutAddress)).Any());
                    Assert.AreEqual(null, contactShortcut.ShortCutAddress);
                    Assert.AreEqual(count, contactShortcutService.GetRead().Count());

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ShortCutAddress = GetRandomString("", 201);
                    Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactShortcutShortCutAddress, "200"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactShortcutService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contactShortcut.ContactShortcutWeb   (ContactShortcutWeb)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactShortcutWeb = null;
                    Assert.IsNull(contactShortcut.ContactShortcutWeb);

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactShortcutWeb = new ContactShortcutWeb();
                    Assert.IsNotNull(contactShortcut.ContactShortcutWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contactShortcut.ContactShortcutReport   (ContactShortcutReport)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactShortcutReport = null;
                    Assert.IsNull(contactShortcut.ContactShortcutReport);

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.ContactShortcutReport = new ContactShortcutReport();
                    Assert.IsNotNull(contactShortcut.ContactShortcutReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contactShortcut.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateDate_UTC = new DateTime();
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactShortcutLastUpdateDate_UTC), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ContactShortcutLastUpdateDate_UTC, "1980"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contactShortcut.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateContactTVItemID = 0;
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactShortcutLastUpdateContactTVItemID, contactShortcut.LastUpdateContactTVItemID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactShortcut = null;
                    contactShortcut = GetFilledRandomContactShortcut("");
                    contactShortcut.LastUpdateContactTVItemID = 1;
                    contactShortcutService.Add(contactShortcut);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactShortcutLastUpdateContactTVItemID, "Contact"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactShortcut contactShortcut = (from c in contactShortcutService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(contactShortcut);

                    ContactShortcut contactShortcutRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        contactShortcutService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            contactShortcutRet = contactShortcutService.GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID);
                            Assert.IsNull(contactShortcutRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactShortcutRet = contactShortcutService.GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactShortcutRet = contactShortcutService.GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactShortcutRet = contactShortcutService.GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactShortcutFields(new List<ContactShortcut>() { contactShortcutRet }, entityQueryDetailType);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactShortcut contactShortcut = (from c in contactShortcutService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(contactShortcut);

                    List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        contactShortcutService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            Assert.AreEqual(0, contactShortcutList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactShortcutFields(contactShortcutList, entityQueryDetailType);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactShortcutDirectQueryList = contactShortcutService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            Assert.AreEqual(0, contactShortcutList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactShortcutFields(contactShortcutList, entityQueryDetailType);
                        Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        Assert.AreEqual(1, contactShortcutList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1,  "ContactShortcutID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactShortcutDirectQueryList = contactShortcutService.GetRead().Skip(1).Take(1).OrderBy(c => c.ContactShortcutID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            Assert.AreEqual(0, contactShortcutList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactShortcutFields(contactShortcutList, entityQueryDetailType);
                        Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        Assert.AreEqual(1, contactShortcutList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 1, 1, "ContactShortcutID,ContactID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactShortcutDirectQueryList = contactShortcutService.GetRead().Skip(1).Take(1).OrderBy(c => c.ContactShortcutID).ThenBy(c => c.ContactID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            Assert.AreEqual(0, contactShortcutList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactShortcutFields(contactShortcutList, entityQueryDetailType);
                        Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        Assert.AreEqual(1, contactShortcutList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 1, "ContactShortcutID", "ContactShortcutID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactShortcutDirectQueryList = contactShortcutService.GetRead().Where(c => c.ContactShortcutID == 4).Skip(0).Take(1).OrderBy(c => c.ContactShortcutID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            Assert.AreEqual(0, contactShortcutList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactShortcutFields(contactShortcutList, entityQueryDetailType);
                        Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        Assert.AreEqual(1, contactShortcutList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 1, "ContactShortcutID", "ContactShortcutID,GT,2|ContactShortcutID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactShortcutDirectQueryList = contactShortcutService.GetRead().Where(c => c.ContactShortcutID > 2 && c.ContactShortcutID < 5).Skip(0).Take(1).OrderBy(c => c.ContactShortcutID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            Assert.AreEqual(0, contactShortcutList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactShortcutFields(contactShortcutList, entityQueryDetailType);
                        Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        Assert.AreEqual(1, contactShortcutList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactShortcut> contactShortcutList = new List<ContactShortcut>();
                    List<ContactShortcut> contactShortcutDirectQueryList = new List<ContactShortcut>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactShortcutService contactShortcutService = new ContactShortcutService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactShortcutService.Query = contactShortcutService.FillQuery(typeof(ContactShortcut), culture.TwoLetterISOLanguageName, 0, 10000, "", "ContactShortcutID,GT,2|ContactShortcutID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactShortcutDirectQueryList = contactShortcutService.GetRead().Where(c => c.ContactShortcutID > 2 && c.ContactShortcutID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                            Assert.AreEqual(0, contactShortcutList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactShortcutList = contactShortcutService.GetContactShortcutList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactShortcutFields(contactShortcutList, entityQueryDetailType);
                        Assert.AreEqual(contactShortcutDirectQueryList[0].ContactShortcutID, contactShortcutList[0].ContactShortcutID);
                        Assert.AreEqual(2, contactShortcutList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactShortcutList() 2Where

        #region Functions private
        private void CheckContactShortcutFields(List<ContactShortcut> contactShortcutList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // ContactShortcut fields
            Assert.IsNotNull(contactShortcutList[0].ContactShortcutID);
            Assert.IsNotNull(contactShortcutList[0].ContactID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutList[0].ShortCutText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutList[0].ShortCutAddress));
            Assert.IsNotNull(contactShortcutList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactShortcutList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // ContactShortcutWeb and ContactShortcutReport fields should be null here
                Assert.IsNull(contactShortcutList[0].ContactShortcutWeb);
                Assert.IsNull(contactShortcutList[0].ContactShortcutReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // ContactShortcutWeb fields should not be null and ContactShortcutReport fields should be null here
                if (!string.IsNullOrWhiteSpace(contactShortcutList[0].ContactShortcutWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutList[0].ContactShortcutWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(contactShortcutList[0].ContactShortcutReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // ContactShortcutWeb and ContactShortcutReport fields should NOT be null here
                if (contactShortcutList[0].ContactShortcutWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutList[0].ContactShortcutWeb.LastUpdateContactTVText));
                }
                if (contactShortcutList[0].ContactShortcutReport.ContactShortcutReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutList[0].ContactShortcutReport.ContactShortcutReportTest));
                }
            }
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
