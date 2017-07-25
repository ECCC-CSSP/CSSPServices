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
        private TVItemTVAuthService tvItemTVAuthService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemTVAuthTest() : base()
        {
            tvItemTVAuthService = new TVItemTVAuthService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemTVAuth GetFilledRandomTVItemTVAuth(string OmitPropName)
        {
            TVItemTVAuth tvItemTVAuth = new TVItemTVAuth();

            if (OmitPropName != "Error") tvItemTVAuth.Error = GetRandomString("", 20);
            if (OmitPropName != "TVItemUserAuthID") tvItemTVAuth.TVItemUserAuthID = GetRandomInt(1, 11);
            if (OmitPropName != "TVText") tvItemTVAuth.TVText = GetRandomString("", 6);
            if (OmitPropName != "TVItemID1") tvItemTVAuth.TVItemID1 = GetRandomInt(1, 11);
            if (OmitPropName != "TVTypeStr") tvItemTVAuth.TVTypeStr = GetRandomString("", 6);
            if (OmitPropName != "TVAuth") tvItemTVAuth.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));

            return tvItemTVAuth;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemTVAuth_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

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
