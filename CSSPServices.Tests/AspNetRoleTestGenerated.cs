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
    public partial class AspNetRoleTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int AspNetRoleID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetRoleTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AspNetRole GetFilledRandomAspNetRole(string OmitPropName)
        {
            AspNetRoleID += 1;

            AspNetRole aspNetRole = new AspNetRole();

            if (OmitPropName != "Id") aspNetRole.Id = GetRandomString("", 5);
            if (OmitPropName != "Name") aspNetRole.Name = GetRandomString("", 5);

            return aspNetRole;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AspNetRole_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            AspNetRoleService aspNetRoleService = new AspNetRoleService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            AspNetRole aspNetRole = GetFilledRandomAspNetRole("");
            Assert.AreEqual(true, aspNetRoleService.Add(aspNetRole));
            Assert.AreEqual(true, aspNetRoleService.GetRead().Where(c => c == aspNetRole).Any());

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
