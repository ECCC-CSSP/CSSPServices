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
        private int RegisterID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public RegisterTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Register GetFilledRandomRegister(string OmitPropName)
        {
            RegisterID += 1;

            Register register = new Register();

            if (OmitPropName != "LoginEmail") register.LoginEmail = GetRandomEmail();
            if (OmitPropName != "FirstName") register.FirstName = GetRandomString("", 5);
            if (OmitPropName != "Initial") register.Initial = GetRandomString("", 5);
            if (OmitPropName != "LastName") register.LastName = GetRandomString("", 5);
            if (OmitPropName != "WebName") register.WebName = GetRandomString("", 5);
            if (OmitPropName != "Password") register.Password = GetRandomString("", 5);
            if (OmitPropName != "ConfirmPassword") register.ConfirmPassword = GetRandomString("", 5);

            return register;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Register_Testing()
        {
            SetupTestHelper(culture);
            RegisterService registerService = new RegisterService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
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
