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
    public partial class InputSummaryServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private InputSummaryService inputSummaryService { get; set; }
        #endregion Properties

        #region Constructors
        public InputSummaryServiceTest() : base()
        {
            //inputSummaryService = new InputSummaryService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private InputSummary GetFilledRandomInputSummary(string OmitPropName)
        {
            InputSummary inputSummary = new InputSummary();

            if (OmitPropName != "Error") inputSummary.Error = GetRandomString("", 20);
            if (OmitPropName != "Summary") inputSummary.Summary = GetRandomString("", 20);

            return inputSummary;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void InputSummary_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                InputSummaryService inputSummaryService = new InputSummaryService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                InputSummary inputSummary = GetFilledRandomInputSummary("");

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
