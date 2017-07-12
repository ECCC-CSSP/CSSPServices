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
    public partial class TVTextLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVTextLanguageID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVTextLanguageTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVTextLanguage GetFilledRandomTVTextLanguage(string OmitPropName)
        {
            TVTextLanguageID += 1;

            TVTextLanguage tvTextLanguage = new TVTextLanguage();

            if (OmitPropName != "TVText") tvTextLanguage.TVText = GetRandomString("", 20);
            if (OmitPropName != "Language") tvTextLanguage.Language = language;

            return tvTextLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVTextLanguage_Testing()
        {
            SetupTestHelper(culture);
            TVTextLanguageService tvTextLanguageService = new TVTextLanguageService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            TVTextLanguage tvTextLanguage = GetFilledRandomTVTextLanguage("");

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
