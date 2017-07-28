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
        private EmailService emailService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailTest() : base()
        {
            emailService = new EmailService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Email GetFilledRandomEmail(string OmitPropName)
        {
            Email email = new Email();

            if (OmitPropName != "EmailTVItemID") email.EmailTVItemID = 29;
            if (OmitPropName != "EmailAddress") email.EmailAddress = GetRandomEmail();
            if (OmitPropName != "EmailType") email.EmailType = (EmailTypeEnum)GetRandomEnumType(typeof(EmailTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") email.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") email.LastUpdateContactTVItemID = 2;

            return email;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Email_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Email email = GetFilledRandomEmail("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = emailService.GetRead().Count();

            emailService.Add(email);
            if (email.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", email.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, emailService.GetRead().Where(c => c == email).Any());
            emailService.Update(email);
            if (email.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", email.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, emailService.GetRead().Count());
            emailService.Delete(email);
            if (email.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", email.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, emailService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // email.EmailID   (Int32)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            email.EmailID = 0;
            emailService.Update(email);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.EmailEmailID), email.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Email)]
            // email.EmailTVItemID   (Int32)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            email.EmailTVItemID = 0;
            emailService.Add(email);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailEmailTVItemID, email.EmailTVItemID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);

            // EmailTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [DataType(DataType.EmailAddress)]
            // [StringLength(255))]
            // email.EmailAddress   (String)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("EmailAddress");
            Assert.AreEqual(false, emailService.Add(email));
            Assert.AreEqual(1, email.ValidationResults.Count());
            Assert.IsTrue(email.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailEmailAddress)).Any());
            Assert.AreEqual(null, email.EmailAddress);
            Assert.AreEqual(0, emailService.GetRead().Count());

            email = null;
            email = GetFilledRandomEmail("");
            // EmailAddress has MinLength [empty] and MaxLength [255]. At Max should return true and no errors
            string emailEmailAddressMin = GetRandomEmail();
            email.EmailAddress = emailEmailAddressMin;
            Assert.AreEqual(true, emailService.Add(email));
            Assert.AreEqual(0, email.ValidationResults.Count());
            Assert.AreEqual(emailEmailAddressMin, email.EmailAddress);
            Assert.AreEqual(true, emailService.Delete(email));
            Assert.AreEqual(count, emailService.GetRead().Count());

            // EmailAddress has MinLength [empty] and MaxLength [255]. At Max - 1 should return true and no errors
            emailEmailAddressMin = GetRandomEmail();
            email.EmailAddress = emailEmailAddressMin;
            Assert.AreEqual(true, emailService.Add(email));
            Assert.AreEqual(0, email.ValidationResults.Count());
            Assert.AreEqual(emailEmailAddressMin, email.EmailAddress);
            Assert.AreEqual(true, emailService.Delete(email));
            Assert.AreEqual(count, emailService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // email.EmailType   (EmailTypeEnum)
            // -----------------------------------

            // EmailType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // email.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // email.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            email = null;
            email = GetFilledRandomEmail("");
            email.LastUpdateContactTVItemID = 0;
            emailService.Add(email);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailLastUpdateContactTVItemID, email.LastUpdateContactTVItemID.ToString()), email.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // email.EmailTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // email.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
