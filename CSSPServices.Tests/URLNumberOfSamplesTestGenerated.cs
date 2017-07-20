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
        private int URLNumberOfSamplesID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public URLNumberOfSamplesTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private URLNumberOfSamples GetFilledRandomURLNumberOfSamples(string OmitPropName)
        {
            URLNumberOfSamplesID += 1;

            URLNumberOfSamples uRLNumberOfSamples = new URLNumberOfSamples();

            if (OmitPropName != "url") uRLNumberOfSamples.url = GetRandomString("", 5);
            if (OmitPropName != "NumberOfSamples") uRLNumberOfSamples.NumberOfSamples = GetRandomInt(1, 1000);

            return uRLNumberOfSamples;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void URLNumberOfSamples_Testing()
        {
            SetupTestHelper(culture);
            URLNumberOfSamplesService uRLNumberOfSamplesService = new URLNumberOfSamplesService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
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
