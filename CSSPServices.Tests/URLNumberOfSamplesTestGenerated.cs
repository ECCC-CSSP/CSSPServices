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
    public partial class URLNumberOfSamplesTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private URLNumberOfSamplesService uRLNumberOfSamplesService { get; set; }
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesTest() : base()
        {
            uRLNumberOfSamplesService = new URLNumberOfSamplesService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private URLNumberOfSamples GetFilledRandomURLNumberOfSamples(string OmitPropName)
        {
            URLNumberOfSamples uRLNumberOfSamples = new URLNumberOfSamples();

            if (OmitPropName != "url") uRLNumberOfSamples.url = GetRandomString("", 6);
            if (OmitPropName != "NumberOfSamples") uRLNumberOfSamples.NumberOfSamples = GetRandomInt(1, 1000);

            return uRLNumberOfSamples;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void URLNumberOfSamples_Testing()
        {

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
