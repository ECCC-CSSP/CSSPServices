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
    public partial class EmailTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int EmailID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public EmailTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Email GetFilledRandomEmail(string OmitPropName)
        {
            EmailID += 1;

            Email email = new Email();

            if (OmitPropName != "EmailID") email.EmailID = EmailID;
            if (OmitPropName != "EmailTVItemID") email.EmailTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "EmailAddress") email.EmailAddress = GetRandomEmail();
            if (OmitPropName != "EmailType") email.EmailType = (EmailTypeEnum)GetRandomEnumType(typeof(EmailTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") email.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") email.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return email;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Email_Testing()
        {
            SetupTestHelper(culture);
            EmailService emailService = new EmailService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            Email email = GetFilledRandomEmail("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, emailService.Add(email));
            Assert.AreEqual(true, emailService.GetRead().Where(c => c == email).Any());
            email.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, emailService.Update(email));
            Assert.AreEqual(1, emailService.GetRead().Count());
            Assert.AreEqual(true, emailService.Delete(email));
            Assert.AreEqual(0, emailService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // EmailTVItemID will automatically be initialized at 0 --> not null

            email = null;
            email = GetFilledRandomEmail("EmailAddress");
            Assert.AreEqual(false, emailService.Add(email));
            Assert.AreEqual(1, email.ValidationResults.Count());
            Assert.IsTrue(email.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailEmailAddress)).Any());
            Assert.AreEqual(null, email.EmailAddress);
            Assert.AreEqual(0, emailService.GetRead().Count());

            //Error: Type not implemented [EmailType]

            email = null;
            email = GetFilledRandomEmail("LastUpdateDate_UTC");
            Assert.AreEqual(false, emailService.Add(email));
            Assert.AreEqual(1, email.ValidationResults.Count());
            Assert.IsTrue(email.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailLastUpdateDate_UTC)).Any());
            Assert.IsTrue(email.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, emailService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [EmailTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [EmailID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [EmailTVItemID] of type [Int32]
            //-----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            // EmailTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            email.EmailTVItemID = 1;
            Assert.AreEqual(true, emailService.Add(email));
            Assert.AreEqual(0, email.ValidationResults.Count());
            Assert.AreEqual(1, email.EmailTVItemID);
            Assert.AreEqual(true, emailService.Delete(email));
            Assert.AreEqual(0, emailService.GetRead().Count());
            // EmailTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            email.EmailTVItemID = 2;
            Assert.AreEqual(true, emailService.Add(email));
            Assert.AreEqual(0, email.ValidationResults.Count());
            Assert.AreEqual(2, email.EmailTVItemID);
            Assert.AreEqual(true, emailService.Delete(email));
            Assert.AreEqual(0, emailService.GetRead().Count());
            // EmailTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            email.EmailTVItemID = 0;
            Assert.AreEqual(false, emailService.Add(email));
            Assert.IsTrue(email.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailEmailTVItemID, "1")).Any());
            Assert.AreEqual(0, email.EmailTVItemID);
            Assert.AreEqual(0, emailService.GetRead().Count());

            //-----------------------------------
            // doing property [EmailAddress] of type [String]
            //-----------------------------------

            email = null;
            email = GetFilledRandomEmail("");

            //-----------------------------------
            // doing property [EmailType] of type [EmailTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            email.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, emailService.Add(email));
            Assert.AreEqual(0, email.ValidationResults.Count());
            Assert.AreEqual(1, email.LastUpdateContactTVItemID);
            Assert.AreEqual(true, emailService.Delete(email));
            Assert.AreEqual(0, emailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            email.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, emailService.Add(email));
            Assert.AreEqual(0, email.ValidationResults.Count());
            Assert.AreEqual(2, email.LastUpdateContactTVItemID);
            Assert.AreEqual(true, emailService.Delete(email));
            Assert.AreEqual(0, emailService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            email.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, emailService.Add(email));
            Assert.IsTrue(email.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, email.LastUpdateContactTVItemID);
            Assert.AreEqual(0, emailService.GetRead().Count());

            //-----------------------------------
            // doing property [EmailTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
