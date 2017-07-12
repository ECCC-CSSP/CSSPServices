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
    public partial class EmailDistributionListContactTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int EmailDistributionListContactID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private EmailDistributionListContact GetFilledRandomEmailDistributionListContact(string OmitPropName)
        {
            EmailDistributionListContactID += 1;

            EmailDistributionListContact emailDistributionListContact = new EmailDistributionListContact();

            if (OmitPropName != "EmailDistributionListContactID") emailDistributionListContact.EmailDistributionListContactID = EmailDistributionListContactID;
            if (OmitPropName != "EmailDistributionListID") emailDistributionListContact.EmailDistributionListID = GetRandomInt(1, 11);
            if (OmitPropName != "IsCC") emailDistributionListContact.IsCC = true;
            if (OmitPropName != "Agency") emailDistributionListContact.Agency = GetRandomString("", 5);
            if (OmitPropName != "Name") emailDistributionListContact.Name = GetRandomString("", 5);
            if (OmitPropName != "Email") emailDistributionListContact.Email = GetRandomEmail();
            if (OmitPropName != "CMPRainfallSeasonal") emailDistributionListContact.CMPRainfallSeasonal = true;
            if (OmitPropName != "CMPWastewater") emailDistributionListContact.CMPWastewater = true;
            if (OmitPropName != "EmergencyWeather") emailDistributionListContact.EmergencyWeather = true;
            if (OmitPropName != "EmergencyWastewater") emailDistributionListContact.EmergencyWastewater = true;
            if (OmitPropName != "ReopeningAllTypes") emailDistributionListContact.ReopeningAllTypes = true;
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListContact.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListContact.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return emailDistributionListContact;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void EmailDistributionListContact_Testing()
        {
            SetupTestHelper(culture);
            EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            EmailDistributionListContact emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(true, emailDistributionListContactService.GetRead().Where(c => c == emailDistributionListContact).Any());
            emailDistributionListContact.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, emailDistributionListContactService.Update(emailDistributionListContact));
            Assert.AreEqual(1, emailDistributionListContactService.GetRead().Count());
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // EmailDistributionListID will automatically be initialized at 0 --> not null

            // IsCC will automatically be initialized at 0 --> not null

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("Agency");
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactAgency)).Any());
            Assert.AreEqual(null, emailDistributionListContact.Agency);
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("Name");
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactName)).Any());
            Assert.AreEqual(null, emailDistributionListContact.Name);
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("Email");
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactEmail)).Any());
            Assert.AreEqual(null, emailDistributionListContact.Email);
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            // CMPRainfallSeasonal will automatically be initialized at 0 --> not null

            // CMPWastewater will automatically be initialized at 0 --> not null

            // EmergencyWeather will automatically be initialized at 0 --> not null

            // EmergencyWastewater will automatically be initialized at 0 --> not null

            // ReopeningAllTypes will automatically be initialized at 0 --> not null

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("LastUpdateDate_UTC");
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactLastUpdateDate_UTC)).Any());
            Assert.IsTrue(emailDistributionListContact.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [EmailDistributionList]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [EmailDistributionListContactID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [EmailDistributionListID] of type [Int32]
            //-----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
            // EmailDistributionListID has Min [1] and Max [empty]. At Min should return true and no errors
            emailDistributionListContact.EmailDistributionListID = 1;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(1, emailDistributionListContact.EmailDistributionListID);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());
            // EmailDistributionListID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            emailDistributionListContact.EmailDistributionListID = 2;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(2, emailDistributionListContact.EmailDistributionListID);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());
            // EmailDistributionListID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            emailDistributionListContact.EmailDistributionListID = 0;
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailDistributionListContactEmailDistributionListID, "1")).Any());
            Assert.AreEqual(0, emailDistributionListContact.EmailDistributionListID);
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            //-----------------------------------
            // doing property [IsCC] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [Agency] of type [String]
            //-----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");

            //-----------------------------------
            // doing property [Name] of type [String]
            //-----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");

            //-----------------------------------
            // doing property [Email] of type [String]
            //-----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");

            //-----------------------------------
            // doing property [CMPRainfallSeasonal] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [CMPWastewater] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [EmergencyWeather] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [EmergencyWastewater] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [ReopeningAllTypes] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            emailDistributionListContact.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(1, emailDistributionListContact.LastUpdateContactTVItemID);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            emailDistributionListContact.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(2, emailDistributionListContact.LastUpdateContactTVItemID);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            emailDistributionListContact.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, emailDistributionListContact.LastUpdateContactTVItemID);
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            //-----------------------------------
            // doing property [EmailDistributionList] of type [EmailDistributionList]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
