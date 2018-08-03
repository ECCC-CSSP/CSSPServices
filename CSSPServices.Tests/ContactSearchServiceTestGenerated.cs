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
    }
}
