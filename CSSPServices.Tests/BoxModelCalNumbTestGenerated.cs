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
    public partial class BoxModelCalNumbTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int BoxModelCalNumbID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelCalNumbTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModelCalNumb GetFilledRandomBoxModelCalNumb(string OmitPropName)
        {
            BoxModelCalNumbID += 1;

            BoxModelCalNumb boxModelCalNumb = new BoxModelCalNumb();

            if (OmitPropName != "Error") boxModelCalNumb.Error = GetRandomString("", 5);
            if (OmitPropName != "BoxModelResultType") boxModelCalNumb.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "CalLength_m") boxModelCalNumb.CalLength_m = GetRandomFloat(0, 10);
            if (OmitPropName != "CalRadius_m") boxModelCalNumb.CalRadius_m = GetRandomFloat(0, 10);
            if (OmitPropName != "CalSurface_m2") boxModelCalNumb.CalSurface_m2 = GetRandomFloat(0, 10);
            if (OmitPropName != "CalVolume_m3") boxModelCalNumb.CalVolume_m3 = GetRandomFloat(0, 10);
            if (OmitPropName != "CalWidth_m") boxModelCalNumb.CalWidth_m = GetRandomFloat(0, 10);
            if (OmitPropName != "FixLength") boxModelCalNumb.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelCalNumb.FixWidth = true;

            return boxModelCalNumb;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void BoxModelCalNumb_Testing()
        {
            SetupTestHelper(culture);
            BoxModelCalNumbService boxModelCalNumbService = new BoxModelCalNumbService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            BoxModelCalNumb boxModelCalNumb = GetFilledRandomBoxModelCalNumb("");

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
