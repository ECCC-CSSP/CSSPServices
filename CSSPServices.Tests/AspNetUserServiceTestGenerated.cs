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
    public partial class AspNetUserServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AspNetUserService aspNetUserService { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserServiceTest() : base()
        {
            //aspNetUserService = new AspNetUserService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AspNetUser GetFilledRandomAspNetUser(string OmitPropName)
        {
            AspNetUser aspNetUser = new AspNetUser();

            if (OmitPropName != "Email") aspNetUser.Email = GetRandomString("", 5);
            if (OmitPropName != "EmailConfirmed") aspNetUser.EmailConfirmed = true;
            if (OmitPropName != "PasswordHash") aspNetUser.PasswordHash = GetRandomString("", 5);
            if (OmitPropName != "SecurityStamp") aspNetUser.SecurityStamp = GetRandomString("", 5);
            if (OmitPropName != "PhoneNumber") aspNetUser.PhoneNumber = GetRandomString("", 5);
            if (OmitPropName != "PhoneNumberConfirmed") aspNetUser.PhoneNumberConfirmed = true;
            if (OmitPropName != "TwoFactorEnabled") aspNetUser.TwoFactorEnabled = true;
            if (OmitPropName != "LockoutEndDateUtc") aspNetUser.LockoutEndDateUtc = new DateTime(2005, 3, 6);
            if (OmitPropName != "LockoutEnabled") aspNetUser.LockoutEnabled = true;
            if (OmitPropName != "AccessFailedCount") aspNetUser.AccessFailedCount = GetRandomInt(0, 10000);
            if (OmitPropName != "UserName") aspNetUser.UserName = GetRandomString("", 5);

            return aspNetUser;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AspNetUser_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AspNetUserService aspNetUserService = new AspNetUserService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    AspNetUser aspNetUser = GetFilledRandomAspNetUser("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = aspNetUserService.GetRead().Count();

                    Assert.AreEqual(aspNetUserService.GetRead().Count(), aspNetUserService.GetEdit().Count());

                    aspNetUserService.Add(aspNetUser);
                    if (aspNetUser.HasErrors)
                    {
                        Assert.AreEqual("", aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, aspNetUserService.GetRead().Where(c => c == aspNetUser).Any());
                    aspNetUserService.Update(aspNetUser);
                    if (aspNetUser.HasErrors)
                    {
                        Assert.AreEqual("", aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, aspNetUserService.GetRead().Count());
                    aspNetUserService.Delete(aspNetUser);
                    if (aspNetUser.HasErrors)
                    {
                        Assert.AreEqual("", aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, aspNetUserService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // [StringLength(128))]
                    // aspNetUser.Id   (String)
                    // -----------------------------------

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.Id = 0;
                    aspNetUserService.Update(aspNetUser);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AspNetUserId), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.Id = 10000000;
                    aspNetUserService.Update(aspNetUser);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.AspNetUser, CSSPModelsRes.AspNetUserId, aspNetUser.Id.ToString()), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(256))]
                    // aspNetUser.Email   (String)
                    // -----------------------------------

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.Email = GetRandomString("", 257);
                    Assert.AreEqual(false, aspNetUserService.Add(aspNetUser));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserEmail, "256"), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, aspNetUserService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // aspNetUser.EmailConfirmed   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(256))]
                    // aspNetUser.PasswordHash   (String)
                    // -----------------------------------

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.PasswordHash = GetRandomString("", 257);
                    Assert.AreEqual(false, aspNetUserService.Add(aspNetUser));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserPasswordHash, "256"), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, aspNetUserService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(256))]
                    // aspNetUser.SecurityStamp   (String)
                    // -----------------------------------

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.SecurityStamp = GetRandomString("", 257);
                    Assert.AreEqual(false, aspNetUserService.Add(aspNetUser));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserSecurityStamp, "256"), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, aspNetUserService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(256))]
                    // aspNetUser.PhoneNumber   (String)
                    // -----------------------------------

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.PhoneNumber = GetRandomString("", 257);
                    Assert.AreEqual(false, aspNetUserService.Add(aspNetUser));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserPhoneNumber, "256"), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, aspNetUserService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // aspNetUser.PhoneNumberConfirmed   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // aspNetUser.TwoFactorEnabled   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // aspNetUser.LockoutEndDateUtc   (DateTime)
                    // -----------------------------------

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.LockoutEndDateUtc = new DateTime(1979, 1, 1);
                    aspNetUserService.Add(aspNetUser);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AspNetUserLockoutEndDateUtc, "1980"), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // aspNetUser.LockoutEnabled   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // aspNetUser.AccessFailedCount   (Int32)
                    // -----------------------------------

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.AccessFailedCount = -1;
                    Assert.AreEqual(false, aspNetUserService.Add(aspNetUser));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AspNetUserAccessFailedCount, "0", "10000"), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, aspNetUserService.GetRead().Count());
                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.AccessFailedCount = 10001;
                    Assert.AreEqual(false, aspNetUserService.Add(aspNetUser));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.AspNetUserAccessFailedCount, "0", "10000"), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, aspNetUserService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(256))]
                    // aspNetUser.UserName   (String)
                    // -----------------------------------

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("UserName");
                    Assert.AreEqual(false, aspNetUserService.Add(aspNetUser));
                    Assert.AreEqual(1, aspNetUser.ValidationResults.Count());
                    Assert.IsTrue(aspNetUser.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AspNetUserUserName)).Any());
                    Assert.AreEqual(null, aspNetUser.UserName);
                    Assert.AreEqual(count, aspNetUserService.GetRead().Count());

                    aspNetUser = null;
                    aspNetUser = GetFilledRandomAspNetUser("");
                    aspNetUser.UserName = GetRandomString("", 257);
                    Assert.AreEqual(false, aspNetUserService.Add(aspNetUser));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AspNetUserUserName, "256"), aspNetUser.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, aspNetUserService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // aspNetUser.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // aspNetUser.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void AspNetUser_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    AspNetUserService aspNetUserService = new AspNetUserService(new GetParam(), dbTestDB, ContactID);
                    AspNetUser aspNetUser = (from c in aspNetUserService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(aspNetUser);

                    AspNetUser aspNetUserRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            aspNetUserRet = aspNetUserService.GetAspNetUserWithAspNetUserID(aspNetUser.AspNetUserID, getParam);
                            Assert.IsNull(aspNetUserRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            aspNetUserRet = aspNetUserService.GetAspNetUserWithAspNetUserID(aspNetUser.AspNetUserID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            aspNetUserRet = aspNetUserService.GetAspNetUserWithAspNetUserID(aspNetUser.AspNetUserID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            aspNetUserRet = aspNetUserService.GetAspNetUserWithAspNetUserID(aspNetUser.AspNetUserID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // AspNetUser fields
                        Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserRet.Id));
                        if (aspNetUserRet.Email != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserRet.Email));
                        }
                        Assert.IsNotNull(aspNetUserRet.EmailConfirmed);
                        if (aspNetUserRet.PasswordHash != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserRet.PasswordHash));
                        }
                        if (aspNetUserRet.SecurityStamp != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserRet.SecurityStamp));
                        }
                        if (aspNetUserRet.PhoneNumber != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserRet.PhoneNumber));
                        }
                        Assert.IsNotNull(aspNetUserRet.PhoneNumberConfirmed);
                        Assert.IsNotNull(aspNetUserRet.TwoFactorEnabled);
                        if (aspNetUserRet.LockoutEndDateUtc != null)
                        {
                            Assert.IsNotNull(aspNetUserRet.LockoutEndDateUtc);
                        }
                        Assert.IsNotNull(aspNetUserRet.LockoutEnabled);
                        Assert.IsNotNull(aspNetUserRet.AccessFailedCount);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserRet.UserName));

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // AspNetUserWeb and AspNetUserReport fields should be null here
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // AspNetUserWeb fields should not be null and AspNetUserReport fields should be null here
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // AspNetUserWeb and AspNetUserReport fields should NOT be null here
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of AspNetUser
        #endregion Tests Get List of AspNetUser

    }
}
