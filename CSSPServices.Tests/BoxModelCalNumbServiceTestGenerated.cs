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
    public partial class BoxModelCalNumbServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private BoxModelCalNumbService boxModelCalNumbService { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelCalNumbServiceTest() : base()
        {
            //boxModelCalNumbService = new BoxModelCalNumbService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private BoxModelCalNumb GetFilledRandomBoxModelCalNumb(string OmitPropName)
        {
            BoxModelCalNumb boxModelCalNumb = new BoxModelCalNumb();

            if (OmitPropName != "BoxModelResultType") boxModelCalNumb.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "CalLength_m") boxModelCalNumb.CalLength_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CalRadius_m") boxModelCalNumb.CalRadius_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CalSurface_m2") boxModelCalNumb.CalSurface_m2 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CalVolume_m3") boxModelCalNumb.CalVolume_m3 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CalWidth_m") boxModelCalNumb.CalWidth_m = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "FixLength") boxModelCalNumb.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelCalNumb.FixWidth = true;
            if (OmitPropName != "BoxModelResultTypeText") boxModelCalNumb.BoxModelResultTypeText = GetRandomString("", 5);

            return boxModelCalNumb;
        }
        #endregion Functions private
    }
}
