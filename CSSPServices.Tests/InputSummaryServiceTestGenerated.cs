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

        #region Functions private
        private InputSummary GetFilledRandomInputSummary(string OmitPropName)
        {
            InputSummary inputSummary = new InputSummary();

            if (OmitPropName != "Summary") inputSummary.Summary = GetRandomString("", 20);

            return inputSummary;
        }
        #endregion Functions private
    }
}
