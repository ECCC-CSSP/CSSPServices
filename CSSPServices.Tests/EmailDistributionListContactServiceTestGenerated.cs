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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void EmailDistributionListContact_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new GetParam(), dbTestDB, ContactID);

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

                    Assert.AreEqual(emailDistributionListContactService.GetRead().Count(), emailDistributionListContactService.GetEdit().Count());

                    emailDistributionListContactService.Add(emailDistributionListContact);
                    if (emailDistributionListContact.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailDistributionListContactService.GetRead().Where(c => c == emailDistributionListContact).Any());
                    emailDistributionListContactService.Update(emailDistributionListContact);
                    if (emailDistributionListContact.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailDistributionListContactService.GetRead().Count());
                    emailDistributionListContactService.Delete(emailDistributionListContact);
                    if (emailDistributionListContact.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactEmailDistributionListContactID), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactID = 10000000;
                    emailDistributionListContactService.Update(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionListContact, CSSPModelsRes.EmailDistributionListContactEmailDistributionListContactID, emailDistributionListContact.EmailDistributionListContactID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID", AllowableTVtypeList = Error)]
                    // emailDistributionListContact.EmailDistributionListID   (Int32)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListID = 0;
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionList, CSSPModelsRes.EmailDistributionListContactEmailDistributionListID, emailDistributionListContact.EmailDistributionListID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // emailDistributionListContact.IsCC   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // emailDistributionListContact.Name   (String)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("Name");
                    Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                    Assert.AreEqual(1, emailDistributionListContact.ValidationResults.Count());
                    Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactName)).Any());
                    Assert.AreEqual(null, emailDistributionListContact.Name);
                    Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.Name = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailDistributionListContactName, "100"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(emailDistributionListContact.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactEmail)).Any());
                    Assert.AreEqual(null, emailDistributionListContact.Email);
                    Assert.AreEqual(count, emailDistributionListContactService.GetRead().Count());

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.Email = GetRandomString("", 201);
                    Assert.AreEqual(false, emailDistributionListContactService.Add(emailDistributionListContact));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.EmailDistributionListContactEmail, "200"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionListContact.EmailDistributionListContactWeb   (EmailDistributionListContactWeb)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactWeb = null;
                    Assert.IsNull(emailDistributionListContact.EmailDistributionListContactWeb);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactWeb = new EmailDistributionListContactWeb();
                    Assert.IsNotNull(emailDistributionListContact.EmailDistributionListContactWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionListContact.EmailDistributionListContactReport   (EmailDistributionListContactReport)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactReport = null;
                    Assert.IsNull(emailDistributionListContact.EmailDistributionListContactReport);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.EmailDistributionListContactReport = new EmailDistributionListContactReport();
                    Assert.IsNotNull(emailDistributionListContact.EmailDistributionListContactReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionListContact.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListContactLastUpdateDate_UTC), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailDistributionListContactLastUpdateDate_UTC, "1980"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionListContact.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateContactTVItemID = 0;
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, emailDistributionListContact.LastUpdateContactTVItemID.ToString()), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListContact = null;
                    emailDistributionListContact = GetFilledRandomEmailDistributionListContact("");
                    emailDistributionListContact.LastUpdateContactTVItemID = 1;
                    emailDistributionListContactService.Add(emailDistributionListContact);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailDistributionListContactLastUpdateContactTVItemID, "Contact"), emailDistributionListContact.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListContact.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListContact.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    EmailDistributionListContactService emailDistributionListContactService = new EmailDistributionListContactService(new GetParam(), dbTestDB, ContactID);
                    EmailDistributionListContact emailDistributionListContact = (from c in emailDistributionListContactService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListContact);

                    EmailDistributionListContact emailDistributionListContactRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID, getParam);
                            Assert.IsNull(emailDistributionListContactRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListContactRet = emailDistributionListContactService.GetEmailDistributionListContactWithEmailDistributionListContactID(emailDistributionListContact.EmailDistributionListContactID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // EmailDistributionListContact fields
                        Assert.IsNotNull(emailDistributionListContactRet.EmailDistributionListContactID);
                        Assert.IsNotNull(emailDistributionListContactRet.EmailDistributionListID);
                        Assert.IsNotNull(emailDistributionListContactRet.IsCC);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactRet.Name));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactRet.Email));
                        Assert.IsNotNull(emailDistributionListContactRet.CMPRainfallSeasonal);
                        Assert.IsNotNull(emailDistributionListContactRet.CMPWastewater);
                        Assert.IsNotNull(emailDistributionListContactRet.EmergencyWeather);
                        Assert.IsNotNull(emailDistributionListContactRet.EmergencyWastewater);
                        Assert.IsNotNull(emailDistributionListContactRet.ReopeningAllTypes);
                        Assert.IsNotNull(emailDistributionListContactRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(emailDistributionListContactRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // EmailDistributionListContactWeb and EmailDistributionListContactReport fields should be null here
                            Assert.IsNull(emailDistributionListContactRet.EmailDistributionListContactWeb);
                            Assert.IsNull(emailDistributionListContactRet.EmailDistributionListContactReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // EmailDistributionListContactWeb fields should not be null and EmailDistributionListContactReport fields should be null here
                            if (emailDistributionListContactRet.EmailDistributionListContactWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactRet.EmailDistributionListContactWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(emailDistributionListContactRet.EmailDistributionListContactReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // EmailDistributionListContactWeb and EmailDistributionListContactReport fields should NOT be null here
                            if (emailDistributionListContactRet.EmailDistributionListContactWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactRet.EmailDistributionListContactWeb.LastUpdateContactTVText));
                            }
                            if (emailDistributionListContactRet.EmailDistributionListContactReport.EmailDistributionListContactReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListContactRet.EmailDistributionListContactReport.EmailDistributionListContactReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of EmailDistributionListContact
        #endregion Tests Get List of EmailDistributionListContact

    }
}
