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
    public partial class AspNetUserRoleTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int AspNetUserRoleID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserRoleTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AspNetUserRole GetFilledRandomAspNetUserRole(string OmitPropName)
        {
            AspNetUserRoleID += 1;

            AspNetUserRole aspNetUserRole = new AspNetUserRole();

            if (OmitPropName != "UserId") aspNetUserRole.UserId = GetRandomString("", 5);
            if (OmitPropName != "RoleId") aspNetUserRole.RoleId = GetRandomString("", 5);

            return aspNetUserRole;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AspNetUserRole_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            AspNetUserRoleService aspNetUserRoleService = new AspNetUserRoleService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            AspNetUserRole aspNetUserRole = GetFilledRandomAspNetUserRole("");
            Assert.AreEqual(true, aspNetUserRoleService.Add(aspNetUserRole));
            Assert.AreEqual(true, aspNetUserRoleService.GetRead().Where(c => c == aspNetUserRole).Any());

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
