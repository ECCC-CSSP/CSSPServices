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
    public partial class EmailDistributionListContactServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private EmailDistributionListContactService emailDistributionListContactService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactServiceTest() : base()
        {
            //emailDistributionListContactService = new EmailDistributionListContactService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "LastUpdateContactTVText") emailDistributionListContact.LastUpdateContactTVText = GetRandomString("", 5);

            return emailDistributionListContact;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void EmailDistributionListContact_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(LanguageRequest, dbTestDB, ContactID);

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
                // [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID", AllowableTVtypeList = Error)]
                // emailDistributionListContact.EmailDistributionListID   (Int32)
                // -----------------------------------

                emailDistributionListContact = null;
                emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                emailDistributionListContact.EmailDistributionListID = 0;
                emailDistributionListContactService.Add(emailDistributionListContact);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.EmailDistributionList, ModelsRes.EmailDistributionListContactEmailDistributionListID, emailDistributionListContact.EmailDistributionListID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // emailDistributionListContact.IsCC   (Boolean)
                // -----------------------------------


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
                Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

                emailDistributionListContact = null;
                emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                emailDistributionListContact.Agency = GetRandomString("", 21);
                Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactAgency, "20"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

                emailDistributionListContact = null;
                emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                emailDistributionListContact.Name = GetRandomString("", 101);
                Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactName, "100"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

                emailDistributionListContact = null;
                emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                emailDistributionListContact.Email = GetRandomString("", 201);
                Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactEmail, "200"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // emailDistributionListContact.CMPRainfallSeasonal   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // emailDistributionListContact.CMPWastewater   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // emailDistributionListContact.EmergencyWeather   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // emailDistributionListContact.EmergencyWastewater   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // emailDistributionListContact.ReopeningAllTypes   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // emailDistributionListContact.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // emailDistributionListContact.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                emailDistributionListContact = null;
                emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                emailDistributionListContact.LastUpdateContactTVItemID = 0;
                emailDistributionListContactService.Add(emailDistributionListContact);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, emailDistributionListContact.LastUpdateContactTVItemID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                emailDistributionListContact = null;
                emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                emailDistributionListContact.LastUpdateContactTVItemID = 1;
                emailDistributionListContactService.Add(emailDistributionListContact);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, "Contact"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // emailDistributionListContact.LastUpdateContactTVText   (String)
                // -----------------------------------

                emailDistributionListContact = null;
                emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                emailDistributionListContact.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListContactLastUpdateContactTVText, "200"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // emailDistributionListContact.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void EmailDistributionListContact_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(LanguageRequest, dbTestDB, ContactID);
                EmailDistributionListContact emailDistributionListContact = (from c in emailDistributionListContactService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(emailDistributionListContact);

                EmailDistributionListContact emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID);
                Assert.IsNotNull(emailDistributionListContactRet.EmailDistributionListContactID);
                Assert.IsNotNull(emailDistributionListContactRet.EmailDistributionListID);
                Assert.IsNotNull(emailDistributionListContactRet.IsCC);
                Assert.IsNotNull(emailDistributionListContactRet.Agency);
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactRet.Agency));
                Assert.IsNotNull(emailDistributionListContactRet.Name);
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactRet.Name));
                Assert.IsNotNull(emailDistributionListContactRet.Email);
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactRet.Email));
                Assert.IsNotNull(emailDistributionListContactRet.CMPRainfallSeasonal);
                Assert.IsNotNull(emailDistributionListContactRet.CMPWastewater);
                Assert.IsNotNull(emailDistributionListContactRet.EmergencyWeather);
                Assert.IsNotNull(emailDistributionListContactRet.EmergencyWastewater);
                Assert.IsNotNull(emailDistributionListContactRet.ReopeningAllTypes);
                Assert.IsNotNull(emailDistributionListContactRet.LastUpdateDate_UTC);
                Assert.IsNotNull(emailDistributionListContactRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(emailDistributionListContactRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}
