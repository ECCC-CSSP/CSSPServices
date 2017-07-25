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
    public partial class ContactSearchTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ContactSearchService contactSearchService { get; set; }
        #endregion Properties

        #region Constructors
        public ContactSearchTest() : base()
        {
            contactSearchService = new ContactSearchService(LanguageRequest, dbTestDB, ContactID);
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

        #region Tests Generated
        [TestMethod]
        public void ContactSearch_Testing()
        {

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
