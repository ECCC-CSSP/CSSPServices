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
    public partial class AspNetUserClaimTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int AspNetUserClaimID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AspNetUserClaimTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AspNetUserClaim GetFilledRandomAspNetUserClaim(string OmitPropName)
        {
            AspNetUserClaimID += 1;

            AspNetUserClaim aspNetUserClaim = new AspNetUserClaim();

            if (OmitPropName != "Id") aspNetUserClaim.Id = AspNetUserClaimID; 
            if (OmitPropName != "UserId") aspNetUserClaim.UserId = GetRandomString("", 5);
            if (OmitPropName != "ClaimType") aspNetUserClaim.ClaimType = GetRandomString("", 20);
            if (OmitPropName != "ClaimValue") aspNetUserClaim.ClaimValue = GetRandomString("", 20);

            return aspNetUserClaim;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AspNetUserClaim_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            AspNetUserClaimService aspNetUserClaimService = new AspNetUserClaimService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            AspNetUserClaim aspNetUserClaim = GetFilledRandomAspNetUserClaim("");
            Assert.AreEqual(true, aspNetUserClaimService.Add(aspNetUserClaim));
            Assert.AreEqual(true, aspNetUserClaimService.GetRead().Where(c => c == aspNetUserClaim).Any());

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
