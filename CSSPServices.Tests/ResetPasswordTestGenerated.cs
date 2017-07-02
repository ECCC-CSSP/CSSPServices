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
        private int ResetPasswordID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ResetPassword GetFilledRandomResetPassword(string OmitPropName)
        {
            ResetPasswordID += 1;

            ResetPassword resetPassword = new ResetPassword();

            if (OmitPropName != "ResetPasswordID") resetPassword.ResetPasswordID = ResetPasswordID;
            if (OmitPropName != "Email") resetPassword.Email = GetRandomEmail();
            if (OmitPropName != "ExpireDate_Local") resetPassword.ExpireDate_Local = GetRandomDateTime();
            if (OmitPropName != "Code") resetPassword.Code = GetRandomString("", 8);
            if (OmitPropName != "LastUpdateDate_UTC") resetPassword.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") resetPassword.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Password") resetPassword.Password = GetRandomString("", 6);
            if (OmitPropName != "ConfirmPassword") resetPassword.ConfirmPassword = resetPassword.Password;

            return resetPassword;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ResetPassword_Testing()
        {
            SetupTestHelper(culture);
            ResetPasswordService resetPasswordService = new ResetPasswordService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            ResetPassword resetPassword = GetFilledRandomResetPassword("");
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(true, resetPasswordService.GetRead().Where(c => c == resetPassword).Any());
            resetPassword.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, resetPasswordService.Update(resetPassword));
            Assert.AreEqual(1, resetPasswordService.GetRead().Count());
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("Email");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordEmail)).Any());
            Assert.AreEqual(null, resetPassword.Email);
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("ExpireDate_Local");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordExpireDate_Local)).Any());
            Assert.IsTrue(resetPassword.ExpireDate_Local.Year < 1900);
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("Code");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordCode)).Any());
            Assert.AreEqual(null, resetPassword.Code);
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("LastUpdateDate_UTC");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordLastUpdateDate_UTC)).Any());
            Assert.IsTrue(resetPassword.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ResetPasswordID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [Email] of type [string]
            //-----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");

            // Email has MinLength [empty] and MaxLength [256]. At Max should return true and no errors
            string resetPasswordEmailMin = GetRandomEmail();
            resetPassword.Email = resetPasswordEmailMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordEmailMin, resetPassword.Email);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            // Email has MinLength [empty] and MaxLength [256]. At Max - 1 should return true and no errors
            resetPasswordEmailMin = GetRandomEmail();
            resetPassword.Email = resetPasswordEmailMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordEmailMin, resetPassword.Email);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            //-----------------------------------
            // doing property [ExpireDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Code] of type [string]
            //-----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");

            // Code has MinLength [8] and MaxLength [8]. At Min should return true and no errors
            string resetPasswordCodeMin = GetRandomString("", 8);
            resetPassword.Code = resetPasswordCodeMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordCodeMin, resetPassword.Code);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            // Code has MinLength [8] and MaxLength [8]. At Min - 1 should return false with one error
            resetPasswordCodeMin = GetRandomString("", 7);
            resetPassword.Code = resetPasswordCodeMin;
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordCode, "8", "8")).Any());
            Assert.AreEqual(resetPasswordCodeMin, resetPassword.Code);
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            // Code has MinLength [8] and MaxLength [8]. At Max should return true and no errors
            resetPasswordCodeMin = GetRandomString("", 8);
            resetPassword.Code = resetPasswordCodeMin;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(resetPasswordCodeMin, resetPassword.Code);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            // Code has MinLength [8] and MaxLength [8]. At Max + 1 should return false with one error
            resetPasswordCodeMin = GetRandomString("", 9);
            resetPassword.Code = resetPasswordCodeMin;
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ResetPasswordCode, "8", "8")).Any());
            Assert.AreEqual(resetPasswordCodeMin, resetPassword.Code);
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            resetPassword.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(1, resetPassword.LastUpdateContactTVItemID);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            resetPassword.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(0, resetPassword.ValidationResults.Count());
            Assert.AreEqual(2, resetPassword.LastUpdateContactTVItemID);
            Assert.AreEqual(true, resetPasswordService.Delete(resetPassword));
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            resetPassword.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.ResetPasswordLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, resetPassword.LastUpdateContactTVItemID);
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
