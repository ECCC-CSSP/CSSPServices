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
    public partial class ResetPasswordTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ResetPasswordService resetPasswordService { get; set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordTest() : base()
        {
            resetPasswordService = new ResetPasswordService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ResetPassword GetFilledRandomResetPassword(string OmitPropName)
        {
            ResetPassword resetPassword = new ResetPassword();

            if (OmitPropName != "Email") resetPassword.Email = GetRandomString("", 5);
            if (OmitPropName != "ExpireDate_Local") resetPassword.ExpireDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Code") resetPassword.Code = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") resetPassword.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") resetPassword.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "Password") resetPassword.Password = GetRandomString("", 11);
            if (OmitPropName != "ConfirmPassword") resetPassword.ConfirmPassword = GetRandomString("", 11);

            return resetPassword;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ResetPassword_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            ResetPassword resetPassword = GetFilledRandomResetPassword("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = resetPasswordService.GetRead().Count();

            resetPasswordService.Add(resetPassword);
            if (resetPassword.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, resetPasswordService.GetRead().Where(c => c == resetPassword).Any());
            resetPasswordService.Update(resetPassword);
            if (resetPassword.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, resetPasswordService.GetRead().Count());
            resetPasswordService.Delete(resetPassword);
            if (resetPassword.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // resetPassword.ResetPasswordID   (Int32)
            // -----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            resetPassword.ResetPasswordID = 0;
            resetPasswordService.Update(resetPassword);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordResetPasswordID), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(256))]
            // resetPassword.Email   (String)
            // -----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("Email");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordEmail)).Any());
            Assert.AreEqual(null, resetPassword.Email);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            resetPassword.Email = GetRandomString("", 257);
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ResetPasswordEmail, "256"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // resetPassword.ExpireDate_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(8))]
            // resetPassword.Code   (String)
            // -----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("Code");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordCode)).Any());
            Assert.AreEqual(null, resetPassword.Code);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            resetPassword.Code = GetRandomString("", 9);
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ResetPasswordCode, "8"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // resetPassword.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // resetPassword.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            resetPassword.LastUpdateContactTVItemID = 0;
            resetPasswordService.Add(resetPassword);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.ResetPasswordLastUpdateContactTVItemID, resetPassword.LastUpdateContactTVItemID.ToString()), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            resetPassword.LastUpdateContactTVItemID = 1;
            resetPasswordService.Add(resetPassword);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.ResetPasswordLastUpdateContactTVItemID, "Contact"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // [StringLength(100, MinimumLength = 6)]
            // resetPassword.Password   (String)
            // -----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("Password");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordPassword)).Any());
            Assert.AreEqual(null, resetPassword.Password);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            resetPassword.Password = GetRandomString("", 5);
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordPassword, "6", "100"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());
            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            resetPassword.Password = GetRandomString("", 101);
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordPassword, "6", "100"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // [StringLength(100, MinimumLength = 6)]
            // resetPassword.ConfirmPassword   (String)
            // -----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("ConfirmPassword");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordConfirmPassword)).Any());
            Assert.AreEqual(null, resetPassword.ConfirmPassword);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            resetPassword.ConfirmPassword = GetRandomString("", 5);
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordConfirmPassword, "6", "100"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());
            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            resetPassword.ConfirmPassword = GetRandomString("", 101);
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordConfirmPassword, "6", "100"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // resetPassword.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
