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
            if (OmitPropName != "Code") resetPassword.Code = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") resetPassword.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") resetPassword.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Password") resetPassword.Password = GetRandomString("", 5);
            if (OmitPropName != "ConfirmPassword") resetPassword.ConfirmPassword = GetRandomString("", 5);

            return resetPassword;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ResetPassword_Testing()
        {
            SetupTestHelper(culture);
            ResetPasswordService resetPasswordService = new ResetPasswordService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            ResetPassword resetPassword = GetFilledRandomResetPassword("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

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

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("Password");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordPassword)).Any());
            Assert.AreEqual(null, resetPassword.Password);
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("ConfirmPassword");
            Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
            Assert.AreEqual(1, resetPassword.ValidationResults.Count());
            Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.ResetPasswordConfirmPassword)).Any());
            Assert.AreEqual(null, resetPassword.ConfirmPassword);
            Assert.AreEqual(0, resetPasswordService.GetRead().Count());

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [ResetPasswordID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [Email] of type [String]
            //-----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");

            //-----------------------------------
            // doing property [ExpireDate_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Code] of type [String]
            //-----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [Password] of type [String]
            //-----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");

            //-----------------------------------
            // doing property [ConfirmPassword] of type [String]
            //-----------------------------------

            resetPassword = null;
            resetPassword = GetFilledRandomResetPassword("");

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
