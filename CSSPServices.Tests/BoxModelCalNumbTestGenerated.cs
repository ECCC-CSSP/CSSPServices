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
        private BoxModelCalNumbService boxModelCalNumbService { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelCalNumbTest() : base()
        {
            boxModelCalNumbService = new BoxModelCalNumbService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModelCalNumb GetFilledRandomBoxModelCalNumb(string OmitPropName)
        {
            BoxModelCalNumb boxModelCalNumb = new BoxModelCalNumb();

            if (OmitPropName != "Error") boxModelCalNumb.Error = GetRandomString("", 5);
            if (OmitPropName != "BoxModelResultType") boxModelCalNumb.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "CalLength_m") boxModelCalNumb.CalLength_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CalRadius_m") boxModelCalNumb.CalRadius_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CalSurface_m2") boxModelCalNumb.CalSurface_m2 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CalVolume_m3") boxModelCalNumb.CalVolume_m3 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CalWidth_m") boxModelCalNumb.CalWidth_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "FixLength") boxModelCalNumb.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelCalNumb.FixWidth = true;

            return boxModelCalNumb;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void BoxModelCalNumb_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            BoxModelCalNumb boxModelCalNumb = GetFilledRandomBoxModelCalNumb("");

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
        #endregion Tests Generated
    }
}
