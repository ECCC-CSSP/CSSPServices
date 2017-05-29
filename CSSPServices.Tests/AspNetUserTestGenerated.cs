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
    public partial class AspNetUserTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int AspNetUserID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AspNetUser GetFilledRandomAspNetUser(string OmitPropName)
        {
            AspNetUserID += 1;

            AspNetUser aspNetUser = new AspNetUser();

            if (OmitPropName != "Id") aspNetUser.Id = GetRandomString("", 5);
            if (OmitPropName != "Email") aspNetUser.Email = GetRandomEmail();
            if (OmitPropName != "EmailConfirmed") aspNetUser.EmailConfirmed = true;
            if (OmitPropName != "PasswordHash") aspNetUser.PasswordHash = GetRandomString("", 20);
            if (OmitPropName != "SecurityStamp") aspNetUser.SecurityStamp = GetRandomString("", 20);
            if (OmitPropName != "PhoneNumber") aspNetUser.PhoneNumber = GetRandomString("", 20);
            if (OmitPropName != "PhoneNumberConfirmed") aspNetUser.PhoneNumberConfirmed = true;
            if (OmitPropName != "TwoFactorEnabled") aspNetUser.TwoFactorEnabled = true;
            if (OmitPropName != "LockoutEndDateUtc") aspNetUser.LockoutEndDateUtc = GetRandomDateTime();
            if (OmitPropName != "LockoutEnabled") aspNetUser.LockoutEnabled = true;
            if (OmitPropName != "AccessFailedCount") aspNetUser.AccessFailedCount = GetRandomInt(0, 10);
            if (OmitPropName != "UserName") aspNetUser.UserName = GetRandomEmail();
            if (OmitPropName != "Password") aspNetUser.Password = GetRandomString("", 6);

            return aspNetUser;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AspNetUser_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            AspNetUserService aspNetUserService = new AspNetUserService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            AspNetUser aspNetUser = GetFilledRandomAspNetUser("");
            Assert.AreEqual(true, aspNetUserService.Add(aspNetUser));
            Assert.AreEqual(true, aspNetUserService.GetRead().Where(c => c == aspNetUser).Any());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


        }
        #endregion Tests Generated
    }
}
