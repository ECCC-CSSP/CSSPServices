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
        private EmailDistributionListContactService emailDistributionListContactService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactTest() : base()
        {
            emailDistributionListContactService = new EmailDistributionListContactService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private EmailDistributionListContact GetFilledRandomEmailDistributionListContact(string OmitPropName)
        {
            EmailDistributionListContact emailDistributionListContact = new EmailDistributionListContact();

            if (OmitPropName != "EmailDistributionListID") emailDistributionListContact.EmailDistributionListID = 1;
            if (OmitPropName != "IsCC") emailDistributionListContact.IsCC = true;
            if (OmitPropName != "Agency") emailDistributionListContact.Agency = GetRandomString("", 5);
            if (OmitPropName != "Name") emailDistributionListContact.Name = GetRandomString("", 5);
            if (OmitPropName != "Email") emailDistributionListContact.Email = GetRandomEmail();
            if (OmitPropName != "CMPRainfallSeasonal") emailDistributionListContact.CMPRainfallSeasonal = true;
            if (OmitPropName != "CMPWastewater") emailDistributionListContact.CMPWastewater = true;
            if (OmitPropName != "EmergencyWeather") emailDistributionListContact.EmergencyWeather = true;
            if (OmitPropName != "EmergencyWastewater") emailDistributionListContact.EmergencyWastewater = true;
            if (OmitPropName != "ReopeningAllTypes") emailDistributionListContact.ReopeningAllTypes = true;
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListContact.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListContact.LastUpdateContactTVItemID = 2;

            return emailDistributionListContact;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void EmailDistributionListContact_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            EmailDistributionListContact emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = emailDistributionListContactService.GetRead().Count();

            emailDistributionListContactService.Add(emailDistributionListContact);
            if (emailDistributionListContact.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, emailDistributionListContactService.GetRead().Where(c => c == emailDistributionListContact).Any());
            emailDistributionListContactService.Update(emailDistributionListContact);
            if (emailDistributionListContact.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, emailDistributionListContactService.GetRead().Count());
            emailDistributionListContactService.Delete(emailDistributionListContact);
            if (emailDistributionListContact.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // emailDistributionListContact.EmailDistributionListContactID   (Int32)
            // -----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
            emailDistributionListContact.EmailDistributionListContactID = 0;
            emailDistributionListContactService.Update(emailDistributionListContact);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactEmailDistributionListContactID), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "EmailDistributionList", Plurial = "s", FieldID = "EmailDistributionListID", TVType = TVTypeEnum.Error)]
            // emailDistributionListContact.EmailDistributionListID   (Int32)
            // -----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
            emailDistributionListContact.EmailDistributionListID = 0;
            emailDistributionListContactService.Add(emailDistributionListContact);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.EmailDistributionList, ModelsRes.EmailDistributionListContactEmailDistributionListID, emailDistributionListContact.EmailDistributionListID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

            // EmailDistributionListID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // emailDistributionListContact.IsCC   (Boolean)
            // -----------------------------------

            // IsCC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(20))]
            // emailDistributionListContact.Agency   (String)
            // -----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("Agency");
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactAgency)).Any());
            Assert.AreEqual(null, emailDistributionListContact.Agency);
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
            // Agency has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string emailDistributionListContactAgencyMin = GetRandomString("", 20);
            emailDistributionListContact.Agency = emailDistributionListContactAgencyMin;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(emailDistributionListContactAgencyMin, emailDistributionListContact.Agency);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

            // Agency has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            emailDistributionListContactAgencyMin = GetRandomString("", 19);
            emailDistributionListContact.Agency = emailDistributionListContactAgencyMin;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(emailDistributionListContactAgencyMin, emailDistributionListContact.Agency);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

            // Agency has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            emailDistributionListContactAgencyMin = GetRandomString("", 21);
            emailDistributionListContact.Agency = emailDistributionListContactAgencyMin;
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactAgency, "20")).Any());
            Assert.AreEqual(emailDistributionListContactAgencyMin, emailDistributionListContact.Agency);
            Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // emailDistributionListContact.Name   (String)
            // -----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("Name");
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactName)).Any());
            Assert.AreEqual(null, emailDistributionListContact.Name);
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
            // Name has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string emailDistributionListContactNameMin = GetRandomString("", 100);
            emailDistributionListContact.Name = emailDistributionListContactNameMin;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(emailDistributionListContactNameMin, emailDistributionListContact.Name);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

            // Name has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            emailDistributionListContactNameMin = GetRandomString("", 99);
            emailDistributionListContact.Name = emailDistributionListContactNameMin;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(emailDistributionListContactNameMin, emailDistributionListContact.Name);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

            // Name has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            emailDistributionListContactNameMin = GetRandomString("", 101);
            emailDistributionListContact.Name = emailDistributionListContactNameMin;
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactName, "100")).Any());
            Assert.AreEqual(emailDistributionListContactNameMin, emailDistributionListContact.Name);
            Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [DataType(DataType.EmailAddress)]
            // [StringLength(200))]
            // emailDistributionListContact.Email   (String)
            // -----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("Email");
            Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
            Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListContactEmail)).Any());
            Assert.AreEqual(null, emailDistributionListContact.Email);
            Assert.AreEqual(0, emailDistributionListContactService.GetRead().Count());

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
            // Email has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string emailDistributionListContactEmailMin = GetRandomEmail();
            emailDistributionListContact.Email = emailDistributionListContactEmailMin;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(emailDistributionListContactEmailMin, emailDistributionListContact.Email);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

            // Email has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            emailDistributionListContactEmailMin = GetRandomEmail();
            emailDistributionListContact.Email = emailDistributionListContactEmailMin;
            Assert.AreEqual(true, emailDistributionListContactService.Add(emailDistributionListContact));
            Assert.AreEqual(0, emailDistributionListContact.ValidationResults.Count());
            Assert.AreEqual(emailDistributionListContactEmailMin, emailDistributionListContact.Email);
            Assert.AreEqual(true, emailDistributionListContactService.Delete(emailDistributionListContact));
            Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // emailDistributionListContact.CMPRainfallSeasonal   (Boolean)
            // -----------------------------------

            // CMPRainfallSeasonal will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // emailDistributionListContact.CMPWastewater   (Boolean)
            // -----------------------------------

            // CMPWastewater will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // emailDistributionListContact.EmergencyWeather   (Boolean)
            // -----------------------------------

            // EmergencyWeather will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // emailDistributionListContact.EmergencyWastewater   (Boolean)
            // -----------------------------------

            // EmergencyWastewater will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // emailDistributionListContact.ReopeningAllTypes   (Boolean)
            // -----------------------------------

            // ReopeningAllTypes will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // emailDistributionListContact.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // emailDistributionListContact.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            emailDistributionListContact = null;
            emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
            emailDistributionListContact.LastUpdateContactTVItemID = 0;
            emailDistributionListContactService.Add(emailDistributionListContact);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, emailDistributionListContact.LastUpdateContactTVItemID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // emailDistributionListContact.EmailDistributionList   (EmailDistributionList)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // emailDistributionListContact.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
