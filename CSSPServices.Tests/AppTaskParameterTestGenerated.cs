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
    public partial class AppTaskParameterTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int AppTaskParameterID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskParameterTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTaskParameter GetFilledRandomAppTaskParameter(string OmitPropName)
        {
            AppTaskParameterID += 1;

            AppTaskParameter appTaskParameter = new AppTaskParameter();

            if (OmitPropName != "Name") appTaskParameter.Name = GetRandomString("", 0);
            if (OmitPropName != "Value") appTaskParameter.Value = GetRandomString("", 0);

            return appTaskParameter;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AppTaskParameter_Testing()
        {
            SetupTestHelper(culture);
            AppTaskParameterService appTaskParameterService = new AppTaskParameterService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
