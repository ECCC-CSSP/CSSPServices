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
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            // Email has MinLength [empty] and MaxLength [256]. At Max should return true and no errors
            string resetPasswordEmailMin = GetRandomEmail();
            resetPassword.Email = resetPasswordEmailMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordEmailMin, resetPassword.Email);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // Email has MinLength [empty] and MaxLength [256]. At Max - 1 should return true and no errors
            resetPasswordEmailMin = GetRandomEmail();
            resetPassword.Email = resetPasswordEmailMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordEmailMin, resetPassword.Email);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // resetPassword.ExpireDate_Local   (DateTime)
            // -----------------------------------

            // ExpireDate_Local will automatically be initialized at 0 --> not null


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
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            // Code has MinLength [empty] and MaxLength [8]. At Max should return true and no errors
            string resetPasswordCodeMin = GetRandomString("", 8);
            resetPassword.Code = resetPasswordCodeMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordCodeMin, resetPassword.Code);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // Code has MinLength [empty] and MaxLength [8]. At Max - 1 should return true and no errors
            resetPasswordCodeMin = GetRandomString("", 7);
            resetPassword.Code = resetPasswordCodeMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordCodeMin, resetPassword.Code);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // Code has MinLength [empty] and MaxLength [8]. At Max + 1 should return false with one error
            resetPasswordCodeMin = GetRandomString("", 9);
            resetPassword.Code = resetPasswordCodeMin;
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ResetPasswordCode, "8")).Any());
            Assert.AreEqual(resetPasswordCodeMin, resetPassword.Code);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // resetPassword.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


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

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


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
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");

            // Password has MinLength [6] and MaxLength [100]. At Min should return true and no errors
            string resetPasswordPasswordMin = GetRandomString("", 6);
            resetPassword.Password = resetPasswordPasswordMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordPasswordMin, resetPassword.Password);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Min + 1 should return true and no errors
            resetPasswordPasswordMin = GetRandomString("", 7);
            resetPassword.Password = resetPasswordPasswordMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordPasswordMin, resetPassword.Password);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Min - 1 should return false with one error
            resetPasswordPasswordMin = GetRandomString("", 5);
            resetPassword.Password = resetPasswordPasswordMin;
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordPassword, "6", "100")).Any());
            Assert.AreEqual(resetPasswordPasswordMin, resetPassword.Password);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Max should return true and no errors
            resetPasswordPasswordMin = GetRandomString("", 100);
            resetPassword.Password = resetPasswordPasswordMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordPasswordMin, resetPassword.Password);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Max - 1 should return true and no errors
            resetPasswordPasswordMin = GetRandomString("", 99);
            resetPassword.Password = resetPasswordPasswordMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordPasswordMin, resetPassword.Password);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // Password has MinLength [6] and MaxLength [100]. At Max + 1 should return false with one error
            resetPasswordPasswordMin = GetRandomString("", 101);
            resetPassword.Password = resetPasswordPasswordMin;
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordPassword, "6", "100")).Any());
            Assert.AreEqual(resetPasswordPasswordMin, resetPassword.Password);
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
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Min should return true and no errors
            string resetPasswordConfirmPasswordMin = GetRandomString("", 6);
            resetPassword.ConfirmPassword = resetPasswordConfirmPasswordMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordConfirmPasswordMin, resetPassword.ConfirmPassword);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Min + 1 should return true and no errors
            resetPasswordConfirmPasswordMin = GetRandomString("", 7);
            resetPassword.ConfirmPassword = resetPasswordConfirmPasswordMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordConfirmPasswordMin, resetPassword.ConfirmPassword);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Min - 1 should return false with one error
            resetPasswordConfirmPasswordMin = GetRandomString("", 5);
            resetPassword.ConfirmPassword = resetPasswordConfirmPasswordMin;
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordConfirmPassword, "6", "100")).Any());
            Assert.AreEqual(resetPasswordConfirmPasswordMin, resetPassword.ConfirmPassword);
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Max should return true and no errors
            resetPasswordConfirmPasswordMin = GetRandomString("", 100);
            resetPassword.ConfirmPassword = resetPasswordConfirmPasswordMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordConfirmPasswordMin, resetPassword.ConfirmPassword);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Max - 1 should return true and no errors
            resetPasswordConfirmPasswordMin = GetRandomString("", 99);
            resetPassword.ConfirmPassword = resetPasswordConfirmPasswordMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordConfirmPasswordMin, resetPassword.ConfirmPassword);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(count, resetPasswordService.GetRead().Count());

            // ConfirmPassword has MinLength [6] and MaxLength [100]. At Max + 1 should return false with one error
            resetPasswordConfirmPasswordMin = GetRandomString("", 101);
            resetPassword.ConfirmPassword = resetPasswordConfirmPasswordMin;
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordConfirmPassword, "6", "100")).Any());
            Assert.AreEqual(resetPasswordConfirmPasswordMin, resetPassword.ConfirmPassword);
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
