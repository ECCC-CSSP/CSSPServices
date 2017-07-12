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
    public partial class TVItemTVAuthTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVItemTVAuthID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemTVAuthTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemTVAuth GetFilledRandomTVItemTVAuth(string OmitPropName)
        {
            TVItemTVAuthID += 1;

            TVItemTVAuth tvItemTVAuth = new TVItemTVAuth();

            if (OmitPropName != "Error") tvItemTVAuth.Error = GetRandomString("", 20);
            if (OmitPropName != "TVItemUserAuthID") tvItemTVAuth.TVItemUserAuthID = GetRandomInt(1, 11);
            if (OmitPropName != "TVText") tvItemTVAuth.TVText = GetRandomString("", 5);
            if (OmitPropName != "TVItemID1") tvItemTVAuth.TVItemID1 = GetRandomInt(1, 11);
            if (OmitPropName != "TVTypeStr") tvItemTVAuth.TVTypeStr = GetRandomString("", 5);
            if (OmitPropName != "TVAuth") tvItemTVAuth.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));

            return tvItemTVAuth;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemTVAuth_Testing()
        {
            SetupTestHelper(culture);
            TVItemTVAuthService tvItemTVAuthService = new TVItemTVAuthService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            TVItemTVAuth tvItemTVAuth = GetFilledRandomTVItemTVAuth("");

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
