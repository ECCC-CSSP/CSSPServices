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
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new GetParam(), dbTestDB, ContactID);

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

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ExpireDate_Local = new DateTime();
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordExpireDate_Local), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ExpireDate_Local = new DateTime(1979, 1, 1);
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ResetPasswordExpireDate_Local, "1980"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    // Is Nullable
                    // [NotMapped]
                    // resetPassword.ResetPasswordWeb   (ResetPasswordWeb)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordWeb = null;
                    Assert.IsNull(resetPassword.ResetPasswordWeb);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordWeb = new ResetPasswordWeb();
                    Assert.IsNotNull(resetPassword.ResetPasswordWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // resetPassword.ResetPasswordReport   (ResetPasswordReport)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordReport = null;
                    Assert.IsNull(resetPassword.ResetPasswordReport);

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.ResetPasswordReport = new ResetPasswordReport();
                    Assert.IsNotNull(resetPassword.ResetPasswordReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // resetPassword.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateDate_UTC = new DateTime();
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ResetPasswordLastUpdateDate_UTC), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);
                    resetPassword = null;
                    resetPassword = GetFilledRandomResetPassword("");
                    resetPassword.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    resetPasswordService.Add(resetPassword);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ResetPasswordLastUpdateDate_UTC, "1980"), resetPassword.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    // Is NOT Nullable
                    // [NotMapped]
                    // resetPassword.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // resetPassword.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
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
                    GetParam getParam = new GetParam();
                    ResetPasswordService resetPasswordService = new ResetPasswordService(new GetParam(), dbTestDB, ContactID);
                    ResetPassword resetPassword = (from c in resetPasswordService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(resetPassword);

                    ResetPassword resetPasswordRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            resetPasswordRet = resetPasswordService.GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID, getParam);
                            Assert.IsNull(resetPasswordRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            resetPasswordRet = resetPasswordService.GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            resetPasswordRet = resetPasswordService.GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            resetPasswordRet = resetPasswordService.GetResetPasswordWithResetPasswordID(resetPassword.ResetPasswordID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // ResetPassword fields
                        Assert.IsNotNull(resetPasswordRet.ResetPasswordID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordRet.Email));
                        Assert.IsNotNull(resetPasswordRet.ExpireDate_Local);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordRet.Code));
                        Assert.IsNotNull(resetPasswordRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(resetPasswordRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ResetPasswordWeb and ResetPasswordReport fields should be null here
                            Assert.IsNull(resetPasswordRet.ResetPasswordWeb);
                            Assert.IsNull(resetPasswordRet.ResetPasswordReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ResetPasswordWeb fields should not be null and ResetPasswordReport fields should be null here
                            if (resetPasswordRet.ResetPasswordWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordRet.ResetPasswordWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(resetPasswordRet.ResetPasswordReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ResetPasswordWeb and ResetPasswordReport fields should NOT be null here
                            if (resetPasswordRet.ResetPasswordWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordRet.ResetPasswordWeb.LastUpdateContactTVText));
                            }
                            if (resetPasswordRet.ResetPasswordReport.ResetPasswordReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(resetPasswordRet.ResetPasswordReport.ResetPasswordReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of ResetPassword
        #endregion Tests Get List of ResetPassword

    }
}
