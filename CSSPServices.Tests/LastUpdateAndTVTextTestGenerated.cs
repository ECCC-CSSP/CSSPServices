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
    public partial class LastUpdateAndTVTextTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int LastUpdateAndTVTextID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndTVTextTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LastUpdateAndTVText GetFilledRandomLastUpdateAndTVText(string OmitPropName)
        {
            LastUpdateAndTVTextID += 1;

            LastUpdateAndTVText lastUpdateAndTVText = new LastUpdateAndTVText();

            if (OmitPropName != "Error") lastUpdateAndTVText.Error = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") lastUpdateAndTVText.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateDate_Local") lastUpdateAndTVText.LastUpdateDate_Local = GetRandomDateTime();
            if (OmitPropName != "TVText") lastUpdateAndTVText.TVText = GetRandomString("", 1);

            return lastUpdateAndTVText;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LastUpdateAndTVText_Testing()
        {
            SetupTestHelper(culture);
            LastUpdateAndTVTextService lastUpdateAndTVTextService = new LastUpdateAndTVTextService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
