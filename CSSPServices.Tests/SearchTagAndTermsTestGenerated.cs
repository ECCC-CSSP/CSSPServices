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
    public partial class SearchTagAndTermsTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SearchTagAndTermsService searchTagAndTermsService { get; set; }
        #endregion Properties

        #region Constructors
        public SearchTagAndTermsTest() : base()
        {
            searchTagAndTermsService = new SearchTagAndTermsService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SearchTagAndTerms GetFilledRandomSearchTagAndTerms(string OmitPropName)
        {
            SearchTagAndTerms searchTagAndTerms = new SearchTagAndTerms();

            if (OmitPropName != "SearchTag") searchTagAndTerms.SearchTag = (SearchTagEnum)GetRandomEnumType(typeof(SearchTagEnum));

            return searchTagAndTerms;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SearchTagAndTerms_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            SearchTagAndTerms searchTagAndTerms = GetFilledRandomSearchTagAndTerms("");

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
