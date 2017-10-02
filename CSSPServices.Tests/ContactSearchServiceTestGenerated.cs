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
    public partial class ContactSearchServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ContactSearchService contactSearchService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactSearchServiceTest() : base()
        {
            //contactSearchService = new ContactSearchService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactSearch GetFilledRandomContactSearch(string OmitPropName)
        {
            ContactSearch contactSearch = new ContactSearch();

            if (OmitPropName != "ContactID") contactSearch.ContactID = GetRandomInt(1, 11);
            if (OmitPropName != "ContactTVItemID") contactSearch.ContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "FullName") contactSearch.FullName = GetRandomString("", 5);

            return contactSearch;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ContactSearch_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ContactSearchService contactSearchService = new ContactSearchService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ContactSearch contactSearch = GetFilledRandomContactSearch("");

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

        #region Tests Generated Get List of ContactSearch
        #endregion Tests Get List of ContactSearch

    }
}
