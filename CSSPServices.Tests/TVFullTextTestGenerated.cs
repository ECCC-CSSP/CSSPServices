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
        private int TVFullTextID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVFullTextTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVFullText GetFilledRandomTVFullText(string OmitPropName)
        {
            TVFullTextID += 1;

            TVFullText tvFullText = new TVFullText();

            if (OmitPropName != "TVPath") tvFullText.TVPath = GetRandomString("", 1);
            if (OmitPropName != "FullText") tvFullText.FullText = GetRandomString("", 1);

            return tvFullText;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVFullText_Testing()
        {
            SetupTestHelper(culture);
            TVFullTextService tvFullTextService = new TVFullTextService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
