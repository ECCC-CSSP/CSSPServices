 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
