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
    public partial class ContactShortcutTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int ContactShortcutID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactShortcut GetFilledRandomContactShortcut(string OmitPropName)
        {
            ContactShortcutID += 1;

            ContactShortcut contactShortcut = new ContactShortcut();

            if (OmitPropName != "ContactShortcutID") contactShortcut.ContactShortcutID = ContactShortcutID;
            if (OmitPropName != "ContactID") contactShortcut.ContactID = GetRandomInt(1, 11);
            if (OmitPropName != "ShortCutText") contactShortcut.ShortCutText = GetRandomString("", 5);
            if (OmitPropName != "ShortCutAddress") contactShortcut.ShortCutAddress = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") contactShortcut.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") contactShortcut.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return contactShortcut;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContactShortcut_Testing()
        {
            SetupTestHelper(culture);
            ContactShortcutService contactShortcutService = new ContactShortcutService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            ContactShortcut contactShortcut = GetFilledRandomContactShortcut("");
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(true, contactShortcutService.GetRead().Where(c => c == contactShortcut).Any());
            contactShortcut.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, contactShortcutService.Update(contactShortcut));
            Assert.AreEqual(1, contactShortcutService.GetRead().Count());
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // ContactID will automatically be initialized at 0 --> not null

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("ShortCutText");
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutText)).Any());
            Assert.AreEqual(null, contactShortcut.ShortCutText);
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("ShortCutAddress");
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutAddress)).Any());
            Assert.AreEqual(null, contactShortcut.ShortCutAddress);
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("LastUpdateDate_UTC");
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutLastUpdateDate_UTC)).Any());
            Assert.IsTrue(contactShortcut.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ContactShortcutID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactID] of type [int]
            //-----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            // ContactID has Min [1] and Max [empty]. At Min should return true and no errors
            contactShortcut.ContactID = 1;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(1, contactShortcut.ContactID);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactShortcut.ContactID = 2;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(2, contactShortcut.ContactID);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactShortcut.ContactID = 0;
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactShortcutContactID, "1")).Any());
            Assert.AreEqual(0, contactShortcut.ContactID);
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            //-----------------------------------
            // doing property [ShortCutText] of type [string]
            //-----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");

            // ShortCutText has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string contactShortcutShortCutTextMin = GetRandomString("", 100);
            contactShortcut.ShortCutText = contactShortcutShortCutTextMin;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(contactShortcutShortCutTextMin, contactShortcut.ShortCutText);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            // ShortCutText has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            contactShortcutShortCutTextMin = GetRandomString("", 99);
            contactShortcut.ShortCutText = contactShortcutShortCutTextMin;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(contactShortcutShortCutTextMin, contactShortcut.ShortCutText);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            // ShortCutText has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            contactShortcutShortCutTextMin = GetRandomString("", 101);
            contactShortcut.ShortCutText = contactShortcutShortCutTextMin;
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutText, "100")).Any());
            Assert.AreEqual(contactShortcutShortCutTextMin, contactShortcut.ShortCutText);
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            //-----------------------------------
            // doing property [ShortCutAddress] of type [string]
            //-----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");

            // ShortCutAddress has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string contactShortcutShortCutAddressMin = GetRandomString("", 200);
            contactShortcut.ShortCutAddress = contactShortcutShortCutAddressMin;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(contactShortcutShortCutAddressMin, contactShortcut.ShortCutAddress);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            // ShortCutAddress has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            contactShortcutShortCutAddressMin = GetRandomString("", 199);
            contactShortcut.ShortCutAddress = contactShortcutShortCutAddressMin;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(contactShortcutShortCutAddressMin, contactShortcut.ShortCutAddress);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            // ShortCutAddress has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            contactShortcutShortCutAddressMin = GetRandomString("", 201);
            contactShortcut.ShortCutAddress = contactShortcutShortCutAddressMin;
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutAddress, "200")).Any());
            Assert.AreEqual(contactShortcutShortCutAddressMin, contactShortcut.ShortCutAddress);
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            contactShortcut.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(1, contactShortcut.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactShortcut.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(2, contactShortcut.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactShortcut.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactShortcutLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, contactShortcut.LastUpdateContactTVItemID);
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
