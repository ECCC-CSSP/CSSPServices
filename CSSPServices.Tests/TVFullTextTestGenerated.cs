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
    public partial class TVFullTextTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVFullTextService tvFullTextService { get; set; }
        #endregion Properties

        #region Constructors
        public TVFullTextTest() : base()
        {
            tvFullTextService = new TVFullTextService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVFullText GetFilledRandomTVFullText(string OmitPropName)
        {
            TVFullText tvFullText = new TVFullText();

            if (OmitPropName != "TVPath") tvFullText.TVPath = GetRandomString("", 6);
            if (OmitPropName != "FullText") tvFullText.FullText = GetRandomString("", 6);

            return tvFullText;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVFullText_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVFullText tvFullText = GetFilledRandomTVFullText("");

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
