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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = contactPreferenceService.GetContactPreferenceList().Count();

                    Assert.AreEqual(contactPreferenceService.GetContactPreferenceList().Count(), (from c in dbTestDB.ContactPreferences select c).Take(200).Count());

                    contactPreferenceService.Add(contactPreference);
                    if (contactPreference.HasErrors)
                    {
                        Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, contactPreferenceService.GetContactPreferenceList().Where(c => c == contactPreference).Any());
                    contactPreferenceService.Update(contactPreference);
                    if (contactPreference.HasErrors)
                    {
                        Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, contactPreferenceService.GetContactPreferenceList().Count());
                    contactPreferenceService.Delete(contactPreference);
                    if (contactPreference.HasErrors)
                    {
                        Assert.AreEqual("", contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, contactPreferenceService.GetContactPreferenceList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ContactPreferenceContactPreferenceID"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactPreferenceID = 10000000;
                    contactPreferenceService.Update(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ContactPreference", "ContactPreferenceContactPreferenceID", contactPreference.ContactPreferenceID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = )]
                    // contactPreference.ContactID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.ContactID = 0;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Contact", "ContactPreferenceContactID", contactPreference.ContactID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // contactPreference.TVType   (TVTypeEnum)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.TVType = (TVTypeEnum)1000000;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ContactPreferenceTVType"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 1000)]
                    // contactPreference.MarkerSize   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.MarkerSize = 0;
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ContactPreferenceMarkerSize", "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetContactPreferenceList().Count());
                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.MarkerSize = 1001;
                    Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ContactPreferenceMarkerSize", "1", "1000"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactPreferenceService.GetContactPreferenceList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contactPreference.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateDate_UTC = new DateTime();
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ContactPreferenceLastUpdateDate_UTC"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);
                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ContactPreferenceLastUpdateDate_UTC", "1980"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contactPreference.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateContactTVItemID = 0;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ContactPreferenceLastUpdateContactTVItemID", contactPreference.LastUpdateContactTVItemID.ToString()), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactPreference = null;
                    contactPreference = GetFilledRandomContactPreference("");
                    contactPreference.LastUpdateContactTVItemID = 1;
                    contactPreferenceService.Add(contactPreference);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ContactPreferenceLastUpdateContactTVItemID", "Contact"), contactPreference.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactPreference contactPreference = (from c in dbTestDB.ContactPreferences select c).FirstOrDefault();
                    Assert.IsNotNull(contactPreference);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        contactPreferenceService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            ContactPreference contactPreferenceRet = contactPreferenceService.GetContactPreferenceWithContactPreferenceID(contactPreference.ContactPreferenceID);
                            CheckContactPreferenceFields(new List<ContactPreference>() { contactPreferenceRet });
                            Assert.AreEqual(contactPreference.ContactPreferenceID, contactPreferenceRet.ContactPreferenceID);
                        }
                        else if (detail == "ExtraA")
                        {
                            ContactPreferenceExtraA contactPreferenceExtraARet = contactPreferenceService.GetContactPreferenceExtraAWithContactPreferenceID(contactPreference.ContactPreferenceID);
                            CheckContactPreferenceExtraAFields(new List<ContactPreferenceExtraA>() { contactPreferenceExtraARet });
                            Assert.AreEqual(contactPreference.ContactPreferenceID, contactPreferenceExtraARet.ContactPreferenceID);
                        }
                        else if (detail == "ExtraB")
                        {
                            ContactPreferenceExtraB contactPreferenceExtraBRet = contactPreferenceService.GetContactPreferenceExtraBWithContactPreferenceID(contactPreference.ContactPreferenceID);
                            CheckContactPreferenceExtraBFields(new List<ContactPreferenceExtraB>() { contactPreferenceExtraBRet });
                            Assert.AreEqual(contactPreference.ContactPreferenceID, contactPreferenceExtraBRet.ContactPreferenceID);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ContactPreference contactPreference = (from c in dbTestDB.ContactPreferences select c).FirstOrDefault();
                    Assert.IsNotNull(contactPreference);

                    List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                    contactPreferenceDirectQueryList = (from c in dbTestDB.ContactPreferences select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        contactPreferenceService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            CheckContactPreferenceFields(contactPreferenceList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ContactPreferenceExtraA> contactPreferenceExtraAList = new List<ContactPreferenceExtraA>();
                            contactPreferenceExtraAList = contactPreferenceService.GetContactPreferenceExtraAList().ToList();
                            CheckContactPreferenceExtraAFields(contactPreferenceExtraAList);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ContactPreferenceExtraB> contactPreferenceExtraBList = new List<ContactPreferenceExtraB>();
                            contactPreferenceExtraBList = contactPreferenceService.GetContactPreferenceExtraBList().ToList();
                            CheckContactPreferenceExtraBFields(contactPreferenceExtraBList);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                        contactPreferenceDirectQueryList = (from c in dbTestDB.ContactPreferences select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            CheckContactPreferenceFields(contactPreferenceList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ContactPreferenceExtraA> contactPreferenceExtraAList = new List<ContactPreferenceExtraA>();
                            contactPreferenceExtraAList = contactPreferenceService.GetContactPreferenceExtraAList().ToList();
                            CheckContactPreferenceExtraAFields(contactPreferenceExtraAList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraAList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ContactPreferenceExtraB> contactPreferenceExtraBList = new List<ContactPreferenceExtraB>();
                            contactPreferenceExtraBList = contactPreferenceService.GetContactPreferenceExtraBList().ToList();
                            CheckContactPreferenceExtraBFields(contactPreferenceExtraBList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraBList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 1, 1,  "ContactPreferenceID", "");

                        List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                        contactPreferenceDirectQueryList = (from c in dbTestDB.ContactPreferences select c).Skip(1).Take(1).OrderBy(c => c.ContactPreferenceID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            CheckContactPreferenceFields(contactPreferenceList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ContactPreferenceExtraA> contactPreferenceExtraAList = new List<ContactPreferenceExtraA>();
                            contactPreferenceExtraAList = contactPreferenceService.GetContactPreferenceExtraAList().ToList();
                            CheckContactPreferenceExtraAFields(contactPreferenceExtraAList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraAList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ContactPreferenceExtraB> contactPreferenceExtraBList = new List<ContactPreferenceExtraB>();
                            contactPreferenceExtraBList = contactPreferenceService.GetContactPreferenceExtraBList().ToList();
                            CheckContactPreferenceExtraBFields(contactPreferenceExtraBList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraBList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 1, 1, "ContactPreferenceID,ContactID", "");

                        List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                        contactPreferenceDirectQueryList = (from c in dbTestDB.ContactPreferences select c).Skip(1).Take(1).OrderBy(c => c.ContactPreferenceID).ThenBy(c => c.ContactID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            CheckContactPreferenceFields(contactPreferenceList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ContactPreferenceExtraA> contactPreferenceExtraAList = new List<ContactPreferenceExtraA>();
                            contactPreferenceExtraAList = contactPreferenceService.GetContactPreferenceExtraAList().ToList();
                            CheckContactPreferenceExtraAFields(contactPreferenceExtraAList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraAList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ContactPreferenceExtraB> contactPreferenceExtraBList = new List<ContactPreferenceExtraB>();
                            contactPreferenceExtraBList = contactPreferenceService.GetContactPreferenceExtraBList().ToList();
                            CheckContactPreferenceExtraBFields(contactPreferenceExtraBList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraBList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 0, 1, "ContactPreferenceID", "ContactPreferenceID,EQ,4", "");

                        List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                        contactPreferenceDirectQueryList = (from c in dbTestDB.ContactPreferences select c).Where(c => c.ContactPreferenceID == 4).Skip(0).Take(1).OrderBy(c => c.ContactPreferenceID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            CheckContactPreferenceFields(contactPreferenceList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ContactPreferenceExtraA> contactPreferenceExtraAList = new List<ContactPreferenceExtraA>();
                            contactPreferenceExtraAList = contactPreferenceService.GetContactPreferenceExtraAList().ToList();
                            CheckContactPreferenceExtraAFields(contactPreferenceExtraAList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraAList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ContactPreferenceExtraB> contactPreferenceExtraBList = new List<ContactPreferenceExtraB>();
                            contactPreferenceExtraBList = contactPreferenceService.GetContactPreferenceExtraBList().ToList();
                            CheckContactPreferenceExtraBFields(contactPreferenceExtraBList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraBList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 0, 1, "ContactPreferenceID", "ContactPreferenceID,GT,2|ContactPreferenceID,LT,5", "");

                        List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                        contactPreferenceDirectQueryList = (from c in dbTestDB.ContactPreferences select c).Where(c => c.ContactPreferenceID > 2 && c.ContactPreferenceID < 5).Skip(0).Take(1).OrderBy(c => c.ContactPreferenceID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            CheckContactPreferenceFields(contactPreferenceList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ContactPreferenceExtraA> contactPreferenceExtraAList = new List<ContactPreferenceExtraA>();
                            contactPreferenceExtraAList = contactPreferenceService.GetContactPreferenceExtraAList().ToList();
                            CheckContactPreferenceExtraAFields(contactPreferenceExtraAList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraAList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ContactPreferenceExtraB> contactPreferenceExtraBList = new List<ContactPreferenceExtraB>();
                            contactPreferenceExtraBList = contactPreferenceService.GetContactPreferenceExtraBList().ToList();
                            CheckContactPreferenceExtraBFields(contactPreferenceExtraBList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraBList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ContactPreferenceService contactPreferenceService = new ContactPreferenceService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        contactPreferenceService.Query = contactPreferenceService.FillQuery(typeof(ContactPreference), culture.TwoLetterISOLanguageName, 0, 10000, "", "ContactPreferenceID,GT,2|ContactPreferenceID,LT,5", "");

                        List<ContactPreference> contactPreferenceDirectQueryList = new List<ContactPreference>();
                        contactPreferenceDirectQueryList = (from c in dbTestDB.ContactPreferences select c).Where(c => c.ContactPreferenceID > 2 && c.ContactPreferenceID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<ContactPreference> contactPreferenceList = new List<ContactPreference>();
                            contactPreferenceList = contactPreferenceService.GetContactPreferenceList().ToList();
                            CheckContactPreferenceFields(contactPreferenceList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceList[0].ContactPreferenceID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<ContactPreferenceExtraA> contactPreferenceExtraAList = new List<ContactPreferenceExtraA>();
                            contactPreferenceExtraAList = contactPreferenceService.GetContactPreferenceExtraAList().ToList();
                            CheckContactPreferenceExtraAFields(contactPreferenceExtraAList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraAList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<ContactPreferenceExtraB> contactPreferenceExtraBList = new List<ContactPreferenceExtraB>();
                            contactPreferenceExtraBList = contactPreferenceService.GetContactPreferenceExtraBList().ToList();
                            CheckContactPreferenceExtraBFields(contactPreferenceExtraBList);
                            Assert.AreEqual(contactPreferenceDirectQueryList[0].ContactPreferenceID, contactPreferenceExtraBList[0].ContactPreferenceID);
                            Assert.AreEqual(contactPreferenceDirectQueryList.Count, contactPreferenceExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetContactPreferenceList() 2Where

        #region Functions private
        private void CheckContactPreferenceFields(List<ContactPreference> contactPreferenceList)
        {
            Assert.IsNotNull(contactPreferenceList[0].ContactPreferenceID);
            Assert.IsNotNull(contactPreferenceList[0].ContactID);
            Assert.IsNotNull(contactPreferenceList[0].TVType);
            Assert.IsNotNull(contactPreferenceList[0].MarkerSize);
            Assert.IsNotNull(contactPreferenceList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactPreferenceList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(contactPreferenceList[0].HasErrors);
        }
        private void CheckContactPreferenceExtraAFields(List<ContactPreferenceExtraA> contactPreferenceExtraAList)
        {
            Assert.IsNotNull(contactPreferenceExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(contactPreferenceExtraAList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceExtraAList[0].TVTypeText));
            }
            Assert.IsNotNull(contactPreferenceExtraAList[0].ContactPreferenceID);
            Assert.IsNotNull(contactPreferenceExtraAList[0].ContactID);
            Assert.IsNotNull(contactPreferenceExtraAList[0].TVType);
            Assert.IsNotNull(contactPreferenceExtraAList[0].MarkerSize);
            Assert.IsNotNull(contactPreferenceExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactPreferenceExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(contactPreferenceExtraAList[0].HasErrors);
        }
        private void CheckContactPreferenceExtraBFields(List<ContactPreferenceExtraB> contactPreferenceExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(contactPreferenceExtraBList[0].ContactPreferenceReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceExtraBList[0].ContactPreferenceReportTest));
            }
            Assert.IsNotNull(contactPreferenceExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(contactPreferenceExtraBList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactPreferenceExtraBList[0].TVTypeText));
            }
            Assert.IsNotNull(contactPreferenceExtraBList[0].ContactPreferenceID);
            Assert.IsNotNull(contactPreferenceExtraBList[0].ContactID);
            Assert.IsNotNull(contactPreferenceExtraBList[0].TVType);
            Assert.IsNotNull(contactPreferenceExtraBList[0].MarkerSize);
            Assert.IsNotNull(contactPreferenceExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(contactPreferenceExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(contactPreferenceExtraBList[0].HasErrors);
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
