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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactShortcut GetFilledRandomContactShortcut(string OmitPropName)
        {
            ContactShortcut contactShortcut = new ContactShortcut();

            // Need to implement (no items found, would need to add at least one in the TestDB) [ContactShortcut ContactID Contact ContactID]
            if (OmitPropName != "ShortCutText") contactShortcut.ShortCutText = GetRandomString("", 5);
            if (OmitPropName != "ShortCutAddress") contactShortcut.ShortCutAddress = GetRandomString("", 5);
            //Error: property [ContactShortcutWeb] and type [ContactShortcut] is  not implemented
            //Error: property [ContactShortcutReport] and type [ContactShortcut] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") contactShortcut.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactShortcut.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") contactShortcut.HasErrors = true;

            return contactShortcut;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ContactShortcut_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(LanguageRequest, dbTestDB, ContactID);

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
                    // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = Error)]
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

                    //Error: Type not implemented [ContactShortcutWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contactShortcut.ContactShortcutReport   (ContactShortcutReport)
                    // -----------------------------------

                    //Error: Type not implemented [ContactShortcutReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contactShortcut.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


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


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactShortcut.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ContactShortcut_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactShortcutService contactShortcutService = new ContactShortcutService(LanguageRequest, dbTestDB, ContactID);
                    ContactShortcut contactShortcut = (from c in contactShortcutService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(contactShortcut);

                    ContactShortcut contactShortcutRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            contactShortcutRet = contactShortcutService.GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactShortcutRet = contactShortcutService.GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactShortcutRet = contactShortcutService.GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(contactShortcutRet.ContactShortcutID);
                        Assert.IsNotNull(contactShortcutRet.ContactID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutRet.ShortCutText));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutRet.ShortCutAddress));
                        Assert.IsNotNull(contactShortcutRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(contactShortcutRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (contactShortcutRet.ContactShortcutWeb != null)
                            {
                                Assert.IsNull(contactShortcutRet.ContactShortcutWeb);
                            }
                            if (contactShortcutRet.ContactShortcutReport != null)
                            {
                                Assert.IsNull(contactShortcutRet.ContactShortcutReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (contactShortcutRet.ContactShortcutWeb != null)
                            {
                                Assert.IsNotNull(contactShortcutRet.ContactShortcutWeb);
                            }
                            if (contactShortcutRet.ContactShortcutReport != null)
                            {
                                Assert.IsNotNull(contactShortcutRet.ContactShortcutReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of ContactShortcut
        #endregion Tests Get List of ContactShortcut

    }
}
