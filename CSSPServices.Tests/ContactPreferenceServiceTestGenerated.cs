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
    public partial class ContactPreferenceServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactPreferenceService contactPreferenceService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceServiceTest() : base()
        {
            //contactPreferenceService = new ContactPreferenceService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ContactPreference_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ContactPreference contactPreference = GetFilledRandomContactPreference("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = contactPreferenceService.GetRead().Count();

                    Assert.AreEqual(contactPreferenceService.GetRead().Count(), contactPreferenceService.GetEdit().Count());

                    contactPreferenceService.Add(contactPreference);
                    if (contactPreference.HasErrors)
                    {
                        Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, contactPreferenceService.GetRead().Where(c => c == contactPreference).Any());
                    contactPreferenceService.Update(contactPreference);
                    if (contactPreference.HasErrors)
                    {
                        Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, contactPreferenceService.GetRead().Count());
                    contactPreferenceService.Delete(contactPreference);
                    if (contactPreference.HasErrors)
                    {
                        Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // contactPreference.ContactPreferenceID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceID = 0;
                    contactPreferenceService.Update(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactPreferenceContactPreferenceID), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceID = 10000000;
                    contactPreferenceService.Update(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ContactPreference, CSSPModelsRes.ContactPreferenceContactPreferenceID, contactPreference.ContactPreferenceID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = Error)]
                    // contactPreference.ContactID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactID = 0;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactPreferenceContactID, contactPreference.ContactID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // contactPreference.TVType   (TVTypeEnum)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.TVType = (TVTypeEnum)1000000;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactPreferenceTVType), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 1000)]
                    // contactPreference.MarkerSize   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.MarkerSize = 0;
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ContactPreferenceMarkerSize, "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetRead().Count());
                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.MarkerSize = 1001;
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ContactPreferenceMarkerSize, "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contactPreference.ContactPreferenceWeb   (ContactPreferenceWeb)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceWeb = null;
                    Assert.IsNull(contactPreference.ContactPreferenceWeb);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceWeb = new ContactPreferenceWeb();
                    Assert.IsNotNull(contactPreference.ContactPreferenceWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contactPreference.ContactPreferenceReport   (ContactPreferenceReport)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceReport = null;
                    Assert.IsNull(contactPreference.ContactPreferenceReport);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceReport = new ContactPreferenceReport();
                    Assert.IsNotNull(contactPreference.ContactPreferenceReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contactPreference.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateDate_UTC = new DateTime();
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactPreferenceLastUpdateDate_UTC), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ContactPreferenceLastUpdateDate_UTC, "1980"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contactPreference.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateContactTVItemID = 0;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactPreferenceLastUpdateContactTVItemID, contactPreference.LastUpdateContactTVItemID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateContactTVItemID = 1;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactPreferenceLastUpdateContactTVItemID, "Contact"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactPreference.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactPreference.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID)
        [TestMethod]
        public void GetContactPreferenceWithContactPreferenceID__contactPreference_ContactPreferenceID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactPreference contactPreference = (from c in contactPreferenceService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(contactPreference);

                    ContactPreference contactPreferenceRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        contactPreferenceService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID);
                            Assert.IsNull(contactPreferenceRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactPreferenceFields(new List<ContactPreference>() { contactPreferenceRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID)

        #region Tests Generated for GetContactPreferenceList()
        [TestMethod]
        public void GetContactPreferenceList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactPreference contactPreference = (from c in contactPreferenceService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(contactPreference);

                    List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        contactPreferenceService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            Assert.AreEqual(0, contactPreferenceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactPreferenceFields(contactPreferenceList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactPreferenceList()

        #region Tests Generated for GetContactPreferenceList() Skip Take
        [TestMethod]
        public void GetContactPreferenceList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                    List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactPreferenceDirectQueryList = contactPreferenceService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            Assert.AreEqual(0, contactPreferenceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactPreferenceFields(contactPreferenceList, entityQueryDetailType);
                        Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        Assert.AreEqual(1, contactPreferenceList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactPreferenceList() Skip Take

        #region Tests Generated for GetContactPreferenceList() Skip Take Order
        [TestMethod]
        public void GetContactPreferenceList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                    List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 1, 1,  "ContactPreferenceID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactPreferenceDirectQueryList = contactPreferenceService.GetRead().Skip(1).Take(1).OrderBy(c => c.ContactPreferenceID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            Assert.AreEqual(0, contactPreferenceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactPreferenceFields(contactPreferenceList, entityQueryDetailType);
                        Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        Assert.AreEqual(1, contactPreferenceList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactPreferenceList() Skip Take Order

        #region Tests Generated for GetContactPreferenceList() Skip Take 2Order
        [TestMethod]
        public void GetContactPreferenceList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                    List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 1, 1, "ContactPreferenceID,ContactID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactPreferenceDirectQueryList = contactPreferenceService.GetRead().Skip(1).Take(1).OrderBy(c => c.ContactPreferenceID).ThenBy(c => c.ContactID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            Assert.AreEqual(0, contactPreferenceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactPreferenceFields(contactPreferenceList, entityQueryDetailType);
                        Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        Assert.AreEqual(1, contactPreferenceList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactPreferenceList() Skip Take 2Order

        #region Tests Generated for GetContactPreferenceList() Skip Take Order Where
        [TestMethod]
        public void GetContactPreferenceList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                    List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 0, 1, "ContactPreferenceID", "ContactPreferenceID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactPreferenceDirectQueryList = contactPreferenceService.GetRead().Where(c => c.ContactPreferenceID == 4).Skip(0).Take(1).OrderBy(c => c.ContactPreferenceID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            Assert.AreEqual(0, contactPreferenceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactPreferenceFields(contactPreferenceList, entityQueryDetailType);
                        Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        Assert.AreEqual(1, contactPreferenceList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactPreferenceList() Skip Take Order Where

        #region Tests Generated for GetContactPreferenceList() Skip Take Order 2Where
        [TestMethod]
        public void GetContactPreferenceList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                    List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 0, 1, "ContactPreferenceID", "ContactPreferenceID,GT,2|ContactPreferenceID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactPreferenceDirectQueryList = contactPreferenceService.GetRead().Where(c => c.ContactPreferenceID > 2 && c.ContactPreferenceID < 5).Skip(0).Take(1).OrderBy(c => c.ContactPreferenceID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            Assert.AreEqual(0, contactPreferenceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactPreferenceFields(contactPreferenceList, entityQueryDetailType);
                        Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        Assert.AreEqual(1, contactPreferenceList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactPreferenceList() Skip Take Order 2Where

        #region Tests Generated for GetContactPreferenceList() 2Where
        [TestMethod]
        public void GetContactPreferenceList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                    List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 0, 10000, "", "ContactPreferenceID,GT,2|ContactPreferenceID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        contactPreferenceDirectQueryList = contactPreferenceService.GetRead().Where(c => c.ContactPreferenceID > 2 && c.ContactPreferenceID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            Assert.AreEqual(0, contactPreferenceList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckContactPreferenceFields(contactPreferenceList, entityQueryDetailType);
                        Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        Assert.AreEqual(2, contactPreferenceList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactPreferenceList() 2Where

        #region Functions private
        private void CheckContactPreferenceFields(List<ContactPreference> contactPreferenceList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // ContactPreference fields
            Assert.IsNotNull(contactPreferenceList[0].ContactPreferenceID);
            Assert.IsNotNull(contactPreferenceList[0].ContactID);
            Assert.IsNotNull(contactPreferenceList[0].TVType);
            Assert.IsNotNull(contactPreferenceList[0].MarkerSize);
            Assert.IsNotNull(contactPreferenceList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactPreferenceList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // ContactPreferenceWeb and ContactPreferenceReport fields should be null here
                Assert.IsNull(contactPreferenceList[0].ContactPreferenceWeb);
                Assert.IsNull(contactPreferenceList[0].ContactPreferenceReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // ContactPreferenceWeb fields should not be null and ContactPreferenceReport fields should be null here
                if (!string.IsNullOrWhiteSpace(contactPreferenceList[0].ContactPreferenceWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceList[0].ContactPreferenceWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(contactPreferenceList[0].ContactPreferenceWeb.TVTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceList[0].ContactPreferenceWeb.TVTypeText));
                }
                Assert.IsNull(contactPreferenceList[0].ContactPreferenceReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // ContactPreferenceWeb and ContactPreferenceReport fields should NOT be null here
                if (contactPreferenceList[0].ContactPreferenceWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceList[0].ContactPreferenceWeb.LastUpdateContactTVText));
                }
                if (contactPreferenceList[0].ContactPreferenceWeb.TVTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceList[0].ContactPreferenceWeb.TVTypeText));
                }
                if (contactPreferenceList[0].ContactPreferenceReport.ContactPreferenceReportText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceList[0].ContactPreferenceReport.ContactPreferenceReportText));
                }
            }
        }
        private ContactPreference GetFilledRandomContactPreference(string OmitPropName)
        {
            ContactPreference contactPreference = new ContactPreference();

            if (OmitPropName != "ContactID") contactPreference.ContactID = 1;
            if (OmitPropName != "TVType") contactPreference.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "MarkerSize") contactPreference.MarkerSize = GetRandomInt(1, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") contactPreference.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactPreference.LastUpdateContactTVItemID = 2;

            return contactPreference;
        }
        #endregion Functions private
    }
}
