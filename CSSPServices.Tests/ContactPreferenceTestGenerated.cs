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
    public partial class ContactPreferenceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int ContactPreferenceID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactPreference GetFilledRandomContactPreference(string OmitPropName)
        {
            ContactPreferenceID += 1;

            ContactPreference contactPreference = new ContactPreference();

            if (OmitPropName != "ContactPreferenceID") contactPreference.ContactPreferenceID = ContactPreferenceID;
            if (OmitPropName != "ContactID") contactPreference.ContactID = GetRandomInt(1, 11);
            if (OmitPropName != "TVType") contactPreference.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "MarkerSize") contactPreference.MarkerSize = GetRandomInt(1, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") contactPreference.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") contactPreference.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return contactPreference;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContactPreference_Testing()
        {
            SetupTestHelper(culture);
            ContactPreferenceService contactPreferenceService = new ContactPreferenceService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            ContactPreference contactPreference = GetFilledRandomContactPreference("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(true, contactPreferenceService.GetRead().Where(c => c == contactPreference).Any());
            contactPreference.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, contactPreferenceService.Update(contactPreference));
            Assert.AreEqual(1, contactPreferenceService.GetRead().Count());
            Assert.AreEqual(true, contactPreferenceService.Delete(contactPreference));
            Assert.AreEqual(0, contactPreferenceService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // ContactID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TVType]

            // MarkerSize will automatically be initialized at 0 --> not null

            contactPreference = null;
            contactPreference = GetFilledRandomContactPreference("LastUpdateDate_UTC");
            Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(1, contactPreference.ValidationResults.Count());
            Assert.IsTrue(contactPreference.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ContactPreferenceLastUpdateDate_UTC)).Any());
            Assert.IsTrue(contactPreference.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, contactPreferenceService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Contact]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ContactPreferenceID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactID] of type [Int32]
            //-----------------------------------

            contactPreference = null;
            contactPreference = GetFilledRandomContactPreference("");
            // ContactID has Min [1] and Max [empty]. At Min should return true and no errors
            contactPreference.ContactID = 1;
            Assert.AreEqual(true, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(0, contactPreference.ValidationResults.Count());
            Assert.AreEqual(1, contactPreference.ContactID);
            Assert.AreEqual(true, contactPreferenceService.Delete(contactPreference));
            Assert.AreEqual(0, contactPreferenceService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactPreference.ContactID = 2;
            Assert.AreEqual(true, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(0, contactPreference.ValidationResults.Count());
            Assert.AreEqual(2, contactPreference.ContactID);
            Assert.AreEqual(true, contactPreferenceService.Delete(contactPreference));
            Assert.AreEqual(0, contactPreferenceService.GetRead().Count());
            // ContactID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactPreference.ContactID = 0;
            Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
            Assert.IsTrue(contactPreference.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactPreferenceContactID, "1")).Any());
            Assert.AreEqual(0, contactPreference.ContactID);
            Assert.AreEqual(0, contactPreferenceService.GetRead().Count());

            //-----------------------------------
            // doing property [TVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [MarkerSize] of type [Int32]
            //-----------------------------------

            contactPreference = null;
            contactPreference = GetFilledRandomContactPreference("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            contactPreference = null;
            contactPreference = GetFilledRandomContactPreference("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            contactPreference.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(0, contactPreference.ValidationResults.Count());
            Assert.AreEqual(1, contactPreference.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactPreferenceService.Delete(contactPreference));
            Assert.AreEqual(0, contactPreferenceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            contactPreference.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, contactPreferenceService.Add(contactPreference));
            Assert.AreEqual(0, contactPreference.ValidationResults.Count());
            Assert.AreEqual(2, contactPreference.LastUpdateContactTVItemID);
            Assert.AreEqual(true, contactPreferenceService.Delete(contactPreference));
            Assert.AreEqual(0, contactPreferenceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            contactPreference.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, contactPreferenceService.Add(contactPreference));
            Assert.IsTrue(contactPreference.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactPreferenceLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, contactPreference.LastUpdateContactTVItemID);
            Assert.AreEqual(0, contactPreferenceService.GetRead().Count());

            //-----------------------------------
            // doing property [Contact] of type [Contact]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
