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
    public partial class RegisterTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private RegisterService registerService { get; set; }
        #endregion Properties

        #region Constructors
        public RegisterTest() : base()
        {
            registerService = new RegisterService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Register GetFilledRandomRegister(string OmitPropName)
        {
            Register register = new Register();

            if (OmitPropName != "LoginEmail") register.LoginEmail = GetRandomString("", 11);
            if (OmitPropName != "FirstName") register.FirstName = GetRandomString("", 6);
            if (OmitPropName != "Initial") register.Initial = GetRandomString("", 5);
            if (OmitPropName != "LastName") register.LastName = GetRandomString("", 6);
            if (OmitPropName != "WebName") register.WebName = GetRandomString("", 6);
            if (OmitPropName != "Password") register.Password = GetRandomString("", 11);
            if (OmitPropName != "ConfirmPassword") register.ConfirmPassword = GetRandomString("", 11);

            return register;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Register_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Register register = GetFilledRandomRegister("");

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
