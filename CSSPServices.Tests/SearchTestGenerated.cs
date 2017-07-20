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
        private int SearchID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public SearchTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Search GetFilledRandomSearch(string OmitPropName)
        {
            SearchID += 1;

            Search search = new Search();

            if (OmitPropName != "value") search.value = GetRandomString("", 5);
            if (OmitPropName != "id") search.id = GetRandomInt(1, 11);

            return search;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Search_Testing()
        {
            SetupTestHelper(culture);
            SearchService searchService = new SearchService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
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
