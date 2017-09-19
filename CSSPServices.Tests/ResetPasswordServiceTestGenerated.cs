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
    public partial class ResetPasswordServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ResetPasswordService resetPasswordService { get; set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordServiceTest() : base()
        {
            //resetPasswordService = new ResetPasswordService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "LastUpdateContactTVText") resetPassword.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "Password") resetPassword.Password = GetRandomString("", 11);
            if (OmitPropName != "ConfirmPassword") resetPassword.ConfirmPassword = GetRandomString("", 11);
            if (OmitPropName != "HasErrors") resetPassword.HasErrors = true;

            return resetPassword;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ResetPassword_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(LanguageRequest, dbTestDB, ContactID);

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

                Assert.AreEqual(resetPasswordService.GetRead().Count(), resetPasswordService.GetEdit().Count());

                resetPasswordService.Add(resetPassword);
                if (resetPassword.HasErrors)
                {
                    Assert.AreEqual("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, resetPasswordService.GetRead().Where(c => c == resetPassword).Any());
                resetPasswordService.Update(resetPassword);
                if (resetPassword.HasErrors)
                {
                    Assert.AreEqual("", resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, resetPasswordService.GetRead().Count());
                resetPasswordService.Delete(resetPassword);
                if (resetPassword.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordResetPasswordID), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordID = 10000000;
                    resetPasswordService.Update(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ResetPassword, CSSPModelsRes.ResetPasswordResetPasswordID, resetPassword.ResetPasswordID.ToString()), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(256))]
                    // resetPassword.Email   (String)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("Email");
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(1, resetPassword.ValidationResults.Count());
                    Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordEmail)).Any());
                    Assert.AreEqual(null, resetPassword.Email);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.Email = GetRandomString("", 257);
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ResetPasswordEmail, "256"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordCode)).Any());
                    Assert.AreEqual(null, resetPassword.Code);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.Code = GetRandomString("", 9);
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ResetPasswordCode, "8"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // resetPassword.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // resetPassword.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateContactTVItemID = 0;
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ResetPasswordLastUpdateContactTVItemID, resetPassword.LastUpdateContactTVItemID.ToString()), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateContactTVItemID = 1;
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ResetPasswordLastUpdateContactTVItemID, "Contact"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // resetPassword.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ResetPasswordLastUpdateContactTVText, "200"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

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
                    Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordPassword)).Any());
                    Assert.AreEqual(null, resetPassword.Password);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.Password = GetRandomString("", 5);
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ResetPasswordPassword, "6", "100"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());
                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.Password = GetRandomString("", 101);
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ResetPasswordPassword, "6", "100"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(resetPassword.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordConfirmPassword)).Any());
                    Assert.AreEqual(null, resetPassword.ConfirmPassword);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ConfirmPassword = GetRandomString("", 5);
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ResetPasswordConfirmPassword, "6", "100"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());
                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ConfirmPassword = GetRandomString("", 101);
                    Assert.AreEqual(false, resetPasswordService.Add(resetPassword));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.ResetPasswordConfirmPassword, "6", "100"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, resetPasswordService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // resetPassword.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // resetPassword.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ResetPassword_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ResetPasswordService resetPasswordService = new ResetPasswordService(LanguageRequest, dbTestDB, ContactID);
                    ResetPassword resetPassword = (from c in resetPasswordService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(resetPassword);

                    ResetPassword resetPasswordRet = resetPasswordService.GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID);
                    Assert.IsNotNull(resetPasswordRet.ResetPasswordID);
                    Assert.IsNotNull(resetPasswordRet.Email);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordRet.Email));
                    Assert.IsNotNull(resetPasswordRet.ExpireDate_Local);
                    Assert.IsNotNull(resetPasswordRet.Code);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordRet.Code));
                    Assert.IsNotNull(resetPasswordRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(resetPasswordRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(resetPasswordRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordRet.LastUpdateContactTVText));
                    Assert.IsNotNull(resetPasswordRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
