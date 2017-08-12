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
    public partial class LoginServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LoginService loginService { get; set; }
        #endregion Properties

        #region Constructors
        public LoginServiceTest() : base()
        {
            //loginService = new LoginService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Login GetFilledRandomLogin(string OmitPropName)
        {
            Login login = new Login();

            if (OmitPropName != "LoginEmail") login.LoginEmail = GetRandomString("", 11);
            if (OmitPropName != "Password") login.Password = GetRandomString("", 11);
            if (OmitPropName != "ConfirmPassword") login.ConfirmPassword = GetRandomString("", 11);
            if (OmitPropName != "HasErrors") login.HasErrors = true;

            return login;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Login_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                LoginService loginService = new LoginService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                Login login = GetFilledRandomLogin("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

    }
}
