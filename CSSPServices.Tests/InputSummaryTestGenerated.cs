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
    public partial class InputSummaryTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int InputSummaryID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public InputSummaryTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private InputSummary GetFilledRandomInputSummary(string OmitPropName)
        {
            InputSummaryID += 1;

            InputSummary inputSummary = new InputSummary();

            if (OmitPropName != "Error") inputSummary.Error = GetRandomString("", 20);
            if (OmitPropName != "Summary") inputSummary.Summary = GetRandomString("", 20);

            return inputSummary;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void InputSummary_Testing()
        {
            SetupTestHelper(culture);
            InputSummaryService inputSummaryService = new InputSummaryService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            InputSummary inputSummary = GetFilledRandomInputSummary("");

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
