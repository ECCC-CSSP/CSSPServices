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
        private int SearchTagAndTermsID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public SearchTagAndTermsTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SearchTagAndTerms GetFilledRandomSearchTagAndTerms(string OmitPropName)
        {
            SearchTagAndTermsID += 1;

            SearchTagAndTerms searchTagAndTerms = new SearchTagAndTerms();

            if (OmitPropName != "SearchTag") searchTagAndTerms.SearchTag = (CSSPEnums.SearchTagEnum)GetRandomEnumType(typeof(CSSPEnums.SearchTagEnum));

            return searchTagAndTerms;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SearchTagAndTerms_Testing()
        {
            SetupTestHelper(culture);
            SearchTagAndTermsService searchTagAndTermsService = new SearchTagAndTermsService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
