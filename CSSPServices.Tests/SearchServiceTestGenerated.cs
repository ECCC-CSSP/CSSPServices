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
    public partial class SearchServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SearchService searchService { get; set; }
        #endregion Properties

        #region Constructors
        public SearchServiceTest() : base()
        {
            //searchService = new SearchService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Search_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SearchService searchService = new SearchService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
                    // Properties testing
                    // -------------------------------
                    // -------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetSearchWithSearchID(search.SearchID)
        #endregion Tests Generated for GetSearchWithSearchID(search.SearchID)

        #region Tests Generated for GetSearchList()
        #endregion Tests Generated for GetSearchList()

        #region Tests Generated for GetSearchList() Skip Take
        #endregion Tests Generated for GetSearchList() Skip Take

        #region Tests Generated for GetSearchList() Skip Take Order
        #endregion Tests Generated for GetSearchList() Skip Take Order

        #region Tests Generated for GetSearchList() Skip Take 2Order
        #endregion Tests Generated for GetSearchList() Skip Take 2Order

        #region Tests Generated for GetSearchList() Skip Take Order Where
        #endregion Tests Generated for GetSearchList() Skip Take Order Where

        #region Tests Generated for GetSearchList() Skip Take Order 2Where
        #endregion Tests Generated for GetSearchList() Skip Take Order 2Where

        #region Tests Generated for GetSearchList() 2Where
        #endregion Tests Generated for GetSearchList() 2Where

        #region Functions private
        private Search GetFilledRandomSearch(string OmitPropName)
        {
            Search search = new Search();

            if (OmitPropName != "value") search.value = GetRandomString("", 6);
            if (OmitPropName != "id") search.id = GetRandomInt(1, 11);

            return search;
        }
        #endregion Functions private
    }
}
