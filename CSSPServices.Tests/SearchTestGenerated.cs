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
    public partial class SearchTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SearchService searchService { get; set; }
        #endregion Properties

        #region Constructors
        public SearchTest() : base()
        {
            searchService = new SearchService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Search GetFilledRandomSearch(string OmitPropName)
        {
            Search search = new Search();

            if (OmitPropName != "value") search.value = GetRandomString("", 6);
            if (OmitPropName != "id") search.id = GetRandomInt(1, 11);

            return search;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Search_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Search search = GetFilledRandomSearch("");

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
