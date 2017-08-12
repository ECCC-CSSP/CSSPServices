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

            if (OmitPropName != "ContactID") contactShortcut.ContactID = 1;
            if (OmitPropName != "ShortCutText") contactShortcut.ShortCutText = GetRandomString("", 5);
            if (OmitPropName != "ShortCutAddress") contactShortcut.ShortCutAddress = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") contactShortcut.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactShortcut.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") contactShortcut.LastUpdateContactTVText = GetRandomString("", 5);
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutContactShortcutID), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                contactShortcut = null;
                contactShortcut = GetFilledRandomContactShortcut("");
                contactShortcut.ContactShortcutID = 10000000;
                contactShortcutService.Update(contactShortcut);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.ContactShortcut, ModelsRes.ContactShortcutContactShortcutID, contactShortcut.ContactShortcutID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = Error)]
                // contactShortcut.ContactID   (Int32)
                // -----------------------------------

                contactShortcut = null;
                contactShortcut = GetFilledRandomContactShortcut("");
                contactShortcut.ContactID = 0;
                contactShortcutService.Add(contactShortcut);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ContactShortcutContactID, contactShortcut.ContactID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [StringLength(100))]
                // contactShortcut.ShortCutText   (String)
                // -----------------------------------

                contactShortcut = null;
                contactShortcut = GetFilledRandomContactShortcut("ShortCutText");
                Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
                Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutText)).Any());
                Assert.AreEqual(null, contactShortcut.ShortCutText);
                Assert.AreEqual(count, contactShortcutService.GetRead().Count());

                contactShortcut = null;
                contactShortcut = GetFilledRandomContactShortcut("");
                contactShortcut.ShortCutText = GetRandomString("", 101);
                Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutText, "100"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutAddress)).Any());
                Assert.AreEqual(null, contactShortcut.ShortCutAddress);
                Assert.AreEqual(count, contactShortcutService.GetRead().Count());

                contactShortcut = null;
                contactShortcut = GetFilledRandomContactShortcut("");
                contactShortcut.ShortCutAddress = GetRandomString("", 201);
                Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutAddress, "200"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactShortcutService.GetRead().Count());

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
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ContactShortcutLastUpdateContactTVItemID, contactShortcut.LastUpdateContactTVItemID.ToString()), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

                contactShortcut = null;
                contactShortcut = GetFilledRandomContactShortcut("");
                contactShortcut.LastUpdateContactTVItemID = 1;
                contactShortcutService.Add(contactShortcut);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ContactShortcutLastUpdateContactTVItemID, "Contact"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // contactShortcut.LastUpdateContactTVText   (String)
                // -----------------------------------

                contactShortcut = null;
                contactShortcut = GetFilledRandomContactShortcut("");
                contactShortcut.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutLastUpdateContactTVText, "200"), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, contactShortcutService.GetRead().Count());

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
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ContactShortcut_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                ContactShortcutService contactShortcutService = new ContactShortcutService(LanguageRequest, dbTestDB, ContactID);
                ContactShortcut contactShortcut = (from c in contactShortcutService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(contactShortcut);

                ContactShortcut contactShortcutRet = contactShortcutService.GetContactShortcutWithContactShortcutID(contactShortcut.ContactShortcutID);
                Assert.IsNotNull(contactShortcutRet.ContactShortcutID);
                Assert.IsNotNull(contactShortcutRet.ContactID);
                Assert.IsNotNull(contactShortcutRet.ShortCutText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutRet.ShortCutText));
                Assert.IsNotNull(contactShortcutRet.ShortCutAddress);
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutRet.ShortCutAddress));
                Assert.IsNotNull(contactShortcutRet.LastUpdateDate_UTC);
                Assert.IsNotNull(contactShortcutRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(contactShortcutRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(contactShortcutRet.LastUpdateContactTVText));
                Assert.IsNotNull(contactShortcutRet.HasErrors);
            }
        }
        #endregion Tests Get With Key

    }
}
