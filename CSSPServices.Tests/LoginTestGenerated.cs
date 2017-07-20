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
    public partial class LoginTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int LoginID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LoginTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Login GetFilledRandomLogin(string OmitPropName)
        {
            LoginID += 1;

            Login login = new Login();

            if (OmitPropName != "LoginEmail") login.LoginEmail = GetRandomEmail();
            if (OmitPropName != "Password") login.Password = GetRandomString("", 5);
            if (OmitPropName != "ConfirmPassword") login.ConfirmPassword = GetRandomString("", 5);

            return login;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Login_Testing()
        {
            SetupTestHelper(culture);
            LoginService loginService = new LoginService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            Login login = GetFilledRandomLogin("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

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
