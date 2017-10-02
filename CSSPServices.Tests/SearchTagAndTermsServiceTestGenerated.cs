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
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class SearchTagAndTermsServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SearchTagAndTermsService searchTagAndTermsService { get; set; }
        #endregion Properties

        #region Constructors
        public SearchTagAndTermsServiceTest() : base()
        {
            //searchTagAndTermsService = new SearchTagAndTermsService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SearchTagAndTerms GetFilledRandomSearchTagAndTerms(string OmitPropName)
        {
            SearchTagAndTerms searchTagAndTerms = new SearchTagAndTerms();

            if (OmitPropName != "SearchTag") searchTagAndTerms.SearchTag = (SearchTagEnum)GetRandomEnumType(typeof(SearchTagEnum));
            if (OmitPropName != "SearchTagText") searchTagAndTerms.SearchTagText = GetRandomString("", 5);

            return searchTagAndTerms;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SearchTagAndTerms_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SearchTagAndTermsService searchTagAndTermsService = new SearchTagAndTermsService(LanguageRequest, dbTestDB, ContactID);

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
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

        #region Tests Generated Get List of SearchTagAndTerms
        #endregion Tests Get List of SearchTagAndTerms

    }
}
