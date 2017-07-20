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
    public partial class RTBStringPosTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int RTBStringPosID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public RTBStringPosTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private RTBStringPos GetFilledRandomRTBStringPos(string OmitPropName)
        {
            RTBStringPosID += 1;

            RTBStringPos rTBStringPos = new RTBStringPos();

            if (OmitPropName != "StartPos") rTBStringPos.StartPos = GetRandomInt(0, 10);
            if (OmitPropName != "EndPos") rTBStringPos.EndPos = GetRandomInt(0, 10);
            if (OmitPropName != "Text") rTBStringPos.Text = GetRandomString("", 20);
            if (OmitPropName != "TagText") rTBStringPos.TagText = GetRandomString("", 20);

            return rTBStringPos;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void RTBStringPos_Testing()
        {
            SetupTestHelper(culture);
            RTBStringPosService rTBStringPosService = new RTBStringPosService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            RTBStringPos rTBStringPos = GetFilledRandomRTBStringPos("");

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
