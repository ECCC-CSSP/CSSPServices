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
    public partial class AspNetUserLoginTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int AspNetUserLoginID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserLoginTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AspNetUserLogin GetFilledRandomAspNetUserLogin(string OmitPropName)
        {
            AspNetUserLoginID += 1;

            AspNetUserLogin aspNetUserLogin = new AspNetUserLogin();

            if (OmitPropName != "LoginProvider") aspNetUserLogin.LoginProvider = GetRandomString("", 5);
            if (OmitPropName != "ProviderKey") aspNetUserLogin.ProviderKey = GetRandomString("", 5);
            if (OmitPropName != "UserId") aspNetUserLogin.UserId = GetRandomString("", 5);

            return aspNetUserLogin;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AspNetUserLogin_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            AspNetUserLoginService aspNetUserLoginService = new AspNetUserLoginService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            AspNetUserLogin aspNetUserLogin = GetFilledRandomAspNetUserLogin("");
            Assert.AreEqual(true, aspNetUserLoginService.Add(aspNetUserLogin));
            Assert.AreEqual(true, aspNetUserLoginService.GetRead().Where(c => c == aspNetUserLogin).Any());

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
