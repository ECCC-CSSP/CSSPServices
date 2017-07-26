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
        private ContactShortcutService contactShortcutService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutTest() : base()
        {
            contactShortcutService = new ContactShortcutService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "LastUpdateDate_UTC") contactShortcut.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") contactShortcut.LastUpdateContactTVItemID = 2;

            return contactShortcut;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContactShortcut_Testing()
        {

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

            contactShortcutService.Add(contactShortcut);
            if (contactShortcut.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, contactShortcutService.GetRead().Where(c => c == contactShortcut).Any());
            contactShortcutService.Update(contactShortcut);
            if (contactShortcut.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, contactShortcutService.GetRead().Count());
            contactShortcutService.Delete(contactShortcut);
            if (contactShortcut.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // contactShortcut.ContactShortcutID   (Int32)
            //-----------------------------------
            contactShortcut = GetFilledRandomContactShortcut("");
            contactShortcut.ContactShortcutID = 0;
            contactShortcutService.Update(contactShortcut);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutContactShortcutID), contactShortcut.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "Contact", Plurial = "s", FieldID = "ContactID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // contactShortcut.ContactID   (Int32)
            //-----------------------------------
            // ContactID will automatically be initialized at 0 --> not null


            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            // ContactID has Min [1] and Max [empty]. At Min should return true and no errors
            contactShortcut.ContactID = 1;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(1, contactShortcut.ContactID);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactShortcut.ContactID = 2;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(2, contactShortcut.ContactID);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactShortcut.ContactID = 0;
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactShortcutContactID, "1")).Any());
            Assert.AreEqual(0, contactShortcut.ContactID);
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(100))]
            // contactShortcut.ShortCutText   (String)
            //-----------------------------------
            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("ShortCutText");
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutText)).Any());
            Assert.AreEqual(null, contactShortcut.ShortCutText);
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());


            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");

            // ShortCutText has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string contactShortcutShortCutTextMin = GetRandomString("", 100);
            contactShortcut.ShortCutText = contactShortcutShortCutTextMin;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(contactShortcutShortCutTextMin, contactShortcut.ShortCutText);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());

            // ShortCutText has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            contactShortcutShortCutTextMin = GetRandomString("", 99);
            contactShortcut.ShortCutText = contactShortcutShortCutTextMin;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(contactShortcutShortCutTextMin, contactShortcut.ShortCutText);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());

            // ShortCutText has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            contactShortcutShortCutTextMin = GetRandomString("", 101);
            contactShortcut.ShortCutText = contactShortcutShortCutTextMin;
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutText, "100")).Any());
            Assert.AreEqual(contactShortcutShortCutTextMin, contactShortcut.ShortCutText);
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(200))]
            // contactShortcut.ShortCutAddress   (String)
            //-----------------------------------
            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("ShortCutAddress");
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(1, contactShortcut.ValidationResults.Count());
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactShortcutShortCutAddress)).Any());
            Assert.AreEqual(null, contactShortcut.ShortCutAddress);
            Assert.AreEqual(0, contactShortcutService.GetRead().Count());


            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");

            // ShortCutAddress has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string contactShortcutShortCutAddressMin = GetRandomString("", 200);
            contactShortcut.ShortCutAddress = contactShortcutShortCutAddressMin;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(contactShortcutShortCutAddressMin, contactShortcut.ShortCutAddress);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());

            // ShortCutAddress has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            contactShortcutShortCutAddressMin = GetRandomString("", 199);
            contactShortcut.ShortCutAddress = contactShortcutShortCutAddressMin;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(contactShortcutShortCutAddressMin, contactShortcut.ShortCutAddress);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());

            // ShortCutAddress has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            contactShortcutShortCutAddressMin = GetRandomString("", 201);
            contactShortcut.ShortCutAddress = contactShortcutShortCutAddressMin;
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactShortcutShortCutAddress, "200")).Any());
            Assert.AreEqual(contactShortcutShortCutAddressMin, contactShortcut.ShortCutAddress);
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // contactShortcut.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // contactShortcut.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            contactShortcut = null;
            contactShortcut = GetFilledRandomContactShortcut("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            contactShortcut.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(1, contactShortcut.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactShortcut.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, contactShortcutService.Add(contactShortcut));
            Assert.AreEqual(0, contactShortcut.ValidationResults.Count());
            Assert.AreEqual(2, contactShortcut.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactShortcutService.Delete(contactShortcut));
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactShortcut.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, contactShortcutService.Add(contactShortcut));
            Assert.IsTrue(contactShortcut.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactShortcutLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, contactShortcut.LastUpdateContactTVItemID);
            Assert.AreEqual(count, contactShortcutService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // contactShortcut.Contact   (Contact)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // contactShortcut.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
