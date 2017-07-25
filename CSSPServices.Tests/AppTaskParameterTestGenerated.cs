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
        private AppTaskParameterService appTaskParameterService { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskParameterTest() : base()
        {
            appTaskParameterService = new AppTaskParameterService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTaskParameter GetFilledRandomAppTaskParameter(string OmitPropName)
        {
            AppTaskParameter appTaskParameter = new AppTaskParameter();

            if (OmitPropName != "Name") appTaskParameter.Name = GetRandomString("", 5);
            if (OmitPropName != "Value") appTaskParameter.Value = GetRandomString("", 5);

            return appTaskParameter;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AppTaskParameter_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            AppTaskParameter appTaskParameter = GetFilledRandomAppTaskParameter("");

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
