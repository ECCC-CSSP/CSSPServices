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
    public partial class TVTypeNamesAndPathTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVTypeNamesAndPathService tvTypeNamesAndPathService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeNamesAndPathTest() : base()
        {
            tvTypeNamesAndPathService = new TVTypeNamesAndPathService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVTypeNamesAndPath GetFilledRandomTVTypeNamesAndPath(string OmitPropName)
        {
            TVTypeNamesAndPath tvTypeNamesAndPath = new TVTypeNamesAndPath();

            if (OmitPropName != "TVTypeName") tvTypeNamesAndPath.TVTypeName = GetRandomString("", 6);
            if (OmitPropName != "Index") tvTypeNamesAndPath.Index = GetRandomInt(1, 11);
            if (OmitPropName != "TVPath") tvTypeNamesAndPath.TVPath = GetRandomString("", 6);

            return tvTypeNamesAndPath;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVTypeNamesAndPath_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVTypeNamesAndPath tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("");

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
        #endregion Tests Generated
    }
}
