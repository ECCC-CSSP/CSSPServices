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
    public partial class URLNumberOfSamplesServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private URLNumberOfSamplesService uRLNumberOfSamplesService { get; set; }
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesServiceTest() : base()
        {
            //uRLNumberOfSamplesService = new URLNumberOfSamplesService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private URLNumberOfSamples GetFilledRandomURLNumberOfSamples(string OmitPropName)
        {
            URLNumberOfSamples uRLNumberOfSamples = new URLNumberOfSamples();

            if (OmitPropName != "url") uRLNumberOfSamples.url = GetRandomString("", 6);
            // should implement a Range for the property NumberOfSamples and type URLNumberOfSamples

            return uRLNumberOfSamples;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void URLNumberOfSamples_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                URLNumberOfSamplesService uRLNumberOfSamplesService = new URLNumberOfSamplesService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                URLNumberOfSamples uRLNumberOfSamples = GetFilledRandomURLNumberOfSamples("");

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
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

    }
}
