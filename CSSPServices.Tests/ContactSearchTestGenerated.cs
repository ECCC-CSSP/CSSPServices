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
        private int ContactSearchID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ContactSearchTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ContactSearch GetFilledRandomContactSearch(string OmitPropName)
        {
            ContactSearchID += 1;

            ContactSearch contactSearch = new ContactSearch();

            if (OmitPropName != "ContactID") contactSearch.ContactID = GetRandomInt(1, 11);
            if (OmitPropName != "ContactTVItemID") contactSearch.ContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "FullName") contactSearch.FullName = GetRandomString("", 1);

            return contactSearch;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ContactSearch_Testing()
        {
            SetupTestHelper(culture);
            ContactSearchService contactSearchService = new ContactSearchService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
