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
    public partial class ContactLoginServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactLoginService contactLoginService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactLoginServiceTest() : base()
        {
            //contactLoginService = new ContactLoginService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactLogin GetFilledRandomContactLogin(string OmitPropName)
        {
            ContactLogin contactLogin = new ContactLogin();

            if (OmitPropName != "ContactID") contactLogin.ContactID = 1;
            if (OmitPropName != "LoginEmail") contactLogin.LoginEmail = GetRandomEmail();
            ContactService contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);

            Register register = new Register();
            register.Password = GetRandomPassword(); // the only thing needed for CreatePasswordHashAndSalt

            byte[] passwordHash;
            byte[] passwordSalt;
            contactService.CreatePasswordHashAndSalt(register, out passwordHash, out passwordSalt);

            if (OmitPropName != "PasswordHash") contactLogin.PasswordHash = passwordHash;
            if (OmitPropName != "PasswordSalt") contactLogin.PasswordSalt = passwordSalt;
            if (OmitPropName != "LastUpdateDate_UTC") contactLogin.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") contactLogin.LastUpdateContactTVItemID = 2;

            return contactLogin;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ContactLogin_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactLoginService contactLoginService = new ContactLoginService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ContactLogin contactLogin = GetFilledRandomContactLogin("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = contactLoginService.GetRead().Count();

                    Assert.AreEqual(contactLoginService.GetRead().Count(), contactLoginService.GetEdit().Count());

                    contactLoginService.Add(contactLogin);
                    if (contactLogin.HasErrors)
                    {
                        Assert.AreEqual("", contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, contactLoginService.GetRead().Where(c => c == contactLogin).Any());
                    contactLoginService.Update(contactLogin);
                    if (contactLogin.HasErrors)
                    {
                        Assert.AreEqual("", contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, contactLoginService.GetRead().Count());
                    contactLoginService.Delete(contactLogin);
                    if (contactLogin.HasErrors)
                    {
                        Assert.AreEqual("", contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, contactLoginService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // contactLogin.ContactLoginID   (Int32)
                    // -----------------------------------

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.ContactLoginID = 0;
                    contactLoginService.Update(contactLogin);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginContactLoginID), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.ContactLoginID = 10000000;
                    contactLoginService.Update(contactLogin);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ContactLogin, CSSPModelsRes.ContactLoginContactLoginID, contactLogin.ContactLoginID.ToString()), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID", AllowableTVtypeList = Error)]
                    // contactLogin.ContactID   (Int32)
                    // -----------------------------------

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.ContactID = 0;
                    contactLoginService.Add(contactLogin);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ContactLoginContactID, contactLogin.ContactID.ToString()), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [DataType(DataType.EmailAddress)]
                    // [StringLength(200))]
                    // contactLogin.LoginEmail   (String)
                    // -----------------------------------

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("LoginEmail");
                    Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                    Assert.AreEqual(1, contactLogin.ValidationResults.Count());
                    Assert.IsTrue(contactLogin.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginLoginEmail)).Any());
                    Assert.AreEqual(null, contactLogin.LoginEmail);
                    Assert.AreEqual(count, contactLoginService.GetRead().Count());

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.LoginEmail = GetRandomString("", 201);
                    Assert.AreEqual(false, contactLoginService.Add(contactLogin));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ContactLoginLoginEmail, "200"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, contactLoginService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // contactLogin.PasswordHash   (Byte[])
                    // -----------------------------------

                    //Error: Type not implemented [PasswordHash]

                    //Error: Type not implemented [PasswordHash]


                    // -----------------------------------
                    // Is NOT Nullable
                    // contactLogin.PasswordSalt   (Byte[])
                    // -----------------------------------

                    //Error: Type not implemented [PasswordSalt]

                    //Error: Type not implemented [PasswordSalt]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contactLogin.ContactLoginWeb   (ContactLoginWeb)
                    // -----------------------------------

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.ContactLoginWeb = null;
                    Assert.IsNull(contactLogin.ContactLoginWeb);

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.ContactLoginWeb = new ContactLoginWeb();
                    Assert.IsNotNull(contactLogin.ContactLoginWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // contactLogin.ContactLoginReport   (ContactLoginReport)
                    // -----------------------------------

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.ContactLoginReport = null;
                    Assert.IsNull(contactLogin.ContactLoginReport);

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.ContactLoginReport = new ContactLoginReport();
                    Assert.IsNotNull(contactLogin.ContactLoginReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // contactLogin.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.LastUpdateDate_UTC = new DateTime();
                    contactLoginService.Add(contactLogin);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ContactLoginLastUpdateDate_UTC), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);
                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    contactLoginService.Add(contactLogin);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ContactLoginLastUpdateDate_UTC, "1980"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // contactLogin.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.LastUpdateContactTVItemID = 0;
                    contactLoginService.Add(contactLogin);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ContactLoginLastUpdateContactTVItemID, contactLogin.LastUpdateContactTVItemID.ToString()), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);

                    contactLogin = null;
                    contactLogin = GetFilledRandomContactLogin("");
                    contactLogin.LastUpdateContactTVItemID = 1;
                    contactLoginService.Add(contactLogin);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ContactLoginLastUpdateContactTVItemID, "Contact"), contactLogin.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactLogin.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // contactLogin.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ContactLogin_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactLoginService contactLoginService = new ContactLoginService(LanguageRequest, dbTestDB, ContactID);
                    ContactLogin contactLogin = (from c in contactLoginService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(contactLogin);

                    ContactLogin contactLoginRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            contactLoginRet = contactLoginService.GetContactLoginWithContactLoginID(contactLogin.ContactLoginID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            contactLoginRet = contactLoginService.GetContactLoginWithContactLoginID(contactLogin.ContactLoginID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            contactLoginRet = contactLoginService.GetContactLoginWithContactLoginID(contactLogin.ContactLoginID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            contactLoginRet = contactLoginService.GetContactLoginWithContactLoginID(contactLogin.ContactLoginID, EntityQueryDetailTypeEnum.EntityReport);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // ContactLogin fields
                        Assert.IsNotNull(contactLoginRet.ContactLoginID);
                        Assert.IsNotNull(contactLoginRet.ContactID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(contactLoginRet.LoginEmail));
                        Assert.IsNotNull(contactLoginRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(contactLoginRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ContactLoginWeb and ContactLoginReport fields should be null here
                            Assert.IsNull(contactLoginRet.ContactLoginWeb);
                            Assert.IsNull(contactLoginRet.ContactLoginReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ContactLoginWeb fields should not be null and ContactLoginReport fields should be null here
                            if (contactLoginRet.ContactLoginWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactLoginRet.ContactLoginWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(contactLoginRet.ContactLoginReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ContactLoginWeb and ContactLoginReport fields should NOT be null here
                            if (contactLoginRet.ContactLoginWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactLoginRet.ContactLoginWeb.LastUpdateContactTVText));
                            }
                            if (contactLoginRet.ContactLoginReport.ContactLoginReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(contactLoginRet.ContactLoginReport.ContactLoginReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of ContactLogin
        #endregion Tests Get List of ContactLogin

    }
}
